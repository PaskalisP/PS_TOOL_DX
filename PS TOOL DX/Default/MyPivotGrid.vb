Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraPivotGrid.ViewInfo


Public Class MyPivotGridControl
    Inherits PivotGridControl
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(viewInfoData As PivotGridViewInfoData)
        MyBase.New(viewInfoData)
    End Sub

    Protected Overrides Function CreateData() As PivotGridViewInfoData
        Return New MyPivotGridViewInfoData(Me)
    End Function
End Class

Public Class MyPivotGridViewInfoData
    Inherits PivotGridViewInfoData
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(control As IViewInfoControl)
        MyBase.New(control)
    End Sub
    Protected Overrides Function CreateViewInfo() As PivotGridViewInfo
        Return New MyPivotGridViewInfo(Me)
    End Function
End Class
Public Class MyPivotGridViewInfo
    Inherits PivotGridViewInfo
    Public Sub New(data As PivotGridViewInfoData)
        MyBase.New(data)
    End Sub
    'Public Overrides ReadOnly Property IsPrefilterPanelVisible() As Boolean
    '    Get
    '        Return True
    '    End Get
    'End Property
End Class

