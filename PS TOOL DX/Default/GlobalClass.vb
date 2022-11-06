Imports System.IO
Public Class GlobalClass
    Public Sub NewImportEventsFolder()
        'Check Import Events File
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(ImportEventsDirectory)
        If infoReader.Length > 5000000 Then
            Dim CurrentDate As Date = Today
            Dim TillDateString = CurrentDate.ToString("ddMMyyyy")
            Dim FromDateString As String = Microsoft.VisualBasic.Left(ReadLineWithNumberFrom(ImportEventsDirectory, 0).ToString.Replace(".", ""), 8)
            Dim FromDateStringNew As String = FromDateString.ToString.Replace("/", "") ' Replace if Date is in American Format
            Dim Newfilepath As String = "PSTOOL_ImportEvents_" & FromDateStringNew & "_till_" & TillDateString & ".txt"
            My.Computer.FileSystem.RenameFile(ImportEventsDirectory, Newfilepath)
            If Not System.IO.File.Exists(ImportEventsDirectory) Then
                System.IO.File.Create(ImportEventsDirectory).Dispose()

            End If

        End If
    End Sub
End Class
