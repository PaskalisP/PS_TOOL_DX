Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports Microsoft.VisualBasic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports System.Drawing
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native


Public Class LcExportCustomers

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private BS_All_Customers As BindingSource

    Dim CrystalRepDir As String = ""
    Dim ConditionType As String = Nothing

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

    Private Sub EXPORT_LC_CUSTOMERSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EXPORT_LC_CUSTOMERSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.LcDataset)

    End Sub

    Private Sub LcExportCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LayoutControl1.Dock = DockStyle.Fill

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick
        AddHandler GridControl4.EmbeddedNavigator.ButtonClick, AddressOf GridControl4_EmbeddedNavigator_ButtonClick
        AddHandler GridControl5.EmbeddedNavigator.ButtonClick, AddressOf GridControl5_EmbeddedNavigator_ButtonClick

        Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)
        Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
        Me.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS_BankDetails)
        Me.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS_Conditions)
        Me.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS_CollectionConditions)

    End Sub

    Private Sub LcExportCustomers_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.ShowAllCustomers_SimpleButton.PerformClick()
        End If
    End Sub

    Private Sub ALL_CUSTOMERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [ClientNo],[ClientType],[English Name],[CLOSE_DATE] FROM [CUSTOMER_INFO] ORDER BY CASE WHEN CLOSE_DATE IS NULL THEN 1 WHEN CLOSE_DATE IS NOT NULL THEN 2 END, ClientNo", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbAllCustomers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbAllCustomers.Fill(ds, "ALL_CUSTOMERS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_Customers = New BindingSource(ds, "ALL_CUSTOMERS")
    End Sub

    Private Sub ALL_CUSTOMERS_InitLookUp()
        Me.ClientNrOCBS_GridLookUpEdit.Properties.DataSource = BS_All_Customers
        Me.ClientNrOCBS_GridLookUpEdit.Properties.DisplayMember = "ClientNo"
        Me.ClientNrOCBS_GridLookUpEdit.Properties.ValueMember = "ClientNo"
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "AddNewCustomer" Then
            Me.LayoutControl1.Visible = False
            Me.EXPORT_LC_CUSTOMERSBindingSource.EndEdit()
            Me.EXPORT_LC_CUSTOMERSBindingSource.AddNew()
            cmd.Connection.Open()
            cmd.CommandText = "Select Count([ID])+1 from [EXPORT_LC_CUSTOMERS]"
            Dim CustomerId As String = String.Format("{0:0000000000}", cmd.ExecuteScalar)
            Me.CustomerID_TextEdit.Text = CustomerId
            cmd.Connection.Close()
            Me.CustomerName_TextEdit.Focus()
            'Bei Neuanlage noch keine Konditionen angeben
            Me.GridControl3.Visible = False
            Me.GridControl4.Visible = False
            Me.GridControl5.Visible = False
            Me.Label20.Visible = False
            Me.DiscountConditions_MemoEdit.Visible = False
        End If
    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.Conditions_GridView.ShowEditForm))
        End If


        If e.Button.Tag = "DeleteCondition" Then
            If Conditions_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Condition be deleted? ", "DELETE CONDITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Condition...")
                        Me.Conditions_GridView.DeleteRow(Conditions_GridView.FocusedRowHandle)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub GridControl4_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.BankDetails_GridView.ShowEditForm))
        End If

        If e.Button.Tag = "DeleteBankDetail" Then
            If BankDetails_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Bank Detail be deleted? ", "DELETE BANK DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Bank Detail...")
                        Me.BankDetails_GridView.DeleteRow(BankDetails_GridView.FocusedRowHandle)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If

    End Sub

    Private Sub GridControl5_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.ExportCollectionConditions_GridView.ShowEditForm))
        End If


        If e.Button.Tag = "DeleteCondition" Then
            If ExportCollectionConditions_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Condition be deleted? ", "DELETE CONDITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Condition...")
                        Me.ExportCollectionConditions_GridView.DeleteRow(ExportCollectionConditions_GridView.FocusedRowHandle)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub ShowAllCustomers_SimpleButton_Click(sender As Object, e As EventArgs) Handles ShowAllCustomers_SimpleButton.Click
        Me.EXPORT_LC_CUSTOMERSBindingSource.CancelEdit()
        Me.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS_Conditions)
        Me.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS_CollectionConditions)
        Me.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS_BankDetails)
        Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)
        Me.LayoutControl1.Visible = True
    End Sub

    Private Sub Save_SimpleButton_Click(sender As Object, e As EventArgs) Handles Save_SimpleButton.Click
        If Me.DxValidationProvider1.Validate() = True Then
            Try
                Me.Validate()
                Me.EXPORT_LC_CUSTOMERSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.LcDataset)
                Me.LayoutControl1.Visible = True
                Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            MessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub

    Private Sub ExportLc_Customers_BaseView_DoubleClick(sender As Object, e As EventArgs) Handles ExportLc_Customers_BaseView.DoubleClick
        Me.LayoutControl1.Visible = False
        'Konditionen anzeigen + angeben
        Me.GridControl3.Visible = True
        Me.GridControl4.Visible = True
        Me.GridControl5.Visible = True
        Me.Label20.Visible = True
        Me.DiscountConditions_MemoEdit.Visible = True
        Me.CustomerName_TextEdit.Focus()

    End Sub

    Private Sub ExportLc_Customers_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLc_Customers_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ExportLc_Customers_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLc_Customers_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ExportLc_Conditions_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLc_Conditions_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ExportLc_Conditions_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLc_Conditions_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridView_btn.Click

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
        Dim reportfooter As String = "FOREIGN CUSTOMERS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub OcbsCustomers_GridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OcbsCustomers_GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ExportCollectionConditions_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportCollectionConditions_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ExportCollectionConditions_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ExportCollectionConditions_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub



    Private Sub RepositoryItemImageComboBox3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox3.EditValueChanged
        Dim editor As DevExpress.XtraEditors.ImageComboBoxEdit = CType(sender, DevExpress.XtraEditors.ImageComboBoxEdit)
        Dim CellValue As String = editor.EditValue

    End Sub

    Private Sub RepositoryItemImageComboBox4_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox4.EditValueChanged
        Dim editor As DevExpress.XtraEditors.ImageComboBoxEdit = CType(sender, DevExpress.XtraEditors.ImageComboBoxEdit)
        ConditionType = editor.EditValue

    End Sub

    Private Sub Conditions_GridView_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles Conditions_GridView.CustomColumnDisplayText
        'If Conditions_GridView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        '    Dim view As ColumnView = TryCast(sender, ColumnView)
        '    If e.Column.FieldName = "ConditionPercent" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

        '        Dim GetConditionType As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "ConditionType")

        '        Select Case GetConditionType
        '            Case = "P"
        '                e.DisplayText = String.Format("{0:p4}", e.Value)
        '                Exit Select
        '            Case = "F"

        '                e.DisplayText = String.Format("{0:c2}", e.Value)
        '                Exit Select
        '        End Select
        '    End If
        'End If

    End Sub

    Private Sub Conditions_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Conditions_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CONDITION_NAME As GridColumn = View.Columns("ConditionName")
        Dim CONDITION_CYCLUS As GridColumn = View.Columns("ConditionCyclus")
        Dim CONDITION_PERCENT As GridColumn = View.Columns("ConditionPercent")
        Dim CONDITION_MIN As GridColumn = View.Columns("ConditionMin")
        Dim CONDITION_MAX As GridColumn = View.Columns("ConditionMax")
        Dim ConditionName As String = View.GetRowCellValue(e.RowHandle, colConditionName).ToString
        Dim ConditionCyclus As String = View.GetRowCellValue(e.RowHandle, colConditionCyclus).ToString
        Dim ConditionPercent As String = View.GetRowCellValue(e.RowHandle, colConditionPercent).ToString
        Dim ConditionMin As Double = CDbl(View.GetRowCellValue(e.RowHandle, colConditionMin))
        Dim ConditionMax As Double = CDbl(View.GetRowCellValue(e.RowHandle, colConditionMax))

        If ConditionName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_NAME, "The Name of the Condition must not be empty")
            e.ErrorText = "The Name of the Condition must not be empty"
        End If

        If ConditionCyclus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_CYCLUS, "The Cyclus of the Condition must not be empty")
            e.ErrorText = "The Cyclus of the Condition must not be empty"
        End If

        If ConditionMin > ConditionMax Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_MAX, "The Min.Condition can not be higher of the Max.Condition!")
            e.ErrorText = "The Min.Condition can not be higher of the Max.Condition!"
        End If

    End Sub

    Private Sub Conditions_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles Conditions_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionPercent"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionMin"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionMax"), 0)

    End Sub

    Private Sub ExportLc_Conditions_BaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ExportLc_Conditions_BaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CONDITION_NAME As GridColumn = View.Columns("ConditionName")
        Dim CONDITION_CYCLUS As GridColumn = View.Columns("ConditionCyclus")
        Dim CONDITION_PERCENT As GridColumn = View.Columns("ConditionPercent")
        Dim CONDITION_MIN As GridColumn = View.Columns("ConditionMin")
        Dim CONDITION_MAX As GridColumn = View.Columns("ConditionMax")
        Dim ConditionName As String = View.GetRowCellValue(e.RowHandle, colConditionName).ToString
        Dim ConditionCyclus As String = View.GetRowCellValue(e.RowHandle, colConditionCyclus).ToString
        Dim ConditionPercent As String = View.GetRowCellValue(e.RowHandle, colConditionPercent).ToString
        Dim ConditionMin As Double = CDbl(View.GetRowCellValue(e.RowHandle, colConditionMin))
        Dim ConditionMax As Double = CDbl(View.GetRowCellValue(e.RowHandle, colConditionMax))

        If ConditionName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_NAME, "The Name of the Condition must not be empty")
            e.ErrorText = "The Name of the Condition must not be empty"
        End If

        If ConditionCyclus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_CYCLUS, "The Cyclus of the Condition must not be empty")
            e.ErrorText = "The Cyclus of the Condition must not be empty"
        End If

        If ConditionMin > ConditionMax Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_MAX, "The Min.Condition can not be higher of the Max.Condition!")
            e.ErrorText = "The Min.Condition can not be higher of the Max.Condition!"
        End If
    End Sub

    Private Sub ExportLc_Conditions_BaseView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ExportLc_Conditions_BaseView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionPercent"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionMin"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionMax"), 0)
    End Sub

    Private Sub ExportCollectionConditions_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ExportCollectionConditions_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CONDITION_NAME As GridColumn = View.Columns("ConditionName")
        Dim CONDITION_CYCLUS As GridColumn = View.Columns("ConditionCyclus")
        Dim CONDITION_PERCENT As GridColumn = View.Columns("ConditionPercent")
        Dim CONDITION_MIN As GridColumn = View.Columns("ConditionMin")
        Dim CONDITION_MAX As GridColumn = View.Columns("ConditionMax")
        Dim ConditionName As String = View.GetRowCellValue(e.RowHandle, colConditionName).ToString
        Dim ConditionCyclus As String = View.GetRowCellValue(e.RowHandle, colConditionCyclus).ToString
        Dim ConditionPercent As String = View.GetRowCellValue(e.RowHandle, colConditionPercent).ToString
        Dim ConditionMin As Double = CDbl(View.GetRowCellValue(e.RowHandle, colConditionMin))
        Dim ConditionMax As Double = CDbl(View.GetRowCellValue(e.RowHandle, colConditionMax))

        If ConditionName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_NAME, "The Name of the Condition must not be empty")
            e.ErrorText = "The Name of the Condition must not be empty"
        End If

        'If ConditionCyclus = "" Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(CONDITION_CYCLUS, "The Cyclus of the Condition must not be empty")
        '    e.ErrorText = "The Cyclus of the Condition must not be empty"
        'End If

        If ConditionMin > ConditionMax Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_MAX, "The Min.Condition can not be higher of the Max.Condition!")
            e.ErrorText = "The Min.Condition can not be higher of the Max.Condition!"
        End If
    End Sub

    Private Sub ExportCollectionConditions_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ExportCollectionConditions_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionPercent"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionMin"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionMax"), 0)
    End Sub

    Private Sub ClientNrOCBS_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientNrOCBS_GridLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If ClientNrOCBS_GridLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.ClientName_lbl.Text = EditRow("English Name").ToString

            Else
                Me.ClientName_lbl.Text = ""

            End If

        End If
    End Sub

    Private Sub BankDetails_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BankDetails_GridView.CellValueChanged
        Dim view As GridView = CType(sender, GridView)
        If e.Column.FieldName = "BIC" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    view.SetRowCellValue(e.RowHandle, "BankName", dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    view.SetRowCellValue(e.RowHandle, "BankName", "")
                End If
            End If
        End If
    End Sub

    Private Sub BankDetails_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles BankDetails_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim ACCOUNT_CONNECTION As GridColumn = View.Columns("AccountConnection")
        Dim ACCOUNT_HOLDER As GridColumn = View.Columns("AccountHolder")
        Dim IBAN_CCY As GridColumn = View.Columns("IBAN_CCY")
        Dim IBAN_NR As GridColumn = View.Columns("IBAN_NR")
        Dim BIC_CODE As GridColumn = View.Columns("BIC")
        Dim BANK_NAME As GridColumn = View.Columns("BankName")
        Dim STATUS_ACC As GridColumn = View.Columns("Status")

        Dim AccountConnection As String = View.GetRowCellValue(e.RowHandle, colAccountConnection).ToString
        Dim AccountHolder As String = View.GetRowCellValue(e.RowHandle, colAccountHolder).ToString
        Dim IbanCCY As String = View.GetRowCellValue(e.RowHandle, colIBAN_CCY).ToString
        Dim IbanNr As String = View.GetRowCellValue(e.RowHandle, colIBAN_NR).ToString
        Dim BicCode As String = View.GetRowCellValue(e.RowHandle, colBIC).ToString
        Dim BankName As String = View.GetRowCellValue(e.RowHandle, colBankName).ToString
        Dim StatusAcc As String = View.GetRowCellValue(e.RowHandle, colStatus).ToString

        If AccountConnection = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ACCOUNT_CONNECTION, "The Account Connection must not be empty")
            e.ErrorText = "The Account Connection must not be empty"
        End If
        If AccountHolder = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ACCOUNT_HOLDER, "The Account holder Name must not be empty")
            e.ErrorText = "The Account holder Name must not be empty"
        End If
        If IbanCCY = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IBAN_CCY, "The Account Currency must not be empty")
            e.ErrorText = "The Account Currency must not be empty"
        End If
        If IbanNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IBAN_NR, "The Account/IBAN Nr. must not be empty")
            e.ErrorText = "The Account/IBAN Nr. must not be empty"
        End If
        If BicCode = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BIC_CODE, "The BIC Code must not be empty")
            e.ErrorText = "The BIC Code must not be empty"
        End If
        If BankName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BANK_NAME, "The Bank Name must not be empty")
            e.ErrorText = "The Bank Name must not be empty"
        End If
        If StatusAcc = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(STATUS_ACC, "The Account Status must not be empty")
            e.ErrorText = "The Account Status must not be empty"
        End If

    End Sub

    Private Sub BankDetails_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles BankDetails_GridView.InitNewRow
        Dim CustomerName As String = Me.CustomerName_TextEdit.Text
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("AccountHolder"), CustomerName)
    End Sub


End Class