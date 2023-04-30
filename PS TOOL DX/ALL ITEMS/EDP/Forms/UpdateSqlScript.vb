Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraRichEdit.Services
Imports PDataTool.RichEditSyntaxSample
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.Spreadsheet

Public Class UpdateSqlScript
    'Inherits EditFormUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Size = New Size(1000, 500)
        ' Add any initialization after the InitializeComponent() call.
        'Me.SetBoundFieldName(MemoEdit1, "ValidityError_Describe")
    End Sub

    Private Sub ColumnsNames_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ColumnsNames_LookUpEdit.EditValueChanged
        If Me.ColumnsNames_LookUpEdit.EditValue.ToString <> "" Then
            QueryText = "select " & ColumnsNames_LookUpEdit.EditValue.ToString & " as FieldValue from " & SQL_Table_TextEdit.EditValue.ToString
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                Me.ColumnValues_LookUpEdit.Properties.DataSource = dt
                Me.ColumnValues_LookUpEdit.Properties.ForceInitialize()
                Me.ColumnValues_LookUpEdit.Properties.PopulateColumns()
                Me.ColumnValues_LookUpEdit.Properties.ValueMember = "FieldValue"
                Me.ColumnValues_LookUpEdit.Properties.DisplayMember = "FieldValue"

            End If
        End If
    End Sub

    Private Sub ColumnValues_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ColumnValues_LookUpEdit.EditValueChanged
        If Me.ColumnValues_LookUpEdit.EditValue.ToString <> "" Then

            QueryText = "select * from " & SQL_Table_TextEdit.EditValue.ToString & " where " & ColumnsNames_LookUpEdit.EditValue.ToString & " = '" & Me.ColumnValues_LookUpEdit.EditValue.ToString & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                'MsgBox(dt.Columns(0).ColumnName.ToString())
                Me.Column_ID_TextEdit.EditValue = dt.Rows(0).Item("ID").ToString
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "Id_SQL_Parameters" Then
                        Me.RelatedID_TextEdit.EditValue = dt.Rows(0).Item("Id_SQL_Parameters").ToString
                        'do your update
                        Exit For
                    ElseIf col.ColumnName = "Id_SQL_Parameters_Details" Then
                        Me.RelatedID_TextEdit.EditValue = dt.Rows(0).Item("Id_SQL_Parameters_Details").ToString
                        Exit For
                    Else
                        Me.RelatedID_TextEdit.EditValue = "0"
                    End If
                Next


                'If dt.Rows(0).Item("Id_SQL_Parameters").ToString IsNot Nothing Then

                'ElseIf dt.Rows(0).Item("Id_SQL_Parameters_Details").ToString IsNot Nothing Then

                'Else
                '    Me.RelatedID_TextEdit.EditValue = "0"
                'End If
            End If
        End If
    End Sub

    Private Sub SpreadsheetCommandBarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs)

    End Sub

    Private Sub SpreadsheetControl1_DocumentLoaded(sender As Object, e As EventArgs) Handles SpreadsheetControl1.DocumentLoaded
        Dim sc As SpreadsheetControl = TryCast(sender, SpreadsheetControl)
        Dim existingCells As IEnumerable(Of DevExpress.Spreadsheet.Cell) = sc.Document.Worksheets(0).GetExistingCells()
        Dim isEmpty As Boolean = True
        For Each cell As DevExpress.Spreadsheet.Cell In existingCells
            If cell.Value IsNot Nothing Then
                isEmpty = False
                Dim workbook As IWorkbook = SpreadsheetControl1.Document
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                Dim A1 As Cell = worksheet.Cells("A1")
                Dim A2 As Cell = worksheet.Cells("A2")
                Dim A6 As Cell = worksheet.Cells("A6")
                If A1.Value.ToObject().ToString = "Exported_SQL_Parameter_Name" _
                    AndAlso A2.Value.ToObject().ToString = "Exported_SQL_Parameter_ID" _
                    AndAlso A6.Value.ToObject().ToString = "Exported_Commands_from_SQL_Table" Then
                    Me.FileValidity_BarEditItem.EditValue = "Y"
                    'MessageBox.Show("Worksheet is not empty")
                    Exit For
                Else
                    Me.FileValidity_BarEditItem.EditValue = "N"
                End If
            End If

        Next
        If isEmpty Then
            Me.FileValidity_BarEditItem.EditValue = "N"
            'MessageBox.Show("Worksheet is empty")
        End If

    End Sub

    Private Sub SpreadsheetControl1_ActiveSheetChanged(sender As Object, e As ActiveSheetChangedEventArgs) Handles SpreadsheetControl1.ActiveSheetChanged
        Dim sc As SpreadsheetControl = TryCast(sender, SpreadsheetControl)
        Dim existingCells As IEnumerable(Of DevExpress.Spreadsheet.Cell) = sc.Document.Worksheets(e.NewActiveSheetName).GetExistingCells()
        Dim isEmpty As Boolean = True
        For Each cell As DevExpress.Spreadsheet.Cell In existingCells
            If cell.Value IsNot Nothing Then
                isEmpty = False
                Exit For
            End If
        Next
        If isEmpty Then
            MessageBox.Show("Worksheet is empty")
        End If
    End Sub

    Private Sub OpenFile_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OpenFile_bbi.ItemClick

        With OpenFileDialog1
            .Filter = "Excel Files|*.xlsx"
            .FilterIndex = 1
            '.InitialDirectory = SQL_STATEMENT_DIR
            .FileName = ""
            .Title = "Load exported SQL Parameter/Commands Excel File"
            If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If IsNothing(Me.OpenFileDialog1.FileName) = False Then
                    Me.SpreadsheetControl1.LoadDocument(Me.OpenFileDialog1.FileName)
                    Me.FileName_TextEdit.Text = Me.OpenFileDialog1.FileName

                End If
            End If
        End With
    End Sub
End Class
