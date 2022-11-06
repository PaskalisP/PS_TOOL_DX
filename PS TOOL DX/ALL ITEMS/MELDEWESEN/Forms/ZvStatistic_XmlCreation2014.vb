Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports Ionic.Zip
Public Class ZvStatistic_XmlCreation2014
    Dim rd As Date = Nothing
    Dim rdsql As String = rd.ToString("yyyyMMdd")

    Dim ReportDay As String = rd.ToString("dd")
    Dim ReportMonth As String = rd.ToString("MM")
    Dim ReportYear As String = rd.ToString("yyyy")

    Dim CurrDate As Date = Now
    Dim CurrDateYear As String = Now.ToString("yy")
    Dim CurrDateMonth As String = Now.ToString("MM")
    Dim CurrDateDay As String = Now.ToString("dd")
    Dim CurrDateHour As String = Now.ToString("HH")
    Dim CurrDateMinute As String = Now.ToString("mm")
    Dim CurrDateSecond As String = Now.ToString("ss")


    Dim Abacus930XmlFileName As String = Nothing
    Dim Abacus907XmlFileName As String = Nothing
    Dim Abacus966XmlFileName As String = Nothing

    Dim MyWriter As System.Xml.XmlWriter
    Dim MySettings As New System.Xml.XmlWriterSettings

    Private BS_All_ZvMeldeschemas As BindingSource
    Public ZvReporting As New ZvStatistikReporting




    Public Sub ZvStatistic_XmlCreation2014_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never

    End Sub


    Public Sub ZVSTA_2014_XML_CREATE(ByVal ZVSTA_MELDESCHEMA As String, ByVal ZVSTA_MELDEPERIODE As String)
        Try
            SplashScreenManager.ShowForm(Me.ZvReporting, GetType(WaitForm1), False, False, True, SplashFormStartPosition.Default)
            SplashScreenManager.Default.SetWaitFormCaption("Start creating the ZVSTA XML Report File for reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'Meldejahr definieren
            Dim MeldeJahr As Double = Me.ZvMeldejahr_DateEdit.Text
            'Bank Data load
            Dim FIRMENNUMMER As String = Nothing
            Dim BANKNAME As String = Nothing
            Dim BANKSTRASSE As String = Nothing
            Dim BANKPLZ As String = Nothing
            Dim BANKORT As String = Nothing

            SplashScreenManager.Default.SetWaitFormCaption("Select Bank Data for reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [BANK]"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                FIRMENNUMMER = dt.Rows.Item(i).Item("BLZ Bank")
                BANKNAME = dt.Rows.Item(i).Item("Name Bank").ToString & " , " & dt.Rows.Item(i).Item("Branch Bank").ToString
                BANKSTRASSE = dt.Rows.Item(i).Item("Strasse Bank")
                BANKPLZ = dt.Rows.Item(i).Item("PLZ Bank")
                BANKORT = dt.Rows.Item(i).Item("Ort Bank")
            Next

            'Parameter Load
            Dim ZVSTA2014_XSD As String = Nothing
            Dim ZVSTA2014_XSD_BASIS As String = Nothing
            Dim XMLSAVEFILE As String = Nothing
            Dim ABSENDERANREDE As String = Nothing
            Dim ABSENDERVORNAME As String = Nothing
            Dim ABSENDERZUNAME As String = Nothing
            Dim ABSENDERABTEILUNG As String = Nothing
            Dim ABSENDERTELEFON As String = Nothing
            Dim ABSENDEREMAIL As String = Nothing
            Dim ABSENDEREXTRANETID As String = Nothing
            Dim MELDDERANREDE As String = Nothing
            Dim MELDERVORNAME As String = Nothing
            Dim MELDERZUNAME As String = Nothing
            Dim MELDERABTEILUNG As String = Nothing
            Dim MELDERTELEFON As String = Nothing
            Dim MELDEREMAIL As String = Nothing
            Dim MELDEREXTRANETID As String = Nothing

            SplashScreenManager.Default.SetWaitFormCaption("Select ZV_STATISTIK_2014 Parameters for reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [PARAMETER] where [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='ZV_STAT'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "ZVSTAXMLSAVE" Then
                    XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERANREDE" Then
                    ABSENDERANREDE = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERVORNAME" Then
                    ABSENDERVORNAME = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERZUNAME" Then
                    ABSENDERZUNAME = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERABTEILUNG" Then
                    ABSENDERABTEILUNG = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERTELEFON" Then
                    ABSENDERTELEFON = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDEREMAIL" Then
                    ABSENDEREMAIL = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDEREXTRANETID" Then
                    ABSENDEREXTRANETID = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDDERANREDE" Then
                    MELDDERANREDE = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERVORNAME" Then
                    MELDERVORNAME = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERZUNAME" Then
                    MELDERZUNAME = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERTELEFON" Then
                    MELDERTELEFON = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDEREMAIL" Then
                    MELDEREMAIL = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDEREXTRANETID" Then
                    MELDEREXTRANETID = dt.Rows.Item(i).Item("PARAMETER2")
                End If
                If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERABTEILUNG" Then
                    MELDERABTEILUNG = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            dt.Clear()

            'QueryText = "Select * from [PARAMETER_C] where  [ParameterStatus]='Y' and [ParameterCodeA]='REGREP' and [ParameterB_Name] in ('ZV_STATISTIK_2014')"
            'da = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then
            '    For i = 0 To dt.Rows.Count - 1
            '        If dt.Rows.Item(i).Item("PARAMETER1").ToString = "ZVSTA_2014_XSD" Then
            '            ZVSTA2014_XSD = dt.Rows.Item(i).Item("PARAMETER2").ToString
            '        End If
            '        If dt.Rows.Item(i).Item("PARAMETER1").ToString = "ZVSTA_2014_XSD_BASIS" Then
            '            ZVSTA2014_XSD_BASIS = dt.Rows.Item(i).Item("PARAMETER2").ToString
            '        End If
            '        If dt.Rows.Item(i).Item("PARAMETER1").ToString = "ZVSTA_2014_XML_CREATION_FOLDER" Then
            '            XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2").ToString
            '        End If
            '    Next
            'End If
            'dt.Clear()

            'SplashScreenManager.Default.SetWaitFormCaption("Select User Parameters for reporting Period: " & ZVSTA_MELDEPERIODE)
            'System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'QueryText = "Select * from [Users] where [WindowsUserID]='" & CurrentUserWindowsID & "'"
            'da = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then
            '    For i = 0 To dt.Rows.Count - 1
            '        ABSENDERANREDE = dt.Rows.Item(i).Item("Anrede").ToString
            '        ABSENDERVORNAME = dt.Rows.Item(i).Item("Vorname").ToString
            '        ABSENDERZUNAME = dt.Rows.Item(i).Item("Zuname").ToString
            '        ABSENDERABTEILUNG = dt.Rows.Item(i).Item("Department").ToString
            '        ABSENDERTELEFON = dt.Rows.Item(i).Item("TelefonNr").ToString
            '        ABSENDEREMAIL = dt.Rows.Item(i).Item("Email").ToString
            '        ABSENDEREXTRANETID = dt.Rows.Item(i).Item("ExtranetID").ToString
            '        MELDDERANREDE = ABSENDERANREDE
            '        MELDERVORNAME = ABSENDERVORNAME
            '        MELDERZUNAME = ABSENDERZUNAME
            '        MELDERTELEFON = ABSENDERTELEFON
            '        MELDEREMAIL = ABSENDEREMAIL
            '        MELDEREXTRANETID = ABSENDEREXTRANETID
            '        MELDERABTEILUNG = ABSENDERABTEILUNG
            '    Next
            'End If
            'dt.Clear()

            SplashScreenManager.Default.SetWaitFormCaption("Start creating XML File for reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'XML DATEI erstellungsdatum un Zeitdefinieren
            Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
            'MELDETERMIN
            'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
            Dim MELDETERMIN As String = Me.ZvMeldejahr_DateEdit.Text & "-12"
            Dim XMLMELDETERMIN As String = Microsoft.VisualBasic.Right(Me.ZvMeldejahr_DateEdit.Text, 2) & "12"

            Dim MyWriter As System.Xml.XmlWriter
            Dim MySettings As New System.Xml.XmlWriterSettings
            MySettings.Indent = True
            MySettings.ConformanceLevel = ConformanceLevel.Auto
            MySettings.IndentChars = "    "

            MySettings.NewLineOnAttributes = False
            MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")

            MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & "\zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml", MySettings)

            With MyWriter

                .WriteStartDocument()
                .WriteStartElement("zvs", "LIEFERUNG-ZVS", "http://www.bundesbank.de/statistik/zvs/v1")
                .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                .WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.bundesbank.de/statistik/zvs/v1 BbkXmwZVS2014.xsd")
                .WriteAttributeString("xmlns", "zvs", Nothing, "http://www.bundesbank.de/statistik/zvs/v1")
                .WriteAttributeString("xmlns", "bbk", Nothing, "http://www.bundesbank.de/xmw/2003-01-01")
                .WriteAttributeString("version", "1.0")
                .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")
                .WriteAttributeString("stufe", "Produktion")
                .WriteAttributeString("bereich", "Statistik")


                'ELEMENT-ABSENDER
                .WriteStartElement("bbk", "ABSENDER", "http://www.bundesbank.de/xmw/2003-01-01")
                .WriteElementString("zvs", "BLZ", Nothing, FIRMENNUMMER)
                .WriteElementString("bbk", "NAME", Nothing, BANKNAME)
                .WriteElementString("bbk", "STRASSE", Nothing, BANKSTRASSE)
                .WriteElementString("bbk", "ORT", Nothing, BANKPLZ & " " & BANKORT)
                .WriteElementString("bbk", "LAND", Nothing, "DE")
                '##############################
                'UNTERELEMENT-KONTAKT
                .WriteStartElement("bbk", "KONTAKT", "http://www.bundesbank.de/xmw/2003-01-01")
                .WriteElementString("bbk", "ANREDE", Nothing, ABSENDERANREDE)
                .WriteElementString("bbk", "VORNAME", Nothing, ABSENDERVORNAME)
                .WriteElementString("bbk", "ZUNAME", Nothing, ABSENDERZUNAME)
                .WriteElementString("bbk", "ABTEILUNG", Nothing, ABSENDERABTEILUNG)
                .WriteElementString("bbk", "TELEFON", Nothing, ABSENDERTELEFON)
                .WriteElementString("bbk", "EMAIL", Nothing, ABSENDEREMAIL)
                .WriteElementString("bbk", "EXTRANET-ID", Nothing, ABSENDEREXTRANETID)
                .WriteEndElement() 'KONTAKT
                .WriteEndElement() 'ABSENDER
                'MELDUNG ERSTELLZEIT
                .WriteStartElement("zvs", "MELDUNG", "http://www.bundesbank.de/statistik/zvs/v1")
                .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")
                '.WriteAttributeString("korrektur", "nein")
                'MELDER
                .WriteStartElement("bbk", "MELDER", "http://www.bundesbank.de/xmw/2003-01-01")
                .WriteElementString("zvs", "BLZ", Nothing, FIRMENNUMMER)
                .WriteElementString("bbk", "NAME", Nothing, BANKNAME)
                .WriteElementString("bbk", "STRASSE", Nothing, BANKSTRASSE)
                .WriteElementString("bbk", "ORT", Nothing, BANKPLZ & "  " & BANKORT)
                'UNTERELEMENT-KONTAKT
                .WriteStartElement("bbk", "KONTAKT", "http://www.bundesbank.de/xmw/2003-01-01")
                .WriteElementString("bbk", "ANREDE", Nothing, MELDDERANREDE)
                .WriteElementString("bbk", "VORNAME", Nothing, MELDERVORNAME)
                .WriteElementString("bbk", "ZUNAME", Nothing, MELDERZUNAME)
                .WriteElementString("bbk", "ABTEILUNG", Nothing, MELDERABTEILUNG)
                .WriteElementString("bbk", "TELEFON", Nothing, MELDERTELEFON)
                .WriteElementString("bbk", "EMAIL", Nothing, MELDEREMAIL)
                .WriteElementString("bbk", "EXTRANET-ID", Nothing, MELDEREXTRANETID)
                .WriteEndElement() 'KONTAKT
                .WriteEndElement() 'MELDER
                'MELDETERMIN
                .WriteElementString("zvs", "MELDETERMIN", Nothing, MELDETERMIN)

                'FORMULAR ZVS1+++++++++++++++++++++
                QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS1' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2014' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 AndAlso Me.ZVS1_CheckEdit.CheckState = CheckState.Checked Then
                    .WriteStartElement("zvs", "FORMULAR-ZVS1", "http://www.bundesbank.de/statistik/zvs/v1")
                    For i = 0 To dt.Rows.Count - 1
                        .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                        .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr").ToString)
                        .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode").ToString)
                        .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                End If

                'FORMULAR ZVS2+++++++++++++++++++++
                QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS2' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2014' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 AndAlso Me.ZVS2_CheckEdit.CheckState = CheckState.Checked Then
                    .WriteStartElement("zvs", "FORMULAR-ZVS2", "http://www.bundesbank.de/statistik/zvs/v1")
                    For i = 0 To dt.Rows.Count - 1
                        .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                        .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr").ToString)
                        .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode").ToString)
                        .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                End If

                'FORMULAR ZVS3+++++++++++++++++++++
                QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS3' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2014' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 AndAlso Me.ZVS3_CheckEdit.CheckState = CheckState.Checked Then
                    .WriteStartElement("zvs", "FORMULAR-ZVS3", "http://www.bundesbank.de/statistik/zvs/v1")
                    For i = 0 To dt.Rows.Count - 1
                        .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                        .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr").ToString)
                        .WriteAttributeString("Landkontext", dt.Rows.Item(i).Item("Landkontext").ToString)
                        .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode").ToString)
                        .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                End If

                'FORMULAR ZVS4+++++++++++++++++++++
                QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS4' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2014' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 AndAlso Me.ZVS4_CheckEdit.CheckState = CheckState.Checked Then
                    .WriteStartElement("zvs", "FORMULAR-ZVS4", "http://www.bundesbank.de/statistik/zvs/v1")
                    For i = 0 To dt.Rows.Count - 1
                        .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                        .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr").ToString)
                        .WriteAttributeString("Landkontext", dt.Rows.Item(i).Item("Landkontext").ToString)
                        .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode").ToString)
                        If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                            .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                        End If
                        If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                            .WriteAttributeString("Wert", dt.Rows.Item(i).Item("Wert_Value").ToString)
                        End If
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                End If

                'FORMULAR ZVS5+++++++++++++++++++++
                QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS5' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2014' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 AndAlso Me.ZVS5_CheckEdit.CheckState = CheckState.Checked Then
                    .WriteStartElement("zvs", "FORMULAR-ZVS5", "http://www.bundesbank.de/statistik/zvs/v1")
                    For i = 0 To dt.Rows.Count - 1
                        .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                        .WriteAttributeString("Terminalkennung", dt.Rows.Item(i).Item("PositionNr").ToString.Substring(0, 1).ToString)
                        .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr").ToString.Replace(dt.Rows.Item(i).Item("PositionNr").ToString.Substring(0, 2).ToString, "").ToString)
                        .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode").ToString)
                        If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                            .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                        End If
                        If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                            .WriteAttributeString("Wert", dt.Rows.Item(i).Item("Wert_Value").ToString)
                        End If
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                End If

                'FORMULAR ZVS8+++++++++++++++++++++
                QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS8' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2014' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 AndAlso Me.ZVS8_CheckEdit.CheckState = CheckState.Checked Then
                    .WriteStartElement("zvs", "FORMULAR-ZVS8", "http://www.bundesbank.de/statistik/zvs/v1")
                    For i = 0 To dt.Rows.Count - 1
                        .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                        .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr").ToString)
                        .WriteAttributeString("Landkontext", dt.Rows.Item(i).Item("Landkontext").ToString)
                        .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode").ToString)
                        If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                            .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                        End If
                        If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                            .WriteAttributeString("Wert", dt.Rows.Item(i).Item("Wert_Value").ToString)
                        End If
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                End If

                '++++++++++++++++++++++++++++++++++
                .WriteEndDocument()
                .Close()

            End With

            SplashScreenManager.Default.SetWaitFormCaption("Set utf-8 to UPPER Case in XML File for reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            Dim xmlfilestring As String = File.ReadAllText(XMLSAVEFILE & "\zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml")
            File.WriteAllText(XMLSAVEFILE & "\zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml", xmlfilestring.Replace("utf-8", "UTF-8"))
            SplashScreenManager.CloseForm(False)


            'VALIDIERUNG DER XML DATEI
            Dim myDocument As New XmlDocument
            myDocument.Load(XMLSAVEFILE & "\zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml")
            myDocument.Schemas.Add("http://www.bundesbank.de/statistik/zvs/v1", ZVSTA2014_XSD)
            myDocument.Schemas.Add("http://www.bundesbank.de/xmw/2003-01-01", ZVSTA2014_XSD_BASIS)
            Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
            myDocument.Validate(eventHandler)

            If MessageBox.Show("Following ZVSTA XML file has being generated: " & vbNewLine & "zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml" & vbNewLine _
                   & "and saved under the following directory:" & vbNewLine _
            & XMLSAVEFILE & vbNewLine & vbNewLine _
            & "Should the directory be opened?", "ZVSTA XML File succesfully generated", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                System.Diagnostics.Process.Start(XMLSAVEFILE)

            End If



            Exit Sub

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub


    Private Sub SelectAll_btn_Click(sender As Object, e As EventArgs) Handles SelectAll_btn.Click
        Me.ZVS1_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS2_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS3_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS4_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS5_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS8_CheckEdit.CheckState = CheckState.Checked
    End Sub

    Private Sub ClearAll_btn_Click(sender As Object, e As EventArgs) Handles ClearAll_btn.Click
        Me.ZVS1_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS2_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS3_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS4_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS5_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS8_CheckEdit.CheckState = CheckState.Unchecked
    End Sub

    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Select Case e.Severity
            Case XmlSeverityType.Error
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(e.Message, "ZVSTA XML Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'MsgBox("Error: {0}", e.Message, "ERROR")
                'Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(e.Message, "ZVSTA XML Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                'Debug.WriteLine("Warning {0}", e.Message)
                'MsgBox("Warning {0}", e.Message, "WARNING")

        End Select
    End Sub
End Class
