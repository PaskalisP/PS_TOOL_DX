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
Public Class CreditRiskRules

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

    Private Sub CREDIT_RISK_RULESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CREDIT_RISK_RULESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)

    End Sub

    Private Sub CreditRiskRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'RiskControllingBasicsDataSet.CREDIT_RISK_RULES' table. You can move, or remove it, as needed.
        Me.CREDIT_RISK_RULESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CREDIT_RISK_RULES)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CREDIT_RISK_RULESBindingSource.EndEdit()
                If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                        Me.CREDIT_RISK_RULESTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CREDIT_RISK_RULES)
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

    Private Sub CreditRiskRulesBaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CreditRiskRulesBaseView.CellValueChanged
        If e.Column.FieldName = "Contract Collateral ID" Then
            Dim row As System.Data.DataRow = CreditRiskRulesBaseView.GetDataRow(CreditRiskRulesBaseView.FocusedRowHandle)
            Dim CONTRACT_TYPE As String = row(2)
            Dim CONTRACT_ID As String = row(3)
            If CONTRACT_TYPE <> "" And CONTRACT_ID <> "" Then
                Select Case CONTRACT_TYPE
                    Case Is = "Client No"
                        cmd.CommandText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & CONTRACT_ID & "'"
                        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                        Dim dt As New DataTable
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            CreditRiskRulesBaseView.SetRowCellValue(e.RowHandle, "Counterparty/Issuer/Collateral Name", dt.Rows.Item(0).Item("English Name"))
                        Else
                            MessageBox.Show("Client No not fund ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            CreditRiskRulesBaseView.SetRowCellValue(e.RowHandle, "Counterparty/Issuer/Collateral Name", "")
                            CreditRiskRulesBaseView.SetRowCellValue(e.RowHandle, "Contract Collateral ID", "")
                        End If
                    Case Is = "Contract ID"
                        cmd.CommandText = "SELECT * FROM [CREDIT RISK] where [Contract Collateral ID]='" & CONTRACT_ID & "'"
                        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                        Dim dt As New DataTable
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            CreditRiskRulesBaseView.SetRowCellValue(e.RowHandle, "Counterparty/Issuer/Collateral Name", dt.Rows.Item(0).Item("Counterparty/Issuer/Collateral Name"))
                        Else
                            MessageBox.Show("Contract ID not fund ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            CreditRiskRulesBaseView.SetRowCellValue(e.RowHandle, "Counterparty/Issuer/Collateral Name", "")
                            CreditRiskRulesBaseView.SetRowCellValue(e.RowHandle, "Contract Collateral ID", "")
                        End If
                End Select
            End If

        End If
    End Sub

    Private Sub CreditRiskRulesBaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles CreditRiskRulesBaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("ContractArt").OptionsColumn.ReadOnly = False
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("ContractArt").OptionsColumn.AllowEdit = True
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("Contract Collateral ID").OptionsColumn.ReadOnly = False
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("Contract Collateral ID").OptionsColumn.AllowEdit = True
        Else
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("ContractArt").OptionsColumn.ReadOnly = True
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("ContractArt").OptionsColumn.AllowEdit = False
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("Contract Collateral ID").OptionsColumn.ReadOnly = True
            Me.CreditRiskRulesBaseView.Columns.ColumnByFieldName("Contract Collateral ID").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub CreditRiskRulesBaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles CreditRiskRulesBaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub CreditRiskRulesBaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles CreditRiskRulesBaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub CreditRiskRulesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CreditRiskRulesBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CreditRiskRulesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CreditRiskRulesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CreditRiskRulesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles CreditRiskRulesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim COLLATERAL_NAME As GridColumn = View.Columns("Counterparty/Issuer/Collateral Name")
        Dim CONTRACT_ART As GridColumn = View.Columns("ContractArt")
        Dim CONTRACT_ID As GridColumn = View.Columns("Contract Collateral ID")
        Dim OBLIGOR_FROM As GridColumn = View.Columns("Obligor Rate from")
        Dim OBLIGOR_TO As GridColumn = View.Columns("Obligor Rate to")
        Dim VALIDITY As GridColumn = View.Columns("Valid")

        Dim CollateralName As String = View.GetRowCellValue(e.RowHandle, GridColumn1).ToString
        Dim ContractArt As String = View.GetRowCellValue(e.RowHandle, colContractArt).ToString
        Dim ContractID As String = View.GetRowCellValue(e.RowHandle, colContractCollateralID).ToString
        Dim ObligorFrom As String = View.GetRowCellValue(e.RowHandle, colObligorRatefrom).ToString
        Dim ObligorTo As String = View.GetRowCellValue(e.RowHandle, colObligorRateto).ToString
        Dim Valid As String = View.GetRowCellValue(e.RowHandle, colValid).ToString

        If CollateralName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(COLLATERAL_NAME, "The Contract Collateral Name must not be empty")
            e.ErrorText = "Contract Collateral Name must not be empty"
        End If
        If ContractArt = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONTRACT_ART, "The Contract Art  must not be empty")
            e.ErrorText = "The Contract Art  must not be empty"
        End If
        If ContractID = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONTRACT_ID, "The Contract ID / Client No  must not be empty")
            e.ErrorText = "The Contract ID / Client No   must not be empty"
        End If
        If ObligorFrom = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(OBLIGOR_FROM, "The Obligor Grate  must not be empty")
            e.ErrorText = "The Obligor Grate  must not be empty"
        End If
        If ObligorTo = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(OBLIGOR_TO, "The Obligor Grate must not be empty")
            e.ErrorText = "The Obligor Grate  must not be empty"
        End If
        If Valid = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY, "The Validity  must not be empty")
            e.ErrorText = "The Validity  must not be empty"
        End If
    End Sub

    Private Sub CreditRiskRules_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles CreditRiskRules_Print_Export_btn.Click
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
        Dim reportfooter As String = "CREDIT RISK RULES "

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub
End Class