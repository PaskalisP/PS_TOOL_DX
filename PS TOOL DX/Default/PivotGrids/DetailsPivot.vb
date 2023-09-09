Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Public Class DetailsPivot

    Dim SelectedColumn As String = Nothing

    Sub New()
        InitSkins()
        InitializeComponent()
        SkinManager.EnableMdiFormSkins()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(CurrentSkinName)
    End Sub



    Private Sub DetailsPivot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "Pivot Cell Details "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PivotDetailsBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PivotDetailsBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.ControlLight
        End If
    End Sub

    Private Sub PivotDetailsBaseView_ShownEditor(sender As Object, e As EventArgs) Handles PivotDetailsBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub PivotDetailsBaseView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles PivotDetailsBaseView.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_DisplayDate As New DevExpress.Utils.Menu.DXMenuItem("DateFormat", New EventHandler(AddressOf MyMenuItem_DisplayDate), ImageCollection1.Images(0))
            Dim menuItem_DisplayNumericN0 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N0", New EventHandler(AddressOf MyMenuItem_DisplayNumericN0), ImageCollection1.Images(1))
            Dim menuItem_DisplayNumericN1 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N1", New EventHandler(AddressOf MyMenuItem_DisplayNumericN1), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN2 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N2", New EventHandler(AddressOf MyMenuItem_DisplayNumericN2), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN3 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N3", New EventHandler(AddressOf MyMenuItem_DisplayNumericN3), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN4 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N4", New EventHandler(AddressOf MyMenuItem_DisplayNumericN4), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN5 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N5", New EventHandler(AddressOf MyMenuItem_DisplayNumericN5), ImageCollection1.Images(2))


            menuItem_DisplayDate.Tag = e.Menu
            menuItem_DisplayNumericN0.Tag = e.Menu
            menuItem_DisplayNumericN1.Tag = e.Menu
            menuItem_DisplayNumericN2.Tag = e.Menu
            menuItem_DisplayNumericN3.Tag = e.Menu
            menuItem_DisplayNumericN4.Tag = e.Menu
            menuItem_DisplayNumericN5.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_DisplayDate)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN0)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN1)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN2)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN3)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN4)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN5)

        End If
    End Sub

    Private Sub MyMenuItem_DisplayDate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                col.DisplayFormat.FormatString = "d"
            End If
        Next

    End Sub

    Private Sub MyMenuItem_DisplayNumericN0(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n0"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n1"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n2"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n3"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n4"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In PivotDetailsBaseView.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n5"
            End If
        Next
    End Sub

    Private Sub PivotDetailsBaseView_MouseDown(sender As Object, e As MouseEventArgs) Handles PivotDetailsBaseView.MouseDown
        Dim focusedView As GridView = CType(GridControl2.FocusedView, GridView)
        If focusedView.RowCount > 0 Then
            Dim ghi As GridHitInfo = focusedView.CalcHitInfo(e.Location)
            If ghi.InColumn Then
                SelectedColumn = ghi.Column.Name
                'MessageBox.Show(SelectedColumn)
            End If

        End If
    End Sub
End Class