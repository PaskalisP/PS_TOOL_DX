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
Public Class IrsCreditEquivalentCalculation

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


    Private Sub IRS_CREDIT_EQUIVALENT_BasicBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.IRS_CREDIT_EQUIVALENT_BasicBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub IrsCreditEquivalentCalculation_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.IRS_BaseView.IsFindPanelVisible Then
            'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
            Dim find As FindControl = TryCast(IRS_BaseView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            find.FindEdit.Focus()
        Else
            IRS_BaseView.ShowFindPanel()
        End If
    End Sub

     

    Private Sub IrsCreditEquivalentCalculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [IRS CREDIT EQUIVALENT Basic] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
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

        Me.IRS_CREDIT_EQUIVALENT_DetailsALLTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_DetailsALL, MaxFxDate)
        Me.IRS_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Details, MaxFxDate)
        Me.IRS_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Basic, MaxFxDate)

        Me.XtraTabControl1.Focus()



    End Sub

    Private Sub FxDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FxDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.IRS_CREDIT_EQUIVALENT_BasicBindingSource
            Me.GridControl3.DataSource = Me.IRS_CREDIT_EQUIVALENT_DetailsALLBindingSource

            If IsDate(Me.FxDateEdit.Text) = True Then
                Dim d As Date = Me.FxDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                'Load  Data
                Me.IRS_CREDIT_EQUIVALENT_DetailsALLTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_DetailsALL, d)
                Me.IRS_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Details, d)
                Me.IRS_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Basic, d)
                SplashScreenManager.CloseForm(False)

            End If
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

    Private Sub FxDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FxDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.IRS_CREDIT_EQUIVALENT_BasicBindingSource
        Me.GridControl3.DataSource = Me.IRS_CREDIT_EQUIVALENT_DetailsALLBindingSource

        If IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
            'Load  Data
            Me.IRS_CREDIT_EQUIVALENT_DetailsALLTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_DetailsALL, d)
            Me.IRS_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Details, d)
            Me.IRS_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(Me.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Basic, d)
            SplashScreenManager.CloseForm(False)
           
        End If



    End Sub


    Private Sub IRS_BaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles IRS_BaseView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "IRS_BaseView" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "IRS Details for Client Group:" & view.GetFocusedRowCellValue("ClientGroupName").ToString & " (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.IRS_DetailView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub IRS_BaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles IRS_BaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "IRS_BaseView" Then
            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "IRS Details for Client Group:" & view.GetFocusedRowCellValue("ClientGroupName").ToString & " (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.IRS_DetailView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub IRS_BaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles IRS_BaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "IRS_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            DetailsViewCaption = "IRS Details for Client Group:" & view.GetFocusedRowCellValue("ClientGroupName").ToString & " (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.IRS_DetailView.ViewCaption = DetailsViewCaption
        End If
    End Sub

    Private Sub IRS_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IRS_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub IRS_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles IRS_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub IRS_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IRS_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub IRS_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles IRS_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub IRS_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IRS_DetailsAll_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub IRS_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles IRS_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
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
        Dim reportfooter As String = "INTEREST RATE SWAP- CREDIT EQUIVALENT CALCULATION " & vbNewLine & "on: " & Me.FxDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
        Dim reportfooter As String = "INTEREST RATE SWAP - CREDIT EQUIVALENT CALCULATION (ALL DETAILS) " & "  " & "on: " & Me.FxDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub FXReport_btn_Click(sender As Object, e As EventArgs) Handles FXReport_btn.Click
        If IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate Swap" & vbNewLine & "Credit Equivelant Calculations Report for " & Me.FxDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INTEREST_RATE_SWAP_CREDIT_EQUIV_CALC.rpt")
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
            c.Text = "Interest Rate Swap Credit Equivelant Calculations Report from " & d
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
End Class