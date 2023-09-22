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
Public Class BLZ_DIRECTORY

    'BLZ Directory Data
    <VBFixedString(8)> Dim BANKLEITZAHL As String = Nothing
    <VBFixedString(1)> Dim MERKMAL As String = Nothing
    <VBFixedString(58)> Dim BEZEICHNUNG As String = Nothing
    <VBFixedString(5)> Dim POSTLEITZAHL As String = Nothing
    <VBFixedString(35)> Dim ORT As String = Nothing
    <VBFixedString(27)> Dim KURZBEZEICHNUNG As String = Nothing
    <VBFixedString(5)> Dim PAN_NR As String = Nothing
    <VBFixedString(11)> Dim BIC As String = Nothing
    <VBFixedString(2)> Dim PRUEFZIFFER_KZ As String = Nothing
    <VBFixedString(6)> Dim DATENSATZ_NR As String = Nothing
    <VBFixedString(1)> Dim AENDERUNG_KZ As String = Nothing
    <VBFixedString(1)> Dim BLZ_LOESCHUNG As String = Nothing
    <VBFixedString(8)> Dim NACHFOLGE_BLZ As String = Nothing

    Dim BLZ_ROW As String = Nothing
    Friend WithEvents BgwCreateBlzDirectory As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Dim BLZ_DirectoryCreationFolder As String = Nothing
    Dim BLZ_CreationFileName As String = Nothing

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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub BLZ_DIRECTORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BLZTableAdapter.Fill(Me.EXTERNALDataset.BLZ)

        'Gridcontrol2 - BIC DIRECTORY
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = BLZGridView
        BLZGridView.ForceDoubleClick = True
        AddHandler BLZGridView.DoubleClick, AddressOf BLZGridView_DoubleClick
        AddHandler BLZLayoutView.MouseDown, AddressOf BLZLayoutView_MouseDown
        'AddHandler BLZViews_btn.Click, AddressOf BLZViews_btn_Click
        BLZLayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        BLZLayoutView.OptionsBehavior.AllowSwitchViewModes = False


    End Sub

#Region "BLZ_DIRECTORY_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = BLZLayoutView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BLZGridView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strShowExtendedMode
        DisplayListDetails_bbi.ImageIndex = 10
        fExtendedEditMode = (GridControl2.MainView Is BLZLayoutView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = BLZGridView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BLZLayoutView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strHideExtendedMode
        DisplayListDetails_bbi.ImageIndex = 11
        fExtendedEditMode = (GridControl2.MainView Is BLZLayoutView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = BLZGridView.GetRowHandle(dataSourceRowIndex)
        BLZGridView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = BLZLayoutView.GetRowHandle(dataSourceRowIndex)
        BLZLayoutView.VisibleRecordIndex = BLZLayoutView.GetVisibleIndex(rowHandle)
        BLZLayoutView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub BLZGridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = BLZGridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub BLZLayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = BLZLayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub BLZViews_btn_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
#End Region

    Private Sub DisplayListDetails_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DisplayListDetails_bbi.ItemClick
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.bbi_Load.Enabled = False
        Me.DisplayListDetails_bbi.Enabled = False
        Me.bbi_CreateBlzDirectory.Enabled = False

    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.bbi_Load.Enabled = True
        Me.DisplayListDetails_bbi.Enabled = True
        Me.bbi_CreateBlzDirectory.Enabled = True
    End Sub



    Private Sub bbi_Load_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Load.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load BLZ Data")
        Me.BLZTableAdapter.Fill(Me.EXTERNALDataset.BLZ)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub bbi_CreateBlzDirectory_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_CreateBlzDirectory.ItemClick
        If XtraMessageBox.Show("Should the BLZ Directory (BLZ plus BIC) be re-created?", "BLZplusBIC Directory creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                Using myFileDialog As New SaveFileDialog()
                    myFileDialog.Title = "BLZplusBIC Directory creation"
                    myFileDialog.Filter = "Text File (*.txt)|*.txt" '"Text files (*.txt)|*.txt|All files (*.*)|*.*"
                    myFileDialog.FilterIndex = 1
                    'myFileDialog.InitialDirectory = "C:\"
                    myFileDialog.CheckFileExists = False
                    myFileDialog.RestoreDirectory = True
                    myFileDialog.FileName = "BLZ_plus_BIC_from_PSTOOL.txt"
                    Dim result As DialogResult = myFileDialog.ShowDialog

                    If result = DialogResult.OK Then
                        BLZ_DirectoryCreationFolder = IO.Path.GetDirectoryName(myFileDialog.FileName)
                        BLZ_CreationFileName = myFileDialog.FileName
                        DISABLE_BUTTONS()
                        Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
                        BgwCreateBlzDirectory = New BackgroundWorker
                        bgws.Add(BgwCreateBlzDirectory)
                        BgwCreateBlzDirectory.WorkerReportsProgress = True
                        BgwCreateBlzDirectory.RunWorkerAsync()
                    End If
                End Using

            Catch ex As System.Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

        End If
    End Sub

    Private Sub BgwCreateBlzDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwCreateBlzDirectory.DoWork
        Try
            BgwCreateBlzDirectory.ReportProgress(5, "Start creating the BLZ Directory")
            QueryText = "SELECT  * FROM  [BLZ] where [BIC]<>'' and [Änderungs-kennzeichen] not in ('D') ORDER BY [Bankleitzahl] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                BgwCreateBlzDirectory.ReportProgress(5, "Create Datarow in BLZ Directory for BLZ: " & dt.Rows.Item(i).Item("Bankleitzahl") & " - " & dt.Rows.Item(i).Item("Bezeichnung"))
                System.Threading.Thread.Sleep(5)
                BANKLEITZAHL = dt.Rows.Item(i).Item("Bankleitzahl")
                MERKMAL = dt.Rows.Item(i).Item("Merkmal")
                BEZEICHNUNG = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Bezeichnung"), 58)
                POSTLEITZAHL = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("PLZ"), 5)
                ORT = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Ort"), 35)
                KURZBEZEICHNUNG = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Kurzbezeichnung"), 27)
                If IsDBNull(dt.Rows.Item(i).Item("PAN")) = False Then
                    PAN_NR = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("PAN"), 5)
                Else
                    PAN_NR = ""
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BIC")) = False Then
                    BIC = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("BIC"), 11)
                Else
                    BIC = ""
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Prüfziffer-berechnungs-methode")) = False Then
                    PRUEFZIFFER_KZ = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Prüfziffer-berechnungs-methode"), 2)
                Else
                    PRUEFZIFFER_KZ = ""
                End If
                DATENSATZ_NR = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Datensatz-nummer"), 6)
                AENDERUNG_KZ = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Änderungs-kennzeichen"), 1)
                BLZ_LOESCHUNG = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Bankleitzahl-löschung"), 1)
                NACHFOLGE_BLZ = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Nachfolge-Bankleitzahl"), 8)


                BLZ_ROW = BANKLEITZAHL & MERKMAL & BEZEICHNUNG & POSTLEITZAHL & ORT & KURZBEZEICHNUNG & PAN_NR & BIC & PRUEFZIFFER_KZ & DATENSATZ_NR & AENDERUNG_KZ & BLZ_LOESCHUNG & NACHFOLGE_BLZ

                System.IO.File.AppendAllText(BLZ_CreationFileName, BLZ_ROW & vbCrLf)
            Next
            BgwCreateBlzDirectory.ReportProgress(5, "The creation of the BLZ Directory is finished")
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            BgwCreateBlzDirectory.CancelAsync()
        End Try
    End Sub

    Private Sub BgwCreateBlzDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwCreateBlzDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwCreateFullT2Directory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwCreateBlzDirectory.RunWorkerCompleted
        If e.Cancelled = False Then
            If XtraMessageBox.Show("The following BLZ file has being created:" & vbNewLine & BLZ_DirectoryCreationFolder & "\" & BLZ_CreationFileName & vbNewLine & "Should the directory be opened?", "NEW T2 DIRECTORY FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                System.Diagnostics.Process.Start(BLZ_DirectoryCreationFolder)
            End If
        End If
        Workers_Complete(BgwCreateBlzDirectory, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never
    End Sub

    Private Sub bbi_PrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintExport.ItemClick
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If DisplayListDetails_bbi.Caption = "Display Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.BLZLayoutView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.BLZLayoutView.OptionsPrint.PrintCardCaption = True
            Me.BLZLayoutView.OptionsPrint.AllowCancelPrintExport = True
            Me.BLZLayoutView.OptionsPrint.ShowPrintExportProgress = True
            'Me.BLZLayoutView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If
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
        Dim reportfooter As String = "BLZ DIRECTORY" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub

    Private Sub BLZ_DIRECTORY_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class