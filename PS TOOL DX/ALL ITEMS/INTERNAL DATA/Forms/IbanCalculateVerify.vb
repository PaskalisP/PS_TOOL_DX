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
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports System.Numerics
Imports DevExpress.XtraEditors.Controls

Public Class IbanCalculateVerify

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private ImageDir As String = Nothing
    Dim CountryName As String = Nothing
    Dim fileName As String = Nothing
    Private Images As Hashtable = New Hashtable()

    Dim CountryCodeTextEdit As New DevExpress.XtraEditors.TextEdit
    Dim ItalianAccount_Ungerade As New DevExpress.XtraEditors.TextEdit

    Dim IbanCalculationParameter As String = Nothing
    Dim ButtonEditorsVisibility As String = Nothing
    Dim BankEditorMask As String = Nothing
    Dim BranchEditorMask As String = Nothing
    Dim AccountEditorMask As String = Nothing
    Dim IbanCalculationMethod As String = Nothing

    Dim BankIdentityInput As String = Nothing
    Dim BranchIdentityInput As String = Nothing
    Dim AccountNrInput As String = Nothing

    Dim BBAN_Original As String = Nothing
    Dim BBAN_Numeric As BigInteger = 0
    Dim CheckDigit As String = Nothing

    'ITALIAN IBAN CALCULATION TEXTBOXES
    Dim TextBox37 As New TextBox 'ABI
    Dim TextBox38 As New TextBox 'CAB
    Dim TextBox39 As New TextBox 'ACC

    Dim TextBox41 As New TextBox
    Dim TextBox42 As New TextBox
    Dim TextBox43 As New TextBox
    Dim TextBox44 As New TextBox
    Dim TextBox45 As New TextBox
    Dim TextBox46 As New TextBox
    Dim TextBox47 As New TextBox
    Dim TextBox48 As New TextBox
    Dim TextBox49 As New TextBox
    Dim TextBox50 As New TextBox

    Dim TextBox51 As New TextBox
    Dim TextBox52 As New TextBox
    Dim TextBox53 As New TextBox
    Dim TextBox54 As New TextBox
    Dim TextBox55 As New TextBox
    Dim TextBox56 As New TextBox
    Dim TextBox57 As New TextBox
    Dim TextBox58 As New TextBox
    Dim TextBox59 As New TextBox
    Dim TextBox60 As New TextBox
    Dim TextBox61 As New TextBox
    Dim TextBox62 As New TextBox
    Dim TextBox63 As New TextBox
    Dim TextBox64 As New TextBox
    Dim TextBox65 As New TextBox
    Dim TextBox66 As New TextBox
    Dim TextBox67 As New TextBox
    Dim TextBox68 As New TextBox
    Dim TextBox69 As New TextBox
    Dim TextBox70 As New TextBox
    Dim TextBox71 As New TextBox
    Dim TextBox72 As New TextBox
    Dim TextBox73 As New TextBox
    Dim TextBox74 As New TextBox
    Dim TextBox75 As New TextBox
    Dim TextBox76 As New TextBox
    Dim TextBox77 As New TextBox
    Dim TextBox78 As New TextBox


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
        Me.TableAdapterManager.UpdateAll(Me.IbanCalVerDataset)

    End Sub

    Private Sub IbanCalculateVerify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Fill ImageList with Images
        'Create new Datatable 
        Dim dt1 As New DataTable
        dt1.Columns.Add("Value", GetType(Integer))
        dt1.Columns.Add("COUNTRY CODE", GetType(String))
        dt1.Columns.Add("COUNTRY NAME", GetType(String))
        dt1.Columns.Add("Flag", GetType(Image))

        cmd.CommandText = "SELECT [COUNTRY CODE],[COUNTRY NAME],(SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='Flags_Images_Directory' and [IdABTEILUNGSPARAMETER]='FLAGS_IMAGES' and [PARAMETER STATUS]='Y')+RTRIM([COUNTRY NAME])+'.png' as 'Flag' FROM [COUNTRIES] where [IBAN COUNTRY]='Y' and [VALID]='Y' order by [COUNTRY NAME] asc"
        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Me.CountryFlags_ImageList.Images.Add(Image.FromFile(dt.Rows.Item(i).Item("Flag")))
            Next
            'Fill new Datatable with data and Images
            For i As Integer = 0 To CountryFlags_ImageList.Images.Count - 1
                dt1.Rows.Add(New Object() {i, dt.Rows.Item(i).Item("COUNTRY CODE"), dt.Rows.Item(i).Item("COUNTRY NAME"), CountryFlags_ImageList.Images(i)})
            Next i
        End If

        IbanCountries_GridLookUpEdit.Properties.DataSource = dt1
        IbanCountries_GridLookUpEdit.Properties.DisplayMember = "COUNTRY NAME"
        IbanCountries_GridLookUpEdit.Properties.ValueMember = "COUNTRY CODE"


        AddHandler IbanCountries_GridLookUpEdit.EditValueChanged, AddressOf IbanCountries_GridLookUpEdit_EditValueChanged
        SyncButtonImage()
        SyncButtonCountryCode()
        AddHandler CountryCodeTextEdit.TextChanged, AddressOf CountryCodeTextEdit_TextChanged

        
    End Sub

   

    Private Function GetSelectedImage() As Image
        Dim row As DataRowView = TryCast(Me.IbanCountries_GridLookUpEdit.Properties.GetRowByKeyValue(Me.IbanCountries_GridLookUpEdit.EditValue), DataRowView)
        If row Is Nothing Then
            Return Nothing
        End If
        Return TryCast(row("Flag"), Image)
    End Function

    Private Function GetSelectedCountryCode() As String
        Dim row As DataRowView = TryCast(Me.IbanCountries_GridLookUpEdit.Properties.GetRowByKeyValue(Me.IbanCountries_GridLookUpEdit.EditValue), DataRowView)
        If row Is Nothing Then
            Return Nothing
        End If
        Return TryCast(row("COUNTRY CODE"), String)
    End Function

    Private Sub SetButtonImage(ByVal selectedImage As Image, ByVal buttonIndex As Integer)
        Dim button As EditorButton = IbanCountries_GridLookUpEdit.Properties.Buttons(buttonIndex)
        button.Visible = Not (selectedImage Is Nothing)
        button.Image = selectedImage
    End Sub

    Private Sub SetButtonCountryCode(ByVal selectedCountryCode As String, ByVal buttonIndex As Integer)
        Dim button As EditorButton = IbanCountries_GridLookUpEdit.Properties.Buttons(buttonIndex)
        button.Visible = Not (selectedCountryCode Is Nothing)
        button.Caption = selectedCountryCode
        Me.CountryCodeTextEdit.Text = selectedCountryCode
    End Sub

    Private Sub SyncButtonImage()
        SetButtonImage(GetSelectedImage(), 1)
    End Sub
    Private Sub SyncButtonCountryCode()
        SetButtonCountryCode(GetSelectedCountryCode, 2)
    End Sub

    Private Sub IbanCountries_GridLookUpEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.IBAN_BIC_lbl.Text = ""
        Me.IBAN_BANK_lbl.Text = ""
        Me.BankIdentifier_ButtonEdit.Text = ""
        Me.BranchIdentifier_ButtonEdit.Text = ""
        Me.AccountNr_ButtonEdit.Text = ""
        Me.CalculatedIBAN_ButtonEdit.Text = ""
        Me.BankIdentifier_ButtonEdit.Visible = False
        Me.BranchIdentifier_ButtonEdit.Visible = False
        Me.AccountNr_ButtonEdit.Visible = False
        Me.Bank_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.Branch_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.Accountnumber_LayoutControlItem.Visibility = LayoutVisibility.Never
        BeginInvoke(New Action(AddressOf SyncButtonImage))
        BeginInvoke(New Action(AddressOf SyncButtonCountryCode))

    End Sub

    Private Sub CountryCodeTextEdit_TextChanged(sender As Object, e As EventArgs)
        Dim CountryCodeTextBox As TextEdit = TryCast(sender, TextEdit)
        If CountryCodeTextBox.Text <> "" Then
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Select [IBAN CALC] from [COUNTRIES] where [COUNTRY CODE]='" & CountryCodeTextBox.Text & "' and [IBAN CALC] is not NULL"
            Dim t As String = cmd.ExecuteScalar()
            cmd.Connection.Close()
            If IsNothing(t) = False Then
                IbanCalculationParameter = t
                Split_IbanCalculationParameter()
                Visibility_Editors()
                BANK_EDITOR_MASK()
                BRANCH_EDITOR_MASK()
                ACCOUNT_EDITOR_MASK()
            Else
                Unvisibility_Editors()
                MessageBox.Show("There's not Iban Calculation Parameter for Country: " & IbanCountries_GridLookUpEdit.Text, "IBAN CALCULATION PARAMETER MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub Split_IbanCalculationParameter()
        Dim words As String() = IbanCalculationParameter.Split(New Char() {"-"c})
        ButtonEditorsVisibility = words(0)
        BankEditorMask = words(1)
        BranchEditorMask = words(2)
        AccountEditorMask = words(3)
        IbanCalculationMethod = words(4)
    End Sub

    Private Sub Visibility_Editors()
        If Len(ButtonEditorsVisibility) = 3 Then
            If Microsoft.VisualBasic.Left(ButtonEditorsVisibility, 1) = "Y" Then
                Me.Bank_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Always
                Me.BankIdentifier_ButtonEdit.Visible = True
            ElseIf Microsoft.VisualBasic.Left(ButtonEditorsVisibility, 1) = "N" Then
                Me.BankIdentifier_ButtonEdit.Visible = False
                Me.Bank_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Never
            End If
            If Microsoft.VisualBasic.Mid(ButtonEditorsVisibility, 2, 1) = "Y" Then
                Me.Branch_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Always
                Me.BranchIdentifier_ButtonEdit.Visible = True
            ElseIf Microsoft.VisualBasic.Mid(ButtonEditorsVisibility, 2, 1) = "N" Then
                Me.BranchIdentifier_ButtonEdit.Visible = False
                Me.Branch_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Never
            End If
            If Microsoft.VisualBasic.Right(ButtonEditorsVisibility, 1) = "Y" Then
                Me.Accountnumber_LayoutControlItem.Visibility = LayoutVisibility.Always
                Me.AccountNr_ButtonEdit.Visible = True
            ElseIf Microsoft.VisualBasic.Right(ButtonEditorsVisibility, 1) = "N" Then
                Me.AccountNr_ButtonEdit.Visible = False
                Me.Accountnumber_LayoutControlItem.Visibility = LayoutVisibility.Never
            End If
            Me.IBAN_Calculate_Button_LayoutControlItem.Visibility = LayoutVisibility.Always
            Me.Calculated_IBAN_LayoutControlItem.Visibility = LayoutVisibility.Always
            Me.IbanCalculate_btn.Visible = True
            Me.CalculatedIBAN_ButtonEdit.Visible = True
        End If
    End Sub

    Private Sub Unvisibility_Editors()
        Me.Bank_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.Branch_Identifier_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.Accountnumber_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.IBAN_Calculate_Button_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.Calculated_IBAN_LayoutControlItem.Visibility = LayoutVisibility.Never
        Me.BankIdentifier_ButtonEdit.Visible = False
        Me.BranchIdentifier_ButtonEdit.Visible = False
        Me.AccountNr_ButtonEdit.Visible = False
        Me.IbanCalculate_btn.Visible = False
        Me.CalculatedIBAN_ButtonEdit.Visible = False

    End Sub

    Private Sub BANK_EDITOR_MASK()
        If BankEditorMask <> "0" Then
            Dim FirstSign As String = Microsoft.VisualBasic.Left(BankEditorMask, 1)
            Dim SecondSign As String = Microsoft.VisualBasic.Mid(BankEditorMask, 2, 100)
            If FirstSign = "N" Then
                Me.BankIdentifier_ButtonEdit.Properties.Mask.EditMask = "[0-9]{" & SecondSign & "} "
            ElseIf FirstSign = "L" Then
                Me.BankIdentifier_ButtonEdit.Properties.Mask.EditMask = "[A-Z]{" & SecondSign & "} "
            ElseIf FirstSign = "X" Then
                Me.BankIdentifier_ButtonEdit.Properties.Mask.EditMask = "[0-9A-Z]{" & SecondSign & "} "
            End If
        End If
    End Sub

    Private Sub BRANCH_EDITOR_MASK()
        If BranchEditorMask <> "0" Then
            Dim FirstSign As String = Microsoft.VisualBasic.Left(BranchEditorMask, 1)
            Dim SecondSign As String = Microsoft.VisualBasic.Mid(BranchEditorMask, 2, 100)
            If FirstSign = "N" Then
                Me.BranchIdentifier_ButtonEdit.Properties.Mask.EditMask = "[0-9]{" & SecondSign & "} "
            ElseIf FirstSign = "L" Then
                Me.BranchIdentifier_ButtonEdit.Properties.Mask.EditMask = "[A-Z]{" & SecondSign & "} "
            ElseIf FirstSign = "X" Then
                Me.BranchIdentifier_ButtonEdit.Properties.Mask.EditMask = "[0-9A-Z]{" & SecondSign & "} "
            End If
        End If
    End Sub

    Private Sub ACCOUNT_EDITOR_MASK()
        If AccountEditorMask <> "0" Then
            Dim FirstSign As String = Microsoft.VisualBasic.Left(AccountEditorMask, 1)
            Dim SecondSign As String = Microsoft.VisualBasic.Mid(AccountEditorMask, 2, 100)
            If FirstSign = "N" Then
                Me.AccountNr_ButtonEdit.Properties.Mask.EditMask = "[0-9]*"
                Me.AccountNr_ButtonEdit.Properties.MaxLength = SecondSign
            ElseIf FirstSign = "L" Then
                Me.AccountNr_ButtonEdit.Properties.Mask.EditMask = "[A-Z]*"
                Me.AccountNr_ButtonEdit.Properties.MaxLength = SecondSign
            ElseIf FirstSign = "X" Then
                Me.AccountNr_ButtonEdit.Properties.Mask.EditMask = "[0-9A-Z]*"
                Me.AccountNr_ButtonEdit.Properties.MaxLength = SecondSign
            End If
        End If
    End Sub
    
    Private Sub AccountNr_ButtonEdit_Leave(sender As Object, e As EventArgs) Handles AccountNr_ButtonEdit.Leave
        If Len(Me.AccountNr_ButtonEdit.Text) > 0 Then
            Dim AccountLenght As Integer = Len(Me.AccountNr_ButtonEdit.Text.Replace("_", ""))
            If AccountLenght < Me.AccountNr_ButtonEdit.Properties.MaxLength Then
                Dim NrLenght As Integer = Me.AccountNr_ButtonEdit.Properties.MaxLength - AccountLenght
                Dim value As String = Nothing
                For i As Integer = 0 To NrLenght - 1
                    value += "0"
                Next i
                Me.AccountNr_ButtonEdit.Text = value & Me.AccountNr_ButtonEdit.Text
            End If
        End If

    End Sub

    Private Sub IbanCalculate_btn_Click(sender As Object, e As EventArgs) Handles IbanCalculate_btn.Click
        If Me.CountryCodeTextEdit.Text <> "" Then
            If Me.BankIdentifier_ButtonEdit.Visible = True Then
                BankIdentityInput = Me.BankIdentifier_ButtonEdit.EditValue
            Else
                BankIdentityInput = ""
            End If
            If Me.BranchIdentifier_ButtonEdit.Visible = True Then
                BranchIdentityInput = Me.BranchIdentifier_ButtonEdit.EditValue
            Else
                BranchIdentityInput = ""
            End If
            If Me.AccountNr_ButtonEdit.Visible = True Then
                AccountNrInput = Me.AccountNr_ButtonEdit.EditValue
            Else
                AccountNrInput = ""
            End If
            BBAN_Original = BankIdentityInput.Replace(" ", "") & BranchIdentityInput.Replace(" ", "") & AccountNrInput.Replace("_", "") & Me.CountryCodeTextEdit.Text
            BBAN_Original = RTrim(BBAN_Original)


            Dim s As String = BBAN_Original

            s = s.Replace("A", "10")
            s = s.Replace("B", "11")
            s = s.Replace("C", "12")
            s = s.Replace("D", "13")
            s = s.Replace("E", "14")
            s = s.Replace("F", "15")
            s = s.Replace("G", "16")
            s = s.Replace("H", "17")
            s = s.Replace("I", "18")
            s = s.Replace("J", "19")
            s = s.Replace("K", "20")
            s = s.Replace("L", "21")
            s = s.Replace("M", "22")
            s = s.Replace("N", "23")
            s = s.Replace("O", "24")
            s = s.Replace("P", "25")
            s = s.Replace("Q", "26")
            s = s.Replace("R", "27")
            s = s.Replace("S", "28")
            s = s.Replace("T", "29")
            s = s.Replace("U", "30")
            s = s.Replace("V", "31")
            s = s.Replace("W", "32")
            s = s.Replace("X", "33")
            s = s.Replace("Y", "34")
            s = s.Replace("Z", "35")


            BBAN_Numeric = BigInteger.Parse(s & "00")

            Select Case IbanCalculationMethod
                Case Is = "STD"
                    IBAN_CALCULATION_STD()
                    IBAN_BANK()
                Case Is = "ITA"
                    IBAN_CALCULATION_ITA()
                    IBAN_BANK()
            End Select
        End If

    End Sub

    Private Sub IBAN_CALCULATION_STD()
        Dim ans As BigInteger = 98 - BigInteger.ModPow(BBAN_Numeric, 1, 97)

        Dim DifferenceModulus As Decimal = ans
        If DifferenceModulus < 10 Then
            CheckDigit = "0" & DifferenceModulus
        Else
            CheckDigit = DifferenceModulus
        End If
        Me.CalculatedIBAN_ButtonEdit.Text = Me.CountryCodeTextEdit.Text & CheckDigit & BankIdentityInput.Replace(" ", "") & BranchIdentityInput.Replace(" ", "") & AccountNrInput.Replace("_", "")
    End Sub

    Private Sub IBAN_CALCULATION_ITA()
        Me.TextBox37.Text = BankIdentityInput.Replace(" ", "")
        Me.TextBox38.Text = BranchIdentityInput.Replace(" ", "")
        Me.TextBox39.Text = AccountNrInput.Replace("_", "")

        'ABI-UNGERADE
        Me.TextBox41.Text = Microsoft.VisualBasic.Left(Me.TextBox37.Text, 1)
        Me.TextBox43.Text = Microsoft.VisualBasic.Mid(Me.TextBox37.Text, 3, 1)
        Me.TextBox45.Text = Microsoft.VisualBasic.Right(Me.TextBox37.Text, 1)
        'ABI GERADE
        Me.TextBox42.Text = Microsoft.VisualBasic.Mid(Me.TextBox37.Text, 2, 1)
        Me.TextBox44.Text = Microsoft.VisualBasic.Mid(Me.TextBox37.Text, 4, 1)
        '**********************
        'CAB-UNGERADE
        Me.TextBox47.Text = Microsoft.VisualBasic.Mid(Me.TextBox38.Text, 2, 1)
        Me.TextBox49.Text = Microsoft.VisualBasic.Mid(Me.TextBox38.Text, 4, 1)
        'CAB-GERADE
        Me.TextBox46.Text = Microsoft.VisualBasic.Left(Me.TextBox38.Text, 1)
        Me.TextBox48.Text = Microsoft.VisualBasic.Mid(Me.TextBox38.Text, 3, 1)
        Me.TextBox50.Text = Microsoft.VisualBasic.Right(Me.TextBox38.Text, 1)
        'UBERNAHME ABI/CAB-UNGERADE
        Select Case Val(Me.TextBox41.Text)
            Case Is = 0
                Me.TextBox41.Text = 1
            Case Is = 1
                Me.TextBox41.Text = 0
            Case Is = 2
                Me.TextBox41.Text = 5
            Case Is = 3
                Me.TextBox41.Text = 7
            Case Is = 4
                Me.TextBox41.Text = 9
            Case Is = 5
                Me.TextBox41.Text = 13
            Case Is = 6
                Me.TextBox41.Text = 15
            Case Is = 7
                Me.TextBox41.Text = 17
            Case Is = 8
                Me.TextBox41.Text = 19
            Case Is = 9
                Me.TextBox41.Text = 21
        End Select
        Select Case Val(Me.TextBox43.Text)
            Case Is = 0
                Me.TextBox43.Text = 1
            Case Is = 1
                Me.TextBox43.Text = 0
            Case Is = 2
                Me.TextBox43.Text = 5
            Case Is = 3
                Me.TextBox43.Text = 7
            Case Is = 4
                Me.TextBox43.Text = 9
            Case Is = 5
                Me.TextBox43.Text = 13
            Case Is = 6
                Me.TextBox43.Text = 15
            Case Is = 7
                Me.TextBox43.Text = 17
            Case Is = 8
                Me.TextBox43.Text = 19
            Case Is = 9
                Me.TextBox43.Text = 21
        End Select
        Select Case Val(Me.TextBox45.Text)
            Case Is = 0
                Me.TextBox45.Text = 1
            Case Is = 1
                Me.TextBox45.Text = 0
            Case Is = 2
                Me.TextBox45.Text = 5
            Case Is = 3
                Me.TextBox45.Text = 7
            Case Is = 4
                Me.TextBox45.Text = 9
            Case Is = 5
                Me.TextBox45.Text = 13
            Case Is = 6
                Me.TextBox45.Text = 15
            Case Is = 7
                Me.TextBox45.Text = 17
            Case Is = 8
                Me.TextBox45.Text = 19
            Case Is = 9
                Me.TextBox45.Text = 21
        End Select
        Select Case Val(Me.TextBox47.Text)
            Case Is = 0
                Me.TextBox47.Text = 1
            Case Is = 1
                Me.TextBox47.Text = 0
            Case Is = 2
                Me.TextBox47.Text = 5
            Case Is = 3
                Me.TextBox47.Text = 7
            Case Is = 4
                Me.TextBox47.Text = 9
            Case Is = 5
                Me.TextBox47.Text = 13
            Case Is = 6
                Me.TextBox47.Text = 15
            Case Is = 7
                Me.TextBox47.Text = 17
            Case Is = 8
                Me.TextBox47.Text = 19
            Case Is = 9
                Me.TextBox47.Text = 21
        End Select
        Select Case Val(Me.TextBox49.Text)
            Case Is = 0
                Me.TextBox49.Text = 1
            Case Is = 1
                Me.TextBox49.Text = 0
            Case Is = 2
                Me.TextBox49.Text = 5
            Case Is = 3
                Me.TextBox49.Text = 7
            Case Is = 4
                Me.TextBox49.Text = 9
            Case Is = 5
                Me.TextBox49.Text = 13
            Case Is = 6
                Me.TextBox49.Text = 15
            Case Is = 7
                Me.TextBox49.Text = 17
            Case Is = 8
                Me.TextBox49.Text = 19
            Case Is = 9
                Me.TextBox49.Text = 21
        End Select
        'KTO UNGERADE
        Me.TextBox51.Text = Microsoft.VisualBasic.Left(Me.TextBox39.Text, 1)
        Me.TextBox53.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 3, 1)
        Me.TextBox55.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 5, 1)
        Me.TextBox57.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 7, 1)
        Me.TextBox59.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 9, 1)
        Me.TextBox61.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 11, 1)
        'KTO GERADE
        Me.TextBox52.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 2, 1)
        Me.TextBox54.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 4, 1)
        Me.TextBox56.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 6, 1)
        Me.TextBox58.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 8, 1)
        Me.TextBox60.Text = Microsoft.VisualBasic.Mid(Me.TextBox39.Text, 10, 1)
        Me.TextBox62.Text = Microsoft.VisualBasic.Right(Me.TextBox39.Text, 1)
        'KTO UBERNAHME-UNGERADE
        If Me.TextBox51.Text = "0" Or Me.TextBox51.Text = "A" Then
            Me.TextBox63.Text = "1"
        End If
        If Me.TextBox51.Text = "1" Or Me.TextBox51.Text = "B" Then
            Me.TextBox63.Text = "0"
        End If
        If Me.TextBox51.Text = "2" Or Me.TextBox51.Text = "C" Then
            Me.TextBox63.Text = "5"
        End If
        If Me.TextBox51.Text = "3" Or Me.TextBox51.Text = "D" Then
            Me.TextBox63.Text = "7"
        End If
        If Me.TextBox51.Text = "4" Or Me.TextBox51.Text = "E" Then
            Me.TextBox63.Text = "9"
        End If
        If Me.TextBox51.Text = "5" Or Me.TextBox51.Text = "F" Then
            Me.TextBox63.Text = "13"
        End If
        If Me.TextBox51.Text = "6" Or Me.TextBox51.Text = "G" Then
            Me.TextBox63.Text = "15"
        End If
        If Me.TextBox51.Text = "7" Or Me.TextBox51.Text = "H" Then
            Me.TextBox63.Text = "17"
        End If
        If Me.TextBox51.Text = "8" Or Me.TextBox51.Text = "I" Then
            Me.TextBox63.Text = "19"
        End If
        If Me.TextBox51.Text = "9" Or Me.TextBox51.Text = "J" Then
            Me.TextBox63.Text = "21"
        End If
        If Me.TextBox51.Text = "K" Then
            Me.TextBox63.Text = "2"
        End If
        If Me.TextBox51.Text = "L" Then
            Me.TextBox63.Text = "4"
        End If
        If Me.TextBox51.Text = "M" Then
            Me.TextBox63.Text = "18"
        End If
        If Me.TextBox51.Text = "N" Then
            Me.TextBox63.Text = "20"
        End If
        If Me.TextBox51.Text = "O" Then
            Me.TextBox63.Text = "11"
        End If
        If Me.TextBox51.Text = "P" Then
            Me.TextBox63.Text = "3"
        End If
        If Me.TextBox51.Text = "Q" Then
            Me.TextBox63.Text = "6"
        End If
        If Me.TextBox51.Text = "R" Then
            Me.TextBox63.Text = "8"
        End If
        If Me.TextBox51.Text = "S" Then
            Me.TextBox63.Text = "12"
        End If
        If Me.TextBox51.Text = "T" Then
            Me.TextBox63.Text = "14"
        End If
        If Me.TextBox51.Text = "U" Then
            Me.TextBox63.Text = "16"
        End If
        If Me.TextBox51.Text = "V" Then
            Me.TextBox63.Text = "10"
        End If
        If Me.TextBox51.Text = "W" Then
            Me.TextBox63.Text = "22"
        End If
        If Me.TextBox51.Text = "X" Then
            Me.TextBox63.Text = "25"
        End If
        If Me.TextBox51.Text = "Y" Then
            Me.TextBox63.Text = "24"
        End If
        If Me.TextBox51.Text = "Z" Then
            Me.TextBox63.Text = "23"
        End If
        '********************************
        If Me.TextBox53.Text = "0" Or Me.TextBox53.Text = "A" Then
            Me.TextBox73.Text = "1"
        End If
        If Me.TextBox53.Text = "1" Or Me.TextBox53.Text = "B" Then
            Me.TextBox73.Text = "0"
        End If
        If Me.TextBox53.Text = "2" Or Me.TextBox53.Text = "C" Then
            Me.TextBox73.Text = "5"
        End If
        If Me.TextBox53.Text = "3" Or Me.TextBox53.Text = "D" Then
            Me.TextBox73.Text = "7"
        End If
        If Me.TextBox53.Text = "4" Or Me.TextBox53.Text = "E" Then
            Me.TextBox73.Text = "9"
        End If
        If Me.TextBox53.Text = "5" Or Me.TextBox53.Text = "F" Then
            Me.TextBox73.Text = "13"
        End If
        If Me.TextBox53.Text = "6" Or Me.TextBox53.Text = "G" Then
            Me.TextBox73.Text = "15"
        End If
        If Me.TextBox53.Text = "7" Or Me.TextBox53.Text = "H" Then
            Me.TextBox73.Text = "17"
        End If
        If Me.TextBox53.Text = "8" Or Me.TextBox53.Text = "I" Then
            Me.TextBox73.Text = "19"
        End If
        If Me.TextBox53.Text = "9" Or Me.TextBox53.Text = "J" Then
            Me.TextBox73.Text = "21"
        End If
        If Me.TextBox53.Text = "K" Then
            Me.TextBox73.Text = "2"
        End If
        If Me.TextBox53.Text = "L" Then
            Me.TextBox73.Text = "4"
        End If
        If Me.TextBox53.Text = "M" Then
            Me.TextBox73.Text = "18"
        End If
        If Me.TextBox53.Text = "N" Then
            Me.TextBox73.Text = "20"
        End If
        If Me.TextBox53.Text = "O" Then
            Me.TextBox73.Text = "11"
        End If
        If Me.TextBox53.Text = "P" Then
            Me.TextBox73.Text = "3"
        End If
        If Me.TextBox53.Text = "Q" Then
            Me.TextBox73.Text = "6"
        End If
        If Me.TextBox53.Text = "R" Then
            Me.TextBox73.Text = "8"
        End If
        If Me.TextBox53.Text = "S" Then
            Me.TextBox73.Text = "12"
        End If
        If Me.TextBox53.Text = "T" Then
            Me.TextBox73.Text = "14"
        End If
        If Me.TextBox53.Text = "U" Then
            Me.TextBox73.Text = "16"
        End If
        If Me.TextBox53.Text = "V" Then
            Me.TextBox73.Text = "10"
        End If
        If Me.TextBox53.Text = "W" Then
            Me.TextBox73.Text = "22"
        End If
        If Me.TextBox53.Text = "X" Then
            Me.TextBox73.Text = "25"
        End If
        If Me.TextBox53.Text = "Y" Then
            Me.TextBox73.Text = "24"
        End If
        If Me.TextBox53.Text = "Z" Then
            Me.TextBox73.Text = "23"
        End If
        '************************************
        If Me.TextBox55.Text = "0" Or Me.TextBox55.Text = "A" Then
            Me.TextBox71.Text = "1"
        End If
        If Me.TextBox55.Text = "1" Or Me.TextBox55.Text = "B" Then
            Me.TextBox71.Text = "0"
        End If
        If Me.TextBox55.Text = "2" Or Me.TextBox55.Text = "C" Then
            Me.TextBox71.Text = "5"
        End If
        If Me.TextBox55.Text = "3" Or Me.TextBox55.Text = "D" Then
            Me.TextBox71.Text = "7"
        End If
        If Me.TextBox55.Text = "4" Or Me.TextBox55.Text = "E" Then
            Me.TextBox71.Text = "9"
        End If
        If Me.TextBox55.Text = "5" Or Me.TextBox55.Text = "F" Then
            Me.TextBox71.Text = "13"
        End If
        If Me.TextBox55.Text = "6" Or Me.TextBox55.Text = "G" Then
            Me.TextBox71.Text = "15"
        End If
        If Me.TextBox55.Text = "7" Or Me.TextBox55.Text = "H" Then
            Me.TextBox71.Text = "17"
        End If
        If Me.TextBox55.Text = "8" Or Me.TextBox55.Text = "I" Then
            Me.TextBox71.Text = "19"
        End If
        If Me.TextBox55.Text = "9" Or Me.TextBox55.Text = "J" Then
            Me.TextBox71.Text = "21"
        End If
        If Me.TextBox55.Text = "K" Then
            Me.TextBox71.Text = "2"
        End If
        If Me.TextBox55.Text = "L" Then
            Me.TextBox71.Text = "4"
        End If
        If Me.TextBox55.Text = "M" Then
            Me.TextBox71.Text = "18"
        End If
        If Me.TextBox55.Text = "N" Then
            Me.TextBox71.Text = "20"
        End If
        If Me.TextBox55.Text = "O" Then
            Me.TextBox71.Text = "11"
        End If
        If Me.TextBox55.Text = "P" Then
            Me.TextBox71.Text = "3"
        End If
        If Me.TextBox55.Text = "Q" Then
            Me.TextBox71.Text = "6"
        End If
        If Me.TextBox55.Text = "R" Then
            Me.TextBox71.Text = "8"
        End If
        If Me.TextBox55.Text = "S" Then
            Me.TextBox71.Text = "12"
        End If
        If Me.TextBox55.Text = "T" Then
            Me.TextBox71.Text = "14"
        End If
        If Me.TextBox55.Text = "U" Then
            Me.TextBox71.Text = "16"
        End If
        If Me.TextBox55.Text = "V" Then
            Me.TextBox71.Text = "10"
        End If
        If Me.TextBox55.Text = "W" Then
            Me.TextBox71.Text = "22"
        End If
        If Me.TextBox55.Text = "X" Then
            Me.TextBox71.Text = "25"
        End If
        If Me.TextBox55.Text = "Y" Then
            Me.TextBox71.Text = "24"
        End If
        If Me.TextBox55.Text = "Z" Then
            Me.TextBox71.Text = "23"
        End If
        '**************************************
        If Me.TextBox57.Text = "0" Or Me.TextBox57.Text = "A" Then
            Me.TextBox69.Text = "1"
        End If
        If Me.TextBox57.Text = "1" Or Me.TextBox57.Text = "B" Then
            Me.TextBox69.Text = "0"
        End If
        If Me.TextBox57.Text = "2" Or Me.TextBox57.Text = "C" Then
            Me.TextBox69.Text = "5"
        End If
        If Me.TextBox57.Text = "3" Or Me.TextBox57.Text = "D" Then
            Me.TextBox69.Text = "7"
        End If
        If Me.TextBox57.Text = "4" Or Me.TextBox57.Text = "E" Then
            Me.TextBox69.Text = "9"
        End If
        If Me.TextBox57.Text = "5" Or Me.TextBox57.Text = "F" Then
            Me.TextBox69.Text = "13"
        End If
        If Me.TextBox57.Text = "6" Or Me.TextBox57.Text = "G" Then
            Me.TextBox69.Text = "15"
        End If
        If Me.TextBox57.Text = "7" Or Me.TextBox57.Text = "H" Then
            Me.TextBox69.Text = "17"
        End If
        If Me.TextBox57.Text = "8" Or Me.TextBox57.Text = "I" Then
            Me.TextBox69.Text = "19"
        End If
        If Me.TextBox57.Text = "9" Or Me.TextBox57.Text = "J" Then
            Me.TextBox69.Text = "21"
        End If
        If Me.TextBox57.Text = "K" Then
            Me.TextBox69.Text = "2"
        End If
        If Me.TextBox57.Text = "L" Then
            Me.TextBox69.Text = "4"
        End If
        If Me.TextBox57.Text = "M" Then
            Me.TextBox69.Text = "18"
        End If
        If Me.TextBox57.Text = "N" Then
            Me.TextBox69.Text = "20"
        End If
        If Me.TextBox57.Text = "O" Then
            Me.TextBox69.Text = "11"
        End If
        If Me.TextBox57.Text = "P" Then
            Me.TextBox69.Text = "3"
        End If
        If Me.TextBox57.Text = "Q" Then
            Me.TextBox69.Text = "6"
        End If
        If Me.TextBox57.Text = "R" Then
            Me.TextBox69.Text = "8"
        End If
        If Me.TextBox57.Text = "S" Then
            Me.TextBox69.Text = "12"
        End If
        If Me.TextBox57.Text = "T" Then
            Me.TextBox69.Text = "14"
        End If
        If Me.TextBox57.Text = "U" Then
            Me.TextBox69.Text = "16"
        End If
        If Me.TextBox57.Text = "V" Then
            Me.TextBox69.Text = "10"
        End If
        If Me.TextBox57.Text = "W" Then
            Me.TextBox69.Text = "22"
        End If
        If Me.TextBox57.Text = "X" Then
            Me.TextBox69.Text = "25"
        End If
        If Me.TextBox57.Text = "Y" Then
            Me.TextBox69.Text = "24"
        End If
        If Me.TextBox57.Text = "Z" Then
            Me.TextBox69.Text = "23"
        End If
        '***************************************
        If Me.TextBox59.Text = "0" Or Me.TextBox59.Text = "A" Then
            Me.TextBox67.Text = "1"
        End If
        If Me.TextBox59.Text = "1" Or Me.TextBox59.Text = "B" Then
            Me.TextBox67.Text = "0"
        End If
        If Me.TextBox59.Text = "2" Or Me.TextBox59.Text = "C" Then
            Me.TextBox67.Text = "5"
        End If
        If Me.TextBox59.Text = "3" Or Me.TextBox59.Text = "D" Then
            Me.TextBox67.Text = "7"
        End If
        If Me.TextBox59.Text = "4" Or Me.TextBox59.Text = "E" Then
            Me.TextBox67.Text = "9"
        End If
        If Me.TextBox59.Text = "5" Or Me.TextBox59.Text = "F" Then
            Me.TextBox67.Text = "13"
        End If
        If Me.TextBox59.Text = "6" Or Me.TextBox59.Text = "G" Then
            Me.TextBox67.Text = "15"
        End If
        If Me.TextBox59.Text = "7" Or Me.TextBox59.Text = "H" Then
            Me.TextBox67.Text = "17"
        End If
        If Me.TextBox59.Text = "8" Or Me.TextBox59.Text = "I" Then
            Me.TextBox67.Text = "19"
        End If
        If Me.TextBox59.Text = "9" Or Me.TextBox59.Text = "J" Then
            Me.TextBox67.Text = "21"
        End If
        If Me.TextBox59.Text = "K" Then
            Me.TextBox67.Text = "2"
        End If
        If Me.TextBox59.Text = "L" Then
            Me.TextBox67.Text = "4"
        End If
        If Me.TextBox59.Text = "M" Then
            Me.TextBox67.Text = "18"
        End If
        If Me.TextBox59.Text = "N" Then
            Me.TextBox67.Text = "20"
        End If
        If Me.TextBox59.Text = "O" Then
            Me.TextBox67.Text = "11"
        End If
        If Me.TextBox59.Text = "P" Then
            Me.TextBox67.Text = "3"
        End If
        If Me.TextBox59.Text = "Q" Then
            Me.TextBox67.Text = "6"
        End If
        If Me.TextBox59.Text = "R" Then
            Me.TextBox67.Text = "8"
        End If
        If Me.TextBox59.Text = "S" Then
            Me.TextBox67.Text = "12"
        End If
        If Me.TextBox59.Text = "T" Then
            Me.TextBox67.Text = "14"
        End If
        If Me.TextBox59.Text = "U" Then
            Me.TextBox67.Text = "16"
        End If
        If Me.TextBox59.Text = "V" Then
            Me.TextBox67.Text = "10"
        End If
        If Me.TextBox59.Text = "W" Then
            Me.TextBox67.Text = "22"
        End If
        If Me.TextBox59.Text = "X" Then
            Me.TextBox67.Text = "25"
        End If
        If Me.TextBox59.Text = "Y" Then
            Me.TextBox67.Text = "24"
        End If
        If Me.TextBox59.Text = "Z" Then
            Me.TextBox67.Text = "23"
        End If
        '****************************************
        If Me.TextBox61.Text = "0" Or Me.TextBox61.Text = "A" Then
            Me.TextBox65.Text = "1"
        End If
        If Me.TextBox61.Text = "1" Or Me.TextBox61.Text = "B" Then
            Me.TextBox65.Text = "0"
        End If
        If Me.TextBox61.Text = "2" Or Me.TextBox61.Text = "C" Then
            Me.TextBox65.Text = "5"
        End If
        If Me.TextBox61.Text = "3" Or Me.TextBox61.Text = "D" Then
            Me.TextBox65.Text = "7"
        End If
        If Me.TextBox61.Text = "4" Or Me.TextBox61.Text = "E" Then
            Me.TextBox65.Text = "9"
        End If
        If Me.TextBox61.Text = "5" Or Me.TextBox61.Text = "F" Then
            Me.TextBox65.Text = "13"
        End If
        If Me.TextBox61.Text = "6" Or Me.TextBox61.Text = "G" Then
            Me.TextBox65.Text = "15"
        End If
        If Me.TextBox61.Text = "7" Or Me.TextBox61.Text = "H" Then
            Me.TextBox65.Text = "17"
        End If
        If Me.TextBox61.Text = "8" Or Me.TextBox61.Text = "I" Then
            Me.TextBox65.Text = "19"
        End If
        If Me.TextBox61.Text = "9" Or Me.TextBox61.Text = "J" Then
            Me.TextBox65.Text = "21"
        End If
        If Me.TextBox61.Text = "K" Then
            Me.TextBox65.Text = "2"
        End If
        If Me.TextBox61.Text = "L" Then
            Me.TextBox65.Text = "4"
        End If
        If Me.TextBox61.Text = "M" Then
            Me.TextBox65.Text = "18"
        End If
        If Me.TextBox61.Text = "N" Then
            Me.TextBox65.Text = "20"
        End If
        If Me.TextBox61.Text = "O" Then
            Me.TextBox65.Text = "11"
        End If
        If Me.TextBox61.Text = "P" Then
            Me.TextBox65.Text = "3"
        End If
        If Me.TextBox61.Text = "Q" Then
            Me.TextBox65.Text = "6"
        End If
        If Me.TextBox61.Text = "R" Then
            Me.TextBox65.Text = "8"
        End If
        If Me.TextBox61.Text = "S" Then
            Me.TextBox65.Text = "12"
        End If
        If Me.TextBox61.Text = "T" Then
            Me.TextBox65.Text = "14"
        End If
        If Me.TextBox61.Text = "U" Then
            Me.TextBox65.Text = "16"
        End If
        If Me.TextBox61.Text = "V" Then
            Me.TextBox65.Text = "10"
        End If
        If Me.TextBox61.Text = "W" Then
            Me.TextBox65.Text = "22"
        End If
        If Me.TextBox61.Text = "X" Then
            Me.TextBox65.Text = "25"
        End If
        If Me.TextBox61.Text = "Y" Then
            Me.TextBox65.Text = "24"
        End If
        If Me.TextBox61.Text = "Z" Then
            Me.TextBox65.Text = "23"
        End If
        '***************************************
        'KTO(UBERNAHME - GERADE)
        If Me.TextBox52.Text = "0" Or Me.TextBox52.Text = "A" Then
            Me.TextBox74.Text = "0"
        End If
        If Me.TextBox52.Text = "1" Or Me.TextBox52.Text = "B" Then
            Me.TextBox74.Text = "1"
        End If
        If Me.TextBox52.Text = "2" Or Me.TextBox52.Text = "C" Then
            Me.TextBox74.Text = "2"
        End If
        If Me.TextBox52.Text = "3" Or Me.TextBox52.Text = "D" Then
            Me.TextBox74.Text = "3"
        End If
        If Me.TextBox52.Text = "4" Or Me.TextBox52.Text = "E" Then
            Me.TextBox74.Text = "4"
        End If
        If Me.TextBox52.Text = "5" Or Me.TextBox52.Text = "F" Then
            Me.TextBox74.Text = "5"
        End If
        If Me.TextBox52.Text = "6" Or Me.TextBox52.Text = "G" Then
            Me.TextBox74.Text = "6"
        End If
        If Me.TextBox52.Text = "7" Or Me.TextBox52.Text = "H" Then
            Me.TextBox74.Text = "7"
        End If
        If Me.TextBox52.Text = "8" Or Me.TextBox52.Text = "I" Then
            Me.TextBox74.Text = "8"
        End If
        If Me.TextBox52.Text = "9" Or Me.TextBox52.Text = "J" Then
            Me.TextBox74.Text = "9"
        End If
        If Me.TextBox52.Text = "K" Then
            Me.TextBox74.Text = "10"
        End If
        If Me.TextBox52.Text = "L" Then
            Me.TextBox74.Text = "11"
        End If
        If Me.TextBox52.Text = "M" Then
            Me.TextBox74.Text = "12"
        End If
        If Me.TextBox52.Text = "N" Then
            Me.TextBox74.Text = "13"
        End If
        If Me.TextBox52.Text = "O" Then
            Me.TextBox74.Text = "14"
        End If
        If Me.TextBox52.Text = "P" Then
            Me.TextBox74.Text = "15"
        End If
        If Me.TextBox52.Text = "Q" Then
            Me.TextBox74.Text = "16"
        End If
        If Me.TextBox52.Text = "R" Then
            Me.TextBox74.Text = "17"
        End If
        If Me.TextBox52.Text = "S" Then
            Me.TextBox74.Text = "18"
        End If
        If Me.TextBox52.Text = "T" Then
            Me.TextBox74.Text = "19"
        End If
        If Me.TextBox52.Text = "U" Then
            Me.TextBox74.Text = "20"
        End If
        If Me.TextBox52.Text = "V" Then
            Me.TextBox74.Text = "21"
        End If
        If Me.TextBox52.Text = "W" Then
            Me.TextBox74.Text = "22"
        End If
        If Me.TextBox52.Text = "X" Then
            Me.TextBox74.Text = "23"
        End If
        If Me.TextBox52.Text = "Y" Then
            Me.TextBox74.Text = "24"
        End If
        If Me.TextBox52.Text = "Z" Then
            Me.TextBox74.Text = "25"
        End If
        '********************************
        If Me.TextBox54.Text = "0" Or Me.TextBox54.Text = "A" Then
            Me.TextBox72.Text = "0"
        End If
        If Me.TextBox54.Text = "1" Or Me.TextBox54.Text = "B" Then
            Me.TextBox72.Text = "1"
        End If
        If Me.TextBox54.Text = "2" Or Me.TextBox54.Text = "C" Then
            Me.TextBox72.Text = "2"
        End If
        If Me.TextBox54.Text = "3" Or Me.TextBox54.Text = "D" Then
            Me.TextBox72.Text = "3"
        End If
        If Me.TextBox54.Text = "4" Or Me.TextBox54.Text = "E" Then
            Me.TextBox72.Text = "4"
        End If
        If Me.TextBox54.Text = "5" Or Me.TextBox54.Text = "F" Then
            Me.TextBox72.Text = "5"
        End If
        If Me.TextBox54.Text = "6" Or Me.TextBox54.Text = "G" Then
            Me.TextBox72.Text = "6"
        End If
        If Me.TextBox54.Text = "7" Or Me.TextBox54.Text = "H" Then
            Me.TextBox72.Text = "7"
        End If
        If Me.TextBox54.Text = "8" Or Me.TextBox54.Text = "I" Then
            Me.TextBox72.Text = "8"
        End If
        If Me.TextBox54.Text = "9" Or Me.TextBox54.Text = "J" Then
            Me.TextBox72.Text = "9"
        End If
        If Me.TextBox54.Text = "K" Then
            Me.TextBox72.Text = "10"
        End If
        If Me.TextBox54.Text = "L" Then
            Me.TextBox72.Text = "11"
        End If
        If Me.TextBox54.Text = "M" Then
            Me.TextBox72.Text = "12"
        End If
        If Me.TextBox54.Text = "N" Then
            Me.TextBox72.Text = "13"
        End If
        If Me.TextBox54.Text = "O" Then
            Me.TextBox72.Text = "14"
        End If
        If Me.TextBox54.Text = "P" Then
            Me.TextBox72.Text = "15"
        End If
        If Me.TextBox54.Text = "Q" Then
            Me.TextBox72.Text = "16"
        End If
        If Me.TextBox54.Text = "R" Then
            Me.TextBox72.Text = "17"
        End If
        If Me.TextBox54.Text = "S" Then
            Me.TextBox72.Text = "18"
        End If
        If Me.TextBox54.Text = "T" Then
            Me.TextBox72.Text = "19"
        End If
        If Me.TextBox54.Text = "U" Then
            Me.TextBox72.Text = "20"
        End If
        If Me.TextBox54.Text = "V" Then
            Me.TextBox72.Text = "21"
        End If
        If Me.TextBox54.Text = "W" Then
            Me.TextBox72.Text = "22"
        End If
        If Me.TextBox54.Text = "X" Then
            Me.TextBox72.Text = "23"
        End If
        If Me.TextBox54.Text = "Y" Then
            Me.TextBox72.Text = "24"
        End If
        If Me.TextBox54.Text = "Z" Then
            Me.TextBox72.Text = "25"
        End If
        '**********************************
        If Me.TextBox56.Text = "0" Or Me.TextBox56.Text = "A" Then
            Me.TextBox70.Text = "0"
        End If
        If Me.TextBox56.Text = "1" Or Me.TextBox56.Text = "B" Then
            Me.TextBox70.Text = "1"
        End If
        If Me.TextBox56.Text = "2" Or Me.TextBox56.Text = "C" Then
            Me.TextBox70.Text = "2"
        End If
        If Me.TextBox56.Text = "3" Or Me.TextBox56.Text = "D" Then
            Me.TextBox70.Text = "3"
        End If
        If Me.TextBox56.Text = "4" Or Me.TextBox56.Text = "E" Then
            Me.TextBox70.Text = "4"
        End If
        If Me.TextBox56.Text = "5" Or Me.TextBox56.Text = "F" Then
            Me.TextBox70.Text = "5"
        End If
        If Me.TextBox56.Text = "6" Or Me.TextBox56.Text = "G" Then
            Me.TextBox70.Text = "6"
        End If
        If Me.TextBox56.Text = "7" Or Me.TextBox56.Text = "H" Then
            Me.TextBox70.Text = "7"
        End If
        If Me.TextBox56.Text = "8" Or Me.TextBox56.Text = "I" Then
            Me.TextBox70.Text = "8"
        End If
        If Me.TextBox56.Text = "9" Or Me.TextBox56.Text = "J" Then
            Me.TextBox70.Text = "9"
        End If
        If Me.TextBox56.Text = "K" Then
            Me.TextBox70.Text = "10"
        End If
        If Me.TextBox56.Text = "L" Then
            Me.TextBox70.Text = "11"
        End If
        If Me.TextBox56.Text = "M" Then
            Me.TextBox70.Text = "12"
        End If
        If Me.TextBox56.Text = "N" Then
            Me.TextBox70.Text = "13"
        End If
        If Me.TextBox56.Text = "O" Then
            Me.TextBox70.Text = "14"
        End If
        If Me.TextBox56.Text = "P" Then
            Me.TextBox70.Text = "15"
        End If
        If Me.TextBox56.Text = "Q" Then
            Me.TextBox70.Text = "16"
        End If
        If Me.TextBox56.Text = "R" Then
            Me.TextBox70.Text = "17"
        End If
        If Me.TextBox56.Text = "S" Then
            Me.TextBox70.Text = "18"
        End If
        If Me.TextBox56.Text = "T" Then
            Me.TextBox70.Text = "19"
        End If
        If Me.TextBox56.Text = "U" Then
            Me.TextBox70.Text = "20"
        End If
        If Me.TextBox56.Text = "V" Then
            Me.TextBox70.Text = "21"
        End If
        If Me.TextBox56.Text = "W" Then
            Me.TextBox70.Text = "22"
        End If
        If Me.TextBox56.Text = "X" Then
            Me.TextBox70.Text = "23"
        End If
        If Me.TextBox56.Text = "Y" Then
            Me.TextBox70.Text = "24"
        End If
        If Me.TextBox56.Text = "Z" Then
            Me.TextBox70.Text = "25"
        End If
        '***************************************
        If Me.TextBox58.Text = "0" Or Me.TextBox58.Text = "A" Then
            Me.TextBox68.Text = "0"
        End If
        If Me.TextBox58.Text = "1" Or Me.TextBox58.Text = "B" Then
            Me.TextBox68.Text = "1"
        End If
        If Me.TextBox58.Text = "2" Or Me.TextBox58.Text = "C" Then
            Me.TextBox68.Text = "2"
        End If
        If Me.TextBox58.Text = "3" Or Me.TextBox58.Text = "D" Then
            Me.TextBox68.Text = "3"
        End If
        If Me.TextBox58.Text = "4" Or Me.TextBox58.Text = "E" Then
            Me.TextBox68.Text = "4"
        End If
        If Me.TextBox58.Text = "5" Or Me.TextBox58.Text = "F" Then
            Me.TextBox68.Text = "5"
        End If
        If Me.TextBox58.Text = "6" Or Me.TextBox58.Text = "G" Then
            Me.TextBox68.Text = "6"
        End If
        If Me.TextBox58.Text = "7" Or Me.TextBox58.Text = "H" Then
            Me.TextBox68.Text = "7"
        End If
        If Me.TextBox58.Text = "8" Or Me.TextBox58.Text = "I" Then
            Me.TextBox68.Text = "8"
        End If
        If Me.TextBox58.Text = "9" Or Me.TextBox58.Text = "J" Then
            Me.TextBox68.Text = "9"
        End If
        If Me.TextBox58.Text = "K" Then
            Me.TextBox68.Text = "10"
        End If
        If Me.TextBox58.Text = "L" Then
            Me.TextBox68.Text = "11"
        End If
        If Me.TextBox58.Text = "M" Then
            Me.TextBox68.Text = "12"
        End If
        If Me.TextBox58.Text = "N" Then
            Me.TextBox68.Text = "13"
        End If
        If Me.TextBox58.Text = "O" Then
            Me.TextBox68.Text = "14"
        End If
        If Me.TextBox58.Text = "P" Then
            Me.TextBox68.Text = "15"
        End If
        If Me.TextBox58.Text = "Q" Then
            Me.TextBox68.Text = "16"
        End If
        If Me.TextBox58.Text = "R" Then
            Me.TextBox68.Text = "17"
        End If
        If Me.TextBox58.Text = "S" Then
            Me.TextBox68.Text = "18"
        End If
        If Me.TextBox58.Text = "T" Then
            Me.TextBox68.Text = "19"
        End If
        If Me.TextBox58.Text = "U" Then
            Me.TextBox68.Text = "20"
        End If
        If Me.TextBox58.Text = "V" Then
            Me.TextBox68.Text = "21"
        End If
        If Me.TextBox58.Text = "W" Then
            Me.TextBox68.Text = "22"
        End If
        If Me.TextBox58.Text = "X" Then
            Me.TextBox68.Text = "23"
        End If
        If Me.TextBox58.Text = "Y" Then
            Me.TextBox68.Text = "24"
        End If
        If Me.TextBox58.Text = "Z" Then
            Me.TextBox68.Text = "25"
        End If
        '*******************************
        If Me.TextBox60.Text = "0" Or Me.TextBox60.Text = "A" Then
            Me.TextBox66.Text = "0"
        End If
        If Me.TextBox60.Text = "1" Or Me.TextBox60.Text = "B" Then
            Me.TextBox66.Text = "1"
        End If
        If Me.TextBox60.Text = "2" Or Me.TextBox60.Text = "C" Then
            Me.TextBox66.Text = "2"
        End If
        If Me.TextBox60.Text = "3" Or Me.TextBox60.Text = "D" Then
            Me.TextBox66.Text = "3"
        End If
        If Me.TextBox60.Text = "4" Or Me.TextBox60.Text = "E" Then
            Me.TextBox66.Text = "4"
        End If
        If Me.TextBox60.Text = "5" Or Me.TextBox60.Text = "F" Then
            Me.TextBox66.Text = "5"
        End If
        If Me.TextBox60.Text = "6" Or Me.TextBox60.Text = "G" Then
            Me.TextBox66.Text = "6"
        End If
        If Me.TextBox60.Text = "7" Or Me.TextBox60.Text = "H" Then
            Me.TextBox66.Text = "7"
        End If
        If Me.TextBox60.Text = "8" Or Me.TextBox60.Text = "I" Then
            Me.TextBox66.Text = "8"
        End If
        If Me.TextBox60.Text = "9" Or Me.TextBox60.Text = "J" Then
            Me.TextBox66.Text = "9"
        End If
        If Me.TextBox60.Text = "K" Then
            Me.TextBox66.Text = "10"
        End If
        If Me.TextBox60.Text = "L" Then
            Me.TextBox66.Text = "11"
        End If
        If Me.TextBox60.Text = "M" Then
            Me.TextBox66.Text = "12"
        End If
        If Me.TextBox60.Text = "N" Then
            Me.TextBox66.Text = "13"
        End If
        If Me.TextBox60.Text = "O" Then
            Me.TextBox66.Text = "14"
        End If
        If Me.TextBox60.Text = "P" Then
            Me.TextBox66.Text = "15"
        End If
        If Me.TextBox60.Text = "Q" Then
            Me.TextBox66.Text = "16"
        End If
        If Me.TextBox60.Text = "R" Then
            Me.TextBox66.Text = "17"
        End If
        If Me.TextBox60.Text = "S" Then
            Me.TextBox66.Text = "18"
        End If
        If Me.TextBox60.Text = "T" Then
            Me.TextBox66.Text = "19"
        End If
        If Me.TextBox60.Text = "U" Then
            Me.TextBox66.Text = "20"
        End If
        If Me.TextBox60.Text = "V" Then
            Me.TextBox66.Text = "21"
        End If
        If Me.TextBox60.Text = "W" Then
            Me.TextBox66.Text = "22"
        End If
        If Me.TextBox60.Text = "X" Then
            Me.TextBox66.Text = "23"
        End If
        If Me.TextBox60.Text = "Y" Then
            Me.TextBox66.Text = "24"
        End If
        If Me.TextBox60.Text = "Z" Then
            Me.TextBox66.Text = "25"
        End If
        '*********************************
        If Me.TextBox62.Text = "0" Or Me.TextBox62.Text = "A" Then
            Me.TextBox64.Text = "0"
        End If
        If Me.TextBox62.Text = "1" Or Me.TextBox62.Text = "B" Then
            Me.TextBox64.Text = "1"
        End If
        If Me.TextBox62.Text = "2" Or Me.TextBox62.Text = "C" Then
            Me.TextBox64.Text = "2"
        End If
        If Me.TextBox62.Text = "3" Or Me.TextBox62.Text = "D" Then
            Me.TextBox64.Text = "3"
        End If
        If Me.TextBox62.Text = "4" Or Me.TextBox62.Text = "E" Then
            Me.TextBox64.Text = "4"
        End If
        If Me.TextBox62.Text = "5" Or Me.TextBox62.Text = "F" Then
            Me.TextBox64.Text = "5"
        End If
        If Me.TextBox62.Text = "6" Or Me.TextBox62.Text = "G" Then
            Me.TextBox64.Text = "6"
        End If
        If Me.TextBox62.Text = "7" Or Me.TextBox62.Text = "H" Then
            Me.TextBox64.Text = "7"
        End If
        If Me.TextBox62.Text = "8" Or Me.TextBox62.Text = "I" Then
            Me.TextBox64.Text = "8"
        End If
        If Me.TextBox62.Text = "9" Or Me.TextBox62.Text = "J" Then
            Me.TextBox64.Text = "9"
        End If
        If Me.TextBox62.Text = "K" Then
            Me.TextBox64.Text = "10"
        End If
        If Me.TextBox62.Text = "L" Then
            Me.TextBox64.Text = "11"
        End If
        If Me.TextBox62.Text = "M" Then
            Me.TextBox64.Text = "12"
        End If
        If Me.TextBox62.Text = "N" Then
            Me.TextBox64.Text = "13"
        End If
        If Me.TextBox62.Text = "O" Then
            Me.TextBox64.Text = "14"
        End If
        If Me.TextBox62.Text = "P" Then
            Me.TextBox64.Text = "15"
        End If
        If Me.TextBox62.Text = "Q" Then
            Me.TextBox64.Text = "16"
        End If
        If Me.TextBox62.Text = "R" Then
            Me.TextBox64.Text = "17"
        End If
        If Me.TextBox62.Text = "S" Then
            Me.TextBox64.Text = "18"
        End If
        If Me.TextBox62.Text = "T" Then
            Me.TextBox64.Text = "19"
        End If
        If Me.TextBox62.Text = "U" Then
            Me.TextBox64.Text = "20"
        End If
        If Me.TextBox62.Text = "V" Then
            Me.TextBox64.Text = "21"
        End If
        If Me.TextBox62.Text = "W" Then
            Me.TextBox64.Text = "22"
        End If
        If Me.TextBox62.Text = "X" Then
            Me.TextBox64.Text = "23"
        End If
        If Me.TextBox62.Text = "Y" Then
            Me.TextBox64.Text = "24"
        End If
        If Me.TextBox62.Text = "Z" Then
            Me.TextBox64.Text = "25"
        End If
        'AUFSUMMIERUNG
        '*************************************
        Me.TextBox75.Text = Me.TextBox64.Text * 1 + Me.TextBox65.Text * 1 + Me.TextBox66.Text * 1 + Me.TextBox67.Text * 1 + Me.TextBox68.Text * 1 + Me.TextBox69.Text * 1 + Me.TextBox70.Text * 1 + Me.TextBox71.Text * 1 + Me.TextBox72.Text * 1 + Me.TextBox73.Text * 1 + Me.TextBox74.Text * 1 + Me.TextBox63.Text * 1 + Me.TextBox41.Text * 1 + Me.TextBox42.Text * 1 + Me.TextBox43.Text * 1 + Me.TextBox44.Text * 1 + Me.TextBox45.Text * 1 + Me.TextBox46.Text * 1 + Me.TextBox47.Text * 1 + Me.TextBox48.Text * 1 + Me.TextBox49.Text * 1 + Me.TextBox50.Text * 1

        'MODULO 26
        Dim SUM As Decimal = Me.TextBox75.Text
        Dim MD1 As Decimal = 26
        Me.TextBox76.Text = SUM Mod MD1
        '***************************************
        'BUCHSTABE DEFINIEREN FUR IBAN
        'CHECK DIGIT
        If Me.TextBox76.Text = "0" Then
            Me.TextBox77.Text = "A"
        End If
        If Me.TextBox76.Text = "1" Then
            Me.TextBox77.Text = "B"
        End If
        If Me.TextBox76.Text = "2" Then
            Me.TextBox77.Text = "C"
        End If
        If Me.TextBox76.Text = "3" Then
            Me.TextBox77.Text = "D"
        End If
        If Me.TextBox76.Text = "4" Then
            Me.TextBox77.Text = "E"
        End If
        If Me.TextBox76.Text = "5" Then
            Me.TextBox77.Text = "F"
        End If
        If Me.TextBox76.Text = "6" Then
            Me.TextBox77.Text = "G"
        End If
        If Me.TextBox76.Text = "7" Then
            Me.TextBox77.Text = "H"
        End If
        If Me.TextBox76.Text = "8" Then
            Me.TextBox77.Text = "I"
        End If
        If Me.TextBox76.Text = "9" Then
            Me.TextBox77.Text = "J"
        End If
        If Me.TextBox76.Text = "10" Then
            Me.TextBox77.Text = "K"
        End If
        If Me.TextBox76.Text = "11" Then
            Me.TextBox77.Text = "L"
        End If
        If Me.TextBox76.Text = "12" Then
            Me.TextBox77.Text = "M"
        End If
        If Me.TextBox76.Text = "13" Then
            Me.TextBox77.Text = "N"
        End If
        If Me.TextBox76.Text = "14" Then
            Me.TextBox77.Text = "O"
        End If
        If Me.TextBox76.Text = "15" Then
            Me.TextBox77.Text = "P"
        End If
        If Me.TextBox76.Text = "16" Then
            Me.TextBox77.Text = "Q"
        End If
        If Me.TextBox76.Text = "17" Then
            Me.TextBox77.Text = "R"
        End If
        If Me.TextBox76.Text = "18" Then
            Me.TextBox77.Text = "S"
        End If
        If Me.TextBox76.Text = "19" Then
            Me.TextBox77.Text = "T"
        End If
        If Me.TextBox76.Text = "20" Then
            Me.TextBox77.Text = "U"
        End If
        If Me.TextBox76.Text = "21" Then
            Me.TextBox77.Text = "V"
        End If
        If Me.TextBox76.Text = "22" Then
            Me.TextBox77.Text = "W"
        End If
        If Me.TextBox76.Text = "23" Then
            Me.TextBox77.Text = "X"
        End If
        If Me.TextBox76.Text = "24" Then
            Me.TextBox77.Text = "Y"
        End If
        If Me.TextBox76.Text = "25" Then
            Me.TextBox77.Text = "Z"
        End If
       
        BBAN_Original = Me.TextBox77.Text & BankIdentityInput.Replace(" ", "") & BranchIdentityInput.Replace(" ", "") & AccountNrInput.Replace("_", "") & Me.CountryCodeTextEdit.Text
        BBAN_Original = RTrim(BBAN_Original)


        Dim s As String = BBAN_Original

        s = s.Replace("A", "10")
        s = s.Replace("B", "11")
        s = s.Replace("C", "12")
        s = s.Replace("D", "13")
        s = s.Replace("E", "14")
        s = s.Replace("F", "15")
        s = s.Replace("G", "16")
        s = s.Replace("H", "17")
        s = s.Replace("I", "18")
        s = s.Replace("J", "19")
        s = s.Replace("K", "20")
        s = s.Replace("L", "21")
        s = s.Replace("M", "22")
        s = s.Replace("N", "23")
        s = s.Replace("O", "24")
        s = s.Replace("P", "25")
        s = s.Replace("Q", "26")
        s = s.Replace("R", "27")
        s = s.Replace("S", "28")
        s = s.Replace("T", "29")
        s = s.Replace("U", "30")
        s = s.Replace("V", "31")
        s = s.Replace("W", "32")
        s = s.Replace("X", "33")
        s = s.Replace("Y", "34")
        s = s.Replace("Z", "35")


        BBAN_Numeric = BigInteger.Parse(s & "00")

        Dim ans As BigInteger = 98 - BigInteger.ModPow(BBAN_Numeric, 1, 97)

        Dim DifferenceModulus As Decimal = ans
        If DifferenceModulus < 10 Then
            CheckDigit = "0" & DifferenceModulus
        Else
            CheckDigit = DifferenceModulus
        End If
        Me.CalculatedIBAN_ButtonEdit.Text = Me.CountryCodeTextEdit.Text & CheckDigit & Me.TextBox77.Text & BankIdentityInput.Replace(" ", "") & BranchIdentityInput.Replace(" ", "") & AccountNrInput.Replace("_", "")

    End Sub

    Private Sub IBAN_CALCULATION_ITA_TEST()
        'Dim ABI_Number As Integer = BankIdentityInput
        Dim ABI_Text As String = BankIdentityInput
        Dim ABI_CHARS() As Char = ABI_Text.ToCharArray
        Dim ABI_CHARS_ARRAY As Array = ABI_CHARS

        Dim CAB_Text As String = BranchIdentityInput
        Dim CAB_CHARS() As Char = CAB_Text.ToCharArray
        Dim CAB_CHARS_ARRAY As Array = CAB_CHARS

        Dim ACC_UNGERADE_Text As String = AccountNrInput
        Dim ACC_UNGERADE_CHARS() As Char = ACC_UNGERADE_Text.ToCharArray
        Dim ACC_UNGERADE_CHARS_ARRAY As Array = ACC_UNGERADE_CHARS

        Dim ACC_GERADE_Text As String = AccountNrInput
        Dim ACC_GERADE_CHARS() As Char = ACC_GERADE_Text.ToCharArray
        Dim ACC_GERADE_CHARS_ARRAY As Array = ACC_GERADE_CHARS

        Dim ReplaceString As String() = {"1", "0", "5", "7", "9", "13", "15", "17", "19", "21"}
        Dim ReplaceStringACCOUNT_UNGERADE As String() = {"1", "0", "5", "7", "9", "13", "15", "17", "19", "21", "2", "4", "18", "20", "11", "3", "6", "8", "12", "14", "16", "10", "22", "25", "24", "23"}
        Dim ReplaceStringACCOUNT_GERADE As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"}

        For i = 0 To 4
            Dim SearchString As String = Nothing
            'ABI
            SearchString = ABI_CHARS(i).ToString()
            Select Case SearchString
                Case Is = "0"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(0))
                    Exit Select
                Case Is = "1"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(1))
                    Exit Select
                Case Is = "2"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(2))
                    Exit Select
                Case Is = "3"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(3))
                    Exit Select
                Case Is = "4"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(4))
                    Exit Select
                Case Is = "5"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(5))
                    Exit Select
                Case Is = "6"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(6))
                    Exit Select
                Case Is = "7"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(7))
                    Exit Select
                Case Is = "8"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(8))
                    Exit Select
                Case Is = "9"
                    ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(SearchString, ReplaceString(9))
                    Exit Select
            End Select
            'CAB
            SearchString = CAB_CHARS(i).ToString()
            Select Case SearchString
                Case Is = "0"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(0))
                    Exit Select
                Case Is = "1"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(1))
                    Exit Select
                Case Is = "2"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(2))
                    Exit Select
                Case Is = "3"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(3))
                    Exit Select
                Case Is = "4"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(4))
                    Exit Select
                Case Is = "5"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(5))
                    Exit Select
                Case Is = "6"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(6))
                    Exit Select
                Case Is = "7"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(7))
                    Exit Select
                Case Is = "8"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(8))
                    Exit Select
                Case Is = "9"
                    CAB_CHARS(i) = CAB_CHARS(i).ToString.Replace(SearchString, ReplaceString(9))
                    Exit Select
            End Select
        Next
        'MsgBox(ABI_CHARS(0) & ABI_CHARS(2) & ABI_CHARS(4) & CAB_CHARS(1) & CAB_CHARS(3))

        For i = 0 To 11
            'ACC UNGERADE
            Dim SearchString As String = Nothing
            SearchString = ACC_UNGERADE_CHARS(i).ToString

            Select Case SearchString
                Case Is = "0"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(0))
                    Exit Select
                Case Is = "A"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(0))
                    Exit Select
                Case Is = "1"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(1))
                    Exit Select
                Case Is = "B"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(1))
                    Exit Select
                Case Is = "2"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(2))
                    Exit Select
                Case Is = "C"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(2))
                    Exit Select
                Case Is = "3"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(3))
                    Exit Select
                Case Is = "D"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(3))
                    Exit Select
                Case Is = "4"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(4))
                    Exit Select
                Case Is = "E"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(4))
                    Exit Select
                Case Is = "5"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(5))
                    Exit Select
                Case Is = "F"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(5))
                    Exit Select
                Case Is = "6"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(6))
                    Exit Select
                Case Is = "G"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(6))
                    Exit Select
                Case Is = "7"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(7))
                    Exit Select
                Case Is = "H"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(7))
                    Exit Select
                Case Is = "8"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(8))
                    Exit Select
                Case Is = "I"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(8))
                    Exit Select
                Case Is = "9"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(9))
                    Exit Select
                Case Is = "J"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(9))
                    Exit Select
                Case Is = "K"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(10))
                    Exit Select
                Case Is = "L"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(11))
                    Exit Select
                Case Is = "M"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(12))
                    Exit Select
                Case Is = "N"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(13))
                    Exit Select
                Case Is = "O"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(14))
                    Exit Select
                Case Is = "P"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(15))
                    Exit Select
                Case Is = "Q"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(16))
                    Exit Select
                Case Is = "R"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(17))
                    Exit Select
                Case Is = "S"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(18))
                    Exit Select
                Case Is = "T"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(19))
                    Exit Select
                Case Is = "U"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(20))
                    Exit Select
                Case Is = "V"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(21))
                    Exit Select
                Case Is = "W"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(22))
                    Exit Select
                Case Is = "X"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(23))
                    Exit Select
                Case Is = "Y"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(24))
                    Exit Select
                Case Is = "Z"
                    ACC_UNGERADE_CHARS(i) = ACC_UNGERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_UNGERADE(25))
                    Exit Select
            End Select

            'ACC GERADE

            SearchString = ACC_GERADE_CHARS(i).ToString()
            Select Case SearchString
                Case Is = "0"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(0))
                    Exit Select
                Case Is = "A"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(0))
                    Exit Select
                Case Is = "1"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(1))
                    Exit Select
                Case Is = "B"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(1))
                    Exit Select
                Case Is = "2"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(2))
                    Exit Select
                Case Is = "C"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(2))
                    Exit Select
                Case Is = "3"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(3))
                    Exit Select
                Case Is = "D"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(3))
                    Exit Select
                Case Is = "4"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(4))
                    Exit Select
                Case Is = "E"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(4))
                    Exit Select
                Case Is = "5"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(5))
                    Exit Select
                Case Is = "F"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(5))
                    Exit Select
                Case Is = "6"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(6))
                    Exit Select
                Case Is = "G"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(6))
                    Exit Select
                Case Is = "7"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(7))
                    Exit Select
                Case Is = "H"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(7))
                    Exit Select
                Case Is = "8"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(8))
                    Exit Select
                Case Is = "I"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(8))
                    Exit Select
                Case Is = "9"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(9))
                    Exit Select
                Case Is = "J"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(9))
                    Exit Select
                Case Is = "K"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(10))
                    Exit Select
                Case Is = "L"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(11))
                    Exit Select
                Case Is = "M"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(12))
                    Exit Select
                Case Is = "N"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(13))
                    Exit Select
                Case Is = "O"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(14))
                    Exit Select
                Case Is = "P"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(15))
                    Exit Select
                Case Is = "Q"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(16))
                    Exit Select
                Case Is = "R"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(17))
                    Exit Select
                Case Is = "S"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(18))
                    Exit Select
                Case Is = "T"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(19))
                    Exit Select
                Case Is = "U"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(20))
                    Exit Select
                Case Is = "V"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(21))
                    Exit Select
                Case Is = "W"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(22))
                    Exit Select
                Case Is = "X"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(23))
                    Exit Select
                Case Is = "Y"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(24))
                    Exit Select
                Case Is = "Z"
                    ACC_GERADE_CHARS(i) = ACC_GERADE_CHARS(i).ToString.Replace(SearchString, ReplaceStringACCOUNT_GERADE(25))
                    Exit Select
            End Select
        Next
        MsgBox("ACC." & vbNewLine & ACC_GERADE_CHARS(11).ToString & vbNewLine & ACC_UNGERADE_CHARS(10).ToString & vbNewLine & ACC_GERADE_CHARS(9).ToString & vbNewLine & ACC_UNGERADE_CHARS(8).ToString & vbNewLine & ACC_GERADE_CHARS(7).ToString & vbNewLine & ACC_UNGERADE_CHARS(6).ToString & vbNewLine & ACC_GERADE_CHARS(5).ToString & vbNewLine & ACC_UNGERADE_CHARS(4).ToString & vbNewLine & ACC_GERADE_CHARS(3).ToString & vbNewLine & ACC_UNGERADE_CHARS(2).ToString & vbNewLine & ACC_GERADE_CHARS(1).ToString & vbNewLine & ACC_UNGERADE_CHARS(0).ToString & vbNewLine & "ABI" & vbNewLine & ABI_CHARS(0).ToString & vbNewLine & ABI_CHARS(1).ToString & vbNewLine & ABI_CHARS(2).ToString & vbNewLine & ABI_CHARS(3).ToString & vbNewLine & ABI_CHARS(4).ToString & vbNewLine & "CAB" & vbNewLine & CAB_CHARS(0).ToString & vbNewLine & CAB_CHARS(1).ToString & vbNewLine & CAB_CHARS(2).ToString & vbNewLine & CAB_CHARS(3).ToString & vbNewLine & CAB_CHARS(4).ToString)

        'MODULO 26 - CHECK LETTER in IBAN
        Dim SumForModulo26 As Decimal = ACC_GERADE_CHARS(11).ToString * 1 + ACC_UNGERADE_CHARS(10).ToString * 1 + ACC_GERADE_CHARS(9).ToString * 1 + ACC_UNGERADE_CHARS(8).ToString * 1 + ACC_GERADE_CHARS(7).ToString * 1 + ACC_UNGERADE_CHARS(6).ToString * 1 + ACC_GERADE_CHARS(5).ToString * 1 + ACC_UNGERADE_CHARS(4).ToString * 1 + ACC_GERADE_CHARS(3).ToString * 1 + ACC_UNGERADE_CHARS(2).ToString * 1 + ACC_GERADE_CHARS(1).ToString * 1 + ACC_UNGERADE_CHARS(0).ToString * 1 + ABI_CHARS(0).ToString * 1 + ABI_CHARS(1).ToString * 1 + ABI_CHARS(2).ToString * 1 + ABI_CHARS(3).ToString * 1 + ABI_CHARS(4).ToString * 1 + CAB_CHARS(0).ToString * 1 + CAB_CHARS(1).ToString * 1 + CAB_CHARS(2).ToString * 1 + CAB_CHARS(3).ToString * 1 + CAB_CHARS(4).ToString * 1
        MsgBox(SumForModulo26)
        Dim Modulo26Result As Decimal = SumForModulo26 Mod 26
        Dim Test As Decimal = CDec(Val(ACC_GERADE_CHARS(11).ToString)) + CDec(Val(ACC_UNGERADE_CHARS(10).ToString)) + CDec(Val(ACC_GERADE_CHARS(9).ToString)) + CDec(Val(ACC_UNGERADE_CHARS(8).ToString)) + CDec(Val(ACC_GERADE_CHARS(7).ToString)) + CDec(Val(ACC_UNGERADE_CHARS(6).ToString)) + CDec(Val(ACC_GERADE_CHARS(5).ToString)) + CDec(Val(ACC_UNGERADE_CHARS(4).ToString)) + CDec(Val(ACC_GERADE_CHARS(3).ToString)) + CDec(Val(ACC_UNGERADE_CHARS(2).ToString)) + CDec(Val(ACC_GERADE_CHARS(1).ToString)) + CDec(Val(ACC_UNGERADE_CHARS(0).ToString)) + CDec(Val(ABI_CHARS(0).ToString)) + CDec(Val(ABI_CHARS(1).ToString)) + CDec(Val(ABI_CHARS(2).ToString)) + CDec(Val(ABI_CHARS(3).ToString)) + CDec(Val(ABI_CHARS(4).ToString)) + CDec(Val(CAB_CHARS(0).ToString)) + CDec(Val(CAB_CHARS(1).ToString)) + CDec(Val(CAB_CHARS(2).ToString)) + CDec(Val(CAB_CHARS(3).ToString)) + CDec(Val(CAB_CHARS(4).ToString))
        MsgBox(Test)
        Dim s As String = Modulo26Result

        s = s.Replace("0", "A")
        s = s.Replace("1", "B")
        s = s.Replace("2", "C")
        s = s.Replace("3", "D")
        s = s.Replace("4", "E")
        s = s.Replace("5", "F")
        s = s.Replace("6", "G")
        s = s.Replace("7", "H")
        s = s.Replace("8", "I")
        s = s.Replace("9", "J")
        s = s.Replace("10", "K")
        s = s.Replace("11", "L")
        s = s.Replace("12", "M")
        s = s.Replace("13", "N")
        s = s.Replace("14", "O")
        s = s.Replace("15", "P")
        s = s.Replace("16", "Q")
        s = s.Replace("17", "R")
        s = s.Replace("18", "S")
        s = s.Replace("19", "T")
        s = s.Replace("20", "U")
        s = s.Replace("21", "V")
        s = s.Replace("22", "W")
        s = s.Replace("23", "X")
        s = s.Replace("24", "Y")
        s = s.Replace("25", "Z")
        MsgBox(s)
        'MsgBox(ACC_UNGERADE_CHARS(0) & ACC_UNGERADE_CHARS(2) & ACC_UNGERADE_CHARS(4) & ACC_UNGERADE_CHARS(6) & ACC_UNGERADE_CHARS(8) & ACC_UNGERADE_CHARS(10))
        'MsgBox(ACC_GERADE_CHARS(1) & ACC_GERADE_CHARS(3) & ACC_GERADE_CHARS(5) & ACC_GERADE_CHARS(7) & ACC_GERADE_CHARS(9) & ACC_GERADE_CHARS(11))
        'For i = 0 To 4
        'For y = 0 To 9
        'Dim SearchString As String = y
        'ABI_CHARS(i) = ABI_CHARS(i).ToString.Replace(y, ReplaceString(y))
        'Next
        'Next

    End Sub
    Private Function ReplaceSpl(ByVal originalText As String, ByVal oldArr() As String, ByVal newArr() As String)
        For i As Integer = 0 To oldArr.Length

            originalText = originalText.Replace(oldArr(i), newArr(i))

        Next

        Return originalText

    End Function


    Private Sub IBAN_BANK()
        cmd.CommandText = "SELECT * from [IBANSTRUCTURE_FULL_DIR] where [IBAN COUNTRY CODE]='" & CountryCodeTextEdit.Text & "'"
        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then

            Dim BankIdentifierPosition As String = dt.Rows.Item(0).Item("BANK IDENTIFIER POSITION")
            Dim BankIdentifierLenght As String = dt.Rows.Item(0).Item("IBAN NATIONAL ID LENGTH")

            Dim IBAN_NATIONAL_ID As String = Microsoft.VisualBasic.Mid(Me.CalculatedIBAN_ButtonEdit.Text, BankIdentifierPosition, BankIdentifierLenght)
            cmd.CommandText = "SELECT * from [IBANPLUS_FULL_DIR] where [IBAN NATIONAL ID]='" & IBAN_NATIONAL_ID & "' and [ISO COUNTRY CODE]='" & CountryCodeTextEdit.Text & "'"
            Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt1 As New DataTable
            da1.Fill(dt1)
            Dim BankBic As String = "+++ No BIC Code fund! +++"
            Dim BankName As String = "+++ No Bank Name fund! +++"
            If dt1.Rows.Count > 0 Then
                BankBic = dt1.Rows.Item(0).Item("IBAN BIC")
                BankName = dt1.Rows.Item(0).Item("INSTITUTION NAME")
            End If
            Me.IBAN_BIC_lbl.Text = BankBic
            Me.IBAN_BANK_lbl.Text = BankName

        End If

    End Sub

    Private Sub IbanCountries_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub IbanCountries_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CalculatedIBAN_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CalculatedIBAN_ButtonEdit.ButtonClick
        If e.Button.Caption = "Print" AndAlso Me.CountryCodeTextEdit.Text <> "" Then
            Me.IBAN_Calculate_Button_LayoutControlItem.Visibility = LayoutVisibility.Never
            Me.Calculated_IBAN_LayoutControlItem.Visibility = LayoutVisibility.Never
            Me.IBAN_CALC_Label_LayoutControlItem.Visibility = LayoutVisibility.Always
            Me.IBAN_BANK_lbl.ForeColor = Color.Navy
            Me.IBAN_BIC_lbl.ForeColor = Color.Navy
            Me.IBAN_CALC_Label.ForeColor = Color.Navy
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
            Me.IBAN_Calculate_Button_LayoutControlItem.Visibility = LayoutVisibility.Always
            Me.Calculated_IBAN_LayoutControlItem.Visibility = LayoutVisibility.Always
            Me.IBAN_CALC_Label_LayoutControlItem.Visibility = LayoutVisibility.Never
            Me.IBAN_BANK_lbl.ForeColor = Color.Cyan
            Me.IBAN_BIC_lbl.ForeColor = Color.Cyan
            Me.IBAN_CALC_Label.ForeColor = Color.Cyan

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
        Dim reportfooter As String = "IBAN CALCULATION" '& vbNewLine & "Printed on: " & Now

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub
    
   

    Private Sub CalculatedIBAN_ButtonEdit_TextChanged(sender As Object, e As EventArgs) Handles CalculatedIBAN_ButtonEdit.TextChanged
        Me.IBAN_CALC_Label.Text = Me.CalculatedIBAN_ButtonEdit.Text
    End Sub

    Private Sub SearchLookUpEdit1View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SearchLookUpEdit1View.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SearchLookUpEdit1View_ShownEditor(sender As Object, e As EventArgs) Handles SearchLookUpEdit1View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub
End Class