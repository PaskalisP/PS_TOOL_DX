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
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraGrid.Columns


Public Class T2_DIRECTORY

    Dim d As Date = Today
    Dim tilld As Date = "31.12.9999"

    <VBFixedString(105)> Public PARTICIPANT_NAME As String = Nothing
    <VBFixedString(105)> Public PARTICIPANT_NAME_BRANCH As String = Nothing
    <VBFixedString(35)> Public CITY_HEADING As String = Nothing
    <VBFixedString(35)> Public CITY_HEADING_BRANCH As String = Nothing
    Dim ADDRESSEE_NAME As String = Nothing
    Dim ACCOUNT_HOLDER_NAME As String = Nothing
    Dim BIC8 As String = Nothing

    <VBFixedString(11)> Public BIC11 As String = Nothing
    <VBFixedString(11)> Public BIC11_BRANCH As String = Nothing
    <VBFixedString(11)> Public ADDRESSEE As String = Nothing
    <VBFixedString(11)> Public ACCOUNT_HOLDER As String = Nothing
    <VBFixedString(105)> Public BIC11_NAME As String = Nothing
    <VBFixedString(35)> Public CITY As String = Nothing
    <VBFixedString(15)> Public SORTCODE As String = Nothing
    <VBFixedString(1)> Public MAIN_BIC_FLAG As String = Nothing
    <VBFixedString(1)> Public TYPE_OF_CHANGE As String = Nothing
    Dim ValidFrom As Date
    <VBFixedString(8)> Public ValidFromSql As String = Nothing
    Dim ValidTill As Date
    <VBFixedString(8)> Public ValidTillSql As String = Nothing
    <VBFixedString(2)> Public PARTICIPATION_TYPE As String = Nothing
    <VBFixedString(23)> Public RESERVE As String = "                       " '23 Blanks

    Dim T2_ROW As String = Nothing
    Dim IsNotNullValidationRule As New ConditionValidationRule()

    Dim ParticipantBIC11 As String = Nothing
    Dim ParticipantBIC8 As String = Nothing
    Dim AddresseeBIC_Value As String = Nothing
    Dim AddresseeBIC_Name_Value As String = Nothing
    Dim AccountHolderBIC_Value As String = Nothing
    Dim AccountHolderBIC_Name_Value As String = Nothing
    Dim TypeOfChange As String = Nothing
    Dim Participant_ValidFrom As Date
    Dim Participant_ValidTill As Date
    Dim Participant_ValidFrom_SQL As String = Nothing
    Dim Participant_ValidTill_SQL As String = Nothing
    Dim Participant_Reserve As String = Nothing

    Friend WithEvents BgwValidateT2Directory As BackgroundWorker
    Friend WithEvents BgwCreateFullT2Directory As BackgroundWorker
    Friend WithEvents BgwCreateModifiedT2Directory As BackgroundWorker

    Private bgws As New List(Of BackgroundWorker)()

    Dim T2_DirectoryCreationFolder As String = Nothing
    Delegate Sub ChangeText()
    Dim CurrentRow As TextBox


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

    Private Sub T2_DIRECTORYBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.T2_DIRECTORYBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)

    End Sub

    Private Sub T2_DIRECTORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.T2_DIRECTORYTableAdapter.FillByT2_FILL(Me.EXTERNALDataset.T2_DIRECTORY)


        Me.ValidFrom_DateEdit.Text = d.ToString("dd.MM.yyyy")
        Me.ValidTill_DateEdit.Text = tilld

        'Gridcontrol2 - CUSTOMERS
        'GridControl2.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = T2BaseView
        T2BaseView.ForceDoubleClick = True
        AddHandler T2BaseView.DoubleClick, AddressOf T2BaseView_DoubleClick
        AddHandler T2DetailView.MouseDown, AddressOf T2DetailView_MouseDown
        T2DetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        T2DetailView.OptionsBehavior.AllowSwitchViewModes = False

        'Validation Rule

        IsNotNullValidationRule.ConditionOperator = ConditionOperator.Equals
        IsNotNullValidationRule.Value1 = ""
        IsNotNullValidationRule.ErrorText = "Please enter BIC Code"
        IsNotNullValidationRule.CaseSensitive = False

        If SUPER_USER = "N" Then
            Me.T2BaseView.OptionsBehavior.Editable = False
            Me.T2DetailView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub T2_DIRECTORY_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub

    'Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
    '    If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then
    '        Me.LayoutControl1.Visible = False
    '    End If
    '    If e.Button.ButtonType = NavigatorButtonType.Custom Then
    '        If e.Button.Tag = "AddNewT2" Then
    '            Me.LayoutControl1.Visible = False
    '        End If
    '    End If
    'End Sub

#Region "T2_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        '***********Save Changes****************
        If Me.EXTERNALDataset.HasChanges = True Then
            'Participant_ValidFrom = Me.T2DetailView.GetRowCellValue(Me.T2DetailView.FocusedRowHandle, colVALID_FROM1)
            'Participant_ValidFrom_SQL = Participant_ValidFrom.ToString("yyyyMMdd")
            'Participant_ValidTill = Me.T2DetailView.GetRowCellValue(Me.T2DetailView.FocusedRowHandle, colVALID_TILL1)
            'Participant_ValidTill_SQL = Participant_ValidTill.ToString("yyyyMMdd")

            If AddresseeBIC_Value <> "" AndAlso AccountHolderBIC_Value <> "" AndAlso IsDate(Participant_ValidFrom) = True AndAlso IsDate(Participant_ValidTill) = True Then

                GridControl2.MainView.PostEditor()
                Dim datasourceRowIndex As Integer = T2DetailView.GetDataSourceRowIndex(rowHandle)
                GridControl2.MainView = T2BaseView
                SynchronizeOrdersView(datasourceRowIndex)
                'GridControl2.UseEmbeddedNavigator = True
                'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                DisplayListDetails_bbi.Caption = strShowExtendedMode
                DisplayListDetails_bbi.ImageIndex = 14
                fExtendedEditMode = (GridControl2.MainView Is T2DetailView)
                T2_Dir_BarSubItem.Visibility = BarItemVisibility.Always

                Try
                    If XtraMessageBox.Show("Should the Changes for Participant BIC:" & ParticipantBIC11 & " in T2 Directory be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Updating T2 Directory-Please wait")
                        Me.Validate()
                        Me.T2_DIRECTORYBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)
                        If XtraMessageBox.Show("Should the Changes for Participant BIC:" & ParticipantBIC11 & " inserted also in " & ParticipantBIC8 & " ?", "SAVE CHANGES in ALL BIC8", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                            OpenSqlConnections()
                            cmd.CommandText = "UPDATE [T2 DIRECTORY] SET [ADDRESSEE]='" & AddresseeBIC_Value & "',[ADDRESSEE_NAME]='" & AddresseeBIC_Name_Value & "',[ACCOUNT_HOLDER]='" & AccountHolderBIC_Value & "',[ACCOUNT_HOLDER_NAME]='" & AccountHolderBIC_Name_Value & "',[TYPE_OF_CHANGE]='" & TypeOfChange & "',[VALID_FROM]='" & Participant_ValidFrom_SQL & "',[VALID_TILL]='" & Participant_ValidTill_SQL & "',[RESERVE]='" & Participant_Reserve & "' where LEFT([BIC11],8)='" & ParticipantBIC8 & "' and [BIC11] not in ('" & ParticipantBIC11 & "' )"
                            cmd.ExecuteNonQuery()
                            CloseSqlConnections()
                        End If
                        Me.T2_DIRECTORYTableAdapter.FillByT2_FILL(Me.EXTERNALDataset.T2_DIRECTORY)
                        SplashScreenManager.CloseForm(False)
                    Else
                        Me.T2_DIRECTORYBindingSource.EndEdit()
                        Me.T2_DIRECTORYBindingSource.CancelEdit()
                        Me.EXTERNALDataset.RejectChanges()

                        'Me.T2_DIRECTORYTableAdapter.FillByT2_FILL(Me.EXTERNALDataset.T2_DIRECTORY)
                    End If
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.T2_DIRECTORYBindingSource.CancelEdit()
                    Me.EXTERNALDataset.RejectChanges()
                    'Me.T2_DIRECTORYTableAdapter.FillByT2_FILL(Me.EXTERNALDataset.T2_DIRECTORY)
                End Try

                '****************************************

            Else
                XtraMessageBox.Show("There are Mandatory Fields without any input! Please check!", "UNABEL TO UPDATE T2 DIRECTORY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If
        Else
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = T2DetailView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = T2BaseView
            SynchronizeOrdersView(datasourceRowIndex)
            'GridControl2.UseEmbeddedNavigator = True
            'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strShowExtendedMode
            DisplayListDetails_bbi.ImageIndex = 14
            fExtendedEditMode = (GridControl2.MainView Is T2DetailView)
            T2_Dir_BarSubItem.Visibility = BarItemVisibility.Always
        End If

    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = T2BaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = T2DetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        'GridControl2.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strHideExtendedMode
        DisplayListDetails_bbi.ImageIndex = 15
        fExtendedEditMode = (GridControl2.MainView Is T2DetailView)
        T2_Dir_BarSubItem.Visibility = BarItemVisibility.Never

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = T2BaseView.GetRowHandle(dataSourceRowIndex)
        T2BaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = T2DetailView.GetRowHandle(dataSourceRowIndex)
        T2DetailView.VisibleRecordIndex = T2DetailView.GetVisibleIndex(rowHandle)
        T2DetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub T2BaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'Manual change only if Reserve=Manual input
        If T2BaseView.IsFilterRow(Me.T2BaseView.FocusedRowHandle) = False Then
            Dim rowHandle As Integer = T2BaseView.FocusedRowHandle
            Dim Reserve As String = T2BaseView.GetRowCellValue(rowHandle, "RESERVE").ToString
            Dim Addresse As String = T2BaseView.GetRowCellValue(rowHandle, "ADDRESSEE").ToString
            If Reserve = "Manual input" OrElse Addresse.StartsWith("TRGT") = True Then
                Me.T2DetailView.Columns.ColumnByFieldName("ADDRESSEE").OptionsColumn.ReadOnly = False
                Me.T2DetailView.Columns.ColumnByFieldName("ACCOUNT_HOLDER").OptionsColumn.ReadOnly = False
            Else
                Me.T2DetailView.Columns.ColumnByFieldName("ADDRESSEE").OptionsColumn.ReadOnly = False
                Me.T2DetailView.Columns.ColumnByFieldName("ACCOUNT_HOLDER").OptionsColumn.ReadOnly = False
            End If
        End If
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = T2BaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If


    End Sub
    Protected Sub T2DetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = T2DetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                'HideDetail(hi.RowHandle)
                DisplayListDetails_bbi.PerformClick()

            End If
        End If
    End Sub
    Protected Sub ViewEdit_btn_Click(ByVal sender As Object, ByVal e As EventArgs)



    End Sub

    Private Sub DisplayListDetails_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DisplayListDetails_bbi.ItemClick
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Manual change only if Reserve=Manual input
            If T2BaseView.IsFilterRow(Me.T2BaseView.FocusedRowHandle) = False Then
                Dim rowHandle As Integer = T2BaseView.FocusedRowHandle
                Dim Reserve As String = T2BaseView.GetRowCellValue(rowHandle, "RESERVE").ToString
                Dim Addresse As String = T2BaseView.GetRowCellValue(rowHandle, "ADDRESSEE").ToString
                If Reserve = "Manual input" OrElse Addresse.StartsWith("TRGT") = True Then
                    Me.T2DetailView.Columns.ColumnByFieldName("ADDRESSEE").OptionsColumn.ReadOnly = False
                    Me.T2DetailView.Columns.ColumnByFieldName("ACCOUNT_HOLDER").OptionsColumn.ReadOnly = False
                Else
                    Me.T2DetailView.Columns.ColumnByFieldName("ADDRESSEE").OptionsColumn.ReadOnly = False
                    Me.T2DetailView.Columns.ColumnByFieldName("ACCOUNT_HOLDER").OptionsColumn.ReadOnly = False
                End If
            End If
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub


#End Region

    Private Sub DISABLE_BUTTONS()
        Me.bbi_Reload_T2_Dir.Enabled = False
        Me.bbi_AddParticipant.Enabled = False
        Me.DisplayListDetails_bbi.Enabled = False
        Me.T2_Dir_BarSubItem.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.bbi_Reload_T2_Dir.Enabled = True
        Me.bbi_AddParticipant.Enabled = True
        Me.DisplayListDetails_bbi.Enabled = True
        Me.T2_Dir_BarSubItem.Enabled = True
    End Sub

    Public Sub Change_CurrentRow()
        CurrentRow.Text = BIC11 & " - " & BIC11_NAME
    End Sub

    Private Sub bbi_Reload_T2_Dir_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Reload_T2_Dir.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Check BIC validity for Manual inputs based on the BIC DIRECTORY")
        OpenSqlConnections()
        cmd.CommandText = "UPDATE [T2 DIRECTORY] SET [TYPE_OF_CHANGE]='D' where  [BIC11] not in (Select [BIC11] from [BIC DIRECTORY]) and [RESERVE] in ('Manual input')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Update [T2 DIRECTORY] set [PARTICIPATION_TYPE]='0' + [PARTICIPATION_TYPE] where LEN([PARTICIPATION_TYPE])=1"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [T2 DIRECTORY] SET [TYPE_OF_CHANGE]='D' where [VALID_TILL]<GETDATE() and [TYPE_OF_CHANGE] not in ('D')"
        cmd.ExecuteNonQuery()
        CloseSqlConnections()
        SplashScreenManager.Default.SetWaitFormCaption("Reload T2 Directory")
        Me.DisplayListDetails_bbi.Visibility = BarItemVisibility.Always
        Me.LayoutControl1.Visible = True
        If Me.DisplayListDetails_bbi.Caption = "Display List" Then
            Me.DisplayListDetails_bbi.PerformClick()
        End If
        Me.T2_DIRECTORYTableAdapter.FillByT2_FILL(Me.EXTERNALDataset.T2_DIRECTORY)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub bbi_AddParticipant_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_AddParticipant.ItemClick
        Me.LayoutControl1.Visible = False
        Me.DisplayListDetails_bbi.Visibility = BarItemVisibility.Never
        T2_Dir_BarSubItem.Visibility = BarItemVisibility.Never
    End Sub

    Private Sub bbi_PrintOrExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintOrExport.ItemClick
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
            Me.T2DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.T2DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.T2DetailView.Columns.ColumnByName("colBIC111").AppearanceCell.ForeColor = Color.Navy
            Me.T2DetailView.Columns.ColumnByName("colINSTITUTION_NAME1").AppearanceCell.ForeColor = Color.Navy
            Me.T2DetailView.Columns.ColumnByName("colADDRESSEE1").AppearanceCell.ForeColor = Color.Navy
            Me.T2DetailView.Columns.ColumnByName("colACCOUNT_HOLDER1").AppearanceCell.ForeColor = Color.Navy
            Me.T2DetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.T2DetailView.OptionsPrint.PrintCardCaption = True
            Me.T2DetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.T2DetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.T2DetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.T2DetailView.Columns.ColumnByName("colBIC111").AppearanceCell.ForeColor = Color.Yellow
            Me.T2DetailView.Columns.ColumnByName("colINSTITUTION_NAME1").AppearanceCell.ForeColor = Color.Yellow
            Me.T2DetailView.Columns.ColumnByName("colADDRESSEE1").AppearanceCell.ForeColor = Color.Cyan
            Me.T2DetailView.Columns.ColumnByName("colACCOUNT_HOLDER1").AppearanceCell.ForeColor = Color.Cyan
            Me.T2DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.T2DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If
    End Sub

    Private Sub bbi_T2_Full_Dir_Create_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_T2_Full_Dir_Create.ItemClick
        If XtraMessageBox.Show("Should the Full T2 Directory be re-created?" & vbNewLine & vbNewLine & "ATTENTION: DELETED T2 PARTICIPANTS WILL NOT BE INCLUDED!!!" & vbNewLine & vbNewLine & "Existing File:" & vbNewLine & T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_FullNew.ORIG" & vbNewLine & "will be deleted!", "Full T2 Directory creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='T2_Directory_Export_Folder' and  [IdABTEILUNGSPARAMETER]='T2_DIRECTORY_EXPORT' and [PARAMETER STATUS]='Y' "
            T2_DirectoryCreationFolder = cmd.ExecuteScalar
            CloseSqlConnections()
            DISABLE_BUTTONS()
            Me.LayoutControlGroup2.Visibility = LayoutVisibility.Always
            Me.LayoutControlGroup2.Text = "T2 Full Directory creation"
            BgwCreateFullT2Directory = New BackgroundWorker
            bgws.Add(BgwCreateFullT2Directory)
            BgwCreateFullT2Directory.WorkerReportsProgress = True
            BgwCreateFullT2Directory.RunWorkerAsync()
        End If
    End Sub

    Private Sub BgwCreateFullT2Directory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwCreateFullT2Directory.DoWork
        Try
            BgwCreateFullT2Directory.ReportProgress(5, "Delete (if exists) current file:T2DIRFULLVA.ASCII_FullNew.ORIG")
            If File.Exists(T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_FullNew.ORIG") = True Then
                File.Delete(T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_FullNew.ORIG")
            End If
            Me.BgwCreateFullT2Directory.ReportProgress(10, "Start creation of the T2 full directory!")
            QueryText = "SELECT  * FROM  [T2 DIRECTORY] where [TYPE_OF_CHANGE] not in ('D') and [VALID_TILL]>=DATEADD(d,DATEDIFF(d,0,getdate()),0) ORDER BY [BIC11] asc" 'where [RESERVE]='Manual input' ORDER BY [BIC11] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    'BgwCreateFullT2Directory.ReportProgress(i, "Create Datarow in T2 Directory for BIC: " & dt.Rows.Item(i).Item("BIC11") & " - " & dt.Rows.Item(i).Item("INSTITUTION_NAME"))
                    BIC11 = dt.Rows.Item(i).Item("BIC11")
                    ADDRESSEE = dt.Rows.Item(i).Item("ADDRESSEE")
                    ACCOUNT_HOLDER = dt.Rows.Item(i).Item("ACCOUNT_HOLDER")
                    BIC11_NAME = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("INSTITUTION_NAME"), 105)
                    CITY = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("CITY_HEADING"), 35)
                    SORTCODE = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("SORTCODE"), 15)
                    MAIN_BIC_FLAG = dt.Rows.Item(i).Item("MAIN_BIC_FLAG")
                    TYPE_OF_CHANGE = dt.Rows.Item(i).Item("TYPE_OF_CHANGE")
                    ValidFrom = dt.Rows.Item(i).Item("VALID_FROM")
                    ValidFromSql = ValidFrom.ToString("yyyyMMdd")
                    ValidTill = dt.Rows.Item(i).Item("VALID_TILL")
                    ValidTillSql = ValidTill.ToString("yyyyMMdd")
                    PARTICIPATION_TYPE = dt.Rows.Item(i).Item("PARTICIPATION_TYPE")

                    'CurrentRow.BeginInvoke(New ChangeText(AddressOf Change_CurrentRow))
                    'Me.BgwCreateFullT2Directory.ReportProgress(i, "Create Datarow in T2 Directory for BIC: " & CurrentRow.Text)

                    T2_ROW = BIC11 & ADDRESSEE & ACCOUNT_HOLDER & BIC11_NAME.PadRight(105) & CITY.PadRight(35) & SORTCODE.PadRight(15) & MAIN_BIC_FLAG & TYPE_OF_CHANGE & ValidFromSql & ValidTillSql & PARTICIPATION_TYPE & RESERVE

                    System.IO.File.AppendAllText(T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_FullNew.ORIG", T2_ROW & vbCrLf)
                    'System.Threading.Thread.Sleep(1000)
                Next i
                BgwCreateFullT2Directory.ReportProgress(10, "T2 Full Directory created!")
            End If

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Finally
            BgwCreateFullT2Directory.CancelAsync()
        End Try
    End Sub

    Private Sub BgwCreateFullT2Directory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwCreateFullT2Directory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwCreateFullT2Directory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwCreateFullT2Directory.RunWorkerCompleted
        If e.Cancelled = False Then
            If XtraMessageBox.Show("The following T2 Directory file has being created:" & vbNewLine & T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_FullNew.ORIG" & vbNewLine & "Should the directory be opened?", "NEW T2 DIRECTORY FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                System.Diagnostics.Process.Start(T2_DirectoryCreationFolder)
            End If
        End If
        Workers_Complete(BgwCreateFullT2Directory, e)
        ENABLE_BUTTONS()
        Me.LayoutControlGroup2.Visibility = LayoutVisibility.Never
    End Sub

    Private Sub bbi_T2_ManInput_Dir_Create_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_T2_ManInput_Dir_Create.ItemClick
        If XtraMessageBox.Show("Should the T2 Directory for Manual inputs be re-created?" & vbNewLine & vbNewLine & "Existing File:" & vbNewLine & T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_ManInp.ORIG" & vbNewLine & "will be deleted!", "T2 Directory (Manual Inputs) creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Select only manually inputed Data from T2 Directory")
                OpenSqlConnections()
                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='T2_Directory_Export_Folder' and  [IdABTEILUNGSPARAMETER]='T2_DIRECTORY_EXPORT' and [PARAMETER STATUS]='Y' "
                T2_DirectoryCreationFolder = cmd.ExecuteScalar
                CloseSqlConnections()
                If File.Exists(T2_DirectoryCreationFolder & "T2DIRFULLVA.ASCII_ManInp.ORIG") = True Then
                    File.Delete(T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_ManInp.ORIG")
                End If
                QueryText = "SELECT  * FROM  [T2 DIRECTORY] where [TYPE_OF_CHANGE] not in ('D') and  [RESERVE]='Manual input' ORDER BY [BIC11] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SplashScreenManager.Default.SetWaitFormCaption("Create Datarow in T2 Directory for BIC: " & dt.Rows.Item(i).Item("BIC11") & vbNewLine & dt.Rows.Item(i).Item("INSTITUTION_NAME"))
                    BIC11 = dt.Rows.Item(i).Item("BIC11")
                    ADDRESSEE = dt.Rows.Item(i).Item("ADDRESSEE")
                    ACCOUNT_HOLDER = dt.Rows.Item(i).Item("ACCOUNT_HOLDER")
                    BIC11_NAME = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("INSTITUTION_NAME"), 105)
                    CITY = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("CITY_HEADING"), 35)
                    SORTCODE = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("SORTCODE"), 15)
                    MAIN_BIC_FLAG = dt.Rows.Item(i).Item("MAIN_BIC_FLAG")
                    TYPE_OF_CHANGE = dt.Rows.Item(i).Item("TYPE_OF_CHANGE")
                    ValidFrom = dt.Rows.Item(i).Item("VALID_FROM")
                    ValidFromSql = ValidFrom.ToString("yyyyMMdd")
                    ValidTill = dt.Rows.Item(i).Item("VALID_TILL")
                    ValidTillSql = ValidTill.ToString("yyyyMMdd")
                    PARTICIPATION_TYPE = dt.Rows.Item(i).Item("PARTICIPATION_TYPE")

                    T2_ROW = BIC11 & ADDRESSEE & ACCOUNT_HOLDER & BIC11_NAME.PadRight(105) & CITY.PadRight(35) & SORTCODE.PadRight(15) & MAIN_BIC_FLAG & TYPE_OF_CHANGE & ValidFromSql & ValidTillSql & PARTICIPATION_TYPE & RESERVE

                    System.IO.File.AppendAllText(T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_ManInp.ORIG", T2_ROW & vbCrLf)
                Next

                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("The following T2 Directory file has being created: " & vbNewLine & T2_DirectoryCreationFolder & "\T2DIRFULLVA.ASCII_ManInp.ORIG", "NEW T2 DIRECTORY FILE", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Catch ex As System.Exception
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()

    End Sub

    Private Sub ParticipantBIC_ButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ParticipantBIC_ButtonEdit.ButtonClick
        Me.ParticipantName_lbl.Text = ""
        If Len(Me.ParticipantBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT [INSTITUTION NAME],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & Me.ParticipantBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.ParticipantName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & vbNewLine & dt.Rows.Item(0).Item("CITY HEADING")
                PARTICIPANT_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                CITY_HEADING = dt.Rows.Item(0).Item("CITY HEADING")
                BIC8 = Microsoft.VisualBasic.Left(Me.ParticipantBIC_ButtonEdit.Text, 8)
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.ParticipantBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub ParticipantBIC_ButtonEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ParticipantBIC_ButtonEdit.EditValueChanged
        Me.ParticipantName_lbl.Text = ""
        If Len(Me.ParticipantBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT [INSTITUTION NAME],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & Me.ParticipantBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.ParticipantName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & vbNewLine & dt.Rows.Item(0).Item("CITY HEADING")
                PARTICIPANT_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                CITY_HEADING = dt.Rows.Item(0).Item("CITY HEADING")
                BIC8 = Microsoft.VisualBasic.Left(Me.ParticipantBIC_ButtonEdit.Text, 8)
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.ParticipantBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub AddresseeBIC_ButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles AddresseeBIC_ButtonEdit.ButtonClick
        Me.AddresseeName_lbl.Text = ""
        If Len(Me.AddresseeBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT [INSTITUTION NAME],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & Me.AddresseeBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.AddresseeName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & vbNewLine & dt.Rows.Item(0).Item("CITY HEADING")
                ADDRESSEE_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                Me.AccountHolderBIC_ButtonEdit.Text = Me.AddresseeBIC_ButtonEdit.Text
                'Check if Addresse is Direct Participant
                cmd.CommandText = "SELECT [ID] as 'Count' from [T2 DIRECTORY] where [ADDRESSEE]='" & Me.AddresseeBIC_ButtonEdit.Text & "' and [RESERVE] not in ('Manual input')"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count = 0 Then
                    cmd.CommandText = "SELECT [Idnr] as 'Count' from [BIC DIRECTORY] where [BIC11]='" & Me.AddresseeBIC_ButtonEdit.Text & "' and [VALUE ADDED SERVICES] like '%TGT%'"
                    Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt2 As New DataTable
                    da2.Fill(dt2)
                    If dt2.Rows.Count = 0 Then
                        XtraMessageBox.Show("ADDRESSE BIC is not Direct T2 Participant" & vbNewLine & "Please enter ADDRESSE BIC which is Direct T2 Participant!!", "ADDRESSE BIC IS NOT DIRECT T2 PARTICIPANT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.AddresseeBIC_ButtonEdit.Text = ""
                    End If
                End If

            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.AddresseeBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub AddresseeBIC_ButtonEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AddresseeBIC_ButtonEdit.EditValueChanged
        Me.AddresseeName_lbl.Text = ""
        If Len(Me.AddresseeBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT [INSTITUTION NAME],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & Me.AddresseeBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.AddresseeName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & vbNewLine & dt.Rows.Item(0).Item("CITY HEADING")
                ADDRESSEE_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                Me.AccountHolderBIC_ButtonEdit.Text = Me.AddresseeBIC_ButtonEdit.Text
                'Check if Addresse is Direct Participant
                cmd.CommandText = "SELECT [ID] from [T2 DIRECTORY] where [ADDRESSEE]='" & Me.AddresseeBIC_ButtonEdit.Text & "' and [RESERVE] not in ('Manual input')"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count = 0 Then
                    cmd.CommandText = "SELECT [Idnr] as 'Count' from [BIC DIRECTORY] where [BIC11]='" & Me.AddresseeBIC_ButtonEdit.Text & "' and [VALUE ADDED SERVICES] like '%TGT%'"
                    Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt2 As New DataTable
                    da2.Fill(dt2)
                    If dt2.Rows.Count = 0 Then
                        XtraMessageBox.Show("ADDRESSE BIC is not Direct T2 Participant" & vbNewLine & "Please enter ADDRESSE BIC which is Direct T2 Participant!!", "ADDRESSE BIC IS NOT DIRECT T2 PARTICIPANT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.AddresseeBIC_ButtonEdit.Text = ""
                    End If
                End If

            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.AddresseeBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub AccountHolderBIC_ButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles AccountHolderBIC_ButtonEdit.ButtonClick
        Me.AccountholderName_lbl.Text = ""
        If Len(Me.AccountHolderBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT [INSTITUTION NAME],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & Me.AccountHolderBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.AccountholderName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & vbNewLine & dt.Rows.Item(0).Item("CITY HEADING")
                ACCOUNT_HOLDER_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.AccountHolderBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub AccountHolderBIC_ButtonEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AccountHolderBIC_ButtonEdit.EditValueChanged
        Me.AccountholderName_lbl.Text = ""
        If Len(Me.AccountHolderBIC_ButtonEdit.Text) = 11 Then

            cmd.CommandText = "SELECT [INSTITUTION NAME],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & Me.AccountHolderBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.AccountholderName_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & vbNewLine & dt.Rows.Item(0).Item("CITY HEADING")
                ACCOUNT_HOLDER_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Else
                XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.AccountHolderBIC_ButtonEdit.Text = ""
            End If

        End If
    End Sub

    Private Sub AddNewT2Participant_btn_Click(sender As Object, e As EventArgs) Handles AddNewT2Participant_btn.Click
        If Me.ParticipantName_lbl.Text <> Nothing AndAlso Me.AddresseeName_lbl.Text <> Nothing AndAlso Me.AccountholderName_lbl.Text <> Nothing Then
            cmd.CommandText = "SELECT [ID] FROM [T2 DIRECTORY] where [BIC11]='" & Me.ParticipantBIC_ButtonEdit.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                Try
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    Dim dtillSql As String = tilld.ToString("yyyyMMdd")
                    Me.Validate()
                    OpenSqlConnections()
                    cmd.CommandText = "INSERT INTO  [T2 DIRECTORY] ([BIC11],[INSTITUTION_NAME],[CITY_HEADING],[SORTCODE],[ADDRESSEE],[ADDRESSEE_NAME]
                                      ,[ACCOUNT_HOLDER],[ACCOUNT_HOLDER_NAME],[MAIN_BIC_FLAG],[TYPE_OF_CHANGE],[VALID_FROM],[VALID_TILL],[PARTICIPATION_TYPE]
                                      ,[PARTICIPATION_TYPE_NAME],[RESERVE])
                                       VALUES('" & Me.ParticipantBIC_ButtonEdit.Text & "','" & PARTICIPANT_NAME & "'+'          ','" & CITY_HEADING & "' + '     ','                         ','" & Me.AddresseeBIC_ButtonEdit.Text & "','" & ADDRESSEE_NAME & "','" & Me.AccountHolderBIC_ButtonEdit.Text & "','" & ACCOUNT_HOLDER_NAME & "','Y','A','" & dsql & "','" & dtillSql & "','05','addressable BIC - Correspondent (including CB Customer)','Manual input')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [T2 DIRECTORY] SET [INSTITUTION_NAME]=LTRIM([INSTITUTION_NAME]),[CITY_HEADING]=LTRIM([CITY_HEADING]),[ADDRESSEE_NAME]=LTRIM([ADDRESSEE_NAME]),[ACCOUNT_HOLDER_NAME]=LTRIM([ACCOUNT_HOLDER_NAME]) 
                                       where [BIC11]='" & Me.ParticipantBIC_ButtonEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Update [T2 DIRECTORY] set [PARTICIPATION_TYPE]='0' + [PARTICIPATION_TYPE] where LEN([PARTICIPATION_TYPE])=1"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    'Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)
                    XtraMessageBox.Show("The Participant has being added to the T2 Directory", "NEW T2 PARTICIPANT INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.ParticipantBIC_ButtonEdit.Text = ""
                    Me.AddresseeBIC_ButtonEdit.Text = ""
                    Me.AccountHolderBIC_ButtonEdit.Text = ""
                    Me.ParticipantName_lbl.Text = Nothing
                    Me.AddresseeName_lbl.Text = Nothing
                    Me.AccountholderName_lbl.Text = Nothing
                    Me.ParticipantBIC_ButtonEdit.Focus()

                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CloseSqlConnections()
                    Exit Sub
                End Try
            Else
                XtraMessageBox.Show("Participant BIC is allreday in the T2 Directory!!", "UNABLE TO INSERT PARTICIPANT TO THE T2 DIRECTORY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            XtraMessageBox.Show("Validation Failed!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.ParticipantBIC_ButtonEdit.Text = ""
        Me.AddresseeBIC_ButtonEdit.Text = ""
        Me.AccountHolderBIC_ButtonEdit.Text = ""
        Me.ParticipantName_lbl.Text = Nothing
        Me.AddresseeName_lbl.Text = Nothing
        Me.AccountholderName_lbl.Text = Nothing
        Me.DisplayListDetails_bbi.Visibility = BarItemVisibility.Always
        Me.LayoutControl1.Visible = True
    End Sub

    Private Sub T2DetailView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles T2DetailView.CellValueChanged

        If T2DetailView.FocusedColumn.FieldName = "BIC11" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT [INSTITUTION NAME],[BRANCH INFORMATION],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    T2DetailView.SetRowCellValue(e.RowHandle, "INSTITUTION_NAME", dt.Rows.Item(0).Item("INSTITUTION NAME"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "CITY_HEADING", dt.Rows.Item(0).Item("CITY HEADING"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "Manual input")
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    T2DetailView.SetRowCellValue(e.RowHandle, "INSTITUTION_NAME", "")
                    T2DetailView.SetRowCellValue(e.RowHandle, "CITY_HEADING", "")
                End If
            End If
        End If
        If T2DetailView.FocusedColumn.FieldName = "ADDRESSEE" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT [INSTITUTION NAME],[BRANCH INFORMATION],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE_NAME", dt.Rows.Item(0).Item("INSTITUTION NAME"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "TYPE_OF_CHANGE", "M")
                    T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "Manual input")
                    'Check if Addresse is Direct Participant
                    cmd.CommandText = "SELECT [ID] as 'Count' from [T2 DIRECTORY] where [ADDRESSEE]='" & BICCODE & "' and [RESERVE] not in ('Manual input')"
                    Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt1 As New DataTable
                    da1.Fill(dt1)
                    If dt1.Rows.Count = 0 Then
                        cmd.CommandText = "SELECT [Idnr] as 'Count' from [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' and [VALUE ADDED SERVICES] like '%TGT%'"
                        Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                        Dim dt2 As New DataTable
                        da2.Fill(dt2)
                        If dt2.Rows.Count = 0 Then
                            XtraMessageBox.Show("ADDRESSE BIC is not Direct T2 Participant" & vbNewLine & "Please enter ADDRESSE BIC which is Direct T2 Participant!!", "ADDRESSE BIC IS NOT DIRECT T2 PARTICIPANT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE", "")
                            T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE_NAME", "")
                            T2DetailView.SetRowCellValue(e.RowHandle, "TYPE_OF_CHANGE", "")
                            T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "")
                        End If

                    End If
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE_NAME", "")
                End If
            End If
        End If
        If T2DetailView.FocusedColumn.FieldName = "ACCOUNT_HOLDER" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT [INSTITUTION NAME],[BRANCH INFORMATION],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    T2DetailView.SetRowCellValue(e.RowHandle, "ACCOUNT_HOLDER_NAME", dt.Rows.Item(0).Item("INSTITUTION NAME"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "TYPE_OF_CHANGE", "M")
                    T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "Manual input")
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    T2DetailView.SetRowCellValue(e.RowHandle, "ACCOUNT_HOLDER_NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub T2DetailView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles T2DetailView.CellValueChanging

        If T2DetailView.FocusedColumn.FieldName = "BIC11" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT [INSTITUTION NAME],[BRANCH INFORMATION],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    T2DetailView.SetRowCellValue(e.RowHandle, "INSTITUTION_NAME", dt.Rows.Item(0).Item("INSTITUTION NAME"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "CITY_HEADING", dt.Rows.Item(0).Item("CITY HEADING"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "Manual input")
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    T2DetailView.SetRowCellValue(e.RowHandle, "INSTITUTION_NAME", "")
                    T2DetailView.SetRowCellValue(e.RowHandle, "CITY_HEADING", "")
                End If
            End If
        End If
        If T2DetailView.FocusedColumn.FieldName = "ADDRESSEE" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT [INSTITUTION NAME],[BRANCH INFORMATION],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE_NAME", dt.Rows.Item(0).Item("INSTITUTION NAME"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "TYPE_OF_CHANGE", "M")
                    T2DetailView.SetRowCellValue(e.RowHandle, "VALID_TILL", "31.12.9999")
                    T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "Manual input")
                    'Check if Addresse is Direct Participant
                    cmd.CommandText = "SELECT [ID] as 'Count' from [T2 DIRECTORY] where [ADDRESSEE]='" & BICCODE & "' and [RESERVE] not in ('Manual input')"
                    Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt1 As New DataTable
                    da1.Fill(dt1)
                    If dt1.Rows.Count = 0 Then
                        cmd.CommandText = "SELECT [Idnr] as 'Count' from [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' and [VALUE ADDED SERVICES] like '%TGT%'"
                        Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                        Dim dt2 As New DataTable
                        da2.Fill(dt2)
                        If dt2.Rows.Count = 0 Then
                            XtraMessageBox.Show("ADDRESSE BIC is not Direct T2 Participant" & vbNewLine & "Please enter ADDRESSE BIC which is Direct T2 Participant!!", "ADDRESSE BIC IS NOT DIRECT T2 PARTICIPANT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE", "")
                            T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE_NAME", "")
                            T2DetailView.SetRowCellValue(e.RowHandle, "TYPE_OF_CHANGE", "")
                            T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "")
                        End If
                    End If
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    T2DetailView.SetRowCellValue(e.RowHandle, "ADDRESSEE_NAME", "")
                End If
            End If
        End If
        If T2DetailView.FocusedColumn.FieldName = "ACCOUNT_HOLDER" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT [INSTITUTION NAME],[BRANCH INFORMATION],[CITY HEADING] FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    T2DetailView.SetRowCellValue(e.RowHandle, "ACCOUNT_HOLDER_NAME", dt.Rows.Item(0).Item("INSTITUTION NAME"))
                    T2DetailView.SetRowCellValue(e.RowHandle, "TYPE_OF_CHANGE", "M")
                    T2DetailView.SetRowCellValue(e.RowHandle, "VALID_TILL", "31.12.9999")
                    T2DetailView.SetRowCellValue(e.RowHandle, "RESERVE", "Manual input")
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    T2DetailView.SetRowCellValue(e.RowHandle, "ACCOUNT_HOLDER_NAME", "")
                End If
            End If
        End If
    End Sub

    Private Sub T2DetailView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles T2DetailView.FocusedRowChanged
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'Manual change only if Reserve=Manual input
        'Dim rowHandle As Integer = T2DetailView.FocusedRowHandle
        'Dim Reserve As String = T2DetailView.GetRowCellValue(rowHandle, "RESERVE").ToString
        'Dim Addresse As String = T2DetailView.GetRowCellValue(rowHandle, "ADDRESSEE").ToString
        'If Reserve = "Manual input" OrElse Addresse.StartsWith("TRGT") = True Then
        'Me.T2DetailView.Columns.ColumnByFieldName("ADDRESSEE").OptionsColumn.ReadOnly = False
        'Me.T2DetailView.Columns.ColumnByFieldName("ACCOUNT_HOLDER").OptionsColumn.ReadOnly = False
        'Else
        'Me.T2DetailView.Columns.ColumnByFieldName("ADDRESSEE").OptionsColumn.ReadOnly = True
        'Me.T2DetailView.Columns.ColumnByFieldName("ACCOUNT_HOLDER").OptionsColumn.ReadOnly = True
        'End If
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    End Sub

    Private Sub T2DetailView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles T2DetailView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

    End Sub

    Private Sub T2DetailView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles T2DetailView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub T2DetailView_MouseWheel(sender As Object, e As MouseEventArgs) Handles T2DetailView.MouseWheel
        TryCast(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
    End Sub

    Private Sub T2DetailView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles T2DetailView.ValidateRow
        Dim ParticipantBIC_Col As GridColumn = Me.T2DetailView.Columns("BIC11")
        Dim AddresseeBIC_Col As GridColumn = Me.T2DetailView.Columns("ADDRESSEE")
        Dim AddresseeBIC_NAME_Col As GridColumn = Me.T2DetailView.Columns("ADDRESSEE_NAME")
        Dim AccHolderBIC_Col As GridColumn = Me.T2DetailView.Columns("ACCOUNT_HOLDER")
        Dim AccHolderBIC_NAME_Col As GridColumn = Me.T2DetailView.Columns("ACCOUNT_HOLDER_NAME")
        Dim TypeOfChange_Col As GridColumn = Me.T2DetailView.Columns("TYPE_OF_CHANGE")
        Dim ValidFrom_Col As GridColumn = Me.T2DetailView.Columns("VALID_FROM")
        Dim ValidTill_Col As GridColumn = Me.T2DetailView.Columns("VALID_TILL")
        Dim Reserve_Col As GridColumn = Me.T2DetailView.Columns("RESERVE")

        ParticipantBIC11 = Me.T2DetailView.GetRowCellValue(e.RowHandle, colBIC111).ToString
        ParticipantBIC8 = Mid(Me.T2DetailView.GetRowCellValue(e.RowHandle, colBIC111).ToString, 1, 8)
        AddresseeBIC_Name_Value = Me.T2DetailView.GetRowCellValue(e.RowHandle, colADDRESSEE_NAME1).ToString
        AccountHolderBIC_Name_Value = Me.T2DetailView.GetRowCellValue(e.RowHandle, colACCOUNT_HOLDER_NAME1).ToString
        TypeOfChange = Me.T2DetailView.GetRowCellValue(e.RowHandle, colTYPE_OF_CHANGE1).ToString
        Participant_Reserve = Me.T2DetailView.GetRowCellValue(e.RowHandle, colRESERVE1).ToString

        AddresseeBIC_Value = Me.T2DetailView.GetRowCellValue(e.RowHandle, colADDRESSEE1).ToString
        If AddresseeBIC_Value = "" Then
            e.Valid = False
            Me.T2DetailView.SetColumnError(colADDRESSEE1, "Addressee BIC Field is Mandatory!")
        Else
            e.Valid = True
            Me.T2DetailView.SetColumnError(colADDRESSEE1, Nothing)
        End If

        AccountHolderBIC_Value = Me.T2DetailView.GetRowCellValue(e.RowHandle, colACCOUNT_HOLDER1).ToString
        If AccountHolderBIC_Value = "" Then
            e.Valid = False
            Me.T2DetailView.SetColumnError(colACCOUNT_HOLDER1, "Account Holder BIC Field is Mandatory!")
        Else
            e.Valid = True
            Me.T2DetailView.SetColumnError(colACCOUNT_HOLDER1, Nothing)
        End If


        If IsDate(Me.T2DetailView.GetRowCellValue(e.RowHandle, colVALID_FROM1)) = False Then
            e.Valid = False
            Me.T2DetailView.SetColumnError(colVALID_FROM1, "Valid From Field is Mandatory!")
        Else
            e.Valid = True
            Me.T2DetailView.SetColumnError(colVALID_FROM1, Nothing)
            Participant_ValidFrom = Me.T2DetailView.GetRowCellValue(e.RowHandle, colVALID_FROM1)
            Participant_ValidFrom_SQL = Participant_ValidFrom.ToString("yyyyMMdd")
        End If

        If IsDate(Me.T2DetailView.GetRowCellValue(e.RowHandle, colVALID_TILL1)) = False Then
            e.Valid = False
            Me.T2DetailView.SetColumnError(colVALID_TILL1, "Valid Till Field is Mandatory!")
        Else
            e.Valid = True
            Me.T2DetailView.SetColumnError(colVALID_TILL1, Nothing)
            Participant_ValidTill = Me.T2DetailView.GetRowCellValue(e.RowHandle, colVALID_TILL1)
            Participant_ValidTill_SQL = Participant_ValidTill.ToString("yyyyMMdd")
        End If

    End Sub

    Private Sub T2DetailView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles T2DetailView.ValidatingEditor

        If GridControl2.MainView Is T2DetailView Then
            'Set Validation to Columnseditors
            If Me.T2DetailView.FocusedColumn.FieldName = "BIC11" OrElse Me.T2DetailView.FocusedColumn.FieldName = "ADDRESSEE" OrElse Me.T2DetailView.FocusedColumn.FieldName = "ACCOUNT_HOLDER" Then
                If Len(e.Value) = 0 OrElse e.Value = Nothing Then
                    e.Valid = False
                    e.ErrorText = "BIC Field: " & Me.T2DetailView.FocusedColumn.Caption.ToString & " is Mandatory!" & vbNewLine & "Please input 11 Alphanummeric Digits!"
                    'T2DetailView.FocusedColumn = Me.T2DetailView.Columns(T2DetailView.FocusedColumn.FieldName.ToString)
                    Me.T2DetailView.ValidateEditor()

                End If
            End If
            If Me.T2DetailView.FocusedColumn.FieldName = "VALID_FROM" OrElse Me.T2DetailView.FocusedColumn.FieldName = "VALID_TILL" Then
                If IsDate(e.Value) = False Then
                    e.Valid = False
                    e.ErrorText = "Field: " & Me.T2DetailView.FocusedColumn.Caption.ToString & " is Mandatory!" & vbNewLine & "Please input a valid Date!"
                End If
            End If
        End If

        'Me.DxValidationProvider1.SetValidationRule(Me.T2DetailView.ActiveEditor, IsNotNullValidationRule)
        'e.Valid = Me.DxValidationProvider1.Validate

    End Sub



    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With {
            .PrintingSystemBase = New PrintingSystem(),
            .Component = component,
            .Landscape = True,
            .PaperKind = Printing.PaperKind.A4,
            .Margins = New Printing.Margins(20, 90, 20, 20)
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
        Dim reportfooter As String = "TARGET2 DIRECTORY" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub AddNewT2ParticipantAllBranches_btn_Click(sender As Object, e As EventArgs) Handles AddNewT2ParticipantAllBranches_btn.Click
        If Me.ParticipantName_lbl.Text <> Nothing AndAlso Me.AddresseeName_lbl.Text <> Nothing AndAlso Me.AccountholderName_lbl.Text <> Nothing Then
            cmd.CommandText = "SELECT [ID] FROM [T2 DIRECTORY] where [BIC11]='" & Me.ParticipantBIC_ButtonEdit.Text & "'"
            Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt1 As New DataTable
            da1.Fill(dt1)
            If dt1.Rows.Count = 0 Then
                If XtraMessageBox.Show("Should the BIC: " & BIC8 & " and all of his Branches be added to the T2 Directory?", "INSERT T2 PARTICIPANT and his BRANCHES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim dsql As String = d.ToString("yyyyMMdd")
                        Dim dtillSql As String = tilld.ToString("yyyyMMdd")
                        Me.Validate()
                        cmd.CommandText = "Select * from [BIC DIRECTORY] where [BIC CODE]='" & BIC8 & "' and [BIC11] not in (Select [BIC11] from [T2 DIRECTORY])"
                        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                        Dim dt As New DataTable
                        da.Fill(dt)
                        OpenSqlConnections()
                        If dt.Rows.Count > 0 Then
                            For i = 0 To dt.Rows.Count - 1
                                BIC11_BRANCH = dt.Rows.Item(i).Item("BIC11")
                                PARTICIPANT_NAME_BRANCH = dt.Rows.Item(i).Item("INSTITUTION NAME")
                                CITY_HEADING_BRANCH = dt.Rows.Item(i).Item("CITY HEADING")
                                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                                SplashScreenManager.Default.SetWaitFormCaption("Insert " & BIC11_BRANCH & vbNewLine & PARTICIPANT_NAME_BRANCH & "  " & CITY_HEADING_BRANCH & " in the T2 Directory")
                                cmd.CommandText = "INSERT INTO  [T2 DIRECTORY] ([BIC11],[INSTITUTION_NAME],[CITY_HEADING],[SORTCODE],[ADDRESSEE],[ADDRESSEE_NAME],[ACCOUNT_HOLDER],[ACCOUNT_HOLDER_NAME],[MAIN_BIC_FLAG],[TYPE_OF_CHANGE],[VALID_FROM],[VALID_TILL],[PARTICIPATION_TYPE],[PARTICIPATION_TYPE_NAME],[RESERVE])VALUES('" & BIC11_BRANCH & "','" & PARTICIPANT_NAME_BRANCH & "'+'          ','" & CITY_HEADING_BRANCH & "' + '     ','                         ','" & Me.AddresseeBIC_ButtonEdit.Text & "','" & ADDRESSEE_NAME & "','" & Me.AccountHolderBIC_ButtonEdit.Text & "','" & ACCOUNT_HOLDER_NAME & "','Y','A','" & dsql & "','" & dtillSql & "','05','addressable BIC - Correspondent (including CB Customer)','Manual input')"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [T2 DIRECTORY] SET [INSTITUTION_NAME]=LTRIM([INSTITUTION_NAME]),[CITY_HEADING]=LTRIM([CITY_HEADING]),[ADDRESSEE_NAME]=LTRIM([ADDRESSEE_NAME]),[ACCOUNT_HOLDER_NAME]=LTRIM([ACCOUNT_HOLDER_NAME]) where [BIC11]='" & BIC11_BRANCH & "'"
                                cmd.ExecuteNonQuery()
                            Next
                        End If
                        cmd.CommandText = "Update [T2 DIRECTORY] set [PARTICIPATION_TYPE]='0' + [PARTICIPATION_TYPE] where LEN([PARTICIPATION_TYPE])=1"
                        cmd.ExecuteNonQuery()
                        CloseSqlConnections()
                        SplashScreenManager.CloseForm(False)

                        'Me.SSISTableAdapter.Fill(Me.PSTOOLDataset.SSIS)
                        XtraMessageBox.Show("The Participant and all his Branches have being added to the T2 Directory", "NEW T2 PARTICIPANTS INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.ParticipantBIC_ButtonEdit.Text = ""
                        Me.AddresseeBIC_ButtonEdit.Text = ""
                        Me.AccountHolderBIC_ButtonEdit.Text = ""
                        Me.ParticipantName_lbl.Text = Nothing
                        Me.AddresseeName_lbl.Text = Nothing
                        Me.AccountholderName_lbl.Text = Nothing
                        Me.ParticipantBIC_ButtonEdit.Focus()



                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        CloseSqlConnections()
                        Exit Sub
                    End Try
                Else
                    Exit Sub

                End If
            Else
                XtraMessageBox.Show("Participant BIC is allreday in the T2 Directory!!", "UNABLE TO INSERT PARTICIPANT TO THE T2 DIRECTORY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show("Validation Failed!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub




End Class