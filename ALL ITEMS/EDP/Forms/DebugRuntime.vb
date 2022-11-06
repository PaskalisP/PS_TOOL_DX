Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraTreeList
Imports CrystalDecisions.Shared
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Public Class DebugRuntime

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim vArgs() As Object

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim ProgrammierungRequest As String = Nothing
    Dim ImplemenationDate As Date



  
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

    Private Sub DebugRuntime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        Me.CURRENT_USERSTableAdapter.Fill(Me.EDPDataSet.CURRENT_USERS)
        Me.BuildsTableAdapter.Fill(Me.AuditDataSet.Builds)

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Fill combobox with Import events files

        For Each file As String In System.IO.Directory.GetFiles(ImportEventsDirectoryFolder)
            If System.IO.Path.GetFileName(file).ToString.StartsWith("PSTOOL_ImportEvents_") = True Then
                Me.ImportEventsFiles_ComboBoxEdit.Properties.Items.Add(System.IO.Path.GetFileName(file))
            End If

        Next

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.BuildsBindingSource.EndEdit()

                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.BuildsTableAdapter.Update(Me.AuditDataSet.Builds)
                    Me.BuildsTableAdapter.Fill(Me.AuditDataSet.Builds)
                Else
                    Me.BuildsBindingSource.CancelEdit()
                    Me.BuildsTableAdapter.Fill(Me.AuditDataSet.Builds)
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Dim row As System.Data.DataRow = Builds_GridView.GetDataRow(Builds_GridView.FocusedRowHandle)
                Dim ID As String = row(0)
                
                If MessageBox.Show("Should the Build Description with ID: " & ID & " be deleted?", "DELETE BUILD ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "DELETE FROM [Builds] where [ID]='" & ID & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.BuildsTableAdapter.Fill(Me.AuditDataSet.Builds)
                Else
                    e.Handled = True
                End If
               
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub RunCode_btn_Click(sender As Object, e As EventArgs) Handles RunCode_btn.Click
        Try
            If Me.VbScript_MemoEdit.Text.Trim <> "" Then
                CompileAndRunCode(Me.VbScript_MemoEdit.Text)
            Else
                MsgBox("Write VB.Net code to compile")
            End If
        Catch err As Exception
            MsgBox(err.Message & " " & err.StackTrace)
        End Try

    End Sub

    Public Function CompileAndRunCode(ByVal VBCodeToExecute As String) As Object

        Dim sReturn_DataType As String
        Dim sReturn_Value As String = ""
        Try

            ' Instance our CodeDom wrapper
            Dim ep As New cVBEvalProvider

            ' Compile and run
            Dim objResult As Object = ep.Eval(VBCodeToExecute)
            If ep.CompilerErrors.Count <> 0 Then
                Diagnostics.Debug.WriteLine("CompileAndRunCode: Compile Error Count = " & ep.CompilerErrors.Count)
                Diagnostics.Debug.WriteLine(ep.CompilerErrors.Item(0))
                Return "ERROR" ' Forget it
            End If
            Dim t As Type = objResult.GetType()
            If t.ToString() = "System.String" Then
                sReturn_DataType = t.ToString
                sReturn_Value = Convert.ToString(objResult)
            Else
                ' Some other type of data - not really handled at 
                ' this point. rwd
                'ToDo: Add handlers for other data return types, if needed

                ' Here is an example to handle a dataset...
                'Dim ds As DataSet = DirectCast(objResult, DataSet)
                'DataGrid1.Visible = True
                'TextBox2.Visible = False
                'DataGrid1.DataSource = ds.Tables(0)
            End If

        Catch ex As Exception
            Dim sErrMsg As String
            sErrMsg = String.Format("{0}", ex.Message)
            ' Do Nothing - This is just a negative case
            ' This outcome is expected in late interpreting
            ' I suppose what I am saying is: Don't stop my program because the script writer can't write
            ' script very well.  To be fair, we could log this somewhere and notify somebody.
        End Try

        Return sReturn_Value

    End Function

    Private Sub RunTextClear_btn_Click(sender As Object, e As EventArgs) Handles RunTextClear_btn.Click
        Me.VbScript_MemoEdit.Text = Nothing

    End Sub

    Private Sub LoadCode_btn_Click(sender As Object, e As EventArgs) Handles LoadCode_btn.Click
        With OpenFileDialog1
            .Filter = "All Files(*.*)|*.*"
            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath
            .FileName = ""
            .Title = "Load VB Code from File"
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                If IsNothing(Me.OpenFileDialog1.FileName) = False Then
                    Me.VbScript_MemoEdit.Text = My.Computer.FileSystem.ReadAllText(Me.OpenFileDialog1.FileName)
                End If
            End If
        End With
    End Sub

    Private Sub PrintCode_btn_Click(sender As Object, e As EventArgs) Handles PrintCode_btn.Click
        Dim l As New Link(New PrintingSystem())
        AddHandler l.CreateDetailArea, AddressOf l_CreateDetailArea
        l.ShowPreviewDialog()

    End Sub
    Private Sub l_CreateDetailArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
        Dim sz As SizeF = g.MeasureString(Me.VbScript_MemoEdit.Text, Me.VbScript_MemoEdit.Font, 600)
        Dim tb As New TextBrick(DevExpress.XtraPrinting.BorderSide.All, 0, Color.Red, Color.White, Color.Black)
        tb.Rect = New RectangleF(New PointF(0, 0), sz)
        tb.Font = Me.VbScript_MemoEdit.Font
        tb.Text = Me.VbScript_MemoEdit.Text
        e.Graph.DrawBrick(tb)
    End Sub

   
    Private Sub LoadImportEvents_btn_Click(sender As Object, e As EventArgs) Handles LoadImportEvents_btn.Click
        Me.VbScript_MemoEdit.Text = My.Computer.FileSystem.ReadAllText(ImportEventsDirectory)
        
    End Sub

    Private Sub LoadImportEventsTextFile_btn_Click(sender As Object, e As EventArgs) Handles LoadImportEventsTextFile_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Import Events")
            Me.ListBoxControl1.Items.AddRange(IO.File.ReadAllLines(ImportEventsDirectory))
            SplashScreenManager.CloseForm(False)
           

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try

    End Sub

    Private Sub ImportEventsSwiftMessages_btn_Click(sender As Object, e As EventArgs) Handles ImportEventsSwiftMessages_btn.Click

        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Swift Messages Import Events")
            cmd.Connection.Open()
            cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_IMPORT_EVENTS'"
            Dim ImportEventsSwiftDirectory As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            Me.ListBoxControl2.Items.AddRange(IO.File.ReadAllLines(ImportEventsSwiftDirectory))
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub CURRENT_USERSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CURRENT_USERSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

    Private Sub LoadCurrentUsers_btn_Click(sender As Object, e As EventArgs) Handles LoadCurrentUsers_btn.Click
        Me.CURRENT_USERSTableAdapter.Fill(Me.EDPDataSet.CURRENT_USERS)
    End Sub

    Private Sub ListBoxControl1_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles ListBoxControl1.DrawItem
        If e.Index = ListBoxControl1.SelectedIndex Then
            e.Appearance.ForeColor = Color.Yellow
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If

        If e.Item.ToString.Contains("ERROR") = True Then
            e.Appearance.ForeColor = Color.Orange
        End If

    End Sub

    Private Sub ListBoxControl2_Click(sender As Object, e As EventArgs) Handles ListBoxControl2.Click

       
    End Sub

    Private Sub ListBoxControl2_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles ListBoxControl2.DrawItem
        If e.Index = ListBoxControl2.SelectedIndex Then
            e.Appearance.ForeColor = Color.Yellow
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If

        If e.Item.ToString.Contains("ERROR") = True Then
            e.Appearance.ForeColor = Color.Orange
        End If
    End Sub

    Private Sub ListBoxControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBoxControl2.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim copy_buffer As New System.Text.StringBuilder
            For Each item As Object In ListBoxControl2.SelectedItems
                copy_buffer.AppendLine(item.ToString)
            Next
            If copy_buffer.Length > 0 Then
                Clipboard.SetText(copy_buffer.ToString)
            End If
        End If
    End Sub

   

    Private Sub ListBoxControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxControl2.SelectedIndexChanged
        Dim i As Integer
        For Each index As Integer In ListBoxControl2.SelectedIndices
            'do something
            Dim selectedItem As Object = ListBoxControl2.Items(i)

            'MsgBox(selectedItem)

        Next

    End Sub

    Private Sub ListBoxControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBoxControl1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim copy_buffer As New System.Text.StringBuilder
            For Each item As Object In ListBoxControl1.SelectedItems
                copy_buffer.AppendLine(item.ToString)
            Next
            If copy_buffer.Length > 0 Then
                Clipboard.SetText(copy_buffer.ToString)
            End If
        End If

    End Sub

    Private Sub CurrentUsers_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CurrentUsers_GridView.CellValueChanged
       

    End Sub

    Private Sub RepositoryItemImageComboBox17_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox17.EditValueChanged
        Try
            CurrentUsers_GridView.PostEditor()
            Me.CURRENT_USERSBindingSource.EndEdit()
            Me.CURRENT_USERSTableAdapter.Update(Me.EDPDataSet.CURRENT_USERS)
            Me.CURRENT_USERSTableAdapter.Fill(Me.EDPDataSet.CURRENT_USERS)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try


    End Sub

    Private Sub Builds_GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles Builds_GridView.CustomRowCellEditForEditing
        If e.Column.FieldName = "Description" Then
            e.RepositoryItem = RepositoryItemMemoExEdit1
        End If

    End Sub

   

    Private Sub Builds_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles Builds_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Builds_GridView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles Builds_GridView.PopupMenuShowing
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)
        If HitInfo.InRow Then
            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)
        End If
    End Sub

    Private Sub Builds_GridView_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles Builds_GridView.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        ProgrammierungRequest = view.GetRowCellValue(e.RowHandle, colDescription).ToString

        Dim IMPLEMENTATION_DATE As GridColumn = view.Columns("ImplementationDate")
        Dim ImplementationDateString As String = view.GetRowCellValue(e.RowHandle, colImplementationDate).ToString

        If ImplementationDateString <> "" Then
            ImplemenationDate = view.GetRowCellValue(e.RowHandle, colImplementationDate).ToString
        Else
            ImplemenationDate = Today

        End If


    End Sub

    Private Sub Builds_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles Builds_GridView.RowClick
        Dim view As GridView = CType(sender, GridView)
        ProgrammierungRequest = view.GetRowCellValue(e.RowHandle, colDescription).ToString

        Dim IMPLEMENTATION_DATE As GridColumn = view.Columns("ImplementationDate")
        Dim ImplementationDateString As String = view.GetRowCellValue(e.RowHandle, colImplementationDate).ToString

        If ImplementationDateString <> "" Then
            ImplemenationDate = view.GetRowCellValue(e.RowHandle, colImplementationDate).ToString
        Else
            ImplemenationDate = Today

        End If

    End Sub

    Private Sub Builds_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Builds_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Builds_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Builds_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Builds_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Builds_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim VersionNr As GridColumn = View.Columns("VerionNr")
        Dim BuildNr As GridColumn = View.Columns("BuildNr")
        Dim Revision As GridColumn = View.Columns("Revision")
        Dim App_Module As GridColumn = View.Columns("Module")
        Dim TableForm As GridColumn = View.Columns("Table_Form")
        Dim Description As GridColumn = View.Columns("Description") '
        Dim ImplemenationDate As GridColumn = View.Columns("ImplementationDate")
       

        Dim VERSION_NR As String = View.GetRowCellValue(e.RowHandle, colVerionNr).ToString
        Dim BUILD_NR As String = View.GetRowCellValue(e.RowHandle, colBuildNr).ToString
        Dim REVISION_TXT As String = View.GetRowCellValue(e.RowHandle, colRevision).ToString
        Dim MODULE_TXT As String = View.GetRowCellValue(e.RowHandle, colModule).ToString
        Dim TABLE_FORM As String = View.GetRowCellValue(e.RowHandle, colTable_Form).ToString
        Dim DESCRIPTION_TXT As String = View.GetRowCellValue(e.RowHandle, colDescription).ToString
        Dim IMPLEMENTATION_DATE As String = View.GetRowCellValue(e.RowHandle, colImplementationDate).ToString
       
        If VERSION_NR = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(VersionNr, "The Version Nr must not be empty")
            e.ErrorText = "The Version Nr must not be empty"
        End If
        If BUILD_NR = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BuildNr, "The Build Nr not be empty")
            e.ErrorText = "The Build Nr must not be empty"
        End If
        If REVISION_TXT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Revision, "The Revision Nr not be empty")
            e.ErrorText = "The Revision Nr must not be empty"
        End If
        If MODULE_TXT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(App_Module, "The Module Name must not be empty")
            e.ErrorText = "The Module Name must not be empty"
        End If
        If TABLE_FORM = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TableForm, "The Table/Form Name must not be empty")
            e.ErrorText = "The Table/Form Name must not be empty"
        End If
        If DESCRIPTION_TXT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(Description, "The Description must not be empty")
            e.ErrorText = "The Description must not be empty"
        End If
        If IMPLEMENTATION_DATE = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ImplemenationDate, "The Implementation Date must not be empty")
            e.ErrorText = "The Implementation Date must not be empty"
        End If
    End Sub

    Private Sub Print_Export_BuildGridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BuildGridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
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
        Dim reportfooter As String = "PS TOOL Builds - Descriptions" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Fill_IDV_Form_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Fill_IDV_Form_ToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Form creation")
            Dim IDV_REQUEST_FORM As String = Nothing
            
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='BUILDS_FORMS'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "IDV_Form_Directory" Then
                    IDV_REQUEST_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

           
            SplashScreenManager.Default.SetWaitFormCaption("Create Form: IDV")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "IDV Request Form"
            c.RichEditControl1.LoadDocument(IDV_REQUEST_FORM)
            c.RichEditControl1.ReadOnly = False
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden
            Dim IT_ProgrammierungPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IT_Programmierung").Range.End
            c.RichEditControl1.Document.InsertText(IT_ProgrammierungPos, ProgrammierungRequest)
            Dim ExpertApprovalDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ExpertApprovalDate").Range.End
            c.RichEditControl1.Document.InsertText(ExpertApprovalDatePos, ImplemenationDate)
            
            
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub ImportEventsFiles_ComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ImportEventsFiles_ComboBoxEdit.SelectedIndexChanged
       
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Import Events File: " & Me.ImportEventsFiles_ComboBoxEdit.Text)
            Me.ListBoxControl1.Items.AddRange(IO.File.ReadAllLines(ImportEventsDirectoryFolder & Me.ImportEventsFiles_ComboBoxEdit.Text))
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

    Private Sub ImportEventsSwiftStatements_btn_Click(sender As Object, e As EventArgs) Handles ImportEventsSwiftStatements_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Swift Statements Import Events")
            cmd.Connection.Open()
            cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='Swift_Statement_ImportEvents_Dir' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SWIFT_STATEMENTS_DIRECTORIES'"
            Dim ImportEventsSwiftDirectory As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            Me.ListBoxControl3.Items.AddRange(IO.File.ReadAllLines(ImportEventsSwiftDirectory))
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ListBoxControl3_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles ListBoxControl3.DrawItem
        If e.Index = ListBoxControl3.SelectedIndex Then
            e.Appearance.ForeColor = Color.Yellow
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If

        If e.Item.ToString.Contains("ERROR") = True Then
            e.Appearance.ForeColor = Color.Orange
        End If
    End Sub

    Private Sub ListBoxControl3_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBoxControl3.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim copy_buffer As New System.Text.StringBuilder
            For Each item As Object In ListBoxControl3.SelectedItems
                copy_buffer.AppendLine(item.ToString)
            Next
            If copy_buffer.Length > 0 Then
                Clipboard.SetText(copy_buffer.ToString)
            End If
        End If
    End Sub
End Class