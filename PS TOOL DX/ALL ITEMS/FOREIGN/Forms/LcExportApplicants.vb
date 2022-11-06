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
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.Data

Public Class LcExportApplicants

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private BS_All_Customers As BindingSource

    Dim CrystalRepDir As String = ""

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


    Private Sub LcExportApplicants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)

    End Sub

    Private Sub LcExportApplicants_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Applicant Data...")
            Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.ApplicantAddresses_GridView.ShowEditForm))
        End If


        If e.Button.Tag = "DeleteData" Then
            If ApplicantAddresses_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Applicant Data be deleted? ", "DELETE APPLICANT DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Applicant Data...")
                        Me.ApplicantAddresses_GridView.DeleteRow(ApplicantAddresses_GridView.FocusedRowHandle)
                        Me.TableAdapterManager.UpdateAll(Me.LcDataset)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If
    End Sub


    Private Sub Save_SimpleButton_Click(sender As Object, e As EventArgs)
        If Me.DxValidationProvider1.Validate() = True Then
            Try
                Me.Validate()
                Me.EXPORT_LC_CUSTOMERSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.LcDataset)
                Me.LayoutControl1.Visible = True
                Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            MessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub



    Private Sub Print_Export_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridView_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
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
        Dim reportfooter As String = "FOREIGN BANKS AND COMPANIES"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



    Private Sub ApplicantAddresses_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ApplicantAddresses_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ApplicantAddresses_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ApplicantAddresses_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ApplicantAddresses_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ApplicantAddresses_GridView.RowUpdated
        Try
            Me.Validate()
            Me.EXPORTLCMT700ApplNameAddressBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.LcDataset)
            Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ApplicantAddresses_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ApplicantAddresses_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim NAME_TYPE As GridColumn = View.Columns("NameType")
        Dim APPL_NAME As GridColumn = View.Columns("Name")
        Dim APPL_ADDRESS As GridColumn = View.Columns("Address")
        Dim APPL_ZIP_CITY As GridColumn = View.Columns("ZipCode_City")
        Dim APPL_COUNTRY_NAME As GridColumn = View.Columns("CountryName")

        Dim NameType As String = View.GetRowCellValue(e.RowHandle, colNameType1).ToString
        Dim ApplName As String = View.GetRowCellValue(e.RowHandle, colName1).ToString
        Dim ApplAddress As String = View.GetRowCellValue(e.RowHandle, colAddress1).ToString
        Dim ApplZipCity As String = View.GetRowCellValue(e.RowHandle, colZipCode_City1).ToString
        Dim ApplCountryName As String = View.GetRowCellValue(e.RowHandle, colCountryName1).ToString

        If NameType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(NAME_TYPE, "The Name Type must not be empty")
            e.ErrorText = "The Name Type must not be empty"
        End If
        If ApplName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_NAME, "The Name must not be empty")
            e.ErrorText = "The Name must not be empty"
        End If
        If ApplAddress = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ADDRESS, "The Address must not be empty")
            e.ErrorText = "The Address must not be empty"
        End If
        If ApplZipCity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ZIP_CITY, "The Postal Code/ City must not be empty")
            e.ErrorText = "The Postal Code/ City must not be empty"
        End If
        If ApplCountryName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_COUNTRY_NAME, "The Country Name must not be empty")
            e.ErrorText = "The Country Name must not be empty"
        End If
    End Sub

    Private Sub ApplicantAddresses_GridView_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles ApplicantAddresses_GridView.RowDeleted
        Try
            Me.Validate()
            Me.EXPORTLCMT700ApplNameAddressBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.LcDataset)
            Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


End Class