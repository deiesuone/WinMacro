Imports System.Runtime.InteropServices

Public Class Win32API

#Region "定数"

    Public Const INPUT_MOUSE = 0
    Public Const INPUT_KEYBOARD = 1
    Public Const INPUT_HARDWARE = 2
    Public Const MOUSEEVENTF_MOVE = &H1
    Public Const MOUSEEVENTF_ABSOLUTE = &H8000
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Public Const MOUSEEVENTF_RIGHTDOWN = &H8
    Public Const MOUSEEVENTF_RIGHTUP = &H10
    Public Const MOUSEEVENTF_MIDDLEDOWN = &H20
    Public Const MOUSEEVENTF_MIDDLEUP = &H40
    Public Const MOUSEEVENTF_WHEEL = &H800
    Public Const WHEEL_DELTA = 120
    Public Const KEYEVENTF_KEYDOWN = &H0
    Public Const KEYEVENTF_KEYUP = &H2
    Public Const KEYEVENTF_EXTENDEDKEY = &H1
    Public Const VK_SHIFT = &H10
    Public Const SM_CYCAPTION = 4
    Public Const SM_CXFRAME = 32
    Public Const SM_CYFRAME = 33
    Public Const SM_CYMENU = 15
    Public Const SM_CXSCREEN = 0
    Public Const SM_CYSCREEN = 1

#End Region

#Region "構造体"

    ''' <summary>
    ''' 四角
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    ''' <summary>
    ''' マウスイベント
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    ''' <summary>
    ''' キーボードイベント
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    ''' <summary>
    ''' ハードウェアイベント
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    ''' <summary>
    ''' SetInput用各種イベント
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Explicit)> _
    Public Structure INPUT
        <FieldOffset(0)> Public type As Integer
        <FieldOffset(4)> Public mi As MOUSEINPUT
        <FieldOffset(4)> Public ki As KEYBDINPUT
        <FieldOffset(4)> Public hi As HARDWAREINPUT
    End Structure

#End Region

#Region "Enum"

    ''' <summary>
    ''' マウスのボタン
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum MouseButtons

        ''' <summary>
        ''' 左
        ''' </summary>
        ''' <remarks></remarks>
        Left

        ''' <summary>
        ''' ホイール
        ''' </summary>
        ''' <remarks></remarks>
        Middle

        ''' <summary>
        ''' 右
        ''' </summary>
        ''' <remarks></remarks>
        Right

    End Enum

    ''' <summary>
    ''' キーボード動作
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum KeyPlays

        ''' <summary>
        ''' 離し
        ''' </summary>
        ''' <remarks></remarks>
        Up

        ''' <summary>
        ''' 押し
        ''' </summary>
        ''' <remarks></remarks>
        Down

    End Enum

    ''' <summary>
    ''' ドラッグ動作
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DragPlays

        ''' <summary>
        ''' 開始
        ''' </summary>
        ''' <remarks></remarks>
        DragStart

        ''' <summary>
        ''' 終了
        ''' </summary>
        ''' <remarks></remarks>
        DragEnd

    End Enum

    ''' <summary>
    ''' ドラッグ動作
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum WheelMoves

        ''' <summary>
        ''' 上方向
        ''' </summary>
        ''' <remarks></remarks>
        Up

        ''' <summary>
        ''' 下方向
        ''' </summary>
        ''' <remarks></remarks>
        Down

    End Enum

#End Region

#Region "静的メソッド"

    ''' <summary>
    ''' 現在座標を取得する
    ''' </summary>
    ''' <param name="lpPoint"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="GetCursorPos")> _
    Public Shared Function GetCursorPos(ByRef lpPoint As System.Drawing.Point) As Int32
    End Function

    ''' <summary>
    ''' 指定座標を設定する
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="SetCursorPos")> _
    Public Shared Function SetCursorPos(ByVal X As Integer, ByVal Y As Integer) As Boolean
    End Function

    ''' <summary>
    ''' 指定座標におけるウィンドウハンドルを取得する
    ''' </summary>
    ''' <param name="lpPoint"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="WindowFromPoint")> _
    Public Shared Function WindowFromPoint(ByVal lpPoint As System.Drawing.Point) As IntPtr
    End Function

    ''' <summary>
    ''' 指定座標におけるウィンドウハンドルを取得する
    ''' </summary>
    ''' <param name="xPoint"></param>
    ''' <param name="yPoint"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="WindowFromPoint")> _
    Public Shared Function WindowFromPoint(ByVal xPoint As Integer, ByVal yPoint As Integer) As IntPtr
    End Function

    ''' <summary>
    ''' 指定ウィンドウハンドルにおけるウィンドウのデバイスコンテキストを取得する
    ''' </summary>
    ''' <param name="hwnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="GetWindowDC")> _
    Public Shared Function GetWindowDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' 指定ウィンドウハンドルにおけるウィンドウのデバイスコンテキストを取得する
    ''' </summary>
    ''' <param name="hwnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="ReleaseDC")> _
    Public Shared Function ReleaseDC(ByVal hwnd As IntPtr, ByVal hDC As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' 指定ウィンドウハンドルにおけるウィンドウの左上と右下の座標を取得する
    ''' </summary>
    ''' <param name="hwnd"></param>
    ''' <param name="lpRect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="GetWindowRect")> _
    Public Shared Function GetWindowRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Integer
    End Function

    ''' <summary>
    ''' マウスの各イベントを発生させる
    ''' </summary>
    ''' <param name="dwFlags"></param>
    ''' <param name="dx"></param>
    ''' <param name="dy"></param>
    ''' <param name="dwData"></param>
    ''' <param name="dwExtraInfo"></param>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="mouse_event")> _
    Public Shared Sub MouseEvent(ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal dwData As Integer, ByVal dwExtraInfo As Integer)
    End Sub

    ''' <summary>
    ''' キーボードイベントを発生させる
    ''' </summary>
    ''' <param name="bVk"></param>
    ''' <param name="bScan"></param>
    ''' <param name="dwFlags"></param>
    ''' <param name="dwExtraInfo"></param>
    ''' <remarks></remarks>
    <DllImport("user32", EntryPoint:="keybd_event")> _
    Public Shared Sub KeybdEvent(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    End Sub

    ''' <summary>
    ''' マウス、キーボード、ハードウェアの動作をシミュレートする
    ''' </summary>
    ''' <param name="nInputs"></param>
    ''' <param name="pInputs"></param>
    ''' <param name="cbsize"></param>
    ''' <remarks></remarks>
    <DllImport("user32.dll", EntryPoint:="SendInput")> _
    Public Shared Sub SendInput(ByVal nInputs As Integer, ByRef pInputs As INPUT, ByVal cbsize As Integer)
    End Sub

    ''' <summary>
    ''' 指定座標のRGBを取得する
    ''' </summary>
    ''' <param name="hdc"></param>
    ''' <param name="nXPos"></param>
    ''' <param name="nYPos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("gdi32", EntryPoint:="GetPixel")> _
    Public Shared Function GetPixel(hdc As IntPtr, nXPos As Integer, nYPos As Integer) As UInteger
    End Function

    ''' <summary>
    ''' 仮想キーコードをスキャンコードに変換
    ''' </summary>
    ''' <param name="wCode"></param>
    ''' <param name="wMapType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32.dll", EntryPoint:="MapVirtualKeyA")> _
    Public Shared Function MapVirtualKeyA(ByVal wCode As Integer, ByVal wMapType As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="GetSystemMetrics")> _
    Public Shared Function GetSystemMetrics(ByVal nIndex As Integer) As Integer
    End Function

#End Region

#Region "ラッパー"

    ''' <summary>
    ''' マウスをクリックさせる
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub MouseClick(e As MouseButtons)

        Dim inp As INPUT() = New INPUT(3 - 1) {}

        If e = MouseButtons.Left Then

            Win32API.MouseEvent(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

        ElseIf e = MouseButtons.Middle Then

            Win32API.MouseEvent(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0)

        ElseIf e = MouseButtons.Right Then

            Win32API.MouseEvent(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)

        End If

    End Sub

    ''' <summary>
    ''' マウスをダブルクリックさせる
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub MouseDoubleClick(e As MouseButtons)

        Dim inp As INPUT() = New INPUT(3 - 1) {}

        If e = MouseButtons.Left Then

            Win32API.MouseEvent(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

        ElseIf e = MouseButtons.Middle Then

            Win32API.MouseEvent(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0)

        ElseIf e = MouseButtons.Right Then

            Win32API.MouseEvent(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)

            Win32API.MouseEvent(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)

        End If

    End Sub

    ''' <summary>
    ''' マウスをドラッグ開始終了させる
    ''' </summary>
    ''' <param name="e1"></param>
    ''' <param name="e2"></param>
    ''' <remarks></remarks>
    Public Shared Sub MouseDrag(e1 As MouseButtons, e2 As DragPlays)

        If e1 = MouseButtons.Left Then

            If e2 = DragPlays.DragStart Then

                Win32API.MouseEvent(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)

            Else

                Win32API.MouseEvent(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

            End If

        ElseIf e1 = MouseButtons.Middle Then

            If e2 = DragPlays.DragStart Then

                Win32API.MouseEvent(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0)

            Else

                Win32API.MouseEvent(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0)

            End If

        ElseIf e1 = MouseButtons.Right Then

            If e2 = DragPlays.DragStart Then

                Win32API.MouseEvent(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)

            Else

                Win32API.MouseEvent(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)

            End If

        End If

    End Sub

    ''' <summary>
    ''' マウスマウスカーソルを指定座標に移動する。
    ''' SetCursorPosと違ってドラッグ対応
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <remarks></remarks>
    Public Shared Sub MouseMove(x As Integer, y As Integer)

        Dim pos As System.Drawing.Point = GetAbsolutePos(x, y)

        Win32API.MouseEvent(MOUSEEVENTF_MOVE Or MOUSEEVENTF_ABSOLUTE, pos.X, pos.Y, 0, 0)

    End Sub

    ''' <summary>
    ''' MouseEventで移動させる際の座標の絶対値を取得する
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAbsolutePos(x As Integer, y As Integer) As System.Drawing.Point

        Dim ret As New System.Drawing.Point

        ret.X = x * (65535 / GetSystemMetrics(SM_CXSCREEN))

        ret.Y = y * (65535 / GetSystemMetrics(SM_CYSCREEN))

        Return ret

    End Function

    ''' <summary>
    ''' ホイールを回転させる
    ''' </summary>
    ''' <param name="state"></param>
    ''' <param name="val"></param>
    ''' <remarks></remarks>
    Public Shared Sub WheelMove(state As WheelMoves, val As Integer)

        If state = WheelMoves.Up Then

            Win32API.MouseEvent(MOUSEEVENTF_WHEEL, 0, 0, val, 0)

        Else

            Win32API.MouseEvent(MOUSEEVENTF_WHEEL, 0, 0, -1 * val, 0)

        End If

    End Sub

    ''' <summary>
    ''' キーを押しまたは離しする
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="plays"></param>
    ''' <remarks></remarks>
    Public Shared Sub KeyPlay(key As Integer, plays As KeyPlays)

        Select Case (plays)

            Case KeyPlays.Up

                Win32API.KeybdEvent(key, 0, Win32API.KEYEVENTF_KEYUP, 0)

            Case KeyPlays.Down

                Win32API.KeybdEvent(key, 0, Win32API.KEYEVENTF_KEYDOWN, 0)

        End Select

    End Sub

#End Region

End Class
