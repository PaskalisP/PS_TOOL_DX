Imports System.Data.SqlClient

Partial Public Class LcDataset
End Class

Namespace LcDatasetTableAdapters
    Partial Class ALL_SWIFT_MESSAGESTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace
