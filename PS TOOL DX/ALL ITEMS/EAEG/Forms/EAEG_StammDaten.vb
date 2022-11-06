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
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Public Class EAEG_StammDaten
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim EAEG_Konten_ViewCaption As String = Nothing

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

    Private Sub EAEG_KUNDEN_STAMMBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EAEG_KUNDEN_STAMMBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)

    End Sub

    Private Sub EAEG_StammDaten_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        Me.EAEG_KUNDEN_KONTEN_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN_ALL)
        Me.EAEG_KUNDEN_KONTENTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN)
        Me.EAEG_KUNDEN_STAMMTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_STAMM)

        If EDP_USER = "Y" Then
            Me.EAEG_StammDaten_BaseView.OptionsBehavior.Editable = True
            Me.EAEG_Alle_Konten_GridView.OptionsBehavior.Editable = True
        Else
            Me.EAEG_StammDaten_BaseView.OptionsBehavior.Editable = False
            Me.EAEG_Alle_Konten_GridView.OptionsBehavior.Editable = False
        End If


    End Sub
    Private Sub UPDATE_B14_AUSCHLUSS_GESAMT_KZ()
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "EXEC [EAEG_KUNDEN_B14_AUSSCHLUSS]"
            cmd.ExecuteNonQuery()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on SQL stored Procedure:[EAEG_KUNDEN_B14_AUSSCHLUSS]", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub UPDATE_C20_C21_AUSCHLUSS_GESAMT_KZ()
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "EXEC [EAEG_KUNDENKONTEN_C20_C21_AUSSCHLUSS]"
            cmd.ExecuteNonQuery()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            XtraMessagebox.Show(ex.Message, "Error on SQL stored Procedure:[EAEG_KUNDEN_B14_AUSSCHLUSS]", MessageboxButtons.OK, MessageboxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.EAEG_StammDatenKonten_BaseView.ClearColumnsFilter()
                Me.EAEG_StammDaten_BaseView.ClearColumnsFilter()

                Me.Validate()
                Me.EAEG_KUNDEN_KONTENBindingSource.EndEdit()
                Me.EAEG_KUNDEN_STAMMBindingSource.EndEdit()
                'If Me.EAEGDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)
                    UPDATE_B14_AUSCHLUSS_GESAMT_KZ()
                    Dim view As GridView = EAEG_StammDaten_BaseView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.GridControl2.BeginUpdate()
                    Me.EAEG_KUNDEN_KONTEN_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN_ALL)
                    Me.EAEG_KUNDEN_KONTENTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN)
                    Me.EAEG_KUNDEN_STAMMTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_STAMM)
                    view.RefreshData()
                    Me.GridControl2.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        'Save Changes Detail
        If e.Button.Hint = "SaveDetail" Then
            Try

                Me.Validate()
                Me.EAEG_KUNDEN_KONTENBindingSource.EndEdit()
                Me.EAEG_KUNDEN_STAMMBindingSource.EndEdit()
                'If Me.EAEGDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)
                    UPDATE_B14_AUSCHLUSS_GESAMT_KZ()
                    Dim view As GridView = EAEG_StammDaten_BaseView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.GridControl2.BeginUpdate()
                    Me.EAEG_KUNDEN_KONTEN_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN_ALL)
                    Me.EAEG_KUNDEN_KONTENTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN)
                    Me.EAEG_KUNDEN_STAMMTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_STAMM)
                    view.RefreshData()
                    Me.GridControl2.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                End If
                'End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.EAEG_StammDatenKonten_BaseView.ClearColumnsFilter()
                Me.EAEG_StammDaten_BaseView.ClearColumnsFilter()

                Me.Validate()
                Me.EAEG_KUNDEN_KONTENBindingSource.EndEdit()
                Me.EAEG_KUNDEN_STAMMBindingSource.EndEdit()
                'If Me.EAEGDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)
                    UPDATE_C20_C21_AUSCHLUSS_GESAMT_KZ()
                    Dim view As GridView = EAEG_Alle_Konten_GridView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.GridControl3.BeginUpdate()
                    Me.EAEG_KUNDEN_KONTEN_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN_ALL)
                    Me.EAEG_KUNDEN_KONTENTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN)
                    Me.EAEG_KUNDEN_STAMMTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_STAMM)
                    view.RefreshData()
                    Me.GridControl3.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Save Changes Detail
        If e.Button.Hint = "SaveDetail" Then
            Try

                Me.Validate()
                Me.EAEG_KUNDEN_KONTENBindingSource.EndEdit()
                Me.EAEG_KUNDEN_STAMMBindingSource.EndEdit()
                'If Me.EAEGDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)
                    UPDATE_C20_C21_AUSCHLUSS_GESAMT_KZ()
                    Dim view As GridView = EAEG_Alle_Konten_GridView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.GridControl3.BeginUpdate()
                    Me.EAEG_KUNDEN_KONTEN_ALL_TableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN_ALL)
                    Me.EAEG_KUNDEN_KONTENTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_KONTEN)
                    Me.EAEG_KUNDEN_STAMMTableAdapter.Fill(Me.EAEGDataSet.EAEG_KUNDEN_STAMM)
                    view.RefreshData()
                    Me.GridControl3.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                End If
                'End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    'Anrede des Kunden bei Änderung automatisch speichern
    Private Sub RepositoryItemImageComboBox1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox1.EditValueChanged
        If XtraMessageBox.Show("Soll die Anrede des Kunden geändert werden?", "Neue Anrede", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                EAEG_StammDaten_BaseView.PostEditor()
                Me.EAEG_KUNDEN_STAMMBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.EAEGDataSet)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Else
            Me.EAEG_KUNDEN_STAMMBindingSource.CancelEdit()
            EAEG_StammDaten_BaseView.HideEditor()
        End If

    End Sub

    Private Sub KundenStammSpeichern_btn_Click(sender As Object, e As EventArgs) Handles KundenStammSpeichern_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl1
        edit.OwnerEdit.ClosePopup()
        'Me.GridControl2.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
        Me.GridControl2.EmbeddedNavigator.Buttons.DoClick(Me.GridControl2.EmbeddedNavigator.Buttons.CustomButtons.Item(0))
        'Me.GridControl2.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False

    End Sub

    Private Sub KundenStamm_Abrechen_btn_Click(sender As Object, e As EventArgs) Handles KundenStamm_Abrechen_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl1
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub Gridview_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Gridview_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
        Dim reportfooter As String = "EAEG STAMMDATEN"

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

    Private Sub EAEG_StammDaten_BaseView_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles EAEG_StammDaten_BaseView.CustomRowCellEdit
        If e.Column.FieldName = "B6_Anrede" Then
            e.RepositoryItem = RepositoryItemImageComboBox1
        End If

    End Sub

    Private Sub EAEG_StammDaten_BaseView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles EAEG_StammDaten_BaseView.CustomRowCellEditForEditing
        If e.Column.FieldName = "B6_Anrede" Then
            e.RepositoryItem = RepositoryItemPopupContainerEdit1
        End If
    End Sub

    Private Sub EAEG_StammDaten_BaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles EAEG_StammDaten_BaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "EAEG_StammDaten_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            EAEG_Konten_ViewCaption = "EAEG Konten für Kunde: " & view.GetFocusedRowCellValue("B3_Nachname").ToString & "  (" & view.GetFocusedRowCellValue("B2_Ordnungskennzeichen").ToString & ")"
            Me.EAEG_StammDatenKonten_BaseView.ViewCaption = EAEG_Konten_ViewCaption
        End If
    End Sub

    Private Sub EAEG_StammDaten_BaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles EAEG_StammDaten_BaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "EAEG_StammDaten_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            EAEG_Konten_ViewCaption = "EAEG Konten für Kunde: " & view.GetFocusedRowCellValue("B3_Nachname").ToString & "  (" & view.GetFocusedRowCellValue("B2_Ordnungskennzeichen").ToString & ")"
            Me.EAEG_StammDatenKonten_BaseView.ViewCaption = EAEG_Konten_ViewCaption
        End If
    End Sub

    Private Sub EAEG_StammDaten_BaseView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles EAEG_StammDaten_BaseView.PrintInitialize
        If MessageBox.Show("Sollen die Kundenkonten details auch angezeigt werden?", "KONTEN DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Me.EAEG_StammDaten_BaseView.OptionsPrint.ExpandAllDetails = True
            Me.EAEG_StammDaten_BaseView.OptionsPrint.PrintDetails = True
        Else
            Me.EAEG_StammDaten_BaseView.OptionsPrint.ExpandAllDetails = False
            Me.EAEG_StammDaten_BaseView.OptionsPrint.PrintDetails = False
        End If
    End Sub



    Private Sub EAEG_StammDaten_BaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles EAEG_StammDaten_BaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "EAEG_StammDaten_BaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            EAEG_Konten_ViewCaption = "EAEG Konten für Kunde: " & view.GetFocusedRowCellValue("B3_Nachname").ToString & "  (" & view.GetFocusedRowCellValue("B2_Ordnungskennzeichen").ToString & ")"
            Me.EAEG_StammDatenKonten_BaseView.ViewCaption = EAEG_Konten_ViewCaption

        End If
    End Sub

    Private Sub EAEG_StammDaten_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EAEG_StammDaten_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub EAEG_StammDaten_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles EAEG_StammDaten_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If

    End Sub

    Private Sub EAEG_StammDatenKonten_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EAEG_StammDatenKonten_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub EAEG_StammDatenKonten_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles EAEG_StammDatenKonten_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub KundenKontoSpeichern_btn_Click(sender As Object, e As EventArgs) Handles KundenKontoSpeichern_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl2
        edit.OwnerEdit.ClosePopup()
        Me.GridControl3.EmbeddedNavigator.Buttons.DoClick(Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(0))
    End Sub

    Private Sub KundenKonto_Abrechen_btn_Click(sender As Object, e As EventArgs) Handles KundenKonto_Abrechen_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl2
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub EAEG_Alle_Konten_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EAEG_Alle_Konten_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub EAEG_Alle_Konten_GridView_ShownEditor(sender As Object, e As EventArgs) Handles EAEG_Alle_Konten_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Konten_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Konten_Print_Export_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
            XtraMessagebox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
        Dim reportfooter As String = "EAEG KUNDENKONTEN"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

   
   
End Class