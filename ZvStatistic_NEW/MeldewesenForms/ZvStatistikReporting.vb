Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraRichEdit.Services
Imports PDataTool.RichEditSyntaxSample
Imports DevExpress.XtraGrid.Views.Printing
Imports PS_TOOL_DX.RichEditSyntaxSample

Public Class ZvStatistikReporting

    Dim ID_1 As Integer = 0
    Dim ID_2 As Integer = 0
    Dim ID_3 As Integer = 0
    Dim ID_4 As Integer = 0

    Dim ParameterB_View As DevExpress.XtraGrid.Views.Grid.GridView
    Dim ParameterC_View As DevExpress.XtraGrid.Views.Grid.GridView
    Dim ParameterD_View As DevExpress.XtraGrid.Views.Grid.GridView

    Dim LEVEL_1 As String = Nothing
    Dim LEVEL_2 As String = Nothing
    Dim LEVEL_3 As String = Nothing

    Dim ParameterB_ViewCaption As String = Nothing
    Dim ParameterC_ViewCaption As String = Nothing
    Dim ParameterD_ViewCaption As String = Nothing

    Dim CurrentSQLCommandDescription As String = Nothing
    Dim CurrentZVSTA_Report As String = Nothing

    Dim ZVSTA_MELDESCHEMA_REP As String = Nothing
    Dim ZVSTA_MELDEJAHR_REP As String = Nothing
    Dim ZVSTA_MELDEPERIODE_REP As String = Nothing

    Dim ZVSTA_SCHEMA As String = Nothing
    Dim ZVSTA_REPORTING_PERIOD As String = Nothing
    Dim ZVSTA_SCHEMA_PERIOD As String = Nothing

    Dim ZVSTA_SCHEMA_XML As String = Nothing
    Dim ZVSTA_REPORTING_PERIOD_XML As String = Nothing
    Dim ZVSTA_SCHEMA_PERIOD_XML As String = Nothing

    Private BS_Meldeschemas As BindingSource
    Dim GetFocusedRow As Integer = 0
    Dim GetView As GridView = Nothing

    Friend WithEvents BgwZVSTA_Loading As BackgroundWorker
    Friend WithEvents BgwZVSTA_Processing As BackgroundWorker
    Friend WithEvents BgwZVSTA_Executing As BackgroundWorker
    Friend WithEvents BgwZVSTA_Finalizing As BackgroundWorker
    Friend WithEvents BgwZVSTA_FirstDataCards As BackgroundWorker
    Friend WithEvents BgwZVSTA_SumsCalculate As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Dim FormNr As String = Nothing
    Dim PositionNr As String = Nothing
    Dim Landkontext As String = Nothing
    Dim LandCode As String = Nothing
    Dim LandCode_T As String = Nothing
    Dim PayCardSystem As String = Nothing
    Dim SumPosition As String = Nothing
    Dim Anzahl_Value As Double = 0
    Dim Wert_Value As Double = 0



    Public Sub NotifyMe(ByVal s As String)
        MsgBox(s)
        Me.ReportStatus_BarStaticItem.Caption = s
    End Sub

    Private Sub FILL_ALL_DATA_CURRENT_REPORT()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
        Me.GridControl3.DataSource = Me.ZVSTAT_ReportingBindingSource
        Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
        ADDITIONAL_CHECKS()
        'ZVSTAT_ReportingALL_Gridview.BestFitColumns()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ZvStatistikReporting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '## crossed-thread parts will not be controlled by this option...
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False


        MELDESCHEMA_SELECTION_initData()
        MELDESCHEMA_SELECTION_InitLookUp()
        Me.ZVSTAT_ReportingTableAdapter.SetCommandTimeOut(60000)

        If BS_Meldeschemas.Count > 0 Then
            'Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = CType(BS_Meldeschemas.Current, DataRowView).Item(0)
        End If

        'Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CType(BS_Meldeschemas.Current, DataRowView).Item(0).ToString)

        'ZVSTAT_ReportingALL_Gridview.BestFitColumns()

        Me.PopupContainerEdit2.PopupFormMinSize = New Size(650, 500)


        'If EDP_USER = 1 Then
        'ZVSTAT_ReportingALL_Gridview.OptionsBehavior.Editable = False
        '    ZVSTAT_ReportingALL_Gridview.OptionsBehavior.Editable = False

        '    Me.BbiAddNewZvReport.Visibility = BarItemVisibility.Never
        '    Me.BbiDelete.Visibility = BarItemVisibility.Never
        'End If

        Me.BbiSqlReload.Visibility = BarItemVisibility.Never

    End Sub



    Private Sub MELDESCHEMA_SELECTION_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table
                                                ([ID] int IDENTITY(1,1) NOT NULL
												,[ZV_MELDUNG] nvarchar(50) NULL
                                                ,[ZV_MELDESCHEMA] nvarchar(50) NULL
                                                ,[ZV_REPORTING_PERIOD] nvarchar(100) NULL
												,[ZV_MELDESCHEMA_DESCRIPTION] nvarchar(100) NULL
												,[ZV_REPORTING_PERIOD_DESCRIPTION] nvarchar(100) NULL)
                                                INSERT INTO @SELECTION_TABLE
                                                SELECT [ZVSTA_Schema]+[ReportingPeriod],
														[ZVSTA_Schema],
                                                        [ReportingPeriod]
														,'ZV_MELDESCHEMA_DESCRIPTION'=Case when [ZVSTA_Schema] like '%Q' then 'QUARTERLY'
																					when [ZVSTA_Schema] like '%H' then 'HALFYEARLY'
																					else 'YEARLY' end
													,'ZV_REPORTING_PERIOD_DESCRIPTION'=RIGHT([ReportingPeriod],2)+'.'+LEFT([ReportingPeriod],4)
                                                    FROM   [ZVSTAT_Reporting] 
													GROUP BY [ZVSTA_Schema],[ReportingPeriod]
													ORDER BY [dbo].[fn_StripCharacters]([ReportingPeriod],'^0-9')*1 desc
                                                    UPDATE @SELECTION_TABLE SET ZV_REPORTING_PERIOD_DESCRIPTION=RIGHT(ZV_REPORTING_PERIOD_DESCRIPTION,4) 
                                                    where ZV_MELDESCHEMA_DESCRIPTION in ('YEARLY')
                                                    SELECT [ZV_MELDUNG] 
													,[ZV_MELDESCHEMA]
													,[ZV_REPORTING_PERIOD]
													,[ZV_MELDESCHEMA_DESCRIPTION]
													,[ZV_REPORTING_PERIOD_DESCRIPTION]
													,[ZV_MELDESCHEMA_DESCRIPTION]+' - '+[ZV_REPORTING_PERIOD_DESCRIPTION]
													 + Case when ZV_MELDESCHEMA_DESCRIPTION in ('HALFYEARLY') and RIGHT(ZV_REPORTING_PERIOD,2)='06' then ' - 1st Halfyear'
													              when ZV_MELDESCHEMA_DESCRIPTION in ('HALFYEARLY') and RIGHT(ZV_REPORTING_PERIOD,2)='12' then ' - 2nd Halfyear'
																  when ZV_MELDESCHEMA_DESCRIPTION in ('QUARTERLY') and RIGHT(ZV_REPORTING_PERIOD,2)='03' then ' - 1st Quarter'
																  when ZV_MELDESCHEMA_DESCRIPTION in ('QUARTERLY') and RIGHT(ZV_REPORTING_PERIOD,2)='06' then ' - 2nd Quarter'
																  when ZV_MELDESCHEMA_DESCRIPTION in ('QUARTERLY') and RIGHT(ZV_REPORTING_PERIOD,2)='09' then ' - 3rd Quarter'
																  when ZV_MELDESCHEMA_DESCRIPTION in ('QUARTERLY') and RIGHT(ZV_REPORTING_PERIOD,2)='12' then ' - 4th Quarter'
																  else '' end as 'ZV_SCHEMA_PERIOD'
													from @SELECTION_TABLE 
                                                    order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbMeldeschemas As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbMeldeschemas.Fill(ds, "ZV_MELDESCHEMAS")

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
        BS_Meldeschemas = New BindingSource(ds, "ZV_MELDESCHEMAS")
    End Sub
    Private Sub MELDESCHEMA_SELECTION_InitLookUp()
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.DataSource = BS_Meldeschemas
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.DisplayMember = "ZV_SCHEMA_PERIOD"
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ValueMember = "ZV_MELDUNG"

    End Sub

    Private Sub ADDITIONAL_CHECKS()
        OpenSqlConnections()
        cmd.CommandText = "IF (select COUNT(ID) from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]='" & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString & "' 
                                and ReportStatus in ('A'))>0
                            BEGIN
                            Select '+++ZVSTA REPORT NOT FINALIZED+++'
                            END
                            ELSE IF (select COUNT(ID) from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]='" & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString & "' 
                                and ReportStatus in ('F'))>0
                            BEGIN
                            Select '+++ZVSTA REPORT NOT VALIDATED+++'
                            END
                            ELSE IF (select COUNT(ID) from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]='" & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString & "' 
                                and ReportStatus in ('V'))>0
                            BEGIN
                            Select 'ZVSTA REPORT VALIDATED'
                            END"
        Me.ReportStatus_BarStaticItem.Caption = CStr(cmd.ExecuteScalar)
        CloseSqlConnections()

        'Modify Back Color
        If Me.ReportStatus_BarStaticItem.Caption.ToString.StartsWith("+") Then
            With Me.ReportStatus_BarStaticItem
                '.ItemAppearance.Normal.BackColor = Color.Gray
                .ItemAppearance.Normal.ForeColor = Color.Navy
            End With
        Else
            With Me.ReportStatus_BarStaticItem
                '.ItemAppearance.Normal.BackColor = Color.Green
                .ItemAppearance.Normal.ForeColor = Color.DarkGreen
            End With
        End If


    End Sub

    Private Sub ZvStatistikReporting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub BbiSqlReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSqlReload.ItemClick
        Try
            If BS_Meldeschemas.Count > 0 Then
                If IsNothing(Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString) = False Then
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
                    Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
                    ADDITIONAL_CHECKS()
                    'ZVSTAT_ReportingALL_Gridview.BestFitColumns()
                    SplashScreenManager.CloseForm(False)
                End If

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub



    Private Sub BbiSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSave.ItemClick

        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show(CType("Should the changes be saved ?", String), "SAVE CHANGES", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then

            If focusedView.Name = "ZVSTAT_ReportingALL_Gridview" Then
                Try
                    Me.Validate()
                    Me.ZVSTAT_ReportingBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.ZvStatistik_Dataset)
                    'Check if FormNr in ZVS5.2 and update Landcodes
                    OpenSqlConnections()
                    If FormNr = "ZVS5.2" Then
                        If LandCode = "W0" And LandCode_T <> "W0" Then
                            cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [Anzahl_Value]= " & Anzahl_Value & ",[Wert_Value]= " & Wert_Value & " 
                                               where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' 
                                               and [LandCode]='" & LandCode_T & "' and [LandCode_T]='" & LandCode & "'
                                               and [PositionNr]='" & PositionNr & "' and [PayCardSystem]='" & PayCardSystem & "' and [Landkontext]='" & Landkontext & "' and [SumPosition] in ('N')"
                            cmd.ExecuteNonQuery()
                        ElseIf LandCode <> "W0" And LandCode_T = "W0" Then
                            cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [Anzahl_Value]= " & Anzahl_Value & ",[Wert_Value]= " & Wert_Value & " 
                                               where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' 
                                               and [LandCode]='" & LandCode_T & "' and [LandCode_T]='" & LandCode & "'
                                               and [PositionNr]='" & PositionNr & "' and [PayCardSystem]='" & PayCardSystem & "' and [Landkontext]='" & Landkontext & "' and [SumPosition] in ('N')"
                            cmd.ExecuteNonQuery()
                        ElseIf LandCode <> "W0" And LandCode_T <> "W0" And LandCode <> LandCode_T Then
                            cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [Anzahl_Value]= " & Anzahl_Value & ",[Wert_Value]= " & Wert_Value & " 
                                               where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' 
                                               and [LandCode]='" & LandCode_T & "' and [LandCode_T]='" & LandCode & "'
                                               and [PositionNr]='" & PositionNr & "' and [PayCardSystem]='" & PayCardSystem & "' and [Landkontext]='" & Landkontext & "' and [SumPosition] in ('N')"
                            cmd.ExecuteNonQuery()
                        ElseIf LandCode <> "W0" And LandCode_T <> "W0" And LandCode = LandCode_T Then
                            cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [Anzahl_Value]= " & Anzahl_Value & ",[Wert_Value]= " & Wert_Value & " 
                                               where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' 
                                               and [LandCode]='W0' and [LandCode_T]='" & LandCode_T & "'
                                               and [PositionNr]='" & PositionNr & "' and [PayCardSystem]='" & PayCardSystem & "' and [Landkontext]='" & Landkontext & "' and [SumPosition] in ('N')"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [Anzahl_Value]= " & Anzahl_Value & ",[Wert_Value]= " & Wert_Value & " 
                                               where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' 
                                               and [LandCode]='" & LandCode & "' and [LandCode_T]='W0'
                                               and [PositionNr]='" & PositionNr & "' and [PayCardSystem]='" & PayCardSystem & "' and [Landkontext]='" & Landkontext & "' and [SumPosition] in ('N')"
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                    CloseSqlConnections()

                    FILL_ALL_DATA_CURRENT_REPORT()
                    focusedView.RefreshData()
                    focusedView.FocusedRowHandle = GetFocusedRow
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try


            End If
        Else

        End If

    End Sub

    Private Sub BbiAddNewZvReport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiAddNewZvReport.ItemClick

        Dim c As New ZvStatistic_NewReportingPeriod

        If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic - Add new Report", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            If IsDate(c.ZvMeldejahr_DateEdit.EditValue) = True _
                AndAlso c.ZvMeldeschemas_SearchLookUpEdit.EditValue.ToString <> Nothing _
                AndAlso c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString <> Nothing Then

                ZVSTA_MELDESCHEMA_REP = c.ZvMeldeschemas_SearchLookUpEdit.EditValue.ToString
                ZVSTA_MELDEJAHR_REP = CDate(c.ZvMeldejahr_DateEdit.EditValue.ToString).ToString("yyyy")
                ZVSTA_MELDEPERIODE_REP = "0" & Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1)

                'Halfyearly
                If ZVSTA_MELDESCHEMA_REP.EndsWith("H") AndAlso Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1) = "1" Then
                    ZVSTA_MELDEPERIODE_REP = "06"
                ElseIf ZVSTA_MELDESCHEMA_REP.EndsWith("H") AndAlso Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1) = "2" Then
                    ZVSTA_MELDEPERIODE_REP = "12"
                End If

                'Quarterly
                If ZVSTA_MELDESCHEMA_REP.EndsWith("Q") AndAlso Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1) = "1" Then
                    ZVSTA_MELDEPERIODE_REP = "03"
                ElseIf ZVSTA_MELDESCHEMA_REP.EndsWith("Q") AndAlso Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1) = "2" Then
                    ZVSTA_MELDEPERIODE_REP = "06"
                ElseIf ZVSTA_MELDESCHEMA_REP.EndsWith("Q") AndAlso Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1) = "3" Then
                    ZVSTA_MELDEPERIODE_REP = "09"
                ElseIf ZVSTA_MELDESCHEMA_REP.EndsWith("Q") AndAlso Microsoft.VisualBasic.Left(c.ZvMeldeperiod_ComboboxEdit.EditValue.ToString, 1) = "4" Then
                    ZVSTA_MELDEPERIODE_REP = "12"
                End If

                OpenSqlConnections()
                If ZVSTA_MELDESCHEMA_REP = "ZVSTA_2014" Then
                    cmd.CommandText = "Select COUNT(ID) from [ZVSTAT_Reporting] where [ZVSTA_Schema]='" & ZVSTA_MELDESCHEMA_REP & "' and [ReportingPeriod]='" & ZVSTA_MELDEJAHR_REP & "'"
                Else
                    cmd.CommandText = "Select COUNT(ID) from [ZVSTAT_Reporting] where [ZVSTA_Schema]='" & ZVSTA_MELDESCHEMA_REP & "' and [ReportingPeriod]='" & ZVSTA_MELDEJAHR_REP & ZVSTA_MELDEPERIODE_REP & "'"
                End If

                If CInt(cmd.ExecuteScalar) = 0 Then
                    Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = ""
                    If ZVSTA_MELDESCHEMA_REP.EndsWith("Q") Then
                        c.ZVSTA_QUARTERLY_CREATE(ZVSTA_MELDESCHEMA_REP, ZVSTA_MELDEJAHR_REP & ZVSTA_MELDEPERIODE_REP)
                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Dim NewID As Integer = BS_Meldeschemas.Find("ZV_MELDUNG", ZVSTA_MELDESCHEMA_REP & ZVSTA_MELDEJAHR_REP & ZVSTA_MELDEPERIODE_REP)
                        Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = CType(BS_Meldeschemas.List(NewID), DataRowView).Item(0)
                        'FILL_ALL_DATA_CURRENT_REPORT()
                        'BbiSqlReload.PerformClick()
                    ElseIf ZVSTA_MELDESCHEMA_REP.EndsWith("H") Then
                        c.ZVSTA_HALFYEARLY_CREATE(ZVSTA_MELDESCHEMA_REP, ZVSTA_MELDEJAHR_REP & ZVSTA_MELDEPERIODE_REP)
                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Dim NewID As Integer = BS_Meldeschemas.Find("ZV_MELDUNG", ZVSTA_MELDESCHEMA_REP & ZVSTA_MELDEJAHR_REP & ZVSTA_MELDEPERIODE_REP)
                        Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = CType(BS_Meldeschemas.List(NewID), DataRowView).Item(0)
                        'FILL_ALL_DATA_CURRENT_REPORT()
                        'BbiSqlReload.PerformClick()
                    Else
                        c.ZVSTA_2014_YEARLY_CREATE(ZVSTA_MELDESCHEMA_REP, ZVSTA_MELDEJAHR_REP)
                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Dim NewID As Integer = BS_Meldeschemas.Find("ZV_MELDUNG", ZVSTA_MELDESCHEMA_REP & ZVSTA_MELDEJAHR_REP)
                        Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = CType(BS_Meldeschemas.List(NewID), DataRowView).Item(0)
                        'FILL_ALL_DATA_CURRENT_REPORT()
                        'BbiSqlReload.PerformClick()
                    End If
                Else
                    XtraMessageBox.Show("The Meldeschema: " & ZVSTA_MELDESCHEMA_REP & " for Reporting Period: " & ZVSTA_MELDEJAHR_REP & ZVSTA_MELDEPERIODE_REP & " exists already!", "UNABLE TO ADD NEW ZVSTA REPORT", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If
                CloseSqlConnections()
            Else
                XtraMessageBox.Show("Please enter Reporting Period and/or Reporting Year for the new ZVSTA Report!", "UNABLE TO PROCEED - REPORTING PERIOD/YEAR IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        End If



    End Sub
    Private Sub BbiDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiDelete.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If BS_Meldeschemas.Count > 0 Then
                If XtraMessageBox.Show(CType("Should the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                         & " be deleted? ", String), "DELETE CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString & "'
                                   DELETE from [ZVSTAT_Reporting] where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema_ReportingPeriod"
                        cmd.ExecuteNonQuery()
                        CloseSqlConnections()
                        MELDESCHEMA_SELECTION_initData()
                        MELDESCHEMA_SELECTION_InitLookUp()
                        Me.GridControl3.DataSource = Nothing

                        'Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
                        'Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = CType(BS_Meldeschemas.Current, DataRowView).Item(0)
                        'FILL_ALL_DATA_CURRENT_SCHEMA()
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("The ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString & " is deleted!", "ZV STATISTIK REPORT DELETION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Catch ex As Exception
                        CloseSqlConnections()
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub Meldeschemas_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles MeldeschemasReportingPeriod_BarEditItem.EditValueChanged
        If BS_Meldeschemas.Count > 0 Then
            'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("Reload ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)

            Me.BbiSqlReload.Visibility = BarItemVisibility.Always
            Me.GridControl3.DataSource = Nothing
            BgwZVSTA_Loading = New BackgroundWorker
            bgws.Add(BgwZVSTA_Loading)
            BgwZVSTA_Loading.WorkerReportsProgress = True
            BgwZVSTA_Loading.RunWorkerAsync()

            Me.RibbonPageGroup2.Visible = False
            Me.RibbonPageGroup4.Visible = False
            Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Always
            Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Load ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

            'SplashScreenManager.CloseForm(False)
        End If


    End Sub

    Private Sub BgwZVSTA_Loading_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_Loading.DoWork
        Try
            Me.BgwZVSTA_Loading.ReportProgress(10, "Loading...Please wait...")
            Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_Loading.ReportProgress(10, "ERROR +++ " & ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwZVSTA_Loading_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_Loading.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwZVSTA_Loading_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_Loading.RunWorkerCompleted
        Workers_Complete(BgwZVSTA_Loading, e)
        bgws.Clear()

        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.GridControl3.DataSource = Me.ZVSTAT_ReportingBindingSource
        ADDITIONAL_CHECKS()

        CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString
        If CurrentZVSTA_Report.Contains("Q") Then
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCodeT_ALL").Visible = False
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCodeT_ALL").Visible = False
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colPayCardSystem_ALL").Visible = True

            Me.ZVSTAT_ReportingALL_Gridview.Columns("LfdNr").VisibleIndex = 0
            Me.ZVSTAT_ReportingALL_Gridview.Columns("FormNr").VisibleIndex = 1
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionNr").VisibleIndex = 2
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionName").VisibleIndex = 3
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Landkontext").VisibleIndex = 4
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCode_ALL").VisibleIndex = 5
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCode_ALL").VisibleIndex = 6
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colPayCardSystem_ALL").VisibleIndex = 7
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Anzahl_Value").VisibleIndex = 8
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Wert_Value").VisibleIndex = 9
            Me.ZVSTAT_ReportingALL_Gridview.Columns("SumPosition").VisibleIndex = 10
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionSQLcommand").VisibleIndex = 11
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionInfo").VisibleIndex = 12
        ElseIf CurrentZVSTA_Report.Contains("H") Then
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCodeT_ALL").Visible = True
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCodeT_ALL").Visible = True
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colPayCardSystem_ALL").Visible = True

            Me.ZVSTAT_ReportingALL_Gridview.Columns("LfdNr").VisibleIndex = 0
            Me.ZVSTAT_ReportingALL_Gridview.Columns("FormNr").VisibleIndex = 1
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionNr").VisibleIndex = 2
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionName").VisibleIndex = 3
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Landkontext").VisibleIndex = 4
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCode_ALL").VisibleIndex = 5
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCode_ALL").VisibleIndex = 6
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCodeT_ALL").VisibleIndex = 7
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCodeT_ALL").VisibleIndex = 8
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colPayCardSystem_ALL").VisibleIndex = 9
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Anzahl_Value").VisibleIndex = 10
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Wert_Value").VisibleIndex = 11
            Me.ZVSTAT_ReportingALL_Gridview.Columns("SumPosition").VisibleIndex = 12
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionSQLcommand").VisibleIndex = 13
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionInfo").VisibleIndex = 14
        Else
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCodeT_ALL").Visible = False
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCodeT_ALL").Visible = False
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colPayCardSystem_ALL").Visible = False

            Me.ZVSTAT_ReportingALL_Gridview.Columns("LfdNr").VisibleIndex = 0
            Me.ZVSTAT_ReportingALL_Gridview.Columns("FormNr").VisibleIndex = 1
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionNr").VisibleIndex = 2
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionName").VisibleIndex = 3
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Landkontext").VisibleIndex = 4
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colLandCode_ALL").VisibleIndex = 5
            Me.ZVSTAT_ReportingALL_Gridview.Columns("colSubdivisionOfCountryCode_ALL").VisibleIndex = 6
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Anzahl_Value").VisibleIndex = 7
            Me.ZVSTAT_ReportingALL_Gridview.Columns("Wert_Value").VisibleIndex = 8
            Me.ZVSTAT_ReportingALL_Gridview.Columns("SumPosition").VisibleIndex = 9
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionSQLcommand").VisibleIndex = 10
            Me.ZVSTAT_ReportingALL_Gridview.Columns("PositionInfo").VisibleIndex = 11
        End If

    End Sub

    Private Sub ZVSTA_Execute_ALL_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_Execute_ALL_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If XtraMessageBox.Show(CType("Should for the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                         & " all processing steps be executed? " & vbNewLine & vbNewLine & "ATTENTION: CURRENT REPORT WILL BE RECREATED" & vbNewLine & "ALL MANUAL MODIFICATIONS WILL BE LOST", String), "EXECUTE ALL PROCESSING STEPS FOR CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Warning, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                    BgwZVSTA_Processing = New BackgroundWorker
                    bgws.Add(BgwZVSTA_Processing)
                    BgwZVSTA_Processing.WorkerReportsProgress = True
                    BgwZVSTA_Processing.RunWorkerAsync()

                    Me.RibbonPageGroup2.Visible = False
                    Me.RibbonPageGroup4.Visible = False
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Always
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Executing all processing steps for ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString


                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If

    End Sub

    Private Sub BgwZVSTA_Processing_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_Processing.DoWork
        Try

            Me.BgwZVSTA_Processing.ReportProgress(10, "Execute ZVSTA Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            OpenSqlConnections()

            Me.BgwZVSTA_Processing.ReportProgress(10, "Get Meldeschema and Period from Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                ZVSTA_SCHEMA = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                ZVSTA_REPORTING_PERIOD = dt.Rows.Item(i).Item("ReportingPeriod").ToString
                If ZVSTA_SCHEMA.EndsWith("Q") Then
                    ZVSTA_SCHEMA_PERIOD = "QUARTERLY"
                ElseIf ZVSTA_SCHEMA.EndsWith("H") Then
                    ZVSTA_SCHEMA_PERIOD = "HALFYEARLY"
                Else
                    ZVSTA_SCHEMA_PERIOD = "YEARLY"
                End If
            Next
            dt.Clear()

            'DELETE CURRENT ZVSTA REPORTING
            Me.BgwZVSTA_Processing.ReportProgress(10, "Delete Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & CurrentZVSTA_Report & "'
                               DELETE from [ZVSTAT_Reporting] where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema_ReportingPeriod"
            cmd.ExecuteNonQuery()

            'DELETE CURRENT ZVSTA_PAYMENTS
            Me.BgwZVSTA_Processing.ReportProgress(10, "Delete Data from ZVSTA_Payments for: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & CurrentZVSTA_Report & "'
                               DELETE from [ZVSTA_Payments] where [ZVSTA_Schema]+[ZVSTA_Reporting_Period]=@ZVSTA_Schema_ReportingPeriod"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Processing.ReportProgress(10, "Insert Data to ZVSTA_Payments for: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & ZVSTA_REPORTING_PERIOD & "'
                                DECLARE @ZVSTA_Schema nvarchar(50) ='" & ZVSTA_SCHEMA & "'

                                DECLARE @ZVSTA_REPORTDATE_TILL Datetime=
                                (SELECT 'ZVSTA_REPORTDATE'=CASE 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='03' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),03,31))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),06,30)) 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='09' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),09,30))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),12,31))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),06,30))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),12,31))
                                END)
                                DECLARE @ZVSTA_REPORTDATE_FROM Datetime=
                                (SELECT 'ZVSTA_REPORTDATE'=CASE 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='03' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),01,01))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),04,01)) 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='09' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),07,01))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),10,01))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),01,01))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),07,01))
                                END)

                                INSERT INTO [dbo].[ZVSTA_Payments]
                                           ([RegisterDate]
                                           ,[MessageType]
                                           ,[InOutMessage]
                                           ,[TransactionType]
                                           ,[TransactionID]
                                           ,[DebitorsCountry]
                                           ,[CreditorsCountry]
                                           ,[CCY]
                                           ,[TransactionAmount]
                                           ,[ZVSTA_Schema]
                                           ,[ZVSTA_Reporting_Period])
                                    SELECT [RegisterDate]
                                          ,[MTTYPE]
                                          ,'TO'
                                          ,[TransactionType]
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
                                          ,[ReceivingBankCountryCode]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                      FROM [GMPS PAYMENTS OUT] where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                      and [MTTYPE] in ('103','103-DD-SEPA') and [OrderingCustomersAccountServicingInstitution] in ('PCBCDEFFXXX')
                                      and OrderingCustomer is not NULL
                                UNION ALL
                                    SELECT [RegisterDate]
                                          ,'103'
                                          ,'TO'
                                          ,'TransactionType'=Case when [TransactionType] in ('From History') then 'From Manual input' else [TransactionType] end
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
                                          ,[ReceivingBankCountryCode]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                      FROM [GMPS PAYMENTS OUT] where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                      and [MTTYPE] in ('2','3','31','32','34','35','43') and [OrderingCustomersAccountServicingInstitution] in ('PCBCDEFFXXX')
                                      and OrderingCustomer is not NULL and [OurReference]=[SenderReference]
                                UNION ALL
                                    SELECT [RegisterDate]
                                          ,'103'
                                          ,'TO'
                                          ,[TransactionType]
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
                                          ,[ReceivingBankCountryCode]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                      FROM [GMPS PAYMENTS OUT] where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                      and [MTTYPE] in ('2','3','31','32','34','35','43') and [OrderingCustomersAccountServicingInstitution] in ('PCBCDEFFXXX')
                                      and OrderingCustomer is not NULL and [TransactionType] in ('From Electronic Banking')
                                    
                        INSERT INTO [dbo].[ZVSTA_Payments]
                                           ([RegisterDate]
                                           ,[MessageType]
                                           ,[InOutMessage]
                                           ,[TransactionType]
                                           ,[TransactionID]
                                           ,[DebitorsCountry]
                                           ,[CreditorsCountry]
                                           ,[CCY]
                                           ,[TransactionAmount]
                                           ,[ZVSTA_Schema]
                                           ,[ZVSTA_Reporting_Period])
                                    SELECT [ValueDate]
	                                      ,[MTTYPE]
	                                      ,'FROM'
                                          ,'N'
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
	                                      ,[MsgBenefCountry]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                    FROM [GMPS PAYMENTS IN] where [ValueDate] BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                    and [MTTYPE] in ('103','103-CT-SEPA','103-DD-SEPA')


                                    UPDATE [ZVSTA_Payments] SET [PaymentType]=
                                    Case when [MessageType] in ('103') then '_Z' 
                                    when [MessageType] in ('103-DD-SEPA') then 'DDS_SEPAC' end where 
                                    [InOutMessage] in ('TO') and RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL

                                    UPDATE [ZVSTA_Payments] SET 
                                    [PaymentType]=Case when [MessageType] in ('103') then '_Z' 
                                    when [MessageType] in ('103-CT-SEPA') then 'CTS_SEPA'
                                    when [MessageType] in ('103-DD-SEPA') then 'DDS_SEPAC' end where 
                                    [InOutMessage] in ('FROM') and RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL

                                    UPDATE A SET A.[ExchangeRate]=B.[CURRENCY RATE] from ZVSTA_Payments A 
                                    INNER JOIN [EXCHANGE RATES ECB] B ON A.CCY=B.[CURRENCY CODE] and A.RegisterDate=B.[EXCHANGE RATE DATE]
                                    where A.RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL

                                    UPDATE ZVSTA_Payments SET TransactionAmountEUR=ROUND(TransactionAmount/ExchangeRate,2)
                                    where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL"
            cmd.ExecuteNonQuery()

            'DELETE CURRENT ZVSTA_ACCOUNTS
            'Me.BgwZVSTA_Processing.ReportProgress(10, "Delete Data from ZVSTA_Accounts for: " & CurrentZVSTA_Report)
            'System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & CurrentZVSTA_Report & "'
            '                   DELETE from [ZVSTA_ACCOUNTS] where [ZVSTA_Schema]+[ZVSTA_Reporting_Period]=@ZVSTA_Schema_ReportingPeriod"
            'cmd.ExecuteNonQuery()

            'CREATE NEW REPORTING
            Me.BgwZVSTA_Processing.ReportProgress(10, "Create new Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'Dim c As New ZvStatistic_NewReportingPeriod
            'Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = ""
            If ZVSTA_SCHEMA_PERIOD = "QUARTERLY" Then
                'c.ZVSTA_QUARTERLY_CREATE(ZVSTA_SCHEMA, ZVSTA_REPORTING_PERIOD)
                Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameter: ZV_STAT\ZVSTAT_QUARTERLY_REPORTING_SCHEME")
                System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                cmd.CommandText = "Select [Status] FROM SQL_PARAMETER_DETAILS where  [SQL_Name_1] In ('ZVSTAT_QUARTERLY_REPORTING_SCHEME') and [Id_SQL_Parameters] in ('ZV_STAT')"
                Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ZVSTAT_QUARTERLY_REPORTING_SCHEME')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_SCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_REPORTING_PERIOD)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                            Me.BgwZVSTA_Processing.ReportProgress(10, dt.Rows.Item(i).Item("SQL_Float_1").ToString & " - " & dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If
                MELDESCHEMA_SELECTION_initData()
                MELDESCHEMA_SELECTION_InitLookUp()
            ElseIf ZVSTA_SCHEMA_PERIOD = "HALFYEARLY" Then
                'c.ZVSTA_HALFYEARLY_CREATE(ZVSTA_SCHEMA, ZVSTA_REPORTING_PERIOD)
                Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameter: ZV_STAT\ZVSTAT_HALFYEARLY_REPORTING_SCHEME")
                System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                cmd.CommandText = "Select [Status] FROM SQL_PARAMETER_DETAILS where  [SQL_Name_1] In ('ZVSTAT_HALFYEARLY_REPORTING_SCHEME') and [Id_SQL_Parameters] in ('ZV_STAT')"
                Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ZVSTAT_HALFYEARLY_REPORTING_SCHEME')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_SCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_REPORTING_PERIOD)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                            Me.BgwZVSTA_Processing.ReportProgress(10, dt.Rows.Item(i).Item("SQL_Float_1").ToString & " - " & dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                End If
                MELDESCHEMA_SELECTION_initData()
                MELDESCHEMA_SELECTION_InitLookUp()
            ElseIf ZVSTA_SCHEMA_PERIOD = "YEARLY" Then
                'c.ZVSTA_2014_YEARLY_CREATE(ZVSTA_SCHEMA, ZVSTA_REPORTING_PERIOD)
                Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameter: ZV_STAT\ZVSTAT_2014_YEARLY_REPORTING_SCHEME")
                System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                cmd.CommandText = "Select [Status] FROM SQL_PARAMETER_DETAILS where  [SQL_Name_1] In ('ZVSTAT_2014_YEARLY_REPORTING_SCHEME') and [Id_SQL_Parameters] in ('ZV_STAT')"
                Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ZVSTAT_2014_YEARLY_REPORTING_SCHEME')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_SCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_REPORTING_PERIOD)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                            Me.BgwZVSTA_Processing.ReportProgress(10, dt.Rows.Item(i).Item("SQL_Float_1").ToString & " - " & dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                End If
                MELDESCHEMA_SELECTION_initData()
                MELDESCHEMA_SELECTION_InitLookUp()
            End If

            'Me.BgwZVSTA_Processing.ReportProgress(10, "Set Values to SQL Parameters in " & CurrentZVSTA_Report)
            'System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'QueryText = "Select * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            'da = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            '    Me.BgwZVSTA_Processing.ReportProgress(10, "Replace Parameters in SQL Commands for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
            '    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            '    Dim ID As String = dt.Rows.Item(i).Item("ID").ToString
            '    Dim SUM_POSITION As String = dt.Rows.Item(i).Item("SumPosition").ToString
            '    Dim COUNT_POSITION = dt.Rows.Item(i).Item("Anzahl").ToString
            '    Dim VALUE_POSITION = dt.Rows.Item(i).Item("Wert").ToString
            '    Dim PAYMENT_FLOW As String = dt.Rows.Item(i).Item("Landkontext").ToString
            '    Dim ZVSTA_POSITION As String = dt.Rows.Item(i).Item("PositionNr").ToString
            '    Dim ZVSTA_COUNTRY_CODE As String = dt.Rows.Item(i).Item("LandCode").ToString
            '    Dim ZVSTA_PAYMENT_CARD_SYSTEM As String = dt.Rows.Item(i).Item("PayCardSystem").ToString

            '    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString.Replace("<ID>", ID) _
            '                    .Replace("<ZVSTA_Schema>", ZVSTA_SCHEMA) _
            '                    .Replace("<ZVSTA_SchemaPeriod>", ZVSTA_SCHEMA_PERIOD) _
            '                    .Replace("<ZVSTA_ReportingPeriod>", ZVSTA_REPORTING_PERIOD) _
            '                    .Replace("<SumPosition>", SUM_POSITION) _
            '                    .Replace("<CountPosition>", COUNT_POSITION) _
            '                    .Replace("<ValuePosition>", VALUE_POSITION) _
            '                    .Replace("<PaymentFlow>", PAYMENT_FLOW) _
            '                    .Replace("<ZVSTA_Position>", ZVSTA_POSITION) _
            '                    .Replace("<ZVSTA_CountryCode>", ZVSTA_COUNTRY_CODE) _
            '                    .Replace("<ZVSTA_PaymentCardSystem>", ZVSTA_PAYMENT_CARD_SYSTEM)
            '    Me.BgwZVSTA_Processing.ReportProgress(10, "Updating Parameters in SQL Commands for ZVSTA Report: " & CurrentZVSTA_Report)
            '    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            '    cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [PositionSQLcommand]=@PositionSQLcommand where [ID]=" & CInt(ID) & ""
            '    cmd.Parameters.Add("@PositionSQLcommand", SqlDbType.NText).Value = SqlCommandText
            '    cmd.ExecuteNonQuery()
            '    cmd.Parameters.Clear()
            'Next
            'dt.Clear()

            Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (NO SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('N') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Commands in ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (NO SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('1') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Commands (First Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('2') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Commands (Intermediary Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY FINAL SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('3') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Commands (Final Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (Final Sum Positions) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            'CloseSqlConnections()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_Processing.ReportProgress(10, "ERROR +++ " & ex.Message & vbNewLine & CurrentSQLCommandDescription)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwZVSTA_Processing_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_Processing.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString

        'OpenSqlConnections()

        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTA_Processing','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@ErrorMessage,'ZVSTA_Processing','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
    End Sub

    Private Sub BgwZVSTA_Processing_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_Processing.RunWorkerCompleted
        CloseSqlConnections()
        CurrentSQLCommandDescription = Nothing
        Workers_Complete(BgwZVSTA_Processing, e)
        'Workers_Complete(BgwZVSTA_Loading, e)
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Never
        'Dim NewID As Integer = BS_Meldeschemas.Find("ZV_MELDUNG", ZVSTA_SCHEMA & ZVSTA_REPORTING_PERIOD)
        'Me.MeldeschemasReportingPeriod_BarEditItem.EditValue = CType(BS_Meldeschemas.List(NewID), DataRowView).Item(0)
        Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
        ADDITIONAL_CHECKS()
    End Sub

    Private Sub ZVSTA_Execute_Commands_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_Execute_Commands_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If XtraMessageBox.Show(CType("Should for the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                        & " the current SQL Parameters be executed? " & vbNewLine & vbNewLine & "ATTENTION: ALL MANUAL MODIFICATIONS WILL BE LOST", String), "EXECUTE CURRENT SQL PARAMETERS FOR CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Warning, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                    BgwZVSTA_Executing = New BackgroundWorker
                    bgws.Add(BgwZVSTA_Executing)
                    BgwZVSTA_Executing.WorkerReportsProgress = True
                    BgwZVSTA_Executing.RunWorkerAsync()

                    Me.RibbonPageGroup2.Visible = False
                    Me.RibbonPageGroup4.Visible = False
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Always
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Executing current SQL Parameters for ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If

    End Sub

    Private Sub BgwZVSTA_Executing_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_Executing.DoWork
        Try

            Me.BgwZVSTA_Executing.ReportProgress(10, "Execute ZVSTA Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            OpenSqlConnections()
            Me.BgwZVSTA_Executing.ReportProgress(10, "Set all Values to Zero in Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE ZVSTAT_Reporting SET Anzahl_Value=0,Wert_Value=0, LastAction=NULL,LastUpdateUser=NULL,LastUpdateDate=GETDATE(),ReportStatus='A' where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Executing.ReportProgress(10, "Get Meldeschema and Period from Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                ZVSTA_SCHEMA = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                ZVSTA_REPORTING_PERIOD = dt.Rows.Item(i).Item("ReportingPeriod").ToString
                If ZVSTA_SCHEMA.EndsWith("Q") Then
                    ZVSTA_SCHEMA_PERIOD = "QUARTERLY"
                ElseIf ZVSTA_SCHEMA.EndsWith("H") Then
                    ZVSTA_SCHEMA_PERIOD = "HALFYEARLY"
                Else
                    ZVSTA_SCHEMA_PERIOD = "YEARLY"
                End If
            Next
            dt.Clear()

            'DELETE CURRENT ZVSTA_PAYMENTS
            Me.BgwZVSTA_Executing.ReportProgress(10, "Delete Data from ZVSTA_Payments for: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & CurrentZVSTA_Report & "'
                               DELETE from [ZVSTA_Payments] where [ZVSTA_Schema]+[ZVSTA_Reporting_Period]=@ZVSTA_Schema_ReportingPeriod"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Executing.ReportProgress(10, "Insert Data to ZVSTA_Payments for: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & ZVSTA_REPORTING_PERIOD & "'
                                DECLARE @ZVSTA_Schema nvarchar(50) ='" & ZVSTA_SCHEMA & "'

                                DECLARE @ZVSTA_REPORTDATE_TILL Datetime=
                                (SELECT 'ZVSTA_REPORTDATE'=CASE 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='03' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),03,31))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),06,30)) 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='09' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),09,30))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),12,31))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),06,30))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),12,31))
                                END)
                                DECLARE @ZVSTA_REPORTDATE_FROM Datetime=
                                (SELECT 'ZVSTA_REPORTDATE'=CASE 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='03' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),01,01))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),04,01)) 
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='09' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),07,01))
                                WHEN @ZVSTA_Schema like '%Q' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),10,01))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='06' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),01,01))
                                WHEN @ZVSTA_Schema like '%H' and RIGHT(@ZVSTA_Schema_ReportingPeriod,2)='12' then (SELECT DATEFROMPARTS(Convert(int,LEFT(@ZVSTA_Schema_ReportingPeriod,4)),07,01))
                                END)

                                INSERT INTO [dbo].[ZVSTA_Payments]
                                           ([RegisterDate]
                                           ,[MessageType]
                                           ,[InOutMessage]
                                           ,[TransactionType]
                                           ,[TransactionID]
                                           ,[DebitorsCountry]
                                           ,[CreditorsCountry]
                                           ,[CCY]
                                           ,[TransactionAmount]
                                           ,[ZVSTA_Schema]
                                           ,[ZVSTA_Reporting_Period])
                                    SELECT [RegisterDate]
                                          ,[MTTYPE]
                                          ,'TO'
                                          ,[TransactionType]
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
                                          ,[ReceivingBankCountryCode]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                      FROM [GMPS PAYMENTS OUT] where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                      and [MTTYPE] in ('103','103-DD-SEPA') and [OrderingCustomersAccountServicingInstitution] in ('PCBCDEFFXXX')
                                      and OrderingCustomer is not NULL
                                UNION ALL
                                    SELECT [RegisterDate]
                                          ,'103'
                                          ,'TO'
                                          ,'TransactionType'=Case when [TransactionType] in ('From History') then 'From Manual input' else [TransactionType] end
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
                                          ,[ReceivingBankCountryCode]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                      FROM [GMPS PAYMENTS OUT] where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                      and [MTTYPE] in ('2','3','31','32','34','35','43') and [OrderingCustomersAccountServicingInstitution] in ('PCBCDEFFXXX')
                                      and OrderingCustomer is not NULL and [OurReference]=[SenderReference]
                                UNION ALL
                                    SELECT [RegisterDate]
                                          ,'103'
                                          ,'TO'
                                          ,[TransactionType]
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
                                          ,[ReceivingBankCountryCode]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                      FROM [GMPS PAYMENTS OUT] where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                      and [MTTYPE] in ('2','3','31','32','34','35','43') and [OrderingCustomersAccountServicingInstitution] in ('PCBCDEFFXXX')
                                      and OrderingCustomer is not NULL and [TransactionType] in ('From Electronic Banking')
                                    
                        INSERT INTO [dbo].[ZVSTA_Payments]
                                           ([RegisterDate]
                                           ,[MessageType]
                                           ,[InOutMessage]
                                           ,[TransactionType]
                                           ,[TransactionID]
                                           ,[DebitorsCountry]
                                           ,[CreditorsCountry]
                                           ,[CCY]
                                           ,[TransactionAmount]
                                           ,[ZVSTA_Schema]
                                           ,[ZVSTA_Reporting_Period])
                                    SELECT [ValueDate]
	                                      ,[MTTYPE]
	                                      ,'FROM'
                                          ,'N'
                                          ,[OurReference]
                                          ,[MsgSenderCountry]
	                                      ,[MsgBenefCountry]
                                          ,[Currency]
                                          ,[Amount]
                                          ,@ZVSTA_Schema
                                          ,@ZVSTA_Schema_ReportingPeriod
                                    FROM [GMPS PAYMENTS IN] where [ValueDate] BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL
                                    and [MTTYPE] in ('103','103-CT-SEPA','103-DD-SEPA')


                                    UPDATE [ZVSTA_Payments] SET [PaymentType]=
                                    Case when [MessageType] in ('103') then '_Z' 
                                    when [MessageType] in ('103-DD-SEPA') then 'DDS_SEPAC' end where 
                                    [InOutMessage] in ('TO') and RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL

                                    UPDATE [ZVSTA_Payments] SET 
                                    [PaymentType]=Case when [MessageType] in ('103') then '_Z' 
                                    when [MessageType] in ('103-CT-SEPA') then 'CTS_SEPA'
                                    when [MessageType] in ('103-DD-SEPA') then 'DDS_SEPAC' end where 
                                    [InOutMessage] in ('FROM') and RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL

                                    UPDATE A SET A.[ExchangeRate]=B.[CURRENCY RATE] from ZVSTA_Payments A 
                                    INNER JOIN [EXCHANGE RATES ECB] B ON A.CCY=B.[CURRENCY CODE] and A.RegisterDate=B.[EXCHANGE RATE DATE]
                                    where A.RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL

                                    UPDATE ZVSTA_Payments SET TransactionAmountEUR=ROUND(TransactionAmount/ExchangeRate,2)
                                    where RegisterDate BETWEEN @ZVSTA_REPORTDATE_FROM and @ZVSTA_REPORTDATE_TILL"
            cmd.ExecuteNonQuery()

            'DELETE CURRENT ZVSTA_ACCOUNTS
            'Me.BgwZVSTA_Processing.ReportProgress(10, "Delete Data from ZVSTA_Accounts for: " & CurrentZVSTA_Report)
            'System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'cmd.CommandText = "DECLARE @ZVSTA_Schema_ReportingPeriod nvarchar(50) ='" & CurrentZVSTA_Report & "'
            '                   DELETE from [ZVSTA_ACCOUNTS] where [ZVSTA_Schema]+[ZVSTA_Reporting_Period]=@ZVSTA_Schema_ReportingPeriod"
            'cmd.ExecuteNonQuery()

            'Me.BgwZVSTA_Executing.ReportProgress(10, "Set Values to SQL Parameters in " & CurrentZVSTA_Report)
            'System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            'QueryText = "Select * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            'da = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            '    Me.BgwZVSTA_Executing.ReportProgress(10, "Replace Parameters in SQL Commands for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
            '    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            '    Dim ID As String = dt.Rows.Item(i).Item("ID").ToString
            '    Dim SUM_POSITION As String = dt.Rows.Item(i).Item("SumPosition").ToString
            '    Dim COUNT_POSITION = dt.Rows.Item(i).Item("Anzahl").ToString
            '    Dim VALUE_POSITION = dt.Rows.Item(i).Item("Wert").ToString
            '    Dim PAYMENT_FLOW As String = dt.Rows.Item(i).Item("Landkontext").ToString
            '    Dim ZVSTA_POSITION As String = dt.Rows.Item(i).Item("PositionNr").ToString
            '    Dim ZVSTA_COUNTRY_CODE As String = dt.Rows.Item(i).Item("LandCode").ToString
            '    Dim ZVSTA_PAYMENT_CARD_SYSTEM As String = dt.Rows.Item(i).Item("PayCardSystem").ToString

            '    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString.Replace("<ID>", ID) _
            '                    .Replace("<ZVSTA_Schema>", ZVSTA_SCHEMA) _
            '                    .Replace("<ZVSTA_SchemaPeriod>", ZVSTA_SCHEMA_PERIOD) _
            '                    .Replace("<ZVSTA_ReportingPeriod>", ZVSTA_REPORTING_PERIOD) _
            '                    .Replace("<SumPosition>", SUM_POSITION) _
            '                    .Replace("<CountPosition>", COUNT_POSITION) _
            '                    .Replace("<ValuePosition>", VALUE_POSITION) _
            '                    .Replace("<PaymentFlow>", PAYMENT_FLOW) _
            '                    .Replace("<ZVSTA_Position>", ZVSTA_POSITION) _
            '                    .Replace("<ZVSTA_CountryCode>", ZVSTA_COUNTRY_CODE) _
            '                    .Replace("<ZVSTA_PaymentCardSystem>", ZVSTA_PAYMENT_CARD_SYSTEM)
            '    Me.BgwZVSTA_Executing.ReportProgress(10, "Updating Parameters in SQL Commands for ZVSTA Report: " & CurrentZVSTA_Report)
            '    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            '    cmd.CommandText = "UPDATE [ZVSTAT_Reporting] SET [PositionSQLcommand]=@PositionSQLcommand where [ID]=" & CInt(ID) & ""
            '    cmd.Parameters.Add("@PositionSQLcommand", SqlDbType.NText).Value = SqlCommandText
            '    cmd.ExecuteNonQuery()
            '    cmd.Parameters.Clear()
            'Next
            'dt.Clear()

            Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (NO SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('N') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Commands in ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (NO SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()


            Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('1') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Commands (First Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('2') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Commands (Intermediary Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (ONLY FINAL SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('3') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Commands (Final Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Executing.ReportProgress(10, "Execute SQL Parameters (Final Sum Positions) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            CloseSqlConnections()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_Executing.ReportProgress(10, "ERROR +++ " & ex.Message & vbNewLine & CurrentSQLCommandDescription)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwZVSTA_Executing_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_Executing.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString

        OpenSqlConnections()

        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTA_Executing','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@ErrorMessage,'ZVSTA_Executing','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
    End Sub

    Private Sub BgwZVSTA_Executing_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_Executing.RunWorkerCompleted
        CloseSqlConnections()
        CurrentSQLCommandDescription = Nothing
        Workers_Complete(BgwZVSTA_Executing, e)
        'Workers_Complete(BgwZVSTA_Loading, e)
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
        ADDITIONAL_CHECKS()
    End Sub

    Private Sub ZVSTA_Finalize_Commands_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_Finalize_Commands_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If XtraMessageBox.Show(CType("Should for the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                       & " be Finalized? " & vbNewLine & vbNewLine & "ATTENTION: ALL MANUAL MODIFICATIONS WILL BE INCLUDED IN THE FINAL REPORT", String), "FINALIZING CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Warning, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                    BgwZVSTA_Finalizing = New BackgroundWorker
                    bgws.Add(BgwZVSTA_Finalizing)
                    BgwZVSTA_Finalizing.WorkerReportsProgress = True
                    BgwZVSTA_Finalizing.RunWorkerAsync()

                    Me.RibbonPageGroup2.Visible = False
                    Me.RibbonPageGroup4.Visible = False
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Always
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Finalizing ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If

    End Sub

    Private Sub BgwZVSTA_Finalizing_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_Finalizing.DoWork
        Try

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Finalizing ZVSTA Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            OpenSqlConnections()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(Y)-LandCode_T(N) -Subdivision_T(N) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is not NULL and LandCode_T is NULL and SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.SubdivisionOfCountryCode and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(Y)-Subdivision_T(N) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is not NULL and SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.SubdivisionOfCountryCode and A.LandCode_T=B.LandCode_T and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(N)-Subdivision_T(Y) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is not NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.LandCode and A.LandCode_T=B.SubdivisionOfCountryCode_T and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(Y)-Subdivision_T(Y) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is not NULL and SubdivisionOfCountryCode_T is not NULL 
								  and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.SubdivisionOfCountryCode and A.LandCode_T=B.SubdivisionOfCountryCode_T and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Set all Sum Positions (except manual Modifications) to Zero in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE ZVSTAT_Reporting SET Anzahl_Value=0,Wert_Value=0 where [SumPosition] in ('1','2','3') and [LastAction] not in ('Modification') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('1') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Commands (First Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('2') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Commands (Intermediary Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Parameters (ONLY FINAL SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('3') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Commands (Final Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Finalizing.ReportProgress(10, "Execute SQL Parameters (Final Sum Positions) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            'GET ZVSTA_Schema and Reporting Period
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim CURRENT_ZVSTAT_SCHEMA As String = dt.Rows.Item(0).Item("ZVSTA_Schema").ToString
            Dim CURRENT_ZVSTAT_REPORTING_PERIOD As String = dt.Rows.Item(0).Item("ReportingPeriod").ToString
            dt.Clear()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Delete non relevant Positions in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "DELETE FROM ZVSTAT_Reporting where [Anzahl_Value]+[Wert_Value]=0 and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Check if there are data for " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                Me.BgwZVSTA_Finalizing.ReportProgress(10, "FEHLANZEIGE - No data for " & CurrentZVSTA_Report)
                cmd.CommandText = "INSERT INTO [ZVSTAT_Reporting] ([ZVSTA_Schema],LfdNr,[ReportingPeriod],[PositionName],Landkontext,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T,PayCardSystem) 
                                                            Values(@CURRENT_ZVSTAT_SCHEMA,1,@CURRENT_ZVSTAT_REPORTING_PERIOD,'FEHLANZEIGE','N','DE - INLÄNDISCH',NULL,NULL,NULL,'N')"
                cmd.Parameters.Add("@CURRENT_ZVSTAT_SCHEMA", SqlDbType.NVarChar).Value = CURRENT_ZVSTAT_SCHEMA
                cmd.Parameters.Add("@CURRENT_ZVSTAT_REPORTING_PERIOD", SqlDbType.NVarChar).Value = CURRENT_ZVSTAT_REPORTING_PERIOD
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            End If

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Set ReportStatus to F(FINALIZED) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE ZVSTAT_Reporting SET [ReportStatus]='F' where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_Finalizing.ReportProgress(10, "Set ReportStatus to V(VALIDATED) if PositionName:FEHLANZEIGE in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE ZVSTAT_Reporting SET [ReportStatus]='V' where [PositionName] in ('FEHLANZEIGE') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            'CloseSqlConnections()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_Finalizing.ReportProgress(10, "ERROR +++ " & ex.Message & vbNewLine & CurrentSQLCommandDescription)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwZVSTA_Finalizing_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_Finalizing.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString

        'OpenSqlConnections()

        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTA_Finalizing','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@ErrorMessage,'ZVSTA_Finalizing','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try

        'CloseSqlConnections()

    End Sub

    Private Sub BgwZVSTA_Finalizing_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_Finalizing.RunWorkerCompleted
        CloseSqlConnections()
        CurrentSQLCommandDescription = Nothing
        Workers_Complete(BgwZVSTA_Finalizing, e)
        'Workers_Complete(BgwZVSTA_Loading, e)
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
        ADDITIONAL_CHECKS()
    End Sub

    Private Sub ZVSTA_Validate_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_Validate_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If Me.ReportStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT FINALIZED") = True _
                OrElse Me.ReportStatus_BarStaticItem.Caption.ToString.Equals("+++ZVSTA REPORT NOT VALIDATED+++") = True _
                OrElse Me.ReportStatus_BarStaticItem.Caption.ToString.Equals("+++ZVSTA REPORT NOT FINALIZED+++") = True _
                OrElse Me.ReportStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT VALIDATED") = True Then

                Dim c As ZvStatistikReportingValidity = New ZvStatistikReportingValidity

                CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString
                QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    c.ZVSTA_Schema_BarEditItem.EditValue = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                    c.ZVSTA_ReportingPeriod_BarEditItem.EditValue = dt.Rows.Item(i).Item("ReportingPeriod").ToString
                Next
                c.Text = "ZVSTA Reporting Validation"
                c.ValidityStatus_BarStaticItem.Caption = "Validity Status: " & Me.ReportStatus_BarStaticItem.Caption
                c.ShowDialog(Me)
                FILL_ALL_DATA_CURRENT_REPORT()

            Else
                XtraMessageBox.Show("Unable to proceed with the ZVSTA Report Validation" & vbNewLine & "Current ZV Statistik report is not finalized!" & vbNewLine & "Please finalize the current ZV Statistik Report!", "UNABLE TO PROCEED - CURRENT REPORT NOT FINALIZED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        End If

    End Sub






    Private Sub BbiPrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiPrintExport.ItemClick
        If ZVSTAT_ReportingALL_Gridview.RowCount > 100000 Then
            If XtraMessageBox.Show(CType("Should the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                        & " be exported? ", String), "ATTENTION! OVER 100.000 ROWS!", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)

            End If
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
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
        Dim reportfooter As String = "ZV Statistik - Parameter"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClose.ItemClick
        Me.Close()

    End Sub

    Private Sub ZVSTAT_ReportingALL_Gridview_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ZVSTAT_ReportingALL_Gridview.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastAction"), "Added")
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateUser"), CurrentUserWindowsID)
        view.SetRowCellValue(e.RowHandle, view.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub ZVSTAT_ReportingALL_Gridview_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ZVSTAT_ReportingALL_Gridview.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("ReportStatus"), "A")
        'Get Positions
        FormNr = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("FormNr")))
        SumPosition = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("SumPosition")))
        If FormNr = "ZVS5.2" Then
            PositionNr = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("PositionNr")))
            Landkontext = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Landkontext")))
            LandCode = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("LandCode")))
            LandCode_T = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("LandCode_T")))
            PayCardSystem = CStr(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("PayCardSystem")))
            Anzahl_Value = CDbl(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Anzahl_Value")))
            Wert_Value = CDbl(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Wert_Value")))
        End If
        BbiSave.PerformClick()
    End Sub



    Private Sub ZVSTAT_ReportingALL_Gridview_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles ZVSTAT_ReportingALL_Gridview.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("PositionSQL") = True Then
                e.RepositoryItem = Me.PopupContainerEdit2
            End If
        End If

        'Dim CurrentMeldeschema As String = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString
        'If e.Column.FieldName = "LandCode" Then

        '    e.RepositoryItem = Me.LandCode2021_ImageComboBox

        'End If


    End Sub

    Private Sub PopupContainerEdit2_QueryPopUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit2.QueryPopUp
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        Dim editor As BaseEdit = DirectCast(sender, BaseEdit)
        RichEditControl1.Document.Text = editor.EditValue.ToString()


    End Sub

    Private Sub PopupContainerEdit2_QueryDisplayText(sender As Object, e As QueryDisplayTextEventArgs) Handles PopupContainerEdit2.QueryDisplayText
        'e.DisplayText = RichEditControl1.Document.Text
    End Sub

    Private Sub PopupContainerEdit2_QueryResultValue(sender As Object, e As QueryResultValueEventArgs) Handles PopupContainerEdit2.QueryResultValue
        e.Value = RichEditControl1.Document.Text
    End Sub

    Private Sub PopupContainerEdit2_QueryCloseUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit2.QueryCloseUp
        'Me.RichEditControl1.DataBindings.Clear()
        'BbiSave.PerformClick()

    End Sub

    Private Sub RichEditControl1_TextChanged(sender As Object, e As EventArgs) Handles RichEditControl1.TextChanged
        If Me.RichEditControl1.Text <> "" Then
            RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        End If
    End Sub

    Private Sub RichEditControl1_GotFocus(sender As Object, e As EventArgs) Handles RichEditControl1.GotFocus
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
    End Sub

    Private Sub ZVSTAT_ReportingALL_Gridview_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ZVSTAT_ReportingALL_Gridview.PrintInitialize
        Dim view As GridView = CType(sender, GridView)
        view.Columns("PositionSQLcommand").ColumnEdit = MemoEdit1
        view.OptionsView.RowAutoHeight = True
    End Sub


    Private Sub PrintableComponentLink1_AfterCreateAreas(sender As Object, e As EventArgs) Handles PrintableComponentLink1.AfterCreateAreas
        ZVSTAT_ReportingALL_Gridview.Columns("PositionSQLcommand").ColumnEdit = RepositoryItemMemoExEdit3
        ZVSTAT_ReportingALL_Gridview.OptionsView.RowAutoHeight = False

        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_1").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_2").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_3").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.Columns("SQL_Command_4").ColumnEdit = RepositoryItemMemoExEdit3
        'SQL_Parameter_Details_First_GridView.OptionsView.RowAutoHeight = False


    End Sub


    Private Sub ZVSTAT_ReportingALL_Gridview_PopupMenuShowing(sender As Object, e As Grid.PopupMenuShowingEventArgs) Handles ZVSTAT_ReportingALL_Gridview.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_EnablePreview As New DevExpress.Utils.Menu.DXMenuItem("ENABLE PREVIEW", New EventHandler(AddressOf MyMenuItem_EnablePreview_D), SharedImageCollection1.ImageSource.Images(5))
            Dim menuItem_DisablePreview As New DevExpress.Utils.Menu.DXMenuItem("DISABLE PREVIEW", New EventHandler(AddressOf MyMenuItem_DisablePreview_D), SharedImageCollection1.ImageSource.Images(6))

            menuItem_EnablePreview.Tag = e.Menu
            menuItem_EnablePreview.BeginGroup = True
            menuItem_DisablePreview.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_EnablePreview)
            ColumnMenu.Items.Add(menuItem_DisablePreview)
        End If

        'Dim view As GridView = TryCast(sender, GridView)
        'If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        '    If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
        '        e.Allow = False
        '        Me.SqlParameterGridviewPopupMenu.ShowPopup(GridControl3.PointToScreen(e.Point))
        '    End If
        'End If

    End Sub

    Private Sub MyMenuItem_EnablePreview_D(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ZVSTAT_ReportingALL_Gridview.OptionsView.ShowPreview = True
    End Sub

    Private Sub MyMenuItem_DisablePreview_D(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ZVSTAT_ReportingALL_Gridview.OptionsView.ShowPreview = False
    End Sub


    Private Sub ZVSTAT_Meldeschemas_Gridview_EditFormShowing(sender As Object, e As EditFormShowingEventArgs) Handles ZVSTAT_ReportingALL_Gridview.EditFormShowing
        'Dim view As GridView = TryCast(sender, GridView)
        'e.Allow = view.IsNewItemRow(e.RowHandle)
    End Sub




    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub

    Private Sub ZVSTAT_ReportingALL_Gridview_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ZVSTAT_ReportingALL_Gridview.EditFormPrepared
        Dim view As GridView = TryCast(sender, GridView)
        If e.BindableControls(view.FocusedColumn) IsNot Nothing Then
            e.FocusField(view.FocusedColumn)
        End If
        'MsgBox(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("SumPosition")).ToString & "  " & view.GetRowCellValue(view.FocusedRowHandle, view.Columns("FormNr")).ToString)
        If view.GetRowCellValue(view.FocusedRowHandle, view.Columns("SumPosition")).ToString <> "N" And view.GetRowCellValue(view.FocusedRowHandle, view.Columns("FormNr")).ToString Like "ZVS5.*" Then
            TryCast(e.BindableControls("Anzahl_Value"), BaseEdit).Properties.[ReadOnly] = False
            TryCast(e.BindableControls("Wert_Value"), BaseEdit).Properties.[ReadOnly] = False
            Exit Sub
        ElseIf view.GetRowCellValue(view.FocusedRowHandle, view.Columns("SumPosition")).ToString <> "N" And (view.GetRowCellValue(view.FocusedRowHandle, view.Columns("FormNr")).ToString <> "ZVS5.1" Or view.GetRowCellValue(view.FocusedRowHandle, view.Columns("FormNr")).ToString <> "ZVS5.2") Then
            TryCast(e.BindableControls("Anzahl_Value"), BaseEdit).Properties.[ReadOnly] = True
            TryCast(e.BindableControls("Wert_Value"), BaseEdit).Properties.[ReadOnly] = True
            Exit Sub
        Else
            TryCast(e.BindableControls("Anzahl_Value"), BaseEdit).Properties.[ReadOnly] = False
            TryCast(e.BindableControls("Wert_Value"), BaseEdit).Properties.[ReadOnly] = False
            Exit Sub
        End If
        If view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Anzahl")).ToString = "Y" Then
            TryCast(e.BindableControls("Anzahl_Value"), BaseEdit).Properties.[ReadOnly] = False
        ElseIf view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Anzahl")).ToString = "N" Then
            TryCast(e.BindableControls("Anzahl_Value"), BaseEdit).Properties.[ReadOnly] = True
        End If
        If view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Wert")).ToString = "Y" Then
            TryCast(e.BindableControls("Wert_Value"), BaseEdit).Properties.[ReadOnly] = False
        ElseIf view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Wert")).ToString = "N" Then
            TryCast(e.BindableControls("Wert_Value"), BaseEdit).Properties.[ReadOnly] = True
        End If

    End Sub

    Private Sub ZVSTA_XML_Create_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_XML_Create_btn.ItemClick

        If ZVSTAT_ReportingALL_Gridview.RowCount > 0 Then
            If Me.ReportStatus_BarStaticItem.Caption.ToString.Equals("ZVSTA REPORT VALIDATED") = True Then
                CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString
                QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    ZVSTA_SCHEMA_XML = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                    ZVSTA_REPORTING_PERIOD_XML = dt.Rows.Item(i).Item("ReportingPeriod").ToString
                    If ZVSTA_SCHEMA_XML.EndsWith("Q") Then
                        ZVSTA_SCHEMA_PERIOD_XML = "QUARTERLY"
                    ElseIf ZVSTA_SCHEMA_XML.EndsWith("H") Then
                        ZVSTA_SCHEMA_PERIOD_XML = "HALFYEARLY"
                    Else
                        ZVSTA_SCHEMA_PERIOD_XML = "YEARLY"
                    End If
                Next
                dt.Clear()

                If ZVSTA_SCHEMA_PERIOD_XML = "YEARLY" Then
                    Dim c As New ZvStatistic_XmlCreation2014
                    c.ZvMeldeschemas_SearchLookUpEdit.Text = ZVSTA_SCHEMA_XML
                    c.ZvMeldeperiod_ComboboxEdit.Text = ZVSTA_SCHEMA_PERIOD_XML
                    c.ZvMeldejahr_DateEdit.Text = ZVSTA_REPORTING_PERIOD_XML
                    If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic - Yearly - Create XML Reporting File", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                        c.ZVSTA_2014_XML_CREATE(ZVSTA_SCHEMA_XML, ZVSTA_REPORTING_PERIOD_XML)
                    End If
                ElseIf ZVSTA_SCHEMA_PERIOD_XML = "HALFYEARLY" Then
                    Dim c As New ZvStatistic_XmlCreation2022_H
                    c.ZvMeldeschemas_SearchLookUpEdit.Text = ZVSTA_SCHEMA_XML
                    c.ZvMeldeperiod_ComboboxEdit.Text = ZVSTA_SCHEMA_PERIOD_XML
                    c.ZvMeldejahr_DateEdit.Text = ZVSTA_REPORTING_PERIOD_XML
                    If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic -Halfyearly - Create XML Reporting File", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                        c.ZVSTA_2022_H_XML_CREATE(ZVSTA_SCHEMA_XML, ZVSTA_REPORTING_PERIOD_XML)
                    End If
                ElseIf ZVSTA_SCHEMA_PERIOD_XML = "QUARTERLY" Then
                    Dim c As New ZvStatistic_XmlCreation2022_Q
                    c.ZvMeldeschemas_SearchLookUpEdit.Text = ZVSTA_SCHEMA_XML
                    c.ZvMeldeperiod_ComboboxEdit.Text = ZVSTA_SCHEMA_PERIOD_XML
                    c.ZvMeldejahr_DateEdit.Text = ZVSTA_REPORTING_PERIOD_XML
                    If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic - Quarterly - Create XML Reporting File", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                        c.ZVSTA_2022_H_XML_CREATE(ZVSTA_SCHEMA_XML, ZVSTA_REPORTING_PERIOD_XML)
                    End If
                End If
            Else
                XtraMessageBox.Show("Unable to proceed with the XML File creation" & vbNewLine & "Current ZV Statistik report is not validated!" & vbNewLine & "Please validate the current ZV Statistik Report!", "UNABLE TO PROCEED - CURRENT REPORT NOT VALIDATED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        End If

    End Sub

    Private Sub ZVSTA_FirstDataCards_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_FirstDataCards_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If XtraMessageBox.Show(CType("Should the cards from FIRST DATA for the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                        & " be added? " & vbNewLine & vbNewLine & "ATTENTION: THE REPORT STATUS WILL BE SET TO: NOT FINALIZED", String), "ADD CARDS FROM FIRST DATA IN CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Warning, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString
                    QueryText = "Select TOP 1 * from [ZVSTA_PayCards_Data] where ZVSTA_Schema+ReportingPeriod='" & CurrentZVSTA_Report & "'"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        BgwZVSTA_FirstDataCards = New BackgroundWorker
                        bgws.Add(BgwZVSTA_FirstDataCards)
                        BgwZVSTA_FirstDataCards.WorkerReportsProgress = True
                        BgwZVSTA_FirstDataCards.RunWorkerAsync()

                        Me.RibbonPageGroup2.Visible = False
                        Me.RibbonPageGroup4.Visible = False
                        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Always
                        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Add cards from FIRST DATA to ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString
                    Else
                        XtraMessageBox.Show("There are no data from FIRST DATA for " & CurrentZVSTA_Report, "NO CARDS DATA ADDED TO THE ZV STATISTIK REPORT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub BgwZVSTA_FirstDataCards_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_FirstDataCards.DoWork
        Try

            Me.BgwZVSTA_FirstDataCards.ReportProgress(10, "Get Meldeschema and Period from Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                ZVSTA_SCHEMA = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                ZVSTA_REPORTING_PERIOD = dt.Rows.Item(i).Item("ReportingPeriod").ToString
                If ZVSTA_SCHEMA.EndsWith("Q") Then
                    ZVSTA_SCHEMA_PERIOD = "QUARTERLY"
                ElseIf ZVSTA_SCHEMA.EndsWith("H") Then
                    ZVSTA_SCHEMA_PERIOD = "HALFYEARLY"
                Else
                    ZVSTA_SCHEMA_PERIOD = "YEARLY"
                End If
            Next
            dt.Clear()

            If ZVSTA_SCHEMA_PERIOD = "QUARTERLY" Then
                Me.BgwZVSTA_FirstDataCards.ReportProgress(10, "Execute SQL Parameter: ZV_STAT\ZVSTAT_2022_QUARTERLY_FIRST_DATA_ADD")
                System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                cmd.CommandText = "Select [Status] FROM [SQL_PARAMETER_B] where  [SQL_Name_1] In ('ZVSTAT_2022_QUARTERLY_FIRST_DATA_ADD') and [Id_SQL_Parameters] in (SELECT [ID] FROM [SQL_PARAMETER_A] where [SQL_Parameter_Name] in ('ZV_STAT'))"
                Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_C]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_B] where SQL_Name_1 in ('ZVSTAT_2022_QUARTERLY_FIRST_DATA_ADD')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_SCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_REPORTING_PERIOD)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                            Me.BgwZVSTA_FirstDataCards.ReportProgress(10, dt.Rows.Item(i).Item("SQL_Float_1").ToString & " - " & dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If
            ElseIf ZVSTA_SCHEMA_PERIOD = "HALFYEARLY" Then
                Me.BgwZVSTA_FirstDataCards.ReportProgress(10, "Execute SQL Parameter: ZV_STAT\ZVSTAT_2022_HALFYEARLY_FIRST_DATA_ADD")
                System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                cmd.CommandText = "Select [Status] FROM [SQL_PARAMETER_B] where  [SQL_Name_1] In ('ZVSTAT_2022_HALFYEARLY_FIRST_DATA_ADD') and [Id_SQL_Parameters] in (SELECT [ID] FROM [SQL_PARAMETER_A] where [SQL_Parameter_Name] in ('ZV_STAT'))"
                Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_C]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_B] where SQL_Name_1 in ('ZVSTAT_2022_HALFYEARLY_FIRST_DATA_ADD')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_SCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_REPORTING_PERIOD)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                            Me.BgwZVSTA_FirstDataCards.ReportProgress(10, dt.Rows.Item(i).Item("SQL_Float_1").ToString & " - " & dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If
            End If




        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_FirstDataCards.ReportProgress(10, "ERROR +++ " & ex.Message & vbNewLine & CurrentSQLCommandDescription)
            e.Cancel = True
        End Try

    End Sub

    Private Sub BgwZVSTA_FirstDataCards_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_FirstDataCards.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString

        OpenSqlConnections()

        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_2022_QUARTERLY_FIRST_DATA_ADD','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@ErrorMessage,'ZVSTAT_2022_QUARTERLY_FIRST_DATA_ADD','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
    End Sub

    Private Sub BgwZVSTA_FirstDataCards_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_FirstDataCards.RunWorkerCompleted
        CloseSqlConnections()
        CurrentSQLCommandDescription = Nothing
        Workers_Complete(BgwZVSTA_FirstDataCards, e)
        'Workers_Complete(BgwZVSTA_Loading, e)
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
        ADDITIONAL_CHECKS()
    End Sub

    Private Sub ZVSTA_FraudelentPayments_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_FraudelentPayments_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            Dim c As New ZvStatistic_NewFraudelentPayment
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                c.ZvMeldeschema_TextEdit.EditValue = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                c.ZvMeldeperiode_TextEdit.EditValue = dt.Rows.Item(i).Item("ReportingPeriod").ToString
            Next
            dt.Clear()

            If CurrentZVSTA_Report.Contains("H") Then
                If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic - Add new Fraudelent Payment Transactions (NO CARDS)", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    If c.ZvMeldeposition_SearchLookUpEdit.EditValue.ToString <> "" AndAlso c.ZvCountry_SearchLookUpEdit.EditValue.ToString <> "" Then
                        Dim ZV_MELDEPOSITION As String = c.ZvMeldeposition_SearchLookUpEdit.EditValue.ToString
                        Dim ZV_COUNTRY As String = c.ZvCountry_SearchLookUpEdit.EditValue.ToString
                        Dim ZV_MELDESCHEMA As String = c.ZvMeldeschema_TextEdit.EditValue.ToString
                        Dim ZV_MELDEPERIODE As String = c.ZvMeldeperiode_TextEdit.EditValue.ToString
                        QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
                                    and [FormNr] in ('ZVS5.1') and [PositionNr]='" & ZV_MELDEPOSITION & "' and [LandCode]='" & ZV_COUNTRY & "'"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count = 0 Then
                            OpenSqlConnections()
                            c.ZVSTA_ADD_FRAUDELENT_PAYMENTS(ZV_MELDEPOSITION, ZV_COUNTRY, ZV_MELDESCHEMA, ZV_MELDEPERIODE)
                            CloseSqlConnections()

                            Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
                            ADDITIONAL_CHECKS()
                        ElseIf dt.Rows.Count > 0 Then
                            XtraMessageBox.Show("The PositionNr and the Country are allready added in the Report" & vbNewLine & "Please modify them in the Report!", "UNABLE TO ADD FRAUDELENT TRANSACTIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub

                        End If
                    Else
                        XtraMessageBox.Show("The PositionNr and the Country should be selected", "UNABLE TO ADD FRAUDELENT TRANSACTIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Else
                XtraMessageBox.Show("The current ZVSTA reporting Schema does not accept the reporting of Fraudelent Transactions", "UNABLE TO ADD FRAUDELENT TRANSACTIONS TO THIS ZVSTA SCHEMA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If

    End Sub

    Private Sub ZVSTA_FraudelentCards_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_FraudelentCards_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            Dim c As New ZvStatistic_NewFraudelentCard
            QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                c.ZvMeldeschema_TextEdit.EditValue = dt.Rows.Item(i).Item("ZVSTA_Schema").ToString
                c.ZvMeldeperiode_TextEdit.EditValue = dt.Rows.Item(i).Item("ReportingPeriod").ToString
            Next
            dt.Clear()

            If CurrentZVSTA_Report.Contains("H") Then
                If DevExpress.XtraEditors.XtraDialog.Show(c, "ZV Statistic - Add new Fraudelent card Transactions (ONLY CARDS)", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    If c.ZvMeldeposition_SearchLookUpEdit.EditValue.ToString <> "" AndAlso c.AcquirerZvCountry_SearchLookUpEdit.EditValue.ToString <> "" AndAlso c.ReceiverZvCountry_SearchLookUpEdit1.EditValue.ToString <> "" AndAlso c.Landkontext_ComboBoxEdit.Text.ToString <> "" Then
                        Dim ZV_MELDEPOSITION As String = c.ZvMeldeposition_SearchLookUpEdit.EditValue.ToString
                        Dim ZV_COUNTRY_A As String = c.AcquirerZvCountry_SearchLookUpEdit.EditValue.ToString
                        Dim ZV_COUNTRY_B As String = c.ReceiverZvCountry_SearchLookUpEdit1.EditValue.ToString
                        Dim ZV_LANDKONTEXT As String = c.Landkontext_ComboBoxEdit.EditValue.ToString
                        Dim ZV_MELDESCHEMA As String = c.ZvMeldeschema_TextEdit.EditValue.ToString
                        Dim ZV_MELDEPERIODE As String = c.ZvMeldeperiode_TextEdit.EditValue.ToString
                        'MsgBox(ZV_MELDEPOSITION & vbNewLine & ZV_COUNTRY_A & vbNewLine & ZV_COUNTRY_B & vbNewLine & ZV_LANDKONTEXT & vbNewLine & CurrentZVSTA_Report)
                        QueryText = "Select top 1 * from [ZVSTAT_Reporting]  where [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
                                    and [FormNr] in ('ZVS5.2') and [PositionNr]='" & ZV_MELDEPOSITION & "' and [LandCode]='" & ZV_COUNTRY_A & "' 
                                    and [LandCode_T]='" & ZV_COUNTRY_B & "' and [Landkontext]='" & ZV_LANDKONTEXT & "'"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count = 0 Then
                            OpenSqlConnections()
                            c.ZVSTA_ADD_FRAUDELENT_CARDS(ZV_MELDEPOSITION, ZV_COUNTRY_A, ZV_COUNTRY_B, ZV_LANDKONTEXT, ZV_MELDESCHEMA, ZV_MELDEPERIODE)
                            CloseSqlConnections()

                            Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
                            ADDITIONAL_CHECKS()
                        ElseIf dt.Rows.Count > 0 Then
                            XtraMessageBox.Show("The PositionNr, Landkontext and the Countries are allready added in the Report" & vbNewLine & "Please modify them in the Report!", "UNABLE TO ADD FRAUDELENT TRANSACTIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub

                        End If
                    Else
                        XtraMessageBox.Show("The PositionNr, Landcontext and the Countries should be selected", "UNABLE TO ADD FRAUDELENT TRANSACTIONS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Else
                XtraMessageBox.Show("The current ZVSTA reporting Schema does not accept the reporting of Fraudelent Transactions", "UNABLE TO ADD FRAUDELENT TRANSACTIONS TO THIS ZVSTA SCHEMA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If
    End Sub

    Private Sub ZVSTA_Sums_Calculate_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ZVSTA_Sums_Calculate_btn.ItemClick
        If ZVSTAT_ReportingALL_Gridview.DataRowCount > 0 Then
            If XtraMessageBox.Show(CType("Should for the current ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString _
                                       & " the Sum Positions be calculated? ", String), "CALCULATE SUM POSITIONS FOR CURRENT ZV STATISTIC REPORT", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Warning, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    CurrentZVSTA_Report = Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                    BgwZVSTA_SumsCalculate = New BackgroundWorker
                    bgws.Add(BgwZVSTA_SumsCalculate)
                    BgwZVSTA_SumsCalculate.WorkerReportsProgress = True
                    BgwZVSTA_SumsCalculate.RunWorkerAsync()

                    Me.RibbonPageGroup2.Visible = False
                    Me.RibbonPageGroup4.Visible = False
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Always
                    Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Calculating Sum Positions for ZV Statistik Report: " & Me.MeldeschemasReportingPeriod_BarEditItem.EditValue.ToString

                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub BgwZVSTA_SumsCalculate_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwZVSTA_SumsCalculate.DoWork
        Try

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Calculating Sum Positions for ZVSTA Report: " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            OpenSqlConnections()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(Y)-LandCode_T(N) -Subdivision_T(N) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is not NULL and LandCode_T is NULL and SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.SubdivisionOfCountryCode and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(Y)-Subdivision_T(N) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is not NULL and SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.SubdivisionOfCountryCode and A.LandCode_T=B.LandCode_T and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(N)-Subdivision_T(Y) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is NULL and SubdivisionOfCountryCode_T is not NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.LandCode and A.LandCode_T=B.SubdivisionOfCountryCode_T and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Update Anzahl + Wert from SubdivisionCountries (Subdivition(Y)-Subdivision_T(Y) to Landcode in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE A SET A.Anzahl_Value=A.Anzahl_Value +B.SumAnzahl,A.Wert_Value=A.Wert_Value+B.SumWert 
								  FROM ZVSTAT_Reporting A INNER JOIN 
								  (Select SUM(Anzahl_Value) as SumAnzahl
								  ,SUM(Wert_Value) as SumWert
								  ,FormNr
								  ,Landkontext
								  ,PositionNr
								  ,LandCode
								  ,SubdivisionOfCountryCode
								  ,LandCode_T
								  ,SubdivisionOfCountryCode_T
								  from ZVSTAT_Reporting where SubdivisionOfCountryCode is not NULL and SubdivisionOfCountryCode_T is not NULL 
								  and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'
								  and (Anzahl_Value<>0 or Wert_Value<>0)
								  GROUP BY FormNr,Landkontext,PositionNr,LandCode,SubdivisionOfCountryCode,LandCode_T,SubdivisionOfCountryCode_T)B
								  ON A.LandCode=B.SubdivisionOfCountryCode and A.LandCode_T=B.SubdivisionOfCountryCode_T and A.PositionNr=B.PositionNr and A.FormNr=B.FormNr and A.Landkontext=B.Landkontext
								  where A.SubdivisionOfCountryCode is NULL and A.SubdivisionOfCountryCode_T is NULL and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Set all Sum Positions to Zero in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "UPDATE ZVSTAT_Reporting SET Anzahl_Value=0,Wert_Value=0 where [SumPosition] in ('1','2','3') and [LastAction] not in ('Modification') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "'"
            cmd.ExecuteNonQuery()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('1') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Commands (First Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY FIRST SUM POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('2') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Commands (Intermediary Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_Processing.ReportProgress(10, "Execute SQL Parameters (ONLY INTERMEDIARY POSITIONS) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()

            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Parameters (ONLY FINAL SUM POSITIONS) in " & CurrentZVSTA_Report)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            QueryText = "Select * from [ZVSTAT_Reporting]  where [SumPosition] in ('3') and [ZVSTA_Schema]+[ReportingPeriod]='" & CurrentZVSTA_Report & "' and [PositionSQLcommand] is not NULL order by [LfdNr] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PositionSQLcommand").ToString <> "" Then
                    Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Commands (Final Sum Positions) for ZVSTA Report: " & CurrentZVSTA_Report & " for ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    SqlCommandText = dt.Rows.Item(i).Item("PositionSQLcommand").ToString
                    Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "Execute SQL Parameters (Final Sum Positions) in ID: " & dt.Rows.Item(i).Item("ID").ToString)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                End If
            Next
            dt.Clear()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwZVSTA_SumsCalculate.ReportProgress(10, "ERROR +++ " & ex.Message & vbNewLine & CurrentSQLCommandDescription)
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwZVSTA_SumsCalculate_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwZVSTA_SumsCalculate.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString

        OpenSqlConnections()

        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTA_SumPositions_Calculating','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@ErrorMessage,'ZVSTA_SumPositions_Calculating','ZV STATISTIK','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
    End Sub

    Private Sub BgwZVSTA_SumsCalculate_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwZVSTA_SumsCalculate.RunWorkerCompleted
        CloseSqlConnections()
        CurrentSQLCommandDescription = Nothing
        Workers_Complete(BgwZVSTA_SumsCalculate, e)
        'Workers_Complete(BgwZVSTA_Loading, e)
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.ZVSTAT_ReportingTableAdapter.FillByMeldeReporting_ALL(Me.ZvStatistik_Dataset.ZVSTAT_Reporting, CurrentZVSTA_Report)
        ADDITIONAL_CHECKS()
    End Sub


End Class