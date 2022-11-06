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
Imports DevExpress.XtraLayout.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Public Class MappingProfitLossGL

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim IdRowValue As String = "" 'ID Row Value for deletion
    Dim IDNrRowValue As Integer ' For PARAMETER deletion
    Dim GL_BaseView As DevExpress.XtraGrid.Views.Grid.GridView '  MasterView
    Dim OCBSAccounts_BaseView As DevExpress.XtraGrid.Views.Grid.GridView 'SecondView
    Dim row As System.Data.DataRow
    Dim GL_Account_Name As String = Nothing
    Dim QueryText As String = Nothing

    Dim DetailsViewCaption As String = Nothing

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


    Private Sub PROFIT_and_LOSS_GL_ITEMSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.PROFIT_and_LOSS_GL_ITEMSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Function FindRowHandleByRowObject(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal row As Object) As Integer
        If Not row Is Nothing Then
            For i = 0 To view.DataRowCount - 1
                If row.Equals(view.GetRow(i)) Then
                    Return i
                End If
            Next
        End If
        Return DevExpress.XtraGrid.GridControl.InvalidRowHandle

    End Function

    Private Sub MappingProfitLossGL_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        Me.GL_ACCOUNTSTableAdapter.Fill(Me.PSTOOLDataset.GL_ACCOUNTS)
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.PROFIT_and_LOSS_MAPPINGTableAdapter.Fill(Me.BalancesDataset.PROFIT_and_LOSS_MAPPING)
        Me.PROFIT_and_LOSS_GL_ITEMSTableAdapter.Fill(Me.BalancesDataset.PROFIT_and_LOSS_GL_ITEMS)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
      
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.PROFIT_and_LOSS_MAPPINGBindingSource.EndEdit()
                Me.PROFIT_and_LOSS_GL_ITEMSBindingSource.EndEdit()
                If Me.BalancesDataset.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)
                        Me.PROFIT_and_LOSS_MAPPINGTableAdapter.Fill(Me.BalancesDataset.PROFIT_and_LOSS_MAPPING)
                        Me.PROFIT_and_LOSS_GL_ITEMSTableAdapter.Fill(Me.BalancesDataset.PROFIT_and_LOSS_GL_ITEMS)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If


        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'Remove PARAMETER NAMES
            If Me.GridControl1.FocusedView.Name = "PL_GLitems_View" Then
                Dim row As System.Data.DataRow = PL_GLitems_View.GetDataRow(PL_GLitems_View.FocusedRowHandle)
                Dim h As Integer = FindRowHandleByRowObject(PL_GLitems_View, row)
                Dim cellvalue As String = row(1)
                If MessageBox.Show("Should the GENERAL LEDGER NR. " & cellvalue & " and all its mapped GL Accounts be deleted ?", "DELETE GENERAL LEDGER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                    cmd.Connection.Open()
                    'Delete Mapped GL Accounts
                    cmd.CommandText = "DELETE FROM [PROFIT and LOSS MAPPING] where [GL_ITEM_Mapped]='" & cellvalue & "'"
                    cmd.ExecuteNonQuery()
                    'Delete GL Item Nr.
                    cmd.CommandText = "DELETE  FROM [PROFIT and LOSS GL ITEMS] where [GL_ITEM_NR]='" & cellvalue & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.PL_GLitems_View.DeleteSelectedRows()
                    GridControl1.Update()
                Else
                    e.Handled = True
                End If
            ElseIf Me.GridControl1.FocusedView.Name = "MappedGLaccounts_BaseView" Then
                If MessageBox.Show("Should the mapped GL Account Nr. " & IdRowValue & " be deleted ? ", "DELETE MAPPED GL ACCOUNT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim GLAccountDelete As BalancesDataset.PROFIT_and_LOSS_MAPPINGRow
                    GLAccountDelete = BalancesDataset.PROFIT_and_LOSS_MAPPING.FindByGL_ACC_Nr(IdRowValue)
                    GLAccountDelete.Delete()
                    MappedGLaccounts_BaseView.DeleteSelectedRows()
                    GridControl1.Update()
                    Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)
                    GridControl1.Update()
                Else
                    e.Handled = True
                End If
            End If
            Me.PROFIT_and_LOSS_MAPPINGTableAdapter.Fill(Me.BalancesDataset.PROFIT_and_LOSS_MAPPING)
            Me.PROFIT_and_LOSS_GL_ITEMSTableAdapter.Fill(Me.BalancesDataset.PROFIT_and_LOSS_GL_ITEMS)
        End If

    End Sub

    Private Sub PL_GLitems_View_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles PL_GLitems_View.FocusedRowChanged
        If Me.PL_GLitems_View.IsNewItemRow(Me.PL_GLitems_View.FocusedRowHandle) = True Then
            Me.PL_GLitems_View.Columns.ColumnByFieldName("GL_ITEM_NR").OptionsColumn.ReadOnly = False
        Else
            Me.PL_GLitems_View.Columns.ColumnByFieldName("GL_ITEM_NR").OptionsColumn.ReadOnly = True
        End If
    End Sub

    Private Sub MappedGLaccounts_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles MappedGLaccounts_BaseView.CellValueChanged
        If e.Column.Caption = "GL Account Nr." Then
            
            Dim view As GridView = DirectCast(sender, GridView)
            view.SetFocusedRowCellValue(colGL_ACC_Name, GL_Account_Name)
        End If

    End Sub

    Private Sub MappedGLaccounts_BaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles MappedGLaccounts_BaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.MappedGLaccounts_BaseView.Columns.ColumnByFieldName("GL_ACC_Nr").OptionsColumn.ReadOnly = False
        Else
            Me.MappedGLaccounts_BaseView.Columns.ColumnByFieldName("GL_ACC_Nr").OptionsColumn.ReadOnly = True
        End If
    End Sub

    Private Sub MappedGLaccounts_BaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles MappedGLaccounts_BaseView.RowClick

        Dim view As GridView = DirectCast(sender, GridView)
        If view.IsNewItemRow(e.RowHandle) = False AndAlso view.IsFilterRow(e.RowHandle) = False Then
            IdRowValue = view.GetFocusedRowCellValue("GL_ACC_Nr").ToString
        End If


    End Sub

    Private Sub RepositoryItemGridLookUpEditGLACCOUNTS_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEditGLACCOUNTS.EditValueChanged
        Dim edit As GridLookUpEdit = TryCast(sender, GridLookUpEdit)
        Dim row As DataRowView = TryCast(edit.Properties.GetRowByKeyValue(edit.EditValue), DataRowView)
        GL_Account_Name = row.Item("GL_AC_Name")
       

    End Sub

    Private Sub PL_GLitems_View_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles PL_GLitems_View.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "PL_GLitems_View" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "Mapped General Ledger Accounts for GL ITEM: " & view.GetFocusedRowCellValue("GL_ITEM_NR").ToString & " (" & view.GetFocusedRowCellValue("GL_ITEM_NAME").ToString & ")"
            Me.MappedGLaccounts_BaseView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub PL_GLitems_View_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles PL_GLitems_View.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "PL_GLitems_View" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "Mapped General Ledger Accounts for GL ITEM: " & view.GetFocusedRowCellValue("GL_ITEM_NR").ToString & " (" & view.GetFocusedRowCellValue("GL_ITEM_NAME").ToString & ")"
            Me.MappedGLaccounts_BaseView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub PL_GLitems_View_RowClick(sender As Object, e As RowClickEventArgs) Handles PL_GLitems_View.RowClick
        If Me.GridControl1.FocusedView.Name = "PL_GLitems_View" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "Mapped General Ledger Accounts for GL ITEM: " & view.GetFocusedRowCellValue("GL_ITEM_NR").ToString & " (" & view.GetFocusedRowCellValue("GL_ITEM_NAME").ToString & ")"
            Me.MappedGLaccounts_BaseView.ViewCaption = DetailsViewCaption
        End If
    End Sub


    Private Sub PL_GLitems_View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PL_GLitems_View.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub PL_GLitems_View_ShownEditor(sender As Object, e As EventArgs) Handles PL_GLitems_View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub MappedGLaccounts_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MappedGLaccounts_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub MappedGLaccounts_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles MappedGLaccounts_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
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
        Dim reportfooter As String = "MAPPING OF THE PROFIT AND LOSS GENERAL LEDGER ITEMS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
End Class