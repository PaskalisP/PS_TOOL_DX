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
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraRichEdit.Services
Imports PS_TOOL_DX.RichEditSyntaxSample
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.XtraLayout

Public Class SqlParameter

    Dim ID_1 As Integer = 0
    Dim ID_2 As Integer = 0
    Dim ID_3 As Integer = 0
    Dim ID_4 As Integer = 0

    Dim ID_2_SQL_Parameters_Details As String = Nothing
    Dim ID_3_SQL_Parameters_Details As Integer = 0
    Dim ID_4_SQL_Parameters_Details As Integer = 0

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim SqlParameterDetailViewCaption As String = Nothing
    Dim SqlParameterSecondDetailViewCaption As String = Nothing
    Dim SqlParameterThirdDetailViewCaption As String = Nothing

    Dim IdRowValue As String = Nothing
    Dim IdRowValueSecond As String = Nothing
    Dim IdRowValueThird As String = Nothing
    Dim row1 As System.Data.DataRow

    Dim GetFocusedRow As Integer = 0
    Dim GetView As GridView = Nothing

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

    Private Sub SQL_PARAMETERBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SQL_PARAMETERBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

    Private Sub SqlParameter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.bbiReload.PerformClick()
        End If
    End Sub

    Private Sub SqlParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick


        Me.RichEditControl1.Document.DefaultCharacterProperties.FontName = "Consolas"
        Me.RichEditControl1.Document.DefaultCharacterProperties.FontSize = 9
        Me.RichEditControl2.Document.DefaultCharacterProperties.FontName = "Consolas"
        Me.RichEditControl2.Document.DefaultCharacterProperties.FontSize = 9

        Me.PopupContainerEdit2.PopupFormMinSize = New Size(650, 500)
        Me.ALL_PopupContainerEdit.PopupFormMinSize = New Size(650, 500)

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        CloseSqlConnections()


        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
        Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
        Me.SQL_Parameter_Gridview.BestFitColumns()

        LOAD_ALL_SQL_PARAMETER_DETAILS()

    End Sub

    Private Sub LOAD_ALL_SQL_PARAMETER_DETAILS()
        'Fill Balance Sheet 2 details
        Dim objCMD As SqlCommand = New SqlCommand("SELECT A.[ID] as 'ID-SQL_PARAMETER'
                                                ,A.[SQL_Parameter_Name] as 'SQL_Parameter_Name-SQL_PARAMETER'
                                                ,A.[SQL_Parameter_Info] as 'SQL_Parameter_Info-SQL_PARAMETER'
                                                ,A.[SQL_Parameter_Status] as 'SQL_Parameter_Status-SQL_PARAMETER'
                                                ,A.[SQL_Command_General] as 'SQL_Command_General-SQL_PARAMETER'
                                                ,A.[SQL_Float] as 'SQL_Float-SQL_PARAMETER'
                                                ,B.[ID] as 'ID-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Name_1] as 'SQL_Name_1-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Name_2] as 'SQL_Name_2-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Name_3] as 'SQL_Name_3-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Name_4] as 'SQL_Name_4-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Float_1] as 'SQL_Float_1-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Float_2] as 'SQL_Float_2-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Float_3] as 'SQL_Float_3-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Float_4] as 'SQL_Float_4-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Command_1] as 'SQL_Command_1-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Command_2] as 'SQL_Command_2-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Command_3] as 'SQL_Command_3-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Command_4] as 'SQL_Command_4-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Date1] as 'SQL_Date1-SQL_PARAMETER_DETAILS'
                                                ,B.[SQL_Date2] as 'SQL_Date2-SQL_PARAMETER_DETAILS'
                                                ,B.[Status] as 'Status-SQL_PARAMETER_DETAILS'
                                                ,B.[Id_SQL_Parameters] as 'Id_SQL_Parameters-SQL_PARAMETER_DETAILS'
                                                ,C.[ID] as 'ID-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Name_1] as 'SQL_Name_1-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Name_2] as 'SQL_Name_2-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Name_3] as 'SQL_Name_3-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Name_4] as 'SQL_Name_4-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Float_1] as 'SQL_Float_1-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Float_2] as 'SQL_Float_2-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Float_3] as 'SQL_Float_3-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Float_4] as 'SQL_Float_4-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Command_1] as 'SQL_Command_1-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Command_2] as 'SQL_Command_2-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Command_3] as 'SQL_Command_3-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Command_4] as 'SQL_Command_4SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Date1] as 'SQL_Date1-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[SQL_Date2] as 'SQL_Date2-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[Status] as 'Status-SQL_PARAMETER_DETAILS_SECOND'
                                                ,C.[Id_SQL_Parameters_Details] as 'Id_SQL_Parameters_Details-SQL_PARAMETER_DETAILS_SECOND'
                                                ,D.[ID] as 'ID-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Name_1] as 'SQL_Name_1-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Name_2] as 'SQL_Name_2-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Name_3] as 'SQL_Name_3-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Name_4] as 'SQL_Name_4-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Float_1] as 'SQL_Float_1-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Float_2] as 'SQL_Float_2-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Float_3] as 'SQL_Float_3-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Float_4] as 'SQL_Float_4-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Command_1] as 'SQL_Command_1-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Command_2] as 'SQL_Command_2-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Command_3] as 'SQL_Command_3-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Command_4] as 'SQL_Command_4-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Date1] as 'SQL_Date1-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[SQL_Date2] as 'SQL_Date2-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[Status] as 'Status-SQL_PARAMETER_DETAILS_THIRD'
                                                ,D.[Id_SQL_Parameters_Details] as 'Id_SQL_Parameters_Details-SQL_PARAMETER_DETAILS_THIRD'
                                                FROM [SQL_PARAMETER] A FULL OUTER JOIN [SQL_PARAMETER_DETAILS] B
                                                ON A.[SQL_Parameter_Name]=B.Id_SQL_Parameters
                                                FULL OUTER JOIN [SQL_PARAMETER_DETAILS_SECOND] C
                                                ON B.ID=C.Id_SQL_Parameters_Details
                                                FULL OUTER JOIN [SQL_PARAMETER_DETAILS_THIRD] D
                                                ON C.ID=D.Id_SQL_Parameters_Details
                                                ORDER BY A.[SQL_Float] asc,B.[SQL_Float_1] asc,C.[SQL_Float_1] asc,D.[SQL_Float_1]", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl1.DataSource = dt
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
            Me.SQL_Parameter_ALL_GridView.PopulateColumns()
            Me.SQL_Parameter_ALL_GridView.BestFitColumns()
        End If
        For Each column As DevExpress.XtraGrid.Columns.GridColumn In SQL_Parameter_ALL_GridView.Columns
            column.OptionsColumn.ReadOnly = True
            If column.FieldName.StartsWith("SQL_Command") Then
                column.OptionsColumn.ReadOnly = False
            End If
        Next
    End Sub

    Private Sub FILL_ALL_DATA()
        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
        Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "SQL Parameters" Then
            Me.bbiSave.Visibility = BarItemVisibility.Always
            Me.bbiDelete.Visibility = BarItemVisibility.Always
            Me.FindAndReplaceText_bbi.Visibility = BarItemVisibility.Always
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "All SQL Parameters (Display)" Then
            Me.bbiSave.Visibility = BarItemVisibility.Never
            Me.bbiDelete.Visibility = BarItemVisibility.Never
            Me.FindAndReplaceText_bbi.Visibility = BarItemVisibility.Never
        End If
    End Sub

    Private Sub bbiReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload SQL Parameters")
        FILL_ALL_DATA()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub bbiSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSave.ItemClick
        OpenSqlConnections()
        Try
            Me.Validate()
            Me.SQL_PARAMETERBindingSource.EndEdit()
            Me.SQL_PARAMETER_DETAILSBindingSource.EndEdit()
            Me.SQL_PARAMETER_DETAILS_SECONDBindingSource.EndEdit()
            Me.SQL_PARAMETER_DETAILS_THIRDBindingSource.EndEdit()
            If Me.EDPDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                    Dim view As GridView = Me.GridControl3.FocusedView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.GridControl3.BeginUpdate()

                    If view.Name = Me.SQL_Parameter_Gridview.Name.ToString Then
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    ElseIf view.Name = Me.SQL_Parameter_Details_GridView.Name.ToString Then
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                    ElseIf view.Name = Me.SQL_Parameter_Details_Second_GridView.Name.ToString Then
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                    ElseIf view.Name = Me.SQL_Parameter_Details_Third_GridView.Name.ToString Then
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                    End If

                    view.RefreshData()
                    Me.GridControl3.EndUpdate()
                    view.FocusedRowHandle = focusedRow

                    'SET SQL COMMAND FIELDS TO NULL IF LEN=0
                    cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                    cmd.ExecuteNonQuery()

                Else
                    Me.SQL_PARAMETERBindingSource.CancelEdit()
                    Me.SQL_PARAMETER_DETAILSBindingSource.CancelEdit()
                    Me.SQL_PARAMETER_DETAILS_SECONDBindingSource.CancelEdit()
                    Me.SQL_PARAMETER_DETAILS_THIRDBindingSource.CancelEdit()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        CloseSqlConnections()

        LOAD_ALL_SQL_PARAMETER_DETAILS()
    End Sub

    Private Sub bbiDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDelete.ItemClick
        OpenSqlConnections()
        'Remove PARAMETER NAMES
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then
            Dim row As System.Data.DataRow = SQL_Parameter_Gridview.GetDataRow(SQL_Parameter_Gridview.FocusedRowHandle)
            Dim cellvalue As String = row(0)
            Dim ParameterName As String = row(1)
            If MessageBox.Show("Should the SQL Parameter " & ParameterName & " and all its details be deleted ?", "DELETE SQL PARAMETER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'Delete Parameter with the same [Id_SQL_Parameters]
                cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "'))"
                cmd.ExecuteNonQuery()
                'Delete Parameter with the same [Id_SQL_Parameters]
                cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "')"
                cmd.ExecuteNonQuery()
                'Delete Parameter with the same [Id_SQL_Parameters]
                cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "'"
                cmd.ExecuteNonQuery()
                'Delete Abteilungen with the same ABTEILUNGS NAME 
                cmd.CommandText = "DELETE  FROM [SQL_PARAMETER] where [SQL_Parameter_Name]='" & ParameterName & "'"
                cmd.ExecuteNonQuery()
                'Me.SQL_Parameter_Gridview.DeleteSelectedRows()
                'GridControl3.Update()
                Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                SplashScreenManager.CloseForm(False)

            End If
        ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then
            'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
            'Dim cellvalue As String = row(0)
            If MessageBox.Show("Should the SQL Parameter ID: " & ID_2 & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                'Delete Parameter with the same [Id_SQL_Parameters]
                cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & ID_2 & "')"
                cmd.ExecuteNonQuery()
                'Delete Parameter with the same [Id_SQL_Parameters]
                cmd.CommandText = "DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID='" & ID_2 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]='" & ID_2 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS_SECOND] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters) B on A.ID=B.ID"
                cmd.ExecuteNonQuery()
                'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                cmd.CommandText = "DECLARE @ID_SQL_Parameters nvarchar(max)=(Select [Id_SQL_Parameters] from [SQL_PARAMETER_DETAILS] where ID='" & ID_2 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS] where [ID]='" & ID_2 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]=@ID_SQL_Parameters) B on A.ID=B.ID"
                cmd.ExecuteNonQuery()
                'Me.SQL_Parameter_Details_GridView.DeleteSelectedRows()
                'GridControl3.Update()
                Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
            End If
        ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then
            'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
            'Dim cellvalue As String = row(0)
            If MessageBox.Show("Should the SQL Parameter ID: " & ID_3 & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                'Delete Parameter with the same [Id_SQL_Parameters]
                cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & ID_3 & "')"
                cmd.ExecuteNonQuery()
                'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                cmd.CommandText = "DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID='" & ID_3 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & ID_3 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS_SECOND] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters) B on A.ID=B.ID"
                cmd.ExecuteNonQuery()
                'Me.SQL_Parameter_Details_Second_GridView.DeleteSelectedRows()
                'GridControl3.Update()
                Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                'Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
            End If
        ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Third_GridView" Then
            'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
            'Dim cellvalue As String = row(0)
            If MessageBox.Show("Should the SQL Parameter ID: " & ID_4 & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                cmd.CommandText = "DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID='" & ID_4 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [ID]='" & ID_4 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters) B on A.ID=B.ID"
                cmd.ExecuteNonQuery()
                'Me.SQL_Parameter_Details_Second_GridView.DeleteSelectedRows()
                'GridControl3.Update()
                Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                'Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)

            End If
        End If
        CloseSqlConnections()

        LOAD_ALL_SQL_PARAMETER_DETAILS()

    End Sub

    Private Sub bbiPrintPreview_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPrintPreview.ItemClick
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 0 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        ElseIf Me.TabbedControlGroup1.SelectedTabPageIndex = 1 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FindAndReplaceText_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles FindAndReplaceText_bbi.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim dtColumns As New DataTable
        dtColumns.Columns.Add("ColumnName", Type.GetType("System.String"))
        dtColumns.Columns.Add("ColumnCaption", Type.GetType("System.String"))

        For Each column As DevExpress.XtraGrid.Columns.GridColumn In focusedView.Columns
            If column.Visible = True And column.OptionsColumn.ReadOnly = False And column.OptionsColumn.AllowEdit = True Then
                Dim dr As DataRow = dtColumns.NewRow
                dr("ColumnName") = column.Name.ToString
                If column.Caption.ToString <> "" Then
                    dr("ColumnCaption") = column.Caption.ToString
                Else
                    dr("ColumnCaption") = column.FieldName.ToString
                End If
                dtColumns.Rows.Add(dr)

            End If
        Next

        Dim c As New FindAndReplaceInGridview
        c.ColumnsNames_LookUpEdit.Properties.DataSource = dtColumns
        c.ColumnsNames_LookUpEdit.Properties.ForceInitialize()
        c.ColumnsNames_LookUpEdit.Properties.PopulateColumns()
        c.ColumnsNames_LookUpEdit.Properties.ValueMember = "ColumnName"
        c.ColumnsNames_LookUpEdit.Properties.DisplayMember = "ColumnName"
        'c.ColumnsNames_LookUpEdit.Text = dtColumns.Rows(1).Item("ColumnName").ToString

        If DevExpress.XtraEditors.XtraDialog.Show(c, "SQL Parameter - Search and Replace", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            If c.ColumnsNames_LookUpEdit.Text <> "" Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Search and replace Text in the specified Column")
                    'MsgBox(c.ColumnsNames_LookUpEdit.EditValue.ToString)
                    Dim column As GridColumn = focusedView.Columns.ColumnByName(c.ColumnsNames_LookUpEdit.EditValue.ToString)
                    Dim searchValue As String = c.SearchText_MemoEdit.Text
                    Dim newValue As String = c.ReplaceText_MemoEdit.Text

                    For i As Integer = focusedView.FocusedRowHandle To focusedView.DataRowCount - 1
                        Dim value As Object = focusedView.GetRowCellDisplayText(i, column)
                        'MsgBox(value)
                        If value.ToString() = "" Then
                            Continue For
                        End If

                        If searchValue <> "" Then
                            If value.ToString().StartsWith(searchValue) Or value.ToString().Contains(searchValue) Or value.ToString().EndsWith(searchValue) Then
                                focusedView.FocusedRowHandle = i
                                SplashScreenManager.Default.SetWaitFormCaption("Replace Text in Row: " & i)
                                focusedView.GetRowCellValue(i, column).ToString()
                                'MsgBox(i & vbNewLine & column.FieldName)
                                If newValue <> "" Then
                                    focusedView.SetRowCellValue(i, column.FieldName, focusedView.GetRowCellValue(i, column).ToString().Replace(searchValue, newValue).ToString)
                                ElseIf newValue = "" Then
                                    focusedView.SetRowCellValue(i, column.FieldName, focusedView.GetRowCellValue(i, column).ToString().Replace(searchValue, "").ToString)
                                End If

                                'Exit For
                            End If
                        End If

                    Next
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("Search and replace finished!" & vbNewLine & "To save changes click on the save button", "SEARCH + REPLACE FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If
        End If
    End Sub


    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            OpenSqlConnections()
            Try
                Me.Validate()
                Me.SQL_PARAMETERBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Dim view As GridView = Me.GridControl3.FocusedView
                        Dim focusedRow As Integer = view.FocusedRowHandle
                        Me.GridControl3.BeginUpdate()

                        If view.Name = Me.SQL_Parameter_Gridview.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                            Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                            Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                        ElseIf view.Name = Me.SQL_Parameter_Details_GridView.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                            Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        ElseIf view.Name = Me.SQL_Parameter_Details_Second_GridView.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                            Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        ElseIf view.Name = Me.SQL_Parameter_Details_Third_GridView.Name.ToString Then
                            Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        End If

                        view.RefreshData()
                        Me.GridControl3.EndUpdate()
                        view.FocusedRowHandle = focusedRow

                        'SET SQL COMMAND FIELDS TO NULL IF LEN=0
                        cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS_SECOND] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where (Len([SQL_Command_1])=0 or Len([SQL_Command_2])=0 or Len([SQL_Command_3])=0 or Len([SQL_Command_4])=0) begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_1]=NULL where Len([SQL_Command_1])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_2]=NULL where Len([SQL_Command_2])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_3]=NULL where Len([SQL_Command_3])=0 end begin update [SQL_PARAMETER_DETAILS_THIRD] set [SQL_Command_4]=NULL where Len([SQL_Command_4])=0 end"
                        cmd.ExecuteNonQuery()

                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            CloseSqlConnections()

            LOAD_ALL_SQL_PARAMETER_DETAILS()
        End If


        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        If e.Button.ButtonType = NavigatorButtonType.Custom Then
            If e.Button.Tag.ToString = "Delete" Then
                OpenSqlConnections()
                'Remove PARAMETER NAMES
                If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then
                    Dim row As System.Data.DataRow = SQL_Parameter_Gridview.GetDataRow(SQL_Parameter_Gridview.FocusedRowHandle)
                    Dim cellvalue As String = row(0)
                    Dim ParameterName As String = row(1)
                    If MessageBox.Show("Should the SQL Parameter " & ParameterName & " and all its details be deleted ?", "DELETE SQL PARAMETER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "'))"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "')"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='" & ParameterName & "'"
                        cmd.ExecuteNonQuery()
                        'Delete Abteilungen with the same ABTEILUNGS NAME 
                        cmd.CommandText = "DELETE  FROM [SQL_PARAMETER] where [SQL_Parameter_Name]='" & ParameterName & "'"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Gridview.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                        SplashScreenManager.CloseForm(False)

                    Else
                        e.Handled = True
                    End If
                ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then
                    'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
                    'Dim cellvalue As String = row(0)
                    If MessageBox.Show("Should the SQL Parameter ID: " & ID_2 & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & ID_2 & "')"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID='" & ID_2 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]='" & ID_2 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS_SECOND] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters) B on A.ID=B.ID"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                        cmd.CommandText = "DECLARE @ID_SQL_Parameters nvarchar(max)=(Select [Id_SQL_Parameters] from [SQL_PARAMETER_DETAILS] where ID='" & ID_2 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS] where [ID]='" & ID_2 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]=@ID_SQL_Parameters) B on A.ID=B.ID"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Details_GridView.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    Else
                        e.Handled = True
                    End If
                ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then
                    'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
                    'Dim cellvalue As String = row(0)
                    If MessageBox.Show("Should the SQL Parameter ID: " & ID_3 & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        'Delete Parameter with the same [Id_SQL_Parameters]
                        cmd.CommandText = "DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & ID_3 & "')"
                        cmd.ExecuteNonQuery()
                        'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                        cmd.CommandText = "DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID='" & ID_3 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS_SECOND] where [ID]='" & ID_3 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS_SECOND] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters) B on A.ID=B.ID"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Details_Second_GridView.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        'Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    Else
                        e.Handled = True
                    End If
                ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Third_GridView" Then
                    'Dim row As System.Data.DataRow = SQL_Parameter_Details_GridView.GetDataRow(SQL_Parameter_Details_GridView.FocusedRowHandle)
                    'Dim cellvalue As String = row(0)
                    If MessageBox.Show("Should the SQL Parameter ID: " & ID_4 & " be deleted ? ", "DELETE SQL PARAMETER DETAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                        cmd.CommandText = "DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID='" & ID_4 & "')
                                           DELETE FROM [SQL_PARAMETER_DETAILS_THIRD] where [ID]='" & ID_4 & "'
                                           UPDATE A SET A.[SQL_Float_1]=B.New_LfdNr FROM  [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN 
                                           (SELECT ID,[SQL_Float_1], ROW_NUMBER() OVER (ORDER BY [SQL_Float_1]) AS New_LfdNr
                                           FROM [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters) B on A.ID=B.ID"
                        cmd.ExecuteNonQuery()
                        'Me.SQL_Parameter_Details_Second_GridView.DeleteSelectedRows()
                        'GridControl3.Update()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        'Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        'Me.SQL_PARAMETERTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER)
                    Else
                        e.Handled = True
                    End If
                End If
                CloseSqlConnections()
            End If
            LOAD_ALL_SQL_PARAMETER_DETAILS()
        End If

    End Sub

    Private Sub SQL_Parameter_Gridview_Click(sender As Object, e As EventArgs) Handles SQL_Parameter_Gridview.Click
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterDetailViewCaption = "SQL Parameter details for : " & view.GetFocusedRowCellValue("SQL_Parameter_Name").ToString
            Me.SQL_Parameter_Details_GridView.ViewCaption = SqlParameterDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles SQL_Parameter_Gridview.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterDetailViewCaption = "SQL Parameter details for : " & view.GetFocusedRowCellValue("SQL_Parameter_Name").ToString
            Me.SQL_Parameter_Details_GridView.ViewCaption = SqlParameterDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles SQL_Parameter_Gridview.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterDetailViewCaption = "SQL Parameter details for : " & view.GetFocusedRowCellValue("SQL_Parameter_Name").ToString
            Me.SQL_Parameter_Details_GridView.ViewCaption = SqlParameterDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_Click(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_GridView.Click
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterSecondDetailViewCaption = SqlParameterDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Second_GridView.ViewCaption = SqlParameterSecondDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles SQL_Parameter_Details_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterSecondDetailViewCaption = SqlParameterDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Second_GridView.ViewCaption = SqlParameterSecondDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles SQL_Parameter_Details_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterSecondDetailViewCaption = SqlParameterDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Second_GridView.ViewCaption = SqlParameterSecondDetailViewCaption


        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles SQL_Parameter_Details_Second_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterThirdDetailViewCaption = SqlParameterSecondDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Third_GridView.ViewCaption = SqlParameterThirdDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles SQL_Parameter_Details_Second_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            SqlParameterThirdDetailViewCaption = SqlParameterSecondDetailViewCaption & " - " & view.GetFocusedRowCellValue("SQL_Name_1").ToString
            Me.SQL_Parameter_Details_Third_GridView.ViewCaption = SqlParameterThirdDetailViewCaption
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles SQL_Parameter_Details_GridView.RowClick
        If SQL_Parameter_Details_GridView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            row1 = view.GetDataRow(view.FocusedRowHandle)
            IdRowValue = row1(0)
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
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
        Dim reportfooter As String = Nothing
        If Me.GridControl3.FocusedView.Name = "SQL_Parameter_Gridview" Then
            reportfooter = "SQL PARAMETER"
        ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_GridView" Then
            reportfooter = SqlParameterDetailViewCaption
        ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Second_GridView" Then
            reportfooter = SqlParameterSecondDetailViewCaption
        ElseIf Me.GridControl3.FocusedView.Name = "SQL_Parameter_Details_Third_GridView" Then
            reportfooter = SqlParameterThirdDetailViewCaption
        End If
        'Dim reportfooter As String = SqlParameterDetailViewCaption & " " & SqlParameterSecondDetailViewCaption & " " & SqlParameterThirdDetailViewCaption
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
        Dim reportfooter As String = "ALL SQL PARAMETER DETAILS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles SQL_Parameter_Details_Second_GridView.RowClick
        If SQL_Parameter_Details_Second_GridView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            row1 = view.GetDataRow(view.FocusedRowHandle)
            IdRowValueSecond = row1(0)
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Details_Second_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_Second_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles SQL_Parameter_Details_Third_GridView.RowClick
        If SQL_Parameter_Details_Second_GridView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            row1 = view.GetDataRow(view.FocusedRowHandle)
            IdRowValueThird = row1(0)
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SQL_Parameter_Details_Third_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SQL_Parameter_Details_Third_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PopupContainerEdit2_QueryPopUp(sender As Object, e As CancelEventArgs) Handles PopupContainerEdit2.QueryPopUp
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        Dim editor As BaseEdit = DirectCast(sender, BaseEdit)
        RichEditControl1.Document.Text = editor.EditValue.ToString()
        Me.RichEditControl1.Document.DefaultCharacterProperties.FontName = "Consolas"
        Me.RichEditControl1.Document.DefaultCharacterProperties.FontSize = 9

    End Sub

    Private Sub PopupContainerEdit2_QueryResultValue(sender As Object, e As QueryResultValueEventArgs) Handles PopupContainerEdit2.QueryResultValue
        e.Value = RichEditControl1.Document.Text
    End Sub


    Private Sub RichEditControl1_TextChanged(sender As Object, e As EventArgs)
        If Me.RichEditControl1.Text <> "" Then
            RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        End If
    End Sub

    Private Sub RichEditControl1_GotFocus(sender As Object, e As EventArgs)
        RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
        Me.RichEditControl1.Document.DefaultCharacterProperties.FontName = "Consolas"
        Me.RichEditControl1.Document.DefaultCharacterProperties.FontSize = 9
    End Sub

    Private Sub SQL_Parameter_Details_GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles SQL_Parameter_Details_GridView.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("SQL_Command") = True Then
                e.RepositoryItem = Me.PopupContainerEdit2

            End If
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles SQL_Parameter_Details_Second_GridView.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("SQL_Command") = True Then
                e.RepositoryItem = Me.PopupContainerEdit2

            End If
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles SQL_Parameter_Details_Third_GridView.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("SQL_Command") = True Then
                e.RepositoryItem = Me.PopupContainerEdit2

            End If
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles SQL_Parameter_Details_GridView.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_DisplayAll As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY ALL COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayAll_B), ImageCollection1.Images.Item(9))
            Dim menuItem_DisplayDefault As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY DEFAULT COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayDefault_B), ImageCollection1.Images.Item(10))

            menuItem_DisplayAll.Tag = e.Menu
            menuItem_DisplayDefault.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_DisplayAll)
            ColumnMenu.Items.Add(menuItem_DisplayDefault)

        End If

        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.SqlParameterGridviewPopupMenu.ShowPopup(GridControl3.PointToScreen(e.Point))
            End If
        End If
    End Sub

    Private Sub MyMenuItem_DisplayAll_B(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i = 0 To SQL_Parameter_Details_GridView.Columns.Count - 1
            SQL_Parameter_Details_GridView.Columns(i).Visible = False
        Next
        SQL_Parameter_Details_GridView.Columns("SQL_Float_1").VisibleIndex = 0
        SQL_Parameter_Details_GridView.Columns("SQL_Name_1").VisibleIndex = 1
        SQL_Parameter_Details_GridView.Columns("SQL_Name_2").VisibleIndex = 2
        SQL_Parameter_Details_GridView.Columns("SQL_Name_3").VisibleIndex = 3
        SQL_Parameter_Details_GridView.Columns("SQL_Name_4").VisibleIndex = 4
        SQL_Parameter_Details_GridView.Columns("SQL_Command_1").VisibleIndex = 5
        SQL_Parameter_Details_GridView.Columns("SQL_Command_2").VisibleIndex = 6
        SQL_Parameter_Details_GridView.Columns("SQL_Command_3").VisibleIndex = 7
        SQL_Parameter_Details_GridView.Columns("SQL_Command_4").VisibleIndex = 8
        SQL_Parameter_Details_GridView.Columns("Status").VisibleIndex = 9
        SQL_Parameter_Details_GridView.Columns("SQL_Float_2").VisibleIndex = 10
        SQL_Parameter_Details_GridView.Columns("SQL_Float_3").VisibleIndex = 11
        SQL_Parameter_Details_GridView.Columns("SQL_Float_4").VisibleIndex = 12
        SQL_Parameter_Details_GridView.Columns("SQL_Date1").VisibleIndex = 13
        SQL_Parameter_Details_GridView.Columns("SQL_Date2").VisibleIndex = 14
        SQL_Parameter_Details_GridView.BestFitColumns()

    End Sub

    Private Sub MyMenuItem_DisplayDefault_B(ByVal sender As System.Object, ByVal e As System.EventArgs)


        For i = 0 To SQL_Parameter_Details_GridView.Columns.Count - 1
            SQL_Parameter_Details_GridView.Columns(i).Visible = False
        Next
        SQL_Parameter_Details_GridView.Columns("SQL_Float_1").VisibleIndex = 0
        SQL_Parameter_Details_GridView.Columns("SQL_Name_1").VisibleIndex = 1
        SQL_Parameter_Details_GridView.Columns("SQL_Command_1").VisibleIndex = 3
        SQL_Parameter_Details_GridView.Columns("Status").VisibleIndex = 4
        SQL_Parameter_Details_GridView.Columns("SQL_Date1").VisibleIndex = 5
        SQL_Parameter_Details_GridView.Columns("SQL_Date2").VisibleIndex = 6


    End Sub


    Private Sub SQL_Parameter_Details_Second_GridView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles SQL_Parameter_Details_Second_GridView.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_DisplayAll As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY ALL COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayAll_C), ImageCollection1.Images.Item(9))
            Dim menuItem_DisplayDefault As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY DEFAULT COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayDefault_C), ImageCollection1.Images.Item(10))

            menuItem_DisplayAll.Tag = e.Menu
            menuItem_DisplayDefault.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_DisplayAll)
            ColumnMenu.Items.Add(menuItem_DisplayDefault)

        End If

        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.SqlParameterGridviewPopupMenu.ShowPopup(GridControl3.PointToScreen(e.Point))
            End If
        End If
    End Sub

    Private Sub MyMenuItem_DisplayAll_C(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i = 0 To SQL_Parameter_Details_Second_GridView.Columns.Count - 1
            SQL_Parameter_Details_Second_GridView.Columns(i).Visible = False
        Next
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Float_1").VisibleIndex = 0
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Name_1").VisibleIndex = 1
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Name_2").VisibleIndex = 2
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Name_3").VisibleIndex = 3
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Name_4").VisibleIndex = 4
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Command_1").VisibleIndex = 5
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Command_2").VisibleIndex = 6
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Command_3").VisibleIndex = 7
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Command_4").VisibleIndex = 8
        SQL_Parameter_Details_Second_GridView.Columns("Status").VisibleIndex = 9
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Float_2").VisibleIndex = 10
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Float_3").VisibleIndex = 11
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Float_4").VisibleIndex = 12
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Date1").VisibleIndex = 13
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Date2").VisibleIndex = 14


    End Sub

    Private Sub MyMenuItem_DisplayDefault_C(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i = 0 To SQL_Parameter_Details_Second_GridView.Columns.Count - 1
            SQL_Parameter_Details_Second_GridView.Columns(i).Visible = False
        Next
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Float_1").VisibleIndex = 0
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Name_1").VisibleIndex = 1
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Command_1").VisibleIndex = 3
        SQL_Parameter_Details_Second_GridView.Columns("Status").VisibleIndex = 4
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Date1").VisibleIndex = 5
        SQL_Parameter_Details_Second_GridView.Columns("SQL_Date2").VisibleIndex = 6


    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles SQL_Parameter_Details_Third_GridView.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_DisplayAll As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY ALL COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayAll_D), ImageCollection1.Images.Item(9))
            Dim menuItem_DisplayDefault As New DevExpress.Utils.Menu.DXMenuItem("DISPLAY DEFAULT COLUMNS", New EventHandler(AddressOf MyMenuItem_DisplayDefault_D), ImageCollection1.Images.Item(10))

            menuItem_DisplayAll.Tag = e.Menu
            menuItem_DisplayDefault.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_DisplayAll)
            ColumnMenu.Items.Add(menuItem_DisplayDefault)

        End If

        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.SqlParameterGridviewPopupMenu.ShowPopup(GridControl3.PointToScreen(e.Point))
            End If
        End If
    End Sub

    Private Sub MyMenuItem_DisplayAll_D(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i = 0 To SQL_Parameter_Details_Third_GridView.Columns.Count - 1
            SQL_Parameter_Details_Third_GridView.Columns(i).Visible = False
        Next
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Float_1").VisibleIndex = 0
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Name_1").VisibleIndex = 1
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Name_2").VisibleIndex = 2
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Name_3").VisibleIndex = 3
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Name_4").VisibleIndex = 4
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Command_1").VisibleIndex = 5
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Command_2").VisibleIndex = 6
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Command_3").VisibleIndex = 7
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Command_4").VisibleIndex = 8
        SQL_Parameter_Details_Third_GridView.Columns("Status").VisibleIndex = 9
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Float_2").VisibleIndex = 10
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Float_3").VisibleIndex = 11
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Float_4").VisibleIndex = 12
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Date1").VisibleIndex = 13
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Date2").VisibleIndex = 14


    End Sub

    Private Sub MyMenuItem_DisplayDefault_D(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i = 0 To SQL_Parameter_Details_Third_GridView.Columns.Count - 1
            SQL_Parameter_Details_Third_GridView.Columns(i).Visible = False
        Next
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Float_1").VisibleIndex = 0
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Name_1").VisibleIndex = 1
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Command_1").VisibleIndex = 3
        SQL_Parameter_Details_Third_GridView.Columns("Status").VisibleIndex = 4
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Date1").VisibleIndex = 5
        SQL_Parameter_Details_Third_GridView.Columns("SQL_Date2").VisibleIndex = 6


    End Sub



    Private Sub SQL_Parameter_Gridview_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles SQL_Parameter_Gridview.RowCellClick
        ID_1 = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_1 = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
    End Sub

    Private Sub SQL_Parameter_Gridview_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles SQL_Parameter_Gridview.FocusedRowChanged
        ID_1 = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_1 = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
    End Sub

    Private Sub SQL_Parameter_Details_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles SQL_Parameter_Details_GridView.RowCellClick
        ID_2 = 0
        ID_2_SQL_Parameters_Details = Nothing
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_2 = CInt(view.GetRowCellValue(rowHandle, colID))
            ID_2_SQL_Parameters_Details = CStr(view.GetRowCellValue(rowHandle, colId_SQL_Parameters))
        End If

    End Sub

    Private Sub SQL_Parameter_Details_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles SQL_Parameter_Details_GridView.FocusedRowChanged
        ID_2 = 0
        ID_2_SQL_Parameters_Details = Nothing
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_2 = CInt(view.GetRowCellValue(rowHandle, colID))
            ID_2_SQL_Parameters_Details = CStr(view.GetRowCellValue(rowHandle, colId_SQL_Parameters))
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles SQL_Parameter_Details_Second_GridView.RowCellClick
        ID_3 = 0
        ID_3_SQL_Parameters_Details = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_3 = CInt(view.GetRowCellValue(rowHandle, colID))
            ID_3_SQL_Parameters_Details = CInt(view.GetRowCellValue(rowHandle, colId_SQL_Parameters_Details_3))
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Second_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles SQL_Parameter_Details_Second_GridView.FocusedRowChanged
        ID_3 = 0
        ID_3_SQL_Parameters_Details = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_3 = CInt(view.GetRowCellValue(rowHandle, colID))
            ID_3_SQL_Parameters_Details = CInt(view.GetRowCellValue(rowHandle, colId_SQL_Parameters_Details_3))
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles SQL_Parameter_Details_Third_GridView.RowCellClick
        ID_4 = 0
        ID_4_SQL_Parameters_Details = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_4 = CInt(view.GetRowCellValue(rowHandle, colID))
            ID_4_SQL_Parameters_Details = CInt(view.GetRowCellValue(rowHandle, colId_SQL_Parameters_Details_4))
        End If
    End Sub

    Private Sub SQL_Parameter_Details_Third_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles SQL_Parameter_Details_Third_GridView.FocusedRowChanged
        ID_4 = 0
        ID_4_SQL_Parameters_Details = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_4 = CInt(view.GetRowCellValue(rowHandle, colID))
            ID_4_SQL_Parameters_Details = CInt(view.GetRowCellValue(rowHandle, colId_SQL_Parameters_Details_4))
        End If
    End Sub


    Private Sub SQL_Parameter_ALL_GridView_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles SQL_Parameter_ALL_GridView.CustomRowCellEdit
        Dim view As GridView = TryCast(sender, GridView)
        If e.Column.FieldName.ToString.Contains("Status") Then
            e.RepositoryItem = ALL_STATUS_ImageComboBox
        End If
        If e.Column.FieldName.ToString.StartsWith("SQL_Command") Then
            e.RepositoryItem = ALL_MemoExEdit
        End If
    End Sub

    Private Sub SQL_Parameter_ALL_GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles SQL_Parameter_ALL_GridView.CustomRowCellEditForEditing
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If e.Column.FieldName.StartsWith("SQL_Command") = True Then
                e.RepositoryItem = Me.ALL_PopupContainerEdit

            End If
        End If
    End Sub

    Private Sub ALL_PopupContainerEdit_QueryPopUp(sender As Object, e As CancelEventArgs) Handles ALL_PopupContainerEdit.QueryPopUp
        RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl2.Document))
        Dim editor As BaseEdit = DirectCast(sender, BaseEdit)
        RichEditControl2.Document.Text = editor.EditValue.ToString()
        Me.RichEditControl2.Document.DefaultCharacterProperties.FontName = "Consolas"
        Me.RichEditControl2.Document.DefaultCharacterProperties.FontSize = 9
    End Sub

    Private Sub ALL_PopupContainerEdit_QueryResultValue(sender As Object, e As QueryResultValueEventArgs) Handles ALL_PopupContainerEdit.QueryResultValue
        e.Value = RichEditControl2.Document.Text
    End Sub

    Private Sub RichEditControl2_TextChanged(sender As Object, e As EventArgs)
        If Me.RichEditControl2.Text <> "" Then
            RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl2.Document))
        End If
    End Sub

    Private Sub RichEditControl2_GotFocus(sender As Object, e As EventArgs)
        RichEditControl2.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl2.Document))
        Me.RichEditControl2.Document.DefaultCharacterProperties.FontName = "Consolas"
        Me.RichEditControl2.Document.DefaultCharacterProperties.FontSize = 9
    End Sub


    Private Sub SQL_Duplicate_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Duplicate_BarButtonItem.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "SQL_Parameter_Details_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in a new row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in a new row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                            DECLARE @ID_FIRST nvarchar(max)=(Select Id_SQL_Parameters from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @SQL_Parameter_Name_New nvarchar(100)=(Select SQL_Name_1 from [SQL_PARAMETER_DETAILS] where ID=@ID_A)+'_NEW'
                                            DECLARE @ID_B int
                                            DECLARE @ID_C int
                                            DECLARE @ID_D int
                                            DECLARE @MinID int
                                            DECLARE @MaxID int
                                            DECLARE @MinID_New int
                                            DECLARE @MaxID_New int
                                            DECLARE @CURRENT_ID int

                                            DECLARE @ID_A_New int
                                            DECLARE @ID_B_New int
                                            DECLARE @ID_C_New int
                                            DECLARE @ID_D_New int

                                            DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                            DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                            DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                            INSERT INTO [SQL_PARAMETER_DETAILS]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters])
                                            SELECT @SQL_Parameter_Name_New
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,(Select Max([SQL_Float_1])+1 from [SQL_PARAMETER_DETAILS] where Id_SQL_Parameters=@ID_FIRST)
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters]
                                            FROM [SQL_PARAMETER_DETAILS] where ID=@ID_A

                                            SET @MaxID_New=(SELECT Max(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]=@SQL_Parameter_Name_New)

                                            INSERT INTO @Param_C(ID_C,ID_SQL_C)
                                            Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_SECOND where Id_SQL_Parameters_Details=@ID_A

                                            UPDATE @Param_C SET ID_SQL_C_New=@MaxID_New


                                            SET @MinID=(Select Min(ID_C) from @Param_C)
                                            SET @MaxID=(Select Max(ID_C) from @Param_C)
                                            while (@MinId<=@MaxId) 
                                            begin
                                            SET @MaxID_New=(Select ID_SQL_C_New from @Param_C where ID_C=@MinID)
                                            INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                                SELECT [SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,@MaxID_New
                                            FROM [SQL_PARAMETER_DETAILS_SECOND] where ID=@MinID

                                            UPDATE @Param_C set ID_C_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_C=@MinID

                                            SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                            SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                            end


                                            SET @MinID=(Select Min(ID_C) from @Param_C)
                                            SET @MaxID=(Select Max(ID_C) from @Param_C)
                                            while (@MinId<=@MaxId) 
                                            begin 
                                            INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                            Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@MinId

                                            UPDATE A SET A.ID_SQL_D_New=B.ID_C_New from  @Param_D A INNER JOIN @Param_C B ON A.ID_SQL_D=B.ID_C   

                                            SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                            SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                            end


                                            SET @MinID=(Select Min(ID_D) from @Param_D)
                                            SET @MaxID=(Select Max(ID_D) from @Param_D)
                                            while (@MinId<=@MaxId) 
                                            begin
                                            SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                            INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_THIRD]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                                SELECT [SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,@MaxID_New
                                            FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                            UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                            SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                            SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                            end"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_2)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Second_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in a new row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in a new row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                        DECLARE @ID_FIRST int=(Select Id_SQL_Parameters_Details from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                        DECLARE @SQL_Parameter_Name_New nvarchar(100)=(Select SQL_Name_1 from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)+'_NEW'
                                        DECLARE @ID_B int
                                        DECLARE @ID_C int
                                        DECLARE @ID_D int
                                        DECLARE @MinID int
                                        DECLARE @MaxID int
                                        DECLARE @MinID_New int
                                        DECLARE @MaxID_New int
                                        DECLARE @CURRENT_ID int

                                        DECLARE @ID_A_New int
                                        DECLARE @ID_B_New int
                                        DECLARE @ID_C_New int
                                        DECLARE @ID_D_New int

                                        DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                        DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                        DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)

                                        INSERT INTO [SQL_PARAMETER_DETAILS_SECOND]
                                                   ([SQL_Name_1]
                                                   ,[SQL_Name_2]
                                                   ,[SQL_Name_3]
                                                   ,[SQL_Name_4]
                                                   ,[SQL_Float_1]
                                                   ,[SQL_Float_2]
                                                   ,[SQL_Float_3]
                                                   ,[SQL_Float_4]
                                                   ,[SQL_Command_1]
                                                   ,[SQL_Command_2]
                                                   ,[SQL_Command_3]
                                                   ,[SQL_Command_4]
                                                   ,[SQL_Date1]
                                                   ,[SQL_Date2]
                                                   ,[Status]
                                                   ,[Id_SQL_Parameters_Details])
                                        SELECT @SQL_Parameter_Name_New
                                                   ,[SQL_Name_2]
                                                   ,[SQL_Name_3]
                                                   ,[SQL_Name_4]
                                                   ,(Select Max([SQL_Float_1])+1 from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details=@ID_FIRST)
                                                   ,[SQL_Float_2]
                                                   ,[SQL_Float_3]
                                                   ,[SQL_Float_4]
                                                   ,[SQL_Command_1]
                                                   ,[SQL_Command_2]
                                                   ,[SQL_Command_3]
                                                   ,[SQL_Command_4]
                                                   ,[SQL_Date1]
                                                   ,[SQL_Date2]
                                                   ,[Status]
                                                   ,[Id_SQL_Parameters_Details]
                                        FROM [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A

                                        SET @MaxID_New=(SELECT Max(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1]=@SQL_Parameter_Name_New)

                                        INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                        Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@ID_A


                                        UPDATE @Param_D SET ID_SQL_D_New=@MaxID_New


                                        SET @MinID=(Select Min(ID_D) from @Param_D)
                                        SET @MaxID=(Select Max(ID_D) from @Param_D)
                                        while (@MinId<=@MaxId) 
                                        begin
                                        SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                        INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                   ([SQL_Name_1]
                                                   ,[SQL_Name_2]
                                                   ,[SQL_Name_3]
                                                   ,[SQL_Name_4]
                                                   ,[SQL_Float_1]
                                                   ,[SQL_Float_2]
                                                   ,[SQL_Float_3]
                                                   ,[SQL_Float_4]
                                                   ,[SQL_Command_1]
                                                   ,[SQL_Command_2]
                                                   ,[SQL_Command_3]
                                                   ,[SQL_Command_4]
                                                   ,[SQL_Date1]
                                                   ,[SQL_Date2]
                                                   ,[Status]
                                                   ,[Id_SQL_Parameters_Details])
                                            SELECT [SQL_Name_1]
                                                   ,[SQL_Name_2]
                                                   ,[SQL_Name_3]
                                                   ,[SQL_Name_4]
                                                   ,[SQL_Float_1]
                                                   ,[SQL_Float_2]
                                                   ,[SQL_Float_3]
                                                   ,[SQL_Float_4]
                                                   ,[SQL_Command_1]
                                                   ,[SQL_Command_2]
                                                   ,[SQL_Command_3]
                                                   ,[SQL_Command_4]
                                                   ,[SQL_Date1]
                                                   ,[SQL_Date2]
                                                   ,[Status]
                                                   ,@MaxID_New
                                        FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                        UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                        SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                        SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                        end"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_3)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Third_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in a new row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in a new row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                            DECLARE @ID_FIRST int=(Select Id_SQL_Parameters_Details from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                            DECLARE @SQL_Parameter_Name_New nvarchar(100)=(Select SQL_Name_1 from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)+'_NEW'
                                            DECLARE @ID_B int
                                            DECLARE @ID_C int
                                            DECLARE @ID_D int
                                            DECLARE @MinID int
                                            DECLARE @MaxID int
                                            DECLARE @MinID_New int
                                            DECLARE @MaxID_New int
                                            DECLARE @CURRENT_ID int

                                            DECLARE @ID_A_New int
                                            DECLARE @ID_B_New int
                                            DECLARE @ID_C_New int
                                            DECLARE @ID_D_New int

                                            DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                            DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                            DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                            INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                            SELECT @SQL_Parameter_Name_New
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,(Select Max([SQL_Float_1])+1 from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details=@ID_FIRST)
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details]
                                            FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_4)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SQL_AddToPosition_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_AddToPosition_BarButtonItem.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "SQL_Parameter_Details_GridView" Then
                If XtraMessageBox.Show("Should in the current position of the SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & "  a new SQL Parameter be added?", "ADD NEW SQL PARAMETER IN CURRENT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting adding new SQL Parameter in current position")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                            DECLARE @ID_SQL_PARAMETER nvarchar(255) =(Select [Id_SQL_Parameters] from [SQL_PARAMETER_DETAILS] where ID=@ID_1)
                                            DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                            DECLARE @DUBLICATE_NR float=0
                                            DECLARE @NEW_RUNNING_NR float=0
                                            DECLARE @ID_3 table (ID int NULL,Number float)
                                            DECLARE @ID_4 table (ID int NULL,Number float)

                                            INSERT INTO [SQL_PARAMETER_DETAILS]
                                            ([SQL_Float_1]
                                            ,[SQL_Name_1]
                                            ,[Id_SQL_Parameters]
                                            ,Status)
                                            Select [SQL_Float_1]
                                            ,'+++NEW SQL COMMAND NAME+++'
                                            ,@ID_SQL_PARAMETER
                                            ,'N' 
                                            from [SQL_PARAMETER_DETAILS] where ID=@ID_1


                                            SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS]
                                            where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where Id_SQL_Parameters=@ID_SQL_PARAMETER group by [SQL_Float_1])
                                            and Id_SQL_Parameters=@ID_SQL_PARAMETER)


                                            IF @DUBLICATE_NR>0
                                            BEGIN
                                            SELECT @DUBLICATE_NR
                                            --Find equal Nr to @DUPLICATE
                                            INSERT INTO @ID_3
                                            (ID,Number)
                                            select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS] where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Float_1]=@DUBLICATE_NR and Id_SQL_Parameters=@ID_SQL_PARAMETER)
                                            and Id_SQL_Parameters=@ID_SQL_PARAMETER

                                            SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                            IF @NEW_RUNNING_NR=0
                                            BEGIN
                                            SET @NEW_RUNNING_NR=1
                                            INSERT INTO @ID_4
                                            (ID,Number)
                                            Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS] where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Float_1] >=@DUBLICATE_NR and Id_SQL_Parameters=@ID_SQL_PARAMETER 
                                            group by [SQL_Float_1]) and Id_SQL_Parameters=@ID_SQL_PARAMETER order by ID asc
                                            END
                                            END

                                            UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS] A INNER JOIN @ID_4 B on A.ID=B.ID"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_ADD>", ID_2)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "removed to a new Position", "NEW SQL PARAMETER ADDED IN CURRENT POSITION", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Second_GridView" Then
                If XtraMessageBox.Show("Should in the current position of the SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & "  a new SQL Parameter be added?", "ADD NEW SQL PARAMETER IN CURRENT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting adding new SQL Parameter in current position")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                            DECLARE @ID_SQL_PARAMETER int =(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_1)
                                            DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                            DECLARE @DUBLICATE_NR float=0
                                            DECLARE @NEW_RUNNING_NR float=0
                                            DECLARE @ID_3 table (ID int NULL,Number float)
                                            DECLARE @ID_4 table (ID int NULL,Number float)

                                            INSERT INTO [SQL_PARAMETER_DETAILS_SECOND]
                                            ([SQL_Float_1]
                                            ,[SQL_Name_1]
                                            ,[Id_SQL_Parameters_Details]
                                            ,Status)
                                            Select [SQL_Float_1]
                                            ,'+++NEW SQL COMMAND NAME+++'
                                            ,@ID_SQL_PARAMETER
                                            ,'N' 
                                            from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_1


                                            SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] 
                                            where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details=@ID_SQL_PARAMETER group by [SQL_Float_1])
                                            and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER)


                                            IF @DUBLICATE_NR>0
                                            BEGIN
                                            SELECT @DUBLICATE_NR
                                            --Find equal Nr to @DUPLICATE
                                            INSERT INTO @ID_3
                                            (ID,Number)
                                            select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Float_1]=@DUBLICATE_NR and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER)
                                            and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER

                                            SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                            IF @NEW_RUNNING_NR=0
                                            BEGIN
                                            SET @NEW_RUNNING_NR=1
                                            INSERT INTO @ID_4
                                            (ID,Number)
                                            Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS_SECOND] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Float_1] >=@DUBLICATE_NR and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER 
                                            group by [SQL_Float_1]) and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER order by ID asc
                                            END
                                            END

                                            UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS_SECOND] A INNER JOIN @ID_4 B on A.ID=B.ID"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_ADD>", ID_3)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "removed to a new Position", "NEW SQL PARAMETER ADDED IN CURRENT POSITION", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Third_GridView" Then
                If XtraMessageBox.Show("Should in the current position of the SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & "  a new SQL Parameter be added?", "ADD NEW SQL PARAMETER IN CURRENT POSITION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting adding new SQL Parameter in current position")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_1 int=<ID_to_ADD>
                                            DECLARE @ID_SQL_PARAMETER int =(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_1)
                                            DECLARE @ID_2 table (ID int IDENTITY(1,1) NOT NULL,Number float,MaxNr float)
                                            DECLARE @DUBLICATE_NR float=0
                                            DECLARE @NEW_RUNNING_NR float=0
                                            DECLARE @ID_3 table (ID int NULL,Number float)
                                            DECLARE @ID_4 table (ID int NULL,Number float)

                                            INSERT INTO [SQL_PARAMETER_DETAILS_THIRD] 
                                            ([SQL_Float_1]
                                            ,[SQL_Name_1]
                                            ,[Id_SQL_Parameters_Details]
                                            ,Status)
                                            Select [SQL_Float_1]
                                            ,'+++NEW SQL COMMAND NAME+++'
                                            ,@ID_SQL_PARAMETER
                                            ,'N'
                                            from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_1

                                            SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_THIRD] 
                                            where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details=@ID_SQL_PARAMETER group by [SQL_Float_1])
                                            and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER)


                                            IF @DUBLICATE_NR>0
                                            BEGIN
                                            SELECT @DUBLICATE_NR
                                            --Find equal Nr to @DUPLICATE
                                            INSERT INTO @ID_3
                                            (ID,Number)
                                            select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS_THIRD] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [SQL_Float_1]=@DUBLICATE_NR and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER)
                                            and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER

                                            SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                            IF @NEW_RUNNING_NR=0
                                            BEGIN
                                            SET @NEW_RUNNING_NR=1
                                            INSERT INTO @ID_4
                                            (ID,Number)
                                            Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS_THIRD] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [SQL_Float_1] >=@DUBLICATE_NR and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER 
                                            group by [SQL_Float_1]) and Id_SQL_Parameters_Details=@ID_SQL_PARAMETER order by ID asc
                                            END
                                            END

                                            UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN @ID_4 B on A.ID=B.ID"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_ADD>", ID_4)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "removed to a new Position", "NEW SQL PARAMETER ADDED IN CURRENT POSITION", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SQL_DuplicateCurrentPosition_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_DuplicateCurrentPosition_BarButtonItem.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "SQL_Parameter_Details_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in the current row?", "DUPLICATE SQL PARAMETER - CURRENT ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in the current row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                            DECLARE @ID_SQL_Parameters nvarchar(100)=(Select Id_SQL_Parameters from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @ID_FIRST nvarchar(max)=(Select Id_SQL_Parameters from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @SQL_Parameter_Name_New nvarchar(100)='NEW_'+ (Select SQL_Name_1 from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @DUBLICATE_NR float=0
                                            DECLARE @NEW_RUNNING_NR float=0
                                            DECLARE @ID_B int
                                            DECLARE @ID_C int
                                            DECLARE @ID_D int
                                            DECLARE @MinID int
                                            DECLARE @MaxID int
                                            DECLARE @MinID_New int
                                            DECLARE @MaxID_New int
                                            DECLARE @CURRENT_ID int

                                            DECLARE @ID_A_New int
                                            DECLARE @ID_B_New int
                                            DECLARE @ID_C_New int
                                            DECLARE @ID_D_New int

                                            DECLARE @ID_3 table (ID int NULL,Number float)
                                            DECLARE @ID_4 table (ID int NULL,Number float)

                                            DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                            DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                            DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                            INSERT INTO [SQL_PARAMETER_DETAILS]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters])
                                            SELECT @SQL_Parameter_Name_New
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters]
                                            FROM [SQL_PARAMETER_DETAILS] where ID=@ID_A

                                            SET @MaxID_New=(SELECT Max(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]=@SQL_Parameter_Name_New)

                                            INSERT INTO @Param_C(ID_C,ID_SQL_C)
                                            Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_SECOND where Id_SQL_Parameters_Details=@ID_A

                                            UPDATE @Param_C SET ID_SQL_C_New=@MaxID_New


                                            SET @MinID=(Select Min(ID_C) from @Param_C)
                                            SET @MaxID=(Select Max(ID_C) from @Param_C)
                                            while (@MinId<=@MaxId) 
                                            begin
                                            SET @MaxID_New=(Select ID_SQL_C_New from @Param_C where ID_C=@MinID)
                                            INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                                SELECT [SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,@MaxID_New
                                            FROM [SQL_PARAMETER_DETAILS_SECOND] where ID=@MinID

                                            UPDATE @Param_C set ID_C_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_C=@MinID

                                            SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                            SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                            end


                                            SET @MinID=(Select Min(ID_C) from @Param_C)
                                            SET @MaxID=(Select Max(ID_C) from @Param_C)
                                            while (@MinId<=@MaxId) 
                                            begin 
                                            INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                            Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@MinId

                                            UPDATE A SET A.ID_SQL_D_New=B.ID_C_New from  @Param_D A INNER JOIN @Param_C B ON A.ID_SQL_D=B.ID_C   

                                            SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                            SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                            end


                                            SET @MinID=(Select Min(ID_D) from @Param_D)
                                            SET @MaxID=(Select Max(ID_D) from @Param_D)
                                            while (@MinId<=@MaxId) 
                                            begin
                                            SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                            INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_THIRD]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                                SELECT [SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,@MaxID_New
                                            FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                            UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                            SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                            SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                            end

                                            SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS]
                                            where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]=@ID_SQL_Parameters group by [SQL_Float_1])
                                            and [Id_SQL_Parameters]=@ID_SQL_Parameters)

                                            IF @DUBLICATE_NR>0
                                            BEGIN
                                            SELECT @DUBLICATE_NR
                                            --Find equal Nr to @DUPLICATE
                                            INSERT INTO @ID_3
                                            (ID,Number)
                                            select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Float_1]=@DUBLICATE_NR and [Id_SQL_Parameters]=@ID_SQL_Parameters)
                                            and [Id_SQL_Parameters]=@ID_SQL_Parameters

                                            SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                            IF @NEW_RUNNING_NR=0
                                            BEGIN
                                            SET @NEW_RUNNING_NR=1
                                            INSERT INTO @ID_4
                                            (ID,Number)
                                            Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Float_1] >=@DUBLICATE_NR and [Id_SQL_Parameters]=@ID_SQL_Parameters
                                            group by [SQL_Float_1]) and [Id_SQL_Parameters]=@ID_SQL_Parameters order by ID asc
                                            END
                                            END

                                            UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS]  A INNER JOIN @ID_4 B on A.ID=B.ID where A.[Id_SQL_Parameters]=@ID_SQL_Parameters"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_2)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated in current Position", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Second_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in the current row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in the current row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                                DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                                DECLARE @ID_FIRST int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                                DECLARE @SQL_Parameter_Name_New nvarchar(100)='NEW_' + (Select SQL_Name_1 from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                                DECLARE @ID_B int
                                                DECLARE @ID_C int
                                                DECLARE @ID_D int
                                                DECLARE @MinID int
                                                DECLARE @MaxID int
                                                DECLARE @MinID_New int
                                                DECLARE @MaxID_New int
                                                DECLARE @CURRENT_ID int

                                                DECLARE @ID_A_New int
                                                DECLARE @ID_B_New int
                                                DECLARE @ID_C_New int
                                                DECLARE @ID_D_New int

                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                                DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                                DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                                INSERT INTO [SQL_PARAMETER_DETAILS_SECOND]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                SELECT @SQL_Parameter_Name_New
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details]
                                                FROM [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A

                                                SET @MaxID_New=(SELECT Max(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1]=@SQL_Parameter_Name_New)

                                                INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                                Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@ID_A


                                                UPDATE @Param_D SET ID_SQL_D_New=@MaxID_New


                                                SET @MinID=(Select Min(ID_D) from @Param_D)
                                                SET @MaxID=(Select Max(ID_D) from @Param_D)
                                                while (@MinId<=@MaxId) 
                                                begin
                                                SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                                INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                    SELECT [SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,@MaxID_New
                                                FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                                UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                                SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                                SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                                end


                                                SET @MinID=(Select Min(ID_C) from @Param_C)
                                                SET @MaxID=(Select Max(ID_C) from @Param_C)
                                                while (@MinId<=@MaxId) 
                                                begin 
                                                INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                                Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@MinId

                                                UPDATE A SET A.ID_SQL_D_New=B.ID_C_New from  @Param_D A INNER JOIN @Param_C B ON A.ID_SQL_D=B.ID_C   

                                                SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                                SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                                end


                                                SET @MinID=(Select Min(ID_D) from @Param_D)
                                                SET @MaxID=(Select Max(ID_D) from @Param_D)
                                                while (@MinId<=@MaxId) 
                                                begin
                                                SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                                INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                    SELECT [SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,@MaxID_New
                                                FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                                UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                                SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                                SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                                end

                                                SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND]
                                                where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters group by [SQL_Float_1])
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)

                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR
                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] 
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Float_1]=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS_SECOND]
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Float_1] >=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters
                                                group by [SQL_Float_1]) and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS_SECOND]  A INNER JOIN @ID_4 B on A.ID=B.ID where A.[Id_SQL_Parameters_Details]=@ID_SQL_Parameters"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_3)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Third_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in the current row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in the current row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                                DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                                DECLARE @ID_FIRST int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                                DECLARE @SQL_Parameter_Name_New nvarchar(100)='NEW_' + (Select SQL_Name_1 from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                                DECLARE @ID_B int
                                                DECLARE @ID_C int
                                                DECLARE @ID_D int
                                                DECLARE @MinID int
                                                DECLARE @MaxID int
                                                DECLARE @MinID_New int
                                                DECLARE @MaxID_New int
                                                DECLARE @CURRENT_ID int

                                                DECLARE @ID_A_New int
                                                DECLARE @ID_B_New int
                                                DECLARE @ID_C_New int
                                                DECLARE @ID_D_New int

                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                                DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                                DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                                INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                SELECT @SQL_Parameter_Name_New
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details]
                                                FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A


                                                SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_THIRD]
                                                where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters group by [SQL_Float_1])
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)


                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR
                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS_THIRD] 
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [SQL_Float_1]=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS_THIRD]
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [SQL_Float_1] >=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters
                                                group by [SQL_Float_1]) and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN @ID_4 B on A.ID=B.ID where A.[Id_SQL_Parameters_Details]=@ID_SQL_Parameters"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_4)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SQL_DuplicateNextPosition_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_DuplicateNextPosition_BarButtonItem.ItemClick
        Dim focusedView As GridView = CType(GridControl3.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If focusedView.RowCount > 0 Then
            If focusedView.Name.ToString = "SQL_Parameter_Details_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in the next row?", "DUPLICATE SQL PARAMETER - CURRENT ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in the next row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                            DECLARE @ID_SQL_Parameters nvarchar(100)=(Select Id_SQL_Parameters from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @ID_FIRST nvarchar(max)=(Select Id_SQL_Parameters from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @SQL_Parameter_Name_New nvarchar(100)='NEW_'+ (Select SQL_Name_1 from [SQL_PARAMETER_DETAILS] where ID=@ID_A)
                                            DECLARE @DUBLICATE_NR float=0
                                            DECLARE @NEW_RUNNING_NR float=0
                                            DECLARE @ID_B int
                                            DECLARE @ID_C int
                                            DECLARE @ID_D int
                                            DECLARE @MinID int
                                            DECLARE @MaxID int
                                            DECLARE @MinID_New int
                                            DECLARE @MaxID_New int
                                            DECLARE @CURRENT_ID int

                                            DECLARE @ID_A_New int
                                            DECLARE @ID_B_New int
                                            DECLARE @ID_C_New int
                                            DECLARE @ID_D_New int

                                            DECLARE @ID_3 table (ID int NULL,Number float)
                                            DECLARE @ID_4 table (ID int NULL,Number float)

                                            DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                            DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                            DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                            INSERT INTO [SQL_PARAMETER_DETAILS]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters])
                                            SELECT @SQL_Parameter_Name_New
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]+1
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters]
                                            FROM [SQL_PARAMETER_DETAILS] where ID=@ID_A

                                            SET @MaxID_New=(SELECT Max(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]=@SQL_Parameter_Name_New)

                                            INSERT INTO @Param_C(ID_C,ID_SQL_C)
                                            Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_SECOND where Id_SQL_Parameters_Details=@ID_A

                                            UPDATE @Param_C SET ID_SQL_C_New=@MaxID_New


                                            SET @MinID=(Select Min(ID_C) from @Param_C)
                                            SET @MaxID=(Select Max(ID_C) from @Param_C)
                                            while (@MinId<=@MaxId) 
                                            begin
                                            SET @MaxID_New=(Select ID_SQL_C_New from @Param_C where ID_C=@MinID)
                                            INSERT INTO [SQL_PARAMETER_DETAILS_SECOND]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                                SELECT [SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,@MaxID_New
                                            FROM [SQL_PARAMETER_DETAILS_SECOND] where ID=@MinID

                                            UPDATE @Param_C set ID_C_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_C=@MinID

                                            SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                            SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                            end


                                            SET @MinID=(Select Min(ID_C) from @Param_C)
                                            SET @MaxID=(Select Max(ID_C) from @Param_C)
                                            while (@MinId<=@MaxId) 
                                            begin 
                                            INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                            Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@MinId

                                            UPDATE A SET A.ID_SQL_D_New=B.ID_C_New from  @Param_D A INNER JOIN @Param_C B ON A.ID_SQL_D=B.ID_C   

                                            SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                            SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                            end


                                            SET @MinID=(Select Min(ID_D) from @Param_D)
                                            SET @MaxID=(Select Max(ID_D) from @Param_D)
                                            while (@MinId<=@MaxId) 
                                            begin
                                            SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                            INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_THIRD]
                                                       ([SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,[Id_SQL_Parameters_Details])
                                                SELECT [SQL_Name_1]
                                                       ,[SQL_Name_2]
                                                       ,[SQL_Name_3]
                                                       ,[SQL_Name_4]
                                                       ,[SQL_Float_1]
                                                       ,[SQL_Float_2]
                                                       ,[SQL_Float_3]
                                                       ,[SQL_Float_4]
                                                       ,[SQL_Command_1]
                                                       ,[SQL_Command_2]
                                                       ,[SQL_Command_3]
                                                       ,[SQL_Command_4]
                                                       ,[SQL_Date1]
                                                       ,[SQL_Date2]
                                                       ,[Status]
                                                       ,@MaxID_New
                                            FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                            UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                            SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                            SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                            end

                                            SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS]
                                            where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]=@ID_SQL_Parameters group by [SQL_Float_1])
                                            and [Id_SQL_Parameters]=@ID_SQL_Parameters)

                                            IF @DUBLICATE_NR>0
                                            BEGIN
                                            SELECT @DUBLICATE_NR
                                            --Find equal Nr to @DUPLICATE
                                            INSERT INTO @ID_3
                                            (ID,Number)
                                            select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Float_1]=@DUBLICATE_NR and [Id_SQL_Parameters]=@ID_SQL_Parameters)
                                            and [Id_SQL_Parameters]=@ID_SQL_Parameters

                                            SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                            IF @NEW_RUNNING_NR=0
                                            BEGIN
                                            SET @NEW_RUNNING_NR=1
                                            INSERT INTO @ID_4
                                            (ID,Number)
                                            Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS] 
                                            where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS] where [SQL_Float_1] >=@DUBLICATE_NR and [Id_SQL_Parameters]=@ID_SQL_Parameters
                                            group by [SQL_Float_1]) and [Id_SQL_Parameters]=@ID_SQL_Parameters order by ID asc
                                            END
                                            END

                                            UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS]  A INNER JOIN @ID_4 B on A.ID=B.ID where A.[Id_SQL_Parameters]=@ID_SQL_Parameters"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_2)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated in current Position", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        Me.SQL_PARAMETER_DETAILSTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Second_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in a new row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in a new row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                                DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                                DECLARE @ID_FIRST int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                                DECLARE @SQL_Parameter_Name_New nvarchar(100)='NEW_' + (Select SQL_Name_1 from [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                                DECLARE @ID_B int
                                                DECLARE @ID_C int
                                                DECLARE @ID_D int
                                                DECLARE @MinID int
                                                DECLARE @MaxID int
                                                DECLARE @MinID_New int
                                                DECLARE @MaxID_New int
                                                DECLARE @CURRENT_ID int

                                                DECLARE @ID_A_New int
                                                DECLARE @ID_B_New int
                                                DECLARE @ID_C_New int
                                                DECLARE @ID_D_New int

                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                                DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                                DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                                INSERT INTO [SQL_PARAMETER_DETAILS_SECOND]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                SELECT @SQL_Parameter_Name_New
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]+1
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details]
                                                FROM [SQL_PARAMETER_DETAILS_SECOND] where ID=@ID_A

                                                SET @MaxID_New=(SELECT Max(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1]=@SQL_Parameter_Name_New)

                                                INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                                Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@ID_A


                                                UPDATE @Param_D SET ID_SQL_D_New=@MaxID_New


                                                SET @MinID=(Select Min(ID_D) from @Param_D)
                                                SET @MaxID=(Select Max(ID_D) from @Param_D)
                                                while (@MinId<=@MaxId) 
                                                begin
                                                SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                                INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                    SELECT [SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,@MaxID_New
                                                FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                                UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                                SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                                SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                                end


                                                SET @MinID=(Select Min(ID_C) from @Param_C)
                                                SET @MaxID=(Select Max(ID_C) from @Param_C)
                                                while (@MinId<=@MaxId) 
                                                begin 
                                                INSERT INTO @Param_D(ID_D,ID_SQL_D)
                                                Select ID,Id_SQL_Parameters_Details from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details=@MinId

                                                UPDATE A SET A.ID_SQL_D_New=B.ID_C_New from  @Param_D A INNER JOIN @Param_C B ON A.ID_SQL_D=B.ID_C   

                                                SET @CURRENT_ID =(Select ID from @Param_C where ID_C=@MinID)
                                                SET @MinID=(Select ID_C from @Param_C where ID=@CURRENT_ID+1)
                                                end


                                                SET @MinID=(Select Min(ID_D) from @Param_D)
                                                SET @MaxID=(Select Max(ID_D) from @Param_D)
                                                while (@MinId<=@MaxId) 
                                                begin
                                                SET @MaxID_New=(Select ID_SQL_D_New from @Param_D where ID_D=@MinID)
                                                INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                    SELECT [SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,@MaxID_New
                                                FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@MinID

                                                UPDATE @Param_D set ID_D_New=(Select MAX(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@MaxID_New) where ID_D=@MinID

                                                SET @CURRENT_ID =(Select ID from @Param_D where ID_D=@MinID)
                                                SET @MinID=(Select ID_D from @Param_D where ID=@CURRENT_ID+1)
                                                end

                                                SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND]
                                                where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters group by [SQL_Float_1])
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)

                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR
                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] 
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Float_1]=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS_SECOND]
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Float_1] >=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters
                                                group by [SQL_Float_1]) and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS_SECOND]  A INNER JOIN @ID_4 B on A.ID=B.ID where A.[Id_SQL_Parameters_Details]=@ID_SQL_Parameters"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_3)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        Me.SQL_PARAMETER_DETAILS_SECONDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_SECOND)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            ElseIf focusedView.Name.ToString = "SQL_Parameter_Details_Third_GridView" Then
                If XtraMessageBox.Show("Should the current SQL Parameter Nr: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & " be duplicated in the next row?", "DUPLICATE SQL PARAMETER - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Starting SQL Parameter duplication in the next row")

                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                                DECLARE @ID_SQL_Parameters int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                                DECLARE @ID_FIRST int=(Select [Id_SQL_Parameters_Details] from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                                DECLARE @SQL_Parameter_Name_New nvarchar(100)='NEW_' + (Select SQL_Name_1 from [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                                DECLARE @ID_B int
                                                DECLARE @ID_C int
                                                DECLARE @ID_D int
                                                DECLARE @MinID int
                                                DECLARE @MaxID int
                                                DECLARE @MinID_New int
                                                DECLARE @MaxID_New int
                                                DECLARE @CURRENT_ID int

                                                DECLARE @ID_A_New int
                                                DECLARE @ID_B_New int
                                                DECLARE @ID_C_New int
                                                DECLARE @ID_D_New int

                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                DECLARE @Param_B TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_B int NULL,ID_SQL_B int NULL,ID_B_New int NULL,ID_SQL_B_New int NULL)
                                                DECLARE @Param_C TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_C int NULL,ID_SQL_C int NULL,ID_C_New int NULL,ID_SQL_C_New int NULL)
                                                DECLARE @Param_D TABLE([ID] int IDENTITY(1,1) NOT NULL,ID_D int NULL,ID_SQL_D int NULL,ID_D_New int NULL,ID_SQL_D_New int NULL)


                                                INSERT INTO [SQL_PARAMETER_DETAILS_THIRD]
                                                           ([SQL_Name_1]
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details])
                                                SELECT @SQL_Parameter_Name_New
                                                           ,[SQL_Name_2]
                                                           ,[SQL_Name_3]
                                                           ,[SQL_Name_4]
                                                           ,[SQL_Float_1]+1
                                                           ,[SQL_Float_2]
                                                           ,[SQL_Float_3]
                                                           ,[SQL_Float_4]
                                                           ,[SQL_Command_1]
                                                           ,[SQL_Command_2]
                                                           ,[SQL_Command_3]
                                                           ,[SQL_Command_4]
                                                           ,[SQL_Date1]
                                                           ,[SQL_Date2]
                                                           ,[Status]
                                                           ,[Id_SQL_Parameters_Details]
                                                FROM [SQL_PARAMETER_DETAILS_THIRD] where ID=@ID_A


                                                SET @DUBLICATE_NR=(select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_THIRD]
                                                where ID not in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [Id_SQL_Parameters_Details]=@ID_SQL_Parameters group by [SQL_Float_1])
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)


                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR
                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[SQL_Float_1] from [SQL_PARAMETER_DETAILS_THIRD] 
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [SQL_Float_1]=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters)
                                                and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[SQL_Float_1]+@NEW_RUNNING_NR from [SQL_PARAMETER_DETAILS_THIRD]
                                                where ID in (Select Min(ID) from [SQL_PARAMETER_DETAILS_THIRD] where [SQL_Float_1] >=@DUBLICATE_NR and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters
                                                group by [SQL_Float_1]) and [Id_SQL_Parameters_Details]=@ID_SQL_Parameters order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[SQL_Float_1]=B.Number from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN @ID_4 B on A.ID=B.ID where A.[Id_SQL_Parameters_Details]=@ID_SQL_Parameters"
                        cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_4)
                        cmd.CommandText = cmd.CommandText
                        cmd.ExecuteNonQuery()
                        SplashScreenManager.CloseForm(False)

                        XtraMessageBox.Show("SQL Parameter:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "SQL_Float_1") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CloseSqlConnections()
                        Me.SQL_PARAMETER_DETAILS_THIRDTableAdapter.Fill(Me.EDPDataSet.SQL_PARAMETER_DETAILS_THIRD)
                        focusedView.RefreshData()
                        focusedView.FocusedRowHandle = GetFocusedRow

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiClose.ItemClick
        Me.Close()
    End Sub





End Class