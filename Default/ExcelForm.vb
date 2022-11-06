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
Public Class ExcelForm

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim ExcelFileName As String = Nothing
    Private BS_BusinessDates As BindingSource

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim d As Date
    Dim workbook As IWorkbook
    Dim SqlCommandText As String = Nothing

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

    Private Sub ExcelForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

       
    End Sub

    Private Sub SaveAsNew_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SaveAsNew.ItemClick
        Using myFileDialog As New SaveFileDialog()
            myFileDialog.Filter = "Excel File (*.xlsx)|.xlsx" '"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            myFileDialog.FilterIndex = 1
            myFileDialog.InitialDirectory = "C:\"
            myFileDialog.CheckFileExists = False
            myFileDialog.RestoreDirectory = False

            Dim result As DialogResult = myFileDialog.ShowDialog
            'Dim workbook As New Workbook()

            If result = DialogResult.OK Then

                'workbook.SaveDocument(myFileDialog.FileName, DocumentFormat.OpenXml)
                Me.SpreadsheetControl1.Document.SaveDocument(myFileDialog.FileName, DocumentFormat.OpenXml)

            End If
        End Using
    End Sub
End Class