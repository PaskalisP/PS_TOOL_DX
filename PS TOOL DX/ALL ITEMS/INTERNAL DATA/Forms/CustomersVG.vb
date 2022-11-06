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
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class CustomersVG

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim CrystalRepDir As String = Nothing

    Private BS_National_Identifiers As BindingSource
    Private BS_NACE_Branch_Codes As BindingSource
    Private BS_Instutional_Sector_Codes As BindingSource
    Private BS_Legal_Codes As BindingSource
    Private BS_Legal_Proceedings As BindingSource
    Private BS_Enterprise_Size As BindingSource
    Private BS_All_Customers As BindingSource

    Dim Details_Default_View As String = Nothing
    Dim ClientNrSearch As String = Nothing
    Dim ResidenceCountryEU_Member As String = Nothing



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

    Private Sub CustomersVG_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown


    End Sub

    Private Sub CustomersVG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Customers_Detail_View' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='DEFAULT_FORM_VIEWS' and [IdABTEILUNGSCODE_NAME]='EDP'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Details_Default_View = cmd.ExecuteScalar
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

        Me.CUSTOMER_INFOTableAdapter.FillByClientNr(Me.PSTOOLDataset.CUSTOMER_INFO, GLOBAL_CLIENT_NR)
        Me.GROUP_CLIENT_DETAILSTableAdapter.FillByClientNr(Me.CustomerGroups.GROUP_CLIENT_DETAILS, GLOBAL_CLIENT_NR)
        Me.CUSTOMER_RATING_DETAILSTableAdapter.FillByClientNr(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS, GLOBAL_CLIENT_NR)
        'Load all Contracts
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM [ALL_CONTRACTS_ACCOUNTS] where [ClientNr]='" & GLOBAL_CLIENT_NR & "' order by [ID] desc"
                sqlCmd.Connection = sqlConn
                sqlConn.Open()
                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.GridControl4.DataSource = Nothing
                Me.GridControl4.DataSource = objDataTable
                Me.GridControl4.ForceInitialize()
                sqlConn.Close()
            End Using
        End Using

        'Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)


    End Sub



    Private Sub Customer_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Customer_Print_Export_btn.Click

        If Not VGridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "CUSTOMERS" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CustomerDetailView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs)

    End Sub

    Private Sub CustomerDetailView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs)

    End Sub

    Private Sub BIC_RepositoryItemTextEdit_EditValueChanged(sender As Object, e As EventArgs) 
        'Try
        'CustomerDetailView.PostEditor()
        'Me.Validate()
        'Me.CUSTOMER_INFOBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Catch ex As Exception
        'CustomerDetailView.HideEditor()
        'XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
    End Sub

    Private Sub LEI_RepositoryItemTextEdit_EditValueChanged(sender As Object, e As EventArgs) 
        'Try
        'CustomerDetailView.PostEditor()
        'Me.Validate()
        'Me.CUSTOMER_INFOBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Catch ex As Exception
        'CustomerDetailView.HideEditor()
        'XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
    End Sub

    Private Sub CCB_Group_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) 
        'Try
        'CustomerDetailView.PostEditor()
        'Me.Validate()
        'Me.CUSTOMER_INFOBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Catch ex As Exception
        'CustomerDetailView.HideEditor()
        'XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
    End Sub



End Class