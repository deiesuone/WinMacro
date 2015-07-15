Public Class PartsPlay002
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

        Me.PartsData = New PartsPlay002Data

        Me.LblWheelVal.Content = String.Concat("移動量", vbCrLf, "(1クリック = ", Win32API.WHEEL_DELTA, ")")

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(parts_data As PartsPlay002Data)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.GlobalKeyHooker = New GlobalKeyHook

        Me.PartsData = parts_data

        Me.LblWheelVal.Content = String.Concat("移動量", vbCrLf, "(1クリック = ", Win32API.WHEEL_DELTA, ")")

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

        Select Case DirectCast(Me.CmbPlayType.SelectedIndex, PartsPlay002Data.CmbPlays)

            Case PartsPlay002Data.CmbPlays.WaitMilliSeconds

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWheelVal IsNot Nothing Then Me.GrpWheelVal.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWaitMilliSeconds IsNot Nothing Then Me.GrpWaitMilliSeconds.Visibility = Windows.Visibility.Visible

            Case PartsPlay002Data.CmbPlays.KeyInput

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Visible

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWheelVal IsNot Nothing Then Me.GrpWheelVal.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWaitMilliSeconds IsNot Nothing Then Me.GrpWaitMilliSeconds.Visibility = Windows.Visibility.Collapsed

            Case PartsPlay002Data.CmbPlays.MoveMouse

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Visible

                If Me.GrpWheelVal IsNot Nothing Then Me.GrpWheelVal.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWaitMilliSeconds IsNot Nothing Then Me.GrpWaitMilliSeconds.Visibility = Windows.Visibility.Collapsed

            Case PartsPlay002Data.CmbPlays.WheelRoleUp

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWheelVal IsNot Nothing Then Me.GrpWheelVal.Visibility = Windows.Visibility.Visible

                If Me.GrpWaitMilliSeconds IsNot Nothing Then Me.GrpWaitMilliSeconds.Visibility = Windows.Visibility.Collapsed

            Case PartsPlay002Data.CmbPlays.WheelRoleDown

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWheelVal IsNot Nothing Then Me.GrpWheelVal.Visibility = Windows.Visibility.Visible

                If Me.GrpWaitMilliSeconds IsNot Nothing Then Me.GrpWaitMilliSeconds.Visibility = Windows.Visibility.Collapsed

            Case Else

                If Me.GrpInputKey IsNot Nothing Then Me.GrpInputKey.Visibility = Windows.Visibility.Collapsed

                If Me.GrpPointAd IsNot Nothing Then Me.GrpPointAd.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWheelVal IsNot Nothing Then Me.GrpWheelVal.Visibility = Windows.Visibility.Collapsed

                If Me.GrpWaitMilliSeconds IsNot Nothing Then Me.GrpWaitMilliSeconds.Visibility = Windows.Visibility.Collapsed

        End Select

    End Sub

    ''' <summary>
    ''' キー入力開始ボタン押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnKeyInput_Click(sender As Object, e As RoutedEventArgs) Handles BtnKeyInput.Click

        With DirectCast(Me.PartsData, PartsPlay002Data)

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

        With DirectCast(Me.PartsData, PartsPlay002Data)

            Me.CmbPlayType.SelectedIndex = UtilValidate.ParseInteger(.CmbPlayType)

            Me.TxtAdX.Text = UtilValidate.ParseInteger(.TxtAdX)

            Me.TxtAdY.Text = UtilValidate.ParseInteger(.TxtAdY)

            Me.TxtWheelVal.Text = UtilValidate.ParseInteger(.TxtWheelVal)

            Me.TxtWaitMilliSeconds.Text = UtilValidate.ParseInteger(.TxtWaitMilliSeconds)

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
    Public Overloads Sub GetData(parts_data As PartsPlay002Data)

        Me.PartsData = parts_data

        Me.GetData()

    End Sub

    ''' <summary>
    ''' コントロールをデータに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetData() Implements IParts.SetData

        With DirectCast(Me.PartsData, PartsPlay002Data)

            .CmbPlayType = Me.CmbPlayType.SelectedIndex

            .TxtAdX = UtilValidate.ParseInteger(Me.TxtAdX.Text)

            .TxtAdY = UtilValidate.ParseInteger(Me.TxtAdY.Text)

            .TxtWheelVal = UtilValidate.ParseInteger(Me.TxtWheelVal.Text)

            .TxtWaitMilliSeconds = UtilValidate.ParseInteger(Me.TxtWaitMilliSeconds.Text)

        End With

    End Sub

#End Region

End Class
