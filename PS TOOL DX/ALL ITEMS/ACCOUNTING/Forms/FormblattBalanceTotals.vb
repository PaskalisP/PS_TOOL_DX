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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Public Class FormblattBalanceTotals

    Dim CrystalRepDir As String = ""

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim ActivaSum As Double = 0
    Dim TotalActivaSum As Double = 0
    Dim AktivaSumVorjahr As Double = 0

    Dim PassivaSum As Double = 0
    Dim TotalPassivaSum As Double = 0
    Dim PassivaSumVorjahr As Double = 0

    Dim BilanzDifferenz As Double = 0

    Dim CheckField As String = Nothing


    Dim ActivaDetailViewCaption As String = Nothing
    Dim PassivaDetailsViewCaption As String = Nothing

    Dim d As Date
    Dim dsql As String = Nothing

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

    Private Sub Formblatt_BILANZ_TOTALS_ACTIVABindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.FormblattBalanceDataset)

    End Sub

    Private Sub FormblattBalanceTotals_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick 'PASSIVA
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick 'AKTIVA

        'Get Max BSDate
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        cmd.CommandText = "Select Max([RiskDate]) from [Formblatt_BILANZ_TOTALS]"
        cmd.Connection.Open()
        d = cmd.ExecuteScalar
        dsql = d.ToString("yyyyMMdd")
        cmd.Connection.Close()
        'Input MaxDate in control
        Me.FromDateEdit.Text = d

        Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
        Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
        Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)

        

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource.EndEdit()
                If Me.FormblattBalanceDataset.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.FormblattBalanceDataset)
                        '************************************************
                        cmd.CommandText = "Update [Formblatt_BILANZ_TOTALS] set [AmountCurrentDate]=[AmountCurrentDate]+[AmountManualBooking] where [RiskDate]='" & dsql & "'"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        '************************************************
                        Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
                        Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
                        Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource.CancelEdit()
                Me.FormblattBalanceDataset.RejectChanges()
                Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
                Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
                Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
                Exit Sub
            End Try
        End If

        'Cancel edit
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource.CancelEdit()
            Me.FormblattBalanceDataset.RejectChanges()
            Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
            Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
            Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.EndEdit()
                If Me.FormblattBalanceDataset.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.FormblattBalanceDataset)
                        '************************************************
                        cmd.CommandText = "Update [Formblatt_BILANZ_TOTALS] set [AmountCurrentDate]=[AmountCurrentDate]+[AmountManualBooking] where [RiskDate]='" & dsql & "'"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        '************************************************
                        Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
                        Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
                        Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.CancelEdit()
                Me.FormblattBalanceDataset.RejectChanges()
                Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
                Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
                Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
                Exit Sub
            End Try
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.CancelEdit()
            Me.FormblattBalanceDataset.RejectChanges()
            Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
            Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
            Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
        End If

    End Sub

    Private Sub LoadDailyBalanceSheets_btn_Click(sender As Object, e As EventArgs) Handles LoadDailyBalanceSheets_btn.Click
        Me.GridControl1.DataSource = Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource
        Me.GridControl2.DataSource = Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource

        If IsDate(Me.FromDateEdit.Text) = True Then
            d = Me.FromDateEdit.Text
            dsql = d.ToString("yyyyMMdd")
            cmd.CommandText = "Select [RiskDate] from [Formblatt_BILANZ_TOTALS] where [RiskDate]='" & dsql & "' "
            cmd.Connection.Open()
            If IsDate(cmd.ExecuteScalar) = True Then
                'Load Balance Sheet
               Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
                Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
                Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
               
            Else
                MessageBox.Show("There's no Data for the indicated Date!", "NO DATA FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'Get Max BSDate

                cmd.CommandText = "Select Max([RiskDate]) from [Formblatt_BILANZ_TOTALS]"
                d = cmd.ExecuteScalar
                dsql = d.ToString("yyyyMMdd")

                'Input MaxDate in control
                Me.FromDateEdit.Text = d

                'Load Balance Sheet
                Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
                Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
                Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)

               
            End If
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub FromDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FromDateEdit.KeyDown
        If IsDate(Me.FromDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            
        End If
    End Sub

    Private Sub ActivaBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ActivaBaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
        If e.Column.Name.StartsWith("Billanzdifferenz") = True Then
            e.Column.AppearanceCell.ForeColor = Color.Yellow
        End If

    End Sub

    Private Sub ActivaBaseView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles ActivaBaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            ActivaSum = 0
            AktivaSumVorjahr = 0
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If CStr(View.GetRowCellValue(e.RowHandle, "AmountCurrentDate").ToString) <> "" Then
                If summaryID = 0 Then
                    ActivaSum += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            CheckField = CStr(View.GetRowCellValue(e.RowHandle, "BilanzpositionArt"))
            If summaryID = 2 Then
                If CheckField = "AKTIVA" Then
                    AktivaSumVorjahr += Convert.ToDecimal(e.FieldValue)
                End If
            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = ActivaSum
                TotalActivaSum = e.TotalValue
            End If
            If summaryID = 1 Then
                e.TotalValue = TotalActivaSum - TotalPassivaSum
            End If
            If summaryID = 2 Then
                e.TotalValue = AktivaSumVorjahr
            End If
        End If
    End Sub

    Private Sub ActivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaBaseView.RowStyle

        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            Dim BILANZPOSITION_ART As String = ActivaBaseView.GetRowCellValue(e.RowHandle, colBilanzpositionArt)
            If BILANZPOSITION_ART = "AKTIVA" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ActivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ActivaBaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva details für Bilanzposition: " & view.GetFocusedRowCellValue("Bilanzposition").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ActivaBaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva details für Bilanzposition: " & view.GetFocusedRowCellValue("Bilanzposition").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles ActivaBaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva details für Bilanzposition: " & view.GetFocusedRowCellValue("Bilanzposition").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles PassivaBaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub PassivaBaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles PassivaBaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            PassivaSum = 0
            PassivaSumVorjahr = 0
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If CStr(View.GetRowCellValue(e.RowHandle, "AmountCurrentDate").ToString) <> "" Then
                If summaryID = 0 Then
                    PassivaSum += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            CheckField = CStr(View.GetRowCellValue(e.RowHandle, "BilanzpositionArt"))
            If summaryID = 1 Then
                If CheckField = "PASSIVA" Then
                    PassivaSumVorjahr += Convert.ToDecimal(e.FieldValue)
                End If
            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = PassivaSum
                TotalPassivaSum = e.TotalValue
            End If
            If summaryID = 1 Then
                e.TotalValue = PassivaSumVorjahr
            End If
            If summaryID = 2 Then
                e.TotalValue = 0
            End If

        End If

    End Sub

    Private Sub PassivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaBaseView.RowStyle
        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            Dim BILANZPOSITION_ART As String = PassivaBaseView.GetRowCellValue(e.RowHandle, colBilanzpositionArt)
            If BILANZPOSITION_ART = "PASSIVA" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PassivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles PassivaBaseView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details für Bilanzposition: " & view.GetFocusedRowCellValue("Bilanzposition").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles PassivaBaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details für Bilanzposition: " & view.GetFocusedRowCellValue("Bilanzposition").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles PassivaBaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details für Bilanzposition: " & view.GetFocusedRowCellValue("Bilanzposition").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub DailyBalanceSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyBalanceSheet_Print_Export_btn.Click
        ' Create objects and define event handlers.
        Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
        AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
        Dim pcLink1 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink2 As PrintableComponentLink = New PrintableComponentLink()
        Dim linkMainReport As Link = New Link()
        AddHandler linkMainReport.CreateDetailArea, AddressOf linkMainReport_CreateDetailArea
        Dim linkGrid1Report As Link = New Link()
        AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
        Dim linkGrid2Report As Link = New Link()
        AddHandler linkGrid2Report.CreateDetailArea, AddressOf linkGrid2Report_CreateDetailArea

        ' Assign the controls to the printing links.
        pcLink1.Component = Me.GridControl2
        pcLink2.Component = Me.GridControl1

        ' Populate the collection of links in the composite link.
        ' The order of operations corresponds to the document structure.
        composLink.Links.Add(linkGrid1Report)
        composLink.Links.Add(pcLink1)
        composLink.Links.Add(linkMainReport)
        composLink.Links.Add(linkGrid2Report)
        composLink.Links.Add(pcLink2)

        composLink.Landscape = True
        composLink.PaperKind = System.Drawing.Printing.PaperKind.A4

        ' Create the report and show the preview window.
        composLink.ShowPreviewDialog()

    End Sub

    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim reportfooter As String = "Formblatt BILANZ" & "  " & "für den " & Me.FromDateEdit.Text & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "AKTIVA"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates an interval between the grids and fills it with color.
    Private Sub linkMainReport_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Rect = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        tb.BackColor = Color.Gray
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates a text header for the second grid.
    Private Sub linkGrid2Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "PASSIVA"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub PassivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PassivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ActivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ActivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
End Class