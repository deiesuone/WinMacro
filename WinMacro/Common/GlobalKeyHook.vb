Imports System.Windows.Forms
Imports System.Runtime.InteropServices

''' <summary>
''' Keyイベント用引数クラス
''' </summary>
''' <remarks></remarks>
Public Class GlobalKeyHookKeyEventArgs
    Inherits EventArgs

    Public Property Key As Keys

    Public Sub New(key As Keys)
        Me.Key = key
    End Sub

End Class

Public Class GlobalKeyHook

#Region "Win32API"

#Region "定数"

    ''' <summary>
    ''' キーフック
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WH_KEYBOARD_LL As Integer = 13

    ''' <summary>
    ''' キー押下
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WM_KEYDOWN = &H100

    ''' <summary>
    ''' キー離し
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WM_KEYUP = &H101

    ''' <summary>
    ''' システムキー押下
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WM_SYSKEYDOWN = &H104

    ''' <summary>
    ''' システムキー離し
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WM_SYSKEYUP = &H105

#End Region

#Region "スタティック変数"

    ''' <summary>
    ''' フックのハンドラ
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared hHook As Integer = 0

#End Region

#Region "メンバ変数"

    ''' <summary>
    ''' キーキャプチャ時のコールバックプロシージャ
    ''' </summary>
    ''' <remarks></remarks>
    Private hookproc As NativeMethods.CallBack

#End Region

#Region "構造体"

    ' KeyboardHookStruct structure declaration.
    <StructLayout(LayoutKind.Sequential)>
    Public Structure KeyboardLLHookStruct
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

#End Region

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' フック取得
    ''' </summary>
    ''' <param name="prmFrm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Init(prmFrm As Window) As Boolean

        Try

            ' フック取得中かどうか
            If hHook = 0 Then

                ' コールバックを設定
                hookproc = AddressOf KeybordHookProc

                ' モジュールのハンドラを取得
                Dim moduel As IntPtr = NativeMethods.GetModuleHandle(IntPtr.Zero)

                ' フックを取得
                hHook = NativeMethods.SetWindowsHookEx(WH_KEYBOARD_LL, hookproc, moduel, 0)

                ' 取得できたかどうか
                If hHook = 0 Then

                    Return False

                End If

            End If

        Catch ex As Exception

            Return False

        End Try

        Return True
    End Function

    ''' <summary>
    ''' フック取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Close() As Boolean

        Try
            ' フック取得中かどうか
            If hHook <> 0 Then

                ' フックを破棄
                Dim ret As Boolean = NativeMethods.UnhookWindowsHookEx(hHook)

                ' 破棄出来たかどうか
                If Not ret Then
                    Return False
                End If

                ' ハンドラ初期化
                hHook = 0

            End If

        Catch ex As Exception

            Return False

        End Try

        Return True

    End Function

#End Region

#Region "コールバック"

#Region "イベント定義"

    ''' <summary>
    ''' キー押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Event KeyDown(sender As Object, e As GlobalKeyHookKeyEventArgs)

    ''' <summary>
    ''' キー離し
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Event KeyUp(sender As Object, e As GlobalKeyHookKeyEventArgs)

#End Region

#Region "静的メソッド"

    ''' <summary>
    ''' フックのコールバック
    ''' </summary>
    ''' <param name="nCode"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function KeybordHookProc(ByVal nCode As Integer _
                                           , ByVal wParam As IntPtr _
                                           , ByVal lParam As IntPtr) As Integer

        ' 押下または離し判定
        If wParam = WM_KEYDOWN Or wParam = WM_KEYUP Or wParam = WM_SYSKEYDOWN Or wParam = WM_SYSKEYUP Then

            Try

                ' コードが不明であればキー入力をスルー
                If (nCode < 0) Then

                    Return NativeMethods.CallNextHookEx(hHook, nCode, wParam, lParam)

                End If

                ' 構造体にキー情報を取得
                Dim hookStruct As KeyboardLLHookStruct = CType(Marshal.PtrToStructure(lParam, hookStruct.GetType()), KeyboardLLHookStruct)

                ' イベントによる場合分け
                If wParam = WM_KEYDOWN Or wParam = WM_SYSKEYDOWN Then

                    ' 押下イベントを発行する
                    RaiseEvent KeyDown(Nothing, New GlobalKeyHookKeyEventArgs(CType(hookStruct.vkCode, Keys)))

                ElseIf wParam = WM_KEYUP Or wParam = WM_SYSKEYUP Then

                    ' 離しイベントを発行する
                    RaiseEvent KeyUp(Nothing, New GlobalKeyHookKeyEventArgs(CType(hookStruct.vkCode, Keys)))

                End If

            Catch

            End Try

        End If

        ' キー入力をスルーする
        Return NativeMethods.CallNextHookEx(hHook, nCode, wParam, lParam)

    End Function

#End Region

#End Region

End Class

Friend NotInheritable Class NativeMethods

#Region "デリゲート"

    ''' <summary>
    ''' コールバックデリゲート
    ''' </summary>
    ''' <param name="nCode"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function CallBack(ByVal nCode As Integer _
                                      , ByVal wParam As IntPtr _
                                      , ByVal lParam As IntPtr) As Integer

#End Region

#Region "Win32API"

    ''' <summary>
    ''' SetWindowsHookEx
    ''' </summary>
    ''' <param name="idHook"></param>
    ''' <param name="HookProc"></param>
    ''' <param name="hInstance"></param>
    ''' <param name="wParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Friend Overloads Shared Function SetWindowsHookEx(ByVal idHook As Integer _
                                                          , ByVal HookProc As CallBack _
                                                          , ByVal hInstance As IntPtr _
                                                          , ByVal wParam As Integer) As Integer
    End Function

    ''' <summary>
    ''' CallNextHookEx
    ''' </summary>
    ''' <param name="idHook"></param>
    ''' <param name="nCode"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Friend Overloads Shared Function CallNextHookEx(ByVal idHook As Integer _
                                                        , ByVal nCode As Integer _
                                                        , ByVal wParam As IntPtr _
                                                        , ByVal lParam As IntPtr) As Integer
    End Function

    ''' <summary>
    ''' UnhookWindowsHookEx
    ''' </summary>
    ''' <param name="idHook"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Friend Overloads Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
    End Function

    ''' <summary>
    ''' GetModuleHandle
    ''' </summary>
    ''' <param name="lpModuleName"></param>
    ''' <returns></returns>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Overloads Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
    End Function

#End Region

End Class