Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.CodeDom.Compiler
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection
Imports System
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.XtraEditors

Module GlobalVariables

    Public conn As SqlConnection = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
    Public conn1 As SqlConnection = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
    Public conn2 As SqlConnection = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
    Public connSYSTEM As SqlConnection = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
    Public connEVENT As SqlConnection = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
    Public connVbScript As SqlConnection = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)

    Public cmd As SqlCommand = New SqlCommand(Nothing, conn)
    Public cmd1 As SqlCommand = New SqlCommand(Nothing, conn1)
    Public cmd2 As SqlCommand = New SqlCommand(Nothing, conn2)
    Public cmdSYSTEM As SqlCommand = New SqlCommand(Nothing, connSYSTEM)
    Public cmdEVENT As SqlCommand = New SqlCommand(Nothing, connEVENT)
    Public cmdVbScript As SqlCommand = New SqlCommand(Nothing, connVbScript)

    Public QueryText As String = Nothing
    Public QueryText1 As String = Nothing
    Public SqlCommandText As String = Nothing
    Public SqlCommandText1 As String = Nothing
    Public SqlCommandText2 As String = Nothing
    Public ScriptType As String = Nothing

    Public da As SqlDataAdapter
    Public dt As System.Data.DataTable
    Public da1 As SqlDataAdapter
    Public dt1 As System.Data.DataTable
    Public da2 As SqlDataAdapter
    Public dt2 As System.Data.DataTable
    Public da3 As SqlDataAdapter
    Public dt3 As System.Data.DataTable
    Public da4 As SqlDataAdapter
    Public dt4 As System.Data.DataTable
    Public da5 As SqlDataAdapter
    Public dt5 As System.Data.DataTable
    Public daInfo As New SqlDataAdapter
    Public dtInfo As New DataTable

    Public daSqlQueries As SqlDataAdapter
    Public dtSqlQueries As System.Data.DataTable
    Public da1SqlQueries As SqlDataAdapter
    Public dt1SqlQueries As System.Data.DataTable
    Public daSqlFileCompare As SqlDataAdapter
    Public dtSqlFileCompare As System.Data.DataTable
    Public da1SqlFileCompare As SqlDataAdapter
    Public dt1SqlFileCompare As System.Data.DataTable

    Public daUsers As SqlDataAdapter
    Public dtUsers As System.Data.DataTable
    Public dtUsersRow As System.Data.DataRow
    Public dtColUsers As System.Data.DataColumn


    Public d As Date = Today
    Public rd As Date
    Public rdsql As String = rd.ToString("yyyyMMdd")
    Public rd1 As Date
    Public rdsql1 As String = rd1.ToString("yyyyMMdd")
    Public rd_Entered As Date
    Public rdsql_Entered As String = rd_Entered.ToString("yyyyMMdd")
    Public rdsql_EnteredYear As String = rd_Entered.ToString("yyyy")

    Public CurrentUserSqlID As String = Nothing
    Public CurrentUserWindowsID As String = Nothing
    Public SessionNr As Double = 0

    Public CurrentProcedureName As String = Nothing
    Public CurrentSystemName As String = Nothing
    Public CurrentSystemExecuting As String = Nothing

    'Application Database
    Public DEFAULT_DOMAIN As String = Nothing
    Public DATABASE_ENVIRONMENT As String = Nothing
    Public TOOL_SQL_SERVER As String = Nothing
    Public TOOL_SQL_SERVER_ONLY As String = Nothing
    Public TOOL_SQL_SERVER_VERSION As String = Nothing
    Public TOOL_SQL_DATABASE As String = Nothing

    Public DeactivatedUserStatus_TextEdit As New DevExpress.XtraEditors.TextEdit
    Public ExecutingSQLThreadSleep As Integer = 0

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
    Public CLEARING_USER As String = Nothing
    Public COMPLIANCE_USER As String = Nothing
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
    Public SELECTED_DATES As String = Nothing
    Public SELECTED_DATES_AS_SQL_VALUES As String = Nothing


    'Global Variables in CUSTOMER_ADD Form
    Public CCB_Group As String = Nothing
    Public CCB_Group_Own_ID As String = Nothing
    Public CIC_Group As String = Nothing
    Public CustomerType As String = Nothing

    'Global Variables in PS TOOL Client for Alerts
    Public OutstandingRatingAlert As Integer = 0
    Public OutstandingNewCustomerAlert As Integer = 0

    'Global Client + Contract Nr
    Public GLOBAL_CLIENT_NR As String = Nothing
    Public GLOBAL_CONTRACT_NR As String = Nothing

    'Global BAIS Version Nr
    Public BAIS_VERSION_NR As Double = 0

    'Global EAEG
    Public EAEG_FILE_DIR As String = Nothing

    'Layouts
    Public PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR As String = Nothing


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



    Public Sub XFormDialog_Shown(ByVal sender As Object, ByVal e As EventArgs)
        'CType(sender, XtraDialogForm).ClientSize = New Size(1000, 1000)
        CType(sender, XtraDialogForm).Size = New Size(1200, 700)
        CType(sender, XtraDialogForm).StartPosition = FormStartPosition.CenterScreen
        CType(sender, XtraDialogForm).FormBorderStyle = FormBorderStyle.Sizable
    End Sub

End Module
