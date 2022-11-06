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
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class OdasRemmitances

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date
    Dim FDateSql As String = Nothing
    Dim LDateSql As String = Nothing

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

    Private Sub ODAS_REMMITANCESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ODAS_REMMITANCESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClearingDataSet)

    End Sub

    Private Sub OdasRemmitances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.CommandText = "Select Max(TRANSACTIONDATE) from [ODAS REMMITANCES]"
        Dim d As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************
        Me.PaymentFromDateEdit.Text = d
        Me.PaymentTillDateEdit.Text = d

        'Gridcontrol2 - CUSTOMERS
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = ODASBaseView
        ODASBaseView.ForceDoubleClick = True
        AddHandler ODASBaseView.DoubleClick, AddressOf ODASBaseView_DoubleClick
        AddHandler ODASDetailView.MouseDown, AddressOf ODASDetailView_MouseDown
        AddHandler ViewEdit_btn.Click, AddressOf ViewEdit_btn_Click
        ODASDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        ODASDetailView.OptionsBehavior.AllowSwitchViewModes = False
    

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

    End Sub

#Region "ODAS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)

        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = ODASDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = ODASBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        ViewEdit_btn.Text = strShowExtendedMode
        ViewEdit_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is ODASDetailView)


        '****************************************
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = ODASBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = ODASDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        ViewEdit_btn.Text = strHideExtendedMode
        ViewEdit_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is ODASDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = ODASBaseView.GetRowHandle(dataSourceRowIndex)
        ODASBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = ODASDetailView.GetRowHandle(dataSourceRowIndex)
        ODASDetailView.VisibleRecordIndex = ODASDetailView.GetVisibleIndex(rowHandle)
        ODASDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub ODASBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = ODASBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub ODASDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = ODASDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub ViewEdit_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub LoadPaymentsData_btn_Click(sender As Object, e As EventArgs) Handles LoadPaymentsData_btn.Click
        If IsDate(Me.PaymentFromDateEdit.Text) = True AndAlso IsDate(Me.PaymentTillDateEdit.Text) = True Then
            FDate = Me.PaymentFromDateEdit.Text
            LDate = Me.PaymentTillDateEdit.Text
            If LDate >= FDate Then
                Dim FDateSql As String = FDate.ToString("yyyyMMdd")
                Dim LDateSql As String = LDate.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load ODAS Remmitances from " & FDate & " till " & LDate)

                'Dim objCMD As SqlCommand = New SqlCommand("execute [ODAS_REM_FILL]  @FROMDATE='" & FDateSql & "', @TILLDATE='" & LDateSql & "'  ", conn)
                'objCMD.CommandTimeout = 5000
                'da = New SqlDataAdapter(objCMD)
                'dt = New DataTable()
                'da.Fill(dt)
                'Results
                'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                'Me.GridControl2.DataSource = Nothing
                'Me.GridControl2.DataSource = dt
                'Me.GridControl2.ForceInitialize()
                'Else
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'Exit Sub
                'End If

                'Data reader
                Try
                    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using sqlCmd As New SqlCommand()
                            sqlCmd.CommandText = "SELECT * FROM [ODAS REMMITANCES] where [TRANSACTIONDATE]>='" & FDateSql & "' and [TRANSACTIONDATE]<='" & LDateSql & "'"
                            sqlCmd.Connection = sqlConn
                            If sqlConn.State = ConnectionState.Closed Then
                                sqlConn.Open()
                            End If

                            Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                            Dim objDataTable As New DataTable()
                            objDataTable.Load(objDataReader)
                            If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                                Me.GridControl2.DataSource = Nothing
                                Me.GridControl2.DataSource = objDataTable
                                Me.GridControl2.ForceInitialize()

                            Else
                                SplashScreenManager.CloseForm(False)
                                MessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Return
                            End If
                            If sqlConn.State = ConnectionState.Open Then
                                sqlConn.Close()
                            End If

                        End Using
                    End Using
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
                SplashScreenManager.CloseForm(False)
            Else
                MessageBox.Show("Date From is higher than Date Till", "WRONG DATE INPUT", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ODASBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ODASBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ODASBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ODASBaseView.ShownEditor
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
        If ViewEdit_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.ODASDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.ODASDetailView.OptionsPrint.PrintCardCaption = True
            Me.ODASDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.ODASDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.ODASDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If
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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "ODAS REMMITANCES" & vbNewLine & "Printed on: " & Now
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
End Class