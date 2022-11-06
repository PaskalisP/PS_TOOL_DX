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
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns


Public Class FlashedCell
    Inherits GridCell

    Private timer As New Timer()

    Public Sub New(ByVal rowHandle As Integer, ByVal column As GridColumn, ByVal view As GridView)
        MyBase.New(rowHandle, column)
        _View = view
        AddHandler view.RowCellStyle, AddressOf view_RowCellStyle
        AddHandler timer.Tick, AddressOf timer_Tick
        timer.Enabled = True
    End Sub

    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        isColored = Not isColored
        _View.RefreshRowCell(RowHandle, Column)
    End Sub

    Private isColored As Boolean
    Private Sub view_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        If isColored Then
            If e.RowHandle = RowHandle AndAlso e.Column Is Column Then
                e.Appearance.Assign(FlashedCellsHelper.FlashedCellAppearance)
            End If
        End If
    End Sub

    Private _Speed As Integer
    Private ReadOnly _View As GridView
    Public Property Speed() As Integer
        Get
            Return _Speed
        End Get
        Set(ByVal value As Integer)
            If value < 0 OrElse _Speed = value Then
                Return
            End If
            _Speed = value
            timer.Stop()
            If (_Speed = 0) Then
                Return
            End If
            timer.Interval = value
            timer.Start()
        End Set
    End Property


End Class

