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

        Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByTop1000(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
        Me.RiskLimitDailyControl_TotalView.BestFitColumns()

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        OpenSqlConnections()
        CrystalRepDir = cmd.ExecuteScalar
        CloseSqlConnections()
        '***********************************************************************

        'FLASHING CELLS
        '_Helper = New FlashedCellsHelper(Me.RiskLimitDailyControl_TotalView)
        'FlashedCellsHelper.FlashedCellAppearance.BackColor = Color.Red
        'FlashedCellsHelper.FlashedCellAppearance.BackColor2 = Color.Yellow
        'FlashedCellsHelper.FlashedCellAppearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical


    End Sub

    Private Sub LoadTop1000_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadTop1000_bbi.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load top 1000 Business Days")
            Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByTop1000(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
            Me.RiskLimitDailyControl_TotalView.BestFitColumns()
            Me.RiskLimitDailyControl_TotalView.ViewCaption = "Top 1000 Business Dates"
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub LoadAll_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadAll_bbi.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load all available Business Days")
            Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
            Me.RiskLimitDailyControl_TotalView.BestFitColumns()
            Me.RiskLimitDailyControl_TotalView.ViewCaption = "All available Business Dates"
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub PrintOrExport_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintOrExport_bbi.ItemClick
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub RiskLimitDailyControl_TotalView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles RiskLimitDailyControl_TotalView.CellValueChanged
        Try
            Dim view As GridView = CType(sender, GridView)
            Dim focusedRow As Integer = view.FocusedRowHandle
            If Me.RiskLimitDailyControl_TotalView.IsFilterRow(e.RowHandle) = False Then 'Wenn Kein Filter Row ist
                If e.Column.FieldName = "Client_Lock" Then
                    Me.Validate()
                    Me.RISK_LIMIT_DAILY_CONTROLBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                End If
                If e.Column.FieldName = "NetProfitMan" Then
                    rd = CDate(view.GetFocusedRowCellValue(colRLDCDate))
                    rdsql = rd.ToString("yyyyMMdd")
                    Me.Validate()
                    Me.RISK_LIMIT_DAILY_CONTROLBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                    If XtraMessageBox.Show(CType("Should the entered Net Income of " & FormatNumber(CDbl(e.Value.ToString()), 2) & " be considered for all future Business Dates ?", String), "UPDATE NET INCOME FOR ALL FUTURE BUSINESS DATES", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @RISKDATE Datetime = '" & rdsql & "'
                                           DECLARE @NET_INCOME_MAN float=(Select NetProfitMan from [RISK LIMIT DAILY CONTROL] where [RLDC Date]=@RISKDATE)
                                           UPDATE [RISK LIMIT DAILY CONTROL] SET NetProfitMan=@NET_INCOME_MAN where [RLDC Date]>@RISKDATE"
                        cmd.ExecuteNonQuery()
                        CloseSqlConnections()
                        If Me.RiskLimitDailyControl_TotalView.ViewCaption = "Top 1000 Business Dates" Then
                            Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByTop1000(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
                        Else
                            Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(Me.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
                        End If
                        view.FocusedRowHandle = focusedRow
                        End If
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
        'If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    e.Appearance.BackColor = SystemColors.InactiveCaptionText
        'End If

    End Sub

    Private Sub RiskLimitDailyControl_TotalView_ShownEditor(sender As Object, e As EventArgs) Handles RiskLimitDailyControl_TotalView.ShownEditor
        'Dim view As GridView = CType(sender, GridView)
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        'End If
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
        Dim reportfooter As String = "RISK LIMIT DAILY CONTROL - " & Me.RiskLimitDailyControl_TotalView.ViewCaption.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub
End Class