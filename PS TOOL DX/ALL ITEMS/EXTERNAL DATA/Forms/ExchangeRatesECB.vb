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
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Public Class ExchangeRatesECB

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

    Private Sub EXCHANGE_RATES_ECBBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EXCHANGE_RATES_ECBBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)

    End Sub

    Private Sub ExchangeRatesECB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'EXTERNALDataset.EXCHANGE_RATES_ECB' table. You can move, or remove it, as needed.
        Me.EXCHANGE_RATES_ECBTableAdapter.FillByLastExchangeDate(Me.EXTERNALDataset.EXCHANGE_RATES_ECB)
        Me.ExchangeRatesECBBaseView.ExpandAllGroups()


    End Sub

    Private Sub LoadExchangeRatesECB_btn_Click(sender As Object, e As EventArgs) Handles LoadExchangeRatesECB_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True AndAlso IsDate(Me.TillDateEdit.Text) = True Then
            Try
                Me.FromDateEdit.DataBindings.Clear()
                Me.TillDateEdit.DataBindings.Clear()

                Dim d1 As Date = Me.FromDateEdit.Text
                Dim d2 As Date = Me.TillDateEdit.Text
                If d1 <= d2 Then
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load ECB Exchange rates from: " & d1 & " till " & d2)
                    Me.EXCHANGE_RATES_ECBTableAdapter.FillByExchangeDate(Me.EXTERNALDataset.EXCHANGE_RATES_ECB, d1, d2)
                    Me.ExchangeRatesECBBaseView.ExpandAllGroups()
                    SplashScreenManager.CloseForm(False)
                Else
                    MessageBox.Show("Field:Date Till must be higher or equal to Field:Date From", "INVALID DATES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

        End If
    End Sub

    Private Sub ExchangeRates_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles ExchangeRates_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "ECB EXCHANGE RATES" & "  " & "from: " & Me.FromDateEdit.Text & " till: " & Me.TillDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    'Private Sub ExchangeRatesECBBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExchangeRatesECBBaseView.RowStyle
    '    If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
    '        e.Appearance.BackColor = SystemColors.InactiveCaptionText
    '    End If
    'End Sub

    'Private Sub ExchangeRatesECBBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExchangeRatesECBBaseView.ShownEditor
    '    Dim view As GridView = CType(sender, GridView)
    '    If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
    '        view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
    '    End If
    'End Sub


End Class