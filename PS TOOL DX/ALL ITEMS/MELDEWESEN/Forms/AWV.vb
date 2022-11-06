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
Public Class AWV

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim RepDate As Date
    Dim rdsql As String = Nothing

    Dim XML_CREATE As String
    Dim CustomersVerticalGrid As New CustomersVG()
    Dim CustomerContractVG As New AllContractsAccountsVG()



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

    Private Sub BANKBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BANKBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)

    End Sub

    Private Sub AWV_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.MeldewesenDataSet.HasChanges = True Then
            If MessageBox.Show("There some unsaved changes in this Form" & vbNewLine & "After closing the Form all changes will be lost!" & vbNewLine & "Exit anyway?", "UNSAVED CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub AWV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl6.EmbeddedNavigator.ButtonClick, AddressOf GridControl6_EmbeddedNavigator_ButtonClick
        AddHandler GridControl7.EmbeddedNavigator.ButtonClick, AddressOf GridControl7_EmbeddedNavigator_ButtonClick
        AddHandler GridControl8.EmbeddedNavigator.ButtonClick, AddressOf GridControl8_EmbeddedNavigator_ButtonClick

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        '*******Get the XML Creator for the file************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='AWVXML_CREATOR' and [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='AWV' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        Dim Result As String = cmd.ExecuteScalar
        cmd.Connection.Close()
        If Result <> "" Then
            XML_CREATE = "Y"
        Else
            XML_CREATE = "N"
        End If
        '***********************************************************************

        'Get Max Report Date
        cmd.CommandText = "SELECT MAX([Z14Z15MeldeMonat]) FROM [AWVz14z15] "
        cmd.Connection.Open()
        Dim MaxRepDate As Date = cmd.ExecuteScalar
        RepDate = MaxRepDate
        cmd.Connection.Close()


        'Bind Combobox
        Me.QueryText = "select * from [AWVz14z15] ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            AWV_ReportDate_ComboBoxEdit.Properties.Items.Add(row("Z14Z15MeldeMonatName"))
        Next
        Me.AWV_ReportDate_ComboBoxEdit.Text = dt.Rows.Item(0).Item("Z14Z15MeldeMonatName")


        Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, MaxRepDate)
        Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, MaxRepDate)
        Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, MaxRepDate)
        Me.AWVz15TableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz15, MaxRepDate)
        Me.AWVz1415RelevantDataTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz1415RelevantData, MaxRepDate)
        Me.AWVz14TableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz14, MaxRepDate)
        Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, MaxRepDate)
        Me.AWVz14z15TableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz14z15, MaxRepDate)
        Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, MaxRepDate)
        'External Data Load
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.COUNTRIESTableAdapter1.Fill(Me.MeldewesenDataSet.COUNTRIES)
        Me.BANKTableAdapter.Fill(Me.MeldewesenDataSet.BANK)

        REPORT_LOCK_UNLOCK()

    End Sub

    Private Sub REPORT_LOCK_UNLOCK()
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
            Me.ReportLocked_CheckEdit.Text = "Report is locked"
            Me.ReportLocked_CheckEdit.BackColor = Color.Red
            Me.ReportLocked_CheckEdit.ForeColor = Color.White
            Me.AWVz14_BaseView.OptionsBehavior.Editable = False
            Me.AWVz14_BaseView.OptionsBehavior.ReadOnly = True
            Me.AWVz15_BaseView.OptionsBehavior.Editable = False
            Me.AWVz15_BaseView.OptionsBehavior.ReadOnly = True
            Me.AWVz4_DIKAPOSTEN_BaseView.OptionsBehavior.Editable = False
            Me.AWVz4_DIKAPOSTEN_BaseView.OptionsBehavior.ReadOnly = True
            Me.AWVz4_TRANSITPOSTEN_BaseView.OptionsBehavior.Editable = False
            Me.AWVz4_TRANSITPOSTEN_BaseView.OptionsBehavior.ReadOnly = True
            Me.AWVz4_DIRINVPOSTEN_BaseView.OptionsBehavior.Editable = False
            Me.AWVz4_DIRINVPOSTEN_BaseView.OptionsBehavior.ReadOnly = True
            Me.AWVz10_BandedGridView.OptionsBehavior.Editable = False
            Me.AWVz10_BandedGridView.OptionsBehavior.ReadOnly = True
            Me.AWVz11_GridView.OptionsBehavior.Editable = False
            Me.AWVz11_GridView.OptionsBehavior.ReadOnly = True
        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.ReportLocked_CheckEdit.Text = "Report is unlocked"
            Me.ReportLocked_CheckEdit.BackColor = Color.Green
            Me.ReportLocked_CheckEdit.ForeColor = Color.White
            Me.AWVz14_BaseView.OptionsBehavior.Editable = True
            Me.AWVz14_BaseView.OptionsBehavior.ReadOnly = False
            Me.AWVz15_BaseView.OptionsBehavior.Editable = True
            Me.AWVz15_BaseView.OptionsBehavior.ReadOnly = False
            Me.AWVz4_DIKAPOSTEN_BaseView.OptionsBehavior.Editable = True
            Me.AWVz4_DIKAPOSTEN_BaseView.OptionsBehavior.ReadOnly = False
            Me.AWVz4_TRANSITPOSTEN_BaseView.OptionsBehavior.Editable = True
            Me.AWVz4_TRANSITPOSTEN_BaseView.OptionsBehavior.ReadOnly = False
            Me.AWVz4_DIRINVPOSTEN_BaseView.OptionsBehavior.Editable = True
            Me.AWVz4_DIRINVPOSTEN_BaseView.OptionsBehavior.ReadOnly = False
            Me.AWVz10_BandedGridView.OptionsBehavior.Editable = True
            Me.AWVz10_BandedGridView.OptionsBehavior.ReadOnly = False
            Me.AWVz11_GridView.OptionsBehavior.Editable = True
            Me.AWVz11_GridView.OptionsBehavior.ReadOnly = False
        End If
    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.AWVz10POSTENBindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                    Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, RepDate)
                Else
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        '    Dim row As System.Data.DataRow = AWVz10_BandedGridView.GetDataRow(AWVz10_BandedGridView.FocusedRowHandle)
        '    Dim ISIN As String = row(3)
        '    Dim BEZEICHNUNG As String = row(4)
        '    Dim ID As String = row(0)
        '    If MessageBox.Show("Should the Security with ISIN Code: " & ISIN & "  be deleted?", "DELETE POSTEN + WERTPAPIER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        '        Dim ISINDelete As MeldewesenDataSet.AWVz10POSTENRow
        '        ISINDelete = MeldewesenDataSet.AWVz10POSTEN.FindByID(ID)
        '        ISINDelete.Delete()
        '        AWVz10_BandedGridView.DeleteSelectedRows()
        '        GridControl1.Update()
        '        Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
        '        Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, RepDate)
        '    Else
        '        e.Handled = True
        '    End If
        'End If
        If AWVz10_BandedGridView.RowCount > 0 Then
            If e.Button.Tag.ToString = "Delete AWVz10 Posten" Then
                Dim row As System.Data.DataRow = AWVz10_BandedGridView.GetDataRow(AWVz10_BandedGridView.FocusedRowHandle)
                Dim ISIN As String = row(3)
                Dim BEZEICHNUNG As String = row(4)
                Dim ID As String = row(0)
                If MessageBox.Show("Should the Security with ISIN Code: " & ISIN & "  be deleted?", "DELETE POSTEN + WERTPAPIER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    AWVz10_BandedGridView.DeleteRow(AWVz10_BandedGridView.FocusedRowHandle)
                    Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                    Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, RepDate)
                Else
                    e.Handled = True
                End If
            End If
        End If


    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)


        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.AWVz4DIKAPPOSTENBindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                    Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, RepDate)
                Else
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        '    Dim row As System.Data.DataRow = AWVz4_DIKAPOSTEN_BaseView.GetDataRow(AWVz4_DIKAPOSTEN_BaseView.FocusedRowHandle)
        '    Dim ZAHLUNGSZWECK As String = row(3)
        '    Dim ID As String = row(0)
        '    If MessageBox.Show("Should the DIKAPOSTEN: " & ZAHLUNGSZWECK & "  be deleted?", "DELETE POSTEN + WERTPAPIER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        '        Dim DIKADelete As MeldewesenDataSet.AWVz4DIKAPPOSTENRow
        '        DIKADelete = MeldewesenDataSet.AWVz4DIKAPPOSTEN.FindByID(ID)
        '        DIKADelete.Delete()
        '        AWVz4_DIKAPOSTEN_BaseView.DeleteSelectedRows()
        '        GridControl2.Update()
        '        Me.AWVz4DIKAPPOSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN)
        '        Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, RepDate)
        '    Else
        '        e.Handled = True
        '    End If
        'End If
        If AWVz4_DIKAPOSTEN_BaseView.RowCount > 0 Then
            If e.Button.Tag.ToString = "Delete DIKAPOSTEN" Then
                Dim row As System.Data.DataRow = AWVz4_DIKAPOSTEN_BaseView.GetDataRow(AWVz4_DIKAPOSTEN_BaseView.FocusedRowHandle)
                Dim ZAHLUNGSZWECK As String = row(3)
                Dim ID As String = row(0)
                If MessageBox.Show("Should the DIKAPOSTEN: " & ZAHLUNGSZWECK & "  be deleted?", "DELETE POSTEN + WERTPAPIER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.AWVz4_DIKAPOSTEN_BaseView.DeleteRow(AWVz4_DIKAPOSTEN_BaseView.FocusedRowHandle)
                    Me.AWVz4DIKAPPOSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN)
                    Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, RepDate)
                Else
                    e.Handled = True
                End If
            End If
        End If


    End Sub

    Private Sub GridControl6_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.AWVz4TRANSITPOSTENBindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                    Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, RepDate)
                Else
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        '    Dim row As System.Data.DataRow = AWVz4_TRANSITPOSTEN_BaseView.GetDataRow(AWVz4_TRANSITPOSTEN_BaseView.FocusedRowHandle)
        '    Dim WARENBEZEICHNUNG As String = row(4)
        '    Dim ID As String = row(0)
        '    If MessageBox.Show("Should the TRANSITPOSTEN: " & WARENBEZEICHNUNG & "  be deleted?", "DELETE TRANSITPOSTEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        '        Dim TRANSITDelete As MeldewesenDataSet.AWVz4TRANSITPOSTENRow
        '        TRANSITDelete = MeldewesenDataSet.AWVz4TRANSITPOSTEN.FindByID(ID)
        '        TRANSITDelete.Delete()
        '        AWVz4_TRANSITPOSTEN_BaseView.DeleteSelectedRows()
        '        GridControl6.Update()
        '        Me.AWVz4TRANSITPOSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN)
        '        Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, RepDate)
        '    Else
        '        e.Handled = True
        '    End If
        'End If
        If AWVz4_TRANSITPOSTEN_BaseView.RowCount > 0 Then
            If e.Button.Tag.ToString = "Delete TRANSITPOSTEN" Then
                Dim row As System.Data.DataRow = AWVz4_TRANSITPOSTEN_BaseView.GetDataRow(AWVz4_TRANSITPOSTEN_BaseView.FocusedRowHandle)
                Dim WARENBEZEICHNUNG As String = row(4)
                Dim ID As String = row(0)
                If MessageBox.Show("Should the TRANSITPOSTEN: " & WARENBEZEICHNUNG & "  be deleted?", "DELETE TRANSITPOSTEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    AWVz4_TRANSITPOSTEN_BaseView.DeleteRow(AWVz4_TRANSITPOSTEN_BaseView.FocusedRowHandle)
                    Me.AWVz4TRANSITPOSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN)
                    Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, RepDate)
                Else
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Private Sub GridControl7_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.AWVz4DIRINVPOSTENBindingSource.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                    Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, RepDate)
                Else
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        '    Dim row As System.Data.DataRow = AWVz4_DIRINVPOSTEN_BaseView.GetDataRow(AWVz4_DIRINVPOSTEN_BaseView.FocusedRowHandle)
        '    Dim BEZEICHNUNG As String = row(4)
        '    Dim ID As String = row(0)
        '    If MessageBox.Show("Should the DIRINVPOSTEN: " & BEZEICHNUNG & "  be deleted?", "DELETE DIRINPOSTEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        '        Dim DIRINVDelete As MeldewesenDataSet.AWVz4DIRINVPOSTENRow
        '        DIRINVDelete = MeldewesenDataSet.AWVz4DIRINVPOSTEN.FindByID(ID)
        '        DIRINVDelete.Delete()
        '        AWVz4_DIRINVPOSTEN_BaseView.DeleteSelectedRows()
        '        GridControl7.Update()
        '        Me.AWVz4DIRINVPOSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN)
        '        Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, RepDate)
        '    Else
        '        e.Handled = True
        '    End If
        'End If
        If AWVz4_DIRINVPOSTEN_BaseView.RowCount > 0 Then
            If e.Button.Tag.ToString = "Delete DIRINVPOSTEN" Then
                Dim row As System.Data.DataRow = AWVz4_DIRINVPOSTEN_BaseView.GetDataRow(AWVz4_DIRINVPOSTEN_BaseView.FocusedRowHandle)
                Dim BEZEICHNUNG As String = row(4)
                Dim ID As String = row(0)
                If MessageBox.Show("Should the DIRINVPOSTEN: " & BEZEICHNUNG & "  be deleted?", "DELETE DIRINPOSTEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    AWVz4_DIRINVPOSTEN_BaseView.DeleteRow(AWVz4_DIRINVPOSTEN_BaseView.FocusedRowHandle)
                    Me.AWVz4DIRINVPOSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN)
                    Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, RepDate)
                Else
                    e.Handled = True
                End If
            End If
        End If


    End Sub

    Private Sub GridControl8_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.AWVz11POSTENBindingSource1.EndEdit()
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                    Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, RepDate)
                Else
                    e.Handled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        '    Dim row As System.Data.DataRow = AWVz11_GridView.GetDataRow(AWVz11_GridView.FocusedRowHandle)
        '    Dim BEZEICHNUNG As String = row(4)
        '    Dim ID As String = row(0)
        '    If MessageBox.Show("Should the ID Nr: " & ID & "  be deleted?", "DELETE AWVz11 Posten", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        '        Dim AWVz11_Delete As MeldewesenDataSet.AWVz11POSTENRow
        '        AWVz11_Delete = MeldewesenDataSet.AWVz11POSTEN.FindByID(ID)
        '        AWVz11_Delete.Delete()
        '        AWVz11_GridView.DeleteSelectedRows()
        '        GridControl8.Update()
        '        Me.AWVz11POSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz11POSTEN)
        '        Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, RepDate)
        '    Else
        '        e.Handled = True
        '    End If
        'End If

        If AWVz11_GridView.RowCount > 0 Then
            If e.Button.Tag.ToString = "Delete AWVz11 Posten" Then
                Dim row As System.Data.DataRow = AWVz11_GridView.GetDataRow(AWVz11_GridView.FocusedRowHandle)
                Dim BEZEICHNUNG As String = row(4)
                Dim ID As String = row(0)
                If MessageBox.Show("Should the ID Nr: " & ID & "  be deleted?", "DELETE AWVz11 Posten", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    AWVz11_GridView.DeleteRow(AWVz11_GridView.FocusedRowHandle)
                    Me.AWVz11POSTENTableAdapter.Update(Me.MeldewesenDataSet.AWVz11POSTEN)
                    Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, RepDate)
                Else
                    e.Handled = True
                End If
            End If
        End If


    End Sub

    Private Sub AWV_ReportDate_ComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AWV_ReportDate_ComboBoxEdit.SelectedIndexChanged
        If Me.AWV_ReportDate_ComboBoxEdit.Text <> "" Then


            cmd.CommandText = "SELECT [Z14Z15MeldeMonat] FROM [AWVz14z15] where [Z14Z15MeldeMonatName]='" & Me.AWV_ReportDate_ComboBoxEdit.Text & "' "
            cmd.Connection.Open()
            RepDate = cmd.ExecuteScalar
            cmd.Connection.Close()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load AWV data for " & RepDate)

            Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, RepDate)
            Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, RepDate)
            Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, RepDate)
            Me.AWVz15TableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz15, RepDate)
            Me.AWVz1415RelevantDataTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz1415RelevantData, RepDate)
            Me.AWVz14TableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz14, RepDate)
            Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, RepDate)
            Me.AWVz14z15TableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz14z15, RepDate)
            Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, RepDate)

            REPORT_LOCK_UNLOCK()

            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub AWVz10_BandedGridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles AWVz10_BandedGridView.CellValueChanged
        If AWVz10_BandedGridView.FocusedColumn.FieldName = "WERTPAPIER_LAND_ISOCODE" Then
            'Get the currently edited value 
            Dim LAND_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(LAND_CODE) = 2 Then
                cmd.CommandText = "SELECT * FROM [COUNTRIES] where [COUNTRY CODE]='" & LAND_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    AWVz10_BandedGridView.SetRowCellValue(e.RowHandle, "WERTPAPIER_LAND_NAME", dt.Rows.Item(0).Item("COUNTRY NAME"))
                Else
                    MessageBox.Show("COUNTRY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    AWVz10_BandedGridView.SetRowCellValue(e.RowHandle, "WERTPAPIER_LAND_NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub AWVz10_BandedGridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles AWVz10_BandedGridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz10_BandedGridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles AWVz10_BandedGridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz10_BandedGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz10_BandedGridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz10_BandedGridView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz10_BandedGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub


    Private Sub AWVz10_BandedGridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AWVz10_BandedGridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim BELEG_ART As GridColumn = View.Columns("BELEGART")
        Dim KENNZAHL_WERTPAPIER As GridColumn = View.Columns("KENNZAHL")
        Dim WERTPAPIER_ISIN As GridColumn = View.Columns("WERTPAPIER_ISIN")
        Dim WERTPAPIER_BEZEICH As GridColumn = View.Columns("WERTAPPIER_BEZEICHNUNG")
        Dim NOMINAL_STUECK As GridColumn = View.Columns("NOMINAL_STUECK")
        Dim WERTPAPIER_SON As GridColumn = View.Columns("WERTPAPIER_SoN")
        Dim WERTPAPIER_LAND As GridColumn = View.Columns("WERTPAPIER_LAND_ISOCODE")
        Dim WERTPAPIER_WHG As GridColumn = View.Columns("WERTPAPIER_WHG")
        Dim WERTPAPIER_BETRAG As GridColumn = View.Columns("WERTPAPIER_BETRAG")

        Dim Belegart As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn2).ToString
        Dim KennzahlWertpapier As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn3).ToString
        Dim WertpapierIsin As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn4).ToString
        Dim WertpapierBezeich As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn5).ToString
        Dim NominalStueck As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn6).ToString
        Dim WertpapierSon As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn7).ToString
        Dim WertpapierLand As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn8).ToString
        Dim WertpapierWhg As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn10).ToString
        Dim WertpapierBetrag As String = View.GetRowCellValue(e.RowHandle, BandedGridColumn11).ToString

        If Belegart = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BELEG_ART, "Belegart must not be empty")
            e.ErrorText = "Belegart must not be empty"
        End If
        If KennzahlWertpapier = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KENNZAHL_WERTPAPIER, "Kennzahl  must not be empty")
            e.ErrorText = "Kennzahl  must not be empty"
        End If

        If WertpapierIsin = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERTPAPIER_ISIN, "ISIN Nr.  must not be empty")
            e.ErrorText = "ISIN Nr.  must not be empty" & vbNewLine & "Bei Finanzderivaten muss XXXXXXXXXXXX einegeben werden!"
        End If

        If WertpapierBezeich = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERTPAPIER_BEZEICH, "Bezeichnung  must not be empty")
            e.ErrorText = "Bezeichnung  must not be empty"
        End If

        If WertpapierIsin = "XXXXXXXXXXXX" And WertpapierSon = "" Then
            e.Valid = True
        ElseIf WertpapierIsin <> "XXXXXXXXXXXX" And WertpapierSon = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERTPAPIER_SON, "Nominalbetrag/Stückzahl  must not be empty")
            e.ErrorText = "Nominalbetrag/Stückzahl  must not be empty"
        End If

        If WertpapierLand = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERTPAPIER_LAND, "Landkennzeichen must not be empty")
            e.ErrorText = "Landkennzeichen must not be empty"
        End If
        If WertpapierWhg = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERTPAPIER_WHG, "Währung  must not be empty")
            e.ErrorText = "Währung  must not be empty"
        End If
        If WertpapierBetrag = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(WERTPAPIER_BETRAG, "Betrag  must not be empty")
            e.ErrorText = "Betrag  must not be empty"
        End If
    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.CellValueChanged
        If AWVz4_DIKAPOSTEN_BaseView.FocusedColumn.FieldName = "DIKA_ISOLAND" Then
            'Get the currently edited value 
            Dim LAND_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(LAND_CODE) = 2 Then
                cmd.CommandText = "SELECT * FROM [COUNTRIES] where [COUNTRY CODE]='" & LAND_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    AWVz4_DIKAPOSTEN_BaseView.SetRowCellValue(e.RowHandle, "DIKA_ISOLAND_NAME", dt.Rows.Item(0).Item("COUNTRY NAME"))
                Else
                    MessageBox.Show("COUNTRY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    AWVz4_DIKAPOSTEN_BaseView.SetRowCellValue(e.RowHandle, "DIKA_ISOLAND_NAME", "")
                End If
            End If

        End If
    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.CustomRowCellEditForEditing

    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim DIKA_BELEGART As GridColumn = View.Columns("DIKA_BELEGART")
        Dim DIKA_KENNZAHL As GridColumn = View.Columns("DIKA_KENNZAHL")
        Dim DIKA_ZAHLUNGSZWECK As GridColumn = View.Columns("DIKA_ZAHLUNGSZWECK")
        Dim DIKA_ISOLAND As GridColumn = View.Columns("DIKA_ISOLAND")
        Dim DIKA_VERRKZ As GridColumn = View.Columns("DIKA_VERRKZ")
        Dim DIKA_BETRAG As GridColumn = View.Columns("DIKA_BETRAG")

        Dim Belegart As String = View.GetRowCellValue(e.RowHandle, colDIKA_BELEGART).ToString
        Dim Kennzahl As String = View.GetRowCellValue(e.RowHandle, colDIKA_KENNZAHL).ToString
        Dim Zahlungszweck As String = View.GetRowCellValue(e.RowHandle, colDIKA_ZAHLUNGSZWECK).ToString
        Dim IsoLand As String = View.GetRowCellValue(e.RowHandle, colDIKA_ISOLAND).ToString
        Dim Verrkz As String = View.GetRowCellValue(e.RowHandle, colDIKA_VERRKZ).ToString
        Dim Betrag As String = View.GetRowCellValue(e.RowHandle, colDIKA_BETRAG).ToString


        If Belegart = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIKA_BELEGART, "Belegart must not be empty")
            e.ErrorText = "Belegart must not be empty"
        End If
        If Kennzahl = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIKA_KENNZAHL, "Kennzahl  must not be empty")
            e.ErrorText = "Kennzahl  must not be empty"
        End If
        If Zahlungszweck = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIKA_ZAHLUNGSZWECK, "Zahlungszweck  must not be empty")
            e.ErrorText = "Zahlungszweck  must not be empty"
        End If
        If IsoLand = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIKA_ISOLAND, "Landkzchn.  must not be empty")
            e.ErrorText = "Landkzchn.  must not be empty"
        End If
        If Verrkz = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIKA_VERRKZ, "Verrechnung Kzchn.  must not be empty")
            e.ErrorText = "Verrechnung Kzchn.  must not be empty"
        End If
        If Betrag = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIKA_BETRAG, "Betrag  must not be empty")
            e.ErrorText = "Betrag must not be empty"
        End If

    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.CellValueChanged
        If AWVz4_TRANSITPOSTEN_BaseView.FocusedColumn.FieldName = "TRANSIT_ISOLAND" Then
            'Get the currently edited value 
            Dim LAND_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(LAND_CODE) = 2 Then
                cmd.CommandText = "SELECT * FROM [COUNTRIES] where [COUNTRY CODE]='" & LAND_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    AWVz4_TRANSITPOSTEN_BaseView.SetRowCellValue(e.RowHandle, "TRANSIT_ISOLAND_NAME", dt.Rows.Item(0).Item("COUNTRY NAME"))
                Else
                    MessageBox.Show("COUNTRY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    AWVz4_TRANSITPOSTEN_BaseView.SetRowCellValue(e.RowHandle, "TRANSIT_ISOLAND_NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim TRANSIT_BELEGART As GridColumn = View.Columns("TRANSIT_BELEGART")
        Dim TRANSIT_KENNZAHL As GridColumn = View.Columns("TRANSIT_KENNZAHL")
        Dim TRANSIT_WARENCODE As GridColumn = View.Columns("TRANSIT_WARENCODE")
        Dim TRANSIT_WARENBEZEICHNUNG As GridColumn = View.Columns("TRANSIT_WARENBEZEICHNUNG")
        Dim TRANSIT_ISOLAND As GridColumn = View.Columns("TRANSIT_ISOLAND")
        Dim TRANSIT_VERRKZ As GridColumn = View.Columns("TRANSIT_VERRKZ")
        Dim TRANSIT_BETRAG As GridColumn = View.Columns("TRANSIT_BETRAG")

        Dim Belegart As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_BELEGART).ToString
        Dim Kennzahl As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_KENNZAHL).ToString
        Dim Warencode As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_WARENCODE).ToString
        Dim Warenbezeichnung As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_WARENBEZEICHNUNG).ToString
        Dim IsoLand As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_ISOLAND).ToString
        Dim Verrkz As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_VERRKZ).ToString
        Dim Betrag As String = View.GetRowCellValue(e.RowHandle, colTRANSIT_BETRAG).ToString


        If Belegart = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_BELEGART, "Belegart must not be empty")
            e.ErrorText = "Belegart must not be empty"
        End If
        If Kennzahl = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_KENNZAHL, "Kennzahl  must not be empty")
            e.ErrorText = "Kennzahl  must not be empty"
        End If
        If Warencode = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_WARENCODE, "Warencode  must not be empty")
            e.ErrorText = "Warencode must not be empty"
        End If
        If Warenbezeichnung = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_WARENBEZEICHNUNG, "Warenbezeichnung  must not be empty")
            e.ErrorText = "Warenbezeichnung  must not be empty"
        End If
        If IsoLand = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_ISOLAND, "Landkennzeichen must not be empty")
            e.ErrorText = "Landkennzeichen  must not be empty"
        End If
        If Verrkz = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_VERRKZ, "Verrechnung Kzchn.  must not be empty")
            e.ErrorText = "Verrechnung Kzchn.  must not be empty"
        End If
        If Betrag = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRANSIT_BETRAG, "Betrag  must not be empty")
            e.ErrorText = "Betrag must not be empty"
        End If
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.CellValueChanged
        If AWVz4_DIRINVPOSTEN_BaseView.FocusedColumn.FieldName = "DIRINV_ISOLAND" Then
            'Get the currently edited value 
            Dim LAND_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(LAND_CODE) = 2 Then
                cmd.CommandText = "SELECT * FROM [COUNTRIES] where [COUNTRY CODE]='" & LAND_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    AWVz4_DIRINVPOSTEN_BaseView.SetRowCellValue(e.RowHandle, "DIRINV_ISOLAND_NAME", dt.Rows.Item(0).Item("COUNTRY NAME"))
                Else
                    MessageBox.Show("COUNTRY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    AWVz4_DIRINVPOSTEN_BaseView.SetRowCellValue(e.RowHandle, "DIRINV_ISOLAND_NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim DIRINV_BELEGART As GridColumn = View.Columns("DIRINV_BELEGART")
        Dim DIRINV_KENNZAHL As GridColumn = View.Columns("DIRINV_KENNZAHL")
        Dim DIRINV_ISIN As GridColumn = View.Columns("DIRINV_ISIN")
        Dim DIRINV_BEZEICHNUNG As GridColumn = View.Columns("DIRINV_BEZEICHNUNG")
        Dim DIRINV_STUECK As GridColumn = View.Columns("DIRINV_STUECK")
        Dim DIRINV_ISOLAND As GridColumn = View.Columns("DIRINV_ISOLAND")
        Dim DIRINV_VERRKZ As GridColumn = View.Columns("DIRINV_VERRKZ")
        Dim DIRINV_BETRAG As GridColumn = View.Columns("DIRINV_BETRAG")

        Dim Belegart As String = View.GetRowCellValue(e.RowHandle, colDIRINV_BELEGART).ToString
        Dim Kennzahl As String = View.GetRowCellValue(e.RowHandle, colDIRINV_KENNZAHL).ToString
        Dim Isin As String = View.GetRowCellValue(e.RowHandle, colDIRINV_ISIN).ToString
        Dim Bezeichnung As String = View.GetRowCellValue(e.RowHandle, colDIRINV_BEZEICHNUNG).ToString
        Dim Stueck As String = View.GetRowCellValue(e.RowHandle, colDIRINV_STUECK).ToString
        Dim IsoLand As String = View.GetRowCellValue(e.RowHandle, colDIRINV_ISOLAND).ToString
        Dim Verrkz As String = View.GetRowCellValue(e.RowHandle, colDIRINV_VERRKZ).ToString
        Dim Betrag As String = View.GetRowCellValue(e.RowHandle, colDIRINV_BETRAG).ToString


        If Belegart = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_BELEGART, "Belegart must not be empty")
            e.ErrorText = "Belegart must not be empty"
        End If
        If Kennzahl = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_KENNZAHL, "Kennzahl  must not be empty")
            e.ErrorText = "Kennzahl  must not be empty"
        End If
        If Isin = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_ISIN, "ISIN  must not be empty")
            e.ErrorText = "ISIN must not be empty"
        End If
        If Bezeichnung = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_BEZEICHNUNG, "Bezeichnung  must not be empty")
            e.ErrorText = "Bezeichnung  must not be empty"
        End If
        If Stueck = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_STUECK, "Stückzahl  must not be empty")
            e.ErrorText = "Stückzahl  must not be empty"
        End If
        If IsoLand = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_ISOLAND, "Landkennzeichen must not be empty")
            e.ErrorText = "Landkennzeichen  must not be empty"
        End If
        If Verrkz = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_VERRKZ, "Verrechnung Kzchn.  must not be empty")
            e.ErrorText = "Verrechnung Kzchn.  must not be empty"
        End If
        If Betrag = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DIRINV_BETRAG, "Betrag  must not be empty")
            e.ErrorText = "Betrag must not be empty"
        End If
    End Sub

    Private Sub AWVz14_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz14_Print_Export_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
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
        Dim reportfooter As String = "AWV Z14 Report " & "   " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub AWVz15_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz15_Print_Export_btn.Click
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
        Dim reportfooter As String = "AWV Z15 Report " & "  " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub AWVz14z15Details_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz14z15Details_Print_Export_btn.Click
        If Not GridControl5.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "AWV Z14-Z15 Details Report " & "  " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub AWVz10_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz10_Print_Export_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink4.CreateDocument()
        PrintableComponentLink4.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "AWV Z10 Report " & "   " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub AWVz4_DIKA_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz4_DIKA_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink5.CreateDocument()
        PrintableComponentLink5.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalHeaderArea
        Dim reportfooter As String = "AWV Z4-DIKAPOSTEN Report " & "  " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub AWVz4_TRANSIT_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz4_TRANSIT_Print_Export_btn.Click
        If Not GridControl6.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink6.CreateDocument()
        PrintableComponentLink6.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalHeaderArea
        Dim reportfooter As String = "AWV Z4-TRANSITPOSTEN Report " & "   " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub AWVz4_DIRINV_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles AWVz4_DIRINV_Print_Export_btn.Click
        If Not GridControl7.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink7.CreateDocument()
        PrintableComponentLink7.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink7_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink7.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink7_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink7.CreateMarginalHeaderArea
        Dim reportfooter As String = "AWV Z4-DIRINVPOSTEN Report " & "   " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Z14Z15_Report_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Z14Z15_Report_BarButtonItem.ItemClick
        Dim RM As String = Me.AWV_ReportDate_ComboBoxEdit.Text
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z14-Z15 Report for " & RM)

        rdsql = RepDate.ToString("yyyyMMdd")
        Dim AWVz1415RelevantData_Da As New SqlDataAdapter("Select * from [AWVz1415RelevantData] where [IdZ14Z15Meldemonat]='" & rdsql & "' ", conn)
        Dim AWVz14z15_Da As New SqlDataAdapter("Select * from [AWVz14z15] where [Z14Z15MeldeMonat]='" & rdsql & "' ", conn)
        Dim AWVz14_Da As New SqlDataAdapter("Select * from [AWVz14] where [IdZ14Z15Meldemonat]='" & rdsql & "' ", conn)
        Dim AWVz15_Da As New SqlDataAdapter("Select * from [AWVz15] where [IdZ14Z15Meldemonat]='" & rdsql & "' ", conn)
        Dim Bank_Da As New SqlDataAdapter("Select * from [BANK]", conn)
        Dim AWV_Dataset As New DataSet("AWV")
        AWVz1415RelevantData_Da.Fill(AWV_Dataset, "AWVz1415RelevantData")
        AWVz14z15_Da.Fill(AWV_Dataset, "AWVz14z15")
        AWVz14_Da.Fill(AWV_Dataset, "AWVz14")
        AWVz15_Da.Fill(AWV_Dataset, "AWVz15")
        Bank_Da.Fill(AWV_Dataset, "BANK")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_z14_z15.rpt")
        'CrRep.SetDataSource(MeldewesenDataSet)
        CrRep.SetDataSource(AWV_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = RM
        myParams.ParameterFieldName = "RepMonth"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z14-Z15 on " & RM
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Z10_REPORT_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Z10_REPORT_BarButtonItem.ItemClick
        Try
            Me.Validate()
            Me.AWVz10POSTENBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim RM As String = Me.AWV_ReportDate_ComboBoxEdit.Text
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z10 Report for " & RM)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_Z10.rpt")
        CrRep.SetDataSource(MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = RM
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z10 on " & RM
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Z4_REPORT_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Z4_REPORT_BarButtonItem.ItemClick
        Try
            Me.Validate()
            Me.AWVz4DIKAPPOSTENBindingSource.EndEdit()
            Me.AWVz4TRANSITPOSTENBindingSource.EndEdit()
            Me.AWVz4DIRINVPOSTENBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim RM As String = Me.AWV_ReportDate_ComboBoxEdit.Text
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z4 Report for " & RM)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_Z4.rpt")
        CrRep.SetDataSource(MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = RM
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z4 on " & RM
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub LoadCreditRiskMak_btn_Click(sender As Object, e As EventArgs) Handles LoadCreditRiskMak_btn.Click
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            If XML_CREATE = "N" AndAlso SUPER_USER = "N" Then
                MessageBox.Show("You are not enabled to create the XML File for the AWV Report to Deutsche Bundesbank", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Dim RM As String = Me.AWV_ReportDate_ComboBoxEdit.Text
                cmd.CommandText = "SELECT [Z14Z15MeldeMonat] FROM [AWVz14z15] where [Z14Z15MeldeMonatName]='" & RM & "' "
                cmd.Connection.Open()
                Dim RD As Date = cmd.ExecuteScalar
                Dim SqlRD As String = RD.ToString("yyyy-MM-dd")
                cmd.Connection.Close()

                If MessageBox.Show("Should the XML File for the AWV Report " & RM & " be created?", "XML AVW FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        'BANK DATEN empfangen
                        Dim FIRMENNUMMER As String = ""
                        Dim BANKNAME As String = ""
                        Dim BANKSTRASSE As String = ""
                        Dim BANKPLZ As String = ""
                        Dim BANKORT As String = ""

                        Me.QueryText = "select * from [BANK]"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        FIRMENNUMMER = dt.Rows.Item(0).Item("BLZ Bank")
                        BANKNAME = dt.Rows.Item(0).Item("Name Bank") & "," & dt.Rows.Item(0).Item("Branch Bank")
                        BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
                        BANKPLZ = dt.Rows.Item(0).Item("PLZ Bank")
                        BANKORT = dt.Rows.Item(0).Item("Ort Bank")

                        'XML PARAMETER empfangen
                        Dim XMLSAVEFILE As String = ""
                        Dim ABSENDERANREDE As String = ""
                        Dim ABSENDERVORNAME As String = ""
                        Dim ABSENDERZUNAME As String = ""
                        Dim ABSENDERABTEILUNG As String = ""
                        Dim ABSENDERTELEFON As String = ""
                        Dim ABSENDERFAX As String = ""
                        Dim ABSENDEREMAIL As String = ""
                        Dim ABSENDEREXTRANETID As String = ""
                        Dim ERSTELLERZUNAME As String = ""
                        Dim ERSTELLERTELEFON As String = ""
                        Dim ERSTELLEREMAIL As String = ""
                        Dim MELDEPFLICHTIGERZUNAME As String = ""
                        Dim MELDEPFLICHTIGERTELEFON As String = ""
                        Dim MELDEPFLICHTIGEREMAIL As String = ""
                        Dim XMLSTUFE As String = ""
                        Dim XMLKOMMENTAR As String = ""


                        Me.QueryText = "SELECT * FROM [PARAMETER] where  [IdABTEILUNGSPARAMETER]='AWV' and [PARAMETER STATUS]='Y' "
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            Dim CheckParameter As String = dt.Rows.Item(i).Item("PARAMETER1")
                            Dim RelevantParameter As String = dt.Rows.Item(i).Item("PARAMETER2")
                            Select Case CheckParameter
                                Case Is = "AWVXML_SAVE_DIR"
                                    XMLSAVEFILE = RelevantParameter
                                Case Is = "ABSENDERANREDE"
                                    ABSENDERANREDE = RelevantParameter
                                Case Is = "ABSENDERVORNAME"
                                    ABSENDERVORNAME = RelevantParameter
                                Case Is = "ABSENDERZUNAME"
                                    ABSENDERZUNAME = RelevantParameter
                                Case Is = "ABSENDERABTEILUNG"
                                    ABSENDERABTEILUNG = RelevantParameter
                                Case Is = "ABSENDERTELEFON"
                                    ABSENDERTELEFON = RelevantParameter
                                Case Is = "ABSENDERFAX"
                                    ABSENDERFAX = RelevantParameter
                                Case Is = "ABSENDEREMAIL"
                                    ABSENDEREMAIL = RelevantParameter
                                Case Is = "ABSENDEREXTRANETID"
                                    ABSENDEREXTRANETID = RelevantParameter
                                Case Is = "ERSTELLERZUNAME"
                                    ERSTELLERZUNAME = RelevantParameter
                                Case Is = "ERSTELLERTELEFON"
                                    ERSTELLERTELEFON = RelevantParameter
                                Case Is = "ERSTELLEREMAIL"
                                    ERSTELLEREMAIL = RelevantParameter
                                Case Is = "MELDEPFLICHTIGERZUNAME"
                                    MELDEPFLICHTIGERZUNAME = RelevantParameter
                                Case Is = "MELDEPFLICHTIGERTELEFON"
                                    MELDEPFLICHTIGERTELEFON = RelevantParameter
                                Case Is = "MELDEPFLICHTIGEREMAIL"
                                    MELDEPFLICHTIGEREMAIL = RelevantParameter
                                Case Is = "XMLSTUFE"
                                    XMLSTUFE = RelevantParameter
                                Case Is = "XMLKOMMENTAR"
                                    XMLKOMMENTAR = RelevantParameter
                            End Select
                        Next


                        'XML DATEI erstellungsdatum un Zeitdefinieren
                        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
                        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")

                        'MELDETERMIN
                        Dim MeldeIddatm As Date = RD
                        Dim MELDETERMIN As String = MeldeIddatm.ToString("yyyy-MM")
                        Dim XMLDATEIMELDEMONAT As String = MeldeIddatm.ToString("yyyyMM")



                        Dim MyWriter As System.Xml.XmlWriter
                        Dim MySettings As New System.Xml.XmlWriterSettings
                        MySettings.Indent = True
                        MySettings.ConformanceLevel = ConformanceLevel.Auto
                        MySettings.IndentChars = "    "

                        MySettings.NewLineOnAttributes = False
                        MySettings.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1")


                        'MyWriter = System.Xml.XmlWriter.Create(Application.StartupPath & IO.Path.DirectorySeparatorChar & "Z14Z15tested.xml", MySettings)
                        MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & "\avzel_" & XMLDATEIMELDEMONAT & "_" & FIRMENNUMMER & ".xml", MySettings)

                        With MyWriter
                            .WriteStartDocument()
                            .WriteStartElement("LIEFERUNG-AWZEL", "http://www.bundesbank.de/xmw/2003-01-01")
                            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                            .WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.bundesbank.de/xmw/2003-01-01 BbkXmwAwzel.xsd")
                            .WriteAttributeString("version", "1.0")
                            .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT)
                            .WriteAttributeString("stufe", XMLSTUFE)
                            .WriteAttributeString("bereich", "Statistik")

                            'ELEMENT-ABSENDER
                            .WriteStartElement("ABSENDER")
                            .WriteElementString("FIRMENNR", FIRMENNUMMER)
                            .WriteElementString("NAME", BANKNAME)
                            .WriteElementString("STRASSE", BANKSTRASSE)
                            .WriteElementString("PLZ", BANKPLZ)
                            .WriteElementString("ORT", BANKORT)
                            .WriteElementString("LAND", "DE")
                            '##############################
                            'UNTERELEMENT-KONTAKT
                            .WriteStartElement("KONTAKT")
                            .WriteElementString("ANREDE", ABSENDERANREDE)
                            .WriteElementString("VORNAME", ABSENDERVORNAME)
                            .WriteElementString("ZUNAME", ABSENDERZUNAME)
                            .WriteElementString("ABTEILUNG", ABSENDERABTEILUNG)
                            .WriteElementString("TELEFON", ABSENDERTELEFON)
                            .WriteElementString("FAX", ABSENDERFAX)
                            .WriteElementString("EMAIL", ABSENDEREMAIL)
                            .WriteElementString("EXTRANET-ID", ABSENDEREXTRANETID)
                            .WriteEndElement() 'KONTAKT
                            .WriteEndElement() 'ABSENDER
                            'ELEMENT-ERSTELLER
                            .WriteStartElement("ERSTELLER")
                            .WriteElementString("FIRMENNR", FIRMENNUMMER)
                            .WriteElementString("NAME", BANKNAME)
                            'UNTERELEMENT-KONTAKT
                            .WriteStartElement("KONTAKT")
                            .WriteElementString("ZUNAME", ERSTELLERZUNAME)
                            .WriteElementString("TELEFON", ERSTELLERTELEFON)
                            .WriteElementString("EMAIL", ERSTELLEREMAIL)
                            .WriteEndElement() 'KONTAKT
                            .WriteEndElement() 'ERSTELLER
                            'KOMMENTAR
                            .WriteElementString("KOMMENTAR", XMLKOMMENTAR)
                            'MELDUNG ERSTELLZEIT
                            .WriteStartElement("MELDUNG")
                            .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT)
                            'MELDEPFLICHTIGER
                            .WriteStartElement("MELDEPFLICHTIGER")
                            .WriteElementString("FIRMENNR", FIRMENNUMMER)
                            .WriteElementString("NAME", BANKNAME)
                            .WriteElementString("STRASSE", BANKSTRASSE)
                            .WriteElementString("PLZ", BANKPLZ)
                            .WriteElementString("ORT", BANKORT)
                            'UNTERELEMENT-KONTAKT
                            .WriteStartElement("KONTAKT")
                            .WriteElementString("ZUNAME", MELDEPFLICHTIGERZUNAME)
                            .WriteElementString("TELEFON", MELDEPFLICHTIGERTELEFON)
                            .WriteElementString("EMAIL", MELDEPFLICHTIGEREMAIL)
                            .WriteEndElement() 'KONTAKT
                            .WriteEndElement() 'MELDEPFLICHTIGER
                            'MELDETERMIN
                            .WriteElementString("MELDETERMIN", MELDETERMIN)
                            'MELDEREFERENZ
                            .WriteElementString("MELDUNGSREF", "meldung vom " & RM)


                            'MELDUNG Z4+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Prüfen ob daten vorhanden sind
                            cmd.CommandText = "SELECT distinct [DIKA_MeldeMonat] FROM [AWVz4DIKAPPOSTEN] Where [DIKA_MeldeMonat]='" & SqlRD & "'"
                            cmd.Connection.Open()
                            Dim zdika As String = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT distinct [TRANSIT_MeldeMonat] FROM [AWVz4TRANSITPOSTEN] Where [TRANSIT_MeldeMonat]='" & SqlRD & "'"
                            Dim ztransit As String = cmd.ExecuteScalar
                            cmd.CommandText = "SELECT distinct [DIRINV_MeldeMonat] FROM [AWVz4DIRINVPOSTEN] Where [DIRINV_MeldeMonat]='" & SqlRD & "'"
                            Dim zdirinv As String = cmd.ExecuteScalar
                            cmd.Connection.Close()


                            If IsNothing(zdika) = False Or IsNothing(ztransit) = False Or IsNothing(zdirinv) = False Then
                                .WriteStartElement("VDR_04")
                                'Dikaposten
                                If IsNothing(zdika) = False Then
                                    Me.QueryText = "SELECT * FROM [AWVz4DIKAPPOSTEN] Where [DIKA_MeldeMonat]='" & SqlRD & "' and [DIKA_BETRAG]>=1000"
                                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                    dt = New DataTable()
                                    da.Fill(dt)
                                    For i = 0 To dt.Rows.Count - 1
                                        .WriteStartElement("DIKAPPOSTEN")
                                        .WriteAttributeString("belegart", dt.Rows.Item(i).Item("DIKA_BELEGART"))
                                        .WriteAttributeString("kennzahl", dt.Rows.Item(i).Item("DIKA_KENNZAHL"))
                                        .WriteAttributeString("zahlungszweck", dt.Rows.Item(i).Item("DIKA_ZAHLUNGSZWECK"))
                                        .WriteStartElement("BETRAG")
                                        .WriteAttributeString("land", dt.Rows.Item(i).Item("DIKA_ISOLAND"))
                                        .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("DIKA_ISOLAND_NAME"), 16))
                                        If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                            If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                                .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                            End If
                                        End If
                                        .WriteValue(Math.Round(dt.Rows.Item(i).Item("DIKA_BETRAG") / 1000, 0))
                                        .WriteEndElement()
                                        .WriteEndElement()
                                    Next
                                End If
                                'Transitposten
                                If IsNothing(ztransit) = False Then
                                    Me.QueryText = "SELECT * FROM [AWVz4TRANSITPOSTEN] Where [TRANSIT_MeldeMonat]='" & SqlRD & "' and [TRANSIT_BETRAG]>=1000"
                                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                    dt = New DataTable()
                                    da.Fill(dt)
                                    For i = 0 To dt.Rows.Count - 1
                                        .WriteStartElement("TRANSITPOSTEN")
                                        .WriteAttributeString("belegart", dt.Rows.Item(i).Item("TRANSIT_BELEGART"))
                                        .WriteAttributeString("kennzahl", dt.Rows.Item(i).Item("TRANSIT_KENNZAHL"))
                                        .WriteStartElement("TRANSIT")
                                        .WriteAttributeString("warencode", dt.Rows.Item(i).Item("TRANSIT_WARENCODE"))
                                        .WriteAttributeString("warenbez", dt.Rows.Item(i).Item("TRANSIT_WARENBEZEICHNUNG"))
                                        .WriteStartElement("BETRAG")
                                        .WriteAttributeString("land", dt.Rows.Item(i).Item("TRANSIT_ISOLAND"))
                                        .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("TRANSIT_ISOLAND_NAME"), 16))
                                        If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                            If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                                .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                            End If
                                        End If
                                        .WriteValue(Math.Round(dt.Rows.Item(i).Item("TRANSIT_BETRAG") / 1000, 0))
                                        .WriteEndElement()
                                        .WriteEndElement()
                                        .WriteEndElement()
                                    Next
                                    'Dirinvposten
                                    If IsNothing(zdirinv) = False Then
                                        Me.QueryText = "SELECT * FROM [AWVz4DIRINVPOSTEN] Where [DIRINV_MeldeMonat]='" & SqlRD & "' and [DIRINV_BETRAG]>=1000"
                                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                        dt = New DataTable()
                                        da.Fill(dt)
                                        For i = 0 To dt.Rows.Count - 1
                                            .WriteStartElement("DIRINVPOSTEN")
                                            .WriteAttributeString("belegart", dt.Rows.Item(i).Item("DIRINV_BELEGART"))
                                            .WriteAttributeString("kennzahl", dt.Rows.Item(i).Item("DIRINV_KENNZAHL"))
                                            .WriteStartElement("WERTPAPIER")
                                            .WriteAttributeString("isin", dt.Rows.Item(i).Item("DIRINV_ISIN"))
                                            .WriteAttributeString("bezeichnung", dt.Rows.Item(i).Item("DIRINV_BEZEICHNUNG"))
                                            .WriteStartElement("STUECK")
                                            .WriteValue(dt.Rows.Item(i).Item("DIRINV_STUECK"))
                                            .WriteEndElement()
                                            .WriteStartElement("BETRAG")
                                            .WriteAttributeString("land", dt.Rows.Item(i).Item("DIRINV_ISOLAND"))
                                            .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("DIRINV_ISOLAND_NAME"), 16))
                                            If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                                If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                                    .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                                End If
                                            End If
                                            .WriteValue(Math.Round(dt.Rows.Item(i).Item("DIRINV_BETRAG") / 1000, 0))
                                            .WriteEndElement()
                                            .WriteEndElement()
                                            .WriteEndElement()
                                        Next
                                    End If
                                End If
                                .WriteEndElement()
                            End If

                            'MELDUNG Z10+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Prüfen ob daten vorhanden sind
                            cmd.CommandText = "SELECT distinct [IdAWVz14z15] FROM [AWVz10POSTEN] Where [IdAWVz14z15]='" & SqlRD & "' and [WERTPAPIER_BETRAG]>=1000"
                            cmd.Connection.Open()
                            Dim t As String = cmd.ExecuteScalar()

                            If IsNothing(t) = False Then
                                .WriteStartElement("VDR_10")
                                Me.QueryText = "SELECT * FROM [AWVz10POSTEN] Where [IdAWVz14z15]='" & SqlRD & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("POSTEN")
                                    .WriteAttributeString("belegart", dt.Rows.Item(i).Item("BELEGART"))
                                    .WriteAttributeString("kennzahl", dt.Rows.Item(i).Item("KENNZAHL"))
                                    .WriteStartElement("WERTPAPIER")
                                    .WriteAttributeString("isin", dt.Rows.Item(i).Item("WERTPAPIER_ISIN"))
                                    .WriteAttributeString("bezeichnung", dt.Rows.Item(i).Item("WERTAPPIER_BEZEICHNUNG"))
                                    If IsDBNull(dt.Rows.Item(i).Item("WERTPAPIER_SoN")) = False Then
                                        .WriteStartElement("NOMINAL_STUECK")
                                        If dt.Rows.Item(i).Item("NOMINAL_STUECK") = "N" Then
                                            .WriteAttributeString("s-oder-n", dt.Rows.Item(i).Item("NOMINAL_STUECK"))
                                            .WriteValue(Math.Round(dt.Rows.Item(i).Item("WERTPAPIER_SoN") / 1000, 0))
                                            .WriteEndElement()
                                        ElseIf dt.Rows.Item(i).Item("NOMINAL_STUECK") = "S" Then
                                            .WriteAttributeString("s-oder-n", dt.Rows.Item(i).Item("NOMINAL_STUECK"))
                                            .WriteValue(dt.Rows.Item(i).Item("WERTPAPIER_SoN"))
                                            .WriteEndElement()
                                        End If
                                    End If
                                    .WriteStartElement("BETRAG")
                                    .WriteAttributeString("land", dt.Rows.Item(i).Item("WERTPAPIER_LAND_ISOCODE"))
                                    .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("WERTPAPIER_LAND_NAME"), 16))
                                    .WriteAttributeString("wrg", dt.Rows.Item(i).Item("WERTPAPIER_WHG"))
                                    If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                        If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                            .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                        End If
                                    End If
                                    .WriteValue(Math.Round(dt.Rows.Item(i).Item("WERTPAPIER_BETRAG") / 1000, 0))
                                    .WriteEndElement()
                                    .WriteEndElement()
                                    .WriteEndElement()
                                Next

                                .WriteEndElement()

                            End If
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                            'MELDUNG Z11+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Prüfen ob daten vorhanden sind
                            cmd.CommandText = "SELECT distinct [IdAWVz14z15] FROM [AWVz11POSTEN]  Where [IdAWVz14z15]='" & SqlRD & "' and [BETRAG]>=1000"
                            Dim AWV_Z11_Data As String = cmd.ExecuteScalar()

                            If IsNothing(AWV_Z11_Data) = False Then
                                .WriteStartElement("VDR_11")
                                Me.QueryText = "SELECT * FROM [AWVz11POSTEN] Where [IdAWVz14z15]='" & SqlRD & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("POSTEN")
                                    .WriteAttributeString("belegart", dt.Rows.Item(i).Item("BELEGART"))
                                    .WriteAttributeString("kennzahl", dt.Rows.Item(i).Item("KENNZAHL"))
                                    .WriteStartElement("BETRAG")
                                    .WriteAttributeString("land", dt.Rows.Item(i).Item("LAND_ISOCODE"))
                                    .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("LAND_NAME"), 16))
                                    If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                        If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                            .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                        End If
                                    End If
                                    .WriteValue(Math.Round(dt.Rows.Item(i).Item("BETRAG") / 1000, 0))
                                    .WriteEndElement()
                                    .WriteEndElement()
                                Next

                                .WriteEndElement()

                            End If
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



                            'MELDUNG-Z14++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Prüfen ob daten vorhanden sind
                            cmd.CommandText = "SELECT distinct [IdZ14Z15Meldemonat] FROM [AWVz14] Where [IdZ14Z15Meldemonat]='" & SqlRD & "'"

                            Dim t1 As String = cmd.ExecuteScalar()
                            If IsNothing(t1) = False Then

                                .WriteStartElement("VDR_14")

                                Me.QueryText = "SELECT * FROM [AWVz14] Where [IdZ14Z15Meldemonat]='" & SqlRD & "' and [CountrySumAmount]>=1000 and [COUNTRY CODE] not in ('DE')"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("BETRAG")
                                    .WriteAttributeString("land", dt.Rows.Item(i).Item("COUNTRY CODE"))
                                    .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("COUNTRY NAME"), 16))
                                    If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                        If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                            .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                        End If
                                    End If
                                    .WriteValue(Math.Round(dt.Rows.Item(i).Item("CountrySumAmount") / 1000, 0))
                                    .WriteEndElement()
                                Next
                                .WriteEndElement()

                            End If
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



                            'MELDUNG-Z15+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            cmd.CommandText = "SELECT distinct [IdZ14Z15Meldemonat] FROM [AWVz15] Where [IdZ14Z15Meldemonat]='" & SqlRD & "'"

                            Dim t2 As String = cmd.ExecuteScalar()

                            If IsNothing(t2) = False Then

                                .WriteStartElement("VDR_15")
                                Me.QueryText = "SELECT * FROM [AWVz15] Where [IdZ14Z15Meldemonat]='" & SqlRD & "' and [CountrySumAmount]>=1000 and [COUNTRY CODE] not in ('DE')"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    .WriteStartElement("BETRAG")
                                    .WriteAttributeString("land", dt.Rows.Item(i).Item("COUNTRY CODE"))
                                    .WriteAttributeString("landname", Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("COUNTRY NAME"), 16))
                                    If IsDBNull(dt.Rows.Item(i).Item("BETRAG_REF")) = False Then
                                        If dt.Rows.Item(i).Item("BETRAG_REF").ToString <> "" Then
                                            .WriteAttributeString("betragsref", dt.Rows.Item(i).Item("BETRAG_REF"))
                                        End If
                                    End If
                                    .WriteValue(Math.Round(dt.Rows.Item(i).Item("CountrySumAmount") / 1000, 0))
                                    .WriteEndElement()
                                Next
                                .WriteEndElement()

                            End If
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                            cmd.Connection.Close()
                            'Schliessen des XML dokumentes
                            .WriteEndDocument()
                            .Close()
                        End With



                        If MessageBox.Show("Folgende XML Datei wurde generiert: " & "avzel_" & XMLDATEIMELDEMONAT & "_" & FIRMENNUMMER & ".xml" & vbNewLine _
                               & "Die Datei wurde im folgenden Verzeichnis abgelegt:" & vbNewLine _
                        & XMLSAVEFILE & vbNewLine & vbNewLine & "Soll das Verzeichnis geöfnet werden?", "AWV XML Datei erfolgreich generiert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(XMLSAVEFILE)
                        End If

                        'VALIDIERUNG DER XML DATEI
                        Dim myDocument As New XmlDocument
                        myDocument.Load(XMLSAVEFILE & "\avzel_" & XMLDATEIMELDEMONAT & "_" & FIRMENNUMMER & ".xml")
                        myDocument.Schemas.Add(Nothing, XMLSAVEFILE & "\BbkXmwAWZEL.xsd")
                        Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
                        myDocument.Validate(eventHandler)

                        Exit Sub

                    Catch ex As System.Exception
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MsgBox(ex.Message)
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
                MsgBox("Error: {0}", e.Message, "AWV XML ERROR")
                'Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                'Debug.WriteLine("Warning {0}", e.Message)
                MsgBox("Warning {0}", e.Message, "AWV XML WARNING")

        End Select
    End Sub

    Private Sub AWVz14_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz14_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz14_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz14_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz15_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz15_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz15_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz15_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz14z15_Details_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz14z15_Details_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz14z15_Details_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz14z15_Details_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz11_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles AWVz11_GridView.CellValueChanged
        If AWVz11_GridView.FocusedColumn.FieldName = "LAND_ISOCODE" Then
            'Get the currently edited value 
            Dim LAND_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(LAND_CODE) = 2 Then
                cmd.CommandText = "SELECT * FROM [COUNTRIES] where [COUNTRY CODE]='" & LAND_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    AWVz11_GridView.SetRowCellValue(e.RowHandle, "LAND_NAME", dt.Rows.Item(0).Item("COUNTRY NAME"))
                Else
                    MessageBox.Show("COUNTRY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    AWVz11_GridView.SetRowCellValue(e.RowHandle, "LAND_NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub AWVz11_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles AWVz11_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz11_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles AWVz11_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AWVz11_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AWVz11_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz11_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AWVz11_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AWVz11_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AWVz11_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim BELEG_ART As GridColumn = View.Columns("BELEGART")
        Dim KENNZAHL_AWV11 As GridColumn = View.Columns("KENNZAHL")
        Dim LAND_AWV11 As GridColumn = View.Columns("LAND_ISOCODE")
        Dim BETRAG_AWV11 As GridColumn = View.Columns("BETRAG")

        Dim Belegart As String = View.GetRowCellValue(e.RowHandle, colBELEGART2).ToString
        Dim KennzahlAWV11 As String = View.GetRowCellValue(e.RowHandle, colKENNZAHL2).ToString
        Dim LandAWV11 As String = View.GetRowCellValue(e.RowHandle, colLAND_ISOCODE1).ToString
        Dim BetragAWV11 As String = View.GetRowCellValue(e.RowHandle, colBETRAG1).ToString

        If Belegart = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BELEG_ART, "Belegart must not be empty")
            e.ErrorText = "Belegart must not be empty"
        End If
        If KennzahlAWV11 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(KENNZAHL_AWV11, "Kennzahl  must not be empty")
            e.ErrorText = "Kennzahl  must not be empty"
        End If
        If LandAWV11 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(LAND_AWV11, "Landkennzeichen  must not be empty")
            e.ErrorText = "Landkennzeichen must not be empty"
        End If
        If BetragAWV11 = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BETRAG_AWV11, "Betrag  must not be empty")
            e.ErrorText = "Währung  must not be empty"
        End If
        
    End Sub

    Private Sub Z11_REPORT_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Z11_REPORT_BarButtonItem.ItemClick
        Try
            Me.Validate()
            Me.AWVz11POSTENBindingSource1.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Dim RM As String = Me.AWV_ReportDate_ComboBoxEdit.Text
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z11 Report for " & RM)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_Z11.rpt")
        CrRep.SetDataSource(MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = RM
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z11 on " & RM
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Print_Export_AWVz11_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_AWVz11_GridView_btn.Click
        If Not GridControl8.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink8.CreateDocument()
        PrintableComponentLink8.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink8_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink8.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink8_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink8.CreateMarginalHeaderArea
        Dim reportfooter As String = "AWV Z11-Zahlungen für Wertpapier-Erträge Report " & "   " & "on: " & Me.AWV_ReportDate_ComboBoxEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub RepositoryItemTextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit2.EditValueChanged
        Try
            AWVz14_BaseView.PostEditor()
            Me.AWVz14BindingSource.EndEdit()
            Me.AWVz14TableAdapter.Update(Me.MeldewesenDataSet.AWVz14)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

    Private Sub RepositoryItemTextEdit6_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit6.EditValueChanged
        Try
            AWVz15_BaseView.PostEditor()
            Me.AWVz15BindingSource.EndEdit()
            Me.AWVz15TableAdapter.Update(Me.MeldewesenDataSet.AWVz15)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

    Private Sub ReportLocked_CheckEdit_CheckStateChanged(sender As Object, e As EventArgs) Handles ReportLocked_CheckEdit.CheckStateChanged

        Try
            REPORT_LOCK_UNLOCK()
            Me.Validate()
            Me.AWVz14z15BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
            '***********************************************************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

    Private Sub AWVz4_DIKAPOSTEN_BaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AWVz4_DIKAPOSTEN_BaseView.RowUpdated
        Try

            Me.Validate()
            Me.AWVz4DIKAPPOSTENBindingSource.EndEdit()
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, RepDate)
            Else
                Me.AWVz4DIKAPPOSTENBindingSource.CancelEdit()
                Me.MeldewesenDataSet.RejectChanges()
                Me.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIKAPPOSTEN, RepDate)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub AWVz4_TRANSITPOSTEN_BaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AWVz4_TRANSITPOSTEN_BaseView.RowUpdated
        Try
            Me.Validate()
            Me.AWVz4TRANSITPOSTENBindingSource.EndEdit()
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, RepDate)
            Else
                Me.AWVz4TRANSITPOSTENBindingSource.CancelEdit()
                Me.MeldewesenDataSet.RejectChanges()
                Me.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4TRANSITPOSTEN, RepDate)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub AWVz4_DIRINVPOSTEN_BaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AWVz4_DIRINVPOSTEN_BaseView.RowUpdated
        Try
            Me.Validate()
            Me.AWVz4DIRINVPOSTENBindingSource.EndEdit()
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, RepDate)
            Else
                Me.AWVz4DIRINVPOSTENBindingSource.CancelEdit()
                Me.MeldewesenDataSet.RejectChanges()
                Me.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz4DIRINVPOSTEN, RepDate)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub AWVz10_BandedGridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AWVz10_BandedGridView.RowUpdated
        Try
            Me.Validate()
            Me.AWVz10POSTENBindingSource.EndEdit()
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, RepDate)
            Else
                Me.AWVz10POSTENBindingSource.CancelEdit()
                Me.MeldewesenDataSet.RejectChanges()
                Me.AWVz10POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz10POSTEN, RepDate)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub AWVz11_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AWVz11_GridView.RowUpdated
        Try
            Me.Validate()
            Me.AWVz11POSTENBindingSource1.EndEdit()
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.MeldewesenDataSet)
                Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, RepDate)
            Else
                Me.AWVz11POSTENBindingSource1.CancelEdit()
                Me.MeldewesenDataSet.RejectChanges()
                Me.AWVz11POSTENTableAdapter.FillByReportMonth(Me.MeldewesenDataSet.AWVz11POSTEN, RepDate)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub AWVz14z15_Details_BaseView_DoubleClick(sender As Object, e As EventArgs) Handles AWVz14z15_Details_BaseView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "Counterparty No" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Counterparty No").ToString
                If IsNothing(ClientNr) = False Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr
                        Me.CustomersVerticalGrid.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
            If view.FocusedColumn.FieldName = "Contract" Then
                Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract").ToString
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Counterparty No").ToString
                If IsNothing(ContractNr) = False And IsNumeric(ContractNr) = True Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Contract Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        GLOBAL_CONTRACT_NR = ContractNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomerContractVG.Text = "Details for Contract Nr. " & ContractNr
                        Me.CustomerContractVG.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub LANDKZ_DIKA_RepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LANDKZ_DIKA_RepositoryItemLookUpEdit1.EditValueChanged

        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        AWVz4_DIKAPOSTEN_BaseView.SetRowCellValue(AWVz4_DIKAPOSTEN_BaseView.FocusedRowHandle, "DIKA_ISOLAND_NAME", EditRow("COUNTRY NAME").ToString)

    End Sub

    Private Sub LANDKZ_DIRINV_RepositoryItemLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LANDKZ_DIRINV_RepositoryItemLookUpEdit.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        AWVz4_DIRINVPOSTEN_BaseView.SetRowCellValue(AWVz4_DIRINVPOSTEN_BaseView.FocusedRowHandle, "DIRINV_ISOLAND_NAME", EditRow("COUNTRY NAME").ToString)
    End Sub

    Private Sub LANDKZ_TRANSIT_RepositoryItemLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LANDKZ_TRANSIT_RepositoryItemLookUpEdit.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        AWVz4_TRANSITPOSTEN_BaseView.SetRowCellValue(AWVz4_TRANSITPOSTEN_BaseView.FocusedRowHandle, "TRANSIT_ISOLAND_NAME", EditRow("COUNTRY NAME").ToString)
    End Sub

    Private Sub COUNTRIESRepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles COUNTRIESRepositoryItemLookUpEdit1.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        AWVz10_BandedGridView.SetRowCellValue(AWVz10_BandedGridView.FocusedRowHandle, "WERTPAPIER_LAND_NAME", EditRow("COUNTRY NAME").ToString)
    End Sub

    Private Sub RepositoryItemLookUpEdit_Countries_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit_Countries.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        AWVz11_GridView.SetRowCellValue(AWVz11_GridView.FocusedRowHandle, "LAND_NAME", EditRow("COUNTRY NAME").ToString)
    End Sub
End Class