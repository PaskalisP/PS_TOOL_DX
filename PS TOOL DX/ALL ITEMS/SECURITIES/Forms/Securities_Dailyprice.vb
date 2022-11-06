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
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing
'Imports GemBox.Spreadsheet
'Imports DevExpress.Spreadsheet


Public Class Securities_Dailyprice

    'Dim EXCELL As New Microsoft.Office.Interop.Excel.Application
    'Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    'Dim xlWorksheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Dim ActiveTabGroup As Double = 0

    'Dim workbook As IWorkbook
    'Dim worksheet As Worksheet
    'Dim workbookN As IWorkbook
    'Dim worksheetN As Worksheet
    Dim ExcelFileName As String = Nothing

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand


    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Public SecDailyPriceAdd As Securities_AddNewDailyPrice
    Dim NewDP As New Securities_AddNewDailyPrice()


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
    

    Private Sub SECURITIES_DailyPriceBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SECURITIES_DailyPriceBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)

    End Sub

    Private Sub Securities_Dailyprice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'If cmd.Connection.State = ConnectionState.Closed Then
        'cmd.Connection.Open()
        'End If
        'cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='DailyPriceExcelFile_Directory' and [IdABTEILUNGSPARAMETER]='DAILY_PRICE_SECURITIES' and [PARAMETER STATUS]='Y'"
        'ExcelFileName = cmd.ExecuteScalar
        'If cmd.Connection.State = ConnectionState.Open Then
        'cmd.Connection.Close()
        'End If

        'workbook = Me.SpreadsheetControl1.Document
        'Using stream As New FileStream(ExcelFileName, FileMode.Open)
        'workbook.LoadDocument(Stream, DocumentFormat.Xlsx)
        'End Using

        'TODO: This line of code loads data into the 'SECURITIESDataset.SECURITIES_DailyPrice' table. You can move, or remove it, as needed.
        Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()



    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Add" Then
            'Dim SecDailyPriceAdd As New Securities_AddNewDailyPrice
            'SecDailyPriceAdd.ShowDialog()
          

        End If
    End Sub



    Private Sub SecuritiesDailyPriceBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SecuritiesDailyPriceBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SecuritiesDailyPriceBaseView_ShownEditor(sender As Object, e As EventArgs) Handles SecuritiesDailyPriceBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub DailyPrice_import_btn_Click(sender As Object, e As EventArgs) Handles DailyPrice_import_btn.Click
        Try

            Dim dxOK_NewDP As New DevExpress.XtraEditors.SimpleButton
            With dxOK_NewDP
                .Text = "Save new Dailyprice"
                .Height = 22
                .Width = 192
                .ImageList = NewDP.ImageCollection1
                .ImageIndex = 7
                .Location = New System.Drawing.Point(12, 603)
            End With

            NewDP.Controls.Add(dxOK_NewDP)
            NewDP.DailyPrice_import_btn.Visible = False

            Dim objCMD As SqlCommand = New SqlCommand("Select *,0.000000 as 'Market_Price' from [SECURITIES_OUR] where [STATUS] in ('ACTIVE')", conn)
            objCMD.CommandTimeout = 5000
            da = New SqlDataAdapter(objCMD)
            dt = New DataTable()
            da.Fill(dt)
            'Results
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                NewDP.GridControl2.DataSource = Nothing
                NewDP.GridControl2.DataSource = dt
                NewDP.GridControl2.ForceInitialize()
            End If


            AddHandler dxOK_NewDP.Click, AddressOf dxOK_NewDP_click

            NewDP.LiquidityDateEdit.EditValue = Today
            NewDP.GridControl2.Focus()
            NewDP.SecuritiesDailyPriceBaseView.FocusedRowHandle = 0
            NewDP.SecuritiesDailyPriceBaseView.FocusedColumn = SecuritiesDailyPriceBaseView.VisibleColumns(7)
            NewDP.SecuritiesDailyPriceBaseView.ShowEditor()
            NewDP.ShowDialog()




            'Code example for LayoutControlItem
            'NewDP.LayoutControlItem3.BeginInit()
            'Dim tempC As Control = NewDP.LayoutControlItem3.Control
            'NewDP.LayoutControlItem3.Control = dxOK_NewDP
            'tempC.Parent = Nothing
            'NewDP.LayoutControlItem3.EndInit()




        Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
            'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()
        End Try

    End Sub

    Private Sub dxOK_NewDP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(NewDP.LiquidityDateEdit.Text) = True Then
            Dim Datadate As Date = NewDP.LiquidityDateEdit.Text
            Dim DatadateSql As String = Datadate.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            Dim dt As New DataTable
            Dim r As DataRow
            dt.Columns.Add("Date", GetType(Date))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("ISIN_Code", GetType(String))
            dt.Columns.Add("Market_Price", GetType(Double))
            dt.Columns.Add("ContractNrOCBS", GetType(Double))

            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
            Dim result As String = cmd.ExecuteScalar
            If result <> "" Then
                If MessageBox.Show("Daily Price Date: " & Datadate & " allready inserted to the Daily Price Table!" & vbNewLine & "Should the current Data be overwritten with the current Market Prices?", "DAILY PRICE DATE ALLREADY INSERTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'lösche alte daten
                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        If NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price) = 0 Then
                            MessageBox.Show("Please enter the Market Price for each Security/Bond", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    Next

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        r = dt.NewRow
                        r("Date") = NewDP.LiquidityDateEdit.Text
                        r("Name") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("SecurityName"))
                        r("ISIN_Code") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ISIN"))
                        r("Market_Price") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price)
                        r("ContractNrOCBS") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ContractNrOCBS"))
                        dt.Rows.Add(r)
                        'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                    Next

                    For Each dr As DataRow In dt.Rows
                        'MsgBox(dr.Item(0).ToString & " " & dr.Item(1) & "  " & dr.Item(2) & "  " & dr.Item(3) & "  " & dr.Item(4))
                        Dim sc As New SqlCommand("INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ContractNrOCBS])" &
                                                  " VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                        sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.Parameters.AddWithValue("@column5", dr.Item(4))
                        sc.ExecuteNonQuery()
                    Next
                    cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price],A.[RIC]=B.[RIC]
                                       ,A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon]
                                       ,A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield]
                                       ,A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating]
                                       ,A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] 
                                        FROM [SECURITIES_DailyPrice] A INNER JOIN [SECURITIES_OUR] B 
                                        on A.ISIN_Code=B.ISIN and A.[Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()


                    'Execute LIQUIDITY RESERVE
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Execute PS TOOL CLIENT PROCEDURE:LIQUIDITY_RESERVE")
                    Dim HasDataResult As String = Nothing
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LIQUIDITY_RESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        cmd.CommandText = "SELECT [Date] FROM [SECURITIES_DailyPrice] WHERE [Date]='" & DatadateSql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", DatadateSql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    Else
                    End If
                    SplashScreenManager.CloseForm(False)

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                    NewDP.Close()

                Else
                    Return
                End If
            Else
                For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                    If NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price) = 0 Then
                        MessageBox.Show("Please enter the Market Price for each Security/Bond", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                Next

                For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                    r = dt.NewRow
                    r("Date") = NewDP.LiquidityDateEdit.Text
                    r("Name") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("SecurityName"))
                    r("ISIN_Code") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ISIN"))
                    r("Market_Price") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price)
                    r("ContractNrOCBS") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ContractNrOCBS"))
                    dt.Rows.Add(r)
                    'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                Next

                For Each dr As DataRow In dt.Rows
                    'MsgBox(dr.Item(0).ToString & " " & dr.Item(1) & "  " & dr.Item(2) & "  " & dr.Item(3) & "  " & dr.Item(4))
                    Dim sc As New SqlCommand("INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ContractNrOCBS])" &
                                                  " VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.Parameters.AddWithValue("@column2", dr.Item(1))
                    sc.Parameters.AddWithValue("@column3", dr.Item(2))
                    sc.Parameters.AddWithValue("@column4", dr.Item(3))
                    sc.Parameters.AddWithValue("@column5", dr.Item(4))
                    sc.ExecuteNonQuery()
                Next
                cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price],A.[RIC]=B.[RIC]
                                       ,A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon]
                                       ,A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield]
                                       ,A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating]
                                       ,A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] 
                                        FROM [SECURITIES_DailyPrice] A INNER JOIN [SECURITIES_OUR] B 
                                        on A.ISIN_Code=B.ISIN and A.[Date]='" & DatadateSql & "'"
                cmd.ExecuteNonQuery()


                'Execute LIQUIDITY RESERVE
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Execute PS TOOL CLIENT PROCEDURE:LIQUIDITY_RESERVE")
                Dim HasDataResult As String = Nothing
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LIQUIDITY_RESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    cmd.CommandText = "SELECT [Date] FROM [SECURITIES_DailyPrice] WHERE [Date]='" & DatadateSql & "'"
                    HasDataResult = cmd.ExecuteScalar
                    If IsNothing(HasDataResult) = False Then
                        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", DatadateSql)
                            cmd.CommandText = SqlCommandText
                            If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    End If
                Else
                End If
                SplashScreenManager.CloseForm(False)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                NewDP.Close()

            End If


        Else
            MessageBox.Show("Please enter the Market Price Date!", "MARKET PRICE DATE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            NewDP.LiquidityDateEdit.Focus()
            Return


        End If

        Me.SECURITIES_DailyPriceTableAdapter.Fill(SECURITIESDataset.SECURITIES_DailyPrice)
        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()

    End Sub

    Private Sub Securities_DailyPrice_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Securities_DailyPrice_Print_Export_btn.Click
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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "CCB Frankfurt - SECURITIES DAILYPRICE" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SaveExcelFile_btn_Click(sender As Object, e As EventArgs) Handles SaveExcelFile_btn.Click
        'Try
        '    workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
        '    MessageBox.Show("Excel file saved!", "SAVE STATUS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Exit Sub

        'End Try
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        'If Me.TabbedControlGroup1.SelectedTabPage.Text = "Securities Daily Prices" Then
        'Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
        'Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
        'ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Daily Price (Excel Sheet)" Then
        'Me.LayoutControlItem1.Visibility = LayoutVisibility.Never
        'Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        'End If
    End Sub

    Private Sub SecuritiesDailyPriceBaseView_DoubleClick(sender As Object, e As EventArgs) Handles SecuritiesDailyPriceBaseView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.IsFilterRow(view.FocusedRowHandle) = False And view.IsGroupRow(view.FocusedRowHandle) = False Then

            Try

                rd = CDate(view.GetFocusedRowCellValue("Date").ToString)
                rdsql = rd.ToString("yyyyMMdd")

                Dim dxOK_Mod_NewDP As New DevExpress.XtraEditors.SimpleButton
                With dxOK_Mod_NewDP
                    .Text = "Modify Securities Dailyprice"
                    .Height = 22
                    .Width = 192
                    .ImageList = NewDP.ImageCollection1
                    .ImageIndex = 7
                    .Location = New System.Drawing.Point(12, 603)
                End With

                NewDP.Controls.Add(dxOK_Mod_NewDP)
                NewDP.DailyPrice_import_btn.Visible = False

                Dim objCMD As SqlCommand = New SqlCommand("Select B.ContractNrOCBS,B.ISIN,B.SecurityName,B.Currency,B.PrincipalOrigAmt,A.Market_Price,B.Purchase_Price,B.AssetType,B.MaturityDate 
                                                          from [SECURITIES_DailyPrice] A INNER JOIN SECURITIES_OUR B on A.ISIN_Code=B.ISIN and A.ContractNrOCBS=B.ContractNrOCBS
                                                          where A.[Date]='" & rdsql & "'", conn)
                objCMD.CommandTimeout = 5000
                da = New SqlDataAdapter(objCMD)
                dt = New DataTable()
                da.Fill(dt)
                'Results
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    NewDP.GridControl2.DataSource = Nothing
                    NewDP.GridControl2.DataSource = dt
                    NewDP.GridControl2.ForceInitialize()
                End If


                AddHandler dxOK_Mod_NewDP.Click, AddressOf dxOK_Mod_NewDP_click

                NewDP.LiquidityDateEdit.EditValue = rd
                NewDP.LiquidityDateEdit.ReadOnly = True
                NewDP.GridControl2.Focus()
                NewDP.SecuritiesDailyPriceBaseView.FocusedRowHandle = 0
                NewDP.SecuritiesDailyPriceBaseView.FocusedColumn = SecuritiesDailyPriceBaseView.VisibleColumns(7)
                NewDP.SecuritiesDailyPriceBaseView.ShowEditor()
                NewDP.ShowDialog()




            Catch ex As System.Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
                'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()
            End Try

        Else
            Return

        End If

    End Sub

    Private Sub dxOK_Mod_NewDP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(NewDP.LiquidityDateEdit.Text) = True Then
            Dim Datadate As Date = NewDP.LiquidityDateEdit.Text
            Dim DatadateSql As String = Datadate.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            Dim dt As New DataTable
            Dim r As DataRow
            dt.Columns.Add("Date", GetType(Date))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("ISIN_Code", GetType(String))
            dt.Columns.Add("Market_Price", GetType(Double))
            dt.Columns.Add("ContractNrOCBS", GetType(Double))

            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
            Dim result As String = cmd.ExecuteScalar
            If result <> "" Then
                If MessageBox.Show("Daily Price Date: " & Datadate & " allready inserted to the Daily Price Table!" & vbNewLine & "Should the current Data be overwritten with the current Market Prices?", "DAILY PRICE DATE ALLREADY INSERTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'lösche alte daten
                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        If NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price) = 0 Then
                            MessageBox.Show("Please enter the Market Price for each Security/Bond", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    Next

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        r = dt.NewRow
                        r("Date") = NewDP.LiquidityDateEdit.Text
                        r("Name") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("SecurityName"))
                        r("ISIN_Code") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ISIN"))
                        r("Market_Price") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price)
                        r("ContractNrOCBS") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ContractNrOCBS"))
                        dt.Rows.Add(r)
                        'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                    Next

                    For Each dr As DataRow In dt.Rows
                        'MsgBox(dr.Item(0).ToString)
                        Dim sc As New SqlCommand("INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ContractNrOCBS])" &
                                                  " VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                        sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.Parameters.AddWithValue("@column5", dr.Item(4))
                        sc.ExecuteNonQuery()
                    Next
                    cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price],A.[RIC]=B.[RIC]
                                       ,A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon]
                                       ,A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield]
                                       ,A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating]
                                       ,A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] 
                                        FROM [SECURITIES_DailyPrice] A INNER JOIN [SECURITIES_OUR] B 
                                        on A.ISIN_Code=B.ISIN and A.[Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()


                    'Execute LIQUIDITY RESERVE
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Execute PS TOOL CLIENT PROCEDURE:LIQUIDITY_RESERVE")
                    Dim HasDataResult As String = Nothing
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LIQUIDITY_RESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        cmd.CommandText = "SELECT [Date] FROM [SECURITIES_DailyPrice] WHERE [Date]='" & DatadateSql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", DatadateSql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    Else
                    End If
                    SplashScreenManager.CloseForm(False)

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                    NewDP.Close()

                Else
                    Return
                End If

            End If


        Else
            MessageBox.Show("Please enter the Market Price Date!", "MARKET PRICE DATE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            NewDP.LiquidityDateEdit.Focus()
            Return


        End If

        Me.SECURITIES_DailyPriceTableAdapter.Fill(SECURITIESDataset.SECURITIES_DailyPrice)
        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()

    End Sub
End Class