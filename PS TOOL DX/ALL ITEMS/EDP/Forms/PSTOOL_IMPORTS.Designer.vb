<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PSTOOL_IMPORTS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PSTOOL_IMPORTS))
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.ODASLastProcFileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ODASLastProcFileTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.ODASLastProcFileTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.OCBSLastProcFileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OCBSLastProcFileTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.OCBSLastProcFileTableAdapter()
        Me.BgwODASimport = New System.ComponentModel.BackgroundWorker()
        Me.BgwOCBSimport = New System.ComponentModel.BackgroundWorker()
        Me.BgwClientRun = New System.ComponentModel.BackgroundWorker()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CurrentOdasImportFile = New DevExpress.XtraEditors.LabelControl()
        Me.LastOdasImportFile = New DevExpress.XtraEditors.LabelControl()
        Me.ODASProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.CurrentOcbsImportFile = New DevExpress.XtraEditors.LabelControl()
        Me.LastOcbsImportFile = New DevExpress.XtraEditors.LabelControl()
        Me.OCBSProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.CURRENT_PROCEDURE_Text = New DevExpress.XtraEditors.LabelControl()
        Me.EVENTSloadtext = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ODASLastProcFileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBSLastProcFileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ODASLastProcFileBindingSource
        '
        Me.ODASLastProcFileBindingSource.DataMember = "ODASLastProcFile"
        Me.ODASLastProcFileBindingSource.DataSource = Me.PSTOOLDataset
        '
        'ODASLastProcFileTableAdapter
        '
        Me.ODASLastProcFileTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
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
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.OCBSLastProcFileTableAdapter = Me.OCBSLastProcFileTableAdapter
        Me.TableAdapterManager.ODASLastProcFileTableAdapter = Me.ODASLastProcFileTableAdapter
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager.SSISTableAdapter = Nothing
        Me.TableAdapterManager.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OCBSLastProcFileBindingSource
        '
        Me.OCBSLastProcFileBindingSource.DataMember = "OCBSLastProcFile"
        Me.OCBSLastProcFileBindingSource.DataSource = Me.PSTOOLDataset
        '
        'OCBSLastProcFileTableAdapter
        '
        Me.OCBSLastProcFileTableAdapter.ClearBeforeFill = True
        '
        'BgwODASimport
        '
        Me.BgwODASimport.WorkerReportsProgress = True
        Me.BgwODASimport.WorkerSupportsCancellation = True
        '
        'BgwOCBSimport
        '
        Me.BgwOCBSimport.WorkerReportsProgress = True
        Me.BgwOCBSimport.WorkerSupportsCancellation = True
        '
        'BgwClientRun
        '
        Me.BgwClientRun.WorkerReportsProgress = True
        Me.BgwClientRun.WorkerSupportsCancellation = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CurrentOdasImportFile)
        Me.GroupControl1.Controls.Add(Me.LastOdasImportFile)
        Me.GroupControl1.Controls.Add(Me.ODASProgressBar)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(113, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(845, 99)
        Me.GroupControl1.TabIndex = 8
        Me.GroupControl1.Text = "ODAS FILES IMPORT"
        '
        'CurrentOdasImportFile
        '
        Me.CurrentOdasImportFile.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.CurrentOdasImportFile.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CurrentOdasImportFile.Location = New System.Drawing.Point(436, 48)
        Me.CurrentOdasImportFile.Name = "CurrentOdasImportFile"
        Me.CurrentOdasImportFile.Size = New System.Drawing.Size(0, 13)
        Me.CurrentOdasImportFile.TabIndex = 7
        '
        'LastOdasImportFile
        '
        Me.LastOdasImportFile.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LastOdasImportFile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ODASLastProcFileBindingSource, "FileName", True))
        Me.LastOdasImportFile.Location = New System.Drawing.Point(330, 48)
        Me.LastOdasImportFile.Name = "LastOdasImportFile"
        Me.LastOdasImportFile.Size = New System.Drawing.Size(0, 13)
        Me.LastOdasImportFile.TabIndex = 6
        '
        'ODASProgressBar
        '
        Me.ODASProgressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ODASProgressBar.Location = New System.Drawing.Point(6, 67)
        Me.ODASProgressBar.Name = "ODASProgressBar"
        Me.ODASProgressBar.Size = New System.Drawing.Size(834, 23)
        Me.ODASProgressBar.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(436, 29)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(99, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "ODAS File for Import"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(330, 29)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Last ODAS File"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.CurrentOcbsImportFile)
        Me.GroupControl2.Controls.Add(Me.LastOcbsImportFile)
        Me.GroupControl2.Controls.Add(Me.OCBSProgressBar)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Location = New System.Drawing.Point(113, 118)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(845, 99)
        Me.GroupControl2.TabIndex = 11
        Me.GroupControl2.Text = "OCBS FILES IMPORT"
        '
        'CurrentOcbsImportFile
        '
        Me.CurrentOcbsImportFile.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.CurrentOcbsImportFile.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CurrentOcbsImportFile.Location = New System.Drawing.Point(436, 48)
        Me.CurrentOcbsImportFile.Name = "CurrentOcbsImportFile"
        Me.CurrentOcbsImportFile.Size = New System.Drawing.Size(0, 13)
        Me.CurrentOcbsImportFile.TabIndex = 7
        '
        'LastOcbsImportFile
        '
        Me.LastOcbsImportFile.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LastOcbsImportFile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OCBSLastProcFileBindingSource, "FileName", True))
        Me.LastOcbsImportFile.Location = New System.Drawing.Point(330, 48)
        Me.LastOcbsImportFile.Name = "LastOcbsImportFile"
        Me.LastOcbsImportFile.Size = New System.Drawing.Size(0, 13)
        Me.LastOcbsImportFile.TabIndex = 6
        '
        'OCBSProgressBar
        '
        Me.OCBSProgressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OCBSProgressBar.Location = New System.Drawing.Point(6, 67)
        Me.OCBSProgressBar.Name = "OCBSProgressBar"
        Me.OCBSProgressBar.Size = New System.Drawing.Size(834, 23)
        Me.OCBSProgressBar.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(436, 29)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl5.TabIndex = 3
        Me.LabelControl5.Text = "OCBS File for Import"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(330, 29)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl6.TabIndex = 2
        Me.LabelControl6.Text = "Last OCBS File"
        '
        'CURRENT_PROCEDURE_Text
        '
        Me.CURRENT_PROCEDURE_Text.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.CURRENT_PROCEDURE_Text.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CURRENT_PROCEDURE_Text.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CURRENT_PROCEDURE_Text.Location = New System.Drawing.Point(113, 388)
        Me.CURRENT_PROCEDURE_Text.Name = "CURRENT_PROCEDURE_Text"
        Me.CURRENT_PROCEDURE_Text.Size = New System.Drawing.Size(845, 20)
        Me.CURRENT_PROCEDURE_Text.TabIndex = 10
        '
        'EVENTSloadtext
        '
        Me.EVENTSloadtext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EVENTSloadtext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.EVENTSloadtext.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.EVENTSloadtext.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.EVENTSloadtext.Location = New System.Drawing.Point(113, 414)
        Me.EVENTSloadtext.Name = "EVENTSloadtext"
        Me.EVENTSloadtext.Size = New System.Drawing.Size(840, 62)
        Me.EVENTSloadtext.TabIndex = 9
        '
        'PSTOOL_IMPORTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 578)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.CURRENT_PROCEDURE_Text)
        Me.Controls.Add(Me.EVENTSloadtext)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PSTOOL_IMPORTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PS TOOL DX IMPORTS - SQL Server 2008"
        Me.TopMost = True
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ODASLastProcFileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBSLastProcFileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents ODASLastProcFileBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ODASLastProcFileTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.ODASLastProcFileTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents OCBSLastProcFileTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.OCBSLastProcFileTableAdapter
    Friend WithEvents OCBSLastProcFileBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BgwODASimport As System.ComponentModel.BackgroundWorker
    Friend WithEvents BgwOCBSimport As System.ComponentModel.BackgroundWorker
    Friend WithEvents BgwClientRun As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CurrentOdasImportFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LastOdasImportFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ODASProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CurrentOcbsImportFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LastOcbsImportFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBSProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CURRENT_PROCEDURE_Text As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EVENTSloadtext As DevExpress.XtraEditors.LabelControl
End Class
