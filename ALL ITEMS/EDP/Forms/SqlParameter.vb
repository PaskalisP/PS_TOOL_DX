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
Imports CrystalDecisions.CrystalReports.Engine

Public Class SqlParameter

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim SqlParameterDetailViewCaption As String = Nothing
    Dim SqlParameterSecondDetailViewCaption As String = Nothing
    Dim SqlParameterThirdDetailViewCaption As String = Nothing

    Dim IdRowValue As String = Nothing
    Dim IdRowValueSecond As String = Nothing
    Dim IdRowValueThird As String = Nothing
    Dim row1 As System.Data.DataRow

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

    Private Sub SQL_PARAMETERBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SQL_PARAMETERBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

    Private Sub SqlParameter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
            Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
            Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
        End If
    End Sub

    Private Sub SqlParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
        Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)


    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Try
                Me.Validate()
                Me.SQL_PARAMETERBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Dim view As GridView = Me.GridControl3.FocusedView
                        Dim focusedRow As Integer = view.FocusedRowHandle
                        Me.GridControl3.BeginUpdate()

                        If view.Name = Me.SQL_Parameter_Gridview.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                            Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                            Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                        ElseIf view.Name = Me.SQL_Parameter_Details_GridView.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                            Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        ElseIf view.Name = Me.SQL_Parameter_Details_Second_GridView.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        ElseIf view.Name = Me.SQL_Parameter_Details_Third_GridView.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        End If

                        view.RefreshData()
                        Me.GridControl3.EndUpdate()
                        view.FocusedRowHandle = focusedRow

                        'SET SQL COMMAND FIELDS TO NULL IF LEN=0
                        cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                        cmd.ExecuteNonQuery()

                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If


        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        If e.Button.ButtonType = NavigatorButtonType.Custom Then
            If e.Button.Tag.ToString = "Delete" Then
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                'Remove PARAMETER NAMES
                If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then
                    Dim row As System.Data.DataRow = SQL_Parameter_Gridview.GetDataRow(SQL_Parameter_Gridview.FocusedRowHandle)
                    Dim cellvalue As String = row(0)
                    Dim ParameterName As String = row(1)
                    If MessageBox.Show("Should the SQL Parameter " & ParameterName & " and all its details be deleted ?", "DELETE SQL PARAMETER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "'))"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "')"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "'"
                        cmd.ExecuteNonQuery()
                        'Delete Abteilungen with the same ABTEILUNGS NAME 
                        cmd.CommandText = "DELETE  FROM [SQL_PARAMETER] where [SQL_Parameter_Name]='" & ParameterName & "'"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Gridview.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                        SplashScreenManager.CloseForm(False)

                    Else
                        e.Handled = True
                    End If
                ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then
                    'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
                    'Dim cellvalue As String = row(0)
                    If MessageBox.Show("Should the SQL Parameter First Detail " & IdRowValue & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & IdRowValue & "')"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]='" & IdRowValue & "'"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS] where [ID]='" & IdRowValue & "'"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Details_GridView.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    Else
                        e.Handled = True
                    End If
                ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then
                    'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
                    'Dim cellvalue As String = row(0)
                    If MessageBox.Show("Should the SQL Parameter Second Detail " & IdRowValueSecond & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & IdRowValueSecond & "')"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & IdRowValueSecond & "'"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Details_Second_GridView.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        'Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    Else
                        e.Handled = True
                    End If
                ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Third_GridView" Then
                    'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
                    'Dim cellvalue As String = row(0)
                    If MessageBox.Show("Should the SQL Parameter Third Detail " & IdRowValueThird & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [ID]='" & IdRowValueThird & "'"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Details_Second_GridView.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        'Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    Else
                        e.Handled = True
                    End If
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If

        End If

    End Sub

    Private Sub SQL_Parameter_Gridview_Click(sender As Object, e As EventArgs) Handles SQL_Parameter_Gridview.Click
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterDetailViewCaption = "SQL Parameter details for : " & view.GetFocusedRowCellValue("SQL_Parameter_Name").ToString
            Me.SQL_Parameter_Details_GridView.ViewCaption = SqlParameterDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles SQL_Parameter_Gridview.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterDetailViewCaption = "SQL Parameter details for : " & view.GetFocusedRowCellValue("SQL_Parameter_Name").ToString
            Me.SQL_Parameter_Details_GridView.ViewCaption = SqlParameterDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles SQL_Parameter_Gridview.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterDetailViewCaption = "SQL Parameter details for : " & view.GetFocusedRowCellValue("SQL_Parameter_Name").ToString
            Me.SQL_Parameter_Details_GridView.ViewCaption = SqlParameterDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_Click(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_GridView.Click
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterSecondDetailViewCaption = SqlParameterDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Second_GridView.ViewCaption = SqlParameterSecondDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles SQL_Parameter_Details_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterSecondDetailViewCaption = SqlParameterDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Second_GridView.ViewCaption = SqlParameterSecondDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles SQL_Parameter_Details_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterSecondDetailViewCaption = SqlParameterDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Second_GridView.ViewCaption = SqlParameterSecondDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles SQL_Parameter_Details_Second_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterThirdDetailViewCaption = SqlParameterSecondDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Third_GridView.ViewCaption = SqlParameterThirdDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles SQL_Parameter_Details_Second_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterThirdDetailViewCaption = SqlParameterSecondDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Third_GridView.ViewCaption = SqlParameterThirdDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

   

    Private Sub SQL_Parameter_Details_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles SQL_Parameter_Details_GridView.RowClick
        If SQL_Parameter_Details_GridView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            row1 = view.GetDataRow(view.FocusedRowHandle)
            IdRowValue = row1(0)
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
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
        Dim reportfooter As String = "SQL PARAMETERS "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles SQL_Parameter_Details_Second_GridView.RowClick
        If SQL_Parameter_Details_Second_GridView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            row1 = view.GetDataRow(view.FocusedRowHandle)
            IdRowValueSecond = row1(0)
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Details_Second_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_Second_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles SQL_Parameter_Details_Third_GridView.RowClick
        If SQL_Parameter_Details_Second_GridView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            row1 = view.GetDataRow(view.FocusedRowHandle)
            IdRowValueThird = row1(0)
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Details_Third_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_Third_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles SQL_Parameter_Gridview.CustomDrawRowIndicator
        'If e.RowHandle >= 0 Then e.Info.DisplayText = e.RowHandle.ToString()

    End Sub

    Private Sub SQL_Parameter_Details_GridView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles SQL_Parameter_Details_GridView.CustomDrawRowIndicator
        'If e.RowHandle >= 0 Then e.Info.DisplayText = e.RowHandle.ToString()

    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles SQL_Parameter_Details_Second_GridView.CustomDrawRowIndicator
        'If e.RowHandle >= 0 Then e.Info.DisplayText = e.RowHandle.ToString()

    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles SQL_Parameter_Details_Third_GridView.CustomDrawRowIndicator
        'If e.RowHandle >= 0 Then e.Info.DisplayText = e.RowHandle.ToString()

    End Sub
End Class