Imports DevExpress.XtraGrid.Views.Grid

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateSqlScriptFromXML
    Inherits EditFormUserControl

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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateSqlScriptFromXML))
        Me.XmlSqlUnderlying_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.XmlSql_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.CommonBar1 = New DevExpress.XtraSpreadsheet.UI.CommonBar()
        Me.OpenFile_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.FileValidity_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FileValidity_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemRadioGroup1 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditFormUserControlLayoutControl1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.SplitterControl2 = New DevExpress.XtraEditors.SplitterControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem59 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.FileName_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem47 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit2 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl5 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit3 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl6 = New DevExpress.XtraLayout.LayoutControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup8 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl7 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup9 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup10 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl8 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit4 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl9 = New DevExpress.XtraLayout.LayoutControl()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup11 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl10 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup12 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup13 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl11 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit5 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl12 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit1 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit3 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit5 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit6 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup14 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl13 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup15 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit7 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup16 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem35 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl14 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit6 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl15 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit2 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit4 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit8 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit9 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit10 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup17 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem38 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem40 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl16 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup18 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem42 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit11 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup19 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem43 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem44 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem45 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem46 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl17 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit7 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl18 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit3 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit12 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit13 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit14 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit15 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup20 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem41 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem13 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem49 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem50 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem51 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem52 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl19 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup21 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem54 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit16 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup22 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem55 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem56 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem57 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem58 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem14 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem15 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl20 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit8 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl21 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit4 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.TextEdit17 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit18 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit19 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit20 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit21 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup23 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem48 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem16 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem61 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem62 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem63 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem64 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem65 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl22 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup24 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem66 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit22 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup25 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem67 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem68 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem69 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem70 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem17 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem18 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl23 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit9 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl24 = New DevExpress.XtraLayout.LayoutControl()
        Me.DateEdit5 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit23 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit24 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit25 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit26 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit27 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit6 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit7 = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup26 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem60 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem19 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem72 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem73 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem74 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem76 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem77 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem78 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem79 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl25 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup27 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem80 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit28 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup28 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem81 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem82 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem83 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem84 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem20 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem21 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl26 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit10 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl27 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit6 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit8 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit30 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit31 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit32 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit33 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit9 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit10 = New DevExpress.XtraEditors.DateEdit()
        Me.ImageComboBoxEdit7 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.LayoutControlGroup29 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem75 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem22 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem86 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem87 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem88 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem89 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem91 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem92 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem93 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem94 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl28 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup30 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem95 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit34 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup31 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem96 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem97 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem98 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem99 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem23 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem24 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl29 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit11 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl30 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit8 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit11 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit36 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit37 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit38 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit39 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit12 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit13 = New DevExpress.XtraEditors.DateEdit()
        Me.ImageComboBoxEdit9 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.LayoutControlGroup32 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem90 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem25 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem101 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem102 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem103 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem104 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem106 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem107 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem108 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem109 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl31 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup33 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem110 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit40 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup34 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem111 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem112 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem113 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem114 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem26 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem27 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl32 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit12 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl33 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit10 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit14 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit35 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit41 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit42 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit43 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit15 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit16 = New DevExpress.XtraEditors.DateEdit()
        Me.ImageComboBoxEdit11 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.TextEdit44 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit45 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup35 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem105 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem28 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem116 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem117 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem118 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem119 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem121 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem122 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem123 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem124 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem125 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem126 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl34 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup36 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem127 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit46 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup37 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem128 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem129 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem130 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem131 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem29 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem30 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl35 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit13 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl36 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit12 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit17 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit47 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit48 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit49 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit50 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit18 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit19 = New DevExpress.XtraEditors.DateEdit()
        Me.ImageComboBoxEdit13 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.TextEdit51 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit52 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem31 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem120 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem132 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem133 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem134 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem136 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem137 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem138 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem139 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem140 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem141 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit53 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup38 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem142 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem143 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem144 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem32 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem33 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl37 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit14 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl38 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit14 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit20 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit55 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit56 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit57 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit58 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit21 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit22 = New DevExpress.XtraEditors.DateEdit()
        Me.ImageComboBoxEdit15 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.TextEdit59 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit60 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup39 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem135 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem34 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem146 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem147 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem148 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem149 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem151 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem152 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem153 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem154 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem155 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem156 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit61 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup40 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem157 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem158 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem159 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem35 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem36 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl39 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit15 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl40 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageComboBoxEdit16 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DateEdit23 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit63 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit64 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit65 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit66 = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit24 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit25 = New DevExpress.XtraEditors.DateEdit()
        Me.ImageComboBoxEdit17 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.TextEdit67 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit68 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup41 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem150 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem37 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem161 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem162 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem163 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem164 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem166 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem167 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem168 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem169 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem170 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem171 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEdit69 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup42 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem172 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem173 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem174 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem38 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem39 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SpreadsheetBarController1 = New DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.XmlSqlUnderlying_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XmlSql_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileValidity_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRadioGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditFormUserControlLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EditFormUserControlLayoutControl1ConvertedLayout.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.FileName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditFormUserControlLayoutControl1ConvertedLayoutitem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.MemoEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl5.SuspendLayout()
        CType(Me.MemoEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl6.SuspendLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl8.SuspendLayout()
        CType(Me.MemoEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl9.SuspendLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl11.SuspendLayout()
        CType(Me.MemoEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl12.SuspendLayout()
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl14.SuspendLayout()
        CType(Me.MemoEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl15.SuspendLayout()
        CType(Me.ImageComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit11.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl17.SuspendLayout()
        CType(Me.MemoEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl18.SuspendLayout()
        CType(Me.ImageComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit14.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit16.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl20.SuspendLayout()
        CType(Me.MemoEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl21.SuspendLayout()
        CType(Me.ImageComboBoxEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit17.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit18.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit19.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit20.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit21.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit22.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl23, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl23.SuspendLayout()
        CType(Me.MemoEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl24.SuspendLayout()
        CType(Me.DateEdit5.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit23.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit24.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit25.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit26.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit27.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit6.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit7.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem78, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem79, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem80, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit28.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem81, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl26.SuspendLayout()
        CType(Me.MemoEdit10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl27, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl27.SuspendLayout()
        CType(Me.ImageComboBoxEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit8.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit30.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit31.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit32.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit33.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit9.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit10.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem86, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem87, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem88, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem89, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem91, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem93, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem94, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem95, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit34.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem96, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem97, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem98, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem99, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl29, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl29.SuspendLayout()
        CType(Me.MemoEdit11.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl30, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl30.SuspendLayout()
        CType(Me.ImageComboBoxEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit11.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit11.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit36.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit37.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit38.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit39.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit12.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit13.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem90, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem101, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem102, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem103, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem104, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem107, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem108, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem109, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem110, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit40.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem113, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem114, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl32, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl32.SuspendLayout()
        CType(Me.MemoEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl33, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl33.SuspendLayout()
        CType(Me.ImageComboBoxEdit10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit14.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit14.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit35.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit41.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit42.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit43.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit15.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit16.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit16.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit11.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit44.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit45.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem105, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem116, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem117, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem118, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem119, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem121, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem122, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem123, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem124, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem125, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem126, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem127, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit46.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem128, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem129, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem131, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl35, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl35.SuspendLayout()
        CType(Me.MemoEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl36, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl36.SuspendLayout()
        CType(Me.ImageComboBoxEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit17.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit17.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit47.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit48.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit49.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit50.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit18.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit18.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit19.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit19.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit51.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit52.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem120, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem132, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem133, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem134, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem136, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem137, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem138, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem139, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem140, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem141, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit53.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem142, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem143, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem144, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl37, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl37.SuspendLayout()
        CType(Me.MemoEdit14.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl38, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl38.SuspendLayout()
        CType(Me.ImageComboBoxEdit14.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit20.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit20.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit55.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit56.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit57.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit58.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit21.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit21.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit22.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit22.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit59.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit60.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem135, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem146, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem147, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem148, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem149, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem151, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem152, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem153, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem154, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem155, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem156, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit61.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem157, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem158, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem159, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl39, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl39.SuspendLayout()
        CType(Me.MemoEdit15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl40, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl40.SuspendLayout()
        CType(Me.ImageComboBoxEdit16.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit23.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit23.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit63.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit64.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit65.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit66.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit24.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit24.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit25.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit25.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageComboBoxEdit17.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit67.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit68.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem150, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem161, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem162, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem163, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem164, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem166, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem167, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem168, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem169, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem170, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem171, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit69.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem172, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem173, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem174, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpreadsheetBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XmlSqlUnderlying_GridView
        '
        Me.XmlSqlUnderlying_GridView.GridControl = Me.GridControl1
        Me.XmlSqlUnderlying_GridView.Name = "XmlSqlUnderlying_GridView"
        Me.XmlSqlUnderlying_GridView.OptionsBehavior.ReadOnly = True
        '
        'GridControl1
        '
        Me.SetBoundPropertyName(Me.GridControl1, "")
        GridLevelNode1.LevelTemplate = Me.XmlSqlUnderlying_GridView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.XmlSql_GridView
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1120, 502)
        Me.GridControl1.TabIndex = 14
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.XmlSql_GridView, Me.XmlSqlUnderlying_GridView})
        '
        'XmlSql_GridView
        '
        Me.XmlSql_GridView.GridControl = Me.GridControl1
        Me.XmlSql_GridView.Name = "XmlSql_GridView"
        Me.XmlSql_GridView.OptionsBehavior.ReadOnly = True
        Me.XmlSql_GridView.OptionsView.ColumnAutoWidth = False
        Me.XmlSql_GridView.OptionsView.ShowGroupPanel = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.CommonBar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenFile_bbi, Me.FileValidity_BarEditItem, Me.BarEditItem1})
        Me.BarManager1.MaxItemId = 17
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.FileValidity_RepositoryItemImageComboBox, Me.RepositoryItemRadioGroup1})
        '
        'CommonBar1
        '
        Me.CommonBar1.BarName = ""
        Me.CommonBar1.Control = Nothing
        Me.CommonBar1.DockCol = 0
        Me.CommonBar1.DockRow = 0
        Me.CommonBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.CommonBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.OpenFile_bbi), New DevExpress.XtraBars.LinkPersistInfo(Me.FileValidity_BarEditItem), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEditItem1)})
        Me.CommonBar1.Text = ""
        '
        'OpenFile_bbi
        '
        Me.OpenFile_bbi.Caption = "Open XML Script File"
        Me.OpenFile_bbi.Id = 10
        Me.OpenFile_bbi.ImageOptions.Image = CType(resources.GetObject("OpenFile_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.OpenFile_bbi.ImageOptions.LargeImage = CType(resources.GetObject("OpenFile_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.OpenFile_bbi.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFile_bbi.ItemAppearance.Normal.Options.UseFont = True
        Me.OpenFile_bbi.Name = "OpenFile_bbi"
        Me.OpenFile_bbi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'FileValidity_BarEditItem
        '
        Me.FileValidity_BarEditItem.Caption = "BarEditItem2"
        Me.FileValidity_BarEditItem.Edit = Me.FileValidity_RepositoryItemImageComboBox
        Me.FileValidity_BarEditItem.EditValue = "N"
        Me.FileValidity_BarEditItem.EditWidth = 120
        Me.FileValidity_BarEditItem.Id = 15
        Me.FileValidity_BarEditItem.ImageOptions.Image = CType(resources.GetObject("FileValidity_BarEditItem.ImageOptions.Image"), System.Drawing.Image)
        Me.FileValidity_BarEditItem.ImageOptions.LargeImage = CType(resources.GetObject("FileValidity_BarEditItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.FileValidity_BarEditItem.Name = "FileValidity_BarEditItem"
        '
        'FileValidity_RepositoryItemImageComboBox
        '
        Me.FileValidity_RepositoryItemImageComboBox.AutoHeight = False
        Me.FileValidity_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FileValidity_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FILE IS VALID", "Y", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FILE INVALID", "N", 6)})
        Me.FileValidity_RepositoryItemImageComboBox.Name = "FileValidity_RepositoryItemImageComboBox"
        Me.FileValidity_RepositoryItemImageComboBox.ReadOnly = True
        Me.FileValidity_RepositoryItemImageComboBox.SmallImages = Me.SharedImageCollection1
        Me.FileValidity_RepositoryItemImageComboBox.UseReadOnlyAppearance = False
        '
        'SharedImageCollection1
        '
        '
        '
        '
        Me.SharedImageCollection1.ImageSource.ImageStream = CType(resources.GetObject("SharedImageCollection1.ImageSource.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(0, "usergroup_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(1, "add_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(2, "BankABCLogoN.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(3, "properties_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(4, "closeheaderandfooter_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(5, "apply_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(6, "cancel_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(7, "table_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(8, "columnsthree_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(9, "Windows-Cascade-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(10, "application-tile-horizontal-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(11, "application-tile-vertical-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(12, "warning_16x16.png")
        Me.SharedImageCollection1.ParentControl = Me
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Me.RepositoryItemRadioGroup1
        Me.BarEditItem1.EditWidth = 300
        Me.BarEditItem1.Id = 16
        Me.BarEditItem1.Name = "BarEditItem1"
        Me.BarEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RepositoryItemRadioGroup1
        '
        Me.RepositoryItemRadioGroup1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepositoryItemRadioGroup1.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Add as new Parameter", True, CType(0, Short)), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Update current Parameter", True, CType(1, Short))})
        Me.RepositoryItemRadioGroup1.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Column
        Me.RepositoryItemRadioGroup1.Name = "RepositoryItemRadioGroup1"
        '
        'barDockControlTop
        '
        Me.SetBoundPropertyName(Me.barDockControlTop, "")
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1168, 31)
        '
        'barDockControlBottom
        '
        Me.SetBoundPropertyName(Me.barDockControlBottom, "")
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 605)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1168, 0)
        '
        'barDockControlLeft
        '
        Me.SetBoundPropertyName(Me.barDockControlLeft, "")
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 574)
        '
        'barDockControlRight
        '
        Me.SetBoundPropertyName(Me.barDockControlRight, "")
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1168, 31)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 574)
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'EditFormUserControlLayoutControl1ConvertedLayout
        '
        Me.SetBoundPropertyName(Me.EditFormUserControlLayoutControl1ConvertedLayout, "")
        Me.EditFormUserControlLayoutControl1ConvertedLayout.Controls.Add(Me.GridControl1)
        Me.EditFormUserControlLayoutControl1ConvertedLayout.Controls.Add(Me.SplitterControl2)
        Me.EditFormUserControlLayoutControl1ConvertedLayout.Location = New System.Drawing.Point(12, 36)
        Me.EditFormUserControlLayoutControl1ConvertedLayout.Name = "EditFormUserControlLayoutControl1ConvertedLayout"
        Me.EditFormUserControlLayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(963, 154, 650, 400)
        Me.EditFormUserControlLayoutControl1ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.EditFormUserControlLayoutControl1ConvertedLayout.Size = New System.Drawing.Size(1144, 526)
        Me.EditFormUserControlLayoutControl1ConvertedLayout.TabIndex = 1
        '
        'SplitterControl2
        '
        Me.SetBoundPropertyName(Me.SplitterControl2, "")
        Me.SplitterControl2.Location = New System.Drawing.Point(504, 102)
        Me.SplitterControl2.Name = "SplitterControl2"
        Me.SplitterControl2.Size = New System.Drawing.Size(10, 3)
        Me.SplitterControl2.TabIndex = 13
        Me.SplitterControl2.TabStop = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem59})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1144, 526)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem59
        '
        Me.LayoutControlItem59.Control = Me.GridControl1
        Me.LayoutControlItem59.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem59.Name = "LayoutControlItem59"
        Me.LayoutControlItem59.Size = New System.Drawing.Size(1124, 506)
        Me.LayoutControlItem59.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem59.TextVisible = False
        '
        'LayoutControl1
        '
        Me.SetBoundPropertyName(Me.LayoutControl1, "")
        Me.LayoutControl1.Controls.Add(Me.FileName_TextEdit)
        Me.LayoutControl1.Controls.Add(Me.EditFormUserControlLayoutControl1ConvertedLayout)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup2
        Me.LayoutControl1.Size = New System.Drawing.Size(1168, 574)
        Me.LayoutControl1.TabIndex = 2
        '
        'FileName_TextEdit
        '
        Me.SetBoundPropertyName(Me.FileName_TextEdit, "")
        Me.FileName_TextEdit.Location = New System.Drawing.Point(81, 12)
        Me.FileName_TextEdit.Name = "FileName_TextEdit"
        Me.FileName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileName_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FileName_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.FileName_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.FileName_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FileName_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FileName_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FileName_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FileName_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FileName_TextEdit.Properties.ReadOnly = True
        Me.FileName_TextEdit.Size = New System.Drawing.Size(1075, 20)
        Me.FileName_TextEdit.StyleController = Me.LayoutControl1
        Me.FileName_TextEdit.TabIndex = 9
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EditFormUserControlLayoutControl1ConvertedLayoutitem, Me.LayoutControlItem47})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1168, 574)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'EditFormUserControlLayoutControl1ConvertedLayoutitem
        '
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem.Control = Me.EditFormUserControlLayoutControl1ConvertedLayout
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem.Location = New System.Drawing.Point(0, 24)
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem.Size = New System.Drawing.Size(1148, 530)
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem.TextSize = New System.Drawing.Size(0, 0)
        Me.EditFormUserControlLayoutControl1ConvertedLayoutitem.TextVisible = False
        '
        'LayoutControlItem47
        '
        Me.LayoutControlItem47.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem47.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem47.Control = Me.FileName_TextEdit
        Me.LayoutControlItem47.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem47.Name = "LayoutControlItem47"
        Me.LayoutControlItem47.Size = New System.Drawing.Size(1148, 24)
        Me.LayoutControlItem47.Text = "File Name:"
        Me.LayoutControlItem47.TextSize = New System.Drawing.Size(57, 13)
        '
        'LayoutControl2
        '
        Me.SetBoundPropertyName(Me.LayoutControl2, "")
        Me.LayoutControl2.Controls.Add(Me.MemoEdit2)
        Me.LayoutControl2.Controls.Add(Me.LayoutControl3)
        Me.LayoutControl2.Controls.Add(Me.LayoutControl4)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup7
        Me.LayoutControl2.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControl2.TabIndex = 2
        '
        'MemoEdit2
        '
        Me.SetBoundPropertyName(Me.MemoEdit2, "")
        Me.MemoEdit2.Location = New System.Drawing.Point(12, 307)
        Me.MemoEdit2.Name = "MemoEdit2"
        Me.MemoEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit2.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit2.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit2.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit2.Properties.ReadOnly = True
        Me.MemoEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit2.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit2.Size = New System.Drawing.Size(1059, 137)
        Me.MemoEdit2.StyleController = Me.LayoutControl2
        Me.MemoEdit2.TabIndex = 0
        '
        'LayoutControl3
        '
        Me.SetBoundPropertyName(Me.LayoutControl3, "")
        Me.LayoutControl3.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.Root = Me.LayoutControlGroup5
        Me.LayoutControl3.Size = New System.Drawing.Size(1059, 207)
        Me.LayoutControl3.TabIndex = 1
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup5.GroupBordersVisible = False
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2})
        Me.LayoutControlGroup5.Name = "Root"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1059, 207)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1039, 187)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl4
        '
        Me.SetBoundPropertyName(Me.LayoutControl4, "")
        Me.LayoutControl4.Location = New System.Drawing.Point(12, 223)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.Root = Me.LayoutControlGroup6
        Me.LayoutControl4.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl4.TabIndex = 4
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup6.GroupBordersVisible = False
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup6.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "item"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(20, 13)
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup7.GroupBordersVisible = False
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup7.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControlGroup7.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LayoutControl3
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1063, 211)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LayoutControl4
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 211)
        Me.LayoutControlItem7.Name = "LayoutControlItem1"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem8.Control = Me.MemoEdit2
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 277)
        Me.LayoutControlItem8.Name = "LayoutControlItem2"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(1063, 159)
        Me.LayoutControlItem8.Text = "Validation Code Description"
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControl5
        '
        Me.SetBoundPropertyName(Me.LayoutControl5, "")
        Me.LayoutControl5.Controls.Add(Me.MemoEdit3)
        Me.LayoutControl5.Controls.Add(Me.LayoutControl6)
        Me.LayoutControl5.Controls.Add(Me.LayoutControl7)
        Me.LayoutControl5.Controls.Add(Me.TextEdit2)
        Me.LayoutControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl5.Name = "LayoutControl5"
        Me.LayoutControl5.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl5.Root = Me.LayoutControlGroup10
        Me.LayoutControl5.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControl5.TabIndex = 2
        '
        'MemoEdit3
        '
        Me.SetBoundPropertyName(Me.MemoEdit3, "")
        Me.MemoEdit3.Location = New System.Drawing.Point(12, 321)
        Me.MemoEdit3.Name = "MemoEdit3"
        Me.MemoEdit3.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit3.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit3.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit3.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit3.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit3.Properties.ReadOnly = True
        Me.MemoEdit3.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit3.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit3.Size = New System.Drawing.Size(1059, 123)
        Me.MemoEdit3.StyleController = Me.LayoutControl5
        Me.MemoEdit3.TabIndex = 0
        '
        'LayoutControl6
        '
        Me.SetBoundPropertyName(Me.LayoutControl6, "")
        Me.LayoutControl6.Controls.Add(Me.DateEdit1)
        Me.LayoutControl6.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl6.Name = "LayoutControl6"
        Me.LayoutControl6.Root = Me.LayoutControlGroup8
        Me.LayoutControl6.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControl6.TabIndex = 1
        '
        'DateEdit1
        '
        Me.SetBoundPropertyName(Me.DateEdit1, "")
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(91, 12)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit1.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit1.Properties.ReadOnly = True
        Me.DateEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit1.Properties.UseReadOnlyAppearance = False
        Me.DateEdit1.Size = New System.Drawing.Size(956, 20)
        Me.DateEdit1.StyleController = Me.LayoutControl6
        Me.DateEdit1.TabIndex = 5
        '
        'LayoutControlGroup8
        '
        Me.LayoutControlGroup8.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup8.GroupBordersVisible = False
        Me.LayoutControlGroup8.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem4, Me.LayoutControlItem11})
        Me.LayoutControlGroup8.Name = "Root"
        Me.LayoutControlGroup8.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControlGroup8.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(1039, 151)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem11.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem11.Control = Me.DateEdit1
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem4"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem11.Text = "Melde Monat"
        Me.LayoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem11.TextToControlDistance = 5
        '
        'LayoutControl7
        '
        Me.SetBoundPropertyName(Me.LayoutControl7, "")
        Me.LayoutControl7.Location = New System.Drawing.Point(12, 211)
        Me.LayoutControl7.Name = "LayoutControl7"
        Me.LayoutControl7.Root = Me.LayoutControlGroup9
        Me.LayoutControl7.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl7.TabIndex = 4
        '
        'LayoutControlGroup9
        '
        Me.LayoutControlGroup9.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup9.GroupBordersVisible = False
        Me.LayoutControlGroup9.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.LayoutControlGroup9.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup9.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup9.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "item"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem12.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit2
        '
        Me.SetBoundPropertyName(Me.TextEdit2, "")
        Me.TextEdit2.Location = New System.Drawing.Point(88, 277)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit2.Properties.Appearance.Options.UseFont = True
        Me.TextEdit2.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit2.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit2.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit2.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit2.Properties.ReadOnly = True
        Me.TextEdit2.Properties.UseReadOnlyAppearance = False
        Me.TextEdit2.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit2.StyleController = Me.LayoutControl5
        Me.TextEdit2.TabIndex = 4
        '
        'LayoutControlGroup10
        '
        Me.LayoutControlGroup10.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup10.GroupBordersVisible = False
        Me.LayoutControlGroup10.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.EmptySpaceItem5})
        Me.LayoutControlGroup10.Name = "Root"
        Me.LayoutControlGroup10.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControlGroup10.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.LayoutControl6
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(1063, 199)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.LayoutControl7
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 199)
        Me.LayoutControlItem14.Name = "LayoutControlItem1"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem15.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem15.Control = Me.MemoEdit3
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 291)
        Me.LayoutControlItem15.Name = "LayoutControlItem2"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(1063, 145)
        Me.LayoutControlItem15.Text = "Validation Code Description"
        Me.LayoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem16.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem16.Control = Me.TextEdit2
        Me.LayoutControlItem16.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 265)
        Me.LayoutControlItem16.Name = "LayoutControlItem9"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem16.Text = "Validation ID:"
        Me.LayoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem16.TextToControlDistance = 3
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(218, 265)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl8
        '
        Me.SetBoundPropertyName(Me.LayoutControl8, "")
        Me.LayoutControl8.Controls.Add(Me.MemoEdit4)
        Me.LayoutControl8.Controls.Add(Me.LayoutControl9)
        Me.LayoutControl8.Controls.Add(Me.LayoutControl10)
        Me.LayoutControl8.Controls.Add(Me.TextEdit4)
        Me.LayoutControl8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl8.Name = "LayoutControl8"
        Me.LayoutControl8.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl8.Root = Me.LayoutControlGroup13
        Me.LayoutControl8.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControl8.TabIndex = 2
        '
        'MemoEdit4
        '
        Me.SetBoundPropertyName(Me.MemoEdit4, "")
        Me.MemoEdit4.Location = New System.Drawing.Point(12, 321)
        Me.MemoEdit4.Name = "MemoEdit4"
        Me.MemoEdit4.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit4.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit4.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit4.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit4.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit4.Properties.ReadOnly = True
        Me.MemoEdit4.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit4.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit4.Size = New System.Drawing.Size(1059, 123)
        Me.MemoEdit4.StyleController = Me.LayoutControl8
        Me.MemoEdit4.TabIndex = 0
        '
        'LayoutControl9
        '
        Me.SetBoundPropertyName(Me.LayoutControl9, "")
        Me.LayoutControl9.Controls.Add(Me.DateEdit2)
        Me.LayoutControl9.Controls.Add(Me.TextEdit3)
        Me.LayoutControl9.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl9.Name = "LayoutControl9"
        Me.LayoutControl9.Root = Me.LayoutControlGroup11
        Me.LayoutControl9.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControl9.TabIndex = 1
        '
        'DateEdit2
        '
        Me.SetBoundPropertyName(Me.DateEdit2, "")
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(802, 12)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit2.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit2.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit2.Properties.ReadOnly = True
        Me.DateEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit2.Properties.UseReadOnlyAppearance = False
        Me.DateEdit2.Size = New System.Drawing.Size(245, 20)
        Me.DateEdit2.StyleController = Me.LayoutControl9
        Me.DateEdit2.TabIndex = 5
        '
        'TextEdit3
        '
        Me.SetBoundPropertyName(Me.TextEdit3, "")
        Me.TextEdit3.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit3.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit3.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit3.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit3.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit3.Properties.ReadOnly = True
        Me.TextEdit3.Properties.UseReadOnlyAppearance = False
        Me.TextEdit3.Size = New System.Drawing.Size(575, 20)
        Me.TextEdit3.StyleController = Me.LayoutControl9
        Me.TextEdit3.TabIndex = 4
        '
        'LayoutControlGroup11
        '
        Me.LayoutControlGroup11.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup11.GroupBordersVisible = False
        Me.LayoutControlGroup11.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.EmptySpaceItem6, Me.LayoutControlItem18})
        Me.LayoutControlGroup11.Name = "Root"
        Me.LayoutControlGroup11.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControlGroup11.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem10.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem10.Control = Me.TextEdit3
        Me.LayoutControlItem10.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem3"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(711, 24)
        Me.LayoutControlItem10.Text = "Message Template ID:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(1039, 151)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem18.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem18.Control = Me.DateEdit2
        Me.LayoutControlItem18.Location = New System.Drawing.Point(711, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem4"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(328, 24)
        Me.LayoutControlItem18.Text = "Melde Monat"
        Me.LayoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem18.TextToControlDistance = 5
        '
        'LayoutControl10
        '
        Me.SetBoundPropertyName(Me.LayoutControl10, "")
        Me.LayoutControl10.Location = New System.Drawing.Point(12, 211)
        Me.LayoutControl10.Name = "LayoutControl10"
        Me.LayoutControl10.Root = Me.LayoutControlGroup12
        Me.LayoutControl10.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl10.TabIndex = 4
        '
        'LayoutControlGroup12
        '
        Me.LayoutControlGroup12.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup12.GroupBordersVisible = False
        Me.LayoutControlGroup12.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem20})
        Me.LayoutControlGroup12.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup12.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup12.TextVisible = False
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem20.Name = "item"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem20.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit4
        '
        Me.SetBoundPropertyName(Me.TextEdit4, "")
        Me.TextEdit4.Location = New System.Drawing.Point(88, 277)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit4.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit4.Properties.Appearance.Options.UseFont = True
        Me.TextEdit4.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit4.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit4.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit4.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit4.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit4.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit4.Properties.ReadOnly = True
        Me.TextEdit4.Properties.UseReadOnlyAppearance = False
        Me.TextEdit4.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit4.StyleController = Me.LayoutControl8
        Me.TextEdit4.TabIndex = 4
        '
        'LayoutControlGroup13
        '
        Me.LayoutControlGroup13.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup13.GroupBordersVisible = False
        Me.LayoutControlGroup13.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem23, Me.LayoutControlItem24, Me.EmptySpaceItem7})
        Me.LayoutControlGroup13.Name = "Root"
        Me.LayoutControlGroup13.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControlGroup13.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.LayoutControl9
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(1063, 199)
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.LayoutControl10
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 199)
        Me.LayoutControlItem22.Name = "LayoutControlItem1"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem22.TextVisible = False
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem23.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem23.Control = Me.MemoEdit4
        Me.LayoutControlItem23.Location = New System.Drawing.Point(0, 291)
        Me.LayoutControlItem23.Name = "LayoutControlItem2"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(1063, 145)
        Me.LayoutControlItem23.Text = "Validation Code Description"
        Me.LayoutControlItem23.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem24.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem24.Control = Me.TextEdit4
        Me.LayoutControlItem24.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem24.Location = New System.Drawing.Point(0, 265)
        Me.LayoutControlItem24.Name = "LayoutControlItem9"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem24.Text = "Validation ID:"
        Me.LayoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem24.TextToControlDistance = 3
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(218, 265)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl11
        '
        Me.SetBoundPropertyName(Me.LayoutControl11, "")
        Me.LayoutControl11.Controls.Add(Me.MemoEdit5)
        Me.LayoutControl11.Controls.Add(Me.LayoutControl12)
        Me.LayoutControl11.Controls.Add(Me.LayoutControl13)
        Me.LayoutControl11.Controls.Add(Me.TextEdit7)
        Me.LayoutControl11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl11.Name = "LayoutControl11"
        Me.LayoutControl11.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl11.Root = Me.LayoutControlGroup16
        Me.LayoutControl11.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControl11.TabIndex = 2
        '
        'MemoEdit5
        '
        Me.SetBoundPropertyName(Me.MemoEdit5, "")
        Me.MemoEdit5.Location = New System.Drawing.Point(12, 321)
        Me.MemoEdit5.Name = "MemoEdit5"
        Me.MemoEdit5.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit5.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit5.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit5.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit5.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit5.Properties.ReadOnly = True
        Me.MemoEdit5.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit5.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit5.Size = New System.Drawing.Size(1059, 123)
        Me.MemoEdit5.StyleController = Me.LayoutControl11
        Me.MemoEdit5.TabIndex = 0
        '
        'LayoutControl12
        '
        Me.SetBoundPropertyName(Me.LayoutControl12, "")
        Me.LayoutControl12.Controls.Add(Me.ImageComboBoxEdit1)
        Me.LayoutControl12.Controls.Add(Me.DateEdit3)
        Me.LayoutControl12.Controls.Add(Me.TextEdit5)
        Me.LayoutControl12.Controls.Add(Me.TextEdit6)
        Me.LayoutControl12.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl12.Name = "LayoutControl12"
        Me.LayoutControl12.Root = Me.LayoutControlGroup14
        Me.LayoutControl12.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControl12.TabIndex = 1
        '
        'ImageComboBoxEdit1
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit1, "")
        Me.ImageComboBoxEdit1.Location = New System.Drawing.Point(78, 60)
        Me.ImageComboBoxEdit1.Name = "ImageComboBoxEdit1"
        Me.ImageComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit1.Properties.ReadOnly = True
        Me.ImageComboBoxEdit1.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit1.Size = New System.Drawing.Size(969, 20)
        Me.ImageComboBoxEdit1.StyleController = Me.LayoutControl12
        Me.ImageComboBoxEdit1.TabIndex = 6
        '
        'DateEdit3
        '
        Me.SetBoundPropertyName(Me.DateEdit3, "")
        Me.DateEdit3.EditValue = Nothing
        Me.DateEdit3.Location = New System.Drawing.Point(802, 12)
        Me.DateEdit3.Name = "DateEdit3"
        Me.DateEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit3.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit3.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit3.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit3.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit3.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit3.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit3.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit3.Properties.ReadOnly = True
        Me.DateEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit3.Properties.UseReadOnlyAppearance = False
        Me.DateEdit3.Size = New System.Drawing.Size(245, 20)
        Me.DateEdit3.StyleController = Me.LayoutControl12
        Me.DateEdit3.TabIndex = 5
        '
        'TextEdit5
        '
        Me.SetBoundPropertyName(Me.TextEdit5, "")
        Me.TextEdit5.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit5.Name = "TextEdit5"
        Me.TextEdit5.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit5.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit5.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit5.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit5.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit5.Properties.ReadOnly = True
        Me.TextEdit5.Properties.UseReadOnlyAppearance = False
        Me.TextEdit5.Size = New System.Drawing.Size(575, 20)
        Me.TextEdit5.StyleController = Me.LayoutControl12
        Me.TextEdit5.TabIndex = 4
        '
        'TextEdit6
        '
        Me.SetBoundPropertyName(Me.TextEdit6, "")
        Me.TextEdit6.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit6.Name = "TextEdit6"
        Me.TextEdit6.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit6.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit6.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit6.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit6.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit6.Properties.ReadOnly = True
        Me.TextEdit6.Properties.UseReadOnlyAppearance = False
        Me.TextEdit6.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit6.StyleController = Me.LayoutControl12
        Me.TextEdit6.TabIndex = 4
        '
        'LayoutControlGroup14
        '
        Me.LayoutControlGroup14.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup14.GroupBordersVisible = False
        Me.LayoutControlGroup14.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem26, Me.EmptySpaceItem8, Me.LayoutControlItem27, Me.LayoutControlItem28, Me.LayoutControlItem30})
        Me.LayoutControlGroup14.Name = "Root"
        Me.LayoutControlGroup14.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControlGroup14.TextVisible = False
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem26.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem26.Control = Me.TextEdit5
        Me.LayoutControlItem26.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem26.Name = "LayoutControlItem3"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(711, 24)
        Me.LayoutControlItem26.Text = "Message Template ID:"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(1039, 103)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem27.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem27.Control = Me.DateEdit3
        Me.LayoutControlItem27.Location = New System.Drawing.Point(711, 0)
        Me.LayoutControlItem27.Name = "LayoutControlItem4"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(328, 24)
        Me.LayoutControlItem27.Text = "Melde Monat"
        Me.LayoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem27.TextToControlDistance = 5
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.TextEdit6
        Me.LayoutControlItem28.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem28.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem28.Name = "LayoutControlItem17"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem28.Text = "Message File Name:"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.Control = Me.ImageComboBoxEdit1
        Me.LayoutControlItem30.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem30.Name = "LayoutControlItem19"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem30.Text = "Client Status"
        Me.LayoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem30.TextToControlDistance = 5
        '
        'LayoutControl13
        '
        Me.SetBoundPropertyName(Me.LayoutControl13, "")
        Me.LayoutControl13.Location = New System.Drawing.Point(12, 211)
        Me.LayoutControl13.Name = "LayoutControl13"
        Me.LayoutControl13.Root = Me.LayoutControlGroup15
        Me.LayoutControl13.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl13.TabIndex = 4
        '
        'LayoutControlGroup15
        '
        Me.LayoutControlGroup15.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup15.GroupBordersVisible = False
        Me.LayoutControlGroup15.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem31})
        Me.LayoutControlGroup15.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup15.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup15.TextVisible = False
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem31.Name = "item"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem31.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit7
        '
        Me.SetBoundPropertyName(Me.TextEdit7, "")
        Me.TextEdit7.Location = New System.Drawing.Point(88, 277)
        Me.TextEdit7.Name = "TextEdit7"
        Me.TextEdit7.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit7.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit7.Properties.Appearance.Options.UseFont = True
        Me.TextEdit7.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit7.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit7.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit7.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit7.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit7.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit7.Properties.ReadOnly = True
        Me.TextEdit7.Properties.UseReadOnlyAppearance = False
        Me.TextEdit7.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit7.StyleController = Me.LayoutControl11
        Me.TextEdit7.TabIndex = 4
        '
        'LayoutControlGroup16
        '
        Me.LayoutControlGroup16.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup16.GroupBordersVisible = False
        Me.LayoutControlGroup16.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem32, Me.LayoutControlItem33, Me.LayoutControlItem34, Me.LayoutControlItem35, Me.EmptySpaceItem9})
        Me.LayoutControlGroup16.Name = "Root"
        Me.LayoutControlGroup16.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControlGroup16.TextVisible = False
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.LayoutControl12
        Me.LayoutControlItem32.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem32.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(1063, 199)
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem32.TextVisible = False
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.LayoutControl13
        Me.LayoutControlItem33.Location = New System.Drawing.Point(0, 199)
        Me.LayoutControlItem33.Name = "LayoutControlItem1"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem33.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem34.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem34.Control = Me.MemoEdit5
        Me.LayoutControlItem34.Location = New System.Drawing.Point(0, 291)
        Me.LayoutControlItem34.Name = "LayoutControlItem2"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(1063, 145)
        Me.LayoutControlItem34.Text = "Validation Code Description"
        Me.LayoutControlItem34.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem35
        '
        Me.LayoutControlItem35.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem35.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem35.Control = Me.TextEdit7
        Me.LayoutControlItem35.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem35.Location = New System.Drawing.Point(0, 265)
        Me.LayoutControlItem35.Name = "LayoutControlItem9"
        Me.LayoutControlItem35.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem35.Text = "Validation ID:"
        Me.LayoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem35.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem35.TextToControlDistance = 3
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(218, 265)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl14
        '
        Me.SetBoundPropertyName(Me.LayoutControl14, "")
        Me.LayoutControl14.Controls.Add(Me.MemoEdit6)
        Me.LayoutControl14.Controls.Add(Me.LayoutControl15)
        Me.LayoutControl14.Controls.Add(Me.LayoutControl16)
        Me.LayoutControl14.Controls.Add(Me.TextEdit11)
        Me.LayoutControl14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl14.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl14.Name = "LayoutControl14"
        Me.LayoutControl14.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl14.Root = Me.LayoutControlGroup19
        Me.LayoutControl14.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControl14.TabIndex = 2
        '
        'MemoEdit6
        '
        Me.SetBoundPropertyName(Me.MemoEdit6, "")
        Me.MemoEdit6.Location = New System.Drawing.Point(12, 321)
        Me.MemoEdit6.Name = "MemoEdit6"
        Me.MemoEdit6.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit6.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit6.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit6.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit6.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit6.Properties.ReadOnly = True
        Me.MemoEdit6.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit6.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit6.Size = New System.Drawing.Size(1059, 123)
        Me.MemoEdit6.StyleController = Me.LayoutControl14
        Me.MemoEdit6.TabIndex = 0
        '
        'LayoutControl15
        '
        Me.SetBoundPropertyName(Me.LayoutControl15, "")
        Me.LayoutControl15.Controls.Add(Me.ImageComboBoxEdit2)
        Me.LayoutControl15.Controls.Add(Me.DateEdit4)
        Me.LayoutControl15.Controls.Add(Me.TextEdit8)
        Me.LayoutControl15.Controls.Add(Me.TextEdit9)
        Me.LayoutControl15.Controls.Add(Me.TextEdit10)
        Me.LayoutControl15.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl15.Name = "LayoutControl15"
        Me.LayoutControl15.Root = Me.LayoutControlGroup17
        Me.LayoutControl15.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControl15.TabIndex = 1
        '
        'ImageComboBoxEdit2
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit2, "")
        Me.ImageComboBoxEdit2.Location = New System.Drawing.Point(727, 60)
        Me.ImageComboBoxEdit2.Name = "ImageComboBoxEdit2"
        Me.ImageComboBoxEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit2.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit2.Properties.ReadOnly = True
        Me.ImageComboBoxEdit2.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit2.Size = New System.Drawing.Size(320, 20)
        Me.ImageComboBoxEdit2.StyleController = Me.LayoutControl15
        Me.ImageComboBoxEdit2.TabIndex = 6
        '
        'DateEdit4
        '
        Me.SetBoundPropertyName(Me.DateEdit4, "")
        Me.DateEdit4.EditValue = Nothing
        Me.DateEdit4.Location = New System.Drawing.Point(669, 12)
        Me.DateEdit4.Name = "DateEdit4"
        Me.DateEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit4.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit4.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit4.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit4.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit4.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit4.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit4.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit4.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit4.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit4.Properties.ReadOnly = True
        Me.DateEdit4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit4.Properties.UseReadOnlyAppearance = False
        Me.DateEdit4.Size = New System.Drawing.Size(378, 20)
        Me.DateEdit4.StyleController = Me.LayoutControl15
        Me.DateEdit4.TabIndex = 5
        '
        'TextEdit8
        '
        Me.SetBoundPropertyName(Me.TextEdit8, "")
        Me.TextEdit8.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit8.Name = "TextEdit8"
        Me.TextEdit8.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit8.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit8.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit8.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit8.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit8.Properties.ReadOnly = True
        Me.TextEdit8.Properties.UseReadOnlyAppearance = False
        Me.TextEdit8.Size = New System.Drawing.Size(442, 20)
        Me.TextEdit8.StyleController = Me.LayoutControl15
        Me.TextEdit8.TabIndex = 4
        '
        'TextEdit9
        '
        Me.SetBoundPropertyName(Me.TextEdit9, "")
        Me.TextEdit9.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit9.Name = "TextEdit9"
        Me.TextEdit9.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit9.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit9.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit9.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit9.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit9.Properties.ReadOnly = True
        Me.TextEdit9.Properties.UseReadOnlyAppearance = False
        Me.TextEdit9.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit9.StyleController = Me.LayoutControl15
        Me.TextEdit9.TabIndex = 4
        '
        'TextEdit10
        '
        Me.SetBoundPropertyName(Me.TextEdit10, "")
        Me.TextEdit10.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit10.Name = "TextEdit10"
        Me.TextEdit10.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit10.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit10.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit10.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit10.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit10.Properties.ReadOnly = True
        Me.TextEdit10.Properties.UseReadOnlyAppearance = False
        Me.TextEdit10.Size = New System.Drawing.Size(513, 20)
        Me.TextEdit10.StyleController = Me.LayoutControl15
        Me.TextEdit10.TabIndex = 4
        '
        'LayoutControlGroup17
        '
        Me.LayoutControlGroup17.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup17.GroupBordersVisible = False
        Me.LayoutControlGroup17.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem29, Me.EmptySpaceItem10, Me.LayoutControlItem37, Me.LayoutControlItem38, Me.LayoutControlItem39, Me.LayoutControlItem40})
        Me.LayoutControlGroup17.Name = "Root"
        Me.LayoutControlGroup17.Size = New System.Drawing.Size(1059, 195)
        Me.LayoutControlGroup17.TextVisible = False
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem29.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem29.Control = Me.TextEdit8
        Me.LayoutControlItem29.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem29.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem29.Name = "LayoutControlItem3"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(578, 24)
        Me.LayoutControlItem29.Text = "Message Template ID:"
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(1039, 103)
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem37.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem37.Control = Me.DateEdit4
        Me.LayoutControlItem37.Location = New System.Drawing.Point(578, 0)
        Me.LayoutControlItem37.Name = "LayoutControlItem4"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(461, 24)
        Me.LayoutControlItem37.Text = "Melde Monat"
        Me.LayoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem37.TextToControlDistance = 5
        '
        'LayoutControlItem38
        '
        Me.LayoutControlItem38.Control = Me.TextEdit9
        Me.LayoutControlItem38.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem38.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem38.Name = "LayoutControlItem17"
        Me.LayoutControlItem38.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem38.Text = "Message File Name:"
        Me.LayoutControlItem38.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.TextEdit10
        Me.LayoutControlItem39.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem39.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem39.Name = "LayoutControlItem25"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(649, 24)
        Me.LayoutControlItem39.Text = "Client Name:"
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem40
        '
        Me.LayoutControlItem40.Control = Me.ImageComboBoxEdit2
        Me.LayoutControlItem40.Location = New System.Drawing.Point(649, 48)
        Me.LayoutControlItem40.Name = "LayoutControlItem19"
        Me.LayoutControlItem40.Size = New System.Drawing.Size(390, 24)
        Me.LayoutControlItem40.Text = "Client Status"
        Me.LayoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem40.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem40.TextToControlDistance = 5
        '
        'LayoutControl16
        '
        Me.SetBoundPropertyName(Me.LayoutControl16, "")
        Me.LayoutControl16.Location = New System.Drawing.Point(12, 211)
        Me.LayoutControl16.Name = "LayoutControl16"
        Me.LayoutControl16.Root = Me.LayoutControlGroup18
        Me.LayoutControl16.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl16.TabIndex = 4
        '
        'LayoutControlGroup18
        '
        Me.LayoutControlGroup18.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup18.GroupBordersVisible = False
        Me.LayoutControlGroup18.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem42})
        Me.LayoutControlGroup18.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup18.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup18.TextVisible = False
        '
        'LayoutControlItem42
        '
        Me.LayoutControlItem42.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem42.Name = "item"
        Me.LayoutControlItem42.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem42.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem42.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit11
        '
        Me.SetBoundPropertyName(Me.TextEdit11, "")
        Me.TextEdit11.Location = New System.Drawing.Point(88, 277)
        Me.TextEdit11.Name = "TextEdit11"
        Me.TextEdit11.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit11.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit11.Properties.Appearance.Options.UseFont = True
        Me.TextEdit11.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit11.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit11.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit11.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit11.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit11.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit11.Properties.ReadOnly = True
        Me.TextEdit11.Properties.UseReadOnlyAppearance = False
        Me.TextEdit11.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit11.StyleController = Me.LayoutControl14
        Me.TextEdit11.TabIndex = 4
        '
        'LayoutControlGroup19
        '
        Me.LayoutControlGroup19.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup19.GroupBordersVisible = False
        Me.LayoutControlGroup19.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem43, Me.LayoutControlItem44, Me.LayoutControlItem45, Me.LayoutControlItem46, Me.EmptySpaceItem11})
        Me.LayoutControlGroup19.Name = "Root"
        Me.LayoutControlGroup19.Size = New System.Drawing.Size(1083, 456)
        Me.LayoutControlGroup19.TextVisible = False
        '
        'LayoutControlItem43
        '
        Me.LayoutControlItem43.Control = Me.LayoutControl15
        Me.LayoutControlItem43.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem43.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem43.Size = New System.Drawing.Size(1063, 199)
        Me.LayoutControlItem43.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem43.TextVisible = False
        '
        'LayoutControlItem44
        '
        Me.LayoutControlItem44.Control = Me.LayoutControl16
        Me.LayoutControlItem44.Location = New System.Drawing.Point(0, 199)
        Me.LayoutControlItem44.Name = "LayoutControlItem1"
        Me.LayoutControlItem44.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem44.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem44.TextVisible = False
        '
        'LayoutControlItem45
        '
        Me.LayoutControlItem45.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem45.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem45.Control = Me.MemoEdit6
        Me.LayoutControlItem45.Location = New System.Drawing.Point(0, 291)
        Me.LayoutControlItem45.Name = "LayoutControlItem2"
        Me.LayoutControlItem45.Size = New System.Drawing.Size(1063, 145)
        Me.LayoutControlItem45.Text = "Validation Code Description"
        Me.LayoutControlItem45.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem45.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem46
        '
        Me.LayoutControlItem46.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem46.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem46.Control = Me.TextEdit11
        Me.LayoutControlItem46.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem46.Location = New System.Drawing.Point(0, 265)
        Me.LayoutControlItem46.Name = "LayoutControlItem9"
        Me.LayoutControlItem46.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem46.Text = "Validation ID:"
        Me.LayoutControlItem46.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem46.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem46.TextToControlDistance = 3
        '
        'EmptySpaceItem11
        '
        Me.EmptySpaceItem11.AllowHotTrack = False
        Me.EmptySpaceItem11.Location = New System.Drawing.Point(218, 265)
        Me.EmptySpaceItem11.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem11.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem11.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl17
        '
        Me.SetBoundPropertyName(Me.LayoutControl17, "")
        Me.LayoutControl17.Controls.Add(Me.MemoEdit7)
        Me.LayoutControl17.Controls.Add(Me.LayoutControl18)
        Me.LayoutControl17.Controls.Add(Me.LayoutControl19)
        Me.LayoutControl17.Controls.Add(Me.TextEdit16)
        Me.LayoutControl17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl17.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl17.Name = "LayoutControl17"
        Me.LayoutControl17.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl17.Root = Me.LayoutControlGroup22
        Me.LayoutControl17.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl17.TabIndex = 2
        '
        'MemoEdit7
        '
        Me.SetBoundPropertyName(Me.MemoEdit7, "")
        Me.MemoEdit7.Location = New System.Drawing.Point(12, 357)
        Me.MemoEdit7.Name = "MemoEdit7"
        Me.MemoEdit7.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit7.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit7.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit7.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit7.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit7.Properties.ReadOnly = True
        Me.MemoEdit7.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit7.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit7.Size = New System.Drawing.Size(1059, 156)
        Me.MemoEdit7.StyleController = Me.LayoutControl17
        Me.MemoEdit7.TabIndex = 0
        '
        'LayoutControl18
        '
        Me.SetBoundPropertyName(Me.LayoutControl18, "")
        Me.LayoutControl18.Controls.Add(Me.ImageComboBoxEdit3)
        Me.LayoutControl18.Controls.Add(Me.TextEdit1)
        Me.LayoutControl18.Controls.Add(Me.TextEdit12)
        Me.LayoutControl18.Controls.Add(Me.TextEdit13)
        Me.LayoutControl18.Controls.Add(Me.TextEdit14)
        Me.LayoutControl18.Controls.Add(Me.TextEdit15)
        Me.LayoutControl18.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl18.Name = "LayoutControl18"
        Me.LayoutControl18.Root = Me.LayoutControlGroup20
        Me.LayoutControl18.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl18.TabIndex = 1
        '
        'ImageComboBoxEdit3
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit3, "")
        Me.ImageComboBoxEdit3.Location = New System.Drawing.Point(866, 60)
        Me.ImageComboBoxEdit3.Name = "ImageComboBoxEdit3"
        Me.ImageComboBoxEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit3.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit3.Properties.ReadOnly = True
        Me.ImageComboBoxEdit3.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit3.Size = New System.Drawing.Size(181, 20)
        Me.ImageComboBoxEdit3.StyleController = Me.LayoutControl18
        Me.ImageComboBoxEdit3.TabIndex = 6
        '
        'TextEdit1
        '
        Me.SetBoundPropertyName(Me.TextEdit1, "")
        Me.TextEdit1.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit1.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit1.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit1.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit1.Properties.ReadOnly = True
        Me.TextEdit1.Properties.UseReadOnlyAppearance = False
        Me.TextEdit1.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit1.StyleController = Me.LayoutControl18
        Me.TextEdit1.TabIndex = 4
        '
        'TextEdit12
        '
        Me.SetBoundPropertyName(Me.TextEdit12, "")
        Me.TextEdit12.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit12.Name = "TextEdit12"
        Me.TextEdit12.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit12.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit12.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit12.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit12.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit12.Properties.ReadOnly = True
        Me.TextEdit12.Properties.UseReadOnlyAppearance = False
        Me.TextEdit12.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit12.StyleController = Me.LayoutControl18
        Me.TextEdit12.TabIndex = 4
        '
        'TextEdit13
        '
        Me.SetBoundPropertyName(Me.TextEdit13, "")
        Me.TextEdit13.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit13.Name = "TextEdit13"
        Me.TextEdit13.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit13.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit13.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit13.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit13.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit13.Properties.ReadOnly = True
        Me.TextEdit13.Properties.UseReadOnlyAppearance = False
        Me.TextEdit13.Size = New System.Drawing.Size(652, 20)
        Me.TextEdit13.StyleController = Me.LayoutControl18
        Me.TextEdit13.TabIndex = 4
        '
        'TextEdit14
        '
        Me.SetBoundPropertyName(Me.TextEdit14, "")
        Me.TextEdit14.Location = New System.Drawing.Point(144, 84)
        Me.TextEdit14.Name = "TextEdit14"
        Me.TextEdit14.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit14.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit14.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit14.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit14.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit14.Properties.ReadOnly = True
        Me.TextEdit14.Properties.UseReadOnlyAppearance = False
        Me.TextEdit14.Size = New System.Drawing.Size(437, 20)
        Me.TextEdit14.StyleController = Me.LayoutControl18
        Me.TextEdit14.TabIndex = 4
        '
        'TextEdit15
        '
        Me.SetBoundPropertyName(Me.TextEdit15, "")
        Me.TextEdit15.Location = New System.Drawing.Point(648, 84)
        Me.TextEdit15.Name = "TextEdit15"
        Me.TextEdit15.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit15.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit15.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit15.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit15.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit15.Properties.ReadOnly = True
        Me.TextEdit15.Properties.UseReadOnlyAppearance = False
        Me.TextEdit15.Size = New System.Drawing.Size(399, 20)
        Me.TextEdit15.StyleController = Me.LayoutControl18
        Me.TextEdit15.TabIndex = 4
        '
        'LayoutControlGroup20
        '
        Me.LayoutControlGroup20.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup20.GroupBordersVisible = False
        Me.LayoutControlGroup20.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem41, Me.EmptySpaceItem13, Me.LayoutControlItem49, Me.LayoutControlItem50, Me.LayoutControlItem51, Me.LayoutControlItem52, Me.LayoutControlItem53})
        Me.LayoutControlGroup20.Name = "Root"
        Me.LayoutControlGroup20.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup20.TextVisible = False
        '
        'LayoutControlItem41
        '
        Me.LayoutControlItem41.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem41.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem41.Control = Me.TextEdit1
        Me.LayoutControlItem41.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem41.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem41.Name = "LayoutControlItem3"
        Me.LayoutControlItem41.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem41.Text = "Message Template ID:"
        Me.LayoutControlItem41.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem13
        '
        Me.EmptySpaceItem13.AllowHotTrack = False
        Me.EmptySpaceItem13.Location = New System.Drawing.Point(0, 96)
        Me.EmptySpaceItem13.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem13.Size = New System.Drawing.Size(1039, 115)
        Me.EmptySpaceItem13.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem49
        '
        Me.LayoutControlItem49.Control = Me.TextEdit12
        Me.LayoutControlItem49.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem49.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem49.Name = "LayoutControlItem17"
        Me.LayoutControlItem49.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem49.Text = "Message File Name:"
        Me.LayoutControlItem49.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem50
        '
        Me.LayoutControlItem50.Control = Me.TextEdit13
        Me.LayoutControlItem50.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem50.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem50.Name = "LayoutControlItem25"
        Me.LayoutControlItem50.Size = New System.Drawing.Size(788, 24)
        Me.LayoutControlItem50.Text = "Client Name:"
        Me.LayoutControlItem50.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem51
        '
        Me.LayoutControlItem51.Control = Me.ImageComboBoxEdit3
        Me.LayoutControlItem51.Location = New System.Drawing.Point(788, 48)
        Me.LayoutControlItem51.Name = "LayoutControlItem19"
        Me.LayoutControlItem51.Size = New System.Drawing.Size(251, 24)
        Me.LayoutControlItem51.Text = "Client Status"
        Me.LayoutControlItem51.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem51.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem51.TextToControlDistance = 5
        '
        'LayoutControlItem52
        '
        Me.LayoutControlItem52.Control = Me.TextEdit14
        Me.LayoutControlItem52.CustomizationFormText = "Instrument ID:"
        Me.LayoutControlItem52.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem52.Name = "LayoutControlItem36"
        Me.LayoutControlItem52.Size = New System.Drawing.Size(573, 24)
        Me.LayoutControlItem52.Text = "Instrument ID:"
        Me.LayoutControlItem52.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.TextEdit15
        Me.LayoutControlItem53.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem53.Location = New System.Drawing.Point(573, 72)
        Me.LayoutControlItem53.Name = "LayoutControlItem47"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(466, 24)
        Me.LayoutControlItem53.Text = "Contract Nr:"
        Me.LayoutControlItem53.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem53.TextToControlDistance = 3
        '
        'LayoutControl19
        '
        Me.SetBoundPropertyName(Me.LayoutControl19, "")
        Me.LayoutControl19.Location = New System.Drawing.Point(12, 247)
        Me.LayoutControl19.Name = "LayoutControl19"
        Me.LayoutControl19.Root = Me.LayoutControlGroup21
        Me.LayoutControl19.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl19.TabIndex = 4
        '
        'LayoutControlGroup21
        '
        Me.LayoutControlGroup21.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup21.GroupBordersVisible = False
        Me.LayoutControlGroup21.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem54})
        Me.LayoutControlGroup21.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup21.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup21.TextVisible = False
        '
        'LayoutControlItem54
        '
        Me.LayoutControlItem54.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem54.Name = "item"
        Me.LayoutControlItem54.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem54.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem54.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit16
        '
        Me.SetBoundPropertyName(Me.TextEdit16, "")
        Me.TextEdit16.Location = New System.Drawing.Point(88, 313)
        Me.TextEdit16.Name = "TextEdit16"
        Me.TextEdit16.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit16.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit16.Properties.Appearance.Options.UseFont = True
        Me.TextEdit16.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit16.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit16.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit16.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit16.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit16.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit16.Properties.ReadOnly = True
        Me.TextEdit16.Properties.UseReadOnlyAppearance = False
        Me.TextEdit16.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit16.StyleController = Me.LayoutControl17
        Me.TextEdit16.TabIndex = 4
        '
        'LayoutControlGroup22
        '
        Me.LayoutControlGroup22.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup22.GroupBordersVisible = False
        Me.LayoutControlGroup22.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem55, Me.LayoutControlItem56, Me.LayoutControlItem57, Me.LayoutControlItem58, Me.EmptySpaceItem14, Me.EmptySpaceItem15})
        Me.LayoutControlGroup22.Name = "Root"
        Me.LayoutControlGroup22.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup22.TextVisible = False
        '
        'LayoutControlItem55
        '
        Me.LayoutControlItem55.Control = Me.LayoutControl18
        Me.LayoutControlItem55.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem55.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem55.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem55.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem55.TextVisible = False
        '
        'LayoutControlItem56
        '
        Me.LayoutControlItem56.Control = Me.LayoutControl19
        Me.LayoutControlItem56.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem56.Name = "LayoutControlItem1"
        Me.LayoutControlItem56.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem56.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem56.TextVisible = False
        '
        'LayoutControlItem57
        '
        Me.LayoutControlItem57.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem57.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem57.Control = Me.MemoEdit7
        Me.LayoutControlItem57.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem57.Name = "LayoutControlItem2"
        Me.LayoutControlItem57.Size = New System.Drawing.Size(1063, 178)
        Me.LayoutControlItem57.Text = "Validation Code Description"
        Me.LayoutControlItem57.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem57.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem58
        '
        Me.LayoutControlItem58.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem58.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem58.Control = Me.TextEdit16
        Me.LayoutControlItem58.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem58.Location = New System.Drawing.Point(0, 301)
        Me.LayoutControlItem58.Name = "LayoutControlItem9"
        Me.LayoutControlItem58.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem58.Text = "Validation ID:"
        Me.LayoutControlItem58.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem58.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem58.TextToControlDistance = 3
        '
        'EmptySpaceItem14
        '
        Me.EmptySpaceItem14.AllowHotTrack = False
        Me.EmptySpaceItem14.Location = New System.Drawing.Point(218, 301)
        Me.EmptySpaceItem14.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem14.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem14.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem15
        '
        Me.EmptySpaceItem15.AllowHotTrack = False
        Me.EmptySpaceItem15.Location = New System.Drawing.Point(0, 505)
        Me.EmptySpaceItem15.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem15.Size = New System.Drawing.Size(1063, 10)
        Me.EmptySpaceItem15.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl20
        '
        Me.SetBoundPropertyName(Me.LayoutControl20, "")
        Me.LayoutControl20.Controls.Add(Me.MemoEdit8)
        Me.LayoutControl20.Controls.Add(Me.LayoutControl21)
        Me.LayoutControl20.Controls.Add(Me.LayoutControl22)
        Me.LayoutControl20.Controls.Add(Me.TextEdit22)
        Me.LayoutControl20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl20.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl20.Name = "LayoutControl20"
        Me.LayoutControl20.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl20.Root = Me.LayoutControlGroup25
        Me.LayoutControl20.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl20.TabIndex = 2
        '
        'MemoEdit8
        '
        Me.SetBoundPropertyName(Me.MemoEdit8, "")
        Me.MemoEdit8.Location = New System.Drawing.Point(12, 357)
        Me.MemoEdit8.Name = "MemoEdit8"
        Me.MemoEdit8.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit8.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit8.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit8.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit8.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit8.Properties.ReadOnly = True
        Me.MemoEdit8.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit8.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit8.Size = New System.Drawing.Size(1059, 156)
        Me.MemoEdit8.StyleController = Me.LayoutControl20
        Me.MemoEdit8.TabIndex = 0
        '
        'LayoutControl21
        '
        Me.SetBoundPropertyName(Me.LayoutControl21, "")
        Me.LayoutControl21.Controls.Add(Me.ImageComboBoxEdit4)
        Me.LayoutControl21.Controls.Add(Me.TextEdit17)
        Me.LayoutControl21.Controls.Add(Me.TextEdit18)
        Me.LayoutControl21.Controls.Add(Me.TextEdit19)
        Me.LayoutControl21.Controls.Add(Me.TextEdit20)
        Me.LayoutControl21.Controls.Add(Me.TextEdit21)
        Me.LayoutControl21.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl21.Name = "LayoutControl21"
        Me.LayoutControl21.Root = Me.LayoutControlGroup23
        Me.LayoutControl21.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl21.TabIndex = 1
        '
        'ImageComboBoxEdit4
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit4, "")
        Me.ImageComboBoxEdit4.Location = New System.Drawing.Point(866, 60)
        Me.ImageComboBoxEdit4.Name = "ImageComboBoxEdit4"
        Me.ImageComboBoxEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit4.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit4.Properties.ReadOnly = True
        Me.ImageComboBoxEdit4.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit4.Size = New System.Drawing.Size(181, 20)
        Me.ImageComboBoxEdit4.StyleController = Me.LayoutControl21
        Me.ImageComboBoxEdit4.TabIndex = 6
        '
        'TextEdit17
        '
        Me.SetBoundPropertyName(Me.TextEdit17, "")
        Me.TextEdit17.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit17.Name = "TextEdit17"
        Me.TextEdit17.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit17.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit17.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit17.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit17.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit17.Properties.ReadOnly = True
        Me.TextEdit17.Properties.UseReadOnlyAppearance = False
        Me.TextEdit17.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit17.StyleController = Me.LayoutControl21
        Me.TextEdit17.TabIndex = 4
        '
        'TextEdit18
        '
        Me.SetBoundPropertyName(Me.TextEdit18, "")
        Me.TextEdit18.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit18.Name = "TextEdit18"
        Me.TextEdit18.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit18.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit18.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit18.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit18.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit18.Properties.ReadOnly = True
        Me.TextEdit18.Properties.UseReadOnlyAppearance = False
        Me.TextEdit18.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit18.StyleController = Me.LayoutControl21
        Me.TextEdit18.TabIndex = 4
        '
        'TextEdit19
        '
        Me.SetBoundPropertyName(Me.TextEdit19, "")
        Me.TextEdit19.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit19.Name = "TextEdit19"
        Me.TextEdit19.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit19.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit19.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit19.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit19.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit19.Properties.ReadOnly = True
        Me.TextEdit19.Properties.UseReadOnlyAppearance = False
        Me.TextEdit19.Size = New System.Drawing.Size(652, 20)
        Me.TextEdit19.StyleController = Me.LayoutControl21
        Me.TextEdit19.TabIndex = 4
        '
        'TextEdit20
        '
        Me.SetBoundPropertyName(Me.TextEdit20, "")
        Me.TextEdit20.Location = New System.Drawing.Point(144, 84)
        Me.TextEdit20.Name = "TextEdit20"
        Me.TextEdit20.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit20.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit20.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit20.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit20.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit20.Properties.ReadOnly = True
        Me.TextEdit20.Properties.UseReadOnlyAppearance = False
        Me.TextEdit20.Size = New System.Drawing.Size(437, 20)
        Me.TextEdit20.StyleController = Me.LayoutControl21
        Me.TextEdit20.TabIndex = 4
        '
        'TextEdit21
        '
        Me.SetBoundPropertyName(Me.TextEdit21, "")
        Me.TextEdit21.Location = New System.Drawing.Point(648, 84)
        Me.TextEdit21.Name = "TextEdit21"
        Me.TextEdit21.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit21.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit21.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit21.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit21.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit21.Properties.ReadOnly = True
        Me.TextEdit21.Properties.UseReadOnlyAppearance = False
        Me.TextEdit21.Size = New System.Drawing.Size(399, 20)
        Me.TextEdit21.StyleController = Me.LayoutControl21
        Me.TextEdit21.TabIndex = 4
        '
        'LayoutControlGroup23
        '
        Me.LayoutControlGroup23.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup23.GroupBordersVisible = False
        Me.LayoutControlGroup23.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem48, Me.EmptySpaceItem16, Me.LayoutControlItem61, Me.LayoutControlItem62, Me.LayoutControlItem63, Me.LayoutControlItem64, Me.LayoutControlItem65})
        Me.LayoutControlGroup23.Name = "Root"
        Me.LayoutControlGroup23.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup23.TextVisible = False
        '
        'LayoutControlItem48
        '
        Me.LayoutControlItem48.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem48.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem48.Control = Me.TextEdit17
        Me.LayoutControlItem48.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem48.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem48.Name = "LayoutControlItem3"
        Me.LayoutControlItem48.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem48.Text = "Message Template ID:"
        Me.LayoutControlItem48.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem16
        '
        Me.EmptySpaceItem16.AllowHotTrack = False
        Me.EmptySpaceItem16.Location = New System.Drawing.Point(0, 96)
        Me.EmptySpaceItem16.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem16.Size = New System.Drawing.Size(1039, 115)
        Me.EmptySpaceItem16.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem61
        '
        Me.LayoutControlItem61.Control = Me.TextEdit18
        Me.LayoutControlItem61.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem61.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem61.Name = "LayoutControlItem17"
        Me.LayoutControlItem61.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem61.Text = "Message File Name:"
        Me.LayoutControlItem61.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem62
        '
        Me.LayoutControlItem62.Control = Me.TextEdit19
        Me.LayoutControlItem62.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem62.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem62.Name = "LayoutControlItem25"
        Me.LayoutControlItem62.Size = New System.Drawing.Size(788, 24)
        Me.LayoutControlItem62.Text = "Client Name:"
        Me.LayoutControlItem62.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem63
        '
        Me.LayoutControlItem63.Control = Me.ImageComboBoxEdit4
        Me.LayoutControlItem63.Location = New System.Drawing.Point(788, 48)
        Me.LayoutControlItem63.Name = "LayoutControlItem19"
        Me.LayoutControlItem63.Size = New System.Drawing.Size(251, 24)
        Me.LayoutControlItem63.Text = "Client Status"
        Me.LayoutControlItem63.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem63.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem63.TextToControlDistance = 5
        '
        'LayoutControlItem64
        '
        Me.LayoutControlItem64.Control = Me.TextEdit20
        Me.LayoutControlItem64.CustomizationFormText = "Instrument ID:"
        Me.LayoutControlItem64.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem64.Name = "LayoutControlItem36"
        Me.LayoutControlItem64.Size = New System.Drawing.Size(573, 24)
        Me.LayoutControlItem64.Text = "Instrument ID:"
        Me.LayoutControlItem64.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem65
        '
        Me.LayoutControlItem65.Control = Me.TextEdit21
        Me.LayoutControlItem65.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem65.Location = New System.Drawing.Point(573, 72)
        Me.LayoutControlItem65.Name = "LayoutControlItem47"
        Me.LayoutControlItem65.Size = New System.Drawing.Size(466, 24)
        Me.LayoutControlItem65.Text = "Contract Nr:"
        Me.LayoutControlItem65.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem65.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem65.TextToControlDistance = 3
        '
        'LayoutControl22
        '
        Me.SetBoundPropertyName(Me.LayoutControl22, "")
        Me.LayoutControl22.Location = New System.Drawing.Point(12, 247)
        Me.LayoutControl22.Name = "LayoutControl22"
        Me.LayoutControl22.Root = Me.LayoutControlGroup24
        Me.LayoutControl22.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl22.TabIndex = 4
        '
        'LayoutControlGroup24
        '
        Me.LayoutControlGroup24.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup24.GroupBordersVisible = False
        Me.LayoutControlGroup24.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem66})
        Me.LayoutControlGroup24.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup24.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup24.TextVisible = False
        '
        'LayoutControlItem66
        '
        Me.LayoutControlItem66.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem66.Name = "item"
        Me.LayoutControlItem66.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem66.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem66.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit22
        '
        Me.SetBoundPropertyName(Me.TextEdit22, "")
        Me.TextEdit22.Location = New System.Drawing.Point(88, 313)
        Me.TextEdit22.Name = "TextEdit22"
        Me.TextEdit22.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit22.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit22.Properties.Appearance.Options.UseFont = True
        Me.TextEdit22.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit22.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit22.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit22.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit22.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit22.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit22.Properties.ReadOnly = True
        Me.TextEdit22.Properties.UseReadOnlyAppearance = False
        Me.TextEdit22.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit22.StyleController = Me.LayoutControl20
        Me.TextEdit22.TabIndex = 4
        '
        'LayoutControlGroup25
        '
        Me.LayoutControlGroup25.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup25.GroupBordersVisible = False
        Me.LayoutControlGroup25.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem67, Me.LayoutControlItem68, Me.LayoutControlItem69, Me.LayoutControlItem70, Me.EmptySpaceItem17, Me.EmptySpaceItem18})
        Me.LayoutControlGroup25.Name = "Root"
        Me.LayoutControlGroup25.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup25.TextVisible = False
        '
        'LayoutControlItem67
        '
        Me.LayoutControlItem67.Control = Me.LayoutControl21
        Me.LayoutControlItem67.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem67.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem67.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem67.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem67.TextVisible = False
        '
        'LayoutControlItem68
        '
        Me.LayoutControlItem68.Control = Me.LayoutControl22
        Me.LayoutControlItem68.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem68.Name = "LayoutControlItem1"
        Me.LayoutControlItem68.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem68.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem68.TextVisible = False
        '
        'LayoutControlItem69
        '
        Me.LayoutControlItem69.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem69.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem69.Control = Me.MemoEdit8
        Me.LayoutControlItem69.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem69.Name = "LayoutControlItem2"
        Me.LayoutControlItem69.Size = New System.Drawing.Size(1063, 178)
        Me.LayoutControlItem69.Text = "Validation Code Description"
        Me.LayoutControlItem69.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem69.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem70
        '
        Me.LayoutControlItem70.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem70.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem70.Control = Me.TextEdit22
        Me.LayoutControlItem70.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem70.Location = New System.Drawing.Point(0, 301)
        Me.LayoutControlItem70.Name = "LayoutControlItem9"
        Me.LayoutControlItem70.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem70.Text = "Validation ID:"
        Me.LayoutControlItem70.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem70.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem70.TextToControlDistance = 3
        '
        'EmptySpaceItem17
        '
        Me.EmptySpaceItem17.AllowHotTrack = False
        Me.EmptySpaceItem17.Location = New System.Drawing.Point(218, 301)
        Me.EmptySpaceItem17.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem17.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem17.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem18
        '
        Me.EmptySpaceItem18.AllowHotTrack = False
        Me.EmptySpaceItem18.Location = New System.Drawing.Point(0, 505)
        Me.EmptySpaceItem18.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem18.Size = New System.Drawing.Size(1063, 10)
        Me.EmptySpaceItem18.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl23
        '
        Me.SetBoundPropertyName(Me.LayoutControl23, "")
        Me.LayoutControl23.Controls.Add(Me.MemoEdit9)
        Me.LayoutControl23.Controls.Add(Me.LayoutControl24)
        Me.LayoutControl23.Controls.Add(Me.LayoutControl25)
        Me.LayoutControl23.Controls.Add(Me.TextEdit28)
        Me.LayoutControl23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl23.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl23.Name = "LayoutControl23"
        Me.LayoutControl23.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl23.Root = Me.LayoutControlGroup28
        Me.LayoutControl23.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl23.TabIndex = 2
        '
        'MemoEdit9
        '
        Me.SetBoundPropertyName(Me.MemoEdit9, "")
        Me.MemoEdit9.Location = New System.Drawing.Point(12, 357)
        Me.MemoEdit9.Name = "MemoEdit9"
        Me.MemoEdit9.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit9.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit9.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit9.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit9.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit9.Properties.ReadOnly = True
        Me.MemoEdit9.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit9.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit9.Size = New System.Drawing.Size(1059, 156)
        Me.MemoEdit9.StyleController = Me.LayoutControl23
        Me.MemoEdit9.TabIndex = 0
        '
        'LayoutControl24
        '
        Me.SetBoundPropertyName(Me.LayoutControl24, "")
        Me.LayoutControl24.Controls.Add(Me.DateEdit5)
        Me.LayoutControl24.Controls.Add(Me.TextEdit23)
        Me.LayoutControl24.Controls.Add(Me.TextEdit24)
        Me.LayoutControl24.Controls.Add(Me.TextEdit25)
        Me.LayoutControl24.Controls.Add(Me.TextEdit26)
        Me.LayoutControl24.Controls.Add(Me.TextEdit27)
        Me.LayoutControl24.Controls.Add(Me.DateEdit6)
        Me.LayoutControl24.Controls.Add(Me.DateEdit7)
        Me.LayoutControl24.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl24.Name = "LayoutControl24"
        Me.LayoutControl24.Root = Me.LayoutControlGroup26
        Me.LayoutControl24.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl24.TabIndex = 1
        '
        'DateEdit5
        '
        Me.SetBoundPropertyName(Me.DateEdit5, "")
        Me.DateEdit5.EditValue = Nothing
        Me.DateEdit5.Location = New System.Drawing.Point(870, 12)
        Me.DateEdit5.Name = "DateEdit5"
        Me.DateEdit5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit5.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit5.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit5.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit5.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit5.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit5.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit5.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit5.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit5.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit5.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit5.Properties.ReadOnly = True
        Me.DateEdit5.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit5.Properties.UseReadOnlyAppearance = False
        Me.DateEdit5.Size = New System.Drawing.Size(177, 20)
        Me.DateEdit5.StyleController = Me.LayoutControl24
        Me.DateEdit5.TabIndex = 5
        '
        'TextEdit23
        '
        Me.SetBoundPropertyName(Me.TextEdit23, "")
        Me.TextEdit23.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit23.Name = "TextEdit23"
        Me.TextEdit23.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit23.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit23.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit23.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit23.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit23.Properties.ReadOnly = True
        Me.TextEdit23.Properties.UseReadOnlyAppearance = False
        Me.TextEdit23.Size = New System.Drawing.Size(643, 20)
        Me.TextEdit23.StyleController = Me.LayoutControl24
        Me.TextEdit23.TabIndex = 4
        '
        'TextEdit24
        '
        Me.SetBoundPropertyName(Me.TextEdit24, "")
        Me.TextEdit24.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit24.Name = "TextEdit24"
        Me.TextEdit24.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit24.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit24.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit24.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit24.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit24.Properties.ReadOnly = True
        Me.TextEdit24.Properties.UseReadOnlyAppearance = False
        Me.TextEdit24.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit24.StyleController = Me.LayoutControl24
        Me.TextEdit24.TabIndex = 4
        '
        'TextEdit25
        '
        Me.SetBoundPropertyName(Me.TextEdit25, "")
        Me.TextEdit25.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit25.Name = "TextEdit25"
        Me.TextEdit25.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit25.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit25.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit25.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit25.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit25.Properties.ReadOnly = True
        Me.TextEdit25.Properties.UseReadOnlyAppearance = False
        Me.TextEdit25.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit25.StyleController = Me.LayoutControl24
        Me.TextEdit25.TabIndex = 4
        '
        'TextEdit26
        '
        Me.SetBoundPropertyName(Me.TextEdit26, "")
        Me.TextEdit26.Location = New System.Drawing.Point(144, 84)
        Me.TextEdit26.Name = "TextEdit26"
        Me.TextEdit26.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit26.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit26.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit26.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit26.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit26.Properties.ReadOnly = True
        Me.TextEdit26.Properties.UseReadOnlyAppearance = False
        Me.TextEdit26.Size = New System.Drawing.Size(383, 20)
        Me.TextEdit26.StyleController = Me.LayoutControl24
        Me.TextEdit26.TabIndex = 4
        '
        'TextEdit27
        '
        Me.SetBoundPropertyName(Me.TextEdit27, "")
        Me.TextEdit27.Location = New System.Drawing.Point(594, 84)
        Me.TextEdit27.Name = "TextEdit27"
        Me.TextEdit27.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit27.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit27.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit27.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit27.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit27.Properties.ReadOnly = True
        Me.TextEdit27.Properties.UseReadOnlyAppearance = False
        Me.TextEdit27.Size = New System.Drawing.Size(453, 20)
        Me.TextEdit27.StyleController = Me.LayoutControl24
        Me.TextEdit27.TabIndex = 4
        '
        'DateEdit6
        '
        Me.SetBoundPropertyName(Me.DateEdit6, "")
        Me.DateEdit6.EditValue = Nothing
        Me.DateEdit6.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit6.Name = "DateEdit6"
        Me.DateEdit6.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit6.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit6.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit6.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit6.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit6.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit6.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit6.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit6.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit6.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit6.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit6.Properties.ReadOnly = True
        Me.DateEdit6.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit6.Properties.UseReadOnlyAppearance = False
        Me.DateEdit6.Size = New System.Drawing.Size(383, 20)
        Me.DateEdit6.StyleController = Me.LayoutControl24
        Me.DateEdit6.TabIndex = 5
        '
        'DateEdit7
        '
        Me.SetBoundPropertyName(Me.DateEdit7, "")
        Me.DateEdit7.EditValue = Nothing
        Me.DateEdit7.Location = New System.Drawing.Point(625, 108)
        Me.DateEdit7.Name = "DateEdit7"
        Me.DateEdit7.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit7.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit7.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit7.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit7.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit7.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit7.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit7.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit7.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit7.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit7.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit7.Properties.ReadOnly = True
        Me.DateEdit7.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit7.Properties.UseReadOnlyAppearance = False
        Me.DateEdit7.Size = New System.Drawing.Size(422, 20)
        Me.DateEdit7.StyleController = Me.LayoutControl24
        Me.DateEdit7.TabIndex = 5
        '
        'LayoutControlGroup26
        '
        Me.LayoutControlGroup26.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup26.GroupBordersVisible = False
        Me.LayoutControlGroup26.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem60, Me.EmptySpaceItem19, Me.LayoutControlItem72, Me.LayoutControlItem73, Me.LayoutControlItem74, Me.LayoutControlItem76, Me.LayoutControlItem77, Me.LayoutControlItem78, Me.LayoutControlItem79})
        Me.LayoutControlGroup26.Name = "Root"
        Me.LayoutControlGroup26.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup26.TextVisible = False
        '
        'LayoutControlItem60
        '
        Me.LayoutControlItem60.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem60.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem60.Control = Me.TextEdit23
        Me.LayoutControlItem60.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem60.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem60.Name = "LayoutControlItem3"
        Me.LayoutControlItem60.Size = New System.Drawing.Size(779, 24)
        Me.LayoutControlItem60.Text = "Message Template ID:"
        Me.LayoutControlItem60.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem19
        '
        Me.EmptySpaceItem19.AllowHotTrack = False
        Me.EmptySpaceItem19.Location = New System.Drawing.Point(0, 120)
        Me.EmptySpaceItem19.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem19.Size = New System.Drawing.Size(1039, 91)
        Me.EmptySpaceItem19.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem72
        '
        Me.LayoutControlItem72.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem72.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem72.Control = Me.DateEdit5
        Me.LayoutControlItem72.Location = New System.Drawing.Point(779, 0)
        Me.LayoutControlItem72.Name = "LayoutControlItem4"
        Me.LayoutControlItem72.Size = New System.Drawing.Size(260, 24)
        Me.LayoutControlItem72.Text = "Melde Monat"
        Me.LayoutControlItem72.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem72.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem72.TextToControlDistance = 5
        '
        'LayoutControlItem73
        '
        Me.LayoutControlItem73.Control = Me.TextEdit24
        Me.LayoutControlItem73.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem73.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem73.Name = "LayoutControlItem17"
        Me.LayoutControlItem73.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem73.Text = "Message File Name:"
        Me.LayoutControlItem73.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem74
        '
        Me.LayoutControlItem74.Control = Me.TextEdit25
        Me.LayoutControlItem74.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem74.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem74.Name = "LayoutControlItem25"
        Me.LayoutControlItem74.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem74.Text = "Client Name:"
        Me.LayoutControlItem74.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem76
        '
        Me.LayoutControlItem76.Control = Me.TextEdit26
        Me.LayoutControlItem76.CustomizationFormText = "Instrument ID:"
        Me.LayoutControlItem76.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem76.Name = "LayoutControlItem36"
        Me.LayoutControlItem76.Size = New System.Drawing.Size(519, 24)
        Me.LayoutControlItem76.Text = "Instrument ID:"
        Me.LayoutControlItem76.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem77
        '
        Me.LayoutControlItem77.Control = Me.TextEdit27
        Me.LayoutControlItem77.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem77.Location = New System.Drawing.Point(519, 72)
        Me.LayoutControlItem77.Name = "LayoutControlItem47"
        Me.LayoutControlItem77.Size = New System.Drawing.Size(520, 24)
        Me.LayoutControlItem77.Text = "Contract Nr:"
        Me.LayoutControlItem77.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem77.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem77.TextToControlDistance = 3
        '
        'LayoutControlItem78
        '
        Me.LayoutControlItem78.Control = Me.DateEdit6
        Me.LayoutControlItem78.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem78.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem78.Name = "LayoutControlItem59"
        Me.LayoutControlItem78.Size = New System.Drawing.Size(519, 24)
        Me.LayoutControlItem78.Text = "Contract Start Date"
        Me.LayoutControlItem78.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem79
        '
        Me.LayoutControlItem79.Control = Me.DateEdit7
        Me.LayoutControlItem79.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem79.Location = New System.Drawing.Point(519, 96)
        Me.LayoutControlItem79.Name = "LayoutControlItem71"
        Me.LayoutControlItem79.Size = New System.Drawing.Size(520, 24)
        Me.LayoutControlItem79.Text = "Contract End Date"
        Me.LayoutControlItem79.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem79.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem79.TextToControlDistance = 5
        '
        'LayoutControl25
        '
        Me.SetBoundPropertyName(Me.LayoutControl25, "")
        Me.LayoutControl25.Location = New System.Drawing.Point(12, 247)
        Me.LayoutControl25.Name = "LayoutControl25"
        Me.LayoutControl25.Root = Me.LayoutControlGroup27
        Me.LayoutControl25.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl25.TabIndex = 4
        '
        'LayoutControlGroup27
        '
        Me.LayoutControlGroup27.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup27.GroupBordersVisible = False
        Me.LayoutControlGroup27.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem80})
        Me.LayoutControlGroup27.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup27.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup27.TextVisible = False
        '
        'LayoutControlItem80
        '
        Me.LayoutControlItem80.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem80.Name = "item"
        Me.LayoutControlItem80.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem80.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem80.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit28
        '
        Me.SetBoundPropertyName(Me.TextEdit28, "")
        Me.TextEdit28.Location = New System.Drawing.Point(88, 313)
        Me.TextEdit28.Name = "TextEdit28"
        Me.TextEdit28.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit28.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit28.Properties.Appearance.Options.UseFont = True
        Me.TextEdit28.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit28.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit28.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit28.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit28.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit28.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit28.Properties.ReadOnly = True
        Me.TextEdit28.Properties.UseReadOnlyAppearance = False
        Me.TextEdit28.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit28.StyleController = Me.LayoutControl23
        Me.TextEdit28.TabIndex = 4
        '
        'LayoutControlGroup28
        '
        Me.LayoutControlGroup28.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup28.GroupBordersVisible = False
        Me.LayoutControlGroup28.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem81, Me.LayoutControlItem82, Me.LayoutControlItem83, Me.LayoutControlItem84, Me.EmptySpaceItem20, Me.EmptySpaceItem21})
        Me.LayoutControlGroup28.Name = "Root"
        Me.LayoutControlGroup28.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup28.TextVisible = False
        '
        'LayoutControlItem81
        '
        Me.LayoutControlItem81.Control = Me.LayoutControl24
        Me.LayoutControlItem81.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem81.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem81.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem81.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem81.TextVisible = False
        '
        'LayoutControlItem82
        '
        Me.LayoutControlItem82.Control = Me.LayoutControl25
        Me.LayoutControlItem82.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem82.Name = "LayoutControlItem1"
        Me.LayoutControlItem82.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem82.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem82.TextVisible = False
        '
        'LayoutControlItem83
        '
        Me.LayoutControlItem83.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem83.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem83.Control = Me.MemoEdit9
        Me.LayoutControlItem83.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem83.Name = "LayoutControlItem2"
        Me.LayoutControlItem83.Size = New System.Drawing.Size(1063, 178)
        Me.LayoutControlItem83.Text = "Validation Code Description"
        Me.LayoutControlItem83.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem83.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem84
        '
        Me.LayoutControlItem84.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem84.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem84.Control = Me.TextEdit28
        Me.LayoutControlItem84.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem84.Location = New System.Drawing.Point(0, 301)
        Me.LayoutControlItem84.Name = "LayoutControlItem9"
        Me.LayoutControlItem84.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem84.Text = "Validation ID:"
        Me.LayoutControlItem84.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem84.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem84.TextToControlDistance = 3
        '
        'EmptySpaceItem20
        '
        Me.EmptySpaceItem20.AllowHotTrack = False
        Me.EmptySpaceItem20.Location = New System.Drawing.Point(218, 301)
        Me.EmptySpaceItem20.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem20.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem20.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem21
        '
        Me.EmptySpaceItem21.AllowHotTrack = False
        Me.EmptySpaceItem21.Location = New System.Drawing.Point(0, 505)
        Me.EmptySpaceItem21.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem21.Size = New System.Drawing.Size(1063, 10)
        Me.EmptySpaceItem21.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl26
        '
        Me.SetBoundPropertyName(Me.LayoutControl26, "")
        Me.LayoutControl26.Controls.Add(Me.MemoEdit10)
        Me.LayoutControl26.Controls.Add(Me.LayoutControl27)
        Me.LayoutControl26.Controls.Add(Me.LayoutControl28)
        Me.LayoutControl26.Controls.Add(Me.TextEdit34)
        Me.LayoutControl26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl26.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl26.Name = "LayoutControl26"
        Me.LayoutControl26.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl26.Root = Me.LayoutControlGroup31
        Me.LayoutControl26.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl26.TabIndex = 2
        '
        'MemoEdit10
        '
        Me.SetBoundPropertyName(Me.MemoEdit10, "")
        Me.MemoEdit10.Location = New System.Drawing.Point(12, 357)
        Me.MemoEdit10.Name = "MemoEdit10"
        Me.MemoEdit10.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit10.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit10.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit10.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit10.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit10.Properties.ReadOnly = True
        Me.MemoEdit10.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit10.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit10.Size = New System.Drawing.Size(1059, 156)
        Me.MemoEdit10.StyleController = Me.LayoutControl26
        Me.MemoEdit10.TabIndex = 0
        '
        'LayoutControl27
        '
        Me.SetBoundPropertyName(Me.LayoutControl27, "")
        Me.LayoutControl27.Controls.Add(Me.ImageComboBoxEdit6)
        Me.LayoutControl27.Controls.Add(Me.DateEdit8)
        Me.LayoutControl27.Controls.Add(Me.TextEdit30)
        Me.LayoutControl27.Controls.Add(Me.TextEdit31)
        Me.LayoutControl27.Controls.Add(Me.TextEdit32)
        Me.LayoutControl27.Controls.Add(Me.TextEdit33)
        Me.LayoutControl27.Controls.Add(Me.DateEdit9)
        Me.LayoutControl27.Controls.Add(Me.DateEdit10)
        Me.LayoutControl27.Controls.Add(Me.ImageComboBoxEdit7)
        Me.LayoutControl27.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl27.Name = "LayoutControl27"
        Me.LayoutControl27.Root = Me.LayoutControlGroup29
        Me.LayoutControl27.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl27.TabIndex = 1
        '
        'ImageComboBoxEdit6
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit6, "")
        Me.ImageComboBoxEdit6.Location = New System.Drawing.Point(523, 60)
        Me.ImageComboBoxEdit6.Name = "ImageComboBoxEdit6"
        Me.ImageComboBoxEdit6.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit6.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit6.Properties.ReadOnly = True
        Me.ImageComboBoxEdit6.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit6.Size = New System.Drawing.Size(524, 20)
        Me.ImageComboBoxEdit6.StyleController = Me.LayoutControl27
        Me.ImageComboBoxEdit6.TabIndex = 6
        '
        'DateEdit8
        '
        Me.SetBoundPropertyName(Me.DateEdit8, "")
        Me.DateEdit8.EditValue = Nothing
        Me.DateEdit8.Location = New System.Drawing.Point(536, 12)
        Me.DateEdit8.Name = "DateEdit8"
        Me.DateEdit8.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit8.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit8.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit8.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit8.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit8.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit8.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit8.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit8.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit8.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit8.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit8.Properties.ReadOnly = True
        Me.DateEdit8.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit8.Properties.UseReadOnlyAppearance = False
        Me.DateEdit8.Size = New System.Drawing.Size(511, 20)
        Me.DateEdit8.StyleController = Me.LayoutControl27
        Me.DateEdit8.TabIndex = 5
        '
        'TextEdit30
        '
        Me.SetBoundPropertyName(Me.TextEdit30, "")
        Me.TextEdit30.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit30.Name = "TextEdit30"
        Me.TextEdit30.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit30.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit30.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit30.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit30.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit30.Properties.ReadOnly = True
        Me.TextEdit30.Properties.UseReadOnlyAppearance = False
        Me.TextEdit30.Size = New System.Drawing.Size(309, 20)
        Me.TextEdit30.StyleController = Me.LayoutControl27
        Me.TextEdit30.TabIndex = 4
        '
        'TextEdit31
        '
        Me.SetBoundPropertyName(Me.TextEdit31, "")
        Me.TextEdit31.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit31.Name = "TextEdit31"
        Me.TextEdit31.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit31.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit31.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit31.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit31.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit31.Properties.ReadOnly = True
        Me.TextEdit31.Properties.UseReadOnlyAppearance = False
        Me.TextEdit31.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit31.StyleController = Me.LayoutControl27
        Me.TextEdit31.TabIndex = 4
        '
        'TextEdit32
        '
        Me.SetBoundPropertyName(Me.TextEdit32, "")
        Me.TextEdit32.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit32.Name = "TextEdit32"
        Me.TextEdit32.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit32.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit32.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit32.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit32.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit32.Properties.ReadOnly = True
        Me.TextEdit32.Properties.UseReadOnlyAppearance = False
        Me.TextEdit32.Size = New System.Drawing.Size(309, 20)
        Me.TextEdit32.StyleController = Me.LayoutControl27
        Me.TextEdit32.TabIndex = 4
        '
        'TextEdit33
        '
        Me.SetBoundPropertyName(Me.TextEdit33, "")
        Me.TextEdit33.Location = New System.Drawing.Point(75, 84)
        Me.TextEdit33.Name = "TextEdit33"
        Me.TextEdit33.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit33.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit33.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit33.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit33.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit33.Properties.ReadOnly = True
        Me.TextEdit33.Properties.UseReadOnlyAppearance = False
        Me.TextEdit33.Size = New System.Drawing.Size(972, 20)
        Me.TextEdit33.StyleController = Me.LayoutControl27
        Me.TextEdit33.TabIndex = 4
        '
        'DateEdit9
        '
        Me.SetBoundPropertyName(Me.DateEdit9, "")
        Me.DateEdit9.EditValue = Nothing
        Me.DateEdit9.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit9.Name = "DateEdit9"
        Me.DateEdit9.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit9.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit9.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit9.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit9.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit9.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit9.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit9.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit9.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit9.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit9.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit9.Properties.ReadOnly = True
        Me.DateEdit9.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit9.Properties.UseReadOnlyAppearance = False
        Me.DateEdit9.Size = New System.Drawing.Size(161, 20)
        Me.DateEdit9.StyleController = Me.LayoutControl27
        Me.DateEdit9.TabIndex = 5
        '
        'DateEdit10
        '
        Me.SetBoundPropertyName(Me.DateEdit10, "")
        Me.DateEdit10.EditValue = Nothing
        Me.DateEdit10.Location = New System.Drawing.Point(403, 108)
        Me.DateEdit10.Name = "DateEdit10"
        Me.DateEdit10.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit10.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit10.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit10.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit10.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit10.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit10.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit10.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit10.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit10.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit10.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit10.Properties.ReadOnly = True
        Me.DateEdit10.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit10.Properties.UseReadOnlyAppearance = False
        Me.DateEdit10.Size = New System.Drawing.Size(424, 20)
        Me.DateEdit10.StyleController = Me.LayoutControl27
        Me.DateEdit10.TabIndex = 5
        '
        'ImageComboBoxEdit7
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit7, "")
        Me.ImageComboBoxEdit7.Location = New System.Drawing.Point(912, 108)
        Me.ImageComboBoxEdit7.Name = "ImageComboBoxEdit7"
        Me.ImageComboBoxEdit7.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit7.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit7.Properties.ReadOnly = True
        Me.ImageComboBoxEdit7.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit7.Size = New System.Drawing.Size(135, 20)
        Me.ImageComboBoxEdit7.StyleController = Me.LayoutControl27
        Me.ImageComboBoxEdit7.TabIndex = 6
        '
        'LayoutControlGroup29
        '
        Me.LayoutControlGroup29.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup29.GroupBordersVisible = False
        Me.LayoutControlGroup29.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem75, Me.EmptySpaceItem22, Me.LayoutControlItem86, Me.LayoutControlItem87, Me.LayoutControlItem88, Me.LayoutControlItem89, Me.LayoutControlItem91, Me.LayoutControlItem92, Me.LayoutControlItem93, Me.LayoutControlItem94})
        Me.LayoutControlGroup29.Name = "Root"
        Me.LayoutControlGroup29.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup29.TextVisible = False
        '
        'LayoutControlItem75
        '
        Me.LayoutControlItem75.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem75.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem75.Control = Me.TextEdit30
        Me.LayoutControlItem75.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem75.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem75.Name = "LayoutControlItem3"
        Me.LayoutControlItem75.Size = New System.Drawing.Size(445, 24)
        Me.LayoutControlItem75.Text = "Message Template ID:"
        Me.LayoutControlItem75.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem22
        '
        Me.EmptySpaceItem22.AllowHotTrack = False
        Me.EmptySpaceItem22.Location = New System.Drawing.Point(0, 120)
        Me.EmptySpaceItem22.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem22.Size = New System.Drawing.Size(1039, 91)
        Me.EmptySpaceItem22.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem86
        '
        Me.LayoutControlItem86.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem86.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem86.Control = Me.DateEdit8
        Me.LayoutControlItem86.Location = New System.Drawing.Point(445, 0)
        Me.LayoutControlItem86.Name = "LayoutControlItem4"
        Me.LayoutControlItem86.Size = New System.Drawing.Size(594, 24)
        Me.LayoutControlItem86.Text = "Melde Monat"
        Me.LayoutControlItem86.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem86.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem86.TextToControlDistance = 5
        '
        'LayoutControlItem87
        '
        Me.LayoutControlItem87.Control = Me.TextEdit31
        Me.LayoutControlItem87.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem87.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem87.Name = "LayoutControlItem17"
        Me.LayoutControlItem87.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem87.Text = "Message File Name:"
        Me.LayoutControlItem87.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem88
        '
        Me.LayoutControlItem88.Control = Me.TextEdit32
        Me.LayoutControlItem88.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem88.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem88.Name = "LayoutControlItem25"
        Me.LayoutControlItem88.Size = New System.Drawing.Size(445, 24)
        Me.LayoutControlItem88.Text = "Client Name:"
        Me.LayoutControlItem88.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem89
        '
        Me.LayoutControlItem89.Control = Me.ImageComboBoxEdit6
        Me.LayoutControlItem89.Location = New System.Drawing.Point(445, 48)
        Me.LayoutControlItem89.Name = "LayoutControlItem19"
        Me.LayoutControlItem89.Size = New System.Drawing.Size(594, 24)
        Me.LayoutControlItem89.Text = "Client Status"
        Me.LayoutControlItem89.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem89.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem89.TextToControlDistance = 5
        '
        'LayoutControlItem91
        '
        Me.LayoutControlItem91.Control = Me.TextEdit33
        Me.LayoutControlItem91.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem91.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem91.Name = "LayoutControlItem47"
        Me.LayoutControlItem91.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem91.Text = "Contract Nr:"
        Me.LayoutControlItem91.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem91.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem91.TextToControlDistance = 3
        '
        'LayoutControlItem92
        '
        Me.LayoutControlItem92.Control = Me.DateEdit9
        Me.LayoutControlItem92.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem92.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem92.Name = "LayoutControlItem59"
        Me.LayoutControlItem92.Size = New System.Drawing.Size(297, 24)
        Me.LayoutControlItem92.Text = "Contract Start Date"
        Me.LayoutControlItem92.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem93
        '
        Me.LayoutControlItem93.Control = Me.DateEdit10
        Me.LayoutControlItem93.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem93.Location = New System.Drawing.Point(297, 96)
        Me.LayoutControlItem93.Name = "LayoutControlItem71"
        Me.LayoutControlItem93.Size = New System.Drawing.Size(522, 24)
        Me.LayoutControlItem93.Text = "Contract End Date"
        Me.LayoutControlItem93.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem93.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem93.TextToControlDistance = 5
        '
        'LayoutControlItem94
        '
        Me.LayoutControlItem94.Control = Me.ImageComboBoxEdit7
        Me.LayoutControlItem94.CustomizationFormText = "Contract Status"
        Me.LayoutControlItem94.Location = New System.Drawing.Point(819, 96)
        Me.LayoutControlItem94.Name = "LayoutControlItem85"
        Me.LayoutControlItem94.Size = New System.Drawing.Size(220, 24)
        Me.LayoutControlItem94.Text = "Contract Status"
        Me.LayoutControlItem94.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem94.TextSize = New System.Drawing.Size(76, 13)
        Me.LayoutControlItem94.TextToControlDistance = 5
        '
        'LayoutControl28
        '
        Me.SetBoundPropertyName(Me.LayoutControl28, "")
        Me.LayoutControl28.Location = New System.Drawing.Point(12, 247)
        Me.LayoutControl28.Name = "LayoutControl28"
        Me.LayoutControl28.Root = Me.LayoutControlGroup30
        Me.LayoutControl28.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl28.TabIndex = 4
        '
        'LayoutControlGroup30
        '
        Me.LayoutControlGroup30.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup30.GroupBordersVisible = False
        Me.LayoutControlGroup30.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem95})
        Me.LayoutControlGroup30.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup30.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup30.TextVisible = False
        '
        'LayoutControlItem95
        '
        Me.LayoutControlItem95.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem95.Name = "item"
        Me.LayoutControlItem95.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem95.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem95.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit34
        '
        Me.SetBoundPropertyName(Me.TextEdit34, "")
        Me.TextEdit34.Location = New System.Drawing.Point(88, 313)
        Me.TextEdit34.Name = "TextEdit34"
        Me.TextEdit34.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit34.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit34.Properties.Appearance.Options.UseFont = True
        Me.TextEdit34.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit34.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit34.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit34.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit34.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit34.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit34.Properties.ReadOnly = True
        Me.TextEdit34.Properties.UseReadOnlyAppearance = False
        Me.TextEdit34.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit34.StyleController = Me.LayoutControl26
        Me.TextEdit34.TabIndex = 4
        '
        'LayoutControlGroup31
        '
        Me.LayoutControlGroup31.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup31.GroupBordersVisible = False
        Me.LayoutControlGroup31.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem96, Me.LayoutControlItem97, Me.LayoutControlItem98, Me.LayoutControlItem99, Me.EmptySpaceItem23, Me.EmptySpaceItem24})
        Me.LayoutControlGroup31.Name = "Root"
        Me.LayoutControlGroup31.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup31.TextVisible = False
        '
        'LayoutControlItem96
        '
        Me.LayoutControlItem96.Control = Me.LayoutControl27
        Me.LayoutControlItem96.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem96.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem96.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem96.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem96.TextVisible = False
        '
        'LayoutControlItem97
        '
        Me.LayoutControlItem97.Control = Me.LayoutControl28
        Me.LayoutControlItem97.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem97.Name = "LayoutControlItem1"
        Me.LayoutControlItem97.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem97.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem97.TextVisible = False
        '
        'LayoutControlItem98
        '
        Me.LayoutControlItem98.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem98.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem98.Control = Me.MemoEdit10
        Me.LayoutControlItem98.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem98.Name = "LayoutControlItem2"
        Me.LayoutControlItem98.Size = New System.Drawing.Size(1063, 178)
        Me.LayoutControlItem98.Text = "Validation Code Description"
        Me.LayoutControlItem98.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem98.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem99
        '
        Me.LayoutControlItem99.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem99.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem99.Control = Me.TextEdit34
        Me.LayoutControlItem99.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem99.Location = New System.Drawing.Point(0, 301)
        Me.LayoutControlItem99.Name = "LayoutControlItem9"
        Me.LayoutControlItem99.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem99.Text = "Validation ID:"
        Me.LayoutControlItem99.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem99.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem99.TextToControlDistance = 3
        '
        'EmptySpaceItem23
        '
        Me.EmptySpaceItem23.AllowHotTrack = False
        Me.EmptySpaceItem23.Location = New System.Drawing.Point(218, 301)
        Me.EmptySpaceItem23.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem23.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem23.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem24
        '
        Me.EmptySpaceItem24.AllowHotTrack = False
        Me.EmptySpaceItem24.Location = New System.Drawing.Point(0, 505)
        Me.EmptySpaceItem24.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem24.Size = New System.Drawing.Size(1063, 10)
        Me.EmptySpaceItem24.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl29
        '
        Me.SetBoundPropertyName(Me.LayoutControl29, "")
        Me.LayoutControl29.Controls.Add(Me.MemoEdit11)
        Me.LayoutControl29.Controls.Add(Me.LayoutControl30)
        Me.LayoutControl29.Controls.Add(Me.LayoutControl31)
        Me.LayoutControl29.Controls.Add(Me.TextEdit40)
        Me.LayoutControl29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl29.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl29.Name = "LayoutControl29"
        Me.LayoutControl29.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl29.Root = Me.LayoutControlGroup34
        Me.LayoutControl29.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl29.TabIndex = 2
        '
        'MemoEdit11
        '
        Me.SetBoundPropertyName(Me.MemoEdit11, "")
        Me.MemoEdit11.Location = New System.Drawing.Point(12, 357)
        Me.MemoEdit11.Name = "MemoEdit11"
        Me.MemoEdit11.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit11.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit11.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit11.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit11.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit11.Properties.ReadOnly = True
        Me.MemoEdit11.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit11.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit11.Size = New System.Drawing.Size(1059, 156)
        Me.MemoEdit11.StyleController = Me.LayoutControl29
        Me.MemoEdit11.TabIndex = 0
        '
        'LayoutControl30
        '
        Me.SetBoundPropertyName(Me.LayoutControl30, "")
        Me.LayoutControl30.Controls.Add(Me.ImageComboBoxEdit8)
        Me.LayoutControl30.Controls.Add(Me.DateEdit11)
        Me.LayoutControl30.Controls.Add(Me.TextEdit36)
        Me.LayoutControl30.Controls.Add(Me.TextEdit37)
        Me.LayoutControl30.Controls.Add(Me.TextEdit38)
        Me.LayoutControl30.Controls.Add(Me.TextEdit39)
        Me.LayoutControl30.Controls.Add(Me.DateEdit12)
        Me.LayoutControl30.Controls.Add(Me.DateEdit13)
        Me.LayoutControl30.Controls.Add(Me.ImageComboBoxEdit9)
        Me.LayoutControl30.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl30.Name = "LayoutControl30"
        Me.LayoutControl30.Root = Me.LayoutControlGroup32
        Me.LayoutControl30.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl30.TabIndex = 1
        '
        'ImageComboBoxEdit8
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit8, "")
        Me.ImageComboBoxEdit8.Location = New System.Drawing.Point(523, 60)
        Me.ImageComboBoxEdit8.Name = "ImageComboBoxEdit8"
        Me.ImageComboBoxEdit8.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit8.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit8.Properties.ReadOnly = True
        Me.ImageComboBoxEdit8.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit8.Size = New System.Drawing.Size(524, 20)
        Me.ImageComboBoxEdit8.StyleController = Me.LayoutControl30
        Me.ImageComboBoxEdit8.TabIndex = 6
        '
        'DateEdit11
        '
        Me.SetBoundPropertyName(Me.DateEdit11, "")
        Me.DateEdit11.EditValue = Nothing
        Me.DateEdit11.Location = New System.Drawing.Point(536, 12)
        Me.DateEdit11.Name = "DateEdit11"
        Me.DateEdit11.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit11.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit11.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit11.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit11.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit11.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit11.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit11.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit11.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit11.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit11.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit11.Properties.ReadOnly = True
        Me.DateEdit11.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit11.Properties.UseReadOnlyAppearance = False
        Me.DateEdit11.Size = New System.Drawing.Size(511, 20)
        Me.DateEdit11.StyleController = Me.LayoutControl30
        Me.DateEdit11.TabIndex = 5
        '
        'TextEdit36
        '
        Me.SetBoundPropertyName(Me.TextEdit36, "")
        Me.TextEdit36.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit36.Name = "TextEdit36"
        Me.TextEdit36.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit36.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit36.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit36.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit36.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit36.Properties.ReadOnly = True
        Me.TextEdit36.Properties.UseReadOnlyAppearance = False
        Me.TextEdit36.Size = New System.Drawing.Size(309, 20)
        Me.TextEdit36.StyleController = Me.LayoutControl30
        Me.TextEdit36.TabIndex = 4
        '
        'TextEdit37
        '
        Me.SetBoundPropertyName(Me.TextEdit37, "")
        Me.TextEdit37.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit37.Name = "TextEdit37"
        Me.TextEdit37.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit37.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit37.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit37.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit37.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit37.Properties.ReadOnly = True
        Me.TextEdit37.Properties.UseReadOnlyAppearance = False
        Me.TextEdit37.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit37.StyleController = Me.LayoutControl30
        Me.TextEdit37.TabIndex = 4
        '
        'TextEdit38
        '
        Me.SetBoundPropertyName(Me.TextEdit38, "")
        Me.TextEdit38.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit38.Name = "TextEdit38"
        Me.TextEdit38.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit38.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit38.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit38.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit38.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit38.Properties.ReadOnly = True
        Me.TextEdit38.Properties.UseReadOnlyAppearance = False
        Me.TextEdit38.Size = New System.Drawing.Size(309, 20)
        Me.TextEdit38.StyleController = Me.LayoutControl30
        Me.TextEdit38.TabIndex = 4
        '
        'TextEdit39
        '
        Me.SetBoundPropertyName(Me.TextEdit39, "")
        Me.TextEdit39.Location = New System.Drawing.Point(75, 84)
        Me.TextEdit39.Name = "TextEdit39"
        Me.TextEdit39.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit39.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit39.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit39.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit39.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit39.Properties.ReadOnly = True
        Me.TextEdit39.Properties.UseReadOnlyAppearance = False
        Me.TextEdit39.Size = New System.Drawing.Size(972, 20)
        Me.TextEdit39.StyleController = Me.LayoutControl30
        Me.TextEdit39.TabIndex = 4
        '
        'DateEdit12
        '
        Me.SetBoundPropertyName(Me.DateEdit12, "")
        Me.DateEdit12.EditValue = Nothing
        Me.DateEdit12.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit12.Name = "DateEdit12"
        Me.DateEdit12.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit12.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit12.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit12.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit12.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit12.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit12.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit12.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit12.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit12.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit12.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit12.Properties.ReadOnly = True
        Me.DateEdit12.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit12.Properties.UseReadOnlyAppearance = False
        Me.DateEdit12.Size = New System.Drawing.Size(161, 20)
        Me.DateEdit12.StyleController = Me.LayoutControl30
        Me.DateEdit12.TabIndex = 5
        '
        'DateEdit13
        '
        Me.SetBoundPropertyName(Me.DateEdit13, "")
        Me.DateEdit13.EditValue = Nothing
        Me.DateEdit13.Location = New System.Drawing.Point(403, 108)
        Me.DateEdit13.Name = "DateEdit13"
        Me.DateEdit13.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit13.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit13.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit13.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit13.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit13.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit13.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit13.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit13.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit13.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit13.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit13.Properties.ReadOnly = True
        Me.DateEdit13.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit13.Properties.UseReadOnlyAppearance = False
        Me.DateEdit13.Size = New System.Drawing.Size(424, 20)
        Me.DateEdit13.StyleController = Me.LayoutControl30
        Me.DateEdit13.TabIndex = 5
        '
        'ImageComboBoxEdit9
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit9, "")
        Me.ImageComboBoxEdit9.Location = New System.Drawing.Point(912, 108)
        Me.ImageComboBoxEdit9.Name = "ImageComboBoxEdit9"
        Me.ImageComboBoxEdit9.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit9.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit9.Properties.ReadOnly = True
        Me.ImageComboBoxEdit9.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit9.Size = New System.Drawing.Size(135, 20)
        Me.ImageComboBoxEdit9.StyleController = Me.LayoutControl30
        Me.ImageComboBoxEdit9.TabIndex = 6
        '
        'LayoutControlGroup32
        '
        Me.LayoutControlGroup32.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup32.GroupBordersVisible = False
        Me.LayoutControlGroup32.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem90, Me.EmptySpaceItem25, Me.LayoutControlItem101, Me.LayoutControlItem102, Me.LayoutControlItem103, Me.LayoutControlItem104, Me.LayoutControlItem106, Me.LayoutControlItem107, Me.LayoutControlItem108, Me.LayoutControlItem109})
        Me.LayoutControlGroup32.Name = "Root"
        Me.LayoutControlGroup32.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup32.TextVisible = False
        '
        'LayoutControlItem90
        '
        Me.LayoutControlItem90.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem90.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem90.Control = Me.TextEdit36
        Me.LayoutControlItem90.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem90.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem90.Name = "LayoutControlItem3"
        Me.LayoutControlItem90.Size = New System.Drawing.Size(445, 24)
        Me.LayoutControlItem90.Text = "Message Template ID:"
        Me.LayoutControlItem90.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem25
        '
        Me.EmptySpaceItem25.AllowHotTrack = False
        Me.EmptySpaceItem25.Location = New System.Drawing.Point(0, 120)
        Me.EmptySpaceItem25.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem25.Size = New System.Drawing.Size(1039, 91)
        Me.EmptySpaceItem25.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem101
        '
        Me.LayoutControlItem101.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem101.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem101.Control = Me.DateEdit11
        Me.LayoutControlItem101.Location = New System.Drawing.Point(445, 0)
        Me.LayoutControlItem101.Name = "LayoutControlItem4"
        Me.LayoutControlItem101.Size = New System.Drawing.Size(594, 24)
        Me.LayoutControlItem101.Text = "Melde Monat"
        Me.LayoutControlItem101.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem101.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem101.TextToControlDistance = 5
        '
        'LayoutControlItem102
        '
        Me.LayoutControlItem102.Control = Me.TextEdit37
        Me.LayoutControlItem102.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem102.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem102.Name = "LayoutControlItem17"
        Me.LayoutControlItem102.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem102.Text = "Message File Name:"
        Me.LayoutControlItem102.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem103
        '
        Me.LayoutControlItem103.Control = Me.TextEdit38
        Me.LayoutControlItem103.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem103.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem103.Name = "LayoutControlItem25"
        Me.LayoutControlItem103.Size = New System.Drawing.Size(445, 24)
        Me.LayoutControlItem103.Text = "Client Name:"
        Me.LayoutControlItem103.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem104
        '
        Me.LayoutControlItem104.Control = Me.ImageComboBoxEdit8
        Me.LayoutControlItem104.Location = New System.Drawing.Point(445, 48)
        Me.LayoutControlItem104.Name = "LayoutControlItem19"
        Me.LayoutControlItem104.Size = New System.Drawing.Size(594, 24)
        Me.LayoutControlItem104.Text = "Client Status"
        Me.LayoutControlItem104.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem104.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem104.TextToControlDistance = 5
        '
        'LayoutControlItem106
        '
        Me.LayoutControlItem106.Control = Me.TextEdit39
        Me.LayoutControlItem106.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem106.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem106.Name = "LayoutControlItem47"
        Me.LayoutControlItem106.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem106.Text = "Contract Nr:"
        Me.LayoutControlItem106.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem106.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem106.TextToControlDistance = 3
        '
        'LayoutControlItem107
        '
        Me.LayoutControlItem107.Control = Me.DateEdit12
        Me.LayoutControlItem107.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem107.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem107.Name = "LayoutControlItem59"
        Me.LayoutControlItem107.Size = New System.Drawing.Size(297, 24)
        Me.LayoutControlItem107.Text = "Contract Start Date"
        Me.LayoutControlItem107.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem108
        '
        Me.LayoutControlItem108.Control = Me.DateEdit13
        Me.LayoutControlItem108.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem108.Location = New System.Drawing.Point(297, 96)
        Me.LayoutControlItem108.Name = "LayoutControlItem71"
        Me.LayoutControlItem108.Size = New System.Drawing.Size(522, 24)
        Me.LayoutControlItem108.Text = "Contract End Date"
        Me.LayoutControlItem108.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem108.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem108.TextToControlDistance = 5
        '
        'LayoutControlItem109
        '
        Me.LayoutControlItem109.Control = Me.ImageComboBoxEdit9
        Me.LayoutControlItem109.CustomizationFormText = "Contract Status"
        Me.LayoutControlItem109.Location = New System.Drawing.Point(819, 96)
        Me.LayoutControlItem109.Name = "LayoutControlItem85"
        Me.LayoutControlItem109.Size = New System.Drawing.Size(220, 24)
        Me.LayoutControlItem109.Text = "Contract Status"
        Me.LayoutControlItem109.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem109.TextSize = New System.Drawing.Size(76, 13)
        Me.LayoutControlItem109.TextToControlDistance = 5
        '
        'LayoutControl31
        '
        Me.SetBoundPropertyName(Me.LayoutControl31, "")
        Me.LayoutControl31.Location = New System.Drawing.Point(12, 247)
        Me.LayoutControl31.Name = "LayoutControl31"
        Me.LayoutControl31.Root = Me.LayoutControlGroup33
        Me.LayoutControl31.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl31.TabIndex = 4
        '
        'LayoutControlGroup33
        '
        Me.LayoutControlGroup33.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup33.GroupBordersVisible = False
        Me.LayoutControlGroup33.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem110})
        Me.LayoutControlGroup33.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup33.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup33.TextVisible = False
        '
        'LayoutControlItem110
        '
        Me.LayoutControlItem110.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem110.Name = "item"
        Me.LayoutControlItem110.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem110.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem110.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit40
        '
        Me.SetBoundPropertyName(Me.TextEdit40, "")
        Me.TextEdit40.Location = New System.Drawing.Point(88, 313)
        Me.TextEdit40.Name = "TextEdit40"
        Me.TextEdit40.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit40.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit40.Properties.Appearance.Options.UseFont = True
        Me.TextEdit40.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit40.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit40.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit40.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit40.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit40.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit40.Properties.ReadOnly = True
        Me.TextEdit40.Properties.UseReadOnlyAppearance = False
        Me.TextEdit40.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit40.StyleController = Me.LayoutControl29
        Me.TextEdit40.TabIndex = 4
        '
        'LayoutControlGroup34
        '
        Me.LayoutControlGroup34.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup34.GroupBordersVisible = False
        Me.LayoutControlGroup34.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem111, Me.LayoutControlItem112, Me.LayoutControlItem113, Me.LayoutControlItem114, Me.EmptySpaceItem26, Me.EmptySpaceItem27})
        Me.LayoutControlGroup34.Name = "Root"
        Me.LayoutControlGroup34.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup34.TextVisible = False
        '
        'LayoutControlItem111
        '
        Me.LayoutControlItem111.Control = Me.LayoutControl30
        Me.LayoutControlItem111.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem111.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem111.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem111.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem111.TextVisible = False
        '
        'LayoutControlItem112
        '
        Me.LayoutControlItem112.Control = Me.LayoutControl31
        Me.LayoutControlItem112.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem112.Name = "LayoutControlItem1"
        Me.LayoutControlItem112.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem112.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem112.TextVisible = False
        '
        'LayoutControlItem113
        '
        Me.LayoutControlItem113.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem113.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem113.Control = Me.MemoEdit11
        Me.LayoutControlItem113.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem113.Name = "LayoutControlItem2"
        Me.LayoutControlItem113.Size = New System.Drawing.Size(1063, 178)
        Me.LayoutControlItem113.Text = "Validation Code Description"
        Me.LayoutControlItem113.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem113.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem114
        '
        Me.LayoutControlItem114.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem114.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem114.Control = Me.TextEdit40
        Me.LayoutControlItem114.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem114.Location = New System.Drawing.Point(0, 301)
        Me.LayoutControlItem114.Name = "LayoutControlItem9"
        Me.LayoutControlItem114.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem114.Text = "Validation ID:"
        Me.LayoutControlItem114.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem114.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem114.TextToControlDistance = 3
        '
        'EmptySpaceItem26
        '
        Me.EmptySpaceItem26.AllowHotTrack = False
        Me.EmptySpaceItem26.Location = New System.Drawing.Point(218, 301)
        Me.EmptySpaceItem26.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem26.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem26.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem27
        '
        Me.EmptySpaceItem27.AllowHotTrack = False
        Me.EmptySpaceItem27.Location = New System.Drawing.Point(0, 505)
        Me.EmptySpaceItem27.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem27.Size = New System.Drawing.Size(1063, 10)
        Me.EmptySpaceItem27.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl32
        '
        Me.SetBoundPropertyName(Me.LayoutControl32, "")
        Me.LayoutControl32.Controls.Add(Me.MemoEdit12)
        Me.LayoutControl32.Controls.Add(Me.LayoutControl33)
        Me.LayoutControl32.Controls.Add(Me.LayoutControl34)
        Me.LayoutControl32.Controls.Add(Me.TextEdit46)
        Me.LayoutControl32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl32.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl32.Name = "LayoutControl32"
        Me.LayoutControl32.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl32.Root = Me.LayoutControlGroup37
        Me.LayoutControl32.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl32.TabIndex = 2
        '
        'MemoEdit12
        '
        Me.SetBoundPropertyName(Me.MemoEdit12, "")
        Me.MemoEdit12.Location = New System.Drawing.Point(12, 357)
        Me.MemoEdit12.Name = "MemoEdit12"
        Me.MemoEdit12.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit12.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit12.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit12.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit12.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit12.Properties.ReadOnly = True
        Me.MemoEdit12.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit12.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit12.Size = New System.Drawing.Size(1059, 156)
        Me.MemoEdit12.StyleController = Me.LayoutControl32
        Me.MemoEdit12.TabIndex = 0
        '
        'LayoutControl33
        '
        Me.SetBoundPropertyName(Me.LayoutControl33, "")
        Me.LayoutControl33.Controls.Add(Me.ImageComboBoxEdit10)
        Me.LayoutControl33.Controls.Add(Me.DateEdit14)
        Me.LayoutControl33.Controls.Add(Me.TextEdit35)
        Me.LayoutControl33.Controls.Add(Me.TextEdit41)
        Me.LayoutControl33.Controls.Add(Me.TextEdit42)
        Me.LayoutControl33.Controls.Add(Me.TextEdit43)
        Me.LayoutControl33.Controls.Add(Me.DateEdit15)
        Me.LayoutControl33.Controls.Add(Me.DateEdit16)
        Me.LayoutControl33.Controls.Add(Me.ImageComboBoxEdit11)
        Me.LayoutControl33.Controls.Add(Me.TextEdit44)
        Me.LayoutControl33.Controls.Add(Me.TextEdit45)
        Me.LayoutControl33.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl33.Name = "LayoutControl33"
        Me.LayoutControl33.Root = Me.LayoutControlGroup35
        Me.LayoutControl33.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl33.TabIndex = 1
        '
        'ImageComboBoxEdit10
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit10, "")
        Me.ImageComboBoxEdit10.Location = New System.Drawing.Point(880, 60)
        Me.ImageComboBoxEdit10.Name = "ImageComboBoxEdit10"
        Me.ImageComboBoxEdit10.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit10.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit10.Properties.ReadOnly = True
        Me.ImageComboBoxEdit10.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit10.Size = New System.Drawing.Size(167, 20)
        Me.ImageComboBoxEdit10.StyleController = Me.LayoutControl33
        Me.ImageComboBoxEdit10.TabIndex = 6
        '
        'DateEdit14
        '
        Me.SetBoundPropertyName(Me.DateEdit14, "")
        Me.DateEdit14.EditValue = Nothing
        Me.DateEdit14.Location = New System.Drawing.Point(893, 12)
        Me.DateEdit14.Name = "DateEdit14"
        Me.DateEdit14.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit14.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit14.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit14.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit14.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit14.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit14.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit14.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit14.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit14.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit14.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit14.Properties.ReadOnly = True
        Me.DateEdit14.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit14.Properties.UseReadOnlyAppearance = False
        Me.DateEdit14.Size = New System.Drawing.Size(154, 20)
        Me.DateEdit14.StyleController = Me.LayoutControl33
        Me.DateEdit14.TabIndex = 5
        '
        'TextEdit35
        '
        Me.SetBoundPropertyName(Me.TextEdit35, "")
        Me.TextEdit35.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit35.Name = "TextEdit35"
        Me.TextEdit35.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit35.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit35.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit35.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit35.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit35.Properties.ReadOnly = True
        Me.TextEdit35.Properties.UseReadOnlyAppearance = False
        Me.TextEdit35.Size = New System.Drawing.Size(666, 20)
        Me.TextEdit35.StyleController = Me.LayoutControl33
        Me.TextEdit35.TabIndex = 4
        '
        'TextEdit41
        '
        Me.SetBoundPropertyName(Me.TextEdit41, "")
        Me.TextEdit41.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit41.Name = "TextEdit41"
        Me.TextEdit41.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit41.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit41.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit41.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit41.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit41.Properties.ReadOnly = True
        Me.TextEdit41.Properties.UseReadOnlyAppearance = False
        Me.TextEdit41.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit41.StyleController = Me.LayoutControl33
        Me.TextEdit41.TabIndex = 4
        '
        'TextEdit42
        '
        Me.SetBoundPropertyName(Me.TextEdit42, "")
        Me.TextEdit42.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit42.Name = "TextEdit42"
        Me.TextEdit42.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit42.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit42.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit42.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit42.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit42.Properties.ReadOnly = True
        Me.TextEdit42.Properties.UseReadOnlyAppearance = False
        Me.TextEdit42.Size = New System.Drawing.Size(666, 20)
        Me.TextEdit42.StyleController = Me.LayoutControl33
        Me.TextEdit42.TabIndex = 4
        '
        'TextEdit43
        '
        Me.SetBoundPropertyName(Me.TextEdit43, "")
        Me.TextEdit43.Location = New System.Drawing.Point(75, 84)
        Me.TextEdit43.Name = "TextEdit43"
        Me.TextEdit43.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit43.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit43.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit43.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit43.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit43.Properties.ReadOnly = True
        Me.TextEdit43.Properties.UseReadOnlyAppearance = False
        Me.TextEdit43.Size = New System.Drawing.Size(972, 20)
        Me.TextEdit43.StyleController = Me.LayoutControl33
        Me.TextEdit43.TabIndex = 4
        '
        'DateEdit15
        '
        Me.SetBoundPropertyName(Me.DateEdit15, "")
        Me.DateEdit15.EditValue = Nothing
        Me.DateEdit15.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit15.Name = "DateEdit15"
        Me.DateEdit15.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit15.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit15.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit15.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit15.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit15.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit15.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit15.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit15.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit15.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit15.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit15.Properties.ReadOnly = True
        Me.DateEdit15.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit15.Properties.UseReadOnlyAppearance = False
        Me.DateEdit15.Size = New System.Drawing.Size(124, 20)
        Me.DateEdit15.StyleController = Me.LayoutControl33
        Me.DateEdit15.TabIndex = 5
        '
        'DateEdit16
        '
        Me.SetBoundPropertyName(Me.DateEdit16, "")
        Me.DateEdit16.EditValue = Nothing
        Me.DateEdit16.Location = New System.Drawing.Point(366, 108)
        Me.DateEdit16.Name = "DateEdit16"
        Me.DateEdit16.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit16.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit16.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit16.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit16.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit16.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit16.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit16.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit16.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit16.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit16.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit16.Properties.ReadOnly = True
        Me.DateEdit16.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit16.Properties.UseReadOnlyAppearance = False
        Me.DateEdit16.Size = New System.Drawing.Size(161, 20)
        Me.DateEdit16.StyleController = Me.LayoutControl33
        Me.DateEdit16.TabIndex = 5
        '
        'ImageComboBoxEdit11
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit11, "")
        Me.ImageComboBoxEdit11.Location = New System.Drawing.Point(612, 108)
        Me.ImageComboBoxEdit11.Name = "ImageComboBoxEdit11"
        Me.ImageComboBoxEdit11.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit11.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit11.Properties.ReadOnly = True
        Me.ImageComboBoxEdit11.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit11.Size = New System.Drawing.Size(435, 20)
        Me.ImageComboBoxEdit11.StyleController = Me.LayoutControl33
        Me.ImageComboBoxEdit11.TabIndex = 6
        '
        'TextEdit44
        '
        Me.SetBoundPropertyName(Me.TextEdit44, "")
        Me.TextEdit44.Location = New System.Drawing.Point(144, 132)
        Me.TextEdit44.Name = "TextEdit44"
        Me.TextEdit44.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit44.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit44.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit44.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit44.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit44.Properties.ReadOnly = True
        Me.TextEdit44.Properties.UseReadOnlyAppearance = False
        Me.TextEdit44.Size = New System.Drawing.Size(124, 20)
        Me.TextEdit44.StyleController = Me.LayoutControl33
        Me.TextEdit44.TabIndex = 4
        '
        'TextEdit45
        '
        Me.SetBoundPropertyName(Me.TextEdit45, "")
        Me.TextEdit45.Location = New System.Drawing.Point(404, 132)
        Me.TextEdit45.Name = "TextEdit45"
        Me.TextEdit45.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit45.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit45.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit45.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit45.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit45.Properties.ReadOnly = True
        Me.TextEdit45.Properties.UseReadOnlyAppearance = False
        Me.TextEdit45.Size = New System.Drawing.Size(643, 20)
        Me.TextEdit45.StyleController = Me.LayoutControl33
        Me.TextEdit45.TabIndex = 4
        '
        'LayoutControlGroup35
        '
        Me.LayoutControlGroup35.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup35.GroupBordersVisible = False
        Me.LayoutControlGroup35.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem105, Me.EmptySpaceItem28, Me.LayoutControlItem116, Me.LayoutControlItem117, Me.LayoutControlItem118, Me.LayoutControlItem119, Me.LayoutControlItem121, Me.LayoutControlItem122, Me.LayoutControlItem123, Me.LayoutControlItem124, Me.LayoutControlItem125, Me.LayoutControlItem126})
        Me.LayoutControlGroup35.Name = "Root"
        Me.LayoutControlGroup35.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup35.TextVisible = False
        '
        'LayoutControlItem105
        '
        Me.LayoutControlItem105.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem105.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem105.Control = Me.TextEdit35
        Me.LayoutControlItem105.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem105.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem105.Name = "LayoutControlItem3"
        Me.LayoutControlItem105.Size = New System.Drawing.Size(802, 24)
        Me.LayoutControlItem105.Text = "Message Template ID:"
        Me.LayoutControlItem105.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem28
        '
        Me.EmptySpaceItem28.AllowHotTrack = False
        Me.EmptySpaceItem28.Location = New System.Drawing.Point(0, 144)
        Me.EmptySpaceItem28.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem28.Size = New System.Drawing.Size(1039, 67)
        Me.EmptySpaceItem28.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem116
        '
        Me.LayoutControlItem116.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem116.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem116.Control = Me.DateEdit14
        Me.LayoutControlItem116.Location = New System.Drawing.Point(802, 0)
        Me.LayoutControlItem116.Name = "LayoutControlItem4"
        Me.LayoutControlItem116.Size = New System.Drawing.Size(237, 24)
        Me.LayoutControlItem116.Text = "Melde Monat"
        Me.LayoutControlItem116.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem116.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem116.TextToControlDistance = 5
        '
        'LayoutControlItem117
        '
        Me.LayoutControlItem117.Control = Me.TextEdit41
        Me.LayoutControlItem117.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem117.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem117.Name = "LayoutControlItem17"
        Me.LayoutControlItem117.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem117.Text = "Message File Name:"
        Me.LayoutControlItem117.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem118
        '
        Me.LayoutControlItem118.Control = Me.TextEdit42
        Me.LayoutControlItem118.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem118.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem118.Name = "LayoutControlItem25"
        Me.LayoutControlItem118.Size = New System.Drawing.Size(802, 24)
        Me.LayoutControlItem118.Text = "Client Name:"
        Me.LayoutControlItem118.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem119
        '
        Me.LayoutControlItem119.Control = Me.ImageComboBoxEdit10
        Me.LayoutControlItem119.Location = New System.Drawing.Point(802, 48)
        Me.LayoutControlItem119.Name = "LayoutControlItem19"
        Me.LayoutControlItem119.Size = New System.Drawing.Size(237, 24)
        Me.LayoutControlItem119.Text = "Client Status"
        Me.LayoutControlItem119.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem119.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem119.TextToControlDistance = 5
        '
        'LayoutControlItem121
        '
        Me.LayoutControlItem121.Control = Me.TextEdit43
        Me.LayoutControlItem121.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem121.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem121.Name = "LayoutControlItem47"
        Me.LayoutControlItem121.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem121.Text = "Contract Nr:"
        Me.LayoutControlItem121.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem121.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem121.TextToControlDistance = 3
        '
        'LayoutControlItem122
        '
        Me.LayoutControlItem122.Control = Me.DateEdit15
        Me.LayoutControlItem122.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem122.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem122.Name = "LayoutControlItem59"
        Me.LayoutControlItem122.Size = New System.Drawing.Size(260, 24)
        Me.LayoutControlItem122.Text = "Contract Start Date"
        Me.LayoutControlItem122.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem123
        '
        Me.LayoutControlItem123.Control = Me.DateEdit16
        Me.LayoutControlItem123.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem123.Location = New System.Drawing.Point(260, 96)
        Me.LayoutControlItem123.Name = "LayoutControlItem71"
        Me.LayoutControlItem123.Size = New System.Drawing.Size(259, 24)
        Me.LayoutControlItem123.Text = "Contract End Date"
        Me.LayoutControlItem123.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem123.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem123.TextToControlDistance = 5
        '
        'LayoutControlItem124
        '
        Me.LayoutControlItem124.Control = Me.ImageComboBoxEdit11
        Me.LayoutControlItem124.CustomizationFormText = "Contract Status"
        Me.LayoutControlItem124.Location = New System.Drawing.Point(519, 96)
        Me.LayoutControlItem124.Name = "LayoutControlItem85"
        Me.LayoutControlItem124.Size = New System.Drawing.Size(520, 24)
        Me.LayoutControlItem124.Text = "Contract Status"
        Me.LayoutControlItem124.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem124.TextSize = New System.Drawing.Size(76, 13)
        Me.LayoutControlItem124.TextToControlDistance = 5
        '
        'LayoutControlItem125
        '
        Me.LayoutControlItem125.Control = Me.TextEdit44
        Me.LayoutControlItem125.CustomizationFormText = "ContractProductType:"
        Me.LayoutControlItem125.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem125.Name = "LayoutControlItem100"
        Me.LayoutControlItem125.Size = New System.Drawing.Size(260, 24)
        Me.LayoutControlItem125.Text = "Contract Product Type:"
        Me.LayoutControlItem125.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem126
        '
        Me.LayoutControlItem126.Control = Me.TextEdit45
        Me.LayoutControlItem126.CustomizationFormText = "ContractProductName:"
        Me.LayoutControlItem126.Location = New System.Drawing.Point(260, 120)
        Me.LayoutControlItem126.Name = "LayoutControlItem115"
        Me.LayoutControlItem126.Size = New System.Drawing.Size(779, 24)
        Me.LayoutControlItem126.Text = "Contract Product Name:"
        Me.LayoutControlItem126.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControl34
        '
        Me.SetBoundPropertyName(Me.LayoutControl34, "")
        Me.LayoutControl34.Location = New System.Drawing.Point(12, 247)
        Me.LayoutControl34.Name = "LayoutControl34"
        Me.LayoutControl34.Root = Me.LayoutControlGroup36
        Me.LayoutControl34.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControl34.TabIndex = 4
        '
        'LayoutControlGroup36
        '
        Me.LayoutControlGroup36.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup36.GroupBordersVisible = False
        Me.LayoutControlGroup36.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem127})
        Me.LayoutControlGroup36.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup36.Size = New System.Drawing.Size(1059, 62)
        Me.LayoutControlGroup36.TextVisible = False
        '
        'LayoutControlItem127
        '
        Me.LayoutControlItem127.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem127.Name = "item"
        Me.LayoutControlItem127.Size = New System.Drawing.Size(1039, 42)
        Me.LayoutControlItem127.TextLocation = DevExpress.Utils.Locations.Bottom
        Me.LayoutControlItem127.TextSize = New System.Drawing.Size(20, 13)
        '
        'TextEdit46
        '
        Me.SetBoundPropertyName(Me.TextEdit46, "")
        Me.TextEdit46.Location = New System.Drawing.Point(88, 313)
        Me.TextEdit46.Name = "TextEdit46"
        Me.TextEdit46.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit46.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit46.Properties.Appearance.Options.UseFont = True
        Me.TextEdit46.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit46.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit46.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit46.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit46.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit46.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit46.Properties.ReadOnly = True
        Me.TextEdit46.Properties.UseReadOnlyAppearance = False
        Me.TextEdit46.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit46.StyleController = Me.LayoutControl32
        Me.TextEdit46.TabIndex = 4
        '
        'LayoutControlGroup37
        '
        Me.LayoutControlGroup37.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup37.GroupBordersVisible = False
        Me.LayoutControlGroup37.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem128, Me.LayoutControlItem129, Me.LayoutControlItem130, Me.LayoutControlItem131, Me.EmptySpaceItem29, Me.EmptySpaceItem30})
        Me.LayoutControlGroup37.Name = "Root"
        Me.LayoutControlGroup37.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup37.TextVisible = False
        '
        'LayoutControlItem128
        '
        Me.LayoutControlItem128.Control = Me.LayoutControl33
        Me.LayoutControlItem128.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem128.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem128.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem128.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem128.TextVisible = False
        '
        'LayoutControlItem129
        '
        Me.LayoutControlItem129.Control = Me.LayoutControl34
        Me.LayoutControlItem129.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem129.Name = "LayoutControlItem1"
        Me.LayoutControlItem129.Size = New System.Drawing.Size(1063, 66)
        Me.LayoutControlItem129.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem129.TextVisible = False
        '
        'LayoutControlItem130
        '
        Me.LayoutControlItem130.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem130.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem130.Control = Me.MemoEdit12
        Me.LayoutControlItem130.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem130.Name = "LayoutControlItem2"
        Me.LayoutControlItem130.Size = New System.Drawing.Size(1063, 178)
        Me.LayoutControlItem130.Text = "Validation Code Description"
        Me.LayoutControlItem130.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem130.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem131
        '
        Me.LayoutControlItem131.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem131.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem131.Control = Me.TextEdit46
        Me.LayoutControlItem131.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem131.Location = New System.Drawing.Point(0, 301)
        Me.LayoutControlItem131.Name = "LayoutControlItem9"
        Me.LayoutControlItem131.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem131.Text = "Validation ID:"
        Me.LayoutControlItem131.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem131.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem131.TextToControlDistance = 3
        '
        'EmptySpaceItem29
        '
        Me.EmptySpaceItem29.AllowHotTrack = False
        Me.EmptySpaceItem29.Location = New System.Drawing.Point(218, 301)
        Me.EmptySpaceItem29.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem29.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem29.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem30
        '
        Me.EmptySpaceItem30.AllowHotTrack = False
        Me.EmptySpaceItem30.Location = New System.Drawing.Point(0, 505)
        Me.EmptySpaceItem30.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem30.Size = New System.Drawing.Size(1063, 10)
        Me.EmptySpaceItem30.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl35
        '
        Me.SetBoundPropertyName(Me.LayoutControl35, "")
        Me.LayoutControl35.Controls.Add(Me.MemoEdit13)
        Me.LayoutControl35.Controls.Add(Me.LayoutControl36)
        Me.LayoutControl35.Controls.Add(Me.TextEdit53)
        Me.LayoutControl35.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl35.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl35.Name = "LayoutControl35"
        Me.LayoutControl35.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl35.Root = Me.LayoutControlGroup38
        Me.LayoutControl35.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl35.TabIndex = 2
        '
        'MemoEdit13
        '
        Me.SetBoundPropertyName(Me.MemoEdit13, "")
        Me.MemoEdit13.Location = New System.Drawing.Point(12, 291)
        Me.MemoEdit13.Name = "MemoEdit13"
        Me.MemoEdit13.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit13.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit13.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit13.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit13.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit13.Properties.ReadOnly = True
        Me.MemoEdit13.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit13.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit13.Size = New System.Drawing.Size(1059, 221)
        Me.MemoEdit13.StyleController = Me.LayoutControl35
        Me.MemoEdit13.TabIndex = 0
        '
        'LayoutControl36
        '
        Me.SetBoundPropertyName(Me.LayoutControl36, "")
        Me.LayoutControl36.Controls.Add(Me.ImageComboBoxEdit12)
        Me.LayoutControl36.Controls.Add(Me.DateEdit17)
        Me.LayoutControl36.Controls.Add(Me.TextEdit47)
        Me.LayoutControl36.Controls.Add(Me.TextEdit48)
        Me.LayoutControl36.Controls.Add(Me.TextEdit49)
        Me.LayoutControl36.Controls.Add(Me.TextEdit50)
        Me.LayoutControl36.Controls.Add(Me.DateEdit18)
        Me.LayoutControl36.Controls.Add(Me.DateEdit19)
        Me.LayoutControl36.Controls.Add(Me.ImageComboBoxEdit13)
        Me.LayoutControl36.Controls.Add(Me.TextEdit51)
        Me.LayoutControl36.Controls.Add(Me.TextEdit52)
        Me.LayoutControl36.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl36.Name = "LayoutControl36"
        Me.LayoutControl36.Root = Me.LayoutControlGroup4
        Me.LayoutControl36.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl36.TabIndex = 1
        '
        'ImageComboBoxEdit12
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit12, "")
        Me.ImageComboBoxEdit12.Location = New System.Drawing.Point(612, 60)
        Me.ImageComboBoxEdit12.Name = "ImageComboBoxEdit12"
        Me.ImageComboBoxEdit12.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit12.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit12.Properties.ReadOnly = True
        Me.ImageComboBoxEdit12.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit12.Size = New System.Drawing.Size(435, 20)
        Me.ImageComboBoxEdit12.StyleController = Me.LayoutControl36
        Me.ImageComboBoxEdit12.TabIndex = 6
        '
        'DateEdit17
        '
        Me.SetBoundPropertyName(Me.DateEdit17, "")
        Me.DateEdit17.EditValue = Nothing
        Me.DateEdit17.Location = New System.Drawing.Point(625, 12)
        Me.DateEdit17.Name = "DateEdit17"
        Me.DateEdit17.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit17.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit17.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit17.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit17.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit17.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit17.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit17.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit17.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit17.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit17.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit17.Properties.ReadOnly = True
        Me.DateEdit17.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit17.Properties.UseReadOnlyAppearance = False
        Me.DateEdit17.Size = New System.Drawing.Size(422, 20)
        Me.DateEdit17.StyleController = Me.LayoutControl36
        Me.DateEdit17.TabIndex = 5
        '
        'TextEdit47
        '
        Me.SetBoundPropertyName(Me.TextEdit47, "")
        Me.TextEdit47.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit47.Name = "TextEdit47"
        Me.TextEdit47.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit47.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit47.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit47.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit47.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit47.Properties.ReadOnly = True
        Me.TextEdit47.Properties.UseReadOnlyAppearance = False
        Me.TextEdit47.Size = New System.Drawing.Size(398, 20)
        Me.TextEdit47.StyleController = Me.LayoutControl36
        Me.TextEdit47.TabIndex = 4
        '
        'TextEdit48
        '
        Me.SetBoundPropertyName(Me.TextEdit48, "")
        Me.TextEdit48.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit48.Name = "TextEdit48"
        Me.TextEdit48.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit48.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit48.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit48.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit48.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit48.Properties.ReadOnly = True
        Me.TextEdit48.Properties.UseReadOnlyAppearance = False
        Me.TextEdit48.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit48.StyleController = Me.LayoutControl36
        Me.TextEdit48.TabIndex = 4
        '
        'TextEdit49
        '
        Me.SetBoundPropertyName(Me.TextEdit49, "")
        Me.TextEdit49.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit49.Name = "TextEdit49"
        Me.TextEdit49.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit49.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit49.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit49.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit49.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit49.Properties.ReadOnly = True
        Me.TextEdit49.Properties.UseReadOnlyAppearance = False
        Me.TextEdit49.Size = New System.Drawing.Size(398, 20)
        Me.TextEdit49.StyleController = Me.LayoutControl36
        Me.TextEdit49.TabIndex = 4
        '
        'TextEdit50
        '
        Me.SetBoundPropertyName(Me.TextEdit50, "")
        Me.TextEdit50.Location = New System.Drawing.Point(75, 84)
        Me.TextEdit50.Name = "TextEdit50"
        Me.TextEdit50.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit50.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit50.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit50.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit50.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit50.Properties.ReadOnly = True
        Me.TextEdit50.Properties.UseReadOnlyAppearance = False
        Me.TextEdit50.Size = New System.Drawing.Size(972, 20)
        Me.TextEdit50.StyleController = Me.LayoutControl36
        Me.TextEdit50.TabIndex = 4
        '
        'DateEdit18
        '
        Me.SetBoundPropertyName(Me.DateEdit18, "")
        Me.DateEdit18.EditValue = Nothing
        Me.DateEdit18.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit18.Name = "DateEdit18"
        Me.DateEdit18.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit18.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit18.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit18.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit18.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit18.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit18.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit18.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit18.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit18.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit18.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit18.Properties.ReadOnly = True
        Me.DateEdit18.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit18.Properties.UseReadOnlyAppearance = False
        Me.DateEdit18.Size = New System.Drawing.Size(60, 20)
        Me.DateEdit18.StyleController = Me.LayoutControl36
        Me.DateEdit18.TabIndex = 5
        '
        'DateEdit19
        '
        Me.SetBoundPropertyName(Me.DateEdit19, "")
        Me.DateEdit19.EditValue = Nothing
        Me.DateEdit19.Location = New System.Drawing.Point(302, 108)
        Me.DateEdit19.Name = "DateEdit19"
        Me.DateEdit19.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit19.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit19.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit19.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit19.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit19.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit19.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit19.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit19.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit19.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit19.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit19.Properties.ReadOnly = True
        Me.DateEdit19.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit19.Properties.UseReadOnlyAppearance = False
        Me.DateEdit19.Size = New System.Drawing.Size(70, 20)
        Me.DateEdit19.StyleController = Me.LayoutControl36
        Me.DateEdit19.TabIndex = 5
        '
        'ImageComboBoxEdit13
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit13, "")
        Me.ImageComboBoxEdit13.Location = New System.Drawing.Point(457, 108)
        Me.ImageComboBoxEdit13.Name = "ImageComboBoxEdit13"
        Me.ImageComboBoxEdit13.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit13.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit13.Properties.ReadOnly = True
        Me.ImageComboBoxEdit13.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit13.Size = New System.Drawing.Size(590, 20)
        Me.ImageComboBoxEdit13.StyleController = Me.LayoutControl36
        Me.ImageComboBoxEdit13.TabIndex = 6
        '
        'TextEdit51
        '
        Me.SetBoundPropertyName(Me.TextEdit51, "")
        Me.TextEdit51.Location = New System.Drawing.Point(144, 132)
        Me.TextEdit51.Name = "TextEdit51"
        Me.TextEdit51.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit51.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit51.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit51.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit51.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit51.Properties.ReadOnly = True
        Me.TextEdit51.Properties.UseReadOnlyAppearance = False
        Me.TextEdit51.Size = New System.Drawing.Size(60, 20)
        Me.TextEdit51.StyleController = Me.LayoutControl36
        Me.TextEdit51.TabIndex = 4
        '
        'TextEdit52
        '
        Me.SetBoundPropertyName(Me.TextEdit52, "")
        Me.TextEdit52.Location = New System.Drawing.Point(340, 132)
        Me.TextEdit52.Name = "TextEdit52"
        Me.TextEdit52.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit52.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit52.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit52.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit52.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit52.Properties.ReadOnly = True
        Me.TextEdit52.Properties.UseReadOnlyAppearance = False
        Me.TextEdit52.Size = New System.Drawing.Size(707, 20)
        Me.TextEdit52.StyleController = Me.LayoutControl36
        Me.TextEdit52.TabIndex = 4
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem31, Me.LayoutControlItem120, Me.LayoutControlItem132, Me.LayoutControlItem133, Me.LayoutControlItem134, Me.LayoutControlItem136, Me.LayoutControlItem137, Me.LayoutControlItem138, Me.LayoutControlItem139, Me.LayoutControlItem140, Me.LayoutControlItem141})
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup4.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem1.Control = Me.TextEdit47
        Me.LayoutControlItem1.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem3"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(534, 24)
        Me.LayoutControlItem1.Text = "Message Template ID:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem31
        '
        Me.EmptySpaceItem31.AllowHotTrack = False
        Me.EmptySpaceItem31.Location = New System.Drawing.Point(0, 144)
        Me.EmptySpaceItem31.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem31.Size = New System.Drawing.Size(1039, 67)
        Me.EmptySpaceItem31.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem120
        '
        Me.LayoutControlItem120.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem120.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem120.Control = Me.DateEdit17
        Me.LayoutControlItem120.Location = New System.Drawing.Point(534, 0)
        Me.LayoutControlItem120.Name = "LayoutControlItem4"
        Me.LayoutControlItem120.Size = New System.Drawing.Size(505, 24)
        Me.LayoutControlItem120.Text = "Melde Monat"
        Me.LayoutControlItem120.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem120.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem120.TextToControlDistance = 5
        '
        'LayoutControlItem132
        '
        Me.LayoutControlItem132.Control = Me.TextEdit48
        Me.LayoutControlItem132.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem132.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem132.Name = "LayoutControlItem17"
        Me.LayoutControlItem132.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem132.Text = "Message File Name:"
        Me.LayoutControlItem132.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem133
        '
        Me.LayoutControlItem133.Control = Me.TextEdit49
        Me.LayoutControlItem133.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem133.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem133.Name = "LayoutControlItem25"
        Me.LayoutControlItem133.Size = New System.Drawing.Size(534, 24)
        Me.LayoutControlItem133.Text = "Client Name:"
        Me.LayoutControlItem133.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem134
        '
        Me.LayoutControlItem134.Control = Me.ImageComboBoxEdit12
        Me.LayoutControlItem134.Location = New System.Drawing.Point(534, 48)
        Me.LayoutControlItem134.Name = "LayoutControlItem19"
        Me.LayoutControlItem134.Size = New System.Drawing.Size(505, 24)
        Me.LayoutControlItem134.Text = "Client Status"
        Me.LayoutControlItem134.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem134.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem134.TextToControlDistance = 5
        '
        'LayoutControlItem136
        '
        Me.LayoutControlItem136.Control = Me.TextEdit50
        Me.LayoutControlItem136.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem136.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem136.Name = "LayoutControlItem47"
        Me.LayoutControlItem136.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem136.Text = "Contract Nr:"
        Me.LayoutControlItem136.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem136.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem136.TextToControlDistance = 3
        '
        'LayoutControlItem137
        '
        Me.LayoutControlItem137.Control = Me.DateEdit18
        Me.LayoutControlItem137.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem137.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem137.Name = "LayoutControlItem59"
        Me.LayoutControlItem137.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem137.Text = "Contract Start Date"
        Me.LayoutControlItem137.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem138
        '
        Me.LayoutControlItem138.Control = Me.DateEdit19
        Me.LayoutControlItem138.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem138.Location = New System.Drawing.Point(196, 96)
        Me.LayoutControlItem138.Name = "LayoutControlItem71"
        Me.LayoutControlItem138.Size = New System.Drawing.Size(168, 24)
        Me.LayoutControlItem138.Text = "Contract End Date"
        Me.LayoutControlItem138.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem138.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem138.TextToControlDistance = 5
        '
        'LayoutControlItem139
        '
        Me.LayoutControlItem139.Control = Me.ImageComboBoxEdit13
        Me.LayoutControlItem139.CustomizationFormText = "Contract Status"
        Me.LayoutControlItem139.Location = New System.Drawing.Point(364, 96)
        Me.LayoutControlItem139.Name = "LayoutControlItem85"
        Me.LayoutControlItem139.Size = New System.Drawing.Size(675, 24)
        Me.LayoutControlItem139.Text = "Contract Status"
        Me.LayoutControlItem139.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem139.TextSize = New System.Drawing.Size(76, 13)
        Me.LayoutControlItem139.TextToControlDistance = 5
        '
        'LayoutControlItem140
        '
        Me.LayoutControlItem140.Control = Me.TextEdit51
        Me.LayoutControlItem140.CustomizationFormText = "ContractProductType:"
        Me.LayoutControlItem140.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem140.Name = "LayoutControlItem100"
        Me.LayoutControlItem140.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem140.Text = "Contract Product Type:"
        Me.LayoutControlItem140.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem141
        '
        Me.LayoutControlItem141.Control = Me.TextEdit52
        Me.LayoutControlItem141.CustomizationFormText = "ContractProductName:"
        Me.LayoutControlItem141.Location = New System.Drawing.Point(196, 120)
        Me.LayoutControlItem141.Name = "LayoutControlItem115"
        Me.LayoutControlItem141.Size = New System.Drawing.Size(843, 24)
        Me.LayoutControlItem141.Text = "Contract Product Name:"
        Me.LayoutControlItem141.TextSize = New System.Drawing.Size(120, 13)
        '
        'TextEdit53
        '
        Me.SetBoundPropertyName(Me.TextEdit53, "")
        Me.TextEdit53.Location = New System.Drawing.Point(88, 247)
        Me.TextEdit53.Name = "TextEdit53"
        Me.TextEdit53.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit53.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit53.Properties.Appearance.Options.UseFont = True
        Me.TextEdit53.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit53.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit53.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit53.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit53.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit53.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit53.Properties.ReadOnly = True
        Me.TextEdit53.Properties.UseReadOnlyAppearance = False
        Me.TextEdit53.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit53.StyleController = Me.LayoutControl35
        Me.TextEdit53.TabIndex = 4
        '
        'LayoutControlGroup38
        '
        Me.LayoutControlGroup38.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup38.GroupBordersVisible = False
        Me.LayoutControlGroup38.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem142, Me.LayoutControlItem143, Me.LayoutControlItem144, Me.EmptySpaceItem32, Me.EmptySpaceItem33})
        Me.LayoutControlGroup38.Name = "Root"
        Me.LayoutControlGroup38.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup38.TextVisible = False
        '
        'LayoutControlItem142
        '
        Me.LayoutControlItem142.Control = Me.LayoutControl36
        Me.LayoutControlItem142.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem142.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem142.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem142.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem142.TextVisible = False
        '
        'LayoutControlItem143
        '
        Me.LayoutControlItem143.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem143.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem143.Control = Me.MemoEdit13
        Me.LayoutControlItem143.Location = New System.Drawing.Point(0, 261)
        Me.LayoutControlItem143.Name = "LayoutControlItem2"
        Me.LayoutControlItem143.Size = New System.Drawing.Size(1063, 243)
        Me.LayoutControlItem143.Text = "Validation Code Description"
        Me.LayoutControlItem143.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem143.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem144
        '
        Me.LayoutControlItem144.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem144.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem144.Control = Me.TextEdit53
        Me.LayoutControlItem144.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem144.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem144.Name = "LayoutControlItem9"
        Me.LayoutControlItem144.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem144.Text = "Validation ID:"
        Me.LayoutControlItem144.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem144.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem144.TextToControlDistance = 3
        '
        'EmptySpaceItem32
        '
        Me.EmptySpaceItem32.AllowHotTrack = False
        Me.EmptySpaceItem32.Location = New System.Drawing.Point(218, 235)
        Me.EmptySpaceItem32.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem32.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem32.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem33
        '
        Me.EmptySpaceItem33.AllowHotTrack = False
        Me.EmptySpaceItem33.Location = New System.Drawing.Point(0, 504)
        Me.EmptySpaceItem33.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem33.Size = New System.Drawing.Size(1063, 11)
        Me.EmptySpaceItem33.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl37
        '
        Me.SetBoundPropertyName(Me.LayoutControl37, "")
        Me.LayoutControl37.Controls.Add(Me.MemoEdit14)
        Me.LayoutControl37.Controls.Add(Me.LayoutControl38)
        Me.LayoutControl37.Controls.Add(Me.TextEdit61)
        Me.LayoutControl37.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl37.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl37.Name = "LayoutControl37"
        Me.LayoutControl37.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl37.Root = Me.LayoutControlGroup40
        Me.LayoutControl37.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl37.TabIndex = 2
        '
        'MemoEdit14
        '
        Me.SetBoundPropertyName(Me.MemoEdit14, "")
        Me.MemoEdit14.Location = New System.Drawing.Point(12, 291)
        Me.MemoEdit14.Name = "MemoEdit14"
        Me.MemoEdit14.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit14.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit14.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit14.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit14.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit14.Properties.ReadOnly = True
        Me.MemoEdit14.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit14.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit14.Size = New System.Drawing.Size(1059, 221)
        Me.MemoEdit14.StyleController = Me.LayoutControl37
        Me.MemoEdit14.TabIndex = 0
        '
        'LayoutControl38
        '
        Me.SetBoundPropertyName(Me.LayoutControl38, "")
        Me.LayoutControl38.Controls.Add(Me.ImageComboBoxEdit14)
        Me.LayoutControl38.Controls.Add(Me.DateEdit20)
        Me.LayoutControl38.Controls.Add(Me.TextEdit55)
        Me.LayoutControl38.Controls.Add(Me.TextEdit56)
        Me.LayoutControl38.Controls.Add(Me.TextEdit57)
        Me.LayoutControl38.Controls.Add(Me.TextEdit58)
        Me.LayoutControl38.Controls.Add(Me.DateEdit21)
        Me.LayoutControl38.Controls.Add(Me.DateEdit22)
        Me.LayoutControl38.Controls.Add(Me.ImageComboBoxEdit15)
        Me.LayoutControl38.Controls.Add(Me.TextEdit59)
        Me.LayoutControl38.Controls.Add(Me.TextEdit60)
        Me.LayoutControl38.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl38.Name = "LayoutControl38"
        Me.LayoutControl38.Root = Me.LayoutControlGroup39
        Me.LayoutControl38.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl38.TabIndex = 1
        '
        'ImageComboBoxEdit14
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit14, "")
        Me.ImageComboBoxEdit14.Location = New System.Drawing.Point(612, 60)
        Me.ImageComboBoxEdit14.Name = "ImageComboBoxEdit14"
        Me.ImageComboBoxEdit14.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit14.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit14.Properties.ReadOnly = True
        Me.ImageComboBoxEdit14.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit14.Size = New System.Drawing.Size(435, 20)
        Me.ImageComboBoxEdit14.StyleController = Me.LayoutControl38
        Me.ImageComboBoxEdit14.TabIndex = 6
        '
        'DateEdit20
        '
        Me.SetBoundPropertyName(Me.DateEdit20, "")
        Me.DateEdit20.EditValue = Nothing
        Me.DateEdit20.Location = New System.Drawing.Point(625, 12)
        Me.DateEdit20.Name = "DateEdit20"
        Me.DateEdit20.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit20.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit20.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit20.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit20.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit20.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit20.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit20.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit20.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit20.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit20.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit20.Properties.ReadOnly = True
        Me.DateEdit20.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit20.Properties.UseReadOnlyAppearance = False
        Me.DateEdit20.Size = New System.Drawing.Size(422, 20)
        Me.DateEdit20.StyleController = Me.LayoutControl38
        Me.DateEdit20.TabIndex = 5
        '
        'TextEdit55
        '
        Me.SetBoundPropertyName(Me.TextEdit55, "")
        Me.TextEdit55.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit55.Name = "TextEdit55"
        Me.TextEdit55.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit55.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit55.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit55.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit55.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit55.Properties.ReadOnly = True
        Me.TextEdit55.Properties.UseReadOnlyAppearance = False
        Me.TextEdit55.Size = New System.Drawing.Size(398, 20)
        Me.TextEdit55.StyleController = Me.LayoutControl38
        Me.TextEdit55.TabIndex = 4
        '
        'TextEdit56
        '
        Me.SetBoundPropertyName(Me.TextEdit56, "")
        Me.TextEdit56.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit56.Name = "TextEdit56"
        Me.TextEdit56.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit56.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit56.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit56.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit56.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit56.Properties.ReadOnly = True
        Me.TextEdit56.Properties.UseReadOnlyAppearance = False
        Me.TextEdit56.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit56.StyleController = Me.LayoutControl38
        Me.TextEdit56.TabIndex = 4
        '
        'TextEdit57
        '
        Me.SetBoundPropertyName(Me.TextEdit57, "")
        Me.TextEdit57.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit57.Name = "TextEdit57"
        Me.TextEdit57.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit57.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit57.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit57.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit57.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit57.Properties.ReadOnly = True
        Me.TextEdit57.Properties.UseReadOnlyAppearance = False
        Me.TextEdit57.Size = New System.Drawing.Size(398, 20)
        Me.TextEdit57.StyleController = Me.LayoutControl38
        Me.TextEdit57.TabIndex = 4
        '
        'TextEdit58
        '
        Me.SetBoundPropertyName(Me.TextEdit58, "")
        Me.TextEdit58.Location = New System.Drawing.Point(75, 84)
        Me.TextEdit58.Name = "TextEdit58"
        Me.TextEdit58.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit58.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit58.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit58.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit58.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit58.Properties.ReadOnly = True
        Me.TextEdit58.Properties.UseReadOnlyAppearance = False
        Me.TextEdit58.Size = New System.Drawing.Size(972, 20)
        Me.TextEdit58.StyleController = Me.LayoutControl38
        Me.TextEdit58.TabIndex = 4
        '
        'DateEdit21
        '
        Me.SetBoundPropertyName(Me.DateEdit21, "")
        Me.DateEdit21.EditValue = Nothing
        Me.DateEdit21.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit21.Name = "DateEdit21"
        Me.DateEdit21.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit21.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit21.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit21.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit21.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit21.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit21.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit21.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit21.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit21.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit21.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit21.Properties.ReadOnly = True
        Me.DateEdit21.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit21.Properties.UseReadOnlyAppearance = False
        Me.DateEdit21.Size = New System.Drawing.Size(60, 20)
        Me.DateEdit21.StyleController = Me.LayoutControl38
        Me.DateEdit21.TabIndex = 5
        '
        'DateEdit22
        '
        Me.SetBoundPropertyName(Me.DateEdit22, "")
        Me.DateEdit22.EditValue = Nothing
        Me.DateEdit22.Location = New System.Drawing.Point(302, 108)
        Me.DateEdit22.Name = "DateEdit22"
        Me.DateEdit22.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit22.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit22.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit22.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit22.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit22.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit22.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit22.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit22.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit22.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit22.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit22.Properties.ReadOnly = True
        Me.DateEdit22.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit22.Properties.UseReadOnlyAppearance = False
        Me.DateEdit22.Size = New System.Drawing.Size(70, 20)
        Me.DateEdit22.StyleController = Me.LayoutControl38
        Me.DateEdit22.TabIndex = 5
        '
        'ImageComboBoxEdit15
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit15, "")
        Me.ImageComboBoxEdit15.Location = New System.Drawing.Point(457, 108)
        Me.ImageComboBoxEdit15.Name = "ImageComboBoxEdit15"
        Me.ImageComboBoxEdit15.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit15.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit15.Properties.ReadOnly = True
        Me.ImageComboBoxEdit15.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit15.Size = New System.Drawing.Size(590, 20)
        Me.ImageComboBoxEdit15.StyleController = Me.LayoutControl38
        Me.ImageComboBoxEdit15.TabIndex = 6
        '
        'TextEdit59
        '
        Me.SetBoundPropertyName(Me.TextEdit59, "")
        Me.TextEdit59.Location = New System.Drawing.Point(144, 132)
        Me.TextEdit59.Name = "TextEdit59"
        Me.TextEdit59.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit59.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit59.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit59.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit59.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit59.Properties.ReadOnly = True
        Me.TextEdit59.Properties.UseReadOnlyAppearance = False
        Me.TextEdit59.Size = New System.Drawing.Size(60, 20)
        Me.TextEdit59.StyleController = Me.LayoutControl38
        Me.TextEdit59.TabIndex = 4
        '
        'TextEdit60
        '
        Me.SetBoundPropertyName(Me.TextEdit60, "")
        Me.TextEdit60.Location = New System.Drawing.Point(340, 132)
        Me.TextEdit60.Name = "TextEdit60"
        Me.TextEdit60.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit60.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit60.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit60.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit60.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit60.Properties.ReadOnly = True
        Me.TextEdit60.Properties.UseReadOnlyAppearance = False
        Me.TextEdit60.Size = New System.Drawing.Size(707, 20)
        Me.TextEdit60.StyleController = Me.LayoutControl38
        Me.TextEdit60.TabIndex = 4
        '
        'LayoutControlGroup39
        '
        Me.LayoutControlGroup39.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup39.GroupBordersVisible = False
        Me.LayoutControlGroup39.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem135, Me.EmptySpaceItem34, Me.LayoutControlItem146, Me.LayoutControlItem147, Me.LayoutControlItem148, Me.LayoutControlItem149, Me.LayoutControlItem151, Me.LayoutControlItem152, Me.LayoutControlItem153, Me.LayoutControlItem154, Me.LayoutControlItem155, Me.LayoutControlItem156})
        Me.LayoutControlGroup39.Name = "Root"
        Me.LayoutControlGroup39.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup39.TextVisible = False
        '
        'LayoutControlItem135
        '
        Me.LayoutControlItem135.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem135.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem135.Control = Me.TextEdit55
        Me.LayoutControlItem135.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem135.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem135.Name = "LayoutControlItem3"
        Me.LayoutControlItem135.Size = New System.Drawing.Size(534, 24)
        Me.LayoutControlItem135.Text = "Message Template ID:"
        Me.LayoutControlItem135.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem34
        '
        Me.EmptySpaceItem34.AllowHotTrack = False
        Me.EmptySpaceItem34.Location = New System.Drawing.Point(0, 144)
        Me.EmptySpaceItem34.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem34.Size = New System.Drawing.Size(1039, 67)
        Me.EmptySpaceItem34.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem146
        '
        Me.LayoutControlItem146.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem146.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem146.Control = Me.DateEdit20
        Me.LayoutControlItem146.Location = New System.Drawing.Point(534, 0)
        Me.LayoutControlItem146.Name = "LayoutControlItem4"
        Me.LayoutControlItem146.Size = New System.Drawing.Size(505, 24)
        Me.LayoutControlItem146.Text = "Melde Monat"
        Me.LayoutControlItem146.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem146.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem146.TextToControlDistance = 5
        '
        'LayoutControlItem147
        '
        Me.LayoutControlItem147.Control = Me.TextEdit56
        Me.LayoutControlItem147.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem147.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem147.Name = "LayoutControlItem17"
        Me.LayoutControlItem147.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem147.Text = "Message File Name:"
        Me.LayoutControlItem147.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem148
        '
        Me.LayoutControlItem148.Control = Me.TextEdit57
        Me.LayoutControlItem148.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem148.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem148.Name = "LayoutControlItem25"
        Me.LayoutControlItem148.Size = New System.Drawing.Size(534, 24)
        Me.LayoutControlItem148.Text = "Client Name:"
        Me.LayoutControlItem148.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem149
        '
        Me.LayoutControlItem149.Control = Me.ImageComboBoxEdit14
        Me.LayoutControlItem149.Location = New System.Drawing.Point(534, 48)
        Me.LayoutControlItem149.Name = "LayoutControlItem19"
        Me.LayoutControlItem149.Size = New System.Drawing.Size(505, 24)
        Me.LayoutControlItem149.Text = "Client Status"
        Me.LayoutControlItem149.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem149.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem149.TextToControlDistance = 5
        '
        'LayoutControlItem151
        '
        Me.LayoutControlItem151.Control = Me.TextEdit58
        Me.LayoutControlItem151.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem151.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem151.Name = "LayoutControlItem47"
        Me.LayoutControlItem151.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem151.Text = "Contract Nr:"
        Me.LayoutControlItem151.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem151.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem151.TextToControlDistance = 3
        '
        'LayoutControlItem152
        '
        Me.LayoutControlItem152.Control = Me.DateEdit21
        Me.LayoutControlItem152.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem152.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem152.Name = "LayoutControlItem59"
        Me.LayoutControlItem152.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem152.Text = "Contract Start Date"
        Me.LayoutControlItem152.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem153
        '
        Me.LayoutControlItem153.Control = Me.DateEdit22
        Me.LayoutControlItem153.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem153.Location = New System.Drawing.Point(196, 96)
        Me.LayoutControlItem153.Name = "LayoutControlItem71"
        Me.LayoutControlItem153.Size = New System.Drawing.Size(168, 24)
        Me.LayoutControlItem153.Text = "Contract End Date"
        Me.LayoutControlItem153.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem153.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem153.TextToControlDistance = 5
        '
        'LayoutControlItem154
        '
        Me.LayoutControlItem154.Control = Me.ImageComboBoxEdit15
        Me.LayoutControlItem154.CustomizationFormText = "Contract Status"
        Me.LayoutControlItem154.Location = New System.Drawing.Point(364, 96)
        Me.LayoutControlItem154.Name = "LayoutControlItem85"
        Me.LayoutControlItem154.Size = New System.Drawing.Size(675, 24)
        Me.LayoutControlItem154.Text = "Contract Status"
        Me.LayoutControlItem154.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem154.TextSize = New System.Drawing.Size(76, 13)
        Me.LayoutControlItem154.TextToControlDistance = 5
        '
        'LayoutControlItem155
        '
        Me.LayoutControlItem155.Control = Me.TextEdit59
        Me.LayoutControlItem155.CustomizationFormText = "ContractProductType:"
        Me.LayoutControlItem155.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem155.Name = "LayoutControlItem100"
        Me.LayoutControlItem155.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem155.Text = "Contract Product Type:"
        Me.LayoutControlItem155.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem156
        '
        Me.LayoutControlItem156.Control = Me.TextEdit60
        Me.LayoutControlItem156.CustomizationFormText = "ContractProductName:"
        Me.LayoutControlItem156.Location = New System.Drawing.Point(196, 120)
        Me.LayoutControlItem156.Name = "LayoutControlItem115"
        Me.LayoutControlItem156.Size = New System.Drawing.Size(843, 24)
        Me.LayoutControlItem156.Text = "Contract Product Name:"
        Me.LayoutControlItem156.TextSize = New System.Drawing.Size(120, 13)
        '
        'TextEdit61
        '
        Me.SetBoundPropertyName(Me.TextEdit61, "")
        Me.TextEdit61.Location = New System.Drawing.Point(88, 247)
        Me.TextEdit61.Name = "TextEdit61"
        Me.TextEdit61.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit61.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit61.Properties.Appearance.Options.UseFont = True
        Me.TextEdit61.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit61.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit61.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit61.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit61.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit61.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit61.Properties.ReadOnly = True
        Me.TextEdit61.Properties.UseReadOnlyAppearance = False
        Me.TextEdit61.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit61.StyleController = Me.LayoutControl37
        Me.TextEdit61.TabIndex = 4
        '
        'LayoutControlGroup40
        '
        Me.LayoutControlGroup40.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup40.GroupBordersVisible = False
        Me.LayoutControlGroup40.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem157, Me.LayoutControlItem158, Me.LayoutControlItem159, Me.EmptySpaceItem35, Me.EmptySpaceItem36})
        Me.LayoutControlGroup40.Name = "Root"
        Me.LayoutControlGroup40.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup40.TextVisible = False
        '
        'LayoutControlItem157
        '
        Me.LayoutControlItem157.Control = Me.LayoutControl38
        Me.LayoutControlItem157.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem157.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem157.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem157.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem157.TextVisible = False
        '
        'LayoutControlItem158
        '
        Me.LayoutControlItem158.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem158.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem158.Control = Me.MemoEdit14
        Me.LayoutControlItem158.Location = New System.Drawing.Point(0, 261)
        Me.LayoutControlItem158.Name = "LayoutControlItem2"
        Me.LayoutControlItem158.Size = New System.Drawing.Size(1063, 243)
        Me.LayoutControlItem158.Text = "Validation Code Description"
        Me.LayoutControlItem158.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem158.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem159
        '
        Me.LayoutControlItem159.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem159.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem159.Control = Me.TextEdit61
        Me.LayoutControlItem159.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem159.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem159.Name = "LayoutControlItem9"
        Me.LayoutControlItem159.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem159.Text = "Validation ID:"
        Me.LayoutControlItem159.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem159.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem159.TextToControlDistance = 3
        '
        'EmptySpaceItem35
        '
        Me.EmptySpaceItem35.AllowHotTrack = False
        Me.EmptySpaceItem35.Location = New System.Drawing.Point(218, 235)
        Me.EmptySpaceItem35.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem35.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem35.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem36
        '
        Me.EmptySpaceItem36.AllowHotTrack = False
        Me.EmptySpaceItem36.Location = New System.Drawing.Point(0, 504)
        Me.EmptySpaceItem36.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem36.Size = New System.Drawing.Size(1063, 11)
        Me.EmptySpaceItem36.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl39
        '
        Me.SetBoundPropertyName(Me.LayoutControl39, "")
        Me.LayoutControl39.Controls.Add(Me.MemoEdit15)
        Me.LayoutControl39.Controls.Add(Me.LayoutControl40)
        Me.LayoutControl39.Controls.Add(Me.TextEdit69)
        Me.LayoutControl39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl39.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl39.Name = "LayoutControl39"
        Me.LayoutControl39.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1130, 177, 650, 400)
        Me.LayoutControl39.Root = Me.LayoutControlGroup42
        Me.LayoutControl39.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControl39.TabIndex = 2
        '
        'MemoEdit15
        '
        Me.SetBoundPropertyName(Me.MemoEdit15, "")
        Me.MemoEdit15.Location = New System.Drawing.Point(12, 291)
        Me.MemoEdit15.Name = "MemoEdit15"
        Me.MemoEdit15.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit15.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit15.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit15.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit15.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit15.Properties.ReadOnly = True
        Me.MemoEdit15.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MemoEdit15.Properties.UseReadOnlyAppearance = False
        Me.MemoEdit15.Size = New System.Drawing.Size(1059, 221)
        Me.MemoEdit15.StyleController = Me.LayoutControl39
        Me.MemoEdit15.TabIndex = 0
        '
        'LayoutControl40
        '
        Me.SetBoundPropertyName(Me.LayoutControl40, "")
        Me.LayoutControl40.Controls.Add(Me.ImageComboBoxEdit16)
        Me.LayoutControl40.Controls.Add(Me.DateEdit23)
        Me.LayoutControl40.Controls.Add(Me.TextEdit63)
        Me.LayoutControl40.Controls.Add(Me.TextEdit64)
        Me.LayoutControl40.Controls.Add(Me.TextEdit65)
        Me.LayoutControl40.Controls.Add(Me.TextEdit66)
        Me.LayoutControl40.Controls.Add(Me.DateEdit24)
        Me.LayoutControl40.Controls.Add(Me.DateEdit25)
        Me.LayoutControl40.Controls.Add(Me.ImageComboBoxEdit17)
        Me.LayoutControl40.Controls.Add(Me.TextEdit67)
        Me.LayoutControl40.Controls.Add(Me.TextEdit68)
        Me.LayoutControl40.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl40.Name = "LayoutControl40"
        Me.LayoutControl40.Root = Me.LayoutControlGroup41
        Me.LayoutControl40.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControl40.TabIndex = 1
        '
        'ImageComboBoxEdit16
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit16, "")
        Me.ImageComboBoxEdit16.Location = New System.Drawing.Point(612, 60)
        Me.ImageComboBoxEdit16.Name = "ImageComboBoxEdit16"
        Me.ImageComboBoxEdit16.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit16.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit16.Properties.ReadOnly = True
        Me.ImageComboBoxEdit16.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit16.Size = New System.Drawing.Size(435, 20)
        Me.ImageComboBoxEdit16.StyleController = Me.LayoutControl40
        Me.ImageComboBoxEdit16.TabIndex = 6
        '
        'DateEdit23
        '
        Me.SetBoundPropertyName(Me.DateEdit23, "")
        Me.DateEdit23.EditValue = Nothing
        Me.DateEdit23.Location = New System.Drawing.Point(625, 12)
        Me.DateEdit23.Name = "DateEdit23"
        Me.DateEdit23.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit23.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit23.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit23.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit23.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit23.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit23.Properties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit23.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit23.Properties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit23.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit23.Properties.Mask.EditMask = "MM.yyyy"
        Me.DateEdit23.Properties.ReadOnly = True
        Me.DateEdit23.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit23.Properties.UseReadOnlyAppearance = False
        Me.DateEdit23.Size = New System.Drawing.Size(422, 20)
        Me.DateEdit23.StyleController = Me.LayoutControl40
        Me.DateEdit23.TabIndex = 5
        '
        'TextEdit63
        '
        Me.SetBoundPropertyName(Me.TextEdit63, "")
        Me.TextEdit63.Location = New System.Drawing.Point(144, 12)
        Me.TextEdit63.Name = "TextEdit63"
        Me.TextEdit63.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit63.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit63.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit63.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit63.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit63.Properties.ReadOnly = True
        Me.TextEdit63.Properties.UseReadOnlyAppearance = False
        Me.TextEdit63.Size = New System.Drawing.Size(398, 20)
        Me.TextEdit63.StyleController = Me.LayoutControl40
        Me.TextEdit63.TabIndex = 4
        '
        'TextEdit64
        '
        Me.SetBoundPropertyName(Me.TextEdit64, "")
        Me.TextEdit64.Location = New System.Drawing.Point(144, 36)
        Me.TextEdit64.Name = "TextEdit64"
        Me.TextEdit64.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit64.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit64.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit64.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit64.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit64.Properties.ReadOnly = True
        Me.TextEdit64.Properties.UseReadOnlyAppearance = False
        Me.TextEdit64.Size = New System.Drawing.Size(903, 20)
        Me.TextEdit64.StyleController = Me.LayoutControl40
        Me.TextEdit64.TabIndex = 4
        '
        'TextEdit65
        '
        Me.SetBoundPropertyName(Me.TextEdit65, "")
        Me.TextEdit65.Location = New System.Drawing.Point(144, 60)
        Me.TextEdit65.Name = "TextEdit65"
        Me.TextEdit65.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit65.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit65.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit65.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit65.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit65.Properties.ReadOnly = True
        Me.TextEdit65.Properties.UseReadOnlyAppearance = False
        Me.TextEdit65.Size = New System.Drawing.Size(398, 20)
        Me.TextEdit65.StyleController = Me.LayoutControl40
        Me.TextEdit65.TabIndex = 4
        '
        'TextEdit66
        '
        Me.SetBoundPropertyName(Me.TextEdit66, "")
        Me.TextEdit66.Location = New System.Drawing.Point(75, 84)
        Me.TextEdit66.Name = "TextEdit66"
        Me.TextEdit66.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit66.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit66.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit66.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit66.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit66.Properties.ReadOnly = True
        Me.TextEdit66.Properties.UseReadOnlyAppearance = False
        Me.TextEdit66.Size = New System.Drawing.Size(972, 20)
        Me.TextEdit66.StyleController = Me.LayoutControl40
        Me.TextEdit66.TabIndex = 4
        '
        'DateEdit24
        '
        Me.SetBoundPropertyName(Me.DateEdit24, "")
        Me.DateEdit24.EditValue = Nothing
        Me.DateEdit24.Location = New System.Drawing.Point(144, 108)
        Me.DateEdit24.Name = "DateEdit24"
        Me.DateEdit24.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit24.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit24.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit24.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit24.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit24.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit24.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit24.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit24.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit24.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateEdit24.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit24.Properties.ReadOnly = True
        Me.DateEdit24.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit24.Properties.UseReadOnlyAppearance = False
        Me.DateEdit24.Size = New System.Drawing.Size(60, 20)
        Me.DateEdit24.StyleController = Me.LayoutControl40
        Me.DateEdit24.TabIndex = 5
        '
        'DateEdit25
        '
        Me.SetBoundPropertyName(Me.DateEdit25, "")
        Me.DateEdit25.EditValue = Nothing
        Me.DateEdit25.Location = New System.Drawing.Point(302, 108)
        Me.DateEdit25.Name = "DateEdit25"
        Me.DateEdit25.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit25.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit25.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM.yyyy"
        Me.DateEdit25.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit25.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM.yyyy"
        Me.DateEdit25.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit25.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit25.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit25.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DateEdit25.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit25.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DateEdit25.Properties.ReadOnly = True
        Me.DateEdit25.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit25.Properties.UseReadOnlyAppearance = False
        Me.DateEdit25.Size = New System.Drawing.Size(70, 20)
        Me.DateEdit25.StyleController = Me.LayoutControl40
        Me.DateEdit25.TabIndex = 5
        '
        'ImageComboBoxEdit17
        '
        Me.SetBoundPropertyName(Me.ImageComboBoxEdit17, "")
        Me.ImageComboBoxEdit17.Location = New System.Drawing.Point(457, 108)
        Me.ImageComboBoxEdit17.Name = "ImageComboBoxEdit17"
        Me.ImageComboBoxEdit17.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit17.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.ImageComboBoxEdit17.Properties.ReadOnly = True
        Me.ImageComboBoxEdit17.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit17.Size = New System.Drawing.Size(590, 20)
        Me.ImageComboBoxEdit17.StyleController = Me.LayoutControl40
        Me.ImageComboBoxEdit17.TabIndex = 6
        '
        'TextEdit67
        '
        Me.SetBoundPropertyName(Me.TextEdit67, "")
        Me.TextEdit67.Location = New System.Drawing.Point(144, 132)
        Me.TextEdit67.Name = "TextEdit67"
        Me.TextEdit67.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit67.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit67.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit67.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit67.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit67.Properties.ReadOnly = True
        Me.TextEdit67.Properties.UseReadOnlyAppearance = False
        Me.TextEdit67.Size = New System.Drawing.Size(60, 20)
        Me.TextEdit67.StyleController = Me.LayoutControl40
        Me.TextEdit67.TabIndex = 4
        '
        'TextEdit68
        '
        Me.SetBoundPropertyName(Me.TextEdit68, "")
        Me.TextEdit68.Location = New System.Drawing.Point(340, 132)
        Me.TextEdit68.Name = "TextEdit68"
        Me.TextEdit68.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit68.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit68.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit68.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit68.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit68.Properties.ReadOnly = True
        Me.TextEdit68.Properties.UseReadOnlyAppearance = False
        Me.TextEdit68.Size = New System.Drawing.Size(707, 20)
        Me.TextEdit68.StyleController = Me.LayoutControl40
        Me.TextEdit68.TabIndex = 4
        '
        'LayoutControlGroup41
        '
        Me.LayoutControlGroup41.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup41.GroupBordersVisible = False
        Me.LayoutControlGroup41.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem150, Me.EmptySpaceItem37, Me.LayoutControlItem161, Me.LayoutControlItem162, Me.LayoutControlItem163, Me.LayoutControlItem164, Me.LayoutControlItem166, Me.LayoutControlItem167, Me.LayoutControlItem168, Me.LayoutControlItem169, Me.LayoutControlItem170, Me.LayoutControlItem171})
        Me.LayoutControlGroup41.Name = "Root"
        Me.LayoutControlGroup41.Size = New System.Drawing.Size(1059, 231)
        Me.LayoutControlGroup41.TextVisible = False
        '
        'LayoutControlItem150
        '
        Me.LayoutControlItem150.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem150.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem150.Control = Me.TextEdit63
        Me.LayoutControlItem150.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem150.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem150.Name = "LayoutControlItem3"
        Me.LayoutControlItem150.Size = New System.Drawing.Size(534, 24)
        Me.LayoutControlItem150.Text = "Message Template ID:"
        Me.LayoutControlItem150.TextSize = New System.Drawing.Size(120, 15)
        '
        'EmptySpaceItem37
        '
        Me.EmptySpaceItem37.AllowHotTrack = False
        Me.EmptySpaceItem37.Location = New System.Drawing.Point(0, 144)
        Me.EmptySpaceItem37.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem37.Size = New System.Drawing.Size(1039, 67)
        Me.EmptySpaceItem37.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem161
        '
        Me.LayoutControlItem161.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem161.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem161.Control = Me.DateEdit23
        Me.LayoutControlItem161.Location = New System.Drawing.Point(534, 0)
        Me.LayoutControlItem161.Name = "LayoutControlItem4"
        Me.LayoutControlItem161.Size = New System.Drawing.Size(505, 24)
        Me.LayoutControlItem161.Text = "Melde Monat"
        Me.LayoutControlItem161.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem161.TextSize = New System.Drawing.Size(74, 15)
        Me.LayoutControlItem161.TextToControlDistance = 5
        '
        'LayoutControlItem162
        '
        Me.LayoutControlItem162.Control = Me.TextEdit64
        Me.LayoutControlItem162.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem162.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem162.Name = "LayoutControlItem17"
        Me.LayoutControlItem162.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem162.Text = "Message File Name:"
        Me.LayoutControlItem162.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem163
        '
        Me.LayoutControlItem163.Control = Me.TextEdit65
        Me.LayoutControlItem163.CustomizationFormText = "Message Template ID:"
        Me.LayoutControlItem163.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem163.Name = "LayoutControlItem25"
        Me.LayoutControlItem163.Size = New System.Drawing.Size(534, 24)
        Me.LayoutControlItem163.Text = "Client Name:"
        Me.LayoutControlItem163.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem164
        '
        Me.LayoutControlItem164.Control = Me.ImageComboBoxEdit16
        Me.LayoutControlItem164.Location = New System.Drawing.Point(534, 48)
        Me.LayoutControlItem164.Name = "LayoutControlItem19"
        Me.LayoutControlItem164.Size = New System.Drawing.Size(505, 24)
        Me.LayoutControlItem164.Text = "Client Status"
        Me.LayoutControlItem164.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem164.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem164.TextToControlDistance = 5
        '
        'LayoutControlItem166
        '
        Me.LayoutControlItem166.Control = Me.TextEdit66
        Me.LayoutControlItem166.CustomizationFormText = "Contract Nr:"
        Me.LayoutControlItem166.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem166.Name = "LayoutControlItem47"
        Me.LayoutControlItem166.Size = New System.Drawing.Size(1039, 24)
        Me.LayoutControlItem166.Text = "Contract Nr:"
        Me.LayoutControlItem166.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem166.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem166.TextToControlDistance = 3
        '
        'LayoutControlItem167
        '
        Me.LayoutControlItem167.Control = Me.DateEdit24
        Me.LayoutControlItem167.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem167.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem167.Name = "LayoutControlItem59"
        Me.LayoutControlItem167.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem167.Text = "Contract Start Date"
        Me.LayoutControlItem167.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem168
        '
        Me.LayoutControlItem168.Control = Me.DateEdit25
        Me.LayoutControlItem168.CustomizationFormText = "Melde Monat"
        Me.LayoutControlItem168.Location = New System.Drawing.Point(196, 96)
        Me.LayoutControlItem168.Name = "LayoutControlItem71"
        Me.LayoutControlItem168.Size = New System.Drawing.Size(168, 24)
        Me.LayoutControlItem168.Text = "Contract End Date"
        Me.LayoutControlItem168.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem168.TextSize = New System.Drawing.Size(89, 13)
        Me.LayoutControlItem168.TextToControlDistance = 5
        '
        'LayoutControlItem169
        '
        Me.LayoutControlItem169.Control = Me.ImageComboBoxEdit17
        Me.LayoutControlItem169.CustomizationFormText = "Contract Status"
        Me.LayoutControlItem169.Location = New System.Drawing.Point(364, 96)
        Me.LayoutControlItem169.Name = "LayoutControlItem85"
        Me.LayoutControlItem169.Size = New System.Drawing.Size(675, 24)
        Me.LayoutControlItem169.Text = "Contract Status"
        Me.LayoutControlItem169.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem169.TextSize = New System.Drawing.Size(76, 13)
        Me.LayoutControlItem169.TextToControlDistance = 5
        '
        'LayoutControlItem170
        '
        Me.LayoutControlItem170.Control = Me.TextEdit67
        Me.LayoutControlItem170.CustomizationFormText = "ContractProductType:"
        Me.LayoutControlItem170.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem170.Name = "LayoutControlItem100"
        Me.LayoutControlItem170.Size = New System.Drawing.Size(196, 24)
        Me.LayoutControlItem170.Text = "Contract Product Type:"
        Me.LayoutControlItem170.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutControlItem171
        '
        Me.LayoutControlItem171.Control = Me.TextEdit68
        Me.LayoutControlItem171.CustomizationFormText = "ContractProductName:"
        Me.LayoutControlItem171.Location = New System.Drawing.Point(196, 120)
        Me.LayoutControlItem171.Name = "LayoutControlItem115"
        Me.LayoutControlItem171.Size = New System.Drawing.Size(843, 24)
        Me.LayoutControlItem171.Text = "Contract Product Name:"
        Me.LayoutControlItem171.TextSize = New System.Drawing.Size(120, 13)
        '
        'TextEdit69
        '
        Me.SetBoundPropertyName(Me.TextEdit69, "")
        Me.TextEdit69.Location = New System.Drawing.Point(88, 247)
        Me.TextEdit69.Name = "TextEdit69"
        Me.TextEdit69.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit69.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TextEdit69.Properties.Appearance.Options.UseFont = True
        Me.TextEdit69.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit69.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit69.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit69.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit69.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit69.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit69.Properties.ReadOnly = True
        Me.TextEdit69.Properties.UseReadOnlyAppearance = False
        Me.TextEdit69.Size = New System.Drawing.Size(138, 22)
        Me.TextEdit69.StyleController = Me.LayoutControl39
        Me.TextEdit69.TabIndex = 4
        '
        'LayoutControlGroup42
        '
        Me.LayoutControlGroup42.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup42.GroupBordersVisible = False
        Me.LayoutControlGroup42.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem172, Me.LayoutControlItem173, Me.LayoutControlItem174, Me.EmptySpaceItem38, Me.EmptySpaceItem39})
        Me.LayoutControlGroup42.Name = "Root"
        Me.LayoutControlGroup42.Size = New System.Drawing.Size(1083, 535)
        Me.LayoutControlGroup42.TextVisible = False
        '
        'LayoutControlItem172
        '
        Me.LayoutControlItem172.Control = Me.LayoutControl40
        Me.LayoutControlItem172.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem172.Name = "EditFormUserControlLayoutControl1ConvertedLayoutitem"
        Me.LayoutControlItem172.Size = New System.Drawing.Size(1063, 235)
        Me.LayoutControlItem172.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem172.TextVisible = False
        '
        'LayoutControlItem173
        '
        Me.LayoutControlItem173.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem173.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem173.Control = Me.MemoEdit15
        Me.LayoutControlItem173.Location = New System.Drawing.Point(0, 261)
        Me.LayoutControlItem173.Name = "LayoutControlItem2"
        Me.LayoutControlItem173.Size = New System.Drawing.Size(1063, 243)
        Me.LayoutControlItem173.Text = "Validation Code Description"
        Me.LayoutControlItem173.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem173.TextSize = New System.Drawing.Size(151, 15)
        '
        'LayoutControlItem174
        '
        Me.LayoutControlItem174.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem174.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem174.Control = Me.TextEdit69
        Me.LayoutControlItem174.CustomizationFormText = "Validation ID:"
        Me.LayoutControlItem174.Location = New System.Drawing.Point(0, 235)
        Me.LayoutControlItem174.Name = "LayoutControlItem9"
        Me.LayoutControlItem174.Size = New System.Drawing.Size(218, 26)
        Me.LayoutControlItem174.Text = "Validation ID:"
        Me.LayoutControlItem174.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem174.TextSize = New System.Drawing.Size(73, 15)
        Me.LayoutControlItem174.TextToControlDistance = 3
        '
        'EmptySpaceItem38
        '
        Me.EmptySpaceItem38.AllowHotTrack = False
        Me.EmptySpaceItem38.Location = New System.Drawing.Point(218, 235)
        Me.EmptySpaceItem38.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem38.Size = New System.Drawing.Size(845, 26)
        Me.EmptySpaceItem38.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem39
        '
        Me.EmptySpaceItem39.AllowHotTrack = False
        Me.EmptySpaceItem39.Location = New System.Drawing.Point(0, 504)
        Me.EmptySpaceItem39.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem39.Size = New System.Drawing.Size(1063, 11)
        Me.EmptySpaceItem39.TextSize = New System.Drawing.Size(0, 0)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UpdateSqlScriptFromXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.LookAndFeel.SkinName = "Office 2019 Colorful"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "UpdateSqlScriptFromXML"
        Me.Size = New System.Drawing.Size(1168, 605)
        CType(Me.XmlSqlUnderlying_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XmlSql_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileValidity_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRadioGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditFormUserControlLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EditFormUserControlLayoutControl1ConvertedLayout.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.FileName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditFormUserControlLayoutControl1ConvertedLayoutitem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.MemoEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl5.ResumeLayout(False)
        CType(Me.MemoEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl6.ResumeLayout(False)
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl8.ResumeLayout(False)
        CType(Me.MemoEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl9.ResumeLayout(False)
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl11.ResumeLayout(False)
        CType(Me.MemoEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl12.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl14.ResumeLayout(False)
        CType(Me.MemoEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl15.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit11.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl17.ResumeLayout(False)
        CType(Me.MemoEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl18.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit14.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit16.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl20.ResumeLayout(False)
        CType(Me.MemoEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl21.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit17.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit18.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit19.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit20.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit21.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit22.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl23, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl23.ResumeLayout(False)
        CType(Me.MemoEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl24.ResumeLayout(False)
        CType(Me.DateEdit5.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit23.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit24.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit25.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit26.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit27.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit6.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit7.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem78, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem79, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem80, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit28.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem81, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl26.ResumeLayout(False)
        CType(Me.MemoEdit10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl27, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl27.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit8.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit30.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit31.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit32.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit33.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit9.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit10.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem86, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem87, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem88, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem89, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem91, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem92, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem93, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem94, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem95, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit34.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem96, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem97, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem98, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem99, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl29, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl29.ResumeLayout(False)
        CType(Me.MemoEdit11.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl30, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl30.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit11.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit11.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit36.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit37.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit38.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit39.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit12.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit13.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem90, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem101, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem102, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem103, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem104, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem107, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem108, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem109, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem110, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit40.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem113, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem114, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl32, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl32.ResumeLayout(False)
        CType(Me.MemoEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl33, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl33.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit14.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit14.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit35.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit41.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit42.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit43.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit15.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit16.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit16.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit11.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit44.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit45.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem105, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem116, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem117, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem118, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem119, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem121, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem122, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem123, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem124, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem125, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem126, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem127, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit46.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem128, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem129, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem131, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl35, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl35.ResumeLayout(False)
        CType(Me.MemoEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl36, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl36.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit17.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit17.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit47.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit48.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit49.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit50.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit18.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit18.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit19.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit19.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit51.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit52.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem120, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem132, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem133, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem134, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem136, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem137, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem138, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem139, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem140, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem141, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit53.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem142, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem143, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem144, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl37, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl37.ResumeLayout(False)
        CType(Me.MemoEdit14.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl38, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl38.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit14.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit20.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit20.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit55.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit56.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit57.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit58.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit21.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit21.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit22.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit22.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit59.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit60.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem135, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem146, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem147, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem148, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem149, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem151, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem152, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem153, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem154, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem155, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem156, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit61.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem157, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem158, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem159, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl39, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl39.ResumeLayout(False)
        CType(Me.MemoEdit15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl40, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl40.ResumeLayout(False)
        CType(Me.ImageComboBoxEdit16.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit23.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit23.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit63.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit64.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit65.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit66.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit24.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit24.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit25.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit25.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageComboBoxEdit17.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit67.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit68.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem150, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem161, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem162, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem163, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem164, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem166, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem167, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem168, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem169, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem170, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem171, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit69.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem172, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem173, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem174, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpreadsheetBarController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EditFormUserControlLayoutControl1ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EditFormUserControlLayoutControl1ConvertedLayoutitem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit2 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl5 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit3 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl6 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup8 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl7 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup9 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup10 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl8 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit4 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl9 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup11 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl10 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup12 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup13 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
    Friend WithEvents LayoutControl11 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit5 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl12 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit1 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit3 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit5 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit6 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup14 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl13 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup15 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem31 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit7 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup16 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem35 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl14 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit6 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl15 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit2 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit4 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit8 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit9 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit10 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup17 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem38 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem40 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl16 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup18 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem42 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit11 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup19 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem43 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem44 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem45 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem46 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl17 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit7 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl18 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit3 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit12 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit13 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit14 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit15 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup20 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem41 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem13 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem49 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem50 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem51 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem52 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem53 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl19 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup21 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem54 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit16 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup22 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem55 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem56 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem57 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem58 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem14 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem15 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl20 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit8 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl21 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit4 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents TextEdit17 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit18 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit19 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit20 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit21 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup23 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem48 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem16 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem61 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem62 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem63 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem64 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem65 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl22 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup24 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem66 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit22 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup25 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem67 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem68 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem69 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem70 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem17 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem18 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl23 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit9 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl24 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DateEdit5 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit23 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit24 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit25 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit26 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit27 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit6 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit7 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup26 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem60 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem19 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem72 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem73 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem74 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem76 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem77 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem78 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem79 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl25 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup27 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem80 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit28 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup28 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem81 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem82 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem83 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem84 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem20 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem21 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl26 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit10 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl27 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit6 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit8 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit30 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit31 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit32 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit33 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit9 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit10 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit7 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents LayoutControlGroup29 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem75 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem22 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem86 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem87 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem88 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem89 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem91 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem92 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem93 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem94 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl28 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup30 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem95 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit34 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup31 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem96 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem97 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem98 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem99 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem23 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem24 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl29 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit11 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl30 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit8 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit11 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit36 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit37 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit38 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit39 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit12 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit13 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit9 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents LayoutControlGroup32 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem90 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem25 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem101 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem102 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem103 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem104 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem106 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem107 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem108 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem109 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl31 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup33 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem110 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit40 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup34 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem111 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem112 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem113 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem114 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem26 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem27 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl32 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit12 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl33 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit10 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit14 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit35 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit41 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit42 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit43 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit15 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit16 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit11 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents TextEdit44 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit45 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup35 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem105 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem28 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem116 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem117 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem118 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem119 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem121 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem122 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem123 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem124 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem125 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem126 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl34 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup36 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem127 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit46 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup37 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem128 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem129 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem130 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem131 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem29 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem30 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl35 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit13 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl36 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit12 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit17 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit47 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit48 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit49 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit50 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit18 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit19 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit13 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents TextEdit51 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit52 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem31 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem120 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem132 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem133 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem134 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem136 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem137 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem138 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem139 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem140 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem141 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit53 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup38 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem142 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem143 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem144 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem32 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem33 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl37 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit14 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl38 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit14 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit20 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit55 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit56 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit57 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit58 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit21 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit22 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit15 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents TextEdit59 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit60 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup39 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem135 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem34 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem146 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem147 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem148 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem149 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem151 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem152 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem153 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem154 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem155 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem156 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit61 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup40 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem157 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem158 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem159 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem35 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem36 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl39 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit15 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl40 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageComboBoxEdit16 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents DateEdit23 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit63 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit64 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit65 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit66 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit24 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit25 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit17 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents TextEdit67 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit68 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup41 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem150 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem37 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem161 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem162 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem163 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem164 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem166 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem167 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem168 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem169 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem170 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem171 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit69 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup42 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem172 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem173 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem174 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem38 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem39 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SpreadsheetBarController1 As DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents CommonBar1 As DevExpress.XtraSpreadsheet.UI.CommonBar
    Friend WithEvents OpenFile_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FileValidity_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents FileValidity_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents SplitterControl2 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents FileName_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem47 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents XmlSql_GridView As GridView
    Friend WithEvents LayoutControlItem59 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XmlSqlUnderlying_GridView As GridView
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemRadioGroup1 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
End Class
