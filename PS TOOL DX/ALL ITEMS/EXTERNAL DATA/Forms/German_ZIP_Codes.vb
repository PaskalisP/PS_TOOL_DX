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
Public Class German_ZIP_Codes

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

    Private Sub PLZ_BUNDESLANDBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.PLZ_BUNDESLANDBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)

    End Sub

    Private Sub German_ZIP_Codes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Validate()
            Me.PLZ_BUNDESLANDBindingSource.EndEdit()
            If Me.EXTERNALDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub German_ZIP_Codes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        'TODO: This line of code loads data into the 'EXTERNALDataset.PLZ_BUNDESLAND' table. You can move, or remove it, as needed.
        Me.PLZ_BUNDESLANDTableAdapter.Fill(Me.EXTERNALDataset.PLZ_BUNDESLAND)
        If SUPER_USER = "N" Then
            PLZBaseView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.PLZ_BUNDESLANDBindingSource.EndEdit()
                If Me.EXTERNALDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                        Me.PLZ_BUNDESLANDTableAdapter.Fill(Me.EXTERNALDataset.PLZ_BUNDESLAND)
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

            Dim row As System.Data.DataRow = PLZBaseView.GetDataRow(PLZBaseView.FocusedRowHandle)
            Dim ID As Integer = row(0)
            Dim PLZ As Double = row(1)
            Dim STADT As String = row(2)

            If XtraMessageBox.Show("Should the Zipcode: " & PLZ & " (" & STADT & ")" & " be deleted?", "DELETE ZIPCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Dim ZipcodeDelete As EXTERNALDataset.PLZ_BUNDESLANDRow
                ZipcodeDelete = EXTERNALDataset.PLZ_BUNDESLAND.FindByID(ID)
                ZipcodeDelete.Delete()
                PLZBaseView.DeleteSelectedRows()
                GridControl2.Update()
                Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                Me.PLZ_BUNDESLANDTableAdapter.Fill(Me.EXTERNALDataset.PLZ_BUNDESLAND)
            Else
                e.Handled = True
            End If
        End If


    End Sub

    Private Sub PLZBaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles PLZBaseView.InvalidRowException
        'Suppress displaying the error message box
        e.ExceptionMode = ExceptionMode.NoAction
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub PLZBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PLZBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PLZBaseView_ShownEditor(sender As Object, e As EventArgs) Handles PLZBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black

        End If
    End Sub

    Private Sub PLZBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles PLZBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim ZipCode As GridColumn = View.Columns("PLZ")
        Dim CityName As GridColumn = View.Columns("ORT")
        Dim Federal_State As GridColumn = View.Columns("BUNDESLAND")

        'Get the value of the first column
        Dim PLZ As String = View.GetRowCellValue(e.RowHandle, colPLZ).ToString
        'Get the value of the second column
        Dim ORT As String = View.GetRowCellValue(e.RowHandle, colORT).ToString
        Dim BUNDESLAND As String = View.GetRowCellValue(e.RowHandle, colBUNDESLAND).ToString

        If PLZ = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ZipCode, "The Zipcode must not be empty")
            e.ErrorText = "The Zipcode must not be empty"
        End If

        If ORT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CityName, "The City Name must not be empty")
            e.ErrorText = "The City Name must not be empty"
        End If

        If BUNDESLAND = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Federal_State, "The Federal State must not be empty")
            e.ErrorText = "The Federal State must not be empty"
        End If

    End Sub

    Private Sub PLZ_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles PLZ_Print_Export_btn.Click
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
        Dim reportfooter As String = "GERMAN ZIPCODES" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PLZBaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles PLZBaseView.RowUpdated
        Try
            Me.Validate()
            Me.PLZ_BUNDESLANDBindingSource.EndEdit()
            If Me.EXTERNALDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                    Me.PLZ_BUNDESLANDTableAdapter.Fill(Me.EXTERNALDataset.PLZ_BUNDESLAND)
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