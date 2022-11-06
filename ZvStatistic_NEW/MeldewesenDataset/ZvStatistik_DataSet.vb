Imports System.Data.SqlClient
Partial Class ZvStatistik_Dataset
End Class

Namespace ZvStatistik_DataSetTableAdapters
    Partial Class ZVSTAT_ReportingTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace
