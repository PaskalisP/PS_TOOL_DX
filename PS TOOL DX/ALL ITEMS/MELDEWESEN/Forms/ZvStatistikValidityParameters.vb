Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraRichEdit.Services
Imports PDataTool.RichEditSyntaxSample
Imports DevExpress.XtraGrid.Views.Printing
Imports PS_TOOL_DX.RichEditSyntaxSample

Public Class ZvStatistikValidityParameters

    Dim ID_1 As Integer = 0
    Dim ID_2 As Integer = 0
    Dim ID_3 As Integer = 0
    Dim ID_4 As Integer = 0

    Dim ParameterB_View As DevExpress.XtraGrid.Views.Grid.GridView
    Dim ParameterC_View As DevExpress.XtraGrid.Views.Grid.GridView
    Dim ParameterD_View As DevExpress.XtraGrid.Views.Grid.GridView

    Dim LEVEL_1 As String = Nothing
    Dim LEVEL_2 As String = Nothing
    Dim LEVEL_3 As String = Nothing

    Dim ParameterB_ViewCaption As String = Nothing
    Dim ParameterC_ViewCaption As String = Nothing
    Dim ParameterD_ViewCaption As String = Nothing

    Private BS_Meldeschemas As BindingSource
    Private BS_MeldeschemasALL As BindingSource
    Dim GetFocusedRow As Integer = 0
    Dim GetView As GridView = Nothing



    Private Sub FILL_ALL_DATA()
        Me.ZVSTAT_ProofingRules_ParameterTableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_ProofingRules_Parameter, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()
    End Sub

    Private Sub FILL_ALL_DATA_CURRENT_SCHEMA()
        Me.ZVSTAT_ProofingRules_ParameterTableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_ProofingRules_Parameter, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()
    End Sub

    Private Sub ZvStatistikValidityParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ZVSTA_Schema_initData()
        ZVSTA_Schema_InitLookUp()
        ZVSTA_SchemaALL_initData()
        ZVSTA_SchemaALL_InitLookUp()
        Me.PopupContainerEdit2.PopupFormMinSize = New Size(650, 500)

        If BS_MeldeschemasALL.Count > 0 Then
            Me.Meldeschemas_BarEditItem.EditValue = CType(BS_Meldeschemas.Current, DataRowView).Item(0)
            Me.ZVSTAT_ProofingRules_ParameterTableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_ProofingRules_Parameter, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        Else
            Me.ZVSTAT_ProofingRules_ParameterTableAdapter.Fill(Me.ZvStatistik_Dataset.ZVSTAT_ProofingRules_Parameter)
        End If

        'If EDP_USER = 1 Then
        '    ZVSTAT_ValidityRules_Gridview.OptionsBehavior.Editable = False
        '    ZVSTAT_ValidityRules_Gridview.OptionsBehavior.Editable = False

        '    Me.BbiAddNewZvParameter.Visibility = BarItemVisibility.Never
        '    Me.BbiDelete.Visibility = BarItemVisibility.Never
        'End If

    End Sub

    Private Sub ZVSTA_Schema_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbMeldeschemas As SqlDataAdapter = New SqlDataAdapter("SELECT TOP 3 ZVSTA_Schema FROM [ZVSTAT_Parameters_from2014] GROUP BY ZVSTA_Schema 
                                                                    UNION ALL SELECT 'ZVSTA_2022_TECHNICAL' as ZVSTA_Schema 
                                                                    order by ZVSTA_Schema asc", conn) '
        Try

            dbMeldeschemas.Fill(ds, "ZVSTA_SCHEMA")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Meldeschemas = New BindingSource(ds, "ZVSTA_SCHEMA")

    End Sub

    Private Sub ZVSTA_Schema_InitLookUp()
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.DataSource = BS_Meldeschemas
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.DisplayMember = "ZVSTA_Schema"
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.ValueMember = "ZVSTA_Schema"

    End Sub

    Private Sub ZVSTA_SchemaALL_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbMeldeschemasALL As SqlDataAdapter = New SqlDataAdapter("SELECT TOP 3 ZVSTA_Schema FROM [ZVSTAT_Parameters_from2014] GROUP BY ZVSTA_Schema 
                                                                    UNION ALL SELECT 'ZVSTA_2022_TECHNICAL' as ZVSTA_Schema 
                                                                    UNION ALL SELECT 'ALL' as ZVSTA_Schema order by ZVSTA_Schema asc", conn) '
        Try

            dbMeldeschemasALL.Fill(ds, "ZVSTA_SCHEMA_ALL")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_MeldeschemasALL = New BindingSource(ds, "ZVSTA_SCHEMA_ALL")

    End Sub

    Private Sub ZVSTA_SchemaALL_InitLookUp()
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.DataSource = BS_MeldeschemasALL
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.DisplayMember = "ZVSTA_Schema"
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ValueMember = "ZVSTA_Schema"
        'Meldeschemas_RepositoryItemSearchLookUpEdit
    End Sub


    Private Sub Meldeschemas_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles Meldeschemas_BarEditItem.EditValueChanged
        If BS_MeldeschemasALL.Count > 0 AndAlso Me.Meldeschemas_BarEditItem.EditValue.ToString <> "ALL" Then

            Me.ZVSTAT_ProofingRules_ParameterTableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_ProofingRules_Parameter, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        Else
            Me.ZVSTAT_ProofingRules_ParameterTableAdapter.Fill(Me.ZvStatistik_Dataset.ZVSTAT_ProofingRules_Parameter)
        End If
    End Sub

    Private Sub bbiReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload ZV Statistik Validity Rules Parameters")
        FILL_ALL_DATA_CURRENT_SCHEMA()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BbiSqlReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSqlReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload ZV Statistik Validity Rules Parameters")
        FILL_ALL_DATA_CURRENT_SCHEMA()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BbiAddNewSqlParameter_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiAddNewZvParameter.ItemClick
        'Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        'If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
        '    Me.ZVSTAT_Meldeschemas_Gridview.AddNewRow()
        '    Me.ZVSTAT_Meldeschemas_Gridview.ShowEditor()
        'End If

        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_ValidityRules_Gridview" Then
                Me.ZVSTAT_ProofingRules_ParameterBindingSource.EndEdit()
                Me.ZVSTAT_ProofingRules_ParameterBindingSource.AddNew()
                focusedView.ShowEditForm()

                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                'If XtraMessageBox.Show("Should a new ZV Statistik Validity Rule be added in a new row?", "ADD NEW ZV STATISTIK VALIDITY RULE - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                '    Try
                '        OpenSqlConnections()
                '        SqlCommandText = "INSERT INTO [ZVSTAT_ProofingRules_Parameter]
                '                           ([Validity_ID]
                '                           ,[ValidityTermStatus]
                '                           ,[LastAction]
                '                           ,[LastUpdateUser]
                '                           ,[LastUpdateDate])
                '                 VALUES 
                '                   ('NEW'
                '                            ,'N'
                '                            ,'New Added'
                '                            ,SYSTEM_USER
                '                            ,GETDATE())"
                '        cmd.CommandText = SqlCommandText
                '        cmd.ExecuteNonQuery()

                '        XtraMessageBox.Show("New ZV Statistik Validity Rule successfull added", "ADDING NEW VALIDITY RULE FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        CloseSqlConnections()
                '        FILL_ALL_DATA_CURRENT_SCHEMA()
                '        focusedView.RefreshData()
                '        focusedView.FocusedRowHandle = GetFocusedRow
                '        focusedView.MoveLast()


                '    Catch ex As Exception
                '        CloseSqlConnections()
                '        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    End Try
                'End If
            End If
        End If

    End Sub

    Private Sub BbiSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSave.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show(CType("Should the changes be saved ?", String), "SAVE CHANGES", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

            If focusedView.Name = "ZVSTAT_ValidityRules_Gridview" Then
                Try
                    Me.Validate()

                    Me.TableAdapterManager.UpdateAll(Me.ZvStatistik_Dataset)
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [ZVSTAT_ProofingRules_Parameter] SET [ValiditySqlParameter]=NULL where [ValiditySqlParameter]=''"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    FILL_ALL_DATA_CURRENT_SCHEMA()
                    focusedView.RefreshData()
                    focusedView.FocusedRowHandle = GetFocusedRow
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try


            End If
        Else

        End If

    End Sub

    Private Sub BbiDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDelete.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.Name.ToString = "ZVSTAT_ValidityRules_Gridview" AndAlso GetFocusedRow <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso focusedView.IsGroupRow(GetFocusedRow) = False Then
            If XtraMessageBox.Show(CType("Should the ZV Statistik Validity Rule: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "Validity_ID").ToString & " - " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ValidityType").ToString & " - Validity Term: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ValidityTerm").ToString _
                                         & " be deleted? ", String), "DELETE ZV STATISTIC VALIDITY RULE PARAMETER", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try

                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete ZV Statistik Validity Rule Parameter")
                    OpenSqlConnections()
                    cmd.CommandText = "DECLARE @ID_1 int
                                       SET @ID_1=" & ID_1 & "
                                       DELETE from ZVSTAT_ProofingRules_Parameter where ID=@ID_1"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    FILL_ALL_DATA_CURRENT_SCHEMA()
                    'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()
                    focusedView.RefreshData()
                    focusedView.FocusedRowHandle = GetFocusedRow
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If



    End Sub

    Private Sub BbiActivateAllValidityParameters_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiActivateAllValidityParameters.ItemClick
        If BS_MeldeschemasALL.Count > 0 AndAlso Me.Meldeschemas_BarEditItem.EditValue.ToString <> "ALL" Then
            Dim CURRENT_MELDESCHEMA As String = Me.Meldeschemas_BarEditItem.EditValue.ToString
            If XtraMessageBox.Show(CType("Should all Validity Parameters for the ZVSTA Schema: " & CURRENT_MELDESCHEMA & " be activated? ", String), "ACTIVATE ALL VALIDITY PARAMETERS", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                OpenSqlConnections()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Activating all Validty Parameters for ZVSTA Schema: " & CURRENT_MELDESCHEMA)
                cmd.CommandText = "UPDATE [ZVSTAT_ProofingRules_Parameter] SET 
                              [ValidityTermStatus]='Y'
                             ,[LastAction]='Activated'
                             ,[LastUpdateUser]='" & CurrentUserWindowsID & "'
                             ,[LastUpdateDate]=GETDATE() where [ZVSTA_Schema]='" & CURRENT_MELDESCHEMA & "' "
                cmd.ExecuteNonQuery()
                CloseSqlConnections()
                FILL_ALL_DATA_CURRENT_SCHEMA()
                SplashScreenManager.CloseForm(False)
            End If
        End If

    End Sub

    Private Sub BbiDeactivateAllValidityParameters_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDeactivateAllValidityParameters.ItemClick
        If BS_MeldeschemasALL.Count > 0 AndAlso Me.Meldeschemas_BarEditItem.EditValue.ToString <> "ALL" Then
            Dim CURRENT_MELDESCHEMA As String = Me.Meldeschemas_BarEditItem.EditValue.ToString
            If XtraMessageBox.Show(CType("Should all Validity Parameters for the ZVSTA Schema: " & CURRENT_MELDESCHEMA & " be Deactivated? ", String), "DEACTIVATE ALL VALIDITY PARAMETERS", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                OpenSqlConnections()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Activating all Validty Parameters for ZVSTA Schema: " & CURRENT_MELDESCHEMA)
                cmd.CommandText = "UPDATE [ZVSTAT_ProofingRules_Parameter] SET 
                              [ValidityTermStatus]='N'
                             ,[LastAction]='Deactivated'
                             ,[LastUpdateUser]='" & CurrentUserWindowsID & "'
                             ,[LastUpdateDate]=GETDATE() where [ZVSTA_Schema]='" & CURRENT_MELDESCHEMA & "' "
                cmd.ExecuteNonQuery()
                CloseSqlConnections()
                FILL_ALL_DATA_CURRENT_SCHEMA()
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles ZVSTAT_ValidityRules_Gridview.RowCellClick
        ID_1 = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_1 = CInt(view.GetRowCellValue(rowHandle, colID))
        End If

        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
        Else
            view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
        End If

    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ZVSTAT_ValidityRules_Gridview.FocusedRowChanged
        ID_1 = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_1 = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
        Else
            view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
        End If

    End Sub



    Private Sub BbiPrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiPrintExport.ItemClick
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
        Dim reportfooter As String = "ZV Statistik - Validity Rules"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClose.ItemClick
        Me.Close()

    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTAT_ValidityRules_Gridview.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTAT_ValidityRules_Gridview.RowUpdated
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Modified")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTAT_ValidityRules_Gridview.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim ZVSTA_SCHEMA As GridColumn = View.Columns("ZVSTA_Schema")
        Dim VALIDITY_ID As GridColumn = View.Columns("Validity_ID")
        Dim VALIDITY_TYPE As GridColumn = View.Columns("ValidityType")
        Dim REPORTING_FORM_LEFT As GridColumn = View.Columns("ReportingFormLeft")
        Dim REPORTING_FORM_RIGHT As GridColumn = View.Columns("ReportingFormRight")
        Dim VALIDITY_TERM As GridColumn = View.Columns("ValidityTerm")
        Dim VALIDITY_TERM_DESCRIPTION As GridColumn = View.Columns("ValidityTermDescription")

        Dim ZvstaSchema As String = View.GetRowCellValue(e.RowHandle, colZVSTA_Schema).ToString
        Dim ValidityID As String = View.GetRowCellValue(e.RowHandle, colValidity_ID).ToString
        Dim ValidityType As String = View.GetRowCellValue(e.RowHandle, colValidityType).ToString
        Dim ReportingFormLeft As String = View.GetRowCellValue(e.RowHandle, colReportingFormLeft).ToString
        Dim ReportingFormRight As String = View.GetRowCellValue(e.RowHandle, colReportingFormRight).ToString
        Dim ValidityTerm As String = View.GetRowCellValue(e.RowHandle, colValidityTerm).ToString
        Dim ValidityTermDescription As String = View.GetRowCellValue(e.RowHandle, colValidityTermDescription).ToString

        If ZvstaSchema = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ZVSTA_SCHEMA, "The ZVSTA Schema must not be empty")
            e.ErrorText = "The ZVSTA Schema must not be empty"
        End If
        If ValidityID = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY_ID, "The Validity ID must not be empty")
            e.ErrorText = "The Validity ID must not be empty"
        End If
        If ValidityType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY_TYPE, "The Validity Type must not be empty")
            e.ErrorText = "The Validity Type must not be empty"
        End If
        If ReportingFormLeft = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(REPORTING_FORM_LEFT, "The Reporting Form must not be empty")
            e.ErrorText = "The Reporting Form must not be empty"
        End If
        If ReportingFormRight = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(REPORTING_FORM_RIGHT, "The Reporting Form must not be empty")
            e.ErrorText = "The Reporting Form must not be empty"
        End If
        If ValidityTerm = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY_TERM, "The Validity Term must not be empty")
            e.ErrorText = "The Validity Term must not be empty"
        End If
        If ValidityTermDescription = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VALIDITY_TERM_DESCRIPTION, "The Validity Term Description must not be empty")
            e.ErrorText = "The Validity Term Description must not be empty"
        End If
    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles ZVSTAT_ValidityRules_Gridview.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("ValiditySql") = True Then
                e.RepositoryItem = Me.PopupContainerEdit2
            End If
        End If


    End Sub

    Private Sub PopupContainerEdit2_QueryPopUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit2.QueryPopUp
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        Dim editor As BaseEdit = DirectCast(sender, BaseEdit)
        RichEditControl1.Document.Text = editor.EditValue.ToString()


    End Sub

    Private Sub PopupContainerEdit2_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles PopupContainerEdit2.QueryDisplayText
        'e.DisplayText = RichEditControl1.Document.Text
    End Sub

    Private Sub PopupContainerEdit2_QueryResultValue(sender As Object, e As QueryResultValueEventArgs) Handles PopupContainerEdit2.QueryResultValue
        e.Value = RichEditControl1.Document.Text
    End Sub

    Private Sub PopupContainerEdit2_QueryCloseUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit2.QueryCloseUp
        'Me.RichEditControl1.DataBindings.Clear()
        'BbiSave.PerformClick()

    End Sub

    Private Sub RichEditControl1_TextChanged(sender As Object, e As EventArgs) Handles RichEditControl1.TextChanged
        If Me.RichEditControl1.Text <> "" Then
            RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        End If
    End Sub

    Private Sub RichEditControl1_GotFocus(sender As Object, e As EventArgs) Handles RichEditControl1.GotFocus
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
    End Sub

    Private Sub ZVSTAT_ValidityRules_Gridview_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ZVSTAT_ValidityRules_Gridview.PrintInitialize
        Dim view As GridView = CType(sender, GridView)
        view.Columns("ValiditySqlParameter").ColumnEdit = MemoEdit1
        view.OptionsView.RowAutoHeight = True
    End Sub


    Private Sub PrintableComponentLink1_AfterCreateAreas(sender As Object, e As EventArgs) Handles PrintableComponentLink1.AfterCreateAreas
        ZVSTAT_ValidityRules_Gridview.Columns("ValiditySqlParameter").ColumnEdit = RepositoryItemMemoExEdit3
        ZVSTAT_ValidityRules_Gridview.OptionsView.RowAutoHeight = False

        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_1").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_2").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_3").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_4").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.OptionsView.RowAutoHeight = False


    End Sub


    Private Sub SQL_Parameter_Details_First_GridView_PopupMenuShowing(sender As Object, e As Grid.PopupMenuShowingEventArgs)

        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.SqlParameterGridviewPopupMenu.ShowPopup(GridControl3.PointToScreen(e.Point))
            End If
        End If
    End Sub


    Private Sub ZVSTAT_ValidityRules_Gridview_PopupMenuShowing(sender As Object, e As Grid.PopupMenuShowingEventArgs) Handles ZVSTAT_ValidityRules_Gridview.PopupMenuShowing

        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_EnablePreview As New DevExpress.Utils.Menu.DXMenuItem("ENABLE PREVIEW", New EventHandler(AddressOf MyMenuItem_EnablePreview_D), SharedImageCollection1.ImageSource.Images(5))
            Dim menuItem_DisablePreview As New DevExpress.Utils.Menu.DXMenuItem("DISABLE PREVIEW", New EventHandler(AddressOf MyMenuItem_DisablePreview_D), SharedImageCollection1.ImageSource.Images(6))

            menuItem_EnablePreview.Tag = e.Menu
            menuItem_EnablePreview.BeginGroup = True
            menuItem_DisablePreview.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_EnablePreview)
            ColumnMenu.Items.Add(menuItem_DisablePreview)
        End If

        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.SqlParameterGridviewPopupMenu.ShowPopup(GridControl3.PointToScreen(e.Point))
            End If
        End If

    End Sub


    Private Sub MyMenuItem_EnablePreview_D(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ZVSTAT_ValidityRules_Gridview.OptionsView.ShowPreview = True
    End Sub

    Private Sub MyMenuItem_DisablePreview_D(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ZVSTAT_ValidityRules_Gridview.OptionsView.ShowPreview = False
    End Sub

    Private Sub ZVSTAT_Meldeschemas_Gridview_EditFormShowing(sender As Object, e As EditFormShowingEventArgs) Handles ZVSTAT_ValidityRules_Gridview.EditFormShowing
        Dim view As GridView = TryCast(sender, GridView)
        e.Allow = view.IsNewItemRow(e.RowHandle)
    End Sub




    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub

    Private Sub FindAndReplaceText_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles FindAndReplaceText_bbi.ItemClick
        Dim dtColumns As New DataTable
        dtColumns.Columns.Add("ColumnName", Type.GetType("System.String"))
        dtColumns.Columns.Add("ColumnCaption", Type.GetType("System.String"))
        For Each column As DevExpress.XtraGrid.Columns.GridColumn In ZVSTAT_ValidityRules_Gridview.Columns
            If column.Visible = True And column.OptionsColumn.ReadOnly = False And column.OptionsColumn.AllowEdit = True Then
                Dim dr As DataRow = dtColumns.NewRow
                dr("ColumnName") = column.Name.ToString
                If column.Caption.ToString <> "" Then
                    dr("ColumnCaption") = column.Caption.ToString
                Else
                    dr("ColumnCaption") = column.FieldName.ToString
                End If

                dtColumns.Rows.Add(dr)

            End If
        Next
        Dim c As New FindAndReplaceInGridview
        c.ColumnsNames_LookUpEdit.Properties.DataSource = dtColumns
        c.ColumnsNames_LookUpEdit.Properties.ForceInitialize()
        c.ColumnsNames_LookUpEdit.Properties.PopulateColumns()
        c.ColumnsNames_LookUpEdit.Properties.ValueMember = "ColumnName"
        c.ColumnsNames_LookUpEdit.Properties.DisplayMember = "ColumnName"
        'c.ColumnsNames_LookUpEdit.Text = dtColumns.Rows(1).Item("ColumnName").ToString

        If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic Validity Rules Parameter - Search and Replace", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            If c.ColumnsNames_LookUpEdit.Text <> "" Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Search and replace Text in the specified Column")
                    'MsgBox(c.ColumnsNames_LookUpEdit.EditValue.ToString)
                    Dim column As GridColumn = ZVSTAT_ValidityRules_Gridview.Columns.ColumnByName(c.ColumnsNames_LookUpEdit.EditValue.ToString)
                    Dim searchValue As String = c.SearchText_MemoEdit.Text
                    Dim newValue As String = c.ReplaceText_MemoEdit.Text

                    For i As Integer = ZVSTAT_ValidityRules_Gridview.FocusedRowHandle To ZVSTAT_ValidityRules_Gridview.DataRowCount - 1
                        Dim value As Object = ZVSTAT_ValidityRules_Gridview.GetRowCellDisplayText(i, column)
                        'MsgBox(value)
                        If value.ToString() = "" Then
                            Continue For
                        End If

                        If searchValue <> "" Then
                            If value.ToString().StartsWith(searchValue) Or value.ToString().Contains(searchValue) Or value.ToString().EndsWith(searchValue) Then
                                ZVSTAT_ValidityRules_Gridview.FocusedRowHandle = i
                                SplashScreenManager.Default.SetWaitFormCaption("Replace Text in Row: " & i)
                                ZVSTAT_ValidityRules_Gridview.GetRowCellValue(i, column).ToString()
                                'MsgBox(i & vbNewLine & column.FieldName)
                                If newValue <> "" Then
                                    ZVSTAT_ValidityRules_Gridview.SetRowCellValue(i, column.FieldName, ZVSTAT_ValidityRules_Gridview.GetRowCellValue(i, column).ToString().Replace(searchValue, newValue).ToString)
                                ElseIf newValue = "" Then
                                    ZVSTAT_ValidityRules_Gridview.SetRowCellValue(i, column.FieldName, ZVSTAT_ValidityRules_Gridview.GetRowCellValue(i, column).ToString().Replace(searchValue, "").ToString)
                                End If

                                'Exit For
                            End If
                        End If

                    Next
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("Search and replace finished!" & vbNewLine & "To save changes click on the save button", "SEARCH + REPLACE FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If
        End If


    End Sub


End Class