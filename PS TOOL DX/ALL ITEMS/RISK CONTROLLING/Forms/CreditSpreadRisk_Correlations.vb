Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider

Partial Public Class CreditSpreadRisk_Correlations

    Dim UserID As Integer = 0
    Dim ClientAddressesViewCaption As String = Nothing

    Private BS_All_Parameters As BindingSource
    Private BS_Countries As BindingSource
    Private BS_CountriesNatIdentif As BindingSource

    Private CountryNameTextEdit As New TextEdit()
    Private CountryNameNatIdentifTextEdit As New TextEdit()

    Private Sub CreditSpreadRisk_Correlations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Parameter_CreditSpreadRisk_CorrelationsTableAdapter.Fill(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_Correlations)

        'Me.AttributeParameter_BarEditItem.EditValue = CType(BS_All_Parameters.Current, DataRowView).Item(0)

        If EDP_USER = "Y" OrElse SUPER_USER = "Y" OrElse RISKCONTROLLING_USER = "Y" Then
            CreditSpreadRiskSegmentCorrelations_GridView.OptionsBehavior.Editable = True
            Me.bbiSave.Visibility = BarItemVisibility.Always
            'Me.bbiDelete.Visibility = BarItemVisibility.Always
        Else
            CreditSpreadRiskSegmentCorrelations_GridView.OptionsBehavior.Editable = False
            Me.bbiSave.Visibility = BarItemVisibility.Never
            'Me.bbiDelete.Visibility = BarItemVisibility.Never
        End If

    End Sub

    Private Sub bbi_ReloadData_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_ReloadData.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Reload data for segment correlations")
            Me.Parameter_CreditSpreadRisk_CorrelationsTableAdapter.Fill(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_Correlations)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub bbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick
        If XtraMessageBox.Show("Should the changes in Segment correlations be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating Data in segment correlations")
                Me.Validate()
                Me.Parameter_CreditSpreadRisk_CorrelationsBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.CreditSpreadRiskDataSet)
                Me.Parameter_CreditSpreadRisk_CorrelationsTableAdapter.Fill(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_Correlations)
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If

    End Sub

    Private Sub bbiSaveAndClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPreview.ItemClick
        ' Check whether the GridControl can be previewed. 
        If Not Me.GridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

        ' Opens the Preview window. 
        'Me.GridControl1.ShowPrintPreview()

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
        Dim reportfooter As String = "Segments correlations"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick

        Me.Close()

    End Sub



    Private Sub CreditSpreadRiskSegmentCorrelations_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs)
        'Dim View As GridView = CType(sender, GridView)
        'Dim PARAMETERNAME_1 As GridColumn = View.Columns("ParameterName1")
        'Dim PARAMETERNAME_2 As GridColumn = View.Columns("ParameterName2")
        'Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        'Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        'Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        'Dim PARAMETER_STATUS As GridColumn = View.Columns("ParameterStatus")

        'Dim ParameterName1 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_RatingClass).ToString
        'Dim ParameterName2 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_Sector).ToString
        'Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_Segment).ToString
        'Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_RiskWeight).ToString
        'Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_ParameterNr).ToString
        'Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_Status).ToString

        'If ParameterName1 = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(PARAMETERNAME_1, "The Rating Class must not be empty")
        '    e.ErrorText = "The Rating Class must not be empty"
        'End If
        'If ParameterName2 = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(PARAMETERNAME_2, "The Sector must not be empty")
        '    e.ErrorText = "The Sector must not be empty"
        'End If
        'If ParameterValue1 = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(PARAMETERVALUE_1, "The Segment must not be empty")
        '    e.ErrorText = "The Segment must not be empty"
        'End If
        'If ParameterValue2 = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(PARAMETERVALUE_2, "The Risk Weight must not be empty")
        '    e.ErrorText = "The Risk Weight must not be empty"
        'End If
        'If ParameterNr = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(PARAMETER_NR, "The ParameterNr must not be empty")
        '    e.ErrorText = "The ParameterNr must not be empty"
        'End If
        'If ParameterStatus = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(PARAMETER_STATUS, "The Parameter Status must not be empty")
        '    e.ErrorText = "The Parameter Status must not be empty"
        'End If

    End Sub

    Private Sub CreditSpreadRiskSegmentCorrelations_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs)
        'Dim view As GridView = CType(sender, GridView)
        'view.SetRowCellValue(e.RowHandle, view.Columns("ParameterNameGeneral"), "Risk_Weight_by_Issuer_Rating_Class_and_Sector")
        ''view.SetRowCellValue(e.RowHandle, view.Columns("AnacreditParameterDE"), "TILGUNGSART")
        ''view.SetRowCellValue(e.RowHandle, view.Columns("Datamart"), "INS104")
        ''view.SetRowCellValue(e.RowHandle, view.Columns("AttributeType"), "INSTRUMENT")
        ''view.SetRowCellValue(e.RowHandle, view.Columns("ValidFrom"), DateSerial(1900, 1, 1))
        ''view.SetRowCellValue(e.RowHandle, view.Columns("ValidTill"), DateSerial(9999, 12, 31))
        'view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        'view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        'view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub CreditSpreadRiskSegmentCorrelations_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs)
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub CreditSpreadRiskSegmentCorrelations_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs)
        If e.BindableControls(CreditSpreadRiskSegmentCorrelations_GridView.FocusedColumn) IsNot Nothing Then
            e.FocusField(CreditSpreadRiskSegmentCorrelations_GridView.FocusedColumn)
        End If
    End Sub


End Class
