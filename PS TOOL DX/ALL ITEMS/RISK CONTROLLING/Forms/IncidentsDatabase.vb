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
Public Class IncidentsDatabase
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = Nothing
    Dim IncidentFilesDir As String = Nothing
    Dim NewIncidentFilesDir As String = Nothing
    Dim ID_Docs As Double = 0
    Dim CaseID As Double = 0
    Dim IdSchadensfall As Double = 0
    Dim FileCopyDirectory As String = Nothing
    Dim IDNR As Double = 0



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

    Private Sub SCHADENSFALLBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SCHADENSFALLBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.IncidentsDataset)

    End Sub

    Private Sub IncidentsDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        'FILES DIR PARAMETER
        '********MANAGEMENT ADMIN**************************
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='SCHADENSFALL_DOCS_DIR' and [IdABTEILUNGSPARAMETER]='SCHANDENSFALL' and [PARAMETER STATUS]='Y' "
        IncidentFilesDir = cmd.ExecuteScalar
        cmd.Connection.Close()


        Me.SCHADENSFALL_OPTIONSTableAdapter.Fill(Me.IncidentsDataset.SCHADENSFALL_OPTIONS)
        Me.SCHADENFALL_DOCSTableAdapter.Fill(Me.IncidentsDataset.SCHADENFALL_DOCS)
        Me.SCHADENSFALLTableAdapter.Fill(Me.IncidentsDataset.SCHADENSFALL)

        'Spell Checking
        Me.SpellChecker1.Check(Me.CaseDescription_MemoEdit)
        Me.SpellChecker1.Check(Me.MeasuresMemoEdit)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
       
        If e.Button.Tag = "AddNew" Then
            Me.LayoutControl1.Visible = False
            Me.SCHADENSFALLBindingSource.AddNew()
            Me.Statuslbl.Text = "NEW INCIDENT"
            Me.ATTACHMENTSXtraTabPage.PageVisible = False
            Me.MEASURESXtraTabPage.PageVisible = False
            Dim d As Date = Now
            CaseID = d.ToString("yyyyMMddHHmmss")
            Me.CaseID_lbl.Text = CaseID
        End If
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Add new File
        If e.Button.Tag = "AddNewAttachment" Then
            FileCopyDirectory = IncidentFilesDir & "\" & Me.CaseID_lbl.Text
            IDNR = Me.Label4.Text
            With OpenFileDialog1

                .InitialDirectory = "C:\"
                .FileName = ""
                .Title = "Import Files"
                .RestoreDirectory = True
                .Multiselect = True

                If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
                    For Each file As String In OpenFileDialog1.FileNames
                        System.IO.File.Copy(file, FileCopyDirectory & "\" & IO.Path.GetFileName(file), True)

                        cmd.Connection.Open()
                        'delete file in Database if exists
                        cmd.CommandText = "DELETE FROM [SCHADENFALL_DOCS] where [FileName]='" & IO.Path.GetFileName(file) & " ' and [IdSchadenfall]=" & IDNR & " "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [SCHADENFALL_DOCS]([FileName],[FileNameType],[FileDirectory],[ImportUser],[IdSchadenfall]) Values ('" & IO.Path.GetFileName(file) & " ','" & IO.Path.GetExtension(file) & " ', '" & FileCopyDirectory & "\" & IO.Path.GetFileName(file) & "','" & SystemInformation.UserName & "','" & Str(Me.Label4.Text) & "')"
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                    Next
                End If
                Me.SCHADENFALL_DOCSTableAdapter.FillByIdDocs(Me.IncidentsDataset.SCHADENFALL_DOCS, IDNR)
            End With
        End If

        'Delete File
        If e.Button.ButtonType = NavigatorButtonType.Remove Then
            If Me.IncidentsDocs_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the File be deleted?", "DELETE CASE FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    cmd.Connection.Open()
                    'delete file in Database if exists
                    cmd.CommandText = "DELETE FROM [SCHADENFALL_DOCS] where [ID]=" & ID_Docs & " "
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    System.IO.File.Delete(FileCopyDirectory)
                    Me.SCHADENFALL_DOCSTableAdapter.FillByIdDocs(Me.IncidentsDataset.SCHADENFALL_DOCS, IDNR)
                Else
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub OpRiskOptions_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles OpRiskOptions_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        Me.OpRiskLevel1_lbl.Text = view.GetFocusedRowCellValue("OpRiskLevel1").ToString
        Me.OpRiskNr_lbl.Text = view.GetFocusedRowCellValue("OpRiskNr").ToString
        Me.OpRiskLevel2_lbl.Text = view.GetFocusedRowCellValue("OpRiskLevel2").ToString
        Me.OpRiskMateriality_lbl.Text = view.GetFocusedRowCellValue("OpRiskMateriality").ToString

    End Sub

    Private Sub Save_Incidents_btn_Click(sender As Object, e As EventArgs) Handles Save_Incidents_btn.Click
        If Me.DxValidationProvider1.Validate() = True Then
            If Me.Statuslbl.Text = "NEW INCIDENT" Then
                Try

                    Me.Validate()
                    Me.SCHADENSFALLBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.IncidentsDataset)
                    'Create new Folder for Docs
                    NewIncidentFilesDir = IncidentFilesDir & "\" & Me.CaseID_lbl.Text
                    If Not Directory.Exists(NewIncidentFilesDir) Then
                        Directory.CreateDirectory(NewIncidentFilesDir)
                    End If
                    'Load and get new inserted Item
                    Me.SCHADENSFALLTableAdapter.FillByNewIncident(Me.IncidentsDataset.SCHADENSFALL, CaseID)
                    Me.SCHADENFALL_DOCSTableAdapter.Fill(Me.IncidentsDataset.SCHADENFALL_DOCS)
                    Me.ATTACHMENTSXtraTabPage.PageVisible = True
                    Me.MEASURESXtraTabPage.PageVisible = True
                    Me.Statuslbl.Text = "INCIDENT MODIFICATION"
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Else
                CaseID = Me.CaseID_lbl.Text
                Me.Validate()
                Me.SCHADENSFALLBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.IncidentsDataset)
                Me.SCHADENSFALLTableAdapter.FillByCaseId(Me.IncidentsDataset.SCHADENSFALL, CaseID)
                Me.SCHADENFALL_DOCSTableAdapter.Fill(Me.IncidentsDataset.SCHADENFALL_DOCS)
            End If
        Else
            MessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If


    End Sub

    Private Sub DamageCompensationAmount_ReadStatus()
        If Me.DamageCompensations_ComboBoxEdit.Text <> "None" Then
            Me.DamageCompensationAmount_SpinEdit.Properties.ReadOnly = False
        Else
            Me.DamageCompensationAmount_SpinEdit.Properties.ReadOnly = True
        End If
    End Sub

    Private Sub DamageCompensations_ComboBoxEdit_TextChanged(sender As Object, e As EventArgs) Handles DamageCompensations_ComboBoxEdit.TextChanged
        DamageCompensationAmount_ReadStatus()
    End Sub

    Private Sub ShowAllCases_btn_Click(sender As Object, e As EventArgs) Handles ShowAllCases_btn.Click
   
        Me.SCHADENSFALLBindingSource.CancelEdit()
        Me.IncidentsDataset.RejectChanges()
        Me.SCHADENFALL_DOCSTableAdapter.Fill(Me.IncidentsDataset.SCHADENFALL_DOCS)
        Me.SCHADENSFALLTableAdapter.Fill(Me.IncidentsDataset.SCHADENSFALL)
        Me.ATTACHMENTSXtraTabPage.PageVisible = True
        Me.MEASURESXtraTabPage.PageVisible = True
        Me.LayoutControl1.Visible = True
    End Sub

    Private Sub IncidentsDocs_GridView_DoubleClick(sender As Object, e As EventArgs) Handles IncidentsDocs_GridView.DoubleClick
        If Me.IncidentsDocs_GridView.RowCount > 0 Then
            Dim view As GridView = DirectCast(sender, GridView)
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Openning Document: " & view.GetFocusedRowCellValue("FileName").ToString)
            System.Diagnostics.Process.Start(view.GetFocusedRowCellValue("FileDirectory").ToString)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub IncidentsDocs_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles IncidentsDocs_GridView.RowClick
        If Me.IncidentsDocs_GridView.RowCount > 0 Then
            Dim view As GridView = DirectCast(sender, GridView)
            ID_Docs = view.GetFocusedRowCellValue("ID").ToString
            FileCopyDirectory = view.GetFocusedRowCellValue("FileDirectory").ToString
            IdSchadensfall = view.GetFocusedRowCellValue("IdSchadenfall").ToString
            IDNR = Me.Label4.Text
        End If
    End Sub

    Private Sub Print_Export_Attachments_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Attachments_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
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
        Dim reportfooter As String = "ATTACHMENTS FOR CASE ID " & Me.CaseID_lbl.Text
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintExportAllIncidents_btn_Click(sender As Object, e As EventArgs) Handles PrintExportAllIncidents_btn.Click
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
        Dim reportfooter As String = "ALL INCIDENTS"
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub OpRiskOptions_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpRiskOptions_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OpRiskOptions_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OpRiskOptions_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub IncidentsDocs_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IncidentsDocs_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub IncidentsDocs_GridView_ShownEditor(sender As Object, e As EventArgs) Handles IncidentsDocs_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Incicents_BaseView_DoubleClick(sender As Object, e As EventArgs) Handles Incicents_BaseView.DoubleClick
        Me.LayoutControl1.Visible = False
        DamageCompensationAmount_ReadStatus()
        Me.Statuslbl.Text = "INCIDENT MODIFICATION"
    End Sub

    Private Sub Incicents_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Incicents_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Incicents_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles Incicents_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Statuslbl_TextChanged(sender As Object, e As EventArgs) Handles Statuslbl.TextChanged
        If Me.Statuslbl.Text = "NEW INCIDENT" Then
            Me.IncidentReport_btn.Visible = False
        Else
            Me.IncidentReport_btn.Visible = True
        End If
    End Sub

    Private Sub IncidentReport_btn_Click(sender As Object, e As EventArgs) Handles IncidentReport_btn.Click
        Try
            Me.Save_Incidents_btn.PerformClick()


            Dim n As Double = Me.Label4.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Incident report for Case ID" & Me.CaseID_lbl.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INCIDENT_CASE.rpt")
            CrRep.SetDataSource(IncidentsDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = n
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Incident report for Case ID: " & Me.CaseID_lbl.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class