Imports System.ComponentModel

Public Interface ICommandType

#Region "プロパティ"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CommandTypeData As ICommandTypeData

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 入力データ取得
    ''' </summary>
    ''' <remarks></remarks>
    Sub GetData()

    ''' <summary>
    ''' 入力データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetData()

#End Region

End Interface
