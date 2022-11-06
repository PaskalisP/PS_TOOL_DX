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
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout


Public Class ChargesRequests

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New System.Data.DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New System.Data.DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable

    Dim CrystalRepDir As String = ""
    Dim IDNrRowValue As Integer
    Dim IDNrTotalRowValue As Integer

    Dim query As New CustomSqlQuery()


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



    Private Sub ChargesRequests_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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

        'Dim d As Date = Today
        'Me.DateFrom_DateEdit.Text = d
        'Me.DateTill_DateEdit.Text = d
        Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES)
        Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details)
        LOAD_ALL_RELATED_PAYMENTS()
        Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.SetCommandTimeOut(120000)

        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "AddPO" Then
            Me.GridControl3.Visible = False
            Me.Our_PO_Reference_TextEdit.Focus()

        End If

        If e.Button.Tag = "Delete" Then
            If PaymentDetails_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the Payment Order be deleted from the Charges Details ? ", "DELETE PAYMENT ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Payment Order details...")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "DELETE FROM [ALL_SWIFT_CHARGES_MESSAGES_Details] where [ID]=" & IDNrRowValue & ""
                        cmd.ExecuteNonQuery()
                        'Try to update Match Status based on Reference 20-21
                        cmd.CommandText = "UPDATE A SET A.MatchedStatus='Y' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES_Details B on A.ID=B.Id_Charges where MatchedStatus='N' and A.ID=" & ID_lbl.Text & ""
                        cmd.ExecuteNonQuery()
                        'Try Update Match Status based on the Charges Sum
                        cmd.CommandText = "UPDATE A SET A.MatchedStatus='Y' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES_Details B on A.ID=B.Id_Charges where MatchedStatus='N' and A.Amount=(Select Sum([RequestedChargesAmount]) from ALL_SWIFT_CHARGES_MESSAGES_Details where Id_Charges=" & ID_lbl.Text & ") and A.ID=" & ID_lbl.Text & ""
                        cmd.ExecuteNonQuery()
                        'Set Match Status to N if no match
                        cmd.CommandText = "UPDATE ALL_SWIFT_CHARGES_MESSAGES SET MatchedStatus='N' where NOT EXISTS (Select * from ALL_SWIFT_CHARGES_MESSAGES_Details where Id_Charges=" & ID_lbl.Text & ") and [ID]=" & ID_lbl.Text & ""
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        'Load Data
                        Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.FillByID(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES, Me.ID_lbl.Text)
                        Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.FillByID_Charges(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details, Me.ID_lbl.Text)
                        'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
                        'Me.SwiftMessageFormated_RichTextBox.Clear()
                        'Me.SwiftMessageFormated_RichTextBox.Text = s
                        'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
                        ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
                        STATUS_CHECK()
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If

        End If

        If e.Button.Tag = "Reset" Then
            If MessageBox.Show("Should the Payment Order details be reseted ?" & vbNewLine & "Attention:All related Payment Orders will be deleted!!", "RESET PAYMENT ORDER DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Reset all related Payment Order details...")
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "DELETE FROM [ALL_SWIFT_CHARGES_MESSAGES_Details] where [ID]=" & IDNrRowValue & ""
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ALL_SWIFT_CHARGES_MESSAGES_Details]([OurReference],[RelatedPayment],[PaymentType],[ReceiverBIC],[ValueDate],[CCY],[Amount],[DetailsOfCharges],[Id_Charges])Select A.OURTRANREFNO,A.EM00KEY1,A.METHOD,A.RECEIVERSWIFT,A.VALUEDATE,A.CURRENCYCODE,A.[Deal Amount],A.DETOFCHARGE,B.ID from [ODAS REMMITANCES] A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES B on A.OURTRANREFNO=B.Ref21 where A.OURTRANREFNO='" & Me.Ref21_TextEdit.Text & "' and  INWARDOUTWARD in ('O') and A.OURTRANREFNO not in  (Select OurReference from [ALL_SWIFT_CHARGES_MESSAGES_Details])"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.MatchedStatus='Y' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES_Details B on A.ID=B.Id_Charges where MatchedStatus='N' and A.ID=" & ID_lbl.Text & ""
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[RequestedChargesCurrency]=B.CCY,A.[RequestedChargesAmount]=B.Amount from ALL_SWIFT_CHARGES_MESSAGES_Details A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES B on A.Id_Charges=B.ID where B.MatchedStatus in ('Y') and A.[RequestedChargesCurrency] IS NULL and B.ID=" & ID_lbl.Text & ""
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    'Load Data
                    Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.FillByID(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES, Me.ID_lbl.Text)
                    Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.FillByID_Charges(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details, Me.ID_lbl.Text)
                    'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
                    'Me.SwiftMessageFormated_RichTextBox.Clear()
                    'Me.SwiftMessageFormated_RichTextBox.Text = s
                    'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
                    ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
                    STATUS_CHECK()
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If
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

    Private Sub LOAD_ALL_RELATED_PAYMENTS()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT  A.[ID],A.[OurReference],A.[RelatedPayment],A.[PaymentType],A.[ReceiverBIC],A.[ValueDate],A.[CCY],A.[Amount],A.[DetailsOfCharges],A.[PayedStatus],A.[RequestedChargesCurrency],A.[RequestedChargesAmount],A.[Id_Charges],B.Ref20 as 'MT191_Reference_20',B.SenderBIC as 'SenderBIC' FROM [ALL_SWIFT_CHARGES_MESSAGES_Details] A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES B on A.Id_Charges=B.ID"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl4.DataSource = Nothing
        Me.GridControl4.DataSource = ds
        Me.GridControl4.DataMember = "customQuery1"
        Me.GridControl4.ForceInitialize()
        Me.GridControl4.RefreshDataSource()
    End Sub


    Private Sub UPDATE_ALL_SWIFT_CHARGES_MESSAGES()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.Parameters.Clear()
        cmd.CommandText = "UPDATE ALL_SWIFT_CHARGES_MESSAGES SET MatchedStatus=@MatchedStatus,PayedStatus=@PayedStatus,PayedDate=@PayedDate,[PayedReference]=@PayedReference,[Notes]=@Notes,[LastUpdate]=@LastUpdate where ID=" & Me.ID_lbl.Text & ""
        cmd.Parameters.Add("@MatchedStatus", SqlDbType.NVarChar).Value = Me.Matched_ImageComboBoxEdit.EditValue
        cmd.Parameters.Add("@PayedStatus", SqlDbType.NVarChar).Value = Me.Payed_ImageComboBoxEdit.EditValue
        cmd.Parameters.Add("@PayedDate", SqlDbType.DateTime).Value = Me.PaymentDate_DateEdit.EditValue
        cmd.Parameters.Add("@PayedReference", SqlDbType.NVarChar).Value = Me.PaymentReference_TextEdit.EditValue
        cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = Me.DetailsOfCharges_TextEdit.EditValue
        cmd.Parameters.Add("@LastUpdate", SqlDbType.NVarChar).Value = "Last Update from " & SystemInformation.UserName & " on " & Now
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        cmd.CommandText = "UPDATE A SET A.PayedStatus='Y' from [ALL_SWIFT_CHARGES_MESSAGES_Details] A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES B on A.Id_Charges=B.ID where B.[PayedStatus] in ('Y') and B.ID=" & ID_lbl.Text & ""
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.PayedStatus='N' from [ALL_SWIFT_CHARGES_MESSAGES_Details] A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES B on A.Id_Charges=B.ID where B.[PayedStatus] in ('N') and B.ID=" & ID_lbl.Text & ""
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub STATUS_CHECK()
        Dim MatchedStatus As String = Me.Matched_ImageComboBoxEdit.EditValue
        Select Case MatchedStatus
            Case = "C"
                Me.Payed_ImageComboBoxEdit.EditValue = "N"
                Me.Payed_ImageComboBoxEdit.ReadOnly = True
                Me.PaymentDate_DateEdit.EditValue = DBNull.Value
                Me.PaymentDate_DateEdit.ReadOnly = True
            Case = "D"
                Me.Payed_ImageComboBoxEdit.ReadOnly = True
                Me.PaymentDate_DateEdit.EditValue = DBNull.Value
                Me.PaymentDate_DateEdit.ReadOnly = True
            Case Else
                Me.Payed_ImageComboBoxEdit.ReadOnly = False
        End Select

        Dim PayedStatus As String = Me.Payed_ImageComboBoxEdit.EditValue
        Select Case PayedStatus
            Case = "Y"
                Me.PaymentDate_DateEdit.ReadOnly = False
                Me.PaymentReference_TextEdit.ReadOnly = False
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = False
            Case = "N"
                Me.PaymentDate_DateEdit.ReadOnly = True
                Me.PaymentReference_TextEdit.ReadOnly = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = True
        End Select

    End Sub

    Private Sub STATUS_PAYMENTS_CHECK()
        Dim PayedStatus As String = Me.Payed_ImageComboBoxEdit.EditValue
        Select Case PayedStatus
            Case = "Y"
                Me.PaymentDate_DateEdit.ReadOnly = True
                Me.PaymentReference_TextEdit.ReadOnly = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = False
            Case = "N"
                Me.PaymentDate_DateEdit.ReadOnly = True
                Me.PaymentReference_TextEdit.ReadOnly = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
                Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = True
        End Select
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

    Private Sub ChargesRequests_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If LayoutControl1.Visible = False Then
                Me.AllMsg_btn.PerformClick()
            End If
        End If

        If e.KeyCode = Keys.F5 Then
            If LayoutControl1.Visible = True Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Loading...")
                Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES)
                Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details)
                LOAD_ALL_RELATED_PAYMENTS()
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub
    'Private Sub SearchMessages_btn_Click(sender As Object, e As EventArgs) Handles SearchMessages_btn.Click
    '    Dim d1 As Date = Me.DateFrom_DateEdit.Text
    '    Dim d2 As Date = Me.DateTill_DateEdit.Text
    '    If d2 >= d1 Then
    '        Try
    '            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '            SplashScreenManager.Default.SetWaitFormCaption("Load Incoming Charges Requests from " & d1 & " till " & d2)
    '            Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.FillByReceivedDate(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES, d1, d2)
    '            Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details)
    '            SplashScreenManager.CloseForm(False)
    '        Catch ex As Exception
    '            SplashScreenManager.CloseForm(False)
    '            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Exit Sub
    '        End Try

    '    Else
    '        MessageBox.Show("Date From is higher than Date Till!" & vbNewLine & "Please input correct Dates!", "WRONG DATES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        Exit Sub

    '    End If
    'End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.FillByID(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES, IDNrTotalRowValue)
        Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.FillByID_Charges(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details, IDNrTotalRowValue)
        Me.LayoutControl1.Visible = False
        'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
        'Me.SwiftMessageFormated_RichTextBox.Clear()
        'Me.SwiftMessageFormated_RichTextBox.Text = s
        'Me.SwiftMessageFormated_RichTextBox.DataBindings.Clear()
        'Me.SwiftMessageFormated_RichTextBox.DataBindings.Add("Text", LcDataset.ALL_SWIFT_MESSAGES, "Swift_Message_Formated")
        'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
        ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
        STATUS_CHECK()
        STATUS_PAYMENTS_CHECK()
    End Sub

    Private Sub AllMsg_btn_Click(sender As Object, e As EventArgs) Handles AllMsg_btn.Click
        UPDATE_ALL_SWIFT_CHARGES_MESSAGES()

        Me.LayoutControl1.Visible = True
        'Dim d1 As Date = Me.DateFrom_DateEdit.Text
        'Dim d2 As Date = Me.DateTill_DateEdit.Text
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Loading...")
            Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES)
            Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.Fill(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details)
            LOAD_ALL_RELATED_PAYMENTS()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

    Private Sub AllSwiftMessages_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllSwiftMessages_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub AllSwiftMessages_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AllSwiftMessages_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
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
        Dim reportfooter As String = "INCOMING CHARGES REQUESTS MT191/991" '& Me.DateFrom_DateEdit.Text & " till " & Me.DateTill_DateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ViewEdit_btn_Click(sender As Object, e As EventArgs) Handles ViewEdit_btn.Click
        If Not GridControl4.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "Related Payment Orders to the incoming Charges Requests" '& Me.DateFrom_DateEdit.Text & " till " & Me.DateTill_DateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SwiftMsgPrint_btn_Click(sender As Object, e As EventArgs) Handles SwiftMsgPrint_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Printform for Message Ref. " & Me.Ref20_TextEdit.Text)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\CHARGES_REQUEST_INCOMING.rpt")
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
        c.Text = "SWIFT CHARGES REQUEST MESSAGE ID " & Me.ID_lbl.Text
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub OurReferenceSearch_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OurReferenceSearch_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PaymentDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PaymentDetails_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PaymentDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles PaymentDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AllRelatedPayments_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllRelatedPayments_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllRelatedPayments_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AllRelatedPayments_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Related_Payments_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Related_Payments_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Related_Payments_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Related_Payments_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub MatchSwiftMessage_btn_Click(sender As Object, e As EventArgs) Handles MatchSwiftMessage_btn.Click
        If Me.Our_PO_Reference_TextEdit.Text <> "" And Me.RequestedChargesAmount_TextEdit.EditValue <> 0 Then
            If MessageBox.Show("Should the details for Payment Order: " & Our_PO_Reference_TextEdit.Text & " be inserted to the current Charges Request ? ", "ADD PAYMENT ORDER TO CHARGES REQUEST", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Data for Payment Order: " & Our_PO_Reference_TextEdit.Text)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select ID from [ODAS REMMITANCES] where OURTRANREFNO='" & Our_PO_Reference_TextEdit.Text & "'"
                    If IsNothing(cmd.ExecuteScalar) = False Then
                        cmd.CommandText = "Select ID from [ALL_SWIFT_CHARGES_MESSAGES_Details] where OurReference='" & Our_PO_Reference_TextEdit.Text & "'"
                        If IsNothing(cmd.ExecuteScalar) = True Then
                            cmd.CommandText = "Select ID from [ODAS REMMITANCES] where OURTRANREFNO='" & Our_PO_Reference_TextEdit.Text & "' and INWARDOUTWARD in ('I')"
                            If IsNothing(cmd.ExecuteScalar) = True Then
                                cmd.CommandText = "INSERT INTO [ALL_SWIFT_CHARGES_MESSAGES_Details]([OurReference],[RelatedPayment],[PaymentType],[ReceiverBIC],[ValueDate],[CCY],[Amount],[DetailsOfCharges],[RequestedChargesCurrency],[RequestedChargesAmount],[Id_Charges]) Select OURTRANREFNO,Case when EM00KEY1 is not NULL then EM00KEY1 else OURTRANREFNO end ,METHOD,RECEIVERSWIFT,VALUEDATE,CURRENCYCODE,[Deal Amount],DETOFCHARGE,'" & Me.RequestedCurrency_SearchLookUpEdit.Text & "','" & Str(Me.RequestedChargesAmount_TextEdit.Text) & "'," & ID_lbl.Text & " from [ODAS REMMITANCES] where OURTRANREFNO='" & Our_PO_Reference_TextEdit.Text & "' and INWARDOUTWARD in ('O') and NOT EXISTS (Select * from [ALL_SWIFT_CHARGES_MESSAGES_Details] where [OurReference]='" & Our_PO_Reference_TextEdit.Text & "')"
                                cmd.ExecuteNonQuery()
                                'Try to update Match Status based on Reference 20-21
                                cmd.CommandText = "UPDATE A SET A.MatchedStatus='Y' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES_Details B on A.ID=B.Id_Charges where MatchedStatus='N' and A.ID=" & ID_lbl.Text & ""
                                cmd.ExecuteNonQuery()
                                'Try Update Match Status based on the Charges Sum
                                cmd.CommandText = "UPDATE A SET A.MatchedStatus='Y' from ALL_SWIFT_CHARGES_MESSAGES A INNER JOIN ALL_SWIFT_CHARGES_MESSAGES_Details B on A.ID=B.Id_Charges where MatchedStatus='N' and A.Amount=(Select Sum([RequestedChargesAmount]) from ALL_SWIFT_CHARGES_MESSAGES_Details where Id_Charges=" & ID_lbl.Text & ") and A.ID=" & ID_lbl.Text & ""
                                cmd.ExecuteNonQuery()
                                'Load Data
                                Me.ALL_SWIFT_CHARGES_MESSAGESTableAdapter.FillByID(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES, Me.ID_lbl.Text)
                                Me.ALL_SWIFT_CHARGES_MESSAGES_DetailsTableAdapter.FillByID_Charges(Me.ClearingDataSet.ALL_SWIFT_CHARGES_MESSAGES_Details, Me.ID_lbl.Text)
                                'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
                                'Me.SwiftMessageFormated_RichTextBox.Clear()
                                'Me.SwiftMessageFormated_RichTextBox.Text = s
                                'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
                                ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
                                STATUS_CHECK()
                                SplashScreenManager.CloseForm(False)
                                '+++++++++++++++++++++++++++
                                MessageBox.Show("The Payment Order " & Our_PO_Reference_TextEdit.Text & " are  imported to the Payment Details", "SUCCESSFUL PAYMENT ORDER IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.Our_PO_Reference_TextEdit.Text = ""
                                Me.RequestedChargesAmount_TextEdit.EditValue = 0
                                Return
                            Else
                                SplashScreenManager.CloseForm(False)
                                MessageBox.Show("The Payment Order " & Our_PO_Reference_TextEdit.Text & " is an incoming Payment!", "UNABLE TO IMPORT THE PAYMENT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Return
                            End If


                        Else
                            Me.QueryText = "Select Ref20,SenderBIC,CONVERT(Varchar(10),ReceivedDate,104) as 'ReceivedDate',
                                            'MathedStatus'=Case when MatchedStatus in ('Y') then 'MATCHED' when MatchedStatus in ('N') then 'NOT MATCHED' when MatchedStatus in ('C') then 'CANCELLED' end,
                                            'PayedStatus'=Case when PayedStatus  in ('Y') then 'PAYED' when PayedStatus  in ('N') then 'NOT PAYED' end
                                            from ALL_SWIFT_CHARGES_MESSAGES 
                                            where ID in ( Select Id_Charges from [ALL_SWIFT_CHARGES_MESSAGES_Details] where OurReference='" & Our_PO_Reference_TextEdit.Text & "')"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            SplashScreenManager.CloseForm(False)
                            MessageBox.Show("The Payment Order " & Our_PO_Reference_TextEdit.Text & " is allready in the Charges Request imported" _
                                            & vbNewLine & "Check Charges Request Reference: " & dt.Rows.Item(0).Item("Ref20").ToString _
                                            & vbNewLine & "Received from " & dt.Rows.Item(0).Item("SenderBIC").ToString _
                                            & vbNewLine & "on " & dt.Rows.Item(0).Item("ReceivedDate").ToString _
                                            & vbNewLine & "Matched Status: " & dt.Rows.Item(0).Item("MathedStatus").ToString _
                                            & vbNewLine & "Payed Status: " & dt.Rows.Item(0).Item("PayedStatus").ToString, "UNABLE TO IMPORT THE PAYMENT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.DetailsOfCharges_TextEdit.EditValue = "The Payment Order " & Our_PO_Reference_TextEdit.Text & " is allready in the Charges Request imported" _
                                            & vbNewLine & "Check Charges Request Reference: " & dt.Rows.Item(0).Item("Ref20").ToString _
                                            & vbNewLine & "Received from " & dt.Rows.Item(0).Item("SenderBIC").ToString _
                                            & vbNewLine & "on " & dt.Rows.Item(0).Item("ReceivedDate").ToString _
                                            & vbNewLine & "Matched Status: " & dt.Rows.Item(0).Item("MathedStatus").ToString _
                                            & vbNewLine & "Payed Status: " & dt.Rows.Item(0).Item("PayedStatus").ToString
                            Return
                        End If

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                    Else
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show("The indicated Payment Order reference " & Our_PO_Reference_TextEdit.Text & " is not present in the ODAS REMMITANCES Table!", "UNABLE TO IMPORT THE PAYMENT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If

                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If
        Else
            MessageBox.Show("Please enter the Internal Payment Orders Reference and/or " & vbNewLine & " the requested Charges Amount!", "PAYMENT ORDER REFERENCE/CHARGES AMOUNT IS EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub Cancel_SimpleButton_Click(sender As Object, e As EventArgs) Handles Cancel_SimpleButton.Click
        Me.Our_PO_Reference_TextEdit.Text = ""
        Me.GridControl3.Visible = True
    End Sub

    Private Sub PaymentDetails_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles PaymentDetails_GridView.RowClick
        If PaymentDetails_GridView.IsFilterRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            IDNrRowValue = view.GetFocusedRowCellValue("ID")
        End If
    End Sub



    Private Sub AllSwiftMessages_BaseView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles AllSwiftMessages_BaseView.RowClick
        If AllSwiftMessages_BaseView.IsFilterRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            IDNrTotalRowValue = view.GetFocusedRowCellValue("ID")
        End If
    End Sub



    Private Sub Payed_ImageComboBoxEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Payed_ImageComboBoxEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            Dim PayedStatus As String = Me.Payed_ImageComboBoxEdit.EditValue

            Select Case PayedStatus
                Case = "Y"
                    Me.PaymentDate_DateEdit.ReadOnly = False
                    Me.PaymentDate_DateEdit.EditValue = Today
                    Me.PaymentReference_TextEdit.ReadOnly = False
                    Me.PaymentReference_TextEdit.Focus()
                    Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False
                    Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
                    Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = False
                Case = "N"
                    Me.PaymentDate_DateEdit.EditValue = DBNull.Value
                    Me.PaymentDate_DateEdit.ReadOnly = True
                    Me.PaymentReference_TextEdit.EditValue = DBNull.Value
                    Me.PaymentReference_TextEdit.ReadOnly = True
                    Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
                    Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
                    Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = True
            End Select

            UPDATE_ALL_SWIFT_CHARGES_MESSAGES()

        End If
    End Sub



    Private Sub Matched_ImageComboBoxEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Matched_ImageComboBoxEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            Dim MatchedStatus As String = Me.Matched_ImageComboBoxEdit.EditValue
            Select Case MatchedStatus
                Case = "C"
                    Me.Payed_ImageComboBoxEdit.EditValue = "N"
                    Me.Payed_ImageComboBoxEdit.ReadOnly = True
                    Me.PaymentDate_DateEdit.EditValue = DBNull.Value
                    Me.PaymentDate_DateEdit.ReadOnly = True
                Case = "D"
                    Me.Payed_ImageComboBoxEdit.ReadOnly = True
                    Me.PaymentDate_DateEdit.EditValue = DBNull.Value
                    Me.PaymentDate_DateEdit.ReadOnly = True
                Case Else
                    Me.Payed_ImageComboBoxEdit.ReadOnly = False
            End Select
            UPDATE_ALL_SWIFT_CHARGES_MESSAGES()

        End If
    End Sub

    Private Sub PaymentDate_DateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PaymentDate_DateEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            UPDATE_ALL_SWIFT_CHARGES_MESSAGES()
        End If
    End Sub

    Private Sub DetailsOfCharges_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DetailsOfCharges_TextEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            UPDATE_ALL_SWIFT_CHARGES_MESSAGES()
        End If
    End Sub

    Private Sub PaymentReference_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PaymentReference_TextEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            UPDATE_ALL_SWIFT_CHARGES_MESSAGES()
        End If
    End Sub
End Class