<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckResults
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckResults))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PrintOrExport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.CheckResults_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCheckResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCheckTable = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colImportProcedure = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckResults_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PrintOrExport_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1417, 633)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PrintOrExport_btn
        '
        Me.PrintOrExport_btn.ImageOptions.Image = CType(resources.GetObject("PrintOrExport_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.PrintOrExport_btn.Location = New System.Drawing.Point(12, 12)
        Me.PrintOrExport_btn.Name = "PrintOrExport_btn"
        Me.PrintOrExport_btn.Size = New System.Drawing.Size(129, 22)
        Me.PrintOrExport_btn.StyleController = Me.LayoutControl1
        Me.PrintOrExport_btn.TabIndex = 5
        Me.PrintOrExport_btn.Text = "Print or Export"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 38)
        Me.GridControl1.MainView = Me.CheckResults_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1393, 583)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CheckResults_GridView})
        '
        'CheckResults_GridView
        '
        Me.CheckResults_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CheckResults_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CheckResults_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CheckResults_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CheckResults_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CheckResults_GridView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.CheckResults_GridView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CheckResults_GridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.CheckResults_GridView.Appearance.SelectedRow.Options.UseBackColor = True
        Me.CheckResults_GridView.Appearance.SelectedRow.Options.UseForeColor = True
        Me.CheckResults_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCheckResult, Me.colCheckTable, Me.colImportProcedure})
        Me.CheckResults_GridView.GridControl = Me.GridControl1
        Me.CheckResults_GridView.Name = "CheckResults_GridView"
        Me.CheckResults_GridView.OptionsBehavior.ReadOnly = True
        Me.CheckResults_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CheckResults_GridView.OptionsFind.AlwaysVisible = True
        Me.CheckResults_GridView.OptionsView.ColumnAutoWidth = False
        Me.CheckResults_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CheckResults_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CheckResults_GridView.OptionsView.ShowGroupPanel = False
        '
        'colCheckResult
        '
        Me.colCheckResult.Caption = "Check Result"
        Me.colCheckResult.FieldName = "Result"
        Me.colCheckResult.Name = "colCheckResult"
        Me.colCheckResult.Visible = True
        Me.colCheckResult.VisibleIndex = 0
        Me.colCheckResult.Width = 458
        '
        'colCheckTable
        '
        Me.colCheckTable.Caption = "Check Table"
        Me.colCheckTable.FieldName = "CheckTable"
        Me.colCheckTable.Name = "colCheckTable"
        Me.colCheckTable.Visible = True
        Me.colCheckTable.VisibleIndex = 1
        Me.colCheckTable.Width = 414
        '
        'colImportProcedure
        '
        Me.colImportProcedure.Caption = "Import Procedure"
        Me.colImportProcedure.FieldName = "ImportProcedure"
        Me.colImportProcedure.Name = "colImportProcedure"
        Me.colImportProcedure.Visible = True
        Me.colImportProcedure.VisibleIndex = 2
        Me.colImportProcedure.Width = 486
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1417, 633)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1397, 587)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(133, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1264, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.PrintOrExport_btn
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(133, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'CheckResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "CheckResults"
        Me.Size = New System.Drawing.Size(1417, 633)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckResults_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CheckResults_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCheckResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCheckTable As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colImportProcedure As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents PrintOrExport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
