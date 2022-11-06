Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text
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
Imports CrystalDecisions.CrystalReports.Engine
Public Class ZvSta2014
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private da1 As New SqlDataAdapter
    Private dt As New DataTable
    Private dt1 As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date

    Dim PaymentsDetailsViewCaption As String = Nothing
    Dim XML_CREATE As String


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
    Public Sub ExpandAllRows(ByVal View As GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub


    Private Sub ZVSTAT_Parameters_from2014BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ZVSTAT_Parameters_from2014BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)

    End Sub

    Private Sub ZvSta2014_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***************************************************
        '*******Get the XML Creator for the file************
        '***************************************************
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='ZVSTAT_XML_CREATOR' and [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='ZV_STAT' and [PARAMETER STATUS]='Y' "
        Dim Result As String = cmd.ExecuteScalar
        If Result <> "" Then
            XML_CREATE = "Y"
        Else
            XML_CREATE = "N"
        End If
        '***********************************************************************
        cmd.Connection.Close()

        'Bind Combobox
        Me.ZvStatMeldejahr_Comboboxedit.Properties.Items.Clear()
        Me.QueryText = "Select * from [ZVSTAT_MeldeJahr_from2014] ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.ZvStatMeldejahr_Comboboxedit.Properties.Items.Add(row("MeldeJahr"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.ZvStatMeldejahr_Comboboxedit.Text = dt.Rows.Item(0).Item("MeldeJahr")
            Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text
            Me.ZVSTAT_Details_from2014TableAdapter.FillByReportYear(Me.MeldewesenDataSet.ZVSTAT_Details_from2014, MeldeJahr)
            Me.ZVSTAT_Meldepositionen_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldepositionen_from2014, MeldeJahr)
            Me.ZVSTAT_Meldeschemas_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldeschemas_from2014, MeldeJahr)
            Me.ZVSTAT_MeldeJahr_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_MeldeJahr_from2014, MeldeJahr)
            '***********************************************************************
            Me.ZVSTAT_Parameters_from2014TableAdapter.Fill(Me.MeldewesenDataSet.ZVSTAT_Parameters_from2014)
        End If



        'Expand all details
        Me.ExpandAllRows(ZVSTAT_MeldeJahr_GridView)
        Me.ExpandAllRows(ZVSTAT_Meldeschemas_GridView)

        REPORT_LOCK_UNLOCK()

    End Sub

    Private Sub REPORT_LOCK_UNLOCK()
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
            Me.ReportLocked_CheckEdit.Text = "Report is locked"
            Me.ReportLocked_CheckEdit.BackColor = Color.Red
            Me.ReportLocked_CheckEdit.ForeColor = Color.White
        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.ReportLocked_CheckEdit.Text = "Report is unlocked"
            Me.ReportLocked_CheckEdit.BackColor = Color.Green
            Me.ReportLocked_CheckEdit.ForeColor = Color.White
        End If
    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim MeldeJahr As Double = 0
        'Add new reporting Year
        If e.Button.Tag = "AddNew" Then
            If MessageBox.Show("Soll ein neues Meldejahr für die ZV STATISTIK erstellt werden?", "NEUES MELDEJAHR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Erstellung neues Meldejahr für ZV STATISTIK")
                Try
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Connection.Open()
                    cmd.CommandText = "Select Max([MeldeJahr]) from [ZVSTAT_MeldeJahr_from2014]"
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        MeldeJahr = cmd.ExecuteScalar + 1
                        cmd.CommandText = "INSERT INTO [ZVSTAT_MeldeJahr_from2014]([MeldeJahr])Values('" & Str(MeldeJahr) & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [ZVSTAT_Meldeschemas_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[IdMeldeJahr]) select [FormNr],[FormName],'" & Str(MeldeJahr) & "',(Select [ID] from [ZVSTAT_MeldeJahr_from2014] where [MeldeJahr]=" & MeldeJahr & ") from [ZVSTAT_Parameters_from2014] GROUP BY [FormNr],[FormName]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [ZVSTAT_Meldepositionen_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[PositionNr],[PositionName],[Landkontext],[LandCode],[AnzahlKz],[WertKz],[PositionSQLcommand]) select [FormNr],[FormName],'" & Str(MeldeJahr) & "',[PositionNr],[PositionName],[Landkontext],[LandCode],[Anzahl],[Wert],[PositionSQLcommand] from [ZVSTAT_Parameters_from2014] where [LandCode] not in ('EU') order by [LfdNr]"
                        cmd.ExecuteNonQuery()
                        'Special Fall EU+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.QueryText = "Select * from [ZVSTAT_Parameters_from2014] where [LandCode] in ('EU')"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            Me.QueryText = "Select * from [COUNTRIES] where [EU EEA] in ('EU') and [COUNTRY CODE] not in ('DE')"
                            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt1 = New DataTable()
                            da1.Fill(dt1)
                            For y = 0 To dt1.Rows.Count - 1
                                cmd.CommandText = "INSERT INTO [ZVSTAT_Meldepositionen_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[PositionNr],[PositionName],[Landkontext],[LandCode],[AnzahlKz],[WertKz]) Values('" & dt.Rows.Item(i).Item("FormNr") & "','" & dt.Rows.Item(i).Item("FormName") & "','" & Str(MeldeJahr) & "','" & dt.Rows.Item(i).Item("PositionNr") & "','" & dt.Rows.Item(i).Item("PositionName") & "  " & dt1.Rows.Item(y).Item("COUNTRY NAME") & "', '" & dt.Rows.Item(i).Item("Landkontext") & "', '" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "', '" & dt.Rows.Item(i).Item("Anzahl") & "','" & dt.Rows.Item(i).Item("Wert") & "')"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= (Select [PositionSQLcommand] from [ZVSTAT_Parameters_from2014] where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "'  and [LandCode]='EU') where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "' and [LandCode]='" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "' and [MeldeJahr]=" & MeldeJahr & ""
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= REPLACE([PositionSQLcommand],'<EU_LAND>','" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "') where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "' and [LandCode]='" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "' and [MeldeJahr]=" & MeldeJahr & ""
                                cmd.ExecuteNonQuery()
                            Next
                        Next
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        cmd.CommandText = "UPDATE A SET A.[IdMeldeschemas]=B.[ID] from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN [ZVSTAT_Meldeschemas_from2014] B ON A.[MeldeschemaNr]=B.[MeldeschemaNr] and A.[MeldeJahr]=B.[MeldeJahr] where A.[MeldeJahr]=" & MeldeJahr & ""
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= REPLACE([PositionSQLcommand],'<MeldeJahr>',[MeldeJahr]) where [MeldeJahr]=" & MeldeJahr & ""
                        cmd.ExecuteNonQuery()
                        'Bind Combobox
                        Me.ZvStatMeldejahr_Comboboxedit.Properties.Items.Clear()

                        Me.QueryText = "Select * from [ZVSTAT_MeldeJahr_from2014] ORDER BY [ID] desc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For Each row As DataRow In dt.Rows
                            If dt.Rows.Count > 0 Then
                                Me.ZvStatMeldejahr_Comboboxedit.Properties.Items.Add(row("MeldeJahr"))
                            End If
                        Next
                        Me.ZvStatMeldejahr_Comboboxedit.Text = dt.Rows.Item(0).Item("MeldeJahr")

                        Me.ZVSTAT_Details_from2014TableAdapter.FillByReportYear(Me.MeldewesenDataSet.ZVSTAT_Details_from2014, MeldeJahr)
                        Me.ZVSTAT_Meldepositionen_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldepositionen_from2014, MeldeJahr)
                        Me.ZVSTAT_Meldeschemas_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldeschemas_from2014, MeldeJahr)
                        Me.ZVSTAT_MeldeJahr_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_MeldeJahr_from2014, MeldeJahr)
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Meldejahr " & MeldeJahr & " wurde angelegt!", "NEUES MELDEJAHR", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        MeldeJahr = 2014
                        cmd.CommandText = "INSERT INTO [ZVSTAT_MeldeJahr_from2014]([MeldeJahr])Values('" & Str(MeldeJahr) & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [ZVSTAT_Meldeschemas_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[IdMeldeJahr]) select [FormNr],[FormName],'" & Str(MeldeJahr) & "',(Select [ID] from [ZVSTAT_MeldeJahr_from2014] where [MeldeJahr]=" & MeldeJahr & ") from [ZVSTAT_Parameters_from2014] GROUP BY [FormNr],[FormName]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [ZVSTAT_Meldepositionen_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[PositionNr],[PositionName],[Landkontext],[LandCode],[AnzahlKz],[WertKz],[PositionSQLcommand]) select [FormNr],[FormName],'" & Str(MeldeJahr) & "',[PositionNr],[PositionName],[Landkontext],[LandCode],[Anzahl],[Wert],[PositionSQLcommand] from [ZVSTAT_Parameters_from2014] where [LandCode] not in ('EU') order by [LfdNr]"
                        cmd.ExecuteNonQuery()
                        'Special Fall EU+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.QueryText = "Select * from [ZVSTAT_Parameters_from2014] where [LandCode] in ('EU')"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            Me.QueryText = "Select * from [COUNTRIES] where [EU EEA] in ('EU') and [COUNTRY CODE] not in ('DE')"
                            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt1 = New DataTable()
                            da1.Fill(dt1)
                            For y = 0 To dt1.Rows.Count - 1
                                cmd.CommandText = "INSERT INTO [ZVSTAT_Meldepositionen_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[PositionNr],[PositionName],[Landkontext],[LandCode],[AnzahlKz],[WertKz]) Values('" & dt.Rows.Item(i).Item("FormNr") & "','" & dt.Rows.Item(i).Item("FormName") & "','" & Str(MeldeJahr) & "','" & dt.Rows.Item(i).Item("PositionNr") & "','" & dt.Rows.Item(i).Item("PositionName") & "  " & dt1.Rows.Item(y).Item("COUNTRY NAME") & "', '" & dt.Rows.Item(i).Item("Landkontext") & "', '" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "', '" & dt.Rows.Item(i).Item("Anzahl") & "','" & dt.Rows.Item(i).Item("Wert") & "')"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= (Select [PositionSQLcommand] from [ZVSTAT_Parameters_from2014] where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "'  and [LandCode]='EU') where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "' and [LandCode]='" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "' and [MeldeJahr]=" & MeldeJahr & ""
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= REPLACE([PositionSQLcommand],'<EU_LAND>','" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "') where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "' and [LandCode]='" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "' and [MeldeJahr]=" & MeldeJahr & ""
                                cmd.ExecuteNonQuery()
                            Next
                        Next
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        cmd.CommandText = "UPDATE A SET A.[IdMeldeschemas]=B.[ID] from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN [ZVSTAT_Meldeschemas_from2014] B ON A.[MeldeschemaNr]=B.[MeldeschemaNr] and A.[MeldeJahr]=B.[MeldeJahr] where A.[MeldeJahr]=" & MeldeJahr & ""
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= REPLACE([PositionSQLcommand],'<MeldeJahr>',[MeldeJahr]) where [MeldeJahr]=" & MeldeJahr & ""
                        cmd.ExecuteNonQuery()
                        'Bind Combobox
                        Me.ZvStatMeldejahr_Comboboxedit.Properties.Items.Clear()
                        Me.QueryText = "Select * from [ZVSTAT_MeldeJahr_from2014] ORDER BY [ID] desc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For Each row As DataRow In dt.Rows
                            If dt.Rows.Count > 0 Then
                                Me.ZvStatMeldejahr_Comboboxedit.Properties.Items.Add(row("MeldeJahr"))
                            End If
                        Next
                        Me.ZvStatMeldejahr_Comboboxedit.Text = dt.Rows.Item(0).Item("MeldeJahr")

                        Me.ZVSTAT_Details_from2014TableAdapter.FillByReportYear(Me.MeldewesenDataSet.ZVSTAT_Details_from2014, MeldeJahr)
                        Me.ZVSTAT_Meldepositionen_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldepositionen_from2014, MeldeJahr)
                        Me.ZVSTAT_Meldeschemas_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldeschemas_from2014, MeldeJahr)
                        Me.ZVSTAT_MeldeJahr_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_MeldeJahr_from2014, MeldeJahr)
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Meldejahr " & MeldeJahr & " wurde angelegt!", "NEUES MELDEJAHR", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                Catch ex As System.Exception
                    SplashScreenManager.CloseForm(False)
                    MsgBox(ex.Message)
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End Try
                SplashScreenManager.CloseForm(False)
            Else
                Exit Sub

            End If
        End If

        'Expand all details
        Me.ExpandAllRows(ZVSTAT_MeldeJahr_GridView)
        Me.ExpandAllRows(ZVSTAT_Meldeschemas_GridView)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ZVSTAT_Parameters_from2014BindingSource.EndEdit()
                If Me.MeldewesenDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                        Me.ZVSTAT_Parameters_from2014TableAdapter.Fill(Me.MeldewesenDataSet.ZVSTAT_Parameters_from2014)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                'Remove 
                If Me.GridControl2.FocusedView.Name = "ZVSTAT_BasicParameters_GridView" Then
                    Dim row As System.Data.DataRow = ZVSTAT_BasicParameters_GridView.GetDataRow(ZVSTAT_BasicParameters_GridView.FocusedRowHandle)
                    Dim FormNr As String = row(1)
                    Dim ID As String = row(0)
                    If MessageBox.Show("Should the Meldeshchema Form: " & FormNr & " be deleted?", "DELETE MELDESCHEMA FORM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim ZVFormNr As MeldewesenDataSet.ZVSTAT_Parameters_from2014Row
                        ZVFormNr = MeldewesenDataSet.ZVSTAT_Parameters_from2014.FindByID(ID)
                        ZVFormNr.Delete()
                        ZVSTAT_BasicParameters_GridView.DeleteSelectedRows()
                        GridControl2.Update()
                        Me.ZVSTAT_Parameters_from2014TableAdapter.Update(Me.MeldewesenDataSet.ZVSTAT_Parameters_from2014)
                        'Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                        'Delete BusinessTypes Details
                        Me.ZVSTAT_Parameters_from2014TableAdapter.Fill(Me.MeldewesenDataSet.ZVSTAT_Parameters_from2014)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub ZVSTAT_BasicParameters_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ZVSTAT_BasicParameters_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ZVSTAT_BasicParameters_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZVSTAT_BasicParameters_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ZVSTAT_BasicParameters_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ZVSTAT_BasicParameters_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ZVSTAT_BasicParameters_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ZVSTAT_BasicParameters_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim LFD_NR As GridColumn = View.Columns("LfdNr")
        Dim FORM_NR As GridColumn = View.Columns("FormNr")
        Dim FORM_NAME As GridColumn = View.Columns("FormName")
        Dim POSITIONS_NR As GridColumn = View.Columns("PositionNr")
        Dim POSITIONS_NAME As GridColumn = View.Columns("PositionName")
        Dim LAND_KONTEXT As GridColumn = View.Columns("Landkontext")
        Dim LAND_CODE As GridColumn = View.Columns("LandCode")
        Dim ANZAHL_A As GridColumn = View.Columns("Anzahl")
        Dim WERT_W As GridColumn = View.Columns("Wert")

        Dim LfdNr As String = View.GetRowCellValue(e.RowHandle, colLfdNr).ToString
        Dim FormNr As String = View.GetRowCellValue(e.RowHandle, colFormNr).ToString
        Dim FormName As String = View.GetRowCellValue(e.RowHandle, colFormName).ToString
        Dim PositionsNr As String = View.GetRowCellValue(e.RowHandle, colPositionNr).ToString
        Dim PositionsName As String = View.GetRowCellValue(e.RowHandle, colPositionName).ToString
        Dim Landkontext As String = View.GetRowCellValue(e.RowHandle, colLandkontext).ToString
        Dim Landcode As String = View.GetRowCellValue(e.RowHandle, colLandCode).ToString
        Dim Anzahl As String = View.GetRowCellValue(e.RowHandle, colAnzahl).ToString
        Dim Wert As String = View.GetRowCellValue(e.RowHandle, colWert).ToString

        If LfdNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(LFD_NR, "The Lfd Nr. must not be empty")
            e.ErrorText = "The Lfd Nr. must not be empty"
        End If
        If FormNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FORM_NR, "The Form Nr. must not be empty")
            e.ErrorText = "The Form Nr. must not be empty"
        End If
        If FormName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FORM_NAME, "The Form Name  must not be empty")
            e.ErrorText = "The Form Name  must not be empty"
        End If
        If PositionsNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(POSITIONS_NR, "The PositionsNr  must not be empty")
            e.ErrorText = "The PositionsNr  must not be empty"
        End If
        If PositionsName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(POSITIONS_NAME, "The Positions Name  must not be empty")
            e.ErrorText = "The Positions Name  must not be empty"
        End If
        If Landkontext = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(LAND_KONTEXT, "The Landkontext  must not be empty")
            e.ErrorText = "The Landkontext  must not be empty"
        End If
        If Landcode = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(LAND_CODE, "The Landcode  must not be empty")
            e.ErrorText = "The Landcode  must not be empty"
        End If
        If Anzahl = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ANZAHL_A, "Anzahl  must not be empty")
            e.ErrorText = "Anzahl  must not be empty"
        End If
        If Wert = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERT_W, "Wert  must not be empty")
            e.ErrorText = "Wert  must not be empty"
        End If
    End Sub

    Private Sub LoadZvStatData_btn_Click(sender As Object, e As EventArgs) Handles LoadZvStatData_btn.Click
      
    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            If Me.ZvStatMeldejahr_Comboboxedit.Text <> "" Then
                If MessageBox.Show("Should the ZV STATISTIC SQL Commands for Meldejahr " & Me.ZvStatMeldejahr_Comboboxedit.Text & " be executed again?", "SQL COMMANDS EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If Me.BgwZVSTAT_Run.IsBusy = False Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Executing ZV STATISTIC SQL Commands for" & Me.ZvStatMeldejahr_Comboboxedit.Text)
                        Me.BgwZVSTAT_Run.RunWorkerAsync()

                    End If
                End If
            End If
        Else

            MessageBox.Show("Please unlock first the Report State!", "REPORT IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub BgwZVSTAT_Run_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTAT_Run.DoWork
        Try
            Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd.Connection.Open()
            cmd.CommandTimeout = 60000
            'Update Payments Status in GMPS Payments out
            cmd.CommandText = "UPDATE [GMPS PAYMENTS OUT] SET [DebitTransactionsSigns]='Debit successfully',[ProcessingQueue]='Finish',[Status]='Complete',[ACK_State]='Complete ACK' where Datepart(year,[RegisterDate])='" & MeldeJahr & "' and Datepart(year,[RegisterDate])>'2015' and [Status] in ('Submit','Wait for sending message')"
            cmd.ExecuteNonQuery()
            'Delete Current Data in Details Table
            cmd.CommandText = "DELETE from [ZVSTAT_Details_from2014] where [ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            'Execute SQL Commands for Details
            Me.QueryText = "Select * from [ZVSTAT_Meldepositionen_from2014] where [PositionNr] not in ('T0') and [MeldeJahr]=" & MeldeJahr & ""
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            Dim da As New SqlDataAdapter
            Dim cmdda As SqlCommand = New SqlCommand(QueryText.Trim(), conn)
            da.SelectCommand = cmdda
            cmdda.CommandTimeout = 60000
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("PositionSQLcommand")) = False Then
                    SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command for Position Nr.: " & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode"))
                    cmd.CommandText = dt.Rows.Item(i).Item("PositionSQLcommand")
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("SQL Commands for Positions Nr.:" & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode") & " executed!")
                End If
            Next

            'Exchange Rates ECB
            SplashScreenManager.Default.SetWaitFormCaption("Update Exchange Rates")
            cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[CURRENCY RATE] from [ZVSTAT_Details_from2014] A INNER JOIN [EXCHANGE RATES ECB] B ON A.[Orig_Cur]=B.[CURRENCY CODE] where B.[EXCHANGE RATE DATE]=(SELECT max([EXCHANGE RATE DATE]) FROM [EXCHANGE RATES ECB] where Datepart(yyyy,[EXCHANGE RATE DATE])=" & MeldeJahr & ") and  A.[ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [ZVSTAT_Details_from2014] SET [ExchangeRate]=1 where [Orig_Cur]='EUR' and [ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            'Amount in EURO
            SplashScreenManager.Default.SetWaitFormCaption("Calculate Payment Amount in EURO")
            cmd.CommandText = "UPDATE [ZVSTAT_Details_from2014] SET [Amt_EUR]=Round([Orig_Amt]/[ExchangeRate],2) where  [ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            'Summen Felder ANZAHL + WERT
            SplashScreenManager.Default.SetWaitFormCaption("Calculate Anzahl und Wert")
            cmd.CommandText = "UPDATE A SET A.[Anzahl]=B.S from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN (Select [IdMeldepositionen],Count([Reference]) as S from [ZVSTAT_Details_from2014] where [ReportYear]=" & MeldeJahr & " group by [IdMeldepositionen]) B on A.[ID]=B.[IdMeldepositionen] where A.[MeldeJahr]=" & MeldeJahr & " and A.[AnzahlKz]='Y'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[Wert]=Round(B.S,0) from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN (Select [IdMeldepositionen],Sum([Amt_EUR]) as S from [ZVSTAT_Details_from2014] where [ReportYear]=" & MeldeJahr & " group by [IdMeldepositionen]) B on A.[ID]=B.[IdMeldepositionen] where A.[MeldeJahr]=" & MeldeJahr & " and A.[WertKz]='Y'"
            cmd.ExecuteNonQuery()
            'TOTAL SUMS
            'Execute SQL Commands for Details
            Me.QueryText = "Select * from [ZVSTAT_Meldepositionen_from2014] where [PositionNr] in ('T0') and [MeldeJahr]=" & MeldeJahr & ""
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            Dim da1 As New SqlDataAdapter
            Dim cmdda1 As SqlCommand = New SqlCommand(QueryText.Trim(), conn)
            da1.SelectCommand = cmdda1
            cmdda1.CommandTimeout = 60000
            dt = New DataTable()
            da1.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("PositionSQLcommand")) = False Then
                    SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command for Position Nr.: " & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode"))
                    cmd.CommandText = dt.Rows.Item(i).Item("PositionSQLcommand")
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("SQL Commands for Positions Nr.:" & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode") & " executed!")
                End If
            Next

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BgwZVSTAT_Run_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTAT_Run.RunWorkerCompleted
        Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text
        Me.ZVSTAT_Details_from2014TableAdapter.SetCommandTimeOut(120000)
        Me.ZVSTAT_Meldepositionen_from2014TableAdapter.SetCommandTimeOut(120000)

        Me.ZVSTAT_Details_from2014TableAdapter.FillByReportYear(Me.MeldewesenDataSet.ZVSTAT_Details_from2014, MeldeJahr)
        Me.ZVSTAT_Meldepositionen_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldepositionen_from2014, MeldeJahr)
        Me.ZVSTAT_Meldeschemas_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldeschemas_from2014, MeldeJahr)
        Me.ZVSTAT_MeldeJahr_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_MeldeJahr_from2014, MeldeJahr)
        SplashScreenManager.CloseForm(False)
        'Expand all details
        Me.ExpandAllRows(ZVSTAT_MeldeJahr_GridView)
        Me.ExpandAllRows(ZVSTAT_Meldeschemas_GridView)

    End Sub

    Private Sub SQL_ReRun_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_BarButtonItem.ItemClick
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            If Me.ZvStatMeldejahr_Comboboxedit.Text <> "" Then
                If MessageBox.Show("Should the ZV STATISTIC SQL Commands for Meldejahr " & Me.ZvStatMeldejahr_Comboboxedit.Text & " be Re-executed again?", "SQL COMMANDS RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If Me.BgwZVSTAT_ReRun.IsBusy = False Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Re-Executing ZV STATISTIC SQL Commands for" & Me.ZvStatMeldejahr_Comboboxedit.Text & vbNewLine & vbNewLine & "Current Data will be deleted!")
                        Me.BgwZVSTAT_ReRun.RunWorkerAsync()

                    End If
                End If
            End If
        Else

            MessageBox.Show("Please unlock first the Report State!", "REPORT IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub BgwZVSTAT_ReRun_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTAT_ReRun.DoWork
        Try
            Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd.Connection.Open()
            cmd.CommandTimeout = 60000
            'Update Payments Status in GMPS Payments out
            cmd.CommandText = "UPDATE [GMPS PAYMENTS OUT] SET [DebitTransactionsSigns]='Debit successfully',[ProcessingQueue]='Finish',[Status]='Complete',[ACK_State]='Complete ACK' where Datepart(year,[RegisterDate])='" & MeldeJahr & "' and Datepart(year,[RegisterDate])>'2015' and [Status] in ('Submit','Wait for sending message')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [ZVSTAT_MeldeJahr_from2014] where [MeldeJahr]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [ZVSTAT_Meldeschemas_from2014] where [MeldeJahr]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [ZVSTAT_Meldepositionen_from2014] where [MeldeJahr]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE from [ZVSTAT_Details_from2014] where [ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()

            cmd.CommandText = "INSERT INTO [ZVSTAT_MeldeJahr_from2014]([MeldeJahr])Values('" & Str(MeldeJahr) & "')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [ZVSTAT_Meldeschemas_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[IdMeldeJahr]) select [FormNr],[FormName],'" & Str(MeldeJahr) & "',(Select [ID] from [ZVSTAT_MeldeJahr_from2014] where [MeldeJahr]=" & MeldeJahr & ") from [ZVSTAT_Parameters_from2014] GROUP BY [FormNr],[FormName]"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [ZVSTAT_Meldepositionen_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[PositionNr],[PositionName],[Landkontext],[LandCode],[AnzahlKz],[WertKz],[PositionSQLcommand]) select [FormNr],[FormName],'" & Str(MeldeJahr) & "',[PositionNr],[PositionName],[Landkontext],[LandCode],[Anzahl],[Wert],[PositionSQLcommand] from [ZVSTAT_Parameters_from2014] where [LandCode] not in ('EU') order by [LfdNr]"
            cmd.ExecuteNonQuery()
            'Special Fall EU+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Me.QueryText = "Select * from [ZVSTAT_Parameters_from2014] where [LandCode] in ('EU')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Me.QueryText = "Select * from [COUNTRIES] where [EU EEA] in ('EU') and [COUNTRY CODE] not in ('DE')"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New DataTable()
                da1.Fill(dt1)
                For y = 0 To dt1.Rows.Count - 1
                    cmd.CommandText = "INSERT INTO [ZVSTAT_Meldepositionen_from2014]([MeldeschemaNr],[MeldeschemaName],[MeldeJahr],[PositionNr],[PositionName],[Landkontext],[LandCode],[AnzahlKz],[WertKz]) Values('" & dt.Rows.Item(i).Item("FormNr") & "','" & dt.Rows.Item(i).Item("FormName") & "','" & Str(MeldeJahr) & "','" & dt.Rows.Item(i).Item("PositionNr") & "','" & dt.Rows.Item(i).Item("PositionName") & "  " & dt1.Rows.Item(y).Item("COUNTRY NAME") & "', '" & dt.Rows.Item(i).Item("Landkontext") & "', '" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "', '" & dt.Rows.Item(i).Item("Anzahl") & "','" & dt.Rows.Item(i).Item("Wert") & "')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= (Select [PositionSQLcommand] from [ZVSTAT_Parameters_from2014] where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "'  and [LandCode]='EU') where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "' and [LandCode]='" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "' and [MeldeJahr]=" & MeldeJahr & ""
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= REPLACE([PositionSQLcommand],'<EU_LAND>','" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "') where [PositionNr]='" & dt.Rows.Item(i).Item("PositionNr") & "' and [LandCode]='" & dt1.Rows.Item(y).Item("COUNTRY CODE") & "' and [MeldeJahr]=" & MeldeJahr & ""
                    cmd.ExecuteNonQuery()
                Next
            Next
            cmd.CommandText = "UPDATE A SET A.[IdMeldeschemas]=B.[ID] from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN [ZVSTAT_Meldeschemas_from2014] B ON A.[MeldeschemaNr]=B.[MeldeschemaNr] and A.[MeldeJahr]=B.[MeldeJahr] where A.[MeldeJahr]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [ZVSTAT_Meldepositionen_from2014] SET [PositionSQLcommand]= REPLACE([PositionSQLcommand],'<MeldeJahr>',[MeldeJahr]) where [MeldeJahr]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()

            'Execute SQL Commands for Details
            Me.QueryText = "Select * from [ZVSTAT_Meldepositionen_from2014] where [PositionNr] not in ('T0') and [MeldeJahr]=" & MeldeJahr & ""
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            Dim da2 As New SqlDataAdapter
            Dim cmdda2 As SqlCommand = New SqlCommand(QueryText.Trim(), conn)
            da2.SelectCommand = cmdda2
            cmdda2.CommandTimeout = 60000
            dt = New DataTable()
            da2.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("PositionSQLcommand")) = False Then
                    SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command for Position Nr.: " & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode"))
                    cmd.CommandText = dt.Rows.Item(i).Item("PositionSQLcommand")
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("SQL Commands for Positions Nr.:" & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode") & " executed!")
                End If
            Next
            'Exchange Rates ECB
            SplashScreenManager.Default.SetWaitFormCaption("Update Exchange Rates")
            cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[CURRENCY RATE] from [ZVSTAT_Details_from2014] A INNER JOIN [EXCHANGE RATES ECB] B ON A.[Orig_Cur]=B.[CURRENCY CODE] where B.[EXCHANGE RATE DATE]=(SELECT max([EXCHANGE RATE DATE]) FROM [EXCHANGE RATES ECB] where Datepart(yyyy,[EXCHANGE RATE DATE])=" & MeldeJahr & ") and  A.[ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [ZVSTAT_Details_from2014] SET [ExchangeRate]=1 where [Orig_Cur]='EUR' and [ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            'Amount in EURO
            SplashScreenManager.Default.SetWaitFormCaption("Calculate Payment Amount in EURO")
            cmd.CommandText = "UPDATE [ZVSTAT_Details_from2014] SET [Amt_EUR]=Round([Orig_Amt]/[ExchangeRate],2) where  [ReportYear]=" & MeldeJahr & ""
            cmd.ExecuteNonQuery()
            'Summen Felder ANZAHL + WERT
            SplashScreenManager.Default.SetWaitFormCaption("Calculate Anzahl und Wert")
            cmd.CommandText = "UPDATE A SET A.[Anzahl]=B.S from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN (Select [IdMeldepositionen],Count([Reference]) as S from [ZVSTAT_Details_from2014] where [ReportYear]=" & MeldeJahr & " group by [IdMeldepositionen]) B on A.[ID]=B.[IdMeldepositionen] where A.[MeldeJahr]=" & MeldeJahr & " and A.[AnzahlKz]='Y'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[Wert]=Round(B.S,0) from [ZVSTAT_Meldepositionen_from2014] A INNER JOIN (Select [IdMeldepositionen],Sum([Amt_EUR]) as S from [ZVSTAT_Details_from2014] where [ReportYear]=" & MeldeJahr & " group by [IdMeldepositionen]) B on A.[ID]=B.[IdMeldepositionen] where A.[MeldeJahr]=" & MeldeJahr & " and A.[WertKz]='Y'"
            cmd.ExecuteNonQuery()
            'TOTAL SUMS
            'Execute SQL Commands for Details
            Me.QueryText = "Select * from [ZVSTAT_Meldepositionen_from2014] where [PositionNr] in ('T0') and [MeldeJahr]=" & MeldeJahr & ""
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            Dim da3 As New SqlDataAdapter
            Dim cmdda3 As SqlCommand = New SqlCommand(QueryText.Trim(), conn)
            da3.SelectCommand = cmdda3
            cmdda3.CommandTimeout = 60000
            dt = New DataTable()
            da3.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("PositionSQLcommand")) = False Then
                    SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command for Position Nr.: " & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode"))
                    cmd.CommandText = dt.Rows.Item(i).Item("PositionSQLcommand")
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("SQL Commands for Positions Nr.:" & dt.Rows.Item(i).Item("PositionNr") & vbNewLine & "Name:" & dt.Rows.Item(i).Item("PositionName") & vbNewLine & "Landkontext:" & dt.Rows.Item(i).Item("Landkontext") & "Landcode:" & dt.Rows.Item(i).Item("LandCode") & " executed!")
                End If
            Next

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BgwZVSTAT_ReRun_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTAT_ReRun.RunWorkerCompleted
        Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text

        Me.ZVSTAT_Details_from2014TableAdapter.SetCommandTimeOut(120000)
        Me.ZVSTAT_Meldepositionen_from2014TableAdapter.SetCommandTimeOut(120000)

        Me.ZVSTAT_Details_from2014TableAdapter.FillByReportYear(Me.MeldewesenDataSet.ZVSTAT_Details_from2014, MeldeJahr)
        Me.ZVSTAT_Meldepositionen_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldepositionen_from2014, MeldeJahr)
        Me.ZVSTAT_Meldeschemas_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldeschemas_from2014, MeldeJahr)
        Me.ZVSTAT_MeldeJahr_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_MeldeJahr_from2014, MeldeJahr)
        SplashScreenManager.CloseForm(False)
        'Expand all details
        Me.ExpandAllRows(ZVSTAT_MeldeJahr_GridView)
        Me.ExpandAllRows(ZVSTAT_Meldeschemas_GridView)

    End Sub

    Private Sub ZVSTAT_Meldepositionen_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ZVSTAT_Meldepositionen_GridView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "ZVSTAT_Meldepositionen_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PaymentsDetailsViewCaption = "Positions Nr. " & view.GetFocusedRowCellValue("PositionNr").ToString & "  Positions Name: " & view.GetFocusedRowCellValue("PositionName").ToString & "  Landkontext: " & view.GetFocusedRowCellValue("Landkontext").ToString & "  Landcode: " & view.GetFocusedRowCellValue("LandCode").ToString
            Me.ZVSTAT_PaymentDetails_GridView.ViewCaption = PaymentsDetailsViewCaption
        End If
    End Sub

    Private Sub ZVSTAT_Meldepositionen_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ZVSTAT_Meldepositionen_GridView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "ZVSTAT_Meldepositionen_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PaymentsDetailsViewCaption = "Positions Nr. " & view.GetFocusedRowCellValue("PositionNr").ToString & "  Positions Name: " & view.GetFocusedRowCellValue("PositionName").ToString & "  Landkontext: " & view.GetFocusedRowCellValue("Landkontext").ToString & "  Landcode: " & view.GetFocusedRowCellValue("LandCode").ToString
            Me.ZVSTAT_PaymentDetails_GridView.ViewCaption = PaymentsDetailsViewCaption
        End If


    End Sub

    Private Sub ZVSTAT_Meldepositionen_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles ZVSTAT_Meldepositionen_GridView.RowClick
        If Me.GridControl1.FocusedView.Name = "ZVSTAT_Meldepositionen_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PaymentsDetailsViewCaption = "Positions Nr. " & view.GetFocusedRowCellValue("PositionNr").ToString & "  Positions Name: " & view.GetFocusedRowCellValue("PositionName").ToString & "  Landkontext: " & view.GetFocusedRowCellValue("Landkontext").ToString & "  Landcode: " & view.GetFocusedRowCellValue("LandCode").ToString
            Me.ZVSTAT_PaymentDetails_GridView.ViewCaption = PaymentsDetailsViewCaption
        End If

    End Sub

    Private Sub ZVSTAT_PaymentDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZVSTAT_PaymentDetails_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ZVSTAT_PaymentDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ZVSTAT_PaymentDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ZVSTAT_Meldeschemas_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZVSTAT_Meldeschemas_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ZVSTAT_Meldeschemas_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ZVSTAT_Meldeschemas_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ZVSTAT_Meldepositionen_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ZVSTAT_Meldepositionen_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ZVSTAT_Meldepositionen_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ZVSTAT_Meldepositionen_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub CreateZvStatXMLfile_btn_Click(sender As Object, e As EventArgs) Handles CreateZvStatXMLfile_btn.Click
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then

            If XML_CREATE = "N" AndAlso SUPER_USER = "N" Then
                MessageBox.Show("You are not enabled to create the XML File for the ZVS Report to Deutsche Bundesbank", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                If MessageBox.Show("Should the XML File for the annual payments statistic report be generated ?", "XML FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Try
                        'Meldejahr definieren
                        Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text
                        'Bank Data load
                        Dim FIRMENNUMMER As String = Nothing
                        Dim BANKNAME As String = Nothing
                        Dim BANKSTRASSE As String = Nothing
                        Dim BANKPLZ As String = Nothing
                        Dim BANKORT As String = Nothing

                        Me.QueryText = "Select * from [BANK]"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            FIRMENNUMMER = dt.Rows.Item(i).Item("BLZ Bank")
                            BANKNAME = dt.Rows.Item(i).Item("Name Bank") & " , " & dt.Rows.Item(i).Item("Branch Bank")
                            BANKSTRASSE = dt.Rows.Item(i).Item("Strasse Bank")
                            BANKPLZ = dt.Rows.Item(i).Item("PLZ Bank")
                            BANKORT = dt.Rows.Item(i).Item("Ort Bank")
                        Next

                        'Parameter Load
                        Dim XMLSAVEFILE As String = Nothing
                        Dim ABSENDERANREDE As String = Nothing
                        Dim ABSENDERVORNAME As String = Nothing
                        Dim ABSENDERZUNAME As String = Nothing
                        Dim ABSENDERABTEILUNG As String = Nothing
                        Dim ABSENDERTELEFON As String = Nothing
                        Dim ABSENDERFAX As String = Nothing
                        Dim ABSENDEREMAIL As String = Nothing
                        Dim ABSENDEREXTRANETID As String = Nothing
                        Dim MELDDERANREDE As String = Nothing
                        Dim MELDERVORNAME As String = Nothing
                        Dim MELDERZUNAME As String = Nothing
                        Dim MELDERABTEILUNG As String = Nothing
                        Dim MELDERTELEFON As String = Nothing
                        Dim MELDERFAX As String = Nothing
                        Dim MELDEREMAIL As String = Nothing
                        Dim MELDEREXTRANETID As String = Nothing

                        Me.QueryText = "Select * from [PARAMETER] where [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='ZV_STAT'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ZVSTAXMLSAVE" Then
                                XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERANREDE" Then
                                ABSENDERANREDE = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERVORNAME" Then
                                ABSENDERVORNAME = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERZUNAME" Then
                                ABSENDERZUNAME = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERABTEILUNG" Then
                                ABSENDERABTEILUNG = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERTELEFON" Then
                                ABSENDERTELEFON = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERFAX" Then
                                ABSENDERFAX = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDEREMAIL" Then
                                ABSENDEREMAIL = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDEREXTRANETID" Then
                                ABSENDEREXTRANETID = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDDERANREDE" Then
                                MELDDERANREDE = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERVORNAME" Then
                                MELDERVORNAME = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERZUNAME" Then
                                MELDERZUNAME = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERTELEFON" Then
                                MELDERTELEFON = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERFAX" Then
                                MELDERFAX = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDEREMAIL" Then
                                MELDEREMAIL = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDEREXTRANETID" Then
                                MELDEREXTRANETID = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                            If dt.Rows.Item(i).Item("PARAMETER1") = "MELDERABTEILUNG" Then
                                MELDERABTEILUNG = dt.Rows.Item(i).Item("PARAMETER2")
                            End If
                        Next

                        'XML DATEI erstellungsdatum un Zeitdefinieren
                        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
                        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
                        'MELDETERMIN
                        Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
                        Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
                        Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

                        Dim MyWriter As System.Xml.XmlWriter
                        Dim MySettings As New System.Xml.XmlWriterSettings
                        MySettings.Indent = True
                        MySettings.ConformanceLevel = ConformanceLevel.Auto
                        MySettings.IndentChars = "    "

                        MySettings.NewLineOnAttributes = False
                        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")

                        MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & "\zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml", MySettings)

                        With MyWriter

                            .WriteStartDocument()
                            .WriteStartElement("zvs", "LIEFERUNG-ZVS", "http://www.bundesbank.de/statistik/zvs/v1")
                            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                            .WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.bundesbank.de/statistik/zvs/v1 BbkXmwZVS2014.xsd")
                            .WriteAttributeString("xmlns", "zvs", Nothing, "http://www.bundesbank.de/statistik/zvs/v1")
                            .WriteAttributeString("xmlns", "bbk", Nothing, "http://www.bundesbank.de/xmw/2003-01-01")
                            .WriteAttributeString("version", "1.0")
                            .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")
                            .WriteAttributeString("stufe", "Produktion")
                            .WriteAttributeString("bereich", "Statistik")


                            'ELEMENT-ABSENDER
                            .WriteStartElement("bbk", "ABSENDER", "http://www.bundesbank.de/xmw/2003-01-01")
                            .WriteElementString("zvs", "BLZ", Nothing, FIRMENNUMMER)
                            .WriteElementString("bbk", "NAME", Nothing, BANKNAME)
                            .WriteElementString("bbk", "STRASSE", Nothing, BANKSTRASSE)
                            .WriteElementString("bbk", "ORT", Nothing, BANKPLZ & " " & BANKORT)
                            .WriteElementString("bbk", "LAND", Nothing, "DE")
                            '##############################
                            'UNTERELEMENT-KONTAKT
                            .WriteStartElement("bbk", "KONTAKT", "http://www.bundesbank.de/xmw/2003-01-01")
                            .WriteElementString("bbk", "ANREDE", Nothing, ABSENDERANREDE)
                            .WriteElementString("bbk", "VORNAME", Nothing, ABSENDERVORNAME)
                            .WriteElementString("bbk", "ZUNAME", Nothing, ABSENDERZUNAME)
                            .WriteElementString("bbk", "ABTEILUNG", Nothing, ABSENDERABTEILUNG)
                            .WriteElementString("bbk", "TELEFON", Nothing, ABSENDERTELEFON)
                            .WriteElementString("bbk", "FAX", Nothing, ABSENDERFAX)
                            .WriteElementString("bbk", "EMAIL", Nothing, ABSENDEREMAIL)
                            .WriteElementString("bbk", "EXTRANET-ID", Nothing, ABSENDEREXTRANETID)
                            .WriteEndElement() 'KONTAKT
                            .WriteEndElement() 'ABSENDER
                            'MELDUNG ERSTELLZEIT
                            .WriteStartElement("zvs", "MELDUNG", "http://www.bundesbank.de/statistik/zvs/v1")
                            .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")
                            '.WriteAttributeString("korrektur", "nein")
                            'MELDER
                            .WriteStartElement("bbk", "MELDER", "http://www.bundesbank.de/xmw/2003-01-01")
                            .WriteElementString("zvs", "BLZ", Nothing, FIRMENNUMMER)
                            .WriteElementString("bbk", "NAME", Nothing, BANKNAME)
                            .WriteElementString("bbk", "STRASSE", Nothing, BANKSTRASSE)
                            .WriteElementString("bbk", "ORT", Nothing, BANKPLZ & "  " & BANKORT)
                            'UNTERELEMENT-KONTAKT
                            .WriteStartElement("bbk", "KONTAKT", "http://www.bundesbank.de/xmw/2003-01-01")
                            .WriteElementString("bbk", "ANREDE", Nothing, MELDDERANREDE)
                            .WriteElementString("bbk", "VORNAME", Nothing, MELDERVORNAME)
                            .WriteElementString("bbk", "ZUNAME", Nothing, MELDERZUNAME)
                            .WriteElementString("bbk", "ABTEILUNG", Nothing, MELDERABTEILUNG)
                            .WriteElementString("bbk", "TELEFON", Nothing, MELDERTELEFON)
                            .WriteElementString("bbk", "FAX", Nothing, MELDERFAX)
                            .WriteElementString("bbk", "EMAIL", Nothing, MELDEREMAIL)
                            .WriteElementString("bbk", "EXTRANET-ID", Nothing, MELDEREXTRANETID)
                            .WriteEndElement() 'KONTAKT
                            .WriteEndElement() 'MELDER
                            'MELDETERMIN
                            .WriteElementString("zvs", "MELDETERMIN", Nothing, MELDETERMIN)

                            'FORMULAR ZVS1+++++++++++++++++++++
                            .WriteStartElement("zvs", "FORMULAR-ZVS1", "http://www.bundesbank.de/statistik/zvs/v1")
                            Me.QueryText = "SELECT * FROM [ZVSTAT_Meldepositionen_from2014] where [MeldeschemaNr]='ZVS1' and [MeldeJahr]=" & MeldeJahr & " and [Anzahl] is not NULL"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                                    .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr"))
                                    .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode"))
                                    .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl"))
                                    .WriteEndElement()
                                Next
                            End If
                            .WriteEndElement()

                            '++++++++++++++++++++++++++++++++++
                            'FORMULAR ZVS4+++++++++++++++++++++
                            .WriteStartElement("zvs", "FORMULAR-ZVS4", "http://www.bundesbank.de/statistik/zvs/v1")
                            'Dim ZV3SHEMA As String = "ZV3- " & Me.UltraLabel56.Text
                            Me.QueryText = "SELECT * FROM [ZVSTAT_Meldepositionen_from2014] where [MeldeschemaNr]='ZVS4' and [MeldeJahr]=" & MeldeJahr & " and [Anzahl] is not NULL"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                                    .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr"))
                                    .WriteAttributeString("Landkontext", dt.Rows.Item(i).Item("Landkontext"))
                                    .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode"))
                                    .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl"))
                                    .WriteAttributeString("Wert", dt.Rows.Item(i).Item("Wert"))
                                    .WriteEndElement()
                                Next
                            End If
                            .WriteEndElement()

                            '++++++++++++++++++++++++++++++++++
                            'FORMULAR ZVS8++++++++++++++++++++++
                            .WriteStartElement("zvs", "FORMULAR-ZVS8", "http://www.bundesbank.de/statistik/zvs/v1")
                            Me.QueryText = "SELECT * FROM [ZVSTAT_Meldepositionen_from2014] where [MeldeschemaNr]='ZVS8' and [MeldeJahr]=" & MeldeJahr & " and [Anzahl] is not NULL"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("zvs", "FELD", "http://www.bundesbank.de/statistik/zvs/v1")
                                    .WriteAttributeString("Pos", dt.Rows.Item(i).Item("PositionNr"))
                                    .WriteAttributeString("Landkontext", dt.Rows.Item(i).Item("Landkontext"))
                                    .WriteAttributeString("Land", dt.Rows.Item(i).Item("LandCode"))
                                    .WriteAttributeString("Anzahl", dt.Rows.Item(i).Item("Anzahl"))
                                    .WriteAttributeString("Wert", dt.Rows.Item(i).Item("Wert"))
                                    .WriteEndElement()
                                Next
                            End If
                            .WriteEndElement()
                            '++++++++++++++++++++++++++++++++++
                            .WriteEndDocument()
                            .Close()

                        End With

                        If MessageBox.Show("Following XML file has being generated: " & "zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml" & vbNewLine _
                               & "and saved under the following directory:" & vbNewLine _
                        & XMLSAVEFILE & vbNewLine & vbNewLine _
                        & "Should the directory be opened?", "ZVSTA XML File succesfully generated", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                            System.Diagnostics.Process.Start(XMLSAVEFILE)

                        End If

                        'VALIDIERUNG DER XML DATEI
                        Dim myDocument As New XmlDocument
                        myDocument.Load(XMLSAVEFILE & "\zvsta" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml")
                        myDocument.Schemas.Add(Nothing, XMLSAVEFILE & "\BbkXmwZVS2014.xsd")
                        Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
                        myDocument.Validate(eventHandler)

                        Exit Sub

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub

                    End Try
                Else
                    Exit Sub

                End If

            End If
        Else

            MessageBox.Show("Please unlock first the Report State!", "REPORT IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Select Case e.Severity
            Case XmlSeverityType.Error
                MsgBox("Error: {0}", e.Message, "ERROR")
                'Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                'Debug.WriteLine("Warning {0}", e.Message)
                MsgBox("Warning {0}", e.Message, "WARNING")

        End Select
    End Sub

    Private Sub ZVStatistic_Report_btn_Click(sender As Object, e As EventArgs) Handles ZVStatistic_Report_btn.Click
        If Me.ZvStatMeldejahr_Comboboxedit.Text <> "" Then
            Dim d As Integer = Me.ZvStatMeldejahr_Comboboxedit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating anual Payments statistic report for " & Me.ZvStatMeldejahr_Comboboxedit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\ZVSTA_Jahresdaten_from2014.rpt")
            CrRep.SetDataSource(MeldewesenDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "MeldeJahr"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Annual Payments statistic Report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub Print_Export_ZVSTAT_Meldung_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ZVSTAT_Meldung_Gridview_btn.Click
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
        Dim reportfooter As String = "ANNUAL PAYMENTS STATISTIC " & "   " & "for: " & Me.ZvStatMeldejahr_Comboboxedit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_ZVSTAT_Parameters_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ZVSTAT_Parameters_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
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
        Dim reportfooter As String = "PAYMENTS STATISTIC PARAMETERS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ZvStatMeldejahr_Comboboxedit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ZvStatMeldejahr_Comboboxedit.SelectedIndexChanged
        If Me.ZvStatMeldejahr_Comboboxedit.Text <> "" Then
            Dim MeldeJahr As Double = Me.ZvStatMeldejahr_Comboboxedit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Annual Payment Statistic Data for " & MeldeJahr)

            Me.ZVSTAT_Details_from2014TableAdapter.FillByReportYear(Me.MeldewesenDataSet.ZVSTAT_Details_from2014, MeldeJahr)
            Me.ZVSTAT_Meldepositionen_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldepositionen_from2014, MeldeJahr)
            Me.ZVSTAT_Meldeschemas_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_Meldeschemas_from2014, MeldeJahr)
            Me.ZVSTAT_MeldeJahr_from2014TableAdapter.FillByMeldeJahr(Me.MeldewesenDataSet.ZVSTAT_MeldeJahr_from2014, MeldeJahr)
            'Expand all details
            Me.ExpandAllRows(ZVSTAT_MeldeJahr_GridView)
            Me.ExpandAllRows(ZVSTAT_Meldeschemas_GridView)
            REPORT_LOCK_UNLOCK()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ReportLocked_CheckEdit_CheckStateChanged(sender As Object, e As EventArgs) Handles ReportLocked_CheckEdit.CheckStateChanged

        Try
            REPORT_LOCK_UNLOCK()
            Me.Validate()
            Me.ZVSTAT_MeldeJahr_from2014BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
            '***********************************************************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub
End Class