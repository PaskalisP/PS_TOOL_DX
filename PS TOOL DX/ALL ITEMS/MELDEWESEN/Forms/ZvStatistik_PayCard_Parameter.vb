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

Partial Public Class ZvStatistik_PayCard_Parameter

    Dim UserID As Integer = 0

    Private BS_All_ZVSTA_PayCard_Parameters As BindingSource


    Private Sub ZvStatistik_PayCard_Parameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ALL_ZVSTA_PAY_CARD_PARAMETERS_initData()
        ALL_ZVSTA_PAY_CARD_PARAMETERS_InitLookUp()

        Me.Parameter_BarEditItem.EditValue = CType(BS_All_ZVSTA_PayCard_Parameters.Current, DataRowView).Item(1)

        Me.ZVSTAT_Pay_Cards_ParametersTableAdapter.FillByZVSTA_PayCard_Param(Me.ZvStatistik_Dataset.ZVSTAT_Pay_Cards_Parameters, Me.Parameter_BarEditItem.EditValue.ToString)

        'If REGULATORY_REPORTING_USER = 1 Then
        '    ZVSTA_PayCards_Parameter_GridView.OptionsBehavior.Editable = False
        '    Me.bbiSave.Visibility = BarItemVisibility.Never
        '    'Me.bbiDelete.Visibility = BarItemVisibility.Never
        'ElseIf REGULATORY_REPORTING_USER = 2 OrElse ADMIN = True Then
        '    ZVSTA_PayCards_Parameter_GridView.OptionsBehavior.Editable = True
        '    Me.bbiSave.Visibility = BarItemVisibility.Always
        '    'Me.bbiDelete.Visibility = BarItemVisibility.Always
        'End If

        ZVSTA_PayCards_Parameter_GridView.OptionsBehavior.Editable = True
        Me.bbiSave.Visibility = BarItemVisibility.Always

    End Sub

    Private Sub ALL_ZVSTA_PAY_CARD_PARAMETERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [ZVSTA_Parameter_General] nvarchar(max) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT [ZVSTA_Parameter_General]
                                                    FROM [ZVSTAT_Pay_Cards_Parameters]
                                                    WHERE ZVSTA_Parameter_General is not NULL
                                                    GROUP BY ZVSTA_Parameter_General
                                                    ORDER BY ZVSTA_Parameter_General asc
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT 'ALL' as 'ZVSTA_Parameter_General'
                                                    select * from @SELECTION_TABLE order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbZVSTA_PayCard_Parameter As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbZVSTA_PayCard_Parameter.Fill(ds, "ZVSTA_PAY_CARD_PARAMETER")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_ZVSTA_PayCard_Parameters = New BindingSource(ds, "ZVSTA_PAY_CARD_PARAMETER")
    End Sub
    Private Sub ALL_ZVSTA_PAY_CARD_PARAMETERS_InitLookUp()
        Me.RepositoryItemSearchLookUpEdit1.DataSource = BS_All_ZVSTA_PayCard_Parameters
        Me.RepositoryItemSearchLookUpEdit1.DisplayMember = "ZVSTA_Parameter_General"
        Me.RepositoryItemSearchLookUpEdit1.ValueMember = "ZVSTA_Parameter_General"
    End Sub



    Private Sub bbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick
        If XtraMessageBox.Show("Should the changes for ZVSTA Payments and Cards Parameter: " & Me.Parameter_BarEditItem.EditValue.ToString & " be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating Data for ZVSTA Payments and Cards Parameter: " & Me.Parameter_BarEditItem.EditValue.ToString)
                Me.Validate()
                Me.ZVSTAT_Pay_Cards_ParametersBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.ZvStatistik_Dataset)
                Me.ZVSTAT_Pay_Cards_ParametersTableAdapter.FillByZVSTA_PayCard_Param(Me.ZvStatistik_Dataset.ZVSTAT_Pay_Cards_Parameters, Me.Parameter_BarEditItem.EditValue.ToString)
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
        Dim reportfooter As String = "ZV Statistik - Paymentssystems and Cardshemes Parameters for " & Me.Parameter_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick

        Me.Close()

    End Sub

    Private Sub Parameter_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles Parameter_BarEditItem.EditValueChanged
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        If Me.Parameter_BarEditItem.EditValue.ToString = "ALL" Then
            Me.ZVSTAT_Pay_Cards_ParametersTableAdapter.Fill(Me.ZvStatistik_Dataset.ZVSTAT_Pay_Cards_Parameters)
            Me.GridControl1.MainView = Me.ZVSTA_PayCards_Parameter_GridView
            Me.ZVSTA_PayCards_Parameter_GridView.ClearColumnsFilter()
        ElseIf Me.Parameter_BarEditItem.EditValue.ToString <> "ALL" Then
            Me.ZVSTAT_Pay_Cards_ParametersTableAdapter.FillByZVSTA_PayCard_Param(Me.ZvStatistik_Dataset.ZVSTAT_Pay_Cards_Parameters, Me.Parameter_BarEditItem.EditValue.ToString)
            Dim AttributeParameterName As String = Me.Parameter_BarEditItem.EditValue.ToString
            Select Case AttributeParameterName
                Case = "PAYMENTS"
                    Me.GridControl1.MainView = Me.ZVSTA_Payments_Parameter_GridView
                    Me.ZVSTA_Payments_Parameter_GridView.ClearColumnsFilter()
                Case = "DIRECT_DEBITS"
                    Me.GridControl1.MainView = Me.ZVSTA_Directdebits_Parameter_GridView
                    Me.ZVSTA_Directdebits_Parameter_GridView.ClearColumnsFilter()
                Case = "CARDS"
                    Me.GridControl1.MainView = Me.ZVSTA_Cards_Parameter_GridView
                    Me.ZVSTA_Cards_Parameter_GridView.ClearColumnsFilter()
                Case = "UNKNOWN"
                    Me.GridControl1.MainView = Me.ZVSTA_Unknown_Parameter_GridView
                    Me.ZVSTA_Unknown_Parameter_GridView.ClearColumnsFilter()
                Case = "MCC_CODES"
                    Me.GridControl1.MainView = Me.ZVSTA_MCC_Codes_Parameter_GridView
                    Me.ZVSTA_MCC_Codes_Parameter_GridView.ClearColumnsFilter()
                Case Else
                    Me.GridControl1.MainView = Me.ZVSTA_PayCards_Parameter_GridView
                    Me.ZVSTA_PayCards_Parameter_GridView.ClearColumnsFilter()

            End Select
        End If
        SplashScreenManager.CloseForm(False)
    End Sub


#Region "PAYMENTS"
    Private Sub ZVSTA_Payments_Parameter_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTA_Payments_Parameter_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("Status")

        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colPayments_Parameter_Parametervalue1).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colPayments_Parameter_Parametervalue2).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colPayments_Parameter_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colPayments_Parameter_ParameterStatus).ToString

        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The ParameterValue1 must not be empty")
            e.ErrorText = "The ParameterValue1 must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The ParameterValue2 must not be empty")
            e.ErrorText = "The ParameterValue2 must not be empty"
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

    Private Sub ZVSTA_Payments_Parameter_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTA_Payments_Parameter_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ZVSTA_Parameter_General"), "PAYMENTS")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTA_Payments_Parameter_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTA_Payments_Parameter_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub ZVSTA_Payments_Parameter_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ZVSTA_Payments_Parameter_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub ZVSTA_Payments_Parameter_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ZVSTA_Payments_Parameter_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, colPayments_Parameter_General).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, colPayments_Parameter_Parametervalue1).ToString + "_" + view.GetRowCellValue(i, colPayments_Parameter_General).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "DIRECT_DEBITS"
    Private Sub ZVSTA_Directdebits_Parameter_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTA_Directdebits_Parameter_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("Status")

        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colDirectDebits_Parameter_ParameterValue1).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colDirectDebits_Parameter_ParameterValue2).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colDirectDebits_Parameter_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colDirectDebits_Parameter_ParameterStatus).ToString

        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The ParameterValue1 must not be empty")
            e.ErrorText = "The ParameterValue1 must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The ParameterValue2 must not be empty")
            e.ErrorText = "The ParameterValue2 must not be empty"
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

    Private Sub ZVSTA_Directdebits_Parameter_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTA_Directdebits_Parameter_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ZVSTA_Parameter_General"), "DIRECT_DEBITS")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTA_Directdebits_Parameter_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTA_Directdebits_Parameter_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub ZVSTA_Directdebits_Parameter_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ZVSTA_Directdebits_Parameter_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub ZVSTA_Directdebits_Parameter_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ZVSTA_Directdebits_Parameter_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, colDirectDebits_Parameter_General).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, colDirectDebits_Parameter_ParameterValue1).ToString + "_" + view.GetRowCellValue(i, colDirectDebits_Parameter_General).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "CARDS"
    Private Sub ZVSTA_Cards_Parameter_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTA_Cards_Parameter_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("Status")

        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colCards_Parameter_ParameterValue1).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colCards_Parameter_ParameterValue2).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colCards_Parameter_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colCards_Parameter_ParameterStatus).ToString

        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The ParameterValue1 must not be empty")
            e.ErrorText = "The ParameterValue1 must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The ParameterValue2 must not be empty")
            e.ErrorText = "The ParameterValue2 must not be empty"
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

    Private Sub ZVSTA_Cards_Parameter_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTA_Cards_Parameter_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ZVSTA_Parameter_General"), "CARDS")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTA_Cards_Parameter_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTA_Cards_Parameter_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub ZVSTA_Cards_Parameter_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ZVSTA_Cards_Parameter_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub ZVSTA_Cards_Parameter_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ZVSTA_Cards_Parameter_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, view.Columns("ZVSTA_Parameter_General")).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, view.Columns("ParameterValue1")).ToString + "_" + view.GetRowCellValue(i, view.Columns("ZVSTA_Parameter_General")).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "UNKNOWN"
    Private Sub ZVSTA_Unknown_Parameter_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTA_Unknown_Parameter_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("Status")

        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colUnknown_Parameter_ParameterValue1).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colUnknown_Parameter_ParameterValue2).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colUnknown_Parameter_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colUnknown_Parameter_Status).ToString

        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The ParameterValue1 must not be empty")
            e.ErrorText = "The ParameterValue1 must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The ParameterValue2 must not be empty")
            e.ErrorText = "The ParameterValue2 must not be empty"
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

    Private Sub ZVSTA_Unknown_Parameter_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTA_Unknown_Parameter_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ZVSTA_Parameter_General"), "UNKNOWN")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTA_Unknown_Parameter_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTA_Unknown_Parameter_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub ZVSTA_Unknown_Parameter_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ZVSTA_Unknown_Parameter_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub ZVSTA_Unknown_Parameter_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ZVSTA_Unknown_Parameter_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, view.Columns("ZVSTA_Parameter_General")).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, view.Columns("ParameterValue1")).ToString + "_" + view.GetRowCellValue(i, view.Columns("ZVSTA_Parameter_General")).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub



#End Region

#Region "MCC_CODES"
    Private Sub ZVSTA_MCC_Codes_Parameter_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTA_MCC_Codes_Parameter_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PARAMETERVALUE_1 As GridColumn = View.Columns("ParameterValue1")
        Dim PARAMETERVALUE_2 As GridColumn = View.Columns("ParameterValue2")
        Dim PARAMETER_NR As GridColumn = View.Columns("ParameterNr")
        Dim PARAMETER_STATUS As GridColumn = View.Columns("Status")

        Dim ParameterValue1 As String = View.GetRowCellValue(e.RowHandle, colZVSTA_MCC_Code_Parameter_ParameterValue1).ToString
        Dim ParameterValue2 As String = View.GetRowCellValue(e.RowHandle, colZVSTA_MCC_Code_Parameter_ParameterValue2).ToString
        Dim ParameterNr As String = View.GetRowCellValue(e.RowHandle, colZVSTA_MCC_Code_Parameter_ParameterNr).ToString
        Dim ParameterStatus As String = View.GetRowCellValue(e.RowHandle, colZVSTA_MCC_Code_Parameter_ParameterStatus).ToString

        If ParameterValue1 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_1, "The ParameterValue1 must not be empty")
            e.ErrorText = "The ParameterValue1 must not be empty"
        End If
        If ParameterValue2 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PARAMETERVALUE_2, "The ParameterValue2 must not be empty")
            e.ErrorText = "The ParameterValue2 must not be empty"
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

    Private Sub ZVSTA_MCC_Codes_Parameter_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTA_MCC_Codes_Parameter_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ZVSTA_Parameter_General"), "MCC_CODES")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTA_MCC_Codes_Parameter_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTA_MCC_Codes_Parameter_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        bbiSave.PerformClick()
    End Sub

    Private Sub ZVSTA_MCC_Codes_Parameter_GridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ZVSTA_MCC_Codes_Parameter_GridView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
    End Sub

    Private Sub ZVSTA_MCC_Codes_Parameter_GridView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ZVSTA_MCC_Codes_Parameter_GridView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentCode As String = e.Value.ToString() + "_" + view.GetRowCellValue(view.FocusedRowHandle, view.Columns("ZVSTA_Parameter_General")).ToString
            For i As Integer = 0 To view.DataRowCount - 1
                If i <> view.FocusedRowHandle Then
                    If currentCode.Equals(view.GetRowCellValue(i, view.Columns("ParameterValue1")).ToString + "_" + view.GetRowCellValue(i, view.Columns("ZVSTA_Parameter_General")).ToString) = True Then
                        e.ErrorText = "Duplicate Parameter Value detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub
#End Region

End Class
