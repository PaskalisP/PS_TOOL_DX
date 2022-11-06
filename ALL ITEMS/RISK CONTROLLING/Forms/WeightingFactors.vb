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
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Public Class WeightingFactors

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim WF_Value As String = Nothing
   



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

    Private Sub RATERISK_BC_WFBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.RATERISK_BC_WFBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)

    End Sub

    Private Sub WeightingFactors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'RiskControllingBasicsDataSet.RATERISK_BC_WF' table. You can move, or remove it, as needed.
        Me.RATERISK_BC_WFTableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.RATERISK_BC_WFBindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                    '****************************************************
                    'Update other weighting Factors
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [RATERISK BC WF] SET [WF+50]=Round([WF+200]/4,4),[WF+100]=Round([WF+200]/2,4),[WF]=Round([WF+200]/20,4),[WF20]=Round([WF+200]/10,4),[WF25]=Round([WF+200]/8,4)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [RATERISK BC WF] SET [WF-200]=[WF+200]*(-1),[WF-50]=[WF+50] *(-1),[WF-100]=[WF+100]*(-1)"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    '*****************************************************
                    Me.RATERISK_BC_WFTableAdapter.Fill(Me.RiskControllingBasicsDataSet.RATERISK_BC_WF)
                Else
                    Me.RATERISK_BC_WFBindingSource.CancelEdit()
                    Me.RiskControllingBasicsDataSet.RejectChanges()
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.RATERISK_BC_WFBindingSource.CancelEdit()
                Me.RiskControllingBasicsDataSet.RejectChanges()
                Exit Sub
            End Try
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.RATERISK_BC_WFBindingSource.CancelEdit()
            Me.RiskControllingBasicsDataSet.RejectChanges()
        End If
    End Sub

    Private Sub WeightingFactorsBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles WeightingFactorsBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub WeightingFactorsBaseView_ShownEditor(sender As Object, e As EventArgs) Handles WeightingFactorsBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub WF_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles WF_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        Me.RATERISK_BC_WFBindingSource.CancelEdit()
        Me.RiskControllingBasicsDataSet.RejectChanges()
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
        Dim reportfooter As String = "Weighting Factors "
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    

    Private Sub RepositoryItemGridLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit1.EditValueChanged
        
        With WeightingFactorsBaseView
            If .FocusedColumn.FieldName = "WFHUMP" And IsNumeric(WF_Value) = True Then
                .SetRowCellValue(.FocusedRowHandle, colWFHUMP, WF_Value)
            End If
        End With

    End Sub

    Private Sub GridView2_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView2.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedColumn.FieldName <> "Period" Then
            WF_Value = view.GetFocusedDisplayText
        End If

    End Sub

    Private Sub RepositoryItemGridLookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit2.EditValueChanged
        With WeightingFactorsBaseView
            If .FocusedColumn.FieldName = "WF_TWIST1" And IsNumeric(WF_Value) = True Then
                .SetRowCellValue(.FocusedRowHandle, colWF_TWIST1, WF_Value)
            End If
        End With
    End Sub

    Private Sub GridView3_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView3.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedColumn.FieldName <> "Period" Then
            WF_Value = view.GetFocusedDisplayText
        End If
    End Sub

    Private Sub RepositoryItemGridLookUpEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit3.EditValueChanged
        With WeightingFactorsBaseView
            If .FocusedColumn.FieldName = "WF_TWIST2" And IsNumeric(WF_Value) = True Then
                .SetRowCellValue(.FocusedRowHandle, colWF_TWIST2, WF_Value)
            End If
        End With
    End Sub

    Private Sub GridView4_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView4.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedColumn.FieldName <> "Period" Then
            WF_Value = view.GetFocusedDisplayText
        End If
    End Sub
End Class