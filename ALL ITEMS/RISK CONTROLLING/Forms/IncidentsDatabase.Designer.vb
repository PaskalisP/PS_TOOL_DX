<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncidentsDatabase
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim CaseIDLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncidentsDatabase))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule4 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule5 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition5 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition6 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim OptionsSpelling1 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim OptionsSpelling2 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim SpellCheckerISpellDictionary1 As DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary = New DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary()
        Dim SpellCheckerCustomDictionary1 As DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary = New DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary()
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Me.colOpRiskMateriality = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OpRiskLevel1_lbl = New System.Windows.Forms.Label()
        Me.SCHADENSFALLBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IncidentsDataset = New PS_TOOL_DX.IncidentsDataset()
        Me.OpRiskNr_lbl = New System.Windows.Forms.Label()
        Me.OpRiskLevel2_lbl = New System.Windows.Forms.Label()
        Me.OpRiskMateriality_lbl = New System.Windows.Forms.Label()
        Me.SCHADENSFALLTableAdapter = New PS_TOOL_DX.IncidentsDatasetTableAdapters.SCHADENSFALLTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.IncidentsDatasetTableAdapters.TableAdapterManager()
        Me.SCHADENFALL_DOCSTableAdapter = New PS_TOOL_DX.IncidentsDatasetTableAdapters.SCHADENFALL_DOCSTableAdapter()
        Me.SCHADENFALL_DOCSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SCHADENSFALL_OPTIONSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SCHADENSFALL_OPTIONSTableAdapter = New PS_TOOL_DX.IncidentsDatasetTableAdapters.SCHADENSFALL_OPTIONSTableAdapter()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.Incicents_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaseID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClassification = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOpRiskLetter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOpRiskLevel1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOpRiskNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOpRiskLevel2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEventDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDeclarationDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExtentOfDamage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDamageCompensations = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDamageCompensationsAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaseDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeasures = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField26 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField27 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField28 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn4 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField29 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn5 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField30 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn6 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField31 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn7 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField32 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn8 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField33 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn9 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField34 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn10 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField35 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn11 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField36 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn12 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField37 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn13 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField38 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn14 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField39 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn15 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField40 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn16 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField41 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn17 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField42 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn18 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField43 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn19 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField44 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn20 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField45 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn21 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField46 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn22 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField47 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn23 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField48 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn24 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField66 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn25 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField67 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn104 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField68 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn105 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField69 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn106 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField70 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn107 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField71 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn108 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField72 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn109 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField73 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn110 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField74 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn111 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField75 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn112 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField76 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn113 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField77 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn114 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField78 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn115 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField79 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn116 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField80 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn117 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField81 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn118 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField82 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn119 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField83 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn120 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField84 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn121 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField85 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn122 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField86 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn123 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField87 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn124 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField88 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn125 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField89 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn126 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField90 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn127 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField91 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn128 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField92 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn129 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField93 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn130 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField94 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn131 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField95 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.LayoutView5 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutView6 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn132 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField96 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn133 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField97 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn134 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField98 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn135 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField99 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn136 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField100 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn137 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField101 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn138 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField102 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn139 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField103 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn140 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField104 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn141 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField105 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn142 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField106 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn143 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField107 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn144 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField108 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn145 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField109 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn146 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField110 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn147 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField111 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn148 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField112 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn149 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField113 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn150 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField114 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn151 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField115 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn152 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField116 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn153 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField117 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn154 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField118 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn155 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField119 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn156 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField120 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.IncidentsDocs_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFileDirectory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colImportDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colImportTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colImportUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInternalNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colIdSchadenfall = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFileNameType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection2 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.AnzahlWertRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LayoutView4 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn51 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn52 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField49 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn53 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBankleitzahl = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn54 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBIC = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn55 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn56 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField50 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn57 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField51 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn58 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField52 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn59 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField53 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn60 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladresseFirma = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn61 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladresseOrt = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn62 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladressePostfach = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn63 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladressePostleitzahl = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn64 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungFirma = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn65 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungPostfach = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn66 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungStraße = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn67 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungPostleitzahl = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn68 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungOrt = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn69 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colInstitutstyp = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn70 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBLZdervorgeschaltetenStelle = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn71 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAvisierungvonZahlungenTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn72 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAvisierungvonZahlungenFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn73 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn74 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField54 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn75 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField55 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn76 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn77 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField56 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn78 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField57 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn79 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField58 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn80 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField59 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn81 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn82 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colScheckanfrageTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn83 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colScheckanfrageFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn84 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colScheckanfrageEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn85 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField60 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn86 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField61 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn87 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField62 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn88 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField63 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn89 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField64 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn90 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colLastschriftrückrufEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn91 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colWechselrückrufeTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn92 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colWechselrückrufeFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn93 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colWechselrückrufeEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn94 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUnbezahlteWechselTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn95 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUnbezahlteWechselFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn96 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUnbezahlteWechselEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn97 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVorgeschalteteStelleTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn98 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVorgeschalteteStelleFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn99 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVorgeschalteteStelleEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn100 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMeldeweg = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn101 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField65 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn102 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUSER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn103 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUNTERBEARBEITUNGVON = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.LayoutView3 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutView2 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn26 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn27 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn28 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn29 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn30 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn31 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField6 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn32 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField7 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn33 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField8 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn34 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField9 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn35 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField10 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn36 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField11 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn37 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField12 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn38 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField13 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn39 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField14 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn40 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField15 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn41 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField16 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn42 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField17 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn43 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField18 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn44 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField19 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn45 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField20 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn46 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField21 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn47 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField22 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn48 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField23 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn49 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField24 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn50 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField25 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.Classification_ComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.EventDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.DeclarationDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.ExtendOfDamage_SpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.OpRisk_GridLookUpEdit = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.OpRiskOptions_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DamageCompensations_ComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DamageCompensationAmount_SpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.MeasuresMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.CaseDescription_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.GENERALXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.CaseID_lbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CASEDESCRIPTIONXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.ATTACHMENTSXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_Attachments_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_INTERBANKV_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.MEASURESXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.Save_Incidents_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ShowAllCases_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Statuslbl = New System.Windows.Forms.Label()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PrintExportAllIncidents_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.IncidentReport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        CaseIDLabel = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        CType(Me.SCHADENSFALLBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncidentsDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCHADENFALL_DOCSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCHADENSFALL_OPTIONSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Incicents_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField78, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField79, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField80, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField81, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField85, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField86, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField87, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField88, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField89, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField90, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField91, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField93, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField94, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField95, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField96, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField97, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField98, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField99, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField101, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField102, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField103, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField104, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField105, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField107, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField108, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField109, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField110, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField113, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField114, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField115, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField116, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField117, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField118, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField119, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField120, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncidentsDocs_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnzahlWertRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBankleitzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladresseFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladresseOrt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladressePostfach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladressePostleitzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungPostfach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungStraße, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungPostleitzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungOrt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInstitutstyp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBLZdervorgeschaltetenStelle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colÜberweisungsnachfragenEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colÜberweisungsrückfragenEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colScheckanfrageTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colScheckanfrageFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colScheckanfrageEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLastschriftrückrufEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWechselrückrufeTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWechselrückrufeFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWechselrückrufeEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUnbezahlteWechselTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUnbezahlteWechselFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUnbezahlteWechselEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMeldeweg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUSER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUNTERBEARBEITUNGVON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutViewField15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Classification_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclarationDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclarationDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExtendOfDamage_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpRisk_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpRiskOptions_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DamageCompensations_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DamageCompensationAmount_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeasuresMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaseDescription_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.GENERALXtraTabPage.SuspendLayout()
        Me.CASEDESCRIPTIONXtraTabPage.SuspendLayout()
        Me.ATTACHMENTSXtraTabPage.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MEASURESXtraTabPage.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label2.Location = New System.Drawing.Point(663, 51)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(49, 13)
        Label2.TabIndex = 8
        Label2.Text = "OpRisk:"
        '
        'Label3
        '
        Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label3.Location = New System.Drawing.Point(232, 50)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(84, 13)
        Label3.TabIndex = 3
        Label3.Text = "Classification:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(7, 18)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(22, 13)
        Label5.TabIndex = 1
        Label5.Text = "ID:"
        '
        'Label1
        '
        Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label1.Location = New System.Drawing.Point(244, 184)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(72, 13)
        Label1.TabIndex = 24
        Label1.Text = "Event Date:"
        '
        'Label6
        '
        Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label6.Location = New System.Drawing.Point(681, 185)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(105, 13)
        Label6.TabIndex = 25
        Label6.Text = "Declaration Date:"
        '
        'Label7
        '
        Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label7.Location = New System.Drawing.Point(203, 312)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(113, 13)
        Label7.TabIndex = 27
        Label7.Text = "Extend of Damage:"
        '
        'Label8
        '
        Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label8.Location = New System.Drawing.Point(640, 312)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(146, 13)
        Label8.TabIndex = 29
        Label8.Text = "Damage compensations:"
        '
        'Label9
        '
        Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label9.Location = New System.Drawing.Point(598, 342)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(188, 13)
        Label9.TabIndex = 31
        Label9.Text = "Damage compensation Amount:"
        '
        'CaseIDLabel
        '
        CaseIDLabel.AutoSize = True
        CaseIDLabel.Location = New System.Drawing.Point(1161, 409)
        CaseIDLabel.Name = "CaseIDLabel"
        CaseIDLabel.Size = New System.Drawing.Size(49, 13)
        CaseIDLabel.TabIndex = 32
        CaseIDLabel.Text = "Case ID:"
        '
        'colOpRiskMateriality
        '
        Me.colOpRiskMateriality.AppearanceCell.Options.UseTextOptions = True
        Me.colOpRiskMateriality.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOpRiskMateriality.Caption = "Materiality"
        Me.colOpRiskMateriality.FieldName = "OpRiskMateriality"
        Me.colOpRiskMateriality.Name = "colOpRiskMateriality"
        Me.colOpRiskMateriality.OptionsColumn.AllowEdit = False
        Me.colOpRiskMateriality.OptionsColumn.ReadOnly = True
        Me.colOpRiskMateriality.Visible = True
        Me.colOpRiskMateriality.VisibleIndex = 3
        Me.colOpRiskMateriality.Width = 125
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Materiality"
        Me.GridColumn6.FieldName = "OpRiskMateriality"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 105
        '
        'OpRiskLevel1_lbl
        '
        Me.OpRiskLevel1_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OpRiskLevel1_lbl.AutoSize = True
        Me.OpRiskLevel1_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "OpRiskLevel1", True))
        Me.OpRiskLevel1_lbl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OpRiskLevel1_lbl.ForeColor = System.Drawing.Color.Cyan
        Me.OpRiskLevel1_lbl.Location = New System.Drawing.Point(907, 50)
        Me.OpRiskLevel1_lbl.Name = "OpRiskLevel1_lbl"
        Me.OpRiskLevel1_lbl.Size = New System.Drawing.Size(53, 14)
        Me.OpRiskLevel1_lbl.TabIndex = 9
        Me.OpRiskLevel1_lbl.Text = "OpRisk:"
        '
        'SCHADENSFALLBindingSource
        '
        Me.SCHADENSFALLBindingSource.DataMember = "SCHADENSFALL"
        Me.SCHADENSFALLBindingSource.DataSource = Me.IncidentsDataset
        '
        'IncidentsDataset
        '
        Me.IncidentsDataset.DataSetName = "IncidentsDataset"
        Me.IncidentsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OpRiskNr_lbl
        '
        Me.OpRiskNr_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OpRiskNr_lbl.AutoSize = True
        Me.OpRiskNr_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "OpRiskNr", True))
        Me.OpRiskNr_lbl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OpRiskNr_lbl.ForeColor = System.Drawing.Color.Cyan
        Me.OpRiskNr_lbl.Location = New System.Drawing.Point(907, 74)
        Me.OpRiskNr_lbl.Name = "OpRiskNr_lbl"
        Me.OpRiskNr_lbl.Size = New System.Drawing.Size(53, 14)
        Me.OpRiskNr_lbl.TabIndex = 10
        Me.OpRiskNr_lbl.Text = "OpRisk:"
        '
        'OpRiskLevel2_lbl
        '
        Me.OpRiskLevel2_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OpRiskLevel2_lbl.AutoSize = True
        Me.OpRiskLevel2_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "OpRiskLevel2", True))
        Me.OpRiskLevel2_lbl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OpRiskLevel2_lbl.ForeColor = System.Drawing.Color.Cyan
        Me.OpRiskLevel2_lbl.Location = New System.Drawing.Point(907, 97)
        Me.OpRiskLevel2_lbl.Name = "OpRiskLevel2_lbl"
        Me.OpRiskLevel2_lbl.Size = New System.Drawing.Size(53, 14)
        Me.OpRiskLevel2_lbl.TabIndex = 11
        Me.OpRiskLevel2_lbl.Text = "OpRisk:"
        '
        'OpRiskMateriality_lbl
        '
        Me.OpRiskMateriality_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OpRiskMateriality_lbl.AutoSize = True
        Me.OpRiskMateriality_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "OpRiskMateriality", True))
        Me.OpRiskMateriality_lbl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OpRiskMateriality_lbl.ForeColor = System.Drawing.Color.Cyan
        Me.OpRiskMateriality_lbl.Location = New System.Drawing.Point(907, 120)
        Me.OpRiskMateriality_lbl.Name = "OpRiskMateriality_lbl"
        Me.OpRiskMateriality_lbl.Size = New System.Drawing.Size(53, 14)
        Me.OpRiskMateriality_lbl.TabIndex = 12
        Me.OpRiskMateriality_lbl.Text = "OpRisk:"
        '
        'SCHADENSFALLTableAdapter
        '
        Me.SCHADENSFALLTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.SCHADENFALL_DOCSTableAdapter = Me.SCHADENFALL_DOCSTableAdapter
        Me.TableAdapterManager.SCHADENSFALL_OPTIONSTableAdapter = Nothing
        Me.TableAdapterManager.SCHADENSFALLTableAdapter = Me.SCHADENSFALLTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.IncidentsDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'SCHADENFALL_DOCSTableAdapter
        '
        Me.SCHADENFALL_DOCSTableAdapter.ClearBeforeFill = True
        '
        'SCHADENFALL_DOCSBindingSource
        '
        Me.SCHADENFALL_DOCSBindingSource.DataMember = "FK_SCHADENFALL_DOCS_SCHADENSFALL"
        Me.SCHADENFALL_DOCSBindingSource.DataSource = Me.SCHADENSFALLBindingSource
        '
        'SCHADENSFALL_OPTIONSBindingSource
        '
        Me.SCHADENSFALL_OPTIONSBindingSource.DataMember = "SCHADENSFALL_OPTIONS"
        Me.SCHADENSFALL_OPTIONSBindingSource.DataSource = Me.IncidentsDataset
        '
        'SCHADENSFALL_OPTIONSTableAdapter
        '
        Me.SCHADENSFALL_OPTIONSTableAdapter.ClearBeforeFill = True
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "DisplayDetail.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "DisplayAll.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "NonValid.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "Valid.ico")
        Me.ImageCollection1.Images.SetKeyName(5, "Report.ico")
        Me.ImageCollection1.Images.SetKeyName(6, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "CrystalReport.jpg")
        Me.ImageCollection1.Images.SetKeyName(8, "Calculator.ico")
        Me.ImageCollection1.Images.SetKeyName(9, "Pending.ico")
        Me.ImageCollection1.Images.SetKeyName(10, "Still Pending.ico")
        Me.ImageCollection1.Images.SetKeyName(11, "Info.ico")
        Me.ImageCollection1.Images.SetKeyName(12, "Refresh.ico")
        Me.ImageCollection1.Images.SetKeyName(13, "save.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 15)
        Me.ImageCollection1.Images.SetKeyName(15, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 16)
        Me.ImageCollection1.Images.SetKeyName(16, "remove_16x16.png")
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.SCHADENSFALLBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 14, True, True, "Add New Incident", "AddNew")})
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.Incicents_BaseView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemMemoExEdit2, Me.RepositoryItemComboBox2, Me.RepositoryItemComboBox3})
        Me.GridControl1.Size = New System.Drawing.Size(1370, 673)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Incicents_BaseView, Me.LayoutView1, Me.LayoutView5, Me.LayoutView6})
        '
        'Incicents_BaseView
        '
        Me.Incicents_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Incicents_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Incicents_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Incicents_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Incicents_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Incicents_BaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.Incicents_BaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Incicents_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colCaseID, Me.colClassification, Me.colOpRiskLetter, Me.colOpRiskLevel1, Me.colOpRiskNr, Me.colOpRiskLevel2, Me.colOpRiskMateriality, Me.colEventDate, Me.colDeclarationDate, Me.colExtentOfDamage, Me.colDamageCompensations, Me.colDamageCompensationsAmount, Me.colCaseDescription, Me.colMeasures})
        Me.Incicents_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Yellow
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.Column = Me.colOpRiskMateriality
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = "Medium"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Green
        StyleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.Green
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.White
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Column = Me.colOpRiskMateriality
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Value1 = "Low"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.Red
        StyleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.Red
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.White
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.Column = Me.colOpRiskMateriality
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition3.Value1 = "High"
        Me.Incicents_BaseView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3})
        Me.Incicents_BaseView.GridControl = Me.GridControl1
        Me.Incicents_BaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance(EUR Equ)", Nothing, "{0:n2}")})
        Me.Incicents_BaseView.Name = "Incicents_BaseView"
        Me.Incicents_BaseView.NewItemRowText = "Add new Basic Parameter"
        Me.Incicents_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Incicents_BaseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Incicents_BaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Incicents_BaseView.OptionsBehavior.ReadOnly = True
        Me.Incicents_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.Incicents_BaseView.OptionsDetail.EnableMasterViewMode = False
        Me.Incicents_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Incicents_BaseView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Incicents_BaseView.OptionsFind.AlwaysVisible = True
        Me.Incicents_BaseView.OptionsSelection.MultiSelect = True
        Me.Incicents_BaseView.OptionsView.ColumnAutoWidth = False
        Me.Incicents_BaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Incicents_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Incicents_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.Incicents_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Incicents_BaseView.OptionsView.ShowFooter = True
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colCaseID
        '
        Me.colCaseID.FieldName = "CaseID"
        Me.colCaseID.Name = "colCaseID"
        Me.colCaseID.OptionsColumn.AllowEdit = False
        Me.colCaseID.OptionsColumn.ReadOnly = True
        '
        'colClassification
        '
        Me.colClassification.AppearanceCell.Options.UseTextOptions = True
        Me.colClassification.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClassification.FieldName = "Classification"
        Me.colClassification.Name = "colClassification"
        Me.colClassification.OptionsColumn.AllowEdit = False
        Me.colClassification.OptionsColumn.ReadOnly = True
        Me.colClassification.Visible = True
        Me.colClassification.VisibleIndex = 0
        Me.colClassification.Width = 82
        '
        'colOpRiskLetter
        '
        Me.colOpRiskLetter.AppearanceCell.Options.UseTextOptions = True
        Me.colOpRiskLetter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOpRiskLetter.FieldName = "OpRiskLetter"
        Me.colOpRiskLetter.Name = "colOpRiskLetter"
        Me.colOpRiskLetter.OptionsColumn.AllowEdit = False
        Me.colOpRiskLetter.OptionsColumn.ReadOnly = True
        Me.colOpRiskLetter.Width = 91
        '
        'colOpRiskLevel1
        '
        Me.colOpRiskLevel1.FieldName = "OpRiskLevel1"
        Me.colOpRiskLevel1.Name = "colOpRiskLevel1"
        Me.colOpRiskLevel1.OptionsColumn.AllowEdit = False
        Me.colOpRiskLevel1.OptionsColumn.ReadOnly = True
        Me.colOpRiskLevel1.Visible = True
        Me.colOpRiskLevel1.VisibleIndex = 1
        Me.colOpRiskLevel1.Width = 267
        '
        'colOpRiskNr
        '
        Me.colOpRiskNr.AppearanceCell.Options.UseTextOptions = True
        Me.colOpRiskNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOpRiskNr.FieldName = "OpRiskNr"
        Me.colOpRiskNr.Name = "colOpRiskNr"
        Me.colOpRiskNr.OptionsColumn.AllowEdit = False
        Me.colOpRiskNr.OptionsColumn.ReadOnly = True
        '
        'colOpRiskLevel2
        '
        Me.colOpRiskLevel2.FieldName = "OpRiskLevel2"
        Me.colOpRiskLevel2.Name = "colOpRiskLevel2"
        Me.colOpRiskLevel2.OptionsColumn.AllowEdit = False
        Me.colOpRiskLevel2.OptionsColumn.ReadOnly = True
        Me.colOpRiskLevel2.Visible = True
        Me.colOpRiskLevel2.VisibleIndex = 2
        Me.colOpRiskLevel2.Width = 295
        '
        'colEventDate
        '
        Me.colEventDate.AppearanceCell.Options.UseTextOptions = True
        Me.colEventDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colEventDate.DisplayFormat.FormatString = "d"
        Me.colEventDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colEventDate.FieldName = "EventDate"
        Me.colEventDate.Name = "colEventDate"
        Me.colEventDate.OptionsColumn.AllowEdit = False
        Me.colEventDate.OptionsColumn.ReadOnly = True
        Me.colEventDate.Visible = True
        Me.colEventDate.VisibleIndex = 4
        Me.colEventDate.Width = 86
        '
        'colDeclarationDate
        '
        Me.colDeclarationDate.AppearanceCell.Options.UseTextOptions = True
        Me.colDeclarationDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDeclarationDate.DisplayFormat.FormatString = "d"
        Me.colDeclarationDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDeclarationDate.FieldName = "DeclarationDate"
        Me.colDeclarationDate.Name = "colDeclarationDate"
        Me.colDeclarationDate.OptionsColumn.AllowEdit = False
        Me.colDeclarationDate.OptionsColumn.ReadOnly = True
        Me.colDeclarationDate.Visible = True
        Me.colDeclarationDate.VisibleIndex = 5
        Me.colDeclarationDate.Width = 92
        '
        'colExtentOfDamage
        '
        Me.colExtentOfDamage.AppearanceCell.Options.UseTextOptions = True
        Me.colExtentOfDamage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExtentOfDamage.DisplayFormat.FormatString = "c2"
        Me.colExtentOfDamage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExtentOfDamage.FieldName = "ExtentOfDamage"
        Me.colExtentOfDamage.Name = "colExtentOfDamage"
        Me.colExtentOfDamage.OptionsColumn.AllowEdit = False
        Me.colExtentOfDamage.OptionsColumn.ReadOnly = True
        Me.colExtentOfDamage.Visible = True
        Me.colExtentOfDamage.VisibleIndex = 6
        Me.colExtentOfDamage.Width = 117
        '
        'colDamageCompensations
        '
        Me.colDamageCompensations.AppearanceCell.Options.UseTextOptions = True
        Me.colDamageCompensations.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDamageCompensations.FieldName = "DamageCompensations"
        Me.colDamageCompensations.Name = "colDamageCompensations"
        Me.colDamageCompensations.OptionsColumn.AllowEdit = False
        Me.colDamageCompensations.OptionsColumn.ReadOnly = True
        Me.colDamageCompensations.Visible = True
        Me.colDamageCompensations.VisibleIndex = 7
        Me.colDamageCompensations.Width = 124
        '
        'colDamageCompensationsAmount
        '
        Me.colDamageCompensationsAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colDamageCompensationsAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colDamageCompensationsAmount.DisplayFormat.FormatString = "c2"
        Me.colDamageCompensationsAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDamageCompensationsAmount.FieldName = "DamageCompensationsAmount"
        Me.colDamageCompensationsAmount.Name = "colDamageCompensationsAmount"
        Me.colDamageCompensationsAmount.OptionsColumn.AllowEdit = False
        Me.colDamageCompensationsAmount.OptionsColumn.ReadOnly = True
        Me.colDamageCompensationsAmount.Visible = True
        Me.colDamageCompensationsAmount.VisibleIndex = 8
        Me.colDamageCompensationsAmount.Width = 166
        '
        'colCaseDescription
        '
        Me.colCaseDescription.FieldName = "CaseDescription"
        Me.colCaseDescription.Name = "colCaseDescription"
        Me.colCaseDescription.OptionsColumn.AllowEdit = False
        Me.colCaseDescription.OptionsColumn.ReadOnly = True
        '
        'colMeasures
        '
        Me.colMeasures.FieldName = "Measures"
        Me.colMeasures.Name = "colMeasures"
        Me.colMeasures.OptionsColumn.AllowEdit = False
        Me.colMeasures.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.DropDownRows = 2
        Me.RepositoryItemComboBox1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox1.ImmediatePopup = True
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AutoHeight = False
        Me.RepositoryItemMemoExEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit2.Name = "RepositoryItemMemoExEdit2"
        Me.RepositoryItemMemoExEdit2.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox2.ImmediatePopup = True
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"N", "IN", "TO", "FROM"})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        Me.RepositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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
        Me.RepositoryItemComboBox3.ImmediatePopup = True
        Me.RepositoryItemComboBox3.Items.AddRange(New Object() {"A1", "DE", "U9", "EU", "Z9"})
        Me.RepositoryItemComboBox3.Name = "RepositoryItemComboBox3"
        Me.RepositoryItemComboBox3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'LayoutView1
        '
        Me.LayoutView1.CardMinSize = New System.Drawing.Size(567, 651)
        Me.LayoutView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.LayoutViewColumn4, Me.LayoutViewColumn5, Me.LayoutViewColumn6, Me.LayoutViewColumn7, Me.LayoutViewColumn8, Me.LayoutViewColumn9, Me.LayoutViewColumn10, Me.LayoutViewColumn11, Me.LayoutViewColumn12, Me.LayoutViewColumn13, Me.LayoutViewColumn14, Me.LayoutViewColumn15, Me.LayoutViewColumn16, Me.LayoutViewColumn17, Me.LayoutViewColumn18, Me.LayoutViewColumn19, Me.LayoutViewColumn20, Me.LayoutViewColumn21, Me.LayoutViewColumn22, Me.LayoutViewColumn23, Me.LayoutViewColumn24, Me.LayoutViewColumn25, Me.LayoutViewColumn104, Me.LayoutViewColumn105, Me.LayoutViewColumn106, Me.LayoutViewColumn107, Me.LayoutViewColumn108, Me.LayoutViewColumn109, Me.LayoutViewColumn110, Me.LayoutViewColumn111, Me.LayoutViewColumn112, Me.LayoutViewColumn113, Me.LayoutViewColumn114, Me.LayoutViewColumn115, Me.LayoutViewColumn116, Me.LayoutViewColumn117, Me.LayoutViewColumn118, Me.LayoutViewColumn119, Me.LayoutViewColumn120, Me.LayoutViewColumn121, Me.LayoutViewColumn122, Me.LayoutViewColumn123, Me.LayoutViewColumn124, Me.LayoutViewColumn125, Me.LayoutViewColumn126, Me.LayoutViewColumn127, Me.LayoutViewColumn128, Me.LayoutViewColumn129, Me.LayoutViewColumn130, Me.LayoutViewColumn131})
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField95, Me.LayoutViewField94})
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView1.OptionsFilter.AllowFilterEditor = False
        Me.LayoutView1.OptionsFilter.AllowMRUFilterList = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowPanButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn1.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn1.FieldName = "ID"
        Me.LayoutViewColumn1.LayoutViewField = Me.LayoutViewField26
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        Me.LayoutViewColumn1.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn1.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn1.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField26
        '
        Me.LayoutViewField26.EditorPreferredWidth = 113
        Me.LayoutViewField26.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField26.Name = "LayoutViewField26"
        Me.LayoutViewField26.Size = New System.Drawing.Size(137, 20)
        Me.LayoutViewField26.TextSize = New System.Drawing.Size(15, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn2.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn2.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn2.FieldName = "Datensatz-nummer"
        Me.LayoutViewColumn2.LayoutViewField = Me.LayoutViewField27
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        Me.LayoutViewColumn2.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn2.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn2.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField27
        '
        Me.LayoutViewField27.EditorPreferredWidth = 85
        Me.LayoutViewField27.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField27.Name = "LayoutViewField27"
        Me.LayoutViewField27.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField27.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn3.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn3.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn3.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn3.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn3.FieldName = "Bankleitzahl"
        Me.LayoutViewColumn3.LayoutViewField = Me.LayoutViewField28
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        Me.LayoutViewColumn3.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn3.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn3.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField28
        '
        Me.LayoutViewField28.EditorPreferredWidth = 85
        Me.LayoutViewField28.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField28.Name = "LayoutViewField28"
        Me.LayoutViewField28.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField28.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn4.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn4.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn4.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn4.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn4.FieldName = "BIC"
        Me.LayoutViewColumn4.LayoutViewField = Me.LayoutViewField29
        Me.LayoutViewColumn4.Name = "LayoutViewColumn4"
        Me.LayoutViewColumn4.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn4.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn4.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField29
        '
        Me.LayoutViewField29.EditorPreferredWidth = 85
        Me.LayoutViewField29.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField29.Name = "LayoutViewField29"
        Me.LayoutViewField29.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField29.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn5
        '
        Me.LayoutViewColumn5.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn5.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn5.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn5.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn5.FieldName = "Bezeichnung des Zahlungsdienstleisters"
        Me.LayoutViewColumn5.LayoutViewField = Me.LayoutViewField30
        Me.LayoutViewColumn5.Name = "LayoutViewColumn5"
        Me.LayoutViewColumn5.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn5.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn5.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField30
        '
        Me.LayoutViewField30.EditorPreferredWidth = 321
        Me.LayoutViewField30.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField30.Name = "LayoutViewField30"
        Me.LayoutViewField30.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField30.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn6
        '
        Me.LayoutViewColumn6.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn6.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn6.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn6.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn6.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn6.FieldName = "Ort (Sitz)"
        Me.LayoutViewColumn6.LayoutViewField = Me.LayoutViewField31
        Me.LayoutViewColumn6.Name = "LayoutViewColumn6"
        Me.LayoutViewColumn6.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn6.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn6.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField31
        '
        Me.LayoutViewField31.EditorPreferredWidth = 321
        Me.LayoutViewField31.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField31.Name = "LayoutViewField31"
        Me.LayoutViewField31.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField31.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn7
        '
        Me.LayoutViewColumn7.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn7.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn7.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn7.FieldName = "Änderungs-kennzeichen"
        Me.LayoutViewColumn7.LayoutViewField = Me.LayoutViewField32
        Me.LayoutViewColumn7.Name = "LayoutViewColumn7"
        Me.LayoutViewColumn7.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn7.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn7.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField32
        '
        Me.LayoutViewField32.EditorPreferredWidth = 321
        Me.LayoutViewField32.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField32.Name = "LayoutViewField32"
        Me.LayoutViewField32.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField32.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn8
        '
        Me.LayoutViewColumn8.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn8.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn8.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn8.FieldName = "Termin BLZ-Löschung"
        Me.LayoutViewColumn8.LayoutViewField = Me.LayoutViewField33
        Me.LayoutViewColumn8.Name = "LayoutViewColumn8"
        Me.LayoutViewColumn8.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn8.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn8.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField33
        '
        Me.LayoutViewField33.EditorPreferredWidth = 321
        Me.LayoutViewField33.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField33.Name = "LayoutViewField33"
        Me.LayoutViewField33.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField33.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn9
        '
        Me.LayoutViewColumn9.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn9.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn9.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn9.FieldName = "DSNr-Nachfolgeinstitut"
        Me.LayoutViewColumn9.LayoutViewField = Me.LayoutViewField34
        Me.LayoutViewColumn9.Name = "LayoutViewColumn9"
        Me.LayoutViewColumn9.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn9.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn9.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField34
        '
        Me.LayoutViewField34.EditorPreferredWidth = 321
        Me.LayoutViewField34.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField34.Name = "LayoutViewField34"
        Me.LayoutViewField34.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField34.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn10
        '
        Me.LayoutViewColumn10.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn10.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn10.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn10.FieldName = "Zustelladresse Firma"
        Me.LayoutViewColumn10.LayoutViewField = Me.LayoutViewField35
        Me.LayoutViewColumn10.Name = "LayoutViewColumn10"
        Me.LayoutViewColumn10.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn10.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn10.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField35
        '
        Me.LayoutViewField35.EditorPreferredWidth = 403
        Me.LayoutViewField35.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField35.Name = "LayoutViewField35"
        Me.LayoutViewField35.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField35.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn11
        '
        Me.LayoutViewColumn11.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn11.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn11.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn11.FieldName = "Zustelladresse Ort"
        Me.LayoutViewColumn11.LayoutViewField = Me.LayoutViewField36
        Me.LayoutViewColumn11.Name = "LayoutViewColumn11"
        Me.LayoutViewColumn11.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn11.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn11.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField36
        '
        Me.LayoutViewField36.EditorPreferredWidth = 403
        Me.LayoutViewField36.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField36.Name = "LayoutViewField36"
        Me.LayoutViewField36.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField36.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn12
        '
        Me.LayoutViewColumn12.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn12.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn12.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn12.FieldName = "Zustelladresse Postfach"
        Me.LayoutViewColumn12.LayoutViewField = Me.LayoutViewField37
        Me.LayoutViewColumn12.Name = "LayoutViewColumn12"
        Me.LayoutViewColumn12.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn12.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn12.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField37
        '
        Me.LayoutViewField37.EditorPreferredWidth = 403
        Me.LayoutViewField37.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField37.Name = "LayoutViewField37"
        Me.LayoutViewField37.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField37.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn13
        '
        Me.LayoutViewColumn13.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn13.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn13.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn13.FieldName = "Zustelladresse Postleitzahl"
        Me.LayoutViewColumn13.LayoutViewField = Me.LayoutViewField38
        Me.LayoutViewColumn13.Name = "LayoutViewColumn13"
        Me.LayoutViewColumn13.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn13.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn13.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField38
        '
        Me.LayoutViewField38.EditorPreferredWidth = 403
        Me.LayoutViewField38.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField38.Name = "LayoutViewField38"
        Me.LayoutViewField38.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField38.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn14
        '
        Me.LayoutViewColumn14.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn14.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn14.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn14.FieldName = "Rücksendung Firma"
        Me.LayoutViewColumn14.LayoutViewField = Me.LayoutViewField39
        Me.LayoutViewColumn14.Name = "LayoutViewColumn14"
        Me.LayoutViewColumn14.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn14.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn14.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField39
        '
        Me.LayoutViewField39.EditorPreferredWidth = 597
        Me.LayoutViewField39.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField39.Name = "LayoutViewField39"
        Me.LayoutViewField39.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField39.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn15
        '
        Me.LayoutViewColumn15.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn15.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn15.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn15.FieldName = "Rücksendung Postfach"
        Me.LayoutViewColumn15.LayoutViewField = Me.LayoutViewField40
        Me.LayoutViewColumn15.Name = "LayoutViewColumn15"
        Me.LayoutViewColumn15.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn15.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn15.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField40
        '
        Me.LayoutViewField40.EditorPreferredWidth = 597
        Me.LayoutViewField40.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField40.Name = "LayoutViewField40"
        Me.LayoutViewField40.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField40.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn16
        '
        Me.LayoutViewColumn16.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn16.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn16.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn16.FieldName = "Rücksendung Straße"
        Me.LayoutViewColumn16.LayoutViewField = Me.LayoutViewField41
        Me.LayoutViewColumn16.Name = "LayoutViewColumn16"
        Me.LayoutViewColumn16.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn16.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn16.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField41
        '
        Me.LayoutViewField41.EditorPreferredWidth = 597
        Me.LayoutViewField41.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField41.Name = "LayoutViewField41"
        Me.LayoutViewField41.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField41.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn17
        '
        Me.LayoutViewColumn17.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn17.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn17.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn17.FieldName = "Rücksendung Postleitzahl"
        Me.LayoutViewColumn17.LayoutViewField = Me.LayoutViewField42
        Me.LayoutViewColumn17.Name = "LayoutViewColumn17"
        Me.LayoutViewColumn17.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn17.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn17.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField42
        '
        Me.LayoutViewField42.EditorPreferredWidth = 597
        Me.LayoutViewField42.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField42.Name = "LayoutViewField42"
        Me.LayoutViewField42.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField42.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn18
        '
        Me.LayoutViewColumn18.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn18.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn18.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn18.FieldName = "Rücksendung Ort"
        Me.LayoutViewColumn18.LayoutViewField = Me.LayoutViewField43
        Me.LayoutViewColumn18.Name = "LayoutViewColumn18"
        Me.LayoutViewColumn18.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn18.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn18.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField43
        '
        Me.LayoutViewField43.EditorPreferredWidth = 597
        Me.LayoutViewField43.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField43.Name = "LayoutViewField43"
        Me.LayoutViewField43.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField43.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn19
        '
        Me.LayoutViewColumn19.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn19.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn19.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn19.FieldName = "Institutstyp"
        Me.LayoutViewColumn19.LayoutViewField = Me.LayoutViewField44
        Me.LayoutViewColumn19.Name = "LayoutViewColumn19"
        Me.LayoutViewColumn19.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn19.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn19.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField44
        '
        Me.LayoutViewField44.EditorPreferredWidth = 321
        Me.LayoutViewField44.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField44.Name = "LayoutViewField44"
        Me.LayoutViewField44.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField44.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn20
        '
        Me.LayoutViewColumn20.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn20.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn20.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn20.FieldName = "BLZ der vorgeschalteten Stelle"
        Me.LayoutViewColumn20.LayoutViewField = Me.LayoutViewField45
        Me.LayoutViewColumn20.Name = "LayoutViewColumn20"
        Me.LayoutViewColumn20.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn20.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn20.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField45
        '
        Me.LayoutViewField45.EditorPreferredWidth = 321
        Me.LayoutViewField45.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField45.Name = "LayoutViewField45"
        Me.LayoutViewField45.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField45.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn21
        '
        Me.LayoutViewColumn21.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn21.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn21.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn21.FieldName = "Avisierung von Zahlungen TEL"
        Me.LayoutViewColumn21.LayoutViewField = Me.LayoutViewField46
        Me.LayoutViewColumn21.Name = "LayoutViewColumn21"
        Me.LayoutViewColumn21.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn21.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn21.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField46
        '
        Me.LayoutViewField46.EditorPreferredWidth = 561
        Me.LayoutViewField46.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField46.Name = "LayoutViewField46"
        Me.LayoutViewField46.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField46.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn22
        '
        Me.LayoutViewColumn22.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn22.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn22.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn22.FieldName = "Avisierung von Zahlungen FAX"
        Me.LayoutViewColumn22.LayoutViewField = Me.LayoutViewField47
        Me.LayoutViewColumn22.Name = "LayoutViewColumn22"
        Me.LayoutViewColumn22.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn22.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn22.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField47
        '
        Me.LayoutViewField47.EditorPreferredWidth = 561
        Me.LayoutViewField47.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField47.Name = "LayoutViewField47"
        Me.LayoutViewField47.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField47.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn23
        '
        Me.LayoutViewColumn23.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn23.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn23.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn23.FieldName = "Avisierung von Zahlungen EMAIL"
        Me.LayoutViewColumn23.LayoutViewField = Me.LayoutViewField48
        Me.LayoutViewColumn23.Name = "LayoutViewColumn23"
        Me.LayoutViewColumn23.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn23.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn23.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField48
        '
        Me.LayoutViewField48.EditorPreferredWidth = 561
        Me.LayoutViewField48.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField48.Name = "LayoutViewField48"
        Me.LayoutViewField48.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField48.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn24
        '
        Me.LayoutViewColumn24.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn24.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn24.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn24.FieldName = "Überweisungs-nachfragen TEL"
        Me.LayoutViewColumn24.LayoutViewField = Me.LayoutViewField66
        Me.LayoutViewColumn24.Name = "LayoutViewColumn24"
        Me.LayoutViewColumn24.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn24.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn24.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField66
        '
        Me.LayoutViewField66.EditorPreferredWidth = 357
        Me.LayoutViewField66.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField66.Name = "LayoutViewField66"
        Me.LayoutViewField66.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField66.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn25
        '
        Me.LayoutViewColumn25.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn25.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn25.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn25.FieldName = "Überweisungs-nachfragen FAX"
        Me.LayoutViewColumn25.LayoutViewField = Me.LayoutViewField67
        Me.LayoutViewColumn25.Name = "LayoutViewColumn25"
        Me.LayoutViewColumn25.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn25.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn25.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField67
        '
        Me.LayoutViewField67.EditorPreferredWidth = 357
        Me.LayoutViewField67.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField67.Name = "LayoutViewField67"
        Me.LayoutViewField67.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField67.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn104
        '
        Me.LayoutViewColumn104.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn104.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn104.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn104.FieldName = "Überweisungsnachfragen EMAIL"
        Me.LayoutViewColumn104.LayoutViewField = Me.LayoutViewField68
        Me.LayoutViewColumn104.Name = "LayoutViewColumn104"
        Me.LayoutViewColumn104.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn104.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn104.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField68
        '
        Me.LayoutViewField68.EditorPreferredWidth = 357
        Me.LayoutViewField68.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField68.Name = "LayoutViewField68"
        Me.LayoutViewField68.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField68.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn105
        '
        Me.LayoutViewColumn105.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn105.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn105.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn105.FieldName = "Überweisungs-rückruf TEL"
        Me.LayoutViewColumn105.LayoutViewField = Me.LayoutViewField69
        Me.LayoutViewColumn105.Name = "LayoutViewColumn105"
        Me.LayoutViewColumn105.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn105.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn105.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField69
        '
        Me.LayoutViewField69.EditorPreferredWidth = 591
        Me.LayoutViewField69.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField69.Name = "LayoutViewField69"
        Me.LayoutViewField69.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField69.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutViewColumn106
        '
        Me.LayoutViewColumn106.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn106.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn106.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn106.FieldName = "Überweisungs-rückruf FAX"
        Me.LayoutViewColumn106.LayoutViewField = Me.LayoutViewField70
        Me.LayoutViewColumn106.Name = "LayoutViewColumn106"
        Me.LayoutViewColumn106.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn106.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn106.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField70
        '
        Me.LayoutViewField70.EditorPreferredWidth = 591
        Me.LayoutViewField70.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField70.Name = "LayoutViewField70"
        Me.LayoutViewField70.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField70.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutViewColumn107
        '
        Me.LayoutViewColumn107.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn107.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn107.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn107.FieldName = "Überweisungs-rückfragen TEL"
        Me.LayoutViewColumn107.LayoutViewField = Me.LayoutViewField71
        Me.LayoutViewColumn107.Name = "LayoutViewColumn107"
        Me.LayoutViewColumn107.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn107.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn107.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField71
        '
        Me.LayoutViewField71.EditorPreferredWidth = 566
        Me.LayoutViewField71.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField71.Name = "LayoutViewField71"
        Me.LayoutViewField71.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField71.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn108
        '
        Me.LayoutViewColumn108.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn108.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn108.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn108.FieldName = "Überweisungs-rückfragen FAX"
        Me.LayoutViewColumn108.LayoutViewField = Me.LayoutViewField72
        Me.LayoutViewColumn108.Name = "LayoutViewColumn108"
        Me.LayoutViewColumn108.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn108.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn108.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField72
        '
        Me.LayoutViewField72.EditorPreferredWidth = 566
        Me.LayoutViewField72.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField72.Name = "LayoutViewField72"
        Me.LayoutViewField72.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField72.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn109
        '
        Me.LayoutViewColumn109.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn109.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn109.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn109.FieldName = "Überweisungsrückfragen EMAIL"
        Me.LayoutViewColumn109.LayoutViewField = Me.LayoutViewField73
        Me.LayoutViewColumn109.Name = "LayoutViewColumn109"
        Me.LayoutViewColumn109.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn109.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn109.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField73
        '
        Me.LayoutViewField73.EditorPreferredWidth = 566
        Me.LayoutViewField73.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField73.Name = "LayoutViewField73"
        Me.LayoutViewField73.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField73.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn110
        '
        Me.LayoutViewColumn110.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn110.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn110.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn110.FieldName = "Scheckanfrage TEL"
        Me.LayoutViewColumn110.LayoutViewField = Me.LayoutViewField74
        Me.LayoutViewColumn110.Name = "LayoutViewColumn110"
        Me.LayoutViewColumn110.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn110.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn110.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField74
        '
        Me.LayoutViewField74.EditorPreferredWidth = 614
        Me.LayoutViewField74.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField74.Name = "LayoutViewField74"
        Me.LayoutViewField74.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField74.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn111
        '
        Me.LayoutViewColumn111.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn111.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn111.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn111.FieldName = "Scheckanfrage FAX"
        Me.LayoutViewColumn111.LayoutViewField = Me.LayoutViewField75
        Me.LayoutViewColumn111.Name = "LayoutViewColumn111"
        Me.LayoutViewColumn111.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn111.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn111.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField75
        '
        Me.LayoutViewField75.EditorPreferredWidth = 614
        Me.LayoutViewField75.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField75.Name = "LayoutViewField75"
        Me.LayoutViewField75.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField75.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn112
        '
        Me.LayoutViewColumn112.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn112.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn112.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn112.FieldName = "Scheckanfrage EMAIL"
        Me.LayoutViewColumn112.LayoutViewField = Me.LayoutViewField76
        Me.LayoutViewColumn112.Name = "LayoutViewColumn112"
        Me.LayoutViewColumn112.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn112.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn112.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField76
        '
        Me.LayoutViewField76.EditorPreferredWidth = 614
        Me.LayoutViewField76.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField76.Name = "LayoutViewField76"
        Me.LayoutViewField76.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField76.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn113
        '
        Me.LayoutViewColumn113.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn113.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn113.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn113.FieldName = "Unbezahlte Schecks/ Lastschriften TEL"
        Me.LayoutViewColumn113.LayoutViewField = Me.LayoutViewField77
        Me.LayoutViewColumn113.Name = "LayoutViewColumn113"
        Me.LayoutViewColumn113.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn113.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn113.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField77
        '
        Me.LayoutViewField77.EditorPreferredWidth = 521
        Me.LayoutViewField77.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField77.Name = "LayoutViewField77"
        Me.LayoutViewField77.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField77.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn114
        '
        Me.LayoutViewColumn114.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn114.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn114.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn114.FieldName = "Unbezahlte Schecks/ Lastschriften FAX"
        Me.LayoutViewColumn114.LayoutViewField = Me.LayoutViewField78
        Me.LayoutViewColumn114.Name = "LayoutViewColumn114"
        Me.LayoutViewColumn114.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn114.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn114.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField78
        '
        Me.LayoutViewField78.EditorPreferredWidth = 521
        Me.LayoutViewField78.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField78.Name = "LayoutViewField78"
        Me.LayoutViewField78.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField78.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn115
        '
        Me.LayoutViewColumn115.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn115.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn115.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn115.FieldName = "Unbezahlte Schecks/ Lastschriften EMAIL"
        Me.LayoutViewColumn115.LayoutViewField = Me.LayoutViewField79
        Me.LayoutViewColumn115.Name = "LayoutViewColumn115"
        Me.LayoutViewColumn115.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn115.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn115.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField79
        '
        Me.LayoutViewField79.EditorPreferredWidth = 521
        Me.LayoutViewField79.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField79.Name = "LayoutViewField79"
        Me.LayoutViewField79.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField79.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn116
        '
        Me.LayoutViewColumn116.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn116.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn116.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn116.FieldName = "Lastschrift-rückruf TEL"
        Me.LayoutViewColumn116.LayoutViewField = Me.LayoutViewField80
        Me.LayoutViewColumn116.Name = "LayoutViewColumn116"
        Me.LayoutViewColumn116.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn116.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn116.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField80
        '
        Me.LayoutViewField80.EditorPreferredWidth = 601
        Me.LayoutViewField80.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField80.Name = "LayoutViewField80"
        Me.LayoutViewField80.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField80.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn117
        '
        Me.LayoutViewColumn117.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn117.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn117.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn117.FieldName = "Lastschrift-rückruf FAX"
        Me.LayoutViewColumn117.LayoutViewField = Me.LayoutViewField81
        Me.LayoutViewColumn117.Name = "LayoutViewColumn117"
        Me.LayoutViewColumn117.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn117.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn117.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField81
        '
        Me.LayoutViewField81.EditorPreferredWidth = 601
        Me.LayoutViewField81.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField81.Name = "LayoutViewField81"
        Me.LayoutViewField81.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField81.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn118
        '
        Me.LayoutViewColumn118.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn118.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn118.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn118.FieldName = "Lastschriftrückruf EMAIL"
        Me.LayoutViewColumn118.LayoutViewField = Me.LayoutViewField82
        Me.LayoutViewColumn118.Name = "LayoutViewColumn118"
        Me.LayoutViewColumn118.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn118.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn118.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField82
        '
        Me.LayoutViewField82.EditorPreferredWidth = 601
        Me.LayoutViewField82.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField82.Name = "LayoutViewField82"
        Me.LayoutViewField82.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField82.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn119
        '
        Me.LayoutViewColumn119.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn119.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn119.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn119.FieldName = "Wechselrückrufe TEL"
        Me.LayoutViewColumn119.LayoutViewField = Me.LayoutViewField83
        Me.LayoutViewColumn119.Name = "LayoutViewColumn119"
        Me.LayoutViewColumn119.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn119.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn119.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField83
        '
        Me.LayoutViewField83.EditorPreferredWidth = 581
        Me.LayoutViewField83.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField83.Name = "LayoutViewField83"
        Me.LayoutViewField83.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField83.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn120
        '
        Me.LayoutViewColumn120.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn120.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn120.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn120.FieldName = "Wechselrückrufe FAX"
        Me.LayoutViewColumn120.LayoutViewField = Me.LayoutViewField84
        Me.LayoutViewColumn120.Name = "LayoutViewColumn120"
        Me.LayoutViewColumn120.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn120.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn120.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField84
        '
        Me.LayoutViewField84.EditorPreferredWidth = 581
        Me.LayoutViewField84.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField84.Name = "LayoutViewField84"
        Me.LayoutViewField84.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField84.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn121
        '
        Me.LayoutViewColumn121.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn121.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn121.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn121.FieldName = "Wechselrückrufe EMAIL"
        Me.LayoutViewColumn121.LayoutViewField = Me.LayoutViewField85
        Me.LayoutViewColumn121.Name = "LayoutViewColumn121"
        Me.LayoutViewColumn121.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn121.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn121.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField85
        '
        Me.LayoutViewField85.EditorPreferredWidth = 581
        Me.LayoutViewField85.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField85.Name = "LayoutViewField85"
        Me.LayoutViewField85.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField85.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn122
        '
        Me.LayoutViewColumn122.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn122.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn122.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn122.FieldName = "Unbezahlte Wechsel TEL"
        Me.LayoutViewColumn122.LayoutViewField = Me.LayoutViewField86
        Me.LayoutViewColumn122.Name = "LayoutViewColumn122"
        Me.LayoutViewColumn122.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn122.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn122.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField86
        '
        Me.LayoutViewField86.EditorPreferredWidth = 564
        Me.LayoutViewField86.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField86.Name = "LayoutViewField86"
        Me.LayoutViewField86.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField86.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn123
        '
        Me.LayoutViewColumn123.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn123.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn123.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn123.FieldName = "Unbezahlte Wechsel FAX"
        Me.LayoutViewColumn123.LayoutViewField = Me.LayoutViewField87
        Me.LayoutViewColumn123.Name = "LayoutViewColumn123"
        Me.LayoutViewColumn123.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn123.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn123.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField87
        '
        Me.LayoutViewField87.EditorPreferredWidth = 564
        Me.LayoutViewField87.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField87.Name = "LayoutViewField87"
        Me.LayoutViewField87.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField87.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn124
        '
        Me.LayoutViewColumn124.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn124.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn124.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn124.FieldName = "Unbezahlte Wechsel EMAIL"
        Me.LayoutViewColumn124.LayoutViewField = Me.LayoutViewField88
        Me.LayoutViewColumn124.Name = "LayoutViewColumn124"
        Me.LayoutViewColumn124.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn124.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn124.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField88
        '
        Me.LayoutViewField88.EditorPreferredWidth = 564
        Me.LayoutViewField88.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField88.Name = "LayoutViewField88"
        Me.LayoutViewField88.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField88.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn125
        '
        Me.LayoutViewColumn125.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn125.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn125.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn125.FieldName = "Vorgeschaltete Stelle TEL"
        Me.LayoutViewColumn125.LayoutViewField = Me.LayoutViewField89
        Me.LayoutViewColumn125.Name = "LayoutViewColumn125"
        Me.LayoutViewColumn125.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn125.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn125.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField89
        '
        Me.LayoutViewField89.EditorPreferredWidth = 584
        Me.LayoutViewField89.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField89.Name = "LayoutViewField89"
        Me.LayoutViewField89.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField89.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn126
        '
        Me.LayoutViewColumn126.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn126.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn126.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn126.FieldName = "Vorgeschaltete Stelle FAX"
        Me.LayoutViewColumn126.LayoutViewField = Me.LayoutViewField90
        Me.LayoutViewColumn126.Name = "LayoutViewColumn126"
        Me.LayoutViewColumn126.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn126.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn126.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField90
        '
        Me.LayoutViewField90.EditorPreferredWidth = 584
        Me.LayoutViewField90.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField90.Name = "LayoutViewField90"
        Me.LayoutViewField90.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField90.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn127
        '
        Me.LayoutViewColumn127.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn127.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn127.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn127.FieldName = "Vorgeschaltete Stelle EMAIL"
        Me.LayoutViewColumn127.LayoutViewField = Me.LayoutViewField91
        Me.LayoutViewColumn127.Name = "LayoutViewColumn127"
        Me.LayoutViewColumn127.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn127.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn127.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField91
        '
        Me.LayoutViewField91.EditorPreferredWidth = 584
        Me.LayoutViewField91.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField91.Name = "LayoutViewField91"
        Me.LayoutViewField91.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField91.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn128
        '
        Me.LayoutViewColumn128.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn128.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn128.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn128.FieldName = "Meldeweg"
        Me.LayoutViewColumn128.LayoutViewField = Me.LayoutViewField92
        Me.LayoutViewColumn128.Name = "LayoutViewColumn128"
        Me.LayoutViewColumn128.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn128.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn128.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField92
        '
        Me.LayoutViewField92.EditorPreferredWidth = 321
        Me.LayoutViewField92.Location = New System.Drawing.Point(0, 200)
        Me.LayoutViewField92.Name = "LayoutViewField92"
        Me.LayoutViewField92.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField92.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn129
        '
        Me.LayoutViewColumn129.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn129.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn129.ColumnEdit = Me.RepositoryItemComboBox1
        Me.LayoutViewColumn129.FieldName = "VALID"
        Me.LayoutViewColumn129.LayoutViewField = Me.LayoutViewField93
        Me.LayoutViewColumn129.Name = "LayoutViewColumn129"
        Me.LayoutViewColumn129.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn129.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn129.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField93
        '
        Me.LayoutViewField93.EditorPreferredWidth = 48
        Me.LayoutViewField93.Location = New System.Drawing.Point(0, 220)
        Me.LayoutViewField93.Name = "LayoutViewField93"
        Me.LayoutViewField93.Size = New System.Drawing.Size(250, 20)
        Me.LayoutViewField93.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn130
        '
        Me.LayoutViewColumn130.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn130.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn130.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn130.FieldName = "USER"
        Me.LayoutViewColumn130.LayoutViewField = Me.LayoutViewField94
        Me.LayoutViewColumn130.Name = "LayoutViewColumn130"
        Me.LayoutViewColumn130.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn130.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn130.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField94
        '
        Me.LayoutViewField94.EditorPreferredWidth = 20
        Me.LayoutViewField94.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField94.Name = "LayoutViewField94"
        Me.LayoutViewField94.Size = New System.Drawing.Size(547, 612)
        Me.LayoutViewField94.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn131
        '
        Me.LayoutViewColumn131.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn131.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn131.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn131.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn131.LayoutViewField = Me.LayoutViewField95
        Me.LayoutViewColumn131.Name = "LayoutViewColumn131"
        Me.LayoutViewColumn131.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn131.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn131.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField95
        '
        Me.LayoutViewField95.EditorPreferredWidth = 20
        Me.LayoutViewField95.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField95.Name = "LayoutViewField95"
        Me.LayoutViewField95.Size = New System.Drawing.Size(547, 612)
        Me.LayoutViewField95.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutViewField95.TextVisible = False
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField26})
        Me.LayoutViewCard1.Name = "LayoutViewCard2"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'LayoutView5
        '
        Me.LayoutView5.GridControl = Me.GridControl1
        Me.LayoutView5.Name = "LayoutView5"
        Me.LayoutView5.TemplateCard = Nothing
        '
        'LayoutView6
        '
        Me.LayoutView6.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn132, Me.LayoutViewColumn133, Me.LayoutViewColumn134, Me.LayoutViewColumn135, Me.LayoutViewColumn136, Me.LayoutViewColumn137, Me.LayoutViewColumn138, Me.LayoutViewColumn139, Me.LayoutViewColumn140, Me.LayoutViewColumn141, Me.LayoutViewColumn142, Me.LayoutViewColumn143, Me.LayoutViewColumn144, Me.LayoutViewColumn145, Me.LayoutViewColumn146, Me.LayoutViewColumn147, Me.LayoutViewColumn148, Me.LayoutViewColumn149, Me.LayoutViewColumn150, Me.LayoutViewColumn151, Me.LayoutViewColumn152, Me.LayoutViewColumn153, Me.LayoutViewColumn154, Me.LayoutViewColumn155, Me.LayoutViewColumn156})
        Me.LayoutView6.GridControl = Me.GridControl1
        Me.LayoutView6.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField117, Me.LayoutViewField116, Me.LayoutViewField114})
        Me.LayoutView6.Name = "LayoutView6"
        Me.LayoutView6.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView6.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView6.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView6.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView6.OptionsCustomization.AllowFilter = False
        Me.LayoutView6.OptionsCustomization.AllowSort = False
        Me.LayoutView6.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView6.OptionsCustomization.ShowGroupView = False
        Me.LayoutView6.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView6.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView6.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView6.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView6.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView6.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView6.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView6.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView6.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView6.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView6.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView6.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn132, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView6.TemplateCard = Nothing
        '
        'LayoutViewColumn132
        '
        Me.LayoutViewColumn132.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn132.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn132.FieldName = "Idnr"
        Me.LayoutViewColumn132.LayoutViewField = Me.LayoutViewField96
        Me.LayoutViewColumn132.Name = "LayoutViewColumn132"
        Me.LayoutViewColumn132.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField96
        '
        Me.LayoutViewField96.EditorPreferredWidth = 61
        Me.LayoutViewField96.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField96.Name = "LayoutViewField96"
        Me.LayoutViewField96.Size = New System.Drawing.Size(178, 20)
        Me.LayoutViewField96.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn133
        '
        Me.LayoutViewColumn133.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn133.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn133.FieldName = "TAG"
        Me.LayoutViewColumn133.LayoutViewField = Me.LayoutViewField97
        Me.LayoutViewColumn133.Name = "LayoutViewColumn133"
        '
        'LayoutViewField97
        '
        Me.LayoutViewField97.EditorPreferredWidth = 318
        Me.LayoutViewField97.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField97.Name = "LayoutViewField97"
        Me.LayoutViewField97.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField97.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn134
        '
        Me.LayoutViewColumn134.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn134.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn134.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn134.LayoutViewField = Me.LayoutViewField98
        Me.LayoutViewColumn134.Name = "LayoutViewColumn134"
        '
        'LayoutViewField98
        '
        Me.LayoutViewField98.EditorPreferredWidth = 318
        Me.LayoutViewField98.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField98.Name = "LayoutViewField98"
        Me.LayoutViewField98.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField98.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn135
        '
        Me.LayoutViewColumn135.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn135.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn135.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn135.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn135.LayoutViewField = Me.LayoutViewField99
        Me.LayoutViewColumn135.Name = "LayoutViewColumn135"
        '
        'LayoutViewField99
        '
        Me.LayoutViewField99.EditorPreferredWidth = 306
        Me.LayoutViewField99.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField99.Name = "LayoutViewField99"
        Me.LayoutViewField99.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField99.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn136
        '
        Me.LayoutViewColumn136.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn136.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn136.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn136.LayoutViewField = Me.LayoutViewField100
        Me.LayoutViewColumn136.Name = "LayoutViewColumn136"
        '
        'LayoutViewField100
        '
        Me.LayoutViewField100.EditorPreferredWidth = 306
        Me.LayoutViewField100.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField100.Name = "LayoutViewField100"
        Me.LayoutViewField100.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField100.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn137
        '
        Me.LayoutViewColumn137.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn137.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn137.FieldName = "CITY HEADING"
        Me.LayoutViewColumn137.LayoutViewField = Me.LayoutViewField101
        Me.LayoutViewColumn137.Name = "LayoutViewColumn137"
        '
        'LayoutViewField101
        '
        Me.LayoutViewField101.EditorPreferredWidth = 306
        Me.LayoutViewField101.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField101.Name = "LayoutViewField101"
        Me.LayoutViewField101.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField101.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn138
        '
        Me.LayoutViewColumn138.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn138.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn138.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn138.LayoutViewField = Me.LayoutViewField102
        Me.LayoutViewColumn138.Name = "LayoutViewColumn138"
        '
        'LayoutViewField102
        '
        Me.LayoutViewField102.EditorPreferredWidth = 306
        Me.LayoutViewField102.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField102.Name = "LayoutViewField102"
        Me.LayoutViewField102.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField102.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn139
        '
        Me.LayoutViewColumn139.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn139.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn139.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn139.LayoutViewField = Me.LayoutViewField103
        Me.LayoutViewColumn139.Name = "LayoutViewColumn139"
        '
        'LayoutViewField103
        '
        Me.LayoutViewField103.EditorPreferredWidth = 303
        Me.LayoutViewField103.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField103.Name = "LayoutViewField103"
        Me.LayoutViewField103.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField103.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn140
        '
        Me.LayoutViewColumn140.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn140.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn140.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn140.LayoutViewField = Me.LayoutViewField104
        Me.LayoutViewColumn140.Name = "LayoutViewColumn140"
        '
        'LayoutViewField104
        '
        Me.LayoutViewField104.EditorPreferredWidth = 318
        Me.LayoutViewField104.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField104.Name = "LayoutViewField104"
        Me.LayoutViewField104.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField104.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn141
        '
        Me.LayoutViewColumn141.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn141.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn141.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn141.LayoutViewField = Me.LayoutViewField105
        Me.LayoutViewColumn141.Name = "LayoutViewColumn141"
        '
        'LayoutViewField105
        '
        Me.LayoutViewField105.EditorPreferredWidth = 316
        Me.LayoutViewField105.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField105.Name = "LayoutViewField105"
        Me.LayoutViewField105.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField105.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn142
        '
        Me.LayoutViewColumn142.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn142.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn142.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn142.LayoutViewField = Me.LayoutViewField106
        Me.LayoutViewColumn142.Name = "LayoutViewColumn142"
        '
        'LayoutViewField106
        '
        Me.LayoutViewField106.EditorPreferredWidth = 316
        Me.LayoutViewField106.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField106.Name = "LayoutViewField106"
        Me.LayoutViewField106.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField106.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn143
        '
        Me.LayoutViewColumn143.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn143.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn143.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn143.LayoutViewField = Me.LayoutViewField107
        Me.LayoutViewColumn143.Name = "LayoutViewColumn143"
        '
        'LayoutViewField107
        '
        Me.LayoutViewField107.EditorPreferredWidth = 316
        Me.LayoutViewField107.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField107.Name = "LayoutViewField107"
        Me.LayoutViewField107.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField107.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn144
        '
        Me.LayoutViewColumn144.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn144.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn144.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn144.LayoutViewField = Me.LayoutViewField108
        Me.LayoutViewColumn144.Name = "LayoutViewColumn144"
        '
        'LayoutViewField108
        '
        Me.LayoutViewField108.EditorPreferredWidth = 316
        Me.LayoutViewField108.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField108.Name = "LayoutViewField108"
        Me.LayoutViewField108.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField108.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn145
        '
        Me.LayoutViewColumn145.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn145.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn145.FieldName = "LOCATION"
        Me.LayoutViewColumn145.LayoutViewField = Me.LayoutViewField109
        Me.LayoutViewColumn145.Name = "LayoutViewColumn145"
        '
        'LayoutViewField109
        '
        Me.LayoutViewField109.EditorPreferredWidth = 316
        Me.LayoutViewField109.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField109.Name = "LayoutViewField109"
        Me.LayoutViewField109.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField109.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn146
        '
        Me.LayoutViewColumn146.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn146.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn146.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn146.LayoutViewField = Me.LayoutViewField110
        Me.LayoutViewColumn146.Name = "LayoutViewColumn146"
        '
        'LayoutViewField110
        '
        Me.LayoutViewField110.EditorPreferredWidth = 316
        Me.LayoutViewField110.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField110.Name = "LayoutViewField110"
        Me.LayoutViewField110.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField110.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn147
        '
        Me.LayoutViewColumn147.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn147.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn147.FieldName = "POB NUMBER"
        Me.LayoutViewColumn147.LayoutViewField = Me.LayoutViewField111
        Me.LayoutViewColumn147.Name = "LayoutViewColumn147"
        '
        'LayoutViewField111
        '
        Me.LayoutViewField111.EditorPreferredWidth = 316
        Me.LayoutViewField111.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField111.Name = "LayoutViewField111"
        Me.LayoutViewField111.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField111.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn148
        '
        Me.LayoutViewColumn148.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn148.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn148.FieldName = "POB LOCATION"
        Me.LayoutViewColumn148.LayoutViewField = Me.LayoutViewField112
        Me.LayoutViewColumn148.Name = "LayoutViewColumn148"
        '
        'LayoutViewField112
        '
        Me.LayoutViewField112.EditorPreferredWidth = 316
        Me.LayoutViewField112.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField112.Name = "LayoutViewField112"
        Me.LayoutViewField112.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField112.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn149
        '
        Me.LayoutViewColumn149.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn149.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn149.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn149.LayoutViewField = Me.LayoutViewField113
        Me.LayoutViewColumn149.Name = "LayoutViewColumn149"
        '
        'LayoutViewField113
        '
        Me.LayoutViewField113.EditorPreferredWidth = 316
        Me.LayoutViewField113.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField113.Name = "LayoutViewField113"
        Me.LayoutViewField113.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField113.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn150
        '
        Me.LayoutViewColumn150.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn150.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn150.FieldName = "USER"
        Me.LayoutViewColumn150.LayoutViewField = Me.LayoutViewField114
        Me.LayoutViewColumn150.Name = "LayoutViewColumn150"
        Me.LayoutViewColumn150.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField114
        '
        Me.LayoutViewField114.EditorPreferredWidth = 20
        Me.LayoutViewField114.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField114.Name = "LayoutViewField114"
        Me.LayoutViewField114.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField114.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn151
        '
        Me.LayoutViewColumn151.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn151.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn151.ColumnEdit = Me.RepositoryItemComboBox1
        Me.LayoutViewColumn151.FieldName = "VALID"
        Me.LayoutViewColumn151.LayoutViewField = Me.LayoutViewField115
        Me.LayoutViewColumn151.Name = "LayoutViewColumn151"
        '
        'LayoutViewField115
        '
        Me.LayoutViewField115.EditorPreferredWidth = 70
        Me.LayoutViewField115.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField115.Name = "LayoutViewField115"
        Me.LayoutViewField115.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField115.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn152
        '
        Me.LayoutViewColumn152.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn152.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn152.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn152.LayoutViewField = Me.LayoutViewField116
        Me.LayoutViewColumn152.Name = "LayoutViewColumn152"
        Me.LayoutViewColumn152.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField116
        '
        Me.LayoutViewField116.EditorPreferredWidth = 20
        Me.LayoutViewField116.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField116.Name = "LayoutViewField116"
        Me.LayoutViewField116.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField116.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn153
        '
        Me.LayoutViewColumn153.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn153.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn153.FieldName = "BIC11"
        Me.LayoutViewColumn153.LayoutViewField = Me.LayoutViewField117
        Me.LayoutViewColumn153.Name = "LayoutViewColumn153"
        Me.LayoutViewColumn153.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField117
        '
        Me.LayoutViewField117.EditorPreferredWidth = 20
        Me.LayoutViewField117.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField117.Name = "LayoutViewField117"
        Me.LayoutViewField117.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField117.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn154
        '
        Me.LayoutViewColumn154.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn154.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn154.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn154.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn154.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn154.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn154.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn154.FieldName = "BIC CODE"
        Me.LayoutViewColumn154.LayoutViewField = Me.LayoutViewField118
        Me.LayoutViewColumn154.Name = "LayoutViewColumn154"
        '
        'LayoutViewField118
        '
        Me.LayoutViewField118.EditorPreferredWidth = 70
        Me.LayoutViewField118.ImageOptions.ImageIndex = 0
        Me.LayoutViewField118.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField118.Name = "LayoutViewField118"
        Me.LayoutViewField118.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField118.TextSize = New System.Drawing.Size(123, 16)
        '
        'LayoutViewColumn155
        '
        Me.LayoutViewColumn155.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn155.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn155.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn155.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn155.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn155.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn155.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn155.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn155.LayoutViewField = Me.LayoutViewField119
        Me.LayoutViewColumn155.Name = "LayoutViewColumn155"
        '
        'LayoutViewField119
        '
        Me.LayoutViewField119.EditorPreferredWidth = 70
        Me.LayoutViewField119.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField119.Name = "LayoutViewField119"
        Me.LayoutViewField119.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField119.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn156
        '
        Me.LayoutViewColumn156.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn156.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn156.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn156.FieldName = "COUNTRY"
        Me.LayoutViewColumn156.LayoutViewField = Me.LayoutViewField120
        Me.LayoutViewColumn156.Name = "LayoutViewColumn156"
        Me.LayoutViewColumn156.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField120
        '
        Me.LayoutViewField120.EditorPreferredWidth = 316
        Me.LayoutViewField120.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField120.Name = "LayoutViewField120"
        Me.LayoutViewField120.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField120.TextSize = New System.Drawing.Size(110, 13)
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl2
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.SCHADENFALL_DOCSBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 16
        Me.GridControl2.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 15, True, True, "Add new Attachment", "AddNewAttachment")})
        Me.GridControl2.Location = New System.Drawing.Point(12, 62)
        Me.GridControl2.MainView = Me.IncidentsDocs_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.AnzahlWertRepositoryItemComboBox, Me.RepositoryItemTextEdit4, Me.RepositoryItemMemoExEdit1, Me.RepositoryItemImageComboBox1})
        Me.GridControl2.Size = New System.Drawing.Size(1284, 505)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.IncidentsDocs_GridView, Me.LayoutView4, Me.LayoutView3, Me.LayoutView2})
        '
        'IncidentsDocs_GridView
        '
        Me.IncidentsDocs_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.IncidentsDocs_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.IncidentsDocs_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.IncidentsDocs_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.IncidentsDocs_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.IncidentsDocs_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colFileName, Me.colFileDirectory, Me.colImportDate, Me.colImportTime, Me.colImportUser, Me.colInternalNotes, Me.colIdSchadenfall, Me.colFileNameType})
        Me.IncidentsDocs_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.IncidentsDocs_GridView.GridControl = Me.GridControl2
        Me.IncidentsDocs_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance(EUR Equ)", Nothing, "{0:n2}")})
        Me.IncidentsDocs_GridView.Images = Me.ImageCollection2
        Me.IncidentsDocs_GridView.Name = "IncidentsDocs_GridView"
        Me.IncidentsDocs_GridView.NewItemRowText = "Add new Basic Parameter"
        Me.IncidentsDocs_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.IncidentsDocs_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.IncidentsDocs_GridView.OptionsCustomization.AllowRowSizing = True
        Me.IncidentsDocs_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.IncidentsDocs_GridView.OptionsFind.AlwaysVisible = True
        Me.IncidentsDocs_GridView.OptionsSelection.MultiSelect = True
        Me.IncidentsDocs_GridView.OptionsView.ColumnAutoWidth = False
        Me.IncidentsDocs_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.IncidentsDocs_GridView.OptionsView.ShowAutoFilterRow = True
        Me.IncidentsDocs_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.IncidentsDocs_GridView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colFileName
        '
        Me.colFileName.AppearanceHeader.Options.UseImage = True
        Me.colFileName.FieldName = "FileName"
        Me.colFileName.ImageOptions.ImageIndex = 8
        Me.colFileName.Name = "colFileName"
        Me.colFileName.OptionsColumn.AllowEdit = False
        Me.colFileName.OptionsColumn.ReadOnly = True
        Me.colFileName.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.colFileName.Visible = True
        Me.colFileName.VisibleIndex = 1
        Me.colFileName.Width = 701
        '
        'colFileDirectory
        '
        Me.colFileDirectory.FieldName = "FileDirectory"
        Me.colFileDirectory.Name = "colFileDirectory"
        Me.colFileDirectory.OptionsColumn.AllowEdit = False
        Me.colFileDirectory.OptionsColumn.ReadOnly = True
        Me.colFileDirectory.OptionsColumn.ShowInCustomizationForm = False
        Me.colFileDirectory.OptionsColumn.ShowInExpressionEditor = False
        Me.colFileDirectory.Width = 290
        '
        'colImportDate
        '
        Me.colImportDate.AppearanceCell.Options.UseTextOptions = True
        Me.colImportDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colImportDate.DisplayFormat.FormatString = "d"
        Me.colImportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colImportDate.FieldName = "ImportDate"
        Me.colImportDate.Name = "colImportDate"
        Me.colImportDate.OptionsColumn.AllowEdit = False
        Me.colImportDate.OptionsColumn.ReadOnly = True
        Me.colImportDate.Visible = True
        Me.colImportDate.VisibleIndex = 2
        Me.colImportDate.Width = 99
        '
        'colImportTime
        '
        Me.colImportTime.AppearanceCell.Options.UseTextOptions = True
        Me.colImportTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colImportTime.DisplayFormat.FormatString = "HH:mm:ss"
        Me.colImportTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colImportTime.FieldName = "ImportTime"
        Me.colImportTime.Name = "colImportTime"
        Me.colImportTime.OptionsColumn.AllowEdit = False
        Me.colImportTime.OptionsColumn.ReadOnly = True
        Me.colImportTime.Visible = True
        Me.colImportTime.VisibleIndex = 3
        Me.colImportTime.Width = 97
        '
        'colImportUser
        '
        Me.colImportUser.FieldName = "ImportUser"
        Me.colImportUser.Name = "colImportUser"
        Me.colImportUser.OptionsColumn.AllowEdit = False
        Me.colImportUser.OptionsColumn.ReadOnly = True
        Me.colImportUser.Visible = True
        Me.colImportUser.VisibleIndex = 4
        Me.colImportUser.Width = 125
        '
        'colInternalNotes
        '
        Me.colInternalNotes.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colInternalNotes.FieldName = "InternalNotes"
        Me.colInternalNotes.Name = "colInternalNotes"
        Me.colInternalNotes.OptionsColumn.AllowEdit = False
        Me.colInternalNotes.OptionsColumn.ReadOnly = True
        Me.colInternalNotes.Width = 85
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colIdSchadenfall
        '
        Me.colIdSchadenfall.FieldName = "IdSchadenfall"
        Me.colIdSchadenfall.Name = "colIdSchadenfall"
        Me.colIdSchadenfall.OptionsColumn.AllowEdit = False
        Me.colIdSchadenfall.OptionsColumn.ReadOnly = True
        '
        'colFileNameType
        '
        Me.colFileNameType.Caption = "Type"
        Me.colFileNameType.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colFileNameType.FieldName = "FileNameType"
        Me.colFileNameType.Name = "colFileNameType"
        Me.colFileNameType.OptionsColumn.ReadOnly = True
        Me.colFileNameType.Visible = True
        Me.colFileNameType.VisibleIndex = 0
        Me.colFileNameType.Width = 43
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PDF", ".pdf ", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("WORD 2003", ".doc ", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("WORD 2007", ".docx ", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("TEXT", ".txt ", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DAT", ".dat ", 1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EXCEL 2003", ".xls ", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EXCEL 2007", ".xlsx ", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PNG", ".png ", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACCESS 2003", ".mdb ", 10), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACCESS 2007", ".accdb ", 10), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JPEG", ".jpeg ", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JPEG", ".jpg ", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("POWER POINT", ".ppt ", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EXECUTABLE", ".exe ", 11), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("XML", ".xml ", 12), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("BITMAP", ".bmp ", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("RAR", ".rar ", 13), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ZIP", ".zip ", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("INI", ".ini ", 15), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CHM", ".chm ", 16), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MP4", ".mp4 ", 17), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MP3", ".mp3", 19), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MKV", ".mkv ", 18), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("AVI", ".avi ", 20), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MPEG", ".mpeg ", 20)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection2
        '
        'ImageCollection2
        '
        Me.ImageCollection2.ImageStream = CType(resources.GetObject("ImageCollection2.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection2.Images.SetKeyName(0, "BmpFile.ico")
        Me.ImageCollection2.Images.SetKeyName(1, "DatFile.ico")
        Me.ImageCollection2.Images.SetKeyName(2, "ExcelFile.ico")
        Me.ImageCollection2.Images.SetKeyName(3, "JPEGfile.ico")
        Me.ImageCollection2.Images.SetKeyName(4, "PdfFile.ico")
        Me.ImageCollection2.Images.SetKeyName(5, "PngFile.ico")
        Me.ImageCollection2.Images.SetKeyName(6, "TextFile.ico")
        Me.ImageCollection2.Images.SetKeyName(7, "WordFile.ico")
        Me.ImageCollection2.Images.SetKeyName(8, "Folder Open.ico")
        Me.ImageCollection2.Images.SetKeyName(9, "PowerPointFile.ico")
        Me.ImageCollection2.Images.SetKeyName(10, "AccessFile.ico")
        Me.ImageCollection2.Images.SetKeyName(11, "ExeFile.ico")
        Me.ImageCollection2.Images.SetKeyName(12, "XmlFile.ico")
        Me.ImageCollection2.Images.SetKeyName(13, "RarFile.ico")
        Me.ImageCollection2.Images.SetKeyName(14, "ZipFile.ico")
        Me.ImageCollection2.Images.SetKeyName(15, "IniFile.ico")
        Me.ImageCollection2.Images.SetKeyName(16, "ChmFile.ico")
        Me.ImageCollection2.Images.SetKeyName(17, "AviFile.ico")
        Me.ImageCollection2.Images.SetKeyName(18, "MkvFile.ico")
        Me.ImageCollection2.Images.SetKeyName(19, "Mp3File.ico")
        Me.ImageCollection2.Images.SetKeyName(20, "Mp4File.ico")
        Me.ImageCollection2.Images.SetKeyName(21, "MPEGFile.ico")
        '
        'AnzahlWertRepositoryItemComboBox
        '
        Me.AnzahlWertRepositoryItemComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AnzahlWertRepositoryItemComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AnzahlWertRepositoryItemComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AnzahlWertRepositoryItemComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.AnzahlWertRepositoryItemComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.AnzahlWertRepositoryItemComboBox.AutoHeight = False
        Me.AnzahlWertRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AnzahlWertRepositoryItemComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AnzahlWertRepositoryItemComboBox.DropDownRows = 2
        Me.AnzahlWertRepositoryItemComboBox.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.AnzahlWertRepositoryItemComboBox.ImmediatePopup = True
        Me.AnzahlWertRepositoryItemComboBox.Items.AddRange(New Object() {"Y", "N"})
        Me.AnzahlWertRepositoryItemComboBox.Name = "AnzahlWertRepositoryItemComboBox"
        Me.AnzahlWertRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'LayoutView4
        '
        Me.LayoutView4.CardMinSize = New System.Drawing.Size(567, 651)
        Me.LayoutView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn51, Me.LayoutViewColumn52, Me.LayoutViewColumn53, Me.LayoutViewColumn54, Me.LayoutViewColumn55, Me.LayoutViewColumn56, Me.LayoutViewColumn57, Me.LayoutViewColumn58, Me.LayoutViewColumn59, Me.LayoutViewColumn60, Me.LayoutViewColumn61, Me.LayoutViewColumn62, Me.LayoutViewColumn63, Me.LayoutViewColumn64, Me.LayoutViewColumn65, Me.LayoutViewColumn66, Me.LayoutViewColumn67, Me.LayoutViewColumn68, Me.LayoutViewColumn69, Me.LayoutViewColumn70, Me.LayoutViewColumn71, Me.LayoutViewColumn72, Me.LayoutViewColumn73, Me.LayoutViewColumn74, Me.LayoutViewColumn75, Me.LayoutViewColumn76, Me.LayoutViewColumn77, Me.LayoutViewColumn78, Me.LayoutViewColumn79, Me.LayoutViewColumn80, Me.LayoutViewColumn81, Me.LayoutViewColumn82, Me.LayoutViewColumn83, Me.LayoutViewColumn84, Me.LayoutViewColumn85, Me.LayoutViewColumn86, Me.LayoutViewColumn87, Me.LayoutViewColumn88, Me.LayoutViewColumn89, Me.LayoutViewColumn90, Me.LayoutViewColumn91, Me.LayoutViewColumn92, Me.LayoutViewColumn93, Me.LayoutViewColumn94, Me.LayoutViewColumn95, Me.LayoutViewColumn96, Me.LayoutViewColumn97, Me.LayoutViewColumn98, Me.LayoutViewColumn99, Me.LayoutViewColumn100, Me.LayoutViewColumn101, Me.LayoutViewColumn102, Me.LayoutViewColumn103})
        Me.LayoutView4.GridControl = Me.GridControl2
        Me.LayoutView4.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colUNTERBEARBEITUNGVON, Me.layoutViewField_colUSER})
        Me.LayoutView4.Name = "LayoutView4"
        Me.LayoutView4.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView4.OptionsFilter.AllowFilterEditor = False
        Me.LayoutView4.OptionsFilter.AllowMRUFilterList = False
        Me.LayoutView4.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowPanButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView4.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView4.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView4.TemplateCard = Me.LayoutViewCard2
        '
        'LayoutViewColumn51
        '
        Me.LayoutViewColumn51.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn51.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn51.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn51.FieldName = "ID"
        Me.LayoutViewColumn51.LayoutViewField = Me.layoutViewField_colID
        Me.LayoutViewColumn51.Name = "LayoutViewColumn51"
        Me.LayoutViewColumn51.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn51.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn51.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colID
        '
        Me.layoutViewField_colID.EditorPreferredWidth = 113
        Me.layoutViewField_colID.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID.Name = "layoutViewField_colID"
        Me.layoutViewField_colID.Size = New System.Drawing.Size(137, 20)
        Me.layoutViewField_colID.TextSize = New System.Drawing.Size(15, 13)
        '
        'LayoutViewColumn52
        '
        Me.LayoutViewColumn52.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn52.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn52.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn52.FieldName = "Datensatz-nummer"
        Me.LayoutViewColumn52.LayoutViewField = Me.LayoutViewField49
        Me.LayoutViewColumn52.Name = "LayoutViewColumn52"
        Me.LayoutViewColumn52.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn52.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn52.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField49
        '
        Me.LayoutViewField49.EditorPreferredWidth = 85
        Me.LayoutViewField49.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField49.Name = "LayoutViewField49"
        Me.LayoutViewField49.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField49.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn53
        '
        Me.LayoutViewColumn53.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn53.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn53.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn53.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn53.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn53.FieldName = "Bankleitzahl"
        Me.LayoutViewColumn53.LayoutViewField = Me.layoutViewField_colBankleitzahl
        Me.LayoutViewColumn53.Name = "LayoutViewColumn53"
        Me.LayoutViewColumn53.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn53.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn53.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBankleitzahl
        '
        Me.layoutViewField_colBankleitzahl.EditorPreferredWidth = 85
        Me.layoutViewField_colBankleitzahl.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colBankleitzahl.Name = "layoutViewField_colBankleitzahl"
        Me.layoutViewField_colBankleitzahl.Size = New System.Drawing.Size(287, 20)
        Me.layoutViewField_colBankleitzahl.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn54
        '
        Me.LayoutViewColumn54.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn54.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn54.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn54.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn54.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn54.FieldName = "BIC"
        Me.LayoutViewColumn54.LayoutViewField = Me.layoutViewField_colBIC
        Me.LayoutViewColumn54.Name = "LayoutViewColumn54"
        Me.LayoutViewColumn54.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn54.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn54.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBIC
        '
        Me.layoutViewField_colBIC.EditorPreferredWidth = 85
        Me.layoutViewField_colBIC.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colBIC.Name = "layoutViewField_colBIC"
        Me.layoutViewField_colBIC.Size = New System.Drawing.Size(287, 20)
        Me.layoutViewField_colBIC.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn55
        '
        Me.LayoutViewColumn55.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn55.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn55.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn55.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn55.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn55.FieldName = "Bezeichnung des Zahlungsdienstleisters"
        Me.LayoutViewColumn55.LayoutViewField = Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters
        Me.LayoutViewColumn55.Name = "LayoutViewColumn55"
        Me.LayoutViewColumn55.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn55.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn55.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBezeichnungdesZahlungsdienstleisters
        '
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.EditorPreferredWidth = 321
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.Name = "layoutViewField_colBezeichnungdesZahlungsdienstleisters"
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn56
        '
        Me.LayoutViewColumn56.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn56.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn56.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn56.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn56.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn56.FieldName = "Ort (Sitz)"
        Me.LayoutViewColumn56.LayoutViewField = Me.LayoutViewField50
        Me.LayoutViewColumn56.Name = "LayoutViewColumn56"
        Me.LayoutViewColumn56.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn56.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn56.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField50
        '
        Me.LayoutViewField50.EditorPreferredWidth = 321
        Me.LayoutViewField50.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField50.Name = "LayoutViewField50"
        Me.LayoutViewField50.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField50.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn57
        '
        Me.LayoutViewColumn57.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn57.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn57.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn57.FieldName = "Änderungs-kennzeichen"
        Me.LayoutViewColumn57.LayoutViewField = Me.LayoutViewField51
        Me.LayoutViewColumn57.Name = "LayoutViewColumn57"
        Me.LayoutViewColumn57.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn57.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn57.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField51
        '
        Me.LayoutViewField51.EditorPreferredWidth = 321
        Me.LayoutViewField51.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField51.Name = "LayoutViewField51"
        Me.LayoutViewField51.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField51.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn58
        '
        Me.LayoutViewColumn58.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn58.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn58.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn58.FieldName = "Termin BLZ-Löschung"
        Me.LayoutViewColumn58.LayoutViewField = Me.LayoutViewField52
        Me.LayoutViewColumn58.Name = "LayoutViewColumn58"
        Me.LayoutViewColumn58.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn58.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn58.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField52
        '
        Me.LayoutViewField52.EditorPreferredWidth = 321
        Me.LayoutViewField52.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField52.Name = "LayoutViewField52"
        Me.LayoutViewField52.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField52.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn59
        '
        Me.LayoutViewColumn59.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn59.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn59.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn59.FieldName = "DSNr-Nachfolgeinstitut"
        Me.LayoutViewColumn59.LayoutViewField = Me.LayoutViewField53
        Me.LayoutViewColumn59.Name = "LayoutViewColumn59"
        Me.LayoutViewColumn59.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn59.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn59.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField53
        '
        Me.LayoutViewField53.EditorPreferredWidth = 321
        Me.LayoutViewField53.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField53.Name = "LayoutViewField53"
        Me.LayoutViewField53.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField53.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn60
        '
        Me.LayoutViewColumn60.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn60.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn60.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn60.FieldName = "Zustelladresse Firma"
        Me.LayoutViewColumn60.LayoutViewField = Me.layoutViewField_colZustelladresseFirma
        Me.LayoutViewColumn60.Name = "LayoutViewColumn60"
        Me.LayoutViewColumn60.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn60.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn60.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladresseFirma
        '
        Me.layoutViewField_colZustelladresseFirma.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladresseFirma.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colZustelladresseFirma.Name = "layoutViewField_colZustelladresseFirma"
        Me.layoutViewField_colZustelladresseFirma.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladresseFirma.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn61
        '
        Me.LayoutViewColumn61.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn61.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn61.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn61.FieldName = "Zustelladresse Ort"
        Me.LayoutViewColumn61.LayoutViewField = Me.layoutViewField_colZustelladresseOrt
        Me.LayoutViewColumn61.Name = "LayoutViewColumn61"
        Me.LayoutViewColumn61.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn61.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn61.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladresseOrt
        '
        Me.layoutViewField_colZustelladresseOrt.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladresseOrt.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colZustelladresseOrt.Name = "layoutViewField_colZustelladresseOrt"
        Me.layoutViewField_colZustelladresseOrt.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladresseOrt.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn62
        '
        Me.LayoutViewColumn62.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn62.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn62.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn62.FieldName = "Zustelladresse Postfach"
        Me.LayoutViewColumn62.LayoutViewField = Me.layoutViewField_colZustelladressePostfach
        Me.LayoutViewColumn62.Name = "LayoutViewColumn62"
        Me.LayoutViewColumn62.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn62.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn62.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladressePostfach
        '
        Me.layoutViewField_colZustelladressePostfach.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladressePostfach.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colZustelladressePostfach.Name = "layoutViewField_colZustelladressePostfach"
        Me.layoutViewField_colZustelladressePostfach.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladressePostfach.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn63
        '
        Me.LayoutViewColumn63.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn63.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn63.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn63.FieldName = "Zustelladresse Postleitzahl"
        Me.LayoutViewColumn63.LayoutViewField = Me.layoutViewField_colZustelladressePostleitzahl
        Me.LayoutViewColumn63.Name = "LayoutViewColumn63"
        Me.LayoutViewColumn63.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn63.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn63.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladressePostleitzahl
        '
        Me.layoutViewField_colZustelladressePostleitzahl.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladressePostleitzahl.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colZustelladressePostleitzahl.Name = "layoutViewField_colZustelladressePostleitzahl"
        Me.layoutViewField_colZustelladressePostleitzahl.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladressePostleitzahl.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn64
        '
        Me.LayoutViewColumn64.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn64.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn64.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn64.FieldName = "Rücksendung Firma"
        Me.LayoutViewColumn64.LayoutViewField = Me.layoutViewField_colRücksendungFirma
        Me.LayoutViewColumn64.Name = "LayoutViewColumn64"
        Me.LayoutViewColumn64.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn64.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn64.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungFirma
        '
        Me.layoutViewField_colRücksendungFirma.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungFirma.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colRücksendungFirma.Name = "layoutViewField_colRücksendungFirma"
        Me.layoutViewField_colRücksendungFirma.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungFirma.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn65
        '
        Me.LayoutViewColumn65.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn65.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn65.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn65.FieldName = "Rücksendung Postfach"
        Me.LayoutViewColumn65.LayoutViewField = Me.layoutViewField_colRücksendungPostfach
        Me.LayoutViewColumn65.Name = "LayoutViewColumn65"
        Me.LayoutViewColumn65.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn65.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn65.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungPostfach
        '
        Me.layoutViewField_colRücksendungPostfach.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungPostfach.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colRücksendungPostfach.Name = "layoutViewField_colRücksendungPostfach"
        Me.layoutViewField_colRücksendungPostfach.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungPostfach.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn66
        '
        Me.LayoutViewColumn66.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn66.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn66.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn66.FieldName = "Rücksendung Straße"
        Me.LayoutViewColumn66.LayoutViewField = Me.layoutViewField_colRücksendungStraße
        Me.LayoutViewColumn66.Name = "LayoutViewColumn66"
        Me.LayoutViewColumn66.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn66.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn66.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungStraße
        '
        Me.layoutViewField_colRücksendungStraße.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungStraße.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colRücksendungStraße.Name = "layoutViewField_colRücksendungStraße"
        Me.layoutViewField_colRücksendungStraße.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungStraße.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn67
        '
        Me.LayoutViewColumn67.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn67.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn67.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn67.FieldName = "Rücksendung Postleitzahl"
        Me.LayoutViewColumn67.LayoutViewField = Me.layoutViewField_colRücksendungPostleitzahl
        Me.LayoutViewColumn67.Name = "LayoutViewColumn67"
        Me.LayoutViewColumn67.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn67.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn67.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungPostleitzahl
        '
        Me.layoutViewField_colRücksendungPostleitzahl.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungPostleitzahl.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colRücksendungPostleitzahl.Name = "layoutViewField_colRücksendungPostleitzahl"
        Me.layoutViewField_colRücksendungPostleitzahl.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungPostleitzahl.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn68
        '
        Me.LayoutViewColumn68.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn68.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn68.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn68.FieldName = "Rücksendung Ort"
        Me.LayoutViewColumn68.LayoutViewField = Me.layoutViewField_colRücksendungOrt
        Me.LayoutViewColumn68.Name = "LayoutViewColumn68"
        Me.LayoutViewColumn68.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn68.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn68.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungOrt
        '
        Me.layoutViewField_colRücksendungOrt.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungOrt.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colRücksendungOrt.Name = "layoutViewField_colRücksendungOrt"
        Me.layoutViewField_colRücksendungOrt.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungOrt.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn69
        '
        Me.LayoutViewColumn69.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn69.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn69.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn69.FieldName = "Institutstyp"
        Me.LayoutViewColumn69.LayoutViewField = Me.layoutViewField_colInstitutstyp
        Me.LayoutViewColumn69.Name = "LayoutViewColumn69"
        Me.LayoutViewColumn69.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn69.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn69.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colInstitutstyp
        '
        Me.layoutViewField_colInstitutstyp.EditorPreferredWidth = 321
        Me.layoutViewField_colInstitutstyp.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colInstitutstyp.Name = "layoutViewField_colInstitutstyp"
        Me.layoutViewField_colInstitutstyp.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colInstitutstyp.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn70
        '
        Me.LayoutViewColumn70.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn70.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn70.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn70.FieldName = "BLZ der vorgeschalteten Stelle"
        Me.LayoutViewColumn70.LayoutViewField = Me.layoutViewField_colBLZdervorgeschaltetenStelle
        Me.LayoutViewColumn70.Name = "LayoutViewColumn70"
        Me.LayoutViewColumn70.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn70.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn70.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBLZdervorgeschaltetenStelle
        '
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.EditorPreferredWidth = 321
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.Name = "layoutViewField_colBLZdervorgeschaltetenStelle"
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn71
        '
        Me.LayoutViewColumn71.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn71.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn71.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn71.FieldName = "Avisierung von Zahlungen TEL"
        Me.LayoutViewColumn71.LayoutViewField = Me.layoutViewField_colAvisierungvonZahlungenTEL
        Me.LayoutViewColumn71.Name = "LayoutViewColumn71"
        Me.LayoutViewColumn71.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn71.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn71.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colAvisierungvonZahlungenTEL
        '
        Me.layoutViewField_colAvisierungvonZahlungenTEL.EditorPreferredWidth = 561
        Me.layoutViewField_colAvisierungvonZahlungenTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colAvisierungvonZahlungenTEL.Name = "layoutViewField_colAvisierungvonZahlungenTEL"
        Me.layoutViewField_colAvisierungvonZahlungenTEL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colAvisierungvonZahlungenTEL.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn72
        '
        Me.LayoutViewColumn72.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn72.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn72.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn72.FieldName = "Avisierung von Zahlungen FAX"
        Me.LayoutViewColumn72.LayoutViewField = Me.layoutViewField_colAvisierungvonZahlungenFAX
        Me.LayoutViewColumn72.Name = "LayoutViewColumn72"
        Me.LayoutViewColumn72.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn72.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn72.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colAvisierungvonZahlungenFAX
        '
        Me.layoutViewField_colAvisierungvonZahlungenFAX.EditorPreferredWidth = 561
        Me.layoutViewField_colAvisierungvonZahlungenFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colAvisierungvonZahlungenFAX.Name = "layoutViewField_colAvisierungvonZahlungenFAX"
        Me.layoutViewField_colAvisierungvonZahlungenFAX.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colAvisierungvonZahlungenFAX.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn73
        '
        Me.LayoutViewColumn73.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn73.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn73.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn73.FieldName = "Avisierung von Zahlungen EMAIL"
        Me.LayoutViewColumn73.LayoutViewField = Me.layoutViewField_colAvisierungvonZahlungenEMAIL
        Me.LayoutViewColumn73.Name = "LayoutViewColumn73"
        Me.LayoutViewColumn73.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn73.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn73.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colAvisierungvonZahlungenEMAIL
        '
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.EditorPreferredWidth = 561
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.Name = "layoutViewField_colAvisierungvonZahlungenEMAIL"
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn74
        '
        Me.LayoutViewColumn74.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn74.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn74.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn74.FieldName = "Überweisungs-nachfragen TEL"
        Me.LayoutViewColumn74.LayoutViewField = Me.LayoutViewField54
        Me.LayoutViewColumn74.Name = "LayoutViewColumn74"
        Me.LayoutViewColumn74.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn74.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn74.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField54
        '
        Me.LayoutViewField54.EditorPreferredWidth = 357
        Me.LayoutViewField54.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField54.Name = "LayoutViewField54"
        Me.LayoutViewField54.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField54.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn75
        '
        Me.LayoutViewColumn75.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn75.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn75.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn75.FieldName = "Überweisungs-nachfragen FAX"
        Me.LayoutViewColumn75.LayoutViewField = Me.LayoutViewField55
        Me.LayoutViewColumn75.Name = "LayoutViewColumn75"
        Me.LayoutViewColumn75.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn75.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn75.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField55
        '
        Me.LayoutViewField55.EditorPreferredWidth = 357
        Me.LayoutViewField55.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField55.Name = "LayoutViewField55"
        Me.LayoutViewField55.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField55.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn76
        '
        Me.LayoutViewColumn76.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn76.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn76.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn76.FieldName = "Überweisungsnachfragen EMAIL"
        Me.LayoutViewColumn76.LayoutViewField = Me.layoutViewField_colÜberweisungsnachfragenEMAIL
        Me.LayoutViewColumn76.Name = "LayoutViewColumn76"
        Me.LayoutViewColumn76.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn76.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn76.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colÜberweisungsnachfragenEMAIL
        '
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.EditorPreferredWidth = 357
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.Name = "layoutViewField_colÜberweisungsnachfragenEMAIL"
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.Size = New System.Drawing.Size(525, 20)
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn77
        '
        Me.LayoutViewColumn77.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn77.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn77.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn77.FieldName = "Überweisungs-rückruf TEL"
        Me.LayoutViewColumn77.LayoutViewField = Me.LayoutViewField56
        Me.LayoutViewColumn77.Name = "LayoutViewColumn77"
        Me.LayoutViewColumn77.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn77.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn77.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField56
        '
        Me.LayoutViewField56.EditorPreferredWidth = 591
        Me.LayoutViewField56.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField56.Name = "LayoutViewField56"
        Me.LayoutViewField56.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField56.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutViewColumn78
        '
        Me.LayoutViewColumn78.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn78.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn78.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn78.FieldName = "Überweisungs-rückruf FAX"
        Me.LayoutViewColumn78.LayoutViewField = Me.LayoutViewField57
        Me.LayoutViewColumn78.Name = "LayoutViewColumn78"
        Me.LayoutViewColumn78.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn78.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn78.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField57
        '
        Me.LayoutViewField57.EditorPreferredWidth = 591
        Me.LayoutViewField57.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField57.Name = "LayoutViewField57"
        Me.LayoutViewField57.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField57.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutViewColumn79
        '
        Me.LayoutViewColumn79.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn79.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn79.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn79.FieldName = "Überweisungs-rückfragen TEL"
        Me.LayoutViewColumn79.LayoutViewField = Me.LayoutViewField58
        Me.LayoutViewColumn79.Name = "LayoutViewColumn79"
        Me.LayoutViewColumn79.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn79.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn79.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField58
        '
        Me.LayoutViewField58.EditorPreferredWidth = 566
        Me.LayoutViewField58.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField58.Name = "LayoutViewField58"
        Me.LayoutViewField58.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField58.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn80
        '
        Me.LayoutViewColumn80.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn80.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn80.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn80.FieldName = "Überweisungs-rückfragen FAX"
        Me.LayoutViewColumn80.LayoutViewField = Me.LayoutViewField59
        Me.LayoutViewColumn80.Name = "LayoutViewColumn80"
        Me.LayoutViewColumn80.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn80.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn80.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField59
        '
        Me.LayoutViewField59.EditorPreferredWidth = 566
        Me.LayoutViewField59.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField59.Name = "LayoutViewField59"
        Me.LayoutViewField59.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField59.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn81
        '
        Me.LayoutViewColumn81.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn81.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn81.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn81.FieldName = "Überweisungsrückfragen EMAIL"
        Me.LayoutViewColumn81.LayoutViewField = Me.layoutViewField_colÜberweisungsrückfragenEMAIL
        Me.LayoutViewColumn81.Name = "LayoutViewColumn81"
        Me.LayoutViewColumn81.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn81.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn81.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colÜberweisungsrückfragenEMAIL
        '
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.EditorPreferredWidth = 566
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.Name = "layoutViewField_colÜberweisungsrückfragenEMAIL"
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn82
        '
        Me.LayoutViewColumn82.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn82.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn82.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn82.FieldName = "Scheckanfrage TEL"
        Me.LayoutViewColumn82.LayoutViewField = Me.layoutViewField_colScheckanfrageTEL
        Me.LayoutViewColumn82.Name = "LayoutViewColumn82"
        Me.LayoutViewColumn82.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn82.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn82.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colScheckanfrageTEL
        '
        Me.layoutViewField_colScheckanfrageTEL.EditorPreferredWidth = 614
        Me.layoutViewField_colScheckanfrageTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colScheckanfrageTEL.Name = "layoutViewField_colScheckanfrageTEL"
        Me.layoutViewField_colScheckanfrageTEL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colScheckanfrageTEL.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn83
        '
        Me.LayoutViewColumn83.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn83.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn83.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn83.FieldName = "Scheckanfrage FAX"
        Me.LayoutViewColumn83.LayoutViewField = Me.layoutViewField_colScheckanfrageFAX
        Me.LayoutViewColumn83.Name = "LayoutViewColumn83"
        Me.LayoutViewColumn83.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn83.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn83.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colScheckanfrageFAX
        '
        Me.layoutViewField_colScheckanfrageFAX.EditorPreferredWidth = 614
        Me.layoutViewField_colScheckanfrageFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colScheckanfrageFAX.Name = "layoutViewField_colScheckanfrageFAX"
        Me.layoutViewField_colScheckanfrageFAX.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colScheckanfrageFAX.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn84
        '
        Me.LayoutViewColumn84.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn84.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn84.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn84.FieldName = "Scheckanfrage EMAIL"
        Me.LayoutViewColumn84.LayoutViewField = Me.layoutViewField_colScheckanfrageEMAIL
        Me.LayoutViewColumn84.Name = "LayoutViewColumn84"
        Me.LayoutViewColumn84.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn84.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn84.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colScheckanfrageEMAIL
        '
        Me.layoutViewField_colScheckanfrageEMAIL.EditorPreferredWidth = 614
        Me.layoutViewField_colScheckanfrageEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colScheckanfrageEMAIL.Name = "layoutViewField_colScheckanfrageEMAIL"
        Me.layoutViewField_colScheckanfrageEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colScheckanfrageEMAIL.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn85
        '
        Me.LayoutViewColumn85.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn85.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn85.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn85.FieldName = "Unbezahlte Schecks/ Lastschriften TEL"
        Me.LayoutViewColumn85.LayoutViewField = Me.LayoutViewField60
        Me.LayoutViewColumn85.Name = "LayoutViewColumn85"
        Me.LayoutViewColumn85.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn85.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn85.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField60
        '
        Me.LayoutViewField60.EditorPreferredWidth = 521
        Me.LayoutViewField60.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField60.Name = "LayoutViewField60"
        Me.LayoutViewField60.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField60.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn86
        '
        Me.LayoutViewColumn86.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn86.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn86.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn86.FieldName = "Unbezahlte Schecks/ Lastschriften FAX"
        Me.LayoutViewColumn86.LayoutViewField = Me.LayoutViewField61
        Me.LayoutViewColumn86.Name = "LayoutViewColumn86"
        Me.LayoutViewColumn86.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn86.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn86.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField61
        '
        Me.LayoutViewField61.EditorPreferredWidth = 521
        Me.LayoutViewField61.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField61.Name = "LayoutViewField61"
        Me.LayoutViewField61.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField61.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn87
        '
        Me.LayoutViewColumn87.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn87.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn87.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn87.FieldName = "Unbezahlte Schecks/ Lastschriften EMAIL"
        Me.LayoutViewColumn87.LayoutViewField = Me.LayoutViewField62
        Me.LayoutViewColumn87.Name = "LayoutViewColumn87"
        Me.LayoutViewColumn87.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn87.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn87.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField62
        '
        Me.LayoutViewField62.EditorPreferredWidth = 521
        Me.LayoutViewField62.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField62.Name = "LayoutViewField62"
        Me.LayoutViewField62.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField62.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn88
        '
        Me.LayoutViewColumn88.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn88.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn88.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn88.FieldName = "Lastschrift-rückruf TEL"
        Me.LayoutViewColumn88.LayoutViewField = Me.LayoutViewField63
        Me.LayoutViewColumn88.Name = "LayoutViewColumn88"
        Me.LayoutViewColumn88.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn88.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn88.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField63
        '
        Me.LayoutViewField63.EditorPreferredWidth = 601
        Me.LayoutViewField63.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField63.Name = "LayoutViewField63"
        Me.LayoutViewField63.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField63.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn89
        '
        Me.LayoutViewColumn89.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn89.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn89.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn89.FieldName = "Lastschrift-rückruf FAX"
        Me.LayoutViewColumn89.LayoutViewField = Me.LayoutViewField64
        Me.LayoutViewColumn89.Name = "LayoutViewColumn89"
        Me.LayoutViewColumn89.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn89.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn89.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField64
        '
        Me.LayoutViewField64.EditorPreferredWidth = 601
        Me.LayoutViewField64.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField64.Name = "LayoutViewField64"
        Me.LayoutViewField64.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField64.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn90
        '
        Me.LayoutViewColumn90.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn90.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn90.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn90.FieldName = "Lastschriftrückruf EMAIL"
        Me.LayoutViewColumn90.LayoutViewField = Me.layoutViewField_colLastschriftrückrufEMAIL
        Me.LayoutViewColumn90.Name = "LayoutViewColumn90"
        Me.LayoutViewColumn90.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn90.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn90.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colLastschriftrückrufEMAIL
        '
        Me.layoutViewField_colLastschriftrückrufEMAIL.EditorPreferredWidth = 601
        Me.layoutViewField_colLastschriftrückrufEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colLastschriftrückrufEMAIL.Name = "layoutViewField_colLastschriftrückrufEMAIL"
        Me.layoutViewField_colLastschriftrückrufEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colLastschriftrückrufEMAIL.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn91
        '
        Me.LayoutViewColumn91.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn91.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn91.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn91.FieldName = "Wechselrückrufe TEL"
        Me.LayoutViewColumn91.LayoutViewField = Me.layoutViewField_colWechselrückrufeTEL
        Me.LayoutViewColumn91.Name = "LayoutViewColumn91"
        Me.LayoutViewColumn91.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn91.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn91.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colWechselrückrufeTEL
        '
        Me.layoutViewField_colWechselrückrufeTEL.EditorPreferredWidth = 581
        Me.layoutViewField_colWechselrückrufeTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colWechselrückrufeTEL.Name = "layoutViewField_colWechselrückrufeTEL"
        Me.layoutViewField_colWechselrückrufeTEL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colWechselrückrufeTEL.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn92
        '
        Me.LayoutViewColumn92.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn92.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn92.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn92.FieldName = "Wechselrückrufe FAX"
        Me.LayoutViewColumn92.LayoutViewField = Me.layoutViewField_colWechselrückrufeFAX
        Me.LayoutViewColumn92.Name = "LayoutViewColumn92"
        Me.LayoutViewColumn92.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn92.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn92.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colWechselrückrufeFAX
        '
        Me.layoutViewField_colWechselrückrufeFAX.EditorPreferredWidth = 581
        Me.layoutViewField_colWechselrückrufeFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colWechselrückrufeFAX.Name = "layoutViewField_colWechselrückrufeFAX"
        Me.layoutViewField_colWechselrückrufeFAX.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colWechselrückrufeFAX.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn93
        '
        Me.LayoutViewColumn93.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn93.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn93.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn93.FieldName = "Wechselrückrufe EMAIL"
        Me.LayoutViewColumn93.LayoutViewField = Me.layoutViewField_colWechselrückrufeEMAIL
        Me.LayoutViewColumn93.Name = "LayoutViewColumn93"
        Me.LayoutViewColumn93.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn93.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn93.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colWechselrückrufeEMAIL
        '
        Me.layoutViewField_colWechselrückrufeEMAIL.EditorPreferredWidth = 581
        Me.layoutViewField_colWechselrückrufeEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colWechselrückrufeEMAIL.Name = "layoutViewField_colWechselrückrufeEMAIL"
        Me.layoutViewField_colWechselrückrufeEMAIL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colWechselrückrufeEMAIL.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn94
        '
        Me.LayoutViewColumn94.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn94.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn94.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn94.FieldName = "Unbezahlte Wechsel TEL"
        Me.LayoutViewColumn94.LayoutViewField = Me.layoutViewField_colUnbezahlteWechselTEL
        Me.LayoutViewColumn94.Name = "LayoutViewColumn94"
        Me.LayoutViewColumn94.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn94.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn94.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUnbezahlteWechselTEL
        '
        Me.layoutViewField_colUnbezahlteWechselTEL.EditorPreferredWidth = 564
        Me.layoutViewField_colUnbezahlteWechselTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUnbezahlteWechselTEL.Name = "layoutViewField_colUnbezahlteWechselTEL"
        Me.layoutViewField_colUnbezahlteWechselTEL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colUnbezahlteWechselTEL.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn95
        '
        Me.LayoutViewColumn95.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn95.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn95.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn95.FieldName = "Unbezahlte Wechsel FAX"
        Me.LayoutViewColumn95.LayoutViewField = Me.layoutViewField_colUnbezahlteWechselFAX
        Me.LayoutViewColumn95.Name = "LayoutViewColumn95"
        Me.LayoutViewColumn95.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn95.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn95.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUnbezahlteWechselFAX
        '
        Me.layoutViewField_colUnbezahlteWechselFAX.EditorPreferredWidth = 564
        Me.layoutViewField_colUnbezahlteWechselFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colUnbezahlteWechselFAX.Name = "layoutViewField_colUnbezahlteWechselFAX"
        Me.layoutViewField_colUnbezahlteWechselFAX.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colUnbezahlteWechselFAX.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn96
        '
        Me.LayoutViewColumn96.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn96.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn96.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn96.FieldName = "Unbezahlte Wechsel EMAIL"
        Me.LayoutViewColumn96.LayoutViewField = Me.layoutViewField_colUnbezahlteWechselEMAIL
        Me.LayoutViewColumn96.Name = "LayoutViewColumn96"
        Me.LayoutViewColumn96.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn96.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn96.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUnbezahlteWechselEMAIL
        '
        Me.layoutViewField_colUnbezahlteWechselEMAIL.EditorPreferredWidth = 564
        Me.layoutViewField_colUnbezahlteWechselEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colUnbezahlteWechselEMAIL.Name = "layoutViewField_colUnbezahlteWechselEMAIL"
        Me.layoutViewField_colUnbezahlteWechselEMAIL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colUnbezahlteWechselEMAIL.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn97
        '
        Me.LayoutViewColumn97.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn97.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn97.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn97.FieldName = "Vorgeschaltete Stelle TEL"
        Me.LayoutViewColumn97.LayoutViewField = Me.layoutViewField_colVorgeschalteteStelleTEL
        Me.LayoutViewColumn97.Name = "LayoutViewColumn97"
        Me.LayoutViewColumn97.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn97.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn97.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colVorgeschalteteStelleTEL
        '
        Me.layoutViewField_colVorgeschalteteStelleTEL.EditorPreferredWidth = 584
        Me.layoutViewField_colVorgeschalteteStelleTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colVorgeschalteteStelleTEL.Name = "layoutViewField_colVorgeschalteteStelleTEL"
        Me.layoutViewField_colVorgeschalteteStelleTEL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colVorgeschalteteStelleTEL.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn98
        '
        Me.LayoutViewColumn98.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn98.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn98.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn98.FieldName = "Vorgeschaltete Stelle FAX"
        Me.LayoutViewColumn98.LayoutViewField = Me.layoutViewField_colVorgeschalteteStelleFAX
        Me.LayoutViewColumn98.Name = "LayoutViewColumn98"
        Me.LayoutViewColumn98.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn98.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn98.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colVorgeschalteteStelleFAX
        '
        Me.layoutViewField_colVorgeschalteteStelleFAX.EditorPreferredWidth = 584
        Me.layoutViewField_colVorgeschalteteStelleFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colVorgeschalteteStelleFAX.Name = "layoutViewField_colVorgeschalteteStelleFAX"
        Me.layoutViewField_colVorgeschalteteStelleFAX.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colVorgeschalteteStelleFAX.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn99
        '
        Me.LayoutViewColumn99.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn99.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn99.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn99.FieldName = "Vorgeschaltete Stelle EMAIL"
        Me.LayoutViewColumn99.LayoutViewField = Me.layoutViewField_colVorgeschalteteStelleEMAIL
        Me.LayoutViewColumn99.Name = "LayoutViewColumn99"
        Me.LayoutViewColumn99.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn99.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn99.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colVorgeschalteteStelleEMAIL
        '
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.EditorPreferredWidth = 584
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.Name = "layoutViewField_colVorgeschalteteStelleEMAIL"
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn100
        '
        Me.LayoutViewColumn100.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn100.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn100.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn100.FieldName = "Meldeweg"
        Me.LayoutViewColumn100.LayoutViewField = Me.layoutViewField_colMeldeweg
        Me.LayoutViewColumn100.Name = "LayoutViewColumn100"
        Me.LayoutViewColumn100.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn100.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn100.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colMeldeweg
        '
        Me.layoutViewField_colMeldeweg.EditorPreferredWidth = 321
        Me.layoutViewField_colMeldeweg.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colMeldeweg.Name = "layoutViewField_colMeldeweg"
        Me.layoutViewField_colMeldeweg.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colMeldeweg.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn101
        '
        Me.LayoutViewColumn101.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn101.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn101.ColumnEdit = Me.AnzahlWertRepositoryItemComboBox
        Me.LayoutViewColumn101.FieldName = "VALID"
        Me.LayoutViewColumn101.LayoutViewField = Me.LayoutViewField65
        Me.LayoutViewColumn101.Name = "LayoutViewColumn101"
        Me.LayoutViewColumn101.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn101.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn101.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField65
        '
        Me.LayoutViewField65.EditorPreferredWidth = 48
        Me.LayoutViewField65.Location = New System.Drawing.Point(0, 220)
        Me.LayoutViewField65.Name = "LayoutViewField65"
        Me.LayoutViewField65.Size = New System.Drawing.Size(250, 20)
        Me.LayoutViewField65.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn102
        '
        Me.LayoutViewColumn102.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn102.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn102.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn102.FieldName = "USER"
        Me.LayoutViewColumn102.LayoutViewField = Me.layoutViewField_colUSER
        Me.LayoutViewColumn102.Name = "LayoutViewColumn102"
        Me.LayoutViewColumn102.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn102.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn102.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUSER
        '
        Me.layoutViewField_colUSER.EditorPreferredWidth = 20
        Me.layoutViewField_colUSER.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUSER.Name = "layoutViewField_colUSER"
        Me.layoutViewField_colUSER.Size = New System.Drawing.Size(547, 612)
        Me.layoutViewField_colUSER.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn103
        '
        Me.LayoutViewColumn103.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn103.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn103.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn103.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn103.LayoutViewField = Me.layoutViewField_colUNTERBEARBEITUNGVON
        Me.LayoutViewColumn103.Name = "LayoutViewColumn103"
        Me.LayoutViewColumn103.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn103.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn103.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUNTERBEARBEITUNGVON
        '
        Me.layoutViewField_colUNTERBEARBEITUNGVON.EditorPreferredWidth = 20
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Name = "layoutViewField_colUNTERBEARBEITUNGVON"
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Size = New System.Drawing.Size(547, 612)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextVisible = False
        '
        'LayoutViewCard2
        '
        Me.LayoutViewCard2.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard2.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID})
        Me.LayoutViewCard2.Name = "LayoutViewCard2"
        Me.LayoutViewCard2.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard2.Text = "TemplateCard"
        '
        'LayoutView3
        '
        Me.LayoutView3.GridControl = Me.GridControl2
        Me.LayoutView3.Name = "LayoutView3"
        Me.LayoutView3.TemplateCard = Nothing
        '
        'LayoutView2
        '
        Me.LayoutView2.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn26, Me.LayoutViewColumn27, Me.LayoutViewColumn28, Me.LayoutViewColumn29, Me.LayoutViewColumn30, Me.LayoutViewColumn31, Me.LayoutViewColumn32, Me.LayoutViewColumn33, Me.LayoutViewColumn34, Me.LayoutViewColumn35, Me.LayoutViewColumn36, Me.LayoutViewColumn37, Me.LayoutViewColumn38, Me.LayoutViewColumn39, Me.LayoutViewColumn40, Me.LayoutViewColumn41, Me.LayoutViewColumn42, Me.LayoutViewColumn43, Me.LayoutViewColumn44, Me.LayoutViewColumn45, Me.LayoutViewColumn46, Me.LayoutViewColumn47, Me.LayoutViewColumn48, Me.LayoutViewColumn49, Me.LayoutViewColumn50})
        Me.LayoutView2.GridControl = Me.GridControl2
        Me.LayoutView2.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField22, Me.LayoutViewField21, Me.LayoutViewField19})
        Me.LayoutView2.Name = "LayoutView2"
        Me.LayoutView2.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView2.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView2.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView2.OptionsCustomization.AllowFilter = False
        Me.LayoutView2.OptionsCustomization.AllowSort = False
        Me.LayoutView2.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView2.OptionsCustomization.ShowGroupView = False
        Me.LayoutView2.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView2.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView2.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView2.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView2.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView2.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView2.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView2.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView2.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView2.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn26, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView2.TemplateCard = Nothing
        '
        'LayoutViewColumn26
        '
        Me.LayoutViewColumn26.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn26.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn26.FieldName = "Idnr"
        Me.LayoutViewColumn26.LayoutViewField = Me.LayoutViewField1
        Me.LayoutViewColumn26.Name = "LayoutViewColumn26"
        Me.LayoutViewColumn26.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField1
        '
        Me.LayoutViewField1.EditorPreferredWidth = 61
        Me.LayoutViewField1.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField1.Name = "LayoutViewField1"
        Me.LayoutViewField1.Size = New System.Drawing.Size(178, 20)
        Me.LayoutViewField1.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn27
        '
        Me.LayoutViewColumn27.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn27.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn27.FieldName = "TAG"
        Me.LayoutViewColumn27.LayoutViewField = Me.LayoutViewField2
        Me.LayoutViewColumn27.Name = "LayoutViewColumn27"
        '
        'LayoutViewField2
        '
        Me.LayoutViewField2.EditorPreferredWidth = 318
        Me.LayoutViewField2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField2.Name = "LayoutViewField2"
        Me.LayoutViewField2.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField2.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn28
        '
        Me.LayoutViewColumn28.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn28.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn28.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn28.LayoutViewField = Me.LayoutViewField3
        Me.LayoutViewColumn28.Name = "LayoutViewColumn28"
        '
        'LayoutViewField3
        '
        Me.LayoutViewField3.EditorPreferredWidth = 318
        Me.LayoutViewField3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField3.Name = "LayoutViewField3"
        Me.LayoutViewField3.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField3.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn29
        '
        Me.LayoutViewColumn29.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn29.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn29.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn29.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn29.LayoutViewField = Me.LayoutViewField4
        Me.LayoutViewColumn29.Name = "LayoutViewColumn29"
        '
        'LayoutViewField4
        '
        Me.LayoutViewField4.EditorPreferredWidth = 306
        Me.LayoutViewField4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField4.Name = "LayoutViewField4"
        Me.LayoutViewField4.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField4.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn30
        '
        Me.LayoutViewColumn30.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn30.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn30.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn30.LayoutViewField = Me.LayoutViewField5
        Me.LayoutViewColumn30.Name = "LayoutViewColumn30"
        '
        'LayoutViewField5
        '
        Me.LayoutViewField5.EditorPreferredWidth = 306
        Me.LayoutViewField5.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField5.Name = "LayoutViewField5"
        Me.LayoutViewField5.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField5.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn31
        '
        Me.LayoutViewColumn31.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn31.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn31.FieldName = "CITY HEADING"
        Me.LayoutViewColumn31.LayoutViewField = Me.LayoutViewField6
        Me.LayoutViewColumn31.Name = "LayoutViewColumn31"
        '
        'LayoutViewField6
        '
        Me.LayoutViewField6.EditorPreferredWidth = 306
        Me.LayoutViewField6.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField6.Name = "LayoutViewField6"
        Me.LayoutViewField6.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField6.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn32
        '
        Me.LayoutViewColumn32.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn32.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn32.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn32.LayoutViewField = Me.LayoutViewField7
        Me.LayoutViewColumn32.Name = "LayoutViewColumn32"
        '
        'LayoutViewField7
        '
        Me.LayoutViewField7.EditorPreferredWidth = 306
        Me.LayoutViewField7.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField7.Name = "LayoutViewField7"
        Me.LayoutViewField7.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField7.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn33
        '
        Me.LayoutViewColumn33.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn33.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn33.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn33.LayoutViewField = Me.LayoutViewField8
        Me.LayoutViewColumn33.Name = "LayoutViewColumn33"
        '
        'LayoutViewField8
        '
        Me.LayoutViewField8.EditorPreferredWidth = 303
        Me.LayoutViewField8.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField8.Name = "LayoutViewField8"
        Me.LayoutViewField8.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField8.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn34
        '
        Me.LayoutViewColumn34.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn34.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn34.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn34.LayoutViewField = Me.LayoutViewField9
        Me.LayoutViewColumn34.Name = "LayoutViewColumn34"
        '
        'LayoutViewField9
        '
        Me.LayoutViewField9.EditorPreferredWidth = 318
        Me.LayoutViewField9.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField9.Name = "LayoutViewField9"
        Me.LayoutViewField9.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField9.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn35
        '
        Me.LayoutViewColumn35.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn35.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn35.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn35.LayoutViewField = Me.LayoutViewField10
        Me.LayoutViewColumn35.Name = "LayoutViewColumn35"
        '
        'LayoutViewField10
        '
        Me.LayoutViewField10.EditorPreferredWidth = 316
        Me.LayoutViewField10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField10.Name = "LayoutViewField10"
        Me.LayoutViewField10.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField10.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn36
        '
        Me.LayoutViewColumn36.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn36.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn36.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn36.LayoutViewField = Me.LayoutViewField11
        Me.LayoutViewColumn36.Name = "LayoutViewColumn36"
        '
        'LayoutViewField11
        '
        Me.LayoutViewField11.EditorPreferredWidth = 316
        Me.LayoutViewField11.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField11.Name = "LayoutViewField11"
        Me.LayoutViewField11.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField11.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn37
        '
        Me.LayoutViewColumn37.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn37.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn37.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn37.LayoutViewField = Me.LayoutViewField12
        Me.LayoutViewColumn37.Name = "LayoutViewColumn37"
        '
        'LayoutViewField12
        '
        Me.LayoutViewField12.EditorPreferredWidth = 316
        Me.LayoutViewField12.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField12.Name = "LayoutViewField12"
        Me.LayoutViewField12.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField12.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn38
        '
        Me.LayoutViewColumn38.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn38.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn38.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn38.LayoutViewField = Me.LayoutViewField13
        Me.LayoutViewColumn38.Name = "LayoutViewColumn38"
        '
        'LayoutViewField13
        '
        Me.LayoutViewField13.EditorPreferredWidth = 316
        Me.LayoutViewField13.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField13.Name = "LayoutViewField13"
        Me.LayoutViewField13.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField13.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn39
        '
        Me.LayoutViewColumn39.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn39.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn39.FieldName = "LOCATION"
        Me.LayoutViewColumn39.LayoutViewField = Me.LayoutViewField14
        Me.LayoutViewColumn39.Name = "LayoutViewColumn39"
        '
        'LayoutViewField14
        '
        Me.LayoutViewField14.EditorPreferredWidth = 316
        Me.LayoutViewField14.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField14.Name = "LayoutViewField14"
        Me.LayoutViewField14.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField14.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn40
        '
        Me.LayoutViewColumn40.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn40.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn40.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn40.LayoutViewField = Me.LayoutViewField15
        Me.LayoutViewColumn40.Name = "LayoutViewColumn40"
        '
        'LayoutViewField15
        '
        Me.LayoutViewField15.EditorPreferredWidth = 316
        Me.LayoutViewField15.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField15.Name = "LayoutViewField15"
        Me.LayoutViewField15.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField15.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn41
        '
        Me.LayoutViewColumn41.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn41.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn41.FieldName = "POB NUMBER"
        Me.LayoutViewColumn41.LayoutViewField = Me.LayoutViewField16
        Me.LayoutViewColumn41.Name = "LayoutViewColumn41"
        '
        'LayoutViewField16
        '
        Me.LayoutViewField16.EditorPreferredWidth = 316
        Me.LayoutViewField16.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField16.Name = "LayoutViewField16"
        Me.LayoutViewField16.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField16.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn42
        '
        Me.LayoutViewColumn42.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn42.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn42.FieldName = "POB LOCATION"
        Me.LayoutViewColumn42.LayoutViewField = Me.LayoutViewField17
        Me.LayoutViewColumn42.Name = "LayoutViewColumn42"
        '
        'LayoutViewField17
        '
        Me.LayoutViewField17.EditorPreferredWidth = 316
        Me.LayoutViewField17.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField17.Name = "LayoutViewField17"
        Me.LayoutViewField17.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField17.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn43
        '
        Me.LayoutViewColumn43.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn43.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn43.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn43.LayoutViewField = Me.LayoutViewField18
        Me.LayoutViewColumn43.Name = "LayoutViewColumn43"
        '
        'LayoutViewField18
        '
        Me.LayoutViewField18.EditorPreferredWidth = 316
        Me.LayoutViewField18.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField18.Name = "LayoutViewField18"
        Me.LayoutViewField18.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField18.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn44
        '
        Me.LayoutViewColumn44.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn44.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn44.FieldName = "USER"
        Me.LayoutViewColumn44.LayoutViewField = Me.LayoutViewField19
        Me.LayoutViewColumn44.Name = "LayoutViewColumn44"
        Me.LayoutViewColumn44.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField19
        '
        Me.LayoutViewField19.EditorPreferredWidth = 20
        Me.LayoutViewField19.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField19.Name = "LayoutViewField19"
        Me.LayoutViewField19.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField19.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn45
        '
        Me.LayoutViewColumn45.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn45.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn45.ColumnEdit = Me.AnzahlWertRepositoryItemComboBox
        Me.LayoutViewColumn45.FieldName = "VALID"
        Me.LayoutViewColumn45.LayoutViewField = Me.LayoutViewField20
        Me.LayoutViewColumn45.Name = "LayoutViewColumn45"
        '
        'LayoutViewField20
        '
        Me.LayoutViewField20.EditorPreferredWidth = 70
        Me.LayoutViewField20.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField20.Name = "LayoutViewField20"
        Me.LayoutViewField20.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField20.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn46
        '
        Me.LayoutViewColumn46.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn46.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn46.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn46.LayoutViewField = Me.LayoutViewField21
        Me.LayoutViewColumn46.Name = "LayoutViewColumn46"
        Me.LayoutViewColumn46.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField21
        '
        Me.LayoutViewField21.EditorPreferredWidth = 20
        Me.LayoutViewField21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField21.Name = "LayoutViewField21"
        Me.LayoutViewField21.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField21.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn47
        '
        Me.LayoutViewColumn47.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn47.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn47.FieldName = "BIC11"
        Me.LayoutViewColumn47.LayoutViewField = Me.LayoutViewField22
        Me.LayoutViewColumn47.Name = "LayoutViewColumn47"
        Me.LayoutViewColumn47.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField22
        '
        Me.LayoutViewField22.EditorPreferredWidth = 20
        Me.LayoutViewField22.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField22.Name = "LayoutViewField22"
        Me.LayoutViewField22.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField22.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn48
        '
        Me.LayoutViewColumn48.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn48.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn48.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn48.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn48.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn48.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn48.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn48.FieldName = "BIC CODE"
        Me.LayoutViewColumn48.LayoutViewField = Me.LayoutViewField23
        Me.LayoutViewColumn48.Name = "LayoutViewColumn48"
        '
        'LayoutViewField23
        '
        Me.LayoutViewField23.EditorPreferredWidth = 70
        Me.LayoutViewField23.ImageOptions.ImageIndex = 0
        Me.LayoutViewField23.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField23.Name = "LayoutViewField23"
        Me.LayoutViewField23.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField23.TextSize = New System.Drawing.Size(123, 16)
        '
        'LayoutViewColumn49
        '
        Me.LayoutViewColumn49.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn49.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn49.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn49.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn49.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn49.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn49.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn49.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn49.LayoutViewField = Me.LayoutViewField24
        Me.LayoutViewColumn49.Name = "LayoutViewColumn49"
        '
        'LayoutViewField24
        '
        Me.LayoutViewField24.EditorPreferredWidth = 70
        Me.LayoutViewField24.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField24.Name = "LayoutViewField24"
        Me.LayoutViewField24.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField24.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn50
        '
        Me.LayoutViewColumn50.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn50.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn50.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn50.FieldName = "COUNTRY"
        Me.LayoutViewColumn50.LayoutViewField = Me.LayoutViewField25
        Me.LayoutViewColumn50.Name = "LayoutViewColumn50"
        Me.LayoutViewColumn50.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField25
        '
        Me.LayoutViewField25.EditorPreferredWidth = 316
        Me.LayoutViewField25.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField25.Name = "LayoutViewField25"
        Me.LayoutViewField25.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField25.TextSize = New System.Drawing.Size(110, 13)
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'Classification_ComboBoxEdit
        '
        Me.Classification_ComboBoxEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Classification_ComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "Classification", True))
        Me.Classification_ComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "Classification", True))
        Me.Classification_ComboBoxEdit.Location = New System.Drawing.Point(319, 47)
        Me.Classification_ComboBoxEdit.Name = "Classification_ComboBoxEdit"
        Me.Classification_ComboBoxEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Classification_ComboBoxEdit.Properties.Appearance.Options.UseFont = True
        Me.Classification_ComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Classification_ComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Classification_ComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Classification_ComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Classification_ComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Classification_ComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Classification_ComboBoxEdit.Properties.Items.AddRange(New Object() {"INTERNAL", "EXTERNAL"})
        Me.Classification_ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.Classification_ComboBoxEdit.Size = New System.Drawing.Size(130, 22)
        Me.Classification_ComboBoxEdit.TabIndex = 7
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Mandatory Field"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        ConditionValidationRule1.Values.Add("INTERNAL")
        ConditionValidationRule1.Values.Add("EXTERNAL")
        Me.DxValidationProvider1.SetValidationRule(Me.Classification_ComboBoxEdit, ConditionValidationRule1)
        '
        'EventDateEdit
        '
        Me.EventDateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.EventDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "EventDate", True))
        Me.EventDateEdit.EditValue = Nothing
        Me.EventDateEdit.Location = New System.Drawing.Point(319, 181)
        Me.EventDateEdit.Name = "EventDateEdit"
        Me.EventDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.EventDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.EventDateEdit.Properties.Appearance.Options.UseFont = True
        Me.EventDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.EventDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.EventDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.EventDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.EventDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.EventDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.EventDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.EventDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.EventDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.EventDateEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.EventDateEdit.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White
        Me.EventDateEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Navy
        Me.EventDateEdit.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.EventDateEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.EventDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EventDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.EventDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.EventDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.EventDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.EventDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.EventDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.EventDateEdit.Size = New System.Drawing.Size(107, 22)
        Me.EventDateEdit.TabIndex = 23
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Mandatory Field"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.EventDateEdit, ConditionValidationRule2)
        '
        'DeclarationDateEdit
        '
        Me.DeclarationDateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DeclarationDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "DeclarationDate", True))
        Me.DeclarationDateEdit.EditValue = Nothing
        Me.DeclarationDateEdit.Location = New System.Drawing.Point(787, 182)
        Me.DeclarationDateEdit.Name = "DeclarationDateEdit"
        Me.DeclarationDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DeclarationDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DeclarationDateEdit.Properties.Appearance.Options.UseFont = True
        Me.DeclarationDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.DeclarationDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DeclarationDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DeclarationDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DeclarationDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DeclarationDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DeclarationDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DeclarationDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.DeclarationDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DeclarationDateEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.DeclarationDateEdit.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White
        Me.DeclarationDateEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Navy
        Me.DeclarationDateEdit.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.DeclarationDateEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.DeclarationDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DeclarationDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DeclarationDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DeclarationDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DeclarationDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.DeclarationDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DeclarationDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.DeclarationDateEdit.Size = New System.Drawing.Size(107, 22)
        Me.DeclarationDateEdit.TabIndex = 26
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule3.ErrorText = "Mandatory Field"
        ConditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.DeclarationDateEdit, ConditionValidationRule3)
        '
        'ExtendOfDamage_SpinEdit
        '
        Me.ExtendOfDamage_SpinEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ExtendOfDamage_SpinEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "ExtentOfDamage", True))
        Me.ExtendOfDamage_SpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ExtendOfDamage_SpinEdit.Location = New System.Drawing.Point(319, 309)
        Me.ExtendOfDamage_SpinEdit.Name = "ExtendOfDamage_SpinEdit"
        Me.ExtendOfDamage_SpinEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ExtendOfDamage_SpinEdit.Properties.Appearance.Options.UseFont = True
        Me.ExtendOfDamage_SpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ExtendOfDamage_SpinEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ExtendOfDamage_SpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ExtendOfDamage_SpinEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ExtendOfDamage_SpinEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ExtendOfDamage_SpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ExtendOfDamage_SpinEdit.Properties.DisplayFormat.FormatString = "c2"
        Me.ExtendOfDamage_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ExtendOfDamage_SpinEdit.Properties.EditFormat.FormatString = "n2"
        Me.ExtendOfDamage_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ExtendOfDamage_SpinEdit.Properties.Mask.EditMask = "c2"
        Me.ExtendOfDamage_SpinEdit.Size = New System.Drawing.Size(199, 22)
        Me.ExtendOfDamage_SpinEdit.TabIndex = 28
        ConditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule4.ErrorText = "Mandatory Field"
        ConditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.ExtendOfDamage_SpinEdit, ConditionValidationRule4)
        '
        'OpRisk_GridLookUpEdit
        '
        Me.OpRisk_GridLookUpEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OpRisk_GridLookUpEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "OpRiskLetter", True))
        Me.OpRisk_GridLookUpEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "OpRiskLetter", True))
        Me.OpRisk_GridLookUpEdit.EditValue = ""
        Me.OpRisk_GridLookUpEdit.Location = New System.Drawing.Point(713, 48)
        Me.OpRisk_GridLookUpEdit.Name = "OpRisk_GridLookUpEdit"
        Me.OpRisk_GridLookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.OpRisk_GridLookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.OpRisk_GridLookUpEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.OpRisk_GridLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OpRisk_GridLookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OpRisk_GridLookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OpRisk_GridLookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OpRisk_GridLookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OpRisk_GridLookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OpRisk_GridLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OpRisk_GridLookUpEdit.Properties.DataSource = Me.SCHADENSFALL_OPTIONSBindingSource
        Me.OpRisk_GridLookUpEdit.Properties.DisplayMember = "OpRiskLetter"
        Me.OpRisk_GridLookUpEdit.Properties.NullText = ""
        Me.OpRisk_GridLookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(1000, 800)
        Me.OpRisk_GridLookUpEdit.Properties.PopupView = Me.OpRiskOptions_GridView
        Me.OpRisk_GridLookUpEdit.Properties.ValueMember = "OpRiskLetter"
        Me.OpRisk_GridLookUpEdit.Size = New System.Drawing.Size(64, 22)
        Me.OpRisk_GridLookUpEdit.TabIndex = 8
        ConditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule5.ErrorText = "Mandatory Field"
        ConditionValidationRule5.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.OpRisk_GridLookUpEdit, ConditionValidationRule5)
        '
        'OpRiskOptions_GridView
        '
        Me.OpRiskOptions_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.OpRiskOptions_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.OpRiskOptions_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.OpRiskOptions_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.OpRiskOptions_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.OpRiskOptions_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.OpRiskOptions_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Yellow
        StyleFormatCondition4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.Column = Me.GridColumn6
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition4.Value1 = "Medium"
        StyleFormatCondition5.Appearance.BackColor = System.Drawing.Color.Green
        StyleFormatCondition5.Appearance.BackColor2 = System.Drawing.Color.Green
        StyleFormatCondition5.Appearance.ForeColor = System.Drawing.Color.White
        StyleFormatCondition5.Appearance.Options.UseBackColor = True
        StyleFormatCondition5.Appearance.Options.UseForeColor = True
        StyleFormatCondition5.Column = Me.GridColumn6
        StyleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition5.Value1 = "Low"
        StyleFormatCondition6.Appearance.BackColor = System.Drawing.Color.Red
        StyleFormatCondition6.Appearance.BackColor2 = System.Drawing.Color.Red
        StyleFormatCondition6.Appearance.ForeColor = System.Drawing.Color.White
        StyleFormatCondition6.Appearance.Options.UseBackColor = True
        StyleFormatCondition6.Appearance.Options.UseForeColor = True
        StyleFormatCondition6.Column = Me.GridColumn6
        StyleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition6.Value1 = "High"
        Me.OpRiskOptions_GridView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition4, StyleFormatCondition5, StyleFormatCondition6})
        Me.OpRiskOptions_GridView.Name = "OpRiskOptions_GridView"
        Me.OpRiskOptions_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OpRiskOptions_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OpRiskOptions_GridView.OptionsFind.AlwaysVisible = True
        Me.OpRiskOptions_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.OpRiskOptions_GridView.OptionsView.AllowCellMerge = True
        Me.OpRiskOptions_GridView.OptionsView.ColumnAutoWidth = False
        Me.OpRiskOptions_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.OpRiskOptions_GridView.OptionsView.ShowAutoFilterRow = True
        Me.OpRiskOptions_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.OpRiskOptions_GridView.OptionsView.ShowGroupPanel = False
        Me.OpRiskOptions_GridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.OpRiskOptions_GridView.ViewCaption = "OpRisk Options"
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "OpRisk Letter"
        Me.GridColumn2.FieldName = "OpRiskLetter"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 88
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "OpRisk Sub-Risk Level1"
        Me.GridColumn3.FieldName = "OpRiskLevel1"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 329
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Nr."
        Me.GridColumn4.FieldName = "OpRiskNr"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 41
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "OpRisk Sub-Risk Level 2"
        Me.GridColumn5.FieldName = "OpRiskLevel2"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 364
        '
        'DamageCompensations_ComboBoxEdit
        '
        Me.DamageCompensations_ComboBoxEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DamageCompensations_ComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "DamageCompensations", True))
        Me.DamageCompensations_ComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "DamageCompensations", True))
        Me.DamageCompensations_ComboBoxEdit.Location = New System.Drawing.Point(787, 309)
        Me.DamageCompensations_ComboBoxEdit.Name = "DamageCompensations_ComboBoxEdit"
        Me.DamageCompensations_ComboBoxEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DamageCompensations_ComboBoxEdit.Properties.Appearance.Options.UseFont = True
        Me.DamageCompensations_ComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DamageCompensations_ComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DamageCompensations_ComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DamageCompensations_ComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DamageCompensations_ComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DamageCompensations_ComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DamageCompensations_ComboBoxEdit.Properties.Items.AddRange(New Object() {"None", "Insurance", "Others"})
        Me.DamageCompensations_ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DamageCompensations_ComboBoxEdit.Size = New System.Drawing.Size(130, 22)
        Me.DamageCompensations_ComboBoxEdit.TabIndex = 30
        '
        'DamageCompensationAmount_SpinEdit
        '
        Me.DamageCompensationAmount_SpinEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DamageCompensationAmount_SpinEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "DamageCompensationsAmount", True))
        Me.DamageCompensationAmount_SpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.DamageCompensationAmount_SpinEdit.Location = New System.Drawing.Point(787, 337)
        Me.DamageCompensationAmount_SpinEdit.Name = "DamageCompensationAmount_SpinEdit"
        Me.DamageCompensationAmount_SpinEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DamageCompensationAmount_SpinEdit.Properties.Appearance.Options.UseFont = True
        Me.DamageCompensationAmount_SpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DamageCompensationAmount_SpinEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DamageCompensationAmount_SpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DamageCompensationAmount_SpinEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DamageCompensationAmount_SpinEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DamageCompensationAmount_SpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DamageCompensationAmount_SpinEdit.Properties.DisplayFormat.FormatString = "c2"
        Me.DamageCompensationAmount_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.DamageCompensationAmount_SpinEdit.Properties.EditFormat.FormatString = "n2"
        Me.DamageCompensationAmount_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.DamageCompensationAmount_SpinEdit.Properties.Mask.EditMask = "c2"
        Me.DamageCompensationAmount_SpinEdit.Size = New System.Drawing.Size(199, 22)
        Me.DamageCompensationAmount_SpinEdit.TabIndex = 32
        '
        'MeasuresMemoEdit
        '
        Me.MeasuresMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "Measures", True))
        Me.MeasuresMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "Measures", True))
        Me.MeasuresMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MeasuresMemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.MeasuresMemoEdit.Name = "MeasuresMemoEdit"
        Me.MeasuresMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeasuresMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.MeasuresMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MeasuresMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MeasuresMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MeasuresMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MeasuresMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.MeasuresMemoEdit, True)
        Me.MeasuresMemoEdit.Size = New System.Drawing.Size(1308, 579)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.MeasuresMemoEdit, OptionsSpelling1)
        Me.MeasuresMemoEdit.TabIndex = 2
        '
        'CaseDescription_MemoEdit
        '
        Me.CaseDescription_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "CaseDescription", True))
        Me.CaseDescription_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.SCHADENSFALLBindingSource, "CaseDescription", True))
        Me.CaseDescription_MemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaseDescription_MemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.CaseDescription_MemoEdit.Name = "CaseDescription_MemoEdit"
        Me.CaseDescription_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CaseDescription_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.CaseDescription_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CaseDescription_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CaseDescription_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CaseDescription_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CaseDescription_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.CaseDescription_MemoEdit, True)
        Me.CaseDescription_MemoEdit.Size = New System.Drawing.Size(1308, 579)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.CaseDescription_MemoEdit, OptionsSpelling2)
        Me.CaseDescription_MemoEdit.TabIndex = 1
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl2.Location = New System.Drawing.Point(47, 55)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.GENERALXtraTabPage
        Me.XtraTabControl2.Size = New System.Drawing.Size(1314, 607)
        Me.XtraTabControl2.TabIndex = 10
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.GENERALXtraTabPage, Me.CASEDESCRIPTIONXtraTabPage, Me.ATTACHMENTSXtraTabPage, Me.MEASURESXtraTabPage})
        '
        'GENERALXtraTabPage
        '
        Me.GENERALXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GENERALXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.GENERALXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.GENERALXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.GENERALXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.GENERALXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.GENERALXtraTabPage.Controls.Add(Label13)
        Me.GENERALXtraTabPage.Controls.Add(Label12)
        Me.GENERALXtraTabPage.Controls.Add(Label11)
        Me.GENERALXtraTabPage.Controls.Add(Label10)
        Me.GENERALXtraTabPage.Controls.Add(CaseIDLabel)
        Me.GENERALXtraTabPage.Controls.Add(Me.CaseID_lbl)
        Me.GENERALXtraTabPage.Controls.Add(Me.DamageCompensationAmount_SpinEdit)
        Me.GENERALXtraTabPage.Controls.Add(Label9)
        Me.GENERALXtraTabPage.Controls.Add(Me.DamageCompensations_ComboBoxEdit)
        Me.GENERALXtraTabPage.Controls.Add(Label8)
        Me.GENERALXtraTabPage.Controls.Add(Me.ExtendOfDamage_SpinEdit)
        Me.GENERALXtraTabPage.Controls.Add(Label7)
        Me.GENERALXtraTabPage.Controls.Add(Me.DeclarationDateEdit)
        Me.GENERALXtraTabPage.Controls.Add(Label6)
        Me.GENERALXtraTabPage.Controls.Add(Label1)
        Me.GENERALXtraTabPage.Controls.Add(Me.EventDateEdit)
        Me.GENERALXtraTabPage.Controls.Add(Me.OpRiskMateriality_lbl)
        Me.GENERALXtraTabPage.Controls.Add(Me.OpRiskLevel2_lbl)
        Me.GENERALXtraTabPage.Controls.Add(Label5)
        Me.GENERALXtraTabPage.Controls.Add(Me.OpRiskNr_lbl)
        Me.GENERALXtraTabPage.Controls.Add(Me.Label4)
        Me.GENERALXtraTabPage.Controls.Add(Me.OpRisk_GridLookUpEdit)
        Me.GENERALXtraTabPage.Controls.Add(Me.OpRiskLevel1_lbl)
        Me.GENERALXtraTabPage.Controls.Add(Me.Classification_ComboBoxEdit)
        Me.GENERALXtraTabPage.Controls.Add(Label2)
        Me.GENERALXtraTabPage.Controls.Add(Label3)
        Me.GENERALXtraTabPage.Name = "GENERALXtraTabPage"
        Me.GENERALXtraTabPage.Size = New System.Drawing.Size(1308, 579)
        Me.GENERALXtraTabPage.Text = "GENERAL"
        '
        'CaseID_lbl
        '
        Me.CaseID_lbl.AutoSize = True
        Me.CaseID_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "CaseID", True))
        Me.CaseID_lbl.Location = New System.Drawing.Point(1161, 422)
        Me.CaseID_lbl.Name = "CaseID_lbl"
        Me.CaseID_lbl.Size = New System.Drawing.Size(44, 13)
        Me.CaseID_lbl.TabIndex = 33
        Me.CaseID_lbl.Text = "Label10"
        Me.CaseID_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SCHADENSFALLBindingSource, "ID", True))
        Me.Label4.Location = New System.Drawing.Point(29, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Label1"
        '
        'CASEDESCRIPTIONXtraTabPage
        '
        Me.CASEDESCRIPTIONXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CASEDESCRIPTIONXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CASEDESCRIPTIONXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.CASEDESCRIPTIONXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.CASEDESCRIPTIONXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.CASEDESCRIPTIONXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CASEDESCRIPTIONXtraTabPage.Controls.Add(Me.CaseDescription_MemoEdit)
        Me.CASEDESCRIPTIONXtraTabPage.Name = "CASEDESCRIPTIONXtraTabPage"
        Me.CASEDESCRIPTIONXtraTabPage.Size = New System.Drawing.Size(1308, 579)
        Me.CASEDESCRIPTIONXtraTabPage.Text = "CASE DESCRIPTION"
        '
        'ATTACHMENTSXtraTabPage
        '
        Me.ATTACHMENTSXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ATTACHMENTSXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.ATTACHMENTSXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.ATTACHMENTSXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.ATTACHMENTSXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.ATTACHMENTSXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.ATTACHMENTSXtraTabPage.Controls.Add(Me.LayoutControl2)
        Me.ATTACHMENTSXtraTabPage.Name = "ATTACHMENTSXtraTabPage"
        Me.ATTACHMENTSXtraTabPage.Size = New System.Drawing.Size(1308, 579)
        Me.ATTACHMENTSXtraTabPage.Text = "ATTACHMENTS"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.Print_Export_Attachments_btn)
        Me.LayoutControl2.Controls.Add(Me.Edit_INTERBANKV_Details_btn)
        Me.LayoutControl2.Controls.Add(Me.GridControl2)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(550, 102, 602, 686)
        Me.LayoutControl2.Root = Me.LayoutControlGroup4
        Me.LayoutControl2.Size = New System.Drawing.Size(1308, 579)
        Me.LayoutControl2.TabIndex = 3
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'Print_Export_Attachments_btn
        '
        Me.Print_Export_Attachments_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Attachments_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Attachments_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Attachments_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Attachments_btn.Name = "Print_Export_Attachments_btn"
        Me.Print_Export_Attachments_btn.Size = New System.Drawing.Size(147, 22)
        Me.Print_Export_Attachments_btn.StyleController = Me.LayoutControl2
        Me.Print_Export_Attachments_btn.TabIndex = 6
        Me.Print_Export_Attachments_btn.Text = "Print or Export"
        '
        'Edit_INTERBANKV_Details_btn
        '
        Me.Edit_INTERBANKV_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_INTERBANKV_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_INTERBANKV_Details_btn.Location = New System.Drawing.Point(1111, 24)
        Me.Edit_INTERBANKV_Details_btn.Name = "Edit_INTERBANKV_Details_btn"
        Me.Edit_INTERBANKV_Details_btn.Size = New System.Drawing.Size(173, 22)
        Me.Edit_INTERBANKV_Details_btn.StyleController = Me.LayoutControl2
        Me.Edit_INTERBANKV_Details_btn.TabIndex = 4
        Me.Edit_INTERBANKV_Details_btn.Text = "Show Details"
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Root"
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1308, 579)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridControl2
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem1"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1288, 509)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem8})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1288, 50)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.Edit_INTERBANKV_Details_btn
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1087, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem2"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(177, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        Me.LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(151, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(936, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.Print_Export_Attachments_btn
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem4"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(151, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'MEASURESXtraTabPage
        '
        Me.MEASURESXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEASURESXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.MEASURESXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.MEASURESXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.MEASURESXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.MEASURESXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.MEASURESXtraTabPage.Controls.Add(Me.MeasuresMemoEdit)
        Me.MEASURESXtraTabPage.Name = "MEASURESXtraTabPage"
        Me.MEASURESXtraTabPage.Size = New System.Drawing.Size(1308, 579)
        Me.MEASURESXtraTabPage.Text = "MEASURES"
        '
        'Save_Incidents_btn
        '
        Me.Save_Incidents_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Save_Incidents_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_Incidents_btn.ImageOptions.ImageIndex = 13
        Me.Save_Incidents_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Save_Incidents_btn.Location = New System.Drawing.Point(47, 683)
        Me.Save_Incidents_btn.Name = "Save_Incidents_btn"
        Me.Save_Incidents_btn.Size = New System.Drawing.Size(116, 22)
        Me.Save_Incidents_btn.TabIndex = 11
        Me.Save_Incidents_btn.Text = "Save"
        '
        'ShowAllCases_btn
        '
        Me.ShowAllCases_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowAllCases_btn.CausesValidation = False
        Me.ShowAllCases_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowAllCases_btn.ImageOptions.ImageIndex = 0
        Me.ShowAllCases_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.ShowAllCases_btn.Location = New System.Drawing.Point(1217, 683)
        Me.ShowAllCases_btn.Name = "ShowAllCases_btn"
        Me.ShowAllCases_btn.Size = New System.Drawing.Size(139, 22)
        Me.ShowAllCases_btn.TabIndex = 12
        Me.ShowAllCases_btn.Text = "Cancel / Back to List"
        '
        'Statuslbl
        '
        Me.Statuslbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Statuslbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Statuslbl.ForeColor = System.Drawing.Color.Yellow
        Me.Statuslbl.Location = New System.Drawing.Point(447, 13)
        Me.Statuslbl.Name = "Statuslbl"
        Me.Statuslbl.Size = New System.Drawing.Size(556, 23)
        Me.Statuslbl.TabIndex = 32
        Me.Statuslbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PrintExportAllIncidents_btn)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(550, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1394, 747)
        Me.LayoutControl1.TabIndex = 33
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PrintExportAllIncidents_btn
        '
        Me.PrintExportAllIncidents_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PrintExportAllIncidents_btn.ImageOptions.ImageIndex = 2
        Me.PrintExportAllIncidents_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.PrintExportAllIncidents_btn.Location = New System.Drawing.Point(24, 24)
        Me.PrintExportAllIncidents_btn.Name = "PrintExportAllIncidents_btn"
        Me.PrintExportAllIncidents_btn.Size = New System.Drawing.Size(156, 22)
        Me.PrintExportAllIncidents_btn.StyleController = Me.LayoutControl1
        Me.PrintExportAllIncidents_btn.TabIndex = 6
        Me.PrintExportAllIncidents_btn.Text = "Print or Export"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton2.ImageOptions.ImageIndex = 5
        Me.SimpleButton2.Location = New System.Drawing.Point(1106, 24)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(264, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "Show Details"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1394, 747)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1374, 677)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1374, 50)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton2
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1082, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(268, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(160, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(922, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PrintExportAllIncidents_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem4"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(160, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'IncidentReport_btn
        '
        Me.IncidentReport_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IncidentReport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IncidentReport_btn.ImageOptions.ImageIndex = 7
        Me.IncidentReport_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.IncidentReport_btn.Location = New System.Drawing.Point(649, 683)
        Me.IncidentReport_btn.Name = "IncidentReport_btn"
        Me.IncidentReport_btn.Size = New System.Drawing.Size(153, 22)
        Me.IncidentReport_btn.TabIndex = 34
        Me.IncidentReport_btn.Text = "Incident Report"
        Me.IncidentReport_btn.Visible = False
        '
        'SpellChecker1
        '
        Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("de-DE")
        SpellCheckerISpellDictionary1.AlphabetPath = "Dictionaries\EnglishAlphabet.txt"
        SpellCheckerISpellDictionary1.CacheKey = Nothing
        SpellCheckerISpellDictionary1.Culture = New System.Globalization.CultureInfo("en-US")
        SpellCheckerISpellDictionary1.DictionaryPath = "Dictionaries\american.xlg"
        SpellCheckerISpellDictionary1.Encoding = System.Text.Encoding.GetEncoding(850)
        SpellCheckerISpellDictionary1.GrammarPath = "Dictionaries\english.aff"
        SpellCheckerCustomDictionary1.AlphabetPath = "Dictionaries\EnglishAlphabet.txt"
        SpellCheckerCustomDictionary1.CacheKey = Nothing
        SpellCheckerCustomDictionary1.Culture = New System.Globalization.CultureInfo("de-DE")
        SpellCheckerCustomDictionary1.DictionaryPath = "Dictionaries\CustomEnglish.dic"
        SpellCheckerCustomDictionary1.Encoding = System.Text.Encoding.GetEncoding(850)
        Me.SpellChecker1.Dictionaries.Add(SpellCheckerISpellDictionary1)
        Me.SpellChecker1.Dictionaries.Add(SpellCheckerCustomDictionary1)
        Me.SpellChecker1.ParentContainer = Nothing
        Me.SpellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
        '
        'Label10
        '
        Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label10.Location = New System.Drawing.Point(784, 51)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(118, 13)
        Label10.TabIndex = 34
        Label10.Text = "OpRisk Sub-Level 1:"
        '
        'Label11
        '
        Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label11.AutoSize = True
        Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label11.Location = New System.Drawing.Point(877, 75)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(25, 13)
        Label11.TabIndex = 35
        Label11.Text = "Nr.:"
        '
        'Label12
        '
        Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label12.AutoSize = True
        Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label12.Location = New System.Drawing.Point(784, 98)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(118, 13)
        Label12.TabIndex = 36
        Label12.Text = "OpRisk Sub-Level 2:"
        '
        'Label13
        '
        Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label13.Location = New System.Drawing.Point(830, 121)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(72, 13)
        Label13.TabIndex = 37
        Label13.Text = "Materiality:"
        '
        'IncidentsDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1394, 747)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.Statuslbl)
        Me.Controls.Add(Me.ShowAllCases_btn)
        Me.Controls.Add(Me.Save_Incidents_btn)
        Me.Controls.Add(Me.XtraTabControl2)
        Me.Controls.Add(Me.IncidentReport_btn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "IncidentsDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Incidents Database"
        CType(Me.SCHADENSFALLBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncidentsDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCHADENFALL_DOCSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCHADENSFALL_OPTIONSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Incicents_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField78, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField79, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField80, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField81, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField85, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField86, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField87, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField88, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField89, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField90, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField91, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField92, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField93, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField94, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField95, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField96, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField97, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField98, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField99, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField101, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField102, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField103, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField104, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField105, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField107, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField108, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField109, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField110, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField113, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField114, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField115, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField116, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField117, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField118, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField119, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField120, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncidentsDocs_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnzahlWertRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBankleitzahl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladresseFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladresseOrt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladressePostfach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladressePostleitzahl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungPostfach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungStraße, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungPostleitzahl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungOrt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInstitutstyp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBLZdervorgeschaltetenStelle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colÜberweisungsnachfragenEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colÜberweisungsrückfragenEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colScheckanfrageTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colScheckanfrageFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colScheckanfrageEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLastschriftrückrufEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWechselrückrufeTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWechselrückrufeFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWechselrückrufeEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUnbezahlteWechselTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUnbezahlteWechselFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUnbezahlteWechselEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMeldeweg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUSER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUNTERBEARBEITUNGVON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutViewField15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Classification_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclarationDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclarationDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExtendOfDamage_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpRisk_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpRiskOptions_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DamageCompensations_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DamageCompensationAmount_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeasuresMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaseDescription_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.GENERALXtraTabPage.ResumeLayout(False)
        Me.GENERALXtraTabPage.PerformLayout()
        Me.CASEDESCRIPTIONXtraTabPage.ResumeLayout(False)
        Me.ATTACHMENTSXtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MEASURESXtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IncidentsDataset As PS_TOOL_DX.IncidentsDataset
    Friend WithEvents SCHADENSFALLBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SCHADENSFALLTableAdapter As PS_TOOL_DX.IncidentsDatasetTableAdapters.SCHADENSFALLTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.IncidentsDatasetTableAdapters.TableAdapterManager
    Friend WithEvents SCHADENFALL_DOCSTableAdapter As PS_TOOL_DX.IncidentsDatasetTableAdapters.SCHADENFALL_DOCSTableAdapter
    Friend WithEvents SCHADENFALL_DOCSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SCHADENSFALL_OPTIONSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SCHADENSFALL_OPTIONSTableAdapter As PS_TOOL_DX.IncidentsDatasetTableAdapters.SCHADENSFALL_OPTIONSTableAdapter
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents GENERALXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents OpRisk_GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents OpRiskOptions_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Classification_ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CASEDESCRIPTIONXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CaseDescription_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ATTACHMENTSXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents MEASURESXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Save_Incidents_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ShowAllCases_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents OpRiskLevel1_lbl As System.Windows.Forms.Label
    Friend WithEvents OpRiskNr_lbl As System.Windows.Forms.Label
    Friend WithEvents OpRiskLevel2_lbl As System.Windows.Forms.Label
    Friend WithEvents OpRiskMateriality_lbl As System.Windows.Forms.Label
    Friend WithEvents DeclarationDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents EventDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ExtendOfDamage_SpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents DamageCompensationAmount_SpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents DamageCompensations_ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Statuslbl As System.Windows.Forms.Label
    Friend WithEvents MeasuresMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_Attachments_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_INTERBANKV_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents IncidentsDocs_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFileDirectory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colImportDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colImportTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colImportUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInternalNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdSchadenfall As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AnzahlWertRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents LayoutView4 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn51 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn52 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField49 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn53 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBankleitzahl As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn54 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBIC As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn55 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBezeichnungdesZahlungsdienstleisters As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn56 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField50 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn57 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField51 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn58 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField52 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn59 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField53 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn60 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladresseFirma As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn61 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladresseOrt As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn62 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladressePostfach As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn63 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladressePostleitzahl As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn64 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungFirma As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn65 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungPostfach As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn66 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungStraße As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn67 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungPostleitzahl As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn68 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungOrt As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn69 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colInstitutstyp As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn70 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBLZdervorgeschaltetenStelle As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn71 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAvisierungvonZahlungenTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn72 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAvisierungvonZahlungenFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn73 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAvisierungvonZahlungenEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn74 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField54 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn75 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField55 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn76 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colÜberweisungsnachfragenEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn77 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField56 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn78 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField57 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn79 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField58 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn80 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField59 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn81 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colÜberweisungsrückfragenEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn82 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colScheckanfrageTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn83 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colScheckanfrageFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn84 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colScheckanfrageEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn85 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField60 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn86 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField61 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn87 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField62 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn88 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField63 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn89 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField64 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn90 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colLastschriftrückrufEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn91 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colWechselrückrufeTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn92 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colWechselrückrufeFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn93 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colWechselrückrufeEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn94 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUnbezahlteWechselTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn95 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUnbezahlteWechselFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn96 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUnbezahlteWechselEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn97 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVorgeschalteteStelleTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn98 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVorgeschalteteStelleFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn99 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVorgeschalteteStelleEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn100 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMeldeweg As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn101 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField65 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn102 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUSER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn103 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUNTERBEARBEITUNGVON As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard2 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutView3 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutView2 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn26 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn27 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn28 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn29 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn30 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn31 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField6 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn32 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField7 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn33 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField8 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn34 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField9 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn35 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField10 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn36 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField11 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn37 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField12 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn38 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField13 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn39 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField14 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn40 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField15 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn41 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField16 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn42 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField17 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn43 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField18 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn44 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField19 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn45 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField20 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn46 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField21 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn47 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField22 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn48 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField23 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn49 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField24 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn50 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField25 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CaseID_lbl As System.Windows.Forms.Label
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PrintExportAllIncidents_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Incicents_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaseID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClassification As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOpRiskLetter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOpRiskLevel1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOpRiskNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOpRiskLevel2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOpRiskMateriality As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEventDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDeclarationDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExtentOfDamage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDamageCompensations As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDamageCompensationsAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaseDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeasures As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField26 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField27 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField28 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn4 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField29 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn5 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField30 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn6 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField31 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn7 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField32 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn8 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField33 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn9 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField34 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn10 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField35 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn11 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField36 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn12 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField37 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn13 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField38 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn14 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField39 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn15 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField40 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn16 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField41 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn17 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField42 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn18 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField43 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn19 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField44 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn20 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField45 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn21 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField46 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn22 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField47 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn23 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField48 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn24 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField66 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn25 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField67 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn104 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField68 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn105 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField69 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn106 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField70 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn107 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField71 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn108 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField72 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn109 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField73 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn110 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField74 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn111 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField75 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn112 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField76 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn113 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField77 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn114 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField78 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn115 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField79 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn116 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField80 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn117 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField81 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn118 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField82 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn119 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField83 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn120 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField84 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn121 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField85 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn122 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField86 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn123 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField87 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn124 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField88 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn125 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField89 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn126 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField90 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn127 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField91 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn128 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField92 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn129 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField93 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn130 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField94 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn131 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField95 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutView5 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutView6 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn132 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField96 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn133 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField97 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn134 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField98 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn135 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField99 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn136 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField100 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn137 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField101 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn138 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField102 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn139 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField103 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn140 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField104 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn141 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField105 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn142 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField106 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn143 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField107 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn144 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField108 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn145 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField109 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn146 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField110 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn147 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField111 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn148 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField112 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn149 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField113 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn150 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField114 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn151 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField115 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn152 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField116 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn153 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField117 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn154 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField118 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn155 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField119 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn156 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField120 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ImageCollection2 As DevExpress.Utils.ImageCollection
    Friend WithEvents colFileNameType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents IncidentReport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
End Class
