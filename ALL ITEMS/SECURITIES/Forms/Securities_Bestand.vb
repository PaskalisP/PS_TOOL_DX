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
Imports DevExpress.XtraReports.Parameters
Public Class Securities_Bestand

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable


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

    Private Sub SECURITIES_BESTANDBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SECURITIES_BESTANDBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)

    End Sub

    Private Sub Securities_Bestand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'SECURITIESDataset.SECURITIES_BESTAND' table. You can move, or remove it, as needed.
        Me.SECURITIES_BESTANDTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_BESTAND)

        Me.SecuritiesBestandBaseView.ExpandAllGroups()

        'Gridcontrol2 - SECURITIES
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = SecuritiesBestandBaseView
        SecuritiesBestandBaseView.ForceDoubleClick = True
        AddHandler SecuritiesBestandBaseView.DoubleClick, AddressOf SecuritiesBestandBaseView_DoubleClick
        AddHandler SecuritiesBestandDetailView.MouseDown, AddressOf SecuritiesBestandDetailView_MouseDown
        AddHandler SecuritiesBestandDetailView_btn.Click, AddressOf SecuritiesBestandDetailView_btn_Click
        SecuritiesBestandDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        SecuritiesBestandDetailView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "SECURITIES_BESTAND_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = SecuritiesBestandDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SecuritiesBestandBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        SecuritiesBestandDetailView_btn.Text = strShowExtendedMode
        SecuritiesBestandDetailView_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is SecuritiesBestandDetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        Dim datasourceRowIndex As Integer = SecuritiesBestandBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SecuritiesBestandDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        SecuritiesBestandDetailView_btn.Text = strHideExtendedMode
        SecuritiesBestandDetailView_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is SecuritiesBestandDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SecuritiesBestandBaseView.GetRowHandle(dataSourceRowIndex)
        SecuritiesBestandBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SecuritiesBestandDetailView.GetRowHandle(dataSourceRowIndex)
        SecuritiesBestandDetailView.VisibleRecordIndex = SecuritiesBestandDetailView.GetVisibleIndex(rowHandle)
        SecuritiesBestandDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub SecuritiesBestandBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = SecuritiesBestandBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub SecuritiesBestandDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = SecuritiesBestandDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub SecuritiesBestandDetailView_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub SecuritiesBestandBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SecuritiesBestandBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SecuritiesBestandBaseView_ShownEditor(sender As Object, e As EventArgs) Handles SecuritiesBestandBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub CreateNewBestand_btn_Click(sender As Object, e As EventArgs) Handles CreateNewBestand_btn.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='LIQUIDITY_RESERVE_USERS' and [PARAMETER STATUS]='Y' "
        Dim LiquidityReserveUserFind As String = cmd.ExecuteScalar
        If LiquidityReserveUserFind <> "" Then
            Try
                If IsDate(Me.BestandDateEdit.Text) = True Then
                    'Date to SQL String
                    Dim d As Date = Today
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    Dim Bestanddate As Date = Me.BestandDateEdit.Text
                    Dim DateSql As String = Bestanddate.ToString("yyyyMMdd")
                    Dim DateYearSql As String = Bestanddate.ToString("yyyy")
                    'Check if BestandDate allready exists
                    cmd.CommandText = "Select distinct [BestandDate] from [SECURITIES_BESTAND] where [BestandDate]='" & DateSql & "' "
                    Dim resultBD As String = cmd.ExecuteScalar
                    'Bestand Date not exists
                    If resultBD = "" Then
                        'Check if Liquidity Reserve exists with the same Bestand date
                        cmd.CommandText = "Select distinct [LiquidityDate] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                        Dim resultLD As String = cmd.ExecuteScalar
                        'Liquidity Date exists
                        If resultLD <> "" Then
                            'Insert to Securities Bestand from Table SECURITIES_LIQUIDITY_RESERVE
                            cmd.CommandText = "INSERT INTO [SECURITIES_BESTAND]([ISIN_Code],[SecurityName],[Ccy],[PrincipalEuroAmt],[MaturityDate],[Purchase_price],[StartofYear_price],[Market_Price],[Amt_Paid],[ValueAsOfDate],[OCBS_Booked_Later],[Buchwert],[TradeDate],[StartDate],[AssetType],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ]) SELECT [ISIN_Code],[SecurityName],[Ccy],[PrincipalEuroAmt],[MaturityDate],[Purchase_price],[StartofYear_price],[Market_Price],[Amt_Paid],[ValueAsOfDate],[Booked_Depreciation],[OCBS_Booked_Later],[TradeDate],[StartDate],[AssetType],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            'Update [BestandCreationDate] and [BestandDate]
                            cmd.CommandText = "UPDATE [SECURITIES_BESTAND] SET [BestandCreationDate]=' " & dsql & "',[BestandDate]=' " & DateSql & "' where [BestandCreationDate] is NULL "
                            cmd.ExecuteNonQuery()
                            '****************************************************************
                            '************SONDERFALL*****3 BUBA BONDS*****Amount Paid=Nominal
                            cmd.CommandText = "UPDATE [SECURITIES_BESTAND] SET [Amt_Paid]=[PrincipalEuroAmt]  where [ISIN_Code] in ('DE0001119931A','DE0001119931B','DE0001119956') and [BestandDate]=' " & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            '****************************************************************
                            '****************************************************************
                            'Update [StartofYear_Amt],[Buchwert]
                            cmd.CommandText = "SELECT * FROM [SECURITIES_BESTAND] Where [StartofYear_Amt] is NULL Begin UPDATE [SECURITIES_BESTAND] SET [StartofYear_Amt]=Round([PrincipalEuroAmt]* [StartofYear_price]/100,2) end "
                            cmd.ExecuteNonQuery()
                            'Update [BuchwertAbgrenzungen]
                            cmd.CommandText = "SELECT * FROM [SECURITIES_BESTAND] Where [BuchwertAbgrenzungen] is NULL Begin UPDATE [SECURITIES_BESTAND] SET [BuchwertAbgrenzungen]=[Buchwert]+[Accrued Interest Coupon EUR Equ] end "
                            cmd.ExecuteNonQuery()
                            'Update [AenderungLfdJahr]
                            Me.QueryText = "Select * from [SECURITIES_BESTAND] where [BestandDate]='" & DateSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                Dim ISINCODE As String = dt.Rows.Item(i).Item("ISIN_Code")
                                'Preis Einstand-Preis Aktuell
                                cmd.CommandText = "SELECT Price_Current= Case When [Purchase_price]>[Market_Price] Then Round([PrincipalEuroAmt]*[Market_Price]/100,2) When [Purchase_price]<=[Market_Price] Then Round([PrincipalEuroAmt]*[Purchase_price]/100,2) end FROM [SECURITIES_BESTAND] Where [BestandDate]='" & DateSql & "' and [ISIN_Code]='" & ISINCODE & "'"
                                Dim Price_Current As Double = cmd.ExecuteScalar
                                'Preis Einstand-Preis Aktuell
                                cmd.CommandText = "SELECT Price_StartYear= Case When [Purchase_price]>[StartofYear_price] Then Round([PrincipalEuroAmt]*[StartofYear_price]/100,2) When [Purchase_price]<=[StartofYear_price] Then Round([PrincipalEuroAmt]*[Purchase_price]/100,2)end FROM [SECURITIES_BESTAND] Where [BestandDate]='" & DateSql & "' and [ISIN_Code]='" & ISINCODE & "'"
                                Dim Price_StartYear As Double = 0
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    Price_StartYear = cmd.ExecuteScalar
                                Else
                                    Price_StartYear = 0
                                End If
                                'Update Änderung Lfd Jahr
                                Dim AenderungLfdJahr As Double = Price_Current - Price_StartYear
                                cmd.CommandText = "UPDATE [SECURITIES_BESTAND] SET [AenderungLfdJahr]=" & Str(AenderungLfdJahr) & " Where [BestandDate]='" & DateSql & "' and [ISIN_Code]='" & ISINCODE & "'"
                                cmd.ExecuteNonQuery()
                            Next
                            'Update [KursReserve]
                            cmd.CommandText = "SELECT * FROM [SECURITIES_BESTAND] Where [KursReserve] is NULL Begin UPDATE [SECURITIES_BESTAND] SET [KursReserve]=Round([PrincipalEuroAmt]*([Market_Price]-[Purchase_price])/100,2) where [Market_Price]>[Purchase_price] and [KursReserve] is NULL end Begin UPDATE [SECURITIES_BESTAND] SET [KursReserve]=0 where [Market_Price]<=[Purchase_price] and [KursReserve] is NULL end  "
                            cmd.ExecuteNonQuery()
                            'Update Client Nr.
                            cmd.CommandText = "UPDATE A SET A.[ClientNr]=B.[ClientNr] from [SECURITIES_BESTAND] A INNER JOIN [SECURITIES_OUR] B on A.[ISIN_Code]=B.ISIN where [BestandDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()

                            'Liquidity Date not exists
                        Else
                            MessageBox.Show("Unable to create SECURITIES BESTAND for the indicated Date-Liquidity Reserve Date is missing" & vbNewLine & "Please create Liquidity reserve for the indicated Date", "LIQUIDITY RESERVE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return
                        End If

                    Else
                        'Bestand Date exists
                        If MessageBox.Show("The Bestand Date is present in the current Table" & vbNewLine & "Should the Securities Bestand be re-created for the given Date?", "BESTAND DATE PRESENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            'Alte Daten löschen
                            cmd.CommandText = "DELETE FROM [SECURITIES_BESTAND] where [BestandDate]=' " & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            'Insert to Securities Bestand from Table SECURITIES_LIQUIDITY_RESERVE
                            cmd.CommandText = "INSERT INTO [SECURITIES_BESTAND]([ISIN_Code],[SecurityName],[Ccy],[PrincipalEuroAmt],[MaturityDate],[Purchase_price],[StartofYear_price],[Market_Price],[Amt_Paid],[ValueAsOfDate],[OCBS_Booked_Later],[Buchwert],[TradeDate],[StartDate],[AssetType],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ]) SELECT [ISIN_Code],[SecurityName],[Ccy],[PrincipalEuroAmt],[MaturityDate],[Purchase_price],[StartofYear_price],[Market_Price],[Amt_Paid],[ValueAsOfDate],[Booked_Depreciation],[OCBS_Booked_Later],[TradeDate],[StartDate],[AssetType],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            'Update [BestandCreationDate] and [BestandDate]
                            cmd.CommandText = "UPDATE [SECURITIES_BESTAND] SET [BestandCreationDate]=' " & dsql & "',[BestandDate]=' " & DateSql & "' where [BestandCreationDate] is NULL "
                            cmd.ExecuteNonQuery()
                            '****************************************************************
                            '************SONDERFALL*****3 BUBA BONDS*****Amount Paid=Nominal
                            cmd.CommandText = "UPDATE [SECURITIES_BESTAND] SET [Amt_Paid]=[PrincipalEuroAmt]  where [ISIN_Code] in ('DE0001119931A','DE0001119931B','DE0001119956') and [BestandDate]=' " & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            '****************************************************************
                            '****************************************************************
                            'Update [StartofYear_Amt],[Buchwert]
                            cmd.CommandText = "SELECT * FROM [SECURITIES_BESTAND] Where [StartofYear_Amt] is NULL Begin UPDATE [SECURITIES_BESTAND] SET [StartofYear_Amt]=Round([PrincipalEuroAmt]* [StartofYear_price]/100,2) end "
                            cmd.ExecuteNonQuery()
                            'Update [BuchwertAbgrenzungen]
                            cmd.CommandText = "SELECT * FROM [SECURITIES_BESTAND] Where [BuchwertAbgrenzungen] is NULL Begin UPDATE [SECURITIES_BESTAND] SET [BuchwertAbgrenzungen]=[Buchwert]+[Accrued Interest Coupon EUR Equ] end "
                            cmd.ExecuteNonQuery()
                            'Update [AenderungLfdJahr]
                            Me.QueryText = "Select * from [SECURITIES_BESTAND] where [BestandDate]='" & DateSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                Dim ISINCODE As String = dt.Rows.Item(i).Item("ISIN_Code")
                                'Preis Einstand-Preis Aktuell
                                cmd.CommandText = "SELECT Price_Current= Case When [Purchase_price]>[Market_Price] Then Round([PrincipalEuroAmt]*[Market_Price]/100,2) When [Purchase_price]<=[Market_Price] Then Round([PrincipalEuroAmt]*[Purchase_price]/100,2) end FROM [SECURITIES_BESTAND] Where [BestandDate]='" & DateSql & "' and [ISIN_Code]='" & ISINCODE & "'"
                                Dim Price_Current As Double = cmd.ExecuteScalar
                                'Preis Einstand-Preis Aktuell
                                cmd.CommandText = "SELECT Price_StartYear= Case When [Purchase_price]>[StartofYear_price] Then Round([PrincipalEuroAmt]*[StartofYear_price]/100,2) When [Purchase_price]<=[StartofYear_price] Then Round([PrincipalEuroAmt]*[Purchase_price]/100,2)end FROM [SECURITIES_BESTAND] Where [BestandDate]='" & DateSql & "' and [ISIN_Code]='" & ISINCODE & "'"
                                Dim Price_StartYear As Double = 0
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    Price_StartYear = cmd.ExecuteScalar
                                Else
                                    Price_StartYear = 0
                                End If
                                'Update Änderung Lfd Jahr
                                Dim AenderungLfdJahr As Double = Price_Current - Price_StartYear
                                cmd.CommandText = "UPDATE [SECURITIES_BESTAND] SET [AenderungLfdJahr]=" & Str(AenderungLfdJahr) & " Where [BestandDate]='" & DateSql & "' and [ISIN_Code]='" & ISINCODE & "'"
                                cmd.ExecuteNonQuery()
                            Next
                            'Update [KursReserve]
                            cmd.CommandText = "SELECT * FROM [SECURITIES_BESTAND] Where [KursReserve] is NULL Begin UPDATE [SECURITIES_BESTAND] SET [KursReserve]=Round([PrincipalEuroAmt]*([Market_Price]-[Purchase_price])/100,2) where [Market_Price]>[Purchase_price] and [KursReserve] is NULL end Begin UPDATE [SECURITIES_BESTAND] SET [KursReserve]=0 where [Market_Price]<=[Purchase_price] and [KursReserve] is NULL end  "
                            cmd.ExecuteNonQuery()
                            'Update Client Nr.
                            cmd.CommandText = "UPDATE A SET A.[ClientNr]=B.[ClientNr] from [SECURITIES_BESTAND] A INNER JOIN [SECURITIES_OUR] B on A.[ISIN_Code]=B.ISIN where [BestandDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
                'Connection close
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.SECURITIES_BESTANDTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_BESTAND)
                Me.SecuritiesBestandBaseView.ExpandAllGroups()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Connection close
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.SECURITIES_BESTANDTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_BESTAND)
                Me.SecuritiesBestandBaseView.ExpandAllGroups()
                Exit Sub
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show("Unable to create Securities Bestand", "ERROR - USER IS NOT AUTHORIZED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub

 
    Private Sub SecuritiesBestandReport_btn_Click(sender As Object, e As EventArgs) Handles SecuritiesBestandReport_btn.Click
        'Get the max Date in Liquidity reserve
        cmd.CommandText = "Select Max([BestandDate]) from [SECURITIES_BESTAND]"
        cmd.Connection.Open()
        Dim BestandDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()

        ' Create a report instance.
        Dim report As New LiquidityBestandXtraReport


        ' Create a parameter and specify its name.
        Dim param1 As New Parameter()
        param1.Name = "BestandDate"

        ' Specify other parameter properties.
        param1.Type = GetType(System.DateTime)
        param1.Value = BestandDate
        param1.Description = "Bestand Date: "
        param1.Visible = True

        ' Add the parameter to the report.
        report.Parameters.Add(param1)
        report.Parameters("BestandDate").Value = BestandDate

        ' Specify the report's filter string.
        report.FilterString = "[BestandDate] = [Parameters.BestandDate]"

        ' Force the report creation without previously 
        ' requesting the parameter value from end-users.
        report.RequestParameters = False


        ' Show the parameter's value on a Report Header band.
        'Dim label As New XRLabel()
        'label.DataBindings.Add(New XRBinding(param1, "Text", "Exchange Rate Date: {0}"))
        'Dim reportHeader As New ReportHeaderBand()
        'reportHeader.Controls.Add(label)
        'report.Bands.Add(reportHeader)

        ' Assign the report to a ReportPrintTool,
        ' to hide the Parameters panel,
        ' and show the report's print preview.
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = True
        pt.ShowRibbonPreview(UserLookAndFeel.Default)
    End Sub

    Private Sub Securities_Bestand_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Securities_Bestand_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If Me.SecuritiesBestandDetailView_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.SecuritiesBestandDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.SecuritiesBestandDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.SecuritiesBestandDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.SecuritiesBestandDetailView.OptionsPrint.PrintCardCaption = True
            Me.SecuritiesBestandDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.SecuritiesBestandDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.SecuritiesBestandDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.SecuritiesBestandDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.SecuritiesBestandDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
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
            iSize = e.Graph.MeasureString(String.Format("CCB Frankfurt - SECURITIES BESTAND" & vbNewLine & "Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "CCB Frankfurt - SECURITIES BESTAND" & vbNewLine & "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "CCB Frankfurt - SECURITIES BESTAND"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        'e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        'e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

   
End Class