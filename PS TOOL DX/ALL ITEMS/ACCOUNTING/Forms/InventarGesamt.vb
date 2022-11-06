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
Imports System.Globalization
Imports DevExpress.Spreadsheet
Public Class InventarGesamt

    Dim EXCELL As New Microsoft.Office.Interop.Excel.Application
    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    Dim xlWorksheet1 As Microsoft.Office.Interop.Excel.Worksheet


    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Double = 0

    Friend WithEvents BgwExcelImport As BackgroundWorker


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

    Private Sub INVENTAR_ALL_ITEMSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.INVENTAR_ALL_ITEMSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.InventarDataSet)

    End Sub

    Private Sub InventarGesamt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick
        AddHandler GridControl5.EmbeddedNavigator.ButtonClick, AddressOf GridControl5_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Inventar_Import_from_Excel_File_Directory' and [IdABTEILUNGSPARAMETER]='INVENTAR' and [PARAMETER STATUS]='Y' "
        'ExcelFileName = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '***********************************************************************

        'workbook = Me.SpreadsheetControl1.Document
        'Using stream As New FileStream(ExcelFileName, FileMode.Open)
        'workbook.LoadDocument(Stream, DocumentFormat.Xlsx)
        'End Using

        'Me.AfADate_Comboedit.Properties.Items.Clear()
        'Me.QueryText = "Select  CONVERT(VARCHAR(10),A.LastDate,104) as 'Datum'  from (SELECT DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,[CalendarDate])+1,0)) as LastDate from [Calendar] where [CalendarDate]<'21001231' GROUP BY [CalendarDate])A GROUP BY A.LastDate order by A.LastDate desc"
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)
        'For Each row As DataRow In dt.Rows
        'If dt.Rows.Count > 0 Then
        'Me.AfADate_Comboedit.Properties.Items.Add(Row("Datum"))
        'End If
        'Next
        Me.INVENTAR_BUCHUNGSKONTENTableAdapter.Fill(Me.InventarDataSet.INVENTAR_BUCHUNGSKONTEN)
        Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
        Me.INVENTAR_KONTEN_MWSTTableAdapter.Fill(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
        Me.INVENTAR_ALL_ITEMSTableAdapter.Fill(Me.InventarDataSet.INVENTAR_ALL_ITEMS)

        ActiveTabGroup = 1

    End Sub

    Private Sub CALCULATIONS_MWST()
        Dim NettoWert As Double = 0
        Dim MWST As Double = 0
        Dim MWST_Rueck As Double = 0
        Dim Anschaffungswert As Double = 0
        Dim Kontonummerwert As Double = 0
        Dim KontonummerMWSTwert As Double = 0
        Dim KontonummerVorsteuerWert As Double = 0
        Dim EURO_AMOUNT As Double = 0
        If Me.NettoWert_TextEdit.Text <> "" And Me.MWst_TextEdit.Text <> "" And Me.MWst_Ruck_TextEdit.Text <> "" Then
            NettoWert = Me.NettoWert_TextEdit.Text
            MWST = Me.MWst_TextEdit.Text
            MWST_Rueck = Me.MWst_Ruck_TextEdit.Text
            Dim OriginalCurrency As String = Me.NettoWertCur_TextEdit.Text
            Select Case OriginalCurrency
                Case Is = "DEM"
                    EURO_AMOUNT = Math.Round(NettoWert / 1.95583, 2)
                Case Is = "EUR"
                    EURO_AMOUNT = NettoWert
            End Select
            'Anschaffungswert = Math.Round(EURO_AMOUNT * MWST / 100 * (100 - MWST_Rueck) / 100 + EURO_AMOUNT, 2)
            Kontonummerwert = EURO_AMOUNT
            KontonummerMWSTwert = Math.Round(EURO_AMOUNT * MWST / 100, 2)
            KontonummerVorsteuerWert = Math.Round(EURO_AMOUNT * MWST / 100 * MWST_Rueck / -100, 2)
            Anschaffungswert = Kontonummerwert + KontonummerMWSTwert + KontonummerVorsteuerWert
            Me.AnschafWert_TextEdit.Text = Anschaffungswert
            Me.Kontonummer_Amount_TextEdit.Text = Kontonummerwert
            Me.KontonummerMWST_Amount_TextEdit.Text = KontonummerMWSTwert
            Me.KontonummerVorsteuer_Amount_TextEdit.Text = KontonummerVorsteuerWert
        End If
    End Sub

    Private Sub NEW_INVENTAR()
        Me.Inventar_BasicView.ClearColumnsFilter()
        Me.Print_Export_Gridview_btn.Focus()

        Me.LayoutControl1.Visible = False
        Me.GroupControl3.Text = "NEUES INVENTAR"
        Me.PrintInventarDetails_btn.Visible = False
        Me.INVENTAR_ALL_ITEMSBindingSource.EndEdit()
        Me.INVENTAR_ALL_ITEMSBindingSource.AddNew()
        Me.NettoWertCur_TextEdit.Text = "EUR"
        Me.AnschafungsDatum_DateEdit.Text = Today
        Me.Ausbuchungsdatum_DateEdit.Visible = False
        Dim d As Date = Me.AnschafungsDatum_DateEdit.Text
        Dim rdsql As String = d.ToString("yyyyMMdd")
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandTimeout = 500
        'Get MWST
        cmd.CommandText = "Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='MWST' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='MEHRWERTSTEUERSATZ'"
        Me.MWst_TextEdit.Text = cmd.ExecuteScalar
        'Get MWST Vorsteuer
        cmd.CommandText = "Select Distinct 'VS' = CASE WHEN EXISTS(Select [Vorsteuersatz] from [INVENTAR_VORSTEUER_SAETZE] where [Jahr]=DATEPART(Year,'" & rdsql & "')) then [Vorsteuersatz]else (SELECT [Vorsteuersatz] FROM [INVENTAR_VORSTEUER_SAETZE] Where [Jahr] IN (Select Max([Jahr]) from [INVENTAR_VORSTEUER_SAETZE])) end from [INVENTAR_VORSTEUER_SAETZE]"
        Me.MWst_Ruck_TextEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.InventarNr_TextEdit.Properties.ReadOnly = False
        Me.AnzahlCount_SpinEdit.Properties.ReadOnly = False
        Me.AnzahlCount_SpinEdit.Text = 1
        Me.AfA_Monate_SpinEdit.Properties.ReadOnly = False
        Me.InventarNr_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.InventarNr_TextEdit.Properties.Mask.EditMask = "[0-9]{1,10}[\.]{1}[0-9]{1,5}"
        Me.InventarNr_TextEdit.Properties.Mask.ShowPlaceHolders = False
        'Me.InventarNr_TextEdit.Properties.Mask.IgnoreMaskBlank = False

        Me.InventarNr_TextEdit.Focus()


    End Sub

    Private Sub CALCULATE_AFA_DETAILS()
        If IsDate(Me.AfADate_Comboedit.Text) = True Then
            Try
                Dim rd As Date = Me.AfADate_Comboedit.Text
                Dim rdsql As String = rd.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("AfA kalkulation für :" & rd)

                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandTimeout = 500
                'set to Zero
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [RestwertEUR]=0,[AfA_Monat_EUR]=0,[AfA_Jahr_EUR]=0,[AfA_Gesamt_EUR]=0,[AfA_Valid]='Y'"
                cmd.ExecuteNonQuery()
                'Update RESTBETRAG
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [RestwertEUR]=(Case when ((datediff(month,[Anschaffungsdatum],'" & rdsql & "') + 1) *([Anschaffungswert]/[Monate]))< [Anschaffungswert]then [Anschaffungswert]-((datediff(month,[Anschaffungsdatum],'" & rdsql & "') + 1) *([Anschaffungswert]/[Monate])) Else 0 end) where [Monate]>0"
                cmd.ExecuteNonQuery()
                'Update AfA_Monat
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [AfA_Monat_EUR]= (Case when Datepart(year,Dateadd(month,[Monate],[Anschaffungsdatum]))>Datepart(year,'" & rdsql & "')then ([Anschaffungswert]/[Monate]) Else 0 end) where [Monate]>0"
                cmd.ExecuteNonQuery()
                'set AfA Jahr
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [AfA_Jahr_EUR]=(Case when Datepart(year,Dateadd(month,[Monate],[Anschaffungsdatum]))=Datepart(year,'" & rdsql & "') then datediff(month,DATEADD(yy, DATEDIFF(yy,0,'" & rdsql & "'), 0),Dateadd(month,[Monate],[Anschaffungsdatum]))*([Anschaffungswert]/[Monate]) when Datepart(year,Dateadd(month,[Monate],[Anschaffungsdatum]))>Datepart(year,'" & rdsql & "') then (datediff(month,DATEADD(yy, DATEDIFF(yy,0,'" & rdsql & "'), 0),'" & rdsql & "') + 1) *([Anschaffungswert]/[Monate]) Else 0 end) where [Monate]>0"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [AfA_Jahr_EUR]=(datediff(month,[Anschaffungsdatum],'" & rdsql & "') + 1)*([Anschaffungswert]/[Monate]) where Datepart(year,[Anschaffungsdatum])=Datepart(year,'" & rdsql & "') and [Monate]>0"
                cmd.ExecuteNonQuery()
                'Update AfA Gesamt
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [AfA_Gesamt_EUR]=(Case when ((datediff(month,[Anschaffungsdatum],'" & rdsql & "') + 1) *([Anschaffungswert]/[Monate]))< [Anschaffungswert] then (datediff(month,[Anschaffungsdatum],'" & rdsql & "') + 1) *([Anschaffungswert]/[Monate]) Else [Anschaffungswert] end) where [Monate]>0"
                cmd.ExecuteNonQuery()
                'Update AfA_Valid
                'cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [AfA_Valid]='N' where Datepart(year,Dateadd(month,[Monate],[Anschaffungsdatum]))<Datepart(year,'" & rdsql & "')"
                'cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [RestwertEUR]=0 where [Anschaffungswert]=[AfA_Gesamt_EUR]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] set [AfA_Valid]='N' where [Ausbuchungsdatum] is not NULL"
                cmd.ExecuteNonQuery()
                'Update BUCHUNGSBELEG
                cmd.CommandText = "Update A Set A.[CR_Amount]=B.SumAfAMonat,A.[DT_Amount]=B.SumAfAMonat from [INVENTAR_BUCHUNGSKONTEN] A INNER JOIN (Select [Kontonummer],Sum([AfA_Monat_EUR]) as 'SumAfAMonat' from [INVENTAR_ALL_ITEMS] where  [AfA_Valid]='Y' GROUP BY [Kontonummer])B on A.[Kontonummer]=B.[Kontonummer]"
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()

                Me.GridControl4.DataSource = Me.AfA_DetailsBindingSource

                Me.AfA_DetailsTableAdapter.Fill(Me.InventarDataSet.AfA_Details)
                Me.INVENTAR_BUCHUNGSKONTENTableAdapter.Fill(Me.InventarDataSet.INVENTAR_BUCHUNGSKONTEN)

                Me.LayoutControlItem12.Visibility = LayoutVisibility.Always
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            XtraMessageBox.Show("Bitte tragen Sie ein Datum für die AfA Berechnung!", "FEHLENDES DATUM", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub


    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "AddNewInventar" Then
            NEW_INVENTAR()
        End If
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            e.Handled = True
            Try
                Me.INVENTAR_KONTEN_MWSTBindingSource.EndEdit()
                Me.INVENTAR_KONTEN_MWSTTableAdapter.Update(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
                Me.INVENTAR_KONTEN_MWSTTableAdapter.Fill(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Try
                Me.INVENTAR_KONTEN_MWSTBindingSource.CancelEdit()
                Me.InventarDataSet.RejectChanges()
                Me.INVENTAR_KONTEN_MWSTTableAdapter.Fill(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag.ToString = "Save" Then
            If MessageBox.Show("Sollen die Änderungen der Vorsteuersätze gespeichert werden?" & vbNewLine & vbNewLine & "ACHTUNG:Die Vorsteuersätze werden in der INVENTAR Tabelle übernommen" & vbNewLine & "ab Anschaffungsjahr:2015!" & vbNewLine & "Der Vorsteuerbetrag und der Anschafungswert werden danach neu Berechnet!", "ÄNDERUNG VORSTEUERSÄTZE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Übernahme der Änderungen in den Vorsteuersätzen")
                'e.Handled = True
                Try
                    Me.Print_Export_Gridview_btn.Focus()
                    Me.INVENTAR_VORSTEUER_SAETZEBindingSource.EndEdit()
                    Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Update(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
                    Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandTimeout = 500
                    cmd.CommandText = "UPDATE A SET A.[MWST_Rueck]=B.[Vorsteuersatz] 
                                  from [INVENTAR_ALL_ITEMS] A INNER JOIN [INVENTAR_VORSTEUER_SAETZE] B 
                                  ON DATEPART(Year,A.[Anschaffungsdatum])=B.[Jahr] 
                                  where DATEPART(Year,A.[Anschaffungsdatum])>=2015 
                                  and ([MWST_Rueck_IsZero] is NULL or [MWST_Rueck_IsZero]=0)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Update [INVENTAR_ALL_ITEMS] set [Kontonummer_Vorsteuer_Amount]=Round([Nettowert]*([MWST_Satz]/100)*([MWST_Rueck]/100)*(-1),2) 
                                   where DATEPART(Year,[Anschaffungsdatum])>=2015 and [MWST_Satz]<>0 and [MWST_Rueck]<>0"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Update [INVENTAR_ALL_ITEMS] 
                                   set [Anschaffungswert]=[KontonummerAmount]+[Kontonummer_MWST_Amount]+[Kontonummer_Vorsteuer_Amount] 
                                   where DATEPART(Year,[Anschaffungsdatum])>=2015"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Me.INVENTAR_ALL_ITEMSTableAdapter.Fill(Me.InventarDataSet.INVENTAR_ALL_ITEMS)
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            Else
                Me.INVENTAR_VORSTEUER_SAETZEBindingSource.CancelEdit()
                Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
            End If

        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Try
                Me.INVENTAR_VORSTEUER_SAETZEBindingSource.CancelEdit()
                Me.InventarDataSet.RejectChanges()
                Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub GridControl5_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            e.Handled = True
            Try
                Me.INVENTAR_BUCHUNGSKONTENBindingSource.EndEdit()
                Me.INVENTAR_BUCHUNGSKONTENTableAdapter.Update(Me.InventarDataSet.INVENTAR_BUCHUNGSKONTEN)
                Me.INVENTAR_BUCHUNGSKONTENTableAdapter.Fill(Me.InventarDataSet.INVENTAR_BUCHUNGSKONTEN)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Try
                Me.INVENTAR_BUCHUNGSKONTENBindingSource.CancelEdit()
                Me.InventarDataSet.RejectChanges()
                Me.INVENTAR_BUCHUNGSKONTENTableAdapter.Fill(Me.InventarDataSet.INVENTAR_BUCHUNGSKONTEN)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub NettoWert_TextEdit_Leave(sender As Object, e As EventArgs) Handles NettoWert_TextEdit.Leave
        CALCULATIONS_MWST()
    End Sub

    Private Sub MWst_TextEdit_Leave(sender As Object, e As EventArgs) Handles MWst_TextEdit.Leave
        CALCULATIONS_MWST()
    End Sub

    Private Sub MWst_Ruck_TextEdit_Leave(sender As Object, e As EventArgs) Handles MWst_Ruck_TextEdit.Leave
        CALCULATIONS_MWST()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click


        If Me.DxValidationProvider1.Validate() = True Then
            Try
                If Me.GroupControl3.Text = "NEUES INVENTAR" Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If

                    Dim s As String = LTrim(RTrim(Me.InventarNr_TextEdit.Text & "%"))

                    cmd.CommandText = "SELECT Count([Inventarnummer]) from [INVENTAR_ALL_ITEMS] where [Inventarnummer] like '" & s & "'"
                    Dim Result As Double = cmd.ExecuteScalar

                    If Result = 0 Then

                        Dim Anzahl_Inventar_Items As Integer = Me.AnzahlCount_SpinEdit.Text
                        If Anzahl_Inventar_Items = 1 Then
                            Me.Validate()
                            Me.INVENTAR_ALL_ITEMSBindingSource.EndEdit()
                            Me.TableAdapterManager.UpdateAll(Me.InventarDataSet)

                        ElseIf Anzahl_Inventar_Items > 1 Then
                            Dim ANZAHL As Double = Me.AnzahlCount_SpinEdit.Text
                            Dim NETTOWERT As Double = Me.NettoWert_TextEdit.Text
                            If XtraMessageBox.Show("Die Inventar Nr. " & Me.InventarNr_TextEdit.Text & " wird bis zu " & Anzahl_Inventar_Items & " mal eingefügt!" _
                                                & vbNewLine & "Die einzelenen Inventar Items werden zu einen Nettowert von je" & vbNewLine & "EUR " & FormatNumber(Math.Round(NETTOWERT / ANZAHL, 2), 2) & " eingefügt" _
                                                & vbNewLine & "Soll fortgefahren werden?", "EINFÜGEN INVENTAR NR. (ANZAHL > 1)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                                SplashScreenManager.Default.SetWaitFormCaption("Starte import der Inventar Items")
                                For i = 1 To Anzahl_Inventar_Items


                                    Dim ANSCHAFUNGSDATUM As Date = Me.AnschafungsDatum_DateEdit.EditValue
                                    Dim ANSCHAFUNGSWERT As Double = Me.AnschafWert_TextEdit.Text
                                    Dim MONATE As Double = Me.AfA_Monate_SpinEdit.Text
                                    Dim KONTONUMMER_AMOUNT As Double = Me.Kontonummer_Amount_TextEdit.Text
                                    Dim KONTONUMMER_MWST_AMOUNT As Double = Me.KontonummerMWST_Amount_TextEdit.Text
                                    Dim KONTONUMMER_VORSTEUER_AMOUNT As Double = Me.KontonummerVorsteuer_Amount_TextEdit.Text
                                    Dim MWST_SATZ As Double = Me.MWst_TextEdit.Text
                                    Dim MWST_RUECK As Double = Me.MWst_Ruck_TextEdit.Text
                                    Dim MWST_RUECK_BIT As Boolean = Me.NoUpdate_CheckEdit.CheckState

                                    cmd.CommandText = "INSERT INTO [INVENTAR_ALL_ITEMS]([Inventarnummer],[Seriennummer],[Bezeichnung],[Anzahl],[Anschaffungsdatum],[Nettowert],[Anschaffungswert],[CCY],[Monate],[Bemerkung],[Kontonummer],[KontonummerAmount],[Kostenstelle],[Kontonummer_MWST],[Kontonummer_MWST_Amount],[Kontonummer_Vorsteuer],[Kontonummer_Vorsteuer_Amount],[MWST_Satz],[MWST_Rueck],[MWST_Rueck_IsZero])VALUES(@Inventarnummer,@Seriennummer,@Bezeichnung,@Anzahl,@Anschaffungsdatum,@Nettowert,@Anschaffungswert,@CCY,@Monate,@Bemerkung,@Kontonummer,@KontonummerAmount,@Kostenstelle,@Kontonummer_MWST,@Kontonummer_MWST_Amount,@Kontonummer_Vorsteuer,@Kontonummer_Vorsteuer_Amount,@MWST_Satz,@MWST_Rueck,@MWST_Rueck_IsZero)"
                                    cmd.Parameters.Add("@Inventarnummer", SqlDbType.NVarChar).Value = Me.InventarNr_TextEdit.Text & "." & i
                                    cmd.Parameters.Add("@Seriennummer", SqlDbType.NVarChar).Value = Me.SerienNr_MemoEdit.Text
                                    cmd.Parameters.Add("@Bezeichnung", SqlDbType.NVarChar).Value = Me.Bezeichnung_MemoEdit.Text
                                    cmd.Parameters.Add("@Anzahl", SqlDbType.Float).Value = 1
                                    cmd.Parameters.Add("@Anschaffungsdatum", SqlDbType.DateTime).Value = ANSCHAFUNGSDATUM
                                    cmd.Parameters.Add("@Nettowert", SqlDbType.Float).Value = Math.Round(NETTOWERT / ANZAHL, 2)
                                    cmd.Parameters.Add("@Anschaffungswert", SqlDbType.Float).Value = Math.Round(ANSCHAFUNGSWERT / ANZAHL, 2)
                                    cmd.Parameters.Add("@CCY", SqlDbType.NVarChar).Value = Me.NettoWertCur_TextEdit.Text
                                    cmd.Parameters.Add("@Monate", SqlDbType.Float).Value = MONATE
                                    cmd.Parameters.Add("@Bemerkung", SqlDbType.NVarChar).Value = Me.Bemerkung_MemoEdit.Text
                                    cmd.Parameters.Add("@Kontonummer", SqlDbType.NVarChar).Value = Me.Kontonummer_LookUpEdit.Text
                                    cmd.Parameters.Add("@KontonummerAmount", SqlDbType.Float).Value = Math.Round(KONTONUMMER_AMOUNT / ANZAHL, 2)
                                    cmd.Parameters.Add("@Kostenstelle", SqlDbType.NVarChar).Value = Me.Kostenstelle_ComboboxEdit.Text
                                    cmd.Parameters.Add("@Kontonummer_MWST", SqlDbType.NVarChar).Value = Me.Kontonummer_MWSt_LookUpEdit.Text
                                    cmd.Parameters.Add("@Kontonummer_MWST_Amount", SqlDbType.Float).Value = Math.Round(KONTONUMMER_MWST_AMOUNT / ANZAHL, 2)
                                    cmd.Parameters.Add("@Kontonummer_Vorsteuer", SqlDbType.NVarChar).Value = Me.Kontonummer_Vorsteuer_LookUpEdit.Text
                                    cmd.Parameters.Add("@Kontonummer_Vorsteuer_Amount", SqlDbType.Float).Value = Math.Round(KONTONUMMER_VORSTEUER_AMOUNT / ANZAHL, 2)
                                    cmd.Parameters.Add("@MWST_Satz", SqlDbType.Float).Value = MWST_SATZ
                                    cmd.Parameters.Add("@MWST_Rueck", SqlDbType.Float).Value = MWST_RUECK
                                    cmd.Parameters.Add("@MWST_Rueck_IsZero", SqlDbType.Bit).Value = MWST_RUECK_BIT

                                    cmd.ExecuteNonQuery()
                                    cmd.Parameters.Clear()

                                Next i
                                SplashScreenManager.CloseForm(False)
                                If cmd.Connection.State = ConnectionState.Open Then
                                    cmd.Connection.Close()
                                End If
                            Else
                                Return
                            End If
                        End If
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                    Else

                        XtraMessageBox.Show("Es existiert bereits eine Inventarnummer die anfängt wie: " & Me.InventarNr_TextEdit.Text & " !!", "EINFÜGEN NEUER INVENTAR NR. NICHT MÖGLICH", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        cmd.Parameters.Clear()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Return

                    End If

                    Me.LayoutControl1.Visible = True
                    Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
                    Me.INVENTAR_KONTEN_MWSTTableAdapter.Fill(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
                    Me.INVENTAR_ALL_ITEMSTableAdapter.Fill(Me.InventarDataSet.INVENTAR_ALL_ITEMS)

                Else 'Wenn INVENTAR ÄNDERUNG
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If

                    Dim InventarNrText As String = Me.InventarNr_TextEdit.Text
                    Dim index1 As Integer = InventarNrText.LastIndexOf("."c)
                    Dim InventarNrTextALL As String = InventarNrText.Substring(0, index1 + 1)
                    'MsgBox(index1 & "  " & InventarNrText.Substring(index1) & "  " & InventarNrTextALL)

                    Dim s As String = LTrim(RTrim(InventarNrTextALL & "%"))
                    cmd.CommandText = "SELECT Count([Inventarnummer]) from [INVENTAR_ALL_ITEMS] where [Inventarnummer] like '" & s & "'"
                    Dim Result As Double = cmd.ExecuteScalar

                    Dim MsgResult As Integer = XtraMessageBox.Show("Sollen die Änderungen bei der InventarNr. " & InventarNrText & " für alle Inventar Items unter der Nr. " & InventarNrTextALL & "... übernohmen werden ?" & vbNewLine & "Insgesamt: " & Result & " items" & vbNewLine & vbNewLine & "YES = FÜR ALLE" & vbNewLine & "NO = NUR FÜR AKUTELLES INVENTAR" & vbNewLine & "CANCEL = KEINE ÄNDERUNG", "INVENTAR ITEM ÄNDERUNG", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                    If MsgResult = DialogResult.Yes Then

                        Dim NETTOWERT As Double = Me.NettoWert_TextEdit.Text
                        Dim ANSCHAFUNGSDATUM As Date = Me.AnschafungsDatum_DateEdit.EditValue
                        Dim ANSCHAFUNGSWERT As Double = Me.AnschafWert_TextEdit.Text
                        Dim MONATE As Double = Me.AfA_Monate_SpinEdit.Text
                        Dim KONTONUMMER_AMOUNT As Double = Me.Kontonummer_Amount_TextEdit.Text
                        Dim KONTONUMMER_MWST_AMOUNT As Double = Me.KontonummerMWST_Amount_TextEdit.Text
                        Dim KONTONUMMER_VORSTEUER_AMOUNT As Double = Me.KontonummerVorsteuer_Amount_TextEdit.Text
                        Dim MWST_SATZ As Double = Me.MWst_TextEdit.Text
                        Dim MWST_RUECK As Double = Me.MWst_Ruck_TextEdit.Text
                        Dim MWST_RUECK_BIT As Boolean = Me.NoUpdate_CheckEdit.CheckState

                        cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS] SET [Seriennummer]=@Seriennummer,[Bezeichnung]=@Bezeichnung,[Anschaffungsdatum]=@Anschaffungsdatum,[Nettowert]=@Nettowert,[Anschaffungswert]=@Anschaffungswert,[Monate]=@Monate,[Bemerkung]=@Bemerkung,[Kontonummer]=@Kontonummer,[KontonummerAmount]=@KontonummerAmount,[Kostenstelle]=@Kostenstelle,[Kontonummer_MWST]=@Kontonummer_MWST,[Kontonummer_MWST_Amount]=@Kontonummer_MWST_Amount,[Kontonummer_Vorsteuer]=@Kontonummer_Vorsteuer,[Kontonummer_Vorsteuer_Amount]=@Kontonummer_Vorsteuer_Amount,[MWST_Satz]=@MWST_Satz,[MWST_Rueck]=@MWST_Rueck,[MWST_Rueck_IsZero]=@MWST_Rueck_IsZero where [Inventarnummer] like '" & s & "'"

                        cmd.Parameters.Add("@Seriennummer", SqlDbType.NVarChar).Value = Me.SerienNr_MemoEdit.Text
                        cmd.Parameters.Add("@Bezeichnung", SqlDbType.NVarChar).Value = Me.Bezeichnung_MemoEdit.Text
                        cmd.Parameters.Add("@Anschaffungsdatum", SqlDbType.DateTime).Value = ANSCHAFUNGSDATUM
                        cmd.Parameters.Add("@Nettowert", SqlDbType.Float).Value = NETTOWERT
                        cmd.Parameters.Add("@Anschaffungswert", SqlDbType.Float).Value = ANSCHAFUNGSWERT
                        cmd.Parameters.Add("@Monate", SqlDbType.Float).Value = MONATE
                        cmd.Parameters.Add("@Bemerkung", SqlDbType.NVarChar).Value = Me.Bemerkung_MemoEdit.Text
                        cmd.Parameters.Add("@Kontonummer", SqlDbType.NVarChar).Value = Me.Kontonummer_LookUpEdit.Text
                        cmd.Parameters.Add("@KontonummerAmount", SqlDbType.Float).Value = KONTONUMMER_AMOUNT
                        cmd.Parameters.Add("@Kostenstelle", SqlDbType.NVarChar).Value = Me.Kostenstelle_ComboboxEdit.Text
                        cmd.Parameters.Add("@Kontonummer_MWST", SqlDbType.NVarChar).Value = Me.Kontonummer_MWSt_LookUpEdit.Text
                        cmd.Parameters.Add("@Kontonummer_MWST_Amount", SqlDbType.Float).Value = KONTONUMMER_MWST_AMOUNT
                        cmd.Parameters.Add("@Kontonummer_Vorsteuer", SqlDbType.NVarChar).Value = Me.Kontonummer_Vorsteuer_LookUpEdit.Text
                        cmd.Parameters.Add("@Kontonummer_Vorsteuer_Amount", SqlDbType.Float).Value = KONTONUMMER_VORSTEUER_AMOUNT
                        cmd.Parameters.Add("@MWST_Satz", SqlDbType.Float).Value = MWST_SATZ
                        cmd.Parameters.Add("@MWST_Rueck", SqlDbType.Float).Value = MWST_RUECK
                        cmd.Parameters.Add("@MWST_Rueck_IsZero", SqlDbType.Bit).Value = MWST_RUECK_BIT

                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()

                    ElseIf MsgResult = DialogResult.No Then
                        Me.Validate()
                        Me.INVENTAR_ALL_ITEMSBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.InventarDataSet)

                    ElseIf MsgResult = DialogResult.Cancel Then
                        Return
                    End If

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                    Me.LayoutControl1.Visible = True
                    Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
                    Me.INVENTAR_KONTEN_MWSTTableAdapter.Fill(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
                    Me.INVENTAR_ALL_ITEMSTableAdapter.Fill(Me.InventarDataSet.INVENTAR_ALL_ITEMS)
                End If

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                cmd.Parameters.Clear()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Return
            End Try
        Else
            XtraMessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.INVENTAR_ALL_ITEMSBindingSource.CancelEdit()
        Me.LayoutControl1.Visible = True
        Me.INVENTAR_VORSTEUER_SAETZETableAdapter.Fill(Me.InventarDataSet.INVENTAR_VORSTEUER_SAETZE)
        Me.INVENTAR_KONTEN_MWSTTableAdapter.Fill(Me.InventarDataSet.INVENTAR_KONTEN_MWST)
        Me.INVENTAR_ALL_ITEMSTableAdapter.Fill(Me.InventarDataSet.INVENTAR_ALL_ITEMS)
    End Sub

    Private Sub Inventar_BasicView_DoubleClick(sender As Object, e As EventArgs) Handles Inventar_BasicView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Me.LayoutControl1.Visible = False
            Me.InventarNr_TextEdit.Properties.ReadOnly = True
            Me.AfA_Monate_SpinEdit.Properties.ReadOnly = False
            Me.AnzahlCount_SpinEdit.Properties.ReadOnly = True
            Me.InventarNr_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.InventarNr_TextEdit.Focus()
            Me.GroupControl3.Text = "ÄNDERUNG INVENTAR NR. " & Me.InventarNr_TextEdit.Text
            Me.PrintInventarDetails_btn.Visible = True
            Me.Ausbuchungsdatum_DateEdit.Visible = True
        End If
    End Sub

    Private Sub KontenMWST_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles KontenMWST_BasicView.InvalidRowException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub KontenMWST_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles KontenMWST_BasicView.InvalidValueException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub KontenMWST_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles KontenMWST_BasicView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub KontenMWST_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles KontenMWST_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub KontenMWST_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles KontenMWST_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim KONTO As GridColumn = View.Columns("Konto")
        Dim KONTO_MWST As GridColumn = View.Columns("Konto_MWSt")
        Dim KONTO_VORSTEUER As GridColumn = View.Columns("Konto_Vorsteuer")
        Dim MWST_SATZ As GridColumn = View.Columns("MWSt_Satz")
        Dim VALID_FROM As GridColumn = View.Columns("valid_from")


        Dim Kontonummer As String = View.GetRowCellValue(e.RowHandle, colKonto).ToString
        Dim KontoMWST As String = View.GetRowCellValue(e.RowHandle, colKonto_MWSt).ToString
        Dim KontoVorsteuer As String = View.GetRowCellValue(e.RowHandle, colKonto_Vorsteuer).ToString
        Dim MWSTsatz As String = View.GetRowCellValue(e.RowHandle, colMWSt_Satz1).ToString
        Dim ValidFrom As String = View.GetRowCellValue(e.RowHandle, colvalid_from).ToString


        If Kontonummer = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KONTO, "Konto must not be empty")
            e.ErrorText = "Konto must not be empty"
        End If
        If KontoMWST = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KONTO_MWST, "Konto MWSt must not be empty")
            e.ErrorText = "Konto MWSt must not be empty"
        End If
        If KontoVorsteuer = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KONTO_VORSTEUER, "Konto Vorsteuer must not be empty")
            e.ErrorText = "Konto Vorsteuer must not be empty"
        End If
        If MWSTsatz = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(MWST_SATZ, "MWSt Satz must not be empty")
            e.ErrorText = "MWSt Satz must not be empty"
        End If
        If ValidFrom = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALID_FROM, "Valid Till must not be empty")
            e.ErrorText = "Valid Till must not be empty"
        End If

    End Sub

    Private Sub Vorsteuersaetze_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles Vorsteuersaetze_BasicView.InvalidRowException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Vorsteuersaetze_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles Vorsteuersaetze_BasicView.InvalidValueException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Vorsteuersaetze_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Vorsteuersaetze_BasicView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Vorsteuersaetze_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Vorsteuersaetze_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Vorsteuersaetze_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Vorsteuersaetze_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim JAHR_NR As GridColumn = View.Columns("Jahr")
        Dim VORSTEUER_SATZ As GridColumn = View.Columns("Vorsteuersatz")

        Dim Jahrnummer As String = View.GetRowCellValue(e.RowHandle, colJahr).ToString
        Dim Vorsteuersatz As String = View.GetRowCellValue(e.RowHandle, colVorsteuersatz).ToString

        If Jahrnummer = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(JAHR_NR, "Jahr must not be empty")
            e.ErrorText = "Jahr must not be empty"
        End If
        If Vorsteuersatz = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VORSTEUER_SATZ, "Vorsteuersatz must not be empty")
            e.ErrorText = "Vorsteuersatz must not be empty"
        End If
    End Sub

    Private Sub Inventar_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Inventar_BasicView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Inventar_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Inventar_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AfA_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AfA_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AfA_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AfA_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Inventar_Buchungskonten_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles Inventar_Buchungskonten_GridView.InvalidRowException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Inventar_Buchungskonten_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles Inventar_Buchungskonten_GridView.InvalidValueException
        'e.ExceptionMode = ExceptionMode.NoAction
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Inventar_Buchungskonten_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Inventar_Buchungskonten_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Inventar_Buchungskonten_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Inventar_Buchungskonten_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Inventar_Buchungskonten_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Inventar_Buchungskonten_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim KONTO_NR As GridColumn = View.Columns("Kontonummer")
        'Dim CR_KONTO As GridColumn = View.Columns("CR_KontoNr")
        'Dim CR_KONTO_CODE As GridColumn = View.Columns("CR_KontoNr_Code")
        Dim CR_KONTO_OCBS As GridColumn = View.Columns("CR_KontoNr_OCBS")
        'Dim DT_KONTO As GridColumn = View.Columns("DT_KontoNr")
        'Dim DT_KONTO_CODE As GridColumn = View.Columns("DT_KontoNr_Code")
        Dim DT_KONTO_OCBS As GridColumn = View.Columns("DT_KontoNr_OCBS")
        Dim KONTO_CURRENCY As GridColumn = View.Columns("KontoCurrency")

        Dim KontoNr As String = View.GetRowCellValue(e.RowHandle, colKontonummer1).ToString
        'Dim CrKonto As String = View.GetRowCellValue(e.RowHandle, colCR_KontoNr).ToString
        'Dim CrKontoCode As String = View.GetRowCellValue(e.RowHandle, colCR_KontoNr_Code).ToString
        Dim CrKontoOCBS As String = View.GetRowCellValue(e.RowHandle, colCR_KontoNr_OCBS).ToString
        'Dim DtKonto As String = View.GetRowCellValue(e.RowHandle, colDT_KontoNr).ToString
        'Dim DtKontoCode As String = View.GetRowCellValue(e.RowHandle, colDT_KontoNr_Code).ToString
        Dim DtKontoOCBS As String = View.GetRowCellValue(e.RowHandle, colDT_KontoNr_OCBS).ToString
        Dim Kontocurrency As String = View.GetRowCellValue(e.RowHandle, colKontoCurrency).ToString


        If KontoNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KONTO_NR, "Kontonummer must not be empty")
            e.ErrorText = "Kontonummer must not be empty"
        End If
        If CrKontoOCBS = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CR_KONTO_OCBS, "Credit Konto OCBS must not be empty")
            e.ErrorText = "Credit Konto OCBS must not be empty"
        End If


        If DtKontoOCBS = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DT_KONTO_OCBS, "Debit Konto OCBS must not be empty")
            e.ErrorText = "Debit Konto OCBS must not be empty"
        End If
        If Kontocurrency = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KONTO_CURRENCY, "Kontowährung must not be empty")
            e.ErrorText = "Kontowährung must not be empty"
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "INVENTAR" Then
            ActiveTabGroup = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "KONTEN- MWSt" Then
            ActiveTabGroup = 2
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "VORSTEUERSÄTZE" Then
            ActiveTabGroup = 3
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "AfA - Details und alle Reports" Then
            ActiveTabGroup = 4
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "BUCHUNGSKONTEN" Then
            ActiveTabGroup = 5
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Import Neues Inventar aus Excel Blatt" Then
            ActiveTabGroup = 6
            Me.SpreadsheetControl1.Focus()

            'Me.SpreadsheetControl1.SelectedCell = workbook.Worksheets(0).Cells("A2")
        End If
    End Sub

#Region "PRINTING_EXPORTS"

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If ActiveTabGroup = 1 Then
            If Not GridControl1.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 2 Then
            If Not GridControl2.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 3 Then
            If Not GridControl3.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 4 Then
            If Not GridControl4.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink4.CreateDocument()
            PrintableComponentLink4.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 5 Then
            If Not GridControl5.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink5.CreateDocument()
            PrintableComponentLink5.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 6 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink6.CreateDocument()
            PrintableComponentLink6.ShowPreview()
            SplashScreenManager.CloseForm(False)
            'Using printingSystem As New PrintingSystem()
            'Using link As New PrintableComponentLink(PrintingSystem)
            'Link.Component = workbook
            'Link.Landscape = True
            'Link.CreateDocument()
            'Link.ShowPreviewDialog()
            'End Using
            'End Using
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
        Dim reportfooter As String = "INVENTARLISTE" & " " & "Date: " & Today
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
        Dim reportfooter As String = "INVENTAR - KONTEN (MEHRWERTSTEUER)" & "  " & "Date: " & Today
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
        Dim reportfooter As String = "INVENTAR - VORSTEUERSÄTZE" & "  " & "Date: " & Today
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "INVENTAR - AfA Details" & "  " & "Date: " & Me.AfADate_Comboedit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalHeaderArea
        Dim reportfooter As String = "INVENTAR - BUCHUNGSKONTEN" '& vbNewLine & "Date: " & Me.AfADate_Comboedit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#End Region



    Private Sub Load_AfA_Details_btn_Click(sender As Object, e As EventArgs) Handles Load_AfA_Details_btn.Click
        If MessageBox.Show("Sollen die AfA kalkuliert werden?", "AfA Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CALCULATE_AFA_DETAILS()
        End If


    End Sub

    Private Sub AfADate_Comboedit_Click(sender As Object, e As EventArgs) Handles AfADate_Comboedit.Click
        If IsDate(Me.AfADate_Comboedit.Text) = True Then
            Me.GridControl4.DataSource = Nothing
            Me.LayoutControlItem12.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub AfADate_Comboedit_KeyDown(sender As Object, e As KeyEventArgs) Handles AfADate_Comboedit.KeyDown
        If IsDate(Me.AfADate_Comboedit.Text) = True Then
            Me.GridControl4.DataSource = Nothing
            Me.LayoutControlItem12.Visibility = LayoutVisibility.Never
        End If
    End Sub

#Region "INVENTAR CRYSTAL REPORTS"

    Private Sub InventarReport_btn_Click(sender As Object, e As EventArgs) Handles InventarReport_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating INVENTARLISTE Report ")

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INVENTARLISTE.rpt")
            CrRep.SetDataSource(Me.InventarDataSet)
            'Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            'Dim myParams As ParameterField = New ParameterField
            'myValue.Value = d
            'myParams.ParameterFieldName = "RDate"
            'myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Inventarliste per " & Today
            'c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            'c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub AfA_Detail_Rep_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AfA_Detail_Rep_BarButtonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating AfA Detail Report for " & Me.AfADate_Comboedit.Text)

            Dim d As Date = Me.AfADate_Comboedit.Text
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INVENTAR-AFA Details.rpt")
            CrRep.SetDataSource(Me.InventarDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "AfA Detail per " & Me.AfADate_Comboedit.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Buchungsbeleg_Rep_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Buchungsbeleg_Rep_BarButtonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating INVENTAR-Buchungsbeleg for " & Me.AfADate_Comboedit.Text)

            Dim d As Date = Me.AfADate_Comboedit.Text
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INVENTAR-Buchungsbeleg.rpt")
            CrRep.SetDataSource(Me.InventarDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "INVENTAR-Buchungsbeleg per " & Me.AfADate_Comboedit.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Kontrollblatt_Rep_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Kontrollblatt_Rep_BarButtonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Kontrollblatt for " & Me.AfADate_Comboedit.Text)

            Dim d As Date = Me.AfADate_Comboedit.Text
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INVENTAR-Kontrollblatt.rpt")
            CrRep.SetDataSource(Me.InventarDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Kontrollblatt per " & Me.AfADate_Comboedit.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Einbuchungen_Rep_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Einbuchungen_Rep_BarButtonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Report EINBUCHUNGEN for " & Me.AfADate_Comboedit.Text)

            Dim d As Date = Me.AfADate_Comboedit.Text
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INVENTAR-Einbuchungen.rpt")
            CrRep.SetDataSource(Me.InventarDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "INVENTAR-Einbuchungen per " & Me.AfADate_Comboedit.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Ausbuchungen_Rep_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Ausbuchungen_Rep_BarButtonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Report AUSBUCHUNGEN for " & Me.AfADate_Comboedit.Text)

            Dim d As Date = Me.AfADate_Comboedit.Text
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INVENTAR-Ausbuchungen.rpt")
            CrRep.SetDataSource(Me.InventarDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "INVENTAR-Ausbuchungen per " & Me.AfADate_Comboedit.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub PrintInventarDetails_btn_Click(sender As Object, e As EventArgs) Handles PrintInventarDetails_btn.Click
        If Me.DxValidationProvider1.Validate() = True Then
            Try
                Me.Validate()
                Me.INVENTAR_ALL_ITEMSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.InventarDataSet)

                Dim InventarNr As String = Me.InventarNr_TextEdit.Text
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Inventar Details for Inventar Nr.: " & InventarNr)


                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\INVENTAR_ITEM.rpt")
                CrRep.SetDataSource(Me.InventarDataSet)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = InventarNr
                myParams.ParameterFieldName = "InventarNr"
                myParams.CurrentValues.Add(myValue)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Inventar Details for Inventar Nr.: " & InventarNr
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            XtraMessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

#End Region

#Region "IMPORT INVENTAR FROM EXCEL"
    Private Sub ImportFromExcel_btn_Click(sender As Object, e As EventArgs) Handles ImportFromExcel_btn.Click
        If XtraMessageBox.Show("Sollen die eingetragenen Inventar Items in die Datenbank eingefügt werden?", "IMPORT NEUE INVENTAR ITEMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Starte import der Inventar Items vom Excel Blatt")
                'Save Excel File
                Try
                    workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandTimeout = 500
                cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where ([InventarNr] is not NULL or [Bezeichnung] is not NULL)')"
                Dim result As Double = cmd.ExecuteScalar
                If result > 0 Then
                    cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='INVENTAR_ALL_ITEMS_Temp' AND xtype='U') DROP TABLE [INVENTAR_ALL_ITEMS_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "CREATE TABLE [dbo].[INVENTAR_ALL_ITEMS_Temp]([Inventarnummer] [nvarchar](255) NOT NULL,[Bezeichnung] [nvarchar](255) NOT NULL,[Seriennummer] [nvarchar](255) NULL,[Anschaffungsdatum] [datetime] NOT NULL,[Nettowert] [float] NOT NULL,[Anzahl] [float] NULL,[Monate] [float] NOT NULL,[Anschaffungswert] [float] NULL,[Kontonummer] [nvarchar](255) NOT NULL,[KontonummerAmount] [float] NULL,[Kontonummer_MWST] [nvarchar](255) NOT NULL,[Kontonummer_MWST_Amount] [float] NULL,[Kontonummer_Vorsteuer] [nvarchar](255) NOT NULL,[Kontonummer_Vorsteuer_Amount] [float] NULL,[MWST_Satz] [float] NOT NULL,[MWST_Rueck] [float] NULL,[Kostenstelle] [nvarchar](255) NOT NULL,[Bemerkung] [nvarchar](255) NULL) ON [PRIMARY]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [dbo].[INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_INVENTAR_ALL_ITEMS_Temp_Anzahl]  DEFAULT (1) FOR [Anzahl]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [dbo].[INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_INVENTAR_ALL_ITEMS_Temp_KontonummerAmount]  DEFAULT (0) FOR [KontonummerAmount]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [dbo].[INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_INVENTAR_ALL_ITEMS_Temp_Kontonummer_MWST_Amount]  DEFAULT (0) FOR [Kontonummer_MWST_Amount]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [dbo].[INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_INVENTAR_ALL_ITEMS_Temp_Kontonummer_Vorsteuer_Amount]  DEFAULT (0) FOR [Kontonummer_Vorsteuer_Amount]"
                    cmd.ExecuteNonQuery()
                    'Import Data to Temporary Table
                    cmd.CommandText = "INSERT INTO [INVENTAR_ALL_ITEMS_Temp] ([Inventarnummer],[Bezeichnung],[Seriennummer],[Anschaffungsdatum],[Nettowert],[Monate],[MWST_Satz],[Kontonummer],[Kontonummer_MWST],[Kontonummer_Vorsteuer],[Kostenstelle],[Bemerkung]) SELECT InventarNr,[Bezeichnung],[SerienNr],Anschafungsdatum,[NettoWert_EURO],AfA_Monate,MWSt_Satz,Kontonummer,Kontonummer_MWST,KontonummerVorsteuer,Kostenstelle,Bemerkung FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [InventarNr] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Check Accounts
                    Me.QueryText = "Select Distinct([Kontonummer]) as 'Kontonummer' from [INVENTAR_ALL_ITEMS_Temp] where [Kontonummer] not in (Select [Konto] from [INVENTAR_KONTEN_MWST])"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim KONTEN As String = Nothing
                        For i = 0 To dt.Rows.Count - 1
                            KONTEN += dt.Rows.Item(i).Item("Kontonummer") & vbNewLine
                        Next
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("Die folgenden Konten sind in der Datenbank nicht vorhanden:" & vbNewLine & KONTEN & vbNewLine & vbNewLine & "Bitte überprüfen Sie Ihre eingaben bzw. fügen Sie die o.a. Konten in die Datenbank ein!", "KONTEN NICHT VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    '+++++
                    Me.QueryText = "Select Distinct([Kontonummer_MWST]) as 'Kontonummer' from [INVENTAR_ALL_ITEMS_Temp] where [Kontonummer_MWST] not in (Select [Konto_MWSt] from [INVENTAR_KONTEN_MWST])"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim KONTEN As String = Nothing
                        For i = 0 To dt.Rows.Count - 1
                            KONTEN += dt.Rows.Item(i).Item("Kontonummer") & vbNewLine
                        Next
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("Die folgenden MWSt Konten sind in der Datenbank nicht vorhanden:" & vbNewLine & KONTEN & vbNewLine & vbNewLine & "Bitte überprüfen Sie Ihre eingaben bzw. fügen Sie die o.a. Konten in die Datenbank ein!", "MWST KONTEN NICHT VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    '++++++
                    Me.QueryText = "Select Distinct([Kontonummer_Vorsteuer]) as 'Kontonummer' from [INVENTAR_ALL_ITEMS_Temp] where [Kontonummer_Vorsteuer] not in (Select [Konto_Vorsteuer] from [INVENTAR_KONTEN_MWST])"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim KONTEN As String = Nothing
                        For i = 0 To dt.Rows.Count - 1
                            KONTEN += dt.Rows.Item(i).Item("Kontonummer") & vbNewLine
                        Next
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("Die folgenden Vorsteuer Konten sind in der Datenbank nicht vorhanden:" & vbNewLine & KONTEN & vbNewLine & vbNewLine & "Bitte überprüfen Sie Ihre eingaben bzw. fügen Sie die o.a. Konten in die Datenbank ein!", "VORSTEUER KONTEN NICHT VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '****************************************************************************

                    'CALCULATIONS
                    cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS_Temp] SET [MWST_Rueck]=(Select Distinct 'VS' = CASE WHEN EXISTS(Select [Vorsteuersatz] from [INVENTAR_VORSTEUER_SAETZE] where [Jahr]=DATEPART(Year,[Anschaffungsdatum])) then [Vorsteuersatz]else (SELECT [Vorsteuersatz] FROM [INVENTAR_VORSTEUER_SAETZE] Where [Jahr] IN (Select Max([Jahr]) from [INVENTAR_VORSTEUER_SAETZE])) end from [INVENTAR_VORSTEUER_SAETZE])"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS_Temp] SET [KontonummerAmount]=[Nettowert],[Kontonummer_MWST_Amount]=ROUND([Nettowert]*[MWST_Satz],2),[Kontonummer_Vorsteuer_Amount]=Round([Nettowert]*[MWST_Satz]*([MWST_Rueck]/100)*(-1),2)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [INVENTAR_ALL_ITEMS_Temp] SET [Anschaffungswert]=[KontonummerAmount]+[Kontonummer_MWST_Amount]+[Kontonummer_Vorsteuer_Amount]"
                    cmd.ExecuteNonQuery()

                    'IMPORT TO MAIN TABLE
                    cmd.CommandText = "INSERT INTO [INVENTAR_ALL_ITEMS]([Inventarnummer],[Bezeichnung],[Seriennummer],[Anschaffungsdatum],[Nettowert],[Anzahl],[Monate],[Anschaffungswert],[Kontonummer],[KontonummerAmount],[Kontonummer_MWST],[Kontonummer_MWST_Amount],[Kontonummer_Vorsteuer],[Kontonummer_Vorsteuer_Amount],[MWST_Satz],[MWST_Rueck],[Kostenstelle],[Bemerkung])SELECT [Inventarnummer],[Bezeichnung],[Seriennummer],[Anschaffungsdatum],[Nettowert],[Anzahl],[Monate],[Anschaffungswert],[Kontonummer],[KontonummerAmount],[Kontonummer_MWST],[Kontonummer_MWST_Amount],[Kontonummer_Vorsteuer],[Kontonummer_Vorsteuer_Amount],[MWST_Satz]*100,[MWST_Rueck],[Kostenstelle],[Bemerkung] FROM [INVENTAR_ALL_ITEMS_Temp] where [Inventarnummer] not in (Select [Inventarnummer] from [INVENTAR_ALL_ITEMS])"
                    cmd.ExecuteNonQuery()

                    'DROP TEMPORARY TABLE
                    cmd.CommandText = "DROP TABLE [INVENTAR_ALL_ITEMS_Temp]"
                    cmd.ExecuteNonQuery()

                    'Clear and save excel file
                    workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
                    Dim worksheet As Worksheet = workbook.Worksheets(0)
                    worksheet.ClearContents(worksheet("A2:L50000"))

                    'Save Excel File
                    Try
                        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                    Me.INVENTAR_ALL_ITEMSTableAdapter.Fill(Me.InventarDataSet.INVENTAR_ALL_ITEMS)
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("Die Inventar Items wurden in der Inventar Datenbank importiert!", "IMPORT ERFOLGREICH", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("Das Excel Blatt ist leer!!" & vbNewLine & "Bitte tragen Sie Daten ist das Excel Blatt ein!", "KEINE DATEN VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
    End Sub

#End Region



    Private Sub Kontonummer_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Kontonummer_LookUpEdit.EditValueChanged

        If Me.LayoutControl1.Visible = False Then

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(Me.Kontonummer_LookUpEdit.Properties.View, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim MWST_Satz As Object = view.GetRowCellValue(view.FocusedRowHandle, "MWSt_Satz")
            Dim Konto_MWST As Object = view.GetRowCellValue(view.FocusedRowHandle, "Konto_MWSt")
            Dim Konto_VORSTEUER As Object = view.GetRowCellValue(view.FocusedRowHandle, "Konto_Vorsteuer")

            Me.MWst_TextEdit.Text = MWST_Satz
            Me.Kontonummer_MWSt_LookUpEdit.Text = Konto_MWST
            Me.Kontonummer_Vorsteuer_LookUpEdit.Text = Konto_VORSTEUER

            CALCULATIONS_MWST()
        End If

    End Sub

    Private Sub Kontonummer_LookUpEdit_Enter(sender As Object, e As EventArgs) Handles Kontonummer_LookUpEdit.Enter
        'Me.Kontonummer_LookUpEdit.BeginInvoke(New MethodInvoker(Me.Kontonummer_LookUpEdit.ShowPopup))

    End Sub

    Private Sub Kontonummer_LookUpEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles Kontonummer_LookUpEdit.KeyDown
        Me.Kontonummer_LookUpEdit.ShowPopup()

    End Sub

  
End Class