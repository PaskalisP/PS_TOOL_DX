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
Imports System.Xml.XmlReader
Imports DevExpress.Spreadsheet
'Imports GemBox.Spreadsheet
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors.Repository
Public Class UnexpectedLoss

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction
    Dim ExcelFileName As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim UnexpectedLossDetailsViewCaption As String = Nothing
    Friend WithEvents BgwExcelLoad As BackgroundWorker

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

   

    Private Sub UnexpectedLoss_Load(sender As Object, e As EventArgs) Handles Me.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.UnexpectedLossDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [UNEXPECTED_LOSS_DATE] ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.UnexpectedLossDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.UnexpectedLossDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxUnexpectedDate As Date = Me.UnexpectedLossDateEdit.Text
       
        Me.UNEXPECTED_LOSS_DetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_Details, MaxUnexpectedDate)
        Me.UNEXPECTED_LOSS_DetailsALLTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DetailsALL, MaxUnexpectedDate)
        Me.UNEXPECTED_LOSSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS, MaxUnexpectedDate)
        Me.UNEXPECTED_LOSS_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DATE, MaxUnexpectedDate)

        If EDP_USER = "Y" OrElse SUPER_USER = "Y" Then
            Me.LevelOfConfidence_SpinEdit.ReadOnly = False
            Me.p_alpha_value_SpinEdit.ReadOnly = False
            Me.nu_Value_SpinEdit.ReadOnly = False
            Me.b_beta_value_SpinEdit.ReadOnly = False
        Else
            Me.LevelOfConfidence_SpinEdit.ReadOnly = True
            Me.p_alpha_value_SpinEdit.ReadOnly = True
            Me.nu_Value_SpinEdit.ReadOnly = True
            Me.b_beta_value_SpinEdit.ReadOnly = True
        End If


    End Sub

    Private Sub UNEXPECTED_LOSS_DATEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.UNEXPECTED_LOSS_DATEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click
       
    End Sub

    Private Sub UnexpectedLossDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles UnexpectedLossDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.UNEXPECTED_LOSSBindingSource
            Me.GridControl2.DataSource = Me.UNEXPECTED_LOSS_DetailsALLBindingSource
            If IsDate(Me.UnexpectedLossDateEdit.Text) = True Then
                Dim d As Date = Me.UnexpectedLossDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load data for " & d)
                'Load  Data
                Me.UNEXPECTED_LOSS_DetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_Details, d)
                Me.UNEXPECTED_LOSS_DetailsALLTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DetailsALL, d)
                Me.UNEXPECTED_LOSSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS, d)
                Me.UNEXPECTED_LOSS_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DATE, d)
                SplashScreenManager.CloseForm(False)

            End If
        End If
    End Sub

    Private Sub UnexpectedLossDateEdit_Click(sender As Object, e As EventArgs) Handles UnexpectedLossDateEdit.Click
        If IsDate(Me.UnexpectedLossDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub UnexpectedLossDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles UnexpectedLossDateEdit.KeyDown
        If IsDate(Me.UnexpectedLossDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles UnexpectedLoss_BasicView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "UnexpectedLoss_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            UnexpectedLossDetailsViewCaption = "Credit Risk details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.UnexpectedLoss_DetailView.ViewCaption = UnexpectedLossDetailsViewCaption
        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles UnexpectedLoss_BasicView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "UnexpectedLoss_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            UnexpectedLossDetailsViewCaption = "Credit Risk details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.UnexpectedLoss_DetailView.ViewCaption = UnexpectedLossDetailsViewCaption
        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles UnexpectedLoss_BasicView.PrintInitialize
        If MessageBox.Show("Should also all the details of the Groups be printed?", "Print Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
            Me.UnexpectedLoss_BasicView.OptionsPrint.ExpandAllDetails = True
            Me.UnexpectedLoss_BasicView.OptionsPrint.PrintDetails = True
        Else
            Me.UnexpectedLoss_BasicView.OptionsPrint.ExpandAllDetails = False
            Me.UnexpectedLoss_BasicView.OptionsPrint.PrintDetails = False

        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles UnexpectedLoss_BasicView.RowClick
        If Me.GridControl1.FocusedView.Name = "UnexpectedLoss_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            UnexpectedLossDetailsViewCaption = "Credit Risk details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.UnexpectedLoss_DetailView.ViewCaption = UnexpectedLossDetailsViewCaption
        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UnexpectedLoss_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles UnexpectedLoss_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub UnexpectedLoss_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UnexpectedLoss_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub UnexpectedLoss_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles UnexpectedLoss_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
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
        Dim reportfooter As String = "UNEXPECTED LOSS " & "   " & "on: " & Me.UnexpectedLossDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub RecalculateUL_btn_Click(sender As Object, e As EventArgs) Handles RecalculateUL_btn.Click
        Try
            If IsDate(Me.UnexpectedLossDateEdit.Text) = True Then
                If MessageBox.Show("Should the Unexpected Loss and Granularity Approach be recalculated based on the Level of confidence for current Day?" & vbNewLine & vbNewLine & "Please note that this recalculation will NOT affect the Unexpected loss Amount in RISK LIMIT DAILY CONTROL!!!" & vbNewLine & vbNewLine & "You wish to proceed with the recalculation?", "UNEXPECTED LOSS - GRANULARITY APPROACH RECALCULATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Dim rd As Date = Me.UnexpectedLossDateEdit.Text
                    Dim rdsql As String = rd.ToString("yyyyMMdd")
                    Dim LevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Recalculating Unexpected Loss for current Date")
                    Me.UNEXPECTED_LOSS_DATEBindingSource.EndEdit()
                    Me.UNEXPECTED_LOSS_DATETableAdapter.Update(RiskControllingDataSet.UNEXPECTED_LOSS_DATE)

                    cmd.Connection.Open()
                    SplashScreenManager.Default.SetWaitFormCaption("Update RW_RiskWeightedExposure and UL_UnexpectedLoss in UNEXPECTED LOSS Table")
                    Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment]<>0"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ID As String = dt.Rows.Item(i).Item("ID")
                        Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
                        Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
                        Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                        Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
                        Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
                        'Get First Part of Formula
                        cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "' "
                        Dim FirstPartFormulaRW = cmd.ExecuteScalar
                        'Get Second Part of Formula
                        cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "'"
                        Dim SecondPartFormulaRW = cmd.ExecuteScalar
                        Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
                        cmd.ExecuteNonQuery()
                    Next
                    'Update Sume Unexpected Loss
                    SplashScreenManager.Default.SetWaitFormCaption("Update Sum Unexpected Loss in UNEXPECTED LOSS DATE Table")
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    'GRANULARITY APPROACH
                    SplashScreenManager.Default.SetWaitFormCaption("Start GRANULARITY APPROACH Calculation for " & rd)
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate s_i Value for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'),10) where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate K_i Value for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end) where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate R_i Value for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS] set [R_i]=Round([LGD]*[PD_3bps_floor],10) where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate VLGD_i Value for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS] set [VLGD_i]=Round((select nu_Value from UNEXPECTED_LOSS_DATE where [RiskDate]='" & rdsql & "')*[LGD]*(1-[LGD]),10) where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate C_i Value for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [RiskDate]='" & rdsql & "' and [LGD]<>0"
                    cmd.ExecuteNonQuery()

                    SplashScreenManager.Default.SetWaitFormCaption("Calculate GAMMAINV for " & rd)
                    Me.QueryText = "Select * from [UNEXPECTED_LOSS_DATE]  Where [RiskDate]='" & rdsql & "'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    Dim p_alpha_Value As Double = dt.Rows.Item(0).Item("p_alpha_Value")
                    Dim b_beta_Value As Double = dt.Rows.Item(0).Item("b_beta_value")
                    Dim ConfidenceLevelUL As Double = dt.Rows.Item(0).Item("LevelOfConfidence")
                    Dim b_beta_Value_Calculated As Double = 1 / b_beta_Value

                    excel = New Microsoft.Office.Interop.Excel.Application
                    instance = excel.WorksheetFunction

                    Dim GAMMA_INV As Double = Math.Round(instance.GammaInv(ConfidenceLevelUL, p_alpha_Value, b_beta_Value_Calculated), 10)

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1

                    SplashScreenManager.Default.SetWaitFormCaption("Calculate DELTA Value for " & rd)
                    Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
                    SplashScreenManager.Default.SetWaitFormCaption("Update DELTA Value and GAMMAINV for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS_DATE] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & " where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert K_Value for " & rd)
                    cmd.CommandText = "Update [UNEXPECTED_LOSS_DATE] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Dim s_i As Decimal = 0
                    Dim C_i As Decimal = 0
                    Dim K_i As Decimal = 0
                    Dim R_i As Decimal = 0
                    Dim LGD_i As Decimal = 0
                    Dim VLGD_i As Decimal = 0
                    Dim CALCULATION_1 As Decimal = 0
                    Dim CALCULATION_2 As Decimal = 0
                    Dim CALCULATION_3 As Decimal = 0
                    Dim TOTAL_CALCULATION As Decimal = 0

                    SplashScreenManager.Default.SetWaitFormCaption("Calculate GA_n Value for " & rd)
                    Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [LGD]<>0"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim IDNR As Double = dt.Rows.Item(i).Item("ID")
                        s_i = dt.Rows.Item(i).Item("s_i")
                        C_i = dt.Rows.Item(i).Item("C_i")
                        K_i = dt.Rows.Item(i).Item("K_i")
                        R_i = dt.Rows.Item(i).Item("R_i")
                        LGD_i = dt.Rows.Item(i).Item("LGD")
                        VLGD_i = dt.Rows.Item(i).Item("VLGD_i")
                        Dim DELTA_VALUE_R As Decimal = Math.Round(DELTA_VALUE, 9)

                        Dim PowerS_i As Decimal = Math.Round(s_i ^ 2, 12)
                        Dim Calculation_A As Decimal = Math.Round(DELTA_VALUE_R * C_i * (K_i + R_i), 12)
                        Dim Calculation_B As Decimal = Math.Round(DELTA_VALUE_R * (K_i + R_i) ^ 2, 12)
                        Dim PowerVLGD As Decimal = VLGD_i ^ 2
                        Dim PowerLGD As Decimal = LGD_i ^ 2
                        Dim Calculation_C As Decimal = Math.Round(PowerVLGD / PowerLGD, 12)
                        Dim Calculation_D As Decimal = Calculation_A + Calculation_B * Calculation_C

                        CALCULATION_1 = Math.Round(Calculation_D, 12)
                        CALCULATION_2 = Math.Round(K_i * (C_i + 2 * (K_i + R_i) * Calculation_C), 12)
                        CALCULATION_3 = CALCULATION_1 - CALCULATION_2

                        TOTAL_CALCULATION = Math.Round(PowerS_i * CALCULATION_3, 12)

                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
                        cmd.ExecuteNonQuery()

                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_rel Value for " & rd)
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'),10) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_Total Value for " & rd)
                    cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
                    Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
                    cmd.CommandText = "Select [SumGA_rel] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
                    Dim SummeGArel As Double = cmd.ExecuteScalar
                    Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumGA_Total]='" & Str(SummeGA_Total) & "' where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()


                    'Fill data for current Date
                    Me.UNEXPECTED_LOSS_DetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_Details, rd)
                    Me.UNEXPECTED_LOSS_DetailsALLTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DetailsALL, rd)
                    Me.UNEXPECTED_LOSSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS, rd)
                    Me.UNEXPECTED_LOSS_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DATE, rd)
                    SplashScreenManager.CloseForm(False)
                End If
            End If
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub UnexpectedLoss_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Me.UnexpectedLoss_BasicView.IsFindPanelVisible Then
            'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
            'Dim find As FindControl = TryCast(UnexpectedLoss_BasicView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            'find.FindEdit.Focus()
        Else
            UnexpectedLoss_BasicView.ShowFindPanel()
        End If
    End Sub

    Private Sub PrintExport_DetailsView_btn_Click(sender As Object, e As EventArgs) Handles PrintExport_DetailsView_btn.Click
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
        Dim reportfooter As String = "UNEXPECTED LOSS (ALL DETAILS) " & "  " & "on: " & Me.UnexpectedLossDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub UnexpectedLoss_AllDetailsView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UnexpectedLoss_AllDetailsView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub UnexpectedLoss_AllDetailsView_ShownEditor(sender As Object, e As EventArgs) Handles UnexpectedLoss_AllDetailsView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub LevelOfConfidence_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelOfConfidence_SpinEdit.ButtonClick
        'Level Of Confidence
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the LEVEL OF CONFIDENCE default value be changed to " & Me.LevelOfConfidence_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPTECTED_LOSS_DATE_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPTECTED_LOSS_DATE_LevelOfConfidence] default (" & Str(DefaultValueLevelOfConfidence) & ") for [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("LEVEL OF CONFIDENCE default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If


    End Sub

    Private Sub nu_Value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles nu_Value_SpinEdit.ButtonClick
        If e.Button.Tag = "nuChangeStandardValue" Then
            If MessageBox.Show("Should the nu default value be changed to " & Me.nu_Value_SpinEdit.Text, "CHANGE NU DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueNU As Double = Me.nu_Value_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPECTED_LOSS_DATE_nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPECTED_LOSS_DATE_nu_Value] default (" & Str(DefaultValueNU) & ") for [nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("NU default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub p_alpha_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles p_alpha_value_SpinEdit.ButtonClick
        If e.Button.Tag = "pAlphaChangeStandardValue" Then
            If MessageBox.Show("Should the p Alpha default value be changed to " & Me.p_alpha_value_SpinEdit.Text, "CHANGE P ALPHA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuepAlpha As Double = Me.p_alpha_value_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPECTED_LOSS_DATE_p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPECTED_LOSS_DATE_p_alpha_Value] default (" & Str(DefaultValuepAlpha) & ") for [p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("p Alpha default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub b_beta_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles b_beta_value_SpinEdit.ButtonClick
        If e.Button.Tag = "bBetaChangeStandardValue" Then
            If MessageBox.Show("Should the b Beta default value be changed to " & Me.b_beta_value_SpinEdit.Text, "CHANGE B BETA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuebBeta As Double = Me.b_beta_value_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPECTED_LOSS_DATE_b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPECTED_LOSS_DATE_b_beta_value] default (" & Str(DefaultValuebBeta) & ") for [b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("b Beta default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub LoadExcelSheet_btn_Click(sender As Object, e As EventArgs) Handles LoadExcelSheet_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.UnexpectedLossDateEdit.Text)

            BgwExcelLoad = New BackgroundWorker
            BgwExcelLoad.WorkerReportsProgress = True
            BgwExcelLoad.RunWorkerAsync()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try


        
    End Sub


    Private Sub BgwExcelLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad.DoWork
        Dim rd As Date = Me.UnexpectedLossDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_EL_UL_GA' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        '**********DATA LOAD***********
        '******************************
        '++++TOTALS Load
        Me.QueryText = "SELECT [ClientGroup],[ClientGroupName],[SubBorrowersCounter],[FinalEadTotalSum],[LGD],[PD_EaD_weighted],[PD_3bps_floor],[IndicatorOfFloor],[MaturityEADweigthed] FROM  [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "' order by ClientGroup  asc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        '+++++++++++++++++++++++++++++
        '+++DETAILS Load
        Me.QueryText = "SELECT A.[ClientGroup],A.[ClientGroupName],A.[Obligor Rate],A.[Client No],A.[Counterparty/Issuer/Collateral Name],A.[Contract Collateral ID],B.BusinessType,A.[Contract Type],A.[Product Type],A.[GL Master / Account Type],'Maturity Date'=Case when A.[Maturity Date] is NULL then '99991231' else A.[Maturity Date] end,A.[Remaining Year(s) to Maturity],A.[Org Ccy],A.[Credit Outstanding (Org Ccy)],A.[Credit Outstanding (EUR Equ)],A.[NetCreditOutstandingAmountEUR],A.[InternalInfo],A.[PD],A.[(1-ER)],A.[Credit Risk Amount(EUR Equ)],A.[NetCredit Risk Amount(EUR Equ)],A.[(1-ER_45)],A.[CreditRiskAmountEUREquER45],A.[NetCreditRiskAmountEUREquER45],A.[CoreDefinition],A.[MaturityWithoutCapFloor],A.[EaDweigthedMaturityWithoutCapFloor],A.[PDxFinalEaD],A.[LGDfinalEaDweighted] from [UNEXPECTED_LOSS_Details] A INNER JOIN [CREDIT RISK] B on A.[Contract Collateral ID]=B.[Contract Collateral ID] and A.RiskDate=B.RiskDate and A.[Org Ccy]=B.[Org Ccy] and A.[Credit Outstanding (Org Ccy)]=B.[Credit Outstanding (Org Ccy)] where A.[RiskDate]='" & rdsql & "' order by A.ClientGroup  asc"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)


        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with basic Parameters for the Calculation")
        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument(ExcelFileName, DocumentFormat.OpenXml)
        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim worksheet1 As Worksheet = workbook.Worksheets(1)
        workbook.Worksheets(0).Cells("A2").Value = "Calculation Expected/Unexpected Loss and Granularity approach for Business Date:"
        workbook.Worksheets(0).Cells("C2").Value = rd
        Dim Nu_Value As Double = Me.nu_Value_SpinEdit.Text
        workbook.Worksheets(0).Cells("E5").Value = Nu_Value
        Dim LevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
        workbook.Worksheets(0).Cells("F5").Value = LevelOfConfidence
        Dim AlphaValue As Double = Me.p_alpha_value_SpinEdit.Text
        workbook.Worksheets(0).Cells("I4").Value = AlphaValue
        Dim BetaValue As Double = Me.b_beta_value_SpinEdit.Text
        workbook.Worksheets(0).Cells("I5").Value = BetaValue
        workbook.Worksheets(1).Cells("A1").Value = "Details - Calculation Expected/Unexpected Loss and Granularity approach for Business Date:"
        workbook.Worksheets(1).Cells("D1").Value = rd

        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet.ClearContents(worksheet("A12:W10000"))
        worksheet1.ClearContents(worksheet1("A3:AB10000"))
        

        'LOAD in DETAILS Sheet
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - DETAILS WORKSHEET")
        worksheet1.Import(dt1, False, 2, 0)
        Dim DETAILS_LastRow As Integer = 0
        If dt1.Rows.Count > 0 Then
            DETAILS_LastRow = dt1.Rows.Count + 2

            Dim RangeDETAILS_W As CellRange = worksheet1.Range("W3:W" & DETAILS_LastRow)
            RangeDETAILS_W.Formula = "=P3*R3*V3"
            Dim RangeDETAILS_X As CellRange = worksheet1.Range("X3:X" & DETAILS_LastRow)
            RangeDETAILS_X.Formula = "=P3*R3*V3"
            Dim RangeDETAILS_Z As CellRange = worksheet1.Range("Z3:Z" & DETAILS_LastRow)
            RangeDETAILS_Z.Formula = "=ROUND((IF(OR(EXACT(K3;DATE(9999;12;31));ISBLANK(K3));DATEDIF($D$1;DATE(YEAR($D$1);MONTH($D$1)+6;DAY($D$1));""d"");DATEDIF($D$1;K3;""d"")))/365,25;2)"
            Dim RangeDETAILS_AA As CellRange = worksheet1.Range("AA3:AA" & DETAILS_LastRow)
            RangeDETAILS_AA.Formula = "=P3*Z3"
            Dim RangeDETAILS_AB As CellRange = worksheet1.Range("AB3:AB" & DETAILS_LastRow)
            RangeDETAILS_AB.Formula = "=P3*R3"
            Dim RangeDETAILS_AC As CellRange = worksheet1.Range("AC3:AC" & DETAILS_LastRow)
            RangeDETAILS_AC.Formula = "=P3*V3"
        End If


        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - TOTALS WORKSHEET")
        worksheet.Import(dt, False, 11, 0)

        Dim UL_Totals_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            UL_Totals_LastRow = dt.Rows.Count + 11

            Dim RangeUL_Totals_C As CellRange = worksheet.Range("C12:C" & UL_Totals_LastRow)
            RangeUL_Totals_C.Formula = "=COUNTIF(Details!$A$3:$A$" & DETAILS_LastRow & ";A12)"

            Dim RangeUL_Totals_D As CellRange = worksheet.Range("D12:D" & UL_Totals_LastRow)
            RangeUL_Totals_D.Formula = "=SUMIF(Details!$A$3:$A$" & DETAILS_LastRow & ";A12;Details!$P$3:$P$" & DETAILS_LastRow & ")"

            Dim RangeUL_Totals_F As CellRange = worksheet.Range("F12:F" & UL_Totals_LastRow)
            RangeUL_Totals_F.Formula = "=IF(ISERROR((SUMIF(Details!$A$3:$A$" & DETAILS_LastRow & ";A12;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D12);0;(SUMIF(Details!$A$3:$A$" & DETAILS_LastRow & ";A12;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D12)"

            Dim RangeUL_Totals_G As CellRange = worksheet.Range("G12:G" & UL_Totals_LastRow)
            RangeUL_Totals_G.Formula = "=MAX(F12;0,0003)*IF(EXACT(0;F12);0;1)"

            Dim RangeUL_Totals_H As CellRange = worksheet.Range("H12:H" & UL_Totals_LastRow)
            RangeUL_Totals_H.Formula = "=IF(G12-F12>0;1;0)"

            Dim RangeUL_Totals_I As CellRange = worksheet.Range("I12:I" & UL_Totals_LastRow)
            RangeUL_Totals_I.Formula = "=IF(ISERROR(MAX(1;MIN(5;(SUMIF(Details!$A$3:$A$" & DETAILS_LastRow & ";A12;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D12)));""n.a."";" & "MAX(1;MIN(5;(SUMIF(Details!$A$3:$A$" & DETAILS_LastRow & ";A12;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D12)))"

            Dim RangeUL_Totals_J As CellRange = worksheet.Range("J12:J" & UL_Totals_LastRow)
            RangeUL_Totals_J.Formula = "=0,12*((1-EXP(-50*G12))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*G12))/(1-EXP(-50))))"

            Dim RangeUL_Totals_K As CellRange = worksheet.Range("K12:K" & UL_Totals_LastRow)
            RangeUL_Totals_K.Formula = "=I12"

            Dim RangeUL_Totals_L As CellRange = worksheet.Range("L12:L" & UL_Totals_LastRow)
            RangeUL_Totals_L.Formula = "=IF(ISERROR((0,11852-0,05478*LN(G12))^2);""n.a."";" & "(0,11852-0,05478*LN(G12))^2)"
            'Original Formula:=IF(ISERROR((0,11852-0,05478*LN(G12))^2);"n.a.";(0,11852-0,05478*LN(G12))^2)

            Dim RangeUL_Totals_M As CellRange = worksheet.Range("M12:M" & UL_Totals_LastRow)
            RangeUL_Totals_M.Formula = "=IF(ISERROR((E12*NORMDIST(  (1/(1-J12))^0,5    *   NORMINV(G12;0;1)    +    (J12/(1-J12))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E12*G12   )*( (1+(K12-2,5)*L12) / (1-1,5*L12)  )*12,5*1,06);""n.a."";" & "(E12*NORMDIST(  (1/(1-J12))^0,5    *   NORMINV(G12;0;1)    +    (J12/(1-J12))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E12*G12   )*( (1+(K12-2,5)*L12) / (1-1,5*L12)  )*12,5*1,06)"
            'Original Formula:=IF(ISERROR((E13*NORMDIST(  (1/(1-J13))^0,5    *   NORMINV(G13;0;1)    +    (J13/(1-J13))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E13*G13   )*( (1+(K13-2,5)*L13) / (1-1,5*L13)  )*12,5*1,06);"n.a.";(E13*NORMDIST(  (1/(1-J13))^0,5    *   NORMINV(G13;0;1)    +    (J13/(1-J13))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E13*G13   )*( (1+(K13-2,5)*L13) / (1-1,5*L13)  )*12,5*1,06)

            Dim RangeUL_Totals_N As CellRange = worksheet.Range("N12:N" & UL_Totals_LastRow)
            RangeUL_Totals_N.Formula = "=IF(ISERROR(M12*D12*0,08);0;M12*D12*0,08)"

            Dim RangeUL_Totals_O As CellRange = worksheet.Range("O12:O" & UL_Totals_LastRow)
            RangeUL_Totals_O.Formula = "=D12*E12*F12"

            Dim RangeUL_Totals_P As CellRange = worksheet.Range("P12:P" & UL_Totals_LastRow)
            RangeUL_Totals_P.Formula = "=D12*F12*0,45"

            Dim RangeUL_Totals_Q As CellRange = worksheet.Range("Q12:Q" & UL_Totals_LastRow)
            RangeUL_Totals_Q.Formula = "=D12/SUM($D$12:$D$" & UL_Totals_LastRow & ")"

            Dim RangeUL_Totals_R As CellRange = worksheet.Range("R12:R" & UL_Totals_LastRow)
            RangeUL_Totals_R.Formula = "=IF(ISERROR(N12/D12);0;N12/D12)"

            Dim RangeUL_Totals_S As CellRange = worksheet.Range("S12:S" & UL_Totals_LastRow)
            RangeUL_Totals_S.Formula = "=E12*G12"

            Dim RangeUL_Totals_T As CellRange = worksheet.Range("T12:T" & UL_Totals_LastRow)
            RangeUL_Totals_T.Formula = "=E12"

            Dim RangeUL_Totals_U As CellRange = worksheet.Range("U12:U" & UL_Totals_LastRow)
            RangeUL_Totals_U.Formula = "=$E$5*T12*(1-T12)"

            Dim RangeUL_Totals_V As CellRange = worksheet.Range("V12:V" & UL_Totals_LastRow)
            RangeUL_Totals_V.Formula = "=IF(ISERROR((T12^2+U12)/T12);0;(T12^2+U12)/T12)"

            Dim RangeUL_Totals_W As CellRange = worksheet.Range("W12:W" & UL_Totals_LastRow)
            RangeUL_Totals_W.Formula = "=IF(ISERROR(Q12^2*(($D$5*V12*(R12+S12) +$D$5*(R12+S12)^2 *(U12^2)/(T12^2))-R12*(V12+2*(R12+S12)*(U12^2)/(T12^2))));0;Q12^2*(($D$5*V12*(R12+S12)+$D$5*(R12+S12)^2*(U12^2)/(T12^2))-R12*(V12+2*(R12+S12)*(U12^2)/(T12^2))))"


            worksheet.Cells("C5").Formula = "=SUMPRODUCT(Q12:Q" & UL_Totals_LastRow & ";R12:R" & UL_Totals_LastRow & ")"
            worksheet.Cells("O10").Formula = "=SUM(O12:O" & UL_Totals_LastRow & ")"
            worksheet.Cells("P10").Formula = "=SUM(P12:P" & UL_Totals_LastRow & ")"
            worksheet.Cells("W11").Formula = "=SUM(W12:W" & UL_Totals_LastRow & ")/(2*$C$5)"




            'Expected Loss
            'worksheet.Cells("C8").Formula = "=O10"
            'Unexpected Loss
            worksheet.Cells("D8").Formula = "=SUM(N12:N" & UL_Totals_LastRow & ")"
            'Granularity Approach
            worksheet.Cells("E8").Formula = "=W11*SUM(D12:D" & UL_Totals_LastRow & ")"
        End If



        'Dim range As CellRange = worksheet1.Range("A:AC")
        'Dim rangeFormatting As DevExpress.Spreadsheet.Formatting = range.BeginUpdateFormatting()
        'rangeFormatting.Font.Color = Color.Black
        'rangeFormatting.Fill.BackgroundColor = Color.White
        'range.EndUpdateFormatting(rangeFormatting)

        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
    End Sub

    Private Sub BgwExcelLoad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized

        c.Text = "Expected/Unexpected Loss and Granularity Approach- Excel File calculation"
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.OpenXml)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub
   
    Private Sub UnexpectedLossDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UnexpectedLossDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.UNEXPECTED_LOSSBindingSource
        Me.GridControl2.DataSource = Me.UNEXPECTED_LOSS_DetailsALLBindingSource
        If IsDate(Me.UnexpectedLossDateEdit.Text) = True Then
            Dim d As Date = Me.UnexpectedLossDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load data for " & d)
                'Load  Data
                Me.UNEXPECTED_LOSS_DetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_Details, d)
                Me.UNEXPECTED_LOSS_DetailsALLTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DetailsALL, d)
                Me.UNEXPECTED_LOSSTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS, d)
                Me.UNEXPECTED_LOSS_DATETableAdapter.FillByRiskDate(Me.RiskControllingDataSet.UNEXPECTED_LOSS_DATE, d)
                SplashScreenManager.CloseForm(False)
           
        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl.Name = GridControl1.Name Then
            Dim view As GridView = TryCast(GridControl1.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "SubBorrowersCounter"
                        args.Contents.Text = "Count of the Client Group Contracts where PD<>0 and Contract Type<>LIMIT"
                    Case Is = "FinalEadTotalSum"
                        args.Contents.Text = "Sum of Net credit outstanding amount for each Client Group"
                    Case Is = "LGD"
                        args.Contents.Text = "from (ER1)"
                    Case Is = "PD_EaD_weighted"
                        args.Contents.Text = "PD*Net Credit outstanding Amount EUR for each client in Group/Total Sum Net Credit outstanding Amount for each Client Group"
                    Case Is = "PD_3bps_floor"
                        args.Contents.Text = "Max between (PD EaD weigthed and 0,0003) * (If (PD EaD weigthed)=0 then 0 else 1)"
                    Case Is = "IndicatorOfFloor"
                        args.Contents.Text = "If [PD (3bps floor)]-[PD (EaD weigthed)]>0 then 1 else 0"
                    Case Is = "MaturityEADweigthed"
                        args.Contents.Text = "Sum [EaD weighted maturity (without cap, floor)/final EaD (total sum)-> Variable 2: Minimum between Number:5 and Variable 1-> Maximum between 1 and Variable 2"
                    Case Is = "R_CoefficientOfColleration"
                        args.Contents.Text = "0,12*((1-EXP(-50*PD))/(1-EXP(-50)))" & vbNewLine & _
                            "+0,24*(1-((1-EXP(-50*PD))/(1-EXP(-50)))) where EXP=e=2.71828182845904"
                    Case Is = "b_MaturityAdjustment"
                        args.Contents.Text = "b=(0,11852-0,05478*Log(PD))^2"
                    Case Is = "RW_RiskWeightedExposure"
                        args.Contents.Text = "(LGD* NORMDIST((1/(1-R))^0,5*NORMINV(PD;0;1)+(R/(1-R))^0,5" & vbNewLine _
                                             & "* NORMINV(Level of confidence;0;1);0;1;TRUE)- LGD*PD)*((1+(Maturity(EaD weigthed)-2,5)*b) / (1-1,5*b))*12,5*1,06) " & vbNewLine _
                                             & "where NORMDIST=cumulative distribution function for a standard normal random variable x  and " & vbNewLine _
                                             & "NORMINV=inverse cumulative distribution function for a standard normal random variable "
                    Case Is = "UL_UnexpectedLoss"
                        args.Contents.Text = "RW*Final EaD*8,00%"
                    Case Is = "s_i"
                        args.Contents.Text = "Final EAD/Sum Final EaD"
                    Case Is = "K_i"
                        args.Contents.Text = "Unexpected Loss/Final EaD"
                    Case Is = "R_i"
                        args.Contents.Text = "LGD * PD"
                    Case Is = "VLGD_i"
                        args.Contents.Text = "(γ) nü value * LGD * (1 - LGD)"
                    Case Is = "C_i"
                        args.Contents.Text = "Power(LGD,2) + VLGD/LGD"
                    Case Is = "GA_n"
                        args.Contents.Text = "S_i^2*((Delta*C_i*(K_i+R_i) +Delta*(K_i+R_i)^2 * (VLGD^2)/(LGD^2) ) -K_i*(C_i+2* (K_i+R_i)*(VLGD^2)/(LGD^2))"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


        If e.SelectedControl.Name = GridControl2.Name Then
            Dim view As GridView = TryCast(GridControl2.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "NetCreditOutstandingAmountEUR"
                        args.Contents.Text = "CASHPLEDGE Consideration"
                    Case Is = "MaturityWithoutCapFloor"
                        args.Contents.Text = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" & vbNewLine _
                                             & "else Maturity Date-RiskDate/365,25"
                    Case Is = "EaDweigthedMaturityWithoutCapFloor"
                        args.Contents.Text = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
                    Case Is = "PDxFinalEaD"
                        args.Contents.Text = "PD * Net Credit outstanding Amount EUR"
                    Case Is = "LGDfinalEaDweighted"
                        args.Contents.Text = "(ER2) * Net Credit Outstanding Amount EUR"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


    End Sub

    Private Sub UnexpectedLoss_AllDetailsView_DoubleClick(sender As Object, e As EventArgs) Handles UnexpectedLoss_AllDetailsView.DoubleClick
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