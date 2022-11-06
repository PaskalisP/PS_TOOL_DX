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
Public Class SwiftStatementsAll

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private objDataTable As New DataTable

    Dim d1 As Date
    Dim d2 As Date
    Dim sqld1 As String = Nothing
    Dim sqld2 As String = Nothing
    Dim rdsql1 As String
    Dim rdsql2 As String

    Dim GLItemlbl As String = Nothing
    Dim GLitemNamelbl As String = Nothing
    Dim GLitemDatefromlbl As String = Nothing
    Dim GLitemDatetilllbl As String = Nothing
    Dim GLitemStartBalancelbl As String = Nothing
    Dim GLitemClosingBalancelbl As String = Nothing

    Dim OCBSaccountNamelbl As String = Nothing
    Dim OCBSaccountlbl As String = Nothing
    Dim OCBSaccountCurlbl As String = Nothing
    Dim OCBSDatefromlbl As String = Nothing
    Dim OCBSDatetilllbl As String = Nothing
    Dim OCBSstartingBalancelbl As String = Nothing
    Dim OCBSclosingBalancelbl As String = Nothing

    Private BS_ExternalAccounts As BindingSource

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

    Private Sub SWIFT_ACC_STATEMENTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SWIFT_ACC_STATEMENTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub SwiftStatementsAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.CURlbl.Text = ""
        Me.Nostro_Balances_BasicView.ActiveFilterString = "[SwiftTagName] NOT LIKE 'Intermed%'"

        EXTERNAL_ACCOUNTS_initData()
        EXTERNAL_ACCOUNTS_InitLookUp()

        GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl1.MainView = Me.Nostro_Balances_BasicView
        Nostro_Balances_BasicView.ForceDoubleClick = True
        AddHandler Nostro_Balances_BasicView.DoubleClick, AddressOf Nostro_Balances_BasicView_DoubleClick
        AddHandler Nostro_Balances_DetailView.MouseDown, AddressOf Nostro_Balances_DetailView_MouseDown
        AddHandler Edit_BICDIR_Details_btn.Click, AddressOf Edit_BICDIR_Details_btn_Click
        Nostro_Balances_DetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        Nostro_Balances_DetailView.OptionsBehavior.AllowSwitchViewModes = False

        'Get Forelast Date and fill DateEdits
        Dim d1 As Date = DateAdd(DateInterval.Day, -1, Today)
        Dim d2 As Date = Today
        OCBS_BookingDate_From.EditValue = d1
        OCBS_BookingDate_Till.EditValue = d2

    End Sub

#Region "NOSTRO_STATEMENTS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl1.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = Nostro_Balances_DetailView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = Nostro_Balances_BasicView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Edit_BICDIR_Details_btn.Text = strShowExtendedMode
        Edit_BICDIR_Details_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl1.MainView Is Nostro_Balances_DetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = Nostro_Balances_BasicView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = Nostro_Balances_DetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Edit_BICDIR_Details_btn.Text = strHideExtendedMode
        Edit_BICDIR_Details_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl1.MainView Is Nostro_Balances_DetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = Nostro_Balances_BasicView.GetRowHandle(dataSourceRowIndex)
        Nostro_Balances_BasicView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = Nostro_Balances_DetailView.GetRowHandle(dataSourceRowIndex)
        Nostro_Balances_DetailView.VisibleRecordIndex = Nostro_Balances_DetailView.GetVisibleIndex(rowHandle)
        Nostro_Balances_DetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub Nostro_Balances_BasicView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = Nostro_Balances_BasicView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub Nostro_Balances_DetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = Nostro_Balances_DetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub Edit_BICDIR_Details_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

#Region "LOAD EXTERNAL ACCOUNTS"
    Private Sub EXTERNAL_ACCOUNTS_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbExternalAccounts As SqlDataAdapter = New SqlDataAdapter("Select [SQL_Name_1] as 'External Account Nr.',[SQL_Name_2] as 'CCY',[SQL_Name_3] as 'Sender BIC',[SQL_Name_4] as 'Sender BIC Name' from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL' order by [SQL_Name_4] asc", conn) '
        Try

            dbExternalAccounts.Fill(ds, "SQL_PARAMETER_DETAILS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_ExternalAccounts = New BindingSource(ds, "SQL_PARAMETER_DETAILS")
    End Sub
    Private Sub EXTERNAL_ACCOUNTS_InitLookUp()
        Me.OCBS_LookUpEdit.Properties.DataSource = BS_ExternalAccounts
        Me.OCBS_LookUpEdit.Properties.DisplayMember = "External Account Nr."
        Me.OCBS_LookUpEdit.Properties.ValueMember = "External Account Nr."
    End Sub
#End Region


    Private Sub LoadOCBS_btn_Click(sender As Object, e As EventArgs) Handles LoadOCBS_btn.Click
        If IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then

            d1 = Me.OCBS_BookingDate_From.Text
            d2 = Me.OCBS_BookingDate_Till.Text
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")
                'ALL SEARCH ITEMS
                If IsNothing(Me.OCBS_LookUpEdit.Text) = False Then
                    Try
                      
                        'Account Name finden
                        Me.QueryText = "Select [SQL_Name_1] as 'External Account Nr.',[SQL_Name_2] as 'CCY',[SQL_Name_3] as 'Sender BIC',[SQL_Name_4] as 'Sender BIC Name' from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL' and [SQL_Name_1]='" & Me.OCBS_LookUpEdit.Text & "'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)

                        Me.CURlbl.Text = dt.Rows.Item(0).Item("CCY")
                        Me.NostroAccountNamelbl.Text = dt.Rows.Item(0).Item("Sender BIC Name")

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load external postings + Balances for external Nostro Account: " & vbNewLine & Me.OCBS_LookUpEdit.Text & " from: " & d1 & " till " & d2)


                        'Dim objCMD As SqlCommand = New SqlCommand("execute [SWIFT_ACCOUNT_STATEMENTS_ALL] @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "',@ACCOUNT_NR='" & Me.OCBS_LookUpEdit.Text & "'  ", conn)
                        'objCMD.CommandTimeout = 5000
                        'da = New SqlDataAdapter(objCMD)

                        'Data reader
                        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            Using sqlCmd As New SqlCommand()
                                sqlCmd.CommandText = "SELECT * FROM [SWIFT_ACC_STATEMENTS] WHERE ([AccountIdentification]= '" & Me.OCBS_LookUpEdit.Text & "') AND ([ReceivedDate] >= '" & rdsql1 & "') AND ([ReceivedDate] <= '" & rdsql2 & "') ORDER BY  PageNr asc,Case SwiftTag when '60F' then 1 when '60M' then 2 when '61' then 3 when '62M' then 4 when '62F' then 5 when '64' then 6 when '65' then 7 end, StatementNr asc "
                                sqlCmd.Connection = sqlConn
                                sqlCmd.CommandTimeout = 5000
                                If sqlConn.State = ConnectionState.Closed Then
                                    sqlConn.Open()
                                End If

                                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                                objDataTable.Clear()
                                objDataTable.Load(objDataReader)

                                If sqlConn.State = ConnectionState.Open Then
                                    sqlConn.Close()
                                End If

                            End Using
                        End Using

                        Me.SearchText_lbl.Text = "Search results for External Nostro Account: " & Me.OCBS_LookUpEdit.Text & " -Currency: " & Me.CURlbl.Text & " from " & d1 & " till " & d2
                        'Me.colNostroCode.Visible = False
                        'Me.colNostroName.Visible = False
                        'dt = New DataTable()
                        'da.Fill(dt)
                        'Results Datareader
                        If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                            Me.GridControl1.DataSource = Nothing
                            Me.GridControl1.DataSource = objDataTable
                            Me.GridControl1.ForceInitialize()
                            SplashScreenManager.CloseForm(False)

                        Else
                            SplashScreenManager.CloseForm(False)
                            Me.GridControl1.DataSource = Nothing
                            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                      
                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        SplashScreenManager.CloseForm(False)
                    End Try



                End If
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If Edit_BICDIR_Details_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.Nostro_Balances_DetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.Nostro_Balances_DetailView.OptionsPrint.PrintCardCaption = True
            Me.Nostro_Balances_DetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.Nostro_Balances_DetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.BICLayoutView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel)
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True

        End If

    End Sub
    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        If Me.SearchText_lbl.Text.StartsWith("Search results for External Nostro Account:") = True Then
            Dim reportfooter As String = "ABFRAGE (Externe Buchungen + Salden) für Externes NOSTRO Konto " & Me.OCBS_LookUpEdit.Text & " (" & Me.CURlbl.Text & ")" & Me.NostroAccountNamelbl.Text & " von " & d1 & " bis " & d2
            e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
            'ElseIf Me.SearchText_lbl.Text.StartsWith("Search results for the last Nostro Accounts Balances") = True Then
            'Dim reportfooter As String = "ABFRAGE (Letzte Salden) für alle NOSTRO Konten"
            'e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        End If

        'Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        'Try
        'iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
        'r = New RectangleF(New PointF(0, 0), iSize)
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        'pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub Nostro_Balances_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Nostro_Balances_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Nostro_Balances_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Nostro_Balances_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub OCBS_LookUpEdit_Click(sender As Object, e As EventArgs) Handles OCBS_LookUpEdit.Click
        Me.GridControl1.DataSource = Nothing
        Me.SearchText_lbl.Text = ""
        Me.CURlbl.Text = ""
        Me.NostroAccountNamelbl.Text = ""
    End Sub

    Private Sub OCBS_LookUpEdit_Leave(sender As Object, e As EventArgs) Handles OCBS_LookUpEdit.Leave
        'Account Name finden
        If Me.OCBS_LookUpEdit.Text <> "" Then
            Me.QueryText = "Select [SQL_Name_1] as 'External Account Nr.',[SQL_Name_2] as 'CCY',[SQL_Name_3] as 'Sender BIC',[SQL_Name_4] as 'Sender BIC Name' from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL' and [SQL_Name_1]='" & Me.OCBS_LookUpEdit.Text & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)

            Me.CURlbl.Text = dt.Rows.Item(0).Item("CCY")
            Me.NostroAccountNamelbl.Text = dt.Rows.Item(0).Item("Sender BIC Name")
        End If

    End Sub

    Private Sub OCBS_LookUpEdit_TextChanged(sender As Object, e As EventArgs) Handles OCBS_LookUpEdit.TextChanged
        'Account Name finden
        If Me.OCBS_LookUpEdit.Text <> "" Then
            Me.QueryText = "Select [SQL_Name_1] as 'External Account Nr.',[SQL_Name_2] as 'CCY',[SQL_Name_3] as 'Sender BIC',[SQL_Name_4] as 'Sender BIC Name' from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL' and [SQL_Name_1]='" & Me.OCBS_LookUpEdit.Text & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)

            Me.CURlbl.Text = dt.Rows.Item(0).Item("CCY")
            Me.NostroAccountNamelbl.Text = dt.Rows.Item(0).Item("Sender BIC Name")
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

End Class