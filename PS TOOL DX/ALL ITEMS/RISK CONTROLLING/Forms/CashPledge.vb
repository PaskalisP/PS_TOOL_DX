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
Public Class CashPledge

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

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

    Private Sub CREDIT_RISK_CASH_PLEDGEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CREDIT_RISK_CASH_PLEDGEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)

    End Sub

    Private Sub CashPledge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'RiskControllingBasicsDataSet.CREDIT_RISK_CASH_PLEDGE' table. You can move, or remove it, as needed.
        Me.CREDIT_RISK_CASH_PLEDGETableAdapter.Fill(Me.RiskControllingBasicsDataSet.CREDIT_RISK_CASH_PLEDGE)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CREDIT_RISK_CASH_PLEDGEBindingSource.EndEdit()
                If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                        Me.CREDIT_RISK_CASH_PLEDGETableAdapter.Fill(Me.RiskControllingBasicsDataSet.CREDIT_RISK_CASH_PLEDGE)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If


    End Sub

    Private Sub Cashpledge_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles Cashpledge_BaseView.CellValueChanged
        If e.Column.FieldName = "CustomerNr" Then
            Dim row As System.Data.DataRow = Cashpledge_BaseView.GetDataRow(Cashpledge_BaseView.FocusedRowHandle)
            Dim CUSTOMER_NO As String = row(2)

            If CUSTOMER_NO <> "" Then
                cmd.CommandText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & CUSTOMER_NO & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Cashpledge_BaseView.SetRowCellValue(e.RowHandle, "CustomerName", dt.Rows.Item(0).Item("English Name"))
                Else
                    MessageBox.Show("Client No not fund ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Cashpledge_BaseView.SetRowCellValue(e.RowHandle, "CustomerName", "")
                    'Cashpledge_BaseView.SetRowCellValue(e.RowHandle, "CustomerNr", "")
                End If


            End If

        End If
    End Sub

    Private Sub Cashpledge_BaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles Cashpledge_BaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.Cashpledge_BaseView.Columns.ColumnByFieldName("CustomerNr").OptionsColumn.ReadOnly = False
            Me.Cashpledge_BaseView.Columns.ColumnByFieldName("CustomerNr").OptionsColumn.AllowEdit = True
        Else
            Me.Cashpledge_BaseView.Columns.ColumnByFieldName("CustomerNr").OptionsColumn.ReadOnly = True
            Me.Cashpledge_BaseView.Columns.ColumnByFieldName("CustomerNr").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub Cashpledge_BaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles Cashpledge_BaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Cashpledge_BaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles Cashpledge_BaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Cashpledge_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Cashpledge_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Cashpledge_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles Cashpledge_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Cashpledge_BaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Cashpledge_BaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CUSTOMER_NAME As GridColumn = View.Columns("CustomerName")
        Dim CUSTOMER_NR As GridColumn = View.Columns("CustomerNr")
        Dim CASHPLEDGE_AMOUNT As GridColumn = View.Columns("CashpledgeAmount")
        Dim VALIDITY As GridColumn = View.Columns("Valid")
        Dim VALID_TILL As GridColumn = View.Columns("ValidTill")

        Dim CustomerName As String = View.GetRowCellValue(e.RowHandle, colCustomerName).ToString
        Dim CustomerNr As String = View.GetRowCellValue(e.RowHandle, colCustomerNr).ToString
        Dim CashpledgeAmount As String = View.GetRowCellValue(e.RowHandle, colCashpledgeAmount).ToString
        Dim Valid As String = View.GetRowCellValue(e.RowHandle, colValid).ToString
        Dim ValidTill As String = View.GetRowCellValue(e.RowHandle, colValidTill).ToString

        If CustomerName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CUSTOMER_NAME, "The Customer Name must not be empty")
            e.ErrorText = "Customer Name must not be empty"
        End If
        If CustomerNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CUSTOMER_NR, "The Custumer No  must not be empty")
            e.ErrorText = "The Custumer No  must not be empty"
        End If
        If CashpledgeAmount = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CASHPLEDGE_AMOUNT, "The Cash pledge amount  must not be empty")
            e.ErrorText = "The Cash pledge amount  must not be empty"
        End If
        If Valid = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY, "The Validity  must not be empty")
            e.ErrorText = "The Validity  must not be empty"
        End If
        If ValidTill = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALID_TILL, "The Validity Date  must not be empty")
            e.ErrorText = "The Validity Date  must not be empty"
        End If
    End Sub

    Private Sub Cashpledge_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Cashpledge_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

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
        Dim reportfooter As String = "CASH PLEDGE "
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
End Class