Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen



Namespace My


    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            ' Set the display time to 5000 milliseconds (5 seconds). 
            Me.MinimumSplashScreenDisplayTime = 5000
            Return MyBase.OnInitialize(commandLineArgs)
        End Function

        Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged

            If My.Computer.Network.IsAvailable = False Then
                Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                args.AutoCloseOptions.ShowTimerOnDefaultButton = True
                args.AutoCloseOptions.Delay = 5000
                args.Caption = "MISSING NETWORK CONNECTION"
                args.Text = "There's no available Network Connection!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!"
                args.Icon = System.Drawing.SystemIcons.Error
                args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)
                'XtraMessageBox.Show("There's no available Network Connection!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "MISSING NETWORK CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Environment.Exit(2)
                'System.Windows.Forms.Application.Exit()
                'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.Close_all_Forms_BarButtonItem.PerformClick()
                'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.CloseAndExit_BarSubItem.PerformClick()
            End If
            If My.Computer.Network.IsAvailable = True Then
                If cmd.Connection.State = ConnectionState.Broken Then
                    Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = True
                    args.AutoCloseOptions.Delay = 5000
                    args.Caption = "MISSING SQL DATABASE CONNECTION"
                    args.Text = "Connection with the SQL Database is lost!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!"
                    args.Icon = System.Drawing.SystemIcons.Error
                    args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
                    XtraMessageBox.SmartTextWrap = True
                    XtraMessageBox.Show(args)

                    'XtraMessageBox.Show("Connection with the SQL Database is lost!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "MISSING SQL DATABASE CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Environment.Exit(2)
                    'System.Windows.Forms.Application.Exit()
                    'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.Close_all_Forms_BarButtonItem.PerformClick()
                    'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.CloseAndExit_BarSubItem.PerformClick()
                End If

            End If

        End Sub


        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            Dim splash As PSTOOL_SplashScreen1 = CType(My.Application.SplashScreen, PSTOOL_SplashScreen1)
            My.Application.SplashScreen = PSTOOL_SplashScreen1

            '+++ERROR on Application Run
            '+++Invoke or BeginInvoke cannot be called on a control until the window handle has been created
            '++++See link:http://stackoverflow.com/questions/25644824/vb-net-invoke-cannot-be-called-on-a-control-until-the-window-handle-has-been-cre
            'SplashScreenManager.ShowForm(GetType(PSTOOL_SplashScreen1))
            'Dim MadeUpSteps() As String = {"Initializing...", "Authenticating...", "Retrieving User Information...", "Loading Components..."}
            'For i As Integer = 0 To MadeUpSteps.Length - 1
            'SplashScreenManager.Default.SendCommand(PSTOOL_SplashScreen1.SplashScreenCommand.SetCaption, MadeUpSteps(i))

            'If i = 3 Then

            'Threading.Thread.Sleep(2000)

            'Next
            CurrentUserWindowsID = SystemInformation.UserName

            'Check If User is able to switch between Databases (Prod and Test) from app.config
            Dim Switch_DB_User_Array As String() = System.Configuration.ConfigurationManager.AppSettings("Switch_DB_User").Split(","c)
            Dim index As Integer = Array.IndexOf(Switch_DB_User_Array, CurrentUserWindowsID)
            'User has rights
            If index >= 0 Then
                Dim c As New LoginForm
                If DevExpress.XtraEditors.XtraDialog.Show(c, "Select Database Environment", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    DB_Environment = c.Environment_SearchLookUpEdit.EditValue.ToString
                    Select Case DB_Environment
                        Case = "Production"
                            DATABASE_ENVIRONMENT = "Production"
                            conn = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            conn1 = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            conn2 = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            connSYSTEM = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            connEVENT = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            connVbScript = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            cmd = New SqlCommand(Nothing, conn)
                            cmd1 = New SqlCommand(Nothing, conn1)
                            cmd2 = New SqlCommand(Nothing, conn2)
                            cmdSYSTEM = New SqlCommand(Nothing, connSYSTEM)
                            cmdEVENT = New SqlCommand(Nothing, connEVENT)
                            cmdVbScript = New SqlCommand(Nothing, connVbScript)
                            'My.Settings.Item("PDataTool.Settings.DataConnectionString") = GetConnectionString()
                            'My.Settings.Save()

                            'Dim k As Common.DbConnectionStringBuilder = New Common.DbConnectionStringBuilder() With
                            '{.ConnectionString = My.Settings.DataConnectionString}
                            'MsgBox(k.ToString)
                            'Get the default Connection String wich is also declared as read only in the DataSet TableAdapters
                            Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            'Create new ConnectioString based on the default
                            Dim sqlConnString As New System.Data.SqlClient.SqlConnectionStringBuilder() With {
                            .DataSource = builder.DataSource,
                            .InitialCatalog = builder.InitialCatalog,
                            .IntegratedSecurity = True,'.Encrypt = True,'.TrustServerCertificate = True,
                            .ConnectTimeout = 60}
                            'MsgBox(My.Settings("DataConnectionString").ToString & vbNewLine & k.ToString)
                            'MsgBox(sqlConnString.ToString)
                            'Set new ConnectionString to Settings and save it
                            My.Settings("PS_TOOL_DX_SQL_Client_ConnectionString") = sqlConnString.ToString

                            'Get the default Connection String wich is also declared as read only in the DataSet TableAdapters
                            Dim OLEDBbuilder As OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder(My.Settings.PSTOOLConnectionString_OLEDB)
                            'Set new ConnectionString to Settings and save it
                            My.Settings("PSTOOLConnectionString_OLEDB") = OLEDBbuilder.ToString

                            'Save the new settings
                            My.Settings.Save()


                        Case = "Test"
                            DATABASE_ENVIRONMENT = "Test"
                            conn = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            conn1 = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            conn2 = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            connSYSTEM = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            connEVENT = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            connVbScript = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            cmd = New SqlCommand(Nothing, conn)
                            cmd1 = New SqlCommand(Nothing, conn1)
                            cmd2 = New SqlCommand(Nothing, conn2)
                            cmdSYSTEM = New SqlCommand(Nothing, connSYSTEM)
                            cmdEVENT = New SqlCommand(Nothing, connEVENT)
                            cmdVbScript = New SqlCommand(Nothing, connVbScript)
                            'My.Settings.Item("PDataTool.Settings.ABC_DataConnectionString") = GetConnectionString()
                            'My.Settings.Save()

                            'Get the relevant Connection String wich needs to be declared for all DataSet Tableadapters
                            Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(My.Settings.PS_TOOL_DX_SQL_ClientTEST_ConnectionString)
                            'Create new ConnectioString based on the declared one
                            Dim sqlConnString As New System.Data.SqlClient.SqlConnectionStringBuilder() With {
                            .DataSource = builder.DataSource,
                            .InitialCatalog = builder.InitialCatalog,
                            .IntegratedSecurity = True,'.Encrypt = True,'.TrustServerCertificate = True,
                            .ConnectTimeout = 60}
                            'Set new ConnectionString to Settings and save it
                            My.Settings("PS_TOOL_DX_SQL_Client_ConnectionString") = sqlConnString.ToString

                            'Get the default Connection String wich is also declared as read only in the DataSet TableAdapters
                            Dim OLEDBbuilder As OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder(My.Settings.PSTOOLConnectionStringTEST_OLEDB)
                            'Set new ConnectionString to Settings and save it
                            My.Settings("PSTOOLConnectionString_OLEDB") = OLEDBbuilder.ToString


                            My.Settings.Save()


                        Case Else
                            XtraMessageBox.Show("Please select the related Environment " & vbNewLine & "for the Application!", "ENVIRONMENT SELECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                    End Select
                Else
                    Environment.Exit(2)
                End If
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ElseIf index < 0 Then
                'User has no rights
                DATABASE_ENVIRONMENT = "Production"
            End If


            If My.Computer.Network.IsAvailable = False Then
                Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                args.AutoCloseOptions.ShowTimerOnDefaultButton = True
                args.AutoCloseOptions.Delay = 5000
                args.Caption = "MISSING NETWORK CONNECTION"
                args.Text = "There's no available Network Connection!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!"
                args.Icon = System.Drawing.SystemIcons.Error
                args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)

                'XtraMessageBox.Show("There's no available Network Connection!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "MISSING NETWORK CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Environment.Exit(2)

                'System.Windows.Forms.Application.Exit()

            ElseIf My.Computer.Network.IsAvailable = True Then
                OpenSqlConnections()
                Try
                    'Check if User is registered to the Server/Database
                    cmd.CommandText = "Exec [GET_LOGIN_USER]"
                    Dim result As Integer = cmd.ExecuteScalar
                    If result = 0 Then
                        CloseSqlConnections()
                        Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = True
                        args.AutoCloseOptions.Delay = 5000
                        args.Caption = "NO REGISTERED USER/NO PERMISSIONS"
                        args.Text = "Current User: " & CurrentUserWindowsID & " is not registered in the " & DATABASE_ENVIRONMENT & " PS TOOL Database or " & vbNewLine & "has not permissions!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!"
                        args.Icon = System.Drawing.SystemIcons.Error
                        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
                        XtraMessageBox.SmartTextWrap = True
                        XtraMessageBox.Show(args)

                        'XtraMessageBox.Show("Current User: " & CurrentUserWindowsID & " is not registered in the " & DATABASE_ENVIRONMENT & " PS TOOL Database or " & vbNewLine & "has not permissions!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "NO REGISTERED USER/NO PERMISSIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Environment.Exit(2)
                    Else
                        'Get Application SQL Server
                        cmd.CommandText = "Select dbo.GetStringPartByDelimeter(@@version,'(',1)"
                            TOOL_SQL_SERVER_VERSION = CStr(cmd.ExecuteScalar)
                            TOOL_SQL_SERVER = conn.DataSource & " - " & TOOL_SQL_SERVER_VERSION
                            TOOL_SQL_SERVER_ONLY = conn.DataSource
                            TOOL_SQL_DATABASE = conn.Database
                            'Get all Tables and Columns
                            cmd.CommandText = "DELETE FROM [ALL_TABLE_COLUMNS]
                                       TRUNCATE TABLE [ALL_TABLE_COLUMNS]

                                        INSERT INTO [ALL_TABLE_COLUMNS]
                                                    ([TABLE_CATALOG]
                                                    ,[TABLE_SCHEMA]
                                                    ,[TABLE_NAME]
                                                    ,[COLUMN_NAME]
                                                    ,[ORDINAL_POSITION]
                                                    ,[COLUMN_DEFAULT]
                                                    ,[IS_NULLABLE]
                                                    ,[DATA_TYPE]
                                                    ,[CHARACTER_MAXIMUM_LENGTH]
                                                    ,[CHARACTER_OCTET_LENGTH]
                                                    ,[NUMERIC_PRECISION]
                                                    ,[NUMERIC_PRECISION_RADIX]
                                                    ,[NUMERIC_SCALE]
                                                    ,[DATETIME_PRECISION]
                                                    ,[CHARACTER_SET_CATALOG]
                                                    ,[CHARACTER_SET_SCHEMA]
                                                    ,[CHARACTER_SET_NAME]
                                                    ,[COLLATION_CATALOG]
                                                    ,[COLLATION_SCHEMA]
                                                    ,[COLLATION_NAME]
                                                    ,[DOMAIN_CATALOG]
                                                    ,[DOMAIN_SCHEMA]
                                                    ,[DOMAIN_NAME]) 
                                         SELECT * FROM information_schema.Columns"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
                            CrystalRepDir = cmd.ExecuteScalar
                            'Get EAEG File directory
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EAEG_File_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EAEG_CREATION_PATH'"
                            EAEG_FILE_DIR = cmd.ExecuteScalar
                            'Get UserID Sessions
                            cmd.CommandText = "DECLARE @CurrentUserWindowsID nvarchar(255)='" & CurrentUserWindowsID & "' 
                                           Select 'UserID'=
                                           Case when (Select Count(ID) from [CURRENT USERS] where [UserName]=@CurrentUserWindowsID)=0 then 1 
                                           when (Select Count(ID) from [CURRENT USERS] where [UserName]=@CurrentUserWindowsID)>0 then 
                                           (Select Max(SessionID)+1 from [CURRENT USERS] where [UserName]=@CurrentUserWindowsID) end"
                            PSTOOL_SessionID = cmd.ExecuteScalar
                            'Insert UserID session
                            cmd.CommandText = "DECLARE @CurrentUserWindowsID nvarchar(255)='" & CurrentUserWindowsID & "'
                                           INSERT INTO [CURRENT USERS] 
                                           ([UserName]
                                            ,[Logged on]
                                            ,[HostName]
                                            ,[IP_Address]
                                            ,[SessionID]) 
                                            Values 
                                            (@CurrentUserWindowsID
                                            ,Getdate() 
                                            ,(SELECT HOST_NAME())
                                            ,(SELECT client_net_address FROM sys.dm_exec_connections WHERE session_id = @@SPID)
                                            , " & Str(PSTOOL_SessionID) & ")"
                            cmd.ExecuteNonQuery()


                    End If
                        CloseSqlConnections()


                Catch ex As Exception
                    CloseSqlConnections()
                    Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = True
                    args.AutoCloseOptions.Delay = 5000
                    args.Caption = "NO REGISTERED USER/NO PERMISSIONS"
                    args.Text = "Current User: " & CurrentUserWindowsID & " is not registered in the " & DATABASE_ENVIRONMENT & " PS TOOL Database or " & vbNewLine & "has not permissions!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!"
                    args.Icon = System.Drawing.SystemIcons.Error
                    args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
                    XtraMessageBox.SmartTextWrap = True
                    XtraMessageBox.Show(args)
                    'XtraMessageBox.Show("Current User: " & CurrentUserWindowsID & " is not registered in the " & DATABASE_ENVIRONMENT & " PS TOOL Database or " & vbNewLine & "has not permissions!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "NO REGISTERED USER/NO PERMISSIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Environment.Exit(2)
                End Try
                CloseSqlConnections()

            End If



            System.Threading.Thread.Sleep(5000)

            'SplashScreenManager.CloseDefaultSplashScreen()




        End Sub
    End Class





End Namespace

