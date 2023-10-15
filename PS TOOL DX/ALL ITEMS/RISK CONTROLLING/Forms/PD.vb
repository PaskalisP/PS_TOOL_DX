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
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Public Class PD

    Dim PrintGrid As Double = 0
    Dim rdYear As Integer = 0
    Private BS_All_RiskYears As BindingSource


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

    Private Sub PD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        'AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        ALL_RISK_YEARS_initData()
        ALL_RISK_YEARS_InitLookUp()

        If BS_All_RiskYears.Count > 0 Then
            Me.RiskYear_SearchLookUpEdit.EditValue = CType(BS_All_RiskYears.Current, DataRowView).Item(0).ToString
        End If

        Me.PDTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD)
        Me.PD_EXTERNALTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD_EXTERNAL)

        Me.TabbedControlGroup1.SelectedTabPageIndex = 0


    End Sub

    Private Sub ALL_RISK_YEARS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Declare @SELECTION_TABLE Table([ID] int IDENTITY(1,1) Not NULL, [RiskYear] int NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT [RiskYear] from PD_Downgrade_Propabilities
                                                    group by RiskYear order by RiskYear desc
                                                    SELECT RiskYear  from @SELECTION_TABLE 
                                                    order by RiskYear desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbRiskYear As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbRiskYear.Fill(ds, "RiskYear")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_RiskYears = New BindingSource(ds, "RiskYear")
    End Sub
    Private Sub ALL_RISK_YEARS_InitLookUp()
        Me.RiskYear_SearchLookUpEdit.Properties.DataSource = BS_All_RiskYears
        Me.RiskYear_SearchLookUpEdit.Properties.DisplayMember = "RiskYear"
        Me.RiskYear_SearchLookUpEdit.Properties.ValueMember = "RiskYear"
    End Sub

    Private Sub RiskYear_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles RiskYear_SearchLookUpEdit.EditValueChanged
        If Me.RiskYear_SearchLookUpEdit.Text <> "" AndAlso BS_All_RiskYears.Count > 0 Then
            rdYear = CInt(Me.RiskYear_SearchLookUpEdit.EditValue.ToString)
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load downgrade probabilities for year: " & rdYear)
            Me.PD_Downgrade_PropabilitiesTableAdapter.FillByRiskYear(Me.CreditMigrationRiskDataSet.PD_Downgrade_Propabilities, rdYear)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RiskYear_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RiskYear_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 2 Then
            Try
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Enter the new Year for the downgrade probabilities"
                args.Prompt = "Business Year"
                args.DefaultButtonIndex = 0
                AddHandler args.Showing, AddressOf Args_Showing
                ' initialize a DateEdit editor with custom settings
                Dim editor As New DateEdit()
                editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
                editor.Properties.Mask.MaskType = Mask.MaskType.RegEx
                editor.Properties.Mask.EditMask = "\d{4}"
                editor.Properties.DisplayFormat.FormatString = "yyyy"
                editor.Properties.EditFormat.FormatString = "yyyy"
                editor.Properties.CalendarView = Repository.CalendarView.Vista
                editor.Properties.VistaCalendarInitialViewStyle = VistaCalendarInitialViewStyle.YearsGroupView
                editor.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView
                editor.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
                editor.Properties.ShowClear = False
                editor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                editor.Properties.MinValue = DateSerial(2020, 1, 1)
                editor.Properties.MaxValue = DateSerial(9999, 12, 31)
                editor.Properties.NullDateCalendarValue = Today
                editor.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
                args.Editor = editor
                ' a default DateEdit value
                args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                ' display an Input Box with the custom editor

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                End If
                If IsDate(obj) = True Then
                    rdYear = CType(DatePart(DateInterval.Year, obj), Integer)
                    OpenSqlConnections()
                    cmd.CommandText = "Select Count(ID) from [PD_Downgrade_Propabilities] where RiskYear='" & rdYear & "' GROUP BY RiskYear"
                    If CInt(cmd.ExecuteScalar) = 0 Then
                        If XtraMessageBox.Show("Should the Business Year: " & rdYear & " be added into Table?", "ADD NEW BUSINESS YEAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            cmd.CommandText = "DECLARE @MIN_OBLIGOR_GRADE int=1
                                       DECLARE @MAX_OBLIGOR_GRADE int=(Select MAX(CONVERT(float,[Obligor Grade]))-1 from PD)

                                        INSERT INTO [PD_Downgrade_Propabilities]
                                                   ([DowngradeNotch]
                                                   ,[DowngradePropability]
                                                   ,[RiskYear]
                                                   ,[LastAction]
                                                   ,[LastUpdateUser]
                                                   ,[LastUpdateDate])
                                        SELECT 
                                        CAST([Obligor Grade] as int)
                                        ,0
                                        ,'" & rdYear & "'
                                        ,'ADD'
                                        ,'" & CurrentUserWindowsID & "'
                                        ,GETDATE()
                                        from PD
                                        where CAST([Obligor Grade] as int)<=@MAX_OBLIGOR_GRADE"
                            cmd.ExecuteNonQuery()
                            ALL_RISK_YEARS_initData()
                            ALL_RISK_YEARS_InitLookUp()

                            'Get all values from BindingSource
                            'For i As Integer = 0 To BS_All_ReportingDates.Count - 1
                            ' MsgBox(CType(BS_All_ReportingDates.List(i), DataRowView).Item(0).ToString)
                            'Next

                            Dim NewID As Integer = BS_All_RiskYears.Find("RiskYear", rdYear)
                            Me.RiskYear_SearchLookUpEdit.EditValue = CType(BS_All_RiskYears.List(NewID), DataRowView).Item(0).ToString
                            CloseSqlConnections()
                            XtraMessageBox.Show("Business Year: " & rdYear & " added successfull in the Downgrade probabilities Table", "NEW BUSINESS YEAR ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If


                    ElseIf CInt(cmd.ExecuteScalar) <> 0 Then
                        XtraMessageBox.Show("Business Year: " & rdYear & " already included in the Downgrade probabilities Table", "UNABLE TO ADD NEW BUSINESS YEAR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    CloseSqlConnections()
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        If e.Button.Tag = 4 Then
            Try
                rdYear = CInt(Me.RiskYear_SearchLookUpEdit.EditValue.ToString)
                Dim rdYearForDeletion As Integer = rdYear
                OpenSqlConnections()
                cmd.CommandText = "Select COUNT(A.Years) from (Select RiskYear as Years from [PD_Downgrade_Propabilities] GROUP BY RiskYear)A"
                If CInt(cmd.ExecuteScalar) > 1 Then
                    If XtraMessageBox.Show("Should the Business Year: " & rdYearForDeletion & " be deleted from the Table?", "DELETE BUSINESS YEAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        cmd.CommandText = "DECLARE @RISK_YEAR int=" & rdYearForDeletion & "
                                           DELETE FROM [PD_Downgrade_Propabilities] where [RiskYear]=@RISK_YEAR"
                        cmd.ExecuteNonQuery()
                        ALL_RISK_YEARS_initData()
                        ALL_RISK_YEARS_InitLookUp()
                        If BS_All_RiskYears.Count > 0 Then
                            Me.RiskYear_SearchLookUpEdit.EditValue = CType(BS_All_RiskYears.Current, DataRowView).Item(0).ToString
                        End If
                        CloseSqlConnections()
                        XtraMessageBox.Show("Business Year: " & rdYearForDeletion & " was deleted from the Downgrade probabilities Table", "BUSINESS YEAR DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                ElseIf CInt(cmd.ExecuteScalar) = 1 Then
                    XtraMessageBox.Show("Unable to delete Business Year: " & rdYearForDeletion & vbNewLine & "At least one Business Year must pe present for the Credit Migration Risk calculation!", "UNABLE TO DELETE BUSINESS YEAR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If
                CloseSqlConnections()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
        'e.Form.CancelButton.DialogResult = DialogResult.None
        e.Form.CloseBox = False
        If e.Form.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        If e.Form.DialogResult = DialogResult.OK Then
            Exit Sub
        End If
    End Sub

    Private Sub bbi_Reload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Reload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload Data")
        Me.PDTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD)
        Me.PD_EXTERNALTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD_EXTERNAL)
        ALL_RISK_YEARS_initData()
        ALL_RISK_YEARS_InitLookUp()
        If Me.RiskYear_SearchLookUpEdit.Text <> "" AndAlso BS_All_RiskYears.Count > 0 Then
            rdYear = CInt(Me.RiskYear_SearchLookUpEdit.EditValue.ToString)
            Me.PD_Downgrade_PropabilitiesTableAdapter.FillByRiskYear(Me.CreditMigrationRiskDataSet.PD_Downgrade_Propabilities, rdYear)
        End If
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.PDBindingSource.EndEdit()
                'If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                    Me.PDTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD)
                    'Update also in CUSTOMER RATINGS (not ,A.[ER_25]=B.[ER_25])
                    cmd.CommandText = "UPDATE A SET A.[CoreDefinition]=B.[CoreDefinition]
                                        ,A.[StandardPoorsRating]=B.[StandardPoorsRating]
                                        ,A.[MainlandBranchRating]=B.[MainlandBranchRating]
                                        ,A.[PD]=B.[PD]
                                        ,A.[ER_45]=B.[ER_45] 
                                        FROM [CUSTOMER_RATING] A INNER JOIN [PD] B 
                                        ON A.[Rating]=B.[Obligor Grade] 
                                        where [ActiveRatingCalculation]=1"
                    OpenSqlConnections()
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                Else
                    e.Handled = True
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
                Me.Validate()
                Me.PD_EXTERNALBindingSource.EndEdit()
                'If Me.RiskControllingBasicsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                    Me.PD_EXTERNALTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD_EXTERNAL)
                    'Update also in CUSTOMER RATINGS (not ,A.[ER_25]=B.[ER_25])
                    'cmd.CommandText = "UPDATE A SET A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MainlandBranchRating]=B.[MainlandBranchRating],A.[PD]=B.[PD],A.[ER_45]=B.[ER_45] FROM [CUSTOMER_RATING] A INNER JOIN [PD] B ON A.[Rating]=B.[Obligor Grade] where [ActiveRatingCalculation]=1"
                    'cmd.Connection.Open()
                    'cmd.ExecuteNonQuery()
                    'cmd.Connection.Close()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub bbi_PrintOrExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintOrExport.ItemClick
        If PrintGrid = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 1 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 2 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "Obligor Grades + Internal Ratings "
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
        Dim reportfooter As String = "External Ratings"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
        Dim reportfooter As String = "Downgrade probabilities for year: " & Me.RiskYear_SearchLookUpEdit.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPageIndex.ToString = "0" Then
            PrintGrid = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPageIndex.ToString = "1" Then
            PrintGrid = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPageIndex.ToString = "2" Then
            PrintGrid = 2
        End If
    End Sub

    Private Sub PDBaseView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles PDBaseView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub PDBaseView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles PDBaseView.RowUpdated

        Try
            Dim View As GridView = CType(sender, GridView)
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
            Me.Validate()
            Me.PDBindingSource.EndEdit()
            'If Me.RiskControllingBasicsDataSet.HasChanges = True Then
            If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                Me.PDTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD)
                'Update also in CUSTOMER RATINGS (not ,A.[ER_25]=B.[ER_25])
                cmd.CommandText = "UPDATE A SET A.[CoreDefinition]=B.[CoreDefinition]
                                        ,A.[StandardPoorsRating]=B.[StandardPoorsRating]
                                        ,A.[MainlandBranchRating]=B.[MainlandBranchRating]
                                        ,A.[PD]=B.[PD]
                                        ,A.[ER_45]=B.[ER_45] 
                                        FROM [CUSTOMER_RATING] A INNER JOIN [PD] B 
                                        ON A.[Rating]=B.[Obligor Grade] 
                                        where [ActiveRatingCalculation]=1"
                OpenSqlConnections()
                cmd.ExecuteNonQuery()
                CloseSqlConnections()
                PDBaseView.RefreshData()
            End If
            'End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub PD_External_BandedGridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles PD_External_BandedGridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub PD_External_BandedGridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles PD_External_BandedGridView.RowUpdated
        Try
            Dim View As GridView = CType(sender, GridView)
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
            Me.Validate()
            Me.PD_EXTERNALBindingSource.EndEdit()
            'If Me.RiskControllingBasicsDataSet.HasChanges = True Then
            If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)
                Me.PD_EXTERNALTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD_EXTERNAL)
                PD_External_BandedGridView.RefreshData()
                'Update also in CUSTOMER RATINGS (not ,A.[ER_25]=B.[ER_25])
                'cmd.CommandText = "UPDATE A SET A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MainlandBranchRating]=B.[MainlandBranchRating],A.[PD]=B.[PD],A.[ER_45]=B.[ER_45] FROM [CUSTOMER_RATING] A INNER JOIN [PD] B ON A.[Rating]=B.[Obligor Grade] where [ActiveRatingCalculation]=1"
                'cmd.Connection.Open()
                'cmd.ExecuteNonQuery()
                'cmd.Connection.Close()
            End If
            'End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub DowngradePropabilities_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles DowngradePropabilities_GridView.RowUpdated
        Try
            Dim View As GridView = CType(sender, GridView)
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
            View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
            Me.Validate()
            Me.PD_Downgrade_PropabilitiesBindingSource.EndEdit()
            If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager1.UpdateAll(Me.CreditMigrationRiskDataSet)
                rdYear = CInt(Me.RiskYear_SearchLookUpEdit.EditValue.ToString)
                Me.PD_Downgrade_PropabilitiesTableAdapter.FillByRiskYear(Me.CreditMigrationRiskDataSet.PD_Downgrade_Propabilities, rdYear)
                DowngradePropabilities_GridView.RefreshData()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub


End Class