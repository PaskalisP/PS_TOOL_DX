Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Reflection
Imports System.Runtime
Imports System.Threading
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
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
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.Data
Imports DevExpress.Spreadsheet
Imports DevExpress.Office.Services
Imports DevExpress.XtraSpreadsheet.Export
Imports DevExpress.XtraEditors.DXErrorProvider
Imports Ionic.Zip
Imports System.Net
Imports PS_TOOL_DX.VbSyntaxHighlightApp


Public Class ExecuteVbCode

    Private Sub ExecuteVbCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        DevExpress.XtraRichEdit.RichEditControlCompatibility.UseThemeFonts = False
        DevExpress.XtraRichEdit.RichEditControlCompatibility.DefaultFontSize = 11
        DevExpress.XtraRichEdit.RichEditControlCompatibility.DefaultFontName = "Consolas"

        txtSource.Options.Behavior.FontSource = RichEditBaseValueSource.Document
        txtSource.Document.DefaultCharacterProperties.FontName = "Consolas"
        txtSource.Document.DefaultCharacterProperties.FontSize = 11
        'txtSource.Document.DefaultCharacterProperties.ForeColor = Color.Red

        Dim path As String = "ExecuteVbCode.vb"
        ' Use service substitution to register a custom service that implements syntax highlighting.
        txtSource.ReplaceService(Of ISyntaxHighlightService)(New VbSyntaxHighlightService(txtSource, txtSource.Document))

    End Sub

    Private Sub bbiOpenVbFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiOpenVbFile.ItemClick
        With XtraOpenFileDialog1
            .Filter = "VB.NET files|*.vb"
            .FilterIndex = 1
            .InitialDirectory = "C:\"
            .FileName = ""
            .RestoreDirectory = True
            .Title = "Load VB.NET Script File"
            If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                If IsNothing(Me.XtraOpenFileDialog1.FileName) = False Then
                    Dim fileName As String = Me.XtraOpenFileDialog1.FileName
                    Dim contents As String = GetFileContent(fileName)
                    Me.txtSource.Text = contents
                    Me.VbFileSaved_BarStaticItem.Visibility = BarItemVisibility.Always
                    Me.VbFileSaved_BarStaticItem.Caption = "Loaded VB Script File: " & System.IO.Path.GetFileName(Me.XtraOpenFileDialog1.FileName)
                    Me.VbFileSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = Color.Cyan
                End If

            End If

        End With
    End Sub

    Private Sub DISABLE_CONTROLS_ON_VB_EXECUTION()
        Me.bbiExecutingVbProgress.Visibility = BarItemVisibility.Always
        Me.bbiStopRunVbCode.Visibility = BarItemVisibility.Always
        Me.bbiOpenVbFile.Enabled = False
        Me.bbiSaveVbFile.Enabled = False
        Me.bbiRunVbCode.Enabled = False
        Me.txtSource.ReadOnly = True
    End Sub

    Private Sub ENABLE_CONTROLS_ON_VB_EXECUTION()
        Me.bbiExecutingVbProgress.Visibility = BarItemVisibility.Never
        Me.bbiStopRunVbCode.Visibility = BarItemVisibility.Never
        Me.bbiOpenVbFile.Enabled = True
        Me.bbiSaveVbFile.Enabled = True
        Me.bbiRunVbCode.Enabled = True
        Me.txtSource.ReadOnly = False
    End Sub

    Private Sub bbiRunVbCode_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiRunVbCode.ItemClick
        If txtSource.Text <> "" Then
            DISABLE_CONTROLS_ON_VB_EXECUTION()
            BgwVbExecute.RunWorkerAsync()
        End If

    End Sub

    Private Sub bbiStopRunVbCode_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiStopRunVbCode.ItemClick
        If Me.BgwVbExecute.IsBusy = True Then
            If XtraMessageBox.Show("Should the VB.NET Script execution be terminated?", "TERMINATE SCRIPT EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.BgwVbExecute.CancelAsync()
            End If
        End If
    End Sub
    Private Sub BgwVbExecute_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwVbExecute.DoWork

        If BgwVbExecute.CancellationPending = True Then
            e.Cancel = True
            Exit Sub
        ElseIf BgwVbExecute.CancellationPending = False Then
            Me.bbiExecutingVbProgress.EditValue = 10
            RunTheProg()
        End If
    End Sub

    Private Sub BgwVbExecute_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwVbExecute.RunWorkerCompleted
        ENABLE_CONTROLS_ON_VB_EXECUTION()
        If e.Cancelled = True Then
            ENABLE_CONTROLS_ON_VB_EXECUTION()
        End If
    End Sub

    Private Sub RunTheProg()
        Dim code As String = txtSource.Text.Trim()
        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
        Dim entry As String = "VB_ScriptForExecution"
        If code = "" Then Return
        If entry = "" Then entry = "VB_ScriptForExecution"
        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
        engine.Run()
    End Sub

    Private Sub txtSource_TextChanged(sender As Object, e As EventArgs) Handles txtSource.TextChanged
        If txtSource.Text <> "" Then
            txtSource.ReplaceService(Of ISyntaxHighlightService)(New VbSyntaxHighlightService(txtSource, txtSource.Document))
        End If
    End Sub

    Public Shared Function GetFileContent(ByVal fileName As String) As String
        If fileName.Length > 0 AndAlso File.Exists(fileName) Then
            Dim reader As StreamReader = Nothing
            Dim fileContents As String = String.Empty

            Try
                reader = New StreamReader(fileName, System.Text.Encoding.[Default])
                fileContents = reader.ReadToEnd().Trim()
            Catch ex As Exception
                XtraMessageBox.Show("Error:  An exception occurred while reading the code from the file" & ex.Message)
            Finally
                If reader IsNot Nothing Then reader.Close()
            End Try

            If fileContents.Length = 0 Then
                XtraMessageBox.Show("Error:  The file is empty")
            End If

            Return fileContents
        Else
            XtraMessageBox.Show("Error:  The file does not exist")
        End If

        Return String.Empty
    End Function

    Private Sub bbiSaveVbFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSaveVbFile.ItemClick
        If txtSource.Text <> "" Then
            With XtraSaveFileDialog1
                .Filter = "vb.net files|*.vb"
                XtraSaveFileDialog1.DefaultExt = "vb"
                .FilterIndex = 1
                '.InitialDirectory = "C:\"
                .RestoreDirectory = True
                .FileName = ""
                .Title = "Save current VB.NET Script file"

                If Me.XtraSaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    If IsNothing(Me.XtraSaveFileDialog1.FileName) = False Then

                        My.Computer.FileSystem.WriteAllText(Me.XtraSaveFileDialog1.FileName, Me.txtSource.Text, False)
                        Me.VbFileSaved_BarStaticItem.Visibility = BarItemVisibility.Always
                        Me.VbFileSaved_BarStaticItem.Caption = "Saved VB.NET Script file: " & System.IO.Path.GetFileName(Me.XtraSaveFileDialog1.FileName)
                        Me.VbFileSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = Color.Cyan
                    End If

                End If
            End With
        End If
    End Sub

    Private Sub ExecuteVbCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.bbiRunVbCode.PerformClick()
        End If
    End Sub

    Private Sub ExecuteVbCode_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If BgwVbExecute.IsBusy AndAlso BgwVbExecute.CancellationPending = False Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub bbiPrintVbScript_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPrintVbScript.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
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
        Dim reportfooter As String = "VB Script"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub txtSource_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSource.KeyDown
        If Me.VbFileSaved_BarStaticItem.Caption <> "" Then
            Me.VbFileSaved_BarStaticItem.Caption = "Loaded VB Script File: " & System.IO.Path.GetFileName(Me.XtraOpenFileDialog1.FileName) & " - MODIFIED"
            Me.VbFileSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = Color.Red
        End If
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiClose.ItemClick
        Me.Close()

    End Sub


End Class