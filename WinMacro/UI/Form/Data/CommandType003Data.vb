Imports System.ComponentModel

<Serializable> _
Public Class CommandType003Data
    Implements ICommandTypeData

#Region "プロパティ"

    ''' <summary>
    ''' タイミングコントロール
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsTiming001Data As New PartsTiming001Data

    ''' <summary>
    ''' 条件コントロール1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsConditions001Data1 As New PartsConditions001Data

    ''' <summary>
    ''' 条件コントロール2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsConditions001Data2 As New PartsConditions001Data

    ''' <summary>
    ''' Or,And条件コントロール
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsConditions002Data As New PartsConditions002Data

    ''' <summary>
    ''' 動作コントロール1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsPlay001Data1 As New PartsPlay001Data

    ''' <summary>
    ''' 動作コントロール2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsPlay001Data2 As New PartsPlay001Data

    ''' <summary>
    ''' 動作コントロール3
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsPlay001Data3 As New PartsPlay001Data

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommandTypeData As ICommandTypeData

    ''' <summary>
    ''' グリッドに表示する詳細
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DisplayString As String Implements ICommandTypeData.DisplayString

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' 動作を開始する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartCommand(bgw As BackgroundWorker) Implements ICommandTypeData.StartCommand

        ' 待機判定
        If Not Me.PartsTiming001Data.Wait(bgw) Then Exit Sub

        ' 条件判定
        If Not Me.PartsConditions002Data.IsConditions(Me.PartsConditions001Data1.IsConditions, Me.PartsConditions001Data2.IsConditions) Then Exit Sub

        ' 結果判定
        Me.PartsPlay001Data1.Play()

        Me.PartsPlay001Data2.Play()

        Me.PartsPlay001Data3.Play()

    End Sub

#End Region

End Class
