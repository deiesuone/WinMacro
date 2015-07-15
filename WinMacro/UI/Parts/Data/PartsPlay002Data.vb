Imports System.Collections.ObjectModel

<Serializable> _
Public Class PartsPlay002Data
    Implements IPartsData

#Region "Enum"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CmbPlays

        ''' <summary>
        ''' ミリ秒何もしない
        ''' </summary>
        ''' <remarks></remarks>
        WaitMilliSeconds

        ''' <summary>
        ''' 左クリック
        ''' </summary>
        ''' <remarks></remarks>
        LeftClick

        ''' <summary>
        ''' 右クリック
        ''' </summary>
        ''' <remarks></remarks>
        RightClick

        ''' <summary>
        ''' ホイールクリック
        ''' </summary>
        ''' <remarks></remarks>
        WheelClick

        ''' <summary>
        ''' 左ダブルクリック
        ''' </summary>
        ''' <remarks></remarks>
        LeftDoubleClick

        ''' <summary>
        ''' 右ダブルクリック
        ''' </summary>
        ''' <remarks></remarks>
        RightDoubleClick

        ''' <summary>
        ''' ホイールダブルクリック
        ''' </summary>
        ''' <remarks></remarks>
        WheelDoubleClick

        ''' <summary>
        ''' ホイールを上方向に回転する
        ''' </summary>
        ''' <remarks></remarks>
        WheelRoleUp

        ''' <summary>
        ''' ホイールを下方向に回転する
        ''' </summary>
        ''' <remarks></remarks>
        WheelRoleDown

        ''' <summary>
        ''' 左ドラッグを開始する
        ''' </summary>
        ''' <remarks></remarks>
        LeftDragStart

        ''' <summary>
        ''' 左ドラッグを終了する
        ''' </summary>
        ''' <remarks></remarks>
        LeftDragEnd

        ''' <summary>
        ''' 右ドラッグを開始する
        ''' </summary>
        ''' <remarks></remarks>
        RightDragStart

        ''' <summary>
        ''' 右ドラッグを終了する
        ''' </summary>
        ''' <remarks></remarks>
        RightDragEnd

        ''' <summary>
        ''' ホイールドラッグを開始する
        ''' </summary>
        ''' <remarks></remarks>
        WheelDragStart

        ''' <summary>
        ''' ホイールドラッグを終了する
        ''' </summary>
        ''' <remarks></remarks>
        WheelDragEnd

        ''' <summary>
        ''' キー入力を行う
        ''' </summary>
        ''' <remarks></remarks>
        KeyInput

        ''' <summary>
        ''' マウスカーソルを座標A'に移動する
        ''' </summary>
        ''' <remarks></remarks>
        MoveMouse

    End Enum

#End Region


#Region "プロパティ"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CmbPlayType As CmbPlays = CmbPlays.WaitMilliSeconds

    ''' <summary>
    ''' 座標A'のX
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtAdX As Integer = 0

    ''' <summary>
    ''' 座標A'のY
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtAdY As Integer = 0

    ''' <summary>
    ''' ホイールの移動量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtWheelVal As Integer = 0

    ''' <summary>
    ''' ミリ秒Wait
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtWaitMilliSeconds As Integer = 0

    ''' <summary>
    ''' キー入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KeyInputData As New ObservableCollection(Of StractInputKeyData)

    ''' <summary>
    ''' グリッドに表示する詳細
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayString As String Implements IPartsData.DisplayString
        Get

            Dim ret As String = String.Empty

            Select Case Me.CmbPlayType

                Case CmbPlays.WaitMilliSeconds

                    If Me.TxtWaitMilliSeconds = 0 Then

                        ret = "何もしない。"

                    Else

                        ret = String.Concat(Me.TxtWaitMilliSeconds, "ミリ秒何もしない。")

                    End If

                Case CmbPlays.LeftClick

                    ret = String.Concat("左クリックする。")

                Case CmbPlays.RightClick

                    ret = String.Concat("右クリックする。")

                Case CmbPlays.WheelClick

                    ret = String.Concat("ホイールクリックする。")

                Case CmbPlays.LeftDoubleClick

                    ret = String.Concat("左ダブルクリックする。")

                Case CmbPlays.RightDoubleClick

                    ret = String.Concat("右ダブルクリックする。")

                Case CmbPlays.WheelDoubleClick

                    ret = String.Concat("ホイールダブルクリックする。")

                Case CmbPlays.WheelRoleUp

                    ret = String.Concat("ホイールを上方向に移動量", Me.TxtWheelVal, "回転する。")

                Case CmbPlays.WheelRoleDown

                    ret = String.Concat("ホイールを下方向に移動量", Me.TxtWheelVal, "回転する。")

                Case CmbPlays.LeftDragStart

                    ret = String.Concat("左ドラッグを開始する。")

                Case CmbPlays.LeftDragEnd

                    ret = String.Concat("左ドラッグを終了する。")

                Case CmbPlays.RightDragStart

                    ret = String.Concat("右ドラッグを開始する。")

                Case CmbPlays.RightDragEnd

                    ret = String.Concat("右ドラッグを終了する。")

                Case CmbPlays.WheelDragStart

                    ret = String.Concat("ホイールドラッグを開始する。")

                Case CmbPlays.WheelDragEnd

                    ret = String.Concat("ホイールドラッグを終了する。")

                Case CmbPlays.KeyInput

                    ret = "キー入力("

                    Dim ret2 As String = String.Empty

                    For i As Integer = 0 To Me.KeyInputData.Count - 1

                        If ret2 <> String.Empty Then ret2 = String.Concat(ret2, ", ")

                        ret2 = String.Concat(ret2, Me.KeyInputData(i).KeyEventName, ":", Me.KeyInputData(i).KeyName)

                        If i = 4 And Me.KeyInputData.Count > 5 Then

                            ret2 = String.Concat(ret2, "…以下略")

                            Exit For

                        End If

                    Next

                    If Me.KeyInputData.Count = 0 Then

                        ret = String.Concat(ret, "キー未入力)を行う。")

                    Else

                        ret = String.Concat(ret, ret2, ")を行う。")

                    End If

                Case CmbPlays.MoveMouse

                    ret = String.Concat("マウスカーソルを座標(", Me.TxtAdX, ",", Me.TxtAdY, ")に移動する。")

            End Select

            Return ret

        End Get

    End Property

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' 動作
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Play()

        ' 結果判定
        Select Case Me.CmbPlayType

            Case PartsPlay002Data.CmbPlays.WaitMilliSeconds

                System.Threading.Thread.Sleep(Me.TxtWaitMilliSeconds)

            Case PartsPlay002Data.CmbPlays.LeftClick

                Win32API.MouseClick(Win32API.MouseButtons.Left)

            Case PartsPlay002Data.CmbPlays.RightClick

                Win32API.MouseClick(Win32API.MouseButtons.Right)

            Case PartsPlay002Data.CmbPlays.WheelClick

                Win32API.MouseClick(Win32API.MouseButtons.Middle)

            Case PartsPlay002Data.CmbPlays.LeftDoubleClick

                Win32API.MouseDoubleClick(Win32API.MouseButtons.Left)

            Case PartsPlay002Data.CmbPlays.RightDoubleClick

                Win32API.MouseDoubleClick(Win32API.MouseButtons.Right)

            Case PartsPlay002Data.CmbPlays.WheelDoubleClick

                Win32API.MouseDoubleClick(Win32API.MouseButtons.Middle)

            Case PartsPlay002Data.CmbPlays.WheelRoleUp

                Win32API.WheelMove(Win32API.WheelMoves.Up, Me.TxtWheelVal)

            Case PartsPlay002Data.CmbPlays.WheelRoleDown

                Win32API.WheelMove(Win32API.WheelMoves.Down, Me.TxtWheelVal)

            Case PartsPlay002Data.CmbPlays.LeftDragStart

                Win32API.MouseDrag(Win32API.MouseButtons.Left, Win32API.DragPlays.DragStart)

            Case PartsPlay002Data.CmbPlays.LeftDragEnd

                Win32API.MouseDrag(Win32API.MouseButtons.Left, Win32API.DragPlays.DragEnd)

            Case PartsPlay002Data.CmbPlays.RightDragStart

                Win32API.MouseDrag(Win32API.MouseButtons.Right, Win32API.DragPlays.DragStart)

            Case PartsPlay002Data.CmbPlays.RightDragEnd

                Win32API.MouseDrag(Win32API.MouseButtons.Right, Win32API.DragPlays.DragEnd)

            Case PartsPlay002Data.CmbPlays.WheelDragStart

                Win32API.MouseDrag(Win32API.MouseButtons.Middle, Win32API.DragPlays.DragStart)

            Case PartsPlay002Data.CmbPlays.WheelDragEnd

                Win32API.MouseDrag(Win32API.MouseButtons.Middle, Win32API.DragPlays.DragEnd)

            Case PartsPlay002Data.CmbPlays.KeyInput

                For Each item In Me.KeyInputData

                    item.Play()

                Next

            Case PartsPlay002Data.CmbPlays.MoveMouse

                Win32API.MouseMove(Me.TxtAdX, Me.TxtAdY)

        End Select

    End Sub

#End Region

End Class
