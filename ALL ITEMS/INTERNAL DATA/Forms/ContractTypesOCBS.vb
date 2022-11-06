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
Public Class ContractTypesOCBS

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

    Private Sub ContractTypeBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ContractTypeBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub ContractTypesOCBS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Validate()
            Me.ContractTypeBindingSource.EndEdit()
            If Me.PSTOOLDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                Else

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub ContractTypesOCBS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        'TODO: This line of code loads data into the 'PSTOOLDataset.ContractType' table. You can move, or remove it, as needed.
        Me.ContractTypeTableAdapter.Fill(Me.PSTOOLDataset.ContractType)
        If SUPER_USER = "N" Then
            Me.ContractTypesBaseView.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ContractTypeBindingSource.EndEdit()
                If Me.PSTOOLDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
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
            If Me.GridControl2.FocusedView.Name = "ContractTypesBaseView" Then
                Dim row As System.Data.DataRow = ContractTypesBaseView.GetDataRow(ContractTypesBaseView.FocusedRowHandle)
                Dim ContractTypeValue As String = row(1)

                If XtraMessageBox.Show("Should the Contract Type: " & ContractTypeValue & " be deleted?", "DELETE CONTRACT TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim ContractTypeDelete As PSTOOLDataset.ContractTypeRow
                    ContractTypeDelete = PSTOOLDataset.ContractType.FindByContract_Type(ContractTypeValue)
                    ContractTypeDelete.Delete()
                    ContractTypesBaseView.DeleteSelectedRows()
                    GridControl2.Update()
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    Me.ContractTypeTableAdapter.Fill(Me.PSTOOLDataset.ContractType)
                Else
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Private Sub ContractTypesBaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ContractTypesBaseView.FocusedRowChanged
        'If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Type").OptionsColumn.ReadOnly = False
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Group").OptionsColumn.ReadOnly = False
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Type Name(English)").OptionsColumn.ReadOnly = False
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Type Name(Local)").OptionsColumn.ReadOnly = False
        'Else
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Type").OptionsColumn.ReadOnly = True
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Group").OptionsColumn.ReadOnly = True
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Type Name(English)").OptionsColumn.ReadOnly = True
        '    Me.ContractTypesBaseView.Columns.ColumnByFieldName("Contract Type Name(Local)").OptionsColumn.ReadOnly = True
        'End If
    End Sub

    Private Sub ContractTypesBaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ContractTypesBaseView.InvalidRowException
        'Suppress displaying the error message box
        e.ExceptionMode = ExceptionMode.NoAction
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub ContractTypesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ContractTypesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ContractTypesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ContractTypesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black

        End If
    End Sub



    Private Sub ContractTypesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ContractTypesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim ContractType As GridColumn = View.Columns("Contract Type")
        Dim ContractGroup As GridColumn = View.Columns("Contract Group")
        Dim ContractNameEN As GridColumn = View.Columns("Contract Type Name(English)")
        Dim ContractNameLOC As GridColumn = View.Columns("Contract Type Name(Local)")
        'Get the value of the first column
        Dim CT As String = View.GetRowCellValue(e.RowHandle, colContractType).ToString
        'Get the value of the second column
        Dim CG As String = View.GetRowCellValue(e.RowHandle, colContractGroup).ToString
        Dim CNEN As String = View.GetRowCellValue(e.RowHandle, GridColumn1).ToString
        Dim CNLOC As String = View.GetRowCellValue(e.RowHandle, GridColumn2).ToString
        If CT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ContractType, "The Contract Type must not be empty")
            e.ErrorText = "The Contract Type must not be empty"
        End If

        If CG = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ContractGroup, "The Contract Group must not be empty")
            e.ErrorText = "The Industry Description must not be empty"
        End If

        If CNEN = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(GridColumn1, "The Contract Name (English) must not be empty")
            e.ErrorText = "The Contract Name (English) must not be empty"
        End If

        If CNLOC = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(GridColumn2, "The Contract Name (Local) must not be empty")
            e.ErrorText = "The Contract Name (Local) must not be empty"
        End If

    End Sub

    Private Sub ContractTypesOCBS_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles ContractTypesOCBS_Print_Export_btn.Click
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
        Dim reportfooter As String = "CONTRACT TYPES" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ContractTypesBaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ContractTypesBaseView.RowUpdated
        Try
            Me.Validate()
            Me.ContractTypeBindingSource.EndEdit()
            If Me.PSTOOLDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
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