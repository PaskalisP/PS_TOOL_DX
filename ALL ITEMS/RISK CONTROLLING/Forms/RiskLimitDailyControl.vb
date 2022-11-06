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
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine


Public Class RiskLimitDailyControl
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private _Helper As FlashedCellsHelper

    Dim DATES_FORM_RBC As New DatesForm()
    Dim DATES_FORM_CHART As New DatesForm()
    Dim DATES_FORM_OLS As New DatesForm() 'Obligo Liability Surplus

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

    Private Sub RISK_LIMIT_DAILY_CONTROLBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.RISK_LIMIT_DAILY_CONTROLBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub RiskLimitDailyControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
        Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)

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

        'FLASHING CELLS
        '_Helper = New FlashedCellsHelper(Me.RiskLimitDailyControl_TotalView)
        'FlashedCellsHelper.FlashedCellAppearance.BackColor = Color.Red
        'FlashedCellsHelper.FlashedCellAppearance.BackColor2 = Color.Yellow
        'FlashedCellsHelper.FlashedCellAppearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical


    End Sub

    Private Sub RiskLimitDailyControl_TotalView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles RiskLimitDailyControl_TotalView.CellValueChanged
        Try
            Dim view As GridView = CType(sender, GridView)

            If Me.RiskLimitDailyControl_TotalView.IsFilterRow(e.RowHandle) = False Then 'Wenn Kein Filter Row ist
                If e.Column.FieldName = "Client_Lock" Then
                    Me.Validate()
                    Me.RISK_LIMIT_DAILY_CONTROLBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub RiskLimitDailyControl_TotalView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles RiskLimitDailyControl_TotalView.CellValueChanging

    End Sub

    Private Sub RiskLimitDailyControl_TotalView_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles RiskLimitDailyControl_TotalView.RowCellStyle
       

    End Sub

    Private Sub RiskLimitDailyControl_TotalView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles RiskLimitDailyControl_TotalView.RowStyle
        'FLASHING CELLS
        'Dim row As System.Data.DataRow = Me.RiskLimitDailyControl_TotalView.GetDataRow(RiskLimitDailyControl_TotalView.FocusedRowHandle)
        'If IsDBNull(row(2)) = False Then
        ' If row(2) < 9.5 Then
        'Dim speed As Integer = CInt(Fix(1000))
        '_Helper.SetFlashSpeed(e.RowHandle, RiskLimitDailyControl_TotalView.Columns(2), CInt(Fix(speed)))
        'End If
        'End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If

    End Sub

    Private Sub RiskLimitDailyControl_TotalView_ShownEditor(sender As Object, e As EventArgs) Handles RiskLimitDailyControl_TotalView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    
    Private Sub Print_Export_RiskLimitDailyControl_Totalview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_RiskLimitDailyControl_Totalview_btn.Click
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
        Dim reportfooter As String = "RISK LIMIT DAILY CONTROL"
       e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl1
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        Try
          
            Dim gv As GridView = Me.RiskLimitDailyControl_TotalView
            Dim RiskDate As Date = gv.GetRowCellValue(gv.FocusedRowHandle, colRLDCDate)

            If IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colInterestrisk)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colCreditRiskCashPledge)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colMarketpriceriskofsecurities)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colCurrencyrisk)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colOperationalrisk)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colLiquidityrisk)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colOwnCapitalBAIS_Thsd)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colMinimumcapitalrequirement)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colPLResult)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colUnexpectedLossAmount)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colConcentrationRiskAmount)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colEssentialInquantifiableRisksBufferZone)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colHGB340F)) = True AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colPLdefault)) = True _
               AndAlso IsNumeric(gv.GetRowCellValue(gv.FocusedRowHandle, colExtendOfDamage)) = True Then
                'Collect Data
                'Säule 1
                Dim InterestRiskAmount As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colInterestrisk)
                Dim CreditRiskCashPledge As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colCreditRiskCashPledge)
                Dim UnexpectedLossAmount As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colUnexpectedLossAmount)
                Dim ConcentrationRiskAmount As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colConcentrationRiskAmount)
                Dim MarketPriceRiskSecurities As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colMarketpriceriskofsecurities)
                Dim CurrencyRisk As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colCurrencyrisk)
                Dim OperationalRisk As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colOperationalrisk)
                Dim LiquidityRisk As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colLiquidityrisk)
                Dim EssentialRiskAmount As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colEssentialInquantifiableRisksBufferZone)
                'Säule 2
                Dim OwnFunds As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colOwnCapitalBAIS_Thsd)
                Dim Tier1_Capital As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colCapitalForSolvV)
                Dim RiskWeightedAmount_Total As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colRiskWeigthedAmount_Total)
                Dim Tier2_Capital_RBC As Double = 0
                If RiskDate < DateSerial(2016, 11, 15) Then
                    Tier2_Capital_RBC = RiskWeightedAmount_Total * 0.1165 * (1 - 0.0905 / 0.1165)
                ElseIf RiskDate >= DateSerial(2016, 11, 15) And RiskDate <= DateSerial(2016, 21, 31) Then
                    Tier2_Capital_RBC = RiskWeightedAmount_Total * 0.1045 * (1 - 0.0815 / 0.1045)
                ElseIf RiskDate >= DateSerial(2016, 11, 15) Then
                    Tier2_Capital_RBC = RiskWeightedAmount_Total * 0.117 * (1 - 0.094 / 0.117)
                End If

                Dim MinimumCapitalRequirement As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colMinimumcapitalrequirement)
                Dim PLResult As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colPLResult)
                Dim PLdefault As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colPLdefault)
                Dim KapitalerhaltungsPuffer As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colKapitalerhaltungsPuffer)
                Dim AntizyklischerKapitalPuffer As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colAntizyklischerKapitalPuffer)
                Dim HGB340F As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colHGB340F)
                Dim ExtendOfDamage As Double = Math.Round(gv.GetRowCellValue(gv.FocusedRowHandle, colExtendOfDamage) / 1000, 0)

                'Recalculate the Unexpected Loss Amount and Concentration Risk Amount
                'Dim UnexpectedLossFactor As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colUnexpectedLossFactor)
                'Dim NewUnexpectedLossAmount As Double = Math.Round(CreditRiskCashPledge / 1000 * UnexpectedLossFactor, 0)
                'Dim ConcentrationRiskFactor As Double = gv.GetRowCellValue(gv.FocusedRowHandle, colConcentrationRiskFactor)
                'Dim NewConcentrationRiskAmount As Double = Math.Round(CreditRiskCashPledge / 1000 * ConcentrationRiskFactor, 0)
                'gv.Columns.ColumnByFieldName("UnexpectedLossAmount").OptionsColumn.ReadOnly = False
                'gv.Columns.ColumnByFieldName("UnexpectedLossAmount").OptionsColumn.AllowEdit = True
                'gv.Columns.ColumnByFieldName("ConcentrationRiskAmount").OptionsColumn.ReadOnly = False
                'gv.Columns.ColumnByFieldName("ConcentrationRiskAmount").OptionsColumn.AllowEdit = True
                'gv.SetRowCellValue(gv.FocusedRowHandle, colUnexpectedLossAmount, NewUnexpectedLossAmount)
                'gv.SetRowCellValue(gv.FocusedRowHandle, colConcentrationRiskAmount, NewConcentrationRiskAmount)
                'gv.Columns.ColumnByFieldName("UnexpectedLossAmount").OptionsColumn.ReadOnly = True
                'gv.Columns.ColumnByFieldName("UnexpectedLossAmount").OptionsColumn.AllowEdit = False
                'gv.Columns.ColumnByFieldName("ConcentrationRiskAmount").OptionsColumn.ReadOnly = True
                'gv.Columns.ColumnByFieldName("ConcentrationRiskAmount").OptionsColumn.AllowEdit = False
                'Calculate first Sum

                'Find Maximum between Operational Risk and ExtendOfDamage
                Dim MaxOperationalRisk As Double = 0
                If OperationalRisk >= ExtendOfDamage Then
                    MaxOperationalRisk = OperationalRisk
                Else
                    MaxOperationalRisk = ExtendOfDamage
                End If

                'CALCULATE RISK BEARING CAPACITY

                Dim s1 As Double = 0
                Dim s2 As Double = 0
                Dim newRBC As Double = 0

                If RiskDate < DateSerial(2014, 1, 1) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                         MarketPriceRiskSecurities + _
                         Math.Round(InterestRiskAmount / 1000, 0) + _
                         CurrencyRisk + _
                         OperationalRisk + _
                         LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement + Math.Round(PLResult / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2
                ElseIf RiskDate >= DateSerial(2014, 1, 1) And RiskDate <= DateSerial(2014, 6, 30) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        MarketPriceRiskSecurities + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2
                ElseIf RiskDate > DateSerial(2014, 6, 30) And RiskDate <= DateSerial(2014, 12, 4) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2
                ElseIf RiskDate > DateSerial(2014, 12, 4) And RiskDate <= DateSerial(2015, 9, 29) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement - Math.Round(MinimumCapitalRequirement * 0.3) + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2

                ElseIf RiskDate > DateSerial(2015, 9, 29) And RiskDate <= DateSerial(2016, 3, 30) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk * 1.2 + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement - Math.Round(MinimumCapitalRequirement * 0.3) + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2

                ElseIf RiskDate > DateSerial(2016, 3, 30) And RiskDate <= DateSerial(2016, 7, 11) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk * 1.2 + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement - Math.Round(MinimumCapitalRequirement * 0.3) - Math.Round(KapitalerhaltungsPuffer / 1000, 0) - Math.Round(AntizyklischerKapitalPuffer / 1000, 0) + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2
                ElseIf RiskDate > DateSerial(2016, 7, 11) And RiskDate <= DateSerial(2016, 8, 7) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = OwnFunds - MinimumCapitalRequirement - Math.Round(MinimumCapitalRequirement * 0.3) - Math.Round(KapitalerhaltungsPuffer / 1000, 0) - Math.Round(AntizyklischerKapitalPuffer / 1000, 0) + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2

                ElseIf RiskDate > DateSerial(2016, 8, 7) And RiskDate <= DateSerial(2016, 10, 26) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = Math.Round(Tier1_Capital / 1000, 0) + Math.Round(Tier2_Capital_RBC / 1000, 0) - MinimumCapitalRequirement - Math.Round(MinimumCapitalRequirement * 0.3) - Math.Round(KapitalerhaltungsPuffer / 1000, 0) - Math.Round(AntizyklischerKapitalPuffer / 1000, 0) + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2

                ElseIf RiskDate > DateSerial(2016, 10, 26) Then
                    s1 = Math.Round(CreditRiskCashPledge / 1000, 0) + UnexpectedLossAmount + ConcentrationRiskAmount + _
                        Math.Round(InterestRiskAmount / 1000, 0) + _
                        CurrencyRisk + _
                        MaxOperationalRisk + _
                        LiquidityRisk
                    'Calculate Second Sum
                    s2 = Math.Round(Tier1_Capital / 1000, 0) + Math.Round(Tier2_Capital_RBC / 1000, 0) - MinimumCapitalRequirement - Math.Round(MinimumCapitalRequirement * 0.15) - Math.Round(KapitalerhaltungsPuffer / 1000, 0) - Math.Round(AntizyklischerKapitalPuffer / 1000, 0) + Math.Round(PLdefault / 1000, 0) + HGB340F - EssentialRiskAmount ' - CurrencyRisk - OperationalRisk (Old Code with MinimumCapitalrequirementSTAGE2


                End If

                'Calculate RISK BEARING CAPACITY
                newRBC = (s1 / s2) * 100

                'Update Data in Gridview
                gv.Columns.ColumnByFieldName("RiskBearingCapacityCashPledge").OptionsColumn.ReadOnly = False
                gv.Columns.ColumnByFieldName("RiskBearingCapacityCashPledge").OptionsColumn.AllowEdit = True
                gv.SetRowCellValue(gv.FocusedRowHandle, colRiskBearingCapacityCashPledge, newRBC)
                gv.Columns.ColumnByFieldName("RiskBearingCapacityCashPledge").OptionsColumn.ReadOnly = True
                gv.Columns.ColumnByFieldName("RiskBearingCapacityCashPledge").OptionsColumn.AllowEdit = False
                Try
                    Me.RISK_LIMIT_DAILY_CONTROLBindingSource.EndEdit()
                    Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Update(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR ON SAVE DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.RISK_LIMIT_DAILY_CONTROLBindingSource.CancelEdit()
                    Exit Sub
                End Try
            Else
                MessageBox.Show("Unable to recalculate the RISK BEARING CAPACITY", "REQUIRED FIELDS ARE EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub RepositoryItemPopupContainerEdit1_Popup(sender As Object, e As EventArgs) Handles RepositoryItemPopupContainerEdit1.Popup
       
    End Sub

    Private Sub ALL_DAYS_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ALL_DAYS_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating RISK LIMIT DAILY CONTROL Report for all available Days")
        'Load Exception Report Data- Link to Main Report
        Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\RISK_LIMIT_DAILY_CONTROL_REP.rpt")
        'Dim r As New RISK_LIMIT_DAILY_CONTROL_REP
        CrRep.SetDataSource(RiskControllingDataSet)
       
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Risk Limit Daily Control report for all days "
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub RBC_DailyCalculation_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RBC_DailyCalculation_BarButtonItem.ItemClick
        Dim dxOK_RBC As New DevExpress.XtraEditors.SimpleButton

        With dxOK_RBC
            .Text = "OK"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
            .ImageList = DATES_FORM_RBC.ImageCollection1
            .ImageIndex = 5
        End With

        DATES_FORM_RBC.Controls.Add(dxOK_RBC)
        DATES_FORM_RBC.OK_btn.Visible = False
        DATES_FORM_RBC.LabelControl1.Visible = False
        DATES_FORM_RBC.LabelControl2.Visible = False
        DATES_FORM_RBC.DateEdit2.Visible = False

        AddHandler dxOK_RBC.Click, AddressOf dxOK_RBC_click


        DATES_FORM_RBC.Text = "RISK BEARING CAPACITY REPORT CREATION"
        DATES_FORM_RBC.Text_lbl.Text = "Please input the Date for the report creation"
        With DATES_FORM_RBC.DateEdit1
            .Location = New Point(122, 74)
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
        DATES_FORM_RBC.ShowDialog()


    End Sub

    Private Sub dxOK_RBC_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DATES_FORM_RBC.DateEdit1.Text) = True Then
            Dim d As Date = DATES_FORM_RBC.DateEdit1.Text

            If d < DateSerial(2014, 7, 1) Then
                DATES_FORM_RBC.Close()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity report for " & d)

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGEold.rpt")
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
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
            ElseIf d >= DateSerial(2014, 7, 1) And d <= DateSerial(2014, 12, 4) Then
                DATES_FORM_RBC.Close()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity report for " & d)

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE.rpt")
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
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
            ElseIf d > DateSerial(2014, 12, 4) And d <= DateSerial(2016, 3, 30) Then
                DATES_FORM_RBC.Close()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity report for " & d)

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from05122014.rpt")
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
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
            ElseIf d > DateSerial(2016, 3, 30) And d <= DateSerial(2016, 8, 7) Then
                DATES_FORM_RBC.Close()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity report for " & d)

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from31032016.rpt")
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
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)

            ElseIf d > DateSerial(2016, 8, 7) And d <= DateSerial(2016, 10, 26) Then
                DATES_FORM_RBC.Close()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity report for " & d)

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from08082016.rpt")
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
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)

            ElseIf d > DateSerial(2016, 10, 26) And d <= DateSerial(2016, 12, 31) Then
                DATES_FORM_RBC.Close()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity report for " & d)

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from27102016.rpt")
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
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
            ElseIf d >= DateSerial(2017, 1, 1) Then
                DATES_FORM_RBC.Close()
                Dim dsql As String = d.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
                Dim RiskBearingCapacityCalculation_Da As New SqlDataAdapter("SELECT * FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [RiskDate]='" & dsql & "'", conn)
                Dim REPORTINGdataset As New DataSet("REPORTING")
                RiskBearingCapacityCalculation_Da.Fill(REPORTINGdataset, "RISK_BEARING_CAPACITY_CALCULATIONS")
                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_TOTAL.rpt")
                CrRep.SetDataSource(REPORTINGdataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = d
                myParams.ParameterFieldName = "RiskDate"
                myParams.CurrentValues.Add(myValue)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Risk bearing Capacity report from " & d
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
            End If

        End If
    End Sub

    Private Sub RBC_Chart_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RBC_Chart_BarButtonItem.ItemClick
        Dim dxOK_RBC_CHART As New DevExpress.XtraEditors.SimpleButton

        With dxOK_RBC_CHART
            .Text = "OK"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
            .ImageList = DATES_FORM_CHART.ImageCollection1
            .ImageIndex = 5
        End With

        DATES_FORM_CHART.Controls.Add(dxOK_RBC_CHART)
        DATES_FORM_CHART.OK_btn.Visible = False
       

        AddHandler dxOK_RBC_CHART.Click, AddressOf dxOK_RBC_CHART_click


        DATES_FORM_CHART.Text = "RISK BEARING CAPACITY CHART"
        DATES_FORM_CHART.Text_lbl.Text = "Please input the Period for chart creation"
        With DATES_FORM_CHART.DateEdit1
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With

        With DATES_FORM_CHART.DateEdit2
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
        DATES_FORM_CHART.ShowDialog()


    End Sub

    Private Sub dxOK_RBC_CHART_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DATES_FORM_CHART.DateEdit1.Text) = True And IsDate(DATES_FORM_CHART.DateEdit2.Text) = True Then
            Dim d1 As Date = DATES_FORM_CHART.DateEdit1.Text
            Dim d2 As Date = DATES_FORM_CHART.DateEdit2.Text

            DATES_FORM_CHART.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity Chart from " & d1 & " till " & d2)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CHART.rpt")
            'Dim r As New RISK_BEARING_CAPACITY_CHART
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            Dim myParams1 As ParameterField = New ParameterField
            myValue.Value = d1
            myParams.ParameterFieldName = "FROM"
            myValue1.Value = d2
            myParams1.ParameterFieldName = "TILL"
            myParams.CurrentValues.Add(myValue)
            myParams1.CurrentValues.Add(myValue1)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity chart report from " & d1 & " till " & d2
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub OLS_DailyCalculation_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OLS_DailyCalculation_BarButtonItem.ItemClick
        Dim dxOK_OLS As New DevExpress.XtraEditors.SimpleButton

        With dxOK_OLS
            .Text = "OK"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
            .ImageList = DATES_FORM_OLS.ImageCollection1
            .ImageIndex = 5
        End With

        DATES_FORM_OLS.Controls.Add(dxOK_OLS)
        DATES_FORM_OLS.OK_btn.Visible = False
        DATES_FORM_OLS.LabelControl1.Visible = False
        DATES_FORM_OLS.LabelControl2.Visible = False
        DATES_FORM_OLS.DateEdit2.Visible = False

        AddHandler dxOK_OLS.Click, AddressOf dxOK_OLS_click


        DATES_FORM_OLS.Text = "OBLIGO LIABILITY SURPLUS"
        DATES_FORM_OLS.Text_lbl.Text = "Please input the Date for the report creation"
        With DATES_FORM_OLS.DateEdit1
            .Location = New Point(122, 74)
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
        DATES_FORM_OLS.ShowDialog()


    End Sub

    Private Sub dxOK_OLS_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DATES_FORM_OLS.DateEdit1.Text) = True Then
            Dim d As Date = DATES_FORM_OLS.DateEdit1.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            'Me.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter.FillByRepDate(Me.RiskControllingDataSet.TIME_DEP_OUTST_CLIENT_DEALS, d)
            DATES_FORM_OLS.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Obligo Liability Surplus report for " & d)

            Dim ObligoLiabilitiesDa As New SqlDataAdapter("SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            ObligoLiabilitiesDa.Fill(REPORTINGdataset, "OBLIGO_SURPLUS_DETAILS")

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\ObligoLiabilitySurplusNew.rpt")
            'Dim r As New ObligoLiabilitySurplus
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Obligo Liability Surplus report from " & d
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

    Private Sub OK_btn1_Click(sender As Object, e As EventArgs) Handles OK_btn1.Click
        '******************************************************************************************
        '**********************Recalculating OBLIGO LIABILITY SURPLUS******************************
        '******************************************************************************************
        Dim BadRefinaceSoldFounded As Double = 0
        Dim SumPledgedVariableDepositsCustomer As Double = 0
        Dim OBLIGOliabilitySurplusDefault As Double = Me.ObligoLiabilitySurplusDefault_TextEdit.Text
        Dim rd As Date = Me.RiskDate_DateEdit1.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        cmd.Connection.Open()
        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus Default]=" & Str(OBLIGOliabilitySurplusDefault) & " where [RLDC Date]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='REFINANCE SOLD FUNDED' and [Client No] in ('67820185','67820386') and [RepDate]='" & rdsql & "'"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            BadRefinaceSoldFounded = cmd.ExecuteScalar
        Else
            BadRefinaceSoldFounded = 0
        End If

        cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='PLEDGED VARIABLE DEPOSITS-CUSTOMER' and [RepDate]='" & rdsql & "'"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            SumPledgedVariableDepositsCustomer = cmd.ExecuteScalar
        Else
            SumPledgedVariableDepositsCustomer = 0
        End If
        'EINFÜGEN IN RISK LIMIT DAILY CONTROL
        cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
        Dim t1 As String = cmd.ExecuteScalar
        If IsNothing(t1) = False Then
            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [BadRefinanceSoldFunded]=" & Str(BadRefinaceSoldFounded) & ",[SumPledgeVariableDepositsCustomer]=" & Str(SumPledgedVariableDepositsCustomer) & " where [RLDC Date]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[SumPledgeVariableDepositsCustomer]+[RetainedEarnings],[CCBINFO Obligo Liability surplus Risk Subtotal]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[RetainedEarnings] where [RLDC Date]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        ElseIf IsNothing(t1) = True Then
            cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [BadRefinanceSoldFunded]=" & Str(BadRefinaceSoldFounded) & ",[SumPledgeVariableDepositsCustomer]=" & Str(SumPledgedVariableDepositsCustomer) & ",[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[SumPledgeVariableDepositsCustomer]+[RetainedEarnings],[CCBINFO Obligo Liability surplus Risk Subtotal]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[RetainedEarnings] where [RLDC Date]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        End If
        cmd.Connection.Close()
        '***********************************************************************************************
        Dim edit As PopupContainerControl = PopupContainerControl2
        edit.OwnerEdit.ClosePopup()
        Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)

    End Sub

    Private Sub Cancel_btn1_Click(sender As Object, e As EventArgs) Handles Cancel_btn1.Click
        Dim edit As PopupContainerControl = PopupContainerControl2
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub ReloadRLDC_btn_Click(sender As Object, e As EventArgs) Handles ReloadRLDC_btn.Click
        Try
            Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class