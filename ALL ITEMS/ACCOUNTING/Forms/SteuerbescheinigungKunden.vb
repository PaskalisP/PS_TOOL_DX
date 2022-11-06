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
Imports DevExpress.XtraBars.Alerter

Public Class SteuerbescheinigungKunden
    Friend WithEvents Alert_PLZ_EAEG_Steuer As New AlertControl
    Friend WithEvents Timer_PLZ_EAEG_Kunden As New System.Windows.Forms.Timer
    'For Allerts
    Dim PLZ_EAEG_TextEdit As New DevExpress.XtraEditors.TextEdit

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATESFORM_ACC As New AccDatesForm
    Dim DATESFORM_ACC_JAHR_ALL As New AccDatesForm
    Dim DATESFORM_ACC_JAHR_SINGLE As New AccDatesForm

    Dim dxOK_MM As New DevExpress.XtraEditors.SimpleButton
    Dim dxOK_Nicht_MM As New DevExpress.XtraEditors.SimpleButton
    Dim dxOK_ALL_JAHR As New DevExpress.XtraEditors.SimpleButton



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

    Private Sub BANKBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BANKBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub SteuerbescheinigungKunden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler PLZ_EAEG_TextEdit.TextChanged, AddressOf HandleTextChanged_PLZ_EAEG_TextEdit

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        Me.ZINSERTRAG_KDDETAILTableAdapter.Fill(Me.AccountingDataSet.ZINSERTRAG_KDDETAIL)
        Me.ZINSERTRAG_KDBASICTableAdapter.Fill(Me.AccountingDataSet.ZINSERTRAG_KDBASIC)
        Me.BANKTableAdapter.Fill(Me.AccountingDataSet.BANK)

        Me.Zinsertrag_BasicView.ExpandAllGroups()
        Me.ZinsertragDetails_BasicView.ExpandAllGroups()

        Me.Timer_PLZ_EAEG_Kunden.Enabled = True
        Me.Timer_PLZ_EAEG_Kunden.Interval = 1000
        Me.Timer_PLZ_EAEG_Kunden.Start()


       

    End Sub

    Private Sub Timer_PLZ_EAEG_Kunden_Tick(sender As Object, e As EventArgs) Handles Timer_PLZ_EAEG_Kunden.Tick
        'Check PLZ between EAEG und STEUERBESCHEINIGUNG
        'Using TimerConn As New SqlConnection(conn.ConnectionString)
        'TimerConn.Open()
        'Dim objCMD As SqlCommand = New SqlCommand("Select Count(A.ID) from [ZINSERTRAG KDBASIC] A INNER JOIN  [EAEG_KUNDEN_STAMM] B ON A.KDSTAMM=B.B2_Ordnungskennzeichen where A.[KDPLZ]<>B.B9_Postleitzahl", TimerConn)
        'objCMD.CommandTimeout = 5000
        'PLZ_EAEG_TextEdit.Text = objCMD.ExecuteScalar
        'End Using
        PLZ_EAEG_TextEdit.Text = KundenZinsenPLZ_EAEG

    End Sub

    Private Sub HandleTextChanged_PLZ_EAEG_TextEdit(sender As Object, e As EventArgs)
        If PLZ_EAEG_TextEdit.Text <> "0" Then
            Me.QueryText = "Select A.[KDSTAMM],A.[KDNAME1] from [ZINSERTRAG KDBASIC] A INNER JOIN  [EAEG_KUNDEN_STAMM] B ON A.KDSTAMM=B.B2_Ordnungskennzeichen where A.[KDPLZ]<>B.B9_Postleitzahl"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)

            Dim InfoText As String = ""
            Dim info As AlertInfo = New AlertInfo("", InfoText)

            If dt.Rows.Count > 0 Then

                InfoText = "Bei folgenden Kunden sind bei den EAEG Stamm Daten andere Postleitzahlen hinterlegt!"
                Dim infoCustomer As String = ""
                For i = 0 To dt.Rows.Count - 1
                    infoCustomer += dt.Rows.Item(i).Item("KDSTAMM") & "   " & dt.Rows.Item(i).Item("KDNAME1") & vbNewLine
                Next
                info = New AlertInfo("Ungleiche PLZ bei den Kunden", InfoText & vbNewLine & infoCustomer & vbNewLine & vbNewLine & "Bitte prüfen und ggfs. korrigieren!")

                'Alert_PLZ_EAEG_Steuer.Show(Me, info)

            End If

            For Each Form As AlertForm In Alert_PLZ_EAEG_Steuer.AlertFormList
                Form.Close()
            Next
            Alert_PLZ_EAEG_Steuer.Show(Me, info)

        Else
            'Dim i As Integer
            'For i = 0 To Alert_PLZ_EAEG_Steuer.AlertFormList.Count - 1 Step i + 1
            '    Alert_PLZ_EAEG_Steuer.AlertFormList(i).Dispose()
            'Next
            For Each Form As AlertForm In Alert_PLZ_EAEG_Steuer.AlertFormList
                Form.Close()
            Next

        End If
    End Sub

    Private Sub Alert_PLZ_EAEG_Steuer_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_PLZ_EAEG_Steuer.BeforeFormShow
        e.AlertForm.Size = New Size(500, 500)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
    End Sub

    Private Sub Alert_PLZ_EAEG_Steuer_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_PLZ_EAEG_Steuer.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

    Private Sub PopUpContainer_Cancel_btn_Click(sender As Object, e As EventArgs) Handles PopUpContainer_Cancel_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl1
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub ConfirmNewKdData_btn_Click(sender As Object, e As EventArgs) Handles ConfirmNewKdData_btn.Click
        Dim KDSTAMM As String = Me.StammNr_TextEdit.Text
        Dim edit As PopupContainerControl = PopupContainerControl1

        With Me.ZinsertragDetails_BasicView
            .SetRowCellValue(.FocusedRowHandle, colKDNAME1, Me.NameKunde1_TextEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKDNAME2, Me.NameKunde2_TextEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKDSTRASSE1, Me.Strasse1_TextEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKDSTRASSE2, Me.Strasse2_TextEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKDPLZ, Me.PLZ_TextEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKDORT, Me.Ort_TextEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colBUNDESLAND, Me.Bundesland_ComboBoxEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKDDEFINE, Me.Definition_ImageComboBoxEdit.Text)
            .SetRowCellValue(.FocusedRowHandle, colKAPISTPFLICHTIG, Me.Kapitalsteuerpflichtig_ComboBoxEdit.Text)
        End With
        'Save all changes
       
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KDNAME1]=@NameKunde1,[KDNAME2]=@NameKunde2,[KDSTRASSE1]=@StrasseKunde1,[KDSTRASSE2]=@StrasseKunde2,[KDPLZ]=@PLZKunde,[KDORT]=@ORTKunde,[BUNDESLAND]=@BUNDESLANDKunde,[KDDEFINE]=@KDDEFINE,[KAPISTPFLICHTIG]=@KAPITALSTEUERPFLICHTIG where [KDSTAMM]='" & KDSTAMM & "'"
        cmd.Parameters.Add("@NameKunde1", SqlDbType.NVarChar).Value = Me.NameKunde1_TextEdit.Text
        cmd.Parameters.Add("@NameKunde2", SqlDbType.NVarChar).Value = Me.NameKunde2_TextEdit.Text
        cmd.Parameters.Add("@StrasseKunde1", SqlDbType.NVarChar).Value = Me.Strasse1_TextEdit.Text
        cmd.Parameters.Add("@StrasseKunde2", SqlDbType.NVarChar).Value = Me.Strasse2_TextEdit.Text
        cmd.Parameters.Add("@PLZKunde", SqlDbType.NVarChar).Value = Me.PLZ_TextEdit.Text
        cmd.Parameters.Add("@ORTKunde", SqlDbType.NVarChar).Value = Me.Ort_TextEdit.Text
        cmd.Parameters.Add("@BUNDESLANDKunde", SqlDbType.NVarChar).Value = Me.Bundesland_ComboBoxEdit.EditValue
        cmd.Parameters.Add("@KDDEFINE", SqlDbType.NVarChar).Value = Me.Definition_ImageComboBoxEdit.EditValue
        cmd.Parameters.Add("@KAPITALSTEUERPFLICHTIG", SqlDbType.NVarChar).Value = Me.Kapitalsteuerpflichtig_ComboBoxEdit.EditValue
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()

        'Update von allen relevanten Tabellen 
        cmd.CommandText = "UPDATE [ZINSERTRAG KDDETAIL] SET [KAPISTPFLICHTIG]='" & Me.Kapitalsteuerpflichtig_ComboBoxEdit.Text & "',[BUNDESLAND]='" & Me.Bundesland_ComboBoxEdit.Text & "' where [Customer]='" & KDSTAMM & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KAPISTPFLICHTIG]='" & Me.Kapitalsteuerpflichtig_ComboBoxEdit.Text & "',[BUNDESLAND]='" & Me.Bundesland_ComboBoxEdit.Text & "' where [Customer]='" & KDSTAMM & "'"
        cmd.ExecuteNonQuery()
        '**************************************************************************************
        Me.QueryText = "SELECT distinct[IdZinsertragsMonat] FROM [ZINSERTRAG KUNDEN DETAILS]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ERTRAGSMONAT As String = dt.Rows.Item(i).Item("IdZinsertragsMonat")
            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeKapErSt]= (Select Sum([KapertstG]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'),[SummeSoli]=(Select Sum([Soli]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y') where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
            cmd.ExecuteNonQuery()
        Next
        '**************************************************************************************
        Me.QueryText = "SELECT distinct[IdErtragJahr] FROM [ZINSERTRAG KUNDEN DETAILS]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ERTRAGSJAHR As String = dt.Rows.Item(i).Item("IdErtragJahr")
            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeKapErSt]= (Select Sum([SummeKapErSt]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'),[SummeSoli]=(Select Sum([SummeSoli]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "') where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
            cmd.ExecuteNonQuery()
        Next
        '****************************************************************************************
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Me.Validate()
        Me.ZINSERTRAG_KDBASICBindingSource.EndEdit()
        Me.ZINSERTRAG_KDDETAILBindingSource.EndEdit()
        'edit.OwnerEdit.ClosePopup()
        Me.PopUpContainer_Cancel_btn.PerformClick()
        'Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
        Me.ZINSERTRAG_KDDETAILTableAdapter.Fill(Me.AccountingDataSet.ZINSERTRAG_KDDETAIL)
        Me.ZINSERTRAG_KDBASICTableAdapter.Fill(Me.AccountingDataSet.ZINSERTRAG_KDBASIC)


    End Sub

    Private Sub Print_Export_Zinsertraege_BasicView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Zinsertraege_BasicView_btn.Click
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
        Dim reportfooter As String = "ZINSERTRÄGE KUNDEN "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SteuerBeschMM_Monatlich_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SteuerBeschMM_Monatlich_BarButtonItem.ItemClick
        If KundenZinsenOhnePlzBundesland = 0 Then
            If KundenZinsenPLZ_EAEG = 0 Then


                With dxOK_MM
                    .Text = "OK"
                    .Height = 23
                    .Width = 75
                    .Location = New System.Drawing.Point(19, 203)
                    .ImageList = DATESFORM_ACC.ImageCollection1
                    .ImageIndex = 5
                End With

                DATESFORM_ACC.Controls.Add(dxOK_MM)
                DATESFORM_ACC.OK_btn.Visible = False
                DATESFORM_ACC.LabelControl1.Visible = True
                DATESFORM_ACC.LabelControl2.Visible = False
                DATESFORM_ACC.LabelControl3.Visible = False
                DATESFORM_ACC.ComboBoxEdit2.Visible = False
                DATESFORM_ACC.ComboBoxEdit3.Visible = False

                AddHandler dxOK_MM.Click, AddressOf dxOK_MM_click

                DATESFORM_ACC.Show()
                DATESFORM_ACC.Text = "KAPITALERTRAGSTEUER-BESCHEINIGUNG für MM KUNDEN-Monatlich"
                DATESFORM_ACC.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Bescheinigung"

                'Me.QueryText = "select distinct([IdZinsertragsMonat]) from [ZINSERTRAG KDDETAIL] "
                Me.QueryText = "SELECT a.[IdZinsertragsMonat],a.[ValDate] FROM [ZINSERTRAG KDDETAIL] a JOIN (SELECT [IdZinsertragsMonat], min(ID) as id FROM [ZINSERTRAG KDDETAIL] GROUP BY [IdZinsertragsMonat]) b ON ( a.id = b.id ) GROUP BY a.[IdZinsertragsMonat],a.[ValDate] order by a.[ValDate] desc "
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    DATESFORM_ACC.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                Next
                DATESFORM_ACC.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
            Else
                MessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Else
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub dxOK_MM_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsMonat As String = DATESFORM_ACC.ComboBoxEdit1.Text
        DATESFORM_ACC.ComboBoxEdit1.Properties.Items.Clear()
        DATESFORM_ACC.Controls.Remove(dxOK_MM)
        DATESFORM_ACC.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Kapitalertragsteuerbescheinigungen der MM Kunden für " & ZinsMonat)
        '++++++++++++++++++++++++++++++++++++++++++++++++++
        'Load new Dataadapter
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim MM_BASIC_CUSTOMER_Da As New SqlDataAdapter("SELECT * FROM [ZINSERTRAG KDBASIC] where [KAPISTPFLICHTIG] in ('Y') and KDDEFINE in ('MM') and [KDSTAMM] in (Select [Customer] from [ZINSERTRAG KDDETAIL] where [IdZinsertragsMonat] in ('" & ZinsMonat & "') and [KapertstG]<>0) ", conn)
        Dim MM_DETAIL_CUSTOMER_Da As New SqlDataAdapter("SELECT * FROM [ZINSERTRAG KDDETAIL] where [IdZinsertragsMonat] in ('" & ZinsMonat & "') and [KapertstG]<>0 ", conn)
        Dim General_Dataset As New DataSet("MM_REPORT")
        MM_BASIC_CUSTOMER_Da.Fill(General_Dataset, "ZINSERTRAG KDBASIC")
        MM_DETAIL_CUSTOMER_Da.Fill(General_Dataset, "ZINSERTRAG KDDETAIL")
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '+++++++++++++++++++++++++++++++++++++++++++++++
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_MM.rpt")
        CrRep.SetDataSource(General_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ZinsMonat
        myParams.ParameterFieldName = "ZINS_MONAT"
        myParams.CurrentValues.Add(myValue)
        CrRep.SetParameterValue("ZINS_MONAT", ZinsMonat, "KD_BESCHEINIGUNG_KAPI_MM.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Kapitalertragsteuer MM Kunden für " & ZinsMonat
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SteuerBesch_Nicht_MM_Monatlich_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SteuerBesch_Nicht_MM_Monatlich_BarButtonItem.ItemClick
        If KundenZinsenOhnePlzBundesland = 0 Then
            If KundenZinsenPLZ_EAEG = 0 Then


                With dxOK_Nicht_MM
                    .Text = "OK"
                    .Height = 23
                    .Width = 75
                    .Location = New System.Drawing.Point(19, 203)
                    .ImageList = DATESFORM_ACC.ImageCollection1
                    .ImageIndex = 5
                End With

                DATESFORM_ACC.Controls.Add(dxOK_Nicht_MM)
                DATESFORM_ACC.OK_btn.Visible = False
                DATESFORM_ACC.LabelControl1.Visible = True
                DATESFORM_ACC.LabelControl2.Visible = False
                DATESFORM_ACC.LabelControl3.Visible = False
                DATESFORM_ACC.ComboBoxEdit2.Visible = False
                DATESFORM_ACC.ComboBoxEdit3.Visible = False

                AddHandler dxOK_Nicht_MM.Click, AddressOf dxOK_Nicht_MM_click

                DATESFORM_ACC.Show()
                DATESFORM_ACC.Text = "KAPITALERTRAGSTEUER-BESCHEINIGUNG für KUNDEN (Keine MM) -Monatlich"
                DATESFORM_ACC.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Bescheinigung"

                'Me.QueryText = "select distinct([IdZinsertragsMonat]) from [ZINSERTRAG KDDETAIL] "
                Me.QueryText = "SELECT a.[IdZinsertragsMonat],a.[ValDate] FROM [ZINSERTRAG KDDETAIL] a JOIN (SELECT [IdZinsertragsMonat], min(ID) as id FROM [ZINSERTRAG KDDETAIL] GROUP BY [IdZinsertragsMonat]) b ON ( a.id = b.id ) GROUP BY a.[IdZinsertragsMonat],a.[ValDate] order by a.[ValDate] desc "
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    DATESFORM_ACC.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                Next
                DATESFORM_ACC.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
            Else
                MessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Else
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub dxOK_Nicht_MM_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsMonat As String = DATESFORM_ACC.ComboBoxEdit1.Text
        DATESFORM_ACC.ComboBoxEdit1.Properties.Items.Clear()
        DATESFORM_ACC.Controls.Remove(dxOK_Nicht_MM)
        DATESFORM_ACC.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Kapitalertragsteuerbescheinigungen der nicht MM Kunden für " & ZinsMonat)
        '++++++++++++++++++++++++++++++++++++++++++++++++++
        'Load new Dataadapter
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim MM_BASIC_CUSTOMER_Da As New SqlDataAdapter("SELECT * FROM [ZINSERTRAG KDBASIC] where [KAPISTPFLICHTIG] in ('Y') and KDDEFINE in ('N') and [KDSTAMM] in (Select [Customer] from [ZINSERTRAG KDDETAIL] where [IdZinsertragsMonat] in ('" & ZinsMonat & "') and [KapertstG]<>0) ", conn)
        Dim MM_DETAIL_CUSTOMER_Da As New SqlDataAdapter("SELECT * FROM [ZINSERTRAG KDDETAIL] where [IdZinsertragsMonat] in ('" & ZinsMonat & "') and [KapertstG]<>0 ", conn)
        Dim General_Dataset As New DataSet("MM_REPORT")
        MM_BASIC_CUSTOMER_Da.Fill(General_Dataset, "ZINSERTRAG KDBASIC")
        MM_DETAIL_CUSTOMER_Da.Fill(General_Dataset, "ZINSERTRAG KDDETAIL")
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '+++++++++++++++++++++++++++++++++++++++++++++++
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_Nicht_MM.rpt")
        CrRep.SetDataSource(General_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ZinsMonat
        myParams.ParameterFieldName = "ZINS_MONAT"
        myParams.CurrentValues.Add(myValue)
        CrRep.SetParameterValue("ZINS_MONAT", ZinsMonat, "KD_BESCHEINIGUNG_KAPI_Nicht_MM.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Kapitalertragsteuer nicht MM Kunden für " & ZinsMonat
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub


    Private Sub SteuerBesch_AlleKundenJahr_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SteuerBesch_AlleKundenJahr_BarButtonItem.ItemClick
        If KundenZinsenOhnePlzBundesland = 0 Then
            If KundenZinsenPLZ_EAEG = 0 Then


                With dxOK_ALL_JAHR
                    .Text = "OK"
                    .Height = 23
                    .Width = 75
                    .Location = New System.Drawing.Point(19, 203)
                    .ImageList = DATESFORM_ACC_JAHR_ALL.ImageCollection1
                    .ImageIndex = 5
                End With

                DATESFORM_ACC_JAHR_ALL.Controls.Add(dxOK_ALL_JAHR)
                DATESFORM_ACC_JAHR_ALL.OK_btn.Visible = False
                DATESFORM_ACC_JAHR_ALL.LabelControl1.Visible = True
                DATESFORM_ACC_JAHR_ALL.LabelControl2.Visible = True
                DATESFORM_ACC_JAHR_ALL.LabelControl3.Visible = False
                DATESFORM_ACC_JAHR_ALL.ComboBoxEdit2.Visible = True
                DATESFORM_ACC_JAHR_ALL.ComboBoxEdit3.Visible = False

                AddHandler dxOK_ALL_JAHR.Click, AddressOf dxOK_ALL_JAHR_click

                DATESFORM_ACC_JAHR_ALL.Show()
                DATESFORM_ACC_JAHR_ALL.Text = "STEUERBESCHEINIGUNG für alle Kunden-Jährlich"
                DATESFORM_ACC_JAHR_ALL.LabelControl1.Text = "Bitte wählen Sie das Zinsertragsjahr für die Bescheinigung"
                DATESFORM_ACC_JAHR_ALL.LabelControl2.Text = "Sollen die Zeilen der Anlage KAP auch ausgedruckt werden"

                Me.QueryText = "select distinct([IdErtragJahr]) from [ZINSERTRAG KDDETAIL] ORDER BY [IdErtragJahr] desc  "
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    DATESFORM_ACC_JAHR_ALL.ComboBoxEdit1.Properties.Items.Add(row("IdErtragJahr"))
                Next
                DATESFORM_ACC_JAHR_ALL.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdErtragJahr")

                With DATESFORM_ACC_JAHR_ALL.ComboBoxEdit2
                    .Properties.Items.Add("NEIN")
                    .Properties.Items.Add("JA")
                    .Text = "NEIN"
                End With
            Else
                MessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Else
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub

    Private Sub dxOK_ALL_JAHR_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsJahr As String = DATESFORM_ACC_JAHR_ALL.ComboBoxEdit1.Text
        Dim Zeilen As String = DATESFORM_ACC_JAHR_ALL.ComboBoxEdit2.Text
        DATESFORM_ACC_JAHR_ALL.ComboBoxEdit1.Properties.Items.Clear()
        DATESFORM_ACC_JAHR_ALL.ComboBoxEdit2.Properties.Items.Clear()
        DATESFORM_ACC_JAHR_ALL.Controls.Remove(dxOK_ALL_JAHR)
        DATESFORM_ACC_JAHR_ALL.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Steuerbescheinigungen aller Kunden für das Jahr " & ZinsJahr)
        '++++++++++++++++++++++++++++++++++++++++++++++++++
        'Load new Dataadapter
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim MM_BASIC_CUSTOMER_Da As New SqlDataAdapter("SELECT * FROM [ZINSERTRAG KDBASIC] where [KAPISTPFLICHTIG] in ('Y') and [KDSTAMM] in (Select [Customer] from [ZINSERTRAG KDDETAIL] where [IdErtragJahr]='" & ZinsJahr & "' and [KapertstG]<>0) ", conn)
        Dim MM_DETAIL_CUSTOMER_Da As New SqlDataAdapter("SELECT * FROM [ZINSERTRAG KDDETAIL] where [IdErtragJahr]='" & ZinsJahr & "' and [KapertstG]<>0 ", conn)
        Dim General_Dataset As New DataSet("MM_REPORT")
        MM_BASIC_CUSTOMER_Da.Fill(General_Dataset, "ZINSERTRAG KDBASIC")
        MM_DETAIL_CUSTOMER_Da.Fill(General_Dataset, "ZINSERTRAG KDDETAIL")
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '+++++++++++++++++++++++++++++++++++++++++++++++
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_JAHR.rpt")
        CrRep.SetDataSource(General_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ZinsJahr
        myParams.ParameterFieldName = "ZINS_JAHR"
        myParams.CurrentValues.Add(myValue)
        CrRep.SetParameterValue("ZEILEN", Zeilen, "KD_BESCHEINIGUNG_KAPI_JAHR.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Steuerbescheinigungen aller Kunden für das Jahr " & ZinsJahr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SteuerBesch_EinzelnerKundeJahr_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SteuerBesch_EinzelnerKundeJahr_BarButtonItem.ItemClick
        If KundenZinsenOhnePlzBundesland = 0 Then
            If KundenZinsenPLZ_EAEG = 0 Then
                Dim dxOK_SINGLE_JAHR As New DevExpress.XtraEditors.SimpleButton

                With dxOK_SINGLE_JAHR
                    .Text = "OK"
                    .Height = 23
                    .Width = 75
                    .Location = New System.Drawing.Point(19, 203)
                    .ImageList = DATESFORM_ACC_JAHR_SINGLE.ImageCollection1
                    .ImageIndex = 5
                End With

                DATESFORM_ACC_JAHR_SINGLE.Controls.Add(dxOK_SINGLE_JAHR)
                DATESFORM_ACC_JAHR_SINGLE.OK_btn.Visible = False
                DATESFORM_ACC_JAHR_SINGLE.LabelControl1.Visible = True
                DATESFORM_ACC_JAHR_SINGLE.LabelControl2.Visible = True
                DATESFORM_ACC_JAHR_SINGLE.LabelControl3.Visible = True
                DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit2.Visible = True
                DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit3.Visible = True

                AddHandler dxOK_SINGLE_JAHR.Click, AddressOf dxOK_SINGLE_JAHR_click

                DATESFORM_ACC_JAHR_SINGLE.Show()
                DATESFORM_ACC_JAHR_SINGLE.Text = "STEUERBESCHEINIGUNG für einzelnen Kunden-Jährlich"
                DATESFORM_ACC_JAHR_SINGLE.LabelControl1.Text = "Bitte wählen Sie das Zinsertragsjahr für die Bescheinigung"
                DATESFORM_ACC_JAHR_SINGLE.LabelControl2.Text = "Bitte wählen Sie die Stamm Nr. des Kunden"
                DATESFORM_ACC_JAHR_SINGLE.LabelControl3.Text = "Sollen die Zeilen der Anlage KAP auch ausgedruckt werden"

                Me.QueryText = "select distinct([IdErtragJahr]) from [ZINSERTRAG KDDETAIL] ORDER BY [IdErtragJahr] desc  "
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit1.Properties.Items.Add(row("IdErtragJahr"))
                Next
                DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdErtragJahr")

                Me.QueryText = "select distinct([IdKDSTAMM]),[CustomerName] from [ZINSERTRAG KDDETAIL] where [KAPISTPFLICHTIG]='Y'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit2.Properties.Items.Add(row("IdKDSTAMM") & "  " & row("CustomerName"))
                Next
                DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit2.Text = dt.Rows.Item(0).Item("IdKDSTAMM") & "  " & dt.Rows.Item(0).Item("CustomerName")

                DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit3.Properties.Items.Clear()
                With DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit3
                    .Properties.Items.Add("NEIN")
                    .Properties.Items.Add("JA")
                    .Text = "NEIN"
                End With
            Else
                MessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Else
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub dxOK_SINGLE_JAHR_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsJahr As String = DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit1.Text
        Dim Kunde As String = Microsoft.VisualBasic.Left(DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit2.Text, 18)
        Dim Zeilen As String = DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit3.Text
        DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit1.Properties.Items.Clear()
        DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit2.Properties.Items.Clear()
        DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit3.Properties.Items.Clear()

        DATESFORM_ACC_JAHR_SINGLE.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung der Steuerbescheinigung des Kunden: " & DATESFORM_ACC_JAHR_SINGLE.ComboBoxEdit2.Text & vbNewLine & " für das Jahr " & ZinsJahr)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_JAHR_Single.rpt")
        CrRep.SetDataSource(AccountingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = ZinsJahr
        myParams.ParameterFieldName = "ZINS_JAHR"
        myValue1.Value = Kunde
        myParams1.ParameterFieldName = "KUNDE"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        CrRep.SetParameterValue("ZEILEN", Zeilen, "KD_BESCHEINIGUNG_KAPI_JAHR.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Steuerbescheinigung Kunden Nr.: " & Kunde & " für das Jahr " & ZinsJahr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Zinsertrag_BasicView_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles Zinsertrag_BasicView.CustomRowCellEdit
        If e.Column.FieldName = "KDDEFINE" Then
            e.RepositoryItem = DEFINITIONRepositoryItemImageComboBox
        End If
        If e.Column.FieldName = "KAPISTPFLICHTIG" Then
            e.RepositoryItem = KAPITALSTPFLRepositoryItemImageComboBox
        End If
    End Sub

    Private Sub Zinsertrag_BasicView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles Zinsertrag_BasicView.CustomRowCellEditForEditing
        If e.Column.FieldName = "KDDEFINE" Then
            e.RepositoryItem = RepositoryItemPopupContainerEdit1
        End If
        If e.Column.FieldName = "KAPISTPFLICHTIG" Then
            e.RepositoryItem = RepositoryItemPopupContainerEdit1
        End If
    End Sub

    Private Sub Zinsertrag_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Zinsertrag_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Zinsertrag_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Zinsertrag_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ZinsertragDetails_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZinsertragDetails_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ZinsertragDetails_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ZinsertragDetails_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    
    Private Sub SteuerbescheinigungenReportsDropDownButton_Click(sender As Object, e As EventArgs) Handles SteuerbescheinigungenReportsDropDownButton.Click
        If KundenZinsenOhnePlzBundesland <> 0 Then
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If KundenZinsenPLZ_EAEG <> 0 Then
            MessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

   
End Class