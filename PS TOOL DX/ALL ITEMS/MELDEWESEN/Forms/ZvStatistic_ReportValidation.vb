Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
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
Public Class ZvStatistic_ReportValidation
    Friend WithEvents BgwZVSTA_Validating As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Private BS_ZVSTA_Rep_DataCheck As BindingSource

    Dim CurrentZVSTA_Report As String = Nothing




    Public Sub ZvStatistic_ReportValidation_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never

        OpenSqlConnections()
        Dim ZVSTA_Reporting_Check_Da As New SqlDataAdapter("SELECT * from [ZVSTAT_ReportingValidityCheck] where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' order by Validity_ID desc", conn)
        Dim ZVSTA_Reporting_Check_Dataset As New DataSet("ZVSTAT_ReportingValidityCheck")
        ZVSTA_Reporting_Check_Da.Fill(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")
        BS_ZVSTA_Rep_DataCheck = New BindingSource(ZVSTA_Reporting_Check_Dataset, "ZVSTAT_ReportingValidityCheck")

        Me.GridControl3.DataSource = BS_ZVSTA_Rep_DataCheck
        Me.GridControl3.Update()
        CloseSqlConnections()

    End Sub


End Class
