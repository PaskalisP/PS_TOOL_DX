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
Imports DevExpress.XtraEditors.Controls
Public Class Calendar

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
    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.DateEdit1.Text = Today
        Me.DateEdit2.Text = Today
        Me.DateEdit3.Text = Today
        Me.DateEdit4.Text = Today

        Me.DateNavigator1.DateTime = Today

        'Calculate Date difference
        Dim d1 As Date = Me.DateEdit1.Text
        Dim d2 As Date = Me.DateEdit2.Text

        Dim Days As Long = DateDiff(DateInterval.Day, d1, d2)
        Dim Weeks As Long = DateDiff(DateInterval.WeekOfYear, d1, d2)
        Dim Months As Long = DateDiff(DateInterval.Month, d1, d2)
        Dim Years As Double = Math.Round(Days / 365, 2)

        Me.DaysCount_lbl.Text = "Days Count: " & Days
        Me.WeeksCount_lbl.Text = "Weeks Count: " & Weeks
        Me.MonthsCount_lbl.Text = "Months Count: " & Months
        Me.YearsCount_lbl.Text = "Years Count: " & Years

        'Calculate Industry date
        Dim d3 As Date = Me.DateEdit4.Text
        Dim Year As String = DatePart(DateInterval.Year, d3)
        Me.IndustryDate_lbl.Text = "The" & " " & DatePart(DateInterval.DayOfYear, d3) & " " & "Day of the Year" & " " & Year

        Me.CalendarTableAdapter.Fill(Me.PSTOOLDataset.Calendar)

        If SUPER_USER = "N" Then
            Calendar_GridView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub DateEdit1_DateTimeChanged(sender As Object, e As EventArgs) Handles DateEdit1.DateTimeChanged
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.YearsCount_lbl.Text = ""
    End Sub

   

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.YearsCount_lbl.Text = ""
    End Sub

    Private Sub DateEdit2_DateTimeChanged(sender As Object, e As EventArgs) Handles DateEdit2.DateTimeChanged
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.YearsCount_lbl.Text = ""
    End Sub

    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit2.EditValueChanged
       
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.YearsCount_lbl.Text = ""
    End Sub

  
    Private Sub Calculate_btn_Click(sender As Object, e As EventArgs) Handles Calculate_btn.Click
        If IsDate(Me.DateEdit1.Text) = True AndAlso IsDate(Me.DateEdit2.Text) = True Then
            Dim d1 As Date = Me.DateEdit1.Text
            Dim d2 As Date = Me.DateEdit2.Text

            Dim Days As Long = DateDiff(DateInterval.Day, d1, d2)
            Dim Weeks As Long = DateDiff(DateInterval.WeekOfYear, d1, d2)
            Dim Months As Long = DateDiff(DateInterval.Month, d1, d2)
            Dim Years As Double = Math.Round(Days / 365, 2)

            Me.DaysCount_lbl.Text = "Days Count: " & Days
            Me.WeeksCount_lbl.Text = "Weeks Count: " & Weeks
            Me.MonthsCount_lbl.Text = "Months Count: " & Months
            Me.YearsCount_lbl.Text = "Years Count: " & Years
        Else
            Me.DaysCount_lbl.Text = ""
            Me.WeeksCount_lbl.Text = ""
            Me.MonthsCount_lbl.Text = ""
            Me.YearsCount_lbl.Text = ""
        End If
    End Sub

    Private Sub DateNavigator1_Click(sender As Object, e As EventArgs) Handles DateNavigator1.Click

    End Sub

    Private Sub DateNavigator1_CustomDrawDayNumberCell(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles DateNavigator1.CustomDrawDayNumberCell

        If e.Date = Today Then
            e.Graphics.FillRectangle(Brushes.Yellow, e.Bounds)
            e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brushes.Black, e.Bounds)
            e.Handled = True
        End If
        If e.Selected = True Then
            e.Graphics.FillRectangle(Brushes.Red, e.Bounds)
            e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brushes.White, e.Bounds)
            e.Handled = True
        End If

    End Sub

    Private Sub SpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles Day_SpinEdit.EditValueChanged
        If IsDate(Me.DateEdit3.Text) = True AndAlso IsNumeric(Me.Day_SpinEdit.Text) = True Then
            Dim CalcDay As Double = Me.Day_SpinEdit.Text
            Dim CurrentDate As Date = Me.DateEdit3.Text
            Dim CalculatedDate As Date = DateAdd(DateInterval.Day, CalcDay, CurrentDate)

            Me.CalculatedDate_lbl.Text = "Calculated Date: " & CalculatedDate
            Me.CalculatedDay_lbl.Text = CalculatedDate.ToString("dddd")
        Else
            Me.CalculatedDate_lbl.Text = ""
            Me.CalculatedDay_lbl.Text = ""
        End If

    End Sub

    Private Sub DateEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit4.EditValueChanged
        If IsDate(Me.DateEdit4.Text) = True Then
            'Calculate Industry date
            Dim d3 As Date = Me.DateEdit4.Text
            Dim Year As String = DatePart(DateInterval.Year, d3)
            Me.IndustryDate_lbl.Text = "The" & " " & DatePart(DateInterval.DayOfYear, d3) & " " & "Day of the Year" & " " & Year
        End If
    End Sub

    Private Sub CalendarBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CalendarBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub RepositoryItemImageComboBox3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox3.EditValueChanged
        Dim view As GridView = Me.Calendar_GridView
        Try

            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating End Dates for Minimum Reserve")
                Dim focusedRow As Integer = view.FocusedRowHandle
                
                view.PostEditor()
                Me.Validate()
                Me.CalendarBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                Me.GridControl4.BeginUpdate()
                Me.CalendarTableAdapter.Fill(Me.PSTOOLDataset.Calendar)
                view.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Calendar_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Calendar_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.Control
            e.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub Calendar_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Calendar_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub RepositoryItemImageComboBox1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox1.EditValueChanged
        Dim view As GridView = Me.Calendar_GridView
        Try

            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating TARGET Holidays")
                Dim focusedRow As Integer = view.FocusedRowHandle

                view.PostEditor()
                Me.Validate()
                Me.CalendarBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                Me.GridControl4.BeginUpdate()
                Me.CalendarTableAdapter.Fill(Me.PSTOOLDataset.Calendar)
                view.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class