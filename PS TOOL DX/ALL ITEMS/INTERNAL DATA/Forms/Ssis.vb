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
Public Class Ssis
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

    Private Sub SSISBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SSISBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub Ssis_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            '***********Save Changes****************
            If Me.PSTOOLDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes in SSIS be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.Validate()
                    Me.SSISBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                End If
            End If
            '****************************************
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = True
            Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)
        End Try
    End Sub

    Private Sub Ssis_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        'TODO: This line of code loads data into the 'PSTOOLDataset.SSIS' table. You can move, or remove it, as needed.
        Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)

        'Gridcontrol2 - CUSTOMERS
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = SSISBaseView
        SSISBaseView.ForceDoubleClick = True
        AddHandler SSISBaseView.DoubleClick, AddressOf SSISBaseView_DoubleClick
        AddHandler SSISDetailView.MouseDown, AddressOf SSISDetailView_MouseDown
        AddHandler ViewEdit_btn.Click, AddressOf ViewEdit_btn_Click
        SSISDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        SSISDetailView.OptionsBehavior.AllowSwitchViewModes = False

        If SUPER_USER = "N" OrElse ACCOUNTING_USER = "N" Then
            Me.SSISDetailView.OptionsBehavior.Editable = False
            Me.SSISBaseView.OptionsBehavior.Editable = False
        ElseIf SUPER_USER = "Y" OrElse ACCOUNTING_USER = "Y" Then
            Me.SSISDetailView.OptionsBehavior.Editable = True
            Me.SSISBaseView.OptionsBehavior.Editable = True

        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
            Me.LayoutControl1.Visible = False
            Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
        End If
    End Sub


#Region "SSIS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "Edit Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)


        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = SSISDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SSISBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        ViewEdit_btn.Text = strShowExtendedMode
        ViewEdit_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is SSISDetailView)

        '***********Save Changes****************
        If Me.PSTOOLDataset.HasChanges = True Then
            If XtraMessageBox.Show("Should the Changes in NOSTRO Accounts be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.Validate()
                Me.SSISBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)
            Else
                Me.SSISBindingSource.CancelEdit()
                Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)

            End If
        End If
        '****************************************
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = SSISBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SSISDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        ViewEdit_btn.Text = strHideExtendedMode
        ViewEdit_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is SSISDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SSISBaseView.GetRowHandle(dataSourceRowIndex)
        SSISBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SSISDetailView.GetRowHandle(dataSourceRowIndex)
        SSISDetailView.VisibleRecordIndex = SSISDetailView.GetVisibleIndex(rowHandle)
        SSISDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub SSISBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = SSISBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub SSISDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = SSISDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub ViewEdit_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub Currencies_LookUpEdit_Click(sender As Object, e As EventArgs) Handles Currencies_LookUpEdit.Click
        Try
            Me.OWN_CURRENCIESTableAdapter.FillByValid(Me.PSTOOLDataset.OWN_CURRENCIES)
        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub Currencies_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Currencies_LookUpEdit.EditValueChanged
        Me.CurrencyName_lbl.Text = Me.Currencies_LookUpEdit.GetColumnValue("CURRENCY NAME").ToString
    End Sub

    Private Sub CorrespondentBIC_ButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles CorrespondentBIC_ButtonEdit.ButtonClick
        If Len(Me.CorrespondentBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & Me.CorrespondentBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.CorrespondentName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CorrespondentBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub


    Private Sub CorrespondentBIC_ButtonEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CorrespondentBIC_ButtonEdit.EditValueChanged
        Me.CorrespondentName_lbl.Text = ""
        If Len(Me.CorrespondentBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & Me.CorrespondentBIC_ButtonEdit.Text & "' "
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.CorrespondentName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CorrespondentBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub IntermediaryBIC_ButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles IntermediaryBIC_ButtonEdit.ButtonClick
        If Len(Me.IntermediaryBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & Me.IntermediaryBIC_ButtonEdit.Text & "' "
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.IntermediaryName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.IntermediaryBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub


    Private Sub IntermediaryBIC_ButtonEdit_EditValueChanged(sender As Object, e As EventArgs) Handles IntermediaryBIC_ButtonEdit.EditValueChanged
        Me.IntermediaryName_lbl.Text = ""
        If Len(Me.IntermediaryBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & Me.IntermediaryBIC_ButtonEdit.Text & "' "
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.IntermediaryName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.IntermediaryBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub


    Private Sub AddNewSSI_btn_Click(sender As Object, e As EventArgs) Handles AddNewSSI_btn.Click
        If Me.Currencies_LookUpEdit.EditValue <> Nothing AndAlso Me.CorrespondentName_lbl.Text <> Nothing AndAlso IsDate(Me.OpenDate_DateEdit.Text) = True Then
            Try
                Me.Validate()
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                Dim d As Date = Me.OpenDate_DateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                cmd.CommandText = "INSERT INTO  [SSIS] 
                ([CURRENCY CODE],[CURRENCY NAME],[ClientNo],[NOSTRO_NAME]
                ,[INTERNAL ACCOUNT],[CORRESPONDENT BIC],[CORRESPONDENT NAME],[AccountIdentifierStatement]
                ,[EXTERNAL ACCOUNT],[INTERMEDIARY BIC],[INTERMEDIARY NAME],[Open_Date],[VALID])
                VALUES('" & Me.Currencies_LookUpEdit.Text & " ','" & Me.CurrencyName_lbl.Text & "','" & Me.ClientNrOCBS_GridLookUpEdit.Text & "','" & Me.ClientName_lbl.Text & "'
                ,'" & Me.InternalAccount_txt.Text & "','" & Me.CorrespondentBIC_ButtonEdit.Text & "','" & Me.CorrespondentName_lbl.Text & "','" & Me.AccountIdentifier_TextEdit.Text & "'
                ,'" & Me.ExternalAccount_txt.Text & "','" & Me.IntermediaryBIC_ButtonEdit.Text & "','" & Me.IntermediaryName_lbl.Text & "','" & dsql & "','Y')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [SSIS] set [CURRENCY CODE]=RTRIM(LTRIM([CURRENCY CODE]))"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)
                XtraMessageBox.Show("The Nostro/Settlement Instruction has being added to the SSIS", "SSI/NOSTRO INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.InternalAccount_txt.Text = ""
                Me.ExternalAccount_txt.Text = ""
                Me.CorrespondentBIC_ButtonEdit.Text = ""
                Me.IntermediaryBIC_ButtonEdit.Text = ""
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            XtraMessageBox.Show("Validation Failed!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub SSISDetailView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles SSISDetailView.CellValueChanged

        If SSISDetailView.FocusedColumn.FieldName = "ClientNo" Then
            'Get the currently edited value 
            Dim CLIENT_NR As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(CLIENT_NR) = 18 Then
                cmd.CommandText = "SELECT [English Name] as 'ClientName' FROM [CUSTOMER_INFO] where [ClientNo]='" & CLIENT_NR & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    SSISDetailView.SetRowCellValue(e.RowHandle, "NOSTRO_NAME", dt.Rows.Item(0).Item("ClientName"))
                Else
                    XtraMessageBox.Show("Client Nr./Name not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SSISDetailView.SetRowCellValue(e.RowHandle, "ClientNo", "")
                    SSISDetailView.SetRowCellValue(e.RowHandle, "NOSTRO_NAME", "")
                End If
            End If
        End If

        If SSISDetailView.FocusedColumn.FieldName = "CORRESPONDENT BIC" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    SSISDetailView.SetRowCellValue(e.RowHandle, "CORRESPONDENT NAME", dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SSISDetailView.SetRowCellValue(e.RowHandle, "CORRESPONDENT NAME", "")
                End If
            End If
        End If
        '***************************************
        If SSISDetailView.FocusedColumn.FieldName = "INTERMEDIARY BIC" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    SSISDetailView.SetRowCellValue(e.RowHandle, "INTERMEDIARY NAME", dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SSISDetailView.SetRowCellValue(e.RowHandle, "INTERMEDIARY NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub SSISDetailView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles SSISDetailView.CellValueChanging
        If SSISDetailView.FocusedColumn.FieldName = "ClientNo" Then
            'Get the currently edited value 
            Dim CLIENT_NR As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(CLIENT_NR) = 18 Then
                cmd.CommandText = "SELECT [English Name] as 'ClientName' FROM [CUSTOMER_INFO] where [ClientNo]='" & CLIENT_NR & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    SSISDetailView.SetRowCellValue(e.RowHandle, "NOSTRO_NAME", dt.Rows.Item(0).Item("ClientName"))
                Else
                    XtraMessageBox.Show("Client Nr./Name not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SSISDetailView.SetRowCellValue(e.RowHandle, "ClientNo", "")
                    SSISDetailView.SetRowCellValue(e.RowHandle, "NOSTRO_NAME", "")
                End If
            End If
        End If
        If SSISDetailView.FocusedColumn.FieldName = "CORRESPONDENT BIC" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    SSISDetailView.SetRowCellValue(e.RowHandle, "CORRESPONDENT NAME", dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SSISDetailView.SetRowCellValue(e.RowHandle, "CORRESPONDENT NAME", "")
                End If
            End If
        End If
        '***************************************
        If SSISDetailView.FocusedColumn.FieldName = "INTERMEDIARY BIC" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT RTRIM(LTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',RTRIM(LTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    SSISDetailView.SetRowCellValue(e.RowHandle, "INTERMEDIARY NAME", dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SSISDetailView.SetRowCellValue(e.RowHandle, "INTERMEDIARY NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub SSISDetailView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles SSISDetailView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub SSISDetailView_MouseWheel(sender As Object, e As MouseEventArgs) Handles SSISDetailView.MouseWheel
        TryCast(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
    End Sub

    Private Sub SSISDetailView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles SSISDetailView.ValidatingEditor
        'Set Validation to Columnseditors
        If Me.SSISDetailView.FocusedColumn.FieldName = "CORRESPONDENT BIC" Or Me.SSISDetailView.FocusedColumn.FieldName = "INTERMEDIARY BIC" Then
            If Len(e.Value) <> 11 Then
                e.Valid = False
                e.ErrorText = "BIC Field: " & Me.SSISDetailView.FocusedColumn.Caption.ToString & " is Mandatory!" & vbNewLine & "Please input 11 Alphanummeric Digits!"
            End If
        End If
    End Sub

    Private Sub SSISBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SSISBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub



    Private Sub SSISBaseView_ShownEditor(sender As Object, e As EventArgs) Handles SSISBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.LayoutControl1.Visible = True
        Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)
    End Sub

    Private Sub SSIS_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles SSIS_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If ViewEdit_btn.Text = "Edit Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.SSISDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.SSISDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.SSISDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.SSISDetailView.OptionsPrint.PrintCardCaption = True
            Me.SSISDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.SSISDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.SSISDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.SSISDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.SSISDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If
    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

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
        Dim reportfooter As String = "NOSTRO ACCOUNTS LIST" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SSISreport_btn_Click(sender As Object, e As EventArgs) Handles SSISreport_btn.Click
        Dim report As New SSISXtraReport()

        Using printTool As New ReportPrintTool(report)
            ' Invoke the Ribbon Print Preview form modally, 
            ' and load the report document into it.
            printTool.ShowRibbonPreviewDialog()


            ' Invoke the Ribbon Print Preview form
            ' with the specified look and feel setting.
            printTool.ShowRibbonPreview(UserLookAndFeel.Default)
        End Using

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
End Class