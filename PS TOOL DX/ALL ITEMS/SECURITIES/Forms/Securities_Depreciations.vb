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
Public Class Securities_Depreciations
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
    Private Sub SECURITIES_DEPRECIATIONSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SECURITIES_DEPRECIATIONSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)

    End Sub

    Private Sub Securities_Depreciations_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            '***********Save Changes****************
            If Me.SECURITIESDataset.HasChanges = True Then
                If MessageBox.Show("Should the Changes in the Securities Depreciations be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.Validate()
                    Me.SECURITIES_DEPRECIATIONSBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)
                Else
                    e.Cancel = False
                End If
            End If
            '****************************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = True
            Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
        End Try
    End Sub

    Private Sub Securities_Depreciations_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
            Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
            SecuritiesDepreciationsBaseView.ExpandAllGroups()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub Securities_Depreciations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
        SecuritiesDepreciationsBaseView.ExpandAllGroups()

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                If Me.SECURITIESDataset.HasChanges = True Then
                    If MessageBox.Show("Should the Changes in our Securities be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        Try
                            Me.Validate()
                            Me.SECURITIES_DEPRECIATIONSBindingSource.EndEdit()
                            Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)
                            Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.SECURITIES_DEPRECIATIONSBindingSource.CancelEdit()
                            Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
                        End Try
                    Else
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
                Exit Sub
            End Try
        End If
        'cancel edit
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.SECURITIES_DEPRECIATIONSBindingSource.CancelEdit()
            Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
        End If

        'Remove
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                If Me.SecuritiesDepreciationsBaseView.SelectedRowsCount > 0 Then
                    Dim row As System.Data.DataRow = SecuritiesDepreciationsBaseView.GetDataRow(SecuritiesDepreciationsBaseView.FocusedRowHandle)
                    Dim cellvalue As String = row(0)

                    If MsgBox("Should the Security Depreciation No " & cellvalue & " be deleted ?", MsgBoxStyle.YesNo, "DELETE SECURITY DEPRECIATION") = MsgBoxResult.Yes Then
                        Dim Depreciationdelete As SECURITIESDataset.SECURITIES_DEPRECIATIONSRow
                        Depreciationdelete = SECURITIESDataset.SECURITIES_DEPRECIATIONS.FindByID(cellvalue)
                        Depreciationdelete.Delete()
                        GridControl2.Update()
                        Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)
                        Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
                    End If
                End If
                Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
                Exit Sub
            End Try
        End If
        SecuritiesDepreciationsBaseView.ExpandAllGroups()
    End Sub

    Private Sub SecuritiesDepreciationsBaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles SecuritiesDepreciationsBaseView.CellValueChanged
        Try
            If e.Column.FieldName = "ISIN_Code" Then
                Dim row As System.Data.DataRow = SecuritiesDepreciationsBaseView.GetDataRow(SecuritiesDepreciationsBaseView.FocusedRowHandle)
                Dim ISINCODE As String = row(2)
                If ISINCODE <> "" Then
                    cmd.CommandText = "SELECT [SecurityName],[Currency],[AssetType] FROM [SECURITIES_OUR] where [ISIN]='" & ISINCODE & "' and [STATUS]='ACTIVE'"
                    Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Name", dt.Rows.Item(0).Item("SecurityName"))
                        SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Ccy", dt.Rows.Item(0).Item("Currency"))
                        SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Depreciation_Type", dt.Rows.Item(0).Item("AssetType"))
                    Else
                        MessageBox.Show("ISIN CODE not fund or EXPIRED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Name", "")
                        SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Ccy", "")
                        SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Depreciation_Type", "")
                        SecuritiesDepreciationsBaseView.ExpandAllGroups()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
            Exit Sub
        End Try
        'If Me.SecuritiesDepreciationsBaseView.FocusedColumn.FieldName = "ISIN_Code" Then
        'Get the currently edited value 
        'Dim ISINCODE As String = Convert.ToString(e.Value)
        'Specify validation criteria 
        'If ISINCODE <> "" Then
        'cmd.CommandText = "SELECT [SecurityName],[Currency],[AssetType] FROM [SECURITIES_OUR] where [ISIN]='" & ISINCODE & "' and [STATUS]='ACTIVE'"
        'Dim da As New SqlDataAdapter(cmd.CommandText, conn)
        'Dim dt As New DataTable
        'da.Fill(dt)
        'If dt.Rows.Count > 0 Then
        'SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Name", dt.Rows.Item(0).Item("SecurityName"))
        'SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Ccy", dt.Rows.Item(0).Item("Currency"))
        'SecuritiesDepreciationsBaseView.SetRowCellValue(e.RowHandle, "Depreciation_Type", dt.Rows.Item(0).Item("AssetType"))
        'Else
        'MessageBox.Show("ISIN CODE not fund or EXPIRED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Me.SECURITIES_DEPRECIATIONSBindingSource.CancelEdit()
        'Me.SECURITIES_DEPRECIATIONSTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DEPRECIATIONS)
        'SecuritiesDepreciationsBaseView.ExpandAllGroups()
        'End If
        'End If
        'End If

    End Sub

    Private Sub SecuritiesDepreciationsBaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles SecuritiesDepreciationsBaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Date").OptionsColumn.ReadOnly = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Date").OptionsColumn.AllowEdit = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("ISIN_Code").OptionsColumn.ReadOnly = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("ISIN_Code").OptionsColumn.AllowEdit = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Booked_Depreciation").OptionsColumn.ReadOnly = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Booked_Depreciation").OptionsColumn.AllowEdit = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Actual_Depreciation").OptionsColumn.ReadOnly = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Actual_Depreciation").OptionsColumn.AllowEdit = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Before").OptionsColumn.ReadOnly = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Before").OptionsColumn.AllowEdit = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Later").OptionsColumn.ReadOnly = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Later").OptionsColumn.AllowEdit = True
        Else
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Date").OptionsColumn.ReadOnly = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Date").OptionsColumn.AllowEdit = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("ISIN_Code").OptionsColumn.ReadOnly = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("ISIN_Code").OptionsColumn.AllowEdit = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Booked_Depreciation").OptionsColumn.ReadOnly = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Booked_Depreciation").OptionsColumn.AllowEdit = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Actual_Depreciation").OptionsColumn.ReadOnly = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("Actual_Depreciation").OptionsColumn.AllowEdit = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Before").OptionsColumn.ReadOnly = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Before").OptionsColumn.AllowEdit = False
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Later").OptionsColumn.ReadOnly = True
            Me.SecuritiesDepreciationsBaseView.Columns.ColumnByFieldName("OCBS_Booked_Later").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub SecuritiesDepreciationsBaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles SecuritiesDepreciationsBaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub SecuritiesDepreciationsBaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles SecuritiesDepreciationsBaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub SecuritiesDepreciationsBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SecuritiesDepreciationsBaseView.RowStyle
          If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SecuritiesDepreciationsBaseView_ShownEditor(sender As Object, e As EventArgs) Handles SecuritiesDepreciationsBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Securities_Deprec_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Securities_Deprec_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
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
        Dim reportfooter As String = "CCB Frankfurt - SECURITIES DEPRECIATIONS" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SecuritiesDepreciationsBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles SecuritiesDepreciationsBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim INPUTDATE As GridColumn = View.Columns("Date")
        Dim ISIN_NR As GridColumn = View.Columns("ISIN_Code")
        Dim SECURITY_NAME As GridColumn = View.Columns("Name")
        Dim SEC_TYPE As GridColumn = View.Columns("Depreciation_Type")
        Dim CURRENCY As GridColumn = View.Columns("Ccy")
        Dim ACTUAL_DEPREC As GridColumn = View.Columns("Actual_Depreciation")
        Dim BOOKED_DEPREC As GridColumn = View.Columns("Booked_Depreciation")
        Dim OCBS_BEFORE As GridColumn = View.Columns("OCBS_Booked_Before")
        Dim OCBS_LATER As GridColumn = View.Columns("OCBS_Booked_Later")
      

        Dim DeprDate As String = View.GetRowCellValue(e.RowHandle, colDate).ToString
        Dim IsinNr As String = View.GetRowCellValue(e.RowHandle, colISIN_Code).ToString
        Dim SecurityName As String = View.GetRowCellValue(e.RowHandle, colName).ToString
        Dim DepreciationType As String = View.GetRowCellValue(e.RowHandle, colDepreciation_Type).ToString
        Dim CUR As String = View.GetRowCellValue(e.RowHandle, colCcy).ToString
        Dim ActualDepreciation As String = View.GetRowCellValue(e.RowHandle, colActual_Depreciation).ToString
        Dim BookedDepreciation As String = View.GetRowCellValue(e.RowHandle, colBooked_Depreciation).ToString
        Dim OCBS_Booked_before As String = View.GetRowCellValue(e.RowHandle, colOCBS_Booked_Before).ToString
        Dim OCBS_Booked_later As String = View.GetRowCellValue(e.RowHandle, colOCBS_Booked_Later).ToString

       
        If DeprDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(INPUTDATE, "The Date must not be empty")
            e.ErrorText = "The Date must not be empty"
        End If
        If IsinNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ISIN_NR, "The ISIN Nr must not be empty")
            e.ErrorText = "The ISIN Nr must not be empty"
        End If
        If SecurityName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SECURITY_NAME, "The Security Name must not be empty")
            e.ErrorText = "The Security Name must not be empty"
        End If
        If DepreciationType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SEC_TYPE, "The Assets Type must not be empty")
            e.ErrorText = "The Assets Type must not be empty"
        End If
        If CUR = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CURRENCY, "The Currency must not be empty")
            e.ErrorText = "The Currency must not be empty"
        End If
        If ActualDepreciation = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ACTUAL_DEPREC, "Actual Depreciation must not be empty")
            e.ErrorText = "Actual Depreciationmust not be empty"
        End If
        If BookedDepreciation = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BOOKED_DEPREC, "Booked Depreciation must not be empty")
            e.ErrorText = "Booked Depreciation must not be empty"
        End If
        If OCBS_Booked_before = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(OCBS_BEFORE, "OCBS booked before must not be empty")
            e.ErrorText = "OCBS booked before must not be empty"
        End If
        If OCBS_Booked_later = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(OCBS_LATER, "OCBS booked later must not be empty")
            e.ErrorText = "OCBS booked later must not be empty"
        End If
       
    End Sub
End Class