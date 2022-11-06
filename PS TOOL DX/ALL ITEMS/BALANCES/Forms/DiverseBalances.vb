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

Public Class DiverseBalances

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

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

    Private Sub DIVERSE_VOLUMESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.DIVERSE_VOLUMESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub DiverseBalances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn


        Me.DIVERSE_MAPPINGTableAdapter.Fill(Me.BalancesDataset.DIVERSE_MAPPING)
        Me.DIVERSE_GL_ITEMSTableAdapter.Fill(Me.BalancesDataset.DIVERSE_GL_ITEMS)

        Me.ComboBoxEdit1.Text = "***"

    End Sub

    Private Sub LoadGL_btn_Click(sender As Object, e As EventArgs) Handles LoadGL_btn.Click
        If IsNothing(Me.GL_LookUpEdit.Text) = False AndAlso IsNumeric(Me.GL_LookUpEdit.Text) = True AndAlso _
          IsDate(Me.GL_BookingDate_From.Text) = True AndAlso IsDate(Me.GL_BookingDate_Till.Text) = True Then
            d1 = Me.GL_BookingDate_From.Text
            d2 = Me.GL_BookingDate_Till.Text
            sqld1 = d1.ToString("yyyyMMdd")
            sqld2 = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then
                
                Try
                    'GL ITEM Name finden
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.CommandTimeout = 120
                    cmd.CommandText = "SELECT [GL_ITEM_NAME] from [DIVERSE_GL_ITEMS] where [GL_ITEM_NR]='" & Me.GL_LookUpEdit.Text & "'"
                    cmd.Connection.Open()
                    Me.LabelControl8.Text = cmd.ExecuteScalar
                    GLItemlbl = Me.GL_LookUpEdit.Text
                    GLitemNamelbl = Me.LabelControl8.Text
                    GLitemDatefromlbl = Me.GL_BookingDate_From.Text
                    GLitemDatetilllbl = Me.GL_BookingDate_Till.Text

                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Postings and Balances for GL Item: " & Me.GL_LookUpEdit.Text & " from: " & d1 & " till " & d2)
                   

                    Dim objCMD As SqlCommand = New SqlCommand("SELECT * FROM DIVERSE_VOLUMES WHERE (GL_Item_Nr = '" & Me.GL_LookUpEdit.Text & "') AND (GL_Rep_Date >= '" & sqld1 & "') AND (GL_Rep_Date <= '" & sqld2 & "') ORDER BY IdNr", conn)
                    objCMD.CommandTimeout = 5000
                    da = New SqlDataAdapter(objCMD)

                    'OPENING BALANCE FOR GL ITEM
                    cmd.CommandText = "SELECT [AmountInEuro] from [DIVERSE_VOLUMES] where [GL_Item_Nr]='" & Me.GL_LookUpEdit.Text & "' and [BatchNo]='GL ITEM OPENING BALANCE' and [GL_Rep_Date]='" & sqld1 & "'"
                    Dim obglitem As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        obglitem = cmd.ExecuteScalar
                    End If
                    Me.LabelControl9.Text = "OPENING BALANCE GL ITEM: " & "  " _
                        & Me.GL_LookUpEdit.Text & " on" & "  " & Me.GL_BookingDate_From.Text & "  " & "  " _
                        & "EUR" & " " & Format(obglitem, "#,##0.00")
                    GLitemStartBalancelbl = Me.LabelControl9.Text

                    'CLOSING BALANCE FOR GL ITEM
                    cmd.CommandText = "SELECT [AmountInEuro] from [DIVERSE_VOLUMES] where [GL_Item_Nr]='" & Me.GL_LookUpEdit.Text & "' and [BatchNo]='GL ITEM CLOSING BALANCE' and [GL_Rep_Date]='" & sqld2 & "'"
                    Dim cbglitem As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        cbglitem = cmd.ExecuteScalar
                    End If
                    Me.LabelControl10.Text = "CLOSING BALANCE GL ITEM: " & "  " _
                        & Me.GL_LookUpEdit.Text & " on" & "  " & Me.GL_BookingDate_Till.Text & "  " & "  " _
                        & "EUR" & " " & Format(cbglitem, "#,##0.00")
                    GLitemClosingBalancelbl = Me.LabelControl10.Text

                    Me.SearchText_lbl.Text = "Search results by GL ITEM (" & Me.GL_LookUpEdit.Text & ")- from " & d1 & " till " & d2

                    Me.GridControl1.MainView = Diverse_Balances_BasicView

                    dt = New DataTable()
                    da.Fill(dt)
                    'Results
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Me.GridControl1.DataSource = Nothing
                        Me.GridControl1.DataSource = dt
                        Me.GridControl1.ForceInitialize()
                        SplashScreenManager.CloseForm(False)

                    Else
                        SplashScreenManager.CloseForm(False)
                        Me.GridControl1.DataSource = Nothing
                        MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If



                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SplashScreenManager.CloseForm(False)
                End Try

            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Else
            MessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub LoadOCBS_btn_Click(sender As Object, e As EventArgs) Handles LoadOCBS_btn.Click
        If IsNothing(Me.OCBS_LookUpEdit.Text) = False AndAlso IsNumeric(Me.OCBS_LookUpEdit.Text) = True AndAlso _
         IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then
            d1 = Me.OCBS_BookingDate_From.Text
            d2 = Me.OCBS_BookingDate_Till.Text
            sqld1 = d1.ToString("yyyyMMdd")
            sqld2 = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then
                Try
                    'GL ITEM Name finden
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.CommandTimeout = 120
                    cmd.CommandText = "SELECT [GL_ACC_Name] from [DIVERSE_MAPPING] where [GL_ACC_Nr]='" & Me.OCBS_LookUpEdit.Text & "'"
                    cmd.Connection.Open()
                    Me.LabelControl5.Text = cmd.ExecuteScalar
                    OCBSaccountNamelbl = Me.LabelControl5.Text
                    OCBSaccountlbl = Me.OCBS_LookUpEdit.Text
                    OCBSaccountCurlbl = Me.ComboBoxEdit1.Text
                    OCBSDatefromlbl = Me.OCBS_BookingDate_From.Text
                    OCBSDatetilllbl = Me.OCBS_BookingDate_Till.Text


                    If Me.ComboBoxEdit1.Text = "***" Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Postings and Balances for OCBS Account: " & Me.OCBS_LookUpEdit.Text & " from: " & d1 & " till " & d2)
                        
                        Dim objCMD As SqlCommand = New SqlCommand("SELECT * FROM [DIVERSE_VOLUMES] WHERE (GL_AC_No = '" & Me.OCBS_LookUpEdit.Text & "') AND (GL_Rep_Date >= '" & sqld1 & "') AND (GL_Rep_Date <= '" & sqld2 & "') ORDER BY IdNr", conn)
                        objCMD.CommandTimeout = 5000
                        da = New SqlDataAdapter(objCMD)

                        'OPENING BALANCE FOR OCBS ACCOUNT
                        cmd.CommandText = "SELECT Sum([AmountInEuro]) from [DIVERSE_VOLUMES] where [GL_AC_No]='" & Me.OCBS_LookUpEdit.Text & "' and [BatchNo]='OPENING BALANCE OCBS ACC.' and [GL_Rep_Date]='" & sqld1 & "'"
                        Dim obglitem As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            obglitem = cmd.ExecuteScalar
                        End If
                        Me.LabelControl4.Text = "OPENING BALANCE OCBS ACCOUNT: " & "  " _
                                                & Me.OCBS_LookUpEdit.Text & " on" & "  " & Me.OCBS_BookingDate_From.Text & "  " & "  " _
                                                & "EUR" & " " & Format(obglitem, "#,##0.00")
                        OCBSstartingBalancelbl = Me.LabelControl4.Text

                        'CLOSING BALANCE FOR OCBS ACCOUNT
                        cmd.CommandText = "SELECT Sum([AmountInEuro]) from [DIVERSE_VOLUMES] where [GL_AC_No]='" & Me.OCBS_LookUpEdit.Text & "' and [BatchNo]='CLOSING BALANCE OCBS ACC.' and [GL_Rep_Date]='" & sqld2 & "'"
                        Dim cbglitem As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            cbglitem = cmd.ExecuteScalar
                        End If
                        Me.LabelControl3.Text = "CLOSING BALANCE OCBS ACCOUNT: " & "  " _
                                                & Me.OCBS_LookUpEdit.Text & " on" & "  " & Me.OCBS_BookingDate_Till.Text & "  " & "  " _
                                                & "EUR" & " " & Format(cbglitem, "#,##0.00")
                        OCBSclosingBalancelbl = Me.LabelControl3.Text

                        Me.SearchText_lbl.Text = "Search results by OCBS Account (" & Me.OCBS_LookUpEdit.Text & ")-" & OCBSaccountNamelbl & " - ALL CURRENCIES - " & "from " & d1 & " till " & d2

                        Me.GridControl1.MainView = OCBS_Balances_BasicView
                        dt = New DataTable()
                        da.Fill(dt)
                        'Results
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Me.GridControl1.DataSource = Nothing
                            Me.GridControl1.DataSource = dt
                            Me.GridControl1.ForceInitialize()
                            SplashScreenManager.CloseForm(False)

                        Else
                            SplashScreenManager.CloseForm(False)
                            Me.GridControl1.DataSource = Nothing
                            MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If


                    Else

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Postings and Balances for OCBS Account: " & Me.OCBS_LookUpEdit.Text & " from: " & d1 & " till " & d2 & " for CURRENCY: " & Me.ComboBoxEdit1.Text)
                        
                        Dim objCMD As SqlCommand = New SqlCommand("execute [DIVERSE_VOLUMES_OCBS_ACC_CUR]  @FROMDATE='" & sqld1 & "', @TILLDATE='" & sqld2 & "',@GL_ACCOUNT_NR='" & Me.OCBS_LookUpEdit.Text & "',@CUR= '" & Me.ComboBoxEdit1.Text & "' ", conn)
                        objCMD.CommandTimeout = 5000
                        da = New SqlDataAdapter(objCMD)

                        'OPENING BALANCE FOR OCBS ACCOUNT
                        cmd.CommandText = "SELECT Sum([AmountInEuro]) from [DIVERSE_VOLUMES] where [GL_AC_No]='" & Me.OCBS_LookUpEdit.Text & "' and [BatchNo]='OPENING BALANCE OCBS ACC.' and [GL_Rep_Date]='" & sqld1 & "' and [CCY]='" & Me.ComboBoxEdit1.Text & "'"
                        Dim obglitem As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            obglitem = cmd.ExecuteScalar
                        End If
                        Me.LabelControl4.Text = "OPENING BALANCE OCBS ACCOUNT: " & "  " _
                                                & Me.OCBS_LookUpEdit.Text & " on" & "  " & Me.OCBS_BookingDate_From.Text & "  " & "  " _
                                                & Me.ComboBoxEdit1.Text & " " & Format(obglitem, "#,##0.00")
                        OCBSstartingBalancelbl = Me.LabelControl4.Text

                        'CLOSING BALANCE FOR OCBS ACCOUNT
                        cmd.CommandText = "SELECT Sum([AmountInEuro]) from [DIVERSE_VOLUMES] where [GL_AC_No]='" & Me.OCBS_LookUpEdit.Text & "' and [BatchNo]='CLOSING BALANCE OCBS ACC.' and [GL_Rep_Date]='" & sqld2 & "' and [CCY]='" & Me.ComboBoxEdit1.Text & "'"
                        Dim cbglitem As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            cbglitem = cmd.ExecuteScalar
                        End If
                        Me.LabelControl3.Text = "CLOSING BALANCE OCBS ACCOUNT: " & "  " _
                                                & Me.OCBS_LookUpEdit.Text & " on" & "  " & Me.OCBS_BookingDate_Till.Text & "  " & "  " _
                                                & Me.ComboBoxEdit1.Text & " " & Format(cbglitem, "#,##0.00")
                        OCBSclosingBalancelbl = Me.LabelControl3.Text

                        Me.SearchText_lbl.Text = "Search results by OCBS Account (" & Me.OCBS_LookUpEdit.Text & ") -" & OCBSaccountNamelbl & "-" & Me.ComboBoxEdit1.Text & " from " & d1 & " till " & d2

                        Me.GridControl1.MainView = OCBS_Balances_BasicView
                        dt = New DataTable()
                        da.Fill(dt)
                        'Results
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Me.GridControl1.DataSource = Nothing
                            Me.GridControl1.DataSource = dt
                            Me.GridControl1.ForceInitialize()
                            SplashScreenManager.CloseForm(False)

                        Else
                            SplashScreenManager.CloseForm(False)
                            Me.GridControl1.DataSource = Nothing
                            MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If


                    End If



                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SplashScreenManager.CloseForm(False)
                End Try

            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Else
            MessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then
            d1 = Me.OCBS_BookingDate_From.Text
            d2 = Me.OCBS_BookingDate_Till.Text
            sqld1 = d1.ToString("yyyyMMdd")
            sqld2 = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Postings for all mapped OCBS Accounts from: " & d1 & " till " & d2)
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                   
                    Dim objCMD As SqlCommand = New SqlCommand("execute [DIVERSE_VOLUMES_OCBS_ACC_ALL_VOLUMES]  @FROMDATE='" & sqld1 & "', @TILLDATE='" & sqld2 & "' ", conn)
                    objCMD.CommandTimeout = 5000
                    da = New SqlDataAdapter(objCMD)

                    Me.GridControl1.MainView = OCBS_Postings_BasicView
                    Me.SearchText_lbl.Text = "Postings of all mapped OCBS Accounts from: " & d1 & " till " & d2
                    dt = New DataTable()
                    da.Fill(dt)
                    'Results
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Me.GridControl1.DataSource = Nothing
                        Me.GridControl1.DataSource = dt
                        Me.GridControl1.ForceInitialize()
                        SplashScreenManager.CloseForm(False)

                    Else
                        SplashScreenManager.CloseForm(False)
                        Me.GridControl1.DataSource = Nothing
                        MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    SplashScreenManager.CloseForm(False)
                End Try
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
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
        If Me.SearchText_lbl.Text.StartsWith("Search results by GL ITEM") = True Then
            Dim reportfooter As String = "UMSATZABFRAGE für GL Item" & GLItemlbl & " (" & GLitemNamelbl & ")" & "von " & d1 & " bis " & d2
            e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        ElseIf Me.SearchText_lbl.Text.StartsWith("Search results by OCBS Account") = True Then
            Dim currency As String = ""
            If OCBSaccountCurlbl = "***" Then
                currency = "FÜR ALLE WÄHRUNGEN"
            Else
                currency = OCBSaccountCurlbl
            End If
            Dim reportfooter As String = "UMSATZABFRAGE für OCBS Konto" & OCBSaccountlbl & " (" & OCBSaccountNamelbl & ")" & currency & " von " & d1 & " bis " & d2
             e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        ElseIf Me.SearchText_lbl.Text.StartsWith("Postings of all mapped OCBS Accounts") = True Then
            Dim specialFindtext As String = Me.OCBS_Postings_BasicView.FindFilterText.ToString
            If specialFindtext <> "" Then
                Dim reportfooter As String = "UMSATZABFRAGE für alle OCBS Konten" & "von " & d1 & " bis " & d2 & " Gesucht nach: " & specialFindtext
                e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
            Else
                Dim reportfooter As String = "UMSATZABFRAGE für alle OCBS Konten" & " von " & d1 & " bis " & d2
                 e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
            End If


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

    Private Sub PrintableComponentLink1_CreateReportFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateReportFooterArea
        If Me.SearchText_lbl.Text.StartsWith("Search results by GL ITEM") = True Then
            Dim reportfooter As String = GLitemNamelbl & "  " & GLitemClosingBalancelbl
            e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        ElseIf Me.SearchText_lbl.Text.StartsWith("Search results by OCBS Account") = True Then
            Dim reportfooter As String = OCBSaccountNamelbl & " " & OCBSclosingBalancelbl
            e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        End If

    End Sub

    Private Sub PrintableComponentLink1_CreateReportHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateReportHeaderArea
        If Me.SearchText_lbl.Text.StartsWith("Search results by GL ITEM") = True Then
            Dim reportHeader As String = GLitemNamelbl & "  " & GLitemStartBalancelbl
            e.Graph.DrawString(reportHeader, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        ElseIf Me.SearchText_lbl.Text.StartsWith("Search results by OCBS Account") = True Then
            Dim reportHeader As String = OCBSaccountNamelbl & "  " & OCBSstartingBalancelbl
           e.Graph.DrawString(reportHeader, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        End If

    End Sub

    Private Sub OCBS_Balances_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OCBS_Balances_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OCBS_Postings_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OCBS_Postings_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Diverse_Balances_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Diverse_Balances_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OCBS_Balances_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles OCBS_Balances_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OCBS_Postings_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles OCBS_Postings_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Diverse_Balances_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Diverse_Balances_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

End Class