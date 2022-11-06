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
Public Class ProductTypesOCBS

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

    Private Sub ProductTypeBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ProductTypeBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub ProductTypesOCBS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Validate()
            Me.ProductTypeBindingSource.EndEdit()
            If Me.PSTOOLDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                Else

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub ProductTypesOCBS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.ContractTypeTableAdapter.Fill(Me.PSTOOLDataset.ContractType)
        'TODO: This line of code loads data into the 'PSTOOLDataset.ProductType' table. You can move, or remove it, as needed.
        Me.ProductTypeTableAdapter.Fill(Me.PSTOOLDataset.ProductType)
        If SUPER_USER = "N" Then
            Me.ProductTypesBaseView.OptionsBehavior.Editable = False

        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ProductTypeBindingSource.EndEdit()
                If Me.PSTOOLDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
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
            If Me.GridControl2.FocusedView.Name = "ProductTypesBaseView" Then
                Dim row As System.Data.DataRow = ProductTypesBaseView.GetDataRow(ProductTypesBaseView.FocusedRowHandle)
                Dim ProductTypeValue As String = row(2)

                If XtraMessageBox.Show("Should the Product Type: " & ProductTypeValue & " be deleted?", "DELETE PRODUCT TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Dim ProductTypeDelete As PSTOOLDataset.ProductTypeRow
                    ProductTypeDelete = PSTOOLDataset.ProductType.FindByProduct_Type(ProductTypeValue)
                    ProductTypeDelete.Delete()
                    ProductTypesBaseView.DeleteSelectedRows()
                    GridControl2.Update()
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    Me.ProductTypeTableAdapter.Fill(Me.PSTOOLDataset.ProductType)
                Else
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Private Sub ProductTypesBaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ProductTypesBaseView.FocusedRowChanged
        'If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Product Group").OptionsColumn.ReadOnly = False
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Product Type").OptionsColumn.ReadOnly = False
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Product Type Name").OptionsColumn.ReadOnly = False
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Contract Type").OptionsColumn.ReadOnly = False
        'Else
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Product Group").OptionsColumn.ReadOnly = True
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Product Type").OptionsColumn.ReadOnly = True
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Product Type Name").OptionsColumn.ReadOnly = True
        '    Me.ProductTypesBaseView.Columns.ColumnByFieldName("Contract Type").OptionsColumn.ReadOnly = True
        'End If
    End Sub

    Private Sub ProductTypesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ProductTypesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ProductTypesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ProductTypesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black

        End If
    End Sub

    Private Sub ProductTypesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ProductTypesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CoreSystem As GridColumn = View.Columns("CoreSystem")
        Dim ProductGroup As GridColumn = View.Columns("Product Group")
        Dim ProductType As GridColumn = View.Columns("Product Type")
        Dim ProductName As GridColumn = View.Columns("Product Type Name")
        Dim ContractType As GridColumn = View.Columns("Contract Type")
        Dim TradeFinance As GridColumn = View.Columns("Trade_Finance")
        'Get the value of the first column
        Dim CS As String = View.GetRowCellValue(e.RowHandle, colCoreSystem).ToString
        Dim PG As String = View.GetRowCellValue(e.RowHandle, colProductGroup).ToString
        'Get the value of the second column
        Dim PT As String = View.GetRowCellValue(e.RowHandle, colProductType).ToString
        Dim PN As String = View.GetRowCellValue(e.RowHandle, colProductTypeName).ToString
        Dim CT As String = View.GetRowCellValue(e.RowHandle, colContractType).ToString
        Dim TF As String = View.GetRowCellValue(e.RowHandle, colTrade_Finance).ToString
        If CS = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CoreSystem, "The Core System must not be empty")
            e.ErrorText = "The Core System must not be empty"
        End If
        If PG = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ProductGroup, "The Product Group must not be empty")
            e.ErrorText = "The Product Group must not be empty"
        End If

        If PT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ProductType, "The Product Type must not be empty")
            e.ErrorText = "The Product Type must not be empty"
        End If

        If PN = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ProductName, "The Product Name must not be empty")
            e.ErrorText = "The Product Name must not be empty"
        End If

        If CT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ContractType, "The Contract Type must not be empty")
            e.ErrorText = "The Contract Type must not be empty"
        End If
        If TF = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TradeFinance, "The Trade Finance Sign must not be empty")
            e.ErrorText = "The Trade Finance Sign must not be empty"
        End If
    End Sub

    Private Sub ProductTypesOCBS_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles ProductTypesOCBS_Print_Export_btn.Click
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
        Dim reportfooter As String = "PRODUCT TYPES" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ProductTypesBaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ProductTypesBaseView.RowUpdated
        Try
            Me.Validate()
            Me.ProductTypeBindingSource.EndEdit()
            If Me.PSTOOLDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
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