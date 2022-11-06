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

            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
            Dim result As String = cmd.ExecuteScalar
            If result <> "" Then
                If MessageBox.Show("Daily Price Date: " & Datadate & " allready inserted to the Daily Price Table!" & vbNewLine & "Should the current Data be overwritten with the current Market Prices?", "DAILY PRICE DATE ALLREADY INSERTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
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

                        dt.Rows.Add(r)
                        'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                    Next

                    For Each dr As DataRow In dt.Rows
                        'MsgBox(dr.Item(0).ToString)
                        Dim sc As New SqlCommand("INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price])" & _
                                                  " VALUES (@column1, @column2, @column3, @column4)", conn)
                        sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.ExecuteNonQuery()
                    Next
                    cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price],A.[RIC]=B.[RIC],A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon],A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield],A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating],A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] FROM [SECURITIES_DailyPrice] A INNER JOIN [SECURITIES_OUR] B on A.ISIN_Code=B.ISIN"
                    cmd.ExecuteNonQuery()

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

                    dt.Rows.Add(r)
                    'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                Next

                For Each dr As DataRow In dt.Rows
                    'MsgBox(dr.Item(0).ToString)
                    Dim sc As New SqlCommand("INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price])" & _
                                              " VALUES (@column1, @column2, @column3, @column4)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.Parameters.AddWithValue("@column2", dr.Item(1))
                    sc.Parameters.AddWithValue("@column3", dr.Item(2))
                    sc.Parameters.AddWithValue("@column4", dr.Item(3))
                    sc.ExecuteNonQuery()
                Next
                cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price],A.[RIC]=B.[RIC],A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon],A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield],A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating],A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] FROM [SECURITIES_DailyPrice] A INNER JOIN [SECURITIES_OUR] B on A.ISIN_Code=B.ISIN"
                cmd.ExecuteNonQuery()

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

    Private Sub OLD_BTN_CODE()
        'Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        'workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
        'Dim Blatt1 As Worksheet = workbook.Worksheets(0)

        'Dim test As Date = Blatt1.Cells("A2").DisplayText
        'Dim Datadate As Date = Blatt1.Cells("A2").DisplayText
        'Dim DatadateSql As String = Datadate.ToString("yyyyMMdd")

        'Dim ExcelFileSqlName As String = ExcelFileName


        'cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
        'If cmd.Connection.State = ConnectionState.Closed Then
        '    cmd.Connection.Open()
        'End If
        'Dim result As String = cmd.ExecuteScalar
        'If result <> "" Then
        '    If MessageBox.Show("File allready imported to the Database!" & vbNewLine & "Should the current Data be overwritten from this file?", "FILE IMPORTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
        '        'lösche alte daten
        '        cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
        '        cmd.ExecuteNonQuery()
        '        'Importiere Datei
        '        cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[Ccy],[ISIN_Code],[RIC],[Market_Price],[Swap_Price],[Purchase_price],[industry],[Fixed rate coupon],[Floating(leg) spread ],[purchasing yield],[bond type],[with swap or not],[Moody-Rating],[S & P],[Fitch-Rating]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileSqlName & ";','SELECT * FROM [Sheet1$]')"
        '        cmd.ExecuteNonQuery()
        '        cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date] is NULL"
        '        cmd.ExecuteNonQuery()
        '        MessageBox.Show("File: Dailyprice imported to the Database", "FILE IMPORTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    Else
        '        If cmd.Connection.State = ConnectionState.Open Then
        '            cmd.Connection.Close()
        '        End If
        '        Exit Sub
        '    End If
        'Else
        '    'Importiere Datei
        '    cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[Ccy],[ISIN_Code],[RIC],[Market_Price],[Swap_Price],[Purchase_price],[industry],[Fixed rate coupon],[Floating(leg) spread ],[purchasing yield],[bond type],[with swap or not],[Moody-Rating],[S & P],[Fitch-Rating]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileSqlName & ";','SELECT * FROM [Sheet1$]')"
        '    cmd.ExecuteNonQuery()
        '    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date] is NULL"
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("File: Dailyprice imported to the Database", "FILE IMPORTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        'End If


        'If cmd.Connection.State = ConnectionState.Open Then
        '    cmd.Connection.Close()
        'End If
        'Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()
    End Sub

    Private Sub OLD_EXCEL_FILE_IMPORT()
        'Try
        '    With Me.OpenFileDialog1
        '        .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
        '        .DefaultExt = "xls"
        '        .FilterIndex = 1
        '        .InitialDirectory = "\\CCB-DB\Apps"
        '        .FileName = ""
        '        .Title = "Import Dailyprice to Datasource"
        '        .RestoreDirectory = True
        '        .Multiselect = False

        '        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
        '            Dim ExcelFileName As String = Me.OpenFileDialog1.FileName.ToString
        '            'Excel Datei Öffnen und Datenformat ändern
        '            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        '            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        '            EXCELL = CreateObject("Excel.Application")
        '            xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
        '            xlWorksheet1 = xlWorkBook.Worksheets(1)
        '            EXCELL.Visible = False

        '            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")
        '            Dim ef As ExcelFile = ExcelFile.Load(ExcelFileName)
        '            Dim ws As ExcelWorksheet = ef.Worksheets(0)



        '            Dim Datadate As Date = xlWorksheet1.Range("A2").Value
        '            Dim DatadateSql As String = Datadate.ToString("yyyyMMdd")

        '            EXCELL.DisplayAlerts = False
        '            If File.Exists("\\CCB-DB\Apps\DailyPrice.xls") = False Then

        '                xlWorkBook.SaveAs("\\CCB-DB\Apps\DailyPrice.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
        '            ElseIf File.Exists("\\CCB-DB\Apps\DailyPrice.xls") = True Then
        '                File.Delete("\\CCB-DB\Apps\DailyPrice.xls")
        '                xlWorkBook.SaveAs("\\CCB-DB\Apps\DailyPrice.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
        '            End If

        '            Dim ExcelFileSqlName As String = "\\CCB-DB\Apps\DailyPrice.xls"
        '            EXCELL.DisplayAlerts = True
        '            xlWorkBook.Close()

        '            EXCELL.Quit()
        '            EXCELL = Nothing

        '            'Excel Instanz beenden
        '            Dim procs1() As Process = Process.GetProcessesByName("EXCEL")
        '            Dim i11 As Short
        '            i11 = 0
        '            For i11 = 0 To (procs1.Length - 1)
        '                procs1(i11).Kill()
        '            Next i11

        '            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


        '            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
        '            cmd.Connection.Open()
        '            Dim result As String = cmd.ExecuteScalar
        '            If result <> "" Then
        '                If MessageBox.Show("File allready imported to the Database!" & vbNewLine & "Should the current Data be overwritten from this file?", "FILE IMPORTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
        '                    'lösche alte daten
        '                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
        '                    cmd.ExecuteNonQuery()
        '                    'Importiere Datei
        '                    cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[Ccy],[ISIN_Code],[RIC],[Market_Price],[Swap_Price],[Purchase_price],[industry],[Fixed rate coupon],[Floating(leg) spread ],[purchasing yield],[bond type],[with swap or not],[Moody-Rating],[S & P],[Fitch-Rating]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileSqlName & ";','SELECT * FROM [Sheet1$]')"
        '                    cmd.ExecuteNonQuery()
        '                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date] is NULL"
        '                    cmd.ExecuteNonQuery()
        '                    MessageBox.Show("File: Dailyprice imported to the Database", "FILE IMPORTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '                Else

        '                End If
        '            Else
        '                'Importiere Datei
        '                cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[Ccy],[ISIN_Code],[RIC],[Market_Price],[Swap_Price],[Purchase_price],[industry],[Fixed rate coupon],[Floating(leg) spread ],[purchasing yield],[bond type],[with swap or not],[Moody-Rating],[S & P],[Fitch-Rating]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileSqlName & ";','SELECT * FROM [Sheet1$]')"
        '                cmd.ExecuteNonQuery()
        '                cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date] is NULL"
        '                cmd.ExecuteNonQuery()
        '                MessageBox.Show("File: Dailyprice imported to the Database", "FILE IMPORTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '            End If

        '            File.Delete("\\CCB-DB\Apps\DailyPrice.xls")
        '            If cmd.Connection.State = ConnectionState.Open Then
        '                cmd.Connection.Close()
        '            End If
        '            Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
        '            Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()
        '        End If
        '    End With
        'Catch ex As System.Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    If cmd.Connection.State = ConnectionState.Open Then
        '        cmd.Connection.Close()
        '    End If
        '    Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
        '    Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()
        'End Try
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
End Class