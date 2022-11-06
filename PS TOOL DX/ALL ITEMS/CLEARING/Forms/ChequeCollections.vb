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
Imports DevExpress.XtraGrid.EditForm.Helpers.Controls

Public Class ChequeCollections

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date

    Private WithEvents SimpleButton As New SimpleButton


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

    Private Sub CHEQUE_COLLECTIONSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CHEQUE_COLLECTIONSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClearingDataSet)

    End Sub

    Private Sub ChequeCollections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf Gridcontrol1_EmbeddedNavigator_ButtonClick


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

        Me.COUNTRIESTableAdapter.Fill(Me.EXTERNALDataset.COUNTRIES)
        Me.CURRENCIESTableAdapter.Fill(Me.EXTERNALDataset.CURRENCIES)
        Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)

    End Sub

    Private Sub Gridcontrol1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
            Me.GridControl1.BeginInvoke(New Action(AddressOf ChequeCollections_Basic_GridView.ShowEditForm))

        End If

        'Save
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            e.Handled = True
            Try
                If ClearingDataSet.HasChanges = True Then
                    Me.CHEQUE_COLLECTIONSBindingSource.EndEdit()
                    Me.CHEQUE_COLLECTIONSTableAdapter.Update(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
                    Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CHEQUE_COLLECTIONSBindingSource.CancelEdit()
                Me.ClearingDataSet.RejectChanges()
                Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
            End Try
        End If

        'Remove
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            If Me.ChequeCollections_Basic_GridView.SelectedRowsCount > 0 Then
                Dim row As System.Data.DataRow = ChequeCollections_Basic_GridView.GetDataRow(ChequeCollections_Basic_GridView.FocusedRowHandle)
                Dim cellvalue As String = row(0)
                Dim chequeNo As String = row(7)
                If MessageBox.Show("Should the Cheque Collection with Cheque Nr. " & chequeNo & " be deleted ?", "DELETE CHEQUE COLLECTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim CHEQUEDELETE As ClearingDataSet.CHEQUE_COLLECTIONSRow
                        CHEQUEDELETE = ClearingDataSet.CHEQUE_COLLECTIONS.FindByID(cellvalue)
                        CHEQUEDELETE.Delete()
                        GridControl1.Update()
                        Me.CHEQUE_COLLECTIONSTableAdapter.Update(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
                        Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.CHEQUE_COLLECTIONSBindingSource.CancelEdit()
                        Me.ClearingDataSet.RejectChanges()
                        Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
                    End Try
                End If
            Else
                MessageBox.Show("There's no selected row to delete!", "ERROR ON DELETE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ChequeCollections_Basic_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles ChequeCollections_Basic_GridView.CellValueChanged
        If e.Column.Caption = "Amount" OrElse e.Column.Caption = "Currency" Then
            Dim row As System.Data.DataRow = ChequeCollections_Basic_GridView.GetDataRow(ChequeCollections_Basic_GridView.FocusedRowHandle)
            If IsDate(row(1)) = True And IsNothing(row(3)) = False And IsDBNull(row(4)) = False Then
                Dim IncomingDate As Date = row(1)
                Dim IncomingDateSql As String = IncomingDate.ToString("yyyyMMdd")
                Dim Currency As String = row(3)
                Dim amount As Double = row(4)
                Dim Exchange_Rate As Double = 0
                Select Case Currency
                    Case Is = "EUR"
                        row(5) = 1
                        row(6) = row(4) / row(5)
                    Case Else
                        cmd.Connection.Open()
                        cmd.CommandText = "SELECT [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [EXCHANGE RATE DATE]='" & IncomingDateSql & "' and [CURRENCY CODE]='" & Currency & "'"
                        If IsNothing(cmd.ExecuteScalar) = False Then
                            Exchange_Rate = cmd.ExecuteScalar
                            cmd.Connection.Close()
                            row(5) = Exchange_Rate
                            row(6) = row(4) / row(5)
                        Else
                            MsgBox("No Exchange Rate find in the Database for this incoming Date and currency!", MsgBoxStyle.Information, "NO EXCHANGE RATE FUND")
                            row(5) = 0
                            row(6) = 0
                        End If
                End Select
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If
    End Sub

    Private Sub ChequeCollections_Basic_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ChequeCollections_Basic_GridView.InvalidRowException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ChequeCollections_Basic_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles ChequeCollections_Basic_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ChequeCollections_Basic_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ChequeCollections_Basic_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ChequeCollections_Basic_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ChequeCollections_Basic_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ChequeCollections_Basic_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ChequeCollections_Basic_GridView.ValidateRow
        'Dim row As System.Data.DataRow = ChequeCollections_Basic_GridView.GetDataRow(ChequeCollections_Basic_GridView.FocusedRowHandle)
        'If IsDate(row(1)) = False Then
        'e.Valid = False
        'ChequeCollections_Basic_GridView.SetColumnError(ChequeCollections_Basic_GridView.Columns("Incoming Date"), "Error: Please input the Incoming Date!")
        'End If
        'If IsNothing(row(2)) = True OrElse IsDBNull(row(2)) = True Then
        'e.Valid = False
        'ChequeCollections_Basic_GridView.SetColumnError(ChequeCollections_Basic_GridView.Columns("Im- Export Cheque"), "Error: Please input IMPORT or EXPORT!")
        'End If
        'If IsNothing(row(3)) = True Then
        'e.Valid = False
        'ChequeCollections_Basic_GridView.SetColumnError(ChequeCollections_Basic_GridView.Columns("Currency"), "Error: Please input the currency!")
        'End If
        'If IsDBNull(row(4)) = True Then
        'e.Valid = False
        'ChequeCollections_Basic_GridView.SetColumnError(ChequeCollections_Basic_GridView.Columns("Amount"), "Error: Please input the Amount!")
        'End If
        Dim View As GridView = CType(sender, GridView)
        Dim INCOMING_DATE As GridColumn = View.Columns("IncomingDate")
        Dim IM_EXPORT_CHEQUE As GridColumn = View.Columns("Import_Export_Cheque")
        Dim CHEQUE_CURRENCY As GridColumn = View.Columns("ChequeCurrency")
        Dim CHEQUE_AMOUNT As GridColumn = View.Columns("ChequeAmount")
        Dim CHEQUE_NR As GridColumn = View.Columns("ChequeNo")
        Dim DRAWER_BANK As GridColumn = View.Columns("DrawerBank")
        Dim COUNTRY_DRAWER_BANK As GridColumn = View.Columns("CountryDrawerBank")
        Dim DRAWEE_BANK As GridColumn = View.Columns("DraweeBank")
        Dim COUNTRY_DRAWEE_BANK As GridColumn = View.Columns("CountryDraweeBank")
        Dim CHEQUE_SETTLEMENT As GridColumn = View.Columns("ChequeSettlement")

        Dim IncomingDate As String = View.GetRowCellValue(e.RowHandle, colIncomingDate).ToString
        Dim ImExportCheque As String = View.GetRowCellValue(e.RowHandle, colImport_Export_Cheque).ToString
        Dim ChequeCurrency As String = View.GetRowCellValue(e.RowHandle, colChequeCurrency).ToString
        Dim ChequeAmount As String = View.GetRowCellValue(e.RowHandle, colChequeAmount).ToString
        Dim ChequeNr As String = View.GetRowCellValue(e.RowHandle, colChequeNo).ToString
        Dim DrawerBank As String = View.GetRowCellValue(e.RowHandle, colDrawerBank).ToString
        Dim CountryDrawerBank As String = View.GetRowCellValue(e.RowHandle, colCountryDrawerBank).ToString
        Dim DraweeBank As String = View.GetRowCellValue(e.RowHandle, colDraweeBank).ToString
        Dim CountryDraweeBank As String = View.GetRowCellValue(e.RowHandle, colCountryDraweeBank).ToString
        Dim ChequeSettlement As String = View.GetRowCellValue(e.RowHandle, colChequeSettlement).ToString

        If IncomingDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(INCOMING_DATE, "Incoming Date must not be empty")
            e.ErrorText = "Incoming Date must not be empty"
        End If
        If ImExportCheque = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IM_EXPORT_CHEQUE, "Im-Export Cheque must not be empty")
            e.ErrorText = "Im-Export Cheque must not be empty"
        End If
        If ChequeCurrency = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CHEQUE_CURRENCY, "Cheque Currency must not be empty")
            e.ErrorText = "Cheque Currency must not be empty"
        End If
        If ChequeAmount = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CHEQUE_AMOUNT, "Cheque Amount must not be empty")
            e.ErrorText = "Cheque Amount must not be empty"
        End If
        If ChequeNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CHEQUE_NR, "Cheque Number must not be empty")
            e.ErrorText = "Cheque Number must not be empty"
        End If
        If DrawerBank = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DRAWER_BANK, "Bank of the Drawer must not be empty")
            e.ErrorText = "Bank of the Drawer must not be empty"
        End If
        If CountryDrawerBank = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(COUNTRY_DRAWER_BANK, "The Country of Bank Drawer must not be empty")
            e.ErrorText = "The Country of Bank Drawer must not be empty"
        End If
        If DraweeBank = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DRAWEE_BANK, "Bank of the Drawee must not be empty")
            e.ErrorText = "Bank of the Drawee must not be empty"
        End If
        If CountryDraweeBank = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(COUNTRY_DRAWEE_BANK, "The Country of Bank Drawee must not be empty")
            e.ErrorText = "The Country of Bank Drawee must not be empty"
        End If
        If ChequeSettlement = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CHEQUE_SETTLEMENT, "The Cheque Settlement method must not be empty")
            e.ErrorText = "The Cheque Settlement method must not be empty"
        End If

    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea

        Dim reportfooter As String = "CHEQUE COLLECTIONS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))


    End Sub

    Private Sub ChequeCollections_Basic_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ChequeCollections_Basic_GridView.RowUpdated
        Try
            If ClearingDataSet.HasChanges = True Then
                Me.CHEQUE_COLLECTIONSBindingSource.EndEdit()
                Me.CHEQUE_COLLECTIONSTableAdapter.Update(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
                Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CHEQUE_COLLECTIONSBindingSource.CancelEdit()
            Me.ClearingDataSet.RejectChanges()
            Me.CHEQUE_COLLECTIONSTableAdapter.Fill(Me.ClearingDataSet.CHEQUE_COLLECTIONS)
        End Try
    End Sub


End Class