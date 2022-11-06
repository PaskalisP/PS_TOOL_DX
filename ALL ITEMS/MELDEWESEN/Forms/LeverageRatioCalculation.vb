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
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Spreadsheet
Public Class LeverageRatioCalculation

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim SqlCommandText As String = Nothing

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim CVA_ExcelFileName As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing


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

    Private Sub LeverageRatioCalculation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.LoadList_btn.PerformClick()

        End If
    End Sub

   

    Private Sub LeverageRatioCalculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='CVA Calculation in Excel' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES_DIRECTORY' and [PARAMETER STATUS]='Y'"
        CVA_ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()


        'Bind Combobox
        Me.CAR_DateEdit_ComboEdit.Properties.Items.Clear()
        'Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20140101' and [PL Result] is not NULL ORDER BY [ID] desc"
        Me.QueryText = "Select CONVERT(VARCHAR(10),[Solvv_Date],104) as 'RLDC Date' from [SOLVV_Date] where [LR_Ratio] is not NULL ORDER BY [Solvv_Date] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.CAR_DateEdit_ComboEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        'If dt.Rows.Count > 0 Then
        'Me.CAR_DateEdit_ComboEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        'End If

        'rd = DateSerial(Microsoft.VisualBasic.Right(Me.CAR_DateEdit_ComboEdit.Text, 4), Mid(Me.CAR_DateEdit_ComboEdit.Text, 4, 2), Microsoft.VisualBasic.Left(Me.CAR_DateEdit_ComboEdit.Text, 2))
        'rdsql = rd.ToString("yyyyMMdd")

        'Me.SOLVV_PositionsDetailsTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsDetails)
        'Me.SOLVV_PositionsDetailsAllTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsDetailsAll)
        'Me.SOLVV_PositionsTotalsTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsTotals)
        Me.SOLVV_DateTableAdapter.FillByLR(Me.SolvaCalculationDataset.SOLVV_Date)


    End Sub


    

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.SOLVV_PositionsTotalsBindingSource.EndEdit()
                'If Me.SolvaCalculationDataset.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.SolvaCalculationDataset)
                    Me.SOLVV_PositionsTotalsTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsTotals)
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Cancel edit
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Try
                Me.SOLVV_PositionsTotalsBindingSource.CancelEdit()
                Me.SOLVV_PositionsTotalsTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsTotals)
            Catch ex As Exception

            End Try
        End If
    End Sub

   

    Private Sub AnticyclicDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AnticyclicDetails_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub AnticyclicDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AnticyclicDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

   

    Private Sub LoadBusinessTypes_btn_Click(sender As Object, e As EventArgs) Handles LoadBusinessTypes_btn.Click
        If IsDate(Me.CAR_DateEdit_ComboEdit.Text) = True Then

            rd = DateSerial(Microsoft.VisualBasic.Right(Me.CAR_DateEdit_ComboEdit.Text, 4), Mid(Me.CAR_DateEdit_ComboEdit.Text, 4, 2), Microsoft.VisualBasic.Left(Me.CAR_DateEdit_ComboEdit.Text, 2))
            rdsql = rd.ToString("yyyyMMdd")


            Me.SOLVV_PositionsDetailsAllTableAdapter.FillByLR(Me.SolvaCalculationDataset.SOLVV_PositionsDetailsAll, rd)
            Me.SOLVV_DateTableAdapter.FillBySolvDate(Me.SolvaCalculationDataset.SOLVV_Date, rd)

        End If
    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick

    End Sub

    Private Sub SQL_ReRun_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_BarButtonItem.ItemClick


    End Sub

    Private Sub CRSA_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CRSA_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CRSA_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CRSA_Details_GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CRSA_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CRSA_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_CRSA_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_CRSA_Totals_Gridview_btn.Click
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
        Dim reportfooter As String = "Leverage Ratio calculation details " & "   " & "on: " & Me.SolvDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_All_DetailsAll_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_All_DetailsAll_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "KSA Positions risk weighted assets - Details " & "   " & "on: " & Me.SolvDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_CAR_Parameters_Gridview_btn_Click(sender As Object, e As EventArgs)
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
        Dim reportfooter As String = "KSA Positions Parameters "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    

    Private Sub GridControl4_DoubleClick(sender As Object, e As EventArgs) Handles GridControl4.DoubleClick
        Me.GridControl4.Visible = False
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Leverage Ratio Details for " & Me.SolvDate_lbl.Text)
        rd = DateSerial(Microsoft.VisualBasic.Right(Me.SolvDate_lbl.Text, 4), Mid(Me.SolvDate_lbl.Text, 4, 2), Microsoft.VisualBasic.Left(Me.SolvDate_lbl.Text, 2))
        Me.SOLVV_PositionsDetailsAllTableAdapter.FillByLR(Me.SolvaCalculationDataset.SOLVV_PositionsDetailsAll, rd)
        Me.CAR_DateEdit_ComboEdit.Text = Me.SolvDate_lbl.Text
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub LoadList_btn_Click(sender As Object, e As EventArgs) Handles LoadList_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload Leverage Ratios List")
        Me.GridControl4.Visible = True
        'Me.SOLVV_PositionsDetailsTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsDetails)
        'Me.SOLVV_PositionsDetailsAllTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsDetailsAll)
        'Me.SOLVV_PositionsTotalsTableAdapter.Fill(Me.SolvaCalculationDataset.SOLVV_PositionsTotals)
        Me.SOLVV_DateTableAdapter.FillByLR(Me.SolvaCalculationDataset.SOLVV_Date)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SOLVA_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SOLVA_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SOLVA_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SOLVA_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CAR_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CAR_DetailsAll_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CAR_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles CAR_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CAR_Calc_Report_btn_Click(sender As Object, e As EventArgs) Handles CAR_Calc_Report_btn.Click
        If IsDate(Me.SolvDate_lbl.Text) = True Then
            Dim d As Date = Me.SolvDate_lbl.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating CAR CALCULATION REPORT for " & Me.SolvDate_lbl.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\CAR_CALCULATION_REP.rpt")
            'Dim r As New INT_RATE_RISK_REP
            CrRep.SetDataSource(SolvaCalculationDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "CAR Calculation report from " & d
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

   

    
   
    Private Sub CVA_Calculation_Rep_ButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CVA_Calculation_Rep_ButtonItem.ItemClick
        If IsDate(Me.SolvDate_lbl.Text) = True Then
            Dim d As Date = Me.SolvDate_lbl.Text
            Dim rdsql As String = d.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating CVA CALCULATION REPORT for " & Me.SolvDate_lbl.Text)

            Dim CVA_Details_Da As New SqlDataAdapter("SELECT * FROM [CVA_Details] where [RiskDate]='" & rdsql & "'", conn)
            Dim CVA_Basic_Da As New SqlDataAdapter("SELECT * FROM [CVA_Basic] where [RiskDate]='" & rdsql & "'", conn)
            Dim CVAdataset As New DataSet("CVA_REPORTING")
            CVA_Basic_Da.FillSchema(CVAdataset, SchemaType.Source, "CVA_Basic")
            CVA_Basic_Da.Fill(CVAdataset, "CVA_Basic")
            Dim BasicDt As DataTable = CVAdataset.Tables("CVA_Basic")
            CVA_Details_Da.FillSchema(CVAdataset, SchemaType.Source, "CVA_Details")
            CVA_Details_Da.Fill(CVAdataset, "CVA_Details")
            Dim DetailDt As DataTable = CVAdataset.Tables("CVA_Details")

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\CVA_CALCULATION_REP.rpt")
            'Dim r As New INT_RATE_RISK_REP
            CrRep.SetDataSource(CVAdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "CVA Calculation report from " & d
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

    Private Sub CVA_Calculation_Excel_buttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CVA_Calculation_Excel_buttonItem.ItemClick
        If IsDate(Me.SolvDate_lbl.Text) = True Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.SolvDate_lbl.Text)
                Dim rd As Date = Me.SolvDate_lbl.Text
                Dim rdsql As String = rd.ToString("yyyyMMdd")

                '**********DETAILS DATA LOAD***********
                '******************************
                Me.QueryText = "SELECT [BusinessTypeName],[ClientGroup],[ClientGroupName],[ClientNr],[CounterpartyName],[ContractColateralID],[MaturityDate],[DaysToMaturity],[RatingExternalSource],[RatingExternal],[Bonitaetsstuffe],[WF_External],[Nominalbetrag],[Nominalbetrag_Restlaufzeit],[CreditEquivAmount] FROM [CVA_Details] where [RiskDate]='" & rdsql & "'"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                '**********BASIC DATA LOAD***********
                '******************************
                Me.QueryText = "SELECT [ClientGroupName],[ClientGroup],[Gewichtung],[GewichteteRestlaufzeit],[Exposure] FROM [CVA_Basic] where [RiskDate]='" & rdsql & "' order by [ClientGroup] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)


                SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(CVA_ExcelFileName, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                workbook.Worksheets(0).Cells("A1").Value = "Credit Value Adjustment Risk Calculation for " & rd

                'Basic Data
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A12:J5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 11, 0)

                If dt.Rows.Count > 0 Then
                    Dim CVA_Totals_LastDtRow As Integer = dt.Rows.Count + 11
                    Dim Range_Abzinsungsfaktor As Range = worksheet.Range("F12:F" & CVA_Totals_LastDtRow)
                    Range_Abzinsungsfaktor.Formula = "=(1-EXP(-D12/20))/(D12/20)"
                    Dim Range_AbgezinstesExposure As Range = worksheet.Range("G12:G" & CVA_Totals_LastDtRow)
                    Range_AbgezinstesExposure.Formula = "=E12*F12"
                    Dim Range_H As Range = worksheet.Range("H12:H" & CVA_Totals_LastDtRow)
                    Range_H.Formula = "=C12*D12*G12"
                    Dim Range_I As Range = worksheet.Range("I12:I" & CVA_Totals_LastDtRow)
                    Range_I.Formula = "=H12/2"
                    Dim Range_J As Range = worksheet.Range("J12:J" & CVA_Totals_LastDtRow)
                    Range_J.Formula = "=(H12^2)*3/4"

                    worksheet.Cells("F5").Formula = "=SUM(E12:E" & CVA_Totals_LastDtRow & ")"
                    worksheet.Cells("G5").Formula = "=COUNTA(B12:B" & CVA_Totals_LastDtRow & ")"
                    worksheet.Cells("F8").Formula = "=SUM(I12:I" & CVA_Totals_LastDtRow & ")^2"
                    worksheet.Cells("G8").Formula = "=SUM(J12:J" & CVA_Totals_LastDtRow & ")"
                    worksheet.Cells("H8").Formula = "=2,33*SQRT(F8+G8)"

                End If

                'Details
                Dim worksheet1 As Worksheet = workbook.Worksheets(1)
                workbook.Worksheets(1).Cells("A1").Value = "Credit Value Adjustment Risk basic data on  " & rd
                worksheet1.ClearContents(worksheet1("A3:O5000"))
                worksheet1.Import(dt1, False, 2, 0)

                'Save Excel File
                workbook.SaveDocument(CVA_ExcelFileName, DocumentFormat.OpenXml)

                'Load Excel Form
                Dim c As New ExcelForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized

                c.Text = "Credit Value Adjustment Risk Calculation on " & rd
                c.SpreadsheetControl1.ReadOnly = True

                workbookN = c.SpreadsheetControl1.Document
                Using stream As New FileStream(CVA_ExcelFileName, FileMode.Open)
                    workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
                End Using


                SplashScreenManager.CloseForm(False)

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        End If
    End Sub

    Private Sub CAR_DateEdit_ComboEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CAR_DateEdit_ComboEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            If IsDate(Me.CAR_DateEdit_ComboEdit.Text) = True Then
                Dim d As Date = Me.CAR_DateEdit_ComboEdit.Text
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)

                Me.SOLVV_PositionsDetailsAllTableAdapter.FillByLR(Me.SolvaCalculationDataset.SOLVV_PositionsDetailsAll, d)
                Me.SOLVV_DateTableAdapter.FillBySolvDate(Me.SolvaCalculationDataset.SOLVV_Date, d)


                Me.GridControl1.DataSource = Me.SOLVV_PositionsDetailsAllBindingSource

                'Me.DotationCapital_lbl.DataBindings.Add(New Binding("Text", Me.SOLVV_DateBindingSource, "Dotation_Capital"))
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    
    Private Sub CAR_DateEdit_ComboEdit_Click(sender As Object, e As EventArgs) Handles CAR_DateEdit_ComboEdit.Click
        If IsDate(Me.CAR_DateEdit_ComboEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.CoreCapital_lbl.Text = ""
            Me.TotalExposure_lbl.Text = ""
            Me.LeverageRatio_lbl.Text = ""

            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub CAR_DateEdit_ComboEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles CAR_DateEdit_ComboEdit.KeyDown
        If IsDate(Me.CAR_DateEdit_ComboEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.CoreCapital_lbl.Text = ""
            Me.TotalExposure_lbl.Text = ""
            Me.LeverageRatio_lbl.Text = ""

            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub CAR_DateEdit_ComboEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CAR_DateEdit_ComboEdit.SelectedIndexChanged
        If IsDate(Me.CAR_DateEdit_ComboEdit.Text) = True Then
            Dim d As Date = Me.CAR_DateEdit_ComboEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
            Me.SOLVV_PositionsDetailsAllTableAdapter.FillByLR(Me.SolvaCalculationDataset.SOLVV_PositionsDetailsAll, d)
            Me.SOLVV_DateTableAdapter.FillBySolvDate(Me.SolvaCalculationDataset.SOLVV_Date, d)


            Me.GridControl1.DataSource = Me.SOLVV_PositionsDetailsAllBindingSource
            'Me.DotationCapital_lbl.DataBindings.Add(New Binding("Text", Me.SOLVV_DateBindingSource, "Dotation_Capital"))
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub CounterCyclReport_btn_Click(sender As Object, e As EventArgs) Handles CounterCyclReport_btn.Click
        If IsDate(Me.SolvDate_lbl.Text) = True Then
            Dim d As Date = Me.SolvDate_lbl.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Countercyclical capital buffer calculation report for " & Me.SolvDate_lbl.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\COUNTERCYCLIC_CALCULATION_REP.rpt")
            'Dim r As New INT_RATE_RISK_REP
            CrRep.SetDataSource(SolvaCalculationDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Countercyclical capital buffer calculation report from " & d
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
End Class