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
Imports DevExpress.XtraGrid.Views.Printing
Imports PS_TOOL_DX.RichEditSyntaxSample

Public Class ZvStatistikParameter

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
    Dim GetFocusedRow As Integer = 0
    Dim GetView As GridView = Nothing



    Private Sub FILL_ALL_DATA()
        Me.Meldeschemas_BarEditItem.EditValue = CType(BS_Meldeschemas.Current, DataRowView).Item(0)
        Me.ZVSTAT_Parameters_from2014TableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_Parameters_from2014, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()
    End Sub

    Private Sub FILL_ALL_DATA_CURRENT_SCHEMA()
        Me.ZVSTAT_Parameters_from2014TableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_Parameters_from2014, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()
    End Sub

    Private Sub ZvStatistikParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MELDESCHEMA_SELECTION_initData()
        MELDESCHEMA_SELECTION_InitLookUp()
        Me.Meldeschemas_BarEditItem.EditValue = CType(BS_Meldeschemas.Current, DataRowView).Item(0)
        Me.ZVSTAT_Parameters_from2014TableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_Parameters_from2014, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()


        Me.PopupContainerEdit2.PopupFormMinSize = New Size(650, 500)

        'If EDP_USER = 1 Then
        '    ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.Editable = False
        '    ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.Editable = False

        '    Me.BbiAddNewZvParameter.Visibility = BarItemVisibility.Never
        '    Me.BbiDelete.Visibility = BarItemVisibility.Never
        'End If

    End Sub

    Private Sub MELDESCHEMA_SELECTION_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("Select ZVSTA_Schema 
                                                    from [ZVSTAT_Parameters_from2014] 
                                                    GROUP BY ZVSTA_Schema 
                                                    order by dbo.fn_StripCharacters([ZVSTA_Schema],'^0-9') desc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbMeldeschemas As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbMeldeschemas.Fill(ds, "ZV_MELDESCHEMAS")

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
        BS_Meldeschemas = New BindingSource(ds, "ZV_MELDESCHEMAS")
    End Sub
    Private Sub MELDESCHEMA_SELECTION_InitLookUp()
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.DataSource = BS_Meldeschemas
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.DisplayMember = "ZVSTA_Schema"
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ValueMember = "ZVSTA_Schema"

    End Sub

    Private Sub ZvStatistik_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub bbiReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload ZV Statistik Parameters")
        FILL_ALL_DATA_CURRENT_SCHEMA()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BbiSqlReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSqlReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload ZV Statistik Parameters")
        FILL_ALL_DATA_CURRENT_SCHEMA()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Meldeschemas_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles Meldeschemas_BarEditItem.EditValueChanged

        Me.ZVSTAT_Parameters_from2014TableAdapter.FillByMeldeschema(Me.ZvStatistik_Dataset.ZVSTAT_Parameters_from2014, Me.Meldeschemas_BarEditItem.EditValue.ToString)
        'ZVSTAT_Meldeschemas_Gridview.BestFitColumns()

        Dim CurrentMeldeschema As String = Me.Meldeschemas_BarEditItem.EditValue.ToString
        If CurrentMeldeschema.EndsWith("2022") OrElse CurrentMeldeschema.Contains("2022") Then
            Me.ZVSTAT_Meldeschemas_Gridview.Columns.ColumnByFieldName("LandCode").ColumnEdit = Me.LandCode2021_ImageComboBox
        Else
            Me.ZVSTAT_Meldeschemas_Gridview.Columns.ColumnByFieldName("LandCode").ColumnEdit = Me.LandCode_ImageComboBox
        End If


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
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                If XtraMessageBox.Show("Should a new ZV Statistik Position be added in a new row?", "ADD NEW ZV STATISTIK POSITION - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          

                                     INSERT INTO [ZVSTAT_Parameters_from2014]
                                           ([ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
	                                VALUES 
			                                (@ZVSTA_Schema
                                            ,(Select Max([LfdNr])+1 from [ZVSTAT_Parameters_from2014] where [ZVSTA_Schema]=@ZVSTA_Schema)
                                            ,'NEW'
                                            ,'N'
                                            ,'DE'
                                            ,'Y'
                                            ,'Y'
                                            ,'N'
                                            ,'New Added'
                                            ,SYSTEM_USER
                                            ,GETDATE())"
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("New ZV Statistik Position successfull added", "ADDING NEW POSITION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow
                        focusedView.MoveLast()


                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub BbiSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSave.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show(CType("Should the changes be saved ?", String), "SAVE CHANGES", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

            If focusedView.Name = "ZVSTAT_Meldeschemas_Gridview" Then
                Try
                    Me.Validate()

                    Me.TableAdapterManager.UpdateAll(Me.ZvStatistik_Dataset)
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [ZVSTAT_Parameters_from2014] SET [PositionSQLcommand]=NULL where [PositionSQLcommand]=''"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [ZVSTAT_Parameters_from2014] SET [PositionInfo]=NULL where [PositionInfo]=''"
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

        If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" AndAlso GetFocusedRow <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso focusedView.IsGroupRow(GetFocusedRow) = False Then
            If XtraMessageBox.Show(CType("Should the ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "FormNr").ToString & " - " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr").ToString & " - ZV Meldeschema: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ZVSTA_Schema").ToString _
                                         & " be deleted? ", String), "DELETE ZV STATISTIC PARAMETER", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try

                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete ZV Statistik Parameter")
                    OpenSqlConnections()
                    cmd.CommandText = "DECLARE @ID_1 int
                                       DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                       SET @ID_1=" & ID_1 & "
                                       DELETE from ZVSTAT_Parameters_from2014 where ID=@ID_1
                                       --Reset LfdNr
                                       UPDATE A SET A.LfdNr=B.New_LfdNr FROM  [ZVSTAT_Parameters_from2014] A INNER JOIN 
                                       (SELECT ID,[LfdNr], ROW_NUMBER() OVER (ORDER BY [LfdNr]) AS New_LfdNr
                                       FROM [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema) B on A.ID=B.ID"
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

    Private Sub ZVSTAT_Meldeschemas_Gridview_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.RowCellClick
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

    Private Sub ZVSTAT_Meldeschemas_Gridview_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.FocusedRowChanged
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
        Dim reportfooter As String = "ZV Statistik - Parameter"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClose.ItemClick
        Me.Close()

    End Sub

    Private Sub ZVSTAT_Meldeschemas_Gridview_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
        view.SetRowCellValue(e.RowHandle, view.Columns("PositionStatus"), "Y")
    End Sub



    Private Sub ZVSTAT_Meldeschemas_Gridview_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("PositionSQL") = True Then
                e.RepositoryItem = Me.PopupContainerEdit2
            End If
        End If

        Dim CurrentMeldeschema As String = Me.Meldeschemas_BarEditItem.EditValue.ToString
        If e.Column.FieldName = "LandCode" Then
            If CurrentMeldeschema.EndsWith("2022") OrElse CurrentMeldeschema.Contains("2022") Then
                e.RepositoryItem = Me.LandCode2021_ImageComboBox
            Else
                e.RepositoryItem = Me.LandCode_ImageComboBox
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

    Private Sub ZVSTAT_Meldeschemas_Gridview_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.PrintInitialize
        Dim view As GridView = CType(sender, GridView)
        view.Columns("PositionSQLcommand").ColumnEdit = MemoEdit1
        view.OptionsView.RowAutoHeight = True
    End Sub


    Private Sub PrintableComponentLink1_AfterCreateAreas(sender As Object, e As EventArgs) Handles PrintableComponentLink1.AfterCreateAreas
        ZVSTAT_Meldeschemas_Gridview.Columns("PositionSQLcommand").ColumnEdit = RepositoryItemMemoExEdit3
        ZVSTAT_Meldeschemas_Gridview.OptionsView.RowAutoHeight = False

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


    Private Sub BbiDuplicateSQLParameter_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDuplicateSQLParameter.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                If XtraMessageBox.Show("Should the ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & " be duplicated in a new row?", "DUPLICATE ZV STATISTIK PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @SQL_FormName_Name_New nvarchar(100)='NEW_'+(Select [FormName] from [ZVSTAT_Parameters_from2014] where ID=@ID_A)

                                          SELECT @SQL_FormName_Name_New

                                     INSERT INTO [ZVSTAT_Parameters_from2014]
                                           ([ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,[FormName]
                                            ,[PositionNr]
                                            ,[PositionName]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[PositionSQLcommand]
                                            ,[PositionInfo]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
	                                SELECT 
			                                [ZVSTA_Schema]
                                            ,(Select Max([LfdNr])+1 from [ZVSTAT_Parameters_from2014] where [ZVSTA_Schema]=@ZVSTA_Schema)
                                            ,[FormNr]
                                            ,@SQL_FormName_Name_New
                                            ,[PositionNr]
                                            ,[PositionName]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[PositionSQLcommand]
                                            ,[PositionInfo]
                                            ,'Duplicated from ID: '+ CONVERT(nvarchar(10),@ID_A)
                                            ,SYSTEM_USER
                                            ,GETDATE()
	                                        FROM [ZVSTAT_Parameters_from2014] where ID=@ID_A"
                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_1)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub BbiDuplicateSQLParameterCurrentPosition_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDuplicateSQLParameterCurrentPosition.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                If XtraMessageBox.Show("Should the ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & " be duplicated in a current position?", "DUPLICATE ZV STATISTIK PARAMETER - CURRENT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @SQL_FormName_Name_New nvarchar(100)='NEW_'+(Select [FormName] from [ZVSTAT_Parameters_from2014] where ID=@ID_1)

                                          DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                          DECLARE @DUBLICATE_NR float=0
                                          DECLARE @NEW_RUNNING_NR float=0
                                          DECLARE @ID_3 table (ID int NULL,Number float)
                                          DECLARE @ID_4 table (ID int NULL,Number float)

                               INSERT INTO [ZVSTAT_Parameters_from2014]
                                           ([ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,[FormName]
                                            ,[PositionNr]
                                            ,[PositionName]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[PositionSQLcommand]
                                            ,[PositionInfo]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
	                            SELECT 
			                                [ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,@SQL_FormName_Name_New
                                            ,[PositionNr]
                                            ,[PositionName]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[PositionSQLcommand]
                                            ,[PositionInfo]
                                            ,'Duplicated from ID: '+ CONVERT(nvarchar(10),@ID_1)
                                            ,SYSTEM_USER
                                            ,GETDATE()
	                                        FROM [ZVSTAT_Parameters_from2014] where ID=@ID_1


                                        SET @DUBLICATE_NR=(select [LfdNr] from [ZVSTAT_Parameters_from2014] 
                                        where ID not in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema group by [LfdNr])
                                        and ZVSTA_Schema=@ZVSTA_Schema)


                                        IF @DUBLICATE_NR>0
                                        BEGIN
                                        SELECT @DUBLICATE_NR
                                        --Find equal Nr to @DUPLICATE
                                        INSERT INTO @ID_3
                                        (ID,Number)
                                        select ID,[LfdNr] from [ZVSTAT_Parameters_from2014]  
                                        where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr]=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema)
                                        and ZVSTA_Schema=@ZVSTA_Schema

                                        SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                        IF @NEW_RUNNING_NR=0
                                        BEGIN
                                        SET @NEW_RUNNING_NR=1
                                        INSERT INTO @ID_4
                                        (ID,Number)
                                        Select ID,[LfdNr]+@NEW_RUNNING_NR from [ZVSTAT_Parameters_from2014] 
                                        where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr] >=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema
                                        group by [LfdNr]) and ZVSTA_Schema=@ZVSTA_Schema order by ID asc
                                        END
                                        END

                                        UPDATE A SET A.[LfdNr]=B.Number from [ZVSTAT_Parameters_from2014] A INNER JOIN @ID_4 B on A.ID=B.ID where A.ZVSTA_Schema=@ZVSTA_Schema"
                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_ADD>", ID_1)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub


    Private Sub BbiDuplicateSQLParameterNextPosition_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDuplicateSQLParameterNextPosition.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                If XtraMessageBox.Show("Should the ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & " be duplicated in the next position?", "DUPLICATE ZV STATISTIK PARAMETER - NEXT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @SQL_FormName_Name_New nvarchar(100)='NEW_'+(Select [FormName] from [ZVSTAT_Parameters_from2014] where ID=@ID_1)

                                          DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                          DECLARE @DUBLICATE_NR float=0
                                          DECLARE @NEW_RUNNING_NR float=0
                                          DECLARE @ID_3 table (ID int NULL,Number float)
                                          DECLARE @ID_4 table (ID int NULL,Number float)

                               INSERT INTO [ZVSTAT_Parameters_from2014]
                                           ([ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,[FormName]
                                            ,[PositionNr]
                                            ,[PositionName]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[PositionSQLcommand]
                                            ,[PositionInfo]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
	                            SELECT 
			                                [ZVSTA_Schema]
                                            ,[LfdNr]+1
                                            ,[FormNr]
                                            ,@SQL_FormName_Name_New
                                            ,[PositionNr]
                                            ,[PositionName]
                                            ,[Landkontext]
                                            ,[LandCode]
                                            ,[Anzahl]
                                            ,[Wert]
                                            ,[SumPosition]
                                            ,[PositionSQLcommand]
                                            ,[PositionInfo]
                                            ,'Duplicated from ID: '+ CONVERT(nvarchar(10),@ID_1)
                                            ,SYSTEM_USER
                                            ,GETDATE()
	                                        FROM [ZVSTAT_Parameters_from2014] where ID=@ID_1


                                        SET @DUBLICATE_NR=(select [LfdNr] from [ZVSTAT_Parameters_from2014] 
                                        where ID not in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema group by [LfdNr])
                                        and ZVSTA_Schema=@ZVSTA_Schema)


                                        IF @DUBLICATE_NR>0
                                        BEGIN
                                        SELECT @DUBLICATE_NR
                                        --Find equal Nr to @DUPLICATE
                                        INSERT INTO @ID_3
                                        (ID,Number)
                                        select ID,[LfdNr] from [ZVSTAT_Parameters_from2014]  
                                        where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014]  where [LfdNr]=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema)
                                        and ZVSTA_Schema=@ZVSTA_Schema

                                        SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                        IF @NEW_RUNNING_NR=0
                                        BEGIN
                                        SET @NEW_RUNNING_NR=1
                                        INSERT INTO @ID_4
                                        (ID,Number)
                                        Select ID,[LfdNr]+@NEW_RUNNING_NR from [ZVSTAT_Parameters_from2014] 
                                        where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr] >=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema
                                        group by [LfdNr]) and ZVSTA_Schema=@ZVSTA_Schema order by ID asc
                                        END
                                        END

                                        UPDATE A SET A.[LfdNr]=B.Number from [ZVSTAT_Parameters_from2014] A INNER JOIN @ID_4 B on A.ID=B.ID where A.ZVSTA_Schema=@ZVSTA_Schema"
                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_ADD>", ID_1)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub BbiAddSQLtoPosition_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiAddSQLtoPosition.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle
        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                If XtraMessageBox.Show("Should in the position of ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & " added a new ZV Statistik Parameter?", "ADD NEW ZV STATISTIC PARAMETER IN CURRENT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try

                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                          DECLARE @DUBLICATE_NR float=0
                                          DECLARE @NEW_RUNNING_NR float=0
                                          DECLARE @ID_3 table (ID int NULL,Number float)
                                          DECLARE @ID_4 table (ID int NULL,Number float)

                                    INSERT INTO [ZVSTAT_Parameters_from2014]
                                            ([ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
	                                SELECT 
			                                [ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,'ADDED TO POSITION'
                                            ,SYSTEM_USER
                                            ,GETDATE()
	                                        FROM [ZVSTAT_Parameters_from2014] where ID=@ID_1

                                     SET @DUBLICATE_NR=(select [LfdNr] from [ZVSTAT_Parameters_from2014] 
                                     where ID not in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema group by [LfdNr])
                                     and ZVSTA_Schema=@ZVSTA_Schema)


                                    IF @DUBLICATE_NR>0
                                    BEGIN
                                    SELECT @DUBLICATE_NR
                                    --Find equal Nr to @DUPLICATE
                                    INSERT INTO @ID_3
                                    (ID,Number)
                                    select ID,[LfdNr] from [ZVSTAT_Parameters_from2014]  
                                    where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr]=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema)
                                    and ZVSTA_Schema=@ZVSTA_Schema

                                    SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                    IF @NEW_RUNNING_NR=0
                                    BEGIN
                                    SET @NEW_RUNNING_NR=1
                                    INSERT INTO @ID_4
                                    (ID,Number)
                                    Select ID,[LfdNr]+@NEW_RUNNING_NR from [ZVSTAT_Parameters_from2014] 
                                    where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr] >=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema
                                    group by [LfdNr]) and ZVSTA_Schema=@ZVSTA_Schema order by ID asc
                                    END
                                    END

                                    UPDATE A SET A.[LfdNr]=B.Number from [ZVSTAT_Parameters_from2014] A INNER JOIN @ID_4 B on A.ID=B.ID where A.ZVSTA_Schema=@ZVSTA_Schema"

                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_ADD>", ID_1)
                        cmd.CommandText = SqlCommandText

                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & vbNewLine & "removed to the new Position", "NEW ZV STATISTIC PARAMETER ADDED IN CURRENT POSITION", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If



    End Sub

    Private Sub BbiAddSQLtoNextPosition_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiAddSQLtoNextPosition.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle
        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                'Me.SQL_PARAMETER_ABindingSource.CancelEdit()
                If XtraMessageBox.Show("Should the ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & " added a next Position?", "ADD NEW ZV STATISTIC PARAMETER IN NEXT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try

                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                          DECLARE @DUBLICATE_NR float=0
                                          DECLARE @NEW_RUNNING_NR float=0
                                          DECLARE @ID_3 table (ID int NULL,Number float)
                                          DECLARE @ID_4 table (ID int NULL,Number float)

                                    INSERT INTO [ZVSTAT_Parameters_from2014]
                                            ([ZVSTA_Schema]
                                            ,[LfdNr]
                                            ,[FormNr]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
	                                SELECT 
			                                [ZVSTA_Schema]
                                            ,[LfdNr]+1
                                            ,[FormNr]
                                            ,'ADDED TO POSITION'
                                            ,SYSTEM_USER
                                            ,GETDATE()
	                                        FROM [ZVSTAT_Parameters_from2014] where ID=@ID_1

                                     SET @DUBLICATE_NR=(select [LfdNr] from [ZVSTAT_Parameters_from2014] 
                                     where ID not in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema group by [LfdNr])
                                     and ZVSTA_Schema=@ZVSTA_Schema)


                                    IF @DUBLICATE_NR>0
                                    BEGIN
                                    SELECT @DUBLICATE_NR
                                    --Find equal Nr to @DUPLICATE
                                    INSERT INTO @ID_3
                                    (ID,Number)
                                    select ID,[LfdNr] from [ZVSTAT_Parameters_from2014]  
                                    where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014]  where [LfdNr]=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema)
                                    and ZVSTA_Schema=@ZVSTA_Schema

                                    SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                    IF @NEW_RUNNING_NR=0
                                    BEGIN
                                    SET @NEW_RUNNING_NR=1
                                    INSERT INTO @ID_4
                                    (ID,Number)
                                    Select ID,[LfdNr]+@NEW_RUNNING_NR from [ZVSTAT_Parameters_from2014] 
                                    where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr] >=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema
                                    group by [LfdNr]) and ZVSTA_Schema=@ZVSTA_Schema order by ID asc
                                    END
                                    END

                                    UPDATE A SET A.[LfdNr]=B.Number from [ZVSTAT_Parameters_from2014] A INNER JOIN @ID_4 B on A.ID=B.ID where A.ZVSTA_Schema=@ZVSTA_Schema"

                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_ADD>", ID_1)
                        cmd.CommandText = SqlCommandText

                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & vbNewLine & "removed to the new Position", "NEW ZV STATISTIC PARAMETER ADDED IN CURRENT POSITION", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub BbiChangeSQLtoPosition_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiChangeSQLtoPosition.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then

                'initialize a New XtraInputBoxArgs instance
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Change Position for current ZV Parameter"
                args.Prompt = "Add new LfdNr"
                args.DefaultButtonIndex = 0

                AddHandler args.Showing, AddressOf Args_Showing
                Dim NewLfdNr As New SpinEdit()
                NewLfdNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
                NewLfdNr.Properties.EditMask = "[0-9]{1,10}"
                args.Editor = NewLfdNr


                Dim result As Object = XtraInputBox.Show(args)
                If result IsNot Nothing Then
                    If XtraMessageBox.Show("Should the ZV Statistik Parameter: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & " be relocated from current LfdNr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "LfdNr") & " to LfdNr: " & NewLfdNr.EditValue.ToString, "RELOCATE ZV STATISTIK PARAMETER TO NEW POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        Try
                            OpenSqlConnections()
                            SqlCommandText = "DECLARE @ID_1 int=<ID_to_RELOCATE>
                                      DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'

                                      DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                      DECLARE @DUBLICATE_NR float=0
                                      DECLARE @NEW_RUNNING_NR float=0
                                      DECLARE @ID_3 table (ID int NULL,Number float)
                                      DECLARE @ID_4 table (ID int NULL,Number float)

                           INSERT INTO [ZVSTAT_Parameters_from2014]
                                       ([ZVSTA_Schema]
                                        ,[LfdNr]
                                        ,[FormNr]
                                        ,[FormName]
                                        ,[PositionNr]
                                        ,[PositionName]
                                        ,[Landkontext]
                                        ,[LandCode]
                                        ,[Anzahl]
                                        ,[Wert]
                                        ,[SumPosition]
                                        ,[PositionSQLcommand]
                                        ,[PositionInfo]
                                        ,[LastAction]
                                        ,[LastUpdateUser]
                                        ,[LastUpdateDate])
                         SELECT 
                                        [ZVSTA_Schema]
                                        ,'" & NewLfdNr.EditValue.ToString & "'
                                        ,[FormNr]
                                        ,[FormName]
                                        ,[PositionNr]
                                        ,[PositionName]
                                        ,[Landkontext]
                                        ,[LandCode]
                                        ,[Anzahl]
                                        ,[Wert]
                                        ,[SumPosition]
                                        ,[PositionSQLcommand]
                                        ,[PositionInfo]
                                        ,'Changed Position from LfdNr: '+ CONVERT(nvarchar(10),[LfdNr])
                                        ,SYSTEM_USER
                                        ,GETDATE()
                                     FROM [ZVSTAT_Parameters_from2014] where ID=@ID_1

                                    DELETE FROM [ZVSTAT_Parameters_from2014] where ID=@ID_1 and [ZVSTA_Schema]=@ZVSTA_Schema

                                    SET @DUBLICATE_NR=(select [LfdNr] from [ZVSTAT_Parameters_from2014] 
                                    where ID not in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema group by [LfdNr])
                                    and ZVSTA_Schema=@ZVSTA_Schema)


                                    IF @DUBLICATE_NR>0
                                    BEGIN
                                    SELECT @DUBLICATE_NR
                                    --Find equal Nr to @DUPLICATE
                                    INSERT INTO @ID_3
                                    (ID,Number)
                                    select ID,[LfdNr] from [ZVSTAT_Parameters_from2014]  
                                    where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr]=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema)
                                    and ZVSTA_Schema=@ZVSTA_Schema

                                    SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                    IF @NEW_RUNNING_NR=0
                                    BEGIN
                                    SET @NEW_RUNNING_NR=1
                                    INSERT INTO @ID_4
                                    (ID,Number)
                                    Select ID,[LfdNr]+@NEW_RUNNING_NR from [ZVSTAT_Parameters_from2014] 
                                    where ID in (Select Min(ID) from [ZVSTAT_Parameters_from2014] where [LfdNr] >=@DUBLICATE_NR and ZVSTA_Schema=@ZVSTA_Schema
                                    group by [LfdNr]) and ZVSTA_Schema=@ZVSTA_Schema order by ID asc
                                    END
                                    END

                                    UPDATE A SET A.[LfdNr]=B.Number from [ZVSTAT_Parameters_from2014] A INNER JOIN @ID_4 B on A.ID=B.ID where A.ZVSTA_Schema=@ZVSTA_Schema


                                   --Reset LfdNr
                                   UPDATE A SET A.LfdNr=B.New_LfdNr FROM  [ZVSTAT_Parameters_from2014] A INNER JOIN 
                                   (SELECT ID,[LfdNr], ROW_NUMBER() OVER (ORDER BY [LfdNr]) AS New_LfdNr
                                   FROM [ZVSTAT_Parameters_from2014] where ZVSTA_Schema=@ZVSTA_Schema) B on A.ID=B.ID"
                            SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_RELOCATE>", ID_1)
                            cmd.CommandText = SqlCommandText
                            cmd.ExecuteNonQuery()

                            XtraMessageBox.Show("ZV Statistik Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "PositionNr") & vbNewLine & "successfull relocated", "RELOCATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CloseSqlConnections()
                            FILL_ALL_DATA_CURRENT_SCHEMA()
                            focusedView.RefreshData()
                            focusedView.FocusedRowHandle = GetFocusedRow

                        Catch ex As Exception
                            CloseSqlConnections()
                            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If
            Else
                XtraMessageBox.Show("Operation is canceled!", "NO LFDNR ENTERED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub BbiDeactivateFormNr_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDeactivateFormNr.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle
        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                If XtraMessageBox.Show("Should the ZV Statistik Form: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "FormNr") & " for ZV Statistic Shema: " & Me.Meldeschemas_BarEditItem.EditValue.ToString & " be deactivated?", "DEACTIVATE ZV STATISTIC FORM NR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try

                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_1 int=<ID_to_DEACTIVATE>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @FORM_NR Nvarchar(50)=(Select FormNr from ZVSTAT_Parameters_from2014 where ID=@ID_1 and [ZVSTA_Schema]=@ZVSTA_Schema)
                                          
                                          UPDATE [ZVSTAT_Parameters_from2014] SET [PositionStatus]='N' where FormNr=@FORM_NR and ZVSTA_Schema=@ZVSTA_Schema"

                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_DEACTIVATE>", ID_1)
                        cmd.CommandText = SqlCommandText

                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik FormNr:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "FormNr") & vbNewLine & " for ZV Statistic Shema: " & Me.Meldeschemas_BarEditItem.EditValue.ToString & " is deactivated", "DEACTIVATE ZV STATISTIC FORM NR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub BbiActivateFormNr_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiActivateFormNr.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle
        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "ZVSTAT_Meldeschemas_Gridview" Then
                If XtraMessageBox.Show("Should the ZV Statistik Form: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "FormNr") & " for ZV Statistic Shema: " & Me.Meldeschemas_BarEditItem.EditValue.ToString & " be activated?", "ACTIVATE ZV STATISTIC FORM NR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try

                        OpenSqlConnections()
                        SqlCommandText = "DECLARE @ID_1 int=<ID_to_ACTIVATE>
                                          DECLARE @ZVSTA_Schema nvarchar(50) ='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                          DECLARE @FORM_NR Nvarchar(50)=(Select FormNr from ZVSTAT_Parameters_from2014 where ID=@ID_1 and [ZVSTA_Schema]=@ZVSTA_Schema)
                                          
                                          UPDATE [ZVSTAT_Parameters_from2014] SET [PositionStatus]='Y' where FormNr=@FORM_NR and ZVSTA_Schema=@ZVSTA_Schema"

                        SqlCommandText = SqlCommandText.ToString.Replace("<ID_to_ACTIVATE>", ID_1)
                        cmd.CommandText = SqlCommandText

                        cmd.ExecuteNonQuery()

                        XtraMessageBox.Show("ZV Statistik FormNr:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "FormNr") & vbNewLine & " for ZV Statistic Shema: " & Me.Meldeschemas_BarEditItem.EditValue.ToString & " is activated", "ACTIVATE ZV STATISTIC FORM NR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        FILL_ALL_DATA_CURRENT_SCHEMA()
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub


    Private Sub ZVSTAT_Meldeschemas_Gridview_PopupMenuShowing(sender As Object, e As Grid.PopupMenuShowingEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.PopupMenuShowing

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
        ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowPreview = True
    End Sub

    Private Sub MyMenuItem_DisablePreview_D(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowPreview = False
    End Sub

    Private Sub ZVSTAT_Meldeschemas_Gridview_EditFormShowing(sender As Object, e As EditFormShowingEventArgs) Handles ZVSTAT_Meldeschemas_Gridview.EditFormShowing
        Dim view As GridView = TryCast(sender, GridView)
        e.Allow = view.IsNewItemRow(e.RowHandle)
    End Sub

    Private Sub NewMeldeschemaFromCurrent_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles NewMeldeschemaFromCurrent_btn.ItemClick
        ' initialize a new XtraInputBoxArgs instance
        Dim args As New XtraInputBoxArgs()
        ' set required Input Box options
        args.Caption = "New ZV Statistic Meldeschema based on current"
        args.Prompt = "Add new Name for Meldeschema"
        args.DefaultButtonIndex = 0

        AddHandler args.Showing, AddressOf Args_Showing
        Dim NewZvMeldeschema As New TextEdit()
        NewZvMeldeschema.Properties.CharacterCasing = CharacterCasing.Upper
        args.Editor = NewZvMeldeschema
        Dim result As Object = XtraInputBox.Show(args)

        If result IsNot Nothing Then
            QueryText = "Select [ID] from [ZVSTAT_Parameters_from2014] where [ZVSTA_Schema]='" & result & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count = 0 Then ' No duplicate ZVSTA Meldeschema

                'MsgBox(AnaCreditContractsList.EditValue.ToString)
                If XtraMessageBox.Show("Should the new ZV Statistic Meldeschema: " & NewZvMeldeschema.EditValue.ToString & vbNewLine _
                                   & "be added with the Parameters of the current Meldeschema:" & Me.Meldeschemas_BarEditItem.EditValue.ToString, "Add new ZV Statistic Meldeschema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Adding ZV Statistic Meldeschema: " & NewZvMeldeschema.EditValue.ToString & " with parameters from current Meldeschema" & Me.Meldeschemas_BarEditItem.EditValue.ToString)
                        'Add by copying current Parameters
                        OpenSqlConnections()
                        cmd.CommandText = "INSERT INTO [ZVSTAT_Parameters_from2014]
                                                    ([ZVSTA_Schema]
                                                    ,[LfdNr]
                                                    ,[FormNr]
                                                    ,[FormName]
                                                    ,[PositionNr]
                                                    ,[PositionName]
                                                    ,[Landkontext]
                                                    ,[LandCode]
                                                    ,[Anzahl]
                                                    ,[Wert]
                                                    ,[SumPosition]
                                                    ,[PositionSQLcommand]
                                                    ,[PositionInfo]
                                                    ,[LastAction]
                                                    ,[LastUpdateUser]
                                                    ,[LastUpdateDate])
                                             SELECT
                                                    '" & NewZvMeldeschema.EditValue.ToString & "'
                                                    ,[LfdNr]
                                                    ,[FormNr]
                                                    ,[FormName]
                                                    ,[PositionNr]
                                                    ,[PositionName]
                                                    ,[Landkontext]
                                                    ,[LandCode]
                                                    ,[Anzahl]
                                                    ,[Wert]
                                                    ,[SumPosition]
                                                    ,[PositionSQLcommand]
                                                    ,[PositionInfo]
                                                    ,'ADDED FROM MELDESCHEMA:' + '" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                                    ,SYSTEM_USER
                                                    ,GETDATE()
                                                     FROM 
                                                     [ZVSTAT_Parameters_from2014]
                                                     where [ZVSTA_Schema]='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'
                                                     Order by LfdNr asc"
                        cmd.ExecuteNonQuery()
                        '+++++++++++++++++++++++++++
                        CloseSqlConnections()

                        SplashScreenManager.Default.SetWaitFormCaption("Load parameters for new added Meldeschema" & NewZvMeldeschema.EditValue.ToString)

                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Me.Meldeschemas_BarEditItem.EditValue = NewZvMeldeschema.EditValue.ToString
                        FILL_ALL_DATA_CURRENT_SCHEMA()

                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return

                    End Try

                End If
            Else
                XtraMessageBox.Show("The entered ZVSTA Meldeschema: " & result & " exists allready" & vbNewLine & "Please enter another Meldeschema Name", "ZVSTA Meldeschema exists", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Operation is canceled!", "NO MELDESCHEMA ENTERED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub


        End If

    End Sub

    Private Sub NewMeldeschema_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles NewMeldeschema_btn.ItemClick
        ' initialize a new XtraInputBoxArgs instance
        Dim args As New XtraInputBoxArgs()
        ' set required Input Box options
        args.Caption = "New ZV Statistic Meldeschema"
        args.Prompt = "Add Name for new Meldeschema"
        args.DefaultButtonIndex = 0

        AddHandler args.Showing, AddressOf Args_Showing
        Dim NewZvMeldeschema As New TextEdit()
        NewZvMeldeschema.Properties.CharacterCasing = CharacterCasing.Upper
        args.Editor = NewZvMeldeschema
        Dim result As Object = XtraInputBox.Show(args)

        If result IsNot Nothing Then
            QueryText = "Select [ID] from [ZVSTAT_Parameters_from2014] where [ZVSTA_Schema]='" & result & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count = 0 Then ' No duplicate ZVSTA Meldeschema

                'MsgBox(AnaCreditContractsList.EditValue.ToString)
                If XtraMessageBox.Show("Should the new ZV Statistic Meldeschema: " & NewZvMeldeschema.EditValue.ToString & vbNewLine _
                                   & "be added ?", "Add new ZV Statistic Meldeschema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Adding new ZV Statistic Meldeschema: " & NewZvMeldeschema.EditValue.ToString)
                        'Add by copying current Parameters
                        OpenSqlConnections()
                        cmd.CommandText = "INSERT INTO [ZVSTAT_Parameters_from2014]
                                                    ([ZVSTA_Schema]
                                                    ,[LfdNr]
                                                    ,[LastAction]
                                                    ,[LastUpdateUser]
                                                    ,[LastUpdateDate])
                                             SELECT '" & NewZvMeldeschema.EditValue.ToString & "'
                                                    ,1
                                                    ,'NEW MELDESCHEMA ADDED'
                                                    ,SYSTEM_USER
                                                    ,GETDATE()"
                        cmd.ExecuteNonQuery()
                        '+++++++++++++++++++++++++++
                        CloseSqlConnections()

                        SplashScreenManager.Default.SetWaitFormCaption("Load parameters for new added Meldeschema" & NewZvMeldeschema.EditValue.ToString)

                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Me.Meldeschemas_BarEditItem.EditValue = NewZvMeldeschema.EditValue.ToString
                        FILL_ALL_DATA_CURRENT_SCHEMA()

                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return

                    End Try

                End If
            Else
                XtraMessageBox.Show("The entered ZVSTA Meldeschema: " & result & " exists allready" & vbNewLine & "Please enter another Meldeschema Name", "ZVSTA Meldeschema exists", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Operation is canceled!", "NO MELDESCHEMA ENTERED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub


        End If
    End Sub

    Private Sub RenameCurrentMeldeschema_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RenameCurrentMeldeschema_btn.ItemClick
        ' initialize a new XtraInputBoxArgs instance
        Dim args As New XtraInputBoxArgs()
        ' set required Input Box options
        args.Caption = "Rename current ZV Statistic Meldeschema"
        args.Prompt = "Add Name for current Meldeschema"
        args.DefaultButtonIndex = 0

        AddHandler args.Showing, AddressOf Args_Showing
        Dim NewZvMeldeschema As New TextEdit()
        NewZvMeldeschema.Properties.CharacterCasing = CharacterCasing.Upper
        args.Editor = NewZvMeldeschema
        Dim result As Object = XtraInputBox.Show(args)

        If result IsNot Nothing Then
            QueryText = "Select [ID] from [ZVSTAT_Parameters_from2014] where [ZVSTA_Schema] in ('" & result & "')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count = 0 Then ' No duplicate ZVSTA Meldeschema

                'MsgBox(AnaCreditContractsList.EditValue.ToString)
                If XtraMessageBox.Show("Should the current ZV Statistic Meldeschema renamed in: " & NewZvMeldeschema.EditValue.ToString & vbNewLine _
                                   , "Rename current ZV Statistic Meldeschema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Rename current ZV Statistic Meldeschema in: " & NewZvMeldeschema.EditValue.ToString)
                        'Add by copying current Parameters
                        OpenSqlConnections()
                        cmd.CommandText = "UPDATE [ZVSTAT_Parameters_from2014] 
                                           SET [ZVSTA_Schema]='" & NewZvMeldeschema.EditValue.ToString & "',
                                           [LastAction]='MELDESCHEMA RENAMED',
                                           [LastUpdateUser]=SYSTEM_USER,
                                           [LastUpdateDate]=GETDATE()
                                           Where [ZVSTA_Schema]='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'"
                        cmd.ExecuteNonQuery()
                        '+++++++++++++++++++++++++++
                        CloseSqlConnections()

                        SplashScreenManager.Default.SetWaitFormCaption("Load new Meldeschema" & NewZvMeldeschema.EditValue.ToString)

                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Me.Meldeschemas_BarEditItem.EditValue = NewZvMeldeschema.EditValue.ToString
                        FILL_ALL_DATA_CURRENT_SCHEMA()

                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return

                    End Try

                End If
            Else
                XtraMessageBox.Show("The entered ZVSTA Meldeschema: " & result & " exists allready" & vbNewLine & "Please enter another Meldeschema Name", "ZVSTA Meldeschema exists", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Operation is canceled!", "NO MELDESCHEMA ENTERED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub


        End If
    End Sub

    Private Sub DeleteCurrentMeldeschema_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DeleteCurrentMeldeschema_btn.ItemClick
        If XtraMessageBox.Show("Should the current ZV Statistic Meldeschema " & Me.Meldeschemas_BarEditItem.EditValue.ToString & " be deleted ?" & vbNewLine _
                                   , "Delete current ZV Statistic Meldeschema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Delete ZV Statistic Meldeschema: " & Me.Meldeschemas_BarEditItem.EditValue.ToString)
                'Add by copying current Parameters
                OpenSqlConnections()
                cmd.CommandText = "DELETE FROM [ZVSTAT_Parameters_from2014] 
                                   Where [ZVSTA_Schema]='" & Me.Meldeschemas_BarEditItem.EditValue.ToString & "'"
                cmd.ExecuteNonQuery()
                '+++++++++++++++++++++++++++
                CloseSqlConnections()

                MELDESCHEMA_SELECTION_initData()
                MELDESCHEMA_SELECTION_InitLookUp()
                FILL_ALL_DATA()

                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End Try

        End If
    End Sub

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub

    Private Sub FindAndReplaceText_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles FindAndReplaceText_bbi.ItemClick
        Dim dtColumns As New DataTable
        dtColumns.Columns.Add("ColumnName", Type.GetType("System.String"))
        For Each column As DevExpress.XtraGrid.Columns.GridColumn In ZVSTAT_Meldeschemas_Gridview.Columns
            If column.Visible = True Then
                Dim dr As DataRow = dtColumns.NewRow
                dr("ColumnName") = column.Name.ToString
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

        If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic Parameter - Search and Replace", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            If c.ColumnsNames_LookUpEdit.Text <> "" Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Search and replace Text in the specified Column")
                    'MsgBox(c.ColumnsNames_LookUpEdit.EditValue.ToString)
                    Dim column As GridColumn = ZVSTAT_Meldeschemas_Gridview.Columns.ColumnByName(c.ColumnsNames_LookUpEdit.EditValue.ToString)
                    Dim searchValue As String = c.SearchText_MemoEdit.Text
                    Dim newValue As String = c.ReplaceText_MemoEdit.Text

                    For i As Integer = ZVSTAT_Meldeschemas_Gridview.FocusedRowHandle To ZVSTAT_Meldeschemas_Gridview.DataRowCount - 1
                        Dim value As Object = ZVSTAT_Meldeschemas_Gridview.GetRowCellDisplayText(i, column)
                        'MsgBox(value)
                        If value.ToString() = "" Then
                            Continue For
                        End If

                        If searchValue <> "" Then
                            If value.ToString().StartsWith(searchValue) Or value.ToString().Contains(searchValue) Or value.ToString().EndsWith(searchValue) Then
                                ZVSTAT_Meldeschemas_Gridview.FocusedRowHandle = i
                                SplashScreenManager.Default.SetWaitFormCaption("Replace Text in Row: " & i)
                                ZVSTAT_Meldeschemas_Gridview.GetRowCellValue(i, column).ToString()
                                'MsgBox(i & vbNewLine & column.FieldName)
                                If newValue <> "" Then
                                    ZVSTAT_Meldeschemas_Gridview.SetRowCellValue(i, column.FieldName, ZVSTAT_Meldeschemas_Gridview.GetRowCellValue(i, column).ToString().Replace(searchValue, newValue).ToString)
                                ElseIf newValue = "" Then
                                    ZVSTAT_Meldeschemas_Gridview.SetRowCellValue(i, column.FieldName, ZVSTAT_Meldeschemas_Gridview.GetRowCellValue(i, column).ToString().Replace(searchValue, "").ToString)
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