Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Spreadsheet

Public Class TESTING
    Inherits System.Windows.Forms.Form
 Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private Shared Sub VB_ScriptForExecution()
        'Dim c As New Form
        'c.Text = "TEST"
        'c.Show()
        'MsgBox("OK")

conn.ConnectionString = "Data Source=DESKTOP-SLJQ4B6;Initial Catalog=PS TOOL DX Live;Integrated Security=True;Connection Timeout=60"
cmd.Connection = conn
cmd.Connection.Open()
cmd.CommandText = "Select [Name Bank] from [Bank]"
Dim NameBank As String = cmd.ExecuteScalar()
XtraMessageBox.Show("Name Bank: " & NameBank)
cmd.Connection.close()

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