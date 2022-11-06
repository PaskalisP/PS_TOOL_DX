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
Imports DevExpress.XtraEditors.Controls
Public Class Currencies
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

    Private Sub CURRENCIESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CURRENCIESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)

    End Sub

    Private Sub Currencies_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Validate()
            Me.CURRENCIESBindingSource.EndEdit()
            If Me.EXTERNALDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                End If
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub Currencies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get connection
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        'TODO: This line of code loads data into the 'EXTERNALDataset.CURRENCIES' table. You can move, or remove it, as needed.
        Me.CURRENCIESTableAdapter.Fill(Me.EXTERNALDataset.CURRENCIES)
        If SUPER_USER = "N" Then
            Me.CurrenciesBaseView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CURRENCIESBindingSource.EndEdit()
                If Me.EXTERNALDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "Update A set A.[LZB_CurrencyCode]=B.[LZB_CurrencyCode] from OWN_CURRENCIES A INNER JOIN CURRENCIES B on A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'Remove PARAMETER NAMES
            If Me.GridControl2.FocusedView.Name = "CurrenciesBaseView" Then
                Dim row As System.Data.DataRow = CurrenciesBaseView.GetDataRow(CurrenciesBaseView.FocusedRowHandle)
                Dim CurrencyCode As String = row(0)

                If XtraMessageBox.Show("Should the Currency Code: " & CurrencyCode & " be deleted?", "DELETE CURRENCY CODE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Dim CurrencyCodeDelete As EXTERNALDataset.CURRENCIESRow
                    CurrencyCodeDelete = EXTERNALDataset.CURRENCIES.FindByCURRENCY_CODE(CurrencyCode)
                    CurrencyCodeDelete.Delete()
                    CurrenciesBaseView.DeleteSelectedRows()
                    GridControl2.Update()
                    Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                    Me.CURRENCIESTableAdapter.Fill(Me.EXTERNALDataset.CURRENCIES)
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub CurrenciesBaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CurrenciesBaseView.CellValueChanged
        If Me.EXTERNALDataset.HasChanges = True Then
            If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                Me.CURRENCIESTableAdapter.Fill(Me.EXTERNALDataset.CURRENCIES)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "Update A set A.[LZB_CurrencyCode]=B.[LZB_CurrencyCode] from OWN_CURRENCIES A INNER JOIN CURRENCIES B on A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            Else
                Me.CURRENCIESBindingSource.CancelEdit()
                Me.CURRENCIESTableAdapter.Fill(Me.EXTERNALDataset.CURRENCIES)
            End If
        End If
    End Sub

    Private Sub CurrenciesBaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles CurrenciesBaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.CurrenciesBaseView.Columns.ColumnByFieldName("CURRENCY CODE").OptionsColumn.ReadOnly = False
            Me.CurrenciesBaseView.Columns.ColumnByFieldName("CURRENCY CODE").OptionsColumn.AllowEdit = True
        Else
            Me.CurrenciesBaseView.Columns.ColumnByFieldName("CURRENCY CODE").OptionsColumn.ReadOnly = True
            Me.CurrenciesBaseView.Columns.ColumnByFieldName("CURRENCY CODE").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub CurrenciesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CurrenciesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CurrenciesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CurrenciesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black

        End If
    End Sub

    Private Sub CurrenciesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles CurrenciesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CurrencyCode As GridColumn = View.Columns("CURRENCY CODE")
        Dim CurrencyName As GridColumn = View.Columns("CURRENCY NAME")
        Dim Valid As GridColumn = View.Columns("VALID")

        Dim CC As String = View.GetRowCellValue(e.RowHandle, colCURRENCYCODE).ToString
        Dim CN As String = View.GetRowCellValue(e.RowHandle, colCURRENCYNAME).ToString
        Dim VL As String = View.GetRowCellValue(e.RowHandle, colVALID).ToString
        If CC = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CurrencyCode, "The Currency Code must not be empty")
            e.ErrorText = "The Currency Code must not be empty"
        End If
        If CN = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CurrencyName, "The Currency Name must not be empty")
            e.ErrorText = "The Currency Name must not be empty"
        End If
        If VL = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Valid, "The Valid Field must not be empty")
            e.ErrorText = "The Valid Field must not be empty"
        End If


    End Sub

    Private Sub Currencies_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Currencies_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()

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
        Dim reportfooter As String = "ALL CURRENCIES" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CurrenciesBaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles CurrenciesBaseView.RowUpdated
        Try
            Me.Validate()
            Me.CURRENCIESBindingSource.EndEdit()
            If Me.EXTERNALDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Update A set A.[LZB_CurrencyCode]=B.[LZB_CurrencyCode] from OWN_CURRENCIES A INNER JOIN CURRENCIES B on A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                Else
                    Return
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class