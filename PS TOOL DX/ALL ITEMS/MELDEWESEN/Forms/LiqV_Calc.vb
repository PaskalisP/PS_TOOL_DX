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
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Spreadsheet
Public Class LiqV_Calc

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim CVA_ExcelFileName As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing

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

    Private Sub LiqV_Details_TotalsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LiqV_Details_TotalsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.LiqV_Dataset)

    End Sub

    Private Sub LiqV_Calc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='CVA Calculation in Excel' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES_DIRECTORY' and [PARAMETER STATUS]='Y'"
        CVA_ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        'Bind Combobox
        Me.LiqV_DateEdit_ComboEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[BSDate],104) as 'RLDC Date' from [DailyBalanceSheets] where [BSDate]<='20171231' GROUP BY [BSDate] ORDER BY [BSDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.LiqV_DateEdit_ComboEdit.Properties.Items.Add(row("RLDC Date"))
                Me.LiqV_Date_Comboedit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.LiqV_DateEdit_ComboEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
            Me.LiqV_Date_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        rd = Me.LiqV_DateEdit_ComboEdit.Text
        rdsql = rd.ToString("yyyyMMdd")

        Me.LiqV_Details_All1TableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_All1, rd)
        Me.LiqV_Details_AllTableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_All, rd)
        Me.LiqV_Details_TotalsTableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_Totals, rd)
        UPDATE_LIQV_RATIO()
    End Sub

    Private Sub UPDATE_LIQV_RATIO()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select LaufzeitBand_1 from [LiqV_Details_Totals] where RiskDate='" & rdsql & "' and ZeilenNr in ('350b')"
        Dim Liqv As Double = cmd.ExecuteScalar
        Me.LiqV_Value_lbl.Text = Liqv
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub
   

    Private Sub LiqV_Totals_BandedGridView_CustomColumnGroup1(sender As Object, e As CustomColumnSortEventArgs) Handles LiqV_Totals_BandedGridView.CustomColumnGroup
        If e.Column.FieldName = "GroupName" Then
            ' If compared field values are the same return 0
            If e.Value1 = e.Value2 Then
                e.Result = 0
            Else
                ' Check on first field value
                Select Case e.Value1.ToString()

                    Case "Berechnung der Liquiditätskennzahl und der Beobachtungskennzahlen"
                        ' "LCR_IN" is lowest status value, so always return -1
                        e.Result = -1
                    Case "Zahlungsmittel"
                        ' "LCR_LA is highest status value, so always return 1
                        e.Result = 1
                    Case "Zahlungsverpflichtungen"
                        ' "LCR_OUT" is middle status, so result depends on second row's field value
                        If e.Value2.ToString() = "Berechnung der Liquiditätskennzahl und der Beobachtungskennzahlen" Then
                            ' "LCR_IN" is lowest status, so the current field value will always be higher
                            e.Result = 1
                        Else
                            ' If value 2 is not 'LCR_IN' it must be 'LCR_OUT', so current field value is lower
                            e.Result = -1
                        End If
                End Select
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub LiqV_Totals_BandedGridView_CustomColumnSort1(sender As Object, e As CustomColumnSortEventArgs) Handles LiqV_Totals_BandedGridView.CustomColumnSort
        If e.Column.FieldName = "GroupName" Then
            ' If compared field values are the same return 0
            If e.Value1 = e.Value2 Then
                e.Result = 0
            Else
                ' Check on first field value
                Select Case e.Value1.ToString()

                    Case "Berechnung der Liquiditätskennzahl und der Beobachtungskennzahlen"
                        ' "LCR_IN" is lowest status value, so always return -1
                        e.Result = -1
                    Case "Zahlungsmittel"
                        ' "LCR_LA is highest status value, so always return 1
                        e.Result = 1
                    Case "Zahlungsverpflichtungen"
                        ' "LCR_OUT" is middle status, so result depends on second row's field value
                        If e.Value2.ToString() = "Berechnung der Liquiditätskennzahl und der Beobachtungskennzahlen" Then
                            ' "LCR_IN" is lowest status, so the current field value will always be higher
                            e.Result = 1
                        Else
                            ' If value 2 is not 'LCR_IN' it must be 'LCR_OUT', so current field value is lower
                            e.Result = -1
                        End If
                End Select
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub LiqV_DateEdit_ComboEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LiqV_DateEdit_ComboEdit.SelectedIndexChanged
        If IsDate(LiqV_DateEdit_ComboEdit.Text) = True Then

            rd = LiqV_DateEdit_ComboEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load LiqV Data for " & rd)
           

            Me.LiqV_Details_All1TableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_All1, rd)
            Me.LiqV_Details_AllTableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_All, rd)
            Me.LiqV_Details_TotalsTableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_Totals, rd)
            UPDATE_LIQV_RATIO()
            SplashScreenManager.CloseForm(False)
           
        End If
    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick
        Try


            If MessageBox.Show("Should the stored procedure:LiqV_CALCULATION for " & rd & " be executed again?", "SQL COMMANDS  EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Commands for " & rd)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandTimeout = 50000

                SplashScreenManager.Default.SetWaitFormCaption("Execute Stored Procedure:LiqV_CALCULATION for " & rd)
                cmd.CommandText = "Exec [LiqV_CALCULATION] @RISKDATE='" & rdsql & "'"
                cmd.ExecuteNonQuery()



                SplashScreenManager.CloseForm(False)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.LiqV_Details_All1TableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_All1, rd)
                Me.LiqV_Details_AllTableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_All, rd)
                Me.LiqV_Details_TotalsTableAdapter.FillByRiskDate(Me.LiqV_Dataset.LiqV_Details_Totals, rd)
                UPDATE_LIQV_RATIO()
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

    Private Sub Load_LiqV_Details_btn_Click(sender As Object, e As EventArgs) Handles Load_LiqV_Details_btn.Click
        If Me.LiqV_Date_Comboedit.Text <> "" Then

            Try
                rd = Me.LiqV_Date_Comboedit.Text
                rdsql = rd.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Calculate LiqV Details (Stored Procedure:LiqV_DETAILS) for Business Date: " & rd)

                Dim da As SqlDataAdapter
                Dim objCMD As SqlCommand = New SqlCommand("execute [LiqV_DETAILS]  @RISKDATE='" & rdsql & "' ", conn)
                objCMD.CommandTimeout = 5000
                da = New SqlDataAdapter(objCMD)
                'da.SelectCommand = objCMD
                '*******************************************************************
                dt = New DataTable()
                da.Fill(dt)

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    'Me.GridControl4.BeginUpdate()
                    Me.GridControl4.DataSource = Nothing
                    'Me.GridControl1.Refresh()
                    Me.GridControl4.DataSource = dt
                    Me.GridControl4.ForceInitialize()
                    'Me.LCR_Details_GridView.PopulateColumns()
                    'Me.LCR_Details_GridView.BestFitColumns()
                    'Me.GridControl4.RefreshDataSource()

                    SplashScreenManager.CloseForm(False)
                Else
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show("There are no Data for the LiqV Details", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try


        End If
    End Sub



    Private Sub LiqV_Totals_BandedGridView_CustomDrawGroupRow(sender As Object, e As RowObjectCustomDrawEventArgs) Handles LiqV_Totals_BandedGridView.CustomDrawGroupRow
        Dim rowInfo As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
        If rowInfo.Column.FieldName = "GroupName" Then
            Dim caption As String = String.Format("{0}:", rowInfo.Column.GetCaption())
            rowInfo.GroupText = rowInfo.GroupText.Replace(caption, "")
        End If

    End Sub

    Private Sub LiqV_DetailsAll_Gridview_CustomDrawGroupRow(sender As Object, e As RowObjectCustomDrawEventArgs) Handles LiqV_DetailsAll_Gridview.CustomDrawGroupRow
        Dim rowInfo As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
        If rowInfo.Column.FieldName = "GroupName" Then
            Dim caption As String = String.Format("{0}:", rowInfo.Column.GetCaption())
            rowInfo.GroupText = rowInfo.GroupText.Replace(caption, "")
        End If
        If rowInfo.Column.FieldName = "ZeilenNr" Then
            Dim caption As String = String.Format("{0}:", rowInfo.Column.GetCaption())
            rowInfo.GroupText = rowInfo.GroupText.Replace(caption, "")
        End If
    End Sub

    Private Sub LiqV_Totals_BandedGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LiqV_Totals_BandedGridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LiqV_Totals_BandedGridView_ShownEditor(sender As Object, e As EventArgs) Handles LiqV_Totals_BandedGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub LiqV_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LiqV_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LiqV_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles LiqV_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    

    Private Sub LiqV_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LiqV_DetailsAll_Gridview.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LiqV_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles LiqV_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub LiquidityCalculation_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LiquidityCalculation_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LiquidityCalculation_GridView_ShownEditor(sender As Object, e As EventArgs) Handles LiquidityCalculation_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Print_Export_LiqV_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_LiqV_Totals_Gridview_btn.Click
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
        Dim reportfooter As String = "Liquidity Ratio calculation Details " & "   " & "Business Date: " & rd
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
        Dim reportfooter As String = "Liquidity Ratio calculation Row Details " & "   " & "Business Date: " & rd
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl4.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "LiqV DETAILS" & "   " & "Business Date: " & Me.LiqV_Date_Comboedit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
End Class