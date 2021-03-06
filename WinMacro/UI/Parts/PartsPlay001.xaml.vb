﻿Public Class PartsPlay001
    Implements IParts

#Region "メンバ変数"

    ''' <summary>
    ''' キーフック
    ''' </summary>
    ''' <remarks></remarks>
    Private GlobalKeyHooker As GlobalKeyHook

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PartsData As IPartsData Implements IParts.PartsData

    ''' <summary>
    ''' ヘッダー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Header As String Implements IParts.Header

        Get

            Return Me.GrpPartsPlay.Header

        End Get

        Set(value As String)

            Me.GrpPartsPlay.Header = value

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

        Me.GlobalKeyHooker = New GlobalKeyHook

        Me.PartsData = New PartsPlay001Data

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(parts_data As PartsPlay001Data)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.GlobalKeyHooker = New GlobalKeyHook

        Me.PartsData = parts_data

    End Sub

#End Region

#Region "イベント"

    ''' <summary>
    ''' コンボボックス選択時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbPlayType_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CmbPlayType.SelectionChanged

        Select Case DirectCast(Me.CmbPlayType.SelectedIndex, PartsPlay001Data.CmbPlays)

            Case PartsPlay001Data.CmbPlays.None

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

            Case PartsPlay001Data.CmbPlays.KeyInput

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Visible

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

            Case Else

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Visible

        End Select

    End Sub

    ''' <summary>
    ''' キー入力開始ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnKeyInput_Click(sender As Object, e As RoutedEventArgs) Handles BtnKeyInput.Click

        With DirectCast(Me.PartsData, PartsPlay001Data)

            Me.SetData()

            Dim win As New InputForm(.KeyInputData)

            win.ShowDialog()

            .KeyInputData = win.InputData

            Me.GetData()

        End With

    End Sub

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' データをコントロールに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub GetData() Implements IParts.GetData

        With DirectCast(Me.PartsData, PartsPlay001Data)

            Me.CmbPlayType.SelectedIndex = UtilValidate.ParseInteger(.CmbPlayType)

            Me.TxtAdX.Text = UtilValidate.ParseInteger(.TxtAdX)

            Me.TxtAdY.Text = UtilValidate.ParseInteger(.TxtAdY)

            If .KeyInputData.Count = 0 Then

                Me.TbkKeyInput.Text = "入力データ無し"

            Else

                Me.TbkKeyInput.Text = "入力データ有り"

            End If

        End With

    End Sub

    ''' <summary>
    ''' データをコントロールに反映
    ''' 引数を所持データに用いる
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub GetData(parts_data As PartsPlay001Data)

        Me.PartsData = parts_data

        Me.GetData()

    End Sub

    ''' <summary>
    ''' コントロールをデータに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetData() Implements IParts.SetData

        With DirectCast(Me.PartsData, PartsPlay001Data)

            .CmbPlayType = Me.CmbPlayType.SelectedIndex

            .TxtAdX = UtilValidate.ParseInteger(Me.TxtAdX.Text)

            .TxtAdY = UtilValidate.ParseInteger(Me.TxtAdY.Text)

        End With

    End Sub

#End Region

End Class
