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
Public Class InterestCalculator

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

    Private Sub InterestCalculator_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DateEdit1.Text = Today
        Me.DateEdit2.Text = Today

        Me.DateNavigator1.DateTime = Today

        'Calculate Date difference
        Dim d1 As Date = Me.DateEdit1.Text
        Dim d2 As Date = Me.DateEdit2.Text

        Dim Days As Long = DateDiff(DateInterval.Day, d1, d2)
        Dim Weeks As Long = DateDiff(DateInterval.WeekOfYear, d1, d2)
        Dim Months As Long = DateDiff(DateInterval.Month, d1, d2)

        Me.DaysCount_lbl.Text = "Days Count: " & Days
        Me.WeeksCount_lbl.Text = "Weeks Count: " & Weeks
        Me.MonthsCount_lbl.Text = "Months Count: " & Months

        Me.InterestMethod_cmb.Text = "ACT/360 EURO"
        Me.InterestDaysCount_lbl.Text = ""



    End Sub

    Private Sub DateEdit1_DateTimeChanged(sender As Object, e As EventArgs) Handles DateEdit1.DateTimeChanged
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.InterestCalculatedAmount_TextEdit.Text = 0
        Me.InterestDaysCount_lbl.Text = ""
    End Sub



    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.InterestCalculatedAmount_TextEdit.Text = 0
        Me.InterestDaysCount_lbl.Text = ""
    End Sub

    Private Sub DateEdit2_DateTimeChanged(sender As Object, e As EventArgs) Handles DateEdit2.DateTimeChanged
        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.InterestCalculatedAmount_TextEdit.Text = 0
        Me.InterestDaysCount_lbl.Text = ""
    End Sub

    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit2.EditValueChanged

        Me.DaysCount_lbl.Text = ""
        Me.WeeksCount_lbl.Text = ""
        Me.MonthsCount_lbl.Text = ""
        Me.InterestCalculatedAmount_TextEdit.Text = 0
        Me.InterestDaysCount_lbl.Text = ""

    End Sub

    Private Sub Calculate_btn_Click(sender As Object, e As EventArgs) Handles Calculate_btn.Click
        If IsDate(Me.DateEdit1.Text) = True AndAlso IsDate(Me.DateEdit2.Text) = True AndAlso IsNumeric(Me.InterestAmount_SpinEdit.Text) = True AndAlso IsNumeric(Me.Interest_SpinEdit.Text) = True Then
            Dim d1 As Date = Me.DateEdit1.Text
            Dim d2 As Date = Me.DateEdit2.Text
            Dim a As Double = Me.InterestAmount_SpinEdit.Text
            Dim i As Double = Me.Interest_SpinEdit.Text
            Dim ci As Double = 0

            If d2 > d1 Then

                Dim Days As Long = DateDiff(DateInterval.Day, d1, d2)
                Dim Weeks As Long = DateDiff(DateInterval.WeekOfYear, d1, d2)
                Dim Months As Long = DateDiff(DateInterval.Month, d1, d2)
                Dim years As Long = DateDiff(DateInterval.Year, d1, d2)

                Me.DaysCount_lbl.Text = "Days Count: " & Days
                Me.WeeksCount_lbl.Text = "Weeks Count: " & Weeks
                Me.MonthsCount_lbl.Text = "Months Count: " & Months

                Dim z As String = Me.InterestMethod_cmb.Text

                Select Case z
                    Case "ACT/360 EURO"
                        ci = (Days * i * a) / 36000
                        Me.InterestCalculatedAmount_TextEdit.Text = FormatNumber(ci, 2)
                        Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & Days & " /360"
                    Case "ACT/365 ENGLISH"
                        ci = (Days * i * a) / 36500
                        Me.InterestCalculatedAmount_TextEdit.Text = FormatNumber(ci, 2)
                        Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & Days & " /365"
                    Case "ACT/ACT"
                        Dim DaysCount_TOTAL As Double = DateDiff(DateInterval.Day, d1, d2)
                        Dim Zinstage_TOTAL As Double = 0
                        Dim LeapYear As Double = 0
                        Dim LeapYearDays As Double = 0
                        For year As Integer = DatePart(DateInterval.Year, d1) To DatePart(DateInterval.Year, d2)
                            If DateTime.IsLeapYear(year) Then
                                LeapYear += 1
                            End If
                        Next
                        LeapYearDays = LeapYear * 366
                        Zinstage_TOTAL = DaysCount_TOTAL - LeapYearDays
                        If DaysCount_TOTAL > 365 Then
                            If LeapYearDays > 0 AndAlso Zinstage_TOTAL > 0 Then
                                ci = (Zinstage_TOTAL * i * a) / 36500 + (LeapYearDays * i * a) / 36600
                                Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & Zinstage_TOTAL & " /365  + " & LeapYearDays & " /366"
                            ElseIf LeapYearDays > 0 AndAlso Zinstage_TOTAL <= 0 Then
                                ci = LeapYearDays * i * a / 36600
                                Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & "0 /365  + " & LeapYearDays & " /366"
                            ElseIf LeapYearDays <= 0 AndAlso Zinstage_TOTAL > 0 Then
                                ci = (Zinstage_TOTAL * i * a) / 36500
                                Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & Zinstage_TOTAL & " /365  + " & LeapYearDays & " /366"
                            End If
                        End If
                        If DaysCount_TOTAL <= 365 Then
                            If LeapYearDays > 0 Then
                                ci = DaysCount_TOTAL * i * a / 36600
                                Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & "0 /365  + " & DaysCount_TOTAL & " /366"
                            ElseIf LeapYearDays <= 0 Then
                                ci = (DaysCount_TOTAL * i * a) / 36500
                                Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & DaysCount_TOTAL & " /365  + " & "0 /366"
                            End If
                        End If
                        Me.InterestCalculatedAmount_TextEdit.Text = FormatNumber(ci, 2)
                    Case "30/360     GERMAN"
                        Dim Zinstage_TOTAL As Double = 0
                        Dim Zinstage_d1 As Double = 0
                        Dim LastInterestDay_d1 As Date = DateSerial(DatePart(DateInterval.Year, d1), DatePart(DateInterval.Month, d1), 30)
                        Dim FirstDayNextMonth_d1 As Date = LastInterestDay_d1.AddDays((LastInterestDay_d1.Day - 1) * -1).AddMonths(1)
                        Zinstage_d1 = DateDiff(DateInterval.Day, d1, LastInterestDay_d1)
                        If Zinstage_d1 > 30 Then
                            Zinstage_d1 = 30
                        End If
                        Dim Zinstage_d2 As Double = 0
                        Dim FirstInterestDay_d2 As Date = DateSerial(DatePart(DateInterval.Year, d2), DatePart(DateInterval.Month, d2), 1)
                        Dim FirstDayLastMonth As Date = DateSerial(DatePart(DateInterval.Year, d2), DatePart(DateInterval.Month, d2), 1)
                        Zinstage_d2 = DateDiff(DateInterval.Day, FirstInterestDay_d2, d2) + 1
                        If Zinstage_d2 > 30 Then
                            Zinstage_d2 = 30
                        End If
                        'MsgBox(Zinstage_d1 & "  " & Zinstage_d2)
                        'MsgBox(FirstDayNextMonth_d1 & "  " & FirstDayLastMonth)
                        Dim MonthsCount As Long = DateDiff(DateInterval.Month, FirstDayNextMonth_d1, FirstDayLastMonth)
                        'MsgBox(MonthsCount)
                        If MonthsCount < 0 Then
                            Zinstage_TOTAL = Zinstage_d1 + Zinstage_d2
                        ElseIf MonthsCount = 0 Then
                            Zinstage_TOTAL = Zinstage_d1 + (MonthsCount * 30) + Zinstage_d2
                        ElseIf MonthsCount > 0 Then
                            Zinstage_TOTAL = Zinstage_d1 + (MonthsCount * 30) + Zinstage_d2
                        End If
                        'MsgBox(Zinstage_TOTAL)
                        ci = (Zinstage_TOTAL * i * a) / 36000
                        Me.InterestCalculatedAmount_TextEdit.Text = FormatNumber(ci, 2)
                        Me.InterestDaysCount_lbl.Text = "Calculated Interest Days: " & Zinstage_TOTAL & " /360"
                    Case "30E/360   USA"
                        Dim LeapYear As Double = 0
                        Dim Zinstage As Double = 0
                        'For year As Integer = DatePart(DateInterval.Year, d1) To DatePart(DateInterval.Year, d2)
                        Dim year As Integer = DatePart(DateInterval.Year, d2)
                        If DateTime.IsLeapYear(year) Then
                            LeapYear += 1
                        End If
                        'Next

                        If DatePart(DateInterval.Month, d2) > 2 Then
                            Zinstage = (Months - LeapYear) * 30 + (LeapYear * 29)
                        ElseIf DatePart(DateInterval.Month, d2) = 2 Then
                            Dim FirstDay_d2 As Date = DateSerial(DatePart(DateInterval.Year, d2), DatePart(DateInterval.Month, d2), 1)
                            Zinstage = (Months - LeapYear) * 30 + DateDiff(DateInterval.Day, FirstDay_d2, d2) + 1
                        End If
                        'MsgBox(LeapYear.ToString)
                        'MsgBox(Zinstage.ToString)
                        ci = (Zinstage * i * a) / 36000
                        Me.InterestCalculatedAmount_TextEdit.Text = FormatNumber(ci, 2)


                End Select


            End If

       
        End If
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

End Class