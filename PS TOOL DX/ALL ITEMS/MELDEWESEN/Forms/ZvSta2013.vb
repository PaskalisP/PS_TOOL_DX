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
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class ZvSta2013

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private QueryText1 As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim DATES_ZVSTA As New AccDatesForm

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

    Private Sub ZVSTATill2013BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ZVSTATill2013BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)

    End Sub

    Private Sub ZvSta2013_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'TODO: This line of code loads data into the 'MeldewesenDataSet.ZVSTA_ProdTill2013' table. You can move, or remove it, as needed.
        Me.ZVSTA_ProdTill2013TableAdapter.Fill(Me.MeldewesenDataSet.ZVSTA_ProdTill2013)
        'TODO: This line of code loads data into the 'MeldewesenDataSet.ZVSTA_FormsTill2013' table. You can move, or remove it, as needed.
        Me.ZVSTA_FormsTill2013TableAdapter.Fill(Me.MeldewesenDataSet.ZVSTA_FormsTill2013)
        'TODO: This line of code loads data into the 'MeldewesenDataSet.ZVSTATill2013' table. You can move, or remove it, as needed.
        Me.ZVSTATill2013TableAdapter.Fill(Me.MeldewesenDataSet.ZVSTATill2013)

    End Sub

    Private Sub ZVSTA_Forms_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZVSTA_Forms_BasicView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ZVSTA_Forms_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ZVSTA_Forms_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ZVSTA_Prod_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZVSTA_Prod_BasicView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ZVSTA_Prod_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ZVSTA_Prod_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ZvStatistic_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZvStatistic_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ZvStatistic_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles ZvStatistic_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "ZV STATISTIC" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ZVSTA_Rep_btn_Click(sender As Object, e As EventArgs) Handles ZVSTA_Rep_btn.Click
        Dim dxOK_ZVSTA As New DevExpress.XtraEditors.SimpleButton

        With dxOK_ZVSTA
            .Text = "OK"
            .Height = 23
            .Width = 75
            .ImageList = DATES_ZVSTA.ImageCollection1
            .ImageIndex = 5
            .Location = New System.Drawing.Point(19, 203)
        End With

        DATES_ZVSTA.Controls.Add(dxOK_ZVSTA)
        DATES_ZVSTA.OK_btn.Visible = False
        DATES_ZVSTA.LabelControl1.Visible = True
        DATES_ZVSTA.LabelControl2.Visible = False
        DATES_ZVSTA.LabelControl3.Visible = False
        DATES_ZVSTA.ComboBoxEdit2.Visible = False
        DATES_ZVSTA.ComboBoxEdit3.Visible = False

        AddHandler dxOK_ZVSTA.Click, AddressOf dxOK_ZVSTA_click

        DATES_ZVSTA.Show()
        DATES_ZVSTA.Text = "Creating the Payments Statistic Analysis Report"
        DATES_ZVSTA.LabelControl1.Text = "Please select the Year for the report creation"

        Me.QueryText = "Select [MeldeJahr] from [ZVSTATill2013] ORDER BY [MeldeJahr] desc "
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            DATES_ZVSTA.ComboBoxEdit1.Properties.Items.Add(row("MeldeJahr"))
        Next
        DATES_ZVSTA.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("MeldeJahr")
    End Sub

    Private Sub dxOK_ZVSTA_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MeldeJahr As String = DATES_ZVSTA.ComboBoxEdit1.Text
        DATES_ZVSTA.ComboBoxEdit1.Properties.Items.Clear()
        DATES_ZVSTA.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creation of the Payments Statistic Analysis Report for " & MeldeJahr)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\ZVSTA_Jahresdaten_till2013.rpt")
        CrRep.SetDataSource(MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = MeldeJahr
        myParams.ParameterFieldName = "MeldeJahr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Payments Statistic Analysis Report for " & MeldeJahr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub
End Class