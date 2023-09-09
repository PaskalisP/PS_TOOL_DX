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

Partial Public Class CreditSpreadRisk_Parameter_References

    Dim UserID As Integer = 0
    Dim ClientAddressesViewCaption As String = Nothing

    Private BS_All_Parameters As BindingSource
    Private BS_Countries As BindingSource
    Private BS_CountriesNatIdentif As BindingSource

    Private CountryNameTextEdit As New TextEdit()
    Private CountryNameNatIdentifTextEdit As New TextEdit()

    Private Sub CreditSpreadRisk_Parameter_References_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ALL_PARAMETERS_initData()
        ALL_PARAMETERS_InitLookUp()

        Me.AttributeParameter_BarEditItem.EditValue = CType(BS_All_Parameters.Current, DataRowView).Item(0)

        If EDP_USER = "Y" OrElse SUPER_USER = "Y" OrElse RISKCONTROLLING_USER = "Y" Then
            CreditSpreadRiskParameterReferences_GridView.OptionsBehavior.Editable = True
            RiskWeightSegments_GridView.OptionsBehavior.Editable = True
            Tenor_GridView.OptionsBehavior.Editable = True
            CorrelationsPositions_GridView.OptionsBehavior.Editable = True
            CurveType_GridView.OptionsBehavior.Editable = True
            Me.bbiSave.Visibility = BarItemVisibility.Always
            'Me.bbiDelete.Visibility = BarItemVisibility.Always
        Else
            CreditSpreadRiskParameterReferences_GridView.OptionsBehavior.Editable = False
            RiskWeightSegments_GridView.OptionsBehavior.Editable = False
            Tenor_GridView.OptionsBehavior.Editable = False
            CorrelationsPositions_GridView.OptionsBehavior.Editable = False
            CurveType_GridView.OptionsBehavior.Editable = False
            Me.bbiSave.Visibility = BarItemVisibility.Never
            'Me.bbiDelete.Visibility = BarItemVisibility.Never
        End If

    End Sub

    Private Sub ALL_PARAMETERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL
                                                    ,[ParameterNameGeneral] nvarchar(max) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT [ParameterNameGeneral]
                                                    FROM [Parameter_CreditSpreadRisk_References]
                                                    WHERE ParameterNameGeneral is not NULL
                                                    GROUP BY ParameterNameGeneral
                                                    ORDER BY ParameterNameGeneral asc
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT 'ALL' as 'ParameterNameGeneral'
                                                    select UPPER([ParameterNameGeneral]) as 'ParameterNameGeneral' from @SELECTION_TABLE order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbAnaCreditParameter As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbAnaCreditParameter.Fill(ds, "CreditSpreadRisk_PARAMETER")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_Parameters = New BindingSource(ds, "CreditSpreadRisk_PARAMETER")
    End Sub
    Private Sub ALL_PARAMETERS_InitLookUp()
        Me.RepositoryItemSearchLookUpEdit1.DataSource = BS_All_Parameters
        Me.RepositoryItemSearchLookUpEdit1.DisplayMember = "ParameterNameGeneral"
        Me.RepositoryItemSearchLookUpEdit1.ValueMember = "ParameterNameGeneral"
    End Sub



    Private Sub bbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick
        If XtraMessageBox.Show("Should the changes for Parameter: " & Me.AttributeParameter_BarEditItem.EditValue.ToString & " be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating Data for Parameter: " & Me.AttributeParameter_BarEditItem.EditValue.ToString)
                Me.Validate()
                Me.Parameter_CreditSpreadRisk_ReferencesBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.CreditSpreadRiskDataSet)
                Me.Parameter_CreditSpreadRisk_ReferencesTableAdapter.FillByGeneralParameter(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_References, Me.AttributeParameter_BarEditItem.EditValue.ToString)
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
        Dim reportfooter As String = "Credit Spread Risk Parameters for " & Me.AttributeParameter_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick

        Me.Close()

    End Sub

    Private Sub AttributeParameter_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles AttributeParameter_BarEditItem.EditValueChanged
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        If Me.AttributeParameter_BarEditItem.EditValue.ToString = "ALL" Then
            Me.Parameter_CreditSpreadRisk_ReferencesTableAdapter.Fill(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_References)
            Me.GridControl1.MainView = Me.CreditSpreadRiskParameterReferences_GridView
            Me.CreditSpreadRiskParameterReferences_GridView.ClearColumnsFilter()
        ElseIf Me.AttributeParameter_BarEditItem.EditValue.ToString <> "ALL" Then
            Me.Parameter_CreditSpreadRisk_ReferencesTableAdapter.FillByGeneralParameter(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_References, Me.AttributeParameter_BarEditItem.EditValue.ToString)
            Dim AttributeParameterName As String = Me.AttributeParameter_BarEditItem.EditValue.ToString
            Select Case AttributeParameterName
                Case = "RISK_WEIGHT_BY_ISSUER_RATING_CLASS_AND_SECTOR"
                    Me.GridControl1.MainView = Me.RiskWeightSegments_GridView
                    Me.RiskWeightSegments_GridView.ClearColumnsFilter()
                Case = "TENOR"
                    Me.GridControl1.MainView = Me.Tenor_GridView
                    Me.Tenor_GridView.ClearColumnsFilter()
                Case = "CORRELATION_BETWEEN_TWO_RISK_POSITIONS"
                    Me.GridControl1.MainView = Me.CorrelationsPositions_GridView
                    Me.CorrelationsPositions_GridView.ClearColumnsFilter()
                Case = "CURVE_TYPE"
                    Me.GridControl1.MainView = Me.CurveType_GridView
                    Me.CurveType_GridView.ClearColumnsFilter()
                Case = "SCALING_PARAMETER_LEVELS"
                    Me.GridControl1.MainView = Me.ScalingLevels_GridView
                    Me.CurveType_GridView.ClearColumnsFilter()
                Case Else
                    Me.GridControl1.MainView = Me.CreditSpreadRiskParameterReferences_GridView
                    Me.CreditSpreadRiskParameterReferences_GridView.ClearColumnsFilter()

            End Select
        End If
        SplashScreenManager.CloseForm(False)
    End Sub

#Region "RISK_WEIGHT_SEGMENTS"

    Private Sub RiskWeightSegments_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles RiskWeightSegments_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERNAME_1 As GridColumn = View.Columns("ParameterName1")
        Dim PARAMETERNAME_2 As GridColumn = View.Columns("ParameterName2")
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("ParameterStatus")

        Dim ParameterName1 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_RatingClass).ToString
        Dim ParameterName2 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_Sector).ToString
        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_Segment).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_RiskWeight).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colRiskWeightSegment_Status).ToString

        If ParameterName1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_1, "The Rating Class must not be empty")
            e.ErrorText = "The Rating Class must not be empty"
        End If
        If ParameterName2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_2, "The Sector must not be empty")
            e.ErrorText = "The Sector must not be empty"
        End If
        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The Segment must not be empty")
            e.ErrorText = "The Segment must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The Risk Weight must not be empty")
            e.ErrorText = "The Risk Weight must not be empty"
        End If
        If ParameterNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_NR, "The ParameterNr must not be empty")
            e.ErrorText = "The ParameterNr must not be empty"
        End If
        If ParameterStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_STATUS, "The Parameter Status must not be empty")
            e.ErrorText = "The Parameter Status must not be empty"
        End If

    End Sub

    Private Sub RiskWeightSegments_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles RiskWeightSegments_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ParameterNameGeneral"), "Risk_Weight_by_Issuer_Rating_Class_and_Sector")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AnacreditParameterDE"), "TILGUNGSART")
        'view.SetRowCellValue(e.RowHandle, view.Columns("Datamart"), "INS104")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AttributeType"), "INSTRUMENT")
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidFrom"), DateSerial(1900, 1, 1))
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidTill"), DateSerial(9999, 12, 31))
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub RiskWeightSegments_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles RiskWeightSegments_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub RiskWeightSegments_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles RiskWeightSegments_GridView.EditFormPrepared
        If e.BindableControls(RiskWeightSegments_GridView.FocusedColumn) IsNot Nothing Then
            e.FocusField(RiskWeightSegments_GridView.FocusedColumn)
        End If
    End Sub
    Private Sub RiskWeightSegments_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles RiskWeightSegments_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentDataView As DataView = TryCast((TryCast(sender, GridView)).DataSource, DataView)
            'view.FocusedColumn.FieldName = "ParameterValue1"
            'If view.FocusedColumn.FieldName = "ParameterValue1" Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, colRiskWeightSegment_ParameterNameGeneral).ToString
            'MsgBox(currentCode)
            'MsgBox(AnacreditAmortizationType_GridView.DataRowCount.ToString)
            For i As Integer = 0 To RiskWeightSegments_GridView.DataRowCount - 1
                'MsgBox(view.GetRowCellValue(i, colAmortizationTypeParameterValue1).ToString + "_" + view.GetRowCellValue(i, colAmortizationTypeAnacreditParameter).ToString)
                If i <> view.FocusedRowHandle Then
                    'MsgBox(view.GetRowCellValue(i, colAmortizationTypeParameterValue1).ToString + "_" + view.GetRowCellValue(i, colAmortizationTypeAnacreditParameter).ToString)
                    If currentCode.Equals(view.GetRowCellValue(i, colRiskWeightSegment_Segment).ToString + "_" + view.GetRowCellValue(i, colRiskWeightSegment_ParameterNameGeneral).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If

            Next
        End If


    End Sub

#End Region

#Region "TENOR"
    Private Sub Tenor_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Tenor_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERNAME_1 As GridColumn = View.Columns("ParameterName1")
        Dim PARAMETERNAME_2 As GridColumn = View.Columns("ParameterName2")
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("ParameterStatus")

        Dim ParameterName1 As String = View.GetRowCellValue(e.RowHandle, colTenor_Period).ToString
        Dim ParameterName2 As String = View.GetRowCellValue(e.RowHandle, colTenor_PeriodDescription).ToString
        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colTenor_Min).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colTenor_Max).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colTenor_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colTenor_ParameterStatus).ToString


        If ParameterName1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_1, "The Period must not be empty")
            e.ErrorText = "The Period must not be empty"
        End If
        If ParameterName2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_2, "The Period Description must not be empty")
            e.ErrorText = "The Period Description must not be empty"
        End If
        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The Min Value must not be empty")
            e.ErrorText = "The Min Value must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The Max Value must not be empty")
            e.ErrorText = "The Max Value must not be empty"
        End If
        If ParameterNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_NR, "The ParameterNr must not be empty")
            e.ErrorText = "The ParameterNr must not be empty"
        End If
        If ParameterStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_STATUS, "The Parameter Status must not be empty")
            e.ErrorText = "The Parameter Status must not be empty"
        End If

    End Sub

    Private Sub Tenor_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles Tenor_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ParameterNameGeneral"), "Tenor")
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidFrom"), DateSerial(1900, 1, 1))
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidTill"), DateSerial(9999, 12, 31))
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub Tenor_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles Tenor_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub Tenor_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles Tenor_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub Tenor_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles Tenor_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, colTenor_ParameterNameGeneral).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, colTenor_Period).ToString + "_" + view.GetRowCellValue(i, colTenor_ParameterNameGeneral).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "CORRELATION_POSITIONS"
    Private Sub CorrelationsPositions_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles CorrelationsPositions_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERNAME_1 As GridColumn = View.Columns("ParameterName1")
        Dim PARAMETERNAME_2 As GridColumn = View.Columns("ParameterName2")
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("ParameterStatus")

        Dim ParameterName1 As String = View.GetRowCellValue(e.RowHandle, colColleration_Type).ToString
        Dim ParameterName2 As String = View.GetRowCellValue(e.RowHandle, colColleration_TypeDescription).ToString
        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colColleration_Same).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colColleration_NotSame).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colColleration_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colColleration_ParameterStatus).ToString


        If ParameterName1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_1, "The Colleration Type must not be empty")
            e.ErrorText = "The Colleration Type must not be empty"
        End If
        If ParameterName2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_2, "The Colleration Type Description must not be empty")
            e.ErrorText = "The Colleration Type Description must not be empty"
        End If
        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The Colleration Same Value must not be empty")
            e.ErrorText = "The Colleration Same Value must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The Colleration Not Same Value must not be empty")
            e.ErrorText = "The Colleration Not Value must not be empty"
        End If
        If ParameterNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_NR, "The ParameterNr must not be empty")
            e.ErrorText = "The ParameterNr must not be empty"
        End If
        If ParameterStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_STATUS, "The Parameter Status must not be empty")
            e.ErrorText = "The Parameter Status must not be empty"
        End If

    End Sub

    Private Sub CorrelationsPositions_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles CorrelationsPositions_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ParameterNameGeneral"), "Correlation_between_two_risk_positions")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AnacreditParameterDE"), "AUSFALLSTATUS_VERTRAGSPARTNER")
        'view.SetRowCellValue(e.RowHandle, view.Columns("Datamart"), "CRI160")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AttributeType"), "INSTRUMENT")
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidFrom"), DateSerial(1900, 1, 1))
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidTill"), DateSerial(9999, 12, 31))
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub CorrelationsPositions_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles CorrelationsPositions_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub CorrelationsPositions_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles CorrelationsPositions_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub CorrelationsPositions_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles CorrelationsPositions_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, colColleration_ParameterNameGeneral).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, colColleration_Type).ToString + "_" + view.GetRowCellValue(i, colColleration_ParameterNameGeneral).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "CURVE_TYPE"
    Private Sub CurveType_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles CurveType_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERNAME_1 As GridColumn = View.Columns("ParameterName1")
        Dim PARAMETERNAME_2 As GridColumn = View.Columns("ParameterName2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("ParameterStatus")

        Dim ParameterName1 As String = View.GetRowCellValue(e.RowHandle, colCurveType_Name).ToString
        Dim ParameterName2 As String = View.GetRowCellValue(e.RowHandle, colCurveType_NameDescription).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colCurveType_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colCurveType_ParameterStatus).ToString

        If ParameterName1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_1, "The curve type Name must not be empty")
            e.ErrorText = "The curve type Name must not be empty"
        End If
        If ParameterName2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_2, "The curve type Name Description must not be empty")
            e.ErrorText = "The curve type Name Description must not be empty"
        End If
        If ParameterNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_NR, "The ParameterNr must not be empty")
            e.ErrorText = "The ParameterNr must not be empty"
        End If
        If ParameterStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_STATUS, "The Parameter Status must not be empty")
            e.ErrorText = "The Parameter Status must not be empty"
        End If

    End Sub

    Private Sub CurveType_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles CurveType_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ParameterNameGeneral"), "Curve_Type")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AnacreditParameterDE"), "VERFAHREN_ZUR_BEWERTUNG_DER_WERTMINDERUNG")
        'view.SetRowCellValue(e.RowHandle, view.Columns("Datamart"), "CRI112")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AttributeType"), "INSTRUMENT")
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidFrom"), DateSerial(1900, 1, 1))
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidTill"), DateSerial(9999, 12, 31))
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub CurveType_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles CurveType_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub CurveType_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles CurveType_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub


    Private Sub CurveType_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles CurveType_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, view.Columns("ParameterNameGeneral")).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, view.Columns("ParameterName1")).ToString + "_" + view.GetRowCellValue(i, view.Columns("ParameterNameGeneral")).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "SCALING_LEVELS"
    Private Sub ScalingLevels_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ScalingLevels_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERNAME_1 As GridColumn = View.Columns("ParameterName1")
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("ParameterStatus")

        Dim ParameterName1 As String = View.GetRowCellValue(e.RowHandle, colScalingParameter_Level).ToString
        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colScalingParameter_LevelValue).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colScalingParameter_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colScalingParameter_Status).ToString

        If ParameterName1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERNAME_1, "The Scaling Parameter Name must not be empty")
            e.ErrorText = "The Scaling Parameter Name must not be empty"
        End If
        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The Scaling Parameter Value must not be empty")
            e.ErrorText = "The Scaling Parameter Value must not be empty"
        End If
        If ParameterNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_NR, "The ParameterNr must not be empty")
            e.ErrorText = "The ParameterNr must not be empty"
        End If
        If ParameterStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETER_STATUS, "The Parameter Status must not be empty")
            e.ErrorText = "The Parameter Status must not be empty"
        End If
    End Sub

    Private Sub ScalingLevels_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ScalingLevels_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ParameterNameGeneral"), "Scaling_Parameter_Levels")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AnacreditParameterDE"), "VERFAHREN_ZUR_BEWERTUNG_DER_WERTMINDERUNG")
        'view.SetRowCellValue(e.RowHandle, view.Columns("Datamart"), "CRI112")
        'view.SetRowCellValue(e.RowHandle, view.Columns("AttributeType"), "INSTRUMENT")
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidFrom"), DateSerial(1900, 1, 1))
        'view.SetRowCellValue(e.RowHandle, view.Columns("ValidTill"), DateSerial(9999, 12, 31))
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ScalingLevels_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ScalingLevels_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub ScalingLevels_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ScalingLevels_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub ScalingLevels_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ScalingLevels_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, view.Columns("ParameterNameGeneral")).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, view.Columns("ParameterName1")).ToString + "_" + view.GetRowCellValue(i, view.Columns("ParameterNameGeneral")).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

#End Region


    Private Sub RepositoryItemSearchLookUpEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemSearchLookUpEdit1.ButtonClick
        If e.Button.Tag.ToString = "2" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If Me.AttributeParameter_BarEditItem.EditValue.ToString = "ALL" Then
                Me.Parameter_CreditSpreadRisk_ReferencesTableAdapter.Fill(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_References)
            ElseIf Me.AttributeParameter_BarEditItem.EditValue.ToString <> "ALL" Then
                Me.Parameter_CreditSpreadRisk_ReferencesTableAdapter.FillByGeneralParameter(Me.CreditSpreadRiskDataSet.Parameter_CreditSpreadRisk_References, Me.AttributeParameter_BarEditItem.EditValue.ToString)
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub


End Class
