' Developer Express Code Central Example:
' How to implement a flashing cell in GridView?
' 
' This example demonstrates how to force a specific cell to flash in GridView. The
' first column allows you to specify flashing speed.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2987

' Developer Express Code Central Example:
' How to implement a flashing cell in GridView?
' 
' This example demonstrates how to force a specific cell to flash in GridView. The
' first column allows you to specify flashing speed.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2987

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils


Public Class FlashedCellsHelper

    Public Shared FlashedCellAppearance As New AppearanceObject()

    Private flashedCells As New List(Of FlashedCell)()
    Private ReadOnly _View As GridView

    Public Sub New(ByVal view As GridView)
        _View = view

    End Sub

    Private Function FindFlashedCell(ByVal rowHanlde As Integer, ByVal col As GridColumn) As FlashedCell
        For Each cell As FlashedCell In flashedCells
            If cell.RowHandle = rowHanlde AndAlso cell.Column Is col Then
                Return cell
            End If
        Next cell

        Dim result As New FlashedCell(rowHanlde, col, _View)
        flashedCells.Add(result)
        Return result
    End Function

    Public Sub SetFlashSpeed(ByVal rowHanlde As Integer, ByVal col As GridColumn, ByVal speed As Integer)
        FindFlashedCell(rowHanlde, col).Speed = speed
    End Sub
End Class

