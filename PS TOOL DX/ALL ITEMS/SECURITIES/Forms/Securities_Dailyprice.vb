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

    Public SecDailyPriceAdd As Securities_AddNewDailyPrice
    Dim NewDP As New Securities_AddNewDailyPrice()

    Private BS_All_ReportingDates As BindingSource


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
        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        ALL_REPORTING_DATES_initData()
        ALL_REPORTING_DATES_InitLookUp()

        If BS_All_ReportingDates.Count > 0 Then
            Me.BusinessDates_BarEditItem.EditValue = CType(BS_All_ReportingDates.Current, DataRowView).Item(0).ToString
        End If


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

        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()

    End Sub

    Private Sub ALL_REPORTING_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Declare @SELECTION_TABLE Table([ID] int IDENTITY(1,1) Not NULL, [REPORTING_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
													SELECT 'ALL'
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT 'REPORTING_DATE'=CONVERT(varchar(10),[Date],104) from SECURITIES_DailyPrice
                                                    group by Date order by Date asc
                                                    SELECT REPORTING_DATE  from @SELECTION_TABLE 
                                                    order by ID desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbReportingDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbReportingDates.Fill(ds, "REPORTING_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_ReportingDates = New BindingSource(ds, "REPORTING_DATE")
    End Sub
    Private Sub ALL_REPORTING_DATES_InitLookUp()
        Me.BusinessDates_SearchLookUpEdit.DataSource = BS_All_ReportingDates
        Me.BusinessDates_SearchLookUpEdit.DisplayMember = "REPORTING_DATE"
        Me.BusinessDates_SearchLookUpEdit.ValueMember = "REPORTING_DATE"
    End Sub

    Private Sub BusinessDates_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessDates_BarEditItem.EditValueChanged
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        If Me.BusinessDates_BarEditItem.EditValue.ToString = "ALL" Then
            SplashScreenManager.Default.SetWaitFormCaption("Load all securities market prices/modified durations for all Business dates")
            Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
            colDate.GroupIndex = 0
            colDate.Visible = True
            Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = True
            Me.BusinessDates_SearchLookUpEdit.Buttons.Item(4).Visible = False
        ElseIf Me.BusinessDates_BarEditItem.EditValue.ToString <> "ALL" AndAlso BS_All_ReportingDates.Count > 0 Then
            rd = CDate(Me.BusinessDates_BarEditItem.EditValue.ToString)
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.Default.SetWaitFormCaption("Load securities market prices/modified durations for Business date: " & rd)
            Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, rd)
            colDate.GroupIndex = -1
            colDate.Visible = False
            colDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = False
            Me.BusinessDates_SearchLookUpEdit.Buttons.Item(4).Visible = True
        End If
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BusinessDates_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessDates_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 2 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If Me.BusinessDates_BarEditItem.EditValue.ToString = "ALL" Then
                SplashScreenManager.Default.SetWaitFormCaption("Load all securities market prices/modified durations for all Business dates")
                Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
                colDate.GroupIndex = 0
                colDate.Visible = True
                Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = True
            ElseIf Me.BusinessDates_BarEditItem.EditValue.ToString <> "ALL" AndAlso BS_All_ReportingDates.Count > 0 Then
                rd = CDate(Me.BusinessDates_BarEditItem.EditValue.ToString)
                rdsql = rd.ToString("yyyyMMdd")
                SplashScreenManager.Default.SetWaitFormCaption("Load securities market prices/modified durations for Business date: " & rd)
                Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, rd)
                colDate.GroupIndex = -1
                colDate.Visible = False
                Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = False
            End If
            SplashScreenManager.CloseForm(False)
        End If

        If e.Button.Tag = 4 Then
            If Me.BusinessDates_BarEditItem.EditValue.ToString <> "ALL" AndAlso BS_All_ReportingDates.Count > 0 Then
                rd = CDate(Me.BusinessDates_BarEditItem.EditValue.ToString)
                rdsql = rd.ToString("yyyyMMdd")

                If XtraMessageBox.Show("Should the current securities modified durations for Business Date: " & rd & vbNewLine & "set as default for all future available Business Dates ?", "SET CURRENT MODIFIED DURATIONSAS DEFAULT FOR ALL FUTURE DATES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        'Update modified durations for all future dates
                        OpenSqlConnections()
                        cmd.CommandText = "UPDATE A SET A.ModifiedDuration=B.ModifiedDuration
                                      ,A.[LastAction]='SET DEFAULT FROM DATE:' + FORMAT(B.Date,'dd.MM.yyyy','de-DE')
                                      ,A.[LastUpdateUser]='" & CurrentUserWindowsID & "'
                                      ,A.[LastUpdateDate]=GETDATE()
                                      from SECURITIES_DailyPrice A INNER JOIN SECURITIES_DailyPrice B 
                                      on A.ISIN_Code=B.ISIN_Code
                                      where A.Date>'" & rdsql & "' and B.Date='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        CloseSqlConnections()
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load securities market prices/modified durations for Business date: " & rd)
                        Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, rd)
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("The current securities modified durations for Business Date: " & rd & vbNewLine & " where set as default for all future available Business Dates!", "SET CURRENT MODIFIED DURATIONSAS DEFAULT FOR ALL FUTURE DATES SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Catch ex As System.Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message)
                    End Try

                End If

            End If
        End If

    End Sub

    Private Sub AddNewData_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AddNewData_bbi.ItemClick
        Try

            Dim dxOK_NewDP As New DevExpress.XtraEditors.SimpleButton
            With dxOK_NewDP
                .Text = "Save Market prices / Modified Duration"
                .Height = 22
                .Width = 238
                .ImageList = NewDP.ImageCollection1
                .ImageIndex = 7
                .Location = New System.Drawing.Point(12, 603)
            End With
            NewDP.Text = "New Daily Market Price / Modified Duration"
            NewDP.Controls.Add(dxOK_NewDP)
            NewDP.DailyPrice_import_btn.Visible = False

            Dim objCMD As SqlCommand = New SqlCommand("DECLARE @SECS_ACTIVE as Table
                                                    (ID [int] IDENTITY(1,1) NOT NULL
                                                    ,[Name] nvarchar(255) NULL
                                                    ,[Ccy] nvarchar(3) NULL
                                                    ,[ISIN_Code] nvarchar(50) NULL
                                                    ,Nominal float default(0)
                                                    ,MaturityDate datetime NULL
                                                    ,MarketPrice float default(0)
                                                    ,ModifiedDuration float default(0))

                                                    DECLARE @LAST_MAX_DATE as Datetime=(Select max(date) from SECURITIES_DailyPrice)

                                                    INSERT INTO @SECS_ACTIVE
                                                    (Ccy
                                                    ,ISIN_Code
                                                    ,MaturityDate
                                                    ,Nominal)
                                                    Select 
                                                    Currency
                                                    ,ISIN
                                                    ,MaturityDate
                                                    ,Sum(PrincipalOrigAmt)
                                                    from SECURITIES_OUR where STATUS in ('ACTIVE')
                                                    GROUP BY SecurityName
                                                    ,Currency
                                                    ,ISIN
                                                    ,MaturityDate

                                                    UPDATE A SET A.Name=B.SecurityName from @SECS_ACTIVE A INNER JOIN SECURITIES_OUR B on A.ISIN_Code=B.ISIN

                                                    UPDATE A SET A.ModifiedDuration=ISNULL(B.ModifiedDuration,0) 
                                                    from @SECS_ACTIVE A INNER JOIN SECURITIES_DailyPrice B on A.ISIN_Code=B.ISIN_Code
                                                    where B.Date=@LAST_MAX_DATE

                                                    select * from @SECS_ACTIVE", conn)
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
            NewDP.SecuritiesDailyPriceBaseView.FocusedColumn = SecuritiesDailyPriceBaseView.VisibleColumns(5)
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
            Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, rd)
            'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()
        End Try
    End Sub

    Private Sub dxOK_NewDP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(NewDP.LiquidityDateEdit.Text) = True Then
            Dim Datadate As Date = NewDP.LiquidityDateEdit.Text
            Dim DatadateSql As String = Datadate.ToString("yyyyMMdd")

            OpenSqlConnections()

            Dim dt As New DataTable
            Dim r As DataRow
            dt.Columns.Add("Date", GetType(Date))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("ISIN_Code", GetType(String))
            dt.Columns.Add("MarketPrice", GetType(Double))
            dt.Columns.Add("ModifiedDuration", GetType(Double))

            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
            Dim result As String = cmd.ExecuteScalar
            If result <> "" Then
                If XtraMessageBox.Show("The Business Date: " & Datadate & " allready inserted to the daily market price Table!" & vbNewLine & "Should the current Data be overwritten with the current Market Prices/modified durations?", "BUSINESS DATE ALLREADY INSERTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'lösche alte daten
                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        If NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("MarketPrice")) < 0 Then
                            XtraMessageBox.Show("Please enter the Market Price for each Security/Bond greater than 0", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    Next

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        r = dt.NewRow
                        r("Date") = NewDP.LiquidityDateEdit.Text
                        r("Name") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("Name"))
                        r("ISIN_Code") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ISIN_Code"))
                        r("MarketPrice") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("MarketPrice"))
                        r("ModifiedDuration") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ModifiedDuration"))
                        dt.Rows.Add(r)
                        'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                    Next

                    cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_SECURITIES_DailyPrice') IS NOT NULL 
                                       DROP TABLE #Temp_SECURITIES_DailyPrice

                                       CREATE TABLE [#Temp_SECURITIES_DailyPrice]
                                       ([ID] [int] IDENTITY(1,1) NOT NULL,
                                       [Date] [datetime] NULL,
                                       [Name] [nvarchar](255) NULL,
                                       [ISIN_Code] [nvarchar](255) NULL,
                                       [Market_Price] [float] NULL,
                                       [ModifiedDuration] [float] NULL)"
                    cmd.ExecuteNonQuery()

                    For Each dr As DataRow In dt.Rows
                        'MsgBox(dr.Item(0).ToString & " " & dr.Item(1) & "  " & dr.Item(2) & "  " & dr.Item(3) & "  " & dr.Item(4))
                        Dim sc As New SqlCommand("INSERT INTO [#Temp_SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ModifiedDuration])" &
                                                  " VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                        sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.Parameters.AddWithValue("@column5", dr.Item(4))
                        sc.ExecuteNonQuery()
                    Next

                    cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice]
                                       ([Date]
                                       ,[Name]
                                       ,[ISIN_Code]
                                       ,[ContractNrOCBS]
                                       ,[Market_Price]
                                       ,[ModifiedDuration]
                                       ,[LastAction]
                                       ,[LastUpdateUser]
                                       ,[LastUpdateDate])
                                    SELECT 
                                        A.Date 
                                       ,A.Name
                                       ,A.ISIN_Code
                                       ,B.ContractNrOCBS
                                       ,A.Market_Price
                                       ,A.ModifiedDuration
                                       ,'ADD_AFTER_DELETE'
                                       ,'" & CurrentUserWindowsID & "'
                                       ,GETDATE()
                                       from #Temp_SECURITIES_DailyPrice A INNER JOIN SECURITIES_OUR B
                                       on A.ISIN_Code=B.ISIN"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_SECURITIES_DailyPrice') IS NOT NULL 
                                       DROP TABLE #Temp_SECURITIES_DailyPrice"
                    cmd.ExecuteNonQuery()


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
                            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                    CloseSqlConnections()

                    NewDP.Close()

                Else
                    Return
                End If
            Else
                For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                    If NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("MarketPrice")) <= 0 Then
                        XtraMessageBox.Show("Please enter the Market Price for each Security/Bond greater than 0", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                Next

                For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                    r = dt.NewRow
                    r("Date") = NewDP.LiquidityDateEdit.Text
                    r("Name") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("Name"))
                    r("ISIN_Code") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ISIN_Code"))
                    r("MarketPrice") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("MarketPrice"))
                    r("ModifiedDuration") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ModifiedDuration"))
                    dt.Rows.Add(r)
                    'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                Next

                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_SECURITIES_DailyPrice') IS NOT NULL 
                                   DROP TABLE #Temp_SECURITIES_DailyPrice

                                   CREATE TABLE [#Temp_SECURITIES_DailyPrice]
                                   ([ID] [int] IDENTITY(1,1) NOT NULL,
                                   [Date] [datetime] NULL,
                                   [Name] [nvarchar](255) NULL,
                                   [ISIN_Code] [nvarchar](255) NULL,
                                   [Market_Price] [float] NULL,
                                   [ModifiedDuration] [float] NULL)"
                cmd.ExecuteNonQuery()

                For Each dr As DataRow In dt.Rows
                    'MsgBox(dr.Item(0).ToString & " " & dr.Item(1) & "  " & dr.Item(2) & "  " & dr.Item(3) & "  " & dr.Item(4))
                    Dim sc As New SqlCommand("INSERT INTO [#Temp_SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ModifiedDuration])" &
                                             "VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.Parameters.AddWithValue("@column2", dr.Item(1))
                    sc.Parameters.AddWithValue("@column3", dr.Item(2))
                    sc.Parameters.AddWithValue("@column4", dr.Item(3))
                    sc.Parameters.AddWithValue("@column5", dr.Item(4))
                    sc.ExecuteNonQuery()
                Next

                cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice]
                                   ([Date]
                                   ,[Name]
                                   ,[ISIN_Code]
                                   ,[ContractNrOCBS]
                                   ,[Market_Price]
                                   ,[ModifiedDuration]
                                   ,[LastAction]
                                   ,[LastUpdateUser]
                                   ,[LastUpdateDate])
                               SELECT 
                                    A.Date 
                                   ,A.Name
                                   ,A.ISIN_Code
                                   ,B.ContractNrOCBS
                                   ,A.Market_Price
                                   ,A.ModifiedDuration
                                   ,'ADD'
                                   ,'" & CurrentUserWindowsID & "'
                                   ,GETDATE()
                                   from #Temp_SECURITIES_DailyPrice A INNER JOIN SECURITIES_OUR B
                                   on A.ISIN_Code=B.ISIN"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_SECURITIES_DailyPrice') IS NOT NULL 
                                   DROP TABLE #Temp_SECURITIES_DailyPrice"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price]
                                   ,A.[RIC]=B.[RIC],A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon]
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
                        QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                CloseSqlConnections()

                NewDP.Close()

                ALL_REPORTING_DATES_initData()
                ALL_REPORTING_DATES_InitLookUp()
                Me.BusinessDates_BarEditItem.EditValue = CType(BS_All_ReportingDates.Current, DataRowView).Item(0).ToString
                'Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, Datadate)

            End If


        Else
            XtraMessageBox.Show("Please enter the Business Date for the market prices!", "BUSINESS DATE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            NewDP.LiquidityDateEdit.Focus()
            Return


        End If


        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()

    End Sub

    Private Sub PrintExport_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintExport_bbi.ItemClick
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
        Dim reportfooter As String = "SECURITIES MARKET PRICE / MODIFIED DURATION  - " & BusinessDates_BarEditItem.EditValue.ToString & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub SecuritiesDailyPriceBaseView_DoubleClick(sender As Object, e As EventArgs) Handles SecuritiesDailyPriceBaseView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.IsFilterRow(view.FocusedRowHandle) = False And view.IsGroupRow(view.FocusedRowHandle) = False Then

            Try

                rd = CDate(view.GetFocusedRowCellValue("Date").ToString)
                rdsql = rd.ToString("yyyyMMdd")

                Dim dxOK_Mod_NewDP As New DevExpress.XtraEditors.SimpleButton
                With dxOK_Mod_NewDP
                    .Text = "Modify Market prices / Modified Duration"
                    .Height = 22
                    .Width = 238
                    .ImageList = NewDP.ImageCollection1
                    .ImageIndex = 7
                    .Location = New System.Drawing.Point(12, 603)
                End With
                NewDP.Text = "Modify Daily Market Price / Modified Duration"
                NewDP.Controls.Add(dxOK_Mod_NewDP)
                NewDP.DailyPrice_import_btn.Visible = False

                Dim objCMD As SqlCommand = New SqlCommand("Select 
                                                           A.ISIN_Code
                                                          ,A.Name
                                                          ,A.Ccy
                                                          ,SUM(B.PrincipalOrigAmt) as 'Nominal'
                                                          ,A.Market_Price as 'MarketPrice'
                                                          ,A.ModifiedDuration
                                                          ,B.MaturityDate 
                                                          from [SECURITIES_DailyPrice] A INNER JOIN SECURITIES_OUR B 
                                                          on A.ISIN_Code=B.ISIN and A.ContractNrOCBS=B.ContractNrOCBS
                                                          where A.[Date]='" & rdsql & "'
                                                          GROUP BY 
                                                          A.ISIN_Code
                                                         ,A.Name
                                                         ,A.Ccy
                                                         ,A.Market_Price
                                                         ,A.ModifiedDuration
                                                         ,B.MaturityDate", conn)
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
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, rd)
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

            OpenSqlConnections()

            Dim dt As New DataTable
            Dim r As DataRow
            dt.Columns.Add("Date", GetType(Date))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("ISIN_Code", GetType(String))
            dt.Columns.Add("MarketPrice", GetType(Double))
            dt.Columns.Add("ModifiedDuration", GetType(Double))

            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
            Dim result As String = cmd.ExecuteScalar
            If result <> "" Then
                If XtraMessageBox.Show("The Business Date: " & Datadate & " allready inserted to the daily market price Table!" & vbNewLine & "Should the current Data be overwritten with the current Market Prices/modified durations?", "BUSINESS DATE ALLREADY INSERTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'lösche alte daten
                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        If NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("MarketPrice")) < 0 Then
                            XtraMessageBox.Show("Please enter the Market Price for each Security/Bond greater than 0", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    Next

                    For i = 0 To NewDP.SecuritiesDailyPriceBaseView.RowCount - 1
                        r = dt.NewRow
                        r("Date") = NewDP.LiquidityDateEdit.Text
                        r("Name") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("Name"))
                        r("ISIN_Code") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ISIN_Code"))
                        r("MarketPrice") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("MarketPrice"))
                        r("ModifiedDuration") = NewDP.SecuritiesDailyPriceBaseView.GetRowCellValue(i, NewDP.SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ModifiedDuration"))
                        dt.Rows.Add(r)
                        'MsgBox(r("Name").ToString & "  " & r("ISIN_Code").ToString)
                    Next

                    cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_SECURITIES_DailyPrice') IS NOT NULL 
                                       DROP TABLE #Temp_SECURITIES_DailyPrice

                                       CREATE TABLE [#Temp_SECURITIES_DailyPrice]
                                       ([ID] [int] IDENTITY(1,1) NOT NULL,
                                       [Date] [datetime] NULL,
                                       [Name] [nvarchar](255) NULL,
                                       [ISIN_Code] [nvarchar](255) NULL,
                                       [Market_Price] [float] NULL,
                                       [ModifiedDuration] [float] NULL)"
                    cmd.ExecuteNonQuery()

                    For Each dr As DataRow In dt.Rows
                        'MsgBox(dr.Item(0).ToString & " " & dr.Item(1) & "  " & dr.Item(2) & "  " & dr.Item(3) & "  " & dr.Item(4))
                        Dim sc As New SqlCommand("INSERT INTO [#Temp_SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ModifiedDuration])" &
                                                 "VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                        sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.Parameters.AddWithValue("@column5", dr.Item(4))
                        sc.ExecuteNonQuery()
                    Next

                    cmd.CommandText = "INSERT INTO [SECURITIES_DailyPrice]
                                   ([Date]
                                   ,[Name]
                                   ,[ISIN_Code]
                                   ,[ContractNrOCBS]
                                   ,[Market_Price]
                                   ,[ModifiedDuration]
                                   ,[LastAction]
                                   ,[LastUpdateUser]
                                   ,[LastUpdateDate])
                               SELECT 
                                    A.Date 
                                   ,A.Name
                                   ,A.ISIN_Code
                                   ,B.ContractNrOCBS
                                   ,A.Market_Price
                                   ,A.ModifiedDuration
                                   ,'UPDATE'
                                   ,'" & CurrentUserWindowsID & "'
                                   ,GETDATE()
                                   from #Temp_SECURITIES_DailyPrice A INNER JOIN SECURITIES_OUR B
                                   on A.ISIN_Code=B.ISIN"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_SECURITIES_DailyPrice') IS NOT NULL 
                                   DROP TABLE #Temp_SECURITIES_DailyPrice"
                    cmd.ExecuteNonQuery()



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
                            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                    CloseSqlConnections()

                    NewDP.Close()


                    If Me.BusinessDates_BarEditItem.EditValue.ToString = "ALL" Then
                        Me.SECURITIES_DailyPriceTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_DailyPrice)
                        colDate.GroupIndex = 0
                        colDate.Visible = True
                        colDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                        Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = True
                    ElseIf Me.BusinessDates_BarEditItem.EditValue.ToString <> "ALL" AndAlso BS_All_ReportingDates.Count > 0 Then
                        Me.SECURITIES_DailyPriceTableAdapter.FillByBusinessDate(Me.SECURITIESDataset.SECURITIES_DailyPrice, Datadate)
                        colDate.GroupIndex = -1
                        colDate.Visible = False
                        Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = False
                    End If

                Else
                    Return
                End If

            End If


        Else
            XtraMessageBox.Show("Please enter the Business Date for the market prices!", "BUSINESS DATE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            NewDP.LiquidityDateEdit.Focus()
            Return


        End If


        'Me.SECURITIES_DailyPriceTableAdapter.Fill(SECURITIESDataset.SECURITIES_DailyPrice)
        'Me.SecuritiesDailyPriceBaseView.ExpandAllGroups()

    End Sub

    Private Sub Close_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Close_bbi.ItemClick
        Me.Close()
    End Sub
End Class