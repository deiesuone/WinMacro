Public Class SchemaLogic

#Region "プロパティ"

    ''' <summary>
    ''' idカラム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Id As Integer

    ''' <summary>
    ''' command_typeカラム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommandType As Integer

    ''' <summary>
    ''' command_typeの表示名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommandTypeName As String

    ''' <summary>
    ''' messageカラム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message As String

    ''' <summary>
    ''' srialize_commandカラム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SrializeCommand As Byte()

    ''' <summary>
    ''' sortカラム
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sort As Integer

#End Region

#Region "Enum"

    ''' <summary>
    ''' command_typeの表示名
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CommandTypes

        コマンド001

        コマンド002

        コマンド003

        コマンド004

    End Enum

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="command_type"></param>
    ''' <param name="message"></param>
    ''' <param name="srialize_command"></param>
    ''' <param name="sort"></param>
    ''' <remarks></remarks>
    Public Sub New(id As Integer, command_type As Integer, message As String, srialize_command As Byte(), sort As Integer)

        Me.Id = id

        Me.CommandType = command_type

        Me.CommandTypeName = GetCommandTypeName(command_type)

        Me.Message = message

        Me.SrializeCommand = srialize_command

        Me.Sort = sort

    End Sub

#End Region

#Region "非公開メソッド"

    ''' <summary>
    ''' command_typeの表示名を取得する
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCommandTypeName(val As Integer) As String

        Return [Enum].GetName(GetType(CommandTypes), val)

    End Function

#End Region

End Class
