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
Imports DevExpress.XtraGrid.Views.Layout.Events
Imports DevExpress.XtraGrid.Views.Layout
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
Imports DevExpress.XtraPrinting.Links
Imports DevExpress.XtraPrintingLinks
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports System.Numerics




Public Class Countries
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim CurrencyCode As String = ""
    Dim CurrencyName As String = ""

    Private BS_ExternalRating As BindingSource

    Private ImageDir As String = Nothing
    Dim CountryName As String = Nothing
    Dim fileName As String = Nothing
    Private Images As Hashtable = New Hashtable()



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

    Private Sub COUNTRIESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.COUNTRIESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)

    End Sub

    Private Sub Countries_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            '***********Save Changes****************
            If Me.EXTERNALDataset.HasChanges = True Then
                If MessageBox.Show("Should the Changes in Countries be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.Validate()
                    Me.COUNTRIESBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                    EWU_UPDATE()
                End If
            End If
            '****************************************
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub Countries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='Flags_Images_Directory' and [IdABTEILUNGSPARAMETER]='FLAGS_IMAGES' and [PARAMETER STATUS]='Y' "
        ImageDir = cmd.ExecuteScalar
        cmd.Connection.Close()

        'TODO: This line of code loads data into the 'EXTERNALDataset.CURRENCIES' table. You can move, or remove it, as needed.
        Me.CURRENCIESTableAdapter.Fill(Me.EXTERNALDataset.CURRENCIES)
        'TODO: This line of code loads data into the 'EXTERNALDataset.COUNTRIES' table. You can move, or remove it, as needed.
        Me.COUNTRIESTableAdapter.Fill(Me.EXTERNALDataset.COUNTRIES)

        'Gridcontrol2 - COUNTRIES
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = CountriesBaseView
        CountriesBaseView.ForceDoubleClick = True
        AddHandler CountriesBaseView.DoubleClick, AddressOf CountriesBaseView_DoubleClick
        AddHandler CountriesDetailView.MouseDown, AddressOf CountriesDetailView_MouseDown
        AddHandler ViewEdit_btn.Click, AddressOf ViewEdit_btn_Click
        CountriesDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        CountriesDetailView.OptionsBehavior.AllowSwitchViewModes = False

        EXTERNAL_RATING_initData()
        EXTERNAL_RATING_InitLookUp()

        If SUPER_USER = "N" Then
            Me.CountriesBaseView.OptionsBehavior.Editable = False
            Me.CountriesDetailView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub EXTERNAL_RATING_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbExternalRating As SqlDataAdapter = New SqlDataAdapter("SELECT [Rating],[Stufe] FROM [PD_EXTERNAL] order by Stufe asc,rating asc", conn) '
        Try

            dbExternalRating.Fill(ds, "PD_EXTERNAL")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_ExternalRating = New BindingSource(ds, "PD_EXTERNAL")

    End Sub

    Private Sub EXTERNAL_RATING_InitLookUp()
        Me.RatingRepositoryItemGridLookUpEdit.DataSource = BS_ExternalRating
        Me.RatingRepositoryItemGridLookUpEdit.DisplayMember = "Rating"
        Me.RatingRepositoryItemGridLookUpEdit.ValueMember = "Rating"
    End Sub
    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

    End Sub

#Region "COUNTRIES_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "Edit Country Data"
    Protected Sub HideDetail(ByVal rowHandle As Integer)

        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = CountriesDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CountriesBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        ViewEdit_btn.Text = strShowExtendedMode
        ViewEdit_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is CountriesDetailView)

        '***********Save Changes****************
        If Me.EXTERNALDataset.HasChanges = True Then
            If MessageBox.Show("Should the Changes in Countries be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.Validate()
                Me.COUNTRIESBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                EWU_UPDATE()
                Me.COUNTRIESTableAdapter.Fill(Me.EXTERNALDataset.COUNTRIES)
            Else
                Me.COUNTRIESBindingSource.CancelEdit()
                Me.COUNTRIESTableAdapter.Fill(Me.EXTERNALDataset.COUNTRIES)
            End If
        End If
        '****************************************
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = CountriesBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CountriesDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        ViewEdit_btn.Text = strHideExtendedMode
        ViewEdit_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is CountriesDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CountriesBaseView.GetRowHandle(dataSourceRowIndex)
        CountriesBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CountriesDetailView.GetRowHandle(dataSourceRowIndex)
        CountriesDetailView.VisibleRecordIndex = CountriesDetailView.GetVisibleIndex(rowHandle)
        CountriesDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub CountriesBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = CountriesBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub CountriesDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = CountriesDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub ViewEdit_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub CountriesDetailView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CountriesDetailView.CellValueChanged
        If CountriesDetailView.FocusedColumn.FieldName = "CURRENCY CODE" Then
            'Get the currently edited value 
            Dim CUR_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(CUR_CODE) = 3 Then
                cmd.CommandText = "SELECT * FROM [CURRENCIES] where [CURRENCY CODE]='" & CUR_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    CountriesDetailView.SetRowCellValue(e.RowHandle, "CURRENCY NAME", dt.Rows.Item(0).Item("CURRENCY NAME"))
                Else
                    MessageBox.Show("CURRENCY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CountriesDetailView.SetRowCellValue(e.RowHandle, "CURRENCY NAME", "")
                End If
            End If
        End If





    End Sub

    Private Sub CountriesDetailView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles CountriesDetailView.CellValueChanging
        If CountriesDetailView.FocusedColumn.FieldName = "CURRENCY CODE" Then
            'Get the currently edited value 
            Dim CUR_CODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(CUR_CODE) = 3 Then
                cmd.CommandText = "SELECT * FROM [CURRENCIES] where [CURRENCY CODE]='" & CUR_CODE & "'"
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    CountriesDetailView.SetRowCellValue(e.RowHandle, "CURRENCY NAME", dt.Rows.Item(0).Item("CURRENCY NAME"))
                Else
                    MessageBox.Show("CURRENCY CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CountriesDetailView.SetRowCellValue(e.RowHandle, "CURRENCY NAME", "")
                End If
            End If
        End If
    End Sub

   


    Private Sub CountriesDetailView_MouseWheel(sender As Object, e As MouseEventArgs) Handles CountriesDetailView.MouseWheel
        TryCast(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
    End Sub

   

    Private Sub CountriesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CountriesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CountriesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CountriesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CurrencyRepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles CurrencyRepositoryItemLookUpEdit1.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = row("CURRENCY NAME")
        If row IsNot Nothing Then
            CurrencyCode = DirectCast(row, DataRowView)("CURRENCY CODE").ToString()
            CurrencyName = DirectCast(row, DataRowView)("CURRENCY NAME").ToString()

        End If

    End Sub

    Private Sub Countries_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Countries_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If ViewEdit_btn.Text = "Edit Country Data" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.CountriesDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.CountriesDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.CountriesDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.CountriesDetailView.OptionsPrint.PrintCardCaption = True
            Me.CountriesDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.CountriesDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.CountriesDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.CountriesDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.CountriesDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If
    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = System.Drawing.Printing.PaperKind.A4, _
            .Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20) _
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
        Dim reportfooter As String = "COUNTRIES" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Function GetFileName(ByVal color As String) As String

        If color Is Nothing OrElse color = String.Empty Then

            Return String.Empty

        End If

        Return RTrim(color) & ".png"

    End Function

    Private Sub CountriesBaseView_CustomUnboundColumnData(sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles CountriesBaseView.CustomUnboundColumnData
        If e.Column.FieldName = "ColCountryFlag" AndAlso e.IsGetData Then

            Dim view As GridView = TryCast(sender, GridView)

            'Dim colorName As String = CStr(view.GetRowCellValue(view.FocusedRowHandle, "COUNTRY NAME"))
            CountryName = CStr((CType(e.Row, DataRowView))("COUNTRY NAME"))

            fileName = Trim(GetFileName(CountryName).ToLower())
            'MsgBox(fileName)

            If (Not Images.ContainsKey(fileName)) Then

                Dim img As Image = Nothing

                Try

                    'Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, ImageDir & fileName, False)
                    Dim filePath As String = ImageDir & fileName
                    'MsgBox(filePath)
                    img = Image.FromFile(filePath)

                Catch

                End Try

                Images.Add(fileName, img)

            End If

            e.Value = Images(fileName)

        End If


    End Sub

    Private Sub CountriesDetailView_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles CountriesDetailView.CustomUnboundColumnData
        Dim Lview As LayoutView = TryCast(sender, LayoutView)
        CountryName = Lview.GetRowCellValue(e.ListSourceRowIndex, "COUNTRY NAME").ToString()
        fileName = Trim(GetFileName(CountryName).ToLower())

        Dim fillePath As String = ImageDir & fileName

        Dim im As Image = Image.FromFile(fillePath)
        e.Value = im

    End Sub

    Private Sub RatingRepositoryItemGridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles RatingRepositoryItemGridLookUpEdit.EditValueChanged
        Try
            CountriesBaseView.PostEditor()
            Me.Validate()
            Me.COUNTRIESBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.COUNTRIESBindingSource.CancelEdit()
            CountriesBaseView.HideEditor()

        End Try
    End Sub

    Private Sub RatingRepositoryItemGridLookUpEdit1View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles RatingRepositoryItemGridLookUpEdit1View.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub RatingRepositoryItemGridLookUpEdit1View_ShownEditor(sender As Object, e As EventArgs) Handles RatingRepositoryItemGridLookUpEdit1View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub EWU_UPDATE()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "UPDATE [COUNTRIES] SET [EWU]='Y' where [CURRENCY CODE] in ('EUR') and [EU EEA] in ('EU') "
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub AufsichtRepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles AufsichtRepositoryItemImageComboBox.EditValueChanged

        Try
            CountriesBaseView.PostEditor()
            Me.Validate()
            Me.COUNTRIESBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.COUNTRIESBindingSource.CancelEdit()
            CountriesBaseView.HideEditor()

        End Try
    End Sub

    Private Sub CountryLimit_RepositoryItemTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CountryLimit_RepositoryItemTextEdit.EditValueChanged
        Try
            CountriesBaseView.PostEditor()
            Me.Validate()
            Me.COUNTRIESBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.COUNTRIESBindingSource.CancelEdit()
            CountriesBaseView.HideEditor()

        End Try
    End Sub

    Private Sub CountryLimit_RepositoryItemSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CountryLimit_RepositoryItemSpinEdit.EditValueChanged
        Try
            CountriesBaseView.PostEditor()
            Me.Validate()
            Me.COUNTRIESBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.COUNTRIESBindingSource.CancelEdit()
            CountriesBaseView.HideEditor()

        End Try
    End Sub
End Class