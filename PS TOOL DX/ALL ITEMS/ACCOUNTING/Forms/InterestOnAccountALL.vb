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
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraLayout

Public Class InterestOnAccountALL
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = Nothing
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New DataTable

    Dim SqlCommandText As String = Nothing

    Dim ds As New SqlDataSource
    Dim query As New CustomSqlQuery()

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim PrintGrid As Double = 0

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

    Private Sub KUNDEN_INTEREST_ON_ACBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.KUNDEN_INTEREST_ON_ACBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub InterestOnAccountALL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''TODO: This line of code loads data into the 'AccountingDataSet.KUNDEN_INTEREST_ON_AC' table. You can move, or remove it, as needed.
        'Me.KUNDEN_INTEREST_ON_ACTableAdapter.Fill(Me.AccountingDataSet.KUNDEN_INTEREST_ON_AC)

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Bind Combobox
        Me.BusinessTypeDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[DateMakCrTotals],104) as 'RLDC Date' from [BusinessTypesLiabilitiesLive] GROUP BY [DateMakCrTotals] Order by [DateMakCrTotals] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BusinessTypeDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BusinessTypeDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        'Get 
        rd = Me.BusinessTypeDateEdit.Text
        rdsql = rd.ToString("yyyyMMdd")

        FILL_PWB_VALUE_ADJUSTMENTS_DATATABLE()
        FILL_EWB_VALUE_ADJUSTMENTS_DATATABLE()


    End Sub

    Private Sub FILL_EWB_VALUE_ADJUSTMENTS_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM [ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST] order by [ID] asc"
        ds.Queries.Add(query)
        ds.Fill()
        'Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.ForceInitialize()
    End Sub

    Private Sub FILL_PWB_VALUE_ADJUSTMENTS_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM [BusinessTypesCreditPortfolioDetails] where RiskDate='" & rdsql & "'"
        ds.Queries.Add(query)
        ds.Fill()
        'Me.GridControl2.DataSource = Nothing
        Me.GridControl2.DataSource = ds
        Me.GridControl2.DataMember = "customQuery1"
        Me.GridControl2.ForceInitialize()
    End Sub

    Private Sub BusinessTypeDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessTypeDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                rd = Me.BusinessTypeDateEdit.Text
                rdsql = rd.ToString("yyyyMMdd")

                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Business Types for " & rd)
                FILL_PWB_VALUE_ADJUSTMENTS_DATATABLE()
                SplashScreenManager.CloseForm(False)

            End If
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_Click(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            'Me.GridControl2.DataSource = Nothing
        End If
    End Sub


    Private Sub BusinessTypeDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles BusinessTypeDateEdit.KeyDown
        'If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
        '    Me.GridControl2.DataSource = Nothing
        '    If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

        '        rd = Me.BusinessTypeDateEdit.Text
        '        rdsql = rd.ToString("yyyyMMdd")

        '        'Load BusinessTypes Data
        '        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        '        SplashScreenManager.Default.SetWaitFormCaption("Load Business Types for " & rd)
        '        FILL_PWB_VALUE_ADJUSTMENTS_DATATABLE()
        '        SplashScreenManager.CloseForm(False)

        '    End If
        'End If
    End Sub

    Private Sub InterestOnAccountAll_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles InterestOnAccountAll_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub InterestOnAccountAll_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles InterestOnAccountAll_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PWB_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PWB_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PWB_GridView_ShownEditor(sender As Object, e As EventArgs) Handles PWB_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_InterestALL_BasicView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_InterestALL_BasicView_btn.Click
        If PrintGrid = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

        If PrintGrid = 1 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

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
        Dim reportfooter As String = "EINZELWERTBERICHTIGUNGEN - INDIVIDUAL VALUE ADJUSTMENTS "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "PAUSCHALWERTBERICHTIGUNGEN - GENERAL VALUE ADJUSTMENTS ON  " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BusinessTypeDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.EditValueChanged
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            'Me.GridControl2.DataSource = Nothing
            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                rd = Me.BusinessTypeDateEdit.Text
                rdsql = rd.ToString("yyyyMMdd")

                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Business Types for " & rd)
                FILL_PWB_VALUE_ADJUSTMENTS_DATATABLE()
                SplashScreenManager.CloseForm(False)

            End If
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "General Value Adjustments (PWB)" Then
            PrintGrid = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Individual Value Adjustments (EWB)" Then
            PrintGrid = 1
        End If
    End Sub
End Class