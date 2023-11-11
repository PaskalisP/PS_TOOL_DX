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
Imports DevExpress.XtraLayout

Public Class WeightingFactors

    Dim WF_Value As String = Nothing


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

    Private Sub WeightingFactors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0

        Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet1.RATERISK_BC_WF1)
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)

        'Me.RATERISK_BC_WFTableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF)
        'Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF1)

        If EDP_USER = "Y" OrElse SUPER_USER = "Y" OrElse RISKCONTROLLING_USER = "Y" Then
            Me.WeightingFactors_GridView.OptionsBehavior.Editable = True
            Me.YieldCurves_GridView.OptionsBehavior.Editable = True
        Else
            Me.WeightingFactors_GridView.OptionsBehavior.Editable = False
            Me.YieldCurves_GridView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub bbi_Reload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Reload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload data")
        Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet1.RATERISK_BC_WF1)
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub bbi_AddNewYieldCurve_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_AddNewYieldCurve.ItemClick
        Me.YIELDCURVESBindingSource.EndEdit()
        Me.YieldCurves_GridView.AddNewRow()
        Me.YieldCurves_GridView.ShowEditForm()

    End Sub

    Private Sub bbi_Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Save.ItemClick
        'Save Yield curves
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 0 Then
            Try
                'If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES IN YIELD CURVES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.Validate()
                    Me.YIELDCURVESBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                    OpenSqlConnections()
                    cmd.CommandText = "DELETE from [YIELD_CURVES] where ID not in (Select Min(ID) from [YIELD_CURVES] GROUP BY Convert(varchar(10),[RiskDate],112)+CCY)"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
                Else
                    Me.YIELDCURVESBindingSource.CancelEdit()
                    Me.RiskControllingBasicsDataSet.RejectChanges()
                    Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
                End If

                'End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.YIELDCURVESBindingSource.CancelEdit()
                Me.RiskControllingBasicsDataSet.RejectChanges()
                Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
            End Try


            'Save Weighting Factors
        ElseIf Me.TabbedControlGroup1.SelectedTabPageIndex = 1 Then

            Try
                Me.Validate()
                Me.RATERISKBCWF1BindingSource.EndEdit()
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES IN WEIGHTING FACTORS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.RATERISK_BC_WF1TableAdapter.Update(Me.RiskControllingBasicsDataSet1.RATERISK_BC_WF1)
                    Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF1)
                Else
                    Me.RATERISKBCWF1BindingSource.CancelEdit()
                    Me.RiskControllingBasicsDataSet.RejectChanges()
                    Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF1)
                End If

            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.RATERISKBCWF1BindingSource.CancelEdit()
                Me.RiskControllingBasicsDataSet.RejectChanges()
                Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF1)
                Exit Sub
            End Try
        End If



    End Sub



    Private Sub bbi_PrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintExport.ItemClick
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 0 Then
            If Not YieldCurves_GridControl.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            Me.YIELDCURVESBindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        ElseIf Me.TabbedControlGroup1.SelectedTabPageIndex = 1 Then
            If Not WeightingFactors_GridControl.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            Me.RATERISKBCWF1BindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
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
        Dim reportfooter As String = "Weighting Factors"
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
        Dim reportfooter As String = "Yield Curves "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub RepositoryItemGridLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit1.EditValueChanged

        With WeightingFactorsBaseView
            If .FocusedColumn.FieldName = "WFHUMP" And IsNumeric(WF_Value) = True Then
                .SetRowCellValue(.FocusedRowHandle, colWFHUMP, WF_Value)
            End If
        End With

    End Sub

    Private Sub GridView2_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView2.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedColumn.FieldName <> "Period" Then
            WF_Value = view.GetFocusedDisplayText
        End If

    End Sub

    Private Sub RepositoryItemGridLookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit2.EditValueChanged
        With WeightingFactorsBaseView
            If .FocusedColumn.FieldName = "WF_TWIST1" And IsNumeric(WF_Value) = True Then
                .SetRowCellValue(.FocusedRowHandle, colWF_TWIST1, WF_Value)
            End If
        End With
    End Sub

    Private Sub GridView3_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView3.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedColumn.FieldName <> "Period" Then
            WF_Value = view.GetFocusedDisplayText
        End If
    End Sub

    Private Sub RepositoryItemGridLookUpEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit3.EditValueChanged
        With WeightingFactorsBaseView
            If .FocusedColumn.FieldName = "WF_TWIST2" And IsNumeric(WF_Value) = True Then
                .SetRowCellValue(.FocusedRowHandle, colWF_TWIST2, WF_Value)
            End If
        End With
    End Sub

    Private Sub GridView4_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView4.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedColumn.FieldName <> "Period" Then
            WF_Value = view.GetFocusedDisplayText
        End If
    End Sub



    Private Sub YieldCurves_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles YieldCurves_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim RISK_DATE As GridColumn = View.Columns("RiskDate")
        Dim CCY As GridColumn = View.Columns("CCY")
        Dim RiskDate As String = View.GetRowCellValue(e.RowHandle, colRiskDate).ToString
        Dim Currency As String = View.GetRowCellValue(e.RowHandle, colCCY).ToString

        If RiskDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(RISK_DATE, "Date must not be empty")
            e.ErrorText = "Date must not be empty"
        End If

        If Currency = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CCY, "Currency Code must not be empty")
            e.ErrorText = "Currency Code must not be empty"
        End If

        If View.IsNewItemRow(e.RowHandle) Then
            If RiskDate <> "" AndAlso Currency <> "" Then
                Dim rd As Date = CDate(RiskDate)
                Dim rdsql As String = rd.ToString("yyyyMMdd")
                OpenSqlConnections()
                cmd.CommandText = "Select COUNT(ID) from [YIELD_CURVES] where Convert(varchar(10),[RiskDate],112)+CCY='" & rdsql & "' + '" & Currency & "'"
                Dim CountResult As Integer = cmd.ExecuteScalar
                If CountResult > 0 Then
                    e.Valid = False
                    'Set errors with specific descriptions for the columns
                    'View.SetColumnError(RISK_DATE, "Date: " & RiskDate & " and CCY:" & " are allready in Table! Please enter another Date and/or CCY")
                    e.ErrorText = "Date: " & RiskDate & " and CCY:" & Currency & " are allready in the Yields Table! Please enter another Date and/or CCY"
                End If
                CloseSqlConnections()
            End If
        End If


    End Sub

    Private Sub YieldCurves_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles YieldCurves_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub YieldCurves_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles YieldCurves_GridView.InvalidValueException
        'Display Error in column
        'e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        'XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub YieldCurves_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles YieldCurves_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbi_Save.PerformClick()
        YieldCurves_GridView.RefreshData()
    End Sub

    Private Sub YieldCurves_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles YieldCurves_GridView.FocusedRowChanged
        'If YieldCurves_GridView.IsNewItemRow(YieldCurves_GridView.FocusedRowHandle) = True Then
        If e.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.YieldCurves_GridView.Columns.ColumnByFieldName("RiskDate").OptionsColumn.ReadOnly = True
            Me.YieldCurves_GridView.Columns.ColumnByFieldName("CCY").OptionsColumn.ReadOnly = True
        ElseIf e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.YieldCurves_GridView.Columns.ColumnByFieldName("RiskDate").OptionsColumn.ReadOnly = False
            Me.YieldCurves_GridView.Columns.ColumnByFieldName("CCY").OptionsColumn.ReadOnly = False
        End If
    End Sub


    Private Sub YieldCurves_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles YieldCurves_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)

        If view.IsNewItemRow(e.RowHandle) Then
            TryCast(e.BindableControls("RiskDate"), BaseEdit).Properties.ReadOnly = False
            TryCast(e.BindableControls("CCY"), BaseEdit).Properties.ReadOnly = False
        Else
            TryCast(e.BindableControls("RiskDate"), BaseEdit).Properties.ReadOnly = True
            TryCast(e.BindableControls("CCY"), BaseEdit).Properties.ReadOnly = True
        End If

        If e.BindableControls(YieldCurves_GridView.FocusedColumn) IsNot Nothing Then
            e.FocusField(YieldCurves_GridView.FocusedColumn)
        End If

    End Sub

    Private Sub YieldCurves_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles YieldCurves_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("1D"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("1M"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("2M"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("3M"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("6M"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("9M"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("1Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("2Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("3Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("4Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("5Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("6Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("7Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("8Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("9Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("10Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("15Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("20Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("30Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("40Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("50Y"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub WeightingFactors_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles WeightingFactors_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbi_Save.PerformClick()
        WeightingFactors_GridView.RefreshData()
    End Sub

    Private Sub WeightingFactors_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles WeightingFactors_GridView.EditFormPrepared
        If e.BindableControls(WeightingFactors_GridView.FocusedColumn) IsNot Nothing Then
            e.FocusField(WeightingFactors_GridView.FocusedColumn)
        End If
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If EDP_USER = "Y" OrElse SUPER_USER = "Y" OrElse RISKCONTROLLING_USER = "Y" Then
            If Me.TabbedControlGroup1.SelectedTabPageIndex = 0 Then
                Me.bbi_AddNewYieldCurve.Visibility = BarItemVisibility.Always
            Else
                Me.bbi_AddNewYieldCurve.Visibility = BarItemVisibility.Never
            End If
        End If
    End Sub


End Class