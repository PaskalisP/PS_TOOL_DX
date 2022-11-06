Imports System
Imports System.IO
Imports System.Data.OleDb
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
Public Class InternalGuarantees

    Dim conn As New OleDbConnection
    Dim cmd As New OleDbCommand

    Private QueryText As String = ""
    Private da As New OleDbDataAdapter
    Private dt As New DataTable

    Sub New()
        InitSkins()
        InitializeComponent()
        SkinManager.EnableMdiFormSkins()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("Sharp Plus")
    End Sub

    Private Sub INTERNAL_GUARANTEESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.INTERNAL_GUARANTEESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)

    End Sub

    Private Sub InternalGuarantees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PSTOOLConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'RiskControllingBasicsDataSet.INTERNAL_GUARANTEES' table. You can move, or remove it, as needed.
        Me.INTERNAL_GUARANTEESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.INTERNAL_GUARANTEES)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.INTERNAL_GUARANTEESBindingSource.EndEdit()
                If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                        Me.INTERNAL_GUARANTEESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.INTERNAL_GUARANTEES)
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

    Private Sub InternalGuarantees_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles InternalGuarantees_BaseView.CellValueChanged
        If e.Column.FieldName = "ContractCollateralID" Then
            Dim row As System.Data.DataRow = InternalGuarantees_BaseView.GetDataRow(InternalGuarantees_BaseView.FocusedRowHandle)

            Dim CONTRACT_ID As String = row(1)
            If CONTRACT_ID <> "" Then

                cmd.CommandText = "SELECT * FROM [CREDIT RISK] where [Contract Collateral ID]='" & CONTRACT_ID & "'"
                Dim da As New OleDbDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    InternalGuarantees_BaseView.SetRowCellValue(e.RowHandle, "CustomerName", dt.Rows.Item(0).Item("Counterparty/Issuer/Collateral Name"))
                Else
                    MessageBox.Show("Contract ID not fund ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    InternalGuarantees_BaseView.SetRowCellValue(e.RowHandle, "CustomerName", "")
                    InternalGuarantees_BaseView.SetRowCellValue(e.RowHandle, "ContractCollateralID", "")
                End If

            End If

        End If
    End Sub

    Private Sub InternalGuarantees_BaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles InternalGuarantees_BaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.InternalGuarantees_BaseView.Columns.ColumnByFieldName("ContractCollateralID").OptionsColumn.ReadOnly = False
            Me.InternalGuarantees_BaseView.Columns.ColumnByFieldName("ContractCollateralID").OptionsColumn.AllowEdit = True
           
        Else
            Me.InternalGuarantees_BaseView.Columns.ColumnByFieldName("ContractCollateralID").OptionsColumn.ReadOnly = True
            Me.InternalGuarantees_BaseView.Columns.ColumnByFieldName("ContractCollateralID").OptionsColumn.AllowEdit = False
           
        End If
    End Sub

    Private Sub InternalGuarantees_BaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles InternalGuarantees_BaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub InternalGuarantees_BaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles InternalGuarantees_BaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub InternalGuarantees_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles InternalGuarantees_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub InternalGuarantees_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles InternalGuarantees_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub InternalGuarantees_BaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles InternalGuarantees_BaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CONTRACT_ID As GridColumn = View.Columns("ContractCollateralID")
        Dim CUSTOMER_NAME As GridColumn = View.Columns("CustomerName")
        Dim VALIDITY As GridColumn = View.Columns("Valid")

        Dim ContractID As String = View.GetRowCellValue(e.RowHandle, colContractCollateralID).ToString
        Dim CustomerName As String = View.GetRowCellValue(e.RowHandle, colCustomerName).ToString
        Dim Valid As String = View.GetRowCellValue(e.RowHandle, colValid).ToString

        If ContractID = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONTRACT_ID, "The Contract ID must not be empty")
            e.ErrorText = "Contract ID must not be empty"
        End If
        If CustomerName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CUSTOMER_NAME, "The Customer Name  must not be empty")
            e.ErrorText = "The Customer Name must not be empty"
        End If
        If Valid = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY, "The Validity  must not be empty")
            e.ErrorText = "The Validity  must not be empty"
        End If
    End Sub

    Private Sub InternalGuarantees_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles InternalGuarantees_Print_Export_btn.Click
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
        Dim reportfooter As String = "INTERNAL GUARANTEES "

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub
End Class