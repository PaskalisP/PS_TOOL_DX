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
Public Class HGB_GV

    Dim CrystalRepDir As String = ""

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim ActiveTabGroup As Double = 0

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

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

   

    Private Sub HGB_GV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [HGB_GV] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.FromDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.FromDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")

        Me.HGB_GL_ItemsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items, d)
        Me.HGB_GL_Items_Bookings_ALL_TableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items_Bookings_ALL, d)
        Me.HGB_GVTableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_GV, d)
        Me.HGB_GL_ItemsALL_TableAdapter.FillByGV_BSDate(Me.FormblattBalanceDataset.HGB_GL_ItemsALL, d)

    End Sub

   

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
        '    Try
        '        Me.Validate()
        '        Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.EndEdit()
        '        If Me.FormblattBalanceDataset.HasChanges = True Then
        '            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
        '                Me.TableAdapterManager.UpdateAll(Me.FormblattBalanceDataset)
        '                '************************************************
        '                cmd.CommandText = "Update [Formblatt_BILANZ_TOTALS] set [AmountCurrentDate]=[AmountCurrentDate]+[AmountManualBooking] where [RiskDate]='" & dsql & "'"
        '                cmd.Connection.Open()
        '                cmd.ExecuteNonQuery()
        '                cmd.Connection.Close()
        '                '************************************************
        '                Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
        '                Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
        '                Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
        '            Else
        '                e.Handled = True
        '            End If
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.CancelEdit()
        '        Me.FormblattBalanceDataset.RejectChanges()
        '        Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
        '        Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
        '        Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
        '        Exit Sub
        '    End Try
        'End If

        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
        '    Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.CancelEdit()
        '    Me.FormblattBalanceDataset.RejectChanges()
        '    Me.Formblatt_BILANZ_DetailsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_Details, d)
        '    Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_PASSIVA, d)
        '    Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.Formblatt_BILANZ_TOTALS_ACTIVA, d)
        'End If

    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl3.DataSource = Me.HGB_GL_Items_Bookings_ALLBindingSource
            Me.GridControl2.DataSource = Me.HGB_GVBindingSource
            Me.GridControl1.DataSource = Me.HGB_GL_ItemsALLBindingSource
            If IsDate(Me.FromDateEdit.Text) = True Then
                Dim d As Date = Me.FromDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load HGB-Gewinn + Verlust Rechnung for " & d)
                'Load HGB
                Me.HGB_GL_Items_Bookings_ALL_TableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items_Bookings_ALL, d)
                Me.HGB_GL_ItemsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items, d)
                Me.HGB_GVTableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_GV, d)
                Me.HGB_GL_ItemsALL_TableAdapter.FillByGV_BSDate(Me.FormblattBalanceDataset.HGB_GL_ItemsALL, d)
                SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            End If
        End If
    End Sub



    Private Sub FromDateEdit_KeyDown(sender As Object, e As KeyEventArgs)
        If IsDate(Me.FromDateEdit.Text) = True Then

            Me.GridControl2.DataSource = Nothing
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        If IsDate(Me.FromDateEdit.Text) = True Then
            Me.GridControl3.DataSource = Me.HGB_GL_Items_Bookings_ALLBindingSource
            Me.GridControl2.DataSource = Me.HGB_GVBindingSource
            Me.GridControl1.DataSource = Me.HGB_GL_ItemsALLBindingSource
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load HGB-Gewinn + Verlust Rechnung for " & d)
            'Load HGB
            Me.HGB_GL_Items_Bookings_ALL_TableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items_Bookings_ALL, d)
            Me.HGB_GL_ItemsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items, d)
            Me.HGB_GVTableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_GV, d)
            Me.HGB_GL_ItemsALL_TableAdapter.FillByGV_BSDate(Me.FormblattBalanceDataset.HGB_GL_ItemsALL, d)
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If
    End Sub

    Private Sub ActivaBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ActivaBaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
        'If e.Column.Name.StartsWith("Billanzdifferenz") = True Then
        '    e.Column.AppearanceCell.ForeColor = Color.Yellow
        'End If

    End Sub

    Private Sub ActivaBaseView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles ActivaBaseView.CustomSummaryCalculate
        'Dim View As GridView = CType(sender, GridView)
        'Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
        '    ActivaSum = 0
        '    AktivaSumVorjahr = 0
        'End If
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '    If CStr(View.GetRowCellValue(e.RowHandle, "AmountCurrentDate").ToString) <> "" Then
        '        If summaryID = 0 Then
        '            ActivaSum += Convert.ToDecimal(e.FieldValue)
        '        End If
        '    End If
        '    CheckField = CStr(View.GetRowCellValue(e.RowHandle, "BilanzpositionArt"))
        '    If summaryID = 2 Then
        '        If CheckField = "AKTIVA" Then
        '            AktivaSumVorjahr += Convert.ToDecimal(e.FieldValue)
        '        End If
        '    End If
        'End If
        '' Finalization 
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
        '    If summaryID = 0 Then
        '        e.TotalValue = ActivaSum
        '        TotalActivaSum = e.TotalValue
        '    End If
        '    If summaryID = 1 Then
        '        e.TotalValue = TotalActivaSum - TotalPassivaSum
        '    End If
        '    If summaryID = 2 Then
        '        e.TotalValue = AktivaSumVorjahr
        '    End If
        'End If
    End Sub

    Private Sub ActivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaBaseView.RowStyle

        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            If Not DBNull.Value.Equals(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_GV_ItemName)) Then
                If IsNumeric(Mid(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_GV_ItemName), 1, 1)) = True Then
                    e.Appearance.BackColor = Color.LightCyan
                    e.Appearance.BackColor2 = Color.WhiteSmoke
                    e.Appearance.ForeColor = Color.Black
                    'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub ActivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ActivaBaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Details für G + V Position: " & view.GetFocusedRowCellValue("HGB_GV_ItemName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ActivaBaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Details für G + V Position: " & view.GetFocusedRowCellValue("HGB_GV_ItemName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles ActivaBaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Details für G + V Position: " & view.GetFocusedRowCellValue("HGB_GV_ItemName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs)
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub PassivaBaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs)
        'Dim View As GridView = CType(sender, GridView)
        'Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
        '    PassivaSum = 0
        '    PassivaSumVorjahr = 0
        'End If
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '    If CStr(View.GetRowCellValue(e.RowHandle, "AmountCurrentDate").ToString) <> "" Then
        '        If summaryID = 0 Then
        '            PassivaSum += Convert.ToDecimal(e.FieldValue)
        '        End If
        '    End If
        '    CheckField = CStr(View.GetRowCellValue(e.RowHandle, "BilanzpositionArt"))
        '    If summaryID = 1 Then
        '        If CheckField = "PASSIVA" Then
        '            PassivaSumVorjahr += Convert.ToDecimal(e.FieldValue)
        '        End If
        '    End If
        'End If
        '' Finalization 
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
        '    If summaryID = 0 Then
        '        e.TotalValue = PassivaSum
        '        TotalPassivaSum = e.TotalValue
        '    End If
        '    If summaryID = 1 Then
        '        e.TotalValue = PassivaSumVorjahr
        '    End If
        '    If summaryID = 2 Then
        '        e.TotalValue = 0
        '    End If

        'End If

    End Sub

    

    Private Sub DailyBalanceSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyBalanceSheet_Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

        If ActiveTabGroup = 1 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub


    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("*Beinhaltet nicht die vollständige Steuerbelastung und ggfs. Bundesbank negativzinsen - Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "*Beinhaltet nicht die vollständige Steuerbelastung und ggfs. Bundesbank negativzinsen - Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "Aufwands- und Ertragsrechnung* der China Construction Bank Corporation Niederlassung Frankfurt vom 01.01 bis " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("*Beinhaltet nicht die vollständige Steuerbelastung und ggfs. ungebuchte Bundesbank negativzinsen - Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "*Beinhaltet nicht die vollständige Steuerbelastung und ggfs. Bundesbank negativzinsen - Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "Aufwands- und Ertragsrechnung  - HGB GL Items and Positions on" & Me.FromDateEdit.Text
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
        Dim reportfooter As String = "All GL Items and Manual Bookings on" & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
   
    
    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "TOTALS G+V" Then
            ActiveTabGroup = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "DETAILS G+V" Then
            ActiveTabGroup = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL GL ITEMS + MANUAL BOOKINGS" Then
            ActiveTabGroup = 2

        End If
    End Sub

    Private Sub HGB_GV_AllDetails_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles HGB_GV_AllDetails_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub HGB_GV_AllDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles HGB_GV_AllDetails_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub HGB_GV_AllDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles HGB_GV_AllDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub ActivaDetailView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ActivaDetailView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub ActivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub ActivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If

    End Sub

    Private Sub ALL_GLITEMS_BOOKINGS_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ALL_GLITEMS_BOOKINGS_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub ALL_GLITEMS_BOOKINGS_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ALL_GLITEMS_BOOKINGS_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub ALL_GLITEMS_BOOKINGS_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ALL_GLITEMS_BOOKINGS_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    
    Private Sub BalanceSheetCR_btn_Click(sender As Object, e As EventArgs) Handles BalanceSheetCR_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating HGB - G+V REPORT for " & Me.FromDateEdit.Text)
            'Me.DailyBalanceSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceSheets, d)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\HGB_GV_Daily.rpt")
            CrRep.SetDataSource(Me.FormblattBalanceDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "FDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "HGB - G+V REPORT from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(75)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub ActivaBaseView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ActivaBaseView.PrintInitialize
        If MessageBox.Show("Should also all the details of the HGB Profit/Loss Sheet be printed?", "Print Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
            Me.ActivaBaseView.OptionsPrint.ExpandAllDetails = True
        Else
            Me.ActivaBaseView.OptionsPrint.ExpandAllDetails = False
        End If
    End Sub
End Class