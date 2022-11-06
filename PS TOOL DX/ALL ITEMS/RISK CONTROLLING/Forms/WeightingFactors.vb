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

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim WF_Value As String = Nothing
    Dim PrintGrid As Double = 0




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

    Private Sub RATERISK_BC_WFBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.RATERISK_BC_WFBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)

    End Sub

    Private Sub WeightingFactors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet1.RATERISK_BC_WF1)
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick
        AddHandler GridControl4.EmbeddedNavigator.ButtonClick, AddressOf GridControl4_EmbeddedNavigator_ButtonClick



        Me.RATERISK_BC_WFTableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF)
        Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF1)

        If EDP_USER = "Y" OrElse SUPER_USER = "Y" OrElse RISKCONTROLLING_USER = "Y" Then
            Me.WeightingFactorsCalculation2_GridView.OptionsBehavior.Editable = True
            Me.YieldCurves_GridView.OptionsBehavior.Editable = True
        Else
            Me.WeightingFactorsCalculation2_GridView.OptionsBehavior.Editable = False
            Me.YieldCurves_GridView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.RATERISK_BC_WFBindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                    '****************************************************
                    'Update other weighting Factors
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "UPDATE [RATERISK BC WF] SET [WF+50]=Round([WF+200]/4,4),[WF+100]=Round([WF+200]/2,4),[WF]=Round([WF+200]/20,4),[WF20]=Round([WF+200]/10,4),[WF25]=Round([WF+200]/8,4)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [RATERISK BC WF] SET [WF-200]=[WF+200]*(-1),[WF-50]=[WF+50] *(-1),[WF-100]=[WF+100]*(-1)"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    '*****************************************************
                    Me.RATERISK_BC_WFTableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF)
                Else
                    Me.RATERISK_BC_WFBindingSource.CancelEdit()
                    Me.RiskControllingBasicsDataSet.RejectChanges()
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.RATERISK_BC_WFBindingSource.CancelEdit()
                Me.RiskControllingBasicsDataSet.RejectChanges()
                Exit Sub
            End Try
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.RATERISK_BC_WFBindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
        End If
    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.RATERISKBCWF1BindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.RATERISK_BC_WF1TableAdapter.Update(Me.RiskControllingBasicsDataSet1.RATERISK_BC_WF1)

                    Me.RATERISK_BC_WF1TableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF1)
                Else
                    Me.RATERISKBCWF1BindingSource.CancelEdit()
                    Me.RiskControllingBasicsDataSet.RejectChanges()
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.RATERISKBCWF1BindingSource.CancelEdit()
                Me.RiskControllingBasicsDataSet.RejectChanges()
                Exit Sub
            End Try
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.RATERISKBCWF1BindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
        End If
    End Sub

    Private Sub GridControl4_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                'If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.Validate()
                        Me.YIELDCURVESBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "DELETE from [YIELD_CURVES] where ID not in (Select Min(ID) from [YIELD_CURVES] GROUP BY Convert(varchar(10),[RiskDate],112)+CCY)"
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
                    Else
                        Me.YIELDCURVESBindingSource.CancelEdit()
                        Me.RiskControllingBasicsDataSet.RejectChanges()
                        Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
                    End If

                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.YIELDCURVESBindingSource.CancelEdit()
                Me.RiskControllingBasicsDataSet.RejectChanges()
                Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
            End Try
        End If
    End Sub

    Private Sub WeightingFactorsBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles WeightingFactorsBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub WeightingFactorsBaseView_ShownEditor(sender As Object, e As EventArgs) Handles WeightingFactorsBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub WeightingFactorsCalculation2_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles WeightingFactorsCalculation2_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub WeightingFactorsCalculation2_GridView_ShownEditor(sender As Object, e As EventArgs) Handles WeightingFactorsCalculation2_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub YieldCurves_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles YieldCurves_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub YieldCurves_GridView_ShownEditor(sender As Object, e As EventArgs) Handles YieldCurves_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub WF_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles WF_Print_Export_btn.Click
        If PrintGrid = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            Me.RATERISK_BC_WFBindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 1 Then
            If Not GridControl3.IsPrintingAvailable Then
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
        If PrintGrid = 2 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            Me.YIELDCURVESBindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
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
        Dim reportfooter As String = "Weighting Factors (IRR Calculation till 30.12.2018)"
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
        Dim reportfooter As String = "Weighting Factors (IRR Amount for RBC Calculation from 31.12.2018)"
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

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Weighting Factors (IRR Calculation till 30.12.2018)" Then
            PrintGrid = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Weighting Factors (IRR Amount for RBC Calculation from 31.12.2018)" Then
            PrintGrid = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Yield Curves" Then
            PrintGrid = 2
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
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "Select COUNT(ID) from [YIELD_CURVES] where Convert(varchar(10),[RiskDate],112)+CCY='" & rdsql & "' + '" & Currency & "'"
                Dim CountResult As Integer = cmd.ExecuteScalar
                If CountResult > 0 Then
                    e.Valid = False
                    'Set errors with specific descriptions for the columns
                    View.SetColumnError(RISK_DATE, "Date: " & RiskDate & " and CCY:" & " are allready in Table! Please enter another Date and/or CCY")
                    e.ErrorText = "Date: " & RiskDate & " and CCY:" & Currency & " are allready in the Yields Table! Please enter another Date and/or CCY"
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If
        End If


    End Sub

    Private Sub YieldCurves_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles YieldCurves_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub YieldCurves_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles YieldCurves_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub YieldCurves_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles YieldCurves_GridView.RowUpdated
        'Dim view As GridView = TryCast(sender, GridView)
        'Dim RISKDATE As String = view.GetRowCellValue(view.FocusedRowHandle, colRiskDate).ToString("dd.MM.yyyy")
        'Dim CCY As String = view.GetRowCellValue(view.FocusedRowHandle, colCCY).ToString
        'MsgBox(RISKDATE & "  " & CCY)
        'Try
        '    If Me.RiskControllingBasicsDataSet.HasChanges = True Then
        '        If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
        '            Me.Validate()
        '            Me.YIELDCURVESBindingSource.EndEdit()
        '            Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
        '            If cmd.Connection.State = ConnectionState.Closed Then
        '                cmd.Connection.Open()
        '            End If
        '            cmd.CommandText = "DELETE from [YIELD_CURVES] where ID not in (Select Min(ID) from [YIELD_CURVES] GROUP BY Convert(varchar(10),[RiskDate],112)+CCY)"
        '            cmd.ExecuteNonQuery()
        '            If cmd.Connection.State = ConnectionState.Open Then
        '                cmd.Connection.Close()
        '            End If
        '            Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
        '        Else
        '            Me.YIELDCURVESBindingSource.CancelEdit()
        '            Me.RiskControllingBasicsDataSet.RejectChanges()
        '            Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
        '        End If

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Me.YIELDCURVESBindingSource.CancelEdit()
        '    Me.RiskControllingBasicsDataSet.RejectChanges()
        '    Me.YIELD_CURVESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.YIELD_CURVES)
        'End Try
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

    End Sub
End Class