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
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports DevExpress.XtraReports.Parameters
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils

Public Class TrialBalance218

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim QueryText As String
    Private da As SqlDataAdapter
    Private dt As DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim ActiveTabGroup As Double = 0

    Dim Derivate_Sum As Double = 0
    Dim CheckField1 As String = Nothing
    Dim CheckField2 As String = Nothing

    Dim SumUSD12 As Double = 0
    Dim SumUSD112 As Double = 0
    Dim SumCNY12 As Double = 0
    Dim SumCNY112 As Double = 0

    Dim SumField2 As Double = 0
    Dim SumField3 As Double = 0


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

    Private Sub TRIAL_BALANCE_218BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TRIAL_BALANCE_218BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub TrialBalance218_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Bind Combobox
        Me.TrialBalanceDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RepDate],104) as 'RLDC Date' from [TRIAL_BALANCE_218] group by [RepDate] order by [RepDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.TrialBalanceDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.TrialBalanceDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxTrialBalanceDate As Date = Me.TrialBalanceDateEdit.Text

        Me.TRIAL_BALANCE_218TableAdapter.FillByTBDate(Me.PSTOOLDataset.TRIAL_BALANCE_218, MaxTrialBalanceDate)
        LOAD_TRIAL_BALANCE_217()
        LOAD_TRIAL_BALANCE_222()

    End Sub

    Private Sub LOAD_TRIAL_BALANCE_217()
        Try
            rd = Me.TrialBalanceDateEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            Dim da As SqlDataAdapter
            Dim objCMD As SqlCommand = New SqlCommand("Select * from [TRIAL_BALANCE_217] where [RiskDate]='" & rdsql & "' ", conn)
            objCMD.CommandTimeout = 5000
            da = New SqlDataAdapter(objCMD)
            'da.SelectCommand = objCMD
            '*******************************************************************
            dt = New DataTable()
            da.Fill(dt)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.GridControl3.DataSource = Nothing
                Me.GridControl3.DataSource = dt
                Me.GridControl3.ForceInitialize()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub LOAD_TRIAL_BALANCE_222()
        Try
            rd = Me.TrialBalanceDateEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            Dim da As SqlDataAdapter
            Dim objCMD As SqlCommand = New SqlCommand("Select * from [TRIAL_BALANCE_222] where [RepDate]='" & rdsql & "' ", conn)
            objCMD.CommandTimeout = 5000
            da = New SqlDataAdapter(objCMD)
            'da.SelectCommand = objCMD
            '*******************************************************************
            dt = New DataTable()
            da.Fill(dt)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.GridControl4.DataSource = Nothing
                Me.GridControl4.DataSource = dt
                Me.GridControl4.ForceInitialize()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub TrialBalanceBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles TrialBalanceBaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub TrialBalanceBaseView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles TrialBalanceBaseView.CustomDrawRowIndicator
        'e.Info.DisplayText = e.RowHandle.ToString
    End Sub

    Private Sub TrialBalanceBaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles TrialBalanceBaseView.CustomSummaryCalculate
        'Die Custom Summaries müssen in jeder Column unter Summaries angegeben werden
        ' mit der Tag Nr.

        'Dim View As GridView = CType(sender, GridView)
        'Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        '' Initialization 
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
        '    Derivate_Sum = 0
        '    SumUSD12 = 0
        '    SumUSD112 = 0
        '    SumCNY12 = 0
        '    SumCNY112 = 0
        'End If
        '' Calculation 
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '    If CStr(View.GetRowCellValue(e.RowHandle, "AccountNo").ToString) <> "" Then
        '        CheckField1 = CStr(View.GetRowCellValue(e.RowHandle, "AccountNo"))
        '        CheckField2 = CStr(View.GetRowCellValue(e.RowHandle, "AccountName"))
        '        'Calculation Derivative Adressenausfallrisikopositionen und Aufrechnungspositionen nach § 12 Abs. 1 SolvV 
        '        If summaryID = 1 Then
        '            Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "Totals"))
        '            If CheckField1.StartsWith("36") = True And CheckField2.EndsWith("contra") = False Then
        '                Derivate_Sum += Convert.ToDecimal(e.FieldValue)
        '            End If
        '        End If
        '        'Calculation USD12 and USD112
        '        If summaryID = 2 Then
        '            If CheckField1.Contains("36014793") = True OrElse CheckField1.Contains("36016793") = True Then
        '                SumUSD12 += Convert.ToDecimal(e.FieldValue)
        '            End If
        '        End If
        '        If summaryID = 3 Then
        '            If CheckField1.Contains("36015793") = True OrElse CheckField1.Contains("36017793") = True Then
        '                SumUSD112 += Convert.ToDecimal(e.FieldValue)
        '            End If
        '        End If
        '        'Calculation CNY12 and CNY112
        '        If summaryID = 4 Then
        '            If CheckField1.Contains("36014793") = True OrElse CheckField1.Contains("36016793") = True Then
        '                SumCNY12 += Convert.ToDecimal(e.FieldValue)
        '            End If
        '        End If
        '        If summaryID = 5 Then
        '            If CheckField1.Contains("36015793") = True OrElse CheckField1.Contains("36017793") = True Then
        '                SumCNY112 += Convert.ToDecimal(e.FieldValue)
        '            End If
        '        End If
        '    End If
        'End If
        '' Finalization 
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
        '    If summaryID = 1 Then
        '        e.TotalValue = Derivate_Sum * 0.02
        '    End If
        '    If summaryID = 2 Then
        '        e.TotalValue = SumUSD12
        '    End If
        '    If summaryID = 3 Then
        '        e.TotalValue = SumUSD112 * (-1)
        '    End If
        '    If summaryID = 4 Then
        '        e.TotalValue = SumCNY12
        '    End If
        '    If summaryID = 5 Then
        '        e.TotalValue = SumCNY112 * (-1)
        '    End If
        'End If
    End Sub

    Private Sub TrialBalanceBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TrialBalanceBaseView.RowStyle
        'Set backcolor fur Subtotal Fields
        'If (e.RowHandle >= 0) Then
        '    Dim ACCNNAME As String = TrialBalanceBaseView.GetRowCellValue(e.RowHandle, colAccountName)
        '    If ACCNNAME.StartsWith("(") = True Or ACCNNAME.StartsWith("Total") = True Then
        '        e.Appearance.BackColor = Color.Orange
        '        e.Appearance.BackColor2 = Color.Orange
        '        e.Appearance.ForeColor = Color.Black
        '        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '    End If
        'End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TrialBalanceDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TrialBalanceDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl2.DataSource = Me.TRIAL_BALANCE_218BindingSource

            If IsDate(Me.TrialBalanceDateEdit.Text) = True Then
                Dim d As Date = Me.TrialBalanceDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Trial Balance Report Data for " & d)
                'Load Fristen Data
                Me.TRIAL_BALANCE_218TableAdapter.FillByTBDate(Me.PSTOOLDataset.TRIAL_BALANCE_218, d)
                LOAD_TRIAL_BALANCE_217()
                LOAD_TRIAL_BALANCE_222()

                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub TrialBalanceDateEdit_Click(sender As Object, e As EventArgs) Handles TrialBalanceDateEdit.Click
        If IsDate(Me.TrialBalanceDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
        End If
    End Sub

    Private Sub TrialBalanceDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles TrialBalanceDateEdit.KeyDown
        If IsDate(Me.TrialBalanceDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadTrialBalance_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TrialBalance_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles TrialBalance_Print_Export_btn.Click
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
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 2 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
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
        Dim reportfooter As String = "TRIAL BALANCE 218 Report " & "  " & "on: " & Me.TrialBalanceDateEdit.Text
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
        Dim reportfooter As String = "TRIAL BALANCE 217 Report " & "  " & "on: " & Me.TrialBalanceDateEdit.Text
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
        Dim reportfooter As String = "TRIAL BALANCE 222 Report " & "  " & "on: " & Me.TrialBalanceDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub TrialBalanceBaseView_ShownEditor(sender As Object, e As EventArgs) Handles TrialBalanceBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        'If e.SelectedControl IsNot GridControl2 Then
        '    Return
        'End If

        'Dim info As ToolTipControlInfo = Nothing
        'Dim view As GridView = TryCast(GridControl2.GetViewAt(e.ControlMousePosition), GridView)
        'If view Is Nothing Then
        '    Return
        'End If
        'Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'If hi.HitTest = GridHitTest.Footer AndAlso hi.Column IsNot Nothing AndAlso hi.Column.SummaryItem.SummaryType = SummaryItemType.Custom Then
        '    If hi.Column.FieldName = "USDequEUR" Then
        '        Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
        '        'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
        '        Dim text As String = "Custom Sums calculated as follows:" & vbNewLine & "USD(12)=36014793+36016793" & vbNewLine & "USD(112)=36015793+36017793" & vbNewLine & vbNewLine _
        '                             & "The Amounts must be inserted in to the BAIS Form- SolvV KSA - MKRFW - Row 12 and Row 112"
        '        info = New ToolTipControlInfo(o, text)
        '    ElseIf hi.Column.FieldName = "OtherCurrequEUR" Then
        '        Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
        '        'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
        '        Dim text As String = "Custom Sums calculated as follows:" & vbNewLine & "CNY(12)=36014793+36016793" & vbNewLine & "CNY(112)=36015793+36017793" & vbNewLine & vbNewLine _
        '                             & "The Amounts must be inserted in to the BAIS Form- SolvV KSA - MKRFW - CNY Row 12 and CNY Row 112"
        '        info = New ToolTipControlInfo(o, text)
        '    ElseIf hi.Column.FieldName = "Totals" Then
        '        Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
        '        Dim text As String = "Kreditäquivalenzbetrag as follows:" & vbNewLine & "Sum of the Derivates * 2%" & vbNewLine & vbNewLine _
        '                             & "The Amounts must be inserted in to the BAIS Form- SolvV KSA - KSAE6 - Row 110"
        '        info = New ToolTipControlInfo(o, text)
        '    End If

        'End If
        'If info IsNot Nothing Then
        '    e.Info = info
        'End If
    End Sub

    Private Sub TrialBalanceDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TrialBalanceDateEdit.SelectedIndexChanged
        Me.GridControl2.DataSource = Me.TRIAL_BALANCE_218BindingSource

        If IsDate(Me.TrialBalanceDateEdit.Text) = True Then
            Dim d As Date = Me.TrialBalanceDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Trial Balance Report Data for " & d)
                'Load Fristen Data
            Me.TRIAL_BALANCE_218TableAdapter.FillByTBDate(Me.PSTOOLDataset.TRIAL_BALANCE_218, d)
            LOAD_TRIAL_BALANCE_217()
            LOAD_TRIAL_BALANCE_222()

            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub TrialBalance217_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles TrialBalance217_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub TrialBalance217_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TrialBalance217_GridView.RowStyle
        'Set backcolor fur Subtotal Fields
        'If (e.RowHandle >= 0) Then
        '    Dim ACCNNAME As String = TrialBalance217_GridView.GetRowCellValue(e.RowHandle, colAccountName)
        '    If ACCNNAME.StartsWith("(") = True Or ACCNNAME.StartsWith("Total") = True Then
        '        e.Appearance.BackColor = Color.Orange
        '        e.Appearance.BackColor2 = Color.Orange
        '        e.Appearance.ForeColor = Color.Black
        '        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '    End If
        'End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TrialBalance217_GridView_ShownEditor(sender As Object, e As EventArgs) Handles TrialBalance217_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TrialBalance222_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles TrialBalance222_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub TrialBalance222_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TrialBalance222_GridView.RowStyle
        'Set backcolor fur Subtotal Fields
        'If (e.RowHandle >= 0) Then
        '    Dim ACCNNAME As String = TrialBalance222_GridView.GetRowCellValue(e.RowHandle, colAccountName)
        '    If ACCNNAME.StartsWith("(") = True Or ACCNNAME.StartsWith("Total") = True Then
        '        e.Appearance.BackColor = Color.Orange
        '        e.Appearance.BackColor2 = Color.Orange
        '        e.Appearance.ForeColor = Color.Black
        '        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '    End If
        'End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TrialBalance222_GridView_ShownEditor(sender As Object, e As EventArgs) Handles TrialBalance222_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "TRIAL BALANCE 218 (Consolidaded)" Then
            ActiveTabGroup = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "TRIAL BALANCE 217 (Single Currency)" Then
            ActiveTabGroup = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "TRIAL BALANCE 222 (YTD Average)" Then
            ActiveTabGroup = 2
        End If
    End Sub
End Class