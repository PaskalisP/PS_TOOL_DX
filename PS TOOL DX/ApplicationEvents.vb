Imports System.Data.SqlClient
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

        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand





        Protected Overrides Function OnInitialize( _
    ByVal commandLineArgs As  _
    System.Collections.ObjectModel.ReadOnlyCollection(Of String) _
) As Boolean
            ' Set the display time to 5000 milliseconds (5 seconds). 
            Me.MinimumSplashScreenDisplayTime = 8000
            Return MyBase.OnInitialize(commandLineArgs)
        End Function

        Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged

            conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
            cmd.Connection = conn

            If My.Computer.Network.IsAvailable = False Then
                XtraMessageBox.Show("There's no available Network Connection!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "MISSING NETWORK CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Environment.Exit(2)
                'System.Windows.Forms.Application.Exit()
                'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.Close_all_Forms_BarButtonItem.PerformClick()
                'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.CloseAndExit_BarSubItem.PerformClick()
            End If
            If My.Computer.Network.IsAvailable = True Then
                If cmd.Connection.State = ConnectionState.Broken Then

                    XtraMessageBox.Show("Connection with the SQL Database is lost!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "MISSING SQL DATABASE CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Environment.Exit(2)
                    'System.Windows.Forms.Application.Exit()
                    'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.Close_all_Forms_BarButtonItem.PerformClick()
                    'PS_TOOL_DX.My.Forms.PSTOOL_MAIN_Form.CloseAndExit_BarSubItem.PerformClick()
                End If

            End If

        End Sub


        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
            cmd.Connection = conn

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

            If My.Computer.Network.IsAvailable = False Then
                XtraMessageBox.Show("There's no available Network Connection!" & vbNewLine & "Application will be closed!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "MISSING NETWORK CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Environment.Exit(2)

                'System.Windows.Forms.Application.Exit()

            ElseIf My.Computer.Network.IsAvailable = True Then
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                Try
                    cmd.CommandText = "Exec [GET_LOGIN_USER]"
                    Dim result As Integer = cmd.ExecuteScalar
                    If result = 0 Then
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        XtraMessageBox.Show("Current User is not registered User in the PS TOOL Database or " & vbNewLine & "has not permissions!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "NO REGISTERED USER/NO PERMISSIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Environment.Exit(2)
                    End If



                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message & vbNewLine & vbNewLine & "Current User is not registered User in the PS TOOL Database or " & vbNewLine & "has not permissions!" & vbNewLine & vbNewLine & "Please contact your Network Administrator!!", "NO REGISTERED USER/NO PERMISSIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Environment.Exit(2)
                End Try
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            End If



            System.Threading.Thread.Sleep(5000)

            'SplashScreenManager.CloseDefaultSplashScreen()




        End Sub
    End Class





End Namespace

