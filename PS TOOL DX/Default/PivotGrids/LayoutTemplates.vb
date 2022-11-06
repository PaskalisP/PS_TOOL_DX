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
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports Ionic.Zip

Public Class LayoutTemplates
    Dim rd As Date = Nothing
    Dim rdsql As String = rd.ToString("yyyyMMdd")

    Dim ReportDay As String = rd.ToString("dd")
    Dim ReportMonth As String = rd.ToString("MM")
    Dim ReportYear As String = rd.ToString("yyyy")

    Dim CurrDate As Date = Now
    Dim CurrDateYear As String = Now.ToString("yy")
    Dim CurrDateMonth As String = Now.ToString("MM")
    Dim CurrDateDay As String = Now.ToString("dd")
    Dim CurrDateHour As String = Now.ToString("HH")
    Dim CurrDateMinute As String = Now.ToString("mm")
    Dim CurrDateSecond As String = Now.ToString("ss")


    Dim Abacus930XmlFileName As String = Nothing
    Dim Abacus907XmlFileName As String = Nothing
    Dim Abacus966XmlFileName As String = Nothing

    Dim MyWriter As System.Xml.XmlWriter
    Dim MySettings As New System.Xml.XmlWriterSettings

    Private BS_All_BusinessDates As BindingSource



    Public Sub LayoutTemplates_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub



    Private Sub Files_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles Files_GridView.RowClick
        Me.FileName_TextEdit.EditValue = Files_GridView.GetFocusedRowCellValue(colFilename)
        Me.FileFullPath_TextEdit.EditValue = Files_GridView.GetFocusedRowCellValue(colFilepath)
    End Sub

    Private Sub Files_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles Files_GridView.RowCellClick
        Me.FileName_TextEdit.EditValue = Files_GridView.GetFocusedRowCellValue(colFilename)
        Me.FileFullPath_TextEdit.EditValue = Files_GridView.GetFocusedRowCellValue(colFilepath)
    End Sub

    Private Sub Files_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles Files_GridView.FocusedRowChanged
        Me.FileName_TextEdit.EditValue = Files_GridView.GetFocusedRowCellValue(colFilename)
        Me.FileFullPath_TextEdit.EditValue = Files_GridView.GetFocusedRowCellValue(colFilepath)
    End Sub
End Class
