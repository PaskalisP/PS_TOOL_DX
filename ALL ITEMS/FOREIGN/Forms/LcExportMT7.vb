Imports System
Imports System.IO
Imports System.Data.OleDb
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
Imports System.Web.Mail
Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class LcExportMT7

    Dim conn As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim connSQL As New SqlConnection
    Dim cmdSQL As New SqlCommand

    Private QueryText As String = ""
    Private da As New OleDbDataAdapter
    Private dt As New DataTable
    Private da1 As New OleDbDataAdapter
    Private dt1 As New DataTable

    Private daSql As New SqlDataAdapter
    Private dtSql As New DataTable

    Dim CrystalRepDir As String = ""
    Dim OUR_REFERENCE As String = Nothing
    Dim OurReferenceSearch As String = Nothing
    Dim RelatedCustomerID As String = Nothing

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

    Private Sub EXPORT_LC_MT700BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EXPORT_LC_MT700BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.LcDataset)

    End Sub

    Private Sub LcExportMT7_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = My.Settings.PSTOOLConnectionString_OLEDB
        cmd.Connection = conn

        connSQL.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdSQL.Connection = connSQL

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)

        Me.TreeList1.OptionsDragAndDrop.DragNodesMode = True

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

    Private Sub SAVE_ALL_CHANGES()
        Try
            Me.Validate()
            Me.EXPORT_LC_MT700BindingSource.EndEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.EndEdit()
            'Me.EXPORT_LC_MT700_RMTableAdapter.Update(Me.LcDataset)
            Me.TableAdapterManager.UpdateAll(Me.LcDataset)
            Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
            Me.SwiftMessageFormated_RichTextBox.Clear()
            Me.SwiftMessageFormated_RichTextBox.Text = s
            ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

#Region "OUR REFERENCE SEARCH"

    Private Sub OurReferenceSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.EditValueChanged
        If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" AndAlso Me.OurReferenceSearch_GridLookUpEdit.Text.ToString.StartsWith("DEFF") = True Then
            Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            OurReferenceSearch = Me.OurReferenceSearch_GridLookUpEdit.Text

            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = True
            LC_RELATED_DATAXtraTabPage.PageVisible = True
            LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
            LC_LIST_XtraTabPage.PageVisible = False
            Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
            Me.XtraTabControl2.Focus()
            FILL_ALL_DATA_BY_OUR_REFERENCE()
            Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
            Me.SwiftMessageFormated_RichTextBox.Clear()
            Me.SwiftMessageFormated_RichTextBox.Text = s
            ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
            RelatedCustomerID = Me.RelatedCustomerID_lbl.Text

            If Me.AdvicedStatus_CheckEdit.EditValue = True Then

                ADVICE_STATUS_DISABLED()
            Else
                ADVICE_STATUS_ENABLED()
            End If
        End If
    End Sub
    Private Sub OurReferenceSearch_GridLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles OurReferenceSearch_GridLookUpEdit.ButtonClick
        If e.Button.Caption = "Search" Then
            If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" Then
                Me.EXPORT_LC_MT700BindingSource.CancelEdit()
                Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
                OurReferenceSearch = Me.OurReferenceSearch_GridLookUpEdit.Text

                Me.XtraTabControl2.Visible = True
                LC_BASIC_DATAXtraTabPage.PageVisible = True
                LC_RELATED_DATAXtraTabPage.PageVisible = True
                LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
                LC_LIST_XtraTabPage.PageVisible = False
                Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
                Me.XtraTabControl2.Focus()
                FILL_ALL_DATA_BY_OUR_REFERENCE()
                Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
                Me.SwiftMessageFormated_RichTextBox.Clear()
                Me.SwiftMessageFormated_RichTextBox.Text = s
                ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
                RelatedCustomerID = Me.RelatedCustomerID_lbl.Text

                If Me.AdvicedStatus_CheckEdit.EditValue = True Then
                    ADVICE_STATUS_DISABLED()
                Else
                    ADVICE_STATUS_ENABLED()
                End If
            End If
        End If
        If e.Button.Caption = "Add" Then
            Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            Me.OurReferenceSearch_GridLookUpEdit.Text = ""
            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = False
            LC_RELATED_DATAXtraTabPage.PageVisible = False
            LC_MANUAL_INPUT_XtraTabPage.PageVisible = True
            LC_LIST_XtraTabPage.PageVisible = False
            '*************************************************************
            'Fill Currency Codes in LC Currency Combo
            Me.M_LC_Currency_TextEdit.Properties.Items.Clear()
            Me.QueryText = "Select [CURRENCY CODE] from [OWN_CURRENCIES] where [VALID]='Y' order by [CURRENCY CODE] asc "
            daSql = New SqlDataAdapter(Me.QueryText.Trim(), connSQL)
            dtSql = New System.Data.DataTable()
            daSql.Fill(dtSql)
            For Each row As DataRow In dtSql.Rows
                If dtSql.Rows.Count > 0 Then
                    Me.M_LC_Currency_TextEdit.Properties.Items.Add(row("CURRENCY CODE"))
                End If
            Next
            ADVICE_STATUS_ENABLED()
            'If dt.Rows.Count > 0 Then
            'M_LC_Currency_TextEdit.Text = dt.Rows.Item(0).Item("CURRENCY CODE")
            'End If
            '***********************************************************
        End If
        If e.Button.Caption = "Load Export LC List" Then
            Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            Me.OurReferenceSearch_GridLookUpEdit.Text = ""
            Me.XtraTabControl2.Visible = False
            '+++++++++++++++++++++++++++++++++++++++++++
            Me.ExportLC_List_GridControl.DataSource = Nothing
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading all Export LC's")
            Try
                Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using sqlCmd As New SqlCommand()
                        sqlCmd.CommandText = "SELECT [ID],[SwiftFileName],[LfdNr],[OurReference],[MessageType],[MessageTypeName],[SenderBIC],[SenderName],[SenderBranch],[ReceivedDate],[OSN],[LC_Form],[LC_Nr],[DateOfIssue],[IssuingBank],[M31D_Date],[M31D_Country],UPPER(SUBSTRING([Applicant], 0,CHARINDEX(CHAR(13),[Applicant]))) as 'Applicant',UPPER(SUBSTRING([Beneficiary], 0,CHARINDEX(CHAR(13),[Beneficiary]))) as 'Beneficiary',[LC_Currency],[LC_Amount],[Available_With],[Available_By],[AdvicedConfirmation],[Adviced],[AdvicedOn],[AdviceChargesCurrency],[AdviceCharges],[Done],[DoneOn],[RelatedCustomerID],[RelatedCustomerName],[CustomersReference] FROM [EXPORT_LC_MT700] order by [LfdNr] desc"
                        sqlCmd.Connection = sqlConn
                        sqlConn.Open()
                        Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                        Dim objDataTable As New DataTable()
                        objDataTable.Load(objDataReader)
                        Me.ExportLC_List_GridControl.DataSource = Nothing
                        Me.ExportLC_List_GridControl.DataSource = objDataTable
                        Me.ExportLC_List_GridControl.ForceInitialize()
                        sqlConn.Close()
                    End Using
                End Using
            Catch
            End Try
            SplashScreenManager.CloseForm(False)
            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = False
            LC_RELATED_DATAXtraTabPage.PageVisible = False
            LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
            LC_LIST_XtraTabPage.PageVisible = True
        End If

    End Sub

    Private Sub OurReferenceSearch_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.Click
        Me.XtraTabControl2.Visible = False
        Me.EXPORT_LC_MT700_BD_TableAdapter.FillByCustomerSearchStoredProcedure(Me.LcDataset.EXPORT_LC_MT700_BD)
    End Sub

    Private Sub FILL_ALL_DATA_BY_OUR_REFERENCE()

        Try
            Me.EXPORT_LC_MT700TableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700, OurReferenceSearch)
            Me.EXPORT_LC_MT700_RMTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_RM, OurReferenceSearch)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Temporary Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

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
    Private Sub SearchLookUpEdit1View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SearchLookUpEdit1View.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SearchLookUpEdit1View_ShownEditor(sender As Object, e As EventArgs) Handles SearchLookUpEdit1View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

#End Region

#Region "LC MT700 ADVICES"

    Private Sub Advice_MT700_DTAEA_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_DTAEA_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf MsgType_lbl.Text <> "700" Then
            MessageBox.Show("Unable to create DTAEA File - Message Type is not 700", "WRONG MESSAGE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create DTAEA File - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [LcAdviceEmail] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [LcAdviceEmail] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar

            If CheckResult = "" Then
                MessageBox.Show("Unable to create DTAEA File - No LC Advice Email receiver has being indicated for this Customer" & vbNewLine & "Please indicate LC Advice email for this Customer!", "LC ADVICE EMAIL IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                DTAEA_MT700_ADVICE()
            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_Fax_Normal_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_Fax_Normal_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Fax Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            Dim CheckResult As String = cmd.ExecuteScalar
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
                Dim CheckResultSecond As String = cmd.ExecuteScalar
                If CheckResultSecond = "" Then
                    MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    FAX_MT700_ADVICE()
                End If

            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_Fax_Variation1_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_Fax_Variation1_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Fax Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
                Dim CheckResultSecond As String = cmd.ExecuteScalar
                If CheckResultSecond = "" Then
                    MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    FAX_MT700_ADVICE_VARIATION1()
                End If
            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_Fax_Variation2_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_Fax_Variation2_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Fax Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
                Dim CheckResultSecond As String = cmd.ExecuteScalar
                If CheckResultSecond = "" Then
                    MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    FAX_MT700_ADVICE_VARIATION2()
                End If

            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_CL_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_CL_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Cover Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
            Dim CheckResultSecond As String = cmd.ExecuteScalar
            If CheckResultSecond = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                ANSCHREIBEN_LC_MT700_ADVICE()
            End If

            cmd.Connection.Close()

        End If
    End Sub

    Private Sub CoverSheet_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CoverSheet_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            LC_COVER_SHEET()
        End If
    End Sub
#End Region

    Private Sub DTAEA_MT700_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As String = Nothing
            Dim M5 As String = Nothing
            Dim M6 As String = Nothing
            Dim M7 As String = Nothing
            Dim M8 As String = Nothing
            Dim M9 As String = Nothing
            Dim M10 As String = Nothing
            Dim M11 As String = Nothing
            Dim M12 As String = Nothing
            Dim M13 As String = Nothing
            Dim M14 As String = Nothing
            Dim M15 As String = Nothing
            Dim M16 As String = Nothing
            Dim M17 As String = Nothing
            Dim M18 As String = Nothing
            Dim M19 As String = Nothing
            Dim M20 As String = Nothing
            Dim M24 As String = "Unverbindliche Kopie"
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim Z3 As String = Nothing
            Dim Z4 As String = Nothing
            Dim Z5 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing
            Dim CustomerLcAdviceCharges_DTAEA_M8 As String = Nothing
            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
              
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M4 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M7 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If
                If dt.Rows.Item(i).Item("LcAdviceChargesDTAEA") IsNot DBNull.Value Then
                    CustomerLcAdviceCharges_DTAEA_M8 = dt.Rows.Item(i).Item("LcAdviceChargesDTAEA")
                End If
            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & IndustrieDatum & ":" & t.ToString("hhmm")
            MT = ":MT:" & MsgType_lbl.Text
            M1 = ":M1:" & OUR_BIC
            M2 = ":M2:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M3 = ":M3:" & Me.OurReference_TextEdit.Text
            M4 = ":M4:" & M4
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M5 = ":M5:2"
            Else
                M5 = ":M5:1"
            End If
            M7 = M7.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M7 = M7.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M7 = ":M7:" & M7
            M8 = ":M8:" & CustomerLcAdviceCharges_DTAEA_M8
            M9 = ":M9:" & Me.IssuingBIC_TextEdit.Text
            M10 = ":M10:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M11 = ":M11:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M20 = ":M20:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            Z1 = ":Z1:Z"
            Z2 = ":Z2:001"
            Z3 = ":Z3:000"
            Z4 = ":Z4:000"
            Dim LcAmount As Double = Me.LcAmount_Textedit.Text
            Z5 = ":Z5:" & String.Format("{0:000000000000000}", LcAmount)

            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M1)
            Writer.WriteLine(M2)
            Writer.WriteLine(M3)
            Writer.WriteLine(M4)
            Writer.WriteLine(M5)
            Writer.WriteLine(M7)
            If CustomerLcAdviceCharges_DTAEA_M8 <> "" Then
                Writer.WriteLine(M8)
            End If
            Writer.WriteLine(M9)
            Writer.WriteLine(M10)
            Writer.WriteLine(M11)
            Writer.WriteLine(M12)
            Writer.WriteLine(M19)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M20)
            End If
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Z3)
            Writer.WriteLine(Z4)
            Writer.WriteLine(Z5)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Avisierung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Das Akkreditiv wurde von der Bank:" & vbNewLine _
                & ISSOUING_BANK_NAME & vbNewLine _
                & ISSOUING_BANK_CITY & vbNewLine _
                & ISSOUING_BANK_COUNTRY & vbNewLine _
                & "Im auftrag von " & vbNewLine _
                & Me.Applicant_MemoEdit.Text & vbNewLine _
                & "unter der LC Nr." & LC_Nr_TextEdit.Text & " am " & Me.IssuingDate_TextEdit.Text & " erröfnet." & vbNewLine & vbNewLine _
                & "Akkreditivbetrag: " & Me.LcCurrency_TextEdit.Text & "  " & Me.LcAmount_Textedit.Text & vbNewLine _
                & "Verfallsdatum / Verfallsort: " & Me.DateOfExpiry_DateEdit.Text & "  " & Me.PlaceOfExpiry_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub

    Private Sub FAX_MT700_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")

            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.SwiftMessageFormated_RichTextBox.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If



            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing



            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If



            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")


            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_FAX" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next


            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next



            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Form - Normal"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PlaceOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            Dim AdviceChargesCurPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceChargesCurrency").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesCurPos, Me.AdviceChargesCur_GridLookUpEdit.Text)
            Dim AdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceCharges").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesPos, Me.AdviceCharges_SpinEdit.Text)
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub FAX_MT700_ADVICE_VARIATION1()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.SwiftMessageFormated_RichTextBox.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_FAX_VARIATION1" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Form - Variation 1"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PlaceOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            Dim AdviceChargesCurPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceChargesCurrency").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesCurPos, Me.AdviceChargesCur_GridLookUpEdit.Text)
            Dim AdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceCharges").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesPos, Me.AdviceCharges_SpinEdit.Text)
            Dim AdviceCharges As Double = Me.AdviceCharges_SpinEdit.Text
            Dim TotalAdviceCharges As Double = AdviceCharges + 30
            Dim TotalAdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("TotalAdviceCharges").Range.End
            c.RichEditControl1.Document.InsertText(TotalAdviceChargesPos, FormatNumber(TotalAdviceCharges, , TriState.UseDefault))
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub FAX_MT700_ADVICE_VARIATION2()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.SwiftMessageFormated_RichTextBox.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_FAX_VARIATION2" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Form - Variation 2"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PlaceOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            'Dim AdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceCharges").Range.End
            'c.RichEditControl1.Document.InsertText(AdviceChargesPos, Me.AdviceCharges_SpinEdit.Text)
            'Dim AdviceCharges As Double = Me.AdviceCharges_SpinEdit.Text
            'Dim TotalAdviceCharges As Double = AdviceCharges + 30
            'Dim TotalAdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("TotalAdviceCharges").Range.End
            'c.RichEditControl1.Document.InsertText(TotalAdviceChargesPos, TotalAdviceCharges)
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub ANSCHREIBEN_LC_MT700_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_ANSCHREIBEN_KUNDE" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next


            SplashScreenManager.Default.SetWaitFormCaption("Create Cover Letter Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Cover Letter Advice Form"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Address").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Address_2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_ZipCode").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_City").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_ExpiryDate").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_ExpiryPlace").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            'Confirmation
            Dim Not_Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Not_Confirmed").Range.End
            Dim Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Confirmed").Range.End
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "X")
                c.RichEditControl1.Document.InsertText(Confirmed_Pos, "")
            Else
                c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "")
                c.RichEditControl1.Document.InsertText(Confirmed_Pos, "X")
            End If
            SplashScreenManager.CloseForm(False)


            Dim message, title, defaultValue As String
            Dim myValue As Object
            message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
                & "Charges for Applicant   = 1" & vbNewLine _
                & "Charges for Beneficiary = 2" & vbNewLine _
                & "Charges Shared          = 0"

            title = "ADVICE COMMISSION SHARING"   ' Set title.
            defaultValue = "1"   ' Set default value.
            ' Display message, title, and default value.
            myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            If myValue = "1" Then
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            ElseIf myValue = "2" Then
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            ElseIf myValue = "0" Then
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            Else
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            End If


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub LC_COVER_SHEET()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Cover Sheet creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing


            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "WITHOUT CONFIRMATION"
            Else
                OurConfirmation = "CONFIRMED"
            End If


            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_COVER_SHEET" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next


            'Get Latest Date of Shipment


            Dim TempString As String = Nothing
            Dim LatestDateOfShipment As Date
            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":44C:") = True Then
                    TempString = Microsoft.VisualBasic.Right(line.Trim, 6)
                    LatestDateOfShipment = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))

                End If
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create LC Cover Sheet")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Cover Sheet"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, Me.Beneficiary_MemoEdit.Text)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcCurrencyRemPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency_Rem").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyRemPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountRemPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount_Rem").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountRemPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            Dim LatestDateOfShipmentPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ShipmentDatePeriod").Range.End
            c.RichEditControl1.Document.InsertText(LatestDateOfShipmentPos, LatestDateOfShipment)
            SplashScreenManager.CloseForm(False)


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.Click
        Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)

    End Sub

    Private Sub LcCustomers_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles LcCustomers_GridView.CellValueChanged
        Dim view As GridView = DirectCast(sender, GridView)
        Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
    End Sub

    Private Sub LcCustomers_GridView_Click(sender As Object, e As EventArgs) Handles LcCustomers_GridView.Click
        Dim view As GridView = DirectCast(sender, GridView)
        Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
    End Sub


    Private Sub LcCustomers_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles LcCustomers_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString


    End Sub

    Private Sub AdvicedStatus_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles AdvicedStatus_CheckEdit.CheckedChanged
        If Me.AdvicedStatus_CheckEdit.Focused = True Then
            If Me.AdviceToCustomer_GridLookUpEdit.Text <> "" AndAlso Me.OurConfirmation_ComboEdit.Text <> "" Then
                If Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
                    Dim d As Date = Today
                    Me.AdvicedOn_DateEdit.Text = d
                    ADVICE_STATUS_DISABLED()
                ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Unchecked Then
                    Me.AdvicedOn_DateEdit.Text = Nothing
                    ADVICE_STATUS_ENABLED()
                End If
                SAVE_ALL_CHANGES()
            Else
                MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.EXPORT_LC_MT700BindingSource.CancelEdit()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ADVICE_STATUS_ENABLED()
        Me.CustomersReference_TextEdit.ReadOnly = False
        Me.AdviceToCustomer_GridLookUpEdit.Properties.ReadOnly = False
        Me.OurConfirmation_ComboEdit.Properties.ReadOnly = False
        Me.AdviceCharges_SpinEdit.ReadOnly = False
        Me.AdviceChargesCur_GridLookUpEdit.Properties.ReadOnly = False
    End Sub

    Private Sub ADVICE_STATUS_DISABLED()
        Me.CustomersReference_TextEdit.ReadOnly = True
        Me.AdviceToCustomer_GridLookUpEdit.Properties.ReadOnly = True
        Me.OurConfirmation_ComboEdit.Properties.ReadOnly = True
        Me.AdviceCharges_SpinEdit.ReadOnly = True
        Me.AdviceChargesCur_GridLookUpEdit.Properties.ReadOnly = True
    End Sub

    Private Sub SaveChanges_btn_Click(sender As Object, e As EventArgs) Handles SaveChanges_btn.Click
        SAVE_ALL_CHANGES()

    End Sub



    Private Sub RelatedCustomerID_lbl_TextChanged(sender As Object, e As EventArgs) Handles RelatedCustomerID_lbl.TextChanged
        RelatedCustomerID = Me.RelatedCustomerID_lbl.Text

        SAVE_ALL_CHANGES()
    End Sub

    Private Sub OurConfirmation_ComboEdit_SelectedValueChanged(sender As Object, e As EventArgs) Handles OurConfirmation_ComboEdit.SelectedValueChanged
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub AdviceCharges_SpinEdit_LostFocus(sender As Object, e As EventArgs) Handles AdviceCharges_SpinEdit.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEdit_LostFocus(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        Dim s As String = Me.RichTextBox1.Text
        Me.RichTextBox1.Clear()
        Me.RichTextBox1.Text = s
        ChangeTextcolor(":", Color.DarkCyan, Me.RichTextBox1, 0)
    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Me.LayoutControl5.Visible = False
        Dim s As String = Me.RichTextBox1.Text
        Me.RichTextBox1.Clear()
        Me.RichTextBox1.Text = s
        ChangeTextcolor(":", Color.DarkCyan, Me.RichTextBox1, 0)
    End Sub

    Private Sub ShowAllRelatedMsg_btn_Click(sender As Object, e As EventArgs) Handles ShowAllRelatedMsg_btn.Click
        Me.LayoutControl5.Visible = True
    End Sub



#Region "LC AMENDMENT ADVICES"
    Private Sub LcAmendmentAdviceDTAEA_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceDTAEA_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create DTAEA File for LC Amendment - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [LcAdviceEmail] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [LcAdviceEmail] is not NULL"
            cmd.Connection.Open()
            Dim CheckResult As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If CheckResult = "" Then
                MessageBox.Show("Unable to create DTAEA Amendment File - No LC Advice Email receiver has being indicated for this Customer" & vbNewLine & "Please indicate LC Advice email for this Customer!", "LC ADVICE EMAIL IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                If Me.MsgType_TextEdit.Text = "707" Then
                    DTAEA_MT707_AMENDMENT_ADVICE()
                ElseIf Me.MsgType_TextEdit.Text = "799" Then
                    DTAEA_MT799_AMENDMENT_ADVICE()
                End If
            End If


        End If
    End Sub

    Private Sub LcAmendmentAdviceFAX_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceFAX_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Amendment Advice Cover Letter Form - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL "
            cmd.Connection.Open()
            Dim CheckResult As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Cover Letter Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                LC_AMENDMENT_ADVICE_FAX()
            End If
        End If
    End Sub

    Private Sub LcAmendmentAdviceCOVER_LETTER_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceCOVER_LETTER_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Amendment Advice Cover Letter Form - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            LC_AMENDMENT_ADVICE_COVER_LETTER()
        End If
    End Sub
#End Region

    Private Sub DTAEA_MT707_AMENDMENT_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As String = Nothing
            Dim M5 As String = Nothing
            Dim M6 As String = Nothing
            Dim M7 As String = Nothing
            Dim M8 As String = Nothing
            Dim M9 As String = Nothing
            Dim M10 As String = Nothing
            Dim M11 As String = Nothing
            Dim M12 As String = Nothing
            Dim M13 As String = Nothing
            Dim M14 As String = Nothing
            Dim M15 As String = Nothing
            Dim M16 As String = Nothing
            Dim M17 As String = Nothing
            Dim M18 As String = Nothing
            Dim M19 As String = Nothing
            Dim M20 As String = Nothing
            Dim M21 As String = Nothing
            Dim M22 As String = Nothing
            Dim M24 As String = "Unverbindliche Kopie"
            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim Z3 As String = Nothing
            Dim Z4 As String = Nothing
            Dim Z5 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing
            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If 
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M4 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M7 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & IndustrieDatum & ":" & t.ToString("hhmm")
            MT = ":MT:" & Me.MsgType_TextEdit.Text
            M1 = ":M1:" & OUR_BIC
            M2 = ":M2:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M3 = ":M3:" & Me.OurReference_TextEdit.Text
            M4 = ":M4:" & M4
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M5 = ":M5:2"
            Else
                M5 = ":M5:1"
            End If
            M7 = ":M7:" & M7.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M7 = ":M7:" & M7.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M9 = ":M9:" & Me.IssuingBIC_TextEdit.Text
            M10 = ":M10:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M11 = ":M11:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M20 = ":M20:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            ' MT707 - Zeilen auslessen 
            Dim TempString As String = Nothing
            Dim TempDate As Date
            Dim DateOfAmendment As String = Nothing
            Dim NewDateOfExpiry As String = Nothing
            Dim NrOfAmendment As String = Nothing
            Dim NewLcCurrency As String = Nothing
            Dim NewLcAmount As Double = 0
            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":30:") = True Then
                    TempString = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDate = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))
                    DateOfAmendment = TempDate.ToString("yyyyMMdd")
                    M21 = ":M21:" & DateOfAmendment
                End If
                If line.StartsWith(":26E:") = True Then
                    NrOfAmendment = Microsoft.VisualBasic.Right(line.Trim, 2)
                    M22 = ":M22:" & NrOfAmendment
                End If
                If line.StartsWith(":31E:") = True Then
                    TempString = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDate = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDate
                    NewDateOfExpiry = TempDate.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
                If line.StartsWith(":34B:") = True Then
                    NewLcCurrency = Microsoft.VisualBasic.Mid(line.Trim, 5, 3)
                    Me.LcCurrency_TextEdit.Text = NewLcCurrency
                    TempString = Microsoft.VisualBasic.Mid(line.Trim, 8, 15)
                    If TempString.Trim.EndsWith(",") = True Then
                        TempString = TempString.Replace(",", "")
                    End If
                    NewLcAmount = TempString
                    Me.LcAmount_Textedit.Text = NewLcAmount
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [LC_Currency]='" & NewLcCurrency & "', [LC_Amount]='" & Str(NewLcAmount) & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next


            Z1 = ":Z1:Z"
            Z2 = ":Z2:000"
            Z3 = ":Z3:001"
            Z4 = ":Z4:000"
            If NewLcAmount > 0 Then
                Z5 = ":Z5:" & String.Format("{0:000000000000000}", NewLcAmount)
            Else
                Z5 = ":Z5:" & String.Format("{0:000000000000000}", 707)
            End If


            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M1)
            Writer.WriteLine(M2)
            Writer.WriteLine(M3)
            Writer.WriteLine(M4)
            Writer.WriteLine(M5)
            Writer.WriteLine(M7)
            Writer.WriteLine(M9)
            Writer.WriteLine(M10)
            Writer.WriteLine(M11)
            Writer.WriteLine(M12)
            Writer.WriteLine(M19)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M20)
            End If
            Writer.WriteLine(M21)
            If IsNothing(M22) = False Then
                Writer.WriteLine(M22)
            End If
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Z3)
            Writer.WriteLine(Z4)
            Writer.WriteLine(Z5)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit amendment advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Akkreditivänderung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT799_AMENDMENT_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As String = Nothing
            Dim M5 As String = Nothing
            Dim M6 As String = Nothing
            Dim M7 As String = Nothing
            Dim M8 As String = Nothing
            Dim M9 As String = Nothing
            Dim M10 As String = Nothing
            Dim M11 As String = Nothing
            Dim M12 As String = Nothing
            Dim M13 As String = Nothing
            Dim M14 As String = Nothing
            Dim M15 As String = Nothing
            Dim M16 As String = Nothing
            Dim M17 As String = Nothing
            Dim M18 As String = Nothing
            Dim M19 As String = Nothing
            Dim M20 As String = Nothing
            Dim M21 As String = Nothing
            Dim M22 As String = Nothing
            Dim M23 As String = Nothing
            Dim M24 As String = "Unverbindliche Kopie"
            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim Z3 As String = Nothing
            Dim Z4 As String = Nothing
            Dim Z5 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing
            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M4 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M23 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & IndustrieDatum & ":" & t.ToString("hhmm")
            MT = ":MT:" & Me.MsgType_TextEdit.Text
            M3 = ":M3:" & Me.OurReference_TextEdit.Text
            M11 = ":M11:" & Me.LC_Nr_TextEdit.Text
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M20 = ":M20:" & Me.CustomersReference_TextEdit.Text
            End If
            M23 = M23.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M23 = M23.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M23 = ":M23:" & M23
            '
            SwiftNachricht = SwiftNachricht.Replace(":20:", "")
            SwiftNachricht = SwiftNachricht.Replace(":21:", "")
            SwiftNachricht = SwiftNachricht.Replace(":79:", "")
            SwiftNachricht = ":79:" & SwiftNachricht

            Z1 = ":Z1:Z"
            Z2 = ":Z2:000"
            Z3 = ":Z3:000"
            Z4 = ":Z4:001"
            Z5 = ":Z5:" & String.Format("{0:000000000000000}", 799)



            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M3)
            Writer.WriteLine(M11)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M20)
            End If
            Writer.WriteLine(M23)
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Z3)
            Writer.WriteLine(Z4)
            Writer.WriteLine(Z5)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit amendment advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Akkreditivänderung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub LC_AMENDMENT_ADVICE_COVER_LETTER()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Cover Letter Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_AMENDMENT_ADVICE_COVER_LETTER" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next

            ' MT707 - Zeilen auslessen 
            Dim NrOfAmendment As String = Nothing

            Dim TempStringDateIssue As String = Nothing
            Dim TempDateIssue As Date

            Dim TempStringDateAmendment As String = Nothing
            Dim TempDateAmendment As Date
            Dim DateOfAmendment As String = Nothing

            Dim TempStringDateExpiry As String = Nothing
            Dim TempDateExpiry As Date
            Dim NewDateOfExpiry As String = Nothing

            Dim TempStringNewLcAmount As String = Nothing
            Dim NewLcCurrency As String = Nothing
            Dim NewLcAmount As Double = 0

            Dim TempStringLatestDateShipment As String = Nothing
            Dim TempLatestDateShipment As Date

            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":31C:") = True Then
                    TempStringDateIssue = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateIssue = DateSerial(Microsoft.VisualBasic.Left(TempStringDateIssue, 2), Microsoft.VisualBasic.Mid(TempStringDateIssue, 3, 2), Microsoft.VisualBasic.Right(TempStringDateIssue, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateIssue, TempDateIssue.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":30:") = True Then
                    TempStringDateAmendment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateAmendment = DateSerial(Microsoft.VisualBasic.Left(TempStringDateAmendment, 2), Microsoft.VisualBasic.Mid(TempStringDateAmendment, 3, 2), Microsoft.VisualBasic.Right(TempStringDateAmendment, 2))
                    DateOfAmendment = TempDateAmendment.ToString("yyyyMMdd")
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateAmendment, TempDateAmendment.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":26E:") = True Then
                    NrOfAmendment = Microsoft.VisualBasic.Right(line.Trim, 2)
                End If
                If line.StartsWith(":31E:") = True Then
                    TempStringDateExpiry = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateExpiry = DateSerial(Microsoft.VisualBasic.Left(TempStringDateExpiry, 2), Microsoft.VisualBasic.Mid(TempStringDateExpiry, 3, 2), Microsoft.VisualBasic.Right(TempStringDateExpiry, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDateExpiry
                    NewDateOfExpiry = TempDateExpiry.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateExpiry, TempDateExpiry.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":34B:") = True Then
                    NewLcCurrency = Microsoft.VisualBasic.Mid(line.Trim, 6, 3)
                    Me.LcCurrency_TextEdit.Text = NewLcCurrency
                    TempStringNewLcAmount = Microsoft.VisualBasic.Mid(line.Trim, 9, 15)
                    If TempStringNewLcAmount.Trim.EndsWith(",") = True Then
                        TempStringNewLcAmount = TempStringNewLcAmount.Replace(",", "")
                    End If
                    NewLcAmount = TempStringNewLcAmount
                    Me.LcAmount_Textedit.Text = NewLcAmount
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [LC_Currency]='" & NewLcCurrency & "', [LC_Amount]='" & Str(NewLcAmount) & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
                If line.StartsWith(":44C:") = True Then
                    TempStringLatestDateShipment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempLatestDateShipment = DateSerial(Microsoft.VisualBasic.Left(TempStringLatestDateShipment, 2), Microsoft.VisualBasic.Mid(TempStringLatestDateShipment, 3, 2), Microsoft.VisualBasic.Right(TempStringLatestDateShipment, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringLatestDateShipment, TempLatestDateShipment.ToString("dd.MM.yyyy"))
                End If
            Next

            'Reformat SWIFT Message
            SwiftNachricht = SwiftNachricht.Replace(":20:", ":20:Sender's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":21:", ":21:Receiver's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":23:", ":23:Issuing Bank's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52A:", ":52A:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52D:", ":52D:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31C:", ":31C:Date of Issue" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":30:", ":30:Date of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":26E:", ":26E:Number of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":59:", ":59:Beneficiary (before this amendment)" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31E:", ":31E:New Date of Expiry" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":32B:", ":32B:Increase of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":33B:", ":33B:Decrease of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":34B:", ":34B:New Documentary Credit Amount After Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39A:", ":39A:Percentage Credit Amount Tolerance" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39B:", ":39B:Maximum Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39C:", ":39C:Additional Amounts Covered" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44A:", ":44A:Place of Taking in Charge/Dispatch from .../Place of Receipt" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44E:", ":44E:Port of Loading/Airport of Departure" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44F:", ":44F:Port of Discharge/Airport of Destination" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44B:", ":44B:Place of Final Destination/For Transportation to .../Place of Delivery" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44C:", ":44C:Latest Date of Shipment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44D:", ":44D:Shipment Period" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":79:", ":79:Narrative" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":72:", ":72:Sender to Receiver Information" & vbNewLine)
            '


            SplashScreenManager.Default.SetWaitFormCaption("Create Cover Letter Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Amendment Advice Cover Letter Form"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim CustomerAddress1Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryAddresse1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1Pos, CustomerNameAddress)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryAddresse2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryZipCode").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryCity").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            'Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            'c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim AmendmentDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfAmendment").Range.End
            If TempDateAmendment > DateSerial(1800, 1, 1) Then
                c.RichEditControl1.Document.InsertText(AmendmentDatePos, TempDateAmendment)
            Else
                c.RichEditControl1.Document.InsertText(AmendmentDatePos, Nothing)
            End If

            Dim AmendmentNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NrOfAmendment").Range.End
            c.RichEditControl1.Document.InsertText(AmendmentNrPos, NrOfAmendment)
            Dim NewExpiryDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewDateOfExpiry").Range.End
            If TempDateExpiry > DateSerial(1800, 1, 1) Then
                c.RichEditControl1.Document.InsertText(NewExpiryDatePos, TempDateExpiry)
            Else
                c.RichEditControl1.Document.InsertText(NewExpiryDatePos, Nothing)
            End If

            Dim NewShipmentDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewLatestDateOfShipment").Range.End
            If TempLatestDateShipment > DateSerial(1800, 1, 1) Then
                c.RichEditControl1.Document.InsertText(NewShipmentDatePos, TempLatestDateShipment)
            Else
                c.RichEditControl1.Document.InsertText(NewShipmentDatePos, Nothing)
            End If

            Dim NewLcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewLcCurrency").Range.End
            c.RichEditControl1.Document.InsertText(NewLcCurrencyPos, NewLcCurrency)
            Dim NewLcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewLcAmount").Range.End
            If NewLcAmount <> 0 Then
                c.RichEditControl1.Document.InsertText(NewLcAmountPos, NewLcAmount)
            Else
                c.RichEditControl1.Document.InsertText(NewLcAmountPos, Nothing)
            End If

            SplashScreenManager.CloseForm(False)

            'Add Signatures
            Dim message, title, defaultValue As String
            Dim myValue As Object
            message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
                & "Charges for Applicant   = 1" & vbNewLine _
                & "Charges for Beneficiary = 2" & vbNewLine _
                & "Charges Shared          = 0"

            title = "ADVICE COMMISSION SHARING"   ' Set title.
            defaultValue = "1"   ' Set default value.
            ' Display message, title, and default value.
            myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            If myValue = "1" Then
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            ElseIf myValue = "2" Then
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            ElseIf myValue = "0" Then
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            Else
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            End If


            Dim message1, title1, defaultValue1 As String
            Dim myValue1 As Object
            message1 = "Please input where the Applicant must confirm the Amendment" & vbNewLine & vbNewLine _
                & "Confirmation    = Y" & vbNewLine _
                & "No Confirmation = N"
            title1 = "APPLICANTS AMENDMENT CONFIRMATION"   ' Set title.
            defaultValue1 = "N"   ' Set default value.
            ' Display message, title, and default value.
            myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)
            Dim ApplicantsConfirmation_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantsConfirmation").Range.End

            If myValue1 = "Y" Then
                c.RichEditControl1.Document.InsertText(ApplicantsConfirmation_Pos, "Wir bitten um Ihre Einverständniserklärung zur Annahme der o.a. Änderung")
            Else
                c.RichEditControl1.Document.InsertText(ApplicantsConfirmation_Pos, "")
            End If



        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub LC_AMENDMENT_ADVICE_FAX()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_AMENDMENT_ADVICE_FAX" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next



            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                CustomerID = dt.Rows.Item(i).Item("CustomerID")
                CustomerName = dt.Rows.Item(i).Item("CustomerName")
                If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                    CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                End If
                If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                    CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                End If
                CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                    CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                End If
                If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                    CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                End If
                If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                    CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                End If
                If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                    CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                End If
                If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                    CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                End If
                If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                    CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                End If

            Next



            ' MT707 - Zeilen auslessen 
            Dim NrOfAmendment As String = Nothing

            Dim TempStringDateIssue As String = Nothing
            Dim TempDateIssue As Date

            Dim TempStringDateAmendment As String = Nothing
            Dim TempDateAmendment As Date
            Dim DateOfAmendment As String = Nothing

            Dim TempStringDateExpiry As String = Nothing
            Dim TempDateExpiry As Date
            Dim NewDateOfExpiry As String = Nothing

            Dim TempStringNewLcAmount As String = Nothing
            Dim NewLcCurrency As String = Nothing
            Dim NewLcAmount As Double = 0

            Dim TempStringLatestDateShipment As String = Nothing
            Dim TempLatestDateShipment As Date

            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":31C:") = True Then
                    TempStringDateIssue = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateIssue = DateSerial(Microsoft.VisualBasic.Left(TempStringDateIssue, 2), Microsoft.VisualBasic.Mid(TempStringDateIssue, 3, 2), Microsoft.VisualBasic.Right(TempStringDateIssue, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateIssue, TempDateIssue.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":30:") = True Then
                    TempStringDateAmendment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateAmendment = DateSerial(Microsoft.VisualBasic.Left(TempStringDateAmendment, 2), Microsoft.VisualBasic.Mid(TempStringDateAmendment, 3, 2), Microsoft.VisualBasic.Right(TempStringDateAmendment, 2))
                    DateOfAmendment = TempDateAmendment.ToString("yyyyMMdd")
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateAmendment, TempDateAmendment.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":26E:") = True Then
                    NrOfAmendment = Microsoft.VisualBasic.Right(line.Trim, 2)
                End If
                If line.StartsWith(":31E:") = True Then
                    TempStringDateExpiry = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateExpiry = DateSerial(Microsoft.VisualBasic.Left(TempStringDateExpiry, 2), Microsoft.VisualBasic.Mid(TempStringDateExpiry, 3, 2), Microsoft.VisualBasic.Right(TempStringDateExpiry, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDateExpiry
                    NewDateOfExpiry = TempDateExpiry.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateExpiry, TempDateExpiry.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":34B:") = True Then
                    NewLcCurrency = Microsoft.VisualBasic.Mid(line.Trim, 6, 3)
                    Me.LcCurrency_TextEdit.Text = NewLcCurrency
                    TempStringNewLcAmount = Microsoft.VisualBasic.Mid(line.Trim, 9, 15)
                    If TempStringNewLcAmount.Trim.EndsWith(",") = True Then
                        TempStringNewLcAmount = TempStringNewLcAmount.Replace(",", "")
                    End If
                    NewLcAmount = TempStringNewLcAmount
                    Me.LcAmount_Textedit.Text = NewLcAmount
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [LC_Currency]='" & NewLcCurrency & "', [LC_Amount]='" & Str(NewLcAmount) & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
                If line.StartsWith(":44C:") = True Then
                    TempStringLatestDateShipment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempLatestDateShipment = DateSerial(Microsoft.VisualBasic.Left(TempStringLatestDateShipment, 2), Microsoft.VisualBasic.Mid(TempStringLatestDateShipment, 3, 2), Microsoft.VisualBasic.Right(TempStringLatestDateShipment, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringLatestDateShipment, TempLatestDateShipment.ToString("dd.MM.yyyy"))
                End If
            Next

            'Reformat SWIFT Message
            SwiftNachricht = SwiftNachricht.Replace(":20:", ":20:Sender's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":21:", ":21:Receiver's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":23:", ":23:Issuing Bank's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52A:", ":52A:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52D:", ":52D:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31C:", ":31C:Date of Issue" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":30:", ":30:Date of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":26E:", ":26E:Number of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":59:", ":59:Beneficiary (before this amendment)" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31E:", ":31E:New Date of Expiry" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":32B:", ":32B:Increase of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":33B:", ":33B:Decrease of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":34B:", ":34B:New Documentary Credit Amount After Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39A:", ":39A:Percentage Credit Amount Tolerance" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39B:", ":39B:Maximum Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39C:", ":39C:Additional Amounts Covered" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44A:", ":44A:Place of Taking in Charge/Dispatch from .../Place of Receipt" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44E:", ":44E:Port of Loading/Airport of Departure" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44F:", ":44F:Port of Discharge/Airport of Destination" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44B:", ":44B:Place of Final Destination/For Transportation to .../Place of Delivery" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44C:", ":44C:Latest Date of Shipment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44D:", ":44D:Shipment Period" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":79:", ":79:Narrative" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":72:", ":72:Sender to Receiver Information" & vbNewLine)
            '

            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Amendment Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Amendment Fax Form"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim AmendmentNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmendmentNr").Range.End
            c.RichEditControl1.Document.InsertText(AmendmentNrPos, NrOfAmendment)
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub


    Private Sub AdvicedAmendment_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles AdvicedAmendment_CheckEdit.CheckedChanged
        If Me.AdvicedAmendment_CheckEdit.Focused = True Then
            If Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
                Dim d As Date = Today
                Me.AdvicedAmendment_DateEdit.Text = d
            ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Unchecked Then
                Me.AdvicedAmendment_DateEdit.Text = Nothing
            End If
            SAVE_ALL_CHANGES()
        End If

    End Sub

    

    

    Private Sub DoneStatus_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles DoneStatus_CheckEdit.CheckedChanged
        If Me.DoneStatus_CheckEdit.CheckState = CheckState.Checked Then
            Dim d As Date = Today
            Me.DoneDateEdit.Text = d
            Me.GroupControl1.Enabled = False
            Me.GroupControl6.Enabled = False
        ElseIf Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.DoneDateEdit.Text = Nothing
            Me.GroupControl1.Enabled = True
            Me.GroupControl6.Enabled = True
        End If

        SAVE_ALL_CHANGES()
    End Sub

  

    Private Sub SwiftMsgPrint_btn_Click(sender As Object, e As EventArgs) Handles SwiftMsgPrint_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Printform for Export LC Ref. " & Me.OurReference_TextEdit.Text)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EXPORT_LC_MT700.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(LcDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Me.IDLabel1.Text
        myParams.ParameterFieldName = "ID"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "EXPORT LC Reference" & Me.OurReference_TextEdit.Text
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SwiftMsgRelatedPrint_btn_Click(sender As Object, e As EventArgs) Handles SwiftMsgRelatedPrint_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Printform for Message Ref. " & Me.Ref20_TextEdit.Text)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EXPORT_LC_MT700_RelatedMsg.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(LcDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Me.ID_RelatedMessage_lbl.Text
        myParams.ParameterFieldName = "ID"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "SWIFT MESSAGE Reference " & Me.Ref20_TextEdit.Text
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ExportLcRelatedMessages_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLcRelatedMessages_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLcRelatedMessages_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLcRelatedMessages_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AdviceChargesCur_GridLookUpEdit_LostFocus(sender As Object, e As EventArgs) Handles AdviceChargesCur_GridLookUpEdit.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub AmendAdviceCur_GridLookUpEdit1_LostFocus(sender As Object, e As EventArgs) Handles AmendAdviceCur_GridLookUpEdit1.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub EXPORT_LC_IMPORT_MANUAL()
        Dim result As DialogResult = XtraMessageBox.Show("Should the LC Nr. " & Me.M_LC_Nr_TextEdit.Text & " be imported ?", "EXPORT LC - MANUAL IMPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.Yes Then

            Using ConnSqlM As New SqlConnection(connSQL.ConnectionString)

                Dim cmdConnSqlM As New SqlCommand
                cmdConnSqlM.Connection = ConnSqlM
                ConnSqlM.Open()

                cmdConnSqlM.CommandText = "Select Max([LfdNr])+1 from [EXPORT_LC_MT700]"
                Dim lfdNr As Double = cmdConnSqlM.ExecuteScalar
                Dim OurReference As String = "DEFF" & lfdNr
                Dim ReceiptDate As Date = Me.M_ReceivedDate_DateEdit.Text
                Dim ReceiptDateSql As String = ReceiptDate.ToString("yyyyMMdd")
                Dim SenderBIC As String = Me.M_SenderBIC_TextEdit.Text
                Dim LCF40A As String = Me.M_LC_Form_TextEdit.Text
                Dim DateOfIssue As Date = Me.M_Issuing_Date_DateEdit.Text
                Dim LCF31C As String = DateOfIssue.ToString("yyyyMMdd")
                Dim DateOfExpiry As Date = Me.M_DateOfExpiry_DateEdit.Text
                Dim LCF31D_Date As String = DateOfExpiry.ToString("yyyyMMdd")
                Dim LCF32B_CUR As String = Me.M_LC_Currency_TextEdit.Text
                Dim LCF32B_AMT As Double = Me.M_LC_Amount_TextEdit.Text
                Dim LCF41_BY As String = Me.M_LC_Available_By_TextEdit.Text

                'Insert in EXPORT_LC_MT700
                cmdConnSqlM.CommandText = "INSERT INTO [EXPORT_LC_MT700]([SwiftFileName],[LfdNr],[OurReference],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[LC_Form],[LC_Nr],[DateOfIssue],[M31D_Date],[M31D_Country],[IssuingBank],[Applicant],[Beneficiary],[LC_Currency],[LC_Amount],[Available_With],[Available_By],[Swift_Message],[Swift_Message_Formated]) Values ('MANUAL','" & Str(lfdNr) & "','" & OurReference & "','700','" & SenderBIC & "','" & ReceiptDateSql & "','0','" & LCF40A & "',@ReferenceLC,'" & LCF31C & "','" & LCF31D_Date & "',@PlaceOfExpiry, @IssuingOrApplicantsBank, @Applicant, @Beneficiary,'" & LCF32B_CUR & "','" & Str(LCF32B_AMT) & "',@AvailableWith,'" & LCF41_BY & "',@SwiftMessageTextAll,@SwiftMessageFormatedTextAll)"
                cmdConnSqlM.Parameters.Add("@ReferenceLC", SqlDbType.NVarChar).Value = Me.M_LC_Nr_TextEdit.Text
                cmdConnSqlM.Parameters.Add("@SwiftMessageTextAll", SqlDbType.NText).Value = Me.M_SwiftMessageBlock_RichTextBox.Text
                cmdConnSqlM.Parameters.Add("@SwiftMessageFormatedTextAll", SqlDbType.NText).Value = Me.M_SwiftMessageBlock_RichTextBox.Text
                cmdConnSqlM.Parameters.Add("@PlaceOfExpiry", SqlDbType.NVarChar).Value = Me.M_PlaceOfExiry_TextEdit.Text
                cmdConnSqlM.Parameters.Add("@IssuingOrApplicantsBank", SqlDbType.NVarChar).Value = Me.M_Issuing_BIC_TextEdit.Text
                cmdConnSqlM.Parameters.Add("@Applicant", SqlDbType.NVarChar).Value = Me.M_Applicant_MemoEdit.Text
                cmdConnSqlM.Parameters.Add("@Beneficiary", SqlDbType.NVarChar).Value = Me.M_Beneficiary_MemoEdit.Text
                cmdConnSqlM.Parameters.Add("@AvailableWith", SqlDbType.NVarChar).Value = Me.AvailableWith_TextEdit.Text
                cmdConnSqlM.ExecuteNonQuery()
                cmdConnSqlM.Parameters.Clear() 'Allways to Use otherwise ERROR EXCEPTION:The Vaiables must be unique
                'Updates in EXPORT_LC_MT700
                cmdConnSqlM.CommandText = "UPDATE A SET A.[SenderName]= B.[INSTITUTION NAME],A.[SenderBranch]=B.[CITY HEADING] FROM [EXPORT_LC_MT700] A INNER JOIN [BIC DIRECTORY] B ON A.[SenderBIC]=B.[BIC CODE]+ B.[BRANCH CODE] where A.[OurReference]='" & OurReference & "'"
                cmdConnSqlM.ExecuteNonQuery()
                cmdConnSqlM.CommandText = "UPDATE A set A.[MessageTypeName]=B.S from  [EXPORT_LC_MT700] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='SWIFT_MESSAGE_NAMES' and [PARAMETER STATUS] ='Y')B ON A.[MessageType]=B.[PARAMETER1] where A.[MessageTypeName] is NULL and A.[OurReference]='" & OurReference & "'"
                cmdConnSqlM.ExecuteNonQuery()
                ConnSqlM.Close()

                XtraMessageBox.Show("EXPORT LC Nr. " & Me.M_LC_Nr_TextEdit.Text & " has being imported with Reference Nr. " & OurReference, "IMPORT FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Set default values
                Me.M_ReceivedDate_DateEdit.EditValue = DBNull.Value
                Me.M_SenderBIC_TextEdit.Text = ""
                Me.M_LC_Nr_TextEdit.Text = ""
                Me.M_LC_Form_TextEdit.Text = ""
                Me.M_Issuing_BIC_TextEdit.Text = ""
                Me.M_Issuing_Date_DateEdit.EditValue = DBNull.Value
                Me.M_DateOfExpiry_DateEdit.EditValue = DBNull.Value
                Me.M_PlaceOfExiry_TextEdit.Text = ""
                Me.M_Applicant_MemoEdit.EditValue = DBNull.Value
                Me.M_Beneficiary_MemoEdit.EditValue = DBNull.Value
                Me.M_LC_Currency_TextEdit.EditValue = DBNull.Value
                Me.M_LC_Amount_TextEdit.EditValue = DBNull.Value
                Me.AvailableWith_TextEdit.Text = ""
                Me.AvailableWith_TextEdit.Text = ""
                Me.M_LC_Available_By_TextEdit.EditValue = DBNull.Value
                Me.M_SwiftMessageBlock_RichTextBox.Text = ""

            End Using
        Else
            Exit Sub
        End If

    End Sub


    Private Sub M_AddManualLC_btn_Click(sender As Object, e As EventArgs) Handles M_AddManualLC_btn.Click
        If Me.DxValidationProvider1.Validate() = True Then
            'Check if issuing bank BIC exists
            If cmdSQL.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Select Count([Idnr]) from [BIC DIRECTORY] where [BIC11]='" & Me.M_SenderBIC_TextEdit.Text & "'"
            Dim r As Double = cmd.ExecuteScalar
            If r > 0 Then
                cmd.CommandText = "Select Count([Idnr]) from [BIC DIRECTORY] where [BIC11]='" & Me.M_Issuing_BIC_TextEdit.Text & "'"
                r = cmd.ExecuteScalar
                If r > 0 Then
                    cmd.Connection.Close()
                    Try
                        EXPORT_LC_IMPORT_MANUAL()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    cmd.Connection.Close()
                    MessageBox.Show("Issuing Bank BIC not fund in BIC DIRECTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                cmd.Connection.Close()
                MessageBox.Show("Sender Bank BIC not fund in BIC DIRECTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


        Else
            MessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub LC_MANUAL_INPUT_XtraTabPage_VisibleChanged(sender As Object, e As EventArgs) Handles LC_MANUAL_INPUT_XtraTabPage.VisibleChanged
        If LC_MANUAL_INPUT_XtraTabPage.PageVisible = True Then
            Me.Label6.Visible = False
            Me.OurReferenceSearch_GridLookUpEdit.Visible = False
        ElseIf LC_MANUAL_INPUT_XtraTabPage.PageVisible = False Then
            'Set default values
            Me.M_ReceivedDate_DateEdit.EditValue = DBNull.Value
            Me.M_SenderBIC_TextEdit.Text = ""
            Me.M_LC_Nr_TextEdit.Text = ""
            Me.M_LC_Form_TextEdit.Text = ""
            Me.M_Issuing_BIC_TextEdit.Text = ""
            Me.M_Issuing_Date_DateEdit.EditValue = DBNull.Value
            Me.M_DateOfExpiry_DateEdit.EditValue = DBNull.Value
            Me.M_PlaceOfExiry_TextEdit.Text = ""
            Me.M_Applicant_MemoEdit.EditValue = DBNull.Value
            Me.M_Beneficiary_MemoEdit.EditValue = DBNull.Value
            Me.M_LC_Currency_TextEdit.EditValue = DBNull.Value
            Me.M_LC_Amount_TextEdit.EditValue = DBNull.Value
            Me.AvailableWith_TextEdit.Text = ""
            Me.AvailableWith_TextEdit.Text = ""
            Me.M_LC_Available_By_TextEdit.EditValue = DBNull.Value
            Me.M_SwiftMessageBlock_RichTextBox.Text = ""
            Me.XtraTabControl2.Visible = False
            Me.Label6.Visible = True
            Me.OurReferenceSearch_GridLookUpEdit.Visible = True
            Me.OurReferenceSearch_GridLookUpEdit.Focus()

        End If
    End Sub

    Private Sub M_Cancel_btn_Click(sender As Object, e As EventArgs) Handles M_Cancel_btn.Click
        LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
    End Sub

  
    Private Sub ExportLC_List_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLC_List_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLC_List_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLC_List_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
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
        Dim reportfooter As String = "EXPORT LETTER OF CREDITS till " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    
    Private Sub PrinOrExport_LC_List_btn_Click(sender As Object, e As EventArgs) Handles PrinOrExport_LC_List_btn.Click
        If Not ExportLC_List_GridControl.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    
End Class