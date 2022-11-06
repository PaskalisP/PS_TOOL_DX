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

Public Class InterestRateRisk

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable


    Dim CheckField1 As String = Nothing
    Dim CheckField2 As String = Nothing

    Dim EuroSum As Double = 0
    Dim USDSum As Double = 0
    Dim CNYSum As Double = 0
    Dim GBPSum As Double = 0
    Dim JPYSum As Double = 0
    Dim CHFSum As Double = 0
    Dim ForeignCurSum As Double = 0

    Dim OldSum_AM1 As Double = 0
    Dim OldSum_AM2 As Double = 0


    Dim Sum200_BPS_Minus As Double = 0
    Dim Sum200_BPS_Plus As Double = 0
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

    Private Sub BANKBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BANKBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub InterestRateRisk_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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
        Me.InterestRateRiskDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RateRiskDate],104) as 'RLDC Date' from [RATERISK DATE] where [RateRiskDate]<='20181230' ORDER BY [RateRiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.InterestRateRiskDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.InterestRateRiskDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If



        Dim d As Date = Me.InterestRateRiskDateEdit.Text

        Me.RATERISK_DELETIONSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DELETIONS, d)
        'Me.RATERISK_TOTALSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_TOTALS, Me.InterestRateRiskDateEdit.Text)
        Me.RATERISK_TOTALSTableAdapter.FillByRATERISK_TOTALS_FILL(Me.RiskControllingDataSet.RATERISK_TOTALS, d)
        'Me.RATERISK_DETAILSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DETAILS, Me.InterestRateRiskDateEdit.Text)
        Me.RATERISK_DETAILSTableAdapter.FillByRATERISK_DETAILS_FILL(Me.RiskControllingDataSet.RATERISK_DETAILS, d)
        Me.RATERISK_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DATE, d)

        Me.BANKTableAdapter.Fill(Me.RiskControllingDataSet.BANK)

        'Me.TOTALSGridView.ExpandAllGroups()
        Me.TOTALSBandedGridView.ExpandAllGroups()
        Me.DETAILSGridView.ExpandAllGroups()


    End Sub

    Private Sub LoadInterestRateRisk_btn_Click(sender As Object, e As EventArgs) Handles LoadInterestRateRisk_btn.Click
        
    End Sub

    Private Sub TOTALSBandedGridView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles TOTALSBandedGridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            EuroSum = 0
            USDSum = 0
            CNYSum = 0
            GBPSum = 0
            JPYSum = 0
            CHFSum = 0
            OldSum_AM1 = 0
            OldSum_AM2 = 0

        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If CStr(View.GetRowCellValue(e.RowHandle, "CURRENCY").ToString) <> "" Then
                CheckField1 = CStr(View.GetRowCellValue(e.RowHandle, "CURRENCY"))
                CheckField2 = CStr(View.GetRowCellValue(e.RowHandle, "AccountName"))
                'Calculation Derivative Adressenausfallrisikopositionen und Aufrechnungspositionen nach § 12 Abs. 1 SolvV 
                If summaryID = 1 Then
                    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "AM1"))
                    If CheckField1.ToString = "EUR" Then
                        EuroSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "USD" Then
                        USDSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "CNY" Then
                        CNYSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "GBP" Then
                        GBPSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "JPY" Then
                        JPYSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "CHF" Then
                        CHFSum += Convert.ToDecimal(e.FieldValue)
                    End If

                End If
                If summaryID = 3 Then
                    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "AM1"))
                    OldSum_AM1 += Convert.ToDecimal(e.FieldValue)
                End If

                'Calculation USD12 and USD112
                If summaryID = 2 Then
                    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "AM2"))
                    If CheckField1.ToString = "EUR" Then
                        EuroSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "USD" Then
                        USDSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "CNY" Then
                        CNYSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "GBP" Then
                        GBPSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "JPY" Then
                        JPYSum += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "CHF" Then
                        CHFSum += Convert.ToDecimal(e.FieldValue)
                    End If

                End If

                If summaryID = 4 Then
                    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "AM2"))
                    OldSum_AM2 += Convert.ToDecimal(e.FieldValue)
                End If

            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            ForeignCurSum = Math.Abs(USDSum) * (-1) + Math.Abs(CNYSum) * (-1) + Math.Abs(GBPSum) * (-1) + Math.Abs(JPYSum) * (-1) + Math.Abs(CHFSum) * (-1)
            If summaryID = 1 Then
                e.TotalValue = EuroSum + ForeignCurSum
            End If
            If summaryID = 3 Then
                e.TotalValue = OldSum_AM1
            End If
            If summaryID = 2 Then
                e.TotalValue = EuroSum + ForeignCurSum
            End If
            If summaryID = 4 Then
                e.TotalValue = OldSum_AM2
            End If
        End If
    End Sub

    Private Sub TOTALSBandedGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TOTALSBandedGridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TOTALSBandedGridView_ShownEditor(sender As Object, e As EventArgs) Handles TOTALSBandedGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub InterestRateRiskDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles InterestRateRiskDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.RATERSIKTOTALSFK00BindingSource
            Me.GridControl2.DataSource = Me.RATERISKDETAILSFK00BindingSource

            If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
                Dim d As Date = Me.InterestRateRiskDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load data for Interest Rate Risk " & d)
                'Load Interest Rate Risk Data
                Me.RATERISK_DELETIONSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DELETIONS, d)
                Me.RATERISK_TOTALSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_TOTALS, d)
                Me.RATERISK_DETAILSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DETAILS, d)
                Me.RATERISK_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DATE, d)
                SplashScreenManager.CloseForm(False)

            End If
            'Me.TOTALSGridView.ExpandAllGroups()
            Me.TOTALSBandedGridView.ExpandAllGroups()
            Me.DETAILSGridView.ExpandAllGroups()
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
        End If
    End Sub

    Private Sub InterestRateRiskDateEdit_Click(sender As Object, e As EventArgs) Handles InterestRateRiskDateEdit.Click
        If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub InterestRateRiskDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles InterestRateRiskDateEdit.KeyDown
        If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub InterestRateRiskDefaultBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles InterestRateRiskDefaultBarButtonItem.ItemClick
        If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
            Dim d As Date = Me.InterestRateRiskDateEdit.Text

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating INTEREST RATE RISK REPORT for " & Me.InterestRateRiskDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP.rpt")
            'Dim r As New INT_RATE_RISK_REP
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Interest Rate Risk report from " & d
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

    Private Sub Print_Export_TOTALSGridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_TOTALSGridview_btn.Click
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
        Dim reportfooter As String = "INTEREST RATE RISK (TOTALS) " & "   " & "on: " & Me.InterestRateRiskDateEdit.Text
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_DETAILSGridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_DETAILSGridview_btn.Click
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
        Dim reportfooter As String = "INTEREST RATE RISK (DETAILS) " & "  " & "on: " & Me.InterestRateRiskDateEdit.Text
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub InterestRateRiskRBCBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles InterestRateRiskRBCBarButtonItem.ItemClick
        If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
            Dim d As Date = Me.InterestRateRiskDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating INTEREST RATE RISK (Risk bearing Capacity) for " & Me.InterestRateRiskDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_BC_REP.rpt")
            'Dim r As New INT_RATE_RISK_BC_REP
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "INTEREST RATE RISK (Risk bearing Capacity) from " & d
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

    Private Sub InterestRateRiskHUMPBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles InterestRateRiskHUMPBarButtonItem.ItemClick
        If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
            Dim d As Date = Me.InterestRateRiskDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating INTEREST RATE RISK (HUMP-TWIST1-TWIST2) for " & Me.InterestRateRiskDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_HUMP_REP.rpt")
            'Dim r As New INT_RATE_RISK_HUMP_REP
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "INTEREST RATE RISK (HUMP - TWIST1 - TWIST2) from " & d
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

  
    Private Sub DETAILSGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles DETAILSGridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub DETAILSGridView_ShownEditor(sender As Object, e As EventArgs) Handles DETAILSGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Recalculate_Interest_Rate_Risk_btn_Click(sender As Object, e As EventArgs) Handles Recalculate_Interest_Rate_Risk_btn.Click
        If MessageBox.Show("Should the Interest Rate Risk be recalculated ?" & vbNewLine & vbNewLine & "PLEASE NOTE THAT RECALCULATION WILL AFFECT" & vbNewLine & "THE INTEREST RATE RISK in RISK LIMIT DAILY CONTROL", "INTEREST RATE RISK RECALCULATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                Dim d As Date = Me.InterestRateRiskDateEdit.Text
                Dim rdsql As String = d.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Recalculate Interest Rate Risk for " & d)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                'Update WEIGHTING FACTORS in RATERISK TOTALS
                cmd.CommandText = "UPDATE A SET A.[WF1]=B.[WF-200],A.[WF2]=B.[WF+200],A.[WF3]=B.[WF+50],A.[WF4]=B.[WF-100],A.[WF10]=B.[WF],A.[WF15]=B.[WF15],A.[WF20]=B.[WF20],A.[WF25]=B.[WF25],A.[WFHUMP]=B.[WFHUMP],A.[WF_TWIST1]=B.[WF_TWIST1],A.[WF_TWIST2]=B.[WF_TWIST2] from [RATERISK TOTALS] A INNER JOIN [RATERISK BC WF] B ON A.[Period]=B.[Period] where [RISK DATE]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Update WEIGHTING FACTORS in RATERISK TOTALS
                cmd.CommandText = "UPDATE [RATERISK TOTALS]  SET [AM1]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF1]/100,2),[AM2]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF2]/100,2),[AM3]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF3]/100,2),[AM4]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF4]/100,2),[AM10]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF10]/100,2),[AM15]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF15]/100,2),[AM20]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF20]/100,2),[AM25]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF25]/100,2),[AMHUMP]=Round([Principal Amount/Value Balance(EUR Equ)]*[WFHUMP]/100,2),[AM_TWIST1]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF_TWIST1]/100,2),[AM_TWIST2]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF_TWIST2]/100,2) where [RISK DATE]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RATERISK TOTALS] SET [AM15]= Round([WF15]*[Principal Amount/Value Balance(EUR Equ)withoutSECUR]/100,2)  where [Principal Amount/Value Balance(EUR Equ)withoutSECUR] is not NULL and [RISK DATE]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'SUMME
                Dim summeAM1 As Double = 0
                Dim summeAM2 As Double = 0
                cmd.CommandText = "SELECT sum([AM1]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "'"
                summeAM1 = cmd.ExecuteScalar()
                cmd.CommandText = "SELECT sum([AM2]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "'"
                summeAM2 = cmd.ExecuteScalar()
                cmd.CommandText = "UPDATE [RATERISK DATE] SET [SumAM1]=" & Str(summeAM1) & ", [SumAM2]=" & Str(summeAM2) & ", [Position/Capital]=Round(" & Str(summeAM2) & "/[Working Capital]*100,2) where [RateRiskDate]='" & rdsql & "'"
                cmd.ExecuteScalar()
                'Interest Rate Risk - ABSOLUTE NUMBER
                cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=ABS([Position/Capital]) where [RateRiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'ÜBERNAHME IN RISK LIMIT DAILY CONTROL
                SplashScreenManager.Default.SetWaitFormCaption("Update Interest Rate Risk in RISK LIMIT DAILY CONTROL")
                Dim irr As Double = 0
                Dim isr As Double = 0
                Dim da As New SqlDataAdapter
                Dim dt As New DataTable

                Me.QueryText = "SELECT [Position/Capital],[SumAM2] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)

                irr = dt.Rows.Item(0).Item("Position/Capital")
                isr = dt.Rows.Item(0).Item("SumAM2") 'wird nicht mehr in RISK LIMIT DAILY CONTROL Importiert

                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                'Übernahme der Summe AM3 (50%)
                Dim SAM3 As Double = 0
                cmd.CommandText = "SELECT Sum([AM3]) from [RATERISK TOTALS] where [RISK DATE]='" & rdsql & "'"
                SAM3 = cmd.ExecuteScalar

                cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                Dim t As String = cmd.ExecuteScalar

                If IsNothing(t) = False Then
                    cmd.CommandText = "SELECT [Interest rate risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    'If cmd.ExecuteScalar Is DBNull.Value = True Then
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Interest rate risk]=" & Str(irr) & ",[Interest risk]=" & Str(SAM3) & " WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                    'End If
                End If

                If IsNothing(t) = True Then
                    cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                    cmd.ExecuteScalar()
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Interest rate risk]=" & Str(irr) & ",[Interest risk]=" & Str(SAM3) & ",[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If

                SplashScreenManager.Default.SetWaitFormCaption("Reload Data for " & d)
                Me.RATERISK_DELETIONSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DELETIONS, Me.InterestRateRiskDateEdit.Text)
                Me.RATERISK_TOTALSTableAdapter.FillByRATERISK_TOTALS_FILL(Me.RiskControllingDataSet.RATERISK_TOTALS, Me.InterestRateRiskDateEdit.Text)
                Me.RATERISK_DETAILSTableAdapter.FillByRATERISK_DETAILS_FILL(Me.RiskControllingDataSet.RATERISK_DETAILS, Me.InterestRateRiskDateEdit.Text)
                Me.RATERISK_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DATE, Me.InterestRateRiskDateEdit.Text)
                SplashScreenManager.CloseForm(False)
                Me.TOTALSBandedGridView.ExpandAllGroups()
                Me.DETAILSGridView.ExpandAllGroups()
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End Try

        Else
            Exit Sub

        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl IsNot GridControl1 Then
            Return
        End If

        Dim info As ToolTipControlInfo = Nothing
        Dim view As GridView = TryCast(GridControl1.GetViewAt(e.ControlMousePosition), GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        If hi.HitTest = GridHitTest.Footer AndAlso hi.Column IsNot Nothing AndAlso hi.Column.SummaryItem.SummaryType = SummaryItemType.Custom Then

            If hi.Column.FieldName = "AM1" OrElse hi.Column.FieldName = "AM2" Then
                Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
                'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
                Dim text As String = "Sum amount is calculated as follows:" & vbNewLine & "Old Method:" & _
                    vbNewLine & "Sum Amount of each Currency for each Column (-200/+200 bps)" & vbNewLine & _
                    vbNewLine & "New Method:" & vbNewLine & "Currency:EURO Sum Amount" & vbNewLine & "+ Minimum Sum Amount of each Currency between +/- 200 bps"

                info = New ToolTipControlInfo(o, text)

                'ElseIf hi.Column.FieldName = "OtherCurrequEUR" Then
                'Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
                'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
                'Dim text As String = "Custom Sums calculated as follows:" & vbNewLine & "CNY(12)=36014793+36016793" & vbNewLine & "CNY(112)=36015793+36017793" & vbNewLine & vbNewLine _
                '                    & "The Amounts must be inserted in to the BAIS Form- SolvV KSA - MKRFW - CNY Row 12 and CNY Row 112"
                'info = New ToolTipControlInfo(o, text)
                'ElseIf hi.Column.FieldName = "Totals" Then
                'Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
                'Dim text As String = "Kreditäquivalenzbetrag as follows:" & vbNewLine & "Sum of the Derivates * 2%" & vbNewLine & vbNewLine _
                '                    & "The Amounts must be inserted in to the BAIS Form- SolvV KSA - KSAE6 - Row 110"
                'info = New ToolTipControlInfo(o, text)

            End If

        End If
        If info IsNot Nothing Then
            e.Info = info
        End If
    End Sub

    Private Sub InterestRateRiskDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InterestRateRiskDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.RATERSIKTOTALSFK00BindingSource
        Me.GridControl2.DataSource = Me.RATERISKDETAILSFK00BindingSource

        If IsDate(Me.InterestRateRiskDateEdit.Text) = True Then
            Dim d As Date = Me.InterestRateRiskDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load data for Interest Rate Risk " & d)
            'Load Interest Rate Risk Data
            Me.RATERISK_DELETIONSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DELETIONS, d)
            Me.RATERISK_TOTALSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_TOTALS, d)
            Me.RATERISK_DETAILSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DETAILS, d)
            Me.RATERISK_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.RATERISK_DATE, d)
            SplashScreenManager.CloseForm(False)
            
        End If
        'Me.TOTALSGridView.ExpandAllGroups()
        Me.TOTALSBandedGridView.ExpandAllGroups()
        Me.DETAILSGridView.ExpandAllGroups()
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
    End Sub
End Class