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
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
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
Public Class KapiSoliMeldungen

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATESFORM_KAPIMLDN As New AccDatesForm
    Dim DATESFORM_KAPIMLDN_REP As New AccDatesForm

    Dim KapiSoliMonatBasicViewCaption As String = Nothing
    Dim KapiSoliDetailsBasicViewCaption As String = Nothing



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

    Private Sub ZINSERTRAG_KUNDEN_JAHRBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ZINSERTRAG_KUNDEN_JAHRBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)

    End Sub

    Private Sub KapiSoliMeldungen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        Me.ZINSERTRAG_KUNDEN_DETAILSTableAdapter.Fill(Me.MeldewesenDataSet.ZINSERTRAG_KUNDEN_DETAILS)
        Me.ZINSERTRAG_KUNDEN_MONATTableAdapter.Fill(Me.MeldewesenDataSet.ZINSERTRAG_KUNDEN_MONAT)
        Me.ZINSERTRAG_KUNDEN_JAHRTableAdapter.Fill(Me.MeldewesenDataSet.ZINSERTRAG_KUNDEN_JAHR)

    End Sub

   
    Private Sub MeldungKapiSoli_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles MeldungKapiSoli_BarButtonItem.ItemClick
        If KundenZinsenOhnePlzBundesland = 0 Then
            Dim dxOK_KAPIMLD As New DevExpress.XtraEditors.SimpleButton

            With dxOK_KAPIMLD
                .Text = "OK"
                .Height = 23
                .Width = 75
                .ImageList = DATESFORM_KAPIMLDN.ImageCollection1
                .ImageIndex = 5
                .Location = New System.Drawing.Point(19, 203)
            End With

            DATESFORM_KAPIMLDN.Controls.Add(dxOK_KAPIMLD)
            DATESFORM_KAPIMLDN.OK_btn.Visible = False
            DATESFORM_KAPIMLDN.LabelControl1.Visible = True
            DATESFORM_KAPIMLDN.LabelControl2.Visible = False
            DATESFORM_KAPIMLDN.LabelControl3.Visible = False
            DATESFORM_KAPIMLDN.ComboBoxEdit2.Visible = False
            DATESFORM_KAPIMLDN.ComboBoxEdit3.Visible = False

            AddHandler dxOK_KAPIMLD.Click, AddressOf dxOK_KAPIMLD_click

            DATESFORM_KAPIMLDN.Show()
            DATESFORM_KAPIMLDN.Text = "MONATLICHE KAPITALERTRAGSTEUERANMELDUNG AN DAS FINANZAMT"
            DATESFORM_KAPIMLDN.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Meldung"


            'Me.QueryText = "SELECT a.[IdZinsertragsMonat],a.[ValDate] FROM [ZINSERTRAG KUNDEN DETAILS] a JOIN (SELECT [IdZinsertragsMonat], min(ID) as id FROM [ZINSERTRAG KUNDEN DETAILS] GROUP BY [IdZinsertragsMonat]) b ON ( a.id = b.id ) GROUP BY a.[IdZinsertragsMonat],a.[ValDate] order by a.[ValDate] desc"
            Me.QueryText = "SELECT Zinsertragsmonat FROM [ZINSERTRAG KUNDEN MONAT] order by ZinsertragsmonatDATE desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                'DATESFORM_KAPIMLDN.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                DATESFORM_KAPIMLDN.ComboBoxEdit1.Properties.Items.Add(row("ZinsertragsMonat"))
            Next
            'DATESFORM_KAPIMLDN.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
            DATESFORM_KAPIMLDN.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("ZinsertragsMonat")
        Else
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If



    End Sub

    Private Sub dxOK_KAPIMLD_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Zinsertragsmonatmeldung As String = DATESFORM_KAPIMLDN.ComboBoxEdit1.Text
        Dim MeldeJahr As String = Microsoft.VisualBasic.Right(Zinsertragsmonatmeldung, 4)
        DATESFORM_KAPIMLDN.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Kapitalertragsteueranmeldung für " & Zinsertragsmonatmeldung)
        'BANK DATEN empfangen
        Dim STEUERNUMMER As String = ""
        Dim BANKNAME As String = ""
        Dim BANKSTRASSE As String = ""
        Dim BANKPLZ As String = ""
        Dim BANKORT As String = ""

        Me.QueryText = "select * from [BANK]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        STEUERNUMMER = dt.Rows.Item(0).Item("SteuerNr")
        BANKNAME = dt.Rows.Item(0).Item("Name Bank") & "," & dt.Rows.Item(0).Item("Branch Bank")
        BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
        BANKPLZ = dt.Rows.Item(0).Item("PLZ Bank")
        BANKORT = dt.Rows.Item(0).Item("Ort Bank")

        'FINANZAMT DATEN-PDF Remplate Empfangen
        Dim FINANZAMT_NAME As String = ""
        Dim FINANZAMT_STRASSE As String = ""
        Dim FINANZAMT_PLZ As String = ""
        Dim FINANZAMT_ORT As String = ""
        Dim PDF_TEMPLATE As String = ""
        Dim PDF_NEW_FILE As String = ""

        Me.QueryText = "SELECT * FROM [PARAMETER] where  [IdABTEILUNGSPARAMETER]='KAPISTEUERMLD' and [PARAMETER STATUS]='Y' "
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim CheckParameter As String = dt.Rows.Item(i).Item("PARAMETER1")
            Dim RelevantParameter As String = dt.Rows.Item(i).Item("PARAMETER2")
            Select Case CheckParameter
                Case Is = "FINANZAMT_NAME"
                    FINANZAMT_NAME = RelevantParameter
                Case Is = "FINANZAMT_STRASSE"
                    FINANZAMT_STRASSE = RelevantParameter
                Case Is = "FINANZAMT_PLZ"
                    FINANZAMT_PLZ = RelevantParameter
                Case Is = "FINANZAMT_ORT"
                    FINANZAMT_ORT = RelevantParameter
                Case Is = "KAPIMELDUNG_TEMPLATE_DIR"
                    PDF_TEMPLATE = RelevantParameter
                Case Is = "KAPIMELDUNG_NEW_DIR"
                    PDF_NEW_FILE = RelevantParameter
            End Select
        Next

        Dim newFileSave As String = PDF_NEW_FILE & "\Kapitalertragsteueranmeldung_" & Zinsertragsmonatmeldung & ".pdf"
        Dim pdfReader As New PdfReader(PDF_TEMPLATE)
        Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFileSave, FileMode.Create))

        Dim pdfFormFields As AcroFields = pdfStamper.AcroFields


        'Füllen der Daten in allen seiten
        pdfFormFields.SetField("topmostSubform[0].Page1[0].MeldeJahr[0]", MeldeJahr)
        pdfFormFields.SetField("topmostSubform[0].Page1[0].Steuernummer[0]", STEUERNUMMER)
        Dim FINANZ_ALL As String = FINANZAMT_NAME & vbNewLine & FINANZAMT_STRASSE & vbNewLine & FINANZAMT_PLZ & "  " & FINANZAMT_ORT
        pdfFormFields.SetField("topmostSubform[0].Page1[0].Finanzamt[0]", FINANZ_ALL)
        Dim BANK_ALL As String = BANKNAME & vbNewLine & BANKSTRASSE & vbNewLine & BANKPLZ & "  " & BANKORT
        pdfFormFields.SetField("topmostSubform[0].Page1[0].Schuldner[0]", BANK_ALL)
       
        'Meldemonat definieren
        If Zinsertragsmonatmeldung.StartsWith("Januar") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Jan[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Februar") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Feb[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("März") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Maerz[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("April") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].April[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Mai") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Mai[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Juni") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Juni[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Juli") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Juli[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("August") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Aug[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("September") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Sept[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Oktober") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Okt[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("November") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Nov[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Dezember") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Dez[0]", "1")
        End If

        'Zinsertraege
        Dim ZINSERTRAG As Double = 0
        cmd.CommandText = "SELECT sum([AmountEuro]) FROM [ZINSERTRAG KUNDEN DETAILS]  where [IdZinsertragsMonat]='" & Zinsertragsmonatmeldung & "'and [KAPISTPFLICHTIG]='Y' and [KapertstG] >0"
        cmd.Connection.Open()
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            ZINSERTRAG = cmd.ExecuteScalar
        Else
            ZINSERTRAG = 0
        End If

        'Kapitalertargssteuer + Soli
        Dim KAPI As Double = 0
        cmd.CommandText = "SELECT [SummeKapErSt] FROM [ZINSERTRAG KUNDEN MONAT]  where [Zinsertragsmonat]='" & Zinsertragsmonatmeldung & "'"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            KAPI = Math.Truncate(cmd.ExecuteScalar)
        Else
            KAPI = 0
        End If

        cmd.Connection.Close()
        Dim SOLI As Double = 0
        SOLI = KAPI * 0.055

        pdfFormFields.SetField("topmostSubform[0].Page1[0].Zinsertraege[0]", Format(ZINSERTRAG, "#,##0.00"))
        pdfFormFields.SetField("topmostSubform[0].Page1[0].KAPIST[0]", Format(KAPI, "#,##0"))
        pdfFormFields.SetField("topmostSubform[0].Page1[0].SOLI[0]", Format(SOLI, "#,##0.00"))

        'Kapitalertragssteuer an Bundesländer
        Me.QueryText = "Select Sum([KapertstG]) as Kapi_Sum,BUNDESLAND from  [ZINSERTRAG KUNDEN DETAILS] where IdZinsertragsMonat='" & Zinsertragsmonatmeldung & "' and [KAPISTPFLICHTIG]='Y' and [KapertstG] is not NULL GROUP BY [BUNDESLAND]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            'Dim SumKAPI As Double = FormatNumber(dt.Rows.Item(i).Item("Kapi_Sum"), 2)
            Dim SumKAPI As Double = Math.Truncate(dt.Rows.Item(i).Item("Kapi_Sum"))

            If dt.Rows.Item(i).Item("BUNDESLAND") = "BADEN-WÜRTTEMBERG" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BW[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BAYERN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BAY[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BERLIN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BER[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BRANDENBURG" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BRAN[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BREMEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BREM[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "HAMBURG" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].HAM[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "HESSEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].HES[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "MECKLENBURG-VORPOMMERN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].MECK[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "NIEDERSACHSEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].NIEDER[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "NORDRHEIN-WESTFALEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].NORD[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "RHEINLAND-PFALZ" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].RHEIN[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SAARLAND" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SAAR[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SACHSEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SACH[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SACHSEN-ANHALT" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SACHAN[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SCHLESWIG-HOLSTEIN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SCHLESW[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "THÜRINGEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].THUR[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].None[0]", Format(SumKAPI, "#,##0"))
            End If
        Next

        ' flatten the form to remove editting options, set it to false
        ' to leave the form open to subsequent manual edits
        pdfStamper.FormFlattening = True

        ' close the pdf
        pdfStamper.Close()


        'Dim c As New PdfForm
        'c.MdiParent = Me.MdiParent
        'c.Show()
        '+++++++++c.AxAcroPDF1.Visible = False
        'c.Text = "Kapitalertragsteueranmeldung für " & Zinsertragsmonatmeldung
        'Dim AxAcroPDF1 As New AxAcroPDFLib.AxAcroPDF
        'c.Controls.Add(AxAcroPDF1)
        'AxAcroPDF1.Dock = DockStyle.Fill
        'AxAcroPDF1.Enabled = True
        'AxAcroPDF1.TabIndex = 0
        'AxAcroPDF1.src = newFileSave
        'AxAcroPDF1.setShowToolbar(True)
        'AxAcroPDF1.Refresh()
        'c.Refresh()

        'New Code for Dev PdfViewer
        Dim f As New PdfDevForm
        f.MdiParent = Me.MdiParent
        f.Show()
        f.Text = "Kapitalertragsteueranmeldung für " & Zinsertragsmonatmeldung
        f.PdfViewer1.LoadDocument(newFileSave)
        f.PdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible


        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub KapiSoliJahr_BasicView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles KapiSoliJahr_BasicView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "KapiSoliJahr_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            KapiSoliMonatBasicViewCaption = "Kapitalertragssteuer/Soli für das Jahr " & view.GetFocusedRowCellValue("ErtragsJahr").ToString
            Me.KapiSoliMonat_BasicView.ViewCaption = KapiSoliMonatBasicViewCaption
        End If
    End Sub

    Private Sub KapiSoliJahr_BasicView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles KapiSoliJahr_BasicView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "KapiSoliJahr_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            KapiSoliMonatBasicViewCaption = "Kapitalertragssteuer/Soli für das Jahr " & view.GetFocusedRowCellValue("ErtragsJahr").ToString
            Me.KapiSoliMonat_BasicView.ViewCaption = KapiSoliMonatBasicViewCaption
        End If
    End Sub

    Private Sub KapiSoliJahr_BasicView_RowClick(sender As Object, e As RowClickEventArgs) Handles KapiSoliJahr_BasicView.RowClick
        If Me.GridControl1.FocusedView.Name = "KapiSoliJahr_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            KapiSoliMonatBasicViewCaption = "Kapitalertragssteuer/Soli für das Jahr " & view.GetFocusedRowCellValue("ErtragsJahr").ToString
            Me.KapiSoliMonat_BasicView.ViewCaption = KapiSoliMonatBasicViewCaption
        End If
    End Sub

    Private Sub KapiSoliJahr_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles KapiSoliJahr_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub KapiSoliJahr_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles KapiSoliJahr_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub KapiSoliMonat_BasicView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles KapiSoliMonat_BasicView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "KapiSoliMonat_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            KapiSoliDetailsBasicViewCaption = "Kapitalertragssteuer/Soli für " & view.GetFocusedRowCellValue("Zinsertragsmonat").ToString
            Me.KapiSoliDetails_BasicView.ViewCaption = KapiSoliDetailsBasicViewCaption
        End If
    End Sub

    Private Sub KapiSoliMonat_BasicView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles KapiSoliMonat_BasicView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "KapiSoliMonat_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            KapiSoliDetailsBasicViewCaption = "Kapitalertragssteuer/Soli für " & view.GetFocusedRowCellValue("Zinsertragsmonat").ToString
            Me.KapiSoliDetails_BasicView.ViewCaption = KapiSoliDetailsBasicViewCaption
        End If
    End Sub

    Private Sub KapiSoliMonat_BasicView_RowClick(sender As Object, e As RowClickEventArgs) Handles KapiSoliMonat_BasicView.RowClick
        If Me.GridControl1.FocusedView.Name = "KapiSoliMonat_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            KapiSoliDetailsBasicViewCaption = "Kapitalertragssteuer/Soli für " & view.GetFocusedRowCellValue("Zinsertragsmonat").ToString
            Me.KapiSoliDetails_BasicView.ViewCaption = KapiSoliDetailsBasicViewCaption
        End If
    End Sub

    Private Sub KapiSoliMonat_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles KapiSoliMonat_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub KapiSoliMonat_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles KapiSoliMonat_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub KapiSoliDetails_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles KapiSoliDetails_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub KapiSoliDetails_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles KapiSoliDetails_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub KapiSoliReportMonatlich_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles KapiSoliReportMonatlich_BarButtonItem.ItemClick
        If KundenZinsenOhnePlzBundesland = 0 Then
            If KundenZinsenPLZ_EAEG = 0 Then
                Dim dxOK_KAPIMLD_REP As New DevExpress.XtraEditors.SimpleButton

                With dxOK_KAPIMLD_REP
                    .Text = "OK"
                    .Height = 23
                    .Width = 75
                    .ImageList = DATESFORM_KAPIMLDN_REP.ImageCollection1
                    .ImageIndex = 5
                    .Location = New System.Drawing.Point(19, 203)
                End With

                DATESFORM_KAPIMLDN_REP.Controls.Add(dxOK_KAPIMLD_REP)
                DATESFORM_KAPIMLDN_REP.OK_btn.Visible = False
                DATESFORM_KAPIMLDN_REP.LabelControl1.Visible = True
                DATESFORM_KAPIMLDN_REP.LabelControl2.Visible = False
                DATESFORM_KAPIMLDN_REP.LabelControl3.Visible = False
                DATESFORM_KAPIMLDN_REP.ComboBoxEdit2.Visible = False
                DATESFORM_KAPIMLDN_REP.ComboBoxEdit3.Visible = False

                AddHandler dxOK_KAPIMLD_REP.Click, AddressOf dxOK_KAPIMLD_REP_click

                DATESFORM_KAPIMLDN_REP.Show()
                DATESFORM_KAPIMLDN_REP.Text = "MONATLICHE KAPITALERTRAGSTEUERANMELDUNG AN DAS FINANZAMT"
                DATESFORM_KAPIMLDN_REP.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Meldung"

                'Me.QueryText = "SELECT a.[IdZinsertragsMonat],a.[ValDate] FROM [ZINSERTRAG KUNDEN DETAILS] a JOIN (SELECT [IdZinsertragsMonat], min(ID) as id FROM [ZINSERTRAG KUNDEN DETAILS] GROUP BY [IdZinsertragsMonat]) b ON ( a.id = b.id ) GROUP BY a.[IdZinsertragsMonat],a.[ValDate] order by a.[ValDate] desc"
                Me.QueryText = "SELECT Zinsertragsmonat FROM [ZINSERTRAG KUNDEN MONAT] order by ZinsertragsmonatDATE desc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For Each row As DataRow In dt.Rows
                    'DATESFORM_KAPIMLDN_REP.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                    DATESFORM_KAPIMLDN_REP.ComboBoxEdit1.Properties.Items.Add(row("ZinsertragsMonat"))
                Next
                'DATESFORM_KAPIMLDN_REP.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
                DATESFORM_KAPIMLDN_REP.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("ZinsertragsMonat")
            Else
                MessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Else
            MessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub


    Private Sub dxOK_KAPIMLD_REP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Zinsertragsmonatmeldung As String = DATESFORM_KAPIMLDN_REP.ComboBoxEdit1.Text
        DATESFORM_KAPIMLDN_REP.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung des Reports für die Kapitalertragsteuer/Soli  " & Zinsertragsmonatmeldung)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KapiMeldungMonat.rpt")
        CrRep.SetDataSource(MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Zinsertragsmonatmeldung
        myParams.ParameterFieldName = "MeldeMonat"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Kapitalertragsteuer/Soli für " & Zinsertragsmonatmeldung
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Print_Export_KapiSoliMeldungen_BasicView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_KapiSoliMeldungen_BasicView_btn.Click
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
        Dim reportfooter As String = "KAPITALERTRAGSTEUER/SOLIDARITÄTSZUSCHLAG "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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