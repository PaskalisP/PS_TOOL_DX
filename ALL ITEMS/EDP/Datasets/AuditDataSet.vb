Imports System.Data.SqlClient.SqlDataAdapter

Partial Class AuditDataSet
End Class

Namespace AuditDataSetTableAdapters
    Partial Class AuditTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlClient.SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace