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
Public Class BusinessTypesLiabilities

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date

    Dim CustomersVerticalGrid As New CustomersVG()
    Dim CustomerContractVG As New AllContractsAccountsVG()



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

    Private Sub BusinessTypesLiabilitiesLiveBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BusinessTypesLiabilitiesLiveBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub BusinessTypesLiabilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.BusinessTypeDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[DateMakCrTotals],104) as 'RLDC Date' from [BusinessTypesLiabilitiesLive] GROUP BY [DateMakCrTotals] Order by [DateMakCrTotals] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BusinessTypeDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BusinessTypeDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxBusinessTypesDate As Date = Me.BusinessTypeDateEdit.Text
       
        Me.BusinessTypesLiabilitiesDetailsAllTableAdapter.FillByBT_LIABILITIES_DETAILS(Me.RiskControllingDataSet.BusinessTypesLiabilitiesAllDetails, MaxBusinessTypesDate)
        Me.BusinessTypesLiabilitiesDetailsTableAdapter.FillByBT_LIABILITIES_DETAILS(Me.RiskControllingDataSet.BusinessTypesLiabilitiesDetails, MaxBusinessTypesDate)
        Me.BusinessTypesLiabilitiesLiveTableAdapter.FillByBT_LIABLITIES_ALL(Me.RiskControllingDataSet.BusinessTypesLiabilitiesLive, MaxBusinessTypesDate)
        Me.XtraTabControl1.Focus()
    End Sub

    Private Sub BusinessTypesLiabilities_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If Me.BT_CP_Totals_GridView.IsFindPanelVisible Then
        '    'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
        '    Dim find As FindControl = TryCast(BT_CP_Totals_GridView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
        '    find.FindEdit.Focus()
        'Else
        '    BT_CP_Totals_GridView.ShowFindPanel()
        'End If

    End Sub

    Private Sub LoadBusinessTypes_btn_Click(sender As Object, e As EventArgs) Handles LoadBusinessTypes_btn.Click
        
    End Sub

    Private Sub BT_CP_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BT_CP_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BT_CP_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BT_CP_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessTypeDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.BusinessTypesLiabilitiesLiveBindingSource
            Me.GridControl3.DataSource = Me.BusinessTypesLiabilitiesAllDetailsBindingSource

            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                Dim d As Date = Me.BusinessTypeDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Business Types for " & d)
                Me.BusinessTypesLiabilitiesDetailsAllTableAdapter.FillByBT_LIABILITIES_DETAILS(Me.RiskControllingDataSet.BusinessTypesLiabilitiesAllDetails, d)
                Me.BusinessTypesLiabilitiesDetailsTableAdapter.FillByBT_LIABILITIES_DETAILS(Me.RiskControllingDataSet.BusinessTypesLiabilitiesDetails, d)
                Me.BusinessTypesLiabilitiesLiveTableAdapter.FillByBT_LIABLITIES_ALL(Me.RiskControllingDataSet.BusinessTypesLiabilitiesLive, d)
                Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
                SplashScreenManager.CloseForm(False)

            End If
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_Click(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
        End If
    End Sub


    Private Sub BusinessTypeDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles BusinessTypeDateEdit.KeyDown
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
        End If
    End Sub
    Private Sub BT_CP_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_DetailsAll_Gridview.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BT_CP_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_BT_CP_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_Totals_Gridview_btn.Click
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
        Dim reportfooter As String = "BUSINESS TYPES - LIABILITIES " & "   " & "on: " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_BT_CP_DetailsAll_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_DetailsAll_Gridview_btn.Click
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
        Dim reportfooter As String = "BUSINESS TYPES - LIABILITIES (ALL DETAILS) " & "  " & "on: " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BusinessTyperReport_btn_Click(sender As Object, e As EventArgs) Handles BusinessTyperReport_btn.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Business Types - Liabilities Report for " & Me.BusinessTypeDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\BusinessTypes_Liabilities.rpt")
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Business Types - Liabilities Report from " & d
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

    Private Sub BusinessTypesLiabilitiesDetailsRep_btn_Click(sender As Object, e As EventArgs) Handles BusinessTypesLiabilitiesDetailsRep_btn.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Business Types - Liabilities Details Report for " & Me.BusinessTypeDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\BusinessTypes_LiabilitiesDetails.rpt")
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Business Types - Liabilities Details Report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.ShowGroupTree()
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub BusinessTypeDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.BusinessTypesLiabilitiesLiveBindingSource
        Me.GridControl3.DataSource = Me.BusinessTypesLiabilitiesAllDetailsBindingSource

        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

            Dim d As Date = Me.BusinessTypeDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
           
                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Business Types - Liabilities for " & d)
                Me.BusinessTypesLiabilitiesDetailsAllTableAdapter.FillByBT_LIABILITIES_DETAILS(Me.RiskControllingDataSet.BusinessTypesLiabilitiesAllDetails, d)
                Me.BusinessTypesLiabilitiesDetailsTableAdapter.FillByBT_LIABILITIES_DETAILS(Me.RiskControllingDataSet.BusinessTypesLiabilitiesDetails, d)
                Me.BusinessTypesLiabilitiesLiveTableAdapter.FillByBT_LIABLITIES_ALL(Me.RiskControllingDataSet.BusinessTypesLiabilitiesLive, d)
                Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
                SplashScreenManager.CloseForm(False)
           
        End If
    End Sub

    Private Sub BT_CP_DetailsAll_Gridview_DoubleClick(sender As Object, e As EventArgs) Handles BT_CP_DetailsAll_Gridview.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "Client No" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ClientNr) = False Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr
                        Me.CustomersVerticalGrid.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
            If view.FocusedColumn.FieldName = "Contract Collateral ID" Then
                Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract Collateral ID").ToString
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ContractNr) = False And IsNumeric(ContractNr) = True Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Contract Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        GLOBAL_CONTRACT_NR = ContractNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomerContractVG.Text = "Details for Contract Nr. " & ContractNr
                        Me.CustomerContractVG.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If
    End Sub
End Class