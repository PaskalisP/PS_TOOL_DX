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
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Public Class FxCreditEquivalentCalculation
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date
    Dim CCB_Guarantees_Sum As Double = 0
    Dim TOTAL_SUM_FX_EQUIV As Double = 0
    Dim CheckField1 As String = Nothing
    Dim CCB_GROUP_CREDIT_EQUIV As Double = 0
    Dim CCB_GROUP_CREDIT_EQUIV_TOTAL As Double = 0

    Dim DetailsViewCaption As String = Nothing


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

    Private Sub FX_CREDIT_EQUIVALENT_BasicBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FX_CREDIT_EQUIVALENT_BasicBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub FxCreditEquivalentCalculation_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If Me.FX_BaseView.IsFindPanelVisible Then
        '    'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
        '    Dim find As FindControl = TryCast(FX_BaseView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
        '    find.FindEdit.Focus()
        'Else
        '    FX_BaseView.ShowFindPanel()
        'End If
    End Sub

    Private Sub FxCreditEquivalentCalculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************

        'Bind Combobox
        Me.FxDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [FX CREDIT EQUIVALENT Basic] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.FxDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.FxDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxFxDate As Date = Me.FxDateEdit.Text
        Dim SqlMaxFxDate As String = MaxFxDate.ToString("yyyyMMdd")

        'Get Sum Amount CCB Guarantees
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxFxDate & "'"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
            CCB_Guarantees_Sum = Me.CCB_Guarantees_lbl.Text
        Else
            Me.CCB_Guarantees_lbl.Text = "0,00"
            CCB_Guarantees_Sum = 0
        End If
        'Get CCB GROUP CREDIT EQUIVALENT
        cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic] where [ClientGroup]='1000' and [RiskDate]='" & SqlMaxFxDate & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxFxDate & "') QUERY"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            Me.CCB_Group_CreditEquiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
        Else
            Me.CCB_Group_CreditEquiv_lbl.Text = "0,00"
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

        Me.FX_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_Details, MaxFxDate)
        Me.FX_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_Basic, MaxFxDate)
        Me.FX_CREDIT_EQUIVALENT_DetailsALLTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_DetailsALL, MaxFxDate)

        Me.XtraTabControl1.Focus()

    End Sub

    Private Sub FX_BaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles FX_BaseView.CustomDrawFooterCell
        
        If e.Column.FieldName = "CreditEquivelantAmount" Then
            Dim ID As String = e.Info.SummaryItem.Tag
            If ID = "11" Then
                e.Appearance.ForeColor = Color.Cyan
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If

        Else
            e.Appearance.ForeColor = Color.Yellow
        End If



    End Sub

    Private Sub FX_BaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles FX_BaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            TOTAL_SUM_FX_EQUIV = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "CreditEquivelantAmount"))
            If CStr(View.GetRowCellValue(e.RowHandle, "ClientGroup").ToString) <> "" Then
                CheckField1 = CStr(View.GetRowCellValue(e.RowHandle, "ClientGroup"))
                If summaryID = 11 Then
                    If CheckField1 = "1000" Then
                        TOTAL_SUM_FX_EQUIV += Convert.ToDecimal(e.FieldValue)
                    End If
                End If
            End If
            CCB_Guarantees_Sum = Me.CCB_Guarantees_lbl.Text
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If Me.CCB_Guarantees_lbl.Text <> "" Then
                CCB_Guarantees_Sum = Me.CCB_Guarantees_lbl.Text
            Else
                CCB_Guarantees_Sum = 0
            End If
            If summaryID = 11 Then
                e.TotalValue = TOTAL_SUM_FX_EQUIV + CCB_Guarantees_Sum
            End If
        End If

    End Sub

    Private Sub FX_BaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles FX_BaseView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "FX_BaseView" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "FX DEALS Details for Client Group:" & view.GetFocusedRowCellValue("ClientGroupName").ToString & " (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.FX_DetailView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub FX_BaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles FX_BaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "FX_BaseView" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "FX DEALS Details for Client Group:" & view.GetFocusedRowCellValue("ClientGroupName").ToString & " (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.FX_DetailView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub FX_BaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles FX_BaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "FX_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "FX DEALS Details for Client Group:" & view.GetFocusedRowCellValue("ClientGroupName").ToString & " (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.FX_DetailView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub FX_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles FX_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FX_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles FX_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click
      

       
    End Sub

    

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
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
        
        Dim reportfooter As String = "FX - CREDIT EQUIVALENT CALCULATION on: " & Me.FxDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub FxDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FxDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.FX_CREDIT_EQUIVALENT_BasicBindingSource
            Me.GridControl3.DataSource = Me.FX_CREDIT_EQUIVALENT_DetailsALLBindingSource

            If IsDate(Me.FxDateEdit.Text) = True Then
                Dim d As Date = Me.FxDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                'Load  Data
                Me.FX_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_Details, d)
                Me.FX_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_Basic, d)
                Me.FX_CREDIT_EQUIVALENT_DetailsALLTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_DetailsALL, d)
                'Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
                cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & dsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
                    CCB_Guarantees_Sum = Me.CCB_Guarantees_lbl.Text
                Else
                    Me.CCB_Guarantees_lbl.Text = "0,00"
                    CCB_Guarantees_Sum = 0
                End If
                'Get CCB GROUP CREDIT EQUIVALENT
                cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic] where [ClientGroup]='1000' and [RiskDate]='" & dsql & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & dsql & "') QUERY"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    Me.CCB_Group_CreditEquiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
                Else
                    Me.CCB_Group_CreditEquiv_lbl.Text = "0,00"
                End If
                SplashScreenManager.CloseForm(False)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If

            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
        End If
    End Sub

    Private Sub FxDateEdit_Click(sender As Object, e As EventArgs) Handles FxDateEdit.Click
        If IsDate(Me.FxDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub FxDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FxDateEdit.KeyDown
        If IsDate(Me.FxDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub FxCreditEquivalentCalculation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If Me.FX_BaseView.IsFindPanelVisible Then
        '    'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
        '    Dim find As FindControl = TryCast(FX_BaseView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
        '    find.FindEdit.Focus()
        'Else
        '    FX_BaseView.ShowFindPanel()
        'End If
    End Sub

    Private Sub FXReport_btn_Click(sender As Object, e As EventArgs) Handles FXReport_btn.Click
        If IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating FX Credit Equivelant Calculations Report for " & Me.FxDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\FX_CREDIT_EQUIV_CALC.rpt")
            CrRep.SetDataSource(AccountingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "FX Credit Equivelant Calculations Report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub CCB_Guarantees_lbl_TextChanged(sender As Object, e As EventArgs) Handles CCB_Guarantees_lbl.TextChanged
        CCB_Guarantees_Sum = Me.CCB_Guarantees_lbl.Text

    End Sub

    Private Sub CCB_Group_CreditEquiv_lbl_TextChanged(sender As Object, e As EventArgs) Handles CCB_Group_CreditEquiv_lbl.TextChanged
        If CCB_Group_CreditEquiv_lbl.Text <> "" AndAlso IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            Dim N As Double = Me.CCB_Group_CreditEquiv_lbl.Text
            If d <= DateSerial(2017, 6, 20) Then
                If N <= 75000000 Then
                    Me.Status_lbl.Text = "NO MEASURES"
                ElseIf N > 75000000 And N <= 90000000 Then
                    Me.Status_lbl.Text = "EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM"
                ElseIf N > 90000000 Then
                    Me.Status_lbl.Text = "NO TRANSACTIONS"
                End If
            ElseIf d > DateSerial(2017, 6, 20) Then
                If N <= 130000000 Then
                    Me.Status_lbl.Text = "NO MEASURES"
                ElseIf N > 130000000 And N <= 140000000 Then
                    Me.Status_lbl.Text = "EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM"
                ElseIf N > 140000000 Then
                    Me.Status_lbl.Text = "NO TRANSACTIONS"
                End If
            End If

        End If
    End Sub

   

   

    Private Sub Print_Export_FX_DetailsAll_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_FX_DetailsAll_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
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
        Dim reportfooter As String = "FX - CREDIT EQUIVALENT CALCULATION (ALL DETAILS) " & "  " & "on: " & Me.FxDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

  

    Private Sub FX_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_DetailsAll_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles FX_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

  
    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
       
        If e.SelectedControl Is GridControl1 Then
            Dim view As GridView = TryCast(GridControl1.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InRowCell Then
                'Dim text As String = "Text - " & view.GetRowCellDisplayText(info.RowHandle, info.Column)
                'Dim cellKey As String = info.RowHandle.ToString() & " - " & info.Column.ToString()
                'e.Info = New DevExpress.Utils.ToolTipControlInfo(cellKey, text)

            End If
            If info.InColumn And Me.GridControl1.FocusedView.Name = "FX_DetailView" Then
                If info.Column.FieldName = "MonthToEventStartDate" Then
                    Dim text As String = "Calculated as follows:" & vbNewLine & _
                        "Datediff between Final Maturity Date and Modified Start Date" & vbNewLine & _
                        "If Final Maturity Day is Monday then - 3 Days in the calculation"
                    e.Info = New DevExpress.Utils.ToolTipControlInfo("Calculation", text)
                End If
                If info.Column.FieldName = "ModifiedStartDate" Then
                    Dim text As String = "Calculated as follows:" & vbNewLine & _
                        "If Input Date=Start Date then Modified Start Date=Start Date + 2 Days" & vbNewLine & _
                        "If Modified Start Day is Saturday then + 2 Days" & vbNewLine & _
                        "If Modified Start Day is Sunday then + 1 Days"
                    e.Info = New DevExpress.Utils.ToolTipControlInfo("Calculation", text)
                End If

            End If
        End If

        If e.SelectedControl Is GridControl3 Then
            Dim view As GridView = TryCast(GridControl3.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                If info.Column.FieldName = "MonthToEventStartDate" Then
                    Dim text As String = "Calculated as follows:" & vbNewLine & _
                        "Datediff between Final Maturity Date and Modified Start Date" & vbNewLine & _
                        "If Final Maturity Day is Monday then - 3 Days in the calculation"
                    e.Info = New DevExpress.Utils.ToolTipControlInfo("Calculation", text)
                End If
                If info.Column.FieldName = "ModifiedStartDate" Then
                    Dim text As String = "Calculated as follows:" & vbNewLine & _
                        "If Input Date=Start Date then Modified Start Date=Start Date + 2 Days" & vbNewLine & _
                        "If Modified Start Day is Saturday then + 2 Days" & vbNewLine & _
                        "If Modified Start Day is Sunday then + 1 Days"
                    e.Info = New DevExpress.Utils.ToolTipControlInfo("Calculation", text)
                End If
            End If
        End If




    End Sub

   

    Private Sub FX_CredEquiv_Calculate_btn_Click(sender As Object, e As EventArgs) Handles FX_CredEquiv_Calculate_btn.Click
        If IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            Dim rdsql As String = d.ToString("yyyyMMdd")

            If MessageBox.Show("Should FX Credit Equivalent Calculation with data from " & d & " be calculated?", "CALCULATION FX CREDIT EQUIVALENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Start calculating FX Credit Equivalent")
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandTimeout = 50000

                    cmd.CommandText = "DELETE  FROM [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE  FROM [FX CREDIT EQUIVALENT Basic] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Import Data in details
                    SplashScreenManager.Default.SetWaitFormCaption("Insert Data in FX CREDIT EQUIVALENT Details from FX DAILY REVALUATION where DealType in (FW,SW) and MaturityDate > RiskDate for " & d)
                    cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Details]([Class],[ContractType],[ProductType],[Contract],[Counterparty_Name],[Counterparty_No],[TradeDate],[StartDate],[Final_Maturity_Date],[AmountType],[OrgCcy],[OrgCcyAmount],[RiskDate],[RepDate])SELECT [DealType],[ContractType],[ProductType],[ContractNr],[ClientName],[ClientNo],[InputDate],[ValueDate],[MaturityDate],'Bank Buy Amount',[BuyCCY],[BuyAmount],[RiskDate],[RiskDate] from [FX DAILY REVALUATION] where [DealType] in ('FW','SW') and [MaturityDate]>[RiskDate] and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update Client Group in Details
                    SplashScreenManager.Default.SetWaitFormCaption("Update Client Group Nr. and client Group Name in FX CREDIT EQUIVALENT Details from CUSTOMER_RATING")
                    cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [CUSTOMER_RATING] B ON A.[Counterparty_No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update Client Group in Details
                    SplashScreenManager.Default.SetWaitFormCaption("Set Client Group and Name to UNDEFINED if Client Nr is NULL")
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] SET [ClientGroup]=999999,[ClientGroupName]='UNDEFINED GROUP' where [Counterparty_No] is NULL and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Set Client Group=Client Nr in FX CREDIT EQUIVALENT Details where Client Group is NULL")
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] SET [ClientGroup]=[Counterparty_No],[ClientGroupName]=[Counterparty_Name]  where [ClientGroup] is NULL and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update OCBS Exchange Rates-Last working day
                    SplashScreenManager.Default.SetWaitFormCaption("Update Exchange Rates in FX CREDIT EQUIVALENT Details")
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] set [ExchangeRate]=1 where [OrgCcy]='EUR' and [ExchangeRate] is NULL and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[ExchangeRate] is NULL and B.[EXCHANGE RATE DATE]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Calculate EuroEquivelant
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate Euro Equivalent nominal amount in FX CREDIT EQUIVALENT Details")
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] set [EURequ]=Round([OrgCcyAmount]/[ExchangeRate],2) where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                    'Import Data in Basic
                    SplashScreenManager.Default.SetWaitFormCaption("Import Data in FX CREDIT EQUIVALENT Basic")
                    cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Basic]([RiskDate],[ClientGroup])select [RiskDate],[ClientGroup] from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [RiskDate],[ClientGroup]"
                    cmd.ExecuteNonQuery()
                    'Update Client Group Name
                    SplashScreenManager.Default.SetWaitFormCaption("Update Client Group Name in FX CREDIT EQUIVALENT Basic")
                    cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [FX CREDIT EQUIVALENT Basic] A INNER JOIN [FX CREDIT EQUIVALENT Details] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details
                    SplashScreenManager.Default.SetWaitFormCaption("Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details")
                    cmd.CommandText = "UPDATE A set A.[IdFX_CRED_EQU_BASIC]=B.[ID] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [FX CREDIT EQUIVALENT Basic] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate] and A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update PD,LGD,Obligor Rate in FX CREDIT EQUIVALENT Details
                    SplashScreenManager.Default.SetWaitFormCaption("Update PD,LGD,Obligor Rate in FX CREDIT EQUIVALENT Details")
                    cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[LGD]=B.[ER_45],A.[Obligor Rate]=B.[Rating] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [CUSTOMER_RATING] B ON A.[Counterparty_No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update MonthsToEventStartDay
                    SplashScreenManager.Default.SetWaitFormCaption("Update MonthsToEventStartDay in FX CREDIT EQUIVALENT Details")
                    SplashScreenManager.Default.SetWaitFormCaption("Update ModifiedStartDate= If Trade Date=Start Date then StartDate + Next Business Day (SQL Function=GetNextWorkingDate) + 1 ELSE StartDate")
                    cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when [TradeDate]=[StartDate] then dbo.GetNextWorkingDay([StartDate])+1 else [StartDate] end) where  [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Modify ModifiedStartDate= If Saturday then + 2 Days and If Sunday then + 1")
                    cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when DATENAME(dw,[ModifiedStartDate]) in ('Sunday') then DATEADD(day,1,[ModifiedStartDate])when DATENAME(dw,[ModifiedStartDate]) in ('Saturday') then DATEADD(day,2,[ModifiedStartDate])else [ModifiedStartDate]end) where  [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update ModifiedStartDate= If Modified Start Date is HOLIDAY then GetNextWorkingDate ELSE ModifiedStartDate")
                    cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=dbo.GetNextWorkingDay([ModifiedStartDate]) where  [RiskDate]='" & rdsql & "' and [ModifiedStartDate] in (Select [CalendarDate] from [Calendar] where [HolidayType] in ('H'))"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update Modified_FinalMaturityDate=If Final_Maturity_Date is MONDAY then - 3 Days else Final_Maturity_Date")
                    cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [Modified_Final_Maturity_Date]=(Case when DATENAME(dw,[Final_Maturity_Date]) in ('Monday') then [Final_Maturity_Date]-3 else [Final_Maturity_Date] end)  where  [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update MonthToEventStartDate to Years(NOT CONSIDERING LEAP YEARS)")
                    cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [MonthToEventStartDate]=dbo.yearDiff([Modified_Final_Maturity_Date],[ModifiedStartDate]) where  [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update Percent Calculation in FX CREDIT EQUIVALENT Details where Modified Start Date <= Business Date and Final Maturity Date <> Working Date")
                    cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.02 where [MonthToEventStartDate]<=1 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.05 where [MonthToEventStartDate]>1 and [MonthToEventStartDate]<=2 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "'end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.08 where [MonthToEventStartDate]>2 and [MonthToEventStartDate]<=3 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.11 where [MonthToEventStartDate]>3 and [MonthToEventStartDate]<=4 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.14 where [MonthToEventStartDate]>4 and [MonthToEventStartDate]<=5 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.17 where [MonthToEventStartDate]>5 and [MonthToEventStartDate]<=6 and [Final_Maturity_Date]<> '" & rdsql & "' and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.20 where [MonthToEventStartDate]>6 and [MonthToEventStartDate]<=7 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "'  and [RiskDate]='" & rdsql & "' end"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update EURequCalculated  and CreditRiskAmountER in FX CREDIT EQUIVALENT Details")
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] set [EURequCalculated]=[EURequ]*[PercentCalculation] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] SET [CreditRiskAmountER]=[EURequCalculated]*[PD]*[LGD] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update Sum Fields in FX CREDIT EQUIVALENT Basic
                    SplashScreenManager.Default.SetWaitFormCaption("Update Sum Fields in FX CREDIT EQUIVALENT Basic")
                    cmd.CommandText = "UPDATE A SET A.[SumEURequ]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequ]) as S from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmount]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountTill1Jear]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [PercentCalculation]=0.02 and [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver1Till2Years]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [PercentCalculation]=0.05 and [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver2Years]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [PercentCalculation]=0.08 and [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditRiskAmountSUM]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([CreditRiskAmountER]) as S from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    SplashScreenManager.Default.SetWaitFormCaption("Reload Data for " & d)
                    Me.LoadData_btn.PerformClick()
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End Try
            End If
        Else
            MessageBox.Show("Please input the Business Date", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If


    End Sub

    Private Sub FxDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FxDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.FX_CREDIT_EQUIVALENT_BasicBindingSource
        Me.GridControl3.DataSource = Me.FX_CREDIT_EQUIVALENT_DetailsALLBindingSource

        If IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
            'Load  Data
            Me.FX_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_Details, d)
            Me.FX_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_Basic, d)
            Me.FX_CREDIT_EQUIVALENT_DetailsALLTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_CREDIT_EQUIVALENT_DetailsALL, d)
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & dsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
                CCB_Guarantees_Sum = Me.CCB_Guarantees_lbl.Text
            Else
                Me.CCB_Guarantees_lbl.Text = "0,00"
                CCB_Guarantees_Sum = 0
            End If
            'Get CCB GROUP CREDIT EQUIVALENT
            cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic] where [ClientGroup]='1000' and [RiskDate]='" & dsql & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & dsql & "') QUERY"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.CCB_Group_CreditEquiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Else
                Me.CCB_Group_CreditEquiv_lbl.Text = "0,00"
            End If
            SplashScreenManager.CloseForm(False)

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If

        'Me.LayoutControlItem7.Visibility = LayoutVisibility.Always

    End Sub
End Class