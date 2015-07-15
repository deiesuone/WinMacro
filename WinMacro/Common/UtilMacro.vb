Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.ComponentModel

Public Class UtilMacro

#Region "デリゲート"

    ''' <summary>
    ''' コントロール作成用
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Delegate Function DelegateGetCommandTypeControlThreadSafe(type As SchemaLogic.CommandTypes, data As ICommandTypeData) As ICommandType

#End Region

#Region "静的メソッド"

    ''' <summary>
    ''' 現在座標のRGBを取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetCursorRGB(Optional bc As BrushConverter = Nothing) As Color

        Try

            Dim Point As System.Drawing.Point

            Dim Rect As Win32API.RECT

            Dim DC As Long

            Dim Wnd As Long

            Dim Clr As Long

            Dim StrColor As String

            Win32API.GetCursorPos(Point)

            Wnd = Win32API.WindowFromPoint(Point.X, Point.Y)

            DC = Win32API.GetWindowDC(Wnd)

            Win32API.GetWindowRect(Wnd, Rect)

            Clr = Win32API.GetPixel(DC, Point.X - Rect.left, Point.Y - Rect.top)

            Win32API.ReleaseDC(Wnd, DC)

            StrColor = Right("000000" + Hex(Clr), 6)

            If bc Is Nothing Then bc = New BrushConverter

            Dim chars = StrColor.ToCharArray

            Dim r As String = StrColor.Substring(4, 2)

            Dim g As String = StrColor.Substring(2, 2)

            Dim b As String = StrColor.Substring(0, 2)

            Dim scb As SolidColorBrush = bc.ConvertFromString(String.Concat("#FF", r, g, b))

            Return scb.Color

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 指定座標のRGBを取得する
    ''' </summary>
    ''' <param name="point"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetCursorRGB(point As System.Drawing.Point, Optional bc As BrushConverter = Nothing) As Color

        Try

            Dim Rect As Win32API.RECT

            Dim DC As Long

            Dim Wnd As Long

            Dim Clr As Long

            Dim StrColor As String

            Wnd = Win32API.WindowFromPoint(point.X, point.Y)

            DC = Win32API.GetWindowDC(Wnd)

            Win32API.GetWindowRect(Wnd, Rect)

            Clr = Win32API.GetPixel(DC, point.X - Rect.left, point.Y - Rect.top)

            Win32API.ReleaseDC(Wnd, DC)

            StrColor = Right("000000" + Hex(Clr), 6)

            If bc Is Nothing Then bc = New BrushConverter

            Dim chars = StrColor.ToCharArray

            Dim r As String = StrColor.Substring(4, 2)

            Dim g As String = StrColor.Substring(2, 2)

            Dim b As String = StrColor.Substring(0, 2)

            Dim scb As SolidColorBrush = bc.ConvertFromString(String.Concat("#FF", r, g, b))

            Return scb.Color

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 現在座標を取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCursorPos() As System.Drawing.Point

        Try

            Dim Point As New System.Drawing.Point

            Win32API.GetCursorPos(Point)

            Return Point

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 指定タイプのコントロールを指定データで初期化して取得する
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCommandTypeControl(type As SchemaLogic.CommandTypes, Optional data As ICommandTypeData = Nothing) As ICommandType

        Select Case type

            Case SchemaLogic.CommandTypes.コマンド001

                Return New CommandType001(data)

            Case SchemaLogic.CommandTypes.コマンド002

                Return New CommandType002(data)

            Case SchemaLogic.CommandTypes.コマンド003

                Return New CommandType003(data)

            Case SchemaLogic.CommandTypes.コマンド004

                Return New CommandType004(data)

        End Select

        Return Nothing

    End Function

    ''' <summary>
    ''' 指定オブジェクトをシリアライズする
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ObjectSirialize(obj As Object) As Byte()

        Using ms As New MemoryStream

            Dim bf As New BinaryFormatter

            bf.Serialize(ms, obj)

            Return ms.ToArray

        End Using

    End Function

    ''' <summary>
    ''' 指定バイト配列をデシリアライズする
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ObjectDesirialize(obj As Byte()) As Object

        Using ms As New MemoryStream

            Dim bf As New BinaryFormatter

            ms.Write(obj, 0, obj.Length)

            ms.Position = 0

            Return bf.Deserialize(ms)

        End Using

    End Function

    ''' <summary>
    ''' 背景色から見やすい文字色を取得する
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToBackColor(source As Color) As SolidColorBrush

        Dim bColor As Single = CSng(source.R * 299I + source.G * 587I + source.B * 114I) / 1000.0F

        If bColor > 127.5F Then

            Return New SolidColorBrush(Colors.Black)

        Else

            Return New SolidColorBrush(Colors.White)

        End If

    End Function

    ''' <summary>
    ''' 指定カラーの補色を取得する
    ''' BrushConverterを指定するとそのインスタンスを使用する
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="bc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToComplementaryColor(source As Color, Optional bc As BrushConverter = Nothing) As SolidColorBrush

        If bc Is Nothing Then bc = New BrushConverter

        Dim h As String = String.Concat("&h", source.ToString.Substring(3, 6))

        Dim xh As String = String.Concat("#FF", Right("00000" & Hex(&HFFFFFF Xor Val(h)), 6))

        Return bc.ConvertFromString(xh)

    End Function

    ''' <summary>
    ''' 指定座標をクリックする。
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="click"></param>
    ''' <remarks></remarks>
    Public Shared Sub PointClick(x As Integer, y As Integer, click As Win32API.MouseButtons)

        Win32API.SetCursorPos(x, y)

        Win32API.MouseClick(click)

    End Sub

    ''' <summary>
    ''' 指定座標をダブルクリックする。
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="click"></param>
    ''' <remarks></remarks>
    Public Shared Sub PointDoubleClick(x As Integer, y As Integer, click As Win32API.MouseButtons)

        Win32API.SetCursorPos(x, y)

        Win32API.MouseDoubleClick(click)

    End Sub

    ''' <summary>
    ''' 指定座標をクリックして元の座標に戻る。
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="click"></param>
    ''' <remarks></remarks>
    Public Shared Sub PointClickReturn(x As Integer, y As Integer, click As Win32API.MouseButtons)

        Dim point As System.Drawing.Point = UtilMacro.GetCursorPos()

        UtilMacro.PointClick(x, y, click)

        Win32API.SetCursorPos(point.X, point.Y)

    End Sub

    ''' <summary>
    ''' 指定座標をダブルクリックして元の座標に戻る。
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="click"></param>
    ''' <remarks></remarks>
    Public Shared Sub PointDoubleClickReturn(x As Integer, y As Integer, click As Win32API.MouseButtons)

        Dim point As System.Drawing.Point = UtilMacro.GetCursorPos()

        UtilMacro.PointDoubleClick(x, y, click)

        Win32API.SetCursorPos(point.X, point.Y)

    End Sub

#End Region

End Class
