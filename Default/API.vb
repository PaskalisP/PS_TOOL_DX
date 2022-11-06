Imports System.Runtime.InteropServices

Public Class API

    ' Window - Management
    Public Declare Function GetDesktopWindow Lib "user32.dll" () _
      As IntPtr

    Public Declare Function GetTopWindow Lib "user32.dll" _
      (ByVal hWnd As IntPtr) As IntPtr

    Public Declare Unicode Function GetWindowText Lib "user32.dll" _
      Alias "GetWindowTextW" (ByVal hWnd As IntPtr, _
      ByVal text As String, ByVal nMaxCount As Integer) As Integer

    Public Declare Function GetWindow Lib "user32.dll" ( _
      ByVal hWnd As IntPtr, ByVal uCmd As Integer) As IntPtr

    Public Declare Function GetForegroundWindow Lib "user32.dll" () _
      As IntPtr

    Public Declare Function SetForegroundWindow Lib "user32.dll" _
      (ByVal hwnd As IntPtr) As Boolean

    Public Declare Function GetWindowRect Lib "user32.dll" _
      (ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Int32

    Public Declare Function ShowWindow Lib "user32.dll" _
      (ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Boolean

    Public Declare Auto Function IsIconic Lib "user32.dll" _
      (ByVal hwnd As IntPtr) As Boolean

    Public Declare Auto Function IsZoomed Lib "user32.dll" _
      (ByVal hwnd As IntPtr) As Boolean

    Public Enum ShowWindowConstants
        SW_HIDE = 0
        SW_SHOWNORMAL = 1
        SW_NORMAL = 1
        SW_SHOWMINIMIZED = 2
        SW_SHOWMAXIMIZED = 3
        SW_MAXIMIZE = 3
        SW_SHOWNOACTIVATE = 4
        SW_SHOW = 5
        SW_MINIMIZE = 6
        SW_SHOWMINNOACTIVE = 7
        SW_SHOWNA = 8
        SW_RESTORE = 9
        SW_SHOWDEFAULT = 10
        SW_FORCEMINIMIZE = 11
        SW_MAX = 11
    End Enum

    Public Declare Function GetWindowInfo Lib "user32.dll" _
      (ByVal hwnd As IntPtr, ByRef pwi As WINDOWINFO) As Boolean

    Public Structure WINDOWINFO
        Public cbSize As Int32
        Public rcWindow As RECT
        Public rcClient As RECT
        Public dwStyle As Int32
        Public dwExStyle As Int32
        Public dwWindowStatus As Int32
        Public cxWindowBorders As Int32
        Public cyWindowBorders As Int32
    End Structure

    Public Declare Function ScreenToClient Lib "user32.dll" _
      (ByVal hWnd As IntPtr, ByRef lpPoint As POINTAPI) As Int32

    Public Enum GetWindowConstants
        GW_HWNDFIRST = 0
        GW_HWNDLAST = 1
        GW_HWNDNEXT = 2
        GW_HWNDPREV = 3
        GW_OWNER = 4
        GW_CHILD = 5
    End Enum

    ' Device Context
    Public Declare Function GetDC Lib "user32.dll" _
      (ByVal hWnd As IntPtr) As IntPtr

    Public Declare Function ReleaseDC Lib "user32.dll" _
      (ByVal hWnd As IntPtr, ByVal hdc As IntPtr) As Int32

    ' GDI-Funktionen
    Public Declare Function StretchBlt Lib "gdi32.dll" _
      (ByVal hdc As IntPtr, ByVal x As Int32, ByVal y As Int32, _
      ByVal nWidth As Int32, ByVal nHeight As Int32, _
      ByVal hSrcDC As IntPtr, ByVal xSrc As Int32, _
      ByVal ySrc As Int32, ByVal nSrcWidth As Int32, _
      ByVal nSrcHeight As Int32, ByVal dwRop As Int32) As Int32

    Public Declare Function BitBlt Lib "gdi32.dll" _
      (ByVal hdc As IntPtr, ByVal x As Int32, ByVal y As Int32, _
      ByVal nWidth As Int32, ByVal nHeight As Int32, _
      ByVal hSrcDC As IntPtr, ByVal xSrc As Int32, _
      ByVal ySrc As Int32, ByVal dwRop As Int32) As Int32

    Public Declare Auto Function SelectObject Lib "gdi32.dll" _
      (ByVal hdc As IntPtr, ByVal hgdiobj As IntPtr) As IntPtr

    Public Declare Auto Function PathCompactPath Lib "shlwapi.dll" _
      (ByVal hDC As IntPtr, ByVal pszPath As _
      System.Text.StringBuilder, ByVal dx As Integer) As Boolean

    Public Declare Function GetDeviceCaps Lib "gdi32.dll" _
      (ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer

    Public Enum GetDeviceCapsConstants
        TECHNOLOGY = 2
        HORZSIZE = 4
        VERTSIZE = 6
        HORZRES = 8
        VERTRES = 10
        BITPIXEL = 12
    End Enum

    Public Structure POINTAPI
        Public x As Int32
        Public y As Int32
    End Structure

    Public Structure RECT
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32
    End Structure

    Public Enum ROPConstants
        SRCCOPY = &HCC0020
    End Enum


    ' Dateiinformationen wie Icons und Dateityp abfragen
    Public Declare Auto Function SHGetFileInfo Lib "shell32.dll" ( _
    ByVal pszPath As String, _
    ByVal dwFileAttributes As Integer, _
    ByRef psfi As SHFILEINFO, _
    ByVal cbFileInfo As Integer, _
    ByVal uFlags As Integer) _
    As IntPtr

    ' Datenstruktur SHFILEINFO für den Aufruf von SHGetFileInfo
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure SHFILEINFO
        Public hIcon As Int32
        Public iIcon As Int32
        Public dwAttributes As Int32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    ' Gebräuchliche Konstanten für SHGetFileInfo
    Public Enum SHGetFileInfoConstants
        SHGFI_TYPENAME = &H400
        SHGFI_ATTRIBUTES = &H800
        SHGFI_EXETYPE = &H2000
        SHGFI_LARGEICON = 0
        SHGFI_SMALLICON = 1
        SHGFI_ICON = &H100
    End Enum

    ' Benötigte Methode zur Freigabe eines Icon - Handles
    Public Declare Auto Function DestroyIcon _
      Lib "user32.dll" (ByVal hicon As IntPtr) As Boolean


    'SendMessage
    Public Declare Function SendMessage Lib "user32.dll" Alias _
      "SendMessageW" (ByVal hwnd As IntPtr, _
      ByVal message As Integer, ByVal wparam As IntPtr, _
      ByVal lparam As IntPtr) As Integer

    Public Declare Function SendMessage Lib "user32.dll" Alias _
       "SendMessageW" (ByVal hwnd As IntPtr, _
       ByVal message As Integer, ByVal wparam As Int32, _
       ByVal lparam As Int32) As Integer

    Public Declare Function SendMessageRef Lib "user32.dll" Alias _
      "SendMessageW" (ByVal hwnd As IntPtr, _
      ByVal message As Integer, ByVal wparam As Int32, _
      ByRef lparam As Int32) As Integer

    ' Konstanten für Multiline-TextBox
    Public Enum TBMultiline
        EM_GETLINECOUNT = &HBA
        EM_LINEFROMCHAR = &HC9
        EM_FMTLINES = &HC8
        EM_LINESCROLL = &HB6
        EM_GETMODIFY = &HB8
        EM_SETMODIFY = &HB9
        EM_LINEINDEX = &HBB
        EM_GETTHUMB = &HBE
        EM_SETTABSTOPS = &HCB
        EM_GETFIRSTVISIBLELINE = &HCE
        EM_POSFROMCHAR = &HD6
        EM_CHARFROMPOS = &HD7
    End Enum


    ' SHFileOperation für Dateioperationen mit Windows-Shell
    Public Declare Auto Function SHFileOperation Lib "shell32.dll" _
      (ByRef lpFileOp As SHFILEOPSTRUCT) As Integer

    ' Unterstützte Kommandos für SHFileOperation
    Public Enum SHFileOpConstants
        Move = 1
        Copy = 2
        Delete = 3
        Rename = 4
    End Enum

    ' Struktur für SHFileOperation
    <StructLayout(LayoutKind.Sequential, Pack:=1, _
    CharSet:=CharSet.Auto)> _
    Public Structure SHFILEOPSTRUCT
        Public hwnd As IntPtr
        Public wFunc As SHFileOpConstants
        Public pFrom As String
        Public pTo As String
        Public fFlags As SHFileOpFlagConstants
        Public fAnyOperationsAborted As Boolean
        Public hNameMappings As IntPtr
        Public lpszProgressTitle As String
    End Structure

    ' Flag-Definitionen für SHFileOperation
    <Flags()> Public Enum SHFileOpFlagConstants As Integer
        Multidestfiles = 1
        Confirmmouse = 2
        Silent = 4
        RenameOnCollision = &H8
        NoConfirmation = &H10
        WantMappingHandle = &H20
        AllowUndo = &H40
        FilesOnly = &H80
        SimpleProgress = &H100
        NoConfirmMakeDir = &H200
        NoErrorUI = &H400
        NoCopySecurityAttribs = &H800
    End Enum

    ' Verzeichnis-Funktionen
    Public Declare Auto Function PathRelativePathTo _
    Lib "shlwapi.dll" (ByVal relPath As System.Text.StringBuilder, _
    ByVal pathFrom As String, ByVal attrFrom As Integer, _
    ByVal pathTo As String, ByVal attrTo As Integer) As Boolean

    Public Declare Auto Function PathCanonicalize Lib "shlwapi.dll" _
      (ByVal dst As System.Text.StringBuilder, ByVal src As String) _
      As Boolean

    Public Enum FileAttribute
        [ReadOnly] = 1
        Hidden = 2
        System = 4
        Directory = &H10
        Archive = &H20
        Normal = &H80
        Temporary = &H100
    End Enum

    ' Sound-Ausgabe
    Public Declare Auto Function sndPlaySound Lib "Winmm.dll" _
      (ByVal path As String, ByVal fuSound As SNDPlaySoundConstants) _
      As Boolean

    <Flags()> Public Enum SNDPlaySoundConstants
        Async = 1
        [Loop] = 8
        Memory = 4
        NoDefault = 2
        NoStop = &H10
        Sync = 0
    End Enum

    ' Abfragen von Zählerstand und Frequenz des Hardware-Counters
    Public Declare Auto Function QueryPerformanceCounter Lib _
      "Kernel32.dll" (ByRef performanceCount As Long) As Boolean

    Public Declare Auto Function QueryPerformanceFrequency Lib _
      "Kernel32.dll" (ByRef frequency As Long) As Boolean

    ' Fehlermeldungen
    Public Declare Auto Function FormatMessage Lib "kernel32.dll" _
      (ByVal dwFlags As Integer, ByVal lpSource As IntPtr, _
      ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, _
      ByVal lpBuffer As System.Text.StringBuilder, _
      ByVal nSize As Integer, ByVal Arguments() As String) As Integer


End Class
