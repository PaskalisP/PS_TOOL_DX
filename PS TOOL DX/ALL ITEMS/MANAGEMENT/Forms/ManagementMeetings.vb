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
Imports DevExpress.XtraEditors.DXErrorProvider

Public Class ManagementMeetings

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""
    Dim DF_AllMeetings As New AccDatesForm

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim MeetingDate As Date
    Dim MANAGEMENTADMIN As String = ""


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

    Private Sub MANAGEMENT_COMITEE_MEETINGBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MANAGEMENT_COMITEE_MEETINGBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ManagementDataset)

    End Sub

    Private Sub ManagementMeetings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '********MANAGEMENT ADMIN**************************
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='MANAGEMENTADMINS' and [PARAMETER STATUS]='Y' "
        Dim MANAGEMENTResult As String = cmd.ExecuteScalar
        If MANAGEMENTResult <> "" Then
            MANAGEMENTADMIN = "Y"
            USER_MANAGEMENTADMIN_YES()
        Else
            MANAGEMENTADMIN = "N"
            USER_MANAGEMENTADMIN_NO()
        End If
        'Set Status to STILL PENDING if Expected Termination<CurrentDay
        If MANAGEMENTADMIN = "Y" Then
            Dim NowDate As Date = Today
            Dim SqlToday As String = NowDate.ToString("yyyyMMdd")
            cmd.CommandText = "UPDATE [MANAGEMENT COMITEE MEETING] SET  [Status]='STILL PENDING' where [ExpectedTermination]<'" & SqlToday & "' and [Status] not in ('CLOSED','ONGOING') "
            cmd.ExecuteNonQuery()
        End If

        cmd.Connection.Close()
        '***********************************************************************

        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)

        Me.GridControl1.MainView = ManagementMeetings_GridView
        ManagementMeetings_GridView.ForceDoubleClick = True
        AddHandler ManagementMeetings_GridView.DoubleClick, AddressOf ManagementMeetings_GridView_DoubleClick
        AddHandler ManagementMeetings_LayoutView.MouseDown, AddressOf ManagementMeetings_LayoutView_MouseDown
        ManagementMeetings_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        ManagementMeetings_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        'Spell Checking
        Me.SpellChecker1.Check(Me.TaskTopicMemoEdit)
        Me.SpellChecker1.Check(Me.TaskDescriptionMemoEdit)
        Me.SpellChecker1.Check(Me.ParticipantsMemoEdit)
        Me.SpellChecker1.Check(Me.ResponsibleDepartmentMemoEdit)
        Me.SpellChecker1.Check(Me.ResponsibleStaffMemberMemoEdit)
        Me.SpellChecker1.Check(Me.FollowUpMemoEdit)

    End Sub

#Region "MANAGEMENT_MEETINGS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl1.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = ManagementMeetings_LayoutView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = ManagementMeetings_GridView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        'Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        fExtendedEditMode = (GridControl1.MainView Is ManagementMeetings_LayoutView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = ManagementMeetings_GridView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = ManagementMeetings_LayoutView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        'Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        fExtendedEditMode = (GridControl1.MainView Is ManagementMeetings_LayoutView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = ManagementMeetings_GridView.GetRowHandle(dataSourceRowIndex)
        ManagementMeetings_GridView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = ManagementMeetings_LayoutView.GetRowHandle(dataSourceRowIndex)
        ManagementMeetings_LayoutView.VisibleRecordIndex = ManagementMeetings_LayoutView.GetVisibleIndex(rowHandle)
        ManagementMeetings_LayoutView.FocusedRowHandle = dataSourceRowIndex
    End Sub
    Protected Sub ManagementMeetings_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        'Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        'Dim hi As GridHitInfo = ManagementMeetings_GridView.CalcHitInfo(ea.Location)
        'If hi.InRow Then
        'ShowDetail(hi.RowHandle)
        'End If

        Me.GridControl1.Visible = False
        Me.Statuslbl.Text = "MODIFICATION"
    End Sub

    Protected Sub ManagementMeetings_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = ManagementMeetings_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub

#End Region


    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "ManagementCommiteeMeetingsReport" Then
            Dim dxOK_ALLMEETINGS_REP As New DevExpress.XtraEditors.SimpleButton

            With dxOK_ALLMEETINGS_REP
                .Text = "OK"
                .Height = 23
                .Width = 75
                .Location = New System.Drawing.Point(19, 203)
            End With

            DF_AllMeetings.Controls.Add(dxOK_ALLMEETINGS_REP)
            DF_AllMeetings.OK_btn.Visible = False
            DF_AllMeetings.LabelControl1.Visible = True
            DF_AllMeetings.LabelControl2.Visible = False
            DF_AllMeetings.LabelControl3.Visible = False
            DF_AllMeetings.ComboBoxEdit2.Visible = False
            DF_AllMeetings.ComboBoxEdit3.Visible = False

            AddHandler dxOK_ALLMEETINGS_REP.Click, AddressOf dxOK_ALLMEETINGS_REP_click

            DF_AllMeetings.Show()
            DF_AllMeetings.Text = "MANAGEMENT COMMITEE MEETINGS REPORT"
            DF_AllMeetings.LabelControl1.Text = "Please select Task Status"

            'Insert items in combobox
            DF_AllMeetings.ComboBoxEdit1.Properties.Items.Add("ALL")
            DF_AllMeetings.ComboBoxEdit1.Properties.Items.Add("PENDING")
            DF_AllMeetings.ComboBoxEdit1.Properties.Items.Add("STILL PENDING")
            DF_AllMeetings.ComboBoxEdit1.Properties.Items.Add("CLOSED")
            DF_AllMeetings.ComboBoxEdit1.Text = DF_AllMeetings.ComboBoxEdit1.Properties.Items(0)

        End If

        If e.Button.Tag = "PrintExport" Then
            If fExtendedEditMode Then
                Me.ManagementMeetings_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.ManagementMeetings_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.ManagementMeetings_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.ManagementMeetings_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.ManagementMeetings_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.ManagementMeetings_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                Me.ManagementMeetings_LayoutView.ShowPrintPreview()
                Me.ManagementMeetings_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.ManagementMeetings_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
            Else
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            End If
        End If
        'Add new 
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
            Me.GridControl1.Visible = False
            Me.MANAGEMENT_COMITEE_MEETINGBindingSource.AddNew()
            Me.Statuslbl.Text = "NEW MEETING"
            Me.MeetingDateEdit.Properties.ReadOnly = False
        End If
    End Sub

   

  

    Private Sub ShowAllMeetings_btn_Click(sender As Object, e As EventArgs) Handles ShowAllMeetings_btn.Click
        Me.MANAGEMENT_COMITEE_MEETINGBindingSource.CancelEdit()
        Me.MeetingDateEdit.Properties.ReadOnly = True
        Me.GridControl1.Visible = True

    End Sub

  


    Private Sub ManagementMeetings_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ManagementMeetings_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ManagementMeetings_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ManagementMeetings_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Save_Changes_btn_Click(sender As Object, e As EventArgs) Handles Save_Changes_btn.Click
        'MODIFICATION
        If Me.Statuslbl.Text = "MODIFICATION" Then
            If Me.DxValidationProvider1.Validate() = True Then
                If Me.PriorityComboBoxEdit.Text <> "INFO" Then
                    If Me.BeginningDateEdit.Text = "" Or Me.ExpectedTerminationDateEdit.Text = "" Then
                        MessageBox.Show("Please enter the Beginning and the Expected Termination Date!", "VALIDATION FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else
                        Try
                            Me.MeetingDateEdit.Properties.ReadOnly = True
                            Me.Validate()
                            Me.MANAGEMENT_COMITEE_MEETINGBindingSource.EndEdit()
                            Me.TableAdapterManager.UpdateAll(Me.ManagementDataset)
                            Me.GridControl1.Visible = True
                            Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)

                        Catch ex As System.Exception
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.GridControl1.Visible = True
                            Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)
                        End Try
                    End If
                Else
                    Try
                        Me.MeetingDateEdit.Properties.ReadOnly = True
                        Me.Validate()
                        Me.MANAGEMENT_COMITEE_MEETINGBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.ManagementDataset)
                        Me.GridControl1.Visible = True
                        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)

                    Catch ex As System.Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.GridControl1.Visible = True
                        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)
                    End Try
                End If

            Else
                MessageBox.Show("Please check your entries!", "VALIDATION FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        'NEW ENTRY
        If Me.Statuslbl.Text = "NEW MEETING" Then
            If Me.DxValidationProvider1.Validate() = True Then
                If Me.PriorityComboBoxEdit.Text <> "INFO" Then
                    If Me.BeginningDateEdit.Text = "" Or Me.ExpectedTerminationDateEdit.Text = "" Then
                        MessageBox.Show("Please enter the Beginning and the Expected Termination Date!", "VALIDATION FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else
                        Try
                            Me.MeetingDateEdit.Properties.ReadOnly = True
                            GET_TASK_ID()
                            Me.Validate()
                            Me.MANAGEMENT_COMITEE_MEETINGBindingSource.EndEdit()
                            Me.TableAdapterManager.UpdateAll(Me.ManagementDataset)
                            Me.GridControl1.Visible = True
                            Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)

                        Catch ex As System.Exception
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.GridControl1.Visible = True
                            Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)
                        End Try
                    End If
                Else
                    Try
                        Me.MeetingDateEdit.Properties.ReadOnly = True
                        GET_TASK_ID()
                        Me.Validate()
                        Me.MANAGEMENT_COMITEE_MEETINGBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.ManagementDataset)
                        Me.GridControl1.Visible = True
                        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)

                    Catch ex As System.Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.GridControl1.Visible = True
                        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.Fill(Me.ManagementDataset.MANAGEMENT_COMITEE_MEETING)
                    End Try
                End If
            Else
                MessageBox.Show("Please check your entries!", "VALIDATION FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub GET_TASK_ID()
        If IsDate(Me.MeetingDateEdit.Text) = True Then
            MeetingDate = Me.MeetingDateEdit.Text
            Dim SqlMeetingDate As String = MeetingDate.ToString("yyyyMMdd")

            cmd.CommandText = "SELECT Max([TaskID])+1 from [MANAGEMENT COMITEE MEETING] Where [MeetingDate]='" & SqlMeetingDate & "'"
            cmd.Connection.Open()
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.TaskIDLabel1.Text = cmd.ExecuteScalar
            Else
                Me.TaskIDLabel1.Text = 1
            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub UpdateFollowUp_btn_Click(sender As Object, e As EventArgs) Handles UpdateFollowUp_btn.Click

        If Me.FollowUpUpdateMemoEdit.Text <> "" Then
            Dim UpdateText As String = "+++ Update from " & SystemInformation.UserName & " on " & Now & " +++ " & vbNewLine _
                                     & Me.FollowUpUpdateMemoEdit.Text
            If Me.FollowUpMemoEdit.Text <> "" Then
                Me.FollowUpMemoEdit.Text = Me.FollowUpMemoEdit.Text & vbNewLine & vbNewLine & UpdateText
                Me.FollowUpUpdateMemoEdit.Text = ""
            Else
                Me.FollowUpMemoEdit.Text = UpdateText
                Me.FollowUpUpdateMemoEdit.Text = ""
            End If
        End If

    End Sub

    Private Sub dxOK_ALLMEETINGS_REP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim STATUS As String = DF_AllMeetings.ComboBoxEdit1.Text
        DF_AllMeetings.ComboBoxEdit1.Properties.Items.Clear()
        DF_AllMeetings.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Management Commitee meetings report " & "(" & STATUS & ")")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\MANAG_MEET_REP.rpt")
        CrRep.SetDataSource(Me.ManagementDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = STATUS
        myParams.ParameterFieldName = "Status"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Management Commitee meetings report " & "(" & STATUS & ")"
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SingleTaskReport_btn_Click(sender As Object, e As EventArgs) Handles SingleTaskReport_btn.Click
        Dim IdNr As Integer = Me.IDLabel1.Text
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Single Task report for ID Nr.: " & IdNr)

     
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\MANAG_MEET_REP_SINGLE.rpt")
        CrRep.SetDataSource(ManagementDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = IdNr
        myParams.ParameterFieldName = "IdNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Single Task report for ID Nr.: " & IdNr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub USER_MANAGEMENTADMIN_YES()
        Me.TaskDescriptionMemoEdit.Properties.ReadOnly = False
        Me.TaskTopicMemoEdit.Properties.ReadOnly = False
        Me.ParticipantsMemoEdit.Properties.ReadOnly = False
        Me.ResponsibleDepartmentMemoEdit.Properties.ReadOnly = False
        Me.ResponsibleStaffMemberMemoEdit.Properties.ReadOnly = False
        Me.StatusComboBoxEdit.Properties.ReadOnly = False
        Me.PriorityComboBoxEdit.Properties.ReadOnly = False
        Me.BeginningDateEdit.Properties.ReadOnly = False
        Me.ExpectedTerminationDateEdit.Properties.ReadOnly = False
        Me.FollowUpUpdateMemoEdit.Properties.ReadOnly = False
        'This Fields must only be read only
        Me.MeetingDateEdit.Properties.ReadOnly = True
        'Embeeded Navigator
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = True
        Me.LayoutControlItem4.Visibility = LayoutVisibility.Always
    End Sub

    Private Sub USER_MANAGEMENTADMIN_NO()
        Me.TaskDescriptionMemoEdit.Properties.ReadOnly = True
        Me.TaskTopicMemoEdit.Properties.ReadOnly = True
        Me.ParticipantsMemoEdit.Properties.ReadOnly = True
        Me.ResponsibleDepartmentMemoEdit.Properties.ReadOnly = True
        Me.ResponsibleStaffMemberMemoEdit.Properties.ReadOnly = True
        Me.StatusComboBoxEdit.Properties.ReadOnly = True
        Me.PriorityComboBoxEdit.Properties.ReadOnly = True
        Me.BeginningDateEdit.Properties.ReadOnly = True
        Me.ExpectedTerminationDateEdit.Properties.ReadOnly = True
        Me.FollowUpUpdateMemoEdit.Properties.ReadOnly = True
        'This Fields must only be read only
        Me.MeetingDateEdit.Properties.ReadOnly = True
        'Embeeded Navigator
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.LayoutControlItem4.Visibility = LayoutVisibility.Never
    End Sub
End Class