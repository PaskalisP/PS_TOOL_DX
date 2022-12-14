Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.CodeDom.Compiler
Imports System.Reflection
Imports System.IO
Namespace PAB.Util
    Public Class EvalProvider
        Public Function Eval(ByVal vbCode As String) As Object
            Dim c As VBCodeProvider = New VBCodeProvider
            Dim icc As ICodeCompiler = c.CreateCompiler()
            Dim cp As CompilerParameters = New CompilerParameters

            cp.ReferencedAssemblies.Add("system.dll")
            cp.ReferencedAssemblies.Add("system.xml.dll")
            cp.ReferencedAssemblies.Add("system.data.dll")
            ' Sample code for adding your own referenced assemblies
            'cp.ReferencedAssemblies.Add("c:\yourProjectDir\bin\YourBaseClass.dll")
            cp.ReferencedAssemblies.Add("Ionic.Zip.dll")
            cp.ReferencedAssemblies.Add("itextsharp.dll")
            cp.ReferencedAssemblies.Add("Office.dll")
            cp.ReferencedAssemblies.Add("Interop.Shell32.dll")
            cp.ReferencedAssemblies.Add("Microsoft.Office.Interop.Excel.dll")
            cp.ReferencedAssemblies.Add("Microsoft.Office.Interop.Outlook.dll")
            cp.CompilerOptions = "/t:library"
            cp.GenerateInMemory = True
            Dim sb As StringBuilder = New StringBuilder("")
            sb.Append("Imports System" & vbCrLf)
            sb.Append("Imports System.Xml" & vbCrLf)
            sb.Append("Imports System.Data" & vbCrLf)
            sb.Append("Imports System.Data.SqlClient" & vbCrLf)
            sb.Append("Imports System.Text" & vbCrLf)
            sb.Append("Imports DevExpress.Spreadsheet" & vbCrLf)
            sb.Append("Imports System.Threading" & vbCrLf)
            sb.Append("Imports Ionic.Zip" & vbCrLf)
            sb.Append("Namespace PAB  " & vbCrLf)
            sb.Append("Class PABLib " & vbCrLf)

            sb.Append("public function  EvalCode() as Object " & vbCrLf)
            'sb.Append("YourNamespace.YourBaseClass thisObject = New YourNamespace.YourBaseClass()")
            sb.Append(vbCode & vbCrLf)
            sb.Append("End Function " & vbCrLf)
            sb.Append("End Class " & vbCrLf)
            sb.Append("End Namespace" & vbCrLf)
            Debug.WriteLine(sb.ToString()) ' look at this to debug your eval string
            Dim cr As CompilerResults = icc.CompileAssemblyFromSource(cp, sb.ToString())
            Dim a As System.Reflection.Assembly = cr.CompiledAssembly
            Dim o As Object
            Dim mi As MethodInfo
            o = a.CreateInstance("PAB.PABLib")
            Dim t As Type = o.GetType()
            mi = t.GetMethod("EvalCode")
            Dim s As Object
            s = mi.Invoke(o, Nothing)
            Return s
        End Function
    End Class
End Namespace
