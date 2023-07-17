Imports System
Imports System.IO
Imports System.Text
Imports System.Math
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Reflection
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
'Imports System.ComponentModel.DataAnnotations
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
'Imports System.Diagnostics
Imports System.Collections.Generic
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
'Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
'Imports System.Drawing
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
'Imports Ionic.Zip
Imports DocumentFormat = DevExpress.Spreadsheet.DocumentFormat
Imports System.Net
Imports DevExpress.XtraTreeList
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.Office.Utils
Imports DevExpress.XtraTreeList.ViewInfo
Imports DevExpress.Utils


Namespace DynamicCompileAndRun
    Public Enum LanguageType
        CSharp
        VB
    End Enum

    Public Class CompileEngine
        Public Sub New(ByVal code As String)
            Me.SourceCode = code
        End Sub

        Public Sub New(ByVal code As String, ByVal language As LanguageType, ByVal entry As String)
            Me.SourceCode = code
            Me.Language = language
            Me.EntryPoint = entry
        End Sub

        Public Sub Run()
            ClearErrMsgs()
            Dim strRealSourceCode As String = PrepareRealSourceCode()
            Dim assembly As Assembly = CreateAssembly(strRealSourceCode)
            CallEntry(assembly, EntryPoint)
            DisplayErrorMsg()
        End Sub

        Friend SourceCode As String = String.Empty
        Friend EntryPoint As String = "Main"
        Friend References As ArrayList = New ArrayList()
        Friend WaitForUserAction As Boolean = True
        Friend Language As LanguageType = LanguageType.VB

        Private Function PrepareRealSourceCode() As String
            Dim strRealSourceCode As String = ""
            Dim strUsingStatement As String = ""

            If Language = LanguageType.VB Then
                Dim basicImportsStatement As String() = {"Imports Microsoft.VisualBasic",
                                                        "Imports System",
                                                        "Imports System.Windows.Forms",
                                                        "Imports System.Data",
                                                        "Imports System.Data.SqlClient",
                                                        "Imports System.Math",
                                                        "Imports System.Xml",
                                                        "Imports System.Collections",
                                                        "Imports CrystalDecisions.Shared",
                                                        "Imports CrystalDecisions.CrystalReports.Engine",
                                                        "Imports Microsoft.Office.Interop",
                                                        "Imports DevExpress.XtraEditors",
                                                        "Imports DevExpress.XtraLayout",
                                                        "Imports DevExpress.XtraLayout.Helpers",
                                                        "Imports DevExpress.XtraEditors.Controls",
                                                        "Imports DevExpress.XtraSplashScreen",
                                                        "Imports DevExpress.XtraGrid.Views",
                                                        "Imports DevExpress.XtraGrid.Views.Base",
                                                        "Imports System.Data.OleDb",
                                                        "Imports System.Xml.XmlReader",
                                                        "Imports System.Diagnostics",
                                                        "Imports System.Collections.Generic",
                                                        "Imports DevExpress.Skins",
                                                        "Imports DevExpress.LookAndFeel",
                                                        "Imports DevExpress.UserSkins",
                                                        "Imports DevExpress.XtraBars",
                                                        "Imports DevExpress.XtraBars.Ribbon",
                                                        "Imports DevExpress.XtraBars.Helpers",
                                                        "Imports DevExpress.XtraGrid.Views.Grid",
                                                        "Imports DevExpress.XtraGrid.Views.Grid.ViewInfo",
                                                        "Imports DevExpress.XtraGrid.Views.Layout.ViewInfo",
                                                        "Imports DevExpress.XtraLayout.Customization",
                                                        "Imports DevExpress.XtraGrid.Views.Layout.Drawing",
                                                        "Imports DevExpress.XtraLayout.Utils",
                                                        "Imports DevExpress.XtraPrinting",
                                                        "Imports System.Threading",
                                                        "Imports DevExpress.XtraTab",
                                                        "Imports DevExpress.XtraTab.ViewInfo",
                                                        "Imports DevExpress.XtraReports.UI",
                                                        "Imports DevExpress.XtraGrid.Columns",
                                                        "Imports DevExpress.XtraGrid.Controls",
                                                        "Imports DevExpress.XtraReports.Parameters",
                                                        "Imports System.Drawing",
                                                        "Imports DevExpress.XtraEditors.Repository",
                                                        "Imports DevExpress.XtraRichEdit",
                                                        "Imports DevExpress.XtraRichEdit.API.Native",
                                                        "Imports DevExpress.XtraRichEdit.Commands",
                                                        "Imports DevExpress.XtraRichEdit.Services",
                                                        "Imports DevExpress.XtraRichEdit.API.Layout",
                                                        "Imports DevExpress.Data",
                                                        "Imports DevExpress.Spreadsheet",
                                                        "Imports DevExpress.Office.Services",
                                                        "Imports DevExpress.XtraSpreadsheet.Export",
                                                        "Imports DevExpress.XtraEditors.DXErrorProvider",
                                                        "Imports DocumentFormat = DevExpress.Spreadsheet.DocumentFormat",
                                                        "Imports System.Net",
                                                        "Imports DevExpress.DataAccess.ConnectionParameters",
                                                        "Imports DevExpress.DataAccess.Sql",
                                                        "Imports DevExpress.Office.Utils",
                                                        "Imports DevExpress.XtraTreeList.ViewInfo",
                                                        "Imports DevExpress.Utils"
                                                         }

                For Each si As String In basicImportsStatement
                    If SourceCode.IndexOf(si) < 0 Then strUsingStatement += si & vbCrLf
                Next
            End If

            strRealSourceCode = strUsingStatement & SourceCode

            If Language = LanguageType.VB AndAlso EntryPoint = "Main" AndAlso strRealSourceCode.IndexOf("Sub Main(") < 0 Then

                Try
                    Dim posClass As Integer = strRealSourceCode.IndexOf("Public Class ") + "Public Class ".Length
                    Dim posClassEnd As Integer = strRealSourceCode.IndexOf(vbCrLf, posClass)
                    Dim className As String = strRealSourceCode.Substring(posClass, posClassEnd - posClass)
                    Dim pos As Integer = strRealSourceCode.LastIndexOf("End Class")
                    If pos > 0 Then strRealSourceCode = strRealSourceCode.Substring(0, pos) & "
										Private Shared Sub Main()
											" & "Dim frm As New " & className & "()" & "
											        If TypeOf frm Is Form Then frm.ShowDialog()
										End Sub
									" & strRealSourceCode.Substring(pos)

                Catch
                End Try
            End If

            Return strRealSourceCode
        End Function

        Private Function CreateAssembly(ByVal strRealSourceCode As String) As Assembly
            If strRealSourceCode.Length = 0 Then
                LogErrMsgs("Error:  There was no CS script code to compile")
                Return Nothing
            End If

            Dim codeProvider As CodeDomProvider = Nothing

            If Language = LanguageType.CSharp Then
                codeProvider = New CSharpCodeProvider()
            ElseIf Language = LanguageType.VB Then
                codeProvider = New VBCodeProvider()
            End If

            Dim compiler As ICodeCompiler = codeProvider.CreateCompiler()
            Dim compilerParams As CompilerParameters = New CompilerParameters()
            compilerParams.CompilerOptions = "/target:library"
            compilerParams.GenerateExecutable = False
            compilerParams.GenerateInMemory = True
            compilerParams.IncludeDebugInformation = False
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll")
            compilerParams.ReferencedAssemblies.Add("System.dll")
            compilerParams.ReferencedAssemblies.Add("System.Data.dll")
            compilerParams.ReferencedAssemblies.Add("System.Numerics.dll")
            compilerParams.ReferencedAssemblies.Add("System.Drawing.dll")
            compilerParams.ReferencedAssemblies.Add("System.Xml.dll")
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll")
            compilerParams.ReferencedAssemblies.Add("Microsoft.Office.Interop.Outlook.dll")
            compilerParams.ReferencedAssemblies.Add("CrystalDecisions.CrystalReports.Engine.dll")
            compilerParams.ReferencedAssemblies.Add("CrystalDecisions.ReportSource.dll")
            compilerParams.ReferencedAssemblies.Add("CrystalDecisions.Shared.dll")
            compilerParams.ReferencedAssemblies.Add("CrystalDecisions.Windows.Forms.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Dialogs.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraEditors.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.BonusSkins.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Charts.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.CodeParser.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Data.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.DataAccess.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Docs.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Images.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Office.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Pdf.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.PivotGrid.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Printing.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.RichEdit.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.RichEdit.v19.2.Export.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Sparkline.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Spreadsheet.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Utils.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Utils.v19.2.UI.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.Xpo.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraBars.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraCharts.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraCharts.v19.2.Extensions.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraCharts.v19.2.UI.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraCharts.v19.2.Wizard.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraDialogs.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraEditors.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraGauges.v19.2.Core.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraGrid.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraLayout.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraPivotGrid.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraPrinting.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraReports.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraReports.v19.2.Extensions.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraRichEdit.v19.2.dll")
            'compilerParams.ReferencedAssemblies.Add("DevExpress.XtraScheduler.v19.2.dll")
            'compilerParams.ReferencedAssemblies.Add("DevExpress.XtraScheduler.v19.2.Core.dll")
            'compilerParams.ReferencedAssemblies.Add("DevExpress.XtraScheduler.v19.2.Extensions.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraSpreadsheet.v19.2.dll")
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraTreeList.v19.2.dll")


            If Language = LanguageType.VB Then
                compilerParams.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            End If

            For Each refAssembly As String In References

                Try
                    compilerParams.ReferencedAssemblies.Add(refAssembly)
                Catch
                End Try
            Next

            Dim results As CompilerResults = compiler.CompileAssemblyFromSource(compilerParams, strRealSourceCode)

            If results.Errors.Count > 0 Then

                For Each [error] As CompilerError In results.Errors
                    LogErrMsgs("Compile Error:  " & [error].ErrorText)
                Next

                Return Nothing
            End If

            Dim generatedAssembly As Assembly = results.CompiledAssembly
            Return generatedAssembly
        End Function

        Private Sub CallEntry(ByVal assembly As Assembly, ByVal entryPoint As String)
            Try
                Dim mods As [Module]() = assembly.GetModules(False)
                Dim types As Type() = mods(0).GetTypes()

                For Each type As Type In types
                    Dim mi As MethodInfo = type.GetMethod(entryPoint, BindingFlags.[Public] Or BindingFlags.NonPublic Or BindingFlags.[Static])

                    If mi IsNot Nothing Then

                        If mi.GetParameters().Length = 1 Then

                            If mi.GetParameters()(0).ParameterType.IsArray Then
                                Dim par As String() = New String(0) {}
                                mi.Invoke(Nothing, par)
                            End If
                        Else
                            mi.Invoke(Nothing, Nothing)
                        End If

                        Return
                    End If
                Next

                LogErrMsgs("Engine could not find the public static " & entryPoint)
            Catch ex As Exception
                LogErrMsgs("ERROR:  An exception occurred", ex)
            End Try
        End Sub

        Friend errMsg As StringBuilder = New StringBuilder()

        Friend Sub LogErrMsgs(ByVal customMsg As String)
            LogErrMsgs(customMsg, Nothing)
        End Sub

        Friend Sub LogErrMsgs(ByVal customMsg As String, ByVal ex As Exception)
            errMsg.Append(vbCrLf).Append(customMsg).Append(vbCrLf)

            While ex IsNot Nothing
                errMsg.Append(vbTab).Append(ex.Message).Append(vbCrLf)
                ex = ex.InnerException
            End While
        End Sub

        Friend Sub ClearErrMsgs()
            errMsg.Remove(0, errMsg.Length)
        End Sub

        Friend Sub DisplayErrorMsg()
            If errMsg.Length > 0 Then
                XtraMessageBox.Show(errMsg.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                If CurrentProcedureName = Nothing Then
                    CurrentProcedureName = "VB_SCRIPT_EXECUTION"
                    CurrentSystemName = "VB_SCRIPT_EXECUTION"
                End If
                OpenVbScript_SqlConnection()
                cmdVbScript.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,@ProcName,@SystemName,@CurrentUserWindowsId)"
                cmdVbScript.Parameters.Add("@Event", SqlDbType.NVarChar).Value = errMsg.ToString()
                cmdVbScript.Parameters.Add("@ProcName", SqlDbType.NVarChar).Value = CurrentProcedureName
                cmdVbScript.Parameters.Add("@SystemName", SqlDbType.NVarChar).Value = CurrentSystemName
                cmdVbScript.Parameters.Add("@CurrentUserWindowsId", SqlDbType.NVarChar).Value = CurrentUserWindowsID
                cmdVbScript.ExecuteNonQuery()
                cmdVbScript.Parameters.Clear()
                CloseVbScript_SqlConnection()

                If CurrentSystemExecuting <> Nothing Then
                    Select Case CurrentSystemExecuting
                        Case = "PS TOOL CLIENT"
                            OpenVbScript_SqlConnection()
                            cmdVbScript.CommandText = "INSERT INTO [CLIENT EVENTS] ([ProcDate],[Event],[ProcName],[SystemName]) 
                                               Values((SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),@Event,@ProcName,@SystemName)"
                            cmdVbScript.Parameters.Add("@Event", SqlDbType.NVarChar).Value = "ERROR +++ " & errMsg.ToString()
                            cmdVbScript.Parameters.Add("@ProcName", SqlDbType.NVarChar).Value = CurrentProcedureName
                            cmdVbScript.Parameters.Add("@SystemName", SqlDbType.NVarChar).Value = CurrentSystemExecuting
                            cmdVbScript.ExecuteNonQuery()
                            cmdVbScript.Parameters.Clear()
                            CloseVbScript_SqlConnection()
                        Case Else
                            OpenVbScript_SqlConnection()
                            cmdVbScript.CommandText = "INSERT INTO [IMPORT EVENTS] ([ProcDate],[Event],[ProcName],[SystemName]) 
                                               Values((SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),@Event,@ProcName,@SystemName)"
                            cmdVbScript.Parameters.Add("@Event", SqlDbType.NVarChar).Value = "ERROR +++ " & errMsg.ToString()
                            cmdVbScript.Parameters.Add("@ProcName", SqlDbType.NVarChar).Value = CurrentProcedureName
                            cmdVbScript.Parameters.Add("@SystemName", SqlDbType.NVarChar).Value = CurrentSystemExecuting
                            cmdVbScript.ExecuteNonQuery()
                            cmdVbScript.Parameters.Clear()
                            CloseVbScript_SqlConnection()

                    End Select


                End If

            End If
        End Sub
    End Class
End Namespace
