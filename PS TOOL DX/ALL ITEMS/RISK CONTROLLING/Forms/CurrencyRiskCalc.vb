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
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Public Class CurrencyRiskCalc

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim SqlCommandText As String = Nothing
    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim CR_DetailsViewCaption As String = Nothing

   

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

    Private Sub CurrencyRisk_DateBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CurrencyRisk_DateBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CurrencyRiskCalcDataSet)

    End Sub

    Private Sub CurrencyRiskCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()


        'Bind Combobox
        Me.CR_DateEdit_ComboEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[CR_Date],104) as 'RLDC Date' from [CurrencyRisk_Date] ORDER BY [CR_Date] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.CR_DateEdit_ComboEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.CR_DateEdit_ComboEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        rd = Me.CR_DateEdit_ComboEdit.Text
        Me.CurrencyRisk_PositionsAllDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsAllDetails, rd)
        Me.CurrencyRisk_PositionsDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsDetails, rd)
        Me.CurrencyRisk_PositionsTotalsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals, rd)
        Me.CurrencyRisk_DateTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_Date, rd)



        'rd = DateSerial(Microsoft.VisualBasic.Right(Me.CR_DateEdit_ComboEdit.Text, 4), Mid(Me.CAR_DateEdit_ComboEdit.Text, 4, 2), Microsoft.VisualBasic.Left(Me.CAR_DateEdit_ComboEdit.Text, 2))
        'rdsql = rd.ToString("yyyyMMdd")

        'Me.CurrencyRisk_PositionsAllDetailsTableAdapter.Fill(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsAllDetails)
        'Me.CurrencyRisk_PositionsDetailsTableAdapter.Fill(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsDetails)
        'Me.CurrencyRisk_PositionsTotalsTableAdapter.Fill(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals)
        'Me.CurrencyRisk_DateTableAdapter.Fill(Me.CurrencyRiskCalcDataSet.CurrencyRisk_Date)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CurrencyRisk_PositionsTotalsBindingSource.EndEdit()
                If Me.CurrencyRiskCalcDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.CurrencyRiskCalcDataSet)
                        Me.CurrencyRisk_PositionsTotalsTableAdapter.Fill(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub LoadBusinessTypes_btn_Click(sender As Object, e As EventArgs) Handles LoadBusinessTypes_btn.Click

    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick
        Try
            rd = DateSerial(Microsoft.VisualBasic.Right(Me.CurrencyRiskDate_lbl.Text, 4), Mid(Me.CurrencyRiskDate_lbl.Text, 4, 2), Microsoft.VisualBasic.Left(Me.CurrencyRiskDate_lbl.Text, 2))
            rdsql = rd.ToString("yyyyMMdd")

            If MessageBox.Show("Should the Currency Risk calculation for " & rd & " be executed again?", "CURRENCY RISK CALCULATION based on FINRECON", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Commands:PS TOOL CLIENT PROCEDURES/CURRENCY_RISK_CALCULATION for " & rd)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandTimeout = 50000

                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CURRENCY_RISK_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Threading.Thread.Sleep(500)
                        SplashScreenManager.Default.SetWaitFormCaption("Execute Currency Risk calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

                SplashScreenManager.CloseForm(False)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.CurrencyRisk_PositionsAllDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsAllDetails, rd)
                Me.CurrencyRisk_PositionsDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsDetails, rd)
                Me.CurrencyRisk_PositionsTotalsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals, rd)
                Me.CurrencyRisk_DateTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_Date, rd)
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

    

    Private Sub Print_Export_CRSA_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_CRSA_Totals_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
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
        Dim reportfooter As String = "Currency Risk Positions " & "  " & "on: " & rd
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_All_DetailsAll_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_All_DetailsAll_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
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
        Dim reportfooter As String = "Currency Risk (All Details)" & "  " & "on: " & rd
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CR_Totals_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles CR_Totals_GridView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "CR_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            CR_DetailsViewCaption = "Currency Risk details for: " & view.GetFocusedRowCellValue("CR_CURRENCY").ToString
            Me.CR_Details_GridView.ViewCaption = CR_DetailsViewCaption
        End If
    End Sub

    Private Sub CR_Totals_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles CR_Totals_GridView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "CR_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            CR_DetailsViewCaption = "Currency Risk details for: " & view.GetFocusedRowCellValue("CR_CURRENCY").ToString
            Me.CR_Details_GridView.ViewCaption = CR_DetailsViewCaption
        End If
    End Sub

    Private Sub CR_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CR_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CR_Details_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles CR_Details_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

   

    Private Sub CR_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CR_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CR_DetailsAll_Gridview_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles CR_DetailsAll_Gridview.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub CR_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CR_DetailsAll_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CR_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CR_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CR_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CR_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CR_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles CR_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CurRisk_Calc_Report_btn_Click(sender As Object, e As EventArgs) Handles CurRisk_Calc_Report_btn.Click
        If IsDate(Me.CurrencyRiskDate_lbl.Text) = True Then
            Dim d As Date = Me.CurrencyRiskDate_lbl.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Currency Risk calculation REPORT for " & Me.CurrencyRiskDate_lbl.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\CurrencyRiskCalculation.rpt")
            'Dim r As New INT_RATE_RISK_REP
            CrRep.SetDataSource(CurrencyRiskCalcDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Currency Risk Calculation report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(75)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub CR_DateEdit_ComboEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CR_DateEdit_ComboEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            If IsDate(Me.CR_DateEdit_ComboEdit.Text) = True Then

                rd = Me.CR_DateEdit_ComboEdit.Text
                rdsql = rd.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Currency Risk for " & rd)
                'If cmd.Connection.State = ConnectionState.Closed Then
                'cmd.Connection.Open()
                'End If

                'cmd.CommandText = "Select [CR_Date] from [CurrencyRisk_Date] where [CR_Date]='" & rdsql & "' "
                'Dim t As String = cmd.ExecuteScalar
                'If IsNothing(t) = True Then
                'cmd.CommandText = "INSERT INTO [CurrencyRisk_Date]([CR_Date]) Values ('" & rdsql & "')"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "INSERT INTO [CurrencyRisk_PositionsTotals]([CR_Position_Date],[CR_CURRENCY],[CR_Sql_Command],[CR_Sql_Command1]) SELECT '" & rdsql & "',[SQL_Name_1],[SQL_Command_1],[SQL_Command_2] FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='CURRENCY RISK CALCULATION'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE A SET A.[IdCurrencyRiskDate]=B.[ID] from [CurrencyRisk_PositionsTotals] A INNER JOIN [CurrencyRisk_Date] B ON A.[CR_Position_Date]=B.[CR_Date] where A.[CR_Position_Date]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [CurrencyRisk_PositionsTotals] SET [CR_Sql_Command]= REPLACE([CR_Sql_Command],'<RiskDate>','" & rdsql & "'),[CR_Sql_Command1]= REPLACE([CR_Sql_Command1],'<RiskDate>','" & rdsql & "') where [CR_Position_Date]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [CurrencyRisk_Date] set [RiskCapitalCharge]=(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='Currency Risk Calculation Percent' and [IdABTEILUNGSPARAMETER]='CURRENCY_RISK_PERCENT')  where [CR_Date]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()

                Me.CurrencyRisk_PositionsAllDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsAllDetails, rd)
                Me.CurrencyRisk_PositionsDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsDetails, rd)
                Me.CurrencyRisk_PositionsTotalsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals, rd)
                Me.CurrencyRisk_DateTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_Date, rd)

                SplashScreenManager.CloseForm(False)
                'If cmd.Connection.State = ConnectionState.Open Then
                'cmd.Connection.Close()
                'End If
            End If
        End If
    End Sub

    Private Sub CR_DateEdit_ComboEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CR_DateEdit_ComboEdit.SelectedIndexChanged
        If IsDate(Me.CR_DateEdit_ComboEdit.Text) = True Then

            rd = Me.CR_DateEdit_ComboEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Currency Risk for " & rd)
            'If cmd.Connection.State = ConnectionState.Closed Then
            'cmd.Connection.Open()
            'End If

            'cmd.CommandText = "Select [CR_Date] from [CurrencyRisk_Date] where [CR_Date]='" & rdsql & "' "
            'Dim t As String = cmd.ExecuteScalar
            'If IsNothing(t) = True Then
            'cmd.CommandText = "INSERT INTO [CurrencyRisk_Date]([CR_Date]) Values ('" & rdsql & "')"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "INSERT INTO [CurrencyRisk_PositionsTotals]([CR_Position_Date],[CR_CURRENCY],[CR_Sql_Command],[CR_Sql_Command1]) SELECT '" & rdsql & "',[SQL_Name_1],[SQL_Command_1],[SQL_Command_2] FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='CURRENCY RISK CALCULATION'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE A SET A.[IdCurrencyRiskDate]=B.[ID] from [CurrencyRisk_PositionsTotals] A INNER JOIN [CurrencyRisk_Date] B ON A.[CR_Position_Date]=B.[CR_Date] where A.[CR_Position_Date]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE [CurrencyRisk_PositionsTotals] SET [CR_Sql_Command]= REPLACE([CR_Sql_Command],'<RiskDate>','" & rdsql & "'),[CR_Sql_Command1]= REPLACE([CR_Sql_Command1],'<RiskDate>','" & rdsql & "') where [CR_Position_Date]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE [CurrencyRisk_Date] set [RiskCapitalCharge]=(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='Currency Risk Calculation Percent' and [IdABTEILUNGSPARAMETER]='CURRENCY_RISK_PERCENT')  where [CR_Date]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()

            Me.CurrencyRisk_PositionsAllDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsAllDetails, rd)
            Me.CurrencyRisk_PositionsDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsDetails, rd)
            Me.CurrencyRisk_PositionsTotalsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals, rd)
            Me.CurrencyRisk_DateTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_Date, rd)

            SplashScreenManager.CloseForm(False)
            'If cmd.Connection.State = ConnectionState.Open Then
            'cmd.Connection.Close()
            'End If
        End If
    End Sub

    Private Sub SQL_BS_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_BS_Run_BarButtonItem.ItemClick
        Try
            rd = DateSerial(Microsoft.VisualBasic.Right(Me.CurrencyRiskDate_lbl.Text, 4), Mid(Me.CurrencyRiskDate_lbl.Text, 4, 2), Microsoft.VisualBasic.Left(Me.CurrencyRiskDate_lbl.Text, 2))
            rdsql = rd.ToString("yyyyMMdd")

            If MessageBox.Show("Should the Currency Risk calculation for " & rd & " be executed again?", "CURRENCY RISK CALCULATION based on BALANCE SHEET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Commands:PS TOOL CLIENT PROCEDURES/CURRENCY_RISK_CALCULATION for " & rd)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandTimeout = 50000

                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CURRENCY_RISK_CALCULATION')) and [SQL_Command_2] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Threading.Thread.Sleep(500)
                        SplashScreenManager.Default.SetWaitFormCaption("Execute Currency Risk calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

                SplashScreenManager.CloseForm(False)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.CurrencyRisk_PositionsAllDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsAllDetails, rd)
                Me.CurrencyRisk_PositionsDetailsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsDetails, rd)
                Me.CurrencyRisk_PositionsTotalsTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_PositionsTotals, rd)
                Me.CurrencyRisk_DateTableAdapter.FillByCRDate(Me.CurrencyRiskCalcDataSet.CurrencyRisk_Date, rd)
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