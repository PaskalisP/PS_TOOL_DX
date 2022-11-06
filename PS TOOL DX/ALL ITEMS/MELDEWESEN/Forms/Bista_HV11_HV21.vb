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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Public Class Bista_HV11_HV21

    Dim CrystalRepDir As String = ""

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim ActivaSum As Double = 0
    Dim TotalActivaSum As Double = 0
    Dim AktivaSumVorjahr As Double = 0

    Dim PassivaSum As Double = 0
    Dim TotalPassivaSum As Double = 0
    Dim PassivaSumVorjahr As Double = 0

    Dim BilanzDifferenz As Double = 0

    Dim CheckField As String = Nothing


    Dim ActivaDetailViewCaption As String = Nothing
    Dim PassivaDetailsViewCaption As String = Nothing

    Dim d As Date
    Dim dsql As String = Nothing


    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing
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

    Private Sub BISTA_TOTALS_ACTIVABindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BISTA_TOTALS_ACTIVABindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BISTA_DataSet)

    End Sub

    Private Sub Bista_HV11_HV21_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.BistaDate_ComboEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[BSDate],104) as 'RLDC Date' from [DailyBalanceSheets] GROUP BY [BSDate] ORDER BY [BSDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BistaDate_ComboEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
       
       

    End Sub

#Region "GRIDVIEWS STYLES"

    Private Sub ActivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaBaseView.RowStyle

        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            Dim BILANZPOSITION_ART As String = ActivaBaseView.GetRowCellValue(e.RowHandle, colBistaPositionArt)
            If BILANZPOSITION_ART = "HV11" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ActivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ActivaBaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "BISTA details für position: " & view.GetFocusedRowCellValue("BistaPositionName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ActivaBaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "BISTA details für position: " & view.GetFocusedRowCellValue("BistaPositionName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles ActivaBaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva details für position: " & view.GetFocusedRowCellValue("BistaPositionName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaBaseView.RowStyle
        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            Dim BILANZPOSITION_ART As String = PassivaBaseView.GetRowCellValue(e.RowHandle, colBistaPositionArt)
            If BILANZPOSITION_ART = "HV21" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PassivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles PassivaBaseView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "BISTA details für Bilanzposition: " & view.GetFocusedRowCellValue("BistaPositionName").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles PassivaBaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details für Bilanzposition: " & view.GetFocusedRowCellValue("BistaPositionName").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles PassivaBaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details für Bilanzposition: " & view.GetFocusedRowCellValue("BistaPositionName").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub


    Private Sub ActivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ActivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PassivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PassivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Bista_Activa_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Bista_Activa_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Bista_Activa_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Bista_Activa_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Bista_Passiva_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Bista_Passiva_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Bista_Passiva_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Bista_Passiva_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
#End Region

#Region "GRIDVIEWS PRINT EXPORT"

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        ' Create objects and define event handlers.
        Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
        AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
        Dim pcLink1 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink2 As PrintableComponentLink = New PrintableComponentLink()
        Dim linkMainReport As Link = New Link()
        AddHandler linkMainReport.CreateDetailArea, AddressOf linkMainReport_CreateDetailArea
        Dim linkGrid1Report As Link = New Link()
        AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
        Dim linkGrid2Report As Link = New Link()
        AddHandler linkGrid2Report.CreateDetailArea, AddressOf linkGrid2Report_CreateDetailArea

        ' Assign the controls to the printing links.
        pcLink1.Component = Me.GridControl2
        pcLink2.Component = Me.GridControl1

        ' Populate the collection of links in the composite link.
        ' The order of operations corresponds to the document structure.
        composLink.Links.Add(linkGrid1Report)
        composLink.Links.Add(pcLink1)
        composLink.Links.Add(linkMainReport)
        composLink.Links.Add(linkGrid2Report)
        composLink.Links.Add(pcLink2)

        composLink.Landscape = True
        composLink.PaperKind = System.Drawing.Printing.PaperKind.A4

        ' Create the report and show the preview window.
        composLink.ShowPreviewDialog()
    End Sub

    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim reportfooter As String = "BILANZSTATISTIK" & "  " & "für den " & Me.BistaDate_ComboEdit.Text & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "BISTA - AKTIVA"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates an interval between the grids and fills it with color.
    Private Sub linkMainReport_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Rect = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        tb.BackColor = Color.Gray
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates a text header for the second grid.
    Private Sub linkGrid2Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "BISTA - PASSIVA"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub Print_Export_Activa_Details_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Activa_Details_btn.Click
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
        Dim reportfooter As String = "BISTA - Aktiiva (Alle Details) " & "   " & "am : " & Me.BistaDate_ComboEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_Passiva_Details_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Passiva_Details_btn.Click
        If Not GridControl4.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "BISTA - Passiva (Alle Details) " & "   " & "am : " & Me.BistaDate_ComboEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
#End Region

    Private Sub BistaDate_ComboEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles BistaDate_ComboEdit.KeyDown
        If IsDate(Me.BistaDate_ComboEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
        End If
    End Sub

    Private Sub BistaDate_ComboEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BistaDate_ComboEdit.SelectedIndexChanged

        Me.GridControl1.DataSource = Me.BISTA_TOTALS_PASSIVABindingSource
        Me.GridControl2.DataSource = Me.BISTA_TOTALS_ACTIVABindingSource
        Me.GridControl3.DataSource = Me.BISTA_Activa_DetailsBindingSource
        Me.GridControl4.DataSource = Me.BISTA_Passiva_DetailsBindingSource

        If IsDate(Me.BistaDate_ComboEdit.Text) = True Then

            rd = Me.BistaDate_ComboEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Select [RiskDate] from [BISTA_TOTALS] where [RiskDate]='" & rdsql & "' "
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [dbo].[BISTA_TOTALS]([BistaPositionNr],[BistaPositionName],[BistaPosition_ID],[BistaPositionArt],[RiskDate])Select SQL_Name_1,SQL_Name_2,SQL_Float_1,SQL_Name_3,'" & rdsql & "' from SQL_PARAMETER_DETAILS where Id_SQL_Parameters='BISTA_HV11_HV21' order by SQL_Float_1 asc"
                cmd.ExecuteNonQuery()

                Me.BISTA_Passiva_Details_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Passiva_Details, rd)
                Me.BISTA_Activa_Details_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Activa_Details, rd)
                Me.BISTA_DetailsTableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Details, rd)
                Me.BISTA_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_TOTALS_PASSIVA, rd)
                Me.BISTA_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_TOTALS_ACTIVA, rd)
            Else
                Me.BISTA_Passiva_Details_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Passiva_Details, rd)
                Me.BISTA_Activa_Details_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Activa_Details, rd)
                Me.BISTA_DetailsTableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Details, rd)
                Me.BISTA_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_TOTALS_PASSIVA, rd)
                Me.BISTA_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_TOTALS_ACTIVA, rd)
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If
    End Sub

    Private Sub BistaCalculate_btn_Click(sender As Object, e As EventArgs) Handles BistaCalculate_btn.Click
        Try
            If IsDate(Me.BistaDate_ComboEdit.Text) = True Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Calculate BISTA for Business Date: " & rd)

                rd = Me.BistaDate_ComboEdit.Text
                rdsql = rd.ToString("yyyyMMdd")
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "DELETE from [BISTA_TOTALS] where [RiskDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [BISTA_Details] where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [DailyBalanceDetailsSheets] SET [BISTA_Sign]=NULL,[BISTA_Pos_Sign]=NULL where [BSDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [dbo].[BISTA_TOTALS]([BistaPositionNr],[BistaPositionName],[BistaPosition_ID],[BistaPositionArt],[RiskDate])Select SQL_Name_1,SQL_Name_2,SQL_Float_1,SQL_Name_3,'" & rdsql & "' from SQL_PARAMETER_DETAILS where Id_SQL_Parameters='BISTA_HV11_HV21' order by SQL_Float_1 asc"
                cmd.ExecuteNonQuery()

                'Calculate Activa
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('BISTA_HV11_HV21') and [SQL_Float_1]<37 and [SQL_Float_1] not in (31,37) order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_1")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_1") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_2")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_2") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'cmd.CommandText = "UPDATE A set A.[BISTA_Sign]='HV11' from [DailyBalanceDetailsSheets] A INNER JOIN [BISTA_Details] B on A.[BSDate]=B.[BSDate] and A.[GL_Item]=B.[GL_Item]  where A.[BISTA_Sign] is NULL and A.[GL_Art] in ('Activa') and A.[BSDate]='" & rdsql & "' "
                'cmd.ExecuteNonQuery()

                'Calculate übrige Activa
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('BISTA_HV11_HV21') and [SQL_Float_1] in (31,37) order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_1")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_1") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_2")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_2") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                Next

                'Calculate Passiva
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('BISTA_HV11_HV21') and [SQL_Float_1]>38 and [SQL_Float_1]<69 and [SQL_Float_1] not in (62,68)  order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_1")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_1") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_2")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_2") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'cmd.CommandText = "UPDATE A set A.[BISTA_Sign]='HV21' from [DailyBalanceDetailsSheets] A INNER JOIN [BISTA_Details] B on A.[BSDate]=B.[BSDate] and A.[GL_Item]=B.[GL_Item]  where A.[BISTA_Sign] is NULL and A.[GL_Art] in ('Passiva') and A.[BSDate]='" & rdsql & "' "
                'cmd.ExecuteNonQuery()
                'Calculate Sonstige und übrige Passiva
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('BISTA_HV11_HV21') and [SQL_Float_1] in (62,68)  order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_1")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_1") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_2")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_2") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                Next

                'Update Sums in Hauptpositions ACTIVA - PASSIVA
                cmd.CommandText = "UPDATE A SET A.[BistaAmountPosition_HP]=B.S from [BISTA_TOTALS] A INNER JOIN  (SELECT [IdBISTA_TOTALS],ABS(Round(Sum([Total_Balance]/1000),0))  as S FROM [BISTA_Details] GROUP BY [IdBISTA_TOTALS])B on A.[ID]=B.[IdBISTA_TOTALS]  WHERE A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Update SUM ACTIVA and PASSIVA
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('BISTA_HV11_HV21') and [SQL_Name_3] in ('HV11_SUM_ACTIVA','HV21_SUM_PASSIVA')  order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_1")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_1") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                Next

                'Calculate Sonstige 
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('BISTA_HV11_HV21') and [SQL_Float_1]>69  order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_1")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_1") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("SQL_Command_2")) = False AndAlso dt.Rows.Item(i).Item("SQL_Command_2") <> "" Then
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'Update Sums in Hauptpositions SONSTIGE
                cmd.CommandText = "UPDATE A SET A.[BistaAmountPosition_HP]=B.S from [BISTA_TOTALS] A INNER JOIN  (SELECT [IdBISTA_TOTALS],ABS(Round(Sum([Total_Balance]/1000),0))  as S FROM [BISTA_Details] GROUP BY [IdBISTA_TOTALS])B on A.[ID]=B.[IdBISTA_TOTALS]  WHERE A.[RiskDate]='" & rdsql & "' and A.[BistaPosition_ID]>69"
                cmd.ExecuteNonQuery()

                'Update Client Type, Client Name and Business Type
                cmd.CommandText = "Update A set A.[ClientType]=C.ClientType,A.ClientName=C.[English Name],A.BusinessType=B.BusinessTypeName from [BISTA_Details] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B on A.ReleatedAccountNr=B.[Contract Collateral ID] INNER JOIN CUSTOMER_INFO C on B.[Client No]=C.ClientNo where A.ReleatedAccountNr is not NULL and A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update A set A.[ClientType]=C.ClientType,A.ClientName=C.[English Name],A.BusinessType=B.BusinessTypeName from [BISTA_Details] A INNER JOIN [BusinessTypesLiabilitiesDetails] B on A.ReleatedAccountNr=B.[Contract Collateral ID] INNER JOIN CUSTOMER_INFO C on B.[Client No]=C.ClientNo where A.ReleatedAccountNr is not NULL and A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BISTA_Passiva_Details_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Passiva_Details, rd)
                Me.BISTA_Activa_Details_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Activa_Details, rd)
                Me.BISTA_DetailsTableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_Details, rd)
                Me.BISTA_TOTALS_PASSIVA_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_TOTALS_PASSIVA, rd)
                Me.BISTA_TOTALS_ACTIVA_TableAdapter.FillByRiskDate(Me.BISTA_DataSet.BISTA_TOTALS_ACTIVA, rd)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub
End Class