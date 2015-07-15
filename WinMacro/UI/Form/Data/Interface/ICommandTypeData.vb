Imports System.ComponentModel

Public Interface ICommandTypeData

#Region "プロパティ"

    ''' <summary>
    ''' グリッドに表示する詳細
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DisplayString As String

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 動作実行
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartCommand(bgw As BackgroundWorker)

#End Region

End Interface
