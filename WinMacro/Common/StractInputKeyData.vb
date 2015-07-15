<Serializable> _
Public Class StractInputKeyData

#Region "プロパティ"

    ''' <summary>
    ''' キー動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KeyEvent As Win32API.KeyPlays

    ''' <summary>
    ''' キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Key As Integer

    ''' <summary>
    ''' キー動作名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property KeyEventName As String

        Get

            Return [Enum].GetName(GetType(Win32API.KeyPlays), KeyEvent)

        End Get

    End Property

    ''' <summary>
    ''' キー名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property KeyName As String

        Get

            Return KeyConst.GetKeyName(Key)

        End Get

    End Property

    ''' <summary>
    ''' インデックス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Index As Integer

#End Region
    
#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="key_event"></param>
    ''' <param name="key"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Public Sub New(key_event As Win32API.KeyPlays, key As Integer, index As Integer)

        Me.KeyEvent = key_event

        Me.Key = key

        Me.Index = index

    End Sub

#End Region
    
#Region "公開メソッド"

    ''' <summary>
    ''' キー入力実行
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Play()

        Win32API.KeyPlay(Me.Key, Me.KeyEvent)

    End Sub

#End Region

End Class

<Serializable> _
Public Class KeyConst

    Private Const VK_0 = &H30
    Private Const VK_1 = &H31
    Private Const VK_2 = &H32
    Private Const VK_3 = &H33
    Private Const VK_4 = &H34
    Private Const VK_5 = &H35
    Private Const VK_6 = &H36
    Private Const VK_7 = &H37
    Private Const VK_8 = &H38
    Private Const VK_9 = &H39
    Private Const VK_A = &H41
    Private Const VK_ACCEPT = &H1E
    Private Const VK_ADD = &H6B
    Private Const VK_APPS = &H5D
    Private Const VK_ATTN = &HF6
    Private Const VK_B = &H42
    Private Const VK_BACK = &H8
    Private Const VK_BROWSER_BACK = &HA6
    Private Const VK_BROWSER_FAVORITES = &HAB
    Private Const VK_BROWSER_FORWARD = &HA7
    Private Const VK_BROWSER_HOME = &HAC
    Private Const VK_BROWSER_REFRESH = &HA8
    Private Const VK_BROWSER_SEARCH = &HAA
    Private Const VK_BROWSER_STOP = &HA9
    Private Const VK_C = &H43
    Private Const VK_CANCEL = &H3
    Private Const VK_CAPITAL = &H14
    Private Const VK_CLEAR = &HC
    Private Const VK_CONTROL = &H11
    Private Const VK_CONVERT = &H1C
    Private Const VK_CRSEL = &HF7
    Private Const VK_D = &H44
    Private Const VK_DECIMAL = &H6E
    Private Const VK_DELETE = &H2E
    Private Const VK_DIVIDE = &H6F
    Private Const VK_DOWN = &H28
    Private Const VK_E = &H45
    Private Const VK_END = &H23
    Private Const VK_EREOF = &HF9
    Private Const VK_ESCAPE = &H1B
    Private Const VK_EXECUTE = &H2B
    Private Const VK_EXSEL = &HF8
    Private Const VK_F = &H46
    Private Const VK_F1 = &H70
    Private Const VK_F10 = &H79
    Private Const VK_F11 = &H7A
    Private Const VK_F12 = &H7B
    Private Const VK_F13 = &H7C
    Private Const VK_F14 = &H7D
    Private Const VK_F15 = &H7E
    Private Const VK_F16 = &H7F
    Private Const VK_F17 = &H80
    Private Const VK_F18 = &H81
    Private Const VK_F19 = &H82
    Private Const VK_F2 = &H71
    Private Const VK_F20 = &H83
    Private Const VK_F21 = &H84
    Private Const VK_F22 = &H85
    Private Const VK_F23 = &H86
    Private Const VK_F24 = &H87
    Private Const VK_F3 = &H72
    Private Const VK_F4 = &H73
    Private Const VK_F5 = &H74
    Private Const VK_F6 = &H75
    Private Const VK_F7 = &H76
    Private Const VK_F8 = &H77
    Private Const VK_F9 = &H78
    Private Const VK_FINAL = &H18
    Private Const VK_G = &H47
    Private Const VK_H = &H48
    Private Const VK_HELP = &H2F
    Private Const VK_HOME = &H24
    Private Const VK_I = &H49
    Private Const VK_INSERT = &H2D
    Private Const VK_J = &H4A
    Private Const VK_JUNJA = &H17
    Private Const VK_K = &H4B
    Private Const VK_KANA = &H15
    Private Const VK_KANJI = &H19
    Private Const VK_L = &H4C
    Private Const VK_LAUNCH_APP1 = &HB6
    Private Const VK_LAUNCH_APP2 = &HB7
    Private Const VK_LAUNCH_MAIL = &HB4
    Private Const VK_LAUNCH_MEDIA_SELECT = &HB5
    Private Const VK_LBUTTON = &H1
    Private Const VK_LCONTROL = &HA2
    Private Const VK_LEFT = &H25
    Private Const VK_LMENU = &HA4
    Private Const VK_LSHIFT = &HA0
    Private Const VK_LWIN = &H5B
    Private Const VK_M = &H4D
    Private Const VK_MBUTTON = &H4
    Private Const VK_MEDIA_NEXT_TRACK = &HB0
    Private Const VK_MEDIA_PLAY_PAUSE = &HB3
    Private Const VK_MEDIA_PREV_TRACK = &HB1
    Private Const VK_MEDIA_STOP = &HB2
    Private Const VK_MENU = &H12
    Private Const VK_MODECHANGE = &H1F
    Private Const VK_MULTIPLY = &H6A
    Private Const VK_N = &H4E
    Private Const VK_NEXT = &H22
    Private Const VK_NONAME = &HFC
    Private Const VK_NONCONVERT = &H1D
    Private Const VK_NUMLOCK = &H90
    Private Const VK_NUMPAD0 = &H60
    Private Const VK_NUMPAD1 = &H61
    Private Const VK_NUMPAD2 = &H62
    Private Const VK_NUMPAD3 = &H63
    Private Const VK_NUMPAD4 = &H64
    Private Const VK_NUMPAD5 = &H65
    Private Const VK_NUMPAD6 = &H66
    Private Const VK_NUMPAD7 = &H67
    Private Const VK_NUMPAD8 = &H68
    Private Const VK_NUMPAD9 = &H69
    Private Const VK_O = &H4F
    Private Const VK_OEM_1 = &HBA
    Private Const VK_OEM_102 = &HE2
    Private Const VK_OEM_2 = &HBF
    Private Const VK_OEM_3 = &HC0
    Private Const VK_OEM_4 = &HDB
    Private Const VK_OEM_5 = &HDC
    Private Const VK_OEM_6 = &HDD
    Private Const VK_OEM_7 = &HDE
    Private Const VK_OEM_8 = &HDF
    Private Const VK_OEM_CLEAR = &HFE
    Private Const VK_OEM_COMMA = &HBC
    Private Const VK_OEM_MINUS = &HBD
    Private Const VK_OEM_PERIOD = &HBE
    Private Const VK_OEM_PLUS = &HBB
    Private Const VK_P = &H50
    Private Const VK_PA1 = &HFD
    Private Const VK_PACKET = &HE7
    Private Const VK_PAUSE = &H13
    Private Const VK_PLAY = &HFA
    Private Const VK_PRINT = &H2A
    Private Const VK_PRIOR = &H21
    Private Const VK_PROCESSKEY = &HE5
    Private Const VK_Q = &H51
    Private Const VK_R = &H52
    Private Const VK_RBUTTON = &H2
    Private Const VK_RCONTROL = &HA3
    Private Const VK_RETURN = &HD
    Private Const VK_RIGHT = &H27
    Private Const VK_RMENU = &HA5
    Private Const VK_RSHIFT = &HA1
    Private Const VK_RWIN = &H5C
    Private Const VK_S = &H53
    Private Const VK_SCROLL = &H91
    Private Const VK_SELECT = &H29
    Private Const VK_SEPARATOR = &H6C
    Private Const VK_SHIFT = &H10
    Private Const VK_SLEEP = &H5F
    Private Const VK_SNAPSHOT = &H2C
    Private Const VK_SPACE = &H20
    Private Const VK_SUBTRACT = &H6D
    Private Const VK_T = &H54
    Private Const VK_TAB = &H9
    Private Const VK_U = &H55
    Private Const VK_UP = &H26
    Private Const VK_V = &H56
    Private Const VK_VOLUME_DOWN = &HAE
    Private Const VK_VOLUME_MUTE = &HAD
    Private Const VK_VOLUME_UP = &HAF
    Private Const VK_W = &H57
    Private Const VK_X = &H58
    Private Const VK_XBUTTON1 = &H5
    Private Const VK_XBUTTON2 = &H6
    Private Const VK_Y = &H59
    Private Const VK_Z = &H5A
    Private Const VK_ZOOM = &HFB

    Private Shared KeyList As New Dictionary(Of Integer, String)

    Public Shared Function GetKeyName(key As Integer) As String

        With KeyList

            If .Count = 0 Then

                .Add(VK_0, "0")
                .Add(VK_1, "1")
                .Add(VK_2, "2")
                .Add(VK_3, "3")
                .Add(VK_4, "4")
                .Add(VK_5, "5")
                .Add(VK_6, "6")
                .Add(VK_7, "7")
                .Add(VK_8, "8")
                .Add(VK_9, "9")
                .Add(VK_A, "A")
                .Add(VK_ACCEPT, "ACCEPT")
                .Add(VK_ADD, "ADD")
                .Add(VK_APPS, "APPS")
                .Add(VK_ATTN, "ATTN")
                .Add(VK_B, "B")
                .Add(VK_BACK, "BACK")
                .Add(VK_BROWSER_BACK, "BROWSER_BACK")
                .Add(VK_BROWSER_FAVORITES, "BROWSER_FAVORITES")
                .Add(VK_BROWSER_FORWARD, "BROWSER_FORWARD")
                .Add(VK_BROWSER_HOME, "BROWSER_HOME")
                .Add(VK_BROWSER_REFRESH, "BROWSER_REFRESH")
                .Add(VK_BROWSER_SEARCH, "BROWSER_SEARCH")
                .Add(VK_BROWSER_STOP, "BROWSER_STOP")
                .Add(VK_C, "C")
                .Add(VK_CANCEL, "CANCEL")
                .Add(VK_CAPITAL, "CAPITAL")
                .Add(VK_CLEAR, "CLEAR")
                .Add(VK_CONTROL, "CONTROL")
                .Add(VK_CONVERT, "CONVERT")
                .Add(VK_CRSEL, "CRSEL")
                .Add(VK_D, "D")
                .Add(VK_DECIMAL, "DECIMAL")
                .Add(VK_DELETE, "DELETE")
                .Add(VK_DIVIDE, "DIVIDE")
                .Add(VK_DOWN, "DOWN")
                .Add(VK_E, "E")
                .Add(VK_END, "END")
                .Add(VK_EREOF, "EREOF")
                .Add(VK_ESCAPE, "ESCAPE")
                .Add(VK_EXECUTE, "EXECUTE")
                .Add(VK_EXSEL, "EXSEL")
                .Add(VK_F, "F")
                .Add(VK_F1, "F1")
                .Add(VK_F10, "F10")
                .Add(VK_F11, "F11")
                .Add(VK_F12, "F12")
                .Add(VK_F13, "F13")
                .Add(VK_F14, "F14")
                .Add(VK_F15, "F15")
                .Add(VK_F16, "F16")
                .Add(VK_F17, "F17")
                .Add(VK_F18, "F18")
                .Add(VK_F19, "F19")
                .Add(VK_F2, "F2")
                .Add(VK_F20, "F20")
                .Add(VK_F21, "F21")
                .Add(VK_F22, "F22")
                .Add(VK_F23, "F23")
                .Add(VK_F24, "F24")
                .Add(VK_F3, "F3")
                .Add(VK_F4, "F4")
                .Add(VK_F5, "F5")
                .Add(VK_F6, "F6")
                .Add(VK_F7, "F7")
                .Add(VK_F8, "F8")
                .Add(VK_F9, "F9")
                .Add(VK_FINAL, "FINAL")
                .Add(VK_G, "G")
                .Add(VK_H, "H")
                .Add(VK_HELP, "HELP")
                .Add(VK_HOME, "HOME")
                .Add(VK_I, "I")
                .Add(VK_INSERT, "INSERT")
                .Add(VK_J, "J")
                .Add(VK_JUNJA, "JUNJA")
                .Add(VK_K, "K")
                .Add(VK_KANA, "KANA")
                .Add(VK_KANJI, "KANJI")
                .Add(VK_L, "L")
                .Add(VK_LAUNCH_APP1, "LAUNCH_APP1")
                .Add(VK_LAUNCH_APP2, "LAUNCH_APP2")
                .Add(VK_LAUNCH_MAIL, "LAUNCH_MAIL")
                .Add(VK_LAUNCH_MEDIA_SELECT, "LAUNCH_MEDIA_SELECT")
                .Add(VK_LBUTTON, "LBUTTON")
                .Add(VK_LCONTROL, "LCONTROL")
                .Add(VK_LEFT, "LEFT")
                .Add(VK_LMENU, "LMENU")
                .Add(VK_LSHIFT, "LSHIFT")
                .Add(VK_LWIN, "LWIN")
                .Add(VK_M, "M")
                .Add(VK_MBUTTON, "MBUTTON")
                .Add(VK_MEDIA_NEXT_TRACK, "MEDIA_NEXT_TRACK")
                .Add(VK_MEDIA_PLAY_PAUSE, "MEDIA_PLAY_PAUSE")
                .Add(VK_MEDIA_PREV_TRACK, "MEDIA_PREV_TRACK")
                .Add(VK_MEDIA_STOP, "MEDIA_STOP")
                .Add(VK_MENU, "MENU")
                .Add(VK_MODECHANGE, "MODECHANGE")
                .Add(VK_MULTIPLY, "MULTIPLY")
                .Add(VK_N, "N")
                .Add(VK_NEXT, "NEXT")
                .Add(VK_NONAME, "NONAME")
                .Add(VK_NONCONVERT, "NONCONVERT")
                .Add(VK_NUMLOCK, "NUMLOCK")
                .Add(VK_NUMPAD0, "NUMPAD0")
                .Add(VK_NUMPAD1, "NUMPAD1")
                .Add(VK_NUMPAD2, "NUMPAD2")
                .Add(VK_NUMPAD3, "NUMPAD3")
                .Add(VK_NUMPAD4, "NUMPAD4")
                .Add(VK_NUMPAD5, "NUMPAD5")
                .Add(VK_NUMPAD6, "NUMPAD6")
                .Add(VK_NUMPAD7, "NUMPAD7")
                .Add(VK_NUMPAD8, "NUMPAD8")
                .Add(VK_NUMPAD9, "NUMPAD9")
                .Add(VK_O, "O")
                .Add(VK_OEM_1, "OEM_1")
                .Add(VK_OEM_102, "OEM_102")
                .Add(VK_OEM_2, "OEM_2")
                .Add(VK_OEM_3, "OEM_3")
                .Add(VK_OEM_4, "OEM_4")
                .Add(VK_OEM_5, "OEM_5")
                .Add(VK_OEM_6, "OEM_6")
                .Add(VK_OEM_7, "OEM_7")
                .Add(VK_OEM_8, "OEM_8")
                .Add(VK_OEM_CLEAR, "OEM_CLEAR")
                .Add(VK_OEM_COMMA, "OEM_COMMA")
                .Add(VK_OEM_MINUS, "OEM_MINUS")
                .Add(VK_OEM_PERIOD, "OEM_PERIOD")
                .Add(VK_OEM_PLUS, "OEM_PLUS")
                .Add(VK_P, "P")
                .Add(VK_PA1, "PA1")
                .Add(VK_PACKET, "PACKET")
                .Add(VK_PAUSE, "PAUSE")
                .Add(VK_PLAY, "PLAY")
                .Add(VK_PRINT, "PRINT")
                .Add(VK_PRIOR, "PRIOR")
                .Add(VK_PROCESSKEY, "PROCESSKEY")
                .Add(VK_Q, "Q")
                .Add(VK_R, "R")
                .Add(VK_RBUTTON, "RBUTTON")
                .Add(VK_RCONTROL, "RCONTROL")
                .Add(VK_RETURN, "RETURN")
                .Add(VK_RIGHT, "RIGHT")
                .Add(VK_RMENU, "RMENU")
                .Add(VK_RSHIFT, "RSHIFT")
                .Add(VK_RWIN, "RWIN")
                .Add(VK_S, "S")
                .Add(VK_SCROLL, "SCROLL")
                .Add(VK_SELECT, "SELECT")
                .Add(VK_SEPARATOR, "SEPARATOR")
                .Add(VK_SHIFT, "SHIFT")
                .Add(VK_SLEEP, "SLEEP")
                .Add(VK_SNAPSHOT, "SNAPSHOT")
                .Add(VK_SPACE, "SPACE")
                .Add(VK_SUBTRACT, "SUBTRACT")
                .Add(VK_T, "T")
                .Add(VK_TAB, "TAB")
                .Add(VK_U, "U")
                .Add(VK_UP, "UP")
                .Add(VK_V, "V")
                .Add(VK_VOLUME_DOWN, "VOLUME_DOWN")
                .Add(VK_VOLUME_MUTE, "VOLUME_MUTE")
                .Add(VK_VOLUME_UP, "VOLUME_UP")
                .Add(VK_W, "W")
                .Add(VK_X, "X")
                .Add(VK_XBUTTON1, "XBUTTON1")
                .Add(VK_XBUTTON2, "XBUTTON2")
                .Add(VK_Y, "Y")
                .Add(VK_Z, "Z")
                .Add(VK_ZOOM, "ZOOM")

            End If

            Dim result As String = String.Empty

            If KeyList.TryGetValue(key, result) Then

                Return result

            Else

                Return "未知のKey:" & key.ToString

            End If

        End With

    End Function


End Class
