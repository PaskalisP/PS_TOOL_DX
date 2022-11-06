<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuration))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.DepartmentsParameterView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGSPARAMETERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEPARTMENT_CODERepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colABTEILUNGSPARAMETERSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VALIDRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colABTEILUNGSPARAMETERINFO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colIdABTEILUNGSCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ABTEILUNGENBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.DepartmentsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGSCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ALL_OTHERRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colABTEILUNGSLEITER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGTEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGFAX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGBEMERKUNGEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGEVENTJOURNAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABTEILUNGSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENTUSER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBearbeitungsstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGSCODE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGSNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn4 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGSLEITER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn5 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn6 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn7 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn8 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGBEMERKUNGEN = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn9 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGEVENTJOURNAL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn10 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colABTEILUNGSTATUS = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn11 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCURRENTUSER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn12 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBearbeitungsstatus = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn13 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colIdBANK = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.ParameterView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETER1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETER2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETERSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETERINFO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdABTEILUNGSPARAMETER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNPARAMETER1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNPARAMETER2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.PARAMETER_AllBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Parameter_All_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETER11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETER21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETERSTATUS1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAMETERINFO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdABTEILUNGSPARAMETER1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNPARAMETER11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNPARAMETER21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdABTEILUNGSCODE_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutView2 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn14 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn15 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn16 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn17 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn18 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField6 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn19 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField7 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn20 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField8 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn21 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField9 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn22 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField10 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn23 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField11 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn24 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField12 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn25 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField13 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn26 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField14 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.ABTEILUNGSPARAMETERBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PARAMETERBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ABTEILUNGENTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.ABTEILUNGENTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.ABTEILUNGSPARAMETERTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.ABTEILUNGSPARAMETERTableAdapter()
        Me.PARAMETER_All_TableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.PARAMETER_All_TableAdapter()
        Me.PARAMETERTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.PARAMETERTableAdapter()
        Me.PARAMETERFK00BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colDPARAMETER1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDPARAMETER2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDPARAMETER11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DPARAMETER22 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.DepartmentsParameterView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPARTMENT_CODERepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VALIDRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ABTEILUNGENBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartmentsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALL_OTHERRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGSCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGSNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGSLEITER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGBEMERKUNGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGEVENTJOURNAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colABTEILUNGSTATUS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCURRENTUSER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBearbeitungsstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colIdBANK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParameterView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PARAMETER_AllBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Parameter_All_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ABTEILUNGSPARAMETERBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PARAMETERBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PARAMETERFK00BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DepartmentsParameterView
        '
        Me.DepartmentsParameterView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.DepartmentsParameterView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.DepartmentsParameterView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.DepartmentsParameterView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DepartmentsParameterView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.DepartmentsParameterView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colABTEILUNGSPARAMETERNAME, Me.colABTEILUNGSPARAMETERSTATUS, Me.colABTEILUNGSPARAMETERINFO, Me.colIdABTEILUNGSCODE})
        Me.DepartmentsParameterView.GridControl = Me.GridControl1
        Me.DepartmentsParameterView.Name = "DepartmentsParameterView"
        Me.DepartmentsParameterView.NewItemRowText = "Add New Department Parameter"
        Me.DepartmentsParameterView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DepartmentsParameterView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DepartmentsParameterView.OptionsBehavior.AllowIncrementalSearch = True
        Me.DepartmentsParameterView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.DepartmentsParameterView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.DepartmentsParameterView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.DepartmentsParameterView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.DepartmentsParameterView.OptionsFind.AlwaysVisible = True
        Me.DepartmentsParameterView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.DepartmentsParameterView.OptionsNavigation.AutoFocusNewRow = True
        Me.DepartmentsParameterView.OptionsSelection.MultiSelect = True
        Me.DepartmentsParameterView.OptionsView.ColumnAutoWidth = False
        Me.DepartmentsParameterView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.DepartmentsParameterView.OptionsView.ShowAutoFilterRow = True
        Me.DepartmentsParameterView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colABTEILUNGSPARAMETERNAME, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.DepartmentsParameterView.ViewCaption = "DEPARTMENT PARAMETERS"
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colABTEILUNGSPARAMETERNAME
        '
        Me.colABTEILUNGSPARAMETERNAME.Caption = "DEPARTMENT PARAMETER NAME"
        Me.colABTEILUNGSPARAMETERNAME.ColumnEdit = Me.DEPARTMENT_CODERepositoryItemTextEdit1
        Me.colABTEILUNGSPARAMETERNAME.FieldName = "ABTEILUNGSPARAMETER NAME"
        Me.colABTEILUNGSPARAMETERNAME.Name = "colABTEILUNGSPARAMETERNAME"
        Me.colABTEILUNGSPARAMETERNAME.OptionsColumn.ReadOnly = True
        Me.colABTEILUNGSPARAMETERNAME.Visible = True
        Me.colABTEILUNGSPARAMETERNAME.VisibleIndex = 0
        Me.colABTEILUNGSPARAMETERNAME.Width = 197
        '
        'DEPARTMENT_CODERepositoryItemTextEdit1
        '
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.AutoHeight = False
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DEPARTMENT_CODERepositoryItemTextEdit1.Name = "DEPARTMENT_CODERepositoryItemTextEdit1"
        '
        'colABTEILUNGSPARAMETERSTATUS
        '
        Me.colABTEILUNGSPARAMETERSTATUS.Caption = "DEPARTMENT PARAMETER STATUS"
        Me.colABTEILUNGSPARAMETERSTATUS.ColumnEdit = Me.VALIDRepositoryItemImageComboBox1
        Me.colABTEILUNGSPARAMETERSTATUS.FieldName = "ABTEILUNGSPARAMETER STATUS"
        Me.colABTEILUNGSPARAMETERSTATUS.Name = "colABTEILUNGSPARAMETERSTATUS"
        Me.colABTEILUNGSPARAMETERSTATUS.Visible = True
        Me.colABTEILUNGSPARAMETERSTATUS.VisibleIndex = 1
        Me.colABTEILUNGSPARAMETERSTATUS.Width = 183
        '
        'VALIDRepositoryItemImageComboBox1
        '
        Me.VALIDRepositoryItemImageComboBox1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.VALIDRepositoryItemImageComboBox1.Appearance.Options.UseFont = True
        Me.VALIDRepositoryItemImageComboBox1.Appearance.Options.UseTextOptions = True
        Me.VALIDRepositoryItemImageComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.VALIDRepositoryItemImageComboBox1.AutoHeight = False
        Me.VALIDRepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VALIDRepositoryItemImageComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VALIDRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NON VALID", "N", 5)})
        Me.VALIDRepositoryItemImageComboBox1.Name = "VALIDRepositoryItemImageComboBox1"
        Me.VALIDRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "Valid.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "NonValid.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 3)
        Me.ImageCollection1.Images.SetKeyName(3, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("exporttoxls_16x16.png", "images/export/exporttoxls_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxls_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "exporttoxls_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("edit_16x16.png", "images/edit/edit_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "edit_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("download_16x16.png", "images/actions/download_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/download_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "download_16x16.png")
        '
        'colABTEILUNGSPARAMETERINFO
        '
        Me.colABTEILUNGSPARAMETERINFO.Caption = "DEPARTMENT PARAMETER INFO"
        Me.colABTEILUNGSPARAMETERINFO.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colABTEILUNGSPARAMETERINFO.FieldName = "ABTEILUNGSPARAMETER INFO"
        Me.colABTEILUNGSPARAMETERINFO.Name = "colABTEILUNGSPARAMETERINFO"
        Me.colABTEILUNGSPARAMETERINFO.Visible = True
        Me.colABTEILUNGSPARAMETERINFO.VisibleIndex = 2
        Me.colABTEILUNGSPARAMETERINFO.Width = 175
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        '
        'colIdABTEILUNGSCODE
        '
        Me.colIdABTEILUNGSCODE.Caption = "ID DEPARTMENT CODE"
        Me.colIdABTEILUNGSCODE.FieldName = "IdABTEILUNGSCODE"
        Me.colIdABTEILUNGSCODE.Name = "colIdABTEILUNGSCODE"
        Me.colIdABTEILUNGSCODE.OptionsColumn.ReadOnly = True
        Me.colIdABTEILUNGSCODE.Visible = True
        Me.colIdABTEILUNGSCODE.VisibleIndex = 3
        Me.colIdABTEILUNGSCODE.Width = 126
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.ABTEILUNGENBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.ImageIndex = 3
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.ImageIndex = 5
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.ImageIndex = 10
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 9
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(2, "Print"), New DevExpress.XtraEditors.NavigatorCustomButton(8, "ExportToExcel"), New DevExpress.XtraEditors.NavigatorCustomButton(11, "ImportFromExcel"), New DevExpress.XtraEditors.NavigatorCustomButton(7, "Delete")})
        GridLevelNode1.LevelTemplate = Me.DepartmentsParameterView
        GridLevelNode2.LevelTemplate = Me.ParameterView
        GridLevelNode2.RelationName = "PARAMETER_FK00"
        GridLevelNode1.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        GridLevelNode1.RelationName = "FK_ABTEILUNGSPARAMETER_ABTEILUNGEN"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(24, 46)
        Me.GridControl1.MainView = Me.DepartmentsView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.DEPARTMENT_CODERepositoryItemTextEdit1, Me.ALL_OTHERRepositoryItemTextEdit1, Me.RepositoryItemMemoExEdit1, Me.VALIDRepositoryItemImageComboBox1, Me.RepositoryItemDateEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1482, 611)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DepartmentsView, Me.LayoutView1, Me.ParameterView, Me.DepartmentsParameterView})
        '
        'ABTEILUNGENBindingSource
        '
        Me.ABTEILUNGENBindingSource.DataMember = "ABTEILUNGEN"
        Me.ABTEILUNGENBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DepartmentsView
        '
        Me.DepartmentsView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.DepartmentsView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.DepartmentsView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.DepartmentsView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DepartmentsView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.DepartmentsView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.DepartmentsView.Appearance.GroupRow.Options.UseForeColor = True
        Me.DepartmentsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colABTEILUNGSCODE, Me.colABTEILUNGSNAME, Me.colABTEILUNGSLEITER, Me.colABTEILUNGTEL, Me.colABTEILUNGFAX, Me.GridColumn1, Me.colABTEILUNGBEMERKUNGEN, Me.colABTEILUNGEVENTJOURNAL, Me.colABTEILUNGSTATUS, Me.colCURRENTUSER, Me.colBearbeitungsstatus, Me.colIdBANK})
        Me.DepartmentsView.GridControl = Me.GridControl1
        Me.DepartmentsView.Images = Me.ImageCollection1
        Me.DepartmentsView.Name = "DepartmentsView"
        Me.DepartmentsView.NewItemRowText = "Add new Department"
        Me.DepartmentsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DepartmentsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DepartmentsView.OptionsBehavior.AllowIncrementalSearch = True
        Me.DepartmentsView.OptionsBehavior.AutoExpandAllGroups = True
        Me.DepartmentsView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.DepartmentsView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.DepartmentsView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.DepartmentsView.OptionsFind.AlwaysVisible = True
        Me.DepartmentsView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.DepartmentsView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.DepartmentsView.OptionsNavigation.AutoFocusNewRow = True
        Me.DepartmentsView.OptionsPrint.ExpandAllDetails = True
        Me.DepartmentsView.OptionsPrint.PrintDetails = True
        Me.DepartmentsView.OptionsPrint.PrintFilterInfo = True
        Me.DepartmentsView.OptionsPrint.PrintPreview = True
        Me.DepartmentsView.OptionsSelection.MultiSelect = True
        Me.DepartmentsView.OptionsView.ColumnAutoWidth = False
        Me.DepartmentsView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.DepartmentsView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.DepartmentsView.OptionsView.ShowAutoFilterRow = True
        Me.DepartmentsView.OptionsView.ShowChildrenInGroupPanel = True
        Me.DepartmentsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.DepartmentsView.OptionsView.ShowFooter = True
        Me.DepartmentsView.OptionsView.ShowGroupedColumns = True
        Me.DepartmentsView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colABTEILUNGSCODE, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colABTEILUNGSCODE
        '
        Me.colABTEILUNGSCODE.Caption = "DEPARTMENT CODE"
        Me.colABTEILUNGSCODE.ColumnEdit = Me.DEPARTMENT_CODERepositoryItemTextEdit1
        Me.colABTEILUNGSCODE.FieldName = "ABTEILUNGS CODE"
        Me.colABTEILUNGSCODE.Name = "colABTEILUNGSCODE"
        Me.colABTEILUNGSCODE.OptionsColumn.ReadOnly = True
        Me.colABTEILUNGSCODE.Visible = True
        Me.colABTEILUNGSCODE.VisibleIndex = 0
        Me.colABTEILUNGSCODE.Width = 166
        '
        'colABTEILUNGSNAME
        '
        Me.colABTEILUNGSNAME.Caption = "DEPARTMENT NAME"
        Me.colABTEILUNGSNAME.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colABTEILUNGSNAME.FieldName = "ABTEILUNGS NAME"
        Me.colABTEILUNGSNAME.Name = "colABTEILUNGSNAME"
        Me.colABTEILUNGSNAME.Visible = True
        Me.colABTEILUNGSNAME.VisibleIndex = 1
        Me.colABTEILUNGSNAME.Width = 408
        '
        'ALL_OTHERRepositoryItemTextEdit1
        '
        Me.ALL_OTHERRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ALL_OTHERRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ALL_OTHERRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ALL_OTHERRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.ALL_OTHERRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.ALL_OTHERRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ALL_OTHERRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ALL_OTHERRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ALL_OTHERRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.ALL_OTHERRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.ALL_OTHERRepositoryItemTextEdit1.AutoHeight = False
        Me.ALL_OTHERRepositoryItemTextEdit1.Name = "ALL_OTHERRepositoryItemTextEdit1"
        '
        'colABTEILUNGSLEITER
        '
        Me.colABTEILUNGSLEITER.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colABTEILUNGSLEITER.FieldName = "ABTEILUNGSLEITER"
        Me.colABTEILUNGSLEITER.Name = "colABTEILUNGSLEITER"
        Me.colABTEILUNGSLEITER.OptionsColumn.ShowInCustomizationForm = False
        Me.colABTEILUNGSLEITER.OptionsColumn.ShowInExpressionEditor = False
        Me.colABTEILUNGSLEITER.Width = 173
        '
        'colABTEILUNGTEL
        '
        Me.colABTEILUNGTEL.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colABTEILUNGTEL.FieldName = "ABTEILUNG TEL"
        Me.colABTEILUNGTEL.Name = "colABTEILUNGTEL"
        Me.colABTEILUNGTEL.OptionsColumn.ShowInCustomizationForm = False
        Me.colABTEILUNGTEL.OptionsColumn.ShowInExpressionEditor = False
        Me.colABTEILUNGTEL.Width = 154
        '
        'colABTEILUNGFAX
        '
        Me.colABTEILUNGFAX.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colABTEILUNGFAX.FieldName = "ABTEILUNG FAX"
        Me.colABTEILUNGFAX.Name = "colABTEILUNGFAX"
        Me.colABTEILUNGFAX.OptionsColumn.ShowInCustomizationForm = False
        Me.colABTEILUNGFAX.OptionsColumn.ShowInExpressionEditor = False
        Me.colABTEILUNGFAX.Width = 66
        '
        'GridColumn1
        '
        Me.GridColumn1.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.GridColumn1.FieldName = "ABTEILUNG E-MAIL"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn1.OptionsColumn.ShowInExpressionEditor = False
        Me.GridColumn1.Width = 66
        '
        'colABTEILUNGBEMERKUNGEN
        '
        Me.colABTEILUNGBEMERKUNGEN.Caption = "DEPARTMENT NOTES"
        Me.colABTEILUNGBEMERKUNGEN.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colABTEILUNGBEMERKUNGEN.FieldName = "ABTEILUNG BEMERKUNGEN"
        Me.colABTEILUNGBEMERKUNGEN.Name = "colABTEILUNGBEMERKUNGEN"
        Me.colABTEILUNGBEMERKUNGEN.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell
        Me.colABTEILUNGBEMERKUNGEN.Visible = True
        Me.colABTEILUNGBEMERKUNGEN.VisibleIndex = 3
        Me.colABTEILUNGBEMERKUNGEN.Width = 112
        '
        'colABTEILUNGEVENTJOURNAL
        '
        Me.colABTEILUNGEVENTJOURNAL.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colABTEILUNGEVENTJOURNAL.FieldName = "ABTEILUNG EVENT JOURNAL"
        Me.colABTEILUNGEVENTJOURNAL.Name = "colABTEILUNGEVENTJOURNAL"
        Me.colABTEILUNGEVENTJOURNAL.OptionsColumn.ShowInCustomizationForm = False
        Me.colABTEILUNGEVENTJOURNAL.OptionsColumn.ShowInExpressionEditor = False
        Me.colABTEILUNGEVENTJOURNAL.Width = 97
        '
        'colABTEILUNGSTATUS
        '
        Me.colABTEILUNGSTATUS.AppearanceCell.Options.UseTextOptions = True
        Me.colABTEILUNGSTATUS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colABTEILUNGSTATUS.AppearanceHeader.Options.UseTextOptions = True
        Me.colABTEILUNGSTATUS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colABTEILUNGSTATUS.Caption = "DEPARTMENT STATUS"
        Me.colABTEILUNGSTATUS.ColumnEdit = Me.VALIDRepositoryItemImageComboBox1
        Me.colABTEILUNGSTATUS.FieldName = "ABTEILUNG STATUS"
        Me.colABTEILUNGSTATUS.Name = "colABTEILUNGSTATUS"
        Me.colABTEILUNGSTATUS.Visible = True
        Me.colABTEILUNGSTATUS.VisibleIndex = 2
        Me.colABTEILUNGSTATUS.Width = 130
        '
        'colCURRENTUSER
        '
        Me.colCURRENTUSER.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colCURRENTUSER.FieldName = "CURRENT USER"
        Me.colCURRENTUSER.Name = "colCURRENTUSER"
        Me.colCURRENTUSER.OptionsColumn.ShowInCustomizationForm = False
        Me.colCURRENTUSER.OptionsColumn.ShowInExpressionEditor = False
        Me.colCURRENTUSER.Width = 90
        '
        'colBearbeitungsstatus
        '
        Me.colBearbeitungsstatus.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colBearbeitungsstatus.FieldName = "Bearbeitungsstatus"
        Me.colBearbeitungsstatus.Name = "colBearbeitungsstatus"
        Me.colBearbeitungsstatus.OptionsColumn.ShowInCustomizationForm = False
        Me.colBearbeitungsstatus.OptionsColumn.ShowInExpressionEditor = False
        Me.colBearbeitungsstatus.Width = 90
        '
        'colIdBANK
        '
        Me.colIdBANK.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colIdBANK.FieldName = "IdBANK"
        Me.colIdBANK.Name = "colIdBANK"
        Me.colIdBANK.OptionsColumn.ShowInCustomizationForm = False
        Me.colIdBANK.OptionsColumn.ShowInExpressionEditor = False
        Me.colIdBANK.Width = 124
        '
        'LayoutView1
        '
        Me.LayoutView1.CardMinSize = New System.Drawing.Size(575, 346)
        Me.LayoutView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.LayoutViewColumn4, Me.LayoutViewColumn5, Me.LayoutViewColumn6, Me.LayoutViewColumn7, Me.LayoutViewColumn8, Me.LayoutViewColumn9, Me.LayoutViewColumn10, Me.LayoutViewColumn11, Me.LayoutViewColumn12, Me.LayoutViewColumn13})
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.FieldName = "ID"
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_colID
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        Me.LayoutViewColumn1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID
        '
        Me.layoutViewField_colID.EditorPreferredWidth = 404
        Me.layoutViewField_colID.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID.Name = "layoutViewField_colID"
        Me.layoutViewField_colID.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colID.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.FieldName = "ABTEILUNGS CODE"
        Me.LayoutViewColumn2.LayoutViewField = Me.layoutViewField_colABTEILUNGSCODE
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        '
        'layoutViewField_colABTEILUNGSCODE
        '
        Me.layoutViewField_colABTEILUNGSCODE.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGSCODE.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colABTEILUNGSCODE.Name = "layoutViewField_colABTEILUNGSCODE"
        Me.layoutViewField_colABTEILUNGSCODE.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGSCODE.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.FieldName = "ABTEILUNGS NAME"
        Me.LayoutViewColumn3.LayoutViewField = Me.layoutViewField_colABTEILUNGSNAME
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        '
        'layoutViewField_colABTEILUNGSNAME
        '
        Me.layoutViewField_colABTEILUNGSNAME.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGSNAME.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colABTEILUNGSNAME.Name = "layoutViewField_colABTEILUNGSNAME"
        Me.layoutViewField_colABTEILUNGSNAME.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGSNAME.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.FieldName = "ABTEILUNGSLEITER"
        Me.LayoutViewColumn4.LayoutViewField = Me.layoutViewField_colABTEILUNGSLEITER
        Me.LayoutViewColumn4.Name = "LayoutViewColumn4"
        '
        'layoutViewField_colABTEILUNGSLEITER
        '
        Me.layoutViewField_colABTEILUNGSLEITER.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGSLEITER.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colABTEILUNGSLEITER.Name = "layoutViewField_colABTEILUNGSLEITER"
        Me.layoutViewField_colABTEILUNGSLEITER.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGSLEITER.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn5
        '
        Me.LayoutViewColumn5.FieldName = "ABTEILUNG TEL"
        Me.LayoutViewColumn5.LayoutViewField = Me.layoutViewField_colABTEILUNGTEL
        Me.LayoutViewColumn5.Name = "LayoutViewColumn5"
        '
        'layoutViewField_colABTEILUNGTEL
        '
        Me.layoutViewField_colABTEILUNGTEL.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGTEL.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colABTEILUNGTEL.Name = "layoutViewField_colABTEILUNGTEL"
        Me.layoutViewField_colABTEILUNGTEL.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGTEL.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn6
        '
        Me.LayoutViewColumn6.FieldName = "ABTEILUNG FAX"
        Me.LayoutViewColumn6.LayoutViewField = Me.layoutViewField_colABTEILUNGFAX
        Me.LayoutViewColumn6.Name = "LayoutViewColumn6"
        '
        'layoutViewField_colABTEILUNGFAX
        '
        Me.layoutViewField_colABTEILUNGFAX.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGFAX.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colABTEILUNGFAX.Name = "layoutViewField_colABTEILUNGFAX"
        Me.layoutViewField_colABTEILUNGFAX.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGFAX.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn7
        '
        Me.LayoutViewColumn7.FieldName = "ABTEILUNG E-MAIL"
        Me.LayoutViewColumn7.LayoutViewField = Me.LayoutViewField1
        Me.LayoutViewColumn7.Name = "LayoutViewColumn7"
        '
        'LayoutViewField1
        '
        Me.LayoutViewField1.EditorPreferredWidth = 404
        Me.LayoutViewField1.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField1.Name = "LayoutViewField1"
        Me.LayoutViewField1.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField1.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn8
        '
        Me.LayoutViewColumn8.FieldName = "ABTEILUNG BEMERKUNGEN"
        Me.LayoutViewColumn8.LayoutViewField = Me.layoutViewField_colABTEILUNGBEMERKUNGEN
        Me.LayoutViewColumn8.Name = "LayoutViewColumn8"
        '
        'layoutViewField_colABTEILUNGBEMERKUNGEN
        '
        Me.layoutViewField_colABTEILUNGBEMERKUNGEN.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGBEMERKUNGEN.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colABTEILUNGBEMERKUNGEN.Name = "layoutViewField_colABTEILUNGBEMERKUNGEN"
        Me.layoutViewField_colABTEILUNGBEMERKUNGEN.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGBEMERKUNGEN.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn9
        '
        Me.LayoutViewColumn9.FieldName = "ABTEILUNG EVENT JOURNAL"
        Me.LayoutViewColumn9.LayoutViewField = Me.layoutViewField_colABTEILUNGEVENTJOURNAL
        Me.LayoutViewColumn9.Name = "LayoutViewColumn9"
        '
        'layoutViewField_colABTEILUNGEVENTJOURNAL
        '
        Me.layoutViewField_colABTEILUNGEVENTJOURNAL.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGEVENTJOURNAL.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colABTEILUNGEVENTJOURNAL.Name = "layoutViewField_colABTEILUNGEVENTJOURNAL"
        Me.layoutViewField_colABTEILUNGEVENTJOURNAL.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGEVENTJOURNAL.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn10
        '
        Me.LayoutViewColumn10.FieldName = "ABTEILUNG STATUS"
        Me.LayoutViewColumn10.LayoutViewField = Me.layoutViewField_colABTEILUNGSTATUS
        Me.LayoutViewColumn10.Name = "LayoutViewColumn10"
        '
        'layoutViewField_colABTEILUNGSTATUS
        '
        Me.layoutViewField_colABTEILUNGSTATUS.EditorPreferredWidth = 404
        Me.layoutViewField_colABTEILUNGSTATUS.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colABTEILUNGSTATUS.Name = "layoutViewField_colABTEILUNGSTATUS"
        Me.layoutViewField_colABTEILUNGSTATUS.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colABTEILUNGSTATUS.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn11
        '
        Me.LayoutViewColumn11.FieldName = "CURRENT USER"
        Me.LayoutViewColumn11.LayoutViewField = Me.layoutViewField_colCURRENTUSER
        Me.LayoutViewColumn11.Name = "LayoutViewColumn11"
        '
        'layoutViewField_colCURRENTUSER
        '
        Me.layoutViewField_colCURRENTUSER.EditorPreferredWidth = 404
        Me.layoutViewField_colCURRENTUSER.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colCURRENTUSER.Name = "layoutViewField_colCURRENTUSER"
        Me.layoutViewField_colCURRENTUSER.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colCURRENTUSER.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn12
        '
        Me.LayoutViewColumn12.FieldName = "Bearbeitungsstatus"
        Me.LayoutViewColumn12.LayoutViewField = Me.layoutViewField_colBearbeitungsstatus
        Me.LayoutViewColumn12.Name = "LayoutViewColumn12"
        '
        'layoutViewField_colBearbeitungsstatus
        '
        Me.layoutViewField_colBearbeitungsstatus.EditorPreferredWidth = 404
        Me.layoutViewField_colBearbeitungsstatus.Location = New System.Drawing.Point(0, 220)
        Me.layoutViewField_colBearbeitungsstatus.Name = "layoutViewField_colBearbeitungsstatus"
        Me.layoutViewField_colBearbeitungsstatus.Size = New System.Drawing.Size(555, 20)
        Me.layoutViewField_colBearbeitungsstatus.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn13
        '
        Me.LayoutViewColumn13.FieldName = "IdBANK"
        Me.LayoutViewColumn13.LayoutViewField = Me.layoutViewField_colIdBANK
        Me.LayoutViewColumn13.Name = "LayoutViewColumn13"
        '
        'layoutViewField_colIdBANK
        '
        Me.layoutViewField_colIdBANK.EditorPreferredWidth = 404
        Me.layoutViewField_colIdBANK.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_colIdBANK.Name = "layoutViewField_colIdBANK"
        Me.layoutViewField_colIdBANK.Size = New System.Drawing.Size(555, 67)
        Me.layoutViewField_colIdBANK.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID, Me.layoutViewField_colABTEILUNGSCODE, Me.layoutViewField_colABTEILUNGSNAME, Me.layoutViewField_colABTEILUNGSLEITER, Me.layoutViewField_colABTEILUNGTEL, Me.layoutViewField_colABTEILUNGFAX, Me.LayoutViewField1, Me.layoutViewField_colABTEILUNGBEMERKUNGEN, Me.layoutViewField_colABTEILUNGEVENTJOURNAL, Me.layoutViewField_colABTEILUNGSTATUS, Me.layoutViewField_colCURRENTUSER, Me.layoutViewField_colBearbeitungsstatus, Me.layoutViewField_colIdBANK})
        Me.LayoutViewCard1.Name = "layoutViewTemplateCard"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'ParameterView
        '
        Me.ParameterView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ParameterView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ParameterView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ParameterView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ParameterView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ParameterView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colPARAMETER1, Me.colPARAMETER2, Me.colPARAMETERSTATUS, Me.colPARAMETERINFO, Me.colIdABTEILUNGSPARAMETER, Me.colNPARAMETER1, Me.colNPARAMETER2, Me.colDPARAMETER1, Me.colDPARAMETER2})
        Me.ParameterView.GridControl = Me.GridControl1
        Me.ParameterView.Name = "ParameterView"
        Me.ParameterView.NewItemRowText = "Add new Parameters"
        Me.ParameterView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ParameterView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ParameterView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.ParameterView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.ParameterView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ParameterView.OptionsFind.AlwaysVisible = True
        Me.ParameterView.OptionsNavigation.AutoFocusNewRow = True
        Me.ParameterView.OptionsSelection.MultiSelect = True
        Me.ParameterView.OptionsView.ColumnAutoWidth = False
        Me.ParameterView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ParameterView.OptionsView.ShowAutoFilterRow = True
        Me.ParameterView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ParameterView.OptionsView.ShowFooter = True
        Me.ParameterView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colPARAMETER1, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.ParameterView.ViewCaption = "PARAMETERS"
        '
        'colID2
        '
        Me.colID2.Caption = "ID"
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colPARAMETER1
        '
        Me.colPARAMETER1.Caption = "PARAMETER 1"
        Me.colPARAMETER1.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colPARAMETER1.FieldName = "PARAMETER1"
        Me.colPARAMETER1.Name = "colPARAMETER1"
        Me.colPARAMETER1.Visible = True
        Me.colPARAMETER1.VisibleIndex = 0
        Me.colPARAMETER1.Width = 433
        '
        'colPARAMETER2
        '
        Me.colPARAMETER2.Caption = "PARAMETER 2"
        Me.colPARAMETER2.ColumnEdit = Me.ALL_OTHERRepositoryItemTextEdit1
        Me.colPARAMETER2.FieldName = "PARAMETER2"
        Me.colPARAMETER2.Name = "colPARAMETER2"
        Me.colPARAMETER2.Visible = True
        Me.colPARAMETER2.VisibleIndex = 1
        Me.colPARAMETER2.Width = 440
        '
        'colPARAMETERSTATUS
        '
        Me.colPARAMETERSTATUS.Caption = "PARAMETER STATUS"
        Me.colPARAMETERSTATUS.ColumnEdit = Me.VALIDRepositoryItemImageComboBox1
        Me.colPARAMETERSTATUS.FieldName = "PARAMETER STATUS"
        Me.colPARAMETERSTATUS.Name = "colPARAMETERSTATUS"
        Me.colPARAMETERSTATUS.Visible = True
        Me.colPARAMETERSTATUS.VisibleIndex = 4
        Me.colPARAMETERSTATUS.Width = 109
        '
        'colPARAMETERINFO
        '
        Me.colPARAMETERINFO.Caption = "PARAMETER INFO"
        Me.colPARAMETERINFO.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colPARAMETERINFO.FieldName = "PARAMETER INFO"
        Me.colPARAMETERINFO.Name = "colPARAMETERINFO"
        Me.colPARAMETERINFO.Visible = True
        Me.colPARAMETERINFO.VisibleIndex = 5
        Me.colPARAMETERINFO.Width = 99
        '
        'colIdABTEILUNGSPARAMETER
        '
        Me.colIdABTEILUNGSPARAMETER.Caption = "ID DEPARTMENT PARAMETER"
        Me.colIdABTEILUNGSPARAMETER.FieldName = "IdABTEILUNGSPARAMETER"
        Me.colIdABTEILUNGSPARAMETER.Name = "colIdABTEILUNGSPARAMETER"
        Me.colIdABTEILUNGSPARAMETER.OptionsColumn.ReadOnly = True
        Me.colIdABTEILUNGSPARAMETER.Visible = True
        Me.colIdABTEILUNGSPARAMETER.VisibleIndex = 6
        Me.colIdABTEILUNGSPARAMETER.Width = 158
        '
        'colNPARAMETER1
        '
        Me.colNPARAMETER1.AppearanceCell.Options.UseTextOptions = True
        Me.colNPARAMETER1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colNPARAMETER1.Caption = "NUMERIC PARAMETER 1"
        Me.colNPARAMETER1.FieldName = "NPARAMETER1"
        Me.colNPARAMETER1.Name = "colNPARAMETER1"
        Me.colNPARAMETER1.Visible = True
        Me.colNPARAMETER1.VisibleIndex = 2
        Me.colNPARAMETER1.Width = 126
        '
        'colNPARAMETER2
        '
        Me.colNPARAMETER2.AppearanceCell.Options.UseTextOptions = True
        Me.colNPARAMETER2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colNPARAMETER2.Caption = "NUMERIC PARAMETER 2"
        Me.colNPARAMETER2.FieldName = "NPARAMETER2"
        Me.colNPARAMETER2.Name = "colNPARAMETER2"
        Me.colNPARAMETER2.Visible = True
        Me.colNPARAMETER2.VisibleIndex = 3
        Me.colNPARAMETER2.Width = 136
        '
        'GridView1
        '
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.GridControl = Me.GridControl2
        Me.GridView1.Name = "GridView1"
        Me.GridView1.NewItemRowText = "Add New Department Parameter"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsBehavior.AllowIncrementalSearch = True
        Me.GridView1.OptionsDetail.AllowExpandEmptyDetails = True
        Me.GridView1.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.GridView1.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.ViewCaption = "DEPARTMENT PARAMETERS"
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "ID"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "DEPARTMENT PARAMETER NAME"
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn3.FieldName = "ABTEILUNGSPARAMETER NAME"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 197
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "DEPARTMENT PARAMETER STATUS"
        Me.GridColumn4.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.GridColumn4.FieldName = "ABTEILUNGSPARAMETER STATUS"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 183
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseFont = True
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemImageComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NON VALID", "N", 5)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "DEPARTMENT PARAMETER INFO"
        Me.GridColumn5.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.GridColumn5.FieldName = "ABTEILUNGSPARAMETER INFO"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 175
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit2.Name = "RepositoryItemMemoExEdit2"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID DEPARTMENT CODE"
        Me.GridColumn6.FieldName = "IdABTEILUNGSCODE"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 126
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.PARAMETER_AllBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 3
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.ImageIndex = 5
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.ImageIndex = 10
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 9
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(7, "Delete Parameter"), New DevExpress.XtraEditors.NavigatorCustomButton(2, "PrintAllParameters")})
        Me.GridControl2.Location = New System.Drawing.Point(24, 46)
        Me.GridControl2.MainView = Me.Parameter_All_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit2, Me.RepositoryItemImageComboBox1})
        Me.GridControl2.Size = New System.Drawing.Size(1482, 611)
        Me.GridControl2.TabIndex = 2
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Parameter_All_GridView, Me.GridView2, Me.LayoutView2, Me.GridView1})
        '
        'PARAMETER_AllBindingSource
        '
        Me.PARAMETER_AllBindingSource.DataMember = "PARAMETER_All"
        Me.PARAMETER_AllBindingSource.DataSource = Me.PSTOOLDataset
        '
        'Parameter_All_GridView
        '
        Me.Parameter_All_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Parameter_All_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Parameter_All_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Parameter_All_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Parameter_All_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Parameter_All_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Parameter_All_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Parameter_All_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID3, Me.colPARAMETER11, Me.colPARAMETER21, Me.colPARAMETERSTATUS1, Me.colPARAMETERINFO1, Me.colIdABTEILUNGSPARAMETER1, Me.colNPARAMETER11, Me.colNPARAMETER21, Me.colDPARAMETER11, Me.DPARAMETER22, Me.colIdABTEILUNGSCODE_NAME})
        Me.Parameter_All_GridView.GridControl = Me.GridControl2
        Me.Parameter_All_GridView.Images = Me.ImageCollection1
        Me.Parameter_All_GridView.Name = "Parameter_All_GridView"
        Me.Parameter_All_GridView.NewItemRowText = "Add new Department"
        Me.Parameter_All_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.Parameter_All_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.Parameter_All_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Parameter_All_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Parameter_All_GridView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.Parameter_All_GridView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.Parameter_All_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Parameter_All_GridView.OptionsFind.AlwaysVisible = True
        Me.Parameter_All_GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.Parameter_All_GridView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Parameter_All_GridView.OptionsNavigation.AutoFocusNewRow = True
        Me.Parameter_All_GridView.OptionsPrint.ExpandAllDetails = True
        Me.Parameter_All_GridView.OptionsPrint.PrintDetails = True
        Me.Parameter_All_GridView.OptionsPrint.PrintFilterInfo = True
        Me.Parameter_All_GridView.OptionsPrint.PrintPreview = True
        Me.Parameter_All_GridView.OptionsSelection.MultiSelect = True
        Me.Parameter_All_GridView.OptionsView.ColumnAutoWidth = False
        Me.Parameter_All_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Parameter_All_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Parameter_All_GridView.OptionsView.ShowAutoFilterRow = True
        Me.Parameter_All_GridView.OptionsView.ShowChildrenInGroupPanel = True
        Me.Parameter_All_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Parameter_All_GridView.OptionsView.ShowFooter = True
        Me.Parameter_All_GridView.OptionsView.ShowGroupedColumns = True
        Me.Parameter_All_GridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colID3, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'colID3
        '
        Me.colID3.FieldName = "ID"
        Me.colID3.Name = "colID3"
        Me.colID3.OptionsColumn.AllowEdit = False
        Me.colID3.OptionsColumn.ReadOnly = True
        Me.colID3.Visible = True
        Me.colID3.VisibleIndex = 0
        '
        'colPARAMETER11
        '
        Me.colPARAMETER11.FieldName = "PARAMETER1"
        Me.colPARAMETER11.Name = "colPARAMETER11"
        Me.colPARAMETER11.Visible = True
        Me.colPARAMETER11.VisibleIndex = 1
        Me.colPARAMETER11.Width = 464
        '
        'colPARAMETER21
        '
        Me.colPARAMETER21.FieldName = "PARAMETER2"
        Me.colPARAMETER21.Name = "colPARAMETER21"
        Me.colPARAMETER21.Visible = True
        Me.colPARAMETER21.VisibleIndex = 2
        Me.colPARAMETER21.Width = 439
        '
        'colPARAMETERSTATUS1
        '
        Me.colPARAMETERSTATUS1.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colPARAMETERSTATUS1.FieldName = "PARAMETER STATUS"
        Me.colPARAMETERSTATUS1.Name = "colPARAMETERSTATUS1"
        Me.colPARAMETERSTATUS1.Visible = True
        Me.colPARAMETERSTATUS1.VisibleIndex = 7
        Me.colPARAMETERSTATUS1.Width = 108
        '
        'colPARAMETERINFO1
        '
        Me.colPARAMETERINFO1.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colPARAMETERINFO1.FieldName = "PARAMETER INFO"
        Me.colPARAMETERINFO1.Name = "colPARAMETERINFO1"
        Me.colPARAMETERINFO1.Visible = True
        Me.colPARAMETERINFO1.VisibleIndex = 8
        Me.colPARAMETERINFO1.Width = 80
        '
        'colIdABTEILUNGSPARAMETER1
        '
        Me.colIdABTEILUNGSPARAMETER1.Caption = "ID DEPARTMENT PARAMETER"
        Me.colIdABTEILUNGSPARAMETER1.FieldName = "IdABTEILUNGSPARAMETER"
        Me.colIdABTEILUNGSPARAMETER1.Name = "colIdABTEILUNGSPARAMETER1"
        Me.colIdABTEILUNGSPARAMETER1.OptionsColumn.AllowEdit = False
        Me.colIdABTEILUNGSPARAMETER1.OptionsColumn.ReadOnly = True
        Me.colIdABTEILUNGSPARAMETER1.Visible = True
        Me.colIdABTEILUNGSPARAMETER1.VisibleIndex = 9
        Me.colIdABTEILUNGSPARAMETER1.Width = 217
        '
        'colNPARAMETER11
        '
        Me.colNPARAMETER11.Caption = "Nummeric Parameter 1"
        Me.colNPARAMETER11.FieldName = "NPARAMETER1"
        Me.colNPARAMETER11.Name = "colNPARAMETER11"
        Me.colNPARAMETER11.Visible = True
        Me.colNPARAMETER11.VisibleIndex = 3
        Me.colNPARAMETER11.Width = 97
        '
        'colNPARAMETER21
        '
        Me.colNPARAMETER21.Caption = "Nummeric Parameter 2"
        Me.colNPARAMETER21.FieldName = "NPARAMETER2"
        Me.colNPARAMETER21.Name = "colNPARAMETER21"
        Me.colNPARAMETER21.Visible = True
        Me.colNPARAMETER21.VisibleIndex = 4
        Me.colNPARAMETER21.Width = 100
        '
        'colIdABTEILUNGSCODE_NAME
        '
        Me.colIdABTEILUNGSCODE_NAME.Caption = "DEPARTMENT NAME"
        Me.colIdABTEILUNGSCODE_NAME.FieldName = "IdABTEILUNGSCODE_NAME"
        Me.colIdABTEILUNGSCODE_NAME.Name = "colIdABTEILUNGSCODE_NAME"
        Me.colIdABTEILUNGSCODE_NAME.OptionsColumn.AllowEdit = False
        Me.colIdABTEILUNGSCODE_NAME.OptionsColumn.ReadOnly = True
        Me.colIdABTEILUNGSCODE_NAME.Visible = True
        Me.colIdABTEILUNGSCODE_NAME.VisibleIndex = 10
        Me.colIdABTEILUNGSCODE_NAME.Width = 161
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'GridView2
        '
        Me.GridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.NewItemRowText = "Add new Parameters"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView2.OptionsDetail.AllowExpandEmptyDetails = True
        Me.GridView2.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.ViewCaption = "PARAMETERS"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID"
        Me.GridColumn7.FieldName = "ID"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "PARAMETER 1"
        Me.GridColumn8.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn8.FieldName = "PARAMETER1"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        Me.GridColumn8.Width = 433
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "PARAMETER 2"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn9.FieldName = "PARAMETER2"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        Me.GridColumn9.Width = 440
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "PARAMETER STATUS"
        Me.GridColumn10.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.GridColumn10.FieldName = "PARAMETER STATUS"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 4
        Me.GridColumn10.Width = 109
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "PARAMETER INFO"
        Me.GridColumn11.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.GridColumn11.FieldName = "PARAMETER INFO"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 5
        Me.GridColumn11.Width = 99
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "ID DEPARTMENT PARAMETER"
        Me.GridColumn12.FieldName = "IdABTEILUNGSPARAMETER"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 6
        Me.GridColumn12.Width = 158
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.Caption = "NUMERIC PARAMETER 1"
        Me.GridColumn13.FieldName = "NPARAMETER1"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 126
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.Caption = "NUMERIC PARAMETER 2"
        Me.GridColumn14.FieldName = "NPARAMETER2"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 136
        '
        'LayoutView2
        '
        Me.LayoutView2.CardMinSize = New System.Drawing.Size(575, 346)
        Me.LayoutView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn14, Me.LayoutViewColumn15, Me.LayoutViewColumn16, Me.LayoutViewColumn17, Me.LayoutViewColumn18, Me.LayoutViewColumn19, Me.LayoutViewColumn20, Me.LayoutViewColumn21, Me.LayoutViewColumn22, Me.LayoutViewColumn23, Me.LayoutViewColumn24, Me.LayoutViewColumn25, Me.LayoutViewColumn26})
        Me.LayoutView2.GridControl = Me.GridControl2
        Me.LayoutView2.Name = "LayoutView2"
        Me.LayoutView2.TemplateCard = Me.LayoutViewCard2
        '
        'LayoutViewColumn14
        '
        Me.LayoutViewColumn14.FieldName = "ID"
        Me.LayoutViewColumn14.LayoutViewField = Me.LayoutViewField2
        Me.LayoutViewColumn14.Name = "LayoutViewColumn14"
        Me.LayoutViewColumn14.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField2
        '
        Me.LayoutViewField2.EditorPreferredWidth = 404
        Me.LayoutViewField2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField2.Name = "LayoutViewField2"
        Me.LayoutViewField2.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField2.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn15
        '
        Me.LayoutViewColumn15.FieldName = "ABTEILUNGS CODE"
        Me.LayoutViewColumn15.LayoutViewField = Me.LayoutViewField3
        Me.LayoutViewColumn15.Name = "LayoutViewColumn15"
        '
        'LayoutViewField3
        '
        Me.LayoutViewField3.EditorPreferredWidth = 404
        Me.LayoutViewField3.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField3.Name = "LayoutViewField3"
        Me.LayoutViewField3.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField3.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn16
        '
        Me.LayoutViewColumn16.FieldName = "ABTEILUNGS NAME"
        Me.LayoutViewColumn16.LayoutViewField = Me.LayoutViewField4
        Me.LayoutViewColumn16.Name = "LayoutViewColumn16"
        '
        'LayoutViewField4
        '
        Me.LayoutViewField4.EditorPreferredWidth = 404
        Me.LayoutViewField4.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField4.Name = "LayoutViewField4"
        Me.LayoutViewField4.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField4.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn17
        '
        Me.LayoutViewColumn17.FieldName = "ABTEILUNGSLEITER"
        Me.LayoutViewColumn17.LayoutViewField = Me.LayoutViewField5
        Me.LayoutViewColumn17.Name = "LayoutViewColumn17"
        '
        'LayoutViewField5
        '
        Me.LayoutViewField5.EditorPreferredWidth = 404
        Me.LayoutViewField5.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField5.Name = "LayoutViewField5"
        Me.LayoutViewField5.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField5.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn18
        '
        Me.LayoutViewColumn18.FieldName = "ABTEILUNG TEL"
        Me.LayoutViewColumn18.LayoutViewField = Me.LayoutViewField6
        Me.LayoutViewColumn18.Name = "LayoutViewColumn18"
        '
        'LayoutViewField6
        '
        Me.LayoutViewField6.EditorPreferredWidth = 404
        Me.LayoutViewField6.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField6.Name = "LayoutViewField6"
        Me.LayoutViewField6.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField6.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn19
        '
        Me.LayoutViewColumn19.FieldName = "ABTEILUNG FAX"
        Me.LayoutViewColumn19.LayoutViewField = Me.LayoutViewField7
        Me.LayoutViewColumn19.Name = "LayoutViewColumn19"
        '
        'LayoutViewField7
        '
        Me.LayoutViewField7.EditorPreferredWidth = 404
        Me.LayoutViewField7.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField7.Name = "LayoutViewField7"
        Me.LayoutViewField7.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField7.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn20
        '
        Me.LayoutViewColumn20.FieldName = "ABTEILUNG E-MAIL"
        Me.LayoutViewColumn20.LayoutViewField = Me.LayoutViewField8
        Me.LayoutViewColumn20.Name = "LayoutViewColumn20"
        '
        'LayoutViewField8
        '
        Me.LayoutViewField8.EditorPreferredWidth = 404
        Me.LayoutViewField8.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField8.Name = "LayoutViewField8"
        Me.LayoutViewField8.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField8.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn21
        '
        Me.LayoutViewColumn21.FieldName = "ABTEILUNG BEMERKUNGEN"
        Me.LayoutViewColumn21.LayoutViewField = Me.LayoutViewField9
        Me.LayoutViewColumn21.Name = "LayoutViewColumn21"
        '
        'LayoutViewField9
        '
        Me.LayoutViewField9.EditorPreferredWidth = 404
        Me.LayoutViewField9.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField9.Name = "LayoutViewField9"
        Me.LayoutViewField9.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField9.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn22
        '
        Me.LayoutViewColumn22.FieldName = "ABTEILUNG EVENT JOURNAL"
        Me.LayoutViewColumn22.LayoutViewField = Me.LayoutViewField10
        Me.LayoutViewColumn22.Name = "LayoutViewColumn22"
        '
        'LayoutViewField10
        '
        Me.LayoutViewField10.EditorPreferredWidth = 404
        Me.LayoutViewField10.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField10.Name = "LayoutViewField10"
        Me.LayoutViewField10.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField10.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn23
        '
        Me.LayoutViewColumn23.FieldName = "ABTEILUNG STATUS"
        Me.LayoutViewColumn23.LayoutViewField = Me.LayoutViewField11
        Me.LayoutViewColumn23.Name = "LayoutViewColumn23"
        '
        'LayoutViewField11
        '
        Me.LayoutViewField11.EditorPreferredWidth = 404
        Me.LayoutViewField11.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField11.Name = "LayoutViewField11"
        Me.LayoutViewField11.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField11.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn24
        '
        Me.LayoutViewColumn24.FieldName = "CURRENT USER"
        Me.LayoutViewColumn24.LayoutViewField = Me.LayoutViewField12
        Me.LayoutViewColumn24.Name = "LayoutViewColumn24"
        '
        'LayoutViewField12
        '
        Me.LayoutViewField12.EditorPreferredWidth = 404
        Me.LayoutViewField12.Location = New System.Drawing.Point(0, 200)
        Me.LayoutViewField12.Name = "LayoutViewField12"
        Me.LayoutViewField12.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField12.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn25
        '
        Me.LayoutViewColumn25.FieldName = "Bearbeitungsstatus"
        Me.LayoutViewColumn25.LayoutViewField = Me.LayoutViewField13
        Me.LayoutViewColumn25.Name = "LayoutViewColumn25"
        '
        'LayoutViewField13
        '
        Me.LayoutViewField13.EditorPreferredWidth = 404
        Me.LayoutViewField13.Location = New System.Drawing.Point(0, 220)
        Me.LayoutViewField13.Name = "LayoutViewField13"
        Me.LayoutViewField13.Size = New System.Drawing.Size(555, 20)
        Me.LayoutViewField13.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewColumn26
        '
        Me.LayoutViewColumn26.FieldName = "IdBANK"
        Me.LayoutViewColumn26.LayoutViewField = Me.LayoutViewField14
        Me.LayoutViewColumn26.Name = "LayoutViewColumn26"
        '
        'LayoutViewField14
        '
        Me.LayoutViewField14.EditorPreferredWidth = 404
        Me.LayoutViewField14.Location = New System.Drawing.Point(0, 240)
        Me.LayoutViewField14.Name = "LayoutViewField14"
        Me.LayoutViewField14.Size = New System.Drawing.Size(555, 67)
        Me.LayoutViewField14.TextSize = New System.Drawing.Size(142, 13)
        '
        'LayoutViewCard2
        '
        Me.LayoutViewCard2.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard2.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField2, Me.LayoutViewField3, Me.LayoutViewField4, Me.LayoutViewField5, Me.LayoutViewField6, Me.LayoutViewField7, Me.LayoutViewField8, Me.LayoutViewField9, Me.LayoutViewField10, Me.LayoutViewField11, Me.LayoutViewField12, Me.LayoutViewField13, Me.LayoutViewField14})
        Me.LayoutViewCard2.Name = "layoutViewTemplateCard"
        Me.LayoutViewCard2.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard2.Text = "TemplateCard"
        '
        'ABTEILUNGSPARAMETERBindingSource
        '
        Me.ABTEILUNGSPARAMETERBindingSource.DataMember = "FK_ABTEILUNGSPARAMETER_ABTEILUNGEN"
        Me.ABTEILUNGSPARAMETERBindingSource.DataSource = Me.ABTEILUNGENBindingSource
        '
        'PARAMETERBindingSource
        '
        Me.PARAMETERBindingSource.DataSource = Me.ABTEILUNGSPARAMETERBindingSource
        '
        'ABTEILUNGENTableAdapter
        '
        Me.ABTEILUNGENTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Me.ABTEILUNGENTableAdapter
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Me.ABTEILUNGSPARAMETERTableAdapter
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
        Me.TableAdapterManager.CalendarTableAdapter = Nothing
        Me.TableAdapterManager.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_INFOTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTS_BAISTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTS_NEWGTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PARAMETER_All_TableAdapter = Me.PARAMETER_All_TableAdapter
        Me.TableAdapterManager.PARAMETERTableAdapter = Me.PARAMETERTableAdapter
        Me.TableAdapterManager.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager.SSISTableAdapter = Nothing
        Me.TableAdapterManager.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ABTEILUNGSPARAMETERTableAdapter
        '
        Me.ABTEILUNGSPARAMETERTableAdapter.ClearBeforeFill = True
        '
        'PARAMETER_All_TableAdapter
        '
        Me.PARAMETER_All_TableAdapter.ClearBeforeFill = True
        '
        'PARAMETERTableAdapter
        '
        Me.PARAMETERTableAdapter.ClearBeforeFill = True
        '
        'PARAMETERFK00BindingSource
        '
        Me.PARAMETERFK00BindingSource.DataMember = "PARAMETER_FK00"
        Me.PARAMETERFK00BindingSource.DataSource = Me.ABTEILUNGSPARAMETERBindingSource
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl2
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(390, 162, 768, 587)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1530, 681)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1530, 681)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.CustomizationFormText = "TabbedControlGroup1"
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup2
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1510, 661)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup2.CustomizationFormText = "Parameter Configuration"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1486, 615)
        Me.LayoutControlGroup2.Text = "Parameter Configuration"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1486, 615)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup3.CustomizationFormText = "All Parameters"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1486, 615)
        Me.LayoutControlGroup3.Text = "All Parameters"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl2
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1486, 615)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
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
        'colDPARAMETER1
        '
        Me.colDPARAMETER1.AppearanceCell.Options.UseTextOptions = True
        Me.colDPARAMETER1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDPARAMETER1.Caption = "DATE PARAMETER 1"
        Me.colDPARAMETER1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colDPARAMETER1.DisplayFormat.FormatString = "d"
        Me.colDPARAMETER1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDPARAMETER1.FieldName = "DPARAMETER1"
        Me.colDPARAMETER1.Name = "colDPARAMETER1"
        Me.colDPARAMETER1.Visible = True
        Me.colDPARAMETER1.VisibleIndex = 7
        Me.colDPARAMETER1.Width = 108
        '
        'colDPARAMETER2
        '
        Me.colDPARAMETER2.AppearanceCell.Options.UseTextOptions = True
        Me.colDPARAMETER2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDPARAMETER2.Caption = "DATE PARAMETER 2"
        Me.colDPARAMETER2.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colDPARAMETER2.DisplayFormat.FormatString = "d"
        Me.colDPARAMETER2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDPARAMETER2.FieldName = "DPARAMETER2"
        Me.colDPARAMETER2.Name = "colDPARAMETER2"
        Me.colDPARAMETER2.Visible = True
        Me.colDPARAMETER2.VisibleIndex = 8
        Me.colDPARAMETER2.Width = 120
        '
        'colDPARAMETER11
        '
        Me.colDPARAMETER11.AppearanceCell.Options.UseTextOptions = True
        Me.colDPARAMETER11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDPARAMETER11.Caption = "Date Parameter"
        Me.colDPARAMETER11.DisplayFormat.FormatString = "d"
        Me.colDPARAMETER11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDPARAMETER11.FieldName = "DPARAMETER1"
        Me.colDPARAMETER11.Name = "colDPARAMETER11"
        Me.colDPARAMETER11.OptionsColumn.AllowEdit = False
        Me.colDPARAMETER11.OptionsColumn.ReadOnly = True
        Me.colDPARAMETER11.Visible = True
        Me.colDPARAMETER11.VisibleIndex = 5
        '
        'DPARAMETER22
        '
        Me.DPARAMETER22.AppearanceCell.Options.UseTextOptions = True
        Me.DPARAMETER22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DPARAMETER22.Caption = "Date Parameter 2"
        Me.DPARAMETER22.DisplayFormat.FormatString = "d"
        Me.DPARAMETER22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DPARAMETER22.FieldName = "DPARAMETER2"
        Me.DPARAMETER22.Name = "DPARAMETER22"
        Me.DPARAMETER22.OptionsColumn.AllowEdit = False
        Me.DPARAMETER22.OptionsColumn.ReadOnly = True
        Me.DPARAMETER22.Visible = True
        Me.DPARAMETER22.VisibleIndex = 6
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1530, 681)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Configuration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DepartmentsParameterView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPARTMENT_CODERepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VALIDRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ABTEILUNGENBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartmentsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALL_OTHERRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGSCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGSNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGSLEITER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGBEMERKUNGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGEVENTJOURNAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colABTEILUNGSTATUS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCURRENTUSER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBearbeitungsstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colIdBANK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParameterView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PARAMETER_AllBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Parameter_All_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ABTEILUNGSPARAMETERBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PARAMETERBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PARAMETERFK00BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents ABTEILUNGENBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ABTEILUNGENTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.ABTEILUNGENTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents ABTEILUNGSPARAMETERTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.ABTEILUNGSPARAMETERTableAdapter
    Friend WithEvents ABTEILUNGSPARAMETERBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PARAMETERTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.PARAMETERTableAdapter
    Friend WithEvents PARAMETERBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents DepartmentsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PARAMETERFK00BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSLEITER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGTEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGFAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGBEMERKUNGEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGEVENTJOURNAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENTUSER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBearbeitungsstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DepartmentsParameterView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGSCODE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGSNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn4 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGSLEITER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn5 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn6 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn7 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn8 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGBEMERKUNGEN As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn9 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGEVENTJOURNAL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn10 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colABTEILUNGSTATUS As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn11 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCURRENTUSER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn12 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBearbeitungsstatus As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn13 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colIdBANK As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSPARAMETERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSPARAMETERSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABTEILUNGSPARAMETERINFO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdABTEILUNGSCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ParameterView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETER1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETER2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETERSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETERINFO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdABTEILUNGSPARAMETER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEPARTMENT_CODERepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ALL_OTHERRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents VALIDRepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents colNPARAMETER1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNPARAMETER2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Parameter_All_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView2 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn14 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn15 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn16 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn17 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn18 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField6 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn19 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField7 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn20 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField8 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn21 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField9 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn22 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField10 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn23 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField11 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn24 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField12 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn25 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField13 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn26 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField14 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard2 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PARAMETER_AllBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PARAMETER_All_TableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.PARAMETER_All_TableAdapter
    Friend WithEvents colID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETER11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETER21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETERSTATUS1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPARAMETERINFO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdABTEILUNGSPARAMETER1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNPARAMETER11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNPARAMETER21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colIdABTEILUNGSCODE_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDPARAMETER1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colDPARAMETER2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDPARAMETER11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DPARAMETER22 As DevExpress.XtraGrid.Columns.GridColumn
End Class
