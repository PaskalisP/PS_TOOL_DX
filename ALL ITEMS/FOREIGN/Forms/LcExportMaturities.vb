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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls

Public Class LcExportMaturities

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


    Private Sub LC_EXPORT_MATURITIESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LC_EXPORT_MATURITIESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ForeignDataset)

    End Sub

    Private Sub LcExportMaturities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.LC_EXPORT_MATURITIESTableAdapter.Fill(Me.ForeignDataset.LC_EXPORT_MATURITIES)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)


        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.LC_EXPORT_MATURITIESBindingSource.EndEdit()
                If Me.ForeignDataset.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.LC_EXPORT_MATURITIESTableAdapter.Update(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                        Me.LC_EXPORT_MATURITIESTableAdapter.Fill(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                    Else
                        Me.LC_EXPORT_MATURITIESBindingSource.CancelEdit()
                        Me.LC_EXPORT_MATURITIESTableAdapter.Fill(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Dim row As System.Data.DataRow = ExportLCMaturitiesBaseView.GetDataRow(ExportLCMaturitiesBaseView.FocusedRowHandle)
                Dim ID As String = row(0)
                Dim OurReference As String = row(5)
                Dim SettlementStatus As String = row(9)
                'MsgBox(row(0) & "  " & row(1) & "  " & row(2) & "  " & row(3) & "  " & row(4) & "  " & row(5) & "  " & row(6) & "  " & row(7) & "  " & row(8) & "  " & row(9) & "  " & row(10))
                If SettlementStatus = "PENDING" Then
                    If MessageBox.Show("Should the Maturity with Reference: " & OurReference & " be deleted?", "DELETE MATURITY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        'Dim MaturityDelete As ForeignDataset.LC_EXPORT_MATURITIESRow
                        'MaturityDelete = ForeignDataset.LC_EXPORT_MATURITIES.FindByID(ID)
                        'MaturityDelete.Delete()
                        'ExportLCMaturitiesBaseView.DeleteSelectedRows()
                        'GridControl2.Update()
                        '+++++++DUPLICATE ROW BASED ON THE ID++++++++++++
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "DELETE FROM [LC EXPORT MATURITIES] where [ID]='" & ID & "'"
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        '++++++++++++++++++++++++++++++++++++++++++++++++
                        'Me.LC_EXPORT_MATURITIESTableAdapter.Update(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                        Me.LC_EXPORT_MATURITIESTableAdapter.Fill(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                    Else
                        e.Handled = True
                    End If
                Else
                    MessageBox.Show("Deletion not posible for Maturities with Status: " & SettlementStatus & " ", "UNABLE TO DELETE MATURITY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    e.Handled = True
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Duplicate Row
        If e.Button.Hint = "Duplicate Row" Then
            Try
                If ExportLCMaturitiesBaseView.RowCount > 0 Then
                    Dim row As System.Data.DataRow = ExportLCMaturitiesBaseView.GetDataRow(ExportLCMaturitiesBaseView.FocusedRowHandle)
                    Dim ID As String = row(0)
                    Dim OurReference As String = row(5)
                    Dim LCreference As String = row(4)
                    If LCreference <> "" Then
                        If MessageBox.Show("Should the Datarow with Our Reference: " & OurReference & " LC Reference:" & LCreference & " be duplicated?", "MATURITY DUPLICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            Me.LC_EXPORT_MATURITIESTableAdapter.Update(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                            '+++++++DUPLICATE ROW BASED ON THE ID++++++++++++
                            If cmd.Connection.State = ConnectionState.Closed Then
                                cmd.Connection.Open()
                            End If
                            cmd.CommandText = "INSERT INTO [LC EXPORT MATURITIES]([DocsSendOn],[ApplicantsBank],[Beneficiary],[LCReference],[OurReference],[Currency],[SettlementStatus]) select [DocsSendOn],[ApplicantsBank],[Beneficiary],[LCReference],[OurReference],[Currency],'PENDING' from [LC EXPORT MATURITIES] where [ID]='" & ID & "'"
                            cmd.ExecuteNonQuery()
                            cmd.Connection.Close()
                            '++++++++++++++++++++++++++++++++++++++++++++++++
                            Me.LC_EXPORT_MATURITIESTableAdapter.Fill(Me.ForeignDataset.LC_EXPORT_MATURITIES)
                        Else
                            Return

                        End If
                        Return
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Duplicate Maturity", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub AddRow(ByVal data As String)
        If data = String.Empty Then
            Return
        End If
        Dim rowData() As String = data.Split(New Char() {ControlChars.Cr, ChrW(&H9)})
        Dim newRow As DataRow = Me.ForeignDataset.LC_EXPORT_MATURITIES.NewRow


        For i As Integer = 0 To rowData.Length - 1
            If i >= Me.ForeignDataset.LC_EXPORT_MATURITIES.Columns.Count Then
                Exit For
            End If
            newRow(i) = rowData(i)
        Next i
        Me.ForeignDataset.LC_EXPORT_MATURITIES.Rows.Add(newRow)
    End Sub

    Private Property ClipboardData() As String
        Get
            Dim iData As IDataObject = Clipboard.GetDataObject()
            If iData Is Nothing Then
                Return ""
            End If

            If iData.GetDataPresent(DataFormats.Text) Then
                Return CStr(iData.GetData(DataFormats.Text))
            End If
            Return ""
        End Get
        Set(ByVal value As String)
            Clipboard.SetDataObject(value)
        End Set
    End Property


    Private Function GetSelectedValues(ByVal View As GridView) As String

        If View.SelectedRowsCount = 0 Then Return ""

        Const CellDelimiter As String = vbTab
        Const LineDelimiter As String = vbCrLf

        Dim Result As String = ""

        ' iterate cells and compose a tab delimited string of cell values

        Dim I, J As Integer
        Dim Row As Integer

        For I = View.SelectedRowsCount - 1 To 0 Step -1
            Row = View.GetSelectedRows()(I)
            For J = 0 To View.VisibleColumns.Count - 1
                Result += View.GetRowCellDisplayText(Row, View.VisibleColumns(J))
                If J <> View.VisibleColumns.Count - 1 Then
                    Result += CellDelimiter
                End If

            Next

            If I <> 0 Then

                Result += LineDelimiter

            End If

        Next

        Return Result

    End Function

    Private Sub ExportLCMaturitiesBaseView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ExportLCMaturitiesBaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("DocsSendOn").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("DocsSendOn").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("ApplicantsBank").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("ApplicantsBank").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("OurReference").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("OurReference").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Currency").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Currency").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Amount").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Amount").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Maturity").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Maturity").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("SettlementStatus").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("SettlementStatus").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Beneficiary").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Beneficiary").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("LCReference").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("LCReference").OptionsColumn.AllowEdit = True
        Else
            Dim CellValue As String
            CellValue = ExportLCMaturitiesBaseView.GetRowCellValue(e.FocusedRowHandle, colSettlementStatus)
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("DocsSendOn").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("DocsSendOn").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("ApplicantsBank").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("ApplicantsBank").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("OurReference").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("OurReference").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Currency").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Currency").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Amount").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Amount").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Maturity").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Maturity").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("SettlementStatus").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("SettlementStatus").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Beneficiary").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("Beneficiary").OptionsColumn.AllowEdit = True
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("LCReference").OptionsColumn.ReadOnly = False
            Me.ExportLCMaturitiesBaseView.Columns.ColumnByFieldName("LCReference").OptionsColumn.AllowEdit = True
          
        End If
    End Sub

    Private Sub ExportLCMaturitiesBaseView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles ExportLCMaturitiesBaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ExportLCMaturitiesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLCMaturitiesBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ExportLCMaturitiesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLCMaturitiesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ExportLCMaturitiesBaseView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles ExportLCMaturitiesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim DocsSendOn As GridColumn = View.Columns("DocsSendOn")
        Dim ApplicantsBank As GridColumn = View.Columns("ApplicantsBank")
        Dim OurReference As GridColumn = View.Columns("OurReference")
        Dim Currency As GridColumn = View.Columns("Currency")
        Dim Amount As GridColumn = View.Columns("Amount")
        Dim Maturity As GridColumn = View.Columns("Maturity") 'Not Mandatory
        Dim SettlementStatus As GridColumn = View.Columns("SettlementStatus")
        Dim Beneficiary As GridColumn = View.Columns("Beneficiary")
        Dim LCReference As GridColumn = View.Columns("LCReference") 'Not Mandatory

        Dim DocsSend As String = View.GetRowCellValue(e.RowHandle, colDocsSendOn).ToString
        Dim ApplicantBank As String = View.GetRowCellValue(e.RowHandle, colApplicantsBank).ToString
        Dim Reference As String = View.GetRowCellValue(e.RowHandle, colOurReference).ToString
        Dim CUR As String = View.GetRowCellValue(e.RowHandle, colCurrency).ToString
        Dim AMT As String = View.GetRowCellValue(e.RowHandle, colAmount).ToString
        Dim MAT As String = View.GetRowCellValue(e.RowHandle, colMaturity).ToString
        Dim SETL As String = View.GetRowCellValue(e.RowHandle, colSettlementStatus).ToString
        Dim BENEF As String = View.GetRowCellValue(e.RowHandle, colBeneficiary).ToString
        Dim LCREF As String = View.GetRowCellValue(e.RowHandle, colLCReference).ToString

        If DocsSend = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DocsSendOn, "The Documents Send Date must not be empty")
            e.ErrorText = "The Documents Send Date must not be empty"
        End If
        If ApplicantBank = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ApplicantsBank, "The Applicant Bank must not be empty")
            e.ErrorText = "The Applicant Bank must not be empty"
        End If
        If Reference = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(OurReference, "Our Reference must not be empty")
            e.ErrorText = "Our Reference must not be empty"
        End If
        If CUR = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Currency, "The Currency must not be empty")
            e.ErrorText = "The Currency must not be empty"
        End If
        If AMT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Amount, "The Amount must not be empty")
            e.ErrorText = "The Amount must not be empty"
        End If
        If SETL = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SettlementStatus, "The Settlement Status must not be empty")
            e.ErrorText = "The Settlement must not be empty"
        End If
        If BENEF = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Maturity, "The Beneficiary must not be empty")
            e.ErrorText = "The Beneficiary must not be empty"
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
        Dim reportfooter As String = "EXPORT LC - MATURITIES" & "   " & "Printed on: " & Now
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ExportLCMaturitiesreport_btn_Click(sender As Object, e As EventArgs) Handles ExportLCMaturitiesreport_btn.Click
        Dim report As New ExportLCMaturitiesPending_Xtrareport

        Using printTool As New ReportPrintTool(report)
            ' Invoke the Ribbon Print Preview form modally, 
            ' and load the report document into it.
            printTool.ShowRibbonPreviewDialog()


            ' Invoke the Ribbon Print Preview form
            ' with the specified look and feel setting.
            printTool.ShowRibbonPreview(UserLookAndFeel.Default)
        End Using
    End Sub
End Class