Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports DevExpress.Spreadsheet
Imports DevExpress.Utils

Public Class EAEG_Datei_New


    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim EAEG_C_Satz_ViewCaption As String = Nothing
    Dim ActiveTabGroup As Boolean = False

    Friend WithEvents BgwEAEG_Daten_ErstellungBASIS As BackgroundWorker
    Friend WithEvents BgwNeuEAEG_Daten_ErstellungBASIS As BackgroundWorker
    Friend WithEvents BgwEinreicherDatei_ErstellungBASIS As BackgroundWorker
    Friend WithEvents BgwMeldeDatei_ErstellungBASIS As BackgroundWorker
    Friend WithEvents BgwExcelLoad As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()
    Dim EAEG_NewStichtag As New EAEG_StichtagNeu()
    Dim EAEG_NewStichtagMeldeBasis As New EAEG_StichtagNeu()
    Dim EAEG_NewStichtagMeldeErweitert As New EAEG_StichtagNeu()

    Dim EAEGDATEI As String = Nothing
    Dim Meldeinhalt_Meldedatei As String = Nothing

    Private BS_Stichtage As BindingSource
    Private BS_All_BusinessDates As BindingSource
    Private BS_Meldedatei_Selection As BindingSource


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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub EAEG_A_E_Satz_Version4BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EAEG_A_E_Satz_Version4BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)

    End Sub

    Private Sub EAEG_Datei_New_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.LayoutControl2.Visible = False Then
                Me.ViewDetails_SwitchItem.Checked = False
                Me.LayoutControl2.Visible = True
                Me.EAEG_A_E_Satz_Version4_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4_ALL)
            End If

        End If
    End Sub

    Private Sub EAEG_Datei_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.EAEG_A_E_Satz_Version4_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4_ALL)
        'Me.EAEG_C_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_C_Satz_Version4)
        'Me.EAEG_B_D_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_B_D_Satz_Version4)
        'Me.EAEG_A_E_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4)

        Me.EAEG_A_E_Satz_Version4_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4_ALL)
        ALL_EAEG_DATES_initData()
        ALL_EAEG_DATES_InitLookUp()

    End Sub

    Private Sub ALL_EAEG_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[EAEG_Stichtag],104) as 'Stichtag' from [EAEG_A_E_Satz_Version4] ORDER BY [ID] desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "Stichtag")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Stichtage = New BindingSource(ds, "Stichtag")
    End Sub
    Private Sub ALL_EAEG_DATES_InitLookUp()
        Me.BusinessDate_SearchLookUpEdit.DataSource = BS_Stichtage
        Me.BusinessDate_SearchLookUpEdit.DisplayMember = "Stichtag"
        Me.BusinessDate_SearchLookUpEdit.ValueMember = "Stichtag"
    End Sub

    Private Sub ALL_BUSINESS_DATE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'BusinessDates' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171208' 
                                                    and [PL Result] is not NULL ORDER BY [ID] desc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbAllBusinessDatesSelection As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbAllBusinessDatesSelection.Fill(ds, "ALL_BUSINESS_DATES")

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
        BS_All_BusinessDates = New BindingSource(ds, "ALL_BUSINESS_DATES")
    End Sub

    Private Sub MELDEDATEI_SELECTION_initData()
        OpenSqlConnections()
        QueryText = "Select * from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BASIS_MELDEDATEI_SELECTION') and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
        CloseSqlConnections()

        Dim objCMD1 As SqlCommand = New SqlCommand(SqlCommandText, conn)
        objCMD1.CommandTimeout = 5000
        Dim dbMeldedateiSelection As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbMeldedateiSelection.Fill(ds, "MELDEDATEI_SELECTION")

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
        BS_Meldedatei_Selection = New BindingSource(ds, "MELDEDATEI_SELECTION")
    End Sub

    Private Sub Reload_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Reload_bbi.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Laden aller EAEG Stichtage")
        Me.EAEG_A_E_Satz_Version4_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4_ALL)
        ALL_EAEG_DATES_initData()
        ALL_EAEG_DATES_InitLookUp()
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub Stichtag_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles Stichtag_BarEditItem.EditValueChanged
        If Me.LayoutControl2.Visible = False Then
            rd = Me.Stichtag_BarEditItem.EditValue.ToString
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Lade EAEG Daten für Stichtag: " & rd)
            Me.EAEG_C_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_C_Satz_Version4, rd)
            Me.EAEG_B_D_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_B_D_Satz_Version4, rd)
            Me.EAEG_A_E_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_A_E_Satz_Version4, rd)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub NewStichtag_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles NewStichtag_bbi.ItemClick
        ' initialize a new XtraInputBoxArgs instance
        Dim args As New XtraInputBoxArgs()
        ' set required Input Box options
        args.Caption = "Stichtage"
        args.Prompt = "Bitte wählen Sie ein Datum für die erstellung der EAEG Daten"
        args.DefaultButtonIndex = 0

        AddHandler args.Showing, AddressOf Args_Showing
        ' initialize a DateEdit editor with custom settings
        Dim BusinessDatesList As New SearchLookUpEdit()
        BusinessDatesList.Properties.PopupFormSize = New Size(300, 600)
        Dim BusinessDate As GridColumn = BusinessDatesList.Properties.View.Columns.AddField("Business Date")
        BusinessDate.FieldName = "BusinessDates"
        BusinessDate.Width = 100
        BusinessDate.Visible = True
        BusinessDatesList.Properties.View.OptionsView.ColumnAutoWidth = False
        BusinessDatesList.Properties.View.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True
        BusinessDatesList.Properties.View.OptionsView.ShowAutoFilterRow = True
        BusinessDatesList.Properties.View.BestFitColumns()

        ALL_BUSINESS_DATE_initData()

        BusinessDatesList.Properties.DataSource = BS_All_BusinessDates
        BusinessDatesList.Properties.DisplayMember = "BusinessDates"
        BusinessDatesList.Properties.ValueMember = "BusinessDates"
        args.Editor = BusinessDatesList

        Dim result As Object = XtraInputBox.Show(args)
        If result IsNot Nothing Then
            rd = BusinessDatesList.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            If XtraMessageBox.Show("Soll der EAEG Stichtag:  " & BusinessDatesList.EditValue.ToString & vbNewLine _
                                   & " für (BASIS VERSION 4.1) erstellt werden?", "EAEG Stichtag erstellung (BASIS VERSION)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    OpenSqlConnections()
                    cmd.CommandText = "Select Count([EAEG_Stichtag]) from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
                    Dim EAEG_Stichtag_result As Double = cmd.ExecuteScalar
                    If EAEG_Stichtag_result <> 0 Then
                        If XtraMessageBox.Show("Der EAEG Stichtag: " & rd & " ist bereits vorhanden!" & vbNewLine & "Soll er nochmals erstellt werden?" & vbNewLine & vbNewLine & "Achtung! Die vorhandenen Daten werden gelöscht!", "EAEG Stichtag erstellung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            QueryText = "Select * from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BASIS_V4.1') and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar.ToString <> "OK" Then
                                QueryText = cmd.CommandText
                                da = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt = New System.Data.DataTable()
                                da.Fill(dt)
                                Dim c As New CheckResults
                                c.GridControl1.DataSource = Nothing
                                c.GridControl1.DataSource = dt
                                c.CheckResults_GridView.BestFitColumns()
                                SplashScreenManager.CloseForm(False)
                                Dim XFormDialog = New XtraDialogForm()
                                AddHandler XFormDialog.Shown, AddressOf XFormDialog_Shown
                                If XFormDialog.ShowMessageBoxDialog(New XtraDialogArgs(Me, c, "EAEG Daten können nicht erstellt werden - Folgende Fehler wurden gefunden:", New DialogResult() {DialogResult.OK}, 0)) = DialogResult.OK Then
                                    Exit Sub
                                End If
                                CloseSqlConnections()
                            ElseIf cmd.ExecuteScalar.ToString = "OK" Then
                                SplashScreenManager.CloseForm(False)
                                BgwNeuEAEG_Daten_ErstellungBASIS = New BackgroundWorker
                                bgws.Add(BgwNeuEAEG_Daten_ErstellungBASIS)
                                BgwNeuEAEG_Daten_ErstellungBASIS.WorkerReportsProgress = True
                                BgwNeuEAEG_Daten_ErstellungBASIS.RunWorkerAsync()
                            End If
                        Else
                            Exit Sub

                        End If
                    Else
                        QueryText = "Select * from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BASIS_V4.1') and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If cmd.ExecuteScalar.ToString <> "OK" Then
                            QueryText = cmd.CommandText
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            Dim c As New CheckResults
                            c.GridControl1.DataSource = Nothing
                            c.GridControl1.DataSource = dt
                            c.CheckResults_GridView.BestFitColumns()
                            SplashScreenManager.CloseForm(False)
                            Dim XFormDialog = New XtraDialogForm()
                            AddHandler XFormDialog.Shown, AddressOf XFormDialog_Shown
                            If XFormDialog.ShowMessageBoxDialog(New XtraDialogArgs(Me, c, "EAEG Daten können nicht erstellt werden - Folgende Fehler wurden gefunden:", New DialogResult() {DialogResult.OK}, 0)) = DialogResult.OK Then
                                Exit Sub
                            End If
                            CloseSqlConnections()
                        ElseIf cmd.ExecuteScalar.ToString = "OK" Then
                            SplashScreenManager.CloseForm(False)
                            BgwNeuEAEG_Daten_ErstellungBASIS = New BackgroundWorker
                            bgws.Add(BgwNeuEAEG_Daten_ErstellungBASIS)
                            BgwNeuEAEG_Daten_ErstellungBASIS.WorkerReportsProgress = True
                            BgwNeuEAEG_Daten_ErstellungBASIS.RunWorkerAsync()
                        End If
                    End If
                    CloseSqlConnections()
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
        End If
    End Sub

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub

    Private Sub EAEG_Dateien_Ordner_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Dateien_Ordner_bbi.ItemClick
        System.Diagnostics.Process.Start(EAEG_FILE_DIR)
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub

    Private Sub EAEG_Datei_New_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each BW As BackgroundWorker In bgws
            If BW.IsBusy = True Then
                e.Cancel = True
            End If
        Next
    End Sub



#Region "EAEG STANDARTWERTE"
    Private Sub ZugehoerigkeitEntschaedigungseinrichtung_ImageComboBoxEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ZugehoerigkeitEntschaedigungseinrichtung_ImageComboBoxEdit.ButtonClick
        If Me.LayoutControl2.Visible = False Then
            If e.Button.Tag = "SaveDefault" Then
                If XtraMessageBox.Show("Soll der Standartwert für die Zugehörigkeit der Entschädigungseinrichtungen auf " & Me.ZugehoerigkeitEntschaedigungseinrichtung_ImageComboBoxEdit.EditValue.ToString & " geändert werden?", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim DefaultValueA3 As String = Me.ZugehoerigkeitEntschaedigungseinrichtung_ImageComboBoxEdit.EditValue.ToString
                        OpenSqlConnections()
                        cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] drop constraint [DF_EAEG_A_E_Satz_Version4_A3_ZugehoerigkeitZuEntsaedigungseinrichtungen]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] add constraint [DF_EAEG_A_E_Satz_Version4_A3_ZugehoerigkeitZuEntsaedigungseinrichtungen] default ('" & DefaultValueA3 & "') for [A3_ZugehoerigkeitZuEntsaedigungseinrichtungen]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                        cmd.ExecuteNonQuery()
                        CloseSqlConnections()
                        XtraMessageBox.Show("Standartwert für die Zugehörigkeit der Entschädigungseinrichtungen wurde geändert!", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Catch ex As System.Exception
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Try
                    End Try
                End If
            End If
        End If
    End Sub
    Private Sub EntschaedigungsObergrenzeEAEG_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles EntschaedigungsObergrenzeEAEG_ButtonEdit.ButtonClick
        If e.Button.Caption = "A4" Then
            If XtraMessageBox.Show("Soll der Standartwert für die gesetzliche Entschädigungsobergrenze EAEG auf " & Me.EntschaedigungsObergrenzeEAEG_ButtonEdit.Text & " geändert werden?", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueA4 As Double = Me.EntschaedigungsObergrenzeEAEG_ButtonEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] drop constraint [DF_EAEG_A_E_Satz_Version4_A4_GesetzlicheEntschaedigungsobergrenzeEAEG]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] add constraint [DF_EAEG_A_E_Satz_Version4_A4_GesetzlicheEntschaedigungsobergrenzeEAEG] default (" & Str(DefaultValueA4) & ") for [A4_GesetzlicheEntschaedigungsobergrenzeEAEG]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("Standartwert der gesetzlichen Entschädigungsobergrenzewurde EAEG wurde geändert!", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
        Me.EAEG_A_E_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4)
    End Sub

    Private Sub EntschaedigungsObergrenzeEU_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles EntschaedigungsObergrenzeEU_ButtonEdit.ButtonClick
        If e.Button.Caption = "A5" Then
            If XtraMessageBox.Show("Soll der Standartwert für die gesetzliche Entschädigungsobergrenze EU Herkunftsstaat auf " & Me.EntschaedigungsObergrenzeEAEG_ButtonEdit.Text & " geändert werden?", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueA5 As Double = Me.EntschaedigungsObergrenzeEU_ButtonEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] drop constraint [DF_EAEG_A_E_Satz_Version4_A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] add constraint [DF_EAEG_A_E_Satz_Version4_A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland] default (" & Str(DefaultValueA5) & ") for [A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("Standartwert der gesetzlichen Entschädigungsobergrenzewurde EU Herkunftsstaat wurde geändert!", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
        Me.EAEG_A_E_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4)
    End Sub

    Private Sub SicherungsgrenzeZusatzsicherung_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles SicherungsgrenzeZusatzsicherung_ButtonEdit.ButtonClick
        If e.Button.Caption = "A6" Then
            If XtraMessageBox.Show("Soll der Standartwert für die Sicherungsgrenze bei Zusatzsicherung auf " & Me.EntschaedigungsObergrenzeEAEG_ButtonEdit.Text & " geändert werden?", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueA6 As Double = Me.SicherungsgrenzeZusatzsicherung_ButtonEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] drop constraint [DF_EAEG_A_E_Satz_Version4_A6_SicherungsgrenzeBeiZusatzsicherung]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] add constraint [DF_EAEG_A_E_Satz_Version4_A6_SicherungsgrenzeBeiZusatzsicherung] default (" & Str(DefaultValueA6) & ") for [A6_SicherungsgrenzeBeiZusatzsicherung]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("Standartwert der Sicherungsgrenze bei Zusatzsicherung  wurde geändert!", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
        Me.EAEG_A_E_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4)
    End Sub

    Private Sub SicherungsgrenzeZusatzsicherungAltfall_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles SicherungsgrenzeZusatzsicherungAltfall_ButtonEdit.ButtonClick
        If e.Button.Caption = "A7" Then
            If XtraMessageBox.Show("Soll der Standartwert für die Sicherungsgrenze bei Zusatzsicherung (Altfall-Regelung) auf " & Me.EntschaedigungsObergrenzeEAEG_ButtonEdit.Text & " geändert werden?", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueA7 As Double = Me.SicherungsgrenzeZusatzsicherungAltfall_ButtonEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] drop constraint [DF_EAEG_A_E_Satz_Version4_A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [EAEG_A_E_Satz_Version4] add constraint [DF_EAEG_A_E_Satz_Version4_A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG] default (" & Str(DefaultValueA7) & ") for [A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("Standartwert der Sicherungsgrenze bei Zusatzsicherung (Altfall-Regelung)  wurde geändert!", "ÄNDERUNG DES STANDARTWERTES", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
        Me.EAEG_A_E_Satz_Version4TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4)
    End Sub

#End Region


#Region "EAEG DATEN erstellung BASIS"
    Private Sub EAEG_Laden_BASIS_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Laden_BASIS_BarButtonItem.ItemClick
        If IsDate(Me.Stichtag_BarEditItem.EditValue.ToString) = True Then
            Try
                rd = Me.Stichtag_BarEditItem.EditValue.ToString
                rdsql = rd.ToString("yyyyMMdd")
                If XtraMessageBox.Show("Sollen die Daten der EAEG Datei für den Stichtag " & rd & " erneut geladen und berechnet werden ?" & vbNewLine & vbNewLine & "ACTHUNG!! Alle aktuellen Daten werden gelöscht!", "NEUERSTELLUNG DER EAEG DATEN (BASIS)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Starte EAEG Daten ertellung zum Stichtag: " & rd)
                    OpenSqlConnections()
                    QueryText = "Select * from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BASIS_V4.1') and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar.ToString <> "OK" Then
                        QueryText = cmd.CommandText
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        Dim c As New CheckResults
                        c.GridControl1.DataSource = Nothing
                        c.GridControl1.DataSource = dt
                        c.CheckResults_GridView.BestFitColumns()
                        SplashScreenManager.CloseForm(False)
                        Dim XFormDialog = New XtraDialogForm()
                        AddHandler XFormDialog.Shown, AddressOf XFormDialog_Shown
                        If XFormDialog.ShowMessageBoxDialog(New XtraDialogArgs(Me, c, "EAEG Daten können nicht erstellt werden - Folgende Fehler wurden gefunden:", New DialogResult() {DialogResult.OK}, 0)) = DialogResult.OK Then
                            Exit Sub
                        End If
                        CloseSqlConnections()
                    ElseIf cmd.ExecuteScalar.ToString = "OK" Then
                        SplashScreenManager.CloseForm(False)
                        BgwEAEG_Daten_ErstellungBASIS = New BackgroundWorker
                        bgws.Add(BgwEAEG_Daten_ErstellungBASIS)
                        BgwEAEG_Daten_ErstellungBASIS.WorkerReportsProgress = True
                        BgwEAEG_Daten_ErstellungBASIS.RunWorkerAsync()
                    End If

                Else
                    Me.EAEG_A_E_Satz_Version4BindingSource.CancelEdit()
                    Exit Sub
                End If
            Catch ex As System.Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.EAEG_A_E_Satz_Version4BindingSource.CancelEdit()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub BgwEAEG_Daten_ErstellungBASIS_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwEAEG_Daten_ErstellungBASIS.DoWork
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Starte EAEG Daten ertellung zum Stichtag: " & rd)
            OpenSqlConnections()
            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BASIS_V4.1')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("EAEG Daten Erstellung zum Stichtag: " & rd & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_1"))
                    Me.BgwEAEG_Daten_ErstellungBASIS.ReportProgress(3, "EAEG Daten Erstellung zum Stichtag: " & rd & " - " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            CloseSqlConnections()


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwEAEG_Daten_ErstellungBASIS_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwEAEG_Daten_ErstellungBASIS.ProgressChanged
        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','EAEG Daten erstellung Version 4.1 (BASIS)','EAEG Daten erstellung Version 4.1 (BASIS)')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','EAEG Daten erstellung Version 4.1 (BASIS)','EAEG Daten erstellung Version 4.1 (BASIS)')"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        CloseEVENT_SqlConnection()

    End Sub

    Private Sub BgwEAEG_Daten_ErstellungBASIS_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwEAEG_Daten_ErstellungBASIS.RunWorkerCompleted
        Workers_Complete(BgwEAEG_Daten_ErstellungBASIS, e)
        If LayoutControl2.Visible = False Then
            Me.EAEG_C_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_C_Satz_Version4, rd)
            Me.EAEG_B_D_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_B_D_Satz_Version4, rd)
            Me.EAEG_A_E_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_A_E_Satz_Version4, rd)
        ElseIf LayoutControl2.Visible = True Then
            Me.EAEG_A_E_Satz_Version4_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4_ALL)
        End If

        SplashScreenManager.CloseForm(False)
    End Sub
#End Region


#Region "EAEG NEU DATEN erstellung BASIS"

    Private Sub BgwNeuEAEG_Daten_ErstellungBASIS_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwNeuEAEG_Daten_ErstellungBASIS.DoWork
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Starte EAEG Daten ertellung zum Stichtag: " & rd)
            OpenSqlConnections()
            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BASIS_V4.1')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("EAEG Daten Erstellung zum Stichtag: " & rd & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_1"))
                    Me.BgwNeuEAEG_Daten_ErstellungBASIS.ReportProgress(3, "EAEG Daten Erstellung zum Stichtag: " & rd & " - " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            CloseSqlConnections()


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwNeuEAEG_Daten_ErstellungBASIS_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwNeuEAEG_Daten_ErstellungBASIS.ProgressChanged
        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','EAEG Daten erstellung Version 4.1 (BASIS)','EAEG Daten erstellung Version 4.1 (BASIS)')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','EAEG Daten erstellung Version 4.1 (BASIS)','EAEG Daten erstellung Version 4.1 (BASIS)')"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        CloseEVENT_SqlConnection()

    End Sub

    Private Sub BgwNeuEAEG_Daten_ErstellungBASIS_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwNeuEAEG_Daten_ErstellungBASIS.RunWorkerCompleted
        Workers_Complete(BgwNeuEAEG_Daten_ErstellungBASIS, e)
        Me.ViewDetails_SwitchItem.Checked = True
        Me.LayoutControl2.Visible = False
        Me.EAEG_C_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_C_Satz_Version4, rd)
        Me.EAEG_B_D_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_B_D_Satz_Version4, rd)
        Me.EAEG_A_E_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_A_E_Satz_Version4, rd)
        ALL_EAEG_DATES_initData()
        ALL_EAEG_DATES_InitLookUp()
        Me.Stichtag_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")

        SplashScreenManager.CloseForm(False)
    End Sub
#End Region


#Region "GRIDVIEW STYLES and PRINT-EXPORT"

    Private Sub B_D_Satz_BaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles B_D_Satz_BaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "B_D_Satz_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            EAEG_C_Satz_ViewCaption = "EAEG Datei (C-Sätze) für Kunde: " & view.GetFocusedRowCellValue("B3_Nachname").ToString & "  (" & view.GetFocusedRowCellValue("B2_Ordnungskennzeichen").ToString & ")"
            Me.C_Satz_GridView.ViewCaption = EAEG_C_Satz_ViewCaption
        End If
    End Sub

    Private Sub B_D_Satz_BaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles B_D_Satz_BaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "B_D_Satz_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            EAEG_C_Satz_ViewCaption = "EAEG Datei (C-Sätze) für Kunde: " & view.GetFocusedRowCellValue("B3_Nachname").ToString & "  (" & view.GetFocusedRowCellValue("B2_Ordnungskennzeichen").ToString & ")"
            Me.C_Satz_GridView.ViewCaption = EAEG_C_Satz_ViewCaption
        End If
    End Sub

    Private Sub B_D_Satz_BaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles B_D_Satz_BaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "B_D_Satz_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            EAEG_C_Satz_ViewCaption = "EAEG Datei (C-Sätze) für Kunde: " & view.GetFocusedRowCellValue("B3_Nachname").ToString & "  (" & view.GetFocusedRowCellValue("B2_Ordnungskennzeichen").ToString & ")"
            Me.C_Satz_GridView.ViewCaption = EAEG_C_Satz_ViewCaption
        End If
    End Sub

    Private Sub B_D_Satz_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles B_D_Satz_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub B_D_Satz_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles B_D_Satz_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub C_Satz_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles C_Satz_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub C_Satz_GridView_ShownEditor(sender As Object, e As EventArgs) Handles C_Satz_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView3_ShownEditor(sender As Object, e As EventArgs) Handles GridView3.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub EAEG_Dates_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EAEG_Dates_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub EAEG_Dates_GridView_ShownEditor(sender As Object, e As EventArgs) Handles EAEG_Dates_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView_Print_Export_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles GridView_Print_Export_bbi.ItemClick
        If ActiveTabGroup = False Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = True Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EAEG_ALL_Print_Export_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_ALL_Print_Export_bbi.ItemClick
        If Not EAEG_ALL_GridControl.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Alle C-Sätze" Then
            ActiveTabGroup = True
        Else
            ActiveTabGroup = False
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
        Dim reportfooter As String = "EAEG DATEN" & "  " & "Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
        Dim reportfooter As String = "EAEG DATEN - Alle C Sätze" & "  " & "Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
        Dim reportfooter As String = "EAEG DATEN - Alle Stichtage"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#End Region

#Region "EAEG CRYSTAL REPORTS"
    Private Sub EAEG_Datei_Gesamt_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Datei_Gesamt_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung des EAEG Datei Reports für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString)
        rd = Me.Stichtag_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EAEG_Datei_DatenV4.rpt")
        'Dim r As New LOAN_STRUCTURE_TABLE
        CrRep.SetDataSource(EAEGDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "EAEG Datei Report für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub EAEG_Daten_Kunden_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Daten_Kunden_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung des EAEG Daten (Kunden) Reports für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString)
        rd = Me.Stichtag_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EAEG_DatenV4.rpt")
        'Dim r As New LOAN_STRUCTURE_TABLE
        CrRep.SetDataSource(EAEGDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "EAEG Daten (Kunden) Report für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Gesetzliche_Einlagensicherung_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Gesetzliche_Einlagensicherung_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung der Gesetzlichen Einlagensicherung (Kundenliste) für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString)
        rd = Me.Stichtag_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        OpenSqlConnections()
        cmd.CommandText = "Delete from [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]"
        cmd.ExecuteNonQuery()
        'New Code
        cmd.CommandText = "INSERT INTO [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]([DepositCustomerName],[DepositAccount],[DepositAmountEUR],[RiskDate]) Select [B3_Nachname]+'  ' + [B4_Vorname],[B2_Ordnungskennzeichen],[D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen],'" & rdsql & "' from [EAEG_B_D_Satz_Version4] where [D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen]>0 and [EAEG_Stichtag]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        'Select Parameters
        Dim Sicherungsgrenze As Double = 0
        cmd.CommandText = "Select [NPARAMETER1] from [PARAMETER] where [IdABTEILUNGSPARAMETER]='EINLAGENSICHERUNG' and [PARAMETER1]='SicherungsgrenzeGesetzlich'"
        Sicherungsgrenze = cmd.ExecuteScalar

        CloseSqlConnections()
        'FILL DATASET
        Dim EinlagensicherungDa As New SqlDataAdapter("SELECT * FROM [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]", conn)
        Dim EINLAGENSICHERUNGdataset As New DataSet("EINLAGENSICHERUNG")
        EinlagensicherungDa.Fill(EINLAGENSICHERUNGdataset, "EINLAGENSICHERUNG_MELDUNG_PRUFVERB")
        'REPORT CREATION
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EinlagensicherungPrufVerbGesetzlich.rpt")
        CrRep.SetDataSource(EINLAGENSICHERUNGdataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Sicherungsgrenze
        myParams.ParameterFieldName = "Sicherungsgrenze"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Meldung zur Einlagensicherung (Gesetzlich) für den " & rd
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "EAEG_EINREICHER_DATEI_ERSTELLUNG_BASIS"
    Private Sub EAEG_EinreicherDatei_Erstellung_BASIS_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem.ItemClick
        If XtraMessageBox.Show("Soll die EAEG Datei (BASIS) für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString & " erstellt werden?" & vbNewLine & vbNewLine & "Vorhandene Datei mit den selben Namen wird dabei gelöscht!", "EAEG Datei erstellung BASIS (Version 4.1)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                rd = Me.Stichtag_BarEditItem.EditValue.ToString
                rdsql = rd.ToString("yyyyMMdd")
                BgwEinreicherDatei_ErstellungBASIS = New BackgroundWorker
                bgws.Add(BgwEinreicherDatei_ErstellungBASIS)
                BgwEinreicherDatei_ErstellungBASIS.WorkerReportsProgress = True
                BgwEinreicherDatei_ErstellungBASIS.RunWorkerAsync()
            Catch ex As System.Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BgwEinreicherDatei_ErstellungBASIS_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwEinreicherDatei_ErstellungBASIS.DoWork
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Datendefinition A und E Satz")
            'Datendefinition  A und E Satz
            Dim A_SATZ As String = Nothing
            Dim EAEG_Stichtag As Date
            Dim EAEG_DateiName As String = Nothing
            Dim A1 As String = Nothing
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As Double = 0
            'Dim A5 As Double = 0
            'Dim A6 As Double = 0
            'Dim A7 As Double = 0
            Dim E_SATZ As String = Nothing
            Dim E1 As String = Nothing
            Dim E2 As String = Nothing
            Dim E3 As Double = 0
            Dim E4 As Double = 0
            Dim E5 As Double = 0
            Dim E6 As Double = 0
            Dim E7 As Double = 0
            Dim E8 As Double = 0
            'Dim E9 As Double = 0
            'Dim E10 As Double = 0
            'Dim E11 As Double = 0
            'Dim E12 As Double = 0
            'Dim E13 As Double = 0
            'Dim E14 As Double = 0
            'Dim E15 As Double = 0

            OpenSqlConnections()
            'A und E SATZ
            SplashScreenManager.Default.SetWaitFormCaption("Lade Daten für A Satz")
            QueryText = "SELECT  [ID],[EAEG_Stichtag],[A1_Satzidentifikator],[A2_Institut],[A3_ZugehoerigkeitZuEntsaedigungseinrichtungen],[A4_GesetzlicheEntschaedigungsobergrenzeEAEG],[A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland],[A6_SicherungsgrenzeBeiZusatzsicherung],[A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG],[E1_Satzidentifikator],[E2_Institut],[E3_GesamteinreichersaldoEinlagen],[E4_GesamteinreichersaldoAusschluesseEinSiG],[E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG],[E6_GesamteinreichersaldoGedekterEinlagenEinSiG],[E7_GesamteinreichersaldoKappungEinSiG],[E8_GesamteinreichersaldoEWR_Niederlassungen],[E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat],[E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut],[E11_GesamteinreichersaldoAusschlueseNurStatut],[E12_GesamteinreichersaldoZusatzsicherung],[E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG],[E14_GesamteinreichersaldoForderungenAnKunden],[E15_GesamteinreichersaldoNichtEWR_Niederlassungen] FROM [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                EAEG_Stichtag = dt.Rows.Item(0).Item("EAEG_Stichtag")
                EAEG_DateiName = EAEG_Stichtag.ToString("yyMMdd")
                A1 = dt.Rows.Item(0).Item("A1_Satzidentifikator")
                A2 = dt.Rows.Item(0).Item("A2_Institut")
                A3 = "01"
                A4 = dt.Rows.Item(0).Item("A4_GesetzlicheEntschaedigungsobergrenzeEAEG")
                'A5 = dt.Rows.Item(0).Item("A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland")
                'A6 = dt.Rows.Item(0).Item("A6_SicherungsgrenzeBeiZusatzsicherung")
                'A7 = dt.Rows.Item(0).Item("A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG")
                A_SATZ = A1 & "*" & A2 & "*" & A3 & "*" & A4.ToString("#0.00") '& "*" & A5.ToString("#0.00") & "*" & A6.ToString("#0.00") & "*" & A7.ToString("#0.00")

                E1 = dt.Rows.Item(0).Item("E1_Satzidentifikator")
                E2 = dt.Rows.Item(0).Item("E2_Institut")
                E3 = dt.Rows.Item(0).Item("E3_GesamteinreichersaldoEinlagen")
                E4 = dt.Rows.Item(0).Item("E4_GesamteinreichersaldoAusschluesseEinSiG")
                E5 = dt.Rows.Item(0).Item("E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG")
                E6 = dt.Rows.Item(0).Item("E6_GesamteinreichersaldoGedekterEinlagenEinSiG")
                E7 = dt.Rows.Item(0).Item("E7_GesamteinreichersaldoKappungEinSiG")
                E8 = dt.Rows.Item(0).Item("E8_GesamteinreichersaldoEWR_Niederlassungen")
                'E9 = dt.Rows.Item(0).Item("E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat")
                'E10 = dt.Rows.Item(0).Item("E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut")
                'E11 = dt.Rows.Item(0).Item("E11_GesamteinreichersaldoAusschlueseNurStatut")
                'E12 = dt.Rows.Item(0).Item("E12_GesamteinreichersaldoZusatzsicherung")
                'E13 = dt.Rows.Item(0).Item("E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG")
                'E14 = dt.Rows.Item(0).Item("E14_GesamteinreichersaldoForderungenAnKunden")
                'E15 = dt.Rows.Item(0).Item("E15_GesamteinreichersaldoNichtEWR_Niederlassungen")
                E_SATZ = E1 & "*" & E2 & "*" & E3.ToString("#0.00") & "*" & E4.ToString("#0.00") & "*" & E5.ToString("#0.00") & "*" & E6.ToString("#0.00") & "*" & E7.ToString("#0.00") & "*" & E8.ToString("#0.00") '& "*" & E9.ToString("#0.00") & "*" & E10.ToString("#0.00") & "*" & E11.ToString("#0.00") & "*" & E12.ToString("#0.00") & "*" & E13.ToString("#0.00") & "*" & E14.ToString("#0.00") & "*" & E15.ToString("#0.00")

                EAEGDATEI = "0000000" & A2 & EAEG_DateiName & ".DGS"
            Next

            If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
                File.Delete(EAEG_FILE_DIR & EAEGDATEI)
            End If

            System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, A_SATZ & vbCrLf)

            SplashScreenManager.Default.SetWaitFormCaption("Datendefinition B und D Satz")
            'B,D und C Sätze
            'Datendefinition  B,D und C Satz
            Dim B_SATZ As String = Nothing
            Dim B1 As String = Nothing
            Dim B2 As String = Nothing
            Dim B3 As String = Nothing
            Dim B4 As String = Nothing
            Dim B5 As String = Nothing
            Dim B6 As String = Nothing
            Dim B7 As String = Nothing
            Dim B8 As String = Nothing
            Dim B9 As String = Nothing
            Dim B10 As String = Nothing
            Dim B11 As String = Nothing
            Dim B12 As Date
            Dim B12s As String = Nothing
            Dim B13 As String = Nothing
            Dim B14_1 As String = Nothing
            Dim B14_2 As String = Nothing
            Dim B14_3 As String = Nothing
            Dim B14_4 As String = Nothing
            Dim B14_5 As String = Nothing
            Dim B14_6 As String = Nothing
            Dim B14_7 As String = Nothing
            Dim B14_8 As String = Nothing
            Dim B14_9 As String = Nothing
            Dim B14_10 As String = Nothing
            Dim B14_11 As String = Nothing
            Dim B14_12 As String = Nothing
            Dim B14_13 As String = Nothing
            Dim B14_14 As String = Nothing
            Dim B14_15 As String = Nothing
            Dim B14_16 As String = Nothing
            Dim B14_17 As String = Nothing
            Dim B14_18 As String = Nothing
            Dim B14_19 As String = Nothing
            Dim B14_20 As String = Nothing
            Dim B14_21 As String = Nothing
            Dim B14_22 As String = Nothing
            Dim B14_23 As String = Nothing
            Dim B14_24 As String = Nothing
            Dim B14_25 As String = Nothing
            Dim B14_26 As String = Nothing
            Dim B14_27 As String = Nothing
            Dim B14_28 As String = Nothing
            Dim B14_29 As String = Nothing
            Dim B14_30 As String = Nothing
            Dim B14_31 As String = Nothing
            Dim B14_32 As String = Nothing
            Dim B14_33 As String = Nothing
            Dim B14_34 As String = Nothing
            Dim B14_35 As String = Nothing
            Dim B14_36 As String = Nothing
            Dim B14_37 As String = Nothing
            Dim B14_38 As String = Nothing
            Dim B14_39 As String = Nothing
            Dim B14_40 As String = Nothing
            Dim B14_41 As String = Nothing
            Dim B14_42 As String = Nothing
            Dim B14_43 As String = Nothing
            Dim B14_44 As String = Nothing
            Dim B14_45 As String = Nothing
            Dim B14_46 As String = Nothing
            Dim B14_47 As String = Nothing
            Dim B14_48 As String = Nothing
            Dim B14_49 As String = Nothing
            Dim B14_50 As String = Nothing
            Dim B15 As String = Nothing 'Kundenkontakt

            Dim C_SATZ As String = Nothing
            Dim C1 As String = Nothing
            Dim C2A As String = Nothing
            Dim C2B As String = Nothing
            Dim C3 As String = Nothing
            Dim C4 As String = Nothing
            Dim C5 As String = Nothing
            Dim C6 As Date
            Dim C6s As String = Nothing
            Dim C7 As String = Nothing
            Dim C8 As String = Nothing
            Dim C9 As Double = 0
            Dim C10 As Double = 0
            Dim C11 As Double = 0
            Dim C12 As Double = 0
            Dim C12s As String = Nothing
            Dim C13 As Date
            Dim C13s As String = Nothing
            Dim C14 As Date
            Dim C14s As String = Nothing
            Dim C15 As String = Nothing
            Dim C16 As String = Nothing
            Dim C17 As Double = 0
            Dim C17s As String = Nothing
            Dim C18 As Double = 0
            Dim C18s As String = Nothing
            Dim C19 As Double = 0
            Dim C19s As String = Nothing
            Dim C20_1 As String = Nothing
            Dim C20_2 As String = Nothing
            Dim C20_3 As String = Nothing
            Dim C20_4 As String = Nothing
            Dim C20_5 As String = Nothing
            Dim C20_6 As String = Nothing
            Dim C20_7 As String = Nothing
            Dim C20_8 As String = Nothing
            Dim C20_9 As String = Nothing
            Dim C20_10 As String = Nothing
            Dim C20_11 As String = Nothing
            Dim C20_12 As String = Nothing
            Dim C20_13 As String = Nothing
            Dim C20_14 As String = Nothing
            Dim C20_15 As String = Nothing
            Dim C20_16 As String = Nothing
            Dim C20_17 As String = Nothing
            Dim C20_18 As String = Nothing
            Dim C20_19 As String = Nothing
            Dim C20_20 As String = Nothing
            Dim C20_21 As String = Nothing
            Dim C20_22 As String = Nothing
            Dim C20_23 As String = Nothing
            Dim C20_24 As String = Nothing
            Dim C20_25 As String = Nothing
            Dim C20_26 As String = Nothing
            Dim C20_27 As String = Nothing
            Dim C20_28 As String = Nothing
            Dim C20_29 As String = Nothing
            Dim C20_30 As String = Nothing
            Dim C20_31 As String = Nothing
            Dim C20_32 As String = Nothing
            Dim C20_33 As String = Nothing
            Dim C20_34 As String = Nothing
            Dim C20_35 As String = Nothing
            Dim C20_36 As String = Nothing
            Dim C20_37 As String = Nothing
            Dim C20_38 As String = Nothing
            Dim C20_39 As String = Nothing
            Dim C20_40 As String = Nothing
            Dim C20_41 As String = Nothing
            Dim C20_42 As String = Nothing
            Dim C20_43 As String = Nothing
            Dim C20_44 As String = Nothing
            Dim C20_45 As String = Nothing
            Dim C20_46 As String = Nothing
            Dim C20_47 As String = Nothing
            Dim C20_48 As String = Nothing
            Dim C20_49 As String = Nothing
            Dim C20_50 As String = Nothing

            Dim C21_1 As String = Nothing
            Dim C21_2 As String = Nothing
            Dim C21_3 As String = Nothing
            Dim C21_4 As String = Nothing
            Dim C21_5 As String = Nothing
            Dim C21_6 As String = Nothing
            Dim C21_7 As String = Nothing
            Dim C21_8 As String = Nothing
            Dim C21_9 As String = Nothing
            Dim C21_10 As String = Nothing
            Dim C21_11 As String = Nothing
            Dim C21_12 As String = Nothing
            Dim C21_13 As String = Nothing
            Dim C21_14 As String = Nothing
            Dim C21_15 As String = Nothing
            Dim C21_16 As String = Nothing
            Dim C21_17 As String = Nothing
            Dim C21_18 As String = Nothing
            Dim C21_19 As String = Nothing
            Dim C21_20 As String = Nothing
            Dim C21_21 As String = Nothing
            Dim C21_22 As String = Nothing
            Dim C21_23 As String = Nothing
            Dim C21_24 As String = Nothing
            Dim C21_25 As String = Nothing
            Dim C21_26 As String = Nothing
            Dim C21_27 As String = Nothing
            Dim C21_28 As String = Nothing
            Dim C21_29 As String = Nothing
            Dim C21_30 As String = Nothing
            Dim C21_31 As String = Nothing
            Dim C21_32 As String = Nothing
            Dim C21_33 As String = Nothing
            Dim C21_34 As String = Nothing
            Dim C21_35 As String = Nothing
            Dim C21_36 As String = Nothing
            Dim C21_37 As String = Nothing
            Dim C21_38 As String = Nothing
            Dim C21_39 As String = Nothing
            Dim C21_40 As String = Nothing
            Dim C21_41 As String = Nothing
            Dim C21_42 As String = Nothing
            Dim C21_43 As String = Nothing
            Dim C21_44 As String = Nothing
            Dim C21_45 As String = Nothing
            Dim C21_46 As String = Nothing
            Dim C21_47 As String = Nothing
            Dim C21_48 As String = Nothing
            Dim C21_49 As String = Nothing
            Dim C21_50 As String = Nothing

            Dim C22 As String = Nothing 'Kennzeichen EWR-Niederlassung
            'Dim C23 As String = Nothing 'Kennzeichen Nicht EWR-Niederlassung

            Dim D1 As String = Nothing
            Dim D2 As String = Nothing
            Dim D3 As Double = 0
            Dim D4 As Double = 0
            Dim D5 As Double = 0
            Dim D6 As Double = 0
            Dim D7 As Double = 0
            Dim D8 As Double = 0
            'Dim D9 As Double = 0
            'Dim D10 As Double = 0
            'Dim D11 As Double = 0
            'Dim D12 As Double = 0
            'Dim D13 As Double = 0
            'Dim D14 As Double = 0
            'Dim D15 As Double = 0

            SplashScreenManager.Default.SetWaitFormCaption("Lade Daten für B und D Satz")
            QueryText = "Select * from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen] in (Select [B2_OrdnungskennzeichenId] from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]<>0 and [EAEG_Stichtag]='" & rdsql & "') and [EAEG_Stichtag]='" & rdsql & "'"
            'QueryText = "Select * from [EAEG_B_D_Satz_Version4]"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SplashScreenManager.Default.SetWaitFormCaption("Lade B Satz Daten für KundenNr.: " & dt.Rows.Item(i).Item("B2_Ordnungskennzeichen"))
                B1 = dt.Rows.Item(i).Item("B1_Satzidentifikator") & "*"
                B2 = dt.Rows.Item(i).Item("B2_Ordnungskennzeichen") & "*"
                B3 = dt.Rows.Item(i).Item("B3_Nachname") & "*"
                B4 = dt.Rows.Item(i).Item("B4_Vorname") & "*"
                B5 = dt.Rows.Item(i).Item("B5_Namenszusatz") & "*"
                B6 = dt.Rows.Item(i).Item("B6_Anrede") & "*"
                B7 = dt.Rows.Item(i).Item("B7_SrasseUndHausnummer") & "*"
                B8 = dt.Rows.Item(i).Item("B8_ZusatzStrasse") & "*"
                B9 = dt.Rows.Item(i).Item("B9_Postleitzahl") & "*"
                B10 = dt.Rows.Item(i).Item("B10_Ort") & "*"
                B11 = dt.Rows.Item(i).Item("B11_Land") & "*"
                If IsDBNull(dt.Rows.Item(i).Item("B12_Geburtsdatum")) = False Then
                    B12 = dt.Rows.Item(i).Item("B12_Geburtsdatum")
                    B12s = B12.ToString("ddMMyyyy") & "*"
                Else
                    B12s = "" & "*"
                End If
                B13 = dt.Rows.Item(i).Item("B13_Branche") & "*"
                B14_1 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos1")
                B14_2 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos2")
                B14_3 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos3")
                B14_4 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos4")
                B14_5 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos5")
                B14_6 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos6")
                B14_7 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos7")
                B14_8 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos8")
                B14_9 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos9")
                B14_10 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos10")
                B14_11 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos11")
                B14_12 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos12")
                B14_13 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos13")
                B14_14 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos14")
                B14_15 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos15")
                B14_16 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos16")
                B14_17 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos17")
                B14_18 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos18")
                B14_19 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos19")
                B14_20 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos20")
                B14_21 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos21")
                B14_22 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos22")
                B14_23 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos23")
                B14_24 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos24")
                B14_25 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos25")
                B14_26 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos26")
                B14_27 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos27")
                B14_28 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos28")
                B14_29 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos29")
                B14_30 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos30")
                B14_31 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos31")
                B14_32 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos32")
                B14_33 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos33")
                B14_34 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos34")
                B14_35 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos35")
                B14_36 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos36")
                B14_37 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos37")
                B14_38 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos38")
                B14_39 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos39")
                B14_40 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos40")
                B14_41 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos41")
                B14_42 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos42")
                B14_43 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos43")
                B14_44 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos44")
                B14_45 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos45")
                B14_46 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos46")
                B14_47 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos47")
                B14_48 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos48")
                B14_49 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos49")
                B14_50 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos50")
                Dim B14_All As String = B14_1 & B14_2 & B14_3 & B14_4 & B14_5 & B14_6 & B14_7 & B14_8 & B14_9 & B14_10 & B14_11 & B14_12 & B14_13 & B14_14 & B14_15 & B14_16 & B14_17 & B14_18 & B14_19 & B14_20 & B14_21 & B14_22 & B14_23 & B14_24 & B14_25 & B14_26 & B14_27 & B14_28 & B14_29 & B14_30 & B14_31 & B14_32 & B14_33 & B14_34 & B14_35 & B14_36 & B14_37 & B14_38 & B14_39 & B14_40 & B14_41 & B14_42 & B14_43 & B14_44 & B14_45 & B14_46 & B14_47 & B14_48 & B14_49 & B14_50

                If IsDBNull(dt.Rows.Item(i).Item("B15_Kundenkontakt")) = False Then
                    B15 = "*" & dt.Rows.Item(i).Item("B15_Kundenkontakt")
                Else
                    B15 = "*"
                End If

                B_SATZ = B1 & B2 & B3 & B4 & B5 & B6 & B7 & B8 & B9 & B10 & B11 & B12s & B13 & B14_All & B15 '+++++++

                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, B_SATZ & vbCrLf)

                Dim STAMM As String = dt.Rows.Item(i).Item("B2_Ordnungskennzeichen")
                QueryText1 = "Select * from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "' and [C19_KontosaldoInEuro]<>0 and [EAEG_Stichtag]='" & rdsql & "'"
                'QueryText1 = "Select * from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "'"
                da1 = New SqlDataAdapter(QueryText1.Trim(), conn)
                dt1 = New DataTable()
                da1.Fill(dt1)
                For y = 0 To dt1.Rows.Count - 1
                    SplashScreenManager.Default.SetWaitFormCaption("Lade C Satz Daten für Konto Nr./ GeschäftsNr.: " & dt1.Rows.Item(y).Item("C2_Kontonummer"))
                    C1 = dt1.Rows.Item(y).Item("C1_Satzidentifikator") & "*"
                    C2A = dt1.Rows.Item(y).Item("B2_OrdnungskennzeichenId") & "*"
                    C2B = dt1.Rows.Item(y).Item("C2_Kontonummer") & "*"
                    C3 = dt1.Rows.Item(y).Item("C3_Kontozusatzbezeichnung") & "*"
                    C4 = dt1.Rows.Item(y).Item("C4_AbweichendWirtschftlichBerechtigter") & "*"
                    C5 = dt1.Rows.Item(y).Item("C5_AnzahlKontoinhaber") & "*"
                    C6 = dt1.Rows.Item(y).Item("C6_Kontoerröfnung")
                    C6s = C6.ToString("ddMMyyyy") & "*"
                    C7 = dt1.Rows.Item(y).Item("C7_Kontoart") & "*"
                    C8 = dt1.Rows.Item(y).Item("C8_Währung") & "*"
                    C9 = dt1.Rows.Item(y).Item("C9_KapitalsaldoInKontowährung")
                    C10 = dt1.Rows.Item(y).Item("C10_Umrechnungskurs")
                    C11 = dt1.Rows.Item(y).Item("C11_KapitalsaldoInEuro")
                    If IsDBNull(dt1.Rows.Item(y).Item("C12_Zinssatz")) = False Then
                        C12 = dt1.Rows.Item(y).Item("C12_Zinssatz")
                        C12s = C12.ToString("#0.00000")
                    Else
                        C12s = ""
                    End If

                    If IsDBNull(dt1.Rows.Item(y).Item("C13_LetzteZinsfaelligkeit")) = False Then
                        C13 = dt1.Rows.Item(y).Item("C13_LetzteZinsfaelligkeit")
                        C13s = C13.ToString("ddMMyyyy") & "*"
                    Else
                        C13s = "" & "*"
                    End If
                    If IsDBNull(dt1.Rows.Item(y).Item("C14_Endfaelligkeit")) = False Then
                        C14 = dt1.Rows.Item(y).Item("C14_Endfaelligkeit")
                        C14s = C14.ToString("ddMMyyyy") & "*"
                    Else
                        C14s = "" & "*"
                    End If
                    C15 = dt1.Rows.Item(y).Item("C15_Faelligkeitsmerkmal") & "*"
                    C16 = dt1.Rows.Item(y).Item("C16_Zinsmethode") & "*"
                    If IsDBNull(dt1.Rows.Item(y).Item("C17_ZinssaldoInKontowährung")) = False Then
                        C17 = dt1.Rows.Item(y).Item("C17_ZinssaldoInKontowährung")
                        C17s = C17.ToString("#0.00") & "*"
                    Else
                        C17s = "" & "*"
                    End If
                    If IsDBNull(dt1.Rows.Item(y).Item("C18_ZinssaldoInEuro")) = False Then
                        C18 = dt1.Rows.Item(y).Item("C18_ZinssaldoInEuro")
                        C18s = C18.ToString("#0.00") & "*"
                    Else
                        C18s = "" & "*"
                    End If

                    If IsDBNull(dt1.Rows.Item(y).Item("C19_KontosaldoInEuro")) = False Then
                        C19 = dt1.Rows.Item(y).Item("C19_KontosaldoInEuro")
                        C19s = C19.ToString("#0.00") & "*"
                    Else
                        C19s = "" & "*"
                    End If

                    C20_1 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos1")
                    C20_2 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos2")
                    C20_3 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos3")
                    C20_4 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos4")
                    C20_5 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos5")
                    C20_6 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos6")
                    C20_7 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos7")
                    C20_8 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos8")
                    C20_9 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos9")
                    C20_10 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos10")
                    C20_11 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos11")
                    C20_12 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos12")
                    C20_13 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos13")
                    C20_14 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos14")
                    C20_15 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos15")
                    C20_16 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos16")
                    C20_17 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos17")
                    C20_18 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos18")
                    C20_19 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos19")
                    C20_20 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos20")
                    C20_21 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos21")
                    C20_22 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos22")
                    C20_23 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos23")
                    C20_24 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos24")
                    C20_25 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos25")
                    C20_26 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos26")
                    C20_27 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos27")
                    C20_28 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos28")
                    C20_29 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos29")
                    C20_30 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos30")
                    C20_31 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos31")
                    C20_32 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos32")
                    C20_33 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos33")
                    C20_34 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos34")
                    C20_35 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos35")
                    C20_36 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos36")
                    C20_37 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos37")
                    C20_38 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos38")
                    C20_39 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos39")
                    C20_40 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos40")
                    C20_41 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos41")
                    C20_42 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos42")
                    C20_43 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos43")
                    C20_44 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos44")
                    C20_45 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos45")
                    C20_46 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos46")
                    C20_47 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos47")
                    C20_48 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos48")
                    C20_49 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos49")
                    C20_50 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos50")
                    Dim C20_All As String = C20_1 & C20_2 & C20_3 & C20_4 & C20_5 & C20_6 & C20_7 & C20_8 & C20_9 & C20_10 & C20_11 & C20_12 & C20_13 & C20_14 & C20_15 & C20_16 & C20_17 & C20_18 & C20_19 & C20_20 & C20_21 & C20_22 & C20_23 & C20_24 & C20_25 & C20_26 & C20_27 & C20_28 & C20_29 & C20_30 & C20_31 & C20_32 & C20_33 & C20_34 & C20_35 & C20_36 & C20_37 & C20_38 & C20_39 & C20_40 & C20_41 & C20_42 & C20_43 & C20_44 & C20_45 & C20_46 & C20_47 & C20_48 & C20_49 & C20_50


                    C21_1 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos1")
                    C21_2 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos2")
                    C21_3 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos3")
                    C21_4 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos4")
                    C21_5 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos5")
                    C21_6 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos6")
                    C21_7 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos7")
                    C21_8 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos8")
                    C21_9 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos9")
                    C21_10 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos10")
                    C21_11 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos11")
                    C21_12 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos12")
                    C21_13 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos13")
                    C21_14 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos14")
                    C21_15 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos15")
                    C21_16 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos16")
                    C21_17 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos17")
                    C21_18 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos18")
                    C21_19 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos19")
                    C21_20 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos20")
                    C21_21 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos21")
                    C21_22 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos22")
                    C21_23 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos23")
                    C21_24 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos24")
                    C21_25 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos25")
                    C21_26 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos26")
                    C21_27 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos27")
                    C21_28 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos28")
                    C21_29 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos29")
                    C21_30 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos30")
                    C21_31 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos31")
                    C21_32 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos32")
                    C21_33 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos33")
                    C21_34 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos34")
                    C21_35 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos35")
                    C21_36 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos36")
                    C21_37 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos37")
                    C21_38 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos38")
                    C21_39 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos39")
                    C21_40 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos40")
                    C21_41 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos41")
                    C21_42 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos42")
                    C21_43 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos43")
                    C21_44 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos44")
                    C21_45 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos45")
                    C21_46 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos46")
                    C21_47 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos47")
                    C21_48 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos48")
                    C21_49 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos49")
                    C21_50 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos50")
                    Dim C21_All As String = C21_1 & C21_2 & C21_3 & C21_4 & C21_5 & C21_6 & C21_7 & C21_8 & C21_9 & C21_10 & C21_11 & C21_12 & C21_13 & C21_14 & C21_15 & C21_16 & C21_17 & C21_18 & C21_19 & C21_20 & C21_21 & C21_22 & C21_23 & C21_24 & C21_25 & C21_26 & C21_27 & C21_28 & C21_29 & C21_30 & C21_31 & C21_32 & C21_33 & C21_34 & C21_35 & C21_36 & C21_37 & C21_38 & C21_39 & C21_40 & C21_41 & C21_42 & C21_43 & C21_44 & C21_45 & C21_46 & C21_47 & C21_48 & C21_49 & C21_50

                    If IsDBNull(dt1.Rows.Item(y).Item("C22_KennzeichenEWR_Niederlassung")) = False Then
                        C22 = dt1.Rows.Item(y).Item("C22_KennzeichenEWR_Niederlassung")
                    Else
                        C22 = ""
                    End If
                    '+++++++
                    'If IsDBNull(dt1.Rows.Item(y).Item("C23_KennzeichenNichtEWR_Niederlassung")) = False Then
                    'C23 = dt1.Rows.Item(y).Item("C23_KennzeichenNichtEWR_Niederlassung")
                    'Else
                    'C23 = ""
                    'End If
                    '++++++++

                    C_SATZ = C1 & C2A & C2B & C3 & C4 & C5 & C6s & C7 & C8 & C9.ToString("#0.00") & "*" & C10.ToString("#0.00000") & "*" & C11.ToString("#0.00") & "*" & C12s & "*" & C13s & C14s & C15 & C16 & C17s & C18s & C19s & C20_All & "*" & C21_All & "*" & C22 '& "*" & C23
                    System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, C_SATZ & vbCrLf)

                Next

                Dim D_SATZ As String = Nothing
                D1 = dt.Rows.Item(i).Item("D1_Satzidentifikator") & "*"
                D2 = dt.Rows.Item(i).Item("D2_Ordnungskennzeichen") & "*"
                D3 = dt.Rows.Item(i).Item("D3_GesamtsaldoEinlagen")
                D4 = dt.Rows.Item(i).Item("D4_GesamtsaldoGesetzlicheAusschluesse")
                D5 = dt.Rows.Item(i).Item("D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen")
                D6 = dt.Rows.Item(i).Item("D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE")
                D7 = dt.Rows.Item(i).Item("D7_GesamtsaldoGesetzlichGedeckterEinlagen_UNTERGRENZE")
                D8 = dt.Rows.Item(i).Item("D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE")
                'D9 = dt.Rows.Item(i).Item("D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE")
                'D10 = dt.Rows.Item(i).Item("D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE")
                'D11 = dt.Rows.Item(i).Item("D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE")
                'D12 = dt.Rows.Item(i).Item("D12_GesamtsaldoZusatzabsicherung")
                'D13 = dt.Rows.Item(i).Item("D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG")
                'D14 = dt.Rows.Item(i).Item("D14_GesamtsaldoForderungenAnKunden")
                'D15 = dt.Rows.Item(i).Item("D15_GesamtsaldoNichtEWR_Niederlassungen")

                D_SATZ = D1 & D2 & D3.ToString("#0.00") & "*" & D4.ToString("#0.00") & "*" & D5.ToString("#0.00") & "*" & D6.ToString("#0.00") & "*" & D7.ToString("#0.00") & "*" & D8.ToString("#0.00") '& "*" & D9.ToString("#0.00") & "*" & D10.ToString("#0.00") & "*" & D11.ToString("#0.00") & "*" & D12.ToString("#0.00") & "*" & D13.ToString("#0.00") & "*" & D14.ToString("#0.00") & "*" & D15.ToString("#0.00") & "*"
                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, D_SATZ & vbCrLf)
            Next


            'E-SATZ
            System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, E_SATZ)


            CloseSqlConnections()

            SplashScreenManager.CloseForm(False)

        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwEinreicherDatei_ErstellungBASIS_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwEinreicherDatei_ErstellungBASIS.ProgressChanged
        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','EAEG Einreicherdatei erstellung Version 4.1 (BASIS)','EAEG Einreicherdatei erstellung Version 4.1 (BASIS)"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','EAEG Einreicherdatei erstellung Version 4.1 (BASIS)','EAEG Einreicherdatei erstellung Version 4.1 (BASIS)"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        CloseEVENT_SqlConnection()

    End Sub

    Private Sub BgwEinreicherDatei_ErstellungBASIS_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwEinreicherDatei_ErstellungBASIS.RunWorkerCompleted
        Workers_Complete(BgwEinreicherDatei_ErstellungBASIS, e)
        If XtraMessageBox.Show("Folgende DGS Datei wurde generiert: " & EAEGDATEI & vbNewLine _
                          & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
                   & EAEG_FILE_DIR & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "EAEG Datei BASIS erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            System.Diagnostics.Process.Start(EAEG_FILE_DIR)
        End If
    End Sub

#End Region

#Region "EAEG_MELDEDATEI_ERSTELLUNG_BASIS"
    Private Sub EAEG_Meldedatei_Erstellung_BASIS_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_MeldeDateiErstellung_BASIS_BarButtonItem.ItemClick

        Try

            ' initialize a new XtraInputBoxArgs instance
            Dim args As New XtraInputBoxArgs()
            ' set required Input Box options
            args.Caption = "ERSTELLUNG DER EAEG MELDEDATEI (BASIS Version 4.1)"
            args.Prompt = "Meldeinhalt - Bitte auswählen"
            args.DefaultButtonIndex = 0

            AddHandler args.Showing, AddressOf Args_Showing
            ' initialize a DateEdit editor with custom settings
            Dim MeldeinhaltList As New SearchLookUpEdit()
            MeldeinhaltList.Properties.PopupFormSize = New Size(1000, 400)
            Dim Meldeinhalt As GridColumn = MeldeinhaltList.Properties.View.Columns.AddField("Meldeinhalt")
            Meldeinhalt.FieldName = "Meldeinhalt"
            Meldeinhalt.Width = 100
            Meldeinhalt.Visible = True
            Dim Beschreibung As GridColumn = MeldeinhaltList.Properties.View.Columns.AddField("Beschreibung")
            Beschreibung.FieldName = "Beschreibung"
            Beschreibung.Width = 300
            Beschreibung.Visible = True

            MeldeinhaltList.Properties.View.OptionsView.ColumnAutoWidth = False
            MeldeinhaltList.Properties.View.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True
            MeldeinhaltList.Properties.View.OptionsView.ShowAutoFilterRow = True
            MeldeinhaltList.Properties.View.BestFitColumns()

            MELDEDATEI_SELECTION_initData()

            MeldeinhaltList.Properties.DataSource = BS_Meldedatei_Selection
            MeldeinhaltList.Properties.DisplayMember = "Meldeinhalt"
            MeldeinhaltList.Properties.ValueMember = "Meldeinhalt"
            args.Editor = MeldeinhaltList

            Dim result As Object = XtraInputBox.Show(args)
            If result IsNot Nothing Then
                If XtraMessageBox.Show("Soll die EAEG Meldedatei (BASIS) für den Stichtag: " & Me.Stichtag_BarEditItem.EditValue.ToString & " erstellt werden?" & vbNewLine & vbNewLine & "Vorhandene Datei mit den selben Namen wird dabei gelöscht!", "EAEG Meldedatei erstellung BASIS (Version 2.1)", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    rd = Me.Stichtag_BarEditItem.EditValue.ToString
                    rdsql = rd.ToString("yyyyMMdd")
                    Meldeinhalt_Meldedatei = MeldeinhaltList.EditValue.ToString
                    BgwMeldeDatei_ErstellungBASIS = New BackgroundWorker
                    bgws.Add(BgwMeldeDatei_ErstellungBASIS)
                    BgwMeldeDatei_ErstellungBASIS.WorkerReportsProgress = True
                    BgwMeldeDatei_ErstellungBASIS.RunWorkerAsync()

                End If
            Else
                XtraMessageBox.Show("Bitte um Auswahl des Meldeinhaltes", "KEIN MELDEINHALT AUSGEWÄHLT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try

    End Sub

    Private Sub BgwMeldeDatei_ErstellungBASIS_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwMeldeDatei_ErstellungBASIS.DoWork
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Datendefinition M Satz")

            'Datendefinition M Satz
            Dim EAEG_Stichtag As Date
            Dim EAEG_DateiName As String = Nothing
            Dim EAEG_Meldestichtag As String = Nothing
            Dim M_SATZ As String = Nothing

            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As Double = 0
            Dim M5 As Double = 0
            Dim M6 As Double = 0
            Dim M7 As Double = 0
            Dim M8 As Double = 0
            Dim M9 As Double = 0
            Dim M10 As Double = 0
            Dim M11 As Double = 0
            Dim M12 As Double = 0
            Dim M13 As Double = 0
            Dim M14 As Double = 0
            Dim M15 As Double = 0
            Dim M16 As Double = 0
            Dim M017 As Double = 0
            Dim M018 As Double = 0
            Dim M019 As Double = 0
            Dim M020 As Double = 0
            Dim M021 As Double = 0
            Dim M022 As Double = 0
            Dim M023 As Double = 0
            Dim M024 As Double = 0
            Dim M025 As Double = 0
            Dim M026 As Double = 0
            Dim M027 As Double = 0
            Dim M028 As Double = 0
            Dim M029 As Double = 0
            Dim M030 As Double = 0
            Dim M031 As Double = 0
            Dim M032 As Double = 0
            Dim M033 As Double = 0
            Dim M034 As Double = 0
            Dim M035 As Double = 0
            Dim M036 As Double = 0
            Dim M037 As Double = 0
            Dim M038 As Double = 0
            Dim M039 As Double = 0
            Dim M040 As Double = 0
            Dim M041 As Double = 0
            Dim M042 As Double = 0
            Dim M043 As Double = 0
            Dim M044 As Double = 0
            Dim M045 As Double = 0
            Dim M046 As Double = 0
            Dim M047 As Double = 0
            Dim M048 As Double = 0
            Dim M049 As Double = 0
            Dim M050 As Double = 0
            Dim M051 As Double = 0
            Dim M052 As Double = 0
            Dim M053 As Double = 0
            Dim M054 As Double = 0
            Dim M055 As Double = 0
            Dim M056 As Double = 0
            Dim M057 As Double = 0
            Dim M058 As Double = 0
            Dim M059 As Double = 0
            Dim M060 As Double = 0
            Dim M061 As Double = 0
            Dim M062 As Double = 0
            Dim M063 As Double = 0
            Dim M064 As Double = 0
            Dim M065 As Double = 0
            Dim M066 As Double = 0
            '
            Dim M067 As Double = 0
            Dim M068 As Double = 0
            Dim M069 As Double = 0
            Dim M070 As Double = 0
            Dim M071 As Double = 0
            Dim M072 As Double = 0
            Dim M073 As Double = 0
            Dim M074 As Double = 0
            Dim M075 As Double = 0
            Dim M076 As Double = 0
            Dim M077 As Double = 0
            Dim M078 As Double = 0
            Dim M079 As Double = 0
            Dim M080 As Double = 0
            Dim M081 As Double = 0
            Dim M082 As Double = 0
            Dim M083 As Double = 0
            Dim M084 As Double = 0
            Dim M085 As Double = 0
            Dim M086 As Double = 0
            Dim M087 As Double = 0
            Dim M088 As Double = 0
            Dim M089 As Double = 0
            Dim M090 As Double = 0
            Dim M091 As Double = 0
            Dim M092 As Double = 0
            Dim M093 As Double = 0
            Dim M094 As Double = 0
            Dim M095 As Double = 0
            Dim M096 As Double = 0
            Dim M097 As Double = 0
            Dim M098 As Double = 0
            Dim M099 As Double = 0
            Dim M100 As Double = 0
            Dim M101 As Double = 0
            Dim M102 As Double = 0
            Dim M103 As Double = 0
            Dim M104 As Double = 0
            Dim M105 As Double = 0
            Dim M106 As Double = 0
            Dim M107 As Double = 0
            Dim M108 As Double = 0
            Dim M109 As Double = 0
            Dim M110 As Double = 0
            Dim M111 As Double = 0
            Dim M112 As Double = 0
            Dim M113 As Double = 0
            Dim M114 As Double = 0
            Dim M115 As Double = 0
            Dim M116 As Double = 0
            '
            Dim M117 As Double = 0
            Dim M118 As Double = 0
            Dim M119 As Double = 0
            Dim M120 As Double = 0
            Dim M121 As Double = 0
            Dim M122 As Double = 0
            Dim M123 As Double = 0
            Dim M124 As Double = 0
            Dim M125 As Double = 0
            Dim M126 As Double = 0
            Dim M127 As Double = 0
            Dim M128 As Double = 0
            Dim M129 As Double = 0
            Dim M130 As Double = 0
            Dim M131 As Double = 0
            Dim M132 As Double = 0
            Dim M133 As Double = 0
            Dim M134 As Double = 0
            Dim M135 As Double = 0
            Dim M136 As Double = 0
            Dim M137 As Double = 0
            Dim M138 As Double = 0
            Dim M139 As Double = 0
            Dim M140 As Double = 0
            'Dim M141 As Double = 0
            'Dim M142 As Double = 0
            'Dim M143 As Double = 0
            'Dim M144 As Double = 0
            'Dim M145 As Double = 0
            'Dim M146 As Double = 0


            OpenSqlConnections()
            'A und E SATZ
            SplashScreenManager.Default.SetWaitFormCaption("Lade Daten für M Satz")
            QueryText = "SELECT  [ID],[EAEG_Stichtag],[A1_Satzidentifikator],[A2_Institut],[A3_ZugehoerigkeitZuEntsaedigungseinrichtungen],[A4_GesetzlicheEntschaedigungsobergrenzeEAEG],[A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland],[A6_SicherungsgrenzeBeiZusatzsicherung],[A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG],[E1_Satzidentifikator],[E2_Institut],[E3_GesamteinreichersaldoEinlagen],[E4_GesamteinreichersaldoAusschluesseEinSiG],[E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG],[E6_GesamteinreichersaldoGedekterEinlagenEinSiG],[E7_GesamteinreichersaldoKappungEinSiG],[E8_GesamteinreichersaldoEWR_Niederlassungen],[E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat],[E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut],[E11_GesamteinreichersaldoAusschlueseNurStatut],[E12_GesamteinreichersaldoZusatzsicherung],[E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG],[E14_GesamteinreichersaldoForderungenAnKunden],[E15_GesamteinreichersaldoNichtEWR_Niederlassungen] FROM [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                EAEG_Stichtag = dt.Rows.Item(0).Item("EAEG_Stichtag")
                EAEG_DateiName = EAEG_Stichtag.ToString("yyMMdd")
                EAEG_Meldestichtag = EAEG_Stichtag.ToString("yyMMdd")

                M1 = "M"
                M2 = dt.Rows.Item(0).Item("A2_Institut")
                M3 = EAEG_Meldestichtag
                M4 = dt.Rows.Item(0).Item("A4_GesetzlicheEntschaedigungsobergrenzeEAEG")
                M5 = dt.Rows.Item(0).Item("E3_GesamteinreichersaldoEinlagen")
                M6 = dt.Rows.Item(0).Item("E4_GesamteinreichersaldoAusschluesseEinSiG")
                M7 = dt.Rows.Item(0).Item("E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG")
                M8 = dt.Rows.Item(0).Item("E6_GesamteinreichersaldoGedekterEinlagenEinSiG")
                M9 = dt.Rows.Item(0).Item("E7_GesamteinreichersaldoKappungEinSiG")
                M10 = dt.Rows.Item(0).Item("E8_GesamteinreichersaldoEWR_Niederlassungen")
            Next

            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos1]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M11 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos2]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M12 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos3]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M13 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos4]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M14 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos5]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M15 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos6]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M16 = cmd.ExecuteScalar

            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos7]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M017 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos8]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M018 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos9]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M019 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos10]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M020 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos11]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M021 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos12]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M022 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos13]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M023 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos14]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M024 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos15]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M025 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos16]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M026 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos17]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M027 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos18]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M028 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos19]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M029 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos20]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M030 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos21]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M031 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos22]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M032 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos23]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M033 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos24]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M034 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos25]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M035 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos26]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M036 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos27]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M037 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos28]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M038 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos29]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M039 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos30]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M040 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos31]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M041 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos32]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M042 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos33]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M043 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos34]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M044 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos35]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M045 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos36]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M046 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos37]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M047 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos38]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M048 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos39]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M049 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos40]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M050 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos41]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M051 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos42]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M052 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos43]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M053 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos44]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M054 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos45]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M055 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos46]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M056 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos47]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M057 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos48]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M058 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos49]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M059 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos50]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M060 = cmd.ExecuteScalar

            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos1]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M061 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos2]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M062 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos3]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M063 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos4]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M064 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos5]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M065 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos6]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M066 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos7]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M067 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos8]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M068 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos9]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M069 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos10]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M070 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos11]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M071 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos12]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M072 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos13]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M073 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos14]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M074 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos15]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M075 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos16]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M076 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos17]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M077 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos18]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M078 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos19]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M079 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos20]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M080 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos21]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M081 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos22]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M082 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos23]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M083 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos24]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M084 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos25]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M085 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos26]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M086 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos27]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M087 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos28]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M088 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos29]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M089 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos30]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M090 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos31]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M091 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos32]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M092 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos33]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M093 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos34]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M094 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos35]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M095 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos36]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M096 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos37]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M097 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos38]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M098 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos39]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M099 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos40]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M100 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos41]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M101 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos42]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M102 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos43]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M103 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos44]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M104 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos45]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M105 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos46]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M106 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos47]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M107 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos48]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M108 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos49]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M109 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos50]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M110 = cmd.ExecuteScalar
            '
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('BE') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M111 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('BG') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M112 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('DK') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M113 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('EE') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M114 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('FI') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M115 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('FR') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M116 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('GR','EL') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M117 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('GB','UK') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M118 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('IE') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M119 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('IS') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M120 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('IT') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M121 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('HR') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M122 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('LV') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M123 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('LI') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M124 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('LT') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M125 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('LU') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M126 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('MT') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M127 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('NL') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M128 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('NO') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M129 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('AT') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M130 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('PL') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M131 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('PT') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M132 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('RO') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M133 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('SE') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M134 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('SK') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M135 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('SI') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M136 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('ES') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M137 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('CZ') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M138 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('HU') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M139 = cmd.ExecuteScalar
            cmd.CommandText = "Select Sum(Case when [C22_KennzeichenEWR_Niederlassung] in ('CY') then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
            M140 = cmd.ExecuteScalar


            M_SATZ = M1 & "*" & M2 & "*" & M3 & "*" & M4.ToString("#0.00") & "*" & M5.ToString("#0.00") & "*" & M6.ToString("#0.00") & "*" & M7.ToString("#0.00") & "*" & M8.ToString("#0.00") & "*" & M9.ToString("#0.00") & "*" & M10.ToString("#0.00") & "*" & M11.ToString("#0.00") & "*" & M12.ToString("#0.00") & "*" & M13.ToString("#0.00") & "*" & M14.ToString("#0.00") & "*" & M15.ToString("#0.00") & "*" & M16.ToString("#0.00") _
                    & "*" & M017.ToString("#0.00") & "*" & M018.ToString("#0.00") & "*" & M019.ToString("#0.00") & "*" & M020.ToString("#0.00") & "*" & M021.ToString("#0.00") & "*" & M022.ToString("#0.00") & "*" & M023.ToString("#0.00") & "*" & M024.ToString("#0.00") & "*" & M025.ToString("#0.00") & "*" & M026.ToString("#0.00") & "*" & M027.ToString("#0.00") & "*" & M028.ToString("#0.00") & "*" & M029.ToString("#0.00") & "*" & M030.ToString("#0.00") & "*" & M031.ToString("#0.00") & "*" & M032.ToString("#0.00") & "*" & M033.ToString("#0.00") & "*" & M034.ToString("#0.00") & "*" & M035.ToString("#0.00") & "*" & M036.ToString("#0.00") & "*" & M037.ToString("#0.00") & "*" & M038.ToString("#0.00") & "*" & M039.ToString("#0.00") & "*" & M040.ToString("#0.00") & "*" & M041.ToString("#0.00") & "*" & M042.ToString("#0.00") & "*" & M043.ToString("#0.00") & "*" & M044.ToString("#0.00") & "*" & M045.ToString("#0.00") & "*" & M046.ToString("#0.00") & "*" & M047.ToString("#0.00") & "*" & M048.ToString("#0.00") & "*" & M049.ToString("#0.00") & "*" & M050.ToString("#0.00") & "*" & M051.ToString("#0.00") & "*" & M052.ToString("#0.00") & "*" & M053.ToString("#0.00") & "*" & M054.ToString("#0.00") & "*" & M055.ToString("#0.00") & "*" & M056.ToString("#0.00") & "*" & M057.ToString("#0.00") & "*" & M058.ToString("#0.00") & "*" & M059.ToString("#0.00") & "*" & M060.ToString("#0.00") & "*" & M061.ToString("#0.00") & "*" & M062.ToString("#0.00") & "*" & M063.ToString("#0.00") & "*" & M064.ToString("#0.00") & "*" & M065.ToString("#0.00") & "*" & M066.ToString("#0.00") _
                    & "*" & M067.ToString("#0.00") & "*" & M068.ToString("#0.00") & "*" & M069.ToString("#0.00") & "*" & M070.ToString("#0.00") & "*" & M071.ToString("#0.00") & "*" & M072.ToString("#0.00") & "*" & M073.ToString("#0.00") & "*" & M074.ToString("#0.00") & "*" & M075.ToString("#0.00") & "*" & M076.ToString("#0.00") & "*" & M077.ToString("#0.00") & "*" & M078.ToString("#0.00") & "*" & M079.ToString("#0.00") & "*" & M080.ToString("#0.00") & "*" & M081.ToString("#0.00") & "*" & M082.ToString("#0.00") & "*" & M083.ToString("#0.00") & "*" & M084.ToString("#0.00") & "*" & M085.ToString("#0.00") & "*" & M086.ToString("#0.00") & "*" & M087.ToString("#0.00") & "*" & M088.ToString("#0.00") & "*" & M089.ToString("#0.00") & "*" & M090.ToString("#0.00") & "*" & M091.ToString("#0.00") & "*" & M092.ToString("#0.00") & "*" & M093.ToString("#0.00") & "*" & M094.ToString("#0.00") & "*" & M095.ToString("#0.00") & "*" & M096.ToString("#0.00") & "*" & M097.ToString("#0.00") & "*" & M098.ToString("#0.00") & "*" & M099.ToString("#0.00") & "*" & M100.ToString("#0.00") & "*" & M101.ToString("#0.00") & "*" & M102.ToString("#0.00") & "*" & M103.ToString("#0.00") & "*" & M104.ToString("#0.00") & "*" & M105.ToString("#0.00") & "*" & M106.ToString("#0.00") & "*" & M107.ToString("#0.00") & "*" & M108.ToString("#0.00") & "*" & M109.ToString("#0.00") & "*" & M110.ToString("#0.00") & "*" & M111.ToString("#0.00") & "*" & M112.ToString("#0.00") & "*" & M113.ToString("#0.00") & "*" & M114.ToString("#0.00") & "*" & M115.ToString("#0.00") & "*" & M116.ToString("#0.00") _
                    & "*" & M117.ToString("#0.00") & "*" & M118.ToString("#0.00") & "*" & M119.ToString("#0.00") & "*" & M120.ToString("#0.00") & "*" & M121.ToString("#0.00") & "*" & M122.ToString("#0.00") & "*" & M123.ToString("#0.00") & "*" & M124.ToString("#0.00") & "*" & M125.ToString("#0.00") & "*" & M126.ToString("#0.00") & "*" & M127.ToString("#0.00") & "*" & M128.ToString("#0.00") & "*" & M129.ToString("#0.00") & "*" & M130.ToString("#0.00") & "*" & M131.ToString("#0.00") & "*" & M132.ToString("#0.00") & "*" & M133.ToString("#0.00") & "*" & M134.ToString("#0.00") & "*" & M135.ToString("#0.00") & "*" & M136.ToString("#0.00") & "*" & M137.ToString("#0.00") & "*" & M138.ToString("#0.00") & "*" & M139.ToString("#0.00") & "*" & M140.ToString("#0.00") '& "*" & M141.ToString("#0.00") & "*" & M142.ToString("#0.00") & "*" & M143.ToString("#0.00") & "*" & M144.ToString("#0.00") & "*" & M145.ToString("#0.00") & "*" & M146.ToString("#0.00")



            'PRODUKTION
            If Meldeinhalt_Meldedatei = "Produktion" Then

                EAEGDATEI = "P0000000" & M2 & EAEG_DateiName & ".csv"

                If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
                    File.Delete(EAEG_FILE_DIR & EAEGDATEI)
                End If

                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, M_SATZ & vbCrLf)

                CloseSqlConnections()

                SplashScreenManager.CloseForm(False)



            ElseIf Meldeinhalt_Meldedatei = "Korrektur" Then
                'KORREKTUR
                EAEGDATEI = "K0000000" & M2 & EAEG_DateiName & ".csv"

                If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
                    File.Delete(EAEG_FILE_DIR & EAEGDATEI)
                End If

                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, M_SATZ & vbCrLf)

                CloseSqlConnections()

                SplashScreenManager.CloseForm(False)



            ElseIf Meldeinhalt_Meldedatei = "Test" Then
                'TEST
                EAEGDATEI = "T0000000" & M2 & EAEG_DateiName & ".csv"

                If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
                    File.Delete(EAEG_FILE_DIR & EAEGDATEI)
                End If

                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, M_SATZ & vbCrLf)

                CloseSqlConnections()

                SplashScreenManager.CloseForm(False)



            End If

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub BgwMeldeDatei_ErstellungBASIS_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwMeldeDatei_ErstellungBASIS.ProgressChanged
        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','EAEG Meldedatei erstellung Version 4.1 (BASIS)','EAEG Meldedatei erstellung Version 4.1 (BASIS)"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','EAEG Meldedatei erstellung Version 4.1 (BASIS)','EAEG Meldedatei erstellung Version 4.1 (BASIS)"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        CloseEVENT_SqlConnection()

    End Sub

    Private Sub BgwMeldeDatei_ErstellungBASIS_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwMeldeDatei_ErstellungBASIS.RunWorkerCompleted
        Workers_Complete(BgwMeldeDatei_ErstellungBASIS, e)
        If XtraMessageBox.Show("Folgende csv Datei wurde für " & Meldeinhalt_Meldedatei.ToUpper & " generiert: " & EAEGDATEI & vbNewLine _
                              & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
                       & EAEG_FILE_DIR & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "EAEG Meldedatei BASIS (" & Meldeinhalt_Meldedatei.ToUpper & ") erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            System.Diagnostics.Process.Start(EAEG_FILE_DIR)
        End If


    End Sub

#End Region

#Region "TOOL TIPS"

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        'B SÄTZE
        If e.SelectedControl.Name = GridControl2.Name Then
            Dim view As GridView = TryCast(GridControl2.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(13)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                If ColumnFieldName.StartsWith("B") = True Then
                    Select Case ColumnFieldName
                        Case Is = "B1_Satzidentifikator"
                            args.Contents.Text = "Konstante 'B'"
                        Case Is = "B2_Ordnungskennzeichen"
                            args.Contents.Text = "Numerisches oder alphanumerisches Kennzeichen (z. B. Kundennummer), das den Kunden (natürliche oder juristische Person, Personen-, Wohnungseigentümergemeinschaft,Fonds-Sondervermögen etc.) eindeutig und einmalig identifiziert."
                        Case Is = "B3_Nachname"
                            args.Contents.Text = "Bei natürlichen / juristischen Personen oder Personengemeinschaften die entsprechende Bezeichnung gemäß § 154 Abgabenordnung bei Wohnungseigentümergemeinschaften die Bezeichnung derselben."
                        Case Is = "B4_Vorname"
                            args.Contents.Text = "Vorname"
                        Case Is = "B5_Namenszusatz"
                            args.Contents.Text = "Gegebenenfalls weitere und den Kunden zusätzlich identifizierende Informationen bzw. die Felder B3 und B4 ergänzende Sachverhalte."
                        Case Is = "B6_Anrede"
                            args.Contents.Text = "0 Ohne bzw. nicht zu den Werten '1' bis '5' korrespondierende Anrede" & vbNewLine &
                                "1 - Herr" & vbNewLine &
                                "2 - Frau" & vbNewLine &
                                "3 - Firma" & vbNewLine &
                                "4 - Herr und Frau" & vbNewLine &
                                "5 - Eheleute"
                        Case Is = "B7_SrasseUndHausnummer"
                            args.Contents.Text = "Straße und Hausnummer, gegebenenfalls auch Postfach, unter der der Kunde postalisch eindeutig zu erreichen ist."
                        Case Is = "B8_ZusatzStrasse"
                            args.Contents.Text = "Weitere, für die korrekte Postzusendung relevante Informationen (z. B. Ortsteilbezeichnung, Wohnungsnummer etc.)."
                        Case Is = "B9_Postleitzahl"
                            args.Contents.Text = "Postleitzahl"
                        Case Is = "B10_Ort"
                            args.Contents.Text = "Wohnort des Kunden"
                        Case Is = "B11_Land"
                            args.Contents.Text = "Angabe des Länderschlüssels gemäß Kodierliste ISO-3166-1-alpha2."
                        Case Is = "B12_Geburtsdatum"
                            args.Contents.Text = "Geburts- / Gründungsdatum in der Form TTMMJJJJ."
                        Case Is = "B13_Branche"
                            args.Contents.Text = "Wert gemäß Angaben der Deutschen Bundesbank 'Bankenstatistik Kundensystematik'."
                        Case Is = "B14_Ausschlusskennzeichen_GESAMT"
                            args.Contents.Text = "INFO Feld: Wenn eine Position in B14 (1 bis 50) mit Y belegt ist dann (Y)-Kunde ist ausgeschlossen sonst (N)-Kunde ist nit ausgeschlossen"
                        Case Is = "B14_Ausschlusskennzeichen_Pos2"
                            args.Contents.Text = "Finanzinstitute im Sinne des Artikels 4 Absatz 1 Nr. 26 der Verordnung (EU) Nr. 575/2013"
                        Case Is = "B14_Ausschlusskennzeichen_Pos3"
                            args.Contents.Text = "Einlagen von Versicherungs- und Rückversicherungsunternehmen im Sinne des Artikels 13 Nummer 1 bis 6 der Richtlinie 2009/138/EG des Europäischen Parlaments und des Rates vom 25.11.2009 betreffend die Aufnahme und Ausübung der Versicherungs- und der Rückversicherungstätigkeit (Solvabilität II) (ABl. L 335 vom 17.12.2009, S. 1)"
                        Case Is = "B14_Ausschlusskennzeichen_Pos4"
                            args.Contents.Text = "Einlagen von Organismen für gemeinsame Anlagen im Sinne des Artikels 4 Absatz 1 Nummer 7 der Verordnung (EU) Nr. 575/2013"
                        Case Is = "B14_Ausschlusskennzeichen_Pos5"
                            args.Contents.Text = "Der Bund, ein Land, ein rechtlich unselbständiges Sondervermögen des Bundes oder eines Landes, eine kommunale Gebietskörperschaft, ein anderer Staat oder eine Regionalregierung oder eine örtliche Gebietskörperschaft eines anderen Staates"
                        Case Is = "B14_Ausschlusskennzeichen_Pos6"
                            args.Contents.Text = "Einlagen von Wertpapierfirmen im Sinne des Artikels 4 Absatz 1 Nummer 1 der Richtlinie 2004/39/EG des Europäischen Parlaments und des Rates vom 21.04.2004 über Märkte für Finanzinstrumente, zur Änderung der Richtlinien 85/611/EWG und 93/6/EWG des Rates und der Richtlinie 2000/12/EG des Europäischen Parlaments und des Rates und zur Aufhebung der Richtlinie 93/22/EWG des Rates (ABl. L 145 vom 30.04.2004, S. 1)"
                        Case Is = "B14_Ausschlusskennzeichen_Pos7"
                            args.Contents.Text = "Pensions- und Rentenfonds, insbesondere von Einrichtungen der betrieblichen Altersversorgung im Sinne des Artikels 6 Buchstabe a der Richtlinie 2003/41/EG des Europäischen Parlaments und des Europäischen Rates vom 03.06.2003 über die Tätigkeiten und die Beaufsichtigung von Einrichtungen der betrieblichen Altersversorgung (ABl. L 235 vom 23.09.2003, S. 10)"
                        Case Is = "B14_Ausschlusskennzeichen_Pos8"
                            args.Contents.Text = "Gläubiger, bei denen die Identität nach Artikel 9 Absatz 1 der Richtlinie 2005/60/EG niemals festgestellt wurde"
                        Case Is = "B14_Ausschlusskennzeichen_Pos10"
                            args.Contents.Text = "Gläubiger, deren Ansprüche gegen das Institut im Zusammenhang mit Geschäften stehen, auf Grund derer Personen in einem Strafverfahren wegen Geldwäsche im Sinne des Artikels 1 der Richtlinie 2005/60/EG des Europäischen Parlaments und des Rates vom 26.10.2005 zur Verhinderung der Nutzung des Finanzsystems zum Zwecke der Geldwäsche und der Terrorismusfinanzierung (ABl. L 309 vom 25.11.2005, S. 15) rechtskräftig verurteilt worden sind"
                        Case Is = "B14_Ausschlusskennzeichen_Pos31"
                            args.Contents.Text = "Personen, die einen Anteil von 50 vom Hundert und mehr am Kapital des Instituts halten, jedoch ohne Berücksichtigung solcher Ansprüche, die zum gebundenen Vermögen im Sinne des § 54 VAG oder zum Fondsvermögen im Sinne des § 2 InvG zählen "
                        Case Is = "B14_Ausschlusskennzeichen_Pos32"
                            args.Contents.Text = "Ehegatten und minderjährige Kinder der in den Positionen 31 und 35 genannten Personen, es sei denn, dass die Gelder aus dem eigenen Vermögen stammen"
                        Case Is = "B14_Ausschlusskennzeichen_Pos33"
                            args.Contents.Text = "(Dritte) Personen, die für Rechnung einer der unter den Positionen 31, 32 oder 35 genannten Personen handeln"
                        Case Is = "B14_Ausschlusskennzeichen_Pos34"
                            args.Contents.Text = "Konzernverbundene Unternehmen des Instituts im Sinne des § 18 AktG"
                        Case Is = "B14_Ausschlusskennzeichen_Pos35"
                            args.Contents.Text = "Geschäftsleiter, persönlich haftende Gesellschafter oder Mitglieder von Aufsichtsorganen des Instituts"
                        Case Is = "B15_Kundenkontakt"
                            args.Contents.Text = "Gegebenenfalls vorhandene alternative Kontaktmöglichkeiten zum Kunden (beispielsweise E-Mail-Adresse)."
                        Case Else
                            args.Contents.Text = "Derzeit ohne Verwendung"
                    End Select
                    SuperTip.Setup(args)
                    e.Info.SuperTip = SuperTip
                End If
                If ColumnFieldName.StartsWith("D") = True Then
                    Select Case ColumnFieldName
                        Case Is = "D1_Satzidentifikator"
                            args.Contents.Text = "Konstante 'D'"
                        Case Is = "D2_Ordnungskennzeichen"
                            args.Contents.Text = "Numerisches oder alphanumerisches Kennzeichen (z. B. Kundennummer), das den Kunden (natürliche oder juristische Person, Personen-, Wohnungseigentümergemeinschaft, Fonds- Sondervermögen etc.) eindeutig und einmalig identifiziert."
                        Case Is = "D3_GesamtsaldoEinlagen"
                            args.Contents.Text = "Summe kreditorischer Kontosalden aus Feld C19."
                        Case Is = "D4_GesamtsaldoGesetzlicheAusschluesse"
                            args.Contents.Text = "Summe kreditorischer Kontosalden aus Feld C19,wenn mindestens eine Position in Feld B14,Bereich '01' bis '30', mit dem Wert 'Y' belegt ist,sonst:Sofern Feld D3 kleiner 20 Euro ist und bei sämtlichen kreditorischen Konten (Feld C19) des Kunden in Feld C20 an Position '01' der Wert 'Y'belegt ist, der Wert aus Feld D3,sonst:Summe kreditorischer Kontosalden aus Feld C19,wenn mindestens eine Position in Feld C20,Bereich '02' bis '20', mit dem Wert 'Y' belegt ist."
                        Case Is = "D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen"
                            args.Contents.Text = "Für Institute mit Wert '01' oder '10' in Feld A3:Ergebnis aus Feld D3 ./. Feld D4.Von den übrigen Instituten ist der Wert '0,00'einzustellen."
                        Case Is = "D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE"
                            args.Contents.Text = "Für Institute mit Wert '01' oder '10' in Feld A3: Ergebnis aus Feld D5 maximal bis zur Höhe des Ergebnisses aus Feld A4 * Feld C5.Von den übrigen Instituten ist der Wert '0,00' einzustellen."
                        Case Is = "D7_GesamtsaldoGesetzlichGedeckterEinlagen_UNTERGRENZE"
                            args.Contents.Text = "Für Institute mit Wert '01' oder '10' in Feld A3:Ergebnis aus Feld D5 ./. Feld D6."
                        Case Is = "D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE"
                            args.Contents.Text = "Summe kreditorischer Kontosalden aus Feld C19, wenn Feld C22 einen Eintrag enthält."
                        Case Is = "D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE"
                            args.Contents.Text = "Für Institute mit Wert '20' in Feld A3:Ergebnis aus Feld D3 maximal bis zur Höhe des Ergebnisses aus Feld A5 * Feld C5.Von den übrigen Instituten ist der Wert '0,00'einzustellen."
                        Case Is = "D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE"
                            args.Contents.Text = "Für Institute mit Wert '10' oder '20' in Feld A3:Summe kreditorischer Kontosalden aus Feld C19,wenn mindestens eine Position in Feld B14,Bereich '31' bis '50', mit dem Wert 'Y' belegt ist,sonst:Summe kreditorischer Kontosalden aus Feld C19,wenn mindestens eine Position in Feld C20,Bereich '11' bis '50', mit dem Wert 'Y' belegt ist."
                        Case Is = "D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE"
                            args.Contents.Text = "Für Institute mit Wert '10' oder '20' in Feld A3:Summe kreditorischer Kontosalden aus Feld C19,wenn mindestens eine Position in Feld B14,Bereich '31' bis '50', mit dem Wert 'Y' belegt ist,sonst:Summe kreditorischer Kontosalden aus Feld C19,wenn mindestens eine Position in Feld C20,Bereich '21' bis '50', mit dem Wert 'Y' belegt ist."
                        Case Is = "D12_GesamtsaldoZusatzabsicherung"
                            args.Contents.Text = "Für Institute mit Wert '10' oder '20' in Feld A3:Ergebnis aus Feld D3 ./. Feld D10 ./. Feld D14.Maximal bis zur Höhe des Ergebnisses aus Feld A6 * Feld C5. Von diesem Zwischenergebnis sind die in den Feldern D6 und D9 eingetragenen Werte in Abzug zu bringen.Zu beachten: Für Kunden mit Konten, für die an Position 05 in Feld C21 der Wert 'Y' gesetzt ist, istzur Berechnung von Feld D12 als Wert vonFeld C5 die '1' zu verwenden.Von den übrigen Instituten oder bei einemnegativen Ergebnis ist der Wert '0,00'einzustellen."
                        Case Is = "D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG"
                            args.Contents.Text = "Für Institute mit Wert '10' oder '20' in Feld A3 und sofern Feld D3 nach Abzug von Feld D14 das Ergebnis aus Feld A6 * Feld C5 übersteigt: Der das Ergebnis aus Feld A6 * Feld C5 übersteigende Anteil derjenigen kreditorischen Kontosalden aus Feld C19, für die der Wert 'Y' an Position 11 in Feld C21 gesetzt und durchgängig der Wert 'N' in den Positionen '21' bis '35' in Feld B14 sowie Positionen '11' bis '50' in Feld C20 eingestellt ist. Maximal bis zur Höhe des Ergebnisses aus Feld D3 ./. Feld D14 ./. Feld D6 ./.Feld D9./. Feld D12 und bis maximal zur Höhe des Ergebnisses aus (Feld A7 ./. Feld A6) * Feld C5.Zu beachten: Für Kunden mit Konten, für die an Position 05 in Feld C21 der Wert 'Y' gesetzt ist, ist zur Berechnung von Feld D13 als Wert von Feld C5 die '1' zu verwenden.Bei nicht zutreffenden Eingangsbedingungen oder bei einem negativen Ergebnis ist der Wert'0,00' einzustellen."
                        Case Is = "D14_GesamtsaldoForderungenAnKunden"
                            args.Contents.Text = "Für Institute mit Wert '10' oder '20' in Feld A3:Summe der debitorischen Kontosalden aus Feld C19."
                        Case Is = "D15_GesamtsaldoNichtEWR_Niederlassungen"
                            args.Contents.Text = "Summe kreditorischer Kontosalden aus Feld C19,wenn Feld C23 einen Eintrag enthält."

                    End Select
                    SuperTip.Setup(args)
                    e.Info.SuperTip = SuperTip
                End If

            End If
        End If

        'C SÄTZE
        If e.SelectedControl.Name = GridControl3.Name Then
            Dim view As GridView = TryCast(GridControl3.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(13)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "B2_OrdnungskennzeichenId"
                        args.Contents.Text = "Numerisches oder alphanumerisches Kennzeichen (z. B. Kundennummer), das den Kunden (natürliche oder juristische Person, Personen-, Wohnungseigentümergemeinschaft,Fonds-Sondervermögen etc.) eindeutig und einmalig identifiziert."
                    Case Is = "C1_Satzidentifikator"
                        args.Contents.Text = "Konstante C"
                    Case Is = "C2_Kontonummer"
                        args.Contents.Text = "Numerisches oder alphanumerisches Kennzeichen, welches das Konto / Geschäft eindeutig identifiziert."
                    Case Is = "Kontoname"
                        args.Contents.Text = "Name auf dem das Konto lautet"
                    Case Is = "C3_Kontozusatzbezeichnung"
                        args.Contents.Text = "Etwaige weitere Informationen zum Verwendungszweck des Kontos (z. B. Gemeinschafts-, Miet-, Anderkonto etc.)."
                    Case Is = "C4_AbweichendWirtschftlichBerechtigter"
                        args.Contents.Text = "Wert <Y> bei existierender abweichend wirtschaftlicher Berechtigung, ansonsten Wert <N>"
                    Case Is = "C5_AnzahlKontoinhaber"
                        args.Contents.Text = "Erforderlich für die korrekte Aufteilung von Einlagen, die als Gemeinschaftskonten bereitVersion 4.1  Juli 2015 | 9 | Feld-Nr. Feld Typ Erläuterung gestellt wurden. Bei Wohnungseigentümergemeinschaften Angabe der Anzahl der einzelnen Miteigentümer."
                    Case Is = "C6_Kontoerröfnung"
                        args.Contents.Text = "Datum der Kontoeröffnung in der Form TTMMJJJJ."
                    Case Is = "C7_Kontoart"
                        args.Contents.Text = "Bezeichnung des Produkts (Kontokorrent, Termingeld etc.)."
                    Case Is = "C8_Währung"
                        args.Contents.Text = "Eintrag des Währungsschlüssels gemäß ISO-4217-Codetabelle."
                    Case Is = "C9_KapitalsaldoInKontowährung"
                        args.Contents.Text = "Kapitalsaldo nach Tagesendeverarbeitung.Bei einem debitorischen Saldo ist das Vorzeichen '-' dem Betrag voranzustellen."
                    Case Is = "C10_Umrechnungskurs"
                        args.Contents.Text = "Der zum Stichtag veröffentlichte Referenzkurs der EZB; bei Einlagen in Euro der Wert '1,00000'.Liegt ein Referenzkurs der EZB nicht vor, ist für die Umrechnung der Mittelkurs aus feststellbaren An- und Verkaufskursen des Stichtages zugrunde zu legen."
                    Case Is = "C11_KapitalsaldoInEuro"
                        args.Contents.Text = "Kapitalsaldo gemäß Feld C9 unter Anwendung des Umrechnungskurses in Feld C10"
                    Case Is = "C12_Zinssatz"
                        args.Contents.Text = "Zum Stichtag gültiger Haben-Zinssatz in Prozent.Bei Produkten mit betragsabhängiger(Staffel-)Verzinsung sowie bei Produkten mit typischerweise wechselnden Zinssätzen (z. B.Verzinsung mit Anlehnung an Interbankenzinssatz)ist eine durchgehende Belegung mit der Ziffer '9' vorzunehmen ('99999,99999'). Bei negativem Haben-Zinssatz ist das Vorzeichen '-'dem Zinssatz voranzustellen.Für Konten mit Anwendung einer Haben- und Soll-Verzinsung (z. B. bei einigen Kontokorrentkonten)ist ausschließlich der Zinssatz für die Habenverzinsung zu berücksichtigen. Für Konten mit alleiniger Sollverzinsung ist keine Bereitstellung eines Zinssatzes erforderlich."
                    Case Is = "C13_LetzteZinsfaelligkeit"
                        args.Contents.Text = "Datum der letzten Zinsfälligkeit in der Form TTMMJJJJ """
                    Case Is = "C14_Endfaelligkeit"
                        args.Contents.Text = "Datum der Einlage-Rückzahlung in der Form TTMMJJJJ """
                    Case Is = "Zinstage"
                        args.Contents.Text = "Berechnete Zinstage"
                    Case Is = "C15_Faelligkeitsmerkmal"
                        args.Contents.Text = "Wert 'Y' bei Fälligkeit zum Stichtag, ansonsten Wert 'N'."
                    Case Is = "C16_Zinsmethode"
                        args.Contents.Text = "Angewandte Methode zur Berechnung der Haben-Zinsen" & vbNewLine &
                            "01 - Act/360 (Eurozinsmethode)" & vbNewLine &
                            "02 - Act/365 (Englische Zinsmethode)" & vbNewLine &
                            "03 - Act/Act (Taggenaue oder Effektivzinsmethode)" & vbNewLine &
                            "04 - 30/360 (Deutsche oder kaufmännische Zinsmethode)" & vbNewLine &
                            "05 - (30(28-29)/360) (US-Zinsmethode)" & vbNewLine &
                            "06 – 10 Derzeit nicht belegt"
                    Case Is = "C17_ZinssaldoInKontowährung"
                        args.Contents.Text = "Für Konten mit alleiniger Sollverzinsung ist keine Bereitstellung von Zinssalden erforderlich.In den übrigen Fällen Bereitstellung des stichtagsbezogenen Brutto-Zinssaldos (einschl. der Berücksichtigung etwaiger Sollzinsen, soweit die Produktmerkmale - z. B. im Kontokorrentbereich - dies vorsehen).Debitorische Salden sind mit dem Vorzeichen '-' zu versehen."
                    Case Is = "C18_ZinssaldoInEuro"
                        args.Contents.Text = "Zinssaldo gemäß Feld C17 unter Anwendung des Umrechnungskurses in Feld C10."
                    Case Is = "C19_KontosaldoInEuro"
                        args.Contents.Text = "Summe aus Feld C11 und Feld C18. Debitorische Salden sind mit dem Vorzeichen ' - ' zu versehen."
                    Case Is = "C20_Ausschlusskennzeichen_GESAMT"
                        args.Contents.Text = "INFO-Feld: Wenn mind. eine Position in C20 (1 bis 50) mit Y belegt ist dann (Y)-Kundenkonto ist ausgeschlossen sonst (N)-Kundenkonto ist nicht ausgeschlossen"
                    Case Is = "C20_Ausschlusskennzeichen_Pos1"
                        args.Contents.Text = "Konto mit einem kreditorischen Saldo kleiner 20 Euro in Feld C19, wenn in den letzten 24 Monaten keine Transaktion in Verbindung mit der Einlage stattgefunden hat."
                    Case Is = "C20_Ausschlusskennzeichen_Pos2"
                        args.Contents.Text = "In der Bilanzposition -Verbindlichkeiten gegenüber Kunden- auszuweisende Verbindlichkeiten aus Orderschuldverschreibungen und Verbindlichkeiten aus eigenen Akzepten und Solawechseln"
                    Case Is = "C20_Ausschlusskennzeichen_Pos3"
                        args.Contents.Text = "Ein Guthaben, dass nur durch ein Finanzinstrument im Sinne des § 2 Absatz 2b des Wertpapierhandelsgesetzes nachgewiesen werden kann, es sei denn, es handelt sich um ein Sparprodukt, das durch ein auf eine benannte Person lautendes Einlagenzertifikat verbrieft ist und bereits zum 02.07.2014 bestand"
                    Case Is = "C20_Ausschlusskennzeichen_Pos4"
                        args.Contents.Text = "Guthaben, das nicht zum Nennwert rückzahlbar ist"
                    Case Is = "C20_Ausschlusskennzeichen_Pos5"
                        args.Contents.Text = "Guthaben, das nur im Rahmen einer bestimmten, vom Institut oder einem Dritten gestellten Garantie oder Vereinbarung rückzahlbar ist"
                    Case Is = "C20_Ausschlusskennzeichen_Pos11"
                        args.Contents.Text = "Verbindlichkeiten, über die eine Bank Inhaberpapiere ausgestellt hat"
                    Case Is = "C20_Ausschlusskennzeichen_Pos21"
                        args.Contents.Text = "Einlagen, zu deren Sicherstellung Hypothekennamenspfandbriefe und öffentliche Namenspfandbriefe ausgegeben sind"
                    Case Is = "C20_Ausschlusskennzeichen_Pos22"
                        args.Contents.Text = "In der Bilanzposition -Verbindlichkeiten gegenüber Kunden- auszuweisende Verbindlichkeiten aus begebenen Hypotheken-Namenspfandbriefen oder öffentlichen Namenspfandbriefen"
                    Case Is = "C20_Ausschlusskennzeichen_Pos23"
                        args.Contents.Text = "In der Bilanzposition -Verbindlichkeiten gegenüber Kunden- auszuweisende Wertpapierpensions- bzw. Repogeschäfte"
                    Case Is = "C20_Ausschlusskennzeichen_Pos24"
                        args.Contents.Text = "In der Bilanzposition -Verbindlichkeiten gegenüber Kunden- auszuweisende Rücklieferungsverpflichtungen aus Wertpapierleihgeschäften"
                    Case Is = "C21_WeitereZustandsverschluesselungen_GESAMT"
                        args.Contents.Text = "INFO-Feld: Wenn mind. eine Position in C21 (1 bis 50) mit Y belegt ist dann (Y)-Kundenkonto hat weitere Zustandsverschlüsselungen sonst (N)-Kundenkonto hat keine Zustandsverschlüsselungen"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos1"
                        args.Contents.Text = "Mietkautionskonten"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos2"
                        args.Contents.Text = "Verpfändete bzw. abgetretene Guthaben"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos3"
                        args.Contents.Text = "Treuhänder und Insolvenzverfahren"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos4"
                        args.Contents.Text = "Pfändungen gemäß § 829 ZPO"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos5"
                        args.Contents.Text = "Wohnungseigentümergemeinschaftskonten"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos6"
                        args.Contents.Text = "Nachlass- bzw. Erbschaftskonten"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos7"
                        args.Contents.Text = "Vormundschaft, Betreuung, Pflegschaft"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos8"
                        args.Contents.Text = "Pfändungsschutzkonten (P-Konto) gemäß § 850k Abs. 7 ZPO"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos9"
                        args.Contents.Text = "Treuhandzahlungen i. S. § 21 Abs. 3 RechKredV"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos10"
                        args.Contents.Text = "Konten mit einem kreditorischen Saldo, wenn in den letzten 24 Monaten keine Transaktion in Verbindung mit der Einlage stattgefunden haben"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos11"
                        args.Contents.Text = "Einlagen, die vor dem 31.12.2011 begründet und seitdem nicht prolongiert oder fällig wurden sowie keine Kündigungsmöglichkeiten hatten"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos12"
                        args.Contents.Text = "Kennzeichen für solche Konten oder Kontenanteile, die bei der Aufteilung von Gemeinschaftskonten unter einem neuen, eindeutigen und einmaligen Ordnungskennzeichen zusammengefasst wurden"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos13"
                        args.Contents.Text = "Einlagen, die restriktiven Maßnahmen unterliegen, die von einer zuständigen deutschen Behörde oder der Europäischen Union oder von einem anderen Staat oder einer internationalen Organisation verhängt worden sind und die für die Bundesrepublik Deutschland rechtlich verbindlich sind, bis zur Aufhebung der betreffenden Maßnahme"
                    Case Is = "C21_WeitereZustandsverschluesselungen_Pos14"
                        args.Contents.Text = "Einlagen, zu welchen Tatsachen darauf hindeuten, dass der Entschädigungsanspruch sich auf Vermögenswerte bezieht, die im Zusammenhang mit Geldwäsche oder Terrorismusfinanzierung stehen und aus diesem Grund ein Ermittlungsverfahren gegen Personen eingeleitet worden ist, bis zur Beendigung dieses Verfahrens."
                    Case Is = "C22_KennzeichenEWR_Niederlassung"
                        args.Contents.Text = "Angabe des Länderschlüssels gemäß Kodierliste ISO-3166-1-alpha2 für den EWR-Staat, in welchem die Zweigniederlassung des inländischen CRR-Kreditinstituts das Konto führt, sonst leer."
                    Case Is = "C23_KennzeichenNichtEWR_Niederlassung"
                        args.Contents.Text = "Angabe des Länderschlüssels gemäß Kodierliste ISO-3166-1-alpha2 für den Staat außerhalb des EWR-Raums, in welchem die Zweigniederlassung des inländischen CRR-Kreditinstituts das Konto führt, sonst leer."
                    Case Else
                        args.Contents.Text = "Derzeit ohne Verwendung"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If
    End Sub

#End Region

    Private Sub EAEG_Dates_GridView_DoubleClick(sender As Object, e As EventArgs) Handles EAEG_Dates_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("EAEG_Stichtag")
            Me.Stichtag_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
            Me.EAEG_C_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_C_Satz_Version4, rd)
            Me.EAEG_B_D_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_B_D_Satz_Version4, rd)
            Me.EAEG_A_E_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_A_E_Satz_Version4, rd)
            Me.LayoutControl2.Visible = False
            Me.ViewDetails_SwitchItem.Checked = True
        End If
    End Sub

    Private Sub EAEG_Dates_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles EAEG_Dates_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("EAEG_Stichtag")
            Me.Stichtag_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
        End If
    End Sub



    Private Sub EAEG_Bilanz_Differences_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Bilanz_Differences_BarbuttonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.Stichtag_BarEditItem.EditValue.ToString)

            BgwExcelLoad = New BackgroundWorker
            BgwExcelLoad.WorkerReportsProgress = True
            BgwExcelLoad.RunWorkerAsync()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwExcelLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad.DoWork
        rd = Me.Stichtag_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_EAEG_BILANZ_DIFFERENCE' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and [PARAMETER STATUS]='Y' "
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        CloseSqlConnections()

        QueryText = "Select * from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BILANZ_Differences')  and [Status] in ('Y') and Id_SQL_Parameters in ('EAEG')"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
        da = New SqlDataAdapter(SqlCommandText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)

        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with Data results")
        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument(ExcelFileName, DocumentFormat.OpenXml)
        Dim worksheet As Worksheet = workbook.Worksheets(0)

        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet.ClearContents(worksheet("A2:Q10000"))

        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
        worksheet.Import(dt, False, 1, 0)

        Dim DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            DETAILS_LastRow = dt.Rows.Count + 1

            Dim RangeDETAILS_H As CellRange = worksheet.Range("H2:H" & DETAILS_LastRow)
            RangeDETAILS_H.Formula = "=F2+G2"
            Dim RangeDETAILS_J As CellRange = worksheet.Range("J2:J" & DETAILS_LastRow)
            RangeDETAILS_J.Formula = "=ROUND(H2/I2;2)"
            Dim RangeDETAILS_M As CellRange = worksheet.Range("M2:M" & DETAILS_LastRow)
            RangeDETAILS_M.Formula = "=K2+L2"
            Dim RangeDETAILS_O As CellRange = worksheet.Range("O2:O" & DETAILS_LastRow)
            RangeDETAILS_O.Formula = "=ROUND(M2/N2;2)"
            Dim RangeDETAILS_P As CellRange = worksheet.Range("P2:P" & DETAILS_LastRow)
            RangeDETAILS_P.Formula = "=J2-O2"

        End If

        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)

    End Sub

    Private Sub BgwExcelLoad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized

        c.Text = "EAEG (EinSiG) - Bilanz Differenzen zum " & Me.Stichtag_BarEditItem.EditValue.ToString
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.OpenXml)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ViewDetails_SwitchItem_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles ViewDetails_SwitchItem.CheckedChanged
        If Me.ViewDetails_SwitchItem.Checked = False Then
            Me.LayoutControl2.Visible = True
            Me.ViewDetails_SwitchItem.Caption = "Show Details"
            Me.Reload_bbi.PerformClick()
        ElseIf Me.ViewDetails_SwitchItem.Checked = True Then
            If IsDate(rd) = True Then
                Me.EAEG_C_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_C_Satz_Version4, rd)
                Me.EAEG_B_D_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_B_D_Satz_Version4, rd)
                Me.EAEG_A_E_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_A_E_Satz_Version4, rd)
                Me.LayoutControl2.Visible = False
                Me.Stichtag_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
                Me.ViewDetails_SwitchItem.Caption = "Show List"
            End If
        End If

    End Sub

    Private Sub LayoutControl2_VisibleChanged(sender As Object, e As EventArgs) Handles LayoutControl2.VisibleChanged
        If Me.LayoutControl2.Visible = True Then
            Me.RibbonPageGroup3.Visible = False
            Me.RibbonPageGroup1.Visible = True
        ElseIf Me.LayoutControl2.Visible = False Then
            Me.RibbonPageGroup3.Visible = True
            Me.RibbonPageGroup1.Visible = False
        End If
    End Sub






    '#Region "EAEG DATEN erstellung ERWEITERT"
    '    Private Sub BgwEAEG_Daten_Erstellung_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwEAEG_Daten_Erstellung.DoWork
    '        Try
    '            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '            SplashScreenManager.Default.SetWaitFormCaption("Starte EAEG Daten ertellung zum Stichtag: " & rd)
    '            OpenSqlConnections()
    '            cmd.CommandText = "SELECT Count([ID]) FROM [EAEG_KUNDEN_STAMM] WHERE  (EAEG_Valid = 'Y') AND [B12_Geburtsdatum] is NULL AND (B2_Ordnungskennzeichen IN (SELECT  B2_OrdnungskennzeichenId FROM EAEG_KUNDEN_KONTEN))"
    '            If cmd.ExecuteScalar = 0 Then
    '                'Check if ECB Exchange Rates are present
    '                cmd.CommandText = "Select Count(ID) from [EXCHANGE RATES ECB] where [EXCHANGE RATE DATE]='" & rdsql & "'"
    '                If cmd.ExecuteScalar <> 0 Then
    '                    'Check Adress Validity
    '                    cmd.CommandText = "SELECT * FROM [EAEG_KUNDEN_STAMM] where [Adresse_Valid]='N' and EAEG_Valid='Y' and [B2_Ordnungskennzeichen] IN (SELECT  [B2_OrdnungskennzeichenId] FROM [EAEG_KUNDEN_KONTEN])"
    '                    If cmd.ExecuteScalar = 0 Then
    '                        SplashScreenManager.Default.SetWaitFormCaption("Alle EAEG Daten mit Stichtag: " & rd & " löschen")
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Alle EAEG Daten mit Stichtag: " & rd & " löschen")
    '                        cmd.CommandText = "Delete from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "Delete from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "Delete from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'A-SATZ
    '                        SplashScreenManager.Default.SetWaitFormCaption("Einfügen neue Daten in Tabelle" & vbNewLine & "EAEG_A_E_Satz_Version4 für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen neue Daten in Tabelle EAEG_A_E_Satz_Version4 für Stichtag " & rd)
    '                        cmd.CommandText = "INSERT INTO [EAEG_A_E_Satz_Version4] ([EAEG_Stichtag],[EAEG_Version]) Values ('" & rdsql & "','ERWEITERT')"
    '                        cmd.ExecuteNonQuery()
    '                        'B-SATZ
    '                        SplashScreenManager.Default.SetWaitFormCaption("Einfügen neue Daten in Tabelle" & vbNewLine & "EAEG_B_D_Satz_Version4 für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen neue Daten in Tabelle EAEG_B_D_Satz_Version4 für Stichtag " & rd)
    '                        cmd.CommandText = "INSERT INTO EAEG_B_D_Satz_Version4 ([B2_Ordnungskennzeichen],[D2_Ordnungskennzeichen],[A_E_Satz_ID],[EAEG_Stichtag]) Select distinct [B2_Ordnungskennzeichen],[B2_Ordnungskennzeichen],(Select [ID] from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'),'" & rdsql & "' from   [EAEG_KUNDEN_STAMM] where   [B2_Ordnungskennzeichen] in (Select   [B2_OrdnungskennzeichenId] from   [EAEG_KUNDEN_KONTEN] where[C7_Kontoart] in ('KK','FG','Darlehen') and [ClosingDate]>' " & rdsql & "')"
    '                        cmd.ExecuteNonQuery()
    '                        SplashScreenManager.Default.SetWaitFormCaption("Aktualissieren der Daten in Tabelle" & vbNewLine & "EAEG_B_D_Satz_Version4 für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Aktualissieren der Daten in Tabelle EAEG_B_D_Satz_Version4 für Stichtag " & rd)
    '                        cmd.CommandText = " UPDATE A SET A.[B3_Nachname]=B.[B3_Nachname],A.[B4_Vorname]=B.[B4_Vorname],A.[B5_Namenszusatz]=B.[B5_Namenszusatz],A.[B6_Anrede]=B.[B6_Anrede],A.[B7_SrasseUndHausnummer]=B.[B7_SrasseUndHausnummer],A.[B8_ZusatzStrasse]=B.[B8_ZusatzStrasse],A.[B9_Postleitzahl]=B.[B9_Postleitzahl],A.[B10_Ort]=B.[B10_Ort],A.[B11_Land]=B.[B11_Land],A.[B12_Geburtsdatum]=B.[B12_Geburtsdatum],A.[B13_Branche]=B.[B13_Branche],A.[B14_Ausschlusskennzeichen_GESAMT]=B.[B14_Ausschlusskennzeichen_GESAMT],A.[B14_Ausschlusskennzeichen_Pos1]=B.[B14_Ausschlusskennzeichen_Pos1],A.[B14_Ausschlusskennzeichen_Pos2]=B.[B14_Ausschlusskennzeichen_Pos2],A.[B14_Ausschlusskennzeichen_Pos3]=B.[B14_Ausschlusskennzeichen_Pos3],A.[B14_Ausschlusskennzeichen_Pos4]=B.[B14_Ausschlusskennzeichen_Pos4],A.[B14_Ausschlusskennzeichen_Pos5]=B.[B14_Ausschlusskennzeichen_Pos5],A.[B14_Ausschlusskennzeichen_Pos6]=B.[B14_Ausschlusskennzeichen_Pos6],A.[B14_Ausschlusskennzeichen_Pos7]=B.[B14_Ausschlusskennzeichen_Pos7],A.[B14_Ausschlusskennzeichen_Pos8]=B.[B14_Ausschlusskennzeichen_Pos8],A.[B14_Ausschlusskennzeichen_Pos9]=B.[B14_Ausschlusskennzeichen_Pos9],A.[B14_Ausschlusskennzeichen_Pos10]=B.[B14_Ausschlusskennzeichen_Pos10],A.[B14_Ausschlusskennzeichen_Pos11]=B.[B14_Ausschlusskennzeichen_Pos11],A.[B14_Ausschlusskennzeichen_Pos12]=B.[B14_Ausschlusskennzeichen_Pos12],A.[B14_Ausschlusskennzeichen_Pos13]=B.[B14_Ausschlusskennzeichen_Pos13],A.[B14_Ausschlusskennzeichen_Pos14]=B.[B14_Ausschlusskennzeichen_Pos14],A.[B14_Ausschlusskennzeichen_Pos15]=B.[B14_Ausschlusskennzeichen_Pos15],A.[B14_Ausschlusskennzeichen_Pos16]=B.[B14_Ausschlusskennzeichen_Pos16],A.[B14_Ausschlusskennzeichen_Pos17]=B.[B14_Ausschlusskennzeichen_Pos17],A.[B14_Ausschlusskennzeichen_Pos18]=B.[B14_Ausschlusskennzeichen_Pos18],A.[B14_Ausschlusskennzeichen_Pos19]=B.[B14_Ausschlusskennzeichen_Pos19],A.[B14_Ausschlusskennzeichen_Pos20]=B.[B14_Ausschlusskennzeichen_Pos20],A.[B14_Ausschlusskennzeichen_Pos21]=B.[B14_Ausschlusskennzeichen_Pos21],A.[B14_Ausschlusskennzeichen_Pos22]=B.[B14_Ausschlusskennzeichen_Pos22],A.[B14_Ausschlusskennzeichen_Pos23]=B.[B14_Ausschlusskennzeichen_Pos23],A.[B14_Ausschlusskennzeichen_Pos24]=B.[B14_Ausschlusskennzeichen_Pos24],A.[B14_Ausschlusskennzeichen_Pos25]=B.[B14_Ausschlusskennzeichen_Pos25],A.[B14_Ausschlusskennzeichen_Pos26]=B.[B14_Ausschlusskennzeichen_Pos26],A.[B14_Ausschlusskennzeichen_Pos27]=B.[B14_Ausschlusskennzeichen_Pos27],A.[B14_Ausschlusskennzeichen_Pos28]=B.[B14_Ausschlusskennzeichen_Pos28],A.[B14_Ausschlusskennzeichen_Pos29]=B.[B14_Ausschlusskennzeichen_Pos29],A.[B14_Ausschlusskennzeichen_Pos30]=B.[B14_Ausschlusskennzeichen_Pos30],A.[B14_Ausschlusskennzeichen_Pos31]=B.[B14_Ausschlusskennzeichen_Pos31],A.[B14_Ausschlusskennzeichen_Pos32]=B.[B14_Ausschlusskennzeichen_Pos32],A.[B14_Ausschlusskennzeichen_Pos33]=B.[B14_Ausschlusskennzeichen_Pos33],A.[B14_Ausschlusskennzeichen_Pos34]=B.[B14_Ausschlusskennzeichen_Pos34],A.[B14_Ausschlusskennzeichen_Pos35]=B.[B14_Ausschlusskennzeichen_Pos35],A.[B14_Ausschlusskennzeichen_Pos36]=B.[B14_Ausschlusskennzeichen_Pos36],A.[B14_Ausschlusskennzeichen_Pos37]=B.[B14_Ausschlusskennzeichen_Pos37],A.[B14_Ausschlusskennzeichen_Pos38]=B.[B14_Ausschlusskennzeichen_Pos38],A.[B14_Ausschlusskennzeichen_Pos39]=B.[B14_Ausschlusskennzeichen_Pos39],A.[B14_Ausschlusskennzeichen_Pos40]=B.[B14_Ausschlusskennzeichen_Pos40],A.[B14_Ausschlusskennzeichen_Pos41]=B.[B14_Ausschlusskennzeichen_Pos41],A.[B14_Ausschlusskennzeichen_Pos42]=B.[B14_Ausschlusskennzeichen_Pos42],A.[B14_Ausschlusskennzeichen_Pos43]=B.[B14_Ausschlusskennzeichen_Pos43],A.[B14_Ausschlusskennzeichen_Pos44]=B.[B14_Ausschlusskennzeichen_Pos44],A.[B14_Ausschlusskennzeichen_Pos45]=B.[B14_Ausschlusskennzeichen_Pos45],A.[B14_Ausschlusskennzeichen_Pos46]=B.[B14_Ausschlusskennzeichen_Pos46],A.[B14_Ausschlusskennzeichen_Pos47]=B.[B14_Ausschlusskennzeichen_Pos47],A.[B14_Ausschlusskennzeichen_Pos48]=B.[B14_Ausschlusskennzeichen_Pos48],A.[B14_Ausschlusskennzeichen_Pos49]=B.[B14_Ausschlusskennzeichen_Pos49],A.[B14_Ausschlusskennzeichen_Pos50]=B.[B14_Ausschlusskennzeichen_Pos50],A.[B15_Kundenkontakt]=B.[B15_Kundenkontakt] from [EAEG_B_D_Satz_Version4] A INNER JOIN [EAEG_KUNDEN_STAMM] B ON A.[B2_Ordnungskennzeichen]=B.[B2_Ordnungskennzeichen] where A.[EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        '****************************************************
    '                        '++++SPEZIAL FALL FÜR EAEG DATEI VERSION 4.0+++++++++
    '                        '****************************************************
    '                        'cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [B14_Ausschlusskennzeichen_Pos9]='N'"
    '                        'cmd.ExecuteNonQuery()
    '                        '****************************************************
    '                        '****************************************************
    '                        'C-SATZ
    '                        SplashScreenManager.Default.SetWaitFormCaption("Einfügen neue Daten in Tabelle" & vbNewLine & "EAEG_C_Satz_Version4 für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen neue Daten in Tabelle EAEG_C_Satz_Version4 für Stichtag " & rd)
    '                        QueryText = "SELECT * FROM [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                        dt = New DataTable()
    '                        da.Fill(dt)
    '                        For i = 0 To dt.Rows.Count - 1
    '                            Dim STAMM As String = dt.Rows.Item(i).Item("B2_Ordnungskennzeichen")
    '                            cmd.CommandText = "INSERT INTO EAEG_C_Satz_Version4 ([B2_OrdnungskennzeichenId],[C2_Kontonummer],[C3_Kontozusatzbezeichnung],[C4_AbweichendWirtschftlichBerechtigter],[C5_AnzahlKontoinhaber],[C6_Kontoerröfnung],[ProductType],[C7_Kontoart],[C8_Währung],[C12_Zinssatz],[C13_LetzteZinsfaelligkeit],[C14_Endfaelligkeit],[C15_Faelligkeitsmerkmal],[C16_Zinsmethode],[C20_Ausschlusskennzeichen_GESAMT],[C20_Ausschlusskennzeichen_Pos1],[C20_Ausschlusskennzeichen_Pos2],[C20_Ausschlusskennzeichen_Pos3],[C20_Ausschlusskennzeichen_Pos4],[C20_Ausschlusskennzeichen_Pos5],[C20_Ausschlusskennzeichen_Pos6],[C20_Ausschlusskennzeichen_Pos7],[C20_Ausschlusskennzeichen_Pos8],[C20_Ausschlusskennzeichen_Pos9],[C20_Ausschlusskennzeichen_Pos10],[C20_Ausschlusskennzeichen_Pos11],[C20_Ausschlusskennzeichen_Pos12],[C20_Ausschlusskennzeichen_Pos13],[C20_Ausschlusskennzeichen_Pos14],[C20_Ausschlusskennzeichen_Pos15],[C20_Ausschlusskennzeichen_Pos16],[C20_Ausschlusskennzeichen_Pos17],[C20_Ausschlusskennzeichen_Pos18],[C20_Ausschlusskennzeichen_Pos19],[C20_Ausschlusskennzeichen_Pos20],[C20_Ausschlusskennzeichen_Pos21],[C20_Ausschlusskennzeichen_Pos22],[C20_Ausschlusskennzeichen_Pos23],[C20_Ausschlusskennzeichen_Pos24],[C20_Ausschlusskennzeichen_Pos25],[C20_Ausschlusskennzeichen_Pos26],[C20_Ausschlusskennzeichen_Pos27],[C20_Ausschlusskennzeichen_Pos28],[C20_Ausschlusskennzeichen_Pos29],[C20_Ausschlusskennzeichen_Pos30],[C20_Ausschlusskennzeichen_Pos31],[C20_Ausschlusskennzeichen_Pos32],[C20_Ausschlusskennzeichen_Pos33],[C20_Ausschlusskennzeichen_Pos34],[C20_Ausschlusskennzeichen_Pos35],[C20_Ausschlusskennzeichen_Pos36],[C20_Ausschlusskennzeichen_Pos37],[C20_Ausschlusskennzeichen_Pos38],[C20_Ausschlusskennzeichen_Pos39],[C20_Ausschlusskennzeichen_Pos40],[C20_Ausschlusskennzeichen_Pos41],[C20_Ausschlusskennzeichen_Pos42],[C20_Ausschlusskennzeichen_Pos43],[C20_Ausschlusskennzeichen_Pos44],[C20_Ausschlusskennzeichen_Pos45],[C20_Ausschlusskennzeichen_Pos46],[C20_Ausschlusskennzeichen_Pos47],[C20_Ausschlusskennzeichen_Pos48],[C20_Ausschlusskennzeichen_Pos49],[C20_Ausschlusskennzeichen_Pos50],[C21_WeitereZustandsverschluesselungen_GESAMT],[C21_WeitereZustandsverschluesselungen_Pos1],[C21_WeitereZustandsverschluesselungen_Pos2],[C21_WeitereZustandsverschluesselungen_Pos3],[C21_WeitereZustandsverschluesselungen_Pos4],[C21_WeitereZustandsverschluesselungen_Pos5],[C21_WeitereZustandsverschluesselungen_Pos6],[C21_WeitereZustandsverschluesselungen_Pos7],[C21_WeitereZustandsverschluesselungen_Pos8],[C21_WeitereZustandsverschluesselungen_Pos9],[C21_WeitereZustandsverschluesselungen_Pos10],[C21_WeitereZustandsverschluesselungen_Pos11],[C21_WeitereZustandsverschluesselungen_Pos12],[C21_WeitereZustandsverschluesselungen_Pos13],[C21_WeitereZustandsverschluesselungen_Pos14],[C21_WeitereZustandsverschluesselungen_Pos15],[C21_WeitereZustandsverschluesselungen_Pos16],[C21_WeitereZustandsverschluesselungen_Pos17],[C21_WeitereZustandsverschluesselungen_Pos18],[C21_WeitereZustandsverschluesselungen_Pos19],[C21_WeitereZustandsverschluesselungen_Pos20],[C21_WeitereZustandsverschluesselungen_Pos21],[C21_WeitereZustandsverschluesselungen_Pos22],[C21_WeitereZustandsverschluesselungen_Pos23],[C21_WeitereZustandsverschluesselungen_Pos24],[C21_WeitereZustandsverschluesselungen_Pos25],[C21_WeitereZustandsverschluesselungen_Pos26],[C21_WeitereZustandsverschluesselungen_Pos27],[C21_WeitereZustandsverschluesselungen_Pos28],[C21_WeitereZustandsverschluesselungen_Pos29],[C21_WeitereZustandsverschluesselungen_Pos30],[C21_WeitereZustandsverschluesselungen_Pos31],[C21_WeitereZustandsverschluesselungen_Pos32],[C21_WeitereZustandsverschluesselungen_Pos33],[C21_WeitereZustandsverschluesselungen_Pos34],[C21_WeitereZustandsverschluesselungen_Pos35],[C21_WeitereZustandsverschluesselungen_Pos36],[C21_WeitereZustandsverschluesselungen_Pos37],[C21_WeitereZustandsverschluesselungen_Pos38],[C21_WeitereZustandsverschluesselungen_Pos39],[C21_WeitereZustandsverschluesselungen_Pos40],[C21_WeitereZustandsverschluesselungen_Pos41],[C21_WeitereZustandsverschluesselungen_Pos42],[C21_WeitereZustandsverschluesselungen_Pos43],[C21_WeitereZustandsverschluesselungen_Pos44],[C21_WeitereZustandsverschluesselungen_Pos45],[C21_WeitereZustandsverschluesselungen_Pos46],[C21_WeitereZustandsverschluesselungen_Pos47],[C21_WeitereZustandsverschluesselungen_Pos48],[C21_WeitereZustandsverschluesselungen_Pos49],[C21_WeitereZustandsverschluesselungen_Pos50],[C22_KennzeichenEWR_Niederlassung],[C23_KennzeichenNichtEWR_Niederlassung],[B_D_Satz_ID],[EAEG_Stichtag]) Select [B2_OrdnungskennzeichenId],[C2_Kontonummer],[C3_Kontozusatzbezeichnung],[C4_AbweichendWirtschftlichBerechtigter],[C5_AnzahlKontoinhaber],[C6_Kontoerröfnung],[ProductType],[C7_Kontoart],[C8_Währung],[C12_Zinssatz],[C13_LetzteZinsfaelligkeit],[C14_Endfaelligkeit],[C15_Faelligkeitsmerkmal],[C16_Zinsmethode],[C20_Ausschlusskennzeichen_GESAMT],[C20_Ausschlusskennzeichen_Pos1],[C20_Ausschlusskennzeichen_Pos2],[C20_Ausschlusskennzeichen_Pos3],[C20_Ausschlusskennzeichen_Pos4],[C20_Ausschlusskennzeichen_Pos5],[C20_Ausschlusskennzeichen_Pos6],[C20_Ausschlusskennzeichen_Pos7],[C20_Ausschlusskennzeichen_Pos8],[C20_Ausschlusskennzeichen_Pos9],[C20_Ausschlusskennzeichen_Pos10],[C20_Ausschlusskennzeichen_Pos11],[C20_Ausschlusskennzeichen_Pos12],[C20_Ausschlusskennzeichen_Pos13],[C20_Ausschlusskennzeichen_Pos14],[C20_Ausschlusskennzeichen_Pos15],[C20_Ausschlusskennzeichen_Pos16],[C20_Ausschlusskennzeichen_Pos17],[C20_Ausschlusskennzeichen_Pos18],[C20_Ausschlusskennzeichen_Pos19],[C20_Ausschlusskennzeichen_Pos20],[C20_Ausschlusskennzeichen_Pos21],[C20_Ausschlusskennzeichen_Pos22],[C20_Ausschlusskennzeichen_Pos23],[C20_Ausschlusskennzeichen_Pos24],[C20_Ausschlusskennzeichen_Pos25],[C20_Ausschlusskennzeichen_Pos26],[C20_Ausschlusskennzeichen_Pos27],[C20_Ausschlusskennzeichen_Pos28],[C20_Ausschlusskennzeichen_Pos29],[C20_Ausschlusskennzeichen_Pos30],[C20_Ausschlusskennzeichen_Pos31],[C20_Ausschlusskennzeichen_Pos32],[C20_Ausschlusskennzeichen_Pos33],[C20_Ausschlusskennzeichen_Pos34],[C20_Ausschlusskennzeichen_Pos35],[C20_Ausschlusskennzeichen_Pos36],[C20_Ausschlusskennzeichen_Pos37],[C20_Ausschlusskennzeichen_Pos38],[C20_Ausschlusskennzeichen_Pos39],[C20_Ausschlusskennzeichen_Pos40],[C20_Ausschlusskennzeichen_Pos41],[C20_Ausschlusskennzeichen_Pos42],[C20_Ausschlusskennzeichen_Pos43],[C20_Ausschlusskennzeichen_Pos44],[C20_Ausschlusskennzeichen_Pos45],[C20_Ausschlusskennzeichen_Pos46],[C20_Ausschlusskennzeichen_Pos47],[C20_Ausschlusskennzeichen_Pos48],[C20_Ausschlusskennzeichen_Pos49],[C20_Ausschlusskennzeichen_Pos50],[C21_WeitereZustandsverschluesselungen_GESAMT],[C21_WeitereZustandsverschluesselungen_Pos1],[C21_WeitereZustandsverschluesselungen_Pos2],[C21_WeitereZustandsverschluesselungen_Pos3],[C21_WeitereZustandsverschluesselungen_Pos4],[C21_WeitereZustandsverschluesselungen_Pos5],[C21_WeitereZustandsverschluesselungen_Pos6],[C21_WeitereZustandsverschluesselungen_Pos7],[C21_WeitereZustandsverschluesselungen_Pos8],[C21_WeitereZustandsverschluesselungen_Pos9],[C21_WeitereZustandsverschluesselungen_Pos10],[C21_WeitereZustandsverschluesselungen_Pos11],[C21_WeitereZustandsverschluesselungen_Pos12],[C21_WeitereZustandsverschluesselungen_Pos13],[C21_WeitereZustandsverschluesselungen_Pos14],[C21_WeitereZustandsverschluesselungen_Pos15],[C21_WeitereZustandsverschluesselungen_Pos16],[C21_WeitereZustandsverschluesselungen_Pos17],[C21_WeitereZustandsverschluesselungen_Pos18],[C21_WeitereZustandsverschluesselungen_Pos19],[C21_WeitereZustandsverschluesselungen_Pos20],[C21_WeitereZustandsverschluesselungen_Pos21],[C21_WeitereZustandsverschluesselungen_Pos22],[C21_WeitereZustandsverschluesselungen_Pos23],[C21_WeitereZustandsverschluesselungen_Pos24],[C21_WeitereZustandsverschluesselungen_Pos25],[C21_WeitereZustandsverschluesselungen_Pos26],[C21_WeitereZustandsverschluesselungen_Pos27],[C21_WeitereZustandsverschluesselungen_Pos28],[C21_WeitereZustandsverschluesselungen_Pos29],[C21_WeitereZustandsverschluesselungen_Pos30],[C21_WeitereZustandsverschluesselungen_Pos31],[C21_WeitereZustandsverschluesselungen_Pos32],[C21_WeitereZustandsverschluesselungen_Pos33],[C21_WeitereZustandsverschluesselungen_Pos34],[C21_WeitereZustandsverschluesselungen_Pos35],[C21_WeitereZustandsverschluesselungen_Pos36],[C21_WeitereZustandsverschluesselungen_Pos37],[C21_WeitereZustandsverschluesselungen_Pos38],[C21_WeitereZustandsverschluesselungen_Pos39],[C21_WeitereZustandsverschluesselungen_Pos40],[C21_WeitereZustandsverschluesselungen_Pos41],[C21_WeitereZustandsverschluesselungen_Pos42],[C21_WeitereZustandsverschluesselungen_Pos43],[C21_WeitereZustandsverschluesselungen_Pos44],[C21_WeitereZustandsverschluesselungen_Pos45],[C21_WeitereZustandsverschluesselungen_Pos46],[C21_WeitereZustandsverschluesselungen_Pos47],[C21_WeitereZustandsverschluesselungen_Pos48],[C21_WeitereZustandsverschluesselungen_Pos49],[C21_WeitereZustandsverschluesselungen_Pos50],[C22_KennzeichenEWRNiederlassung],[C23_KennzeichenNichtEWRNiederlassung],(Select [ID] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "' ),'" & rdsql & "' from  [EAEG_KUNDEN_KONTEN] where   [B2_OrdnungskennzeichenId]='" & STAMM & "' and [C7_Kontoart] in ('KK','FG','Darlehen') and [ClosingDate]>' " & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                        Next
    '                        SplashScreenManager.Default.SetWaitFormCaption("Update Kontoname in EAEG_C_Satz_Version4 from CUSTOMER_INFO")
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(60, "Update Kontoname in EAEG_C_Satz_Version4 from CUSTOMER_INFO")
    '                        cmd.CommandText = "UPDATE A set A.[Kontoname]=B.[English Name] from [EAEG_C_Satz_Version4] A INNER JOIN [CUSTOMER_INFO] B On A.[B2_OrdnungskennzeichenId]=B.[ClientNo] where A.[Kontoname] is NULL and A.[EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        SplashScreenManager.Default.SetWaitFormCaption("Letzte Zinsfaelligkeit ermitteln in Tabelle" & vbNewLine & "EAEG_C_Satz_Version4 wenn Kontoart=KK für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Letzte Zinsfaelligkeit ermitteln in Tabelle EAEG_C_Satz_Version4 wenn Kontoart=KK für Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C13_LetzteZinsfaelligkeit]=DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0,'" & rdsql & "'),0)) where  [C7_Kontoart]='KK' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        SplashScreenManager.Default.SetWaitFormCaption("Letzte Zinsfaelligkeit=Erröfnungs Datum wenn" & vbNewLine & "Letzte Zinsfaelligkeit<Erröfnungsdatum für Kontoart=KK zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Letzte Zinsfaelligkeit=Erröfnungs Datum wenn" & vbNewLine & "Letzte Zinsfaelligkeit<Erröfnungsdatum für Kontoart=KK zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C13_LetzteZinsfaelligkeit]=[C6_Kontoerröfnung] where [C13_LetzteZinsfaelligkeit]<[C6_Kontoerröfnung] and  [C7_Kontoart]='KK' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        SplashScreenManager.Default.SetWaitFormCaption("Löschen der Daten in Tabelle EAEG_C_Satz_Version4" & vbNewLine & "wenn Kontoart=KK und Letzte Zinsfaelligkeit=NULL für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Löschen der Daten in Tabelle EAEG_C_Satz_Version4 wenn Kontoart=KK und Letzte Zinsfaelligkeit=NULL für Stichtag " & rd)
    '                        cmd.CommandText = "DELETE FROM [EAEG_C_Satz_Version4] where [C7_Kontoart]='KK' and [C13_LetzteZinsfaelligkeit] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        '****************************************************
    '                        '++++SET OCBS Account Nr in [OriginalAccountNrTest]+++++++++
    '                        '****************************************************
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [OriginalAccountNrTest]=NULL where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "Update A  set A.[OriginalAccountNrTest]=B.[Client Account] from  [EAEG_C_Satz_Version4] A INNER JOIN [CUSTOMER_ACCOUNTS] B on A.[C2_Kontonummer]=convert(float,B.[ClientAccountDomestic]) where A.[EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "Update [EAEG_C_Satz_Version4] set [OriginalAccountNrTest]=[C2_Kontonummer] where [OriginalAccountNrTest] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        '****************************************************
    '                        '****************************************************

    '                        'EINFÜGEN ECB WÄHRUNGSKURSE
    '                        SplashScreenManager.Default.SetWaitFormCaption("Einfügen der ECB Umrechnungskurse zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen der ECB Umrechnungskurse zum Stichtag " & rd)
    '                        'WÄHRUNG=EUR
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C10_Umrechnungskurs]=1 where [C8_Währung]='EUR' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'WÄHRUNG<>EUR
    '                        cmd.CommandText = "UPDATE A SET A.[C10_Umrechnungskurs]=B.[CURRENCY RATE] FROM [EAEG_C_Satz_Version4] A INNER JOIN [EXCHANGE RATES ECB] B ON A.[C8_Währung]=B.[CURRENCY CODE] and A.[EAEG_Stichtag]=B.[EXCHANGE RATE DATE] where  A.[EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()

    '                        'ZINSMETHODE EINFÜGEN NUR FÜR KK und FG
    '                        SplashScreenManager.Default.SetWaitFormCaption("Aktualisieren der Zinsmethode" & vbNewLine & "für KK und FG zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Aktualisieren der Zinsmethode für KK und FG zum Stichtag " & rd)
    '                        cmd.CommandText = "SELECT [C7_Kontoart] from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "' Begin UPDATE [EAEG_C_Satz_Version4] SET [C16_Zinsmethode]='01' where [C7_Kontoart] in ('KK','FG') and [C8_Währung] not in ('GBP') and [C16_Zinsmethode] is NULL and [EAEG_Stichtag]='" & rdsql & "' end Begin UPDATE [EAEG_C_Satz_Version4] SET [C16_Zinsmethode]='02' where [C7_Kontoart] in ('KK','FG') and [C8_Währung] in ('GBP') and [C16_Zinsmethode] is NULL and [EAEG_Stichtag]='" & rdsql & "' end"
    '                        cmd.ExecuteNonQuery()


    '                        'Einfügen der KK Salden + Zinsen (BUCHUNG oder VALUTARISCH)
    '                        SplashScreenManager.Default.SetWaitFormCaption("Abfrage Parameter EAEG_SALDEN/KK_SALDO bezüglich" & vbNewLine & "des Buchhaltärischen oder Valutarischen Saldo von KK Konten")
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Abfrage Parameter EAEG_SALDEN/KK_SALDO bezüglich des Buchhaltärischen oder Valutarischen Saldo von KK Konten")
    '                        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='KK_SALDO' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EAEG_SALDEN'"
    '                        Dim EAEG_SALDO_KZ As String = cmd.ExecuteScalar
    '                        If rd <= DateSerial(2017, 12, 8) Then 'OCBS
    '                            If EAEG_SALDO_KZ = "B" Then
    '                                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                                'KONTOKORRENT SALDO + ZINSSALDEN (ABGRENZUNG)
    '                                SplashScreenManager.Default.SetWaitFormCaption("Einfügen (Buchungssaldo) der KK und Zinssalden zum Stichtag " & rd)
    '                                Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen (Buchungssaldo) der KK und Zinssalden zum Stichtag " & rd)
    '                                QueryText = "SELECT * FROM [EAEG_C_Satz_Version4] where [C7_Kontoart]='KK' and [EAEG_Stichtag]='" & rdsql & "' "
    '                                da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                                dt = New DataTable()
    '                                da.Fill(dt)
    '                                For i = 0 To dt.Rows.Count - 1
    '                                    Dim KK As Decimal = dt.Rows.Item(i).Item("C2_Kontonummer")
    '                                    Dim KKformated As String = KK.ToString("0000000000")
    '                                    cmd.CommandText = "Select [Client Account] from [CUSTOMER_ACCOUNTS] where [ClientAccountDomestic]='" & KKformated & "'"
    '                                    Dim KKnumber As String = cmd.ExecuteScalar
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=(Select [Amount] from [CUSTOMER_VOLUMES] where [AccountNo]='" & KKnumber & "' and [BatchNo]='CLOSING BALANCE' and [GL_Rep_Date]='" & rdsql & "') where [C2_Kontonummer]='" & KK & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=0 where [C2_Kontonummer]='" & KK & "' and [C9_KapitalsaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=Round([C9_KapitalsaldoInKontowährung],2),[C12_Zinssatz]=99999.99999 where [C2_Kontonummer]='" & KK & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    'ZINSSALDO GIROKONTEN
    '                                    Dim LetzteZinsfaelligkeit As Date = dt.Rows.Item(i).Item("C13_LetzteZinsfaelligkeit")
    '                                    Dim LetzteZinsfaelligkeitSql As String = LetzteZinsfaelligkeit.ToString("yyyyMMdd")
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=(Select Sum([AmountInEuro]) from [ACCRUED INTEREST DEMAND DEPOSITS] where [AccountNo]='" & KKnumber & "' and [Description] like '%DAILY ACCRUAL%' and [GL_Rep_Date]>'" & LetzteZinsfaelligkeitSql & "'and [GL_Rep_Date]<='" & rdsql & "') where [C2_Kontonummer]='" & KK & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=0 where [C2_Kontonummer]='" & KK & "' and [C17_ZinssaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                Next
    '                            ElseIf EAEG_SALDO_KZ = "V" Then
    '                                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                                'KONTOKORRENT SALDO + ZINSSALDEN (ABGRENZUNG)
    '                                SplashScreenManager.Default.SetWaitFormCaption("Einfügen (Valutarischer Saldo) " & vbNewLine & "der KK und Zinssalden zum Stichtag " & rd)
    '                                Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen (Valutarischer Saldo) der KK und Zinssalden zum Stichtag " & rd)
    '                                cmd.CommandText = "UPDATE A SET A.[C9_KapitalsaldoInKontowährung]=B.[OrgPrincipalAmount],A.[C17_ZinssaldoInKontowährung]=B.[OrgInterestAmount] from [EAEG_C_Satz_Version4] A INNER JOIN [CUSTOMER_ACCOUNTS] C on A.[C2_Kontonummer]=Substring(C.[ClientAccountDomestic], patindex('%[^0]%',C.[ClientAccountDomestic]), 10) INNER JOIN [BusinessTypesLiabilitiesDetails] B ON C.[Client Account]=B.[Contract Collateral ID] where B.[RiskDate]='" & rdsql & "' and A.[C7_Kontoart]='KK' and A.[EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=0 where [C7_Kontoart]='KK' and [C9_KapitalsaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=Round([C9_KapitalsaldoInKontowährung],2),[C12_Zinssatz]=99999.99999 where [C7_Kontoart]='KK' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=0 where [C7_Kontoart]='KK' and [C17_ZinssaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If
    '                        ElseIf rd > DateSerial(2017, 12, 8) Then 'NEWG
    '                            If EAEG_SALDO_KZ = "B" Then
    '                                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                                'BOOKED BALANCE
    '                                SplashScreenManager.Default.SetWaitFormCaption("Einfügen (Buchungssaldo) der KK und Zinssalden zum Stichtag " & rd)
    '                                Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen (Buchungssaldo) der KK und Zinssalden zum Stichtag " & rd)
    '                                QueryText = "SELECT * FROM [EAEG_C_Satz_Version4] where [C7_Kontoart]='KK' and [EAEG_Stichtag]='" & rdsql & "' "
    '                                da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                                dt = New DataTable()
    '                                da.Fill(dt)
    '                                For i = 0 To dt.Rows.Count - 1
    '                                    Dim KK As Decimal = dt.Rows.Item(i).Item("C2_Kontonummer")
    '                                    Dim KKformated As String = KK.ToString("0000000000")
    '                                    cmd.CommandText = "Select [Client Account] from [CUSTOMER_ACCOUNTS] where [ClientAccountDomestic]='" & KKformated & "'"
    '                                    Dim KKnumber As String = cmd.ExecuteScalar
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=(Select [AvailableBalance] from [CUSTOMER_ACC_BALANCES] where [AccountNo]='" & KKnumber & "'  and [BalanceDate]='" & rdsql & "') where [C2_Kontonummer]='" & KK & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=0 where [C2_Kontonummer]='" & KK & "' and [C9_KapitalsaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=Round([C9_KapitalsaldoInKontowährung],2),[C12_Zinssatz]=99999.99999 where [C2_Kontonummer]='" & KK & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    'ZINSSALDO GIROKONTEN
    '                                    Dim LetzteZinsfaelligkeit As Date = dt.Rows.Item(i).Item("C13_LetzteZinsfaelligkeit")
    '                                    Dim LetzteZinsfaelligkeitSql As String = LetzteZinsfaelligkeit.ToString("yyyyMMdd")
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=(Select Sum([CR_Interest]+[DR_Interest]) from [CUSTOMER_ACC_BALANCES] where [AccountNo]='" & KKnumber & "' and [BalanceDate]='" & rdsql & "') where [C2_Kontonummer]='" & KK & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=0 where [C2_Kontonummer]='" & KK & "' and [C17_ZinssaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                Next
    '                            ElseIf EAEG_SALDO_KZ = "V" Then
    '                                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                                'VALUE BALANCE
    '                                SplashScreenManager.Default.SetWaitFormCaption("Einfügen (Valutarischer Saldo) " & vbNewLine & "der KK und Zinssalden zum Stichtag " & rd)
    '                                Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen (Valutarischer Saldo) der KK und Zinssalden zum Stichtag " & rd)
    '                                cmd.CommandText = "UPDATE A SET A.[C9_KapitalsaldoInKontowährung]=B.[ValueBalance],A.[C17_ZinssaldoInKontowährung]=B.[CR_Interest]+B.[DR_Interest] from [EAEG_C_Satz_Version4] A INNER JOIN [CUSTOMER_ACCOUNTS] C on A.[C2_Kontonummer]=Substring(C.[ClientAccountDomestic], patindex('%[^0]%',C.[ClientAccountDomestic]), 10) INNER JOIN [CUSTOMER_ACC_BALANCES] B ON C.[Client Account]=B.[AccountNo] where B.[BalanceDate]='" & rdsql & "' and A.[C7_Kontoart]='KK' and A.[EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=0 where [C7_Kontoart]='KK' and [C9_KapitalsaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C9_KapitalsaldoInKontowährung]=Round([C9_KapitalsaldoInKontowährung],2),[C12_Zinssatz]=99999.99999 where [C7_Kontoart]='KK' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=0 where [C7_Kontoart]='KK' and [C17_ZinssaldoInKontowährung] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If
    '                        End If

    '                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                        'FESTGELDER KONTOSALDO,ZINSATZ,LETZTE ZINSFÄLLIGKEIT EINFÜGEN
    '                        SplashScreenManager.Default.SetWaitFormCaption("Einfügen der FG Salden,Zinsatz und " & vbNewLine & "Letzte Zinsfaelligkeit zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen der FG Salden,Zinsatz,Letzte Zinsfaelligkeit zum Stichtag " & rd)
    '                        QueryText = "SELECT * FROM [EAEG_C_Satz_Version4] where [C7_Kontoart]='FG' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                        dt = New DataTable()
    '                        da.Fill(dt)
    '                        For i = 0 To dt.Rows.Count - 1
    '                            Dim FG As Decimal = dt.Rows.Item(i).Item("C2_Kontonummer")
    '                            Dim Contract As String = dt.Rows.Item(i).Item("C2_Kontonummer")
    '                            'Select Max Date from Accrued Interest where Contract=C2_KontoNummer and Datadate<=Stichtag
    '                            'cmd.CommandText = "Select Max([Datadate]) FROM [ACCRUED INTEREST ANALYSIS] where [Contract]='" & Contract & "' and [Datadate]<='" & rdsql & "'"
    '                            'Dim LetzteAnzeigeDatum As Date = cmd.ExecuteScalar
    '                            'Dim rdsql_New As String = LetzteAnzeigeDatum.ToString("yyyyMMdd")
    '                            cmd.CommandText = "UPDATE A SET A.[C9_KapitalsaldoInKontowährung]=B.[Principal (Org  Ccy)]*-1,A.[C12_Zinssatz]=B.[Current Interest Rate] from [EAEG_C_Satz_Version4] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[C2_Kontonummer]=B.[Contract] where B.[Datadate]='" & rdsql & "' and A.[C7_Kontoart]='FG' and A.[EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                            'Ermitteln letzte Zinsfälligkeit
    '                            cmd.CommandText = "UPDATE A SET A.[C13_LetzteZinsfaelligkeit]=B.[Current Interest Coupon Period Start Date] from [EAEG_C_Satz_Version4] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[C2_Kontonummer]=B.[Contract] where B.[Datadate]='" & rdsql & "' and A.[C7_Kontoart]='FG' and B.[Start Date]<>B.[Current Interest Coupon Period Start Date] and A.[EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                        Next
    '                        'ZINSTAGE FÜR FG
    '                        SplashScreenManager.Default.SetWaitFormCaption("Berechnung des Zinstage für FG zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Berechnung des Zinstage für FG zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [Zinstage]=DATEDIFF(day,[C13_LetzteZinsfaelligkeit],'" & rdsql & "') where [C7_Kontoart] in ('FG') and [C13_LetzteZinsfaelligkeit] is not NULL and [C14_Endfaelligkeit]>='" & rdsql & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [Zinstage]=DATEDIFF(day,[C6_Kontoerröfnung],'" & rdsql & "') where [C7_Kontoart] in ('FG') and [C13_LetzteZinsfaelligkeit] is NULL and [C14_Endfaelligkeit]>='" & rdsql & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [Zinstage]=DATEDIFF(day,[C13_LetzteZinsfaelligkeit],[C14_Endfaelligkeit]) where [C7_Kontoart] in ('FG') and [C13_LetzteZinsfaelligkeit] is not NULL and [C14_Endfaelligkeit]<='" & rdsql & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [Zinstage]=DATEDIFF(day,[C6_Kontoerröfnung],[C14_Endfaelligkeit]) where [C7_Kontoart] in ('FG') and [C13_LetzteZinsfaelligkeit] is NULL and [C14_Endfaelligkeit]<='" & rdsql & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'ZINSSALDO FÜR FG
    '                        SplashScreenManager.Default.SetWaitFormCaption("Berechnung des Zinssaldos " & vbNewLine & "für FG (Zinsmethode ACT/360) zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Berechnung des Zinssaldos für FG (Zinsmethode ACT/360) zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=Round(([Zinstage]*[C12_Zinssatz]/100 *[C9_KapitalsaldoInKontowährung])/360,2)  where [C7_Kontoart] in ('FG') and [C16_Zinsmethode] not in ('02') and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        SplashScreenManager.Default.SetWaitFormCaption("Berechnung des Zinssaldos " & vbNewLine & "für FG (Zinsmethode ACT/365) zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Berechnung des Zinssaldos für FG (Zinsmethode ACT/365) zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C17_ZinssaldoInKontowährung]=Round(([Zinstage]*[C12_Zinssatz]/100 *[C9_KapitalsaldoInKontowährung])/365,2)  where [C7_Kontoart] in ('FG') and [C16_Zinsmethode] in ('02') and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                        'DARLEHEN
    '                        SplashScreenManager.Default.SetWaitFormCaption("Einfügen der DARLEHENS Salden zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Einfügen der DARLEHENS Salden zum Stichtag " & rd)
    '                        QueryText = "SELECT * FROM [EAEG_C_Satz_Version4] where [C7_Kontoart]='Darlehen' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                        dt = New DataTable()
    '                        da.Fill(dt)
    '                        For i = 0 To dt.Rows.Count - 1
    '                            Dim DL As Decimal = dt.Rows.Item(i).Item("C2_Kontonummer")
    '                            'Dim Contract As String = dt.Rows.Item(i).Item("C2_Kontonummer")
    '                            'Select Max Date from Accrued Interest where Contract=C2_KontoNummer and Datadate<=Stichtag
    '                            'cmd.CommandText = "Select Max([Datadate]) FROM [ACCRUED INTEREST ANALYSIS] where [Contract]='" & Contract & "' and [Datadate]<='" & rdsql & "'"
    '                            'Dim LetzteAnzeigeDatum As Date = cmd.ExecuteScalar
    '                            'Dim rdsql_New As String = LetzteAnzeigeDatum.ToString("yyyyMMdd")
    '                            cmd.CommandText = "UPDATE A SET A.[C9_KapitalsaldoInKontowährung]=B.[Principal (Org  Ccy)]*-1 from [EAEG_C_Satz_Version4] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[C2_Kontonummer]=B.[Contract] where B.[Datadate]='" & rdsql & "' and A.[C7_Kontoart]='Darlehen' and A.[EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                        Next
    '                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                        'FÄLLIGKEITSMERKMAL
    '                        SplashScreenManager.Default.SetWaitFormCaption("Aktualisieren des Fälligkeitsmerkmals " & vbNewLine & "zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Aktualisieren des Fälligkeitsmerkmals zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C15_Faelligkeitsmerkmal]='Y' where [C14_Endfaelligkeit]='" & rdsql & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    '                        'BERECHNEN DER FELDER KAPITALSALDO,ZINSSALDO,KONTOSALDO IN EURO
    '                        SplashScreenManager.Default.SetWaitFormCaption("Aktualisieren der Felder [C11_KapitalsaldoInEuro]," & vbNewLine & "[C18_ZinssaldoInEuro],[C19_KontosaldoInEuro] zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Aktualissieren der Felder [C11_KapitalsaldoInEuro],[C18_ZinssaldoInEuro],[C19_KontosaldoInEuro] zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C11_KapitalsaldoInEuro]=Round([C9_KapitalsaldoInKontowährung]/[C10_Umrechnungskurs],2),[C18_ZinssaldoInEuro]=Round([C17_ZinssaldoInKontowährung]/[C10_Umrechnungskurs],2) where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C19_KontosaldoInEuro]=[C11_KapitalsaldoInEuro]+[C18_ZinssaldoInEuro] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    '                        'DEFAULT =NULL wenn KONTOART=Darlehen
    '                        SplashScreenManager.Default.SetWaitFormCaption("Setzen der Felder:C12,C13,C14,C16,C17,C18 " & vbNewLine & "als NULL wenn Kontoart=Darlehen zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Setzen der Felder:C12,C13,C14,C16,C17,C18 als NULL wenn Kontoart=Darlehen zum Stichtag " & rd)
    '                        cmd.CommandText = "UPDATE [EAEG_C_Satz_Version4] SET [C12_Zinssatz]=NULL,[C13_LetzteZinsfaelligkeit]=NULL,[C14_Endfaelligkeit]=NULL,[C16_Zinsmethode]=NULL,[C17_ZinssaldoInKontowährung]=NULL,[C18_ZinssaldoInEuro]=NULL where [C7_Kontoart]='Darlehen' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()

    '                        'NICHT RELEVANTE DATEN LÖSCHEN
    '                        SplashScreenManager.Default.SetWaitFormCaption("Löschen aller C-Sätze wenn " & vbNewLine & "Kontoerröfnungsdatum größer ist als zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Löschen aller C-Sätze wenn Kontoerröfnungsdatum größer ist als zum Stichtag " & rd)
    '                        cmd.CommandText = "DELETE from  [EAEG_C_Satz_Version4] where   [C6_Kontoerröfnung]>'" & rdsql & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        SplashScreenManager.Default.SetWaitFormCaption("Löschen aller B-Sätze " & vbNewLine & "die keinen C-Satz haben zum Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Löschen aller B-Sätze die keinen C-Satz haben zum Stichtag " & rd)
    '                        cmd.CommandText = "DELETE from  [EAEG_B_D_Satz_Version4] where   [B2_Ordnungskennzeichen] not in (Select   [B2_OrdnungskennzeichenId] from   [EAEG_C_Satz_Version4]) and [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()

    '                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                        'D-SATZ SUMMEN
    '                        SplashScreenManager.Default.SetWaitFormCaption("Aktualissieren der Summenfelder in Tabelle " & vbNewLine & "EAEG_B_D_Satz_Version4 (D-SÄTZE) für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Aktualissieren der Summenfelder in Tabelle EAEG_B_D_Satz_Version4 (D-SÄTZE) für Stichtag " & rd)
    '                        QueryText = "SELECT [B2_Ordnungskennzeichen],[ID] FROM [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "' GROUP BY [B2_Ordnungskennzeichen],[ID] "
    '                        da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                        dt = New DataTable()
    '                        da.Fill(dt)
    '                        For i = 0 To dt.Rows.Count - 1
    '                            Dim STAMM As String = dt.Rows.Item(i).Item("B2_Ordnungskennzeichen")
    '                            Dim ID As String = dt.Rows.Item(i).Item("ID")
    '                            'D3
    '                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D3_GesamtsaldoEinlagen]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D3_GesamtsaldoEinlagen]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D3_GesamtsaldoEinlagen] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                            'D4
    '                            cmd.CommandText = "Select [ID] from [EAEG_B_D_Satz_Version4] where ([B14_Ausschlusskennzeichen_Pos1]='Y' or [B14_Ausschlusskennzeichen_Pos2]='Y' or [B14_Ausschlusskennzeichen_Pos3]='Y' or [B14_Ausschlusskennzeichen_Pos4]='Y' or [B14_Ausschlusskennzeichen_Pos5]='Y' or [B14_Ausschlusskennzeichen_Pos6]='Y' or [B14_Ausschlusskennzeichen_Pos7]='Y' or [B14_Ausschlusskennzeichen_Pos8]='Y' or [B14_Ausschlusskennzeichen_Pos9]='Y' or [B14_Ausschlusskennzeichen_Pos10]='Y' or [B14_Ausschlusskennzeichen_Pos11]='Y' or [B14_Ausschlusskennzeichen_Pos12]='Y' or [B14_Ausschlusskennzeichen_Pos13]='Y' or [B14_Ausschlusskennzeichen_Pos14]='Y' or [B14_Ausschlusskennzeichen_Pos15]='Y' or [B14_Ausschlusskennzeichen_Pos16]='Y' or [B14_Ausschlusskennzeichen_Pos17]='Y' or [B14_Ausschlusskennzeichen_Pos18]='Y' or [B14_Ausschlusskennzeichen_Pos19]='Y' or [B14_Ausschlusskennzeichen_Pos20]='Y'or [B14_Ausschlusskennzeichen_Pos21]='Y' or [B14_Ausschlusskennzeichen_Pos22]='Y' or [B14_Ausschlusskennzeichen_Pos23]='Y' or [B14_Ausschlusskennzeichen_Pos24]='Y' or [B14_Ausschlusskennzeichen_Pos25]='Y' or [B14_Ausschlusskennzeichen_Pos26]='Y' or [B14_Ausschlusskennzeichen_Pos27]='Y' or [B14_Ausschlusskennzeichen_Pos28]='Y' or [B14_Ausschlusskennzeichen_Pos29]='Y' or [B14_Ausschlusskennzeichen_Pos30]='Y') and [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                            Dim t As String = cmd.ExecuteScalar
    '                            If t <> "" Then
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D4_GesamtsaldoGesetzlicheAusschluesse]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D4_GesamtsaldoGesetzlicheAusschluesse]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D4_GesamtsaldoGesetzlicheAusschluesse] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            Else
    '                                cmd.CommandText = "Select CASE when exists(Select [ID] from [EAEG_B_D_Satz_Version4] where [D3_GesamtsaldoEinlagen]<20 and [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "' and EXISTS(Select [ID] from [EAEG_C_Satz_Version4] where [C20_Ausschlusskennzeichen_Pos1]='Y' and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'))then (Select [D3_GesamtsaldoEinlagen] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "')else (Select Case when EXISTS(Select [ID] from [EAEG_C_Satz_Version4] where [C20_Ausschlusskennzeichen_Pos2]='Y' and [C20_Ausschlusskennzeichen_Pos3]='Y' and [C20_Ausschlusskennzeichen_Pos4]='Y' and [C20_Ausschlusskennzeichen_Pos5]='Y' and [C20_Ausschlusskennzeichen_Pos6]='Y' and [C20_Ausschlusskennzeichen_Pos7]='Y' and [C20_Ausschlusskennzeichen_Pos8]='Y' and [C20_Ausschlusskennzeichen_Pos9]='Y' and [C20_Ausschlusskennzeichen_Pos10]='Y' and [C20_Ausschlusskennzeichen_Pos11]='Y' and [C20_Ausschlusskennzeichen_Pos12]='Y' and [C20_Ausschlusskennzeichen_Pos13]='Y' and [C20_Ausschlusskennzeichen_Pos14]='Y' and [C20_Ausschlusskennzeichen_Pos15]='Y' and [C20_Ausschlusskennzeichen_Pos16]='Y' and [C20_Ausschlusskennzeichen_Pos17]='Y' and [C20_Ausschlusskennzeichen_Pos18]='Y' and [C20_Ausschlusskennzeichen_Pos19]='Y' and [C20_Ausschlusskennzeichen_Pos20]='Y' and [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "')then (Select sum([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "')else'0'end) end"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D4_GesamtsaldoGesetzlicheAusschluesse]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D4_GesamtsaldoGesetzlicheAusschluesse] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If
    '                            'D5
    '                            cmd.CommandText = "Select [ID] from [EAEG_A_E_Satz_Version4] where [A3_ZugehoerigkeitZuEntsaedigungseinrichtungen] in ('01','10') and [EAEG_Stichtag]='" & rdsql & "'"
    '                            t = cmd.ExecuteScalar
    '                            If t <> "" Then
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen]=[D3_GesamtsaldoEinlagen]-[D4_GesamtsaldoGesetzlicheAusschluesse] where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If
    '                            'D6
    '                            If t <> "" Then
    '                                Dim berechnung1 As Double = 0
    '                                Dim berechnung2 As Double = 0
    '                                cmd.CommandText = "Select [D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung1 = cmd.ExecuteScalar
    '                                Else
    '                                    berechnung1 = 0
    '                                End If

    '                                cmd.CommandText = "Select(Select distinct [C5_AnzahlKontoinhaber] from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "')*(Select [A4_GesetzlicheEntschaedigungsobergrenzeEAEG] from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "')"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung2 = cmd.ExecuteScalar
    '                                    If berechnung1 > berechnung2 Then
    '                                        cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE]=" & Str(berechnung2) & " where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                        cmd.ExecuteNonQuery()
    '                                    Else
    '                                        cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE]=" & Str(berechnung1) & " where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                        cmd.ExecuteNonQuery()
    '                                    End If
    '                                End If
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE]=0 where [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE]=0 where [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If


    '                            'D7
    '                            If t <> "" Then
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D7_GesamtsaldoGesetzlichGedeckterEinlagen_UNTERGRENZE]=[D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen]-[D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE] where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If

    '                            'D8
    '                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]>0 and [C22_KennzeichenEWR_Niederlassung] is not NULL and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE]=0 where [D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                            'D9
    '                            cmd.CommandText = "Select [ID] from [EAEG_A_E_Satz_Version4] where [A3_ZugehoerigkeitZuEntsaedigungseinrichtungen] in ('20') and [EAEG_Stichtag]='" & rdsql & "'"
    '                            t = cmd.ExecuteScalar
    '                            If t <> "" Then
    '                                Dim berechnung1 As Double = 0
    '                                Dim berechnung2 As Double = 0
    '                                cmd.CommandText = "Select [D3_GesamtsaldoEinlagen] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung1 = cmd.ExecuteScalar
    '                                Else
    '                                    berechnung1 = 0
    '                                End If

    '                                cmd.CommandText = "Select(Select distinct [C5_AnzahlKontoinhaber] from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "')*(Select [A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland] from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "')"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung2 = cmd.ExecuteScalar
    '                                    If berechnung1 > berechnung2 Then
    '                                        cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE]=" & Str(berechnung2) & " where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                        cmd.ExecuteNonQuery()
    '                                    Else
    '                                        cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE]=" & Str(berechnung1) & " where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                        cmd.ExecuteNonQuery()
    '                                    End If
    '                                End If
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE]=0 where [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If


    '                            'D10
    '                            cmd.CommandText = "Select [ID] from [EAEG_A_E_Satz_Version4] where [A3_ZugehoerigkeitZuEntsaedigungseinrichtungen] in ('10','20') and [EAEG_Stichtag]='" & rdsql & "'"
    '                            t = cmd.ExecuteScalar
    '                            If t <> "" Then
    '                                cmd.CommandText = "Select [ID] from [EAEG_B_D_Satz_Version4] where ([B14_Ausschlusskennzeichen_Pos31]='Y' or [B14_Ausschlusskennzeichen_Pos32]='Y' or [B14_Ausschlusskennzeichen_Pos33]='Y' or [B14_Ausschlusskennzeichen_Pos34]='Y' or [B14_Ausschlusskennzeichen_Pos35]='Y' or [B14_Ausschlusskennzeichen_Pos36]='Y' or [B14_Ausschlusskennzeichen_Pos37]='Y' or [B14_Ausschlusskennzeichen_Pos38]='Y' or [B14_Ausschlusskennzeichen_Pos39]='Y' or [B14_Ausschlusskennzeichen_Pos40]='Y' or [B14_Ausschlusskennzeichen_Pos41]='Y' or [B14_Ausschlusskennzeichen_Pos42]='Y' or [B14_Ausschlusskennzeichen_Pos43]='Y' or [B14_Ausschlusskennzeichen_Pos44]='Y' or [B14_Ausschlusskennzeichen_Pos45]='Y' or [B14_Ausschlusskennzeichen_Pos46]='Y' or [B14_Ausschlusskennzeichen_Pos47]='Y' or [B14_Ausschlusskennzeichen_Pos48]='Y' or [B14_Ausschlusskennzeichen_Pos49]='Y' or [B14_Ausschlusskennzeichen_Pos50]='Y') and [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                Dim t1 As String = cmd.ExecuteScalar
    '                                If t1 <> "" Then
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                Else
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where ([C20_Ausschlusskennzeichen_Pos11]='Y' or [C20_Ausschlusskennzeichen_Pos12]='Y' or [C20_Ausschlusskennzeichen_Pos13]='Y' or [C20_Ausschlusskennzeichen_Pos14]='Y' or [C20_Ausschlusskennzeichen_Pos15]='Y' or [C20_Ausschlusskennzeichen_Pos16]='Y' or [C20_Ausschlusskennzeichen_Pos17]='Y' or [C20_Ausschlusskennzeichen_Pos18]='Y' or [C20_Ausschlusskennzeichen_Pos19]='Y' or [C20_Ausschlusskennzeichen_Pos20]='Y' or [C20_Ausschlusskennzeichen_Pos21]='Y' or [C20_Ausschlusskennzeichen_Pos22]='Y' or [C20_Ausschlusskennzeichen_Pos23]='Y' or [C20_Ausschlusskennzeichen_Pos24]='Y' or [C20_Ausschlusskennzeichen_Pos25]='Y' or [C20_Ausschlusskennzeichen_Pos26]='Y' or [C20_Ausschlusskennzeichen_Pos27]='Y' or [C20_Ausschlusskennzeichen_Pos28]='Y' or [C20_Ausschlusskennzeichen_Pos29]='Y' or [C20_Ausschlusskennzeichen_Pos30]='Y' or [C20_Ausschlusskennzeichen_Pos31]='Y' or [C20_Ausschlusskennzeichen_Pos32]='Y' or [C20_Ausschlusskennzeichen_Pos33]='Y' or [C20_Ausschlusskennzeichen_Pos34]='Y' or [C20_Ausschlusskennzeichen_Pos35]='Y' or [C20_Ausschlusskennzeichen_Pos36]='Y' or [C20_Ausschlusskennzeichen_Pos37]='Y' or [C20_Ausschlusskennzeichen_Pos38]='Y' or [C20_Ausschlusskennzeichen_Pos39]='Y' or [C20_Ausschlusskennzeichen_Pos40]='Y' or [C20_Ausschlusskennzeichen_Pos41]='Y' or [C20_Ausschlusskennzeichen_Pos42]='Y' or [C20_Ausschlusskennzeichen_Pos43]='Y' or [C20_Ausschlusskennzeichen_Pos44]='Y' or [C20_Ausschlusskennzeichen_Pos45]='Y' or [C20_Ausschlusskennzeichen_Pos46]='Y' or [C20_Ausschlusskennzeichen_Pos47]='Y' or [C20_Ausschlusskennzeichen_Pos48]='Y' or [C20_Ausschlusskennzeichen_Pos49]='Y' or [C20_Ausschlusskennzeichen_Pos50]='Y') and [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()

    '                                End If

    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If


    '                            'D11
    '                            If t <> "" Then
    '                                cmd.CommandText = "Select [ID] from [EAEG_B_D_Satz_Version4] where ([B14_Ausschlusskennzeichen_Pos31]='Y' or [B14_Ausschlusskennzeichen_Pos32]='Y' or [B14_Ausschlusskennzeichen_Pos33]='Y' or [B14_Ausschlusskennzeichen_Pos34]='Y' or [B14_Ausschlusskennzeichen_Pos35]='Y' or [B14_Ausschlusskennzeichen_Pos36]='Y' or [B14_Ausschlusskennzeichen_Pos37]='Y' or [B14_Ausschlusskennzeichen_Pos38]='Y' or [B14_Ausschlusskennzeichen_Pos39]='Y' or [B14_Ausschlusskennzeichen_Pos40]='Y' or [B14_Ausschlusskennzeichen_Pos41]='Y' or [B14_Ausschlusskennzeichen_Pos42]='Y' or [B14_Ausschlusskennzeichen_Pos43]='Y' or [B14_Ausschlusskennzeichen_Pos44]='Y' or [B14_Ausschlusskennzeichen_Pos45]='Y' or [B14_Ausschlusskennzeichen_Pos46]='Y' or [B14_Ausschlusskennzeichen_Pos47]='Y' or [B14_Ausschlusskennzeichen_Pos48]='Y' or [B14_Ausschlusskennzeichen_Pos49]='Y' or [B14_Ausschlusskennzeichen_Pos50]='Y') and [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                Dim t1 As String = cmd.ExecuteScalar
    '                                If t1 <> "" Then
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                Else
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where ([C20_Ausschlusskennzeichen_Pos21]='Y' or [C20_Ausschlusskennzeichen_Pos22]='Y' or [C20_Ausschlusskennzeichen_Pos23]='Y' or [C20_Ausschlusskennzeichen_Pos24]='Y' or [C20_Ausschlusskennzeichen_Pos25]='Y' or [C20_Ausschlusskennzeichen_Pos26]='Y' or [C20_Ausschlusskennzeichen_Pos27]='Y' or [C20_Ausschlusskennzeichen_Pos28]='Y' or [C20_Ausschlusskennzeichen_Pos29]='Y' or [C20_Ausschlusskennzeichen_Pos30]='Y' or [C20_Ausschlusskennzeichen_Pos31]='Y' or [C20_Ausschlusskennzeichen_Pos32]='Y' or [C20_Ausschlusskennzeichen_Pos33]='Y' or [C20_Ausschlusskennzeichen_Pos34]='Y' or [C20_Ausschlusskennzeichen_Pos35]='Y' or [C20_Ausschlusskennzeichen_Pos36]='Y' or [C20_Ausschlusskennzeichen_Pos37]='Y' or [C20_Ausschlusskennzeichen_Pos38]='Y' or [C20_Ausschlusskennzeichen_Pos39]='Y' or [C20_Ausschlusskennzeichen_Pos40]='Y' or [C20_Ausschlusskennzeichen_Pos41]='Y' or [C20_Ausschlusskennzeichen_Pos42]='Y' or [C20_Ausschlusskennzeichen_Pos43]='Y' or [C20_Ausschlusskennzeichen_Pos44]='Y' or [C20_Ausschlusskennzeichen_Pos45]='Y' or [C20_Ausschlusskennzeichen_Pos46]='Y' or [C20_Ausschlusskennzeichen_Pos47]='Y' or [C20_Ausschlusskennzeichen_Pos48]='Y' or [C20_Ausschlusskennzeichen_Pos49]='Y' or [C20_Ausschlusskennzeichen_Pos50]='Y') and [C19_KontosaldoInEuro]>0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE] is NULL and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()

    '                                End If
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If

    '                            'D14
    '                            If t <> "" Then
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D14_GesamtsaldoForderungenAnKunden]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]<0 and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D14_GesamtsaldoForderungenAnKunden]=0 where [D14_GesamtsaldoForderungenAnKunden] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D14_GesamtsaldoForderungenAnKunden]=0 where [D14_GesamtsaldoForderungenAnKunden] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If

    '                            'D12
    '                            If t <> "" Then
    '                                Dim berechnung1 As Double = 0
    '                                Dim berechnung2 As Double = 0
    '                                Dim berechnung3 As Double = 0
    '                                cmd.CommandText = "Select  [D3_GesamtsaldoEinlagen] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung1 = cmd.ExecuteScalar
    '                                Else
    '                                    berechnung1 = 0
    '                                End If
    '                                cmd.CommandText = "Select  [D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung2 = cmd.ExecuteScalar
    '                                Else
    '                                    berechnung2 = 0
    '                                End If
    '                                cmd.CommandText = "Select  ABS([D14_GesamtsaldoForderungenAnKunden]) from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                    berechnung3 = cmd.ExecuteScalar
    '                                Else
    '                                    berechnung3 = 0
    '                                End If
    '                                Dim result1 As Double = berechnung1 - berechnung2 - berechnung3
    '                                If result1 > 0 Then
    '                                    cmd.CommandText = "Select(Select distinct [C5_AnzahlKontoinhaber] from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "')*(Select [A6_SicherungsgrenzeBeiZusatzsicherung] from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "')"
    '                                    Dim result2 As Double = 0
    '                                    If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                        result2 = cmd.ExecuteScalar
    '                                        If result1 > result2 Then
    '                                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D12_GesamtsaldoZusatzabsicherung]=" & Str(result2) & " - [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE] - [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE] where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                            cmd.ExecuteNonQuery()
    '                                        Else
    '                                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D12_GesamtsaldoZusatzabsicherung]=" & Str(result1) & " - [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE] - [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE] where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                            cmd.ExecuteNonQuery()
    '                                        End If
    '                                    End If
    '                                Else
    '                                    cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D12_GesamtsaldoZusatzabsicherung]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                    cmd.ExecuteNonQuery()
    '                                End If
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D12_GesamtsaldoZusatzabsicherung]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If

    '                            'D13
    '                            If t <> "" Then
    '                                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                                'Dim berechnung1 As Double = 0
    '                                'Dim berechnung2 As Double = 0
    '                                'Dim berechnung3 As Double = 0
    '                                'cmd.CommandText = "Select(Select [D3_GesamtsaldoEinlagen] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "')-(Select [D14_GesamtsaldoForderungenAnKunden] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "')"
    '                                'If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                'berechnung1 = cmd.ExecuteScalar
    '                                'Else
    '                                'berechnung1 = 0
    '                                'End If
    '                                'cmd.CommandText = "Select(Select distinct [C5_AnzahlKontoinhaber] from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "')*(Select [A6_SicherungsgrenzeBeiZusatzsicherung] from [EAEG_A_E_Satz_Version4])"
    '                                'If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                'berechnung2 = cmd.ExecuteScalar
    '                                'Else
    '                                'berechnung2 = 0
    '                                'End If
    '                                'If berechnung1 > berechnung2 Then
    '                                'MessageBox.Show("Achtung!! Feld D13 für Kunden: " & STAMM & vbNewLine & " Bitte spezifikation lesen und manuell korigieren!", "EINGABEBEDINGUNG IM FELD D13", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                                'Dim berechnung4 As Double = 0
    '                                'Dim berechnung5 As Double = 0
    '                                'cmd.CommandText = "Select(Select [D3_GesamtsaldoEinlagen] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "')-(Select [D14_GesamtsaldoForderungenAnKunden] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "') -(Select [D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "') -(Select [D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "')-(Select [D12_GesamtsaldoZusatzabsicherung] from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen]='" & STAMM & "')"
    '                                'If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                'berechnung4 = cmd.ExecuteScalar
    '                                'Else
    '                                'berechnung4 = 0
    '                                'End If
    '                                'cmd.CommandText = "Select(Select distinct [C5_AnzahlKontoinhaber] from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "')*(Select [A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG] from [EAEG_A_E_Satz_Version4])-(Select [A6_SicherungsgrenzeBeiZusatzsicherung] from [EAEG_A_E_Satz_Version4])"
    '                                'If cmd.ExecuteScalar IsNot DBNull.Value Then
    '                                'berechnung5 = cmd.ExecuteScalar
    '                                'Else
    '                                'berechnung5 = 0
    '                                'End If
    '                                'If berechnung4 > berechnung5 Then
    '                                'cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]=" & Str(berechnung5) & " where [B2_Ordnungskennzeichen]= '" & STAMM & "'"
    '                                'cmd.ExecuteNonQuery()
    '                                'Else
    '                                'cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]=" & Str(berechnung4) & " where [B2_Ordnungskennzeichen]= '" & STAMM & "'"
    '                                'cmd.ExecuteNonQuery()
    '                                'End If
    '                                'cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]<= 0 "
    '                                'cmd.ExecuteNonQuery()
    '                                'Else
    '                                'cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "'"
    '                                'cmd.ExecuteNonQuery()
    '                                'End If
    '                            Else
    '                                cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]=0 where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                                cmd.ExecuteNonQuery()
    '                            End If

    '                            'D15
    '                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D15_GesamtsaldoNichtEWR_Niederlassungen]=(Select Sum ([C19_KontosaldoInEuro]) from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]>0 and [C23_KennzeichenNichtEWR_Niederlassung] is not NULL and [B2_OrdnungskennzeichenId]='" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "') where [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()
    '                            cmd.CommandText = "UPDATE [EAEG_B_D_Satz_Version4] SET [D15_GesamtsaldoNichtEWR_Niederlassungen]=0 where [D15_GesamtsaldoNichtEWR_Niederlassungen] is NULL and [B2_Ordnungskennzeichen]= '" & STAMM & "' and [EAEG_Stichtag]='" & rdsql & "'"
    '                            cmd.ExecuteNonQuery()

    '                        Next

    '                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                        'E-SATZ SUMMEN
    '                        SplashScreenManager.Default.SetWaitFormCaption("Aktualissieren der Summenfelder in Tabelle " & vbNewLine & "EAEG_A_E_Satz_Version4 (E-SÄTZE) für Stichtag " & rd)
    '                        Me.BgwEAEG_Daten_Erstellung.ReportProgress(40, "Aktualissieren der Summenfelder in Tabelle EAEG_A_E_Satz_Version4 (E-SÄTZE) für Stichtag " & rd)
    '                        'E3
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E3_GesamteinreichersaldoEinlagen]= (Select Sum([D3_GesamtsaldoEinlagen]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E4
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E4_GesamteinreichersaldoAusschluesseEinSiG]= (Select Sum([D4_GesamtsaldoGesetzlicheAusschluesse]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E5
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG]= (Select Sum([D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E6
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E6_GesamteinreichersaldoGedekterEinlagenEinSiG]= (Select Sum([D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E7
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E7_GesamteinreichersaldoKappungEinSiG]= (Select Sum([D7_GesamtsaldoGesetzlichGedeckterEinlagen_UNTERGRENZE]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E8
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E8_GesamteinreichersaldoEWR_Niederlassungen]= (Select Sum([D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E9
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat]= (Select Sum([D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E10
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut]= (Select Sum([D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E11
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E11_GesamteinreichersaldoAusschlueseNurStatut]= (Select Sum([D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E12
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E12_GesamteinreichersaldoZusatzsicherung]= (Select Sum([D12_GesamtsaldoZusatzabsicherung]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'Special Case
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E12_GesamteinreichersaldoZusatzsicherung]=(Select Case when [E12_GesamteinreichersaldoZusatzsicherung]>[E4_GesamteinreichersaldoAusschluesseEinSiG] then [E3_GesamteinreichersaldoEinlagen]-[E6_GesamteinreichersaldoGedekterEinlagenEinSiG]-[E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat]else [E12_GesamteinreichersaldoZusatzsicherung] end from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E13
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]= (Select Sum([D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E14
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E14_GesamteinreichersaldoForderungenAnKunden]= (Select Sum([D14_GesamtsaldoForderungenAnKunden]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        'E15
    '                        cmd.CommandText = "UPDATE [EAEG_A_E_Satz_Version4] SET [E15_GesamteinreichersaldoNichtEWR_Niederlassungen]= (Select Sum([D15_GesamtsaldoNichtEWR_Niederlassungen]) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "') where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()


    '                        CloseSqlConnections()

    '                    Else
    '                        CloseSqlConnections()

    '                        XtraMessageBox.Show("Nicht Gültige Adressendaten von Kunde(n) gefunden in EAEG Stamm Daten! Bitte Adressendaten prüfen und ergänzen!", "EAEG Einreicherdateierstellung nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                        Exit Sub
    '                    End If
    '                Else
    '                    CloseSqlConnections()

    '                    XtraMessageBox.Show("EZB Währungskurse sind nicht vorhanden für den " & rd & vbNewLine & "Bitte EZB Währungskurse importieren!", "EAEG Einreicherdateierstellung nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                    Exit Sub
    '                End If


    '            Else
    '                CloseSqlConnections()

    '                XtraMessageBox.Show("Kunde(n) ohne Geburts bzw. Gründungsdatum in EAEG Stamm Daten! Bitte fehlende Daten eintragen!", "EAEG Einreicherdateierstellung nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                Exit Sub
    '            End If
    '        Catch ex As Exception
    '            SplashScreenManager.CloseForm(False)
    '            CloseSqlConnections()
    '            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Me.BgwEAEG_Daten_Erstellung.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
    '            Exit Sub
    '        End Try
    '    End Sub

    '    Private Sub BgwEAEG_Daten_Erstellung_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwEAEG_Daten_Erstellung.ProgressChanged
    '        OpenEVENT_SqlConnection()
    '        Try
    '            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','EAEG Daten erstellung Version 4.1 (ERWEITERT)','EAEG Daten erstellung Version 4.1 (ERWEITERT)')"
    '            cmdEVENT.ExecuteNonQuery()
    '        Catch ex As System.Exception
    '            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','EAEG Daten erstellung Version 4.1 (ERWEITERT)','EAEG Daten erstellung Version 4.1 (ERWEITERT)')"
    '            cmdEVENT.ExecuteNonQuery()
    '            Exit Try
    '        End Try
    '        CloseEVENT_SqlConnection()
    '    End Sub

    '    Private Sub BgwEAEG_Daten_Erstellung_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwEAEG_Daten_Erstellung.RunWorkerCompleted
    '        If LayoutControl2.Visible = False Then
    '            Me.EAEG_C_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_C_Satz_Version4, rd)
    '            Me.EAEG_B_D_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_B_D_Satz_Version4, rd)
    '            Me.EAEG_A_E_Satz_Version4TableAdapter.FillByStichtag(Me.EAEGDataSet.EAEG_A_E_Satz_Version4, rd)
    '        ElseIf LayoutControl2.Visible = True Then
    '            Me.EAEG_A_E_Satz_Version4_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_A_E_Satz_Version4_ALL)
    '        End If

    '        SplashScreenManager.CloseForm(False)
    '    End Sub
    '#End Region

    '#Region "EAEG_EINREICHER_DATEI_ERSTELLUNG_ERWEITERT"

    '    Private Sub EAEG_EinreicherDatei_Erstellung_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_EinreicherDatei_Erstellung_BarButtonItem.ItemClick
    '        If XtraMessageBox.Show("Soll die EAEG Datei (ERWEITERT) für den Stichtag: " & Me.EAEG_Stichtag_DateEdit.Text & " erstellt werden?" & vbNewLine & vbNewLine & "Vorhandene Datei mit den selben Namen wird dabei gelöscht!", "EAEG Datei erstellung ERWEITERT (Version 4.1)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
    '            Try
    '                rd = Me.EAEG_Stichtag_DateEdit.Text
    '                rdsql = rd.ToString("yyyyMMdd")
    '                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '                SplashScreenManager.Default.SetWaitFormCaption("Datendefinition A und E Satz")
    '                'Datendefinition  A und E Satz
    '                Dim EAEGDATEI As String = Nothing
    '                Dim A_SATZ As String = Nothing
    '                Dim EAEG_Stichtag As Date
    '                Dim EAEG_DateiName As String = Nothing
    '                Dim A1 As String = Nothing
    '                Dim A2 As String = Nothing
    '                Dim A3 As String = Nothing
    '                Dim A4 As Double = 0
    '                Dim A5 As Double = 0
    '                Dim A6 As Double = 0
    '                Dim A7 As Double = 0
    '                Dim E_SATZ As String = Nothing
    '                Dim E1 As String = Nothing
    '                Dim E2 As String = Nothing
    '                Dim E3 As Double = 0
    '                Dim E4 As Double = 0
    '                Dim E5 As Double = 0
    '                Dim E6 As Double = 0
    '                Dim E7 As Double = 0
    '                Dim E8 As Double = 0
    '                Dim E9 As Double = 0
    '                Dim E10 As Double = 0
    '                Dim E11 As Double = 0
    '                Dim E12 As Double = 0
    '                Dim E13 As Double = 0
    '                Dim E14 As Double = 0
    '                Dim E15 As Double = 0

    '                OpenSqlConnections()


    '                SplashScreenManager.Default.SetWaitFormCaption("Lade EAEG Dateiverzeichnis")
    '                'Get EAEG File directory
    '                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EAEG_File_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EAEG_CREATION_PATH'"
    '                Dim EAEG_FILE_DIR As String = cmd.ExecuteScalar

    '                'A und E SATZ
    '                SplashScreenManager.Default.SetWaitFormCaption("Lade Daten für A Satz")
    '                QueryText = "SELECT  [ID],[EAEG_Stichtag],[A1_Satzidentifikator],[A2_Institut],[A3_ZugehoerigkeitZuEntsaedigungseinrichtungen],[A4_GesetzlicheEntschaedigungsobergrenzeEAEG],[A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland],[A6_SicherungsgrenzeBeiZusatzsicherung],[A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG],[E1_Satzidentifikator],[E2_Institut],[E3_GesamteinreichersaldoEinlagen],[E4_GesamteinreichersaldoAusschluesseEinSiG],[E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG],[E6_GesamteinreichersaldoGedekterEinlagenEinSiG],[E7_GesamteinreichersaldoKappungEinSiG],[E8_GesamteinreichersaldoEWR_Niederlassungen],[E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat],[E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut],[E11_GesamteinreichersaldoAusschlueseNurStatut],[E12_GesamteinreichersaldoZusatzsicherung],[E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG],[E14_GesamteinreichersaldoForderungenAnKunden],[E15_GesamteinreichersaldoNichtEWR_Niederlassungen] FROM [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                dt = New DataTable()
    '                da.Fill(dt)
    '                For i = 0 To dt.Rows.Count - 1
    '                    EAEG_Stichtag = dt.Rows.Item(0).Item("EAEG_Stichtag")
    '                    EAEG_DateiName = EAEG_Stichtag.ToString("yyMMdd")
    '                    A1 = dt.Rows.Item(0).Item("A1_Satzidentifikator")
    '                    A2 = dt.Rows.Item(0).Item("A2_Institut")
    '                    A3 = dt.Rows.Item(0).Item("A3_ZugehoerigkeitZuEntsaedigungseinrichtungen")
    '                    A4 = dt.Rows.Item(0).Item("A4_GesetzlicheEntschaedigungsobergrenzeEAEG")
    '                    A5 = dt.Rows.Item(0).Item("A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland")
    '                    A6 = dt.Rows.Item(0).Item("A6_SicherungsgrenzeBeiZusatzsicherung")
    '                    A7 = dt.Rows.Item(0).Item("A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG")
    '                    A_SATZ = A1 & "*" & A2 & "*" & A3 & "*" & A4.ToString("#0.00") & "*" & A5.ToString("#0.00") & "*" & A6.ToString("#0.00") & "*" & A7.ToString("#0.00")

    '                    E1 = dt.Rows.Item(0).Item("E1_Satzidentifikator")
    '                    E2 = dt.Rows.Item(0).Item("E2_Institut")
    '                    E3 = dt.Rows.Item(0).Item("E3_GesamteinreichersaldoEinlagen")
    '                    E4 = dt.Rows.Item(0).Item("E4_GesamteinreichersaldoAusschluesseEinSiG")
    '                    E5 = dt.Rows.Item(0).Item("E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG")
    '                    E6 = dt.Rows.Item(0).Item("E6_GesamteinreichersaldoGedekterEinlagenEinSiG")
    '                    E7 = dt.Rows.Item(0).Item("E7_GesamteinreichersaldoKappungEinSiG")
    '                    E8 = dt.Rows.Item(0).Item("E8_GesamteinreichersaldoEWR_Niederlassungen")
    '                    E9 = dt.Rows.Item(0).Item("E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat")
    '                    E10 = dt.Rows.Item(0).Item("E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut")
    '                    E11 = dt.Rows.Item(0).Item("E11_GesamteinreichersaldoAusschlueseNurStatut")
    '                    E12 = dt.Rows.Item(0).Item("E12_GesamteinreichersaldoZusatzsicherung")
    '                    E13 = dt.Rows.Item(0).Item("E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG")
    '                    E14 = dt.Rows.Item(0).Item("E14_GesamteinreichersaldoForderungenAnKunden")
    '                    E15 = dt.Rows.Item(0).Item("E15_GesamteinreichersaldoNichtEWR_Niederlassungen")
    '                    E_SATZ = E1 & "*" & E2 & "*" & E3.ToString("#0.00") & "*" & E4.ToString("#0.00") & "*" & E5.ToString("#0.00") & "*" & E6.ToString("#0.00") & "*" & E7.ToString("#0.00") & "*" & E8.ToString("#0.00") & "*" & E9.ToString("#0.00") & "*" & E10.ToString("#0.00") & "*" & E11.ToString("#0.00") & "*" & E12.ToString("#0.00") & "*" & E13.ToString("#0.00") & "*" & E14.ToString("#0.00") & "*" & E15.ToString("#0.00")

    '                    EAEGDATEI = "0000000" & A2 & EAEG_DateiName & ".esf"
    '                Next

    '                If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
    '                    File.Delete(EAEG_FILE_DIR & EAEGDATEI)
    '                End If

    '                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, A_SATZ & vbCrLf)

    '                SplashScreenManager.Default.SetWaitFormCaption("Datendefinition B und D Satz")
    '                'B,D und C Sätze
    '                'Datendefinition  B,D und C Satz
    '                Dim B_SATZ As String = Nothing
    '                Dim B1 As String = Nothing
    '                Dim B2 As String = Nothing
    '                Dim B3 As String = Nothing
    '                Dim B4 As String = Nothing
    '                Dim B5 As String = Nothing
    '                Dim B6 As String = Nothing
    '                Dim B7 As String = Nothing
    '                Dim B8 As String = Nothing
    '                Dim B9 As String = Nothing
    '                Dim B10 As String = Nothing
    '                Dim B11 As String = Nothing
    '                Dim B12 As Date
    '                Dim B12s As String = Nothing
    '                Dim B13 As String = Nothing
    '                Dim B14_1 As String = Nothing
    '                Dim B14_2 As String = Nothing
    '                Dim B14_3 As String = Nothing
    '                Dim B14_4 As String = Nothing
    '                Dim B14_5 As String = Nothing
    '                Dim B14_6 As String = Nothing
    '                Dim B14_7 As String = Nothing
    '                Dim B14_8 As String = Nothing
    '                Dim B14_9 As String = Nothing
    '                Dim B14_10 As String = Nothing
    '                Dim B14_11 As String = Nothing
    '                Dim B14_12 As String = Nothing
    '                Dim B14_13 As String = Nothing
    '                Dim B14_14 As String = Nothing
    '                Dim B14_15 As String = Nothing
    '                Dim B14_16 As String = Nothing
    '                Dim B14_17 As String = Nothing
    '                Dim B14_18 As String = Nothing
    '                Dim B14_19 As String = Nothing
    '                Dim B14_20 As String = Nothing
    '                Dim B14_21 As String = Nothing
    '                Dim B14_22 As String = Nothing
    '                Dim B14_23 As String = Nothing
    '                Dim B14_24 As String = Nothing
    '                Dim B14_25 As String = Nothing
    '                Dim B14_26 As String = Nothing
    '                Dim B14_27 As String = Nothing
    '                Dim B14_28 As String = Nothing
    '                Dim B14_29 As String = Nothing
    '                Dim B14_30 As String = Nothing
    '                Dim B14_31 As String = Nothing
    '                Dim B14_32 As String = Nothing
    '                Dim B14_33 As String = Nothing
    '                Dim B14_34 As String = Nothing
    '                Dim B14_35 As String = Nothing
    '                Dim B14_36 As String = Nothing
    '                Dim B14_37 As String = Nothing
    '                Dim B14_38 As String = Nothing
    '                Dim B14_39 As String = Nothing
    '                Dim B14_40 As String = Nothing
    '                Dim B14_41 As String = Nothing
    '                Dim B14_42 As String = Nothing
    '                Dim B14_43 As String = Nothing
    '                Dim B14_44 As String = Nothing
    '                Dim B14_45 As String = Nothing
    '                Dim B14_46 As String = Nothing
    '                Dim B14_47 As String = Nothing
    '                Dim B14_48 As String = Nothing
    '                Dim B14_49 As String = Nothing
    '                Dim B14_50 As String = Nothing
    '                Dim B15 As String = Nothing 'Kundenkontakt

    '                Dim C_SATZ As String = Nothing
    '                Dim C1 As String = Nothing
    '                Dim C2A As String = Nothing
    '                Dim C2B As String = Nothing
    '                Dim C3 As String = Nothing
    '                Dim C4 As String = Nothing
    '                Dim C5 As String = Nothing
    '                Dim C6 As Date
    '                Dim C6s As String = Nothing
    '                Dim C7 As String = Nothing
    '                Dim C8 As String = Nothing
    '                Dim C9 As Double = 0
    '                Dim C10 As Double = 0
    '                Dim C11 As Double = 0
    '                Dim C12 As Double = 0
    '                Dim C12s As String = Nothing
    '                Dim C13 As Date
    '                Dim C13s As String = Nothing
    '                Dim C14 As Date
    '                Dim C14s As String = Nothing
    '                Dim C15 As String = Nothing
    '                Dim C16 As String = Nothing
    '                Dim C17 As Double = 0
    '                Dim C17s As String = Nothing
    '                Dim C18 As Double = 0
    '                Dim C18s As String = Nothing
    '                Dim C19 As Double = 0
    '                Dim C19s As String = Nothing
    '                Dim C20_1 As String = Nothing
    '                Dim C20_2 As String = Nothing
    '                Dim C20_3 As String = Nothing
    '                Dim C20_4 As String = Nothing
    '                Dim C20_5 As String = Nothing
    '                Dim C20_6 As String = Nothing
    '                Dim C20_7 As String = Nothing
    '                Dim C20_8 As String = Nothing
    '                Dim C20_9 As String = Nothing
    '                Dim C20_10 As String = Nothing
    '                Dim C20_11 As String = Nothing
    '                Dim C20_12 As String = Nothing
    '                Dim C20_13 As String = Nothing
    '                Dim C20_14 As String = Nothing
    '                Dim C20_15 As String = Nothing
    '                Dim C20_16 As String = Nothing
    '                Dim C20_17 As String = Nothing
    '                Dim C20_18 As String = Nothing
    '                Dim C20_19 As String = Nothing
    '                Dim C20_20 As String = Nothing
    '                Dim C20_21 As String = Nothing
    '                Dim C20_22 As String = Nothing
    '                Dim C20_23 As String = Nothing
    '                Dim C20_24 As String = Nothing
    '                Dim C20_25 As String = Nothing
    '                Dim C20_26 As String = Nothing
    '                Dim C20_27 As String = Nothing
    '                Dim C20_28 As String = Nothing
    '                Dim C20_29 As String = Nothing
    '                Dim C20_30 As String = Nothing
    '                Dim C20_31 As String = Nothing
    '                Dim C20_32 As String = Nothing
    '                Dim C20_33 As String = Nothing
    '                Dim C20_34 As String = Nothing
    '                Dim C20_35 As String = Nothing
    '                Dim C20_36 As String = Nothing
    '                Dim C20_37 As String = Nothing
    '                Dim C20_38 As String = Nothing
    '                Dim C20_39 As String = Nothing
    '                Dim C20_40 As String = Nothing
    '                Dim C20_41 As String = Nothing
    '                Dim C20_42 As String = Nothing
    '                Dim C20_43 As String = Nothing
    '                Dim C20_44 As String = Nothing
    '                Dim C20_45 As String = Nothing
    '                Dim C20_46 As String = Nothing
    '                Dim C20_47 As String = Nothing
    '                Dim C20_48 As String = Nothing
    '                Dim C20_49 As String = Nothing
    '                Dim C20_50 As String = Nothing

    '                Dim C21_1 As String = Nothing
    '                Dim C21_2 As String = Nothing
    '                Dim C21_3 As String = Nothing
    '                Dim C21_4 As String = Nothing
    '                Dim C21_5 As String = Nothing
    '                Dim C21_6 As String = Nothing
    '                Dim C21_7 As String = Nothing
    '                Dim C21_8 As String = Nothing
    '                Dim C21_9 As String = Nothing
    '                Dim C21_10 As String = Nothing
    '                Dim C21_11 As String = Nothing
    '                Dim C21_12 As String = Nothing
    '                Dim C21_13 As String = Nothing
    '                Dim C21_14 As String = Nothing
    '                Dim C21_15 As String = Nothing
    '                Dim C21_16 As String = Nothing
    '                Dim C21_17 As String = Nothing
    '                Dim C21_18 As String = Nothing
    '                Dim C21_19 As String = Nothing
    '                Dim C21_20 As String = Nothing
    '                Dim C21_21 As String = Nothing
    '                Dim C21_22 As String = Nothing
    '                Dim C21_23 As String = Nothing
    '                Dim C21_24 As String = Nothing
    '                Dim C21_25 As String = Nothing
    '                Dim C21_26 As String = Nothing
    '                Dim C21_27 As String = Nothing
    '                Dim C21_28 As String = Nothing
    '                Dim C21_29 As String = Nothing
    '                Dim C21_30 As String = Nothing
    '                Dim C21_31 As String = Nothing
    '                Dim C21_32 As String = Nothing
    '                Dim C21_33 As String = Nothing
    '                Dim C21_34 As String = Nothing
    '                Dim C21_35 As String = Nothing
    '                Dim C21_36 As String = Nothing
    '                Dim C21_37 As String = Nothing
    '                Dim C21_38 As String = Nothing
    '                Dim C21_39 As String = Nothing
    '                Dim C21_40 As String = Nothing
    '                Dim C21_41 As String = Nothing
    '                Dim C21_42 As String = Nothing
    '                Dim C21_43 As String = Nothing
    '                Dim C21_44 As String = Nothing
    '                Dim C21_45 As String = Nothing
    '                Dim C21_46 As String = Nothing
    '                Dim C21_47 As String = Nothing
    '                Dim C21_48 As String = Nothing
    '                Dim C21_49 As String = Nothing
    '                Dim C21_50 As String = Nothing

    '                Dim C22 As String = Nothing 'Kennzeichen EWR-Niederlassung
    '                Dim C23 As String = Nothing 'Kennzeichen Nicht EWR-Niederlassung

    '                Dim D1 As String = Nothing
    '                Dim D2 As String = Nothing
    '                Dim D3 As Double = 0
    '                Dim D4 As Double = 0
    '                Dim D5 As Double = 0
    '                Dim D6 As Double = 0
    '                Dim D7 As Double = 0
    '                Dim D8 As Double = 0
    '                Dim D9 As Double = 0
    '                Dim D10 As Double = 0
    '                Dim D11 As Double = 0
    '                Dim D12 As Double = 0
    '                Dim D13 As Double = 0
    '                Dim D14 As Double = 0
    '                Dim D15 As Double = 0

    '                SplashScreenManager.Default.SetWaitFormCaption("Lade Daten für B und D Satz")
    '                QueryText = "Select * from [EAEG_B_D_Satz_Version4] where [B2_Ordnungskennzeichen] in (Select [B2_OrdnungskennzeichenId] from [EAEG_C_Satz_Version4] where [C19_KontosaldoInEuro]<>0 and [EAEG_Stichtag]='" & rdsql & "') and [EAEG_Stichtag]='" & rdsql & "'"
    '                'QueryText = "Select * from [EAEG_B_D_Satz_Version4]"
    '                da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                dt = New DataTable()
    '                da.Fill(dt)
    '                For i = 0 To dt.Rows.Count - 1
    '                    SplashScreenManager.Default.SetWaitFormCaption("Lade B Satz Daten für KundenNr.: " & dt.Rows.Item(i).Item("B2_Ordnungskennzeichen"))
    '                    B1 = dt.Rows.Item(i).Item("B1_Satzidentifikator") & "*"
    '                    B2 = dt.Rows.Item(i).Item("B2_Ordnungskennzeichen") & "*"
    '                    B3 = dt.Rows.Item(i).Item("B3_Nachname") & "*"
    '                    B4 = dt.Rows.Item(i).Item("B4_Vorname") & "*"
    '                    B5 = dt.Rows.Item(i).Item("B5_Namenszusatz") & "*"
    '                    B6 = dt.Rows.Item(i).Item("B6_Anrede") & "*"
    '                    B7 = dt.Rows.Item(i).Item("B7_SrasseUndHausnummer") & "*"
    '                    B8 = dt.Rows.Item(i).Item("B8_ZusatzStrasse") & "*"
    '                    B9 = dt.Rows.Item(i).Item("B9_Postleitzahl") & "*"
    '                    B10 = dt.Rows.Item(i).Item("B10_Ort") & "*"
    '                    B11 = dt.Rows.Item(i).Item("B11_Land") & "*"
    '                    If IsDBNull(dt.Rows.Item(i).Item("B12_Geburtsdatum")) = False Then
    '                        B12 = dt.Rows.Item(i).Item("B12_Geburtsdatum")
    '                        B12s = B12.ToString("ddMMyyyy") & "*"
    '                    Else
    '                        B12s = "" & "*"
    '                    End If
    '                    B13 = dt.Rows.Item(i).Item("B13_Branche") & "*"
    '                    B14_1 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos1")
    '                    B14_2 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos2")
    '                    B14_3 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos3")
    '                    B14_4 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos4")
    '                    B14_5 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos5")
    '                    B14_6 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos6")
    '                    B14_7 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos7")
    '                    B14_8 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos8")
    '                    B14_9 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos9")
    '                    B14_10 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos10")
    '                    B14_11 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos11")
    '                    B14_12 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos12")
    '                    B14_13 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos13")
    '                    B14_14 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos14")
    '                    B14_15 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos15")
    '                    B14_16 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos16")
    '                    B14_17 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos17")
    '                    B14_18 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos18")
    '                    B14_19 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos19")
    '                    B14_20 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos20")
    '                    B14_21 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos21")
    '                    B14_22 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos22")
    '                    B14_23 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos23")
    '                    B14_24 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos24")
    '                    B14_25 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos25")
    '                    B14_26 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos26")
    '                    B14_27 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos27")
    '                    B14_28 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos28")
    '                    B14_29 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos29")
    '                    B14_30 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos30")
    '                    B14_31 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos31")
    '                    B14_32 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos32")
    '                    B14_33 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos33")
    '                    B14_34 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos34")
    '                    B14_35 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos35")
    '                    B14_36 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos36")
    '                    B14_37 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos37")
    '                    B14_38 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos38")
    '                    B14_39 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos39")
    '                    B14_40 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos40")
    '                    B14_41 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos41")
    '                    B14_42 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos42")
    '                    B14_43 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos43")
    '                    B14_44 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos44")
    '                    B14_45 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos45")
    '                    B14_46 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos46")
    '                    B14_47 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos47")
    '                    B14_48 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos48")
    '                    B14_49 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos49")
    '                    B14_50 = dt.Rows.Item(i).Item("B14_Ausschlusskennzeichen_Pos50")
    '                    Dim B14_All As String = B14_1 & B14_2 & B14_3 & B14_4 & B14_5 & B14_6 & B14_7 & B14_8 & B14_9 & B14_10 & B14_11 & B14_12 & B14_13 & B14_14 & B14_15 & B14_16 & B14_17 & B14_18 & B14_19 & B14_20 & B14_21 & B14_22 & B14_23 & B14_24 & B14_25 & B14_26 & B14_27 & B14_28 & B14_29 & B14_30 & B14_31 & B14_32 & B14_33 & B14_34 & B14_35 & B14_36 & B14_37 & B14_38 & B14_39 & B14_40 & B14_41 & B14_42 & B14_43 & B14_44 & B14_45 & B14_46 & B14_47 & B14_48 & B14_49 & B14_50

    '                    If IsDBNull(dt.Rows.Item(i).Item("B15_Kundenkontakt")) = False Then
    '                        B15 = "*" & dt.Rows.Item(i).Item("B15_Kundenkontakt")
    '                    Else
    '                        B15 = "*"
    '                    End If

    '                    B_SATZ = B1 & B2 & B3 & B4 & B5 & B6 & B7 & B8 & B9 & B10 & B11 & B12s & B13 & B14_All & B15 '+++++++

    '                    System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, B_SATZ & vbCrLf)

    '                    Dim STAMM As String = dt.Rows.Item(i).Item("B2_Ordnungskennzeichen")
    '                    QueryText1 = "Select * from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "' and [C19_KontosaldoInEuro]<>0 and [EAEG_Stichtag]='" & rdsql & "'"
    '                    'QueryText1 = "Select * from [EAEG_C_Satz_Version4] where [B2_OrdnungskennzeichenId]='" & STAMM & "'"
    '                    da1 = New SqlDataAdapter(QueryText1.Trim(), conn)
    '                    dt1 = New DataTable()
    '                    da1.Fill(dt1)
    '                    For y = 0 To dt1.Rows.Count - 1
    '                        SplashScreenManager.Default.SetWaitFormCaption("Lade C Satz Daten für Konto Nr./ GeschäftsNr.: " & dt1.Rows.Item(y).Item("C2_Kontonummer"))
    '                        C1 = dt1.Rows.Item(y).Item("C1_Satzidentifikator") & "*"
    '                        C2A = dt1.Rows.Item(y).Item("B2_OrdnungskennzeichenId") & "*"
    '                        C2B = dt1.Rows.Item(y).Item("C2_Kontonummer") & "*"
    '                        C3 = dt1.Rows.Item(y).Item("C3_Kontozusatzbezeichnung") & "*"
    '                        C4 = dt1.Rows.Item(y).Item("C4_AbweichendWirtschftlichBerechtigter") & "*"
    '                        C5 = dt1.Rows.Item(y).Item("C5_AnzahlKontoinhaber") & "*"
    '                        C6 = dt1.Rows.Item(y).Item("C6_Kontoerröfnung")
    '                        C6s = C6.ToString("ddMMyyyy") & "*"
    '                        C7 = dt1.Rows.Item(y).Item("C7_Kontoart") & "*"
    '                        C8 = dt1.Rows.Item(y).Item("C8_Währung") & "*"
    '                        C9 = dt1.Rows.Item(y).Item("C9_KapitalsaldoInKontowährung")
    '                        C10 = dt1.Rows.Item(y).Item("C10_Umrechnungskurs")
    '                        C11 = dt1.Rows.Item(y).Item("C11_KapitalsaldoInEuro")
    '                        If IsDBNull(dt1.Rows.Item(y).Item("C12_Zinssatz")) = False Then
    '                            C12 = dt1.Rows.Item(y).Item("C12_Zinssatz")
    '                            C12s = C12.ToString("#0.00000")
    '                        Else
    '                            C12s = ""
    '                        End If

    '                        If IsDBNull(dt1.Rows.Item(y).Item("C13_LetzteZinsfaelligkeit")) = False Then
    '                            C13 = dt1.Rows.Item(y).Item("C13_LetzteZinsfaelligkeit")
    '                            C13s = C13.ToString("ddMMyyyy") & "*"
    '                        Else
    '                            C13s = "" & "*"
    '                        End If
    '                        If IsDBNull(dt1.Rows.Item(y).Item("C14_Endfaelligkeit")) = False Then
    '                            C14 = dt1.Rows.Item(y).Item("C14_Endfaelligkeit")
    '                            C14s = C14.ToString("ddMMyyyy") & "*"
    '                        Else
    '                            C14s = "" & "*"
    '                        End If
    '                        C15 = dt1.Rows.Item(y).Item("C15_Faelligkeitsmerkmal") & "*"
    '                        C16 = dt1.Rows.Item(y).Item("C16_Zinsmethode") & "*"
    '                        If IsDBNull(dt1.Rows.Item(y).Item("C17_ZinssaldoInKontowährung")) = False Then
    '                            C17 = dt1.Rows.Item(y).Item("C17_ZinssaldoInKontowährung")
    '                            C17s = C17.ToString("#0.00") & "*"
    '                        Else
    '                            C17s = "" & "*"
    '                        End If
    '                        If IsDBNull(dt1.Rows.Item(y).Item("C18_ZinssaldoInEuro")) = False Then
    '                            C18 = dt1.Rows.Item(y).Item("C18_ZinssaldoInEuro")
    '                            C18s = C18.ToString("#0.00") & "*"
    '                        Else
    '                            C18s = "" & "*"
    '                        End If

    '                        If IsDBNull(dt1.Rows.Item(y).Item("C19_KontosaldoInEuro")) = False Then
    '                            C19 = dt1.Rows.Item(y).Item("C19_KontosaldoInEuro")
    '                            C19s = C19.ToString("#0.00") & "*"
    '                        Else
    '                            C19s = "" & "*"
    '                        End If

    '                        C20_1 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos1")
    '                        C20_2 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos2")
    '                        C20_3 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos3")
    '                        C20_4 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos4")
    '                        C20_5 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos5")
    '                        C20_6 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos6")
    '                        C20_7 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos7")
    '                        C20_8 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos8")
    '                        C20_9 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos9")
    '                        C20_10 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos10")
    '                        C20_11 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos11")
    '                        C20_12 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos12")
    '                        C20_13 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos13")
    '                        C20_14 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos14")
    '                        C20_15 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos15")
    '                        C20_16 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos16")
    '                        C20_17 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos17")
    '                        C20_18 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos18")
    '                        C20_19 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos19")
    '                        C20_20 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos20")
    '                        C20_21 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos21")
    '                        C20_22 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos22")
    '                        C20_23 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos23")
    '                        C20_24 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos24")
    '                        C20_25 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos25")
    '                        C20_26 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos26")
    '                        C20_27 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos27")
    '                        C20_28 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos28")
    '                        C20_29 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos29")
    '                        C20_30 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos30")
    '                        C20_31 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos31")
    '                        C20_32 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos32")
    '                        C20_33 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos33")
    '                        C20_34 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos34")
    '                        C20_35 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos35")
    '                        C20_36 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos36")
    '                        C20_37 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos37")
    '                        C20_38 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos38")
    '                        C20_39 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos39")
    '                        C20_40 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos40")
    '                        C20_41 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos41")
    '                        C20_42 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos42")
    '                        C20_43 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos43")
    '                        C20_44 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos44")
    '                        C20_45 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos45")
    '                        C20_46 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos46")
    '                        C20_47 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos47")
    '                        C20_48 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos48")
    '                        C20_49 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos49")
    '                        C20_50 = dt1.Rows.Item(y).Item("C20_Ausschlusskennzeichen_Pos50")
    '                        Dim C20_All As String = C20_1 & C20_2 & C20_3 & C20_4 & C20_5 & C20_6 & C20_7 & C20_8 & C20_9 & C20_10 & C20_11 & C20_12 & C20_13 & C20_14 & C20_15 & C20_16 & C20_17 & C20_18 & C20_19 & C20_20 & C20_21 & C20_22 & C20_23 & C20_24 & C20_25 & C20_26 & C20_27 & C20_28 & C20_29 & C20_30 & C20_31 & C20_32 & C20_33 & C20_34 & C20_35 & C20_36 & C20_37 & C20_38 & C20_39 & C20_40 & C20_41 & C20_42 & C20_43 & C20_44 & C20_45 & C20_46 & C20_47 & C20_48 & C20_49 & C20_50


    '                        C21_1 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos1")
    '                        C21_2 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos2")
    '                        C21_3 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos3")
    '                        C21_4 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos4")
    '                        C21_5 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos5")
    '                        C21_6 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos6")
    '                        C21_7 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos7")
    '                        C21_8 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos8")
    '                        C21_9 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos9")
    '                        C21_10 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos10")
    '                        C21_11 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos11")
    '                        C21_12 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos12")
    '                        C21_13 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos13")
    '                        C21_14 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos14")
    '                        C21_15 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos15")
    '                        C21_16 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos16")
    '                        C21_17 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos17")
    '                        C21_18 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos18")
    '                        C21_19 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos19")
    '                        C21_20 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos20")
    '                        C21_21 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos21")
    '                        C21_22 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos22")
    '                        C21_23 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos23")
    '                        C21_24 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos24")
    '                        C21_25 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos25")
    '                        C21_26 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos26")
    '                        C21_27 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos27")
    '                        C21_28 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos28")
    '                        C21_29 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos29")
    '                        C21_30 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos30")
    '                        C21_31 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos31")
    '                        C21_32 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos32")
    '                        C21_33 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos33")
    '                        C21_34 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos34")
    '                        C21_35 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos35")
    '                        C21_36 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos36")
    '                        C21_37 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos37")
    '                        C21_38 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos38")
    '                        C21_39 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos39")
    '                        C21_40 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos40")
    '                        C21_41 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos41")
    '                        C21_42 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos42")
    '                        C21_43 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos43")
    '                        C21_44 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos44")
    '                        C21_45 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos45")
    '                        C21_46 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos46")
    '                        C21_47 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos47")
    '                        C21_48 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos48")
    '                        C21_49 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos49")
    '                        C21_50 = dt1.Rows.Item(y).Item("C21_WeitereZustandsverschluesselungen_Pos50")
    '                        Dim C21_All As String = C21_1 & C21_2 & C21_3 & C21_4 & C21_5 & C21_6 & C21_7 & C21_8 & C21_9 & C21_10 & C21_11 & C21_12 & C21_13 & C21_14 & C21_15 & C21_16 & C21_17 & C21_18 & C21_19 & C21_20 & C21_21 & C21_22 & C21_23 & C21_24 & C21_25 & C21_26 & C21_27 & C21_28 & C21_29 & C21_30 & C21_31 & C21_32 & C21_33 & C21_34 & C21_35 & C21_36 & C21_37 & C21_38 & C21_39 & C21_40 & C21_41 & C21_42 & C21_43 & C21_44 & C21_45 & C21_46 & C21_47 & C21_48 & C21_49 & C21_50

    '                        If IsDBNull(dt1.Rows.Item(y).Item("C22_KennzeichenEWR_Niederlassung")) = False Then
    '                            C22 = dt1.Rows.Item(y).Item("C22_KennzeichenEWR_Niederlassung")
    '                        Else
    '                            C22 = ""
    '                        End If
    '                        '+++++++
    '                        If IsDBNull(dt1.Rows.Item(y).Item("C23_KennzeichenNichtEWR_Niederlassung")) = False Then
    '                            C23 = dt1.Rows.Item(y).Item("C23_KennzeichenNichtEWR_Niederlassung")
    '                        Else
    '                            C23 = ""
    '                        End If
    '                        '++++++++

    '                        C_SATZ = C1 & C2A & C2B & C3 & C4 & C5 & C6s & C7 & C8 & C9.ToString("#0.00") & "*" & C10.ToString("#0.00000") & "*" & C11.ToString("#0.00") & "*" & C12s & "*" & C13s & C14s & C15 & C16 & C17s & C18s & C19s & C20_All & "*" & C21_All & "*" & C22 & "*" & C23
    '                        System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, C_SATZ & vbCrLf)

    '                    Next

    '                    Dim D_SATZ As String = Nothing
    '                    D1 = dt.Rows.Item(i).Item("D1_Satzidentifikator") & "*"
    '                    D2 = dt.Rows.Item(i).Item("D2_Ordnungskennzeichen") & "*"
    '                    D3 = dt.Rows.Item(i).Item("D3_GesamtsaldoEinlagen")
    '                    D4 = dt.Rows.Item(i).Item("D4_GesamtsaldoGesetzlicheAusschluesse")
    '                    D5 = dt.Rows.Item(i).Item("D5_GesamtsaldoGesetzlichErstattungsfaehigerEinlagen")
    '                    D6 = dt.Rows.Item(i).Item("D6_GesamtsaldoGesetzlichGedeckterEinlagen_OBERGRENZE")
    '                    D7 = dt.Rows.Item(i).Item("D7_GesamtsaldoGesetzlichGedeckterEinlagen_UNTERGRENZE")
    '                    D8 = dt.Rows.Item(i).Item("D8_GesamtsaldoGesetzlichGedeckterEinlagenKG_OBERGRENZE")
    '                    D9 = dt.Rows.Item(i).Item("D9_GesamtsaldoGesetzlichGedeckterEinlagenKG_UNTERGRENZE")
    '                    D10 = dt.Rows.Item(i).Item("D10_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_OBERGRENZE")
    '                    D11 = dt.Rows.Item(i).Item("D11_GesamtsaldoGesetzlichGedeckterEinlagenEU_Herkunftsstaat_UNTERGRENZE")
    '                    D12 = dt.Rows.Item(i).Item("D12_GesamtsaldoZusatzabsicherung")
    '                    D13 = dt.Rows.Item(i).Item("D13_GesamtsaldoZusatzabsicherungAnteil_ALTFALLREGELUNG")
    '                    D14 = dt.Rows.Item(i).Item("D14_GesamtsaldoForderungenAnKunden")
    '                    D15 = dt.Rows.Item(i).Item("D15_GesamtsaldoNichtEWR_Niederlassungen")

    '                    D_SATZ = D1 & D2 & D3.ToString("#0.00") & "*" & D4.ToString("#0.00") & "*" & D5.ToString("#0.00") & "*" & D6.ToString("#0.00") & "*" & D7.ToString("#0.00") & "*" & D8.ToString("#0.00") & "*" & D9.ToString("#0.00") & "*" & D10.ToString("#0.00") & "*" & D11.ToString("#0.00") & "*" & D12.ToString("#0.00") & "*" & D13.ToString("#0.00") & "*" & D14.ToString("#0.00") & "*" & D15.ToString("#0.00") & "*"
    '                    System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, D_SATZ & vbCrLf)
    '                Next


    '                'E-SATZ
    '                System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, E_SATZ)


    '                CloseSqlConnections()

    '                SplashScreenManager.CloseForm(False)

    '                If XtraMessageBox.Show("Folgende ESF Datei wurde generiert: " & EAEGDATEI & vbNewLine _
    '                          & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
    '                   & EAEG_FILE_DIR & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "EAEG Datei ERWEITERT erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
    '                    System.Diagnostics.Process.Start(EAEG_FILE_DIR)
    '                End If

    '            Catch ex As System.Exception
    '                SplashScreenManager.CloseForm(False)
    '                CloseSqlConnections()
    '                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                Exit Sub
    '            End Try
    '        Else
    '            Exit Sub
    '        End If
    '    End Sub
    '#End Region

    '#Region "EAEG_MELDEDATEI_ERSTELLUNG_ERWEITERT"

    '    Private Sub EAEG_Meldedatei_Erstellung_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Meldedatei_Erstellung_BarButtonItem.ItemClick

    '        Try

    '            With dxSLE_Meldeinhalt_Erweitert
    '                .Height = 26
    '                .Width = 136
    '                .Location = New System.Drawing.Point(143, 37)
    '                .Properties.DataSource = dtMeldeInhalt
    '                .Properties.TextEditStyle = TextEditStyles.DisableTextEditor
    '                .Properties.DisplayMember = "Meldeinhalt"
    '                .Properties.ValueMember = "Meldeinhalt"
    '                .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '                .Properties.NullText = Nothing
    '            End With

    '            Dim dxOK_NewMeldedatei_Erweitert As New DevExpress.XtraEditors.SimpleButton
    '            With dxOK_NewMeldedatei_Erweitert
    '                .Text = "EAEG Meldedatei erstellung (ERWEITERT Version 4.1)"
    '                .Height = 23
    '                .Width = 285
    '                .ImageList = EAEG_NewStichtagMeldeErweitert.ImageCollection1
    '                .ImageIndex = 9
    '                .Location = New System.Drawing.Point(12, 98)
    '            End With

    '            EAEG_NewStichtagMeldeErweitert.Controls.Add(dxOK_NewMeldedatei_Erweitert)
    '            EAEG_NewStichtagMeldeErweitert.Controls.Add(dxSLE_Meldeinhalt_Erweitert)
    '            EAEG_NewStichtagMeldeErweitert.StichtagNeu_btn.Visible = False
    '            EAEG_NewStichtagMeldeErweitert.Stichtag_Comboedit.Visible = False
    '            EAEG_NewStichtagMeldeErweitert.LabelControl4.Text = "Meldeinhalt - Bitte um Auswahl"



    '            AddHandler dxOK_NewMeldedatei_Erweitert.Click, AddressOf dxOK_NewMeldedatei_Erweitert_click

    '            EAEG_NewStichtagMeldeErweitert.Text = "ERSTELLUNG DER EAEG MELDEDATEI (ERWEITERT Version 4.1)"
    '            EAEG_NewStichtagMeldeErweitert.ShowDialog()


    '        Catch ex As System.Exception
    '            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

    '        End Try




    '    End Sub

    '    Private Sub dxOK_NewMeldedatei_Erweitert_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If dxSLE_Meldeinhalt_Erweitert.Text <> "" Then
    '            Dim result As Integer = XtraMessageBox.Show("Soll die EAEG Meldedatei (ERWEITERT) für den Stichtag: " & Me.EAEG_Stichtag_DateEdit.Text & " erstellt werden?" & vbNewLine & vbNewLine & "Vorhandene Datei mit den selben Namen wird dabei gelöscht!", "EAEG Meldedatei erstellung ERWEITERT (Version 2.1)", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '            rd = Me.EAEG_Stichtag_DateEdit.Text
    '            rdsql = rd.ToString("yyyyMMdd")

    '            If result = DialogResult.Cancel Or result = DialogResult.No Then
    '                Exit Sub

    '            ElseIf result = DialogResult.Yes Then
    '                EAEG_NewStichtagMeldeErweitert.Close()
    '                Try
    '                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '                    SplashScreenManager.Default.SetWaitFormCaption("Datendefinition M Satz")

    '                    'Datendefinition M Satz
    '                    Dim EAEG_FILE_DIR As String = Nothing
    '                    Dim EAEGDATEI As String = Nothing
    '                    Dim EAEG_Stichtag As Date
    '                    Dim EAEG_DateiName As String = Nothing
    '                    Dim EAEG_Meldestichtag As String = Nothing
    '                    Dim M_SATZ As String = Nothing
    '                    Dim A2 As String = Nothing
    '                    Dim E1 As String = Nothing
    '                    Dim E2 As String = Nothing
    '                    Dim E3 As Double = 0
    '                    Dim E4 As Double = 0
    '                    Dim E5 As Double = 0
    '                    Dim E6 As Double = 0
    '                    Dim E7 As Double = 0
    '                    Dim E8 As Double = 0
    '                    Dim E9 As Double = 0
    '                    Dim E10 As Double = 0
    '                    Dim E11 As Double = 0
    '                    Dim E12 As Double = 0
    '                    Dim E13 As Double = 0
    '                    Dim E14 As Double = 0
    '                    Dim E15 As Double = 0
    '                    '
    '                    Dim M017 As Double = 0
    '                    Dim M018 As Double = 0
    '                    Dim M019 As Double = 0
    '                    Dim M020 As Double = 0
    '                    Dim M021 As Double = 0
    '                    Dim M022 As Double = 0
    '                    Dim M023 As Double = 0
    '                    Dim M024 As Double = 0
    '                    Dim M025 As Double = 0
    '                    Dim M026 As Double = 0
    '                    Dim M027 As Double = 0
    '                    Dim M028 As Double = 0
    '                    Dim M029 As Double = 0
    '                    Dim M030 As Double = 0
    '                    Dim M031 As Double = 0
    '                    Dim M032 As Double = 0
    '                    Dim M033 As Double = 0
    '                    Dim M034 As Double = 0
    '                    Dim M035 As Double = 0
    '                    Dim M036 As Double = 0
    '                    Dim M037 As Double = 0
    '                    Dim M038 As Double = 0
    '                    Dim M039 As Double = 0
    '                    Dim M040 As Double = 0
    '                    Dim M041 As Double = 0
    '                    Dim M042 As Double = 0
    '                    Dim M043 As Double = 0
    '                    Dim M044 As Double = 0
    '                    Dim M045 As Double = 0
    '                    Dim M046 As Double = 0
    '                    Dim M047 As Double = 0
    '                    Dim M048 As Double = 0
    '                    Dim M049 As Double = 0
    '                    Dim M050 As Double = 0
    '                    Dim M051 As Double = 0
    '                    Dim M052 As Double = 0
    '                    Dim M053 As Double = 0
    '                    Dim M054 As Double = 0
    '                    Dim M055 As Double = 0
    '                    Dim M056 As Double = 0
    '                    Dim M057 As Double = 0
    '                    Dim M058 As Double = 0
    '                    Dim M059 As Double = 0
    '                    Dim M060 As Double = 0
    '                    Dim M061 As Double = 0
    '                    Dim M062 As Double = 0
    '                    Dim M063 As Double = 0
    '                    Dim M064 As Double = 0
    '                    Dim M065 As Double = 0
    '                    Dim M066 As Double = 0
    '                    '
    '                    Dim M067 As Double = 0
    '                    Dim M068 As Double = 0
    '                    Dim M069 As Double = 0
    '                    Dim M070 As Double = 0
    '                    Dim M071 As Double = 0
    '                    Dim M072 As Double = 0
    '                    Dim M073 As Double = 0
    '                    Dim M074 As Double = 0
    '                    Dim M075 As Double = 0
    '                    Dim M076 As Double = 0
    '                    Dim M077 As Double = 0
    '                    Dim M078 As Double = 0
    '                    Dim M079 As Double = 0
    '                    Dim M080 As Double = 0
    '                    Dim M081 As Double = 0
    '                    Dim M082 As Double = 0
    '                    Dim M083 As Double = 0
    '                    Dim M084 As Double = 0
    '                    Dim M085 As Double = 0
    '                    Dim M086 As Double = 0
    '                    Dim M087 As Double = 0
    '                    Dim M088 As Double = 0
    '                    Dim M089 As Double = 0
    '                    Dim M090 As Double = 0
    '                    Dim M091 As Double = 0
    '                    Dim M092 As Double = 0
    '                    Dim M093 As Double = 0
    '                    Dim M094 As Double = 0
    '                    Dim M095 As Double = 0
    '                    Dim M096 As Double = 0
    '                    Dim M097 As Double = 0
    '                    Dim M098 As Double = 0
    '                    Dim M099 As Double = 0
    '                    Dim M100 As Double = 0
    '                    Dim M101 As Double = 0
    '                    Dim M102 As Double = 0
    '                    Dim M103 As Double = 0
    '                    Dim M104 As Double = 0
    '                    Dim M105 As Double = 0
    '                    Dim M106 As Double = 0
    '                    Dim M107 As Double = 0
    '                    Dim M108 As Double = 0
    '                    Dim M109 As Double = 0
    '                    Dim M110 As Double = 0
    '                    Dim M111 As Double = 0
    '                    Dim M112 As Double = 0
    '                    Dim M113 As Double = 0
    '                    Dim M114 As Double = 0
    '                    Dim M115 As Double = 0
    '                    Dim M116 As Double = 0
    '                    '
    '                    Dim M117 As Double = 0
    '                    Dim M118 As Double = 0
    '                    Dim M119 As Double = 0
    '                    Dim M120 As Double = 0
    '                    Dim M121 As Double = 0
    '                    Dim M122 As Double = 0
    '                    Dim M123 As Double = 0
    '                    Dim M124 As Double = 0
    '                    Dim M125 As Double = 0
    '                    Dim M126 As Double = 0
    '                    Dim M127 As Double = 0
    '                    Dim M128 As Double = 0
    '                    Dim M129 As Double = 0
    '                    Dim M130 As Double = 0
    '                    Dim M131 As Double = 0
    '                    Dim M132 As Double = 0
    '                    Dim M133 As Double = 0
    '                    Dim M134 As Double = 0
    '                    Dim M135 As Double = 0
    '                    Dim M136 As Double = 0
    '                    Dim M137 As Double = 0
    '                    Dim M138 As Double = 0
    '                    Dim M139 As Double = 0
    '                    Dim M140 As Double = 0
    '                    Dim M141 As Double = 0
    '                    Dim M142 As Double = 0
    '                    Dim M143 As Double = 0
    '                    Dim M144 As Double = 0
    '                    Dim M145 As Double = 0
    '                    Dim M146 As Double = 0


    '                    OpenSqlConnections()


    '                    SplashScreenManager.Default.SetWaitFormCaption("Lade EAEG Dateiverzeichnis")
    '                    'Get EAEG File directory
    '                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EAEG_File_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EAEG_CREATION_PATH'"
    '                    EAEG_FILE_DIR = cmd.ExecuteScalar

    '                    'A und E SATZ
    '                    SplashScreenManager.Default.SetWaitFormCaption("Lade Daten für M Satz")
    '                    QueryText = "SELECT  [ID],[EAEG_Stichtag],[A1_Satzidentifikator],[A2_Institut],[A3_ZugehoerigkeitZuEntsaedigungseinrichtungen],[A4_GesetzlicheEntschaedigungsobergrenzeEAEG],[A5_GesetzlicheEntschaedigungsobergrenzeEU_Herkunftsland],[A6_SicherungsgrenzeBeiZusatzsicherung],[A7_SicherungsgrenzeBeiZusatzsicherungALTFALL_REGELUNG],[E1_Satzidentifikator],[E2_Institut],[E3_GesamteinreichersaldoEinlagen],[E4_GesamteinreichersaldoAusschluesseEinSiG],[E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG],[E6_GesamteinreichersaldoGedekterEinlagenEinSiG],[E7_GesamteinreichersaldoKappungEinSiG],[E8_GesamteinreichersaldoEWR_Niederlassungen],[E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat],[E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut],[E11_GesamteinreichersaldoAusschlueseNurStatut],[E12_GesamteinreichersaldoZusatzsicherung],[E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG],[E14_GesamteinreichersaldoForderungenAnKunden],[E15_GesamteinreichersaldoNichtEWR_Niederlassungen] FROM [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    da = New SqlDataAdapter(QueryText.Trim(), conn)
    '                    dt = New DataTable()
    '                    da.Fill(dt)
    '                    For i = 0 To dt.Rows.Count - 1
    '                        EAEG_Stichtag = dt.Rows.Item(0).Item("EAEG_Stichtag")
    '                        EAEG_DateiName = EAEG_Stichtag.ToString("yyMMdd")
    '                        EAEG_Meldestichtag = EAEG_Stichtag.ToString("yyMMdd")

    '                        E1 = "M"
    '                        A2 = dt.Rows.Item(0).Item("A2_Institut")
    '                        E2 = dt.Rows.Item(0).Item("E2_Institut")
    '                        E3 = dt.Rows.Item(0).Item("E3_GesamteinreichersaldoEinlagen")
    '                        E4 = dt.Rows.Item(0).Item("E4_GesamteinreichersaldoAusschluesseEinSiG")
    '                        E5 = dt.Rows.Item(0).Item("E5_GesamteinreichersaldoEntschaedigungsFaehigerEinlagenEinSiG")
    '                        E6 = dt.Rows.Item(0).Item("E6_GesamteinreichersaldoGedekterEinlagenEinSiG")
    '                        E7 = dt.Rows.Item(0).Item("E7_GesamteinreichersaldoKappungEinSiG")
    '                        E8 = dt.Rows.Item(0).Item("E8_GesamteinreichersaldoEWR_Niederlassungen")
    '                        E9 = dt.Rows.Item(0).Item("E9_GesamteinreichersaldoGedekterEinlagenEU_Herkunftsstaat")
    '                        E10 = dt.Rows.Item(0).Item("E10_GesamteinreichersaldoAusschlueseNachStatutEinSiGundNurStatut")
    '                        E11 = dt.Rows.Item(0).Item("E11_GesamteinreichersaldoAusschlueseNurStatut")
    '                        E12 = dt.Rows.Item(0).Item("E12_GesamteinreichersaldoZusatzsicherung")
    '                        E13 = dt.Rows.Item(0).Item("E13_GesamteinreichersaldoZusatzabsicherungAnteil_ALTFALLREGELUNG")
    '                        E14 = dt.Rows.Item(0).Item("E14_GesamteinreichersaldoForderungenAnKunden")
    '                        E15 = dt.Rows.Item(0).Item("E15_GesamteinreichersaldoNichtEWR_Niederlassungen")
    '                    Next

    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos1]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M017 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos2]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M018 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos3]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M019 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos4]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M020 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos5]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M021 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos6]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M022 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos7]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M023 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos8]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M024 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos9]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M025 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos10]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M026 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos11]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M027 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos12]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M028 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos13]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M029 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos14]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M030 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos15]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M031 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos16]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M032 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos17]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M033 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos18]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M034 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos19]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M035 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos20]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M036 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos21]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M037 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos22]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M038 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos23]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M039 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos24]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M040 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos25]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M041 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos26]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M042 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos27]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M043 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos28]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M044 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos29]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M045 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos30]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M046 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos31]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M047 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos32]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M048 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos33]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M049 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos34]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M050 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos35]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M051 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos36]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M052 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos37]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M053 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos38]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M054 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos39]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M055 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos40]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M056 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos41]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M057 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos42]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M058 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos43]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M059 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos44]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M060 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos45]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M061 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos46]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M062 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos47]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M063 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos48]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M064 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos49]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M065 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [B14_Ausschlusskennzeichen_Pos50]='Y' then [D3_GesamtsaldoEinlagen] else 0 end) from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M066 = cmd.ExecuteScalar
    '                    '
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos1]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M067 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos2]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M068 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos3]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M069 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos4]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M070 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos5]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M071 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos6]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M072 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos7]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M073 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos8]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M074 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos9]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M075 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos10]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M076 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos11]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M077 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos12]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M078 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos13]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M079 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos14]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M080 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos15]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M081 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos16]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M082 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos17]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M083 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos18]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M084 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos19]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M085 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos20]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M086 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos21]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M087 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos22]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M088 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos23]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M089 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos24]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M090 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos25]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M091 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos26]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M092 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos27]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M093 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos28]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M094 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos29]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M095 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos30]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M096 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos31]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M097 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos32]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M098 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos33]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M099 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos34]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M100 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos35]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M101 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos36]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M102 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos37]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M103 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos38]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M104 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos39]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M105 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos40]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M106 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos41]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M107 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos42]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M108 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos43]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M109 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos44]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M110 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos45]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M111 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos46]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M112 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos47]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M113 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos48]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M114 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos49]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M115 = cmd.ExecuteScalar
    '                    cmd.CommandText = "Select Sum(Case when [C20_Ausschlusskennzeichen_Pos50]='Y' then [C19_KontosaldoInEuro] else 0 end) from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                    M116 = cmd.ExecuteScalar


    '                    M_SATZ = E1 & "*" & A2 & "*" & EAEG_Meldestichtag & "*" & E3.ToString("#0.00") & "*" & E4.ToString("#0.00") & "*" & E5.ToString("#0.00") & "*" & E6.ToString("#0.00") & "*" & E7.ToString("#0.00") & "*" & E8.ToString("#0.00") & "*" & E9.ToString("#0.00") & "*" & E10.ToString("#0.00") & "*" & E11.ToString("#0.00") & "*" & E12.ToString("#0.00") & "*" & E13.ToString("#0.00") & "*" & E14.ToString("#0.00") & "*" & E15.ToString("#0.00") _
    '                        & "*" & M017.ToString("#0.00") & "*" & M018.ToString("#0.00") & "*" & M019.ToString("#0.00") & "*" & M020.ToString("#0.00") & "*" & M021.ToString("#0.00") & "*" & M022.ToString("#0.00") & "*" & M023.ToString("#0.00") & "*" & M024.ToString("#0.00") & "*" & M025.ToString("#0.00") & "*" & M026.ToString("#0.00") & "*" & M027.ToString("#0.00") & "*" & M028.ToString("#0.00") & "*" & M029.ToString("#0.00") & "*" & M030.ToString("#0.00") & "*" & M031.ToString("#0.00") & "*" & M032.ToString("#0.00") & "*" & M033.ToString("#0.00") & "*" & M034.ToString("#0.00") & "*" & M035.ToString("#0.00") & "*" & M036.ToString("#0.00") & "*" & M037.ToString("#0.00") & "*" & M038.ToString("#0.00") & "*" & M039.ToString("#0.00") & "*" & M040.ToString("#0.00") & "*" & M041.ToString("#0.00") & "*" & M042.ToString("#0.00") & "*" & M043.ToString("#0.00") & "*" & M044.ToString("#0.00") & "*" & M045.ToString("#0.00") & "*" & M046.ToString("#0.00") & "*" & M047.ToString("#0.00") & "*" & M048.ToString("#0.00") & "*" & M049.ToString("#0.00") & "*" & M050.ToString("#0.00") & "*" & M051.ToString("#0.00") & "*" & M052.ToString("#0.00") & "*" & M053.ToString("#0.00") & "*" & M054.ToString("#0.00") & "*" & M055.ToString("#0.00") & "*" & M056.ToString("#0.00") & "*" & M057.ToString("#0.00") & "*" & M058.ToString("#0.00") & "*" & M059.ToString("#0.00") & "*" & M060.ToString("#0.00") & "*" & M061.ToString("#0.00") & "*" & M062.ToString("#0.00") & "*" & M063.ToString("#0.00") & "*" & M064.ToString("#0.00") & "*" & M065.ToString("#0.00") & "*" & M066.ToString("#0.00") _
    '                        & "*" & M067.ToString("#0.00") & "*" & M068.ToString("#0.00") & "*" & M069.ToString("#0.00") & "*" & M070.ToString("#0.00") & "*" & M071.ToString("#0.00") & "*" & M072.ToString("#0.00") & "*" & M073.ToString("#0.00") & "*" & M074.ToString("#0.00") & "*" & M075.ToString("#0.00") & "*" & M076.ToString("#0.00") & "*" & M077.ToString("#0.00") & "*" & M078.ToString("#0.00") & "*" & M079.ToString("#0.00") & "*" & M080.ToString("#0.00") & "*" & M081.ToString("#0.00") & "*" & M082.ToString("#0.00") & "*" & M083.ToString("#0.00") & "*" & M084.ToString("#0.00") & "*" & M085.ToString("#0.00") & "*" & M086.ToString("#0.00") & "*" & M087.ToString("#0.00") & "*" & M088.ToString("#0.00") & "*" & M089.ToString("#0.00") & "*" & M090.ToString("#0.00") & "*" & M091.ToString("#0.00") & "*" & M092.ToString("#0.00") & "*" & M093.ToString("#0.00") & "*" & M094.ToString("#0.00") & "*" & M095.ToString("#0.00") & "*" & M096.ToString("#0.00") & "*" & M097.ToString("#0.00") & "*" & M098.ToString("#0.00") & "*" & M099.ToString("#0.00") & "*" & M100.ToString("#0.00") & "*" & M101.ToString("#0.00") & "*" & M102.ToString("#0.00") & "*" & M103.ToString("#0.00") & "*" & M104.ToString("#0.00") & "*" & M105.ToString("#0.00") & "*" & M106.ToString("#0.00") & "*" & M107.ToString("#0.00") & "*" & M108.ToString("#0.00") & "*" & M109.ToString("#0.00") & "*" & M110.ToString("#0.00") & "*" & M111.ToString("#0.00") & "*" & M112.ToString("#0.00") & "*" & M113.ToString("#0.00") & "*" & M114.ToString("#0.00") & "*" & M115.ToString("#0.00") & "*" & M116.ToString("#0.00") _
    '                        & "*" & M117.ToString("#0.00") & "*" & M118.ToString("#0.00") & "*" & M119.ToString("#0.00") & "*" & M120.ToString("#0.00") & "*" & M121.ToString("#0.00") & "*" & M122.ToString("#0.00") & "*" & M123.ToString("#0.00") & "*" & M124.ToString("#0.00") & "*" & M125.ToString("#0.00") & "*" & M126.ToString("#0.00") & "*" & M127.ToString("#0.00") & "*" & M128.ToString("#0.00") & "*" & M129.ToString("#0.00") & "*" & M130.ToString("#0.00") & "*" & M131.ToString("#0.00") & "*" & M132.ToString("#0.00") & "*" & M133.ToString("#0.00") & "*" & M134.ToString("#0.00") & "*" & M135.ToString("#0.00") & "*" & M136.ToString("#0.00") & "*" & M137.ToString("#0.00") & "*" & M138.ToString("#0.00") & "*" & M139.ToString("#0.00") & "*" & M140.ToString("#0.00") & "*" & M141.ToString("#0.00") & "*" & M142.ToString("#0.00") & "*" & M143.ToString("#0.00") & "*" & M144.ToString("#0.00") & "*" & M145.ToString("#0.00") & "*" & M146.ToString("#0.00")

    '                    'PRODUKTION
    '                    If dxSLE_Meldeinhalt_Erweitert.Text = "Produktion" Then

    '                        EAEGDATEI = "P0000000" & A2 & EAEG_DateiName & ".csv"

    '                        If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
    '                            File.Delete(EAEG_FILE_DIR & EAEGDATEI)
    '                        End If

    '                        System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, M_SATZ & vbCrLf)

    '                        CloseSqlConnections()


    '                        SplashScreenManager.CloseForm(False)

    '                        If XtraMessageBox.Show("Folgende csv Datei wurde generiert: " & EAEGDATEI & vbNewLine _
    '                                  & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
    '                           & EAEG_FILE_DIR & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "EAEG Meldedatei ERWEITERT (PRODUKTION) erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
    '                            System.Diagnostics.Process.Start(EAEG_FILE_DIR)
    '                        End If

    '                    ElseIf dxSLE_Meldeinhalt_Erweitert.Text = "Korrektur" Then
    '                        'KORREKTUR
    '                        EAEGDATEI = "K0000000" & A2 & EAEG_DateiName & ".csv"

    '                        If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
    '                            File.Delete(EAEG_FILE_DIR & EAEGDATEI)
    '                        End If

    '                        System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, M_SATZ & vbCrLf)

    '                        CloseSqlConnections()


    '                        SplashScreenManager.CloseForm(False)

    '                        If XtraMessageBox.Show("Folgende csv Datei wurde generiert: " & EAEGDATEI & vbNewLine _
    '                                  & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
    '                           & EAEG_FILE_DIR & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "EAEG Meldedatei ERWEITERT (KORREKTUR) erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
    '                            System.Diagnostics.Process.Start(EAEG_FILE_DIR)
    '                        End If

    '                    ElseIf dxSLE_Meldeinhalt_Erweitert.Text = "Test" Then
    '                        'TEST
    '                        EAEGDATEI = "T0000000" & A2 & EAEG_DateiName & ".csv"

    '                        If File.Exists(EAEG_FILE_DIR & EAEGDATEI) = True Then
    '                            File.Delete(EAEG_FILE_DIR & EAEGDATEI)
    '                        End If

    '                        System.IO.File.AppendAllText(EAEG_FILE_DIR & EAEGDATEI, M_SATZ & vbCrLf)

    '                        CloseSqlConnections()

    '                        SplashScreenManager.CloseForm(False)

    '                        If XtraMessageBox.Show("Folgende csv Datei wurde generiert: " & EAEGDATEI & vbNewLine _
    '                                  & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
    '                           & EAEG_FILE_DIR & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "EAEG Meldedatei ERWEITERT (TEST) erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
    '                            System.Diagnostics.Process.Start(EAEG_FILE_DIR)
    '                        End If

    '                    End If

    '                Catch ex As Exception
    '                    SplashScreenManager.CloseForm(False)
    '                    CloseSqlConnections()
    '                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                    Return
    '                End Try

    '            End If
    '        Else
    '            XtraMessageBox.Show("Bitte um Auswahl des Meldeinhaltes", "KEIN MELDEINHALT AUSGEWÄHLT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Return

    '        End If

    '    End Sub

    '#End Region


    'ERWEITERTE VERSION
    'Private Sub dxOK_NewStichtag_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    OpenSqlConnections()
    '    If IsDate(EAEG_NewStichtag.Stichtag_Comboedit.Text) = True Then
    '        Try
    '            rd = EAEG_NewStichtag.Stichtag_Comboedit.Text
    '            rdsql = rd.ToString("yyyyMMdd")

    '            If XtraMessageBox.Show("Soll der EAEG Stichtag: " & rd & " (ERWEITERTE VERSION) erstellt werden?", "EAEG Stichtag erstellung (ERWEITERTE VERSION)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

    '                cmd.CommandText = "Select Count([EAEG_Stichtag]) from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                Dim result As Double = cmd.ExecuteScalar
    '                If result <> 0 Then
    '                    If XtraMessageBox.Show("Der EAEG Stichtag: " & rd & " ist bereits vorhanden!" & vbNewLine & "Soll er nochmals erstellt werden?" & vbNewLine & vbNewLine & "Achtung! Die vorhandenen Daten werden gelöscht!", "EAEG Stichtag erstellung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

    '                        cmd.CommandText = "Delete from [EAEG_C_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "Delete from [EAEG_B_D_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()
    '                        cmd.CommandText = "Delete from [EAEG_A_E_Satz_Version4] where [EAEG_Stichtag]='" & rdsql & "'"
    '                        cmd.ExecuteNonQuery()

    '                    Else
    '                        Return
    '                    End If
    '                End If
    '                EAEG_NewStichtag.Close()
    '                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '                'SplashScreenManager.Default.SetWaitFormCaption("Starte EAEG Daten ertellung zum Stichtag: " & rd)
    '                BgwEAEG_Daten_Erstellung = New BackgroundWorker
    '                BgwEAEG_Daten_Erstellung.WorkerReportsProgress = True
    '                BgwEAEG_Daten_Erstellung.RunWorkerAsync()
    '            Else
    '                Exit Sub

    '            End If

    '        Catch ex As System.Exception
    '            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Exit Sub
    '        End Try
    '    End If
    '    CloseSqlConnections()
    'End Sub

    'BASIS VERSION

    'Private Sub EAEG_Laden_ERWEITERT_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EAEG_Laden_ERWEITERT_BarButtonItem.ItemClick
    '    If IsDate(Me.EAEG_Stichtag_DateEdit.Text) = True Then
    '        Try
    '            rd = Me.EAEG_Stichtag_DateEdit.Text
    '            rdsql = rd.ToString("yyyyMMdd")
    '            If XtraMessageBox.Show("Sollen die Daten der EAEG Datei für den Stichtag " & rd & " erneut geladen und berechnet werden ?" & vbNewLine & vbNewLine & "ACTHUNG!! Alle aktuellen Daten werden gelöscht!", "NEUERSTELLUNG DER EAEG DATEN (ERWEITERT)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

    '                BgwEAEG_Daten_Erstellung = New BackgroundWorker
    '                BgwEAEG_Daten_Erstellung.WorkerReportsProgress = True
    '                BgwEAEG_Daten_Erstellung.RunWorkerAsync()
    '            Else
    '                Me.EAEG_A_E_Satz_Version4BindingSource.CancelEdit()
    '                Exit Sub
    '            End If
    '        Catch ex As System.Exception
    '            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Me.EAEG_A_E_Satz_Version4BindingSource.CancelEdit()
    '            Exit Sub
    '        End Try
    '    End If

    'End Sub

End Class