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
Public Class ZvStatistic_XmlCreation2022_H
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




    Public Sub ZvStatistic_XmlCreation2022_H_Load(sender As Object, e As EventArgs) Handles Me.Load



        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never

    End Sub


    Public Sub ZVSTA_2022_H_XML_CREATE(ByVal ZVSTA_MELDESCHEMA As String, ByVal ZVSTA_MELDEPERIODE As String)
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
            Dim MFI_CODE As String = Nothing

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
                MFI_CODE = dt.Rows.Item(i).Item("MFI_Code")
            Next

            'Parameter Load
            Dim ZVSTA_2022_H_SDMXMessage_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXRegistry_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXDataGeneric_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXMetadataStructureSpecific_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXDataStructureSpecific_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructure_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQuery_XSD As String = Nothing
            Dim ZVSTA_2022_H_xml_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXMessageFooter_XSD As String = Nothing
            Dim ZVSTA_2022_H_BBK_PAY_V1_0_SDMX_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXMetadataGeneric_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXCommon_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryMetadata_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureDataflow_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryStructureSet_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureCategory_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXRegistryBase_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryBase_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureReportingTaxonomy_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryProcess_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryReportingTaxonomy_XSD As String = Nothing
            Dim ZVSTA_2022_H_BBKCommonTypes_V2_2_SDMX_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureProvisionAgreement_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryDataflow_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXRegistryRegistration_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureBase_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureMetadataStructure_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryCategory_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXRegistrySubscription_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureHierarchicalCodelist_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryMetadataStructure_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureConstraint_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXCommonReferences_XSD As String = Nothing
            Dim ZVSTA_2022_H_ECBCommonTypes_V2_2_SDMX_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryOrganisation_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXDataStructureSpecificTimeSeries_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureMetadataflow_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryCategorisation_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryProvisionAgreement_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXDataGenericTimeSeries_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryMetadataflow_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryStructures_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryHierarchicalCodelist_XSD As String = Nothing
            Dim ZVSTA_2022_H_ECB_CDLST_V2_2_SDMX_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureConcept_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryCodelist_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureDataStructure_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryConstraint_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXRegistryStructure_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXDataGenericBase_XSD As String = Nothing
            Dim ZVSTA_2022_H_BBK_CDLST_V2_4_1_SDMX_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureCategorisation_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQuerySchema_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXDataStructureSpecificBase_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryConcept_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureCodelist_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryDataStructure_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureStructureSet_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureOrganisation_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXQueryData_XSD As String = Nothing
            Dim ZVSTA_2022_H_SDMXStructureProcess_XSD As String = Nothing
            Dim XMLSAVEFILE As String = Nothing
            Dim XMLTESTFILE As String = Nothing
            Dim MELDETERMIN As String = Nothing
            Dim XMLMESSAGEID As String = Nothing
            Dim XMLMELDETERMIN As String = Nothing
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

            SplashScreenManager.Default.SetWaitFormCaption("Select ZV_STATISTIK_2022_H Parameters for reporting Period: " & ZVSTA_MELDEPERIODE)
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

            'QueryText = "Select * from [PARAMETER_C] where  [ParameterStatus]='Y' and [ParameterCodeA]='REGREP' and [ParameterB_Name] in ('ZV_STATISTIK_2022_H')"
            'da = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then
            '    For i = 0 To dt.Rows.Count - 1
            '        'If dt.Rows.Item(i).Item("PARAMETER1").ToString = "ZVSTA_2014_XSD" Then
            '        '    ZVSTA2014_XSD = dt.Rows.Item(i).Item("PARAMETER2").ToString
            '        'End If
            '        If dt.Rows.Item(i).Item("PARAMETER1").ToString = "ZVSTA_2022_H_XML_CREATION_FOLDER" Then
            '            XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2").ToString
            '        End If
            '        If dt.Rows.Item(i).Item("PARAMETER1").ToString = "ZVSTA_2022_H_XML_FILE_TEST" Then
            '            XMLTESTFILE = dt.Rows.Item(i).Item("PARAMETER2").ToString
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
            XMLMESSAGEID = DateTime.Now.ToString("yyMMdd") & ERSTELLUNGSZEIT.ToString("HHmmss")
            'MELDETERMIN
            MELDETERMIN = CStr(MeldeJahr)
            XMLMELDETERMIN = MELDETERMIN
            'Replace Halfyear with 06 + 12
            'If Microsoft.VisualBasic.Right(ZVSTA_MELDEPERIODE, 2) = "01" Then
            '    MELDETERMIN = Microsoft.VisualBasic.Left(Me.ZvMeldejahr_DateEdit.Text, 4) & "06"
            '    XMLMELDETERMIN = MELDETERMIN
            'ElseIf Microsoft.VisualBasic.Right(ZVSTA_MELDEPERIODE, 2) = "02" Then
            '    MELDETERMIN = Microsoft.VisualBasic.Left(Me.ZvMeldejahr_DateEdit.Text, 4) & "12"
            '    XMLMELDETERMIN = MELDETERMIN
            'End If


            Dim MyWriter As System.Xml.XmlWriter
            Dim MySettings As New System.Xml.XmlWriterSettings
            MySettings.Indent = True
            MySettings.ConformanceLevel = ConformanceLevel.Auto
            MySettings.IndentChars = "    "

            MySettings.NewLineOnAttributes = False
            MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")


            MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & "\payh_" & MFI_CODE & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml", MySettings)

            'Check if FEHLANZEIGE or REPORT
            QueryText = "SELECT TOP 1 ID FROM [ZVSTAT_Reporting] where [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and PositionName not in ('FEHLANZEIGE')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                With MyWriter
                    'XML HEADER
                    .WriteStartDocument(True)
                    .WriteStartElement("message", "StructureSpecificData", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                    .WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message SDMXMessage.xsd http://www.bundesbank.de/statistik/pay/rs/v1 BBK_PAY_V1.0-SDMX.xsd")
                    .WriteAttributeString("xmlns", "data", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/structurespecific")
                    .WriteAttributeString("xmlns", "common", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/common")
                    .WriteAttributeString("xmlns", "PAY", Nothing, "http://www.bundesbank.de/statistik/pay/rs/v1")
                    '.WriteAttributeString("version", "1.0")
                    '.WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")
                    '.WriteAttributeString("stufe", "Produktion")
                    '.WriteAttributeString("bereich", "Statistik")


                    'ELEMENT-HEADER
                    .WriteStartElement("message", "Header", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteAttributeString("xsi", "type", Nothing, "message:StructureSpecificDataHeaderType")
                    .WriteElementString("message", "ID", Nothing, XMLMESSAGEID)
                    .WriteElementString("message", "Test", Nothing, XMLTESTFILE)
                    .WriteElementString("message", "Prepared", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "+01:00")
                    'Element-Sender
                    .WriteStartElement("message", "Sender", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteAttributeString("id", MFI_CODE)
                    'Unterelement - Contact
                    .WriteStartElement("message", "Contact", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteElementString("common", "Name", Nothing, ABSENDERVORNAME & " " & ABSENDERZUNAME)
                    .WriteElementString("message", "Email", Nothing, "Payments@vtb.eu")
                    .WriteElementString("message", "Telephone", Nothing, ABSENDERTELEFON)
                    .WriteEndElement() 'Contact
                    .WriteEndElement() 'Sender
                    '##############################
                    'Structure BBK_PAY_HDR_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_PAY_HDR_C")
                    .WriteAttributeString("namespace", "BBK_PAY_HDR_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_PAY_HDR_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_ACCNTS_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_ACCNTS_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_ACCNTS_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_ACCNTS_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_PYMNT_CRDS_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_PYMNT_CRDS_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_PYMNT_CRDS_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_PYMNT_CRDS_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_TRMNLS_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_TRMNLS_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_TRMNLS_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_TRMNLS_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_INSTRMNTS_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_INSTRMNTS_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_INSTRMNTS_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_INSTRMNTS_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_CRDS_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_CRDS_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_CRDS_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_CRDS_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_INSTRMNTS_FRD_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_INSTRMNTS_FRD_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_INSTRMNTS_FRD_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_INSTRMNTS_FRD_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_CRDS_FRD_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_CRDS_FRD_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_CRDS_FRD_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_CRDS_FRD_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    'Structure BBK_TRNSCTNS_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_TRNSCTNS_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteAttributeString("namespace", "BBK_TRNSCTNS_C")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_TRNSCTNS_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    '##############################
                    .WriteEndElement() 'End ELEMENT HEADER
                    '##############################
                    'Dataset BBK_PAY_HDR_C
                    .WriteStartElement("message", "DataSet", Nothing)
                    .WriteAttributeString("data", "structureRef", Nothing, "BBK_PAY_HDR_C")
                    .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_PAY_HDR_C")
                    .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                    .WriteStartElement(Nothing, "Obs", Nothing)
                    .WriteAttributeString("RPRTNG_AGNT_CD", MFI_CODE)
                    .WriteAttributeString("DT_RFRNC", XMLMELDETERMIN)
                    .WriteAttributeString("APPLCTN", "PAY")
                    .WriteAttributeString("SRVY_ID", "PAY_H")
                    .WriteAttributeString("SBMSSN_TYP", "FULL_REPLACEMENT")
                    .WriteEndElement() 'obs
                    .WriteEndElement() 'message DataSet
                    '##############################

                    'FORMULAR ZVS1+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS1' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS1_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_ACCNTS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_ACCNTS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("AREA", dt.Rows.Item(i).Item("LandCode").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_ACCNTS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_ACCNTS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement() 'message DataSet
                    End If

                    'FORMULAR ZVS2+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS2' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS2_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_PYMNT_CRDS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_PYMNT_CRDS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("AREA", dt.Rows.Item(i).Item("LandCode").ToString)
                            .WriteAttributeString("PYMNT_SCHM", dt.Rows.Item(i).Item("PayCardSystem").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_PYMNT_CRDS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_PYMNT_CRDS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()

                    End If

                    ''FORMULAR ZVS3+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS3' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS3_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_TRMNLS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_TRMNLS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("AREA", dt.Rows.Item(i).Item("LandCode").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_TRMNLS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_TRMNLS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()
                    End If

                    ''FORMULAR ZVS4.1+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS4.1' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS41_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_INSTRMNTS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_INSTRMNTS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("PYMNT_DRCTN", dt.Rows.Item(i).Item("Landkontext").ToString)
                            .WriteAttributeString("AREA", dt.Rows.Item(i).Item("LandCode").ToString)
                            .WriteAttributeString("PYMNT_SCHM", dt.Rows.Item(i).Item("PayCardSystem").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_INSTRMNTS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_INSTRMNTS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()
                    End If

                    ''FORMULAR ZVS4.2+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS4.2' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS42_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_CRDS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_CRDS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("PYMNT_DRCTN", dt.Rows.Item(i).Item("Landkontext").ToString)
                            .WriteAttributeString("AREA_A", dt.Rows.Item(i).Item("LandCode").ToString)
                            .WriteAttributeString("AREA_T", dt.Rows.Item(i).Item("LandCode_T").ToString)
                            .WriteAttributeString("PYMNT_SCHM", dt.Rows.Item(i).Item("PayCardSystem").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_CRDS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_CRDS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()
                    End If

                    ''FORMULAR ZVS5.1+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS5.1' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS51_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_INSTRMNTS_FRD_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_INSTRMNTS_FRD_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("PYMNT_DRCTN", dt.Rows.Item(i).Item("Landkontext").ToString)
                            .WriteAttributeString("AREA", dt.Rows.Item(i).Item("LandCode").ToString)
                            .WriteAttributeString("PYMNT_SCHM", dt.Rows.Item(i).Item("PayCardSystem").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_INSTRMNTS_FRD_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_INSTRMNTS_FRD_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()
                    End If

                    ''FORMULAR ZVS5.2+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS5.2' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS52_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_CRDS_FRD_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_CRDS_FRD_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("PYMNT_DRCTN", dt.Rows.Item(i).Item("Landkontext").ToString)
                            .WriteAttributeString("AREA_A", dt.Rows.Item(i).Item("LandCode").ToString)
                            .WriteAttributeString("AREA_T", dt.Rows.Item(i).Item("LandCode_T").ToString)
                            .WriteAttributeString("PYMNT_SCHM", dt.Rows.Item(i).Item("PayCardSystem").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBBK_CRDS_FRD_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_CRDS_FRD_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()
                    End If

                    ''FORMULAR ZVS6+++++++++++++++++++++
                    QueryText = "SELECT * FROM [ZVSTAT_Reporting] where [FormNr]='ZVS6' and [ReportingPeriod]=" & MeldeJahr & " and [ZVSTA_Schema]='ZVSTA_2022_H' and (SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is NULL) and ([Anzahl_Value]<>0 OR [Wert_Value]<>0)"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 AndAlso Me.ZVS6_CheckEdit.CheckState = CheckState.Checked Then
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_TRNSCTNS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_TRNSCTNS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("PSTN", dt.Rows.Item(i).Item("PositionNr").ToString)
                            .WriteAttributeString("AREA", dt.Rows.Item(i).Item("LandCode").ToString)
                            If dt.Rows.Item(i).Item("Anzahl").ToString = "Y" Then
                                .WriteAttributeString("NMBR", dt.Rows.Item(i).Item("Anzahl_Value").ToString)
                            End If
                            If dt.Rows.Item(i).Item("Wert").ToString = "Y" Then
                                .WriteAttributeString("VL", Math.Round(dt.Rows.Item(i).Item("Wert_Value"), 2).ToString.Replace(",", "."))
                            End If
                            .WriteEndElement()
                        Next
                        .WriteEndElement()
                    Else
                        .WriteStartElement("message", "DataSet", Nothing)
                        .WriteAttributeString("data", "structureRef", Nothing, "BBK_TRNSCTNS_C")
                        .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_TRNSCTNS_C")
                        .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                        .WriteAttributeString("data", "action", Nothing, "Replace")
                        .WriteFullEndElement()
                    End If

                    '++++++++++++++++++++++++++++++++++
                    .WriteEndDocument()
                    .Close()

                End With

                'FEHLANZEIGE
            ElseIf dt.Rows.Count = 0 Then
                With MyWriter
                    'XML HEADER
                    .WriteStartDocument(True)
                    .WriteStartElement("message", "StructureSpecificData", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                    .WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message SDMXMessage.xsd http://www.bundesbank.de/statistik/pay/rs/v1 BBK_PAY_V1.0-SDMX.xsd")
                    .WriteAttributeString("xmlns", "data", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/structurespecific")
                    .WriteAttributeString("xmlns", "common", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/common")
                    .WriteAttributeString("xmlns", "PAY", Nothing, "http://www.bundesbank.de/statistik/pay/rs/v1")
                    '.WriteAttributeString("version", "1.0")
                    '.WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")
                    '.WriteAttributeString("stufe", "Produktion")
                    '.WriteAttributeString("bereich", "Statistik")


                    'ELEMENT-HEADER
                    .WriteStartElement("message", "Header", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteAttributeString("xsi", "type", Nothing, "message:StructureSpecificDataHeaderType")
                    .WriteElementString("message", "ID", Nothing, XMLMESSAGEID)
                    .WriteElementString("message", "Test", Nothing, XMLTESTFILE)
                    .WriteElementString("message", "Prepared", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "+01:00")
                    'Element-Sender
                    .WriteStartElement("message", "Sender", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteAttributeString("id", MFI_CODE)
                    'Unterelement - Contact
                    .WriteStartElement("message", "Contact", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                    .WriteElementString("common", "Name", Nothing, ABSENDERVORNAME & " " & ABSENDERZUNAME)
                    .WriteElementString("message", "Email", Nothing, "Payments@vtb.eu")
                    .WriteElementString("message", "Telephone", Nothing, ABSENDERTELEFON)
                    .WriteEndElement() 'Contact
                    .WriteEndElement() 'Sender
                    '##############################
                    'Structure BBK_PAY_HDR_C
                    .WriteStartElement("message", "Structure", Nothing)
                    .WriteAttributeString("structureID", "BBK_PAY_HDR_C")
                    .WriteAttributeString("namespace", "BBK_PAY_HDR_C")
                    .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                    .WriteStartElement("common", "Structure", Nothing)
                    .WriteStartElement(Nothing, "Ref", Nothing)
                    .WriteAttributeString("agencyID", "BBK")
                    .WriteAttributeString("id", "BBK_PAY_HDR_C")
                    .WriteEndElement() 'common structure
                    .WriteEndElement() 'Ref
                    .WriteEndElement() 'message Structure
                    .WriteEndElement() 'End Header
                    '##############################
                    '##############################
                    'Dataset BBK_PAY_HDR_C
                    .WriteStartElement("message", "DataSet", Nothing)
                    .WriteAttributeString("data", "structureRef", Nothing, "BBK_PAY_HDR_C")
                    .WriteAttributeString("xsi", "type", Nothing, "PAY:BBK_PAY_HDR_C")
                    .WriteAttributeString("data", "dataScope", Nothing, "DataStructure")
                    .WriteStartElement(Nothing, "Obs", Nothing)
                    .WriteAttributeString("RPRTNG_AGNT_CD", MFI_CODE)
                    .WriteAttributeString("DT_RFRNC", XMLMELDETERMIN)
                    .WriteAttributeString("APPLCTN", "PAY")
                    .WriteAttributeString("SRVY_ID", "PAY_H")
                    .WriteAttributeString("SBMSSN_TYP", "NO_REPORT")
                    .WriteEndElement() 'obs
                    .WriteEndElement() 'message DataSet
                    '##############################
                    '++++++++++++++++++++++++++++++++++
                    .WriteEndDocument()
                    .Close()

                End With


            End If

            SplashScreenManager.Default.SetWaitFormCaption("Set utf-8 to UPPER Case in XML File for reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            Dim xmlfilestring As String = File.ReadAllText(XMLSAVEFILE & "\payh_" & MFI_CODE & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml")
            File.WriteAllText(XMLSAVEFILE & "\payh_" & MFI_CODE & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml", xmlfilestring.Replace("utf-8", "UTF-8"))
            SplashScreenManager.CloseForm(False)


            'VALIDIERUNG DER XML DATEI
            'Dim myDocument As New XmlDocument
            'myDocument.Load(XMLSAVEFILE & "\payh_" & MFI_CODE & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml")
            'myDocument.Schemas.Add("http://www.bundesbank.de/statistik/zvs/v1", ZVSTA2014_XSD)
            'myDocument.Schemas.Add("http://www.bundesbank.de/xmw/2003-01-01", ZVSTA2014_XSD_BASIS)
            'Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
            'myDocument.Validate(eventHandler)

            If MessageBox.Show("Following ZVSTA XML file has being generated: " & vbNewLine & "payh_" & MFI_CODE & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml" & vbNewLine _
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
        Me.ZVS41_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS42_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS51_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS52_CheckEdit.CheckState = CheckState.Checked
        Me.ZVS6_CheckEdit.CheckState = CheckState.Checked
    End Sub

    Private Sub ClearAll_btn_Click(sender As Object, e As EventArgs) Handles ClearAll_btn.Click
        Me.ZVS1_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS2_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS3_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS41_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS42_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS51_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS52_CheckEdit.CheckState = CheckState.Unchecked
        Me.ZVS6_CheckEdit.CheckState = CheckState.Unchecked
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

    Private Sub Fehlanzeige_btn_Click(sender As Object, e As EventArgs)

    End Sub
End Class
