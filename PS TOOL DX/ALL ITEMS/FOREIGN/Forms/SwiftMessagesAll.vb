Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
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
Imports CrystalDecisions.Shared
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports Microsoft.VisualBasic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports System.Drawing
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout


Public Class SwiftMessagesAll

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

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

    Private Sub ALL_SWIFT_MESSAGESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ALL_SWIFT_MESSAGESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.LcDataset)

    End Sub




    Private Sub SwiftMessagesAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LcDataset.EXPORT_LC_MT700_BD' table. You can move, or remove it, as needed.
        'Me.EXPORT_LC_MT700_BD_TableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_BD)

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        Dim d As Date = Today
        Me.DateFrom_DateEdit.Text = d
        Me.DateTill_DateEdit.Text = d
        Me.ALL_SWIFT_MESSAGESTableAdapter.FillByReceivedDate(Me.LcDataset.ALL_SWIFT_MESSAGES, d, d)
        Me.ALL_SWIFT_MESSAGESTableAdapter.SetCommandTimeOut(120000)

        'MATCHING MESSAGES
        If SUPER_USER = "Y" Then
            Me.GroupControl3.Visible = True
        Else
            Me.GroupControl3.Visible = False
        End If

    End Sub

    Private Sub SwiftMessagesAll_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.LayoutControl1.Visible = True
        End If
    End Sub

    Private Sub ApplyCustomFormatting(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
        For Each paragraph As Paragraph In document.Paragraphs
            Dim parRange As DocumentRange = paragraph.Range

            If document.GetText(parRange).TrimStart().StartsWith(":") Then
                Dim cp As CharacterProperties = document.BeginUpdateCharacters(parRange)
                cp.ForeColor = Color.White
                cp.BackColor = Color.DarkCyan
                document.EndUpdateCharacters(cp)
            End If
        Next
    End Sub

    Public Shared Sub ChangeTextcolor(textToMark As String, color As Color, richTextBox As RichTextBox, startIndex As Integer)
        If startIndex < 0 OrElse startIndex > textToMark.Length - 1 Then
            startIndex = 0
        End If

        Dim newFont As System.Drawing.Font = New Font("Verdana", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, False)
        Try
            For Each line As String In richTextBox.Lines
                If line.StartsWith(textToMark) Then
                    richTextBox.[Select](startIndex, line.Length)
                    richTextBox.SelectionBackColor = color
                End If
                startIndex += line.Length + 1
            Next
        Catch
        End Try
    End Sub



    Private Sub SearchMessages_btn_Click(sender As Object, e As EventArgs) Handles SearchMessages_btn.Click
        Dim d1 As Date = Me.DateFrom_DateEdit.Text
        Dim d2 As Date = Me.DateTill_DateEdit.Text
        If d2 >= d1 Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Incoming Swift Messages from " & d1 & " till " & d2)
                Me.ALL_SWIFT_MESSAGESTableAdapter.FillByReceivedDate(Me.LcDataset.ALL_SWIFT_MESSAGES, d1, d2)
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

        Else
            MessageBox.Show("Date From is higher than Date Till!" & vbNewLine & "Please input correct Dates!", "WRONG DATES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Me.LayoutControl1.Visible = False
        'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
        'Me.SwiftMessageFormated_RichTextBox.Clear()
        'Me.SwiftMessageFormated_RichTextBox.Text = s
        'Me.SwiftMessageFormated_RichTextBox.DataBindings.Clear()
        'Me.SwiftMessageFormated_RichTextBox.DataBindings.Add("Text", LcDataset.ALL_SWIFT_MESSAGES, "Swift_Message_Formated")
        'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
        ApplyCustomFormatting(Me.RichEditControl1.Document)

    End Sub




    Private Sub AllMsg_btn_Click(sender As Object, e As EventArgs) Handles AllMsg_btn.Click
            Me.LayoutControl1.Visible = True



        End Sub

        Private Sub AllSwiftMessages_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllSwiftMessages_BaseView.RowStyle
            If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                e.Appearance.BackColor = SystemColors.InactiveCaptionText

            End If
        End Sub

        Private Sub AllSwiftMessages_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AllSwiftMessages_BaseView.ShownEditor
            Dim view As GridView = CType(sender, GridView)
            If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
            End If
        End Sub

        Private Sub Print_Export_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridView_btn.Click
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
            Dim reportfooter As String = "INCOMING SWIFT MESSAGES from " & Me.DateFrom_DateEdit.Text & " till " & Me.DateTill_DateEdit.Text
            e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        End Sub

        Private Sub SwiftMsgPrint_btn_Click(sender As Object, e As EventArgs) Handles SwiftMsgPrint_btn.Click
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Printform for Message Ref. " & Me.Ref20_TextEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\SWIFT_MSG_INCOMING.rpt")
            'Dim r As New ObligoLiabilitySurplus
            CrRep.SetDataSource(LcDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = Me.ID_lbl.Text
            myParams.ParameterFieldName = "ID"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "SWIFT MESSAGE ID " & Me.ID_lbl.Text
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End Sub

        Private Sub OurReferenceSearch_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.Click

            Me.EXPORT_LC_MT700_BD_TableAdapter.FillByCustomerSearchStoredProcedure(Me.LcDataset.EXPORT_LC_MT700_BD)
        End Sub

        Private Sub OurReferenceSearch_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OurReferenceSearch_GridLookUpEditView.RowStyle
            If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                e.Appearance.BackColor = SystemColors.InactiveCaptionText
            End If
        End Sub

        Private Sub OurReferenceSearch_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEditView.ShownEditor
            Dim view As GridView = CType(sender, GridView)
            If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
            End If
        End Sub

        Private Sub MatchSwiftMessage_btn_Click(sender As Object, e As EventArgs) Handles MatchSwiftMessage_btn.Click
            If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" Then
                If MessageBox.Show("Should the current Swift Message be matched with Export LC Reference " & Me.OurReferenceSearch_GridLookUpEdit.Text & " ? ", "MATCHING SWIFT MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "INSERT INTO [EXPORT_LC_MT700_RM] ([SwiftFileName],[Ref20],[Ref21],[MessageType],[MessageTypeName],[SenderBIC],[SenderName],[SenderBranch],[ReceivedDate],[OSN],[Swift_Message],[Swift_Message_Formated],[OSN_ReceivedDate],[Id_OurReference])Select [SwiftFileName],[Ref20],[Ref21],[MessageType],[MessageTypeName],[SenderBIC],[SenderName],[SenderBranch],[ReceivedDate],[OSN],[Swift_Message],[Swift_Message_Formated],[OSN_ReceivedDate],'" & Me.OurReferenceSearch_GridLookUpEdit.Text & "' from [ALL_SWIFT_MESSAGES]  where [OSN_ReceivedDate]='" & Me.OSN_ReceivedDateLabel1.Text & "' and [OSN_ReceivedDate] not in (Select [OSN_ReceivedDate] from [EXPORT_LC_MT700_RM])"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    MessageBox.Show("The Swift message has being matched with Export LC Reference " & Me.OurReferenceSearch_GridLookUpEdit.Text, "SWIFT MESSAGE MATCHED WITH SUCESS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                End If
            End If

        End Sub


    End Class