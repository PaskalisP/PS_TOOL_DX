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
Public Class GL_Accounts

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim PrintGrid As Integer = 0

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

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

    Private Sub GL_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GL_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub GL_Accounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.GL_ACCOUNTS_NEWGTableAdapter.Fill(Me.PSTOOLDataset.GL_ACCOUNTS_NEWG)
        Me.ALL_GL_ITEMS_PL_TableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_PL)
        Me.ALL_GL_ITEMS_BS_TableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_BS)

        Me.GL_ACCOUNTSTableAdapter.Fill(Me.PSTOOLDataset.GL_ACCOUNTS)
        'LOAD_NEWG_GL_ACCOUNTS()
        LOAD_GL_RANGES()

        AddHandler GL_ITEM_BS_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GL_ITEM_BS_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler GL_ITEM_PL_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GL_ITEM_PL_GridControl_EmbeddedNavigator_ButtonClick

        If EDP_USER = "Y" OrElse SUPER_USER = "Y" Then
            Me.NEWG_GL_Accounts_GridView.OptionsBehavior.Editable = True
        Else
            Me.NEWG_GL_Accounts_GridView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub GL_ITEM_BS_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ALL_GL_ITEMS_BSBindingSource.EndEdit()
                'If Me.AllContractsAccountsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.ALL_GL_ITEMS_BS_TableAdapter.Update(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_BS)
                    Me.ALL_GL_ITEMS_BS_TableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_BS)
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ALL_GL_ITEMS_BSBindingSource.CancelEdit()
                Me.AllContractsAccountsDataSet.RejectChanges()
                Me.ALL_GL_ITEMS_BS_TableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_BS)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub GL_ITEM_PL_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ALL_GL_ITEMS_PLBindingSource.EndEdit()
                'If Me.AllContractsAccountsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.ALL_GL_ITEMS_PL_TableAdapter.Update(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_PL)
                    Me.ALL_GL_ITEMS_PL_TableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_PL)
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ALL_GL_ITEMS_PLBindingSource.CancelEdit()
                Me.AllContractsAccountsDataSet.RejectChanges()
                Me.ALL_GL_ITEMS_PL_TableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_GL_ITEMS_PL)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub LOAD_GL_RANGES()
        Me.GridControl3.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [GL_ACC_RANGES] Order by [ID] asc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.GridControl3.DataSource = Nothing
                    Me.GridControl3.DataSource = objDataTable
                    Me.GridControl3.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub LOAD_NEWG_GL_ACCOUNTS()
        Me.GridControl3.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [GL_ACCOUNTS_NEWG] Order by [ID] asc"
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

    Private Sub GL_Accounts_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GL_Accounts_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GL_Accounts_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles GL_Accounts_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GL_Accounts_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles GL_Accounts_Print_Export_btn.Click
        If PrintGrid = 0 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 1 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)

        End If
        If PrintGrid = 2 Then
            If Not GL_ITEM_BS_GridControl.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 3 Then
            If Not GL_ITEM_PL_GridControl.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink4.CreateDocument()
            PrintableComponentLink4.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 4 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink5.CreateDocument()
            PrintableComponentLink5.ShowPreview()
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
        Dim reportfooter As String = "ALL GENERAL LEDGER ACCOUNTS (OCBS)"
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
        Dim reportfooter As String = "GENERAL LEDGER ACCOUNTS RANGES"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "GL ITEMS - BALANCE SHEET"
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
        Dim reportfooter As String = "GL ITEMS - PROFIT/LOSS SHEET"
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

    Private Sub PrintableComponentLink5_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalHeaderArea
        Dim reportfooter As String = "ALL GENERAL LEDGER ACCOUNTS (NGS)"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL GENERAL LEDGER ACCOUNTS (NGS)" Then
            PrintGrid = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL GENERAL LEDGER ACCOUNTS (OCBS)" Then
            PrintGrid = 4
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "GENERAL LEDGER ACCOUNTS RANGE" Then
            PrintGrid = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "GL ITEMS (Balance Sheet)" Then
            PrintGrid = 2
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "GL ITEMS (Profit/Loss Sheet)" Then
            PrintGrid = 3
        End If
    End Sub

    Private Sub GL_ACC_Ranges_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GL_ACC_Ranges_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GL_ACC_Ranges_GridView_ShownEditor(sender As Object, e As EventArgs) Handles GL_ACC_Ranges_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GL_Items_BS_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GL_Items_BS_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GL_Items_BS_GridView_ShownEditor(sender As Object, e As EventArgs) Handles GL_Items_BS_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GL_Items_PL_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GL_Items_PL_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GL_Items_PL_GridView_ShownEditor(sender As Object, e As EventArgs) Handles GL_Items_PL_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub NEWG_GL_Accounts_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NEWG_GL_Accounts_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub NEWG_GL_Accounts_GridView_ShownEditor(sender As Object, e As EventArgs) Handles NEWG_GL_Accounts_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim view As GridView = Me.NEWG_GL_Accounts_GridView
        Try


            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                
                Dim focusedRow As Integer = view.FocusedRowHandle
                view.PostEditor()
                Me.Validate()
                Me.GL_ACCOUNTS_NEWGBindingSource.EndEdit()

                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                

                Me.GridControl3.BeginUpdate()
                Me.GL_ACCOUNTS_NEWGTableAdapter.Fill(Me.PSTOOLDataset.GL_ACCOUNTS_NEWG)
                Me.NEWG_GL_Accounts_GridView.RefreshData()
                Me.GridControl3.EndUpdate()
                view.FocusedRowHandle = focusedRow


            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class