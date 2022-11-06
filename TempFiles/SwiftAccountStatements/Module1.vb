Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Xml 'NEW
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Text
Imports Ionic.Zip
'Imports <xmlns="urn:iso:std:iso:20022:tech:xsd:head.001.001.01"> 'NEW

Module Module1

    'SWIFT Messages Directories and Status for Message Types import
    Dim SWIFT_MESSAGES_IMPORT_DIRECTORY As String = Nothing
    Dim SWIFT_MESSAGES_SAVED_DIRECTORY As String = Nothing
    Dim SWIFT_STATEMENT_IMPORT_STATUS_MT940 As String = Nothing
    Dim SWIFT_STATEMENT_IMPORT_STATUS_MT950 As String = Nothing
    Dim SWIFT_MESSAGE_IMPORT_STATUS_MT191 As String = Nothing
    Dim SWIFT_MESSAGE_IMPORT_STATUS_MT991 As String = Nothing
    Dim SWIFT_STATEMENT_IMPORT_STATUS_RTGS_CAMT053 As String = Nothing
    Dim SWIFT_STATEMENT_IMPORT_STATUS_CBPR_CAMT053 As String = Nothing

    Dim ImportEventsDirectory As String = Nothing
    Dim TextImportFileRow As String = Nothing
    Dim ImportedFileNameDirectory As String = Nothing 'NEW
    Dim GeneralFileName As String = Nothing
    Dim GeneralFileNameDirectory As String = Nothing

    'SWIFT MESSAGE TEXT (without Header and Trailer blocks)
    Dim SwiftMessageText As String = Nothing
    Dim SwiftMessageFormatedText As String = Nothing
    Dim SwiftMessageFileName As String = Nothing
    Dim XML_STATEMENT_FILE As String = Nothing 'NEW

    'SWIFT MESSAGE HEADER
    Dim IndexHeader As Integer
    Dim OSN As Double = 0
    Dim OSN_IncomeDate As String = Nothing
    Dim MessageType As String = Nothing
    Dim RowBic As String = Nothing
    Dim SenderBIC As String = Nothing
    Dim ReceiptDateString As String = Nothing
    Dim ReceiptDate As Date
    Dim ReceiptDateSql As String = Nothing

    'XML READER
    Dim m_xmlr As XmlTextReader 'New
    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode
    Dim XML_NAMESPACE As String = Nothing

    'SWIFT MESSAGE TEXT BODY
    Dim RegexPatern As String = Nothing
    Dim RegexInput As String = Nothing

    Dim RegexSd As Array
    Dim RegexMyIndex As Integer


    Dim arrText() As String
    Dim sLine As String = Nothing

    Dim RestStringforAmount As String = Nothing
    Dim DEBIT_CREDIT_SIGN As String = Nothing
    Dim SignAndFundCode As String = Nothing

    Dim StatementReference As String = Nothing
    Dim AccountIdentification As String = Nothing
    Dim StatementNrPageNr As String = Nothing
    Dim StatementNr As Double = 0
    Dim PageNr As Double = 0

    Dim CreditDebitMarkHeader As String = Nothing
    Dim BookingDateStatementHeader As Date = Nothing
    Dim SQLBookingDateStatementHeader As String = Nothing
    Dim CurrencyStatementHeader As String = Nothing
    Dim AmountStatementHeader As Double = 0

    Dim ValueDateStatemetLine As Date
    Dim SQLValueDateStatemetLine As String = Nothing
    Dim BookingDateStatementLine As Date 'BUCHUNGSDATUM DETAILS
    Dim SQLBookingDateStatementLine As String = Nothing
    Dim CreditDebitMarkStatementLine As String = Nothing 'CREDIT DEBIT MARK
    Dim FundsCode As String = Nothing
    Dim AmountStatementLine As Double = 0 'AMOUNT
    Dim TransactionTypeIdentificationCode As String = Nothing 'Transaction Type Identification Code
    Dim ReferenceForTheAccountOwner As String = Nothing 'Reference for the Account Owner
    Dim ReferenceForTheAccountServicingInstitution As String = Nothing 'Account Servicing Institution's Reference
    Dim SupplementaryDetails As String = Nothing 'Supplementary Details

    'MT191
    Dim MT191_20, MT191_21, MT191_32B_CUR, MT191_71B As String
    Dim MT191_32B_AMT As Double = 0

    'SQL Connection
    Private QueryText As String = ""
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEvent As New SqlConnection
    Dim cmdEvent As New SqlCommand
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable
    Private da3 As New SqlDataAdapter
    Private dt3 As New DataTable

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem
    Private WithEvents ChangeEvent As New EventChanged

    'Dim connSql As New SqlConnection
    'Dim cmdSql As New SqlCommand

    Sub Main()

        'Establish connection with database
          'conn.ConnectionString = "Provider=SQLOLEDB;Data Source=CCB-DB;Integrated Security=SSPI;Initial Catalog=PS TOOL DX Live" FOR OLEDB PROVIDER
        conn.ConnectionString = "server=CCB-PSTOOL-NEW;Integrated Security=SSPI; database=PS TOOL DX Live; Connect timeout=10000"
        'Dim cmd As New OleDbCommand
        cmd.Connection = conn
        cmd.CommandTimeout = 50000

        cmdEvent.Connection = conn
        cmdEvent.CommandTimeout = 50000

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        If cmdEvent.Connection.State = ConnectionState.Closed Then
            cmdEvent.Connection.Open()
        End If

        'Get Directories for the Import
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_Import_Dir' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_MESSAGES_IMPORT_DIRECTORY = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_Saved_Dir' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_MESSAGES_SAVED_DIRECTORY = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_ImportEvents_Dir' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        ImportEventsDirectory = cmd.ExecuteScalar

        'Get Import Status
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_Import_Status_MT940' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_STATEMENT_IMPORT_STATUS_MT940 = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_Import_Status_MT950' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_STATEMENT_IMPORT_STATUS_MT950 = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Message_Import_Status_MT191' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_MESSAGE_IMPORT_STATUS_MT191 = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Message_Import_Status_MT991' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_MESSAGE_IMPORT_STATUS_MT991 = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_Import_Status_RTGS_Camt053_Header001' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_STATEMENT_IMPORT_STATUS_RTGS_CAMT053 = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_Import_Status_CBPR_Camt053_Header002' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
        SWIFT_STATEMENT_IMPORT_STATUS_CBPR_CAMT053 = cmd.ExecuteScalar


        'Check if network is available and SQL Connection is open
        Dim SWIFT_MESSAGES_IMPORT_DIRECTORY_INFO As New System.IO.DirectoryInfo(SWIFT_MESSAGES_IMPORT_DIRECTORY)
        If SWIFT_MESSAGES_IMPORT_DIRECTORY_INFO.Exists AndAlso cmd.Connection.State = ConnectionState.Open Then

            Try

                TextImportFileRow = "Start SWIFT STATEMENTS/CHARGES REQUESTS Import Procedure"
                ChangeEvent.Variable = TextImportFileRow

                Dim txtFiles = Directory.GetFiles(SWIFT_MESSAGES_IMPORT_DIRECTORY, "*HOX", SearchOption.TopDirectoryOnly).[Select](Function(nm) Path.GetFileName(nm))
                Dim arrayList As New System.Collections.ArrayList()
                For Each filenm As String In txtFiles
                    Dim test As FileInfo = New FileInfo(filenm) 'TEST
                    Dim CurrentDateTime As DateTime = Now 'TEST
                    Dim fileCreatedDate As DateTime = File.GetCreationTime(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm) 'TEST

                    'Get SWIFT Filename
                    SwiftMessageFileName = filenm
                    TextImportFileRow = "Importing File :" & filenm & "  " & Now
                    ChangeEvent.Variable = TextImportFileRow
                    'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                    'HEADER BLOCK
                    Dim LinesHeader() As String = IO.File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm)

                    If LinesHeader(0).Trim.StartsWith("{1:") = True AndAlso LinesHeader(0).Contains("{2:O") = True AndAlso Microsoft.VisualBasic.Mid(LinesHeader(0).Trim.ToString, 87, 4) = "{2:O" Then ' Checks if it is an incoming message
                        IndexHeader = LinesHeader(0).IndexOf("{2:O")
                        'Get Fields from HEADER BLOCK
                        OSN = LinesHeader(0).Substring(23, 6).ToString
                        'If LinesHeader(2).Contains("31001520313059200281") = True Then
                        'OSN = LinesHeader(0).Substring(22, 6).ToString  ' special OSN for CCB Shanghai, because the original OSN is alway 1! changed and later deleted!
                        'End If

                        MessageType = LinesHeader(0).Substring(IndexHeader + 4, 3).ToString
                        RowBic = LinesHeader(0).Substring(IndexHeader + 17, 12).ToString
                        SenderBIC = RowBic.Substring(0, 8).ToString & RowBic.Substring(9, 3).ToString
                        ReceiptDateString = LinesHeader(0).Substring(IndexHeader + 11, 6).ToString
                        ReceiptDate = DateSerial(ReceiptDateString.Substring(0, 2), ReceiptDateString.Substring(2, 2), ReceiptDateString.Substring(4, 2))
                        ReceiptDateSql = ReceiptDate.ToString("yyyyMMdd")
                        OSN_IncomeDate = OSN.ToString & ReceiptDateString



                        arrText = File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm)
                        Select Case MessageType
                            Case "940"
                                If SWIFT_STATEMENT_IMPORT_STATUS_MT940 = "Y" Then
                                    MT_STATEMENT_FORMATTED()
                                    MT_STATEMENT_READ_BASIC_INFO()
                                    MT_STATEMENT_CREATE_NEW()
                                    MT_STATEMENT_IMPORT()


                                    My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                        File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    End If
                                    File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)

                                    TextImportFileRow = "File :" & filenm & " imported and renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                    'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                                    'Console.WriteLine(TextImportFileRow)

                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetails.txt")
                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetailsNew.txt")
                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputCorrectNumberFormat.txt")

                                    '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
                                    STORE_IMPORTED_FILE_IN_ZIP()

                                Else
                                    TextImportFileRow = "MT940 File Name: " & SwiftMessageFileName & " not imported! Import Status for SWIFT:MT940 is deactivated on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                End If

                            Case "950"
                                If SWIFT_STATEMENT_IMPORT_STATUS_MT950 = "Y" Then
                                    MT_STATEMENT_FORMATTED()
                                    MT_STATEMENT_READ_BASIC_INFO()
                                    MT_STATEMENT_CREATE_NEW()
                                    MT_STATEMENT_IMPORT()


                                    My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                        File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    End If
                                    File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)

                                    TextImportFileRow = "File :" & filenm & " imported and renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                    'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                                    'Console.WriteLine(TextImportFileRow)

                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetails.txt")
                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetailsNew.txt")
                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputCorrectNumberFormat.txt")

                                    '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
                                    STORE_IMPORTED_FILE_IN_ZIP()
                                Else
                                    TextImportFileRow = "MT950 File Name: " & SwiftMessageFileName & " not imported! Import Status for SWIFT:MT950 is deactivated on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                End If

                            Case "191"
                                If SWIFT_MESSAGE_IMPORT_STATUS_MT191 = "Y" Then
                                    MT191_FORMATTED()
                                    MT191_REPLACE_SWIFT_SIGN()
                                    MT191_IMPORT()

                                    My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                        File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    End If
                                    File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)

                                    TextImportFileRow = "File :" & filenm & " imported and renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                    'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                                    'Console.WriteLine(TextImportFileRow)

                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")

                                    '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
                                    STORE_IMPORTED_FILE_IN_ZIP()
                                Else
                                    TextImportFileRow = "MT191 File Name: " & SwiftMessageFileName & " not imported! Import Status for SWIFT:MT191 is deactivated on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                End If

                            Case "991"
                                If SWIFT_MESSAGE_IMPORT_STATUS_MT991 = "Y" Then
                                    MT191_FORMATTED()
                                    MT191_REPLACE_SWIFT_SIGN()
                                    MT191_IMPORT()

                                    My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                        File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                    End If
                                    File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)

                                    TextImportFileRow = "File :" & filenm & " imported and renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                    'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                                    'Console.WriteLine(TextImportFileRow)

                                    File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")

                                    '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
                                    STORE_IMPORTED_FILE_IN_ZIP()
                                Else
                                    TextImportFileRow = "MT991 File Name: " & SwiftMessageFileName & " not imported! Import Status for SWIFT:MT991 is deactivated on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                End If

                            Case Else
                                'My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                'If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                '    File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                'End If
                                'File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)

                                'TextImportFileRow = "File :" & filenm & " is not MT940/950/191/992 - Renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                'ChangeEvent.Variable = TextImportFileRow
                                ''System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                                ''Console.WriteLine(TextImportFileRow)

                                'File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetails.txt")
                                'File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetailsNew.txt")
                                'File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputCorrectNumberFormat.txt")
                        End Select


                        TextImportFileRow = "End SWIFT STATEMENTS/CHARGES REQUESTS Import Procedure"
                        ChangeEvent.Variable = TextImportFileRow


                        'Else 'File allready imported

                        '    My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                        '    If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                        '        File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                        '    End If
                        '    File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)

                        '    TextImportFileRow = "File :" & filenm & " allready imported to PS TOOL Database - Table:SWIFT_ACC_STATEMENTS " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                        '    ChangeEvent.Variable = TextImportFileRow
                        '    'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
                        '    'Console.WriteLine(TextImportFileRow)



                    End If

                Next


                'CAMT.053 XML STATEMENTS IMPORT
                Dim XmlFiles = Directory.GetFiles(SWIFT_MESSAGES_IMPORT_DIRECTORY, "*.xml", SearchOption.TopDirectoryOnly).[Select](Function(nm) Path.GetFileName(nm))
                Dim XMLarrayList As New System.Collections.ArrayList()
                For Each filenm As String In XmlFiles
                    Dim test As FileInfo = New FileInfo(filenm) 'TEST
                    Dim CurrentDateTime As DateTime = Now 'TEST
                    Dim fileCreatedDate As DateTime = File.GetCreationTime(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm) 'TEST

                    'Get SWIFT Filename
                    SwiftMessageFileName = filenm
                    TextImportFileRow = "Reading File :" & filenm & "  " & Now
                    ChangeEvent.Variable = TextImportFileRow
                    XML_STATEMENT_FILE = SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm

                    Dim sSource As String = File.ReadAllText(XML_STATEMENT_FILE) 'XML FILE that is being searched
                    'XML HEADER
                    Dim sDelimStart As String = "<AppHdr" 'First delimiting word
                    Dim sDelimEnd As String = "</AppHdr>" 'Second delimiting word
                    Dim nIndexStart As Integer = sSource.IndexOf(sDelimStart) 'Find the first occurrence of f1
                    Dim nIndexEnd As Integer = sSource.IndexOf(sDelimEnd) 'Find the first occurrence of f2
                    Dim XmlFileHeader As String = Nothing
                    'XML DOCUMENT
                    Dim DocDelimStart As String = "<BkToCstmrStmt>" 'First delimiting word
                    Dim DocDelimEnd As String = "</BkToCstmrStmt>" 'Second delimiting word
                    Dim DocIndexStart As Integer = sSource.IndexOf(DocDelimStart) 'Find the first occurrence of f1
                    Dim DocIndexEnd As Integer = sSource.IndexOf(DocDelimEnd) 'Find the first occurrence of f2
                    Dim XmlFileDocument As String = Nothing

                    If nIndexStart > -1 AndAlso nIndexEnd > -1 AndAlso DocIndexStart > -1 AndAlso DocIndexEnd > -1 Then '-1 means the word was not found.
                        XmlFileHeader = sDelimStart & "  " & Strings.Mid(sSource, nIndexStart + sDelimStart.Length + 1, nIndexEnd - nIndexStart - sDelimStart.Length) & "  " & sDelimEnd 'Crop the text between
                        XmlFileDocument = DocDelimStart & "  " & Strings.Mid(sSource, DocIndexStart + DocDelimStart.Length + 1, DocIndexEnd - DocIndexStart - DocDelimStart.Length) & "  " & DocDelimEnd

                        Dim XX As New Xml.XmlDocument()


                        XX.LoadXml(XmlFileHeader)
                        Dim NS As New Xml.XmlNamespaceManager(XX.NameTable)
                        NS.AddNamespace("sd", XX.DocumentElement.Attributes("xmlns").InnerText)
                        'NS.AddNamespace("sd", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
                        For Each node As XmlNode In XX.SelectNodes("/sd:AppHdr", NS)

                            XML_NAMESPACE = XX.DocumentElement.Attributes("xmlns").InnerText
                            MessageType = node.SelectSingleNode("sd:MsgDefIdr", NS).InnerText
                            OSN = node.SelectSingleNode("sd:BizMsgIdr", NS).InnerText
                            SenderBIC = node.SelectSingleNode("sd:Fr/sd:FIId/sd:FinInstnId/sd:BICFI", NS).InnerText
                            ReceiptDateString = node.SelectSingleNode("sd:CreDt", NS).InnerText
                            ReceiptDate = Date.Parse(Left(node.SelectSingleNode("sd:CreDt", NS).InnerText, 10))
                            ReceiptDateSql = ReceiptDate.ToString("yyyyMMdd")
                            OSN_IncomeDate = LTrim(RTrim(CStr(OSN).ToString & "_" & ReceiptDateString))

                            'MsgBox("MessageType:" & MessageType & vbLf &
                            '       "Header Namespace:" & XML_NAMESPACE & vbLf &
                            '       "OSN:" & OSN & vbLf &
                            '       "SenderBIC:" & SenderBIC & vbLf &
                            '       "ReceiptDateString:" & ReceiptDateString & vbLf &
                            '       "ReceiptDate:" & ReceiptDate & vbLf &
                            '       "ReceiptDateSql:" & ReceiptDateSql & vbLf &
                            '       "OSN_IncomeDate:" & OSN_IncomeDate)

                        Next

                        'Read XML HEADER (works if xmlns is imported hard coded
                        'Dim xDocHeader = XDocument.Parse(XmlFileHeader)
                        'For Each x In xDocHeader.<AppHdr>
                        '    MessageType = x.<MsgDefIdr>.Value.ToString
                        '    OSN = x.<BizMsgIdr>.Value.ToString
                        '    SenderBIC = x.<Fr>.<FIId>.<FinInstnId>.<BICFI>.Value.ToString
                        '    ReceiptDateString = x.<CreDt>.Value.ToString
                        '    ReceiptDate = Date.Parse(Left(x.<CreDt>.Value, 10))
                        '    ReceiptDateSql = ReceiptDate.ToString("yyyyMMdd")
                        '    OSN_IncomeDate = LTrim(RTrim(CStr(OSN).ToString & "_" & ReceiptDateString))
                        'Next
                        'Read XML Document
                        Dim xDocDocument As New XmlDocument()
                        xDocDocument.LoadXml(XmlFileDocument)
                        If XML_NAMESPACE = "urn:iso:std:iso:20022:tech:xsd:head.001.001.01" Then
                            PageNr = xDocDocument.SelectSingleNode("/BkToCstmrStmt/GrpHdr/MsgPgntn/PgNb").InnerText
                            StatementNr = xDocDocument.SelectSingleNode("/BkToCstmrStmt/Stmt/Id").InnerText
                            AccountIdentification = xDocDocument.SelectSingleNode("/BkToCstmrStmt/Stmt/Acct/Id/Othr/Id").InnerText
                        ElseIf XML_NAMESPACE = "urn:iso:std:iso:20022:tech:xsd:head.001.001.02" Then
                            PageNr = xDocDocument.SelectSingleNode("/BkToCstmrStmt/Stmt/StmtPgntn/PgNb").InnerText
                            StatementNr = xDocDocument.SelectSingleNode("/BkToCstmrStmt/Stmt/Id").InnerText
                            If xDocDocument.GetElementsByTagName("/BkToCstmrStmt/Stmt/Acct/Id/Othr/Id").Count > 0 Then
                                AccountIdentification = xDocDocument.SelectSingleNode("/BkToCstmrStmt/Stmt/Acct/Id/Othr/Id").InnerText
                            Else
                                AccountIdentification = xDocDocument.SelectSingleNode("/BkToCstmrStmt/Stmt/Acct/Id/IBAN").InnerText
                            End If
                        End If


                        'MsgBox("MessageType:" & MessageType & vbLf &
                        '       "OSN:" & OSN & vbLf &
                        '       "SenderBIC:" & SenderBIC & vbLf &
                        '       "ReceiptDateString:" & ReceiptDateString & vbLf &
                        '       "ReceiptDate:" & ReceiptDate & vbLf &
                        '       "ReceiptDateSql:" & ReceiptDateSql & vbLf &
                        '       "OSN_IncomeDate:" & OSN_IncomeDate & vbLf &
                        '       "PageNr:" & PageNr & vbLf &
                        '       "StatementNr:" & StatementNr & vbLf &
                        '       "AccountIdentification:" & AccountIdentification)

                        Select Case MessageType
                            Case "camt.053.001.08"
                                TextImportFileRow = "Recognized Message Type :" & MessageType & "  " & Now
                                ChangeEvent.Variable = TextImportFileRow
                                If XML_NAMESPACE = "urn:iso:std:iso:20022:tech:xsd:head.001.001.01" Then
                                    If SWIFT_STATEMENT_IMPORT_STATUS_RTGS_CAMT053 = "Y" Then
                                        TextImportFileRow = "Recognized XML Namespace :" & XML_NAMESPACE & "  " & Now
                                        ChangeEvent.Variable = TextImportFileRow
                                        TextImportFileRow = "Executing Import Script: CAMT_053_001_08_IMPORT_HEAD_001_001_01" & "  " & Now
                                        ChangeEvent.Variable = TextImportFileRow
                                        CAMT_053_001_08_IMPORT_HEAD_001_001_01()
                                        'Check if camt Message imported into Database
                                        cmd.CommandText = "Select [ID] from [SWIFT_ACC_STATEMENTS] where [OSN_ReceivedDate]='" & OSN_IncomeDate & "' and SenderBIC='" & SenderBIC & "' and [AccountIdentification]='" & AccountIdentification & "' and [StatementNr]='" & StatementNr & " ' and [PageNr]='" & PageNr & "'"
                                        If IsNothing(cmd.ExecuteScalar) = False Then
                                            TextImportFileRow = "XML File:" & SwiftMessageFileName & " successfully imported into Database"
                                            ChangeEvent.Variable = TextImportFileRow
                                        End If

                                        My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                        If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                            File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                        End If
                                        File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                        TextImportFileRow = "File :" & filenm & " imported and renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                        ChangeEvent.Variable = TextImportFileRow

                                        '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
                                        STORE_IMPORTED_FILE_IN_ZIP()
                                    Else
                                        TextImportFileRow = "RTGS camt.053 File Name: " & SwiftMessageFileName & " not imported! Import Status for RTGS camt.053 is deactivated on " & Now
                                        ChangeEvent.Variable = TextImportFileRow
                                    End If

                                ElseIf XML_NAMESPACE = "urn:iso:std:iso:20022:tech:xsd:head.001.001.02" Then
                                    If SWIFT_STATEMENT_IMPORT_STATUS_CBPR_CAMT053 = "Y" Then
                                        TextImportFileRow = "Recognized XML Namespace :" & XML_NAMESPACE & "  " & Now
                                        ChangeEvent.Variable = TextImportFileRow
                                        TextImportFileRow = "Executing Import Script: CAMT_053_001_08_IMPORT_HEAD_001_001_02" & "  " & Now
                                        ChangeEvent.Variable = TextImportFileRow
                                        CAMT_053_001_08_IMPORT_HEAD_001_001_02()
                                        'Check if camt Message imported into Database
                                        cmd.CommandText = "Select [ID] from [SWIFT_ACC_STATEMENTS] where [OSN_ReceivedDate]='" & OSN_IncomeDate & "' and SenderBIC='" & SenderBIC & "' and [AccountIdentification]='" & AccountIdentification & "' and [StatementNr]='" & StatementNr & " ' and [PageNr]='" & PageNr & "'"
                                        If IsNothing(cmd.ExecuteScalar) = False Then
                                            TextImportFileRow = "XML File:" & SwiftMessageFileName & " successfully imported into Database"
                                            ChangeEvent.Variable = TextImportFileRow
                                        End If

                                        My.Computer.FileSystem.RenameFile(SWIFT_MESSAGES_IMPORT_DIRECTORY & filenm, SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                        If File.Exists(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) = True Then
                                            File.Delete(SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                        End If
                                        File.Move(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC, SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                                        TextImportFileRow = "File :" & filenm & " imported and renamed: " & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC & " on " & Now
                                        ChangeEvent.Variable = TextImportFileRow

                                        '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
                                        STORE_IMPORTED_FILE_IN_ZIP()
                                    Else
                                        TextImportFileRow = "CBPR camt.053 File Name: " & SwiftMessageFileName & " not imported! Import Status for CBPR camt.053 is deactivated on " & Now
                                        ChangeEvent.Variable = TextImportFileRow
                                    End If

                                Else
                                    'MsgBox("XML Header Namespace: " & XML_NAMESPACE & " not regognized for import!!!" & vbNewLine & "Unable to read and import the XML File")
                                    TextImportFileRow = "XML Header Namespace: " & XML_NAMESPACE & " not regognized for import!!!" & vbNewLine & "Unable to read and import the XML File: " & SwiftMessageFileName & " on " & Now
                                    ChangeEvent.Variable = TextImportFileRow
                                End If


                            Case Else
                                'MsgBox("XML MessageType not regognized!!!" & vbNewLine & "Unable to read and import the XML File")
                                TextImportFileRow = "XML MessageType not regognized!!!" & vbNewLine & "Unable to read and import the XML File: " & SwiftMessageFileName & " on " & Now
                                ChangeEvent.Variable = TextImportFileRow


                        End Select

                    Else
                        'MsgBox("Could not read the XML File")
                        TextImportFileRow = "Could not read the XML File: " & SwiftMessageFileName & " on " & Now
                        ChangeEvent.Variable = TextImportFileRow
                    End If

                    TextImportFileRow = "End XML SWIFT STATEMENTS Import Procedure"
                    ChangeEvent.Variable = TextImportFileRow

                Next

                'Dim [set] = New HashSet(Of String) From {".QC3", ".QD8"}
                'Dim SepaFiles = Directory.GetFiles(SWIFT_MESSAGES_IMPORT_DIRECTORY, "*.*", SearchOption.AllDirectories).Where(Function(f) [set].Contains(New FileInfo(f).Extension, StringComparer.OrdinalIgnoreCase))


                cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT], A.[Nostro_Name]=B.[NOSTRO_NAME] from [SWIFT_ACC_STATEMENTS] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
                cmd.ExecuteNonQuery()



            Catch ex As System.Exception
                MsgBox(ex.Message)
                TextImportFileRow = ex.Message.ToString & " on " & Now
                ChangeEvent.Variable = TextImportFileRow
                'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

            End Try
        Else
            Exit Sub
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        If cmdEvent.Connection.State = ConnectionState.Open Then
            cmdEvent.Connection.Close()
        End If
    End Sub

    Private Sub STORE_IMPORTED_FILE_IN_ZIP()
        '++++++++STORE IMPORTED FILE IN ZIP++++++++++++++++
        'Get Year from SwiftMessageFileName
        ImportedFileNameDirectory = SWIFT_MESSAGES_SAVED_DIRECTORY & SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC
        GeneralFileName = Left(ReceiptDateSql, 4)
        GeneralFileNameDirectory = SWIFT_MESSAGES_SAVED_DIRECTORY & GeneralFileName & ".zip"
        If File.Exists(GeneralFileNameDirectory) = True Then
            Using zip As ZipFile = ZipFile.Read(GeneralFileNameDirectory)
                If zip.ContainsEntry(SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC) Then
                    zip.RemoveEntry(SwiftMessageFileName & "_" & MessageType & "_" & OSN & "_" & SenderBIC)
                    zip.Save(GeneralFileNameDirectory)
                End If
                zip.AddFile(ImportedFileNameDirectory, "")
                zip.Save(GeneralFileNameDirectory)
                File.Delete(ImportedFileNameDirectory)
            End Using
        Else
            Using zip As New ZipFile
                zip.AddFile(ImportedFileNameDirectory, "")
                zip.Save(GeneralFileNameDirectory)
                File.Delete(ImportedFileNameDirectory)
            End Using
        End If
    End Sub

    Public Function SplitString(ByVal strText As String, _
 ByVal strChars As String, ByVal Mode As Integer) As String

        ' String in zwei Teile splitten
        ' und entweder linken Teil (Mode = 1)
        ' oder rechten Teil (Mode = 2) zurückgeben

        Dim sPos As Long

        sPos = InStr(strText, strChars)
        If sPos > 0 Then
            ' strChars ist in strText enthalten
            If Mode = 1 Then
                ' linke Teilstring zurückgeben
                SplitString = Microsoft.VisualBasic.Left(strText, sPos - 1)


            Else
                ' rechten Teilstring zurückgeben
                SplitString = Mid$(strText, sPos + Len(strChars))
            End If
        Else
            ' strChars ist in strText nicht enthalten
            SplitString = ""
        End If
    End Function

    'MT940/MT950

    Private Sub MT_STATEMENT_FORMATTED()
        'Temporary SWIFT MessageCorrectNumberFormat

        Using objWriter As StreamWriter = New StreamWriter(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputCorrectNumberFormat.txt")
            For I As Integer = 1 To arrText.Length - 2
                If (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",N", ",00N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",0N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",0N", ",00N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",1N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",1N", ",10N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",2N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",2N", ",20N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",3N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",3N", ",30N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",4N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",4N", ",40N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",5N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",5N", ",50N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",6N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",6N", ",60N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",7N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",7N", ",70N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",8N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",8N", ",80N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",9N")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",9N", ",90N"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",S", ",00S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",0S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",0S", ",00S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",1S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",1S", ",10S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",2S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",2S", ",20S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",3S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",3S", ",30S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",4S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",4S", ",40S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",5S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",5S", ",50S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",6S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",6S", ",60S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",7S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",7S", ",70S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",8S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",8S", ",80S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",9S")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",9S", ",90S"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",F", ",00F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",0F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",0F", ",00F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",1F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",1F", ",10F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",2F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",2F", ",20F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",3F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",3F", ",30F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",4F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",4F", ",40F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",5F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",5F", ",50F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",6F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",6F", ",60F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",7F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",7F", ",70F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",8F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",8F", ",80F"))
                ElseIf (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I).Contains(",9F")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(",9F", ",90F"))
                Else
                    objWriter.WriteLine(arrText(I))
                End If
            Next
        End Using
    End Sub

    Private Sub MT_STATEMENT_READ_BASIC_INFO()
        RegexPatern = ":"  'Split on ':'  :[0-9]{2}: 
        Dim RegexInput As String = IO.File.ReadAllText(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputCorrectNumberFormat.txt")
        Dim RegexSubstrings() As String = Regex.Split(RegexInput, RegexPatern)
        Dim RegexArrList As New List(Of String)
        'Define Strings
        Dim myString20 As String = "20"
        Dim myString25 As String = "25"
        Dim myString28 As String = "28C"
        RegexSd = RegexSubstrings.ToArray
        RegexMyIndex = Array.IndexOf(RegexSd, myString20)
        StatementReference = (RegexSd((RegexMyIndex + 1)))
        RegexMyIndex = Array.IndexOf(RegexSd, myString25)
        AccountIdentification = (RegexSd((RegexMyIndex + 1)))
        RegexMyIndex = Array.IndexOf(RegexSd, myString28)
        StatementNrPageNr = (RegexSd((RegexMyIndex + 1)))
        'MsgBox(StatementNrPageNr)
        If StatementNrPageNr.Contains("/") = True Then
            StatementNr = CDbl(SplitString(StatementNrPageNr, "/", 1).ToString())
            PageNr = CDbl(SplitString(StatementNrPageNr, "/", 2).ToString())
        ElseIf StatementNrPageNr.Contains("/") = False Then
            StatementNr = CDbl(StatementNrPageNr.ToString())
            PageNr = 0
        End If

        'MsgBox(StatementNr & " " & PageNr)

    End Sub

    Private Sub MT_STATEMENT_CREATE_NEW()
        arrText = File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputCorrectNumberFormat.txt")
        Using objWriter As StreamWriter = New StreamWriter(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetails.txt")
            For I As Integer = 0 To arrText.Length - 1
                If (arrText(I).StartsWith(":61:")) = True AndAlso (arrText(I + 1).StartsWith(":")) = False Then

                    objWriter.WriteLine(arrText(I) & " ~ " & arrText(I + 1))
                Else
                    objWriter.WriteLine(arrText(I))

                End If

            Next
        End Using
        arrText = File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetails.txt")
        Using objWriter As StreamWriter = New StreamWriter(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetailsNew.txt")
            For I As Integer = 0 To arrText.Length - 1
                If (arrText(I).StartsWith(":")) = True AndAlso (arrText(I).StartsWith(":86:")) = False Then

                    objWriter.WriteLine(arrText(I))

                End If

            Next
        End Using
    End Sub

    Private Sub MT_STATEMENT_IMPORT()

        'Check first if Message has allready imported to Database
        ' add by Yu, to check the duplication, besides OSN and Statement Nr, but also [AccountIdentification]='" & AccountIdentification &
        cmd.CommandText = "Select [ID] from [SWIFT_ACC_STATEMENTS] where [OSN_ReceivedDate]='" & OSN_IncomeDate & "' and SenderBIC='" & SenderBIC & "' and [AccountIdentification]='" & AccountIdentification & "' and [StatementNr]='" & StatementNr & " ' and [PageNr]='" & PageNr & "'"
        If IsNothing(cmd.ExecuteScalar) = True Then

            arrText = File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & "TemporaryOutputAllDetailsNew.txt")
            For I As Integer = 0 To arrText.Length - 1

                If (arrText(I).ToString.StartsWith(":60F:")) = True Then
                    CreditDebitMarkHeader = Mid$(arrText(I).ToString, 6, 1)
                    BookingDateStatementHeader = DateSerial(Mid$(arrText(I).ToString, 7, 2), Mid$(arrText(I).ToString, 9, 2), Mid$(arrText(I).ToString, 11, 2))
                    SQLBookingDateStatementHeader = BookingDateStatementHeader.ToString("yyyyMMdd")
                    CurrencyStatementHeader = Mid$(arrText(I).ToString, 13, 3)
                    AmountStatementHeader = RTrim(LTrim(Mid$(arrText(I).ToString, 16, 15)))
                    'MsgBox("Credit Debit Mark:" & CreditDebitMarkHeader & vbNewLine _
                    ' & "Booking Date:" & BookingDateStatementHeader & vbNewLine _
                    '& "Amount:" & AmountStatementHeader & vbNewLine _
                    '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                    '& "StatementNr.:" & StatementNr & vbNewLine _
                    '& "Page Nr:" & PageNr)
                    'Insert in SWIFT ACCOUNT STATEMENTS
                    cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[BookingDate],[CUR],[Amount]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','60F','Opening Balance','" & CreditDebitMarkHeader & "','" & SQLBookingDateStatementHeader & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementHeader) & "')"
                    cmd.ExecuteNonQuery()
                End If

                If (arrText(I).ToString.StartsWith(":60M:")) = True Then
                    CreditDebitMarkHeader = Mid$(arrText(I).ToString, 6, 1)
                    BookingDateStatementHeader = DateSerial(Mid$(arrText(I).ToString, 7, 2), Mid$(arrText(I).ToString, 9, 2), Mid$(arrText(I).ToString, 11, 2))
                    SQLBookingDateStatementHeader = BookingDateStatementHeader.ToString("yyyyMMdd")
                    CurrencyStatementHeader = Mid$(arrText(I).ToString, 13, 3)
                    AmountStatementHeader = RTrim(LTrim(Mid$(arrText(I).ToString, 16, 15)))
                    'MsgBox("Credit Debit Mark:" & CreditDebitMarkHeader & vbNewLine _
                    '& "Booking Date:" & BookingDateStatementHeader & vbNewLine _
                    '& "Amount:" & AmountStatementHeader & vbNewLine _
                    '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                    '& "StatementNr.:" & StatementNr & vbNewLine _
                    '& "Page Nr:" & PageNr)
                    'Insert in SWIFT ACCOUNT STATEMENTS
                    cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[BookingDate],[CUR],[Amount]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','60M','Intermediate Opening Balance','" & CreditDebitMarkHeader & "','" & SQLBookingDateStatementHeader & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementHeader) & "')"
                    cmd.ExecuteNonQuery()


                End If

                If (arrText(I).ToString.StartsWith(":61:")) = True Then
                    'Value Date
                    ValueDateStatemetLine = DateSerial(Left(SplitString(arrText(I), ":61:", 2).ToString, 2), Mid$(SplitString(arrText(I), ":61:", 2).ToString, 3, 2), Mid$(SplitString(arrText(I), ":61:", 2).ToString, 5, 2))
                    SQLValueDateStatemetLine = ValueDateStatemetLine.ToString("yyyyMMdd")
                    'Booking Date
                    'Check if bookingDate exists
                    If IsNumeric(Left(SplitString(arrText(I), ":61:", 2).ToString, 7)) = True Then 'HAS BOOKING DATE
                        BookingDateStatementLine = DateSerial(ReceiptDate.Year, Mid$(SplitString(arrText(I), ":61:", 2).ToString, 7, 2), Mid$(SplitString(arrText(I), ":61:", 2).ToString, 9, 2))
                        SQLBookingDateStatementLine = BookingDateStatementLine.ToString("yyyyMMdd")
                        'Check if Debit_Credit Mark is 1 or 2 Letters
                        DEBIT_CREDIT_SIGN = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 11, 1)
                        'MsgBox(DEBIT_CREDIT_SIGN)
                        Select Case DEBIT_CREDIT_SIGN
                            Case Is = "C"
                                CreditDebitMarkStatementLine = DEBIT_CREDIT_SIGN
                                'Check if there's a FundsCode
                                If IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 12, 1)) = False Then 'Funds Code present
                                    FundsCode = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 12, 1)
                                    'MsgBox(FundsCode)
                                    RestStringforAmount = SplitString(arrText(I), FundsCode, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                ElseIf IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 12, 1)) = True Then 'Funds Code not present
                                    FundsCode = Nothing
                                    RestStringforAmount = SplitString(arrText(I), DEBIT_CREDIT_SIGN, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                End If
                            Case Is = "D"
                                CreditDebitMarkStatementLine = DEBIT_CREDIT_SIGN
                                'Check if there's a FundsCode
                                If IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 12, 1)) = False Then 'Funds Code present
                                    FundsCode = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 12, 1)
                                    'MsgBox(FundsCode)
                                    SignAndFundCode = Mid$(arrText(I).ToString, 15, 2)
                                    RestStringforAmount = SplitString(arrText(I), SignAndFundCode, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                ElseIf IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 12, 1)) = True Then 'Funds Code not present
                                    FundsCode = Nothing
                                    RestStringforAmount = SplitString(arrText(I), DEBIT_CREDIT_SIGN, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                End If
                            Case "R"
                                CreditDebitMarkStatementLine = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 11, 2)
                                'Check if there's a FundsCode
                                If IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 13, 1)) = False Then 'Funds Code present
                                    FundsCode = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 13, 1)
                                    'MsgBox(FundsCode)
                                    SignAndFundCode = Mid$(arrText(I).ToString, 15, 3)
                                    RestStringforAmount = SplitString(arrText(I), SignAndFundCode, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                ElseIf IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 13, 1)) = True Then 'Funds Code not present
                                    FundsCode = Nothing
                                    RestStringforAmount = SplitString(arrText(I), CreditDebitMarkStatementLine, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                End If
                        End Select
                        'MsgBox(SignAndFundCode & " - " & RestStringforAmount & " - " & AmountStatementLine & " - " & CreditDebitMarkStatementLine)


                        TransactionTypeIdentificationCode = Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 3, 4)
                        ReferenceForTheAccountOwner = SplitString(Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 7), "//", 1)

                        Dim SplitReferenceDetails As String = SplitString(arrText(I), "//", 2)
                        ReferenceForTheAccountServicingInstitution = SplitString(SplitReferenceDetails, "~", 1)
                        SupplementaryDetails = SplitString(SplitReferenceDetails, "~", 2)

                        'MsgBox("Credit Debit Mark:" & CreditDebitMarkStatementLine & vbNewLine _
                        '& "FundsCode:" & FundsCode & vbNewLine _
                        '& "Value Date:" & ValueDateStatemetLine & vbNewLine _
                        '& "Booking Date:" & BookingDateStatementLine & vbNewLine _
                        '& "Amount:" & AmountStatementLine & vbNewLine _
                        '& "Transaction Type Identification Code: " & TransactionTypeIdentificationCode & vbNewLine _
                        '& "Reference for the Account Owner: " & ReferenceForTheAccountOwner & vbNewLine _
                        '& "Account Servicing Institution's Reference:" & ReferenceForTheAccountServicingInstitution & vbNewLine _
                        '& "Supplementary Details:" & SupplementaryDetails & vbNewLine _
                        '& "StatementReference:" & StatementReference & vbNewLine _
                        '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                        '& "StatementNr.:" & StatementNr & vbNewLine _
                        '& "Page Nr:" & PageNr)


                        'Insert in SWIFT ACCOUNT STATEMENTS
                        cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],TransactionTypeID,[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','61','Booking Entry','" & CreditDebitMarkStatementLine & "','" & FundsCode & "','" & SQLBookingDateStatementLine & "','" & SQLValueDateStatemetLine & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementLine) & "','" & TransactionTypeIdentificationCode & "',@ReferenceAccountOwner,@ReferenceAccountServInstitut,@SupplmentaryDetails)"
                        cmd.Parameters.Add("@ReferenceAccountOwner", SqlDbType.NVarChar).Value = ReferenceForTheAccountOwner
                        cmd.Parameters.Add("@ReferenceAccountServInstitut", SqlDbType.NVarChar).Value = ReferenceForTheAccountServicingInstitution
                        cmd.Parameters.Add("@SupplmentaryDetails", SqlDbType.NVarChar).Value = SupplementaryDetails
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()

                    ElseIf IsNumeric(Left(SplitString(arrText(I), ":61:", 2).ToString, 7)) = False Then 'NO BOOKING DATE
                        'Check if Debit_Credit Mark is 1 or 2 Letters
                        DEBIT_CREDIT_SIGN = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 7, 1)
                        'MsgBox(DEBIT_CREDIT_SIGN)
                        Select Case DEBIT_CREDIT_SIGN
                            Case Is = "C"
                                CreditDebitMarkStatementLine = DEBIT_CREDIT_SIGN
                                'Check if there's a FundsCode
                                If IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)) = False Then 'Funds Code present
                                    FundsCode = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)
                                    'MsgBox(FundsCode)
                                    RestStringforAmount = SplitString(arrText(I), FundsCode, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                ElseIf IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)) = True Then 'Funds Code not present
                                    FundsCode = Nothing
                                    RestStringforAmount = SplitString(arrText(I), DEBIT_CREDIT_SIGN, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                End If
                            Case Is = "D"
                                CreditDebitMarkStatementLine = DEBIT_CREDIT_SIGN
                                'Check if there's a FundsCode
                                If IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)) = False Then 'Funds Code present
                                    FundsCode = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)
                                    'MsgBox(FundsCode)
                                    SignAndFundCode = Mid$(arrText(I).ToString, 11, 2)
                                    RestStringforAmount = SplitString(arrText(I), SignAndFundCode, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                ElseIf IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)) = True Then 'Funds Code not present
                                    FundsCode = Nothing
                                    RestStringforAmount = SplitString(arrText(I), DEBIT_CREDIT_SIGN, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                End If
                            Case "R"
                                CreditDebitMarkStatementLine = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 7, 2)
                                'Check if there's a FundsCode
                                If IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)) = False Then 'Funds Code present
                                    FundsCode = Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)
                                    'MsgBox(FundsCode)
                                    SignAndFundCode = Mid$(arrText(I).ToString, 11, 3)
                                    RestStringforAmount = SplitString(arrText(I), SignAndFundCode, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                ElseIf IsNumeric(Mid$(SplitString(arrText(I), ":61:", 2).ToString, 8, 1)) = True Then 'Funds Code not present
                                    FundsCode = Nothing
                                    RestStringforAmount = SplitString(arrText(I), CreditDebitMarkStatementLine, 2)
                                    AmountStatementLine = SplitString(RestStringforAmount, ",", 1) & "," & Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 1, 2)
                                End If
                        End Select
                        'MsgBox(RestStringforAmount & " " & AmountStatementLine)


                        TransactionTypeIdentificationCode = Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 3, 4)
                        ReferenceForTheAccountOwner = SplitString(Microsoft.VisualBasic.Mid(SplitString(RestStringforAmount, ",", 2), 7), "//", 1)

                        Dim SplitReferenceDetails As String = SplitString(arrText(I), "//", 2)
                        ReferenceForTheAccountServicingInstitution = SplitString(SplitReferenceDetails, "~", 1)
                        SupplementaryDetails = SplitString(SplitReferenceDetails, "~", 2)

                        'Insert in SWIFT ACCOUNT STATEMENTS
                        cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[ValueDate],[CUR],[Amount],TransactionTypeID,[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','61','Booking Entry','" & CreditDebitMarkStatementLine & "','" & FundsCode & "','" & SQLValueDateStatemetLine & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementLine) & "','" & TransactionTypeIdentificationCode & "',@ReferenceAccountOwner,@ReferenceAccountServInstitut,@SupplmentaryDetails)"
                        cmd.Parameters.Add("@ReferenceAccountOwner", SqlDbType.NVarChar).Value = ReferenceForTheAccountOwner
                        cmd.Parameters.Add("@ReferenceAccountServInstitut", SqlDbType.NVarChar).Value = ReferenceForTheAccountServicingInstitution
                        cmd.Parameters.Add("@SupplmentaryDetails", SqlDbType.NVarChar).Value = SupplementaryDetails
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If

                End If

                If (arrText(I).ToString.StartsWith(":62F:")) = True Then
                    CreditDebitMarkHeader = Mid$(arrText(I).ToString, 6, 1)
                    BookingDateStatementHeader = DateSerial(Mid$(arrText(I).ToString, 7, 2), Mid$(arrText(I).ToString, 9, 2), Mid$(arrText(I).ToString, 11, 2))
                    SQLBookingDateStatementHeader = BookingDateStatementHeader.ToString("yyyyMMdd")
                    'CurrencyStatementHeader = Mid$(arrText(I).ToString, 13, 3)
                    AmountStatementHeader = RTrim(LTrim(Mid$(arrText(I).ToString, 16, 15)))
                    'MsgBox("Credit Debit Mark:" & CreditDebitMarkHeader & vbNewLine _
                    '& "Booking Date:" & BookingDateStatementHeader & vbNewLine _
                    '& "Amount:" & AmountStatementHeader & vbNewLine _
                    '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                    '& "StatementNr.:" & StatementNr & vbNewLine _
                    '& "Page Nr:" & PageNr)
                    'Insert in SWIFT ACCOUNT STATEMENTS
                    cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[BookingDate],[CUR],[Amount]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','62F','Clossing Balance (Booked Funds)','" & CreditDebitMarkHeader & "','" & SQLBookingDateStatementHeader & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementHeader) & "')"
                    cmd.ExecuteNonQuery()
                End If
                If (arrText(I).ToString.StartsWith(":62M:")) = True Then
                    CreditDebitMarkHeader = Mid$(arrText(I).ToString, 6, 1)
                    BookingDateStatementHeader = DateSerial(Mid$(arrText(I).ToString, 7, 2), Mid$(arrText(I).ToString, 9, 2), Mid$(arrText(I).ToString, 11, 2))
                    SQLBookingDateStatementHeader = BookingDateStatementHeader.ToString("yyyyMMdd")
                    'CurrencyStatementHeader = Mid$(arrText(I).ToString, 13, 3)
                    AmountStatementHeader = RTrim(LTrim(Mid$(arrText(I).ToString, 16, 15)))
                    'MsgBox("Credit Debit Mark:" & CreditDebitMarkHeader & vbNewLine _
                    '& "Booking Date:" & BookingDateStatementHeader & vbNewLine _
                    '& "Amount:" & AmountStatementHeader & vbNewLine _
                    '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                    '& "StatementNr.:" & StatementNr & vbNewLine _
                    '& "Page Nr:" & PageNr)
                    'Insert in SWIFT ACCOUNT STATEMENTS
                    cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[BookingDate],[CUR],[Amount]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','62M','Intermediate Clossing Balance','" & CreditDebitMarkHeader & "','" & SQLBookingDateStatementHeader & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementHeader) & "')"
                    cmd.ExecuteNonQuery()
                End If
                If (arrText(I).ToString.StartsWith(":64:")) = True Then
                    CreditDebitMarkHeader = Mid$(arrText(I).ToString, 5, 1)
                    BookingDateStatementHeader = DateSerial(Mid$(arrText(I).ToString, 6, 2), Mid$(arrText(I).ToString, 8, 2), Mid$(arrText(I).ToString, 10, 2))
                    SQLBookingDateStatementHeader = BookingDateStatementHeader.ToString("yyyyMMdd")
                    'MsgBox(CurrencyStatementHeader)
                    'CurrencyStatementHeader = Mid$(arrText(I).ToString, 11, 3)
                    AmountStatementHeader = RTrim(LTrim(Mid$(arrText(I).ToString, 15, 15)))
                    'MsgBox("Credit Debit Mark:" & CreditDebitMarkHeader & vbNewLine _
                    '& "Booking Date:" & BookingDateStatementHeader & vbNewLine _
                    '& "Amount:" & AmountStatementHeader & vbNewLine _
                    '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                    '& "StatementNr.:" & StatementNr & vbNewLine _
                    '& "Page Nr:" & PageNr)
                    'Insert in SWIFT ACCOUNT STATEMENTS
                    cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[BookingDate],[CUR],[Amount]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','64','Closing Available Balance (Available Funds)','" & CreditDebitMarkHeader & "','" & SQLBookingDateStatementHeader & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementHeader) & "')"
                    cmd.ExecuteNonQuery()
                End If
                If (arrText(I).ToString.StartsWith(":65:")) = True Then
                    CreditDebitMarkHeader = Mid$(arrText(I).ToString, 5, 1)
                    BookingDateStatementHeader = DateSerial(Mid$(arrText(I).ToString, 6, 2), Mid$(arrText(I).ToString, 8, 2), Mid$(arrText(I).ToString, 10, 2))
                    SQLBookingDateStatementHeader = BookingDateStatementHeader.ToString("yyyyMMdd")
                    'CurrencyStatementHeader = Mid$(arrText(I).ToString, 11, 3)
                    AmountStatementHeader = RTrim(LTrim(Mid$(arrText(I).ToString, 15, 15)))
                    'MsgBox("Credit Debit Mark:" & CreditDebitMarkHeader & vbNewLine _
                    '& "Booking Date:" & BookingDateStatementHeader & vbNewLine _
                    '& "Amount:" & AmountStatementHeader & vbNewLine _
                    '& "AccountIdentification:" & AccountIdentification & vbNewLine _
                    '& "StatementNr.:" & StatementNr & vbNewLine _
                    '& "Page Nr:" & PageNr)
                    'Insert in SWIFT ACCOUNT STATEMENTS
                    cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS] ([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[BookingDate],[CUR],[Amount]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "','" & StatementReference & "','" & AccountIdentification & "','" & Str(StatementNr) & "','" & Str(PageNr) & "','65','Forward Available Balance','" & CreditDebitMarkHeader & "','" & SQLBookingDateStatementHeader & "','" & CurrencyStatementHeader & "','" & Str(AmountStatementHeader) & "')"
                    cmd.ExecuteNonQuery()
                End If
            Next I

        End If



        cmd.CommandText = "UPDATE [SWIFT_ACC_STATEMENTS] SET [Ref20]=REPLACE(REPLACE([Ref20], CHAR(13), ''), CHAR(10), ''),[AccountIdentification]=REPLACE(REPLACE([AccountIdentification], CHAR(13), ''), CHAR(10), '') where [SwiftFileName]='" & SwiftMessageFileName & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [Amount]=[Amount]*(-1) where [DebitCreditMark] in ('D','RC') and [SwiftFileName]='" & SwiftMessageFileName & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "INSERT INTO [SQL_PARAMETER_DETAILS]([SQL_Name_1],[SQL_Name_2],[SQL_Name_3],[SQL_Name_4],[Id_SQL_Parameters])SELECT A.[AccountIdentification],A.CUR, A.SenderBIC,(RTRIM(LTRIM(B.[INSTITUTION NAME]))+ ' , ' + RTRIM(LTRIM(B.[CITY HEADING]))) as 'Institution Name','SWIFT STATEMENTS ACCOUNTS ALL' FROM [SWIFT_ACC_STATEMENTS] A INNER JOIN [BIC DIRECTORY] B on A.SenderBIC=B.BIC11 where A.AccountIdentification not in (Select [SQL_Name_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL') and [SwiftFileName]='" & SwiftMessageFileName & "' GROUP BY [AccountIdentification],A.CUR,SenderBIC,B.[INSTITUTION NAME],B.[CITY HEADING]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [BookingDate]=[ValueDate] where [BookingDate] is NULL and [SwiftFileName]='" & SwiftMessageFileName & "'"
        cmd.ExecuteNonQuery()
        '++++++++++++++++++++++++++
        'Sonderfall - In Years End there's some bug regarding the booking Date
        'If Value Date=31.12.2016 the Booking Date is wrobgly updated to 31.12.2017
        'Therefore the following SQL Command in order to set the Booking Date equal to Value Date if Value Date in (30.12.XXXX,31.12.XXXX)
        cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [BookingDate]=[ValueDate] where convert(varchar(5),[ValueDate],104) in ('30.12','31.12') and [SwiftFileName]='" & SwiftMessageFileName & "'"
        cmd.ExecuteNonQuery()
        '++++++++++++++++++++++++++
        '**************************
        'INSERT NEW BOOKINGS IN NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS
        cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS]([ID_EB],[SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[InternalAccount],[Nostro_Name],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],[TransactionTypeID],[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails])SELECT ID,[SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[InternalAccount],[Nostro_Name],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],[TransactionTypeID],[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails] FROM SWIFT_ACC_STATEMENTS where SwiftTag in ('61') and [SwiftFileName]='" & SwiftMessageFileName & "' and ID not in (Select [ID_EB] from [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT], A.[Nostro_Name]=B.[NOSTRO_NAME] from [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
        cmd.ExecuteNonQuery()
        'INSERT Swift File Name and Statement Nr. with Swift Tag=62F (CLOSING BOOKED BALANCE)
        cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS_CLOSED_BALANCES]([SwiftFileName],[StatementNr],[AccountIdentification],[HasClosingBalance]) SELECT [SwiftFileName],[StatementNr],[AccountIdentification],'Y' FROM [SWIFT_ACC_STATEMENTS] where [SwiftFileName]='" & SwiftMessageFileName & "' and SwiftTag in ('62F')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT] from [SWIFT_ACC_STATEMENTS_CLOSED_BALANCES] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
        cmd.ExecuteNonQuery()
        '+++++++++++++++++++++++++++++++++++++++



    End Sub

    Private Sub CAMT_053_001_08_IMPORT_HEAD_001_001_01()
        'Check first if Message has allready imported to Database (hhhhhh)
        ' add by Yu, to check the duplication, besides OSN and Statement Nr, but also [AccountIdentification]='" & AccountIdentification &
        cmd.CommandText = "Select [ID] from [SWIFT_ACC_STATEMENTS] where [OSN_ReceivedDate]='" & OSN_IncomeDate & "' and SenderBIC='" & SenderBIC & "' and [AccountIdentification]='" & AccountIdentification & "' and [StatementNr]='" & StatementNr & " ' and [PageNr]='" & PageNr & "'"
        If IsNothing(cmd.ExecuteScalar) = True Then
            cmd.CommandText = "DECLARE @XML_FileDir nvarchar(MAX)='" & XML_STATEMENT_FILE & "'
                                DECLARE @XML_FileName nvarchar(MAX)=(SELECT RIGHT(@XML_FileDir, CHARINDEX('\', REVERSE(@XML_FileDir)) - 1))

                                IF OBJECT_ID('tempdb..#Temp_XMLwithOpenXML') IS NULL 
                                CREATE TABLE [#Temp_XMLwithOpenXML]
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,[XMLData] [xml] NULL
                                ,XML_File_Name Nvarchar(MAX) NULL
                                ,[LoadedDateTime] [datetime] NULL) 
                                ON [PRIMARY]
                                else
                                DELETE from [#Temp_XMLwithOpenXML]

                                INSERT INTO #Temp_XMLwithOpenXML
                                (XMLData,XML_File_Name, LoadedDateTime)
                                SELECT CONVERT(XML, BulkColumn) AS BulkColumn, @XML_FileName,GETDATE() 
                                FROM OPENROWSET(BULK  '" & XML_STATEMENT_FILE & "', SINGLE_BLOB) AS x


                                DECLARE @STATEMENT_HEADER_DATA as Table
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,SenderBIC Nvarchar(50) NULL
                                ,ReceiverBIC Nvarchar(50) NULL
                                ,UniqueBusinessMessageIdentifier Nvarchar(50) NULL
                                ,MessageDefinitionIdentification Nvarchar(50) NULL
                                ,MessageCreationDateTimeString Nvarchar(50) NULL
                                ,MessageCreationDateTime Datetime NULL)

                                DECLARE @STATEMENT_BASIC_DATA as Table
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,DataType Nvarchar(50) NULL
                                ,MsgId Nvarchar(50) NULL
                                ,StatementCreationDate Datetime
                                ,PageNumber int
                                ,LastPageIndicator Nvarchar(50) NULL
                                ,StatementID Nvarchar(50) NULL
                                ,AccountID Nvarchar(50) NULL
                                ,AccountOwnerBicCode Nvarchar(50) NULL
                                ,BalanceType Nvarchar(50) NULL
                                ,Currency Nvarchar(50) NULL
                                ,BalanceValue float default(0)
                                ,CreditDebitIndicator Nvarchar(50) NULL
                                ,BalanceDate Datetime
                                ,TransactionsEntriesCount int
                                ,XML_File_Name Nvarchar(MAX) NULL)

                                DECLARE @STATEMENT_DETAILS_DATA as Table
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,DataType Nvarchar(50) NULL
                                ,AccountID Nvarchar(50) NULL
                                ,AccountOwnerBicCode Nvarchar(50) NULL
                                ,EntryReference Nvarchar(50) NULL
                                ,Currency Nvarchar(50) NULL
                                ,EntryAmount float default(0)
                                ,CreditDebitIndicator Nvarchar(50) NULL
                                ,EntryStatus Nvarchar(50) NULL
                                ,BookingDate Datetime
                                ,ValueDate Datetime
                                ,BankTransactionCode Nvarchar(50) NULL
                                ,InstructedID Nvarchar(50) NULL
                                ,EndToEndID Nvarchar(50) NULL
                                ,UETR Nvarchar(50) NULL
                                ,RelatedParty_DebtorAcc Nvarchar(50) NULL
                                ,RelatedParty_CreditorAcc Nvarchar(50) NULL
                                ,RelatedParty_DebtorName Nvarchar(50) NULL
                                ,RelatedParty_DebtorBIC Nvarchar(50) NULL
                                ,RelatedParty_CreditorName Nvarchar(50) NULL
                                ,RelatedParty_CreditorBIC Nvarchar(50) NULL
                                ,RelatedAgent_InstructingAgent Nvarchar(50) NULL
                                ,RelatedAgent_InstructedAgent Nvarchar(50) NULL
                                ,LocalInstrument Nvarchar(50) NULL
                                ,RelatedDetails_InterbankSettlementDate Datetime
                                ,XML_File_Name Nvarchar(MAX) NULL)

                               
                                DECLARE @XML_DATA xml=(SELECT [XMLData]  from [#Temp_XMLwithOpenXML])
                                ;WITH XMLNAMESPACES(DEFAULT 'urn:iso:std:iso:20022:tech:xsd:head.001.001.01')
                                INSERT INTO @STATEMENT_HEADER_DATA
                                (SenderBIC
                                ,ReceiverBIC
                                ,UniqueBusinessMessageIdentifier
                                ,MessageDefinitionIdentification
                                ,MessageCreationDateTimeString
                                ,MessageCreationDateTime)
                                SELECT 
                                'SenderBIC'=CstrStmtHeader.st.value('(Fr/FIId/FinInstnId/BICFI/text())[1]', 'nvarchar(50)') 
                                ,'ReceiverBIC'=CstrStmtHeader.st.value('(To/FIId/FinInstnId/BICFI/text())[1]', 'nvarchar(50)')
                                ,'UniqueBusinessMessageIdentifier'=CstrStmtHeader.st.value('(BizMsgIdr/text())[1]', 'nvarchar(50)') 
                                ,'MessageDefinitionIdentification'=CstrStmtHeader.st.value('(MsgDefIdr/text())[1]', 'nvarchar(50)') 
                                ,'MessageCreationDateTimeString'=CstrStmtHeader.st.value('(CreDt/text())[1]', 'nvarchar(50)')
                                ,'MessageCreationDateTime'=CONVERT(DATETIME,CstrStmtHeader.st.value('(CreDt/text())[1]', 'nvarchar(50)')) 
                                FROM 
                                @XML_DATA.nodes('AppHdr') as CstrStmtHeader(St)

                                DECLARE @SENDER_BIC Nvarchar(50)=CASE WHEN (Select COUNT(SenderBIC) from @STATEMENT_HEADER_DATA)=1 then (Select SenderBIC from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @RECEIVER_BIC Nvarchar(50)=CASE WHEN (Select COUNT(ReceiverBIC) from @STATEMENT_HEADER_DATA)=1 then (Select ReceiverBIC from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @UNIQUE_BUSINESS_MESSAGE_IDENTIFIER Nvarchar(50)=CASE WHEN (Select COUNT(UniqueBusinessMessageIdentifier) from @STATEMENT_HEADER_DATA)=1 Then (Select UniqueBusinessMessageIdentifier from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @MESSAGE_DEFINITION_IDENTIFICATION Nvarchar(50)=CASE WHEN (Select COUNT(MessageDefinitionIdentification) from @STATEMENT_HEADER_DATA)=1 Then (Select MessageDefinitionIdentification from @STATEMENT_HEADER_DATA) Else 'camt.053.001.08' End
                                DECLARE @MESSAGE_CREATION_DATETIME_STRING Nvarchar(50)=CASE WHEN (Select COUNT(MessageCreationDateTimeString) from @STATEMENT_HEADER_DATA)=1 Then (Select MessageCreationDateTimeString from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @MESSAGE_CREATION_DATETIME Datetime=CASE WHEN (Select COUNT(MessageCreationDateTime) from @STATEMENT_HEADER_DATA)=1 Then (Select MessageCreationDateTime from @STATEMENT_HEADER_DATA) Else NULL End

                                ;WITH XMLNAMESPACES(DEFAULT 'urn:iso:std:iso:20022:tech:xsd:camt.053.001.08')
                                INSERT INTO @STATEMENT_BASIC_DATA
                                (DataType
                                ,MsgId
                                ,StatementCreationDate
                                ,PageNumber
                                ,LastPageIndicator
                                ,StatementID
                                ,AccountID
                                ,AccountOwnerBicCode
                                ,BalanceType
                                ,Currency
                                ,BalanceValue
                                ,CreditDebitIndicator
                                ,BalanceDate
                                ,TransactionsEntriesCount
                                ,XML_File_Name)
                                SELECT 
                                'BasicData' as DataType
                                ,'MsgId'=CstrStmt.St.value('(GrpHdr/MsgId/text())[1]', 'nvarchar(50)')
                                ,'StatementCreationDate'=CONVERT(DATETIME, CONVERT(DATE, CstrStmt.St.value('(GrpHdr/CreDtTm/text())[1]', 'Datetime')), 121)  
                                ,'PageNumber'=CstrStmt.St.value('(GrpHdr/MsgPgntn/PgNb/text())[1]', 'int')
                                ,'LastPageIndicator'=CstrStmt.St.value('(GrpHdr/MsgPgntn/LastPgInd/text())[1]', 'nvarchar(50)')
                                ,'StatementID'=Account.Ac.value('(./Id/text())[1]', 'nvarchar(50)')   
                                ,'AccountID'=Account.Ac.value('(Acct/Id/Othr/Id/text())[1]', 'nvarchar(50)') 
                                ,'AccountOwnerBicCode'=Account.Ac.value('(Acct/Ownr/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'BalanceType'=Balance.Bal.value('(./Tp/CdOrPrtry/Cd/text())[1]', 'nvarchar(50)')
                                ,'Currency'=BalanceCcy.Bal.value('./@Ccy', 'nvarchar(3)') 
                                ,'BalanceValue'=Balance.Bal.value('(./Amt/text())[1]', 'float') 
                                ,'CreditDebitIndicator'=Balance.Bal.value('(./CdtDbtInd/text())[1]', 'nvarchar(50)') 
                                ,'BalanceDate'=CONVERT(DATETIME, CONVERT(DATE, Balance.Bal.value('(./Dt/Dt/text())[1]', 'Datetime')), 121) 
                                ,'TransactionsEntriesCount'=BalanceSum.Entries.value('(./TtlNtries/NbOfNtries/text())[1]', 'int')
                                ,@XML_FileName
                                FROM 
                                @XML_DATA.nodes('Document/BkToCstmrStmt') as CstrStmt(St)
                                CROSS APPLY CstrStmt.St.nodes('Stmt') as Account(Ac)
                                CROSS APPLY Account.Ac.nodes('Bal') as Balance(bal)
                                CROSS APPLY Balance.bal.nodes('Amt') as BalanceCcy(Bal)
                                CROSS APPLY Account.Ac.nodes('TxsSummry') as BalanceSum(Entries)

                                ;WITH XMLNAMESPACES(DEFAULT 'urn:iso:std:iso:20022:tech:xsd:camt.053.001.08')
                                INSERT INTO @STATEMENT_DETAILS_DATA
                                (DataType
                                ,AccountID
                                ,AccountOwnerBicCode
                                ,EntryReference 
                                ,Currency 
                                ,EntryAmount 
                                ,CreditDebitIndicator 
                                ,EntryStatus 
                                ,BookingDate 
                                ,ValueDate 
                                ,BankTransactionCode 
                                ,InstructedID 
                                ,EndToEndID 
                                ,UETR 
                                ,RelatedParty_DebtorAcc 
                                ,RelatedParty_CreditorAcc 
                                ,RelatedParty_DebtorName 
                                ,RelatedParty_DebtorBIC 
                                ,RelatedParty_CreditorName 
                                ,RelatedParty_CreditorBIC 
                                ,RelatedAgent_InstructingAgent 
                                ,RelatedAgent_InstructedAgent 
                                ,LocalInstrument
                                ,RelatedDetails_InterbankSettlementDate
                                ,XML_File_Name)
                                SELECT 
                                'PostingEntries' as DataType
                                ,'AccountID'=Account.Ac.value('(Acct/Id/Othr/Id/text())[1]', 'nvarchar(50)')
                                ,'AccountOwnerBicCode'=Account.Ac.value('(Acct/Ownr/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'EntryReference'=Ntry.bal.value('(./NtryRef/text())[1]', 'nvarchar(50)')
                                ,'Currency'=NtryCcy.bal.value('./@Ccy', 'nvarchar(3)')
                                ,'EntryAmount'=Ntry.Bal.value('(./Amt/text())[1]', 'float')
                                ,'CreditDebitIndicator'=Ntry.Bal.value('(./CdtDbtInd/text())[1]', 'nvarchar(50)')
                                ,'EntryStatus'=Ntry.Bal.value('(./Sts/Cd/text())[1]', 'nvarchar(50)')
                                ,'BookingDate'=CONVERT(DATETIME, CONVERT(DATE, Ntry.Bal.value('(./BookgDt/DtTm/text())[1]', 'Datetime')), 121)
                                ,'ValueDate'=Ntry.Bal.value('(./ValDt/Dt/text())[1]', 'Datetime')
                                ,'BankTransactionCode'=Ntry.Bal.value('(./BkTxCd/Prtry/Cd/text())[1]', 'nvarchar(50)')
                                ,'InstructedID'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/InstrId/text())[1]', 'nvarchar(50)')
                                ,'EndToEndID'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/EndToEndId/text())[1]', 'nvarchar(50)')
                                ,'UETR'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/UETR/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_DebtorAcc'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/DbtrAcct/Id/Othr/Id/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_CreditorAcc'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/CdtrAcct/Id/Othr/Id/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_DebtorName'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Dbtr/Pty/Nm/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_DebtorBIC'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Dbtr/Pty/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_CreditorName'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Cdtr/Pty/Nm/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_CreditorBIC'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Cdtr/Pty/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'RelatedAgent_InstructingAgent'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdAgts/InstgAgt/FinInstnId/BICFI/text())[1]', 'nvarchar(50)')
                                ,'RelatedAgent_InstructedAgent'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdAgts/InstdAgt/FinInstnId/BICFI/text())[1]', 'nvarchar(50)')
                                ,'LocalInstrument'=Ntry.Bal.value('(./NtryDtls/TxDtls/LclInstrm/Prtry/text())[1]', 'nvarchar(50)') 
                                ,'RelatedDetails_InterbankSettlementDate'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdDts/IntrBkSttlmDt/text())[1]', 'Datetime') 
                                ,@XML_FileName
                                FROM 
                                @XML_DATA.nodes('Document/BkToCstmrStmt/Stmt') as Account(Ac)
                                CROSS APPLY Account.Ac.nodes('Ntry') as Ntry(bal)
                                CROSS APPLY Ntry.bal.nodes('Amt') as NtryCcy(Bal)

                            DECLARE @ACCOUNTS as Table
                            (ID int IDENTITY (1,1) NOT NULL,
                            AccountID Nvarchar(max) NULL,
                            MsgId Nvarchar(max) NULL,
                            StatementCreationDate Datetime NULL,
                            StatementID Nvarchar(max) NULL,
                            PageNumber int)
                            INSERT INTO @ACCOUNTS
                            (AccountID,MsgId,StatementCreationDate,StatementID,PageNumber)
                            Select AccountID,MsgId,StatementCreationDate,StatementID,PageNumber 
                            from @STATEMENT_BASIC_DATA
                            group by AccountID,MsgId,StatementCreationDate,StatementID,PageNumber

                                DECLARE @MIN_ID int=1
                                DECLARE @MAX_ID int=(Select max(ID) from @ACCOUNTS)
                                WHILE @MIN_ID<=@MAX_ID
                                    BEGIN
                                    DECLARE @ACCOUNT_NR nvarchar(max)=(Select AccountID from @ACCOUNTS where ID=@MIN_ID)
                                    DECLARE @MESSAGE_ID nvarchar(max)=(Select MsgId from @ACCOUNTS where ID=@MIN_ID)
                                    DECLARE @STATEMENT_CREATION_DATE nvarchar(max)=(Select StatementCreationDate from @ACCOUNTS where ID=@MIN_ID)
                                    DECLARE @STATEMENT_ID nvarchar(max)=(Select StatementID from @ACCOUNTS where ID=@MIN_ID)
                                    DECLARE @PAGE_NR int=(Select PageNumber from @ACCOUNTS where ID=@MIN_ID)

                                    --INSERT OPENNING BALANCE---
                                    INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                               ([SwiftFileName]
                                               ,[MessageType]
		                                       ,SenderBIC
                                               ,[ReceivedDate]
                                               ,[OSN]
                                               ,[OSN_ReceivedDate]
                                               ,[Ref20]
                                               ,[AccountIdentification]
                                               ,[StatementNr]
                                               ,[PageNr]
                                               ,[SwiftTag]
                                               ,[SwiftTagName]
                                               ,[DebitCreditMark]
                                               ,[BookingDate]
                                               ,[CUR]
                                               ,[Amount])
                                    SELECT 
                                    [SwiftFileName]=XML_File_Name
                                    ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                    ,@SENDER_BIC
                                    ,[ReceivedDate]=@STATEMENT_CREATION_DATE
                                    ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                    ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                    ,[Ref20]=MsgId
                                    ,[AccountIdentification]=@ACCOUNT_NR
                                    ,[StatementNr]=StatementID
                                    ,[PageNr]=PageNumber
                                    ,[SwiftTag]=Case when BalanceType in ('OPBD') and PageNumber=1  then '60F'
				                                    when BalanceType in ('OPBD') and PageNumber>1 and LastPageIndicator in ('true') then '60M'
				                                    when BalanceType in ('OPBD') and PageNumber>1 and LastPageIndicator in ('false') then '60M' end
                                    ,[SwiftTagName]=Case when BalanceType in ('OPBD') and PageNumber=1  then 'Opening Balance'
					                                     when BalanceType in ('OPBD') and PageNumber>1 and LastPageIndicator in ('true') then 'Intermediate Opening Balance'
					                                     when BalanceType in ('OPBD') and PageNumber>=1 and LastPageIndicator in ('false') then 'Intermediate Opening Balance' end                                     
                                    ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                    ,[BookingDate]=BalanceDate
                                    ,[CUR]=Currency
                                    ,[Amount]=BalanceValue
                                    from @STATEMENT_BASIC_DATA 
                                    where BalanceType in ('OPBD') and AccountID=@ACCOUNT_NR

                                    --INSERT BOOKING ENTRIES
                                    INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                               ([SwiftFileName]
                                               ,[MessageType]
		                                       ,SenderBIC
                                               ,[ReceivedDate]
                                               ,[OSN]
                                               ,[OSN_ReceivedDate]
                                               ,[Ref20]
                                               ,[AccountIdentification]
                                               ,[StatementNr]
                                               ,[PageNr]
                                               ,[SwiftTag]
                                               ,[SwiftTagName]
                                               ,[DebitCreditMark]
                                               ,[BookingDate]
                                               ,[ValueDate]
                                               ,[CUR]
                                               ,[Amount]
                                               ,[TransactionTypeID]
                                               ,[ReferenceAccountOwner]
                                               ,[ReferenceServiInstitution]
                                               ,[SupplementaryDetails]
										      ,[UETR]
										      ,[RelatedParty_DebtorAcc]
										      ,[RelatedParty_CreditorAcc]
										      ,[RelatedParty_DebtorName]
										      ,[RelatedParty_DebtorBIC]
										      ,[RelatedParty_CreditorName]
										      ,[RelatedParty_CreditorBIC]
										      ,[RelatedAgent_InstructingAgent]
										      ,[RelatedAgent_InstructedAgent]
										      ,[LocalInstrument]
                                              ,RelatedDetails_InterbankSettlementDate)
                                    SELECT 
                                    [SwiftFileName]=XML_File_Name
                                    ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                    ,@SENDER_BIC
                                    ,[ReceivedDate]=@STATEMENT_CREATION_DATE
                                    ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                    ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                    ,[Ref20]=@MESSAGE_ID
                                    ,[AccountIdentification]=@ACCOUNT_NR
                                    ,[StatementNr]=@STATEMENT_ID
                                    ,[PageNr]=@PAGE_NR
                                    ,[SwiftTag]='61'
                                    ,[SwiftTagName]='Booking Entry'
                                    ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                    ,[BookingDate]=BookingDate
                                    ,[ValueDate]=ValueDate
                                    ,[CUR]=Currency
                                    ,[Amount]=EntryAmount
                                    ,[TransactionTypeID]=BankTransactionCode
                                    ,[ReferenceAccountOwner]=InstructedID
                                    ,[ReferenceServiInstitution]=EntryReference
                                    ,[SupplementaryDetails]=EndToEndID
								    ,[UETR]=UETR
							        ,[RelatedParty_DebtorAcc]=[RelatedParty_DebtorAcc]
							        ,[RelatedParty_CreditorAcc]=[RelatedParty_CreditorAcc]
							        ,[RelatedParty_DebtorName]=[RelatedParty_DebtorName]
								    ,[RelatedParty_DebtorBIC]=[RelatedParty_DebtorBIC]
								    ,[RelatedParty_CreditorName]=[RelatedParty_CreditorName]
								    ,[RelatedParty_CreditorBIC]=[RelatedParty_CreditorBIC]
								    ,[RelatedAgent_InstructingAgent]=[RelatedAgent_InstructingAgent]
								    ,[RelatedAgent_InstructedAgent]=[RelatedAgent_InstructedAgent]
								    ,[LocalInstrument]=[LocalInstrument]
                                    ,[RelatedDetails_InterbankSettlementDate]=[RelatedDetails_InterbankSettlementDate]
                                    from @STATEMENT_DETAILS_DATA  where AccountID=@ACCOUNT_NR
                                    order by ID asc

                                    --INSERT CLOSING BALANCE
                                    INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                               ([SwiftFileName]
                                               ,[MessageType]
		                                       ,SenderBIC
                                               ,[ReceivedDate]
                                               ,[OSN]
                                               ,[OSN_ReceivedDate]
                                               ,[Ref20]
                                               ,[AccountIdentification]
                                               ,[StatementNr]
                                               ,[PageNr]
                                               ,[SwiftTag]
                                               ,[SwiftTagName]
                                               ,[DebitCreditMark]
                                               ,[BookingDate]
                                               ,[CUR]
                                               ,[Amount])
                                    SELECT 
                                    [SwiftFileName]=XML_File_Name
                                    ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                    ,@SENDER_BIC
                                    ,[ReceivedDate]=StatementCreationDate
                                    ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                    ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                    ,[Ref20]=MsgId
                                    ,[AccountIdentification]=AccountID
                                    ,[StatementNr]=StatementID
                                    ,[PageNr]=PageNumber
                                    ,[SwiftTag]=Case when BalanceType in ('CLBD') and PageNumber>=1 and LastPageIndicator in ('true') then '62F'  
				                                     when BalanceType in ('CLBD') and PageNumber>=1 and LastPageIndicator in ('false') then '62M' end
                                    ,[SwiftTagName]=Case when BalanceType in ('CLBD') and PageNumber>=1 and LastPageIndicator in ('true') then 'Clossing Balance (Booked Funds)'  
					                                     when BalanceType in ('CLBD') and PageNumber>=1 and LastPageIndicator in ('false') then 'Intermediate Clossing Balance' end 
                                    ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                    ,[BookingDate]=BalanceDate
                                    ,[CUR]=Currency
                                    ,[Amount]=BalanceValue
                                    from @STATEMENT_BASIC_DATA
                                    where BalanceType in ('CLBD') and AccountID=@ACCOUNT_NR

                                    SET @MIN_ID=@MIN_ID+1
                                    END

                                DROP TABLE #Temp_XMLwithOpenXML"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "UPDATE [SWIFT_ACC_STATEMENTS] SET [Ref20]=REPLACE(REPLACE([Ref20], CHAR(13), ''), CHAR(10), ''),[AccountIdentification]=REPLACE(REPLACE([AccountIdentification], CHAR(13), ''), CHAR(10), '') where [SwiftFileName]='" & SwiftMessageFileName & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [Amount]=[Amount]*(-1) where [DebitCreditMark] in ('D','RC') and [SwiftFileName]='" & SwiftMessageFileName & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [SQL_PARAMETER_DETAILS]([SQL_Name_1],[SQL_Name_2],[SQL_Name_3],[SQL_Name_4],[Id_SQL_Parameters])SELECT A.[AccountIdentification],A.CUR, A.SenderBIC,(RTRIM(LTRIM(B.[INSTITUTION NAME]))+ ' , ' + RTRIM(LTRIM(B.[CITY HEADING]))) as 'Institution Name','SWIFT STATEMENTS ACCOUNTS ALL' FROM [SWIFT_ACC_STATEMENTS] A INNER JOIN [BIC DIRECTORY] B on A.SenderBIC=B.BIC11 where A.AccountIdentification not in (Select [SQL_Name_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL') and [SwiftFileName]='" & SwiftMessageFileName & "' GROUP BY [AccountIdentification],A.CUR,SenderBIC,B.[INSTITUTION NAME],B.[CITY HEADING]"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [BookingDate]=[ValueDate] where [BookingDate] is NULL and [SwiftFileName]='" & SwiftMessageFileName & "'"
            cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++
            'Sonderfall - In Years End there's some bug regarding the booking Date
            'If Value Date=31.12.2016 the Booking Date is wrobgly updated to 31.12.2017
            'Therefore the following SQL Command in order to set the Booking Date equal to Value Date if Value Date in (30.12.XXXX,31.12.XXXX)
            'cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [BookingDate]=[ValueDate] where convert(varchar(5),[ValueDate],104) in ('30.12','31.12') and [SwiftFileName]='" & SwiftMessageFileName & "'"
            'cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++
            '**************************
            'INSERT NEW BOOKINGS IN NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS
            cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS]([ID_EB],[SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[InternalAccount],[Nostro_Name],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],[TransactionTypeID],[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails])SELECT ID,[SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[InternalAccount],[Nostro_Name],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],[TransactionTypeID],[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails] FROM SWIFT_ACC_STATEMENTS where SwiftTag in ('61') and [SwiftFileName]='" & SwiftMessageFileName & "' and ID not in (Select [ID_EB] from [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS])"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT], A.[Nostro_Name]=B.[NOSTRO_NAME] from [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
            cmd.ExecuteNonQuery()
            'INSERT Swift File Name and Statement Nr. with Swift Tag=62F (CLOSING BOOKED BALANCE)
            cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS_CLOSED_BALANCES]([SwiftFileName],[StatementNr],[AccountIdentification],[HasClosingBalance]) SELECT [SwiftFileName],[StatementNr],[AccountIdentification],'Y' FROM [SWIFT_ACC_STATEMENTS] where [SwiftFileName]='" & SwiftMessageFileName & "' and SwiftTag in ('62F')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT] from [SWIFT_ACC_STATEMENTS_CLOSED_BALANCES] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++

        End If

    End Sub

    Private Sub CAMT_053_001_08_IMPORT_HEAD_001_001_02()
        'Check first if Message has allready imported to Database (hhhhhh)
        ' add by Yu, to check the duplication, besides OSN and Statement Nr, but also [AccountIdentification]='" & AccountIdentification &
        cmd.CommandText = "Select [ID] from [SWIFT_ACC_STATEMENTS] where [OSN_ReceivedDate]='" & OSN_IncomeDate & "' and SenderBIC='" & SenderBIC & "' and [AccountIdentification]='" & AccountIdentification & "' and [StatementNr]='" & StatementNr & " ' and [PageNr]='" & PageNr & "'"
        If IsNothing(cmd.ExecuteScalar) = True Then
            cmd.CommandText = "DECLARE @XML_FileDir nvarchar(MAX)='" & XML_STATEMENT_FILE & "'
                                DECLARE @XML_FileName nvarchar(MAX)=(SELECT RIGHT(@XML_FileDir, CHARINDEX('\', REVERSE(@XML_FileDir)) - 1))

                                IF OBJECT_ID('tempdb..#Temp_XMLwithOpenXML') IS NULL 
                                CREATE TABLE [#Temp_XMLwithOpenXML]
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,[XMLData] [xml] NULL
                                ,XML_File_Name Nvarchar(MAX) NULL
                                ,[LoadedDateTime] [datetime] NULL) 
                                ON [PRIMARY]
                                else
                                DELETE from [#Temp_XMLwithOpenXML]

                                INSERT INTO #Temp_XMLwithOpenXML
                                (XMLData,XML_File_Name, LoadedDateTime)
                                SELECT CONVERT(XML, BulkColumn) AS BulkColumn, @XML_FileName,GETDATE() 
                                FROM OPENROWSET(BULK  '" & XML_STATEMENT_FILE & "', SINGLE_BLOB) AS x

                                DECLARE @STATEMENT_HEADER_DATA as Table
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,SenderBIC Nvarchar(50) NULL
                                ,ReceiverBIC Nvarchar(50) NULL
                                ,UniqueBusinessMessageIdentifier Nvarchar(50) NULL
                                ,MessageDefinitionIdentification Nvarchar(50) NULL
                                ,MessageCreationDateTimeString Nvarchar(50) NULL
                                ,MessageCreationDateTime Datetime NULL)

                                DECLARE @STATEMENT_BASIC_DATA as Table
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,DataType Nvarchar(50) NULL
                                ,MsgId Nvarchar(50) NULL
                                ,StatementCreationDate Datetime
                                ,PageNumber int
                                ,LastPageIndicator Nvarchar(50) NULL
                                ,StatementID Nvarchar(50) NULL
                                ,AccountID Nvarchar(50) NULL
                                ,AccountOwnerBicCode Nvarchar(50) NULL
                                ,BalanceType Nvarchar(50) NULL
                                ,BalanceSubType Nvarchar(50) NULL --NEW
                                ,Currency Nvarchar(50) NULL
                                ,BalanceValue float default(0)
                                ,CreditDebitIndicator Nvarchar(50) NULL
                                ,BalanceDate Datetime
                                ,TransactionsEntriesCount int
                                ,XML_File_Name Nvarchar(MAX) NULL)

                                DECLARE @STATEMENT_DETAILS_DATA as Table
                                ([ID] [int] IDENTITY(1,1) NOT NULL
                                ,DataType Nvarchar(50) NULL
                                ,AccountID Nvarchar(50) NULL
                                ,AccountOwnerBicCode Nvarchar(50) NULL
                                ,EntryReference Nvarchar(50) NULL
                                ,Currency Nvarchar(50) NULL
                                ,EntryAmount float default(0)
                                ,CreditDebitIndicator Nvarchar(50) NULL
                                ,ReversalIndicator Nvarchar(50) NULL --NEW
                                ,EntryStatus Nvarchar(50) NULL
                                ,BookingDate Datetime
                                ,ValueDate Datetime
                                ,BankTransactionCode Nvarchar(50) NULL
                                ,AccountServicerReference Nvarchar(50) NULL --NEW
                                ,AccountOwnerTransactionIdentification Nvarchar(50) NULL --NEW
                                ,AccountServicerTransactionIdentification Nvarchar(50) NULL --NEW
                                ,InstructedID Nvarchar(50) NULL
                                ,EndToEndID Nvarchar(50) NULL
                                ,UETR Nvarchar(50) NULL
                                ,RelatedParty_DebtorAcc Nvarchar(50) NULL
                                ,RelatedParty_CreditorAcc Nvarchar(50) NULL
                                ,RelatedParty_DebtorName Nvarchar(50) NULL
                                ,RelatedParty_DebtorBIC Nvarchar(50) NULL
                                ,RelatedParty_CreditorName Nvarchar(50) NULL
                                ,RelatedParty_CreditorBIC Nvarchar(50) NULL
                                ,RelatedAgent_InstructingAgent Nvarchar(50) NULL
                                ,RelatedAgent_InstructedAgent Nvarchar(50) NULL
                                ,LocalInstrument Nvarchar(50) NULL
                                ,RelatedDetails_InterbankSettlementDate Datetime NULL
                                ,XML_File_Name Nvarchar(MAX) NULL)


                                DECLARE @XML_DATA xml=(SELECT [XMLData]  from [#Temp_XMLwithOpenXML])
                                ;WITH XMLNAMESPACES(DEFAULT 'urn:iso:std:iso:20022:tech:xsd:head.001.001.02')
                                INSERT INTO @STATEMENT_HEADER_DATA
                                (SenderBIC
                                ,ReceiverBIC
                                ,UniqueBusinessMessageIdentifier
                                ,MessageDefinitionIdentification
                                ,MessageCreationDateTimeString
                                ,MessageCreationDateTime)
                                SELECT 
                                'SenderBIC'=CstrStmtHeader.st.value('(Fr/FIId/FinInstnId/BICFI/text())[1]', 'nvarchar(50)') 
                                ,'ReceiverBIC'=CstrStmtHeader.st.value('(To/FIId/FinInstnId/BICFI/text())[1]', 'nvarchar(50)')
                                ,'UniqueBusinessMessageIdentifier'=CstrStmtHeader.st.value('(BizMsgIdr/text())[1]', 'nvarchar(50)') 
                                ,'MessageDefinitionIdentification'=CstrStmtHeader.st.value('(MsgDefIdr/text())[1]', 'nvarchar(50)') 
                                ,'MessageCreationDateTimeString'=CstrStmtHeader.st.value('(CreDt/text())[1]', 'nvarchar(50)')
                                ,'MessageCreationDateTime'=CONVERT(DATETIME,CstrStmtHeader.st.value('(CreDt/text())[1]', 'nvarchar(50)')) 
                                FROM 
                                @XML_DATA.nodes('AppHdr') as CstrStmtHeader(St)

                                DECLARE @SENDER_BIC Nvarchar(50)=CASE WHEN (Select COUNT(SenderBIC) from @STATEMENT_HEADER_DATA)=1 then (Select SenderBIC from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @RECEIVER_BIC Nvarchar(50)=CASE WHEN (Select COUNT(ReceiverBIC) from @STATEMENT_HEADER_DATA)=1 then (Select ReceiverBIC from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @UNIQUE_BUSINESS_MESSAGE_IDENTIFIER Nvarchar(50)=CASE WHEN (Select COUNT(UniqueBusinessMessageIdentifier) from @STATEMENT_HEADER_DATA)=1 Then (Select UniqueBusinessMessageIdentifier from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @MESSAGE_DEFINITION_IDENTIFICATION Nvarchar(50)=CASE WHEN (Select COUNT(MessageDefinitionIdentification) from @STATEMENT_HEADER_DATA)=1 Then (Select MessageDefinitionIdentification from @STATEMENT_HEADER_DATA) Else 'camt.053.001.08' End
                                DECLARE @MESSAGE_CREATION_DATETIME_STRING Nvarchar(50)=CASE WHEN (Select COUNT(MessageCreationDateTimeString) from @STATEMENT_HEADER_DATA)=1 Then (Select MessageCreationDateTimeString from @STATEMENT_HEADER_DATA) Else NULL End
                                DECLARE @MESSAGE_CREATION_DATETIME Datetime=CASE WHEN (Select COUNT(MessageCreationDateTime) from @STATEMENT_HEADER_DATA)=1 Then (Select MessageCreationDateTime from @STATEMENT_HEADER_DATA) Else NULL End

                                ;WITH XMLNAMESPACES(DEFAULT 'urn:iso:std:iso:20022:tech:xsd:camt.053.001.08')
                                INSERT INTO @STATEMENT_BASIC_DATA
                                (DataType
                                ,MsgId
                                ,StatementCreationDate
                                ,PageNumber
                                ,LastPageIndicator
                                ,StatementID
                                ,AccountID
                                ,AccountOwnerBicCode
                                ,BalanceType
                                ,BalanceSubType
                                ,Currency
                                ,BalanceValue
                                ,CreditDebitIndicator
                                ,BalanceDate
                                ,TransactionsEntriesCount
                                ,XML_File_Name)
                                SELECT 
                                'BasicData' as DataType
                                ,'MsgId'=CstrStmt.St.value('(GrpHdr/MsgId/text())[1]', 'nvarchar(50)')
                                ,'StatementCreationDate'=CONVERT(DATETIME, CONVERT(DATE, CstrStmt.St.value('(GrpHdr/CreDtTm/text())[1]', 'Datetime')), 121)  
                                ,'PageNumber'=Account.Ac.value('(StmtPgntn/PgNb/text())[1]', 'int')
                                ,'LastPageIndicator'=Account.Ac.value('(StmtPgntn/LastPgInd/text())[1]', 'nvarchar(50)')
                                ,'StatementID'=Account.Ac.value('(./Id/text())[1]', 'nvarchar(50)')   
                                ,'AccountID'=CASE when Account.Ac.value('(Acct/Id/Othr/Id/text())[1]', 'nvarchar(50)') is NULL then Account.Ac.value('(Acct/Id/IBAN/text())[1]', 'nvarchar(50)') 
                                                             else Account.Ac.value('(Acct/Id/Othr/Id/text())[1]', 'nvarchar(50)')  end
                                ,'AccountOwnerBicCode'=Account.Ac.value('(Acct/Ownr/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'BalanceType'=Balance.Bal.value('(./Tp/CdOrPrtry/Cd/text())[1]', 'nvarchar(50)')
                                ,'BalanceSubType'=Balance.Bal.value('(./Tp/SubTp/Cd/text())[1]', 'nvarchar(50)')
                                ,'Currency'=BalanceCcy.Bal.value('./@Ccy', 'nvarchar(3)') 
                                ,'BalanceValue'=Balance.Bal.value('(./Amt/text())[1]', 'float') 
                                ,'CreditDebitIndicator'=Balance.Bal.value('(./CdtDbtInd/text())[1]', 'nvarchar(50)') 
                                ,'BalanceDate'=CONVERT(DATETIME, CONVERT(DATE, Balance.Bal.value('(./Dt/Dt/text())[1]', 'Datetime')), 121) 
                                ,'TransactionsEntriesCount'=BalanceSum.Entries.value('(./TtlNtries/NbOfNtries/text())[1]', 'int')
                                ,@XML_FileName
                                FROM 
                                @XML_DATA.nodes('Document/BkToCstmrStmt') as CstrStmt(St)
                                CROSS APPLY CstrStmt.St.nodes('Stmt') as Account(Ac)
                                CROSS APPLY Account.Ac.nodes('Bal') as Balance(bal)
                                CROSS APPLY Balance.bal.nodes('Amt') as BalanceCcy(Bal)
                                CROSS APPLY Account.Ac.nodes('TxsSummry') as BalanceSum(Entries)

                                ;WITH XMLNAMESPACES(DEFAULT 'urn:iso:std:iso:20022:tech:xsd:camt.053.001.08')
                                INSERT INTO @STATEMENT_DETAILS_DATA
                                (DataType
                                ,AccountID
                                ,AccountOwnerBicCode
                                ,EntryReference 
                                ,Currency 
                                ,EntryAmount 
                                ,CreditDebitIndicator 
                                ,ReversalIndicator
                                ,EntryStatus 
                                ,BookingDate 
                                ,ValueDate 
                                ,BankTransactionCode
                                ,AccountServicerReference
                                ,AccountOwnerTransactionIdentification
                                ,AccountServicerTransactionIdentification
                                ,InstructedID 
                                ,EndToEndID 
                                ,UETR 
                                ,RelatedParty_DebtorAcc 
                                ,RelatedParty_CreditorAcc 
                                ,RelatedParty_DebtorName 
                                ,RelatedParty_DebtorBIC 
                                ,RelatedParty_CreditorName 
                                ,RelatedParty_CreditorBIC 
                                ,RelatedAgent_InstructingAgent 
                                ,RelatedAgent_InstructedAgent 
                                ,LocalInstrument
                                ,RelatedDetails_InterbankSettlementDate
                                ,XML_File_Name)
                                SELECT 
                                'PostingEntries' as DataType
                                ,'AccountID'=CASE when Account.Ac.value('(Acct/Id/Othr/Id/text())[1]', 'nvarchar(50)') is NULL then Account.Ac.value('(Acct/Id/IBAN/text())[1]', 'nvarchar(50)') 
                                                             else Account.Ac.value('(Acct/Id/Othr/Id/text())[1]', 'nvarchar(50)')  end
                                ,'AccountOwnerBicCode'=Account.Ac.value('(Acct/Ownr/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'EntryReference'=Ntry.bal.value('(./NtryRef/text())[1]', 'nvarchar(50)')
                                ,'Currency'=NtryCcy.bal.value('./@Ccy', 'nvarchar(3)')
                                ,'EntryAmount'=Ntry.Bal.value('(./Amt/text())[1]', 'float')
                                ,'CreditDebitIndicator'=Ntry.Bal.value('(./CdtDbtInd/text())[1]', 'nvarchar(50)')
                                ,'ReversalIndicator'=Ntry.Bal.value('(./RvslInd/text())[1]', 'nvarchar(50)')
                                ,'EntryStatus'=Ntry.Bal.value('(./Sts/Cd/text())[1]', 'nvarchar(50)')
                                ,'BookingDate'=CONVERT(DATETIME, CONVERT(DATE, Ntry.Bal.value('(./BookgDt/DtTm/text())[1]', 'Datetime')), 121)
                                ,'ValueDate'=Ntry.Bal.value('(./ValDt/Dt/text())[1]', 'Datetime')
                                ,'BankTransactionCode'=Ntry.Bal.value('(./BkTxCd/Prtry/Cd/text())[1]', 'nvarchar(50)')
                                ,'AccountServicerReference'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/AcctSvcrRef/text())[1]', 'nvarchar(50)')
                                ,'AccountOwnerTransactionIdentification'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/AcctOwnrTxId/text())[1]', 'nvarchar(50)')
                                ,'AccountServicerTransactionIdentification'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/AcctSvcrTxId/text())[1]', 'nvarchar(50)')
                                ,'InstructedID'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/InstrId/text())[1]', 'nvarchar(50)')
                                ,'EndToEndID'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/EndToEndId/text())[1]', 'nvarchar(50)')
                                ,'UETR'=Ntry.Bal.value('(./NtryDtls/TxDtls/Refs/UETR/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_DebtorAcc'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/DbtrAcct/Id/Othr/Id/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_CreditorAcc'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/CdtrAcct/Id/Othr/Id/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_DebtorName'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Dbtr/Pty/Nm/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_DebtorBIC'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Dbtr/Pty/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_CreditorName'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Cdtr/Pty/Nm/text())[1]', 'nvarchar(50)')
                                ,'RelatedParty_CreditorBIC'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdPties/Cdtr/Pty/Id/OrgId/AnyBIC/text())[1]', 'nvarchar(50)')
                                ,'RelatedAgent_InstructingAgent'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdAgts/InstgAgt/FinInstnId/BICFI/text())[1]', 'nvarchar(50)')
                                ,'RelatedAgent_InstructedAgent'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdAgts/InstdAgt/FinInstnId/BICFI/text())[1]', 'nvarchar(50)')
                                ,'LocalInstrument'=Ntry.Bal.value('(./NtryDtls/TxDtls/LclInstrm/Prtry/text())[1]', 'nvarchar(50)') 
                                ,'RelatedDetails_InterbankSettlementDate'=Ntry.Bal.value('(./NtryDtls/TxDtls/RltdDts/IntrBkSttlmDt/text())[1]', 'Datetime') 
                                ,@XML_FileName
                                FROM 
                                @XML_DATA.nodes('Document/BkToCstmrStmt/Stmt') as Account(Ac)
                                CROSS APPLY Account.Ac.nodes('Ntry') as Ntry(bal)
                                CROSS APPLY Ntry.bal.nodes('Amt') as NtryCcy(Bal)

                                --SELECT * FROM @STATEMENT_HEADER_DATA
                                --SELECT * from @STATEMENT_BASIC_DATA
                                --SELECT * from @STATEMENT_DETAILS_DATA


                                DECLARE @ACCOUNTS as Table
                                (ID int IDENTITY (1,1) NOT NULL,
                                AccountID Nvarchar(max) NULL,
                                MsgId Nvarchar(max) NULL,
                                StatementCreationDate Datetime NULL,
                                StatementID Nvarchar(max) NULL,
                                PageNumber int)
                                INSERT INTO @ACCOUNTS
                                (AccountID,MsgId,StatementCreationDate,StatementID,PageNumber)
                                Select AccountID,MsgId,StatementCreationDate,StatementID,PageNumber 
                                from @STATEMENT_BASIC_DATA
                                group by AccountID,MsgId,StatementCreationDate,StatementID,PageNumber

                                --select * FROM @ACCOUNTS

                                DECLARE @MIN_ID int=1
                                DECLARE @MAX_ID int=(Select max(ID) from @ACCOUNTS)
                                WHILE @MIN_ID<=@MAX_ID
                                BEGIN
                                              DECLARE @ACCOUNT_NR nvarchar(max)=(Select AccountID from @ACCOUNTS where ID=@MIN_ID)
                                              DECLARE @MESSAGE_ID nvarchar(max)=(Select MsgId from @ACCOUNTS where ID=@MIN_ID)
                                              DECLARE @STATEMENT_CREATION_DATE Datetime=(Select StatementCreationDate from @ACCOUNTS where ID=@MIN_ID)
                                              DECLARE @STATEMENT_ID nvarchar(max)=(Select StatementID from @ACCOUNTS where ID=@MIN_ID)
                                              DECLARE @PAGE_NR int=(Select PageNumber from @ACCOUNTS where ID=@MIN_ID)

                                              ----INSERT OPENNING BALANCE---
                                              INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                              ([SwiftFileName]
                                              ,[MessageType]
                                              ,SenderBIC
                                              ,[ReceivedDate]
                                              ,[OSN]
                                              ,[OSN_ReceivedDate]
                                              ,[Ref20]
                                              ,[AccountIdentification]
                                              ,[StatementNr]
                                              ,[PageNr]
                                              ,[SwiftTag]
                                              ,[SwiftTagName]
                                              ,[DebitCreditMark]
                                              ,[BookingDate]
                                              ,[CUR]
                                              ,[Amount])
                                              SELECT 
                                              [SwiftFileName]=XML_File_Name
                                              ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                              ,@SENDER_BIC
                                              ,[ReceivedDate]=@STATEMENT_CREATION_DATE
                                              ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                              ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                              ,[Ref20]=MsgId
                                              ,[AccountIdentification]=@ACCOUNT_NR
                                              ,[StatementNr]=dbo.fn_StripCharacters(StatementID,'^0-9')
                                              ,[PageNr]=PageNumber
                                              ,[SwiftTag]=Case when BalanceType in ('OPBD') AND ISNULL(BalanceSubType,'') not in ('INTM') then '60F'  
                                                               when BalanceType in ('OPBD') and ISNULL(BalanceSubType,'') in ('INTM') then '60M' end
                                              ,[SwiftTagName]=Case when BalanceType in ('OPBD') AND ISNULL(BalanceSubType,'') not in ('INTM') then 'Opening Balance'  
                                                                   when BalanceType in ('OPBD') and ISNULL(BalanceSubType,'') in ('INTM') then 'Intermediate Opening Balance' end                                
                                              ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                              ,[BookingDate]=BalanceDate
                                              ,[CUR]=Currency
                                              ,[Amount]=BalanceValue
                                              from @STATEMENT_BASIC_DATA 
                                              where BalanceType in ('OPBD') and AccountID=@ACCOUNT_NR

                                              --INSERT BOOKING ENTRIES
                                              INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                              ([SwiftFileName]
                                              ,[MessageType]
                                              ,SenderBIC
                                              ,[ReceivedDate]
                                              ,[OSN]
                                              ,[OSN_ReceivedDate]
                                              ,[Ref20]
                                              ,[AccountIdentification]
                                              ,[StatementNr]
                                              ,[PageNr]
                                              ,[SwiftTag]
                                              ,[SwiftTagName]
                                              ,[DebitCreditMark]
                                              ,[BookingDate]
                                              ,[ValueDate]
                                              ,[CUR]
                                              ,[Amount]
                                              ,[TransactionTypeID]
                                              ,[ReferenceAccountOwner]
                                              ,[ReferenceServiInstitution]
                                              ,[SupplementaryDetails]
                                              ,[UETR]
                                              ,[RelatedParty_DebtorAcc]
                                              ,[RelatedParty_CreditorAcc]
                                              ,[RelatedParty_DebtorName]
                                              ,[RelatedParty_DebtorBIC]
                                              ,[RelatedParty_CreditorName]
                                              ,[RelatedParty_CreditorBIC]
                                              ,[RelatedAgent_InstructingAgent]
                                              ,[RelatedAgent_InstructedAgent]
                                              ,[LocalInstrument]
                                              ,RelatedDetails_InterbankSettlementDate)
                                              SELECT 
                                              [SwiftFileName]=XML_File_Name
                                              ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                              ,@SENDER_BIC
                                              ,[ReceivedDate]=@STATEMENT_CREATION_DATE
                                              ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                              ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                              ,[Ref20]=@MESSAGE_ID
                                              ,[AccountIdentification]=@ACCOUNT_NR
                                              ,[StatementNr]=dbo.fn_StripCharacters(@STATEMENT_ID,'^0-9')
                                              ,[PageNr]=@PAGE_NR
                                              ,[SwiftTag]='61'
                                              ,[SwiftTagName]='Booking Entry'
                                              ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                              ,[BookingDate]=BookingDate
                                              ,[ValueDate]=ValueDate
                                              ,[CUR]=Currency
                                              ,[Amount]=EntryAmount
                                              ,[TransactionTypeID]=BankTransactionCode
                                              ,[ReferenceAccountOwner]=AccountOwnerTransactionIdentification
                                              ,[ReferenceServiInstitution]=AccountServicerTransactionIdentification
                                              ,[SupplementaryDetails]=AccountServicerReference
                                              ,[UETR]=UETR
                                              ,[RelatedParty_DebtorAcc]=[RelatedParty_DebtorAcc]
                                              ,[RelatedParty_CreditorAcc]=[RelatedParty_CreditorAcc]
                                              ,[RelatedParty_DebtorName]=[RelatedParty_DebtorName]
                                              ,[RelatedParty_DebtorBIC]=[RelatedParty_DebtorBIC]
                                              ,[RelatedParty_CreditorName]=[RelatedParty_CreditorName]
                                              ,[RelatedParty_CreditorBIC]=[RelatedParty_CreditorBIC]
                                              ,[RelatedAgent_InstructingAgent]=[RelatedAgent_InstructingAgent]
                                              ,[RelatedAgent_InstructedAgent]=[RelatedAgent_InstructedAgent]
                                              ,[LocalInstrument]=[LocalInstrument]
                                              ,[RelatedDetails_InterbankSettlementDate]=[RelatedDetails_InterbankSettlementDate]
                                              from @STATEMENT_DETAILS_DATA  where AccountID=@ACCOUNT_NR
                                              order by ID asc

                                              --INSERT CLOSING BOOKED BALANCE
                                              INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                              ([SwiftFileName]
                                              ,[MessageType]
                                              ,SenderBIC
                                              ,[ReceivedDate]
                                              ,[OSN]
                                              ,[OSN_ReceivedDate]
                                              ,[Ref20]
                                              ,[AccountIdentification]
                                              ,[StatementNr]
                                              ,[PageNr]
                                              ,[SwiftTag]
                                              ,[SwiftTagName]
                                              ,[DebitCreditMark]
                                              ,[BookingDate]
                                              ,[CUR]
                                              ,[Amount])
                                              SELECT 
                                              [SwiftFileName]=XML_File_Name
                                              ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                              ,@SENDER_BIC
                                              ,[ReceivedDate]=StatementCreationDate
                                              ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                              ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                              ,[Ref20]=MsgId
                                              ,[AccountIdentification]=AccountID
                                              ,[StatementNr]=dbo.fn_StripCharacters(StatementID,'^0-9')
                                              ,[PageNr]=PageNumber
                                              ,[SwiftTag]=Case when BalanceType in ('CLBD') AND ISNULL(BalanceSubType,'') not in ('INTM') then '62F'  
                                                               when BalanceType in ('CLBD') and ISNULL(BalanceSubType,'') in ('INTM') then '62M' end
                                              ,[SwiftTagName]=Case when BalanceType in ('CLBD') AND ISNULL(BalanceSubType,'') not in ('INTM') then 'Clossing Balance (Booked Funds)'  
                                                                   when BalanceType in ('CLBD') and ISNULL(BalanceSubType,'') in ('INTM') then 'Intermediate Clossing Balance' end      
                                              ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                              ,[BookingDate]=BalanceDate
                                              ,[CUR]=Currency
                                              ,[Amount]=BalanceValue
                                              from @STATEMENT_BASIC_DATA
                                              where BalanceType in ('CLBD') and AccountID=@ACCOUNT_NR

                                               --INSERT CLOSING AVAILABLE BALANCE
                                              INSERT INTO [dbo].[SWIFT_ACC_STATEMENTS]
                                              ([SwiftFileName]
                                              ,[MessageType]
                                              ,SenderBIC
                                              ,[ReceivedDate]
                                              ,[OSN]
                                              ,[OSN_ReceivedDate]
                                              ,[Ref20]
                                              ,[AccountIdentification]
                                              ,[StatementNr]
                                              ,[PageNr]
                                              ,[SwiftTag]
                                              ,[SwiftTagName]
                                              ,[DebitCreditMark]
                                              ,[BookingDate]
                                              ,[CUR]
                                              ,[Amount])
                                              SELECT 
                                              [SwiftFileName]=XML_File_Name
                                              ,[MessageType]=@MESSAGE_DEFINITION_IDENTIFICATION
                                              ,@SENDER_BIC
                                              ,[ReceivedDate]=StatementCreationDate
                                              ,[OSN]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER
                                              ,[OSN_ReceivedDate]=@UNIQUE_BUSINESS_MESSAGE_IDENTIFIER+'_'+@MESSAGE_CREATION_DATETIME_STRING
                                              ,[Ref20]=MsgId
                                              ,[AccountIdentification]=AccountID
                                              ,[StatementNr]=dbo.fn_StripCharacters(StatementID,'^0-9')
                                              ,[PageNr]=PageNumber
                                              ,[SwiftTag]='64'
                                              ,[SwiftTagName]='Closing Available Balance (Available Funds)'    
                                              ,[DebitCreditMark]=Case when CreditDebitIndicator in ('CRDT') then 'C'  when CreditDebitIndicator in ('DBIT') then 'D' end
                                              ,[BookingDate]=BalanceDate
                                              ,[CUR]=Currency
                                              ,[Amount]=BalanceValue
                                              from @STATEMENT_BASIC_DATA
                                              where BalanceType in ('CLAV') and AccountID=@ACCOUNT_NR

                                SET @MIN_ID=@MIN_ID+1
                                END

                                DROP TABLE #Temp_XMLwithOpenXML"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "UPDATE [SWIFT_ACC_STATEMENTS] SET [Ref20]=REPLACE(REPLACE([Ref20], CHAR(13), ''), CHAR(10), ''),[AccountIdentification]=REPLACE(REPLACE([AccountIdentification], CHAR(13), ''), CHAR(10), '') where [SwiftFileName]='" & SwiftMessageFileName & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [Amount]=[Amount]*(-1) where [DebitCreditMark] in ('D','RC') and [SwiftFileName]='" & SwiftMessageFileName & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [SQL_PARAMETER_DETAILS]([SQL_Name_1],[SQL_Name_2],[SQL_Name_3],[SQL_Name_4],[Id_SQL_Parameters])SELECT A.[AccountIdentification],A.CUR, A.SenderBIC,(RTRIM(LTRIM(B.[INSTITUTION NAME]))+ ' , ' + RTRIM(LTRIM(B.[CITY HEADING]))) as 'Institution Name','SWIFT STATEMENTS ACCOUNTS ALL' FROM [SWIFT_ACC_STATEMENTS] A INNER JOIN [BIC DIRECTORY] B on A.SenderBIC=B.BIC11 where A.AccountIdentification not in (Select [SQL_Name_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='SWIFT STATEMENTS ACCOUNTS ALL') and [SwiftFileName]='" & SwiftMessageFileName & "' GROUP BY [AccountIdentification],A.CUR,SenderBIC,B.[INSTITUTION NAME],B.[CITY HEADING]"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [BookingDate]=[ValueDate] where [BookingDate] is NULL and [SwiftFileName]='" & SwiftMessageFileName & "'"
            cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++
            'Sonderfall - In Years End there's some bug regarding the booking Date
            'If Value Date=31.12.2016 the Booking Date is wrobgly updated to 31.12.2017
            'Therefore the following SQL Command in order to set the Booking Date equal to Value Date if Value Date in (30.12.XXXX,31.12.XXXX)
            'cmd.CommandText = "Update [SWIFT_ACC_STATEMENTS] set [BookingDate]=[ValueDate] where convert(varchar(5),[ValueDate],104) in ('30.12','31.12') and [SwiftFileName]='" & SwiftMessageFileName & "'"
            'cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++
            '**************************
            'INSERT NEW BOOKINGS IN NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS
            cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS]([ID_EB],[SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[InternalAccount],[Nostro_Name],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],[TransactionTypeID],[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails])SELECT ID,[SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[AccountIdentification],[InternalAccount],[Nostro_Name],[StatementNr],[PageNr],[SwiftTag],[SwiftTagName],[DebitCreditMark],[FundsCode],[BookingDate],[ValueDate],[CUR],[Amount],[TransactionTypeID],[ReferenceAccountOwner],[ReferenceServiInstitution],[SupplementaryDetails] FROM SWIFT_ACC_STATEMENTS where SwiftTag in ('61') and [SwiftFileName]='" & SwiftMessageFileName & "' and ID not in (Select [ID_EB] from [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS])"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT], A.[Nostro_Name]=B.[NOSTRO_NAME] from [NOSTRO_ACC_RECON_NEW_EXTERNAL_BOOKINGS] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
            cmd.ExecuteNonQuery()
            'INSERT Swift File Name and Statement Nr. with Swift Tag=62F (CLOSING BOOKED BALANCE)
            cmd.CommandText = "INSERT INTO [SWIFT_ACC_STATEMENTS_CLOSED_BALANCES]([SwiftFileName],[StatementNr],[AccountIdentification],[HasClosingBalance]) SELECT [SwiftFileName],[StatementNr],[AccountIdentification],'Y' FROM [SWIFT_ACC_STATEMENTS] where [SwiftFileName]='" & SwiftMessageFileName & "' and SwiftTag in ('62F')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A Set A.[InternalAccount]=B.[INTERNAL ACCOUNT] from [SWIFT_ACC_STATEMENTS_CLOSED_BALANCES] A INNER JOIN [SSIS] B on A.[AccountIdentification]=B.[AccountIdentifierStatement] where B.[AccountIdentifierStatement] is not NULL and A.[InternalAccount] is NULL"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++

        End If

    End Sub


    'MT191/991

    Private Sub MT191_FORMATTED()
        Dim arrText() As String
        Dim sLine As String = Nothing
        arrText = File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName)
        'Temporary SWIFT Message-Without BLOCKS to get the SWIFT TEXT
        Using objWriter As StreamWriter = New StreamWriter(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
            For I As Integer = 1 To arrText.Length - 2
                objWriter.WriteLine(arrText(I))
            Next
        End Using
        SwiftMessageText = IO.File.ReadAllText(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
        File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
        '------------------------------------------------------------------
        Using objWriter As StreamWriter = New StreamWriter(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
            For I As Integer = 1 To arrText.Length - 2
                If (arrText(I).StartsWith(":20:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":20:", ":20:Transaction Reference Number" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":21:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":21:", ":21:Related Reference" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":32B:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":32B:", ":32B:Currency Code, Amount" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":52A:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":52A:", ":52A:Ordering Institution" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":52D:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":52D:", ":52A:Ordering Institution" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":57A:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":57A:", ":57A:Account With Institution" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":57B:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":57B:", ":57B:Account With Institution" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":57D:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":57D:", ":57D:Account With Institution" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":71B:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":71B:", ":71B:Details of Charges" & vbNewLine))
                ElseIf (arrText(I).StartsWith(":72:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":72:", ":72:Sender to Receiver Information" & vbNewLine))
                Else
                    objWriter.WriteLine(arrText(I))
                End If

            Next
        End Using

        SwiftMessageFormatedText = IO.File.ReadAllText(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
        File.Delete(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")

    End Sub

    Private Sub MT191_REPLACE_SWIFT_SIGN()
        Dim arrText() As String
        Dim sLine As String = Nothing
        arrText = File.ReadAllLines(SWIFT_MESSAGES_IMPORT_DIRECTORY & SwiftMessageFileName)

        Using objWriter As StreamWriter = New StreamWriter(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
            For I As Integer = 1 To arrText.Length - 2
                If (arrText(I).StartsWith(":20:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":20:", "#20#"))
                ElseIf (arrText(I).StartsWith(":21:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":21:", "#21#"))
                ElseIf (arrText(I).StartsWith(":32B:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":32B:", "#32B#"))
                ElseIf (arrText(I).StartsWith(":52A:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":52A:", "#52A#"))
                ElseIf (arrText(I).StartsWith(":52D:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":52D:", "#52D#"))
                ElseIf (arrText(I).StartsWith(":57A:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":57A:", "#57A#"))
                ElseIf (arrText(I).StartsWith(":57B:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":57B:", "#57B#"))
                ElseIf (arrText(I).StartsWith(":57D:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":57D:", "#57D#"))
                ElseIf (arrText(I).StartsWith(":71B:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":71B:", "#71B#"))
                ElseIf (arrText(I).StartsWith(":72:")) = True Then
                    objWriter.WriteLine(arrText(I).Replace(":72:", "#72#"))
                    ''''''''''
                    'ElseIf (arrText(I).StartsWith(":79:")) = True Then
                    'objWriter.WriteLine(arrText(I).Replace(":79:", "#79#"))
                    'ElseIf (arrText(I).StartsWith(":72:")) = True Then
                    'objWriter.WriteLine(arrText(I).Replace(":72:", "#72#"))
                    'ElseIf (arrText(I).Contains("'")) = True Then
                    'objWriter.WriteLine(arrText(I).Replace("'", "''"))

                Else
                    objWriter.WriteLine(arrText(I))
                End If


            Next
        End Using



    End Sub

    Private Sub MT191_IMPORT()

        RegexPatern = "#"  'Split on ':'  :[0-9]{2}: 
        Dim RegexInput As String = IO.File.ReadAllText(SWIFT_MESSAGES_IMPORT_DIRECTORY & "MTx91_TemporaryOutput.txt")
        Dim RegexSubstrings() As String = Regex.Split(RegexInput, RegexPatern)
        Dim RegexArrList As New List(Of String)
        'Define Strings
        Dim myString20 As String = "20"
        Dim myString21 As String = "21"
        Dim myString32B As String = "32B"
        Dim myString71B As String = "71B"


        RegexSd = RegexSubstrings.ToArray

        RegexMyIndex = Array.IndexOf(RegexSd, myString20)
        MT191_20 = (RegexSd((RegexMyIndex + 1)))
        RegexMyIndex = Array.IndexOf(RegexSd, myString21)
        MT191_21 = (RegexSd((RegexMyIndex + 1)))
        'Currency
        RegexMyIndex = Array.IndexOf(RegexSd, myString32B)
        MT191_32B_CUR = Microsoft.VisualBasic.Left((RegexSd((RegexMyIndex + 1))), 3)
        'Amount
        Dim AmountString As String = Microsoft.VisualBasic.Mid((RegexSd((RegexMyIndex + 1))), 4, 15)
        If AmountString.Trim.EndsWith(",") = True Then
            AmountString = AmountString.Replace(",", "")
        End If
        MT191_32B_AMT = AmountString
        'Details of Charges
        RegexMyIndex = Array.IndexOf(RegexSd, myString71B)
        MT191_71B = (RegexSd((RegexMyIndex + 1)))


        'cmd.Connection.Open()
        'Check first if Message has allready imported to Database
        cmd.CommandText = "Select [ID] from [ALL_SWIFT_CHARGES_MESSAGES] where [OSN_ReceivedDate]='" & OSN_IncomeDate & "' and [Ref21]= '" & MT191_21.ToString.Trim & "'"
        If IsNothing(cmd.ExecuteScalar) = True Then

            'Insert in ALL_SWIFT_CHARGES_MESSAGES
            cmd.CommandText = "INSERT INTO [ALL_SWIFT_CHARGES_MESSAGES]([SwiftFileName],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[OSN_ReceivedDate],[Ref20],[Ref21],[CCY],[Amount],[DetailsOfCharges],[Swift_Message],[Swift_Message_Formated]) Values ('" & SwiftMessageFileName & "','" & MessageType & "','" & SenderBIC & "','" & ReceiptDateSql & "','" & Str(OSN) & "','" & OSN_IncomeDate & "',@Ref20,@Ref21,@CCY,@Amount,@DetailsOfCharges,@SwiftMessageTextAll,@SwiftMessageFormatedTextAll)"
            cmd.Parameters.Add("@Ref20", SqlDbType.NVarChar).Value = MT191_20.ToString.Trim
            cmd.Parameters.Add("@Ref21", SqlDbType.NVarChar).Value = MT191_21.ToString.Trim
            cmd.Parameters.Add("@CCY", SqlDbType.NVarChar).Value = MT191_32B_CUR.ToString.Trim
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = MT191_32B_AMT
            cmd.Parameters.Add("@DetailsOfCharges", SqlDbType.NVarChar).Value = MT191_71B
            cmd.Parameters.Add("@SwiftMessageTextAll", SqlDbType.NText).Value = SwiftMessageText
            cmd.Parameters.Add("@SwiftMessageFormatedTextAll", SqlDbType.NText).Value = SwiftMessageFormatedText
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear() 'Allways to Use otherwise ERROR EXCEPTION:The Vaiables must be unique
            'UPDATES in ALL_SWIFT_CHARGES_MESSAGES
            cmd.CommandText = "UPDATE A SET A.[SenderName]= B.[INSTITUTION NAME],A.[SenderBranch]=B.[CITY HEADING] FROM [ALL_SWIFT_CHARGES_MESSAGES] A INNER JOIN [BIC DIRECTORY] B ON A.[SenderBIC]=B.[BIC CODE]+ B.[BRANCH CODE] where A.[SENDERNAME] is NULL "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A set A.[MessageTypeName]=B.S from  [ALL_SWIFT_CHARGES_MESSAGES] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='SWIFT_MESSAGE_NAMES' and [PARAMETER STATUS] ='Y')B ON A.[MessageType]=B.[PARAMETER1] where A.[MessageTypeName] is NULL"
            cmd.ExecuteNonQuery()
            'Check for receivers Correspondent
            cmd.CommandText = "Update A set A.ReceiverCorrespondent='T2 PARTICIPANT' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN [T2 DIRECTORY] B on A.SenderBIC=B.BIC11 and A.SenderBIC=B.ADDRESSEE and A.SenderBIC=B.ACCOUNT_HOLDER where A.ReceiverCorrespondent in ('NOT FUND') and B.TYPE_OF_CHANGE not in ('D') and A.SenderBIC='" & SenderBIC & "' and A.[CCY] in ('EUR')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A set A.ReceiverCorrespondent=B.ADDRESSEE from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN [T2 DIRECTORY] B on A.SenderBIC=B.BIC11 and B.ADDRESSEE=B.ACCOUNT_HOLDER where A.ReceiverCorrespondent in ('NOT FUND') and B.TYPE_OF_CHANGE not in ('D') and A.SenderBIC='" & SenderBIC & "' and A.[CCY] in ('EUR')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A set A.ReceiverCorrespondent=B.ACCOUNT_HOLDER from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN [T2 DIRECTORY] B on A.SenderBIC=B.BIC11 and A.SenderBIC=B.ADDRESSEE and B.ADDRESSEE<>B.ACCOUNT_HOLDER where A.ReceiverCorrespondent in ('NOT FUND') and B.TYPE_OF_CHANGE not in ('D') and A.SenderBIC='" & SenderBIC & "' and A.[CCY] in ('EUR')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A set A.ReceiverCorrespondent=B.ACCOUNT_HOLDER + ' through ' + B.ADDRESSEE from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN [T2 DIRECTORY] B on A.SenderBIC=B.BIC11 and B.BIC11<>B.ADDRESSEE and B.ADDRESSEE<>B.ACCOUNT_HOLDER  where A.ReceiverCorrespondent in ('NOT FUND') and B.TYPE_OF_CHANGE not in ('D') and A.SenderBIC='" & SenderBIC & "' and A.[CCY] in ('EUR')"
            cmd.ExecuteNonQuery()
            'Check if Payment Order allready exists
            cmd.CommandText = "Select [ID] from [ALL_SWIFT_CHARGES_MESSAGES_Details] where [OurReference]='" & MT191_21.ToString.Trim & "'"
            If IsNothing(cmd.ExecuteScalar) = True Then
                'Insert in to Payment Details
                cmd.CommandText = "INSERT INTO [ALL_SWIFT_CHARGES_MESSAGES_Details]([OurReference],[RelatedPayment],[PaymentType],[ReceiverBIC],[ValueDate],[CCY],[Amount],[DetailsOfCharges],[Id_Charges])Select OURTRANREFNO,EM00KEY1,METHOD,RECEIVERSWIFT,VALUEDATE,CURRENCYCODE,[Deal Amount],DETOFCHARGE,(Select ID from ALL_SWIFT_CHARGES_MESSAGES where OSN_ReceivedDate='" & OSN_IncomeDate & "')from [ODAS REMMITANCES] where OURTRANREFNO='" & MT191_21.ToString.Trim & "' and INWARDOUTWARD in ('O') and NOT EXISTS (Select * from [ALL_SWIFT_CHARGES_MESSAGES_Details] where [OurReference]='" & MT191_21.ToString.Trim & "')"
                cmd.ExecuteNonQuery()
                'Update MatchedStatus
                cmd.CommandText = "UPDATE A SET A.MatchedStatus='Y' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES_Details B on A.ID=B.Id_Charges where MatchedStatus='N'"
                cmd.ExecuteNonQuery()
                'Update Requested Charges Amount in Details Sector
                cmd.CommandText = "UPDATE A SET A.[RequestedChargesCurrency]=B.CCY,A.[RequestedChargesAmount]=B.Amount from ALL_SWIFT_CHARGES_MESSAGES_Details A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES B on A.Id_Charges=B.ID where B.MatchedStatus in ('Y') and A.[RequestedChargesCurrency] IS NULL"
                cmd.ExecuteNonQuery()
            Else
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('Email_Charges_Requests_MT191_991')) and SQL_Name_1 in ('Email_MT191_991_DuplicateField21') and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim SqlCommandText1 As String = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<Field_20>", MT191_20.ToString.Trim)
                    Dim SqlCommandText2 As String = SqlCommandText1.ToString.Replace("<Field_21>", MT191_21.ToString.Trim)
                    Dim SqlCommandText3 As String = SqlCommandText2.ToString.Replace("<SenderBIC>", SenderBIC.ToString.Trim)
                    Dim SqlCommandText4 As String = SqlCommandText3.ToString.Replace("<MessageType>", MessageType)
                    cmd.CommandText = SqlCommandText4
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

        Else
            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('Email_Charges_Requests_MT191_991')) and SQL_Name_1 in ('Email_MT191_991_DuplicateMessage') and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim SqlCommandText1 As String = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<Field_20>", MT191_20.ToString.Trim)
                Dim SqlCommandText2 As String = SqlCommandText1.ToString.Replace("<SenderBIC>", SenderBIC.ToString.Trim)
                Dim SqlCommandText3 As String = SqlCommandText2.ToString.Replace("<MessageType>", MessageType)
                cmd.CommandText = SqlCommandText3
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    cmd.ExecuteNonQuery()
                End If
            Next

        End If


    End Sub

    Private Sub VariableChanged(ByVal NewValue As String) Handles ChangeEvent.VariableChanged
        Console.WriteLine(NewValue)
        'MsgBox(NewValue)
        'Establish connection with database

        cmdEvent.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & NewValue & "','SWIFT MESSAGE IMPORT FILE: '+ '" & SwiftMessageFileName & "' + ' SWIFT STATEMENTS/CHARGES REQUESTS IMPORT','SCHEDULED TASK')"
        cmdEvent.ExecuteNonQuery()

    End Sub

End Module
