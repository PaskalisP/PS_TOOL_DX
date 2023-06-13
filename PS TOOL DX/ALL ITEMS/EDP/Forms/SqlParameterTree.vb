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
Imports PS_TOOL_DX.RichEditSyntaxSample
Imports PS_TOOL_DX.VbSyntaxHighlightApp
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils.Menu
Imports DevExpress.Utils.Svg
Imports DevExpress.XtraTreeList.Localization

Public Class SqlParameterTree

    Dim ID_1 As Integer = 0
    Dim ID_2 As Integer = 0
    Dim ID_3 As Integer = 0
    Dim ID_4 As Integer = 0

    Dim Sql_ScriptType_General As String = Nothing


    Dim ParameterB_View As DevExpress.XtraGrid.Views.Grid.GridView
    Dim ParameterC_View As DevExpress.XtraGrid.Views.Grid.GridView
    Dim ParameterD_View As DevExpress.XtraGrid.Views.Grid.GridView

    Dim LEVEL_1 As String = Nothing
    Dim LEVEL_2 As String = Nothing
    Dim LEVEL_3 As String = Nothing

    Dim ParameterB_ViewCaption As String = Nothing
    Dim ParameterC_ViewCaption As String = Nothing
    Dim ParameterD_ViewCaption As String = Nothing

    Dim workbookI As IWorkbook
    Dim workbook As Workbook
    Dim worksheet As Worksheet
    Dim ExcelFileDirectory As String = Nothing
    Dim ExcelFileExtension As String = Nothing



    Private Sub FILL_ALL_DATA()
        QueryText = "DECLARE @SQL_TREE_LIST as Table
                    (ID int IDENTITY(1,1) NOT NULL,
                    PARENTID int NULL,
                    ORIGID int NULL,
                    SQL_Name_1 nvarchar(255) NULL,
					SQL_Name_2 nvarchar(255) NULL,
					SQL_Name_3 nvarchar(255) NULL,
					SQL_Name_4 nvarchar(255) NULL,
					SQL_Float_1 float NULL,
					SQL_Float_2 float NULL,
					SQL_Float_3 float NULL,
					SQL_Float_4 float NULL,
					SQL_Command_1 varchar(max) NULL,
					SQL_Command_2 varchar(max) NULL,
					SQL_Command_3 varchar(max) NULL,
					SQL_Command_4 varchar(max) NULL,
					SQL_Date1 datetime NULL,
					SQL_Date2 datetime NULL,
					SQL_Status nvarchar(50) NULL,
					LastAction nvarchar(4000) NULL,
					LastUpdateUser nvarchar(255) NULL,
					LastUpdateDate datetime NULL,
					SQL_ScriptType_1 nvarchar(50) NULL,
					SQL_ScriptType_2 nvarchar(50) NULL,
					SQL_ScriptType_3 nvarchar(50) NULL,
					SQL_ScriptType_4 nvarchar(50) NULL,
                    Table_Level nvarchar(255) NULL)

					 INSERT INTO @SQL_TREE_LIST
                    (PARENTID,
                    ORIGID,
                    SQL_Name_1,
					SQL_Command_1,
					SQL_Command_2,
					SQL_Float_1,
					SQL_Status,
                    Table_Level)
                    SELECT 
                    -1,
                    ID,
                    SQL_Parameter_Name,
					SQL_Command_General,
					SQL_Parameter_Info,
					SQL_Float,
					SQL_Parameter_Status,
                    'A'
                    FROM [SQL_PARAMETER]
					order by SQL_Float asc

					 INSERT INTO @SQL_TREE_LIST
                    (PARENTID,
                    ORIGID,
                    SQL_Name_1,
					SQL_Name_2,
					SQL_Name_3,
					SQL_Name_4,
					SQL_Float_1,
					SQL_Float_2,
					SQL_Float_3,
					SQL_Float_4,
					SQL_Command_1,
					SQL_Command_2,
					SQL_Command_3,
					SQL_Command_4,
					SQL_Date1,
					SQL_Date2,
					SQL_Status,
                    Table_Level)
                    SELECT 
                    B.ID,
                    A.ID,
                    A.SQL_Name_1,
					A.SQL_Name_2,
					A.SQL_Name_3,
					A.SQL_Name_4,
					A.SQL_Float_1,
					A.SQL_Float_2,
					A.SQL_Float_3,
					A.SQL_Float_4,
					A.SQL_Command_1,
					A.SQL_Command_2,
					A.SQL_Command_3,
					A.SQL_Command_4,
					A.SQL_Date1,
					A.SQL_Date2,
					A.Status,
                    'B'
                    FROM [SQL_PARAMETER_DETAILS] A INNER JOIN @SQL_TREE_LIST B 
					on A.Id_SQL_Parameters= B.SQL_Name_1
					ORDER BY A.SQL_Float_1 asc

					INSERT INTO @SQL_TREE_LIST
                    (PARENTID,
                    ORIGID,
                    SQL_Name_1,
					SQL_Name_2,
					SQL_Name_3,
					SQL_Name_4,
					SQL_Float_1,
					SQL_Float_2,
					SQL_Float_3,
					SQL_Float_4,
					SQL_Command_1,
					SQL_Command_2,
					SQL_Command_3,
					SQL_Command_4,
					SQL_Date1,
					SQL_Date2,
					SQL_Status,
                    Table_Level)
                    SELECT 
                    B.ID,
                    A.ID,
					A.SQL_Name_1,
					A.SQL_Name_2,
					A.SQL_Name_3,
					A.SQL_Name_4,
					A.SQL_Float_1,
					A.SQL_Float_2,
					A.SQL_Float_3,
					A.SQL_Float_4,
					A.SQL_Command_1,
					A.SQL_Command_2,
					A.SQL_Command_3,
					A.SQL_Command_4,
					A.SQL_Date1,
					A.SQL_Date2,
					A.Status,
                    'C'
                    FROM [SQL_PARAMETER_DETAILS_SECOND] A INNER JOIN @SQL_TREE_LIST B on A.Id_SQL_Parameters_Details=B.ORIGID
					ORDER BY A.SQL_Float_1 asc

					INSERT INTO @SQL_TREE_LIST
                    (PARENTID,
                    ORIGID,
					SQL_Name_1,
					SQL_Name_2,
					SQL_Name_3,
					SQL_Name_4,
					SQL_Float_1,
					SQL_Float_2,
					SQL_Float_3,
					SQL_Float_4,
					SQL_Command_1,
					SQL_Command_2,
					SQL_Command_3,
					SQL_Command_4,
					SQL_Date1,
					SQL_Date2,
					SQL_Status,
                    Table_Level)
                    SELECT 
                    B.ID,
                    A.ID,
					A.SQL_Name_1,
					A.SQL_Name_2,
					A.SQL_Name_3,
					A.SQL_Name_4,
					A.SQL_Float_1,
					A.SQL_Float_2,
					A.SQL_Float_3,
					A.SQL_Float_4,
					A.SQL_Command_1,
					A.SQL_Command_2,
					A.SQL_Command_3,
					A.SQL_Command_4,
					A.SQL_Date1,
					A.SQL_Date2,
					A.Status,
                    'D'
                    FROM [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN @SQL_TREE_LIST B on A.Id_SQL_Parameters_Details=B.ORIGID
					ORDER BY A.SQL_Float_1 asc

                    --DELETE from @SQL_TREE_LIST where ID not in (Select MAX(ID) from @SQL_TREE_LIST GROUP BY ORIGID, SQL_NAME_1)


                    SELECT * from @SQL_TREE_LIST ORDER BY SQL_Float_1 asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.TreeList1.DataSource = Nothing
            Me.TreeList1.DataSource = dt
            Me.TreeList1.Columns(TreeList1.KeyFieldName).Visible = False
            Me.TreeList1.Columns(TreeList1.ParentFieldName).Visible = False

            'Me.TreeList1.ForceInitialize()
            'Me.TreeList1.BestFitColumns()

        End If
    End Sub

    Private Sub SqlParameterTree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FILL_ALL_DATA()
        Me.TreeList1.CollapseAll()
        Me.PopupContainerEdit3.PopupFormMinSize = New Size(650, 500)

    End Sub

    Private Sub SqlParameterTree_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub BbiSqlReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSqlReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload SQL Parameters Tree")
        Me.TreeList1.ClearColumnsFilter()
        Me.TreeList1.CollapseAll()
        TreeList1.FocusedNode = TreeList1.Nodes(0)
        FILL_ALL_DATA()
        Me.TreeList1.CollapseAll()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "SQL Parameters Tree"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClose.ItemClick
        Me.Close()

    End Sub

    Private Sub PrintableComponentLink1_BeforeCreateAreas(sender As Object, e As EventArgs) Handles PrintableComponentLink1.BeforeCreateAreas
        Me.TreeList1.OptionsView.AutoWidth = True

        Me.TreeList1.Columns("SQL_Command_1").ColumnEdit = MemoEdit1
        Me.TreeList1.Columns("SQL_Command_2").ColumnEdit = MemoEdit1
        Me.TreeList1.Columns("SQL_Command_3").ColumnEdit = MemoEdit1
        Me.TreeList1.Columns("SQL_Command_4").ColumnEdit = MemoEdit1
    End Sub

    Private Sub PrintableComponentLink1_AfterCreateAreas(sender As Object, e As EventArgs) Handles PrintableComponentLink1.AfterCreateAreas
        Me.TreeList1.OptionsView.AutoWidth = False

        Me.TreeList1.Columns("SQL_Command_1").ColumnEdit = RepositoryItemMemoExEdit1
        Me.TreeList1.Columns("SQL_Command_2").ColumnEdit = RepositoryItemMemoExEdit1
        Me.TreeList1.Columns("SQL_Command_3").ColumnEdit = RepositoryItemMemoExEdit1
        Me.TreeList1.Columns("SQL_Command_4").ColumnEdit = RepositoryItemMemoExEdit1

    End Sub


    Private Sub TreeList1_CustomNodeCellEditForEditing(sender As Object, e As GetCustomNodeCellEditEventArgs) Handles TreeList1.CustomNodeCellEditForEditing
        Dim view As TreeList = CType(sender, TreeList)

        If e.Column.FieldName.StartsWith("SQL_Command") = True Then
            e.RepositoryItem = Me.PopupContainerEdit3
            Me.RichEditControl2.ReadOnly = True
        End If

    End Sub


    Private Sub TreeList1_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles TreeList1.FocusedNodeChanged
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = TreeList1.FocusedNode
        If node IsNot TreeList1.Nodes.AutoFilterNode Then

            Sql_ScriptType_General = Nothing
            Sql_ScriptType_General = node.Item(17).ToString()
        ElseIf TreeList1.FocusedNode Is TreeList1.Nodes.AutoFilterNode Then
            Sql_ScriptType_General = Nothing
        End If

    End Sub

    Private Sub PopupContainerEdit3_QueryPopUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit3.QueryPopUp
        If Sql_ScriptType_General = "VB" Then
            RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New VbSyntaxHighlightService(RichEditControl2, RichEditControl2.Document))
        Else
            RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl2.Document))
        End If

        Dim editor As BaseEdit = DirectCast(sender, BaseEdit)
        RichEditControl2.Document.Text = editor.EditValue.ToString()
    End Sub

    Private Sub PopupContainerEdit3_QueryResultValue(sender As Object, e As QueryResultValueEventArgs) Handles PopupContainerEdit3.QueryResultValue
        e.Value = RichEditControl2.Document.Text
    End Sub

    Private Sub RichEditControl2_TextChanged(sender As Object, e As EventArgs) Handles RichEditControl2.TextChanged
        If Me.RichEditControl2.Text <> "" Then
            If Sql_ScriptType_General = "VB" Then
                RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New VbSyntaxHighlightService(RichEditControl2, RichEditControl2.Document))
            Else
                RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl2.Document))
            End If
        End If
    End Sub

    Private Sub RichEditControl2_GotFocus(sender As Object, e As EventArgs) Handles RichEditControl2.GotFocus
        If Sql_ScriptType_General = "VB" Then
            RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New VbSyntaxHighlightService(RichEditControl2, RichEditControl2.Document))
        Else
            RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl2.Document))
        End If
    End Sub

    Private Sub TreeList1_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles TreeList1.PopupMenuShowing
        Dim treeList As TreeList = TryCast(sender, TreeList)
        Dim hitInfo As TreeListHitInfo = treeList.CalcHitInfo(e.Point)

        If hitInfo.HitInfoType = HitInfoType.Column Then

            Dim menuItem_DisplayAll As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY ALL COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayAll), SharedImageCollection1.ImageSource.Images(7))
            Dim menuItem_DisplayDefault As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY DEFAULT COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayDefault), SharedImageCollection1.ImageSource.Images(8))
            Dim menuItem_EnablePreview As New DevExpress.Utils.Menu.DXMenuItem("ENABLE PREVIEW", New EventHandler(AddressOf MyMenuItem_EnablePreview), SharedImageCollection1.ImageSource.Images(5))
            Dim menuItem_DisablePreview As New DevExpress.Utils.Menu.DXMenuItem("DISABLE PREVIEW", New EventHandler(AddressOf MyMenuItem_DisablePreview), SharedImageCollection1.ImageSource.Images(6))


            menuItem_DisplayAll.Tag = hitInfo.Column
            menuItem_DisplayAll.BeginGroup = True
            menuItem_DisplayDefault.Tag = hitInfo.Column
            menuItem_EnablePreview.Tag = hitInfo.Column
            menuItem_EnablePreview.BeginGroup = True
            menuItem_DisablePreview.Tag = hitInfo.Column

            e.Menu.Items.Add(menuItem_DisplayAll)
            e.Menu.Items.Add(menuItem_DisplayDefault)
            e.Menu.Items.Add(menuItem_EnablePreview)
            e.Menu.Items.Add(menuItem_DisablePreview)

            Dim expandAllCaption As String = TreeListLocalizer.Active.GetLocalizedString(TreeListStringId.MenuNodeExpandAll)
            Dim expandAll As New DXMenuItem(expandAllCaption, Sub(ss, ee) treeList.ExpandAll())
            expandAll.ImageOptions.SvgImage = CommonSvgImages.Get(CommonSvgImages.Column.ExpandAll)
            e.Menu.Items.Add(expandAll)
            Dim collapseAllCaption As String = TreeListLocalizer.Active.GetLocalizedString(TreeListStringId.MenuNodeCollapseAll)
            Dim collapseAll As New DXMenuItem(collapseAllCaption, Sub(ss, ee) treeList.CollapseAll())
            collapseAll.ImageOptions.SvgImage = CommonSvgImages.Get(CommonSvgImages.Column.CollapseAll)
            e.Menu.Items.Add(collapseAll)
            e.Allow = True

        End If
    End Sub

    Private Sub MyMenuItem_DisplayAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i = 0 To Me.TreeList1.Columns.Count - 1
            Me.TreeList1.Columns(i).Visible = False
        Next
        Me.TreeList1.Columns("SQL_Float_1").VisibleIndex = 0
        Me.TreeList1.Columns("SQL_Name_1").VisibleIndex = 1
        Me.TreeList1.Columns("SQL_Name_2").VisibleIndex = 2
        Me.TreeList1.Columns("SQL_Name_3").VisibleIndex = 3
        Me.TreeList1.Columns("SQL_Name_4").VisibleIndex = 4
        Me.TreeList1.Columns("SQL_Command_1").VisibleIndex = 5
        Me.TreeList1.Columns("SQL_Command_2").VisibleIndex = 6
        Me.TreeList1.Columns("SQL_Command_3").VisibleIndex = 7
        Me.TreeList1.Columns("SQL_Command_4").VisibleIndex = 8
        Me.TreeList1.Columns("SQL_Status").VisibleIndex = 9
        Me.TreeList1.Columns("SQL_Float_2").VisibleIndex = 10
        Me.TreeList1.Columns("SQL_Float_3").VisibleIndex = 11
        Me.TreeList1.Columns("SQL_Float_4").VisibleIndex = 12
        Me.TreeList1.Columns("SQL_ScriptType_1").VisibleIndex = 13
        Me.TreeList1.Columns("SQL_ScriptType_2").VisibleIndex = 14
        Me.TreeList1.Columns("SQL_ScriptType_3").VisibleIndex = 15
        Me.TreeList1.Columns("SQL_ScriptType_4").VisibleIndex = 16
        Me.TreeList1.Columns("SQL_Date1").VisibleIndex = 17
        Me.TreeList1.Columns("SQL_Date2").VisibleIndex = 18
        Me.TreeList1.Columns("Table_Level").VisibleIndex = 19
    End Sub

    Private Sub MyMenuItem_DisplayDefault(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i = 0 To Me.TreeList1.Columns.Count - 1
            Me.TreeList1.Columns(i).Visible = False
        Next
        Me.TreeList1.Columns("SQL_Float_1").VisibleIndex = 0
        Me.TreeList1.Columns("SQL_Name_1").VisibleIndex = 1
        Me.TreeList1.Columns("SQL_ScriptType_1").VisibleIndex = 2
        Me.TreeList1.Columns("SQL_Command_1").VisibleIndex = 3
        Me.TreeList1.Columns("SQL_Status").VisibleIndex = 4
        Me.TreeList1.Columns("Table_Level").VisibleIndex = 5

    End Sub

    Private Sub MyMenuItem_EnablePreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TreeList1.OptionsView.ShowPreview = True
        Me.TreeList1.PreviewFieldName = "SQL_Command_1"
        Me.TreeList1.OptionsView.AutoCalcPreviewLineCount = True
        Me.TreeList1.OptionsFind.HighlightFindResults = True

    End Sub

    Private Sub MyMenuItem_DisablePreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TreeList1.OptionsView.ShowPreview = False
    End Sub


End Class