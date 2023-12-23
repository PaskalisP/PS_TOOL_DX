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
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.Spreadsheet

Public Class UpdateSqlScriptFromXML


    Dim ViewLabelName As String = Nothing
    'Inherits EditFormUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Size = New Size(1200, 600)
        ' Add any initialization after the InitializeComponent() call.
        'Me.SetBoundFieldName(MemoEdit1, "ValidityError_Describe")
    End Sub

    Private Sub OpenFile_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OpenFile_bbi.ItemClick

        With OpenFileDialog1
            .Filter = "XML Files|*.xml"
            .FilterIndex = 1
            '.InitialDirectory = SQL_STATEMENT_DIR
            .FileName = ""
            .Title = "Load exported Parameter/Commands XML File"
            If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If IsNothing(Me.OpenFileDialog1.FileName) = False Then
                    'Me.SpreadsheetControl1.LoadDocument(Me.OpenFileDialog1.FileName)
                    Me.FileName_TextEdit.Text = Me.OpenFileDialog1.FileName
                    Dim xmlFilePath As String = Me.OpenFileDialog1.FileName

                    Try
                        XmlSqlDataSet.Clear()
                        XmlSqlDataSet.ReadXml(Me.OpenFileDialog1.FileName)
                        ' Assuming the XML file contains multiple tables (if not, it will create a single table)
                        ' Accessing the first table in the DataSet

                        Dim tableIndex As Integer = 0 ' Change this index to access other tables if present
                        If XmlSqlDataSet.Tables.Count > tableIndex Then
                            'MsgBox(XmlSqlDataSet.Tables.Count.ToString)
                            XmlSqlDataTable = XmlSqlDataSet.Tables(tableIndex)
                            GridControl1.DataSource = XmlSqlDataTable
                            Me.XmlSql_GridView.BeginUpdate()
                            Try
                                Dim dataRowCount As Integer = Me.XmlSql_GridView.DataRowCount
                                Dim rHandle As Integer
                                For rHandle = 0 To dataRowCount - 1
                                    Me.XmlSql_GridView.SetMasterRowExpanded(rHandle, True)
                                Next
                            Finally
                                Me.XmlSql_GridView.EndUpdate()
                            End Try
                            Me.XmlSql_GridView.BestFitColumns()
                            'Check XML Validity
                            If XmlSqlDataTable.Columns.Contains("CURRENT_TABLE") AndAlso XmlSqlDataTable.Columns.Contains("UNDERLYING_TABLE") AndAlso ViewLabelName = "document_UnderlyingTable" Then
                                Me.FileValidity_BarEditItem.EditValue = "Y"
                            End If
                        End If


                    Catch ex As Exception
                        XtraMessageBox.Show("Error reading XML: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End Try



                End If
            End If
        End With
    End Sub

    Private Sub XmlSql_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles XmlSql_GridView.MasterRowExpanded
        Dim view As GridView = TryCast(XmlSql_GridView.GetDetailView(e.RowHandle, e.RelationIndex), GridView)
        ViewLabelName = view.LevelName.ToString
    End Sub
End Class
