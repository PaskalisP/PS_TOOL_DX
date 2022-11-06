Imports System.Data.SqlClient
Partial Class ClearingDataSet
End Class

Namespace ClearingDataSetTableAdapters
    Partial Class GMPS_PAYMENTS_OUTTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
    Partial Class GMPS_PAYMENTS_INTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
    Partial Class ODAS_REMMITANCESTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace
