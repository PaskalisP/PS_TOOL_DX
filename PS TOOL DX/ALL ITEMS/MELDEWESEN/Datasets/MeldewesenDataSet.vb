Imports System.Data.SqlClient

Partial Class MeldewesenDataSet
End Class

Namespace MeldewesenDataSetTableAdapters
    Partial Class ZVSTAT_Details_from2014TableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
    Partial Class ZVSTAT_Meldepositionen_from2014TableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
    Partial Class ZVSTAT_Meldeschemas_from2014TableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
    Partial Class ZVSTAT_MeldeJahr_from2014TableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace



