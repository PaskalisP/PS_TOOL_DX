Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Spreadsheet

Public Class TESTING
    Inherits System.Windows.Forms.Form

    Private Shared Sub VB_ScriptForExecution()
        'Dim c As New Form
        'c.Text = "TEST"
        'c.Show()
        'MsgBox("OK")

Dim connectionString As String = "Data Source=DESKTOP-SLJQ4B6;Initial Catalog=PS TOOL DX Live;Integrated Security=True;Connection Timeout=60"
Using connection As New SqlConnection(connectionString)
    ' Open the connection
    connection.Open()

    ' Define the SQL command to execute
    Dim sqlCommandText As String = "Select [Name Bank] from [Bank]"

    ' Create a new SqlCommand object with the SQL command and connection
    Using sqlCommand As New SqlCommand(sqlCommandText, connection)
        ' Execute the SQL command
        Dim NameBank As String = sqlCommand.ExecuteScalar()

        ' Print the number of rows affected by the SQL command
         XtraMessageBox.Show("Name Bank: " & NameBank)
    End Using
 connection.Close()
    End Using

        Dim i1, i2 As Integer
        Dim result As Double = 0
        i1 = 13
        i2 = 15
        result = i1 + i2
        XtraMessageBox.Show("Result is : " & result)

Dim workbook As New DevExpress.Spreadsheet.Workbook()
Dim worksheets As WorksheetCollection = workbook.Worksheets
Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets(0)
worksheet.Range("A1").NumberFormat = "#0.00"
worksheet.Range("A2").NumberFormat = "#0.00"
worksheet.Range("A3").NumberFormat = "#0.00"
worksheet.Range("A4").NumberFormat = "#0.0000000000"
worksheet.Range("A1").Value = 0.95
worksheet.Range("A2").Value = 0.25
worksheet.Range("A3").Value = 4
worksheet.Range("A4").Formula = "=ROUND(GAMMAINV(A1;A2;A3);10)"
Dim GAMMA_INV As Double = worksheet.Range("A4").Value.NumericValue


XtraMessageBox.Show("GAMMA INVERSE CALCULATION is : " & vbNewLine & GAMMA_INV)



    End Sub
End Class