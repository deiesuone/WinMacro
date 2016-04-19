Imports System.Collections.ObjectModel

Public Class InputForm

#Region "メンバ変数"

    ''' <summary>
    ''' キーフック
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents GlobalKeyHooker As GlobalKeyHook

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <remarks></remarks>
    Private _InputData As ObservableCollection(Of StractInputKeyData)

    ''' <summary>
    ''' 入力データのバッファ
    ''' </summary>
    ''' <remarks></remarks>
    Private InputDataBuff As ObservableCollection(Of StractInputKeyData)

    ''' <summary>
    ''' 開始しているかどうか
    ''' </summary>
    ''' <remarks></remarks>
    Private IsStart As Boolean = False

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property InputData As ObservableCollection(Of StractInputKeyData)

        Get

            Return Me._InputData

        End Get

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

        Me.GlobalKeyHooker.Init(Me)

        Me._InputData = New ObservableCollection(Of StractInputKeyData)

        Me.InputDataBuff = New ObservableCollection(Of StractInputKeyData)

        Me.DgdInputKey.ItemsSource = New ObservableCollection(Of StractInputKeyData)

        Me.TbkPressUpdate()

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="input_data"></param>
    ''' <remarks></remarks>
    Public Sub New(input_data As ObservableCollection(Of StractInputKeyData))

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.GlobalKeyHooker = New GlobalKeyHook

        Me.GlobalKeyHooker.Init(Me)

        Me._InputData = New ObservableCollection(Of StractInputKeyData)(input_data)

        Me.InputDataBuff = New ObservableCollection(Of StractInputKeyData)(input_data)

        Me.DgdInputKey.ItemsSource = New ObservableCollection(Of StractInputKeyData)

        Me.TbkPressUpdate()

    End Sub

#End Region

#Region "イベント"

    ''' <summary>
    ''' 開始停止ボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbnStartStop_Click(sender As Object, e As RoutedEventArgs) Handles TbnStartStop.Click

        If Me.IsStart Then

            Me.TbnStartStop.Content = "入力開始"

            Me.Background = Brushes.White

        Else

            Me.TbnStartStop.Content = "入力停止"

            Me.Background = Brushes.LightPink

        End If

        Me.IsStart = Not Me.IsStart

    End Sub

    ''' <summary>
    ''' 保存して終了押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSave_Click(sender As Object, e As RoutedEventArgs) Handles BtnSave.Click

        Me._InputData = Me.InputDataBuff

        Me.Close()

    End Sub

    ''' <summary>
    ''' 保存せずに終了押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnNoSave_Click(sender As Object, e As RoutedEventArgs) Handles BtnNoSave.Click

        Me.Close()

    End Sub

    ''' <summary>
    ''' グローバルフックのキー押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GlobalKeyHooker_KeyDown(sender As Object, e As GlobalKeyHookKeyEventArgs) Handles GlobalKeyHooker.KeyDown

        If Not Me.IsStart Then Return

        Me.InputDataBuff.Add(New StractInputKeyData(Win32API.KeyPlays.Down, e.Key, Me.InputDataBuff.Count + 1))

        Me.TbkPressUpdate()

    End Sub

    ''' <summary>
    ''' グローバルフックのキー離しイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GlobalKeyHooker_KeyUp(sender As Object, e As GlobalKeyHookKeyEventArgs) Handles GlobalKeyHooker.KeyUp

        If Not Me.IsStart Then Return

        Me.InputDataBuff.Add(New StractInputKeyData(Win32API.KeyPlays.Up, e.Key, Me.InputDataBuff.Count + 1))

        Me.TbkPressUpdate()

    End Sub

    ''' <summary>
    ''' 削除ボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelete_Click(sender As Object, e As RoutedEventArgs) Handles BtnDelete.Click

        If Me.InputDataBuff.Count > 0 Then Me.InputDataBuff.Remove(Me.DgdInputKey.SelectedItem)

        For i As Integer = 1 To Me.InputDataBuff.Count

            Me.InputDataBuff(i - 1).Index = i

        Next

        Me.TbkPressUpdate()

    End Sub

    ''' <summary>
    ''' クリアボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClear_Click(sender As Object, e As RoutedEventArgs) Handles BtnClear.Click

        Me.InputDataBuff.Clear()

        Me.TbkPressUpdate()

    End Sub

    ''' <summary>
    ''' ウィンドウを閉じる前イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InputForm_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Closing

        ' キーフックの参照を外す
        Me.GlobalKeyHooker = Nothing

    End Sub

#End Region

#Region "非公開メソッド"

    ''' <summary>
    ''' 入力履歴のアップデート
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TbkPressUpdate()

        With DirectCast(Me.DgdInputKey.ItemsSource, ObservableCollection(Of StractInputKeyData))

            .Clear()

            Dim index = Me.DgdInputKey.SelectedIndex

            For Each tmp In Me.InputDataBuff.Reverse

                .Add(tmp)

            Next

            If .Count > 0 Then Me.DgdInputKey.SelectedIndex = index

            If .Count > 0 And Me.DgdInputKey.SelectedIndex = -1 Then Me.DgdInputKey.SelectedIndex = 0

        End With

    End Sub

#End Region

End Class
