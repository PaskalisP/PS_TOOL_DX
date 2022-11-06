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
Public Class EmployesAverage

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATESFORM_EMPL_AVG As New AccDatesForm

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

    Private Sub EMPLOYES_YEAR_AVERAGEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EMPLOYES_YEAR_AVERAGEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)

    End Sub

    Private Sub EmployesAverage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        Me.EMPLOYES_YEAR_AVERAGETableAdapter.Fill(Me.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Add new Year
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
            'Me.EMPLOYES_YEAR_AVERAGEBindingSource.EndEdit()
            cmd.CommandText = "INSERT INTO [EMPLOYES YEAR AVERAGE]([JahrLfd])SELECT((Select Max([JahrLfd])+1 from [EMPLOYES YEAR AVERAGE]))"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            Me.EMPLOYES_YEAR_AVERAGETableAdapter.Fill(Me.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)
        End If

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            'If MeldewesenDataSet.HasChanges = True Then
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Try
                    Me.Validate()
                    Me.EMPLOYES_YEAR_AVERAGEBindingSource.EndEdit()
                    Me.EMPLOYES_YEAR_AVERAGETableAdapter.Update(Me.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)

                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "UPDATE [EMPLOYES YEAR AVERAGE] set [EmplAverage]=Round(([1VJ]+[2VJ]+[3VJ]+[4VJ])/4,0)"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.EMPLOYES_YEAR_AVERAGETableAdapter.Fill(Me.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.EMPLOYES_YEAR_AVERAGEBindingSource.CancelEdit()
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If
            'End If

        End If

    End Sub

    

    Private Sub EmployesAverage_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles EmployesAverage_BasicView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub EmployesAverage_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles EmployesAverage_BasicView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub EmployesAverage_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EmployesAverage_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub EmployesAverage_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles EmployesAverage_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_AverageEmployes_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_AverageEmployes_btn.Click
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
        Dim reportfooter As String = "Durchschnittlicher Mitarbeiterstand gem. § 267 Abs.5 HgB" & "  " & " der China Construction Bank, Niederlassung Frankfurt"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub EmployeAverageRep_btn_Click(sender As Object, e As EventArgs) Handles EmployeAverageRep_btn.Click
        'Save Changes---------------------
        Me.Validate()
        Me.EMPLOYES_YEAR_AVERAGEBindingSource.EndEdit()
        Me.EMPLOYES_YEAR_AVERAGETableAdapter.Update(Me.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)
        Me.EMPLOYES_YEAR_AVERAGETableAdapter.Fill(Me.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)
        '---------------------------------

        Dim dxOK_EMPL_AVG As New DevExpress.XtraEditors.SimpleButton

        With dxOK_EMPL_AVG
            .Text = "OK"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(19, 203)
        End With

        DATESFORM_EMPL_AVG.Controls.Add(dxOK_EMPL_AVG)
        DATESFORM_EMPL_AVG.OK_btn.Visible = False
        DATESFORM_EMPL_AVG.LabelControl1.Visible = True
        DATESFORM_EMPL_AVG.LabelControl2.Visible = False
        DATESFORM_EMPL_AVG.LabelControl3.Visible = False
        DATESFORM_EMPL_AVG.ComboBoxEdit2.Visible = False
        DATESFORM_EMPL_AVG.ComboBoxEdit3.Visible = False

        AddHandler dxOK_EMPL_AVG.Click, AddressOf dxOK_EMPL_AVG_click

        DATESFORM_EMPL_AVG.Show()
        DATESFORM_EMPL_AVG.Text = "Erstellung des Durchschnittlichen Mitarbeiterstandes"
        DATESFORM_EMPL_AVG.LabelControl1.Text = "Bitte wählen Sie das Jahr aus für den Report"

        Me.QueryText = "select [JahrLfd] from [EMPLOYES YEAR AVERAGE] ORDER BY [JahrLfd] desc "
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            DATESFORM_EMPL_AVG.ComboBoxEdit1.Properties.Items.Add(row("JahrLfd"))
        Next
        DATESFORM_EMPL_AVG.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("JahrLfd")
    End Sub

    Private Sub dxOK_EMPL_AVG_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MeldeJahr As String = DATESFORM_EMPL_AVG.ComboBoxEdit1.Text
        DATESFORM_EMPL_AVG.ComboBoxEdit1.Properties.Items.Clear()
        DATESFORM_EMPL_AVG.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung des Durchschnittlichen Mitarbeiterstandes für " & MeldeJahr)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AVERAGE_EMPLOYES.rpt")
        CrRep.SetDataSource(MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = MeldeJahr
        myParams.ParameterFieldName = "IdNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Durchschnittlicher Mitarbeiterstand für " & MeldeJahr
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