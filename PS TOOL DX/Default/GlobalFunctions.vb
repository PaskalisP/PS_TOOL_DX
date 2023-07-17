Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel

Module GlobalFunctions

    Public Function OpenSqlConnections() As SqlConnection
        cmd.CommandTimeout = 60000
        cmd1.CommandTimeout = 60000
        cmd2.CommandTimeout = 60000
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        If cmd1.Connection.State = ConnectionState.Closed Then
            cmd1.Connection.Open()
        End If
        If cmd2.Connection.State = ConnectionState.Closed Then
            cmd2.Connection.Open()
        End If

        Return conn
        Return conn1
        Return conn2
    End Function

    Public Function CloseSqlConnections() As SqlConnection
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        If cmd1.Connection.State = ConnectionState.Open Then
            cmd1.Connection.Close()
        End If
        If cmd2.Connection.State = ConnectionState.Open Then
            cmd2.Connection.Close()
        End If
        Return conn
        Return conn1
        Return conn2
    End Function

    Public Function OpenSYSTEM_SqlConnection() As SqlConnection
        cmdSYSTEM.CommandTimeout = 60000
        If cmdSYSTEM.Connection.State = ConnectionState.Closed Then
            cmdSYSTEM.Connection.Open()
        End If
        Return connSYSTEM
    End Function

    Public Function CloseSYSTEM_SqlConnection() As SqlConnection
        If cmdSYSTEM.Connection.State = ConnectionState.Open Then
            cmdSYSTEM.Connection.Close()
        End If
        Return connSYSTEM
    End Function

    Public Function OpenEVENT_SqlConnection() As SqlConnection
        cmdEVENT.CommandTimeout = 60000
        If cmdEVENT.Connection.State = ConnectionState.Closed Then
            cmdEVENT.Connection.Open()
        End If
        Return connEVENT
    End Function

    Public Function CloseEVENT_SqlConnection() As SqlConnection
        If cmdEVENT.Connection.State = ConnectionState.Open Then
            cmdEVENT.Connection.Close()
        End If
        Return connEVENT
    End Function

    Public Function OpenVbScript_SqlConnection() As SqlConnection
        cmdVbScript.CommandTimeout = 60000
        If cmdVbScript.Connection.State = ConnectionState.Closed Then
            cmdVbScript.Connection.Open()
        End If
        Return connVbScript
    End Function

    Public Function CloseVbScript_SqlConnection() As SqlConnection
        If cmdVbScript.Connection.State = ConnectionState.Open Then
            cmdVbScript.Connection.Close()
        End If
        Return connVbScript
    End Function

    Public Function Fileinfo_To_DataTable(ByVal directory As String) As DataTable
        Try
            'Create a new data table
            Dim dt As DataTable = New DataTable

            'Add the following columns:
            '                          Name
            '                          Length
            '                          Last Write Time
            ''                         Creation Time
            dt.Columns.AddRange({New DataColumn("Filename"),
                                New DataColumn("Filepath"),
                                New DataColumn("Filename_Full"),
                                New DataColumn("Last Write Time"),
                                New DataColumn("Creation Time")})

            'Loop through each file in the directory
            For Each file As IO.FileInfo In New IO.DirectoryInfo(directory).GetFiles
                'Create a new row
                Dim dr As DataRow = dt.NewRow

                'Set the data
                dr(0) = file.Name.Substring(0, file.Name.Length - file.Extension.Length)
                dr(1) = file.FullName
                dr(2) = file.Name
                dr(3) = file.LastWriteTime
                dr(4) = file.CreationTime

                'Add the row to the data table
                dt.Rows.Add(dr)
            Next

            'Return the data table
            Return dt
        Catch ex As Exception
            Console.WriteLine(ex.ToString)

            'Return nothing if something fails
            Return Nothing
        End Try
    End Function

End Module
