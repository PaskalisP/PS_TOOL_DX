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
Public Class IndustrialValuesOCBS

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New DataTable

    Private objDataTable As New DataTable
    Private objDataTableNace As New DataTable

    Dim SqlCommandText As String = Nothing

    Dim ActiveTabGroup As Double = 0

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

    Private Sub INDUSTRY_VALUESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.INDUSTRY_VALUESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub IndustrialValuesOCBS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Validate()
            Me.INDUSTRY_VALUESBindingSource.EndEdit()
            If Me.PSTOOLDataset.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                Else

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub IndustrialValuesOCBS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.INDUSTRY_VALUESTableAdapter.Fill(Me.PSTOOLDataset.INDUSTRY_VALUES)
        Me.IndustrialClassLocalTableAdapter.Fill(Me.PSTOOLDataset.IndustrialClassLocal)

        LOAD_NACE_CODES()
        'LOAD_NEWG_INDUSTRY_CHINA()
        


    End Sub

    Private Sub LOAD_NACE_CODES()
        'NACE CODES
        'Data reader
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('NACE_REVISION2_BRANCH_CODES')) and [Status] in ('Y') order by ID asc"
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 5000
                If sqlConn.State = ConnectionState.Closed Then
                    sqlConn.Open()
                End If

                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.GridControl4.DataSource = Nothing
                Me.GridControl4.DataSource = objDataTable
                Me.GridControl4.ForceInitialize()
                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                End If

            End Using
        End Using
      
    End Sub

    Private Sub LOAD_NEWG_INDUSTRY_CHINA()
        'INDUSTRY CHINA NEWG
        'Data reader
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('NEWG_IC_China')) and [Status] in ('Y') order by SQL_Name_1 asc"
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 5000
                If sqlConn.State = ConnectionState.Closed Then
                    sqlConn.Open()
                End If

                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.GridControl5.DataSource = Nothing
                Me.GridControl5.DataSource = objDataTable
                Me.GridControl5.ForceInitialize()
                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                End If

            End Using
        End Using
      
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.INDUSTRY_VALUESBindingSource.EndEdit()
                If Me.PSTOOLDataset.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'Remove PARAMETER NAMES
            If Me.GridControl2.FocusedView.Name = "IndustrialValuesBaseView" Then
                Dim row As System.Data.DataRow = IndustrialValuesBaseView.GetDataRow(IndustrialValuesBaseView.FocusedRowHandle)
                Dim ID As Integer = row(0)
                Dim IndustrialValue As String = row(1)
                If MessageBox.Show("Should the Industry Value: " & IndustrialValue & " be deleted?", "DELETE CONTRACT TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim IndustryDelete As PSTOOLDataset.INDUSTRY_VALUESRow
                    IndustryDelete = PSTOOLDataset.INDUSTRY_VALUES.FindByID(ID)
                    IndustryDelete.Delete()
                    IndustrialValuesBaseView.DeleteSelectedRows()
                    GridControl2.Update()
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    Me.INDUSTRY_VALUESTableAdapter.Fill(Me.PSTOOLDataset.INDUSTRY_VALUES)
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub


    Private Sub IndustrialValuesBaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles IndustrialValuesBaseView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.IndustrialValuesBaseView.Columns.ColumnByFieldName("Industry Code").OptionsColumn.ReadOnly = False
            Me.IndustrialValuesBaseView.Columns.ColumnByFieldName("Industry Description").OptionsColumn.ReadOnly = False
        Else
            Me.IndustrialValuesBaseView.Columns.ColumnByFieldName("Industry Code").OptionsColumn.ReadOnly = True
            Me.IndustrialValuesBaseView.Columns.ColumnByFieldName("Industry Description").OptionsColumn.ReadOnly = True
        End If
    End Sub

    Private Sub IndustrialValuesBaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles IndustrialValuesBaseView.InvalidRowException
        'Suppress displaying the error message box
        e.ExceptionMode = ExceptionMode.NoAction
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

    End Sub

    Private Sub IndustrialValuesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IndustrialValuesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub IndustrialValuesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles IndustrialValuesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub IndustriesOCBS_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles IndustriesOCBS_Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            ' Opens the Preview window. 
            'GridControl1.ShowPrintPreview()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

        If ActiveTabGroup = 1 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            ' Opens the Preview window. 
            'GridControl1.ShowPrintPreview()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

        If ActiveTabGroup = 2 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            ' Opens the Preview window. 
            'GridControl1.ShowPrintPreview()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

        If ActiveTabGroup = 3 Then
            If Not GridControl5.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            ' Opens the Preview window. 
            'GridControl1.ShowPrintPreview()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink4.CreateDocument()
            PrintableComponentLink4.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
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
        Dim reportfooter As String = "Industrial Values (China)" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "LOCAL INDUSTRIAL CLASSES" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "Classification of Economic activities in the EU" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "Industrial Values (NEWG)" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub IndustrialValuesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles IndustrialValuesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim IndustryValue As GridColumn = View.Columns("Industry Code")
        Dim IndustryDescription As GridColumn = View.Columns("Industry Description")
        'Get the value of the first column
        Dim IV As String = View.GetRowCellValue(e.RowHandle, colIndustryCode).ToString
        'Get the value of the second column
        Dim ID As String = View.GetRowCellValue(e.RowHandle, colIndustryDescription).ToString

        If IV = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IndustryValue, "The Industry Code must not be empty")
            e.ErrorText = "The Industry Code must not be empty"
        End If

        If ID = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IndustryDescription, "The Industry Description must not be empty")
            e.ErrorText = "The Industry Description must not be empty"
        End If

    End Sub

    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView3_ShownEditor(sender As Object, e As EventArgs) Handles GridView3.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Industrial Values" Then
            ActiveTabGroup = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Industrial Values (NEWG)" Then
            ActiveTabGroup = 3
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Industrial Class (Local)" Then
            ActiveTabGroup = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Classification of Economic activities in the EU" Then
            ActiveTabGroup = 2
        End If

    End Sub

    Private Sub NACE_Codes_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NACE_Codes_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub NACE_Codes_GridView_ShownEditor(sender As Object, e As EventArgs) Handles NACE_Codes_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView5_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView5.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView5_ShownEditor(sender As Object, e As EventArgs) Handles GridView5.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
End Class