﻿Imports System.ComponentModel

Public Class CommandType004
    Implements ICommandType

#Region "メンバ変数"

    ''' <summary>
    ''' データ保存用
    ''' </summary>
    ''' <remarks></remarks>
    Private _CommandTypeData As CommandType004Data

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
    ''' 引数で初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me._CommandTypeData = New CommandType004Data

        Me.SetData()

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <param name="command_type_data"></param>
    ''' <remarks></remarks>
    Public Sub New(command_type_data As CommandType004Data)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        If command_type_data Is Nothing Then

            Me._CommandTypeData = New CommandType004Data

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

        Me.PartsConditions1.GetData(Me._CommandTypeData.PartsConditions001Data1)

        Me.PartsConditions2.GetData(Me._CommandTypeData.PartsConditions002Data)

        Me.PartsConditions3.GetData(Me._CommandTypeData.PartsConditions001Data2)

        Me.PartsPlay1.GetData(Me._CommandTypeData.PartsPlay002Data1)

        Me.PartsPlay2.GetData(Me._CommandTypeData.PartsPlay002Data2)

        Me.PartsPlay3.GetData(Me._CommandTypeData.PartsPlay002Data3)

        Me.PartsPlay4.GetData(Me._CommandTypeData.PartsPlay002Data4)

        Me.PartsPlay5.GetData(Me._CommandTypeData.PartsPlay002Data5)

        Me.PartsPlay6.GetData(Me._CommandTypeData.PartsPlay002Data6)

        Me.PartsPlay7.GetData(Me._CommandTypeData.PartsPlay002Data7)

        Me.PartsPlay8.GetData(Me._CommandTypeData.PartsPlay002Data8)

    End Sub

    ''' <summary>
    ''' 入力データを各コントロールから取得する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetData() Implements ICommandType.GetData

        Me.PartsTiming.SetData()

        Me.PartsConditions1.SetData()

        Me.PartsConditions2.SetData()

        Me.PartsConditions3.SetData()

        Me.PartsPlay1.SetData()

        Me.PartsPlay2.SetData()

        Me.PartsPlay3.SetData()

        Me.PartsPlay4.SetData()

        Me.PartsPlay5.SetData()

        Me.PartsPlay6.SetData()

        Me.PartsPlay7.SetData()

        Me.PartsPlay8.SetData()

        Me._CommandTypeData.DisplayString = String.Concat(Me.PartsTiming.PartsData.DisplayString, Me.PartsConditions1.PartsData.DisplayString, Me.PartsConditions2.PartsData.DisplayString, Me.PartsConditions3.PartsData.DisplayString, Me.PartsPlay1.PartsData.DisplayString, Me.PartsPlay2.PartsData.DisplayString, Me.PartsPlay3.PartsData.DisplayString, Me.PartsPlay4.PartsData.DisplayString, Me.PartsPlay5.PartsData.DisplayString, Me.PartsPlay6.PartsData.DisplayString, Me.PartsPlay7.PartsData.DisplayString, Me.PartsPlay8.PartsData.DisplayString)

    End Sub

#End Region

End Class
