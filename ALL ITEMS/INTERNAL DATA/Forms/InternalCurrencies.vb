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
Public Class InternalCurrencies

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

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
        'Get connection
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        'TODO: This line of code loads data into the 'PSTOOLDataset.OWN_CURRENCIES' table. You can move, or remove it, as needed.
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        If SUPER_USER = "N" Then
            Me.CurrenciesBaseView.OptionsBehavior.Editable = False
        End If

    End Sub
    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
            Me.LayoutControl1.Visible = False
        End If
    End Sub

    Private Sub Currencies_LookUpEdit_Click(sender As Object, e As EventArgs) Handles Currencies_LookUpEdit.Click
        Try
            Me.CURRENCIESTableAdapter.FillByValidCurrencies(Me.EXTERNALDataset.CURRENCIES)
        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub Currencies_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Currencies_LookUpEdit.EditValueChanged
        Me.CurrencyName_lbl.Text = Me.Currencies_LookUpEdit.GetColumnValue("CURRENCY NAME").ToString

    End Sub


    Private Sub AddNewInternalCurrency_btn_Click(sender As Object, e As EventArgs) Handles AddNewInternalCurrency_btn.Click

        If Me.Currencies_LookUpEdit.EditValue <> Nothing AndAlso Me.NacionalCurrency_ComboBoxEdit.EditValue <> Nothing AndAlso Me.CurrencySpread_txt.Text >= 0 Then
            Try
                Me.Validate()
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                cmd.CommandText = "INSERT INTO  [OWN_CURRENCIES] ([CURRENCY CODE],[CURRENCY NAME],[OWN CURRENCY],[ACCEPTS DECIMALS],[SPREAD],[VALID])VALUES('" & Me.Currencies_LookUpEdit.Text & " ','" & Me.CurrencyName_lbl.Text & "','" & Me.NacionalCurrency_ComboBoxEdit.Text & "','" & Me.AcceptsDecimals_ComboBoxEdit.Text & "','" & Str(Me.CurrencySpread_txt.Text) & "','Y')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update A set A.[LZB_CurrencyCode]=B.[LZB_CurrencyCode],A.[NEWG_CurrencyCode]=B.[NEWG_CurrencyCode] from OWN_CURRENCIES A INNER JOIN CURRENCIES B on A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.LayoutControl1.Visible = True
                Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
                XtraMessageBox.Show("The Currency Code: " & Me.Currencies_LookUpEdit.Text & " has being added to the Internal Currencies", "CURRENCY INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            XtraMessageBox.Show("Validation Failed!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub


    Private Sub Currencies_LookUpEdit_Validating(sender As Object, e As CancelEventArgs) Handles Currencies_LookUpEdit.Validating
        If TryCast(sender, LookUpEdit).EditValue Is Nothing Then
            'e.Cancel = True
        End If

    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.LayoutControl1.Visible = True

    End Sub


    Private Sub NacionalCurrency_ComboBoxEdit_Validating(sender As Object, e As CancelEventArgs) Handles NacionalCurrency_ComboBoxEdit.Validating
        If TryCast(sender, ComboBoxEdit).Text Is Nothing Then
            'e.Cancel = True
        End If
    End Sub

    Private Sub CurrencySpread_txt_Validating(sender As Object, e As CancelEventArgs) Handles CurrencySpread_txt.Validating
        If TryCast(sender, TextEdit).Text < 0 Then
            'e.Cancel = True
        End If
    End Sub

    Private Sub CurrenciesBaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CurrenciesBaseView.CellValueChanged

        If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Try
                Me.Validate()
                Me.OWN_CURRENCIESBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "Update A set A.[LZB_CurrencyCode]=B.[LZB_CurrencyCode],A.[NEWG_CurrencyCode]=B.[NEWG_CurrencyCode] from OWN_CURRENCIES A INNER JOIN CURRENCIES B on A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.OWN_CURRENCIESBindingSource.CancelEdit()
                Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
                Exit Sub
            End Try
        End If


    End Sub

    Private Sub CurrenciesBaseView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles CurrenciesBaseView.InvalidValueException
        'Do not perform any default action 
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)


    End Sub

    Private Sub CurrenciesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CurrenciesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CurrenciesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CurrenciesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub



    Private Sub CurrenciesBaseView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles CurrenciesBaseView.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "SPREAD" Then
            'Get the currently edited value 
            Dim SpreadValue As Double = Convert.ToDouble(e.Value)
            'Specify validation criteria 
            If SpreadValue < 0 Then
                e.Valid = False
                e.ErrorText = "SPREAD accepts only positive or Zero values"
            End If
        End If



    End Sub

    Private Sub InternalCurrencies_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles InternalCurrencies_Print_Export_btn.Click
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
End Class