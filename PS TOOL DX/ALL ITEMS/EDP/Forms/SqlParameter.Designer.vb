<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqlParameter
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SqlParameter))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SQL_Parameter_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Name_1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Name_2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Name_3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Name_4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Float_1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colSQL_Float_2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Float_3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Float_4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Command_1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colSQL_Command_2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Command_3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Command_4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Date1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colSQL_Date2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colId_SQL_Parameters = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.SQL_PARAMETERBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EDPDataSet = New PS_TOOL_DX.EDPDataSet()
        Me.SQL_Parameter_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Float = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Parameter_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colSQL_Parameter_Info = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQL_Parameter_Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.PopupContainerEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.popupContainerControl = New DevExpress.XtraEditors.PopupContainerControl()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SQL_Duplicate_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_AddToPosition_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_DuplicateCurrentPosition_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_DuplicateNextPosition_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExportCurrentSqlParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_Parameter_Details_Second_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colId_SQL_Parameters_Details_3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SQL_Parameter_Details_Third_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colId_SQL_Parameters_Details_4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SQL_PARAMETERTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETERTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager()
        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETER_DETAILS_SECONDTableAdapter()
        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETER_DETAILS_THIRDTableAdapter()
        Me.SQL_PARAMETER_DETAILSTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETER_DETAILSTableAdapter()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.SQL_Parameter_ALL_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ALL_STATUS_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ALL_MemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn77 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn79 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn80 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn81 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn82 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn83 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn84 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn85 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn86 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn87 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn88 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn89 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ALL_PopupContainerEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.PopupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.RichEditControl2 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SQL_PARAMETER_DETAILSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQL_PARAMETER_DETAILS_SECONDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQL_PARAMETER_DETAILS_THIRDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SqlParameterGridviewPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbiReload = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPrintPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.FindAndReplaceText_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.ImportSqlFromExcelFile_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        CType(Me.SQL_Parameter_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_PARAMETERBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_Parameter_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl.SuspendLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_Parameter_Details_Second_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_Parameter_Details_Third_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_Parameter_ALL_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALL_STATUS_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALL_MemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALL_PopupContainerEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupContainerControl1.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_PARAMETER_DETAILSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_PARAMETER_DETAILS_SECONDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQL_PARAMETER_DETAILS_THIRDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SQL_Parameter_Details_GridView
        '
        Me.SQL_Parameter_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SQL_Parameter_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SQL_Parameter_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SQL_Parameter_Details_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SQL_Parameter_Details_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SQL_Parameter_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colSQL_Name_1, Me.colSQL_Name_2, Me.colSQL_Name_3, Me.colSQL_Name_4, Me.colSQL_Float_1, Me.colSQL_Float_2, Me.colSQL_Float_3, Me.colSQL_Float_4, Me.colSQL_Command_1, Me.colSQL_Command_2, Me.colSQL_Command_3, Me.colSQL_Command_4, Me.colSQL_Date1, Me.colSQL_Date2, Me.colStatus, Me.colId_SQL_Parameters})
        Me.SQL_Parameter_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SQL_Parameter_Details_GridView.GridControl = Me.GridControl3
        Me.SQL_Parameter_Details_GridView.Name = "SQL_Parameter_Details_GridView"
        Me.SQL_Parameter_Details_GridView.NewItemRowText = "Add new SQL Parameter Command"
        Me.SQL_Parameter_Details_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_GridView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.SQL_Parameter_Details_GridView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.SQL_Parameter_Details_GridView.OptionsDetail.AutoZoomDetail = True
        Me.SQL_Parameter_Details_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SQL_Parameter_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.SQL_Parameter_Details_GridView.OptionsSelection.MultiSelect = True
        Me.SQL_Parameter_Details_GridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.SQL_Parameter_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.SQL_Parameter_Details_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.SQL_Parameter_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.SQL_Parameter_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SQL_Parameter_Details_GridView.OptionsView.ShowGroupPanel = False
        Me.SQL_Parameter_Details_GridView.ViewCaption = "SQL Parameter Details"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colSQL_Name_1
        '
        Me.colSQL_Name_1.Caption = "SQL Name 1"
        Me.colSQL_Name_1.FieldName = "SQL_Name_1"
        Me.colSQL_Name_1.Name = "colSQL_Name_1"
        Me.colSQL_Name_1.Visible = True
        Me.colSQL_Name_1.VisibleIndex = 1
        Me.colSQL_Name_1.Width = 526
        '
        'colSQL_Name_2
        '
        Me.colSQL_Name_2.Caption = "SQL Name 2"
        Me.colSQL_Name_2.FieldName = "SQL_Name_2"
        Me.colSQL_Name_2.Name = "colSQL_Name_2"
        Me.colSQL_Name_2.Width = 201
        '
        'colSQL_Name_3
        '
        Me.colSQL_Name_3.Caption = "SQL Name 3"
        Me.colSQL_Name_3.FieldName = "SQL_Name_3"
        Me.colSQL_Name_3.Name = "colSQL_Name_3"
        Me.colSQL_Name_3.Width = 193
        '
        'colSQL_Name_4
        '
        Me.colSQL_Name_4.Caption = "SQL Name 4"
        Me.colSQL_Name_4.FieldName = "SQL_Name_4"
        Me.colSQL_Name_4.Name = "colSQL_Name_4"
        Me.colSQL_Name_4.Width = 198
        '
        'colSQL_Float_1
        '
        Me.colSQL_Float_1.Caption = "Float 1"
        Me.colSQL_Float_1.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colSQL_Float_1.FieldName = "SQL_Float_1"
        Me.colSQL_Float_1.Name = "colSQL_Float_1"
        Me.colSQL_Float_1.Visible = True
        Me.colSQL_Float_1.VisibleIndex = 0
        Me.colSQL_Float_1.Width = 95
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Mask.BeepOnError = True
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'colSQL_Float_2
        '
        Me.colSQL_Float_2.Caption = "Float 2"
        Me.colSQL_Float_2.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colSQL_Float_2.FieldName = "SQL_Float_2"
        Me.colSQL_Float_2.Name = "colSQL_Float_2"
        Me.colSQL_Float_2.Width = 74
        '
        'colSQL_Float_3
        '
        Me.colSQL_Float_3.Caption = "Float 3"
        Me.colSQL_Float_3.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colSQL_Float_3.FieldName = "SQL_Float_3"
        Me.colSQL_Float_3.Name = "colSQL_Float_3"
        Me.colSQL_Float_3.Width = 74
        '
        'colSQL_Float_4
        '
        Me.colSQL_Float_4.Caption = "Float 4"
        Me.colSQL_Float_4.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colSQL_Float_4.FieldName = "SQL_Float_4"
        Me.colSQL_Float_4.Name = "colSQL_Float_4"
        Me.colSQL_Float_4.Width = 72
        '
        'colSQL_Command_1
        '
        Me.colSQL_Command_1.Caption = "SQL Command 1"
        Me.colSQL_Command_1.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colSQL_Command_1.FieldName = "SQL_Command_1"
        Me.colSQL_Command_1.Name = "colSQL_Command_1"
        Me.colSQL_Command_1.Visible = True
        Me.colSQL_Command_1.VisibleIndex = 2
        Me.colSQL_Command_1.Width = 97
        '
        'RepositoryItemMemoExEdit3
        '
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AutoHeight = False
        Me.RepositoryItemMemoExEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit3.Name = "RepositoryItemMemoExEdit3"
        Me.RepositoryItemMemoExEdit3.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colSQL_Command_2
        '
        Me.colSQL_Command_2.Caption = "SQL Command 2"
        Me.colSQL_Command_2.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colSQL_Command_2.FieldName = "SQL_Command_2"
        Me.colSQL_Command_2.Name = "colSQL_Command_2"
        Me.colSQL_Command_2.Width = 103
        '
        'colSQL_Command_3
        '
        Me.colSQL_Command_3.Caption = "SQL Command 3"
        Me.colSQL_Command_3.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colSQL_Command_3.FieldName = "SQL_Command_3"
        Me.colSQL_Command_3.Name = "colSQL_Command_3"
        Me.colSQL_Command_3.Width = 108
        '
        'colSQL_Command_4
        '
        Me.colSQL_Command_4.Caption = "SQL Command 4"
        Me.colSQL_Command_4.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colSQL_Command_4.FieldName = "SQL_Command_4"
        Me.colSQL_Command_4.Name = "colSQL_Command_4"
        Me.colSQL_Command_4.Width = 110
        '
        'colSQL_Date1
        '
        Me.colSQL_Date1.Caption = "Date 1"
        Me.colSQL_Date1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colSQL_Date1.DisplayFormat.FormatString = "d"
        Me.colSQL_Date1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colSQL_Date1.FieldName = "SQL_Date1"
        Me.colSQL_Date1.Name = "colSQL_Date1"
        Me.colSQL_Date1.Visible = True
        Me.colSQL_Date1.VisibleIndex = 4
        Me.colSQL_Date1.Width = 101
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'colSQL_Date2
        '
        Me.colSQL_Date2.Caption = "Date 2"
        Me.colSQL_Date2.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colSQL_Date2.DisplayFormat.FormatString = "d"
        Me.colSQL_Date2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colSQL_Date2.FieldName = "SQL_Date2"
        Me.colSQL_Date2.Name = "colSQL_Date2"
        Me.colSQL_Date2.Visible = True
        Me.colSQL_Date2.VisibleIndex = 5
        Me.colSQL_Date2.Width = 99
        '
        'colStatus
        '
        Me.colStatus.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colStatus.FieldName = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.Visible = True
        Me.colStatus.VisibleIndex = 3
        Me.colStatus.Width = 115
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEACTIVATED", "N", 6)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "SQL Runner.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "CrystalReport.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "save_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(9, "table_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(10, "columnstwo_16x16.png")
        '
        'colId_SQL_Parameters
        '
        Me.colId_SQL_Parameters.FieldName = "Id_SQL_Parameters"
        Me.colId_SQL_Parameters.Name = "colId_SQL_Parameters"
        Me.colId_SQL_Parameters.OptionsColumn.ReadOnly = True
        Me.colId_SQL_Parameters.Width = 70
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.SQL_PARAMETERBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.ImageIndex = 4
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 7, True, False, "Delete selected Item", "Delete")})
        GridLevelNode1.LevelTemplate = Me.SQL_Parameter_Details_GridView
        GridLevelNode2.LevelTemplate = Me.SQL_Parameter_Details_Second_GridView
        GridLevelNode3.LevelTemplate = Me.SQL_Parameter_Details_Third_GridView
        GridLevelNode3.RelationName = "FK_SQL_PARAMETER_DETAILS_THIRD_SQL_PARAMETER_DETAILS_SECOND"
        GridLevelNode2.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode3})
        GridLevelNode2.RelationName = "FK_SQL_PARAMETER_DETAILS_SECOND_SQL_PARAMETER_DETAILS"
        GridLevelNode1.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        GridLevelNode1.RelationName = "FK_SQL_PARAMETER_DETAILS_SQL_PARAMETER"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl3.Location = New System.Drawing.Point(36, 57)
        Me.GridControl3.MainView = Me.SQL_Parameter_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox3, Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3, Me.RepositoryItemSpinEdit1, Me.RepositoryItemImageComboBox1, Me.RepositoryItemDateEdit1, Me.PopupContainerEdit2})
        Me.GridControl3.Size = New System.Drawing.Size(1362, 367)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SQL_Parameter_Gridview, Me.SQL_Parameter_Details_Second_GridView, Me.SQL_Parameter_Details_Third_GridView, Me.SQL_Parameter_Details_GridView})
        '
        'SQL_PARAMETERBindingSource
        '
        Me.SQL_PARAMETERBindingSource.DataMember = "SQL_PARAMETER"
        Me.SQL_PARAMETERBindingSource.DataSource = Me.EDPDataSet
        '
        'EDPDataSet
        '
        Me.EDPDataSet.DataSetName = "EDPDataSet"
        Me.EDPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SQL_Parameter_Gridview
        '
        Me.SQL_Parameter_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SQL_Parameter_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SQL_Parameter_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SQL_Parameter_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SQL_Parameter_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.SQL_Parameter_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colSQL_Float, Me.colSQL_Parameter_Name, Me.colSQL_Parameter_Info, Me.colSQL_Parameter_Status})
        Me.SQL_Parameter_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SQL_Parameter_Gridview.GridControl = Me.GridControl3
        Me.SQL_Parameter_Gridview.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CRSA_Position_Amount", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditOutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "BusinessTypeName", Nothing, "Count={0:n0}")})
        Me.SQL_Parameter_Gridview.Name = "SQL_Parameter_Gridview"
        Me.SQL_Parameter_Gridview.NewItemRowText = "Add new SQL Parameter Name"
        Me.SQL_Parameter_Gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Gridview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.SQL_Parameter_Gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.SQL_Parameter_Gridview.OptionsDetail.AllowExpandEmptyDetails = True
        Me.SQL_Parameter_Gridview.OptionsDetail.AutoZoomDetail = True
        Me.SQL_Parameter_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SQL_Parameter_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.SQL_Parameter_Gridview.OptionsFind.AlwaysVisible = True
        Me.SQL_Parameter_Gridview.OptionsSelection.MultiSelect = True
        Me.SQL_Parameter_Gridview.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.SQL_Parameter_Gridview.OptionsView.ColumnAutoWidth = False
        Me.SQL_Parameter_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.SQL_Parameter_Gridview.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.SQL_Parameter_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.SQL_Parameter_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SQL_Parameter_Gridview.OptionsView.ShowFooter = True
        Me.SQL_Parameter_Gridview.OptionsView.ShowGroupPanel = False
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colSQL_Float
        '
        Me.colSQL_Float.Caption = "Parameter Nr."
        Me.colSQL_Float.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colSQL_Float.DisplayFormat.FormatString = "n0"
        Me.colSQL_Float.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSQL_Float.FieldName = "SQL_Float"
        Me.colSQL_Float.Name = "colSQL_Float"
        Me.colSQL_Float.Visible = True
        Me.colSQL_Float.VisibleIndex = 0
        '
        'colSQL_Parameter_Name
        '
        Me.colSQL_Parameter_Name.Caption = "SQL Parameter Name"
        Me.colSQL_Parameter_Name.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSQL_Parameter_Name.FieldName = "SQL_Parameter_Name"
        Me.colSQL_Parameter_Name.Name = "colSQL_Parameter_Name"
        Me.colSQL_Parameter_Name.Visible = True
        Me.colSQL_Parameter_Name.VisibleIndex = 1
        Me.colSQL_Parameter_Name.Width = 611
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'colSQL_Parameter_Info
        '
        Me.colSQL_Parameter_Info.Caption = "Info"
        Me.colSQL_Parameter_Info.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colSQL_Parameter_Info.FieldName = "SQL_Parameter_Info"
        Me.colSQL_Parameter_Info.Name = "colSQL_Parameter_Info"
        Me.colSQL_Parameter_Info.Visible = True
        Me.colSQL_Parameter_Info.VisibleIndex = 2
        Me.colSQL_Parameter_Info.Width = 122
        '
        'colSQL_Parameter_Status
        '
        Me.colSQL_Parameter_Status.Caption = "Status"
        Me.colSQL_Parameter_Status.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colSQL_Parameter_Status.FieldName = "SQL_Parameter_Status"
        Me.colSQL_Parameter_Status.Name = "colSQL_Parameter_Status"
        Me.colSQL_Parameter_Status.Visible = True
        Me.colSQL_Parameter_Status.VisibleIndex = 3
        Me.colSQL_Parameter_Status.Width = 115
        '
        'RepositoryItemComboBox3
        '
        Me.RepositoryItemComboBox3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox3.AutoHeight = False
        Me.RepositoryItemComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox3.DropDownRows = 2
        Me.RepositoryItemComboBox3.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox3.ImmediatePopup = True
        Me.RepositoryItemComboBox3.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox3.Name = "RepositoryItemComboBox3"
        Me.RepositoryItemComboBox3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'PopupContainerEdit2
        '
        Me.PopupContainerEdit2.Appearance.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupContainerEdit2.Appearance.Options.UseFont = True
        Me.PopupContainerEdit2.AutoHeight = False
        Me.PopupContainerEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit2.Name = "PopupContainerEdit2"
        Me.PopupContainerEdit2.PopupControl = Me.popupContainerControl
        '
        'popupContainerControl
        '
        Me.popupContainerControl.Controls.Add(Me.RichEditControl1)
        Me.popupContainerControl.Location = New System.Drawing.Point(1214, 45)
        Me.popupContainerControl.Name = "popupContainerControl"
        Me.popupContainerControl.Size = New System.Drawing.Size(162, 38)
        Me.popupContainerControl.TabIndex = 18
        '
        'RichEditControl1
        '
        Me.RichEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.RichEditControl1.Appearance.Text.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichEditControl1.Appearance.Text.Options.UseFont = True
        Me.RichEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.RichEditControl1.Location = New System.Drawing.Point(0, 0)
        Me.RichEditControl1.MenuManager = Me.BarManager1
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Size = New System.Drawing.Size(162, 38)
        Me.RichEditControl1.TabIndex = 2
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.SQL_Duplicate_BarButtonItem, Me.SQL_AddToPosition_BarButtonItem, Me.SQL_DuplicateCurrentPosition_BarButtonItem, Me.SQL_DuplicateNextPosition_BarButtonItem, Me.bbiExportCurrentSqlParameter})
        Me.BarManager1.MaxItemId = 5
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1434, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 576)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1434, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 576)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1434, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 576)
        '
        'SQL_Duplicate_BarButtonItem
        '
        Me.SQL_Duplicate_BarButtonItem.Caption = "Duplicate current SQL Parameter (as new Parameter)"
        Me.SQL_Duplicate_BarButtonItem.Id = 0
        Me.SQL_Duplicate_BarButtonItem.ImageOptions.Image = CType(resources.GetObject("SQL_Duplicate_BarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.SQL_Duplicate_BarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("SQL_Duplicate_BarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.SQL_Duplicate_BarButtonItem.Name = "SQL_Duplicate_BarButtonItem"
        '
        'SQL_AddToPosition_BarButtonItem
        '
        Me.SQL_AddToPosition_BarButtonItem.Caption = "Add new SQL Parameter to current position"
        Me.SQL_AddToPosition_BarButtonItem.Id = 1
        Me.SQL_AddToPosition_BarButtonItem.ImageOptions.Image = CType(resources.GetObject("SQL_AddToPosition_BarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.SQL_AddToPosition_BarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("SQL_AddToPosition_BarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.SQL_AddToPosition_BarButtonItem.Name = "SQL_AddToPosition_BarButtonItem"
        '
        'SQL_DuplicateCurrentPosition_BarButtonItem
        '
        Me.SQL_DuplicateCurrentPosition_BarButtonItem.Caption = "Duplicate current SQL Parameter (in the current Position)"
        Me.SQL_DuplicateCurrentPosition_BarButtonItem.Id = 2
        Me.SQL_DuplicateCurrentPosition_BarButtonItem.ImageOptions.Image = CType(resources.GetObject("SQL_DuplicateCurrentPosition_BarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.SQL_DuplicateCurrentPosition_BarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("SQL_DuplicateCurrentPosition_BarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.SQL_DuplicateCurrentPosition_BarButtonItem.Name = "SQL_DuplicateCurrentPosition_BarButtonItem"
        '
        'SQL_DuplicateNextPosition_BarButtonItem
        '
        Me.SQL_DuplicateNextPosition_BarButtonItem.Caption = "Duplicate current SQL Parameter (in the next Position)"
        Me.SQL_DuplicateNextPosition_BarButtonItem.Id = 3
        Me.SQL_DuplicateNextPosition_BarButtonItem.ImageOptions.Image = CType(resources.GetObject("SQL_DuplicateNextPosition_BarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.SQL_DuplicateNextPosition_BarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("SQL_DuplicateNextPosition_BarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.SQL_DuplicateNextPosition_BarButtonItem.Name = "SQL_DuplicateNextPosition_BarButtonItem"
        '
        'bbiExportCurrentSqlParameter
        '
        Me.bbiExportCurrentSqlParameter.Caption = "Export current SQL Parameter"
        Me.bbiExportCurrentSqlParameter.Id = 4
        Me.bbiExportCurrentSqlParameter.ImageOptions.Image = CType(resources.GetObject("bbiExportCurrentSqlParameter.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiExportCurrentSqlParameter.ImageOptions.LargeImage = CType(resources.GetObject("bbiExportCurrentSqlParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiExportCurrentSqlParameter.Name = "bbiExportCurrentSqlParameter"
        '
        'SQL_Parameter_Details_Second_GridView
        '
        Me.SQL_Parameter_Details_Second_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Details_Second_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Details_Second_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SQL_Parameter_Details_Second_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SQL_Parameter_Details_Second_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SQL_Parameter_Details_Second_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SQL_Parameter_Details_Second_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SQL_Parameter_Details_Second_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn32, Me.GridColumn33, Me.colId_SQL_Parameters_Details_3})
        Me.SQL_Parameter_Details_Second_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SQL_Parameter_Details_Second_GridView.GridControl = Me.GridControl3
        Me.SQL_Parameter_Details_Second_GridView.Name = "SQL_Parameter_Details_Second_GridView"
        Me.SQL_Parameter_Details_Second_GridView.NewItemRowText = "Add new SQL Parameter Command"
        Me.SQL_Parameter_Details_Second_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_Second_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_Second_GridView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.SQL_Parameter_Details_Second_GridView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.SQL_Parameter_Details_Second_GridView.OptionsDetail.AutoZoomDetail = True
        Me.SQL_Parameter_Details_Second_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SQL_Parameter_Details_Second_GridView.OptionsFind.AlwaysVisible = True
        Me.SQL_Parameter_Details_Second_GridView.OptionsSelection.MultiSelect = True
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.ColumnAutoWidth = False
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.ShowAutoFilterRow = True
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SQL_Parameter_Details_Second_GridView.OptionsView.ShowGroupPanel = False
        Me.SQL_Parameter_Details_Second_GridView.ViewCaption = "SQL Parameter Details"
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SQL Name 1"
        Me.GridColumn2.FieldName = "SQL_Name_1"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 558
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "SQL Name 2"
        Me.GridColumn3.FieldName = "SQL_Name_2"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Width = 201
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "SQL Name 3"
        Me.GridColumn4.FieldName = "SQL_Name_3"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Width = 193
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "SQL Name 4"
        Me.GridColumn5.FieldName = "SQL_Name_4"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Width = 198
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Float 1"
        Me.GridColumn6.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn6.FieldName = "SQL_Float_1"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 95
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Float 2"
        Me.GridColumn7.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn7.FieldName = "SQL_Float_2"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Width = 74
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Float 3"
        Me.GridColumn8.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn8.FieldName = "SQL_Float_3"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Width = 74
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Float 4"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn9.FieldName = "SQL_Float_4"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Width = 72
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "SQL Command 1"
        Me.GridColumn10.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn10.FieldName = "SQL_Command_1"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        Me.GridColumn10.Width = 97
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "SQL Command 2"
        Me.GridColumn11.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn11.FieldName = "SQL_Command_2"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Width = 103
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "SQL Command 3"
        Me.GridColumn12.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn12.FieldName = "SQL_Command_3"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Width = 108
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "SQL Command 4"
        Me.GridColumn13.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn13.FieldName = "SQL_Command_4"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Width = 110
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Date 1"
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn14.DisplayFormat.FormatString = "d"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn14.FieldName = "SQL_Date1"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 101
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Date 2"
        Me.GridColumn32.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn32.DisplayFormat.FormatString = "d"
        Me.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn32.FieldName = "SQL_Date2"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 5
        Me.GridColumn32.Width = 99
        '
        'GridColumn33
        '
        Me.GridColumn33.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.GridColumn33.FieldName = "Status"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 3
        Me.GridColumn33.Width = 115
        '
        'colId_SQL_Parameters_Details_3
        '
        Me.colId_SQL_Parameters_Details_3.Caption = "Id_SQL_Parameters_Details"
        Me.colId_SQL_Parameters_Details_3.FieldName = "Id_SQL_Parameters_Details"
        Me.colId_SQL_Parameters_Details_3.Name = "colId_SQL_Parameters_Details_3"
        Me.colId_SQL_Parameters_Details_3.OptionsColumn.ReadOnly = True
        Me.colId_SQL_Parameters_Details_3.Width = 70
        '
        'SQL_Parameter_Details_Third_GridView
        '
        Me.SQL_Parameter_Details_Third_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Details_Third_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SQL_Parameter_Details_Third_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SQL_Parameter_Details_Third_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SQL_Parameter_Details_Third_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SQL_Parameter_Details_Third_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SQL_Parameter_Details_Third_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SQL_Parameter_Details_Third_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.colId_SQL_Parameters_Details_4})
        Me.SQL_Parameter_Details_Third_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SQL_Parameter_Details_Third_GridView.GridControl = Me.GridControl3
        Me.SQL_Parameter_Details_Third_GridView.Name = "SQL_Parameter_Details_Third_GridView"
        Me.SQL_Parameter_Details_Third_GridView.NewItemRowText = "Add new SQL Parameter Command"
        Me.SQL_Parameter_Details_Third_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_Third_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_Third_GridView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.SQL_Parameter_Details_Third_GridView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.SQL_Parameter_Details_Third_GridView.OptionsDetail.AutoZoomDetail = True
        Me.SQL_Parameter_Details_Third_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SQL_Parameter_Details_Third_GridView.OptionsFind.AlwaysVisible = True
        Me.SQL_Parameter_Details_Third_GridView.OptionsSelection.MultiSelect = True
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.ColumnAutoWidth = False
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.ShowAutoFilterRow = True
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SQL_Parameter_Details_Third_GridView.OptionsView.ShowGroupPanel = False
        Me.SQL_Parameter_Details_Third_GridView.ViewCaption = "SQL Parameter Details"
        '
        'GridColumn15
        '
        Me.GridColumn15.FieldName = "ID"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "SQL Name 1"
        Me.GridColumn16.FieldName = "SQL_Name_1"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        Me.GridColumn16.Width = 554
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "SQL Name 2"
        Me.GridColumn17.FieldName = "SQL_Name_2"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Width = 201
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "SQL Name 3"
        Me.GridColumn18.FieldName = "SQL_Name_3"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 193
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "SQL Name 4"
        Me.GridColumn19.FieldName = "SQL_Name_4"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Width = 198
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Float 1"
        Me.GridColumn20.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn20.FieldName = "SQL_Float_1"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 0
        Me.GridColumn20.Width = 95
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Float 2"
        Me.GridColumn21.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn21.FieldName = "SQL_Float_2"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Width = 74
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Float 3"
        Me.GridColumn22.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn22.FieldName = "SQL_Float_3"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Width = 74
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Float 4"
        Me.GridColumn23.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn23.FieldName = "SQL_Float_4"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Width = 72
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "SQL Command 1"
        Me.GridColumn24.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn24.FieldName = "SQL_Command_1"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 2
        Me.GridColumn24.Width = 97
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "SQL Command 2"
        Me.GridColumn25.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn25.FieldName = "SQL_Command_2"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Width = 103
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "SQL Command 3"
        Me.GridColumn26.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn26.FieldName = "SQL_Command_3"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Width = 108
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "SQL Command 4"
        Me.GridColumn27.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn27.FieldName = "SQL_Command_4"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Width = 110
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Date 1"
        Me.GridColumn28.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn28.DisplayFormat.FormatString = "d"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn28.FieldName = "SQL_Date1"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 4
        Me.GridColumn28.Width = 101
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Date 2"
        Me.GridColumn29.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn29.DisplayFormat.FormatString = "d"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn29.FieldName = "SQL_Date2"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 5
        Me.GridColumn29.Width = 99
        '
        'GridColumn30
        '
        Me.GridColumn30.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.GridColumn30.FieldName = "Status"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 3
        Me.GridColumn30.Width = 115
        '
        'colId_SQL_Parameters_Details_4
        '
        Me.colId_SQL_Parameters_Details_4.Caption = "Id_SQL_Parameters_Details"
        Me.colId_SQL_Parameters_Details_4.FieldName = "Id_SQL_Parameters_Details"
        Me.colId_SQL_Parameters_Details_4.Name = "colId_SQL_Parameters_Details_4"
        Me.colId_SQL_Parameters_Details_4.OptionsColumn.ReadOnly = True
        Me.colId_SQL_Parameters_Details_4.Width = 70
        '
        'SQL_PARAMETERTableAdapter
        '
        Me.SQL_PARAMETERTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_TABLE_COLUMNSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CLIENT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.CURRENT_USERSTableAdapter = Nothing
        Me.TableAdapterManager.FILES_IMPORTTableAdapter = Nothing
        Me.TableAdapterManager.IMPORT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.MANUAL_IMPORTSTableAdapter = Nothing
        Me.TableAdapterManager.OCBS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.ODAS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILS_SECONDTableAdapter = Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter
        Me.TableAdapterManager.SQL_PARAMETER_DETAILS_THIRDTableAdapter = Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter
        Me.TableAdapterManager.SQL_PARAMETER_DETAILSTableAdapter = Me.SQL_PARAMETER_DETAILSTableAdapter
        Me.TableAdapterManager.SQL_PARAMETERTableAdapter = Me.SQL_PARAMETERTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'SQL_PARAMETER_DETAILS_SECONDTableAdapter
        '
        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.ClearBeforeFill = True
        '
        'SQL_PARAMETER_DETAILS_THIRDTableAdapter
        '
        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.ClearBeforeFill = True
        '
        'SQL_PARAMETER_DETAILSTableAdapter
        '
        Me.SQL_PARAMETER_DETAILSTableAdapter.ClearBeforeFill = True
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl3
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl1
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Location = New System.Drawing.Point(36, 57)
        Me.GridControl1.MainView = Me.SQL_Parameter_ALL_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ALL_MemoExEdit, Me.ALL_PopupContainerEdit, Me.ALL_STATUS_ImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1362, 367)
        Me.GridControl1.TabIndex = 26
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SQL_Parameter_ALL_GridView})
        '
        'SQL_Parameter_ALL_GridView
        '
        Me.SQL_Parameter_ALL_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SQL_Parameter_ALL_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SQL_Parameter_ALL_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SQL_Parameter_ALL_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SQL_Parameter_ALL_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SQL_Parameter_ALL_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SQL_Parameter_ALL_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SQL_Parameter_ALL_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn31, Me.GridColumn34, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69, Me.GridColumn70, Me.GridColumn71, Me.GridColumn72, Me.GridColumn73, Me.GridColumn74, Me.GridColumn75, Me.GridColumn76, Me.GridColumn77, Me.GridColumn78, Me.GridColumn79, Me.GridColumn80, Me.GridColumn81, Me.GridColumn82, Me.GridColumn83, Me.GridColumn84, Me.GridColumn85, Me.GridColumn86, Me.GridColumn87, Me.GridColumn88, Me.GridColumn89})
        Me.SQL_Parameter_ALL_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SQL_Parameter_ALL_GridView.GridControl = Me.GridControl1
        Me.SQL_Parameter_ALL_GridView.Name = "SQL_Parameter_ALL_GridView"
        Me.SQL_Parameter_ALL_GridView.NewItemRowText = "Add new SQL Parameter Command"
        Me.SQL_Parameter_ALL_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SQL_Parameter_ALL_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SQL_Parameter_ALL_GridView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.SQL_Parameter_ALL_GridView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.SQL_Parameter_ALL_GridView.OptionsDetail.AutoZoomDetail = True
        Me.SQL_Parameter_ALL_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SQL_Parameter_ALL_GridView.OptionsFind.AlwaysVisible = True
        Me.SQL_Parameter_ALL_GridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.SQL_Parameter_ALL_GridView.OptionsView.ColumnAutoWidth = False
        Me.SQL_Parameter_ALL_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SQL_Parameter_ALL_GridView.OptionsView.ShowAutoFilterRow = True
        Me.SQL_Parameter_ALL_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SQL_Parameter_ALL_GridView.OptionsView.ShowGroupPanel = False
        Me.SQL_Parameter_ALL_GridView.ViewCaption = "SQL Parameter Details"
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "ID-SQL_PARAMETER"
        Me.GridColumn35.FieldName = "ID-SQL_PARAMETER"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.ReadOnly = True
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 48
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "SQL_Parameter_Name-SQL_PARAMETER"
        Me.GridColumn36.FieldName = "SQL_Parameter_Name-SQL_PARAMETER"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.ReadOnly = True
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 1
        Me.GridColumn36.Width = 191
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "SQL_Parameter_Info-SQL_PARAMETER"
        Me.GridColumn37.FieldName = "SQL_Parameter_Info-SQL_PARAMETER"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.ReadOnly = True
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 2
        Me.GridColumn37.Width = 201
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "SQL_Parameter_Status-SQL_PARAMETER"
        Me.GridColumn38.ColumnEdit = Me.ALL_STATUS_ImageComboBox
        Me.GridColumn38.FieldName = "SQL_Parameter_Status-SQL_PARAMETER"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsColumn.ReadOnly = True
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 49
        Me.GridColumn38.Width = 193
        '
        'ALL_STATUS_ImageComboBox
        '
        Me.ALL_STATUS_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ALL_STATUS_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ALL_STATUS_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ALL_STATUS_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ALL_STATUS_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ALL_STATUS_ImageComboBox.AutoHeight = False
        Me.ALL_STATUS_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ALL_STATUS_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEACTIVATED", "N", 6)})
        Me.ALL_STATUS_ImageComboBox.Name = "ALL_STATUS_ImageComboBox"
        Me.ALL_STATUS_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "SQL_Command_General-SQL_PARAMETER"
        Me.GridColumn39.ColumnEdit = Me.ALL_MemoExEdit
        Me.GridColumn39.FieldName = "SQL_Command_General-SQL_PARAMETER"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.ReadOnly = True
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 50
        Me.GridColumn39.Width = 198
        '
        'ALL_MemoExEdit
        '
        Me.ALL_MemoExEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ALL_MemoExEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ALL_MemoExEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ALL_MemoExEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ALL_MemoExEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ALL_MemoExEdit.AutoHeight = False
        Me.ALL_MemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ALL_MemoExEdit.Name = "ALL_MemoExEdit"
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "SQL_Float-SQL_PARAMETER"
        Me.GridColumn40.FieldName = "SQL_Float-SQL_PARAMETER"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.ReadOnly = True
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 0
        Me.GridColumn40.Width = 145
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "ID-SQL_PARAMETER_DETAILS"
        Me.GridColumn41.FieldName = "ID-SQL_PARAMETER_DETAILS"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.ReadOnly = True
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 51
        Me.GridColumn41.Width = 74
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "SQL_Name_1-SQL_PARAMETER_DETAILS"
        Me.GridColumn42.FieldName = "SQL_Name_1-SQL_PARAMETER_DETAILS"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.ReadOnly = True
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 52
        Me.GridColumn42.Width = 74
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "SQL_Name_2-SQL_PARAMETER_DETAILS"
        Me.GridColumn43.FieldName = "SQL_Name_2-SQL_PARAMETER_DETAILS"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.ReadOnly = True
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 53
        Me.GridColumn43.Width = 72
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "SQL_Name_3-SQL_PARAMETER_DETAILS"
        Me.GridColumn44.FieldName = "SQL_Name_3-SQL_PARAMETER_DETAILS"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.ReadOnly = True
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 4
        Me.GridColumn44.Width = 97
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "SQL_Name_4-SQL_PARAMETER_DETAILS"
        Me.GridColumn45.FieldName = "SQL_Name_4-SQL_PARAMETER_DETAILS"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.ReadOnly = True
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 5
        Me.GridColumn45.Width = 103
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "SQL_Float_1-SQL_PARAMETER_DETAILS"
        Me.GridColumn46.FieldName = "SQL_Float_1-SQL_PARAMETER_DETAILS"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.ReadOnly = True
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 54
        Me.GridColumn46.Width = 108
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "SQL_Float_2-SQL_PARAMETER_DETAILS"
        Me.GridColumn47.FieldName = "SQL_Float_2-SQL_PARAMETER_DETAILS"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.ReadOnly = True
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 55
        Me.GridColumn47.Width = 110
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "SQL_Float_3-SQL_PARAMETER_DETAILS"
        Me.GridColumn48.DisplayFormat.FormatString = "d"
        Me.GridColumn48.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn48.FieldName = "SQL_Float_3-SQL_PARAMETER_DETAILS"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.ReadOnly = True
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 6
        Me.GridColumn48.Width = 101
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "SQL_Float_4-SQL_PARAMETER_DETAILS"
        Me.GridColumn49.DisplayFormat.FormatString = "d"
        Me.GridColumn49.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn49.FieldName = "SQL_Float_4-SQL_PARAMETER_DETAILS"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.ReadOnly = True
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 7
        Me.GridColumn49.Width = 99
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "SQL_Command_1-SQL_PARAMETER_DETAILS"
        Me.GridColumn50.FieldName = "SQL_Command_1-SQL_PARAMETER_DETAILS"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.ReadOnly = True
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 3
        Me.GridColumn50.Width = 196
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "SQL_Command_2-SQL_PARAMETER_DETAILS"
        Me.GridColumn51.FieldName = "SQL_Command_2-SQL_PARAMETER_DETAILS"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.ReadOnly = True
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 56
        Me.GridColumn51.Width = 70
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "GridColumn31"
        Me.GridColumn31.FieldName = "SQL_Command_3-SQL_PARAMETER_DETAILS"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 8
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "GridColumn34"
        Me.GridColumn34.FieldName = "SQL_Command_4-SQL_PARAMETER_DETAILS"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 9
        '
        'GridColumn52
        '
        Me.GridColumn52.Caption = "GridColumn52"
        Me.GridColumn52.FieldName = "SQL_Date1-SQL_PARAMETER_DETAILS"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.OptionsColumn.ReadOnly = True
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 10
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "GridColumn53"
        Me.GridColumn53.FieldName = "SQL_Date2-SQL_PARAMETER_DETAILS"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.ReadOnly = True
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 11
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "GridColumn54"
        Me.GridColumn54.FieldName = "Status-SQL_PARAMETER_DETAILS"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.OptionsColumn.ReadOnly = True
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 12
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "GridColumn55"
        Me.GridColumn55.FieldName = "Id_SQL_Parameters-SQL_PARAMETER_DETAILS"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.OptionsColumn.ReadOnly = True
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 13
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "GridColumn56"
        Me.GridColumn56.FieldName = "ID-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.OptionsColumn.ReadOnly = True
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 14
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "GridColumn57"
        Me.GridColumn57.FieldName = "SQL_Name_1-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.OptionsColumn.ReadOnly = True
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 15
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "GridColumn58"
        Me.GridColumn58.FieldName = "SQL_Name_2-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.OptionsColumn.ReadOnly = True
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 16
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "GridColumn59"
        Me.GridColumn59.FieldName = "SQL_Name_3-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.OptionsColumn.ReadOnly = True
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 17
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "GridColumn60"
        Me.GridColumn60.FieldName = "SQL_Name_4-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.OptionsColumn.ReadOnly = True
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 18
        '
        'GridColumn61
        '
        Me.GridColumn61.Caption = "GridColumn61"
        Me.GridColumn61.FieldName = "SQL_Float_1-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.OptionsColumn.ReadOnly = True
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 19
        '
        'GridColumn62
        '
        Me.GridColumn62.Caption = "GridColumn62"
        Me.GridColumn62.FieldName = "SQL_Float_2-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.OptionsColumn.ReadOnly = True
        Me.GridColumn62.Visible = True
        Me.GridColumn62.VisibleIndex = 20
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "GridColumn63"
        Me.GridColumn63.FieldName = "SQL_Float_3-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.OptionsColumn.ReadOnly = True
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 21
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "GridColumn64"
        Me.GridColumn64.FieldName = "SQL_Float_4-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.OptionsColumn.ReadOnly = True
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 22
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "GridColumn65"
        Me.GridColumn65.FieldName = "SQL_Command_1-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.OptionsColumn.ReadOnly = True
        Me.GridColumn65.Visible = True
        Me.GridColumn65.VisibleIndex = 23
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "GridColumn66"
        Me.GridColumn66.FieldName = "SQL_Command_2-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.OptionsColumn.ReadOnly = True
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 24
        '
        'GridColumn67
        '
        Me.GridColumn67.Caption = "GridColumn67"
        Me.GridColumn67.FieldName = "SQL_Command_3-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.OptionsColumn.ReadOnly = True
        Me.GridColumn67.Visible = True
        Me.GridColumn67.VisibleIndex = 25
        '
        'GridColumn68
        '
        Me.GridColumn68.Caption = "GridColumn68"
        Me.GridColumn68.FieldName = "SQL_Command_4SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.OptionsColumn.ReadOnly = True
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 26
        '
        'GridColumn69
        '
        Me.GridColumn69.Caption = "GridColumn69"
        Me.GridColumn69.FieldName = "SQL_Date1-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.OptionsColumn.ReadOnly = True
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 27
        '
        'GridColumn70
        '
        Me.GridColumn70.Caption = "GridColumn70"
        Me.GridColumn70.FieldName = "SQL_Date2-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.OptionsColumn.ReadOnly = True
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 28
        '
        'GridColumn71
        '
        Me.GridColumn71.Caption = "GridColumn71"
        Me.GridColumn71.FieldName = "Status-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn71.Name = "GridColumn71"
        Me.GridColumn71.OptionsColumn.ReadOnly = True
        Me.GridColumn71.Visible = True
        Me.GridColumn71.VisibleIndex = 29
        '
        'GridColumn72
        '
        Me.GridColumn72.Caption = "GridColumn72"
        Me.GridColumn72.FieldName = "Id_SQL_Parameters_Details-SQL_PARAMETER_DETAILS_SECOND"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.OptionsColumn.ReadOnly = True
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 30
        '
        'GridColumn73
        '
        Me.GridColumn73.Caption = "GridColumn73"
        Me.GridColumn73.FieldName = "ID-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn73.Name = "GridColumn73"
        Me.GridColumn73.OptionsColumn.ReadOnly = True
        Me.GridColumn73.Visible = True
        Me.GridColumn73.VisibleIndex = 31
        '
        'GridColumn74
        '
        Me.GridColumn74.Caption = "GridColumn74"
        Me.GridColumn74.FieldName = "SQL_Name_1-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn74.Name = "GridColumn74"
        Me.GridColumn74.OptionsColumn.ReadOnly = True
        Me.GridColumn74.Visible = True
        Me.GridColumn74.VisibleIndex = 32
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "GridColumn75"
        Me.GridColumn75.FieldName = "SQL_Name_2-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn75.Name = "GridColumn75"
        Me.GridColumn75.OptionsColumn.ReadOnly = True
        Me.GridColumn75.Visible = True
        Me.GridColumn75.VisibleIndex = 33
        '
        'GridColumn76
        '
        Me.GridColumn76.Caption = "GridColumn76"
        Me.GridColumn76.FieldName = "SQL_Name_3-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.OptionsColumn.ReadOnly = True
        Me.GridColumn76.Visible = True
        Me.GridColumn76.VisibleIndex = 34
        '
        'GridColumn77
        '
        Me.GridColumn77.Caption = "GridColumn77"
        Me.GridColumn77.FieldName = "SQL_Name_4-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn77.Name = "GridColumn77"
        Me.GridColumn77.OptionsColumn.ReadOnly = True
        Me.GridColumn77.Visible = True
        Me.GridColumn77.VisibleIndex = 35
        '
        'GridColumn78
        '
        Me.GridColumn78.Caption = "GridColumn78"
        Me.GridColumn78.FieldName = "SQL_Float_1-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn78.Name = "GridColumn78"
        Me.GridColumn78.OptionsColumn.ReadOnly = True
        Me.GridColumn78.Visible = True
        Me.GridColumn78.VisibleIndex = 36
        '
        'GridColumn79
        '
        Me.GridColumn79.Caption = "GridColumn79"
        Me.GridColumn79.FieldName = "SQL_Float_2-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn79.Name = "GridColumn79"
        Me.GridColumn79.OptionsColumn.ReadOnly = True
        Me.GridColumn79.Visible = True
        Me.GridColumn79.VisibleIndex = 37
        '
        'GridColumn80
        '
        Me.GridColumn80.Caption = "GridColumn80"
        Me.GridColumn80.FieldName = "SQL_Float_3-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn80.Name = "GridColumn80"
        Me.GridColumn80.OptionsColumn.ReadOnly = True
        Me.GridColumn80.Visible = True
        Me.GridColumn80.VisibleIndex = 38
        '
        'GridColumn81
        '
        Me.GridColumn81.Caption = "GridColumn81"
        Me.GridColumn81.FieldName = "SQL_Float_4-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn81.Name = "GridColumn81"
        Me.GridColumn81.OptionsColumn.ReadOnly = True
        Me.GridColumn81.Visible = True
        Me.GridColumn81.VisibleIndex = 39
        '
        'GridColumn82
        '
        Me.GridColumn82.Caption = "GridColumn82"
        Me.GridColumn82.FieldName = "SQL_Command_1-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn82.Name = "GridColumn82"
        Me.GridColumn82.OptionsColumn.ReadOnly = True
        Me.GridColumn82.Visible = True
        Me.GridColumn82.VisibleIndex = 40
        '
        'GridColumn83
        '
        Me.GridColumn83.Caption = "GridColumn83"
        Me.GridColumn83.FieldName = "SQL_Command_2-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn83.Name = "GridColumn83"
        Me.GridColumn83.OptionsColumn.ReadOnly = True
        Me.GridColumn83.Visible = True
        Me.GridColumn83.VisibleIndex = 41
        '
        'GridColumn84
        '
        Me.GridColumn84.Caption = "GridColumn84"
        Me.GridColumn84.FieldName = "SQL_Command_3-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn84.Name = "GridColumn84"
        Me.GridColumn84.OptionsColumn.ReadOnly = True
        Me.GridColumn84.Visible = True
        Me.GridColumn84.VisibleIndex = 42
        '
        'GridColumn85
        '
        Me.GridColumn85.Caption = "GridColumn85"
        Me.GridColumn85.FieldName = "SQL_Command_4-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn85.Name = "GridColumn85"
        Me.GridColumn85.OptionsColumn.ReadOnly = True
        Me.GridColumn85.Visible = True
        Me.GridColumn85.VisibleIndex = 43
        '
        'GridColumn86
        '
        Me.GridColumn86.Caption = "GridColumn86"
        Me.GridColumn86.FieldName = "SQL_Date1-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn86.Name = "GridColumn86"
        Me.GridColumn86.OptionsColumn.ReadOnly = True
        Me.GridColumn86.Visible = True
        Me.GridColumn86.VisibleIndex = 44
        '
        'GridColumn87
        '
        Me.GridColumn87.Caption = "GridColumn87"
        Me.GridColumn87.FieldName = "SQL_Date2-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn87.Name = "GridColumn87"
        Me.GridColumn87.OptionsColumn.ReadOnly = True
        Me.GridColumn87.Visible = True
        Me.GridColumn87.VisibleIndex = 45
        '
        'GridColumn88
        '
        Me.GridColumn88.Caption = "GridColumn88"
        Me.GridColumn88.FieldName = "Status-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn88.Name = "GridColumn88"
        Me.GridColumn88.OptionsColumn.ReadOnly = True
        Me.GridColumn88.Visible = True
        Me.GridColumn88.VisibleIndex = 46
        '
        'GridColumn89
        '
        Me.GridColumn89.Caption = "GridColumn89"
        Me.GridColumn89.FieldName = "Id_SQL_Parameters_Details-SQL_PARAMETER_DETAILS_THIRD"
        Me.GridColumn89.Name = "GridColumn89"
        Me.GridColumn89.OptionsColumn.ReadOnly = True
        Me.GridColumn89.Visible = True
        Me.GridColumn89.VisibleIndex = 47
        '
        'ALL_PopupContainerEdit
        '
        Me.ALL_PopupContainerEdit.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ALL_PopupContainerEdit.Appearance.Options.UseFont = True
        Me.ALL_PopupContainerEdit.AutoHeight = False
        Me.ALL_PopupContainerEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ALL_PopupContainerEdit.Name = "ALL_PopupContainerEdit"
        Me.ALL_PopupContainerEdit.PopupControl = Me.PopupContainerControl1
        '
        'PopupContainerControl1
        '
        Me.PopupContainerControl1.Controls.Add(Me.RichEditControl2)
        Me.PopupContainerControl1.Location = New System.Drawing.Point(1030, 45)
        Me.PopupContainerControl1.Name = "PopupContainerControl1"
        Me.PopupContainerControl1.Size = New System.Drawing.Size(162, 38)
        Me.PopupContainerControl1.TabIndex = 25
        '
        'RichEditControl2
        '
        Me.RichEditControl2.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.RichEditControl2.Appearance.Text.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichEditControl2.Appearance.Text.Options.UseFont = True
        Me.RichEditControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichEditControl2.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.RichEditControl2.Location = New System.Drawing.Point(0, 0)
        Me.RichEditControl2.MenuManager = Me.BarManager1
        Me.RichEditControl2.Name = "RichEditControl2"
        Me.RichEditControl2.ReadOnly = True
        Me.RichEditControl2.Size = New System.Drawing.Size(162, 38)
        Me.RichEditControl2.TabIndex = 2
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.GridControl1)
        Me.LayoutControl3.Controls.Add(Me.GridControl3)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 641, 547)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1434, 460)
        Me.LayoutControl3.TabIndex = 3
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup6})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1434, 460)
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1414, 440)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Aqua
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup1
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1390, 416)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1366, 371)
        Me.LayoutControlGroup1.Text = "SQL Parameters"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridControl3
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1366, 371)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "item0"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1366, 371)
        Me.LayoutControlGroup3.Text = "All SQL Parameters (Display)"
        Me.LayoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1366, 371)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'SQL_PARAMETER_DETAILSBindingSource
        '
        Me.SQL_PARAMETER_DETAILSBindingSource.DataMember = "SQL_PARAMETER_DETAILS"
        Me.SQL_PARAMETER_DETAILSBindingSource.DataSource = Me.EDPDataSet
        '
        'SQL_PARAMETER_DETAILS_SECONDBindingSource
        '
        Me.SQL_PARAMETER_DETAILS_SECONDBindingSource.DataMember = "FK_SQL_PARAMETER_DETAILS_SECOND_SQL_PARAMETER_DETAILS"
        Me.SQL_PARAMETER_DETAILS_SECONDBindingSource.DataSource = Me.SQL_PARAMETER_DETAILSBindingSource
        '
        'SQL_PARAMETER_DETAILS_THIRDBindingSource
        '
        Me.SQL_PARAMETER_DETAILS_THIRDBindingSource.DataMember = "SQL_PARAMETER_DETAILS_THIRD"
        Me.SQL_PARAMETER_DETAILS_THIRDBindingSource.DataSource = Me.EDPDataSet
        '
        'SqlParameterGridviewPopupMenu
        '
        Me.SqlParameterGridviewPopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_DuplicateCurrentPosition_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_Duplicate_BarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_DuplicateNextPosition_BarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_AddToPosition_BarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiExportCurrentSqlParameter, True)})
        Me.SqlParameterGridviewPopupMenu.Manager = Me.BarManager1
        Me.SqlParameterGridviewPopupMenu.Name = "SqlParameterGridviewPopupMenu"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.bbiReload, Me.bbiSave, Me.bbiDelete, Me.bbiPrintPreview, Me.FindAndReplaceText_bbi, Me.bbiClose, Me.ImportSqlFromExcelFile_bbi})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 8
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1434, 94)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'bbiReload
        '
        Me.bbiReload.Caption = "Reload"
        Me.bbiReload.Id = 1
        Me.bbiReload.ImageOptions.Image = CType(resources.GetObject("bbiReload.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiReload.ImageOptions.LargeImage = CType(resources.GetObject("bbiReload.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiReload.Name = "bbiReload"
        '
        'bbiSave
        '
        Me.bbiSave.Caption = "Save changes"
        Me.bbiSave.Id = 2
        Me.bbiSave.ImageOptions.Image = CType(resources.GetObject("bbiSave.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiSave.ImageOptions.LargeImage = CType(resources.GetObject("bbiSave.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiSave.Name = "bbiSave"
        '
        'bbiDelete
        '
        Me.bbiDelete.Caption = "Delete"
        Me.bbiDelete.Id = 3
        Me.bbiDelete.ImageOptions.Image = CType(resources.GetObject("bbiDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiDelete.ImageOptions.LargeImage = CType(resources.GetObject("bbiDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiDelete.Name = "bbiDelete"
        '
        'bbiPrintPreview
        '
        Me.bbiPrintPreview.Caption = "Print Preview"
        Me.bbiPrintPreview.Id = 4
        Me.bbiPrintPreview.ImageOptions.Image = CType(resources.GetObject("bbiPrintPreview.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiPrintPreview.ImageOptions.LargeImage = CType(resources.GetObject("bbiPrintPreview.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiPrintPreview.Name = "bbiPrintPreview"
        '
        'FindAndReplaceText_bbi
        '
        Me.FindAndReplaceText_bbi.Caption = "Find and replace"
        Me.FindAndReplaceText_bbi.Id = 5
        Me.FindAndReplaceText_bbi.ImageOptions.Image = CType(resources.GetObject("FindAndReplaceText_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.FindAndReplaceText_bbi.ImageOptions.LargeImage = CType(resources.GetObject("FindAndReplaceText_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.FindAndReplaceText_bbi.Name = "FindAndReplaceText_bbi"
        '
        'bbiClose
        '
        Me.bbiClose.Caption = "Close"
        Me.bbiClose.Id = 6
        Me.bbiClose.ImageOptions.Image = CType(resources.GetObject("bbiClose.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiClose.ImageOptions.LargeImage = CType(resources.GetObject("bbiClose.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiClose.Name = "bbiClose"
        '
        'ImportSqlFromExcelFile_bbi
        '
        Me.ImportSqlFromExcelFile_bbi.Caption = "Update SQL parameters from File"
        Me.ImportSqlFromExcelFile_bbi.Id = 7
        Me.ImportSqlFromExcelFile_bbi.ImageOptions.Image = CType(resources.GetObject("ImportSqlFromExcelFile_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.ImportSqlFromExcelFile_bbi.ImageOptions.LargeImage = CType(resources.GetObject("ImportSqlFromExcelFile_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ImportSqlFromExcelFile_bbi.Name = "ImportSqlFromExcelFile_bbi"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiReload)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiSave, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiDelete, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiPrintPreview, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.FindAndReplaceText_bbi, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.ImportSqlFromExcelFile_bbi, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiClose, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 554)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1434, 22)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'SqlParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1434, 576)
        Me.Controls.Add(Me.PopupContainerControl1)
        Me.Controls.Add(Me.popupContainerControl)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("SqlParameter.IconOptions.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "SqlParameter"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "SQL Procedures Parameter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SQL_Parameter_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_PARAMETERBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_Parameter_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl.ResumeLayout(False)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_Parameter_Details_Second_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_Parameter_Details_Third_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_Parameter_ALL_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALL_STATUS_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALL_MemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALL_PopupContainerEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupContainerControl1.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_PARAMETER_DETAILSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_PARAMETER_DETAILS_SECONDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQL_PARAMETER_DETAILS_THIRDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EDPDataSet As PS_TOOL_DX.EDPDataSet
    Friend WithEvents SQL_PARAMETERBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQL_PARAMETERTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETERTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SQL_Parameter_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Name_1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Name_2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Name_3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Name_4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Float_1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colSQL_Float_2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Float_3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Float_4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Command_1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colSQL_Command_2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Command_3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Command_4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colId_SQL_Parameters As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SQL_Parameter_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Parameter_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colSQL_Parameter_Info As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents SQL_PARAMETER_DETAILSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQL_PARAMETER_DETAILSTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETER_DETAILSTableAdapter
    Friend WithEvents SQL_PARAMETER_DETAILS_SECONDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQL_PARAMETER_DETAILS_SECONDTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.SQL_PARAMETER_DETAILS_SECONDTableAdapter
    Friend WithEvents SQL_Parameter_Details_Second_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSQL_Parameter_Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Date1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colSQL_Date2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQL_Float As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SQL_PARAMETER_DETAILS_THIRDBindingSource As BindingSource
    Friend WithEvents SQL_PARAMETER_DETAILS_THIRDTableAdapter As EDPDataSetTableAdapters.SQL_PARAMETER_DETAILS_THIRDTableAdapter
    Friend WithEvents SQL_Parameter_Details_Third_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PopupContainerEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colId_SQL_Parameters_Details_3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colId_SQL_Parameters_Details_4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SqlParameterGridviewPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SQL_Parameter_ALL_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SQL_Duplicate_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SQL_AddToPosition_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SQL_DuplicateCurrentPosition_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SQL_DuplicateNextPosition_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents bbiReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPrintPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FindAndReplaceText_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents popupContainerControl As DevExpress.XtraEditors.PopupContainerControl
    Private WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
    Private WithEvents PopupContainerControl1 As DevExpress.XtraEditors.PopupContainerControl
    Private WithEvents RichEditControl2 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents ALL_MemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ALL_PopupContainerEdit As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents ALL_STATUS_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn79 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn80 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn81 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn82 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn83 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn84 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn85 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn86 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn87 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn88 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn89 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bbiExportCurrentSqlParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ImportSqlFromExcelFile_bbi As DevExpress.XtraBars.BarButtonItem
End Class
