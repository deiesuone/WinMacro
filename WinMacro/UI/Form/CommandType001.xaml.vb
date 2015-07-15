Imports System.ComponentModel

Public Class CommandType001
    Implements ICommandType

#Region "メンバ変数"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <remarks></remarks>
    Private _CommandTypeData As CommandType001Data

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommandTypeData As ICommandTypeData Implements ICommandType.CommandTypeData

        Get

            Me.GetData()

            Return Me._CommandTypeData

        End Get

        Set(value As ICommandTypeData)

            Me._CommandTypeData = value

            Me.SetData()

        End Set

    End Property

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me._CommandTypeData = New CommandType001Data

        Me.SetData()

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <param name="command_type_data"></param>
    ''' <remarks></remarks>
    Public Sub New(command_type_data As CommandType001Data)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        If command_type_data Is Nothing Then

            Me._CommandTypeData = New CommandType001Data

        Else

            Me._CommandTypeData = command_type_data

        End If

        Me.SetData()

    End Sub

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' 入力データを各コントロールに反映する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetData() Implements ICommandType.SetData

        Me.PartsTiming.GetData(Me._CommandTypeData.PartsTiming001Data)

        Me.PartsConditions.GetData(Me._CommandTypeData.PartsConditions001Data)

        Me.PartsPlay.GetData(Me._CommandTypeData.PartsPlay001Data)

    End Sub

    ''' <summary>
    ''' 入力データを各コントロールから取得する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetData() Implements ICommandType.GetData

        Me.PartsTiming.SetData()

        Me.PartsConditions.SetData()

        Me.PartsPlay.SetData()

        Me._CommandTypeData.PartsTiming001Data = Me.PartsTiming.PartsData

        Me._CommandTypeData.PartsConditions001Data = Me.PartsConditions.PartsData

        Me._CommandTypeData.PartsPlay001Data = Me.PartsPlay.PartsData

        Me._CommandTypeData.DisplayString = String.Concat(Me.PartsTiming.PartsData.DisplayString, Me.PartsConditions.PartsData.DisplayString, Me.PartsPlay.PartsData.DisplayString)

    End Sub

#End Region

End Class
