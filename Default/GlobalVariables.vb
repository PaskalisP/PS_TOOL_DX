Imports System.IO
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Module GlobalVariables
    'Import events directory
    Public ImportEventsDirectory As String = Nothing
    Public ImportEventsDirectoryFolder As String = Nothing
    Public TextImportFileRow As String = Nothing
    Public ExcelParameterFile As String = Nothing
    Public UserGuideFile As String = Nothing
    Public KundenZinsenOhnePlzBundesland As Double = 0
    Public KundenZinsenPLZ_EAEG As Double = 0
    Public PSTOOL_SessionID As Double = 0
    Public CurrentSkinName As String = Nothing

    Public SUPER_USER As String = Nothing
    Public EDP_USER As String = Nothing
    Public AML_USER As String = Nothing
    Public FOREIGN_USER As String = Nothing
    Public SECURITIES_USER As String = Nothing
    Public ACCOUNTING_USER As String = Nothing
    Public ACCOUNTING_NOSTRO_RECONCILIATION_STATUS As String = Nothing
    Public ACCOUNTING_SUSPENCE_RECONCILIATION_STATUS As String = Nothing
    Public RISKCONTROLLING_USER As String = Nothing
    Public MELDEWESEN_USER As String = Nothing
    Public MANAGEMENT_USER As String = Nothing
    Public EAEG_USER As String = Nothing
    Public TREASURY_USER As String = Nothing
    Public CREDIT_USER As String = Nothing
    Public CrystalRepDir As String = Nothing

    Public ACTIVE_DIRECTORY_NEW_USER_ALERT As String = Nothing
    Public BUNDESBANK_RESERVE_END_DATE_ALERT As String = Nothing
    Public EAEG_KUNDEN_AENDERUNG_ALERT As String = Nothing
    Public EAEG_KUNDEN_NEU_ALERT As String = Nothing
    Public IMPORT_ERRORS_ALERT As String = Nothing
    Public NOSTRO_ACC_WITHOUT_STATEMENT_INDICATION_ALERT As String = Nothing
    Public ONLINE_BANKING_ACCOUNTS_ALERT As String = Nothing
    Public TARGET_HOLIDAY_ALERT As String = Nothing
    Public UNRATED_CUSTOMERS_ALERT As String = Nothing
    Public UPDATE_ODAS_FX_DEALS As String = Nothing
    Public NEW_CUSTOMER_ALERT As String = Nothing
    Public NEW_CURRENCY_ALERT As String = Nothing
    Public BS_DIFFERENCE_ALERT As String = Nothing
    Public GROUP_COUNTRIES_NUMMERIC_ALERT As String = Nothing


    'Global Variables in CUSTOMER_ADD Form
    Public CCB_Group As String = Nothing
    Public CCB_Group_Own_ID As String = Nothing
    Public CIC_Group As String = Nothing

    'Global Variables in PS TOOL Client for Alerts
    Public OutstandingRatingAlert As Integer = 0
    Public OutstandingNewCustomerAlert As Integer = 0



    Public Function ReadLineWithNumberFrom(filePath As String, ByVal lineNumber As Integer) As String
        Using file As New StreamReader(filePath)
            ' Skip all preceding lines: '
            For i As Integer = 1 To lineNumber - 1
                If file.ReadLine() Is Nothing Then
                    Throw New ArgumentOutOfRangeException("lineNumber")
                End If
            Next
            ' Attempt to read the line you're interested in: '
            Dim line As String = file.ReadLine()
            If line Is Nothing Then
                Throw New ArgumentOutOfRangeException("lineNumber")
            End If
            ' Succeded!
            Return line
        End Using
    End Function

    Public Function GMTDiff(ByVal vDate As Date) As Long
        ' Zeit-Differenz zur GMT-Zeitangabe in Stunden
        Return Val(vDate.ToString("zzzz").Substring(0, 3))
    End Function

    Public Function getNumeric(value As String) As String
        Dim output As StringBuilder = New StringBuilder
        For i = 0 To value.Length - 1
            If IsNumeric(value(i)) Then
                output.Append(value(i))
            End If
        Next
        Return output.ToString()
    End Function

    Public Function LoadScript(ByVal filename As String) As String

        Try

            ' Create an instance of StreamReader to read from our file. 
            ' The using statement also closes the StreamReader. 
            Dim sr As New StreamReader(filename)

            ' use a string builder to get all our lines from the file 
            Dim fileContents As New StringBuilder()

            ' string to hold the current line 
            Dim curLine As String = ""

            ' loop through our file and read each line into our 
            ' stringbuilder as we go along 
            Do
                ' read each line and MAKE SURE YOU ADD BACK THE 
                ' LINEFEED THAT IT THE ReadLine() METHOD STRIPS OFF 
                curLine = sr.ReadLine()
                fileContents.Append(curLine + vbCrLf)
            Loop Until curLine Is Nothing

            ' close our reader now that we are done 
            sr.Close()

            ' call RunScript and pass in our file contents 
            ' converted to a string 
            Return fileContents.ToString()

        Catch e As Exception
            ' Let the user know what went wrong. 
            Dim errorText As String = "The file could not be read:"
            errorText += e.Message + "\n"
            Return errorText
        End Try

    End Function

    'Public Function RunScript(ByVal scriptText As String) As String

    '    ' create Powershell runspace 
    '    Dim MyRunSpace As Runspace = RunspaceFactory.CreateRunspace()

    '    ' open it 
    '    MyRunSpace.Open()

    '    ' create a pipeline and feed it the script text 
    '    Dim MyPipeline As Pipeline = MyRunSpace.CreatePipeline()

    '    MyPipeline.Commands.AddScript(scriptText)

    '    ' add an extra command to transform the script output objects into nicely formatted strings 
    '    ' remove this line to get the actual objects that the script returns. For example, the script 
    '    ' "Get-Process" returns a collection of System.Diagnostics.Process instances. 
    '    MyPipeline.Commands.Add("Out-String")

    '    ' execute the script 
    '    Dim results As Collection(Of PSObject) = MyPipeline.Invoke()

    '    ' close the runspace 
    '    MyRunSpace.Close()

    '    ' convert the script result into a single string 
    '    Dim MyStringBuilder As New StringBuilder()

    '    For Each obj As PSObject In results
    '        MyStringBuilder.AppendLine(obj.ToString())
    '    Next

    '    ' return the results of the script that has 
    '    ' now been converted to text 
    '    Return MyStringBuilder.ToString()

    'End Function

    Public Sub SetReportDb(ByVal ConnectionString As String, ByRef CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal reportDocument As ReportDocument)
        'Get SQL Server Details
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()

        builder.ConnectionString = ConnectionString


        Dim zServer As String = TryCast(builder("Data Source"), String)
        Dim zDatabase As String = TryCast(builder("Initial Catalog"), String)
        'Dim zUsername As String = TryCast(builder("User ID"), String)
        'Dim zPassword As String = TryCast(builder("Password"), String)

        Dim ciReportConnection As New ConnectionInfo

        ciReportConnection.ServerName = zServer
        ciReportConnection.DatabaseName = zDatabase
        ciReportConnection.IntegratedSecurity = True
        'ciReportConnection.UserID = zUsername
        'ciReportConnection.Password = zPassword

        'Assign data source details to tables

        For Each table As Table In reportDocument.Database.Tables
            table.LogOnInfo.ConnectionInfo = ciReportConnection
            table.ApplyLogOnInfo(table.LogOnInfo)
        Next

        For Each subrep As ReportDocument In reportDocument.Subreports
            For Each table As Table In subrep.Database.Tables
                table.LogOnInfo.ConnectionInfo = ciReportConnection
                table.ApplyLogOnInfo(table.LogOnInfo)
            Next
        Next

        'Assign data source details to the report viewer
        If CrystalReportViewer.LogOnInfo IsNot Nothing Then
            Dim tlInfo As TableLogOnInfos = CrystalReportViewer.LogOnInfo
            For Each tbloginfo As TableLogOnInfo In tlInfo
                tbloginfo.ConnectionInfo = ciReportConnection
            Next
        End If
        reportDocument.VerifyDatabase()
        reportDocument.Refresh()
        CrystalReportViewer.ReportSource = reportDocument
        CrystalReportViewer.Refresh()
    End Sub

End Module
