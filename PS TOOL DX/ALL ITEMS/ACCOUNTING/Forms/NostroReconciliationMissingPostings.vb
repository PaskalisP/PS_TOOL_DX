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
Imports PS_TOOL_DX.RichEditSyntaxSample
Imports DevExpress.XtraGrid.Views.Printing


Public Class NostroReconciliationMissingPostings
    Inherits XtraForm

    Friend WithEvents BgwMissingPostings_Check As BackgroundWorker
    Friend WithEvents BgwAddMissingPostings_Reconciliation As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Private BS_ZVSTA_Rep_DataCheck As BindingSource
    Dim FinalizedReportStatus As Boolean = False

    Delegate Sub FocusOnCurrentCheck(ByVal i As Integer)

    Dim CurrentZVSTA_Report As String = Nothing


    Private Sub NostroReconciliationMissingPostings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CurrentZVSTA_Report = Me.ZVSTA_Schema_BarEditItem.EditValue.ToString & Me.InternalNostroAccount_BarEditItem.EditValue.ToString

        'Me.PopupContainerEdit2.PopupFormMinSize = New Size(650, 500)

        'OpenSqlConnections()
        'Dim ZVSTA_Reporting_Check_Da As New SqlDataAdapter("SELECT * from [ZVSTAT_ReportingValidityCheck] where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' order by Validity_ID desc", conn)
        'Dim ZVSTA_Reporting_Check_Dataset As New DataSet("ZVSTAT_ReportingValidityCheck")
        'ZVSTA_Reporting_Check_Da.Fill(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")
        'BS_ZVSTA_Rep_DataCheck = New BindingSource(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")

        'Me.GridControl3.DataSource = BS_ZVSTA_Rep_DataCheck
        'Me.GridControl3.Update()
        'CloseSqlConnections()

        'VALIDITY_STATUS_CHANGED()
        'If Me.ValidityStatus_BarStaticItem.Caption.ToString.Contains("ZVSTA REPORT NOT FINALIZED") Then
        '    FinalizedReportStatus = False
        'ElseIf Me.ValidityStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT FINALIZED") _
        '    OrElse Me.ValidityStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT VALIDATED") _
        '    OrElse Me.ValidityStatus_BarStaticItem.Caption.ToString.Contains("ZVSTA REPORT NOT VALIDATED") Then
        '    FinalizedReportStatus = True
        'End If
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


    Public Sub Focus_OnCurrentCheck(ByVal i As Integer)
        Me.MissingPostings_Gridview.FocusedRowHandle = i
        Me.MissingPostings_Gridview.FocusedColumn = colReference_AccountOwner_IB_Second
    End Sub

    Private Sub CheckMissingPostings_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CheckMissingPostings_BarButtonItem.ItemClick
        If XtraMessageBox.Show(CType("Should the check for missing postings on: " & Me.ReconcileDate_BarEditItem.EditValue.ToString & " for internal account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString _
                                       & " be startet? ", String), "CHECKING FOR MISSING POSTINGS IN RECONCILIATION", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                Me.CheckMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Never
                Me.ReconcileDate_BarEditItem.Enabled = False
                Me.BbiPrintExport.Visibility = BarItemVisibility.Never
                Me.GridControl3.DataSource = Nothing
                Me.GridControl3.Update()
                Me.LayoutControlItem2.Visibility = LayoutVisibility.Always
                Me.ProgressPanel1.Caption = Nothing
                BgwMissingPostings_Check = New BackgroundWorker
                bgws.Add(BgwMissingPostings_Check)
                BgwMissingPostings_Check.WorkerReportsProgress = True
                BgwMissingPostings_Check.RunWorkerAsync()


            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
    End Sub

    Private Sub BgwMissingPostings_Check_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwMissingPostings_Check.DoWork
        Try

            rd = CDate(Me.ReconcileDate_BarEditItem.EditValue.ToString)
            rdsql = rd.ToString("yyyyMMdd")
            Me.BgwMissingPostings_Check.ReportProgress(10, "Start missing postings check on: " & Me.ReconcileDate_BarEditItem.EditValue.ToString & " for internal nostro account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND where SQL_Name_1 in ('NOSTRO_MISSING_POSTINGS_CHECK') and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql).Replace("<InternalNostroAccount>", Me.InternalNostroAccount_BarEditItem.EditValue.ToString).ToString
                Dim objCMD1 As SqlCommand = New SqlCommand(SqlCommandText, conn)
                objCMD1.CommandTimeout = 5000
                da1 = New SqlDataAdapter(objCMD1)
                dt1 = New DataTable()
                da1.Fill(dt1)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwMissingPostings_Check.ReportProgress(10, "ERROR +++ " & ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwMissingPostings_Check_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwMissingPostings_Check.ProgressChanged
        Try
            Me.ProgressPanel1.Caption = e.UserState.ToString
            'Me.GridControl3.DataSource = Nothing
            'Me.GridControl3.DataSource = dt1
            'Me.GridControl3.Update()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwMissingPostings_Check_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwMissingPostings_Check.RunWorkerCompleted
        Me.LayoutControlItem2.Visibility = LayoutVisibility.Never
        Workers_Complete(BgwMissingPostings_Check, e)
        bgws.Clear()
        Me.GridControl3.DataSource = Nothing
        Me.GridControl3.DataSource = dt1
        Me.GridControl3.Update()

        Me.CheckMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Always
        Me.BbiPrintExport.Visibility = BarItemVisibility.Always
        Me.ReconcileDate_BarEditItem.Enabled = True
        If MissingPostings_Gridview.DataRowCount > 0 Then
            XtraMessageBox.Show(MissingPostings_Gridview.DataRowCount.ToString & " missing postings found on: " & Me.ReconcileDate_BarEditItem.EditValue.ToString & " for internal account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString, "MISSING POSTINGS CHECK", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.AddMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Always
        ElseIf MissingPostings_Gridview.DataRowCount = 0 Then
            Me.AddMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Never
            XtraMessageBox.Show("They are no missing postings on: " & Me.ReconcileDate_BarEditItem.EditValue.ToString & " for internal account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString, "MISSING POSTINGS CHECK", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If


    End Sub

    Private Sub AddMissingPostings_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AddMissingPostings_BarButtonItem.ItemClick
        If XtraMessageBox.Show(CType("Should the displayed missing postings on: " & Me.ReconcileDate_BarEditItem.EditValue.ToString & " for internal account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString _
                                       & " be added to the last reconciliation? ", String), "ADD MISSING POSTINGS IN TO LAST RECONCILIATION", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                Me.CheckMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Never
                Me.ReconcileDate_BarEditItem.Enabled = False
                Me.AddMissingPostings_BarButtonItem.Enabled = False
                Me.BbiPrintExport.Visibility = BarItemVisibility.Never
                Me.LayoutControlItem2.Visibility = LayoutVisibility.Always
                Me.ProgressPanel1.Caption = Nothing
                BgwAddMissingPostings_Reconciliation = New BackgroundWorker
                bgws.Add(BgwAddMissingPostings_Reconciliation)
                BgwAddMissingPostings_Reconciliation.WorkerReportsProgress = True
                BgwAddMissingPostings_Reconciliation.RunWorkerAsync()


            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
    End Sub

    Private Sub BgwAddMissingPostings_Reconciliation_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwAddMissingPostings_Reconciliation.DoWork
        Try

            rd = CDate(Me.ReconcileDate_BarEditItem.EditValue.ToString)
            rdsql = rd.ToString("yyyyMMdd")
            Me.BgwAddMissingPostings_Reconciliation.ReportProgress(10, "Start add displayed missing postings on: " & Me.ReconcileDate_BarEditItem.EditValue.ToString & " for internal account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString & " in to the last reconciliation date!")
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND where SQL_Name_1 in ('NOSTRO_ADD_MISSING_POSTINGS_TO_RECONCILIATION') and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql).Replace("<InternalNostroAccount>", Me.InternalNostroAccount_BarEditItem.EditValue.ToString).ToString
                Dim objCMD1 As SqlCommand = New SqlCommand(SqlCommandText, conn)
                objCMD1.CommandTimeout = 5000
                da1 = New SqlDataAdapter(objCMD1)
                dt1 = New DataTable()
                da1.Fill(dt1)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwAddMissingPostings_Reconciliation.ReportProgress(10, "ERROR +++ " & ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwAddMissingPostings_Reconciliation_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwAddMissingPostings_Reconciliation.ProgressChanged
        Try
            Me.ProgressPanel1.Caption = e.UserState.ToString
            'Me.GridControl3.DataSource = Nothing
            'Me.GridControl3.DataSource = dt1
            'Me.GridControl3.Update()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwAddMissingPostings_Reconciliation_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwAddMissingPostings_Reconciliation.RunWorkerCompleted
        Me.LayoutControlItem2.Visibility = LayoutVisibility.Never
        Workers_Complete(BgwAddMissingPostings_Reconciliation, e)
        bgws.Clear()

        Me.CheckMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Always
        Me.BbiPrintExport.Visibility = BarItemVisibility.Always

        XtraMessageBox.Show("The missing postings where added in to the last reconciliation date of internal nostro account:" & Me.InternalNostroAccount_BarEditItem.EditValue.ToString, "MISSING POSTINGS ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Me.GridControl3.DataSource = Nothing
        Me.GridControl3.Update()
        Me.ReconcileDate_BarEditItem.Enabled = True
        Me.AddMissingPostings_BarButtonItem.Enabled = True
        If MissingPostings_Gridview.DataRowCount = 0 Then
            Me.AddMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Never
        End If


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
        Dim reportfooter As String = "Missing postings on reconciliation date " & ReconcileDate_BarEditItem.EditValue.ToString & " for internal account: " & Me.InternalNostroAccount_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ReconcileDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles ReconcileDate_BarEditItem.EditValueChanged
        Me.GridControl3.DataSource = Nothing
        Me.GridControl3.Update()
        Me.AddMissingPostings_BarButtonItem.Visibility = BarItemVisibility.Never
    End Sub


End Class