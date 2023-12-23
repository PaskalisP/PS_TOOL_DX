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
Imports DevExpress.XtraGrid.Columns

Public Class InternalCurrencies

    Private CurrencyNameTextEdit As New TextEdit()
    Private BS_Currencies As BindingSource

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

    Private Sub OWN_CURRENCIESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.OWN_CURRENCIESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub InternalCurrencies_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        CURRENCIES_initData()
        CURRENCIES_InitLookUp()
        If SUPER_USER = "N" Then
            Me.CurrenciesBaseView.OptionsBehavior.Editable = False
            Me.bbiAddNewCCY.Enabled = False
            Me.bbiSave.Enabled = False
        End If

    End Sub

    Private Sub CURRENCIES_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbCurrencies As SqlDataAdapter = New SqlDataAdapter(" SELECT 
                                                                [CURRENCY CODE]
                                                              ,[CURRENCY NAME] 
                                                                FROM [CURRENCIES] 
                                                                where [VALID] in ('Y') 
                                                                and [CURRENCY CODE] not in (Select [CURRENCY CODE] from [OWN_CURRENCIES]) 
																UNION ALL
																 SELECT 
                                                                [CURRENCY CODE]
                                                              ,[CURRENCY NAME] 
                                                                FROM [OWN_CURRENCIES]
                                                                order by [CURRENCY CODE] asc", conn) '
        Try

            dbCurrencies.Fill(ds, "CURRENCIES")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Currencies = New BindingSource(ds, "CURRENCIES")

    End Sub
    Private Sub CURRENCIES_InitLookUp()
        Me.CCY_RepositoryItemSearchLookUpEdit.DataSource = BS_Currencies
        Me.CCY_RepositoryItemSearchLookUpEdit.DisplayMember = "CURRENCY CODE"
        Me.CCY_RepositoryItemSearchLookUpEdit.ValueMember = "CURRENCY CODE"
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
        '    Me.LayoutControl1.Visible = False
        'End If
    End Sub

    Private Sub bbiReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload own Currencies")
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        CURRENCIES_initData()
        CURRENCIES_InitLookUp()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub bbiAddNewCCY_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiAddNewCCY.ItemClick
        Me.CURRENCIESBindingSource.EndEdit()
        Me.CurrenciesBaseView.AddNewRow()
        Me.CurrenciesBaseView.ShowEditForm()
    End Sub

    Private Sub bbiSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSave.ItemClick
        If Me.PSTOOLDataset.HasChanges = True Then
            If XtraMessageBox.Show("Should the changes  be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Updating Data for Currencies")
                    Me.Validate()
                    Me.CURRENCIESBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    OpenSqlConnections()
                    cmd.CommandText = "Update A set A.[LZB_CurrencyCode]=B.[LZB_CurrencyCode]
                                                ,A.[NEWG_CurrencyCode]=B.[NEWG_CurrencyCode] 
                                                from OWN_CURRENCIES A INNER JOIN CURRENCIES B 
                                                on A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
                    CURRENCIES_initData()
                    CURRENCIES_InitLookUp()
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            Else
                Me.CURRENCIESBindingSource.CancelEdit()
            End If
        End If
    End Sub

    Private Sub bbiPrintOrExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPrintOrExport.ItemClick
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiClose.ItemClick
        Me.Close()
    End Sub

    Private Sub CurrenciesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles CurrenciesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CURRENCY_CODE As GridColumn = View.Columns("CURRENCY CODE")
        Dim CURRENCY_NAME As GridColumn = View.Columns("CURRENCY NAME")
        Dim NATIONAL_CURRENCY As GridColumn = View.Columns("OWN CURRENCY")
        Dim CURRENCY_STATUS As GridColumn = View.Columns("VALID")
        Dim SPREAD_VALUE As GridColumn = View.Columns("SPREAD")

        Dim CurrencyCode As String = View.GetRowCellValue(e.RowHandle, colCURRENCYCODE).ToString
        Dim CurrencyName As String = View.GetRowCellValue(e.RowHandle, colCURRENCYNAME).ToString
        Dim NationalCurrency As String = View.GetRowCellValue(e.RowHandle, colOWNCURRENCY).ToString
        Dim CurrencyStatus As String = View.GetRowCellValue(e.RowHandle, colVALID).ToString
        Dim Spread As Double = CDbl(View.GetRowCellValue(e.RowHandle, colSPREAD).ToString)


        If CurrencyCode = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CURRENCY_CODE, "The Currency code must not be empty")
            e.ErrorText = "The Currency code must not be empty"
        End If
        If CurrencyName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CURRENCY_NAME, "The Currency Name must not be empty")
            e.ErrorText = "The Currency Name must not be empty"
        End If
        If NationalCurrency = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(NATIONAL_CURRENCY, "The National Currency Indication must not be empty")
            e.ErrorText = "The National Currency Indication must not be empty"
        End If
        If CurrencyStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CURRENCY_STATUS, "The Currency Status must not be empty")
            e.ErrorText = "The Currency Status must not be empty"
        End If
        If Spread < 0 Then
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SPREAD_VALUE, "The Spread must not be empty or less 0")
            e.ErrorText = "The Spread must not be empty or less 0"
        End If
    End Sub

    Private Sub CurrenciesBaseView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles CurrenciesBaseView.InvalidValueException
        'Do not perform any default action 
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)


    End Sub


    Private Sub CurrenciesBaseView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles CurrenciesBaseView.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If View.FocusedColumn.FieldName = "SPREAD" Then
                'Get the currently edited value 
                Dim SpreadValue As Double = Convert.ToDouble(e.Value)
                'Specify validation criteria 
                If SpreadValue < 0 Then
                    e.Valid = False
                    e.ErrorText = "SPREAD accepts only positive or Zero values"
                End If
            End If
        End If



    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "INTERNAL CURRENCIES" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CCY_RepositoryItemSearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CCY_RepositoryItemSearchLookUpEdit.EditValueChanged
        Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        Dim Currencyrow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = (TryCast(sender, SearchLookUpEdit)).EditValue

        If value IsNot Nothing AndAlso value.ToString <> "" Then
            CurrenciesBaseView.SetRowCellValue(CurrenciesBaseView.FocusedRowHandle, "CURRENCY NAME", Currencyrow("CURRENCY NAME").ToString)
            CurrenciesBaseView.SetFocusedRowCellValue("CURRENCY NAME", Currencyrow("CURRENCY NAME").ToString)
            CurrencyNameTextEdit.EditValue = Currencyrow("CURRENCY NAME").ToString
        End If
    End Sub

    Private Sub CurrenciesBaseView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles CurrenciesBaseView.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        CurrencyNameTextEdit = TryCast(e.BindableControls(colCURRENCYNAME), TextEdit)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If

        If view.IsNewItemRow(e.RowHandle) Then
            TryCast(e.BindableControls("CURRENCY CODE"), BaseEdit).Properties.ReadOnly = False
            TryCast(e.BindableControls("CURRENCY NAME"), BaseEdit).Properties.ReadOnly = False
        Else
            TryCast(e.BindableControls("CURRENCY CODE"), BaseEdit).Properties.ReadOnly = True
            TryCast(e.BindableControls("CURRENCY NAME"), BaseEdit).Properties.ReadOnly = True
        End If
    End Sub

    Private Sub CurrenciesBaseView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles CurrenciesBaseView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
        view.SetRowCellValue(e.RowHandle, view.Columns("SPREAD"), 0)
    End Sub

    Private Sub CurrenciesBaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles CurrenciesBaseView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)

    End Sub

    Private Sub RepositoryItemTextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1.EditValueChanged
        Dim textEditor As TextEdit = CType(sender, TextEdit)
        If textEditor.EditValue < 0 Then
            XtraMessageBox.Show("SPREAD accepts only positive or Zero values", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub

    Private Sub CurrenciesBaseView_EditFormHidden(sender As Object, e As EditFormHiddenEventArgs) Handles CurrenciesBaseView.EditFormHidden
        If PSTOOLDataset.HasChanges Then
            bbiSave.PerformClick()
        End If
    End Sub
End Class