Imports System
Imports System.IO
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
Imports DevExpress.XtraLayout.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls

Public Class Bank_Data

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

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

    Private Sub Bank_Data_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Validate()
            Me.BANKBindingSource.EndEdit()
            If Me.PSTOOLDataset.HasChanges = True Then
                If MessageBox.Show("Should the changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "UPDATE A SET A.NUTS_3_Code=B.NUTS_3_CODE from BANK A INNER JOIN NUTS_3 B on LTRIM(RTRIM(dbo.RemoveAllSpaces(A.[PLZ Bank])))=LTRIM(RTRIM(dbo.RemoveAllSpaces(B.CODE))) where  B.COUNTRY_CODE in ('DE')"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
            Me.BANKTableAdapter.Fill(Me.PSTOOLDataset.BANK)
        End Try
    End Sub
    Private Sub Bank_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.BANKTableAdapter.Fill(Me.PSTOOLDataset.BANK)
        If SUPER_USER = "N" Then
            Me.LayoutView1.OptionsBehavior.Editable = False

        End If
    End Sub

    Private Sub LayoutView1_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles LayoutView1.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Private Sub LayoutView1_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles LayoutView1.ValidatingEditor
        'Set Validation to Columnseditors
        If Me.LayoutView1.FocusedColumn.FieldName = "Name Bank" Or Me.LayoutView1.FocusedColumn.FieldName = "Branch Bank" _
            Or Me.LayoutView1.FocusedColumn.FieldName = "Strasse Bank" Or Me.LayoutView1.FocusedColumn.FieldName = "Ort Bank" _
            Or Me.LayoutView1.FocusedColumn.FieldName = "PLZ Bank" Or Me.LayoutView1.FocusedColumn.FieldName = "Land Bank" _
            Or Me.LayoutView1.FocusedColumn.FieldName = "BIC Bank" Then
            If e.Value = "" Then
                e.Valid = False
                e.ErrorText = "Field: " & Me.LayoutView1.FocusedColumn.Caption.ToString & " is Mandatory!" & vbNewLine & "Please input Value!"
            End If
        End If
    End Sub

    Private Sub Printbtn_Click(sender As Object, e As EventArgs) Handles Printbtn.Click
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = False
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = False
        Me.LayoutView1.OptionsPrint.PrintSelectedCardsOnly = True
        Me.LayoutView1.OptionsPrint.PrintCardCaption = True
        Me.LayoutView1.OptionsPrint.AllowCancelPrintExport = True
        Me.LayoutView1.OptionsPrint.ShowPrintExportProgress = True
        'Me.LayoutView1.ShowPrintPreview()
        PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel)
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True
    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

    End Sub
End Class