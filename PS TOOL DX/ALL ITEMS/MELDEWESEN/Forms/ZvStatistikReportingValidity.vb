Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraGrid.Views.Printing
Imports PS_TOOL_DX.RichEditSyntaxSample

Public Class ZvStatistikReportingValidity
    Inherits XtraForm

    Friend WithEvents BgwZVSTA_Validating As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Private BS_ZVSTA_Rep_DataCheck As BindingSource
    Dim FinalizedReportStatus As Boolean = False

    Delegate Sub FocusOnCurrentCheck(ByVal i As Integer)

    Dim CurrentZVSTA_Report As String = Nothing


    Private Sub ZvStatistikReportingValidity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentZVSTA_Report = Me.ZVSTA_Schema_BarEditItem.EditValue.ToString & Me.ZVSTA_ReportingPeriod_BarEditItem.EditValue.ToString

        Me.PopupContainerEdit2.PopupFormMinSize = New Size(650, 500)

        OpenSqlConnections()
        Dim ZVSTA_Reporting_Check_Da As New SqlDataAdapter("SELECT * from [ZVSTAT_ReportingValidityCheck] where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' order by Validity_ID desc", conn)
        Dim ZVSTA_Reporting_Check_Dataset As New DataSet("ZVSTAT_ReportingValidityCheck")
        ZVSTA_Reporting_Check_Da.Fill(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")
        BS_ZVSTA_Rep_DataCheck = New BindingSource(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")

        Me.GridControl3.DataSource = BS_ZVSTA_Rep_DataCheck
        Me.GridControl3.Update()
        CloseSqlConnections()

        VALIDITY_STATUS_CHANGED()
        If Me.ValidityStatus_BarStaticItem.Caption.ToString.Contains("ZVSTA REPORT NOT FINALIZED") Then
            FinalizedReportStatus = False
        ElseIf Me.ValidityStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT FINALIZED") _
            OrElse Me.ValidityStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT VALIDATED") _
            OrElse Me.ValidityStatus_BarStaticItem.Caption.ToString.Contains("ZVSTA REPORT NOT VALIDATED") Then
            FinalizedReportStatus = True
        End If
    End Sub

    Private Sub VALIDITY_STATUS_CHANGED()
        If Me.ValidityStatus_BarStaticItem.Caption.ToString.EndsWith("+") Then
            With Me.ValidityStatus_BarStaticItem
                '.ItemAppearance.Normal.BackColor = Color.Gray
                .ItemAppearance.Normal.ForeColor = Color.Red
            End With
        Else
            With Me.ValidityStatus_BarStaticItem
                '.ItemAppearance.Normal.BackColor = Color.Green
                .ItemAppearance.Normal.ForeColor = Color.DarkGreen
            End With
        End If
    End Sub

    Private Sub ZvStatistikReportingValidity_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If

    End Sub

    Private Sub ZvStatistikReportingValidity_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


    End Sub

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub PopupContainerEdit2_QueryPopUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit2.QueryPopUp
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        Dim editor As BaseEdit = DirectCast(sender, BaseEdit)
        RichEditControl1.Document.Text = editor.EditValue.ToString()
    End Sub

    Private Sub PopupContainerEdit2_QueryResultValue(sender As Object, e As QueryResultValueEventArgs) Handles PopupContainerEdit2.QueryResultValue
        e.Value = RichEditControl1.Document.Text
    End Sub

    Private Sub RichEditControl1_TextChanged(sender As Object, e As EventArgs) Handles RichEditControl1.TextChanged
        If Me.RichEditControl1.Text <> "" Then
            RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        End If
    End Sub

    Private Sub RichEditControl1_GotFocus(sender As Object, e As EventArgs) Handles RichEditControl1.GotFocus
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
    End Sub

    Private Sub ZVSTAT_ValidityCheckResults_Gridview_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles ZVSTAT_ValidityCheckResults_Gridview.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        'If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        If e.Column.FieldName.Equals("ValiditySqlParameter") = True Then
            e.RepositoryItem = Me.PopupContainerEdit2
        End If
        'End If
    End Sub

    Public Sub Focus_OnCurrentCheck(ByVal i As Integer)
        Me.ZVSTAT_ValidityCheckResults_Gridview.FocusedRowHandle = i
        Me.ZVSTAT_ValidityCheckResults_Gridview.FocusedColumn = colValidityCheckResult
    End Sub

    Private Sub ZVSTA_Validate_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_Validate_BarButtonItem.ItemClick
        If XtraMessageBox.Show(CType("Should the validation of the ZV Statistik Report: " & Me.ZVSTA_Schema_BarEditItem.EditValue.ToString & Me.ZVSTA_ReportingPeriod_BarEditItem.EditValue.ToString _
                                       & " be startet? ", String), "VALIDATING CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                Me.ZVSTA_Validate_BarButtonItem.Visibility = BarItemVisibility.Never
                Me.BbiPrintExport.Visibility = BarItemVisibility.Never
                Me.ProcessStatus_BarStaticItem.Visibility = BarItemVisibility.Always
                BgwZVSTA_Validating = New BackgroundWorker
                bgws.Add(BgwZVSTA_Validating)
                BgwZVSTA_Validating.WorkerReportsProgress = True
                BgwZVSTA_Validating.RunWorkerAsync()


            Catch ex As Exception
                CloseSqlConnections()
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
    End Sub

    Private Sub BgwZVSTA_Validating_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_Validating.DoWork
        Try
            OpenSqlConnections()
            Me.BgwZVSTA_Validating.ReportProgress(10, "Validate ZVSTA Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DELETE FROM  [ZVSTAT_ReportingValidityCheck] where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Validating.ReportProgress(10, "Insert all Validation Rules for Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "INSERT INTO [ZVSTAT_ReportingValidityCheck]
                               ([ZVSTA_Schema]
                               ,[ReportingPeriod]
                               ,[Validity_ID]
                               ,[ValidityType]
                               ,[ReportingFormLeft]
                               ,[ReportingFormRight]
                               ,[ValidityTerm]
                               ,[ValidityTermDescription]
                               ,[ValiditySqlParameter]
                               ,[ValidityCheckResult])
                         SELECT '" & Me.ZVSTA_Schema_BarEditItem.EditValue.ToString & "'
                              , '" & Me.ZVSTA_ReportingPeriod_BarEditItem.EditValue.ToString & "'
                              , [Validity_ID]
                               ,[ValidityType]
                               ,[ReportingFormLeft]
                               ,[ReportingFormRight]
                               ,[ValidityTerm]
                               ,[ValidityTermDescription]
                               ,[ValiditySqlParameter]
                               ,'UNCHECKED'
                           from [ZVSTAT_ProofingRules_Parameter]  where [ZVSTA_Schema]='" & Me.ZVSTA_Schema_BarEditItem.EditValue.ToString & "'
                            and [ValidityTermStatus] in ('Y') 
                            and [ValiditySqlParameter] is not NULL
                           ORDER BY Validity_ID asc"
            cmd.ExecuteNonQuery()


            Me.BgwZVSTA_Validating.ReportProgress(10, "Execute SQL Validity Parameters for " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_ReportingValidityCheck]  where  [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' order by [ID] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("ValiditySqlParameter").ToString <> "" Then
                    Dim ID As String = dt.Rows.Item(i).Item("ID").ToString
                    SqlCommandText = dt.Rows.Item(i).Item("ValiditySqlParameter").ToString.Replace("<CurrentZVSTA_Report>", CurrentZVSTA_Report)
                    cmd.CommandText = "UPDATE [ZVSTAT_ReportingValidityCheck] SET [ValiditySqlParameter]=@ValiditySqlParameter where [ID]=" & CInt(ID) & ""
                    cmd.Parameters.Add("@ValiditySqlParameter", SqlDbType.NText).Value = SqlCommandText
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Me.BgwZVSTA_Validating.ReportProgress(10, "Execute SQL Validity Commands  for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    'SqlCommandText = dt.Rows.Item(i).Item("ValiditySqlParameter").ToString

                    Me.ZVSTAT_ValidityCheckResults_Gridview.GridControl.BeginInvoke(CType((Function()
                                                                                               Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
                                                                                               Dim GetFocusedRow As Integer = focusedView.FocusedRowHandle
                                                                                               Me.ZVSTAT_ValidityCheckResults_Gridview.FocusedRowHandle = i
                                                                                               Me.ZVSTAT_ValidityCheckResults_Gridview.FocusedColumn = colValidityCheckResult
                                                                                           End Function), Action))

                    cmd.CommandText = SqlCommandText
                    Dim Result As String = CStr(cmd.ExecuteScalar)
                    cmd.CommandText = "Update [ZVSTAT_ReportingValidityCheck] SET [ValidityCheckResult]='" & Result & "' where ID=" & CInt(ID) & ""
                    cmd.ExecuteNonQuery()

                End If
            Next


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_Validating.ReportProgress(10, "ERROR +++ " & ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwZVSTA_Validating_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_Validating.ProgressChanged
        Try
            Me.ProcessStatus_BarStaticItem.Caption = "Process Status: " & e.UserState.ToString

            'OpenSqlConnections()
            Dim ZVSTA_Reporting_Check_Da As New SqlDataAdapter("SELECT * from [ZVSTAT_ReportingValidityCheck] where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' order by Validity_ID asc", conn1)
            Dim ZVSTA_Reporting_Check_Dataset As New DataSet("ZVSTAT_ReportingValidityCheck")
            ZVSTA_Reporting_Check_Da.Fill(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")
            BS_ZVSTA_Rep_DataCheck = New BindingSource(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")

            Me.GridControl3.DataSource = BS_ZVSTA_Rep_DataCheck
            Me.GridControl3.Update()
            'CloseSqlConnections()
            'ZVSTAT_ValidityCheckResults_Gridview.MoveLast()

            'For i As Integer = 0 To Me.ZVSTAT_ValidityCheckResults_Gridview.DataRowCount - 1
            '    Me.ZVSTAT_ValidityCheckResults_Gridview.FocusedRowHandle = i
            '    Me.ZVSTAT_ValidityCheckResults_Gridview.FocusedColumn = colValidityCheckResult
            'Next i

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwZVSTA_Validating_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_Validating.RunWorkerCompleted
        Workers_Complete(BgwZVSTA_Validating, e)
        bgws.Clear()

        Dim ZVSTA_Reporting_Check_Da As New SqlDataAdapter("SELECT * from [ZVSTAT_ReportingValidityCheck] where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' order by Validity_ID asc", conn)
        Dim ZVSTA_Reporting_Check_Dataset As New DataSet("ZVSTAT_ReportingValidityCheck")
        ZVSTA_Reporting_Check_Da.Fill(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")
        BS_ZVSTA_Rep_DataCheck = New BindingSource(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")

        Me.GridControl3.DataSource = BS_ZVSTA_Rep_DataCheck
        Me.GridControl3.Update()

        Me.ZVSTA_Validate_BarButtonItem.Visibility = BarItemVisibility.Always
        Me.BbiPrintExport.Visibility = BarItemVisibility.Always
        Me.ProcessStatus_BarStaticItem.Visibility = BarItemVisibility.Never

        'Check Results
        QueryText = "Select * from [ZVSTAT_ReportingValidityCheck]  where  [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and ValidityCheckResult in ('N','UNCHECKED') order by [ID] asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            XtraMessageBox.Show("There are Validation Errors in the current ZV Statistic Report!", "VALIDATION FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [ReportStatus]='F' where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()
            Me.ValidityStatus_BarStaticItem.Caption = "+++ZVSTA REPORT NOT VALIDATED+++"
            'MessageBox.Show("Parent form text: " + CType(ZvStatistikReporting, ZvStatistikReporting).Name)
            'Dim parent As ZvStatistikReporting = CType(ZvStatistikReporting, ZvStatistikReporting)
            'Me.Owner = parent
            'parent.NotifyMe("OK")
            'parent.ReportStatus_BarStaticItem.Caption = "OK"

            Return
        ElseIf dt.Rows.Count = 0 Then
            XtraMessageBox.Show("The current ZV Statistic Report is Valid", "VALIDATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If FinalizedReportStatus = True Then
                cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [ReportStatus]='V' where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
                cmd.ExecuteNonQuery()
            End If
            Me.ValidityStatus_BarStaticItem.Caption = "ZVSTA REPORT VALIDATED"
            'c.NotifyMe("ZVSTA REPORT VALIDATED")
        End If

        VALIDITY_STATUS_CHANGED()


        CloseSqlConnections()


    End Sub

    Private Sub BbiPrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiPrintExport.ItemClick
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
        Dim reportfooter As String = "ZV Statistik - Validation Results for " & CurrentZVSTA_Report
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ZVSTAT_ValidityCheckResults_Gridview_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ZVSTAT_ValidityCheckResults_Gridview.PrintInitialize
        Dim view As GridView = CType(sender, GridView)
        view.Columns("ValiditySqlParameter").ColumnEdit = MemoEdit1
        view.OptionsView.RowAutoHeight = True
    End Sub

    Private Sub PrintableComponentLink1_AfterCreateAreas(sender As Object, e As EventArgs) Handles PrintableComponentLink1.AfterCreateAreas
        ZVSTAT_ValidityCheckResults_Gridview.Columns("ValiditySqlParameter").ColumnEdit = RepositoryItemMemoExEdit3
        ZVSTAT_ValidityCheckResults_Gridview.OptionsView.RowAutoHeight = False



    End Sub


End Class