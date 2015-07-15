Imports System.Collections.ObjectModel

<Serializable> _
Public Class PartsPlay001Data
    Implements IPartsData

#Region "Enum"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CmbPlays

        ''' <summary>
        ''' 何もしない
        ''' </summary>
        ''' <remarks></remarks>
        None

        ''' <summary>
        ''' キー入力を行う
        ''' </summary>
        ''' <remarks></remarks>
        KeyInput

        ''' <summary>
        ''' カーソルの移動
        ''' </summary>
        ''' <remarks></remarks>
        PointChange

        ''' <summary>
        ''' 座標のクリック
        ''' </summary>
        ''' <remarks></remarks>
        PointClick

        ''' <summary>
        ''' 座標のダブルクリック
        ''' </summary>
        ''' <remarks></remarks>
        PointDoubleClick

        ''' <summary>
        ''' 座標をクリック後、元の位置に戻る
        ''' </summary>
        ''' <remarks></remarks>
        PointClickReturn

        ''' <summary>
        ''' 座標をダブルクリック後、元の位置に戻る
        ''' </summary>
        ''' <remarks></remarks>
        PointDoubleClickReturn

    End Enum

#End Region


#Region "プロパティ"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CmbPlayType As CmbPlays = CmbPlays.None

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

                Case CmbPlays.None

                    ret = "何もしない。"

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

                Case CmbPlays.PointChange

                    ret = String.Concat("座標(", Me.TxtAdX, ",", Me.TxtAdY, ")に移動する。")

                Case CmbPlays.PointClick

                    ret = String.Concat("座標(", Me.TxtAdX, ",", Me.TxtAdY, ")をクリックする。")

                Case CmbPlays.PointDoubleClick

                    ret = String.Concat("座標(", Me.TxtAdX, ",", Me.TxtAdY, ")をダブルクリックする。")

                Case CmbPlays.PointClickReturn

                    ret = String.Concat("座標(", Me.TxtAdX, ",", Me.TxtAdY, ")をクリックして元の座標に戻る。")

                Case CmbPlays.PointDoubleClickReturn

                    ret = String.Concat("座標(", Me.TxtAdX, ",", Me.TxtAdY, ")をダブルクリックして元の座標に戻る。")

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

            Case PartsPlay001Data.CmbPlays.None

            Case PartsPlay001Data.CmbPlays.KeyInput

                For Each item In Me.KeyInputData

                    item.Play()

                Next

            Case PartsPlay001Data.CmbPlays.PointChange

                Win32API.SetCursorPos(Me.TxtAdX, Me.TxtAdY)

            Case PartsPlay001Data.CmbPlays.PointClick

                UtilMacro.PointClick(Me.TxtAdX, Me.TxtAdY, Win32API.MouseButtons.Left)

            Case PartsPlay001Data.CmbPlays.PointDoubleClick

                UtilMacro.PointDoubleClick(Me.TxtAdX, Me.TxtAdY, Win32API.MouseButtons.Left)

            Case PartsPlay001Data.CmbPlays.PointClickReturn

                UtilMacro.PointClickReturn(Me.TxtAdX, Me.TxtAdY, Win32API.MouseButtons.Left)

            Case PartsPlay001Data.CmbPlays.PointDoubleClickReturn

                UtilMacro.PointDoubleClickReturn(Me.TxtAdX, Me.TxtAdY, Win32API.MouseButtons.Left)

        End Select

    End Sub

#End Region

End Class
