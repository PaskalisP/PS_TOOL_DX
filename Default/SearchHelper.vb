Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports DevExpress.XtraNavBar
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks



Public Enum SearchCriteria
    Contains
    StartsWith
    Equals
End Enum

Public NotInheritable Class SearchHelper
    Private Shared navBarControl1 As NavBarControl
    Private Shared textEdit As TextEdit
    Private Shared criteria1 As SearchCriteria

    Private Sub New()
    End Sub
    Public Shared Sub CreateSearchPanel(ByVal navBarControl As NavBarControl, ByVal criteria As SearchCriteria)
        If navBarControl IsNot Nothing Then
            navBarControl1 = navBarControl
            criteria1 = criteria
            textEdit = New TextEdit()
            Dim navBarGroup As New NavBarGroup()
            navBarControl.Groups.Insert(0, navBarGroup)
            navBarGroup.GroupStyle = NavBarGroupStyle.ControlContainer
            navBarGroup.Caption = "Search"
           
            navBarGroup.ControlContainer.Controls.Add(textEdit)
            textEdit.Dock = System.Windows.Forms.DockStyle.Fill
            textEdit.Visible = True
            textEdit.Properties.CharacterCasing = CharacterCasing.Upper
            textEdit.Properties.Appearance.BackColor = Color.LightYellow
            textEdit.Properties.Appearance.BackColor = Color.Black
            textEdit.Properties.AppearanceFocused.BackColor = Color.Yellow
            textEdit.Properties.AppearanceFocused.ForeColor = Color.Black

            navBarGroup.GroupClientHeight = 26
            navBarGroup.Expanded = True
            navBarControl.Groups.Add(navBarGroup)

            AddHandler navBarControl.CustomDrawGroupCaption, AddressOf navBarControl_CustomDrawGroupCaption
            AddHandler textEdit.EditValueChanged, AddressOf textEdit_EditValueChanged
        End If
    End Sub

    Private Shared Sub navBarControl_CustomDrawGroupCaption(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs)
        If e.Caption = "Search" Then
            Dim rect As Rectangle = e.RealBounds
            rect.Inflate(-10, -5)

            e.Graphics.DrawString(e.Caption, e.Appearance.Font, Brushes.LightYellow, rect)
            e.Handled = True
        End If
    End Sub

    Private Shared Sub textEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        For Each group As NavBarGroup In navBarControl1.Groups
            For Each link As NavBarItemLink In group.ItemLinks
                Select Case criteria1
                    Case SearchCriteria.Contains
                        link.Visible = link.Caption.Contains(textEdit.Text)
                    Case SearchCriteria.StartsWith
                        link.Visible = link.Caption.StartsWith(textEdit.Text)
                    Case SearchCriteria.Equals
                        link.Visible = link.Caption.Equals(textEdit.Text)
                End Select
                If group.VisibleItemLinks.Count = 0 Then
                    group.Visible = False
                Else
                    group.Expanded = True
                    group.Visible = True
                End If
            Next link
        Next group
    End Sub

End Class

