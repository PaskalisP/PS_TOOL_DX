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
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Spreadsheet

Public Class UserDirectoryPermissions

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim CVA_ExcelFileName As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim ActiveTabGroupUserDetail As Double = 0
    Dim ActiveTabGroupUserTOTALS As Double = 0


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

    Private Sub ActiveDirectoryUsersBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ActiveDirectoryUsersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.UserSystemsPermissionsDataSet)

    End Sub

    Private Sub UserDirectoryPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Me.ActiveDirectoryUsersBankSystemsPermissionsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissionsALL)
        Me.ActiveDirectoryUsersBankSystemsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsALL)
        Me.ActiveDirectoryGroupsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroupsALL)

        Me.ActiveDirectoryUsersBankSystemsPermissionsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissions)
        Me.ActiveDirectoryUsersBankSystemsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystems)
        Me.ActiveDirectoryGroupsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroups)
        Me.ActiveDirectoryUsersTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsers)

        USER_PERSONAL_OR_NONE()

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes

        If e.Button.Tag.ToString = "AddNewUser" Then
            Try
                Me.LayoutControl2.Visible = False
                Me.XtraTabControl1.Visible = False
                Me.UserLoginName_TextEdit.Focus()

                'Get User info for PS TOOL
                Me.PS_UserLoginName_ComboBoxEdit.Properties.Items.Clear()
                'Me.QueryText = "SELECT [Member_Name] FROM [ActiveDirectoryUsers] where [Member_Name] not in (SELECT dbo.getStringPartByDelimeter(name,'\',2) from sys.database_principals where type='U' and name like 'CCB%') and [AccountStatus] in ('*ENABLED') and NonPersonalUser=0"
                Me.QueryText = "SELECT [Member_Name] FROM [ActiveDirectoryUsers] where [Member_Name] not in (SELECT dbo.getStringPartByDelimeter(loginname,'\',2) from master..syslogins where loginname like 'CCB%') and [AccountStatus] in ('*ENABLED') and NonPersonalUser=0"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    If dt.Rows.Count > 0 Then
                        Me.PS_UserLoginName_ComboBoxEdit.Properties.Items.Add(row("Member_Name"))
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    Me.PS_UserLoginName_ComboBoxEdit.Text = dt.Rows.Item(0).Item("Member_Name")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If


    End Sub


    Private Sub USER_PERSONAL_OR_NONE()
        If Me.NonPersonalUser_CheckEdit.CheckState = CheckState.Checked Then
            Me.NonPersonalUser_CheckEdit.Text = "None Personal User"
            Me.NonPersonalUser_CheckEdit.BackColor = Color.Red
            Me.NonPersonalUser_CheckEdit.ForeColor = Color.White

        ElseIf Me.NonPersonalUser_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.NonPersonalUser_CheckEdit.Text = "Personal User"
            Me.NonPersonalUser_CheckEdit.BackColor = Color.Green
            Me.NonPersonalUser_CheckEdit.ForeColor = Color.White

        End If
    End Sub

    Private Sub UserDirectoryPermissions_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 AndAlso Me.XtraTabControl1.Visible = True Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Users and Permissions....")
            Me.ActiveDirectoryUsersBankSystemsPermissionsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissionsALL)
            Me.ActiveDirectoryUsersBankSystemsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsALL)
            Me.ActiveDirectoryGroupsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroupsALL)

            Me.ActiveDirectoryUsersBankSystemsPermissionsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissions)
            Me.ActiveDirectoryUsersBankSystemsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystems)
            Me.ActiveDirectoryGroupsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroups)
            Me.ActiveDirectoryUsersTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsers)

            USER_PERSONAL_OR_NONE()
            SplashScreenManager.CloseForm(False)

        End If

        If e.KeyCode = Keys.Escape Then

            Me.DisplayAllUsers_btn.PerformClick()

        End If
    End Sub

#Region "GRIDVIEWS-DETAILS"

    Private Sub SaveUserData_btn_Click(sender As Object, e As EventArgs) Handles SaveUserData_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Saving User Details...Please wait...")
            Threading.Thread.Sleep(1000)
            Me.ActiveDirectoryUsersBindingSource.EndEdit()
            Me.ActiveDirectoryUsersBankSystemsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.UserSystemsPermissionsDataSet)
            USER_PERSONAL_OR_NONE()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub NonPersonalUser_CheckEdit_CheckStateChanged(sender As Object, e As EventArgs) Handles NonPersonalUser_CheckEdit.CheckStateChanged
        Try
            Me.ActiveDirectoryUsersBindingSource.EndEdit()
            Me.ActiveDirectoryUsersBankSystemsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.UserSystemsPermissionsDataSet)
            USER_PERSONAL_OR_NONE()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub All_User_Permissions_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_User_Permissions_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub All_User_Permissions_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_User_Permissions_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BankSystemsUserID_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BankSystemsUserID_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BankSystemsUserID_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BankSystemsUserID_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub UserPermissions_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UserPermissions_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub UserPermissions_GridView_ShownEditor(sender As Object, e As EventArgs) Handles UserPermissions_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ActiveDirectoryGroups_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActiveDirectoryGroups_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ActiveDirectoryGroups_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles ActiveDirectoryGroups_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_UserDetail_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_UserDetail_Gridview_btn.Click
        Dim result As Integer = MessageBox.Show("Should all User Details be printed/Exported?", "Print-Export all User Details", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result = DialogResult.Yes Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Me.LayoutControlItem2.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem4.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            Me.LayoutControlItem2.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem4.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
            SplashScreenManager.CloseForm(False)
        ElseIf result = DialogResult.No Then
            If ActiveTabGroupUserDetail = 0 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink2.CreateDocument()
                PrintableComponentLink2.ShowPreview()
                SplashScreenManager.CloseForm(False)
            ElseIf ActiveTabGroupUserDetail = 1 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink3.CreateDocument()
                PrintableComponentLink3.ShowPreview()
                SplashScreenManager.CloseForm(False)
            ElseIf ActiveTabGroupUserDetail = 2 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink4.CreateDocument()
                PrintableComponentLink4.ShowPreview()
                SplashScreenManager.CloseForm(False)
            End If
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
        Dim reportfooter As String = "Active Directory User Groups - Systems Permissions for User: " & Me.UserName_TextEdit.Text
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
        Dim reportfooter As String = "Active Directory User Groups for User: " & Me.UserName_TextEdit.Text
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

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "User ID and Permissions in all Bank Systems for User: " & Me.UserName_TextEdit.Text
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

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "All User Permissions for User: " & Me.UserName_TextEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Active Directory User Groups" Then
            ActiveTabGroupUserDetail = 0

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "User ID and Permissions in all Bank Systems" Then
            ActiveTabGroupUserDetail = 1

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "All User Permissions" Then
            ActiveTabGroupUserDetail = 2

        End If
    End Sub




    Private Sub ShowDetails_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowDetails_ToolStripMenuItem.Click
        'Dim view As GridView = DirectCast(sender, GridView)
        'If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        Try
            Me.ActiveDirectoryUsersBankSystemsPermissionsSpecificUser_TableAdapter.FillbyUserMemberName(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissionsSpecificUser, Me.UserName_TextEdit.Text)
            Me.LayoutControl2.Visible = False
            USER_PERSONAL_OR_NONE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'End If

    End Sub




    Private Sub DisplayAllUsers_btn_Click(sender As Object, e As EventArgs) Handles DisplayAllUsers_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        Me.ActiveDirectoryUsersBankSystemsPermissionsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissions)
        Me.ActiveDirectoryUsersBankSystemsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystems)
        Me.ActiveDirectoryGroupsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroups)
        Me.ActiveDirectoryUsersTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsers)
        Me.ActiveDirectoryUsersBankSystemsPermissionsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissionsALL)
        Me.ActiveDirectoryUsersBankSystemsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsALL)
        Me.ActiveDirectoryGroupsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroupsALL)
        Me.LayoutControl2.Visible = True
        SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "GRIDVIEWS-BASIC"

   

    Private Sub RepositoryItemCheckEdit1_CheckStateChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckStateChanged
        Try
           
            Me.ActiveDirectoryUsersBindingSource.EndEdit()
            Me.ActiveDirectoryUsersTableAdapter.Update(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsers)
            Me.TableAdapterManager.UpdateAll(Me.UserSystemsPermissionsDataSet)
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Users and Permissions....")
            Me.ActiveDirectoryUsersBankSystemsPermissionsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissionsALL)
            Me.ActiveDirectoryUsersBankSystemsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsALL)
            Me.ActiveDirectoryGroupsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroupsALL)

            Me.ActiveDirectoryUsersBankSystemsPermissionsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissions)
            Me.ActiveDirectoryUsersBankSystemsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystems)
            Me.ActiveDirectoryGroupsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroups)
            Me.ActiveDirectoryUsersTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsers)


            SplashScreenManager.CloseForm(False)



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim CHECK As String = Me.Users_TOTAL_GridView.GetFocusedRowCellValue(colNonPersonalUser)
        If CHECK = "True" Then
            Me.Users_TOTAL_GridView.SetRowCellValue(Me.Users_TOTAL_GridView.FocusedRowHandle, colNonPersonalUser, 0)
        ElseIf CHECK = "False" Then
            Me.Users_TOTAL_GridView.SetRowCellValue(Me.Users_TOTAL_GridView.FocusedRowHandle, colNonPersonalUser, 1)
        End If

    End Sub

   

    Private Sub Users_TOTAL_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Users_TOTAL_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Users_TOTAL_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Users_TOTAL_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub User_Groups_TOTAL_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles User_Groups_TOTAL_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub User_Groups_TOTAL_GridView_ShownEditor(sender As Object, e As EventArgs) Handles User_Groups_TOTAL_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Users_Names_TOTALS_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles Users_Names_TOTALS_GridView.CellValueChanged
        Try

            Dim view As GridView = CType(sender, GridView)
            Dim ID As String = view.GetRowCellValue(view.FocusedRowHandle, GridColumn30).ToString
            Dim UserID As String = view.GetRowCellValue(view.FocusedRowHandle, GridColumn32).ToString
            'MsgBox(ID & "   " & UserID)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "UPDATE [ActiveDirectoryUsersBankSystems] set [UserID]='" & UserID & "' where [ID]='" & ID & "'"
            cmd.ExecuteNonQuery()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.Users_Names_TOTALS_GridView.HideEditor()
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub



    Private Sub Users_Names_TOTALS_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Users_Names_TOTALS_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Users_Names_TOTALS_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Users_Names_TOTALS_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Users_Permissions_TOTAL_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Users_Permissions_TOTAL_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Users_Permissions_TOTAL_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Users_Permissions_TOTAL_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ALL_User_Groups_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ALL_User_Groups_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ALL_User_Groups_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ALL_User_Groups_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ALL_User_BankSystems_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ALL_User_BankSystems_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ALL_User_BankSystems_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ALL_User_BankSystems_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ALL_User_SystemsPermissions_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ALL_User_SystemsPermissions_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ALL_User_SystemsPermissions_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ALL_User_SystemsPermissions_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub RepositoryItemTextEdit4_EditValueChanged(sender As Object, e As EventArgs)
        If Me.GridControl2.MainView Is Users_Names_TOTALS_GridView AndAlso Users_Names_TOTALS_GridView.IsFilterRow(Users_Names_TOTALS_GridView.FocusedRowHandle) = False Then
            Me.Users_Names_TOTALS_GridView.PostEditor()

        End If



    End Sub

    Private Sub Print_Export_User_TOTALS_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_User_TOTALS_Gridview_btn.Click
        Dim result As Integer = MessageBox.Show("Should all User Details be printed/Exported?", "Print-Export all User Details", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result = DialogResult.Yes Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Me.LayoutControlItem8.Visibility = LayoutVisibility.Never
            'Me.LayoutControlItem6.Visibility = LayoutVisibility.Never
            PrintableComponentLink5.CreateDocument()
            PrintableComponentLink5.ShowPreview()
            Me.LayoutControlItem8.Visibility = LayoutVisibility.Always
            'Me.LayoutControlItem6.Visibility = LayoutVisibility.Always
            SplashScreenManager.CloseForm(False)
        ElseIf result = DialogResult.No Then
            If ActiveTabGroupUserTOTALS = 0 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink6.CreateDocument()
                PrintableComponentLink6.ShowPreview()
                SplashScreenManager.CloseForm(False)
            ElseIf ActiveTabGroupUserTOTALS = 1 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink7.CreateDocument()
                PrintableComponentLink7.ShowPreview()
                SplashScreenManager.CloseForm(False)
            ElseIf ActiveTabGroupUserTOTALS = 2 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink8.CreateDocument()
                PrintableComponentLink8.ShowPreview()
                SplashScreenManager.CloseForm(False)
            ElseIf ActiveTabGroupUserTOTALS = 3 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink9.CreateDocument()
                PrintableComponentLink9.ShowPreview()
                SplashScreenManager.CloseForm(False)
            End If
        End If
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

    Private Sub PrintableComponentLink5_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalHeaderArea
        Dim reportfooter As String = "Active Directory User Groups - Systems Permissions for All Users"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub PrintableComponentLink6_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalHeaderArea
        Dim reportfooter As String = "Active Directory Users - Systems - Permissions - Details"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub PrintableComponentLink7_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink7.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink7_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink7.CreateMarginalHeaderArea
        Dim reportfooter As String = "Active Directory - All User Groups"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink8_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink8.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink8_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink8.CreateMarginalHeaderArea
        Dim reportfooter As String = "All User - Bank Systems"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub PrintableComponentLink9_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink9.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink9_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink9.CreateMarginalHeaderArea
        Dim reportfooter As String = "All User - Systems permissions"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub TabbedControlGroup2_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup2.SelectedPageChanged
        If Me.TabbedControlGroup2.SelectedTabPage.Text = "Active Directory Users - Systems - Permissions - Details" Then
            ActiveTabGroupUserTOTALS = 0

        ElseIf Me.TabbedControlGroup2.SelectedTabPage.Text = "Active Directory - All User Groups" Then
            ActiveTabGroupUserTOTALS = 1

        ElseIf Me.TabbedControlGroup2.SelectedTabPage.Text = "All User - Bank Systems" Then
            ActiveTabGroupUserTOTALS = 2

        ElseIf Me.TabbedControlGroup2.SelectedTabPage.Text = "All User - Systems permissions" Then
            ActiveTabGroupUserTOTALS = 3

        End If
    End Sub

#End Region

#Region "ADD NEW USER"

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.UserLoginName_TextEdit.Text = ""
        Me.UserTitle_ComboBoxEdit.Text = ""
        Me.UserSurname_TextEdit.Text = ""
        Me.UserNameNew_TextEdit.Text = ""
        'Set all checkboxes to unchecked
        For Each ctrl As Control In Me.GroupControl2.Controls
            If TypeOf ctrl Is DevExpress.XtraEditors.CheckEdit Then
                DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).CheckState = CheckState.Unchecked
                DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).Enabled = True
            End If
        Next
        Me.XtraTabControl1.Visible = True
        Me.LayoutControl2.Visible = True

    End Sub

    Private Sub AddNewUser_btn_Click(sender As Object, e As EventArgs) Handles AddNewUser_btn.Click
        If Me.UserLoginName_TextEdit.Text <> "" AndAlso Me.UserTitle_ComboBoxEdit.Text <> "" AndAlso Me.UserSurname_TextEdit.Text <> "" AndAlso Me.UserNameNew_TextEdit.Text <> "" Then
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Select Count([ID]) from [ActiveDirectoryUsers] where UPPER([Member_Name])='" & Me.UserLoginName_TextEdit.Text.ToUpper & "'"
            Dim n As Double = cmd.ExecuteScalar
            If n > 0 Then
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show("User Login Name: " & Me.UserLoginName_TextEdit.Text & " allready exists in the Database! Please check your entry!", "USER LOGIN NAME EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.UserLoginName_TextEdit.Focus()
                Exit Sub
            ElseIf n = 0 Then
                cmd.CommandText = "INSERT INTO [dbo].[ActiveDirectoryUsers]([Title],[Surname],[Name],[Member_Name],[AccountStatus],[NonPersonalUser]) Values ('" & Me.UserTitle_ComboBoxEdit.Text & "','" & Me.UserSurname_TextEdit.Text & "','" & Me.UserNameNew_TextEdit.Text & "','" & Me.UserLoginName_TextEdit.Text & "','*ENABLED',0)"
                cmd.ExecuteNonQuery()
                Me.QueryText = "Select * from [ActiveDirectoryUsers] where [ID] not in (Select [Id_ActiveDirectoryUser] from [ActiveDirectoryUsersBankSystems])"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ID As Integer = dt.Rows.Item(i).Item("ID")
                    cmd.CommandText = "INSERT INTO [ActiveDirectoryUsersBankSystems] ([System],[Id_ActiveDirectoryUser]) Select [PARAMETER2]," & ID & " from [PARAMETER] where [PARAMETER1]='BankSystem' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='BANK_SYSTEMS' order by ID asc"
                    cmd.ExecuteNonQuery()
                Next
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.XtraTabControl1.Visible = True
                Me.LayoutControl2.Visible = True
                Me.ActiveDirectoryUsersBankSystemsPermissionsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissionsALL)
                Me.ActiveDirectoryUsersBankSystemsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsALL)
                Me.ActiveDirectoryGroupsALL_TableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroupsALL)

                Me.ActiveDirectoryUsersBankSystemsPermissionsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystemsPermissions)
                Me.ActiveDirectoryUsersBankSystemsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsersBankSystems)
                Me.ActiveDirectoryGroupsTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryGroups)
                Me.ActiveDirectoryUsersTableAdapter.Fill(Me.UserSystemsPermissionsDataSet.ActiveDirectoryUsers)

                USER_PERSONAL_OR_NONE()

                MessageBox.Show("User Login Name: " & Me.UserLoginName_TextEdit.Text & " inserted to the Database!", "USER LOGIN NAME INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("User Data missing! Please input data in all Fields!", "USER DATA MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub

#End Region

   
   
#Region "ADD NEW PSTOOL USER"
    Private Sub SuperUser_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles SuperUser_CheckEdit.CheckedChanged
        If Me.SuperUser_CheckEdit.CheckState = CheckState.Checked Then
            For Each ctrl As Control In Me.GroupControl2.Controls
                If TypeOf ctrl Is DevExpress.XtraEditors.CheckEdit AndAlso ctrl.Name <> "SuperUser_CheckEdit" Then
                    DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).CheckState = CheckState.Unchecked
                    DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).Enabled = False
                End If
            Next
        End If
        If Me.SuperUser_CheckEdit.CheckState = CheckState.Unchecked Then
            For Each ctrl As Control In Me.GroupControl2.Controls
                If TypeOf ctrl Is DevExpress.XtraEditors.CheckEdit AndAlso ctrl.Name <> "SuperUser_CheckEdit" Then
                    DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).CheckState = CheckState.Unchecked
                    DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub AddNewPSTOOL_User_btn_Click(sender As Object, e As EventArgs) Handles AddNewPSTOOL_User_btn.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Try
            If Me.PS_UserLoginName_ComboBoxEdit.Text <> "" Then
                If Me.SuperUser_CheckEdit.CheckState = CheckState.Checked Then
                    If MessageBox.Show("Should the Windows User: " & Me.PS_UserLoginName_ComboBoxEdit.Text & " be added in the PS TOOL Users as SUPER USER?", "ADD NEW PS TOOL USER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        'FOR SQL SERVER SPECIFIC
                        cmd.CommandText = "CREATE LOGIN [CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "] FROM WINDOWS WITH DEFAULT_DATABASE=[PS TOOL DX Live], DEFAULT_LANGUAGE=[us_english]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC master..sp_addsrvrolemember @loginame = N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "', @rolename = N'serveradmin'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC master..sp_addsrvrolemember @loginame = N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "', @rolename = N'sysadmin'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "USE [PS TOOL DX Live]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC sp_addrolemember N'db_datareader', N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC sp_addrolemember N'db_datawriter', N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "'"
                        cmd.ExecuteNonQuery()
                        'PS TOOL SPECIFIC
                        cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='SUPERUSER' and [IdABTEILUNGSCODE_NAME]='EDP'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','SUPERUSER','EDP')"
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("User: " & Me.PS_UserLoginName_ComboBoxEdit.Text & " has being added in PS TOOL Users", "NEW PS TOOL USER ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                End If
                If ACC_CheckEdit.CheckState = CheckState.Checked OrElse
               CREDIT_CheckEdit.CheckState = CheckState.Checked OrElse
               EAEG_CheckEdit.CheckState = CheckState.Checked OrElse
               EDP_CheckEdit.CheckState = CheckState.Checked OrElse
               FOREIGN_CheckEdit.CheckState = CheckState.Checked OrElse
               MNGM_CheckEdit.CheckState = CheckState.Checked OrElse
               MLDW_CheckEdit.CheckState = CheckState.Checked OrElse
               RC_CheckEdit.CheckState = CheckState.Checked OrElse
               SEC_CheckEdit.CheckState = CheckState.Checked OrElse
               TRES_CheckEdit.CheckState = CheckState.Checked Then
                    If MessageBox.Show("Should the Windows User: " & Me.PS_UserLoginName_ComboBoxEdit.Text & " be added in the PS TOOL Users for specific Departments?", "ADD NEW PS TOOL USER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        'FOR SQL SERVER SPECIFIC
                        cmd.CommandText = "CREATE LOGIN [CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "] FROM WINDOWS WITH DEFAULT_DATABASE=[PS TOOL DX Live], DEFAULT_LANGUAGE=[us_english]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC master..sp_addsrvrolemember @loginame = N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "', @rolename = N'serveradmin'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC master..sp_addsrvrolemember @loginame = N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "', @rolename = N'sysadmin'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "USE [PS TOOL DX Live]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC sp_addrolemember N'db_datareader', N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "EXEC sp_addrolemember N'db_datawriter', N'CCB-FRANKFURT\" & PS_UserLoginName_ComboBoxEdit.Text & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='SUPERUSER' and [IdABTEILUNGSCODE_NAME]='EDP'"
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("User: " & Me.PS_UserLoginName_ComboBoxEdit.Text & " has being added in PS TOOL Users", "NEW PS TOOL USER ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                End If

                If ACC_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='ACCOUNTING_USER' and [IdABTEILUNGSCODE_NAME]='ACCOUNTING'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','ACCOUNTING_USER','ACCOUNTING')"
                    cmd.ExecuteNonQuery()
                End If
                If CREDIT_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='CREDIT_USERS' and [IdABTEILUNGSCODE_NAME]='CREDIT'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','CREDIT_USERS','CREDIT')"
                    cmd.ExecuteNonQuery()
                End If
                If EAEG_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='EAEG_USERS' and [IdABTEILUNGSCODE_NAME]='EAEG'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','EAEG_USERS','EAEG')"
                    cmd.ExecuteNonQuery()
                End If
                If EDP_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='EDP_USERS' and [IdABTEILUNGSCODE_NAME]='EDP'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','EDP_USERS','EDP')"
                    cmd.ExecuteNonQuery()
                End If
                If FOREIGN_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [IdABTEILUNGSCODE_NAME]='FOREIGN'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','FOREIGN_USER','FOREIGN')"
                    cmd.ExecuteNonQuery()
                End If
                If MNGM_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='MANAGEMENTUSERS' and [IdABTEILUNGSCODE_NAME]='MANAGEMENT'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','MANAGEMENTUSERS','MANAGEMENT')"
                    cmd.ExecuteNonQuery()
                End If
                If MLDW_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='MELDEWESEN_USER' and [IdABTEILUNGSCODE_NAME]='MELDEWESEN'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','MELDEWESEN_USER','MELDEWESEN')"
                    cmd.ExecuteNonQuery()
                End If
                If RC_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='RISKCONTROLLING_USER' and [IdABTEILUNGSCODE_NAME]='RISK CONTROLLING'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','RISKCONTROLLING_USER','RISK CONTROLLING')"
                    cmd.ExecuteNonQuery()
                End If
                If SEC_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='SECURITIES_USER' and [IdABTEILUNGSCODE_NAME]='SECURITIES'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','SECURITIES_USER','SECURITIES')"
                    cmd.ExecuteNonQuery()
                End If
                If TRES_CheckEdit.CheckState = CheckState.Checked Then
                    'PS TOOL SPECIFIC
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [PARAMETER2]='" & PS_UserLoginName_ComboBoxEdit.Text & "' and [IdABTEILUNGSPARAMETER]='TREASURY_USERS' and [IdABTEILUNGSCODE_NAME]='TREASURY'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [dbo].[PARAMETER]([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[IdABTEILUNGSPARAMETER],[IdABTEILUNGSCODE_NAME])VALUES ((Select Surname + '  ' + Name from [ActiveDirectoryUsers] where Member_Name='" & PS_UserLoginName_ComboBoxEdit.Text & "'),'" & PS_UserLoginName_ComboBoxEdit.Text & "','Y','TREASURY_USERS','TREASURY')"
                    cmd.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on add new PS TOOL User", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
        'Set all checkboxes to unchecked
        For Each ctrl As Control In Me.GroupControl2.Controls
            If TypeOf ctrl Is DevExpress.XtraEditors.CheckEdit Then
                DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).CheckState = CheckState.Unchecked
                DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).Enabled = True
            End If
        Next
        'Get User info for PS TOOL
        Me.PS_UserLoginName_ComboBoxEdit.Properties.Items.Clear()
        Me.QueryText = "SELECT [Member_Name] FROM [ActiveDirectoryUsers] where [Member_Name] not in (SELECT dbo.getStringPartByDelimeter(name,'\',2) from sys.database_principals where type='U' and name like 'CCB%') and [AccountStatus] in ('*ENABLED') and NonPersonalUser=0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.PS_UserLoginName_ComboBoxEdit.Properties.Items.Add(row("Member_Name"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.PS_UserLoginName_ComboBoxEdit.Text = dt.Rows.Item(0).Item("Member_Name")
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub PSTOOL_Cancel_btn_Click(sender As Object, e As EventArgs) Handles PSTOOL_Cancel_btn.Click
        Me.Cancel_btn.PerformClick()
    End Sub



#End Region

    Private Sub ActiveUsersPermissionsRep_btn_Click(sender As Object, e As EventArgs) Handles ActiveUsersPermissionsRep_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Create Active Users - Permissions Report ")

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ActiveDirectoryUsersDa As New SqlDataAdapter("SELECT * FROM [ActiveDirectoryUsers]", conn)
        Dim ActiveDirectoryUsersBankSystemsDa As New SqlDataAdapter("SELECT * FROM [ActiveDirectoryUsersBankSystems]", conn)
        Dim REPORTINGdataset As New DataSet("REPORTING")
        ActiveDirectoryUsersDa.Fill(REPORTINGdataset, "ActiveDirectoryUsers")
        ActiveDirectoryUsersBankSystemsDa.Fill(REPORTINGdataset, "ActiveDirectoryUsersBankSystems")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\ActiveUsersPermissions.rpt")
        CrRep.SetDataSource(REPORTINGdataset)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Active Users - Permissions Report"
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = True
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

End Class