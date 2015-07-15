Imports System.Collections.ObjectModel
Imports System.ComponentModel

Class MainWindow

#Region "Enum"

    ''' <summary>
    ''' 開始停止ステータス
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum StartStop

        ''' <summary>
        ''' 開始中
        ''' </summary>
        ''' <remarks></remarks>
        StatusStart

        ''' <summary>
        ''' 停止中
        ''' </summary>
        ''' <remarks></remarks>
        StatusStop

    End Enum

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' DgdLogicのソース
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property DgdLogicSorce As New ObservableCollection(Of SchemaLogic)

    ''' <summary>
    ''' 現在の開始停止のステータス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property StatusStartStop As StartStop = StartStop.StatusStop

    ''' <summary>
    ''' Altが押されているかどうか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsALTDown As Boolean = False

    ''' <summary>
    ''' F2が押されているかどうか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsF2Down As Boolean = False

#End Region

#Region "メンバ変数"

    ''' <summary>
    ''' BrushConverter、何度もインスタンス化するのも無駄なので。
    ''' </summary>
    ''' <remarks></remarks>
    Private BrshCon As New BrushConverter

    ''' <summary>
    ''' 常設座標取得用タイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents CheckTimer As New Timers.Timer With {.Interval = 100, .Enabled = True}

    ''' <summary>
    ''' 開始時のタイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents BgwTimer As New Timers.Timer With {.Interval = 1}

    ''' <summary>
    ''' バッググラウンド処理
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents Bgw As New BackgroundWorker With {.WorkerSupportsCancellation = True}

    ''' <summary>
    ''' キーフック
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents GlobalKeyHooker As New GlobalKeyHook

#End Region

#Region "デリゲート"

    ''' <summary>
    ''' 常設座標取得用デリゲート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Delegate Sub CheckTimerElapsedDelegate(sender As Object, e As Timers.ElapsedEventArgs)

    ''' <summary>
    ''' 行選択用デリゲート
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Delegate Sub SelectDgdLogicIndexDelegate(row As SchemaLogic)

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

        If Not IO.File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "Database", "WinMacro")) Then

            MessageBox.Show("\Database\WinMacroが無いよ！", My.Application.Info.ProductName, MessageBoxButton.OK, MessageBoxImage.Error)

            Application.Current.Shutdown()

            Exit Sub

        End If

        Me.TxtSort.Text = 1

        Me.DgdLogic.ItemsSource = Me.DgdLogicSorce

        Me.DgdLogicUpdate()

        Me.GlobalKeyHooker.Init(Me)

    End Sub

#End Region

#Region "メニュー"

    ''' <summary>
    ''' メニュー開始or停止押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAltF2_Click(sender As Object, e As RoutedEventArgs) Handles MenuAltF2.Click

        Me.TbtnStartStop.IsChecked = Not Me.TbtnStartStop.IsChecked

        Me.TbtnStartStop_Click(Me.MenuAltF2, Nothing)

    End Sub

    ''' <summary>
    ''' メニュー終了押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuEnd_Click(sender As Object, e As RoutedEventArgs) Handles MenuEnd.Click

        Application.Current.Shutdown()

    End Sub

    ''' <summary>
    ''' メニュー常に最前面に表示押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuTopMost_Click(sender As Object, e As RoutedEventArgs) Handles MenuTopMost.Click

        Me.Topmost = Not Me.Topmost

        Me.MenuTopMost.IsChecked = Me.Topmost

    End Sub

    ''' <summary>
    ''' メニューハイライト押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuHightlight_Click(sender As Object, e As RoutedEventArgs) Handles MenuHighlight.Click

        Me.MenuHighlight.IsChecked = Not Me.MenuHighlight.IsChecked

        If Me.MenuHighlight.IsChecked Then MessageBox.Show(String.Concat("短時間で終わる命令ばかりの場合はチェックしないで下さい。", vbCrLf, "操作しづらくなります。", vbCrLf, "操作不能に陥った場合はAlt+F2による停止を行って下さい。"), My.Application.Info.ProductName, MessageBoxButton.OK, MessageBoxImage.Information)

    End Sub

    ''' <summary>
    ''' メニューバージョン情報押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuVersion_Click(sender As Object, e As RoutedEventArgs) Handles MenuVersion.Click

        With My.Application.Info

            MessageBox.Show(String.Concat(.ProductName, " v", .Version.Major, ".", .Version.Minor, ".", .Version.Build, ".", .Version.Revision, vbCrLf, vbCrLf, .Copyright), .ProductName, MessageBoxButton.OK, MessageBoxImage.Information)

        End With

    End Sub

#End Region

#Region "イベント"

    ''' <summary>
    ''' キーフックからのキー押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Hook_KeyDown(sender As Object, e As GlobalKeyHookKeyEventArgs) Handles GlobalKeyHooker.KeyDown

        If Application.Current.Windows.Count <> 1 Then Exit Sub

        If e.Key = Forms.Keys.LMenu Or e.Key = Forms.Keys.RMenu Then Me.IsALTDown = True

        If e.Key = Forms.Keys.F2 Then Me.IsF2Down = True

    End Sub

    ''' <summary>
    ''' キーフックからのキー離しイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Hook_KeyUp(sender As Object, e As GlobalKeyHookKeyEventArgs) Handles GlobalKeyHooker.KeyUp

        If Application.Current.Windows.Count <> 1 Then Return

        If e.Key = Forms.Keys.LMenu Or e.Key = Forms.Keys.RMenu Or e.Key = Forms.Keys.F2 Then

            If Me.IsALTDown And Me.IsF2Down Then

                Me.TbtnStartStop.IsChecked = Not Me.TbtnStartStop.IsChecked

                Me.TbtnStartStop_Click(Me.GlobalKeyHooker, Nothing)

            End If

        End If

        Me.IsALTDown = False

        Me.IsF2Down = False

    End Sub

    ''' <summary>
    ''' 行選択時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DgdLogic_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles DgdLogic.SelectionChanged

        If Not sender.Equals(Me.DgdLogic) Then

            Me.TxtSort.Text = 1

            Exit Sub

        End If

        If Me.DgdLogic.SelectedIndex = -1 Then

            Me.GrpCommandType.Content = UtilMacro.GetCommandTypeControl(Me.CmbCommandType.SelectedIndex)

            Me.TxtSort.Text = 1

        Else

            With DirectCast(Me.DgdLogic.SelectedItem, SchemaLogic)

                Me.CmbCommandType.SelectedIndex = .CommandType

                Me.TxtSort.Text = .Sort

                DirectCast(Me.GrpCommandType.Content, ICommandType).CommandTypeData = UtilMacro.ObjectDesirialize(.SrializeCommand)

            End With

        End If

    End Sub

    ''' <summary>
    ''' コンボボックス選択時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CmbCommandType_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CmbCommandType.SelectionChanged

        If Me.GrpCommandType Is Nothing Then Exit Sub

        If Me.DgdLogic.SelectedIndex = -1 _
        OrElse DirectCast(Me.DgdLogic.SelectedItem, SchemaLogic).CommandType <> Me.CmbCommandType.SelectedIndex Then

            Me.GrpCommandType.Content = UtilMacro.GetCommandTypeControl(Me.CmbCommandType.SelectedIndex)

        Else

            Dim command_data As ICommandTypeData = UtilMacro.ObjectDesirialize(DirectCast(Me.DgdLogic.SelectedItem, SchemaLogic).SrializeCommand)

            Me.GrpCommandType.Content = UtilMacro.GetCommandTypeControl(Me.CmbCommandType.SelectedIndex, command_data)

        End If

    End Sub

    ''' <summary>
    ''' 開始停止ボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbtnStartStop_Click(sender As Object, e As RoutedEventArgs) Handles TbtnStartStop.Click

        If Me.StatusStartStop = StartStop.StatusStop AndAlso Me.IsBusy Then

            Me.TbtnStartStop.IsChecked = False

            Exit Sub

        End If

        Me.DgdLogic.CanUserSortColumns = Not Me.DgdLogic.CanUserSortColumns

        Me.MenuRoot.IsEnabled = Not Me.MenuRoot.IsEnabled

        Me.BtnAdd.IsEnabled = Not Me.BtnAdd.IsEnabled

        Me.BtnDel.IsEnabled = Not Me.BtnDel.IsEnabled

        Me.BtnEdit.IsEnabled = Not Me.BtnEdit.IsEnabled

        Me.TxtSort.IsEnabled = Not Me.TxtSort.IsEnabled

        Me.CmbCommandType.IsEnabled = Not Me.CmbCommandType.IsEnabled

        Me.GrpCommandType.IsEnabled = Not Me.GrpCommandType.IsEnabled

        Select Case Me.StatusStartStop

            Case StartStop.StatusStart

                Me.StatusStartStop = StartStop.StatusStop

                Me.TbtnStartStop.Content = "開始(Alt+F2)"

                Me.MenuAltF2.Header = "開始(Alt+F2)"

                Me.BgwTimer.Stop()

                Me.Bgw.CancelAsync()

            Case StartStop.StatusStop

                Me.StatusStartStop = StartStop.StatusStart

                Me.TbtnStartStop.Content = "停止(Alt+F2)"

                Me.MenuAltF2.Header = "停止(Alt+F2)"

                Me.BgwTimer.Start()

        End Select

    End Sub

    ''' <summary>
    ''' 追加ボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAdd_Click(sender As Object, e As RoutedEventArgs) Handles BtnAdd.Click

        If Me.IsBusy Then Exit Sub

        With DirectCast(Me.GrpCommandType.Content, ICommandType)

            Using ad As New WinMacroDataSetTableAdapters.commandsTableAdapter

                ad.Connection.Open()

                ad.Insert(Me.CmbCommandType.SelectedIndex, .CommandTypeData.DisplayString, UtilMacro.ObjectSirialize(.CommandTypeData), UtilValidate.ParseInteger(Me.TxtSort.Text, 0, 65535))

                Me.DgdLogicUpdate(ad.Connection.LastInsertRowId)

                ad.Connection.Close()

            End Using

        End With

    End Sub

    ''' <summary>
    ''' 編集ボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnEdit_Click(sender As Object, e As RoutedEventArgs) Handles BtnEdit.Click

        If Me.DgdLogic.SelectedIndex = -1 Then Exit Sub

        If Me.IsBusy Then Exit Sub

        With DirectCast(Me.DgdLogic.SelectedItem, SchemaLogic)

            Using ad As New WinMacroDataSetTableAdapters.commandsTableAdapter

                ad.Update(Me.CmbCommandType.SelectedIndex _
                          , DirectCast(Me.GrpCommandType.Content, ICommandType).CommandTypeData.DisplayString _
                          , UtilMacro.ObjectSirialize(DirectCast(Me.GrpCommandType.Content, ICommandType).CommandTypeData) _
                          , UtilValidate.ParseInteger(Me.TxtSort.Text, 0, 65535) _
                          , .Id _
                          , .CommandType _
                          , .Message _
                          , .SrializeCommand _
                          , .Sort)

                Me.DgdLogicUpdate(.Id)

            End Using

        End With

    End Sub

    ''' <summary>
    ''' 削除ボタン押下時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDel_Click(sender As Object, e As RoutedEventArgs) Handles BtnDel.Click

        If Me.DgdLogic.SelectedIndex = -1 Then Exit Sub

        If Me.IsBusy Then Exit Sub

        Using ad As New WinMacroDataSetTableAdapters.commandsTableAdapter

            With DirectCast(Me.DgdLogic.SelectedItem, SchemaLogic)

                ad.Delete(.Id, .CommandType, .Message, .SrializeCommand, .Sort)

            End With

        End Using

        Dim index = Me.DgdLogic.SelectedIndex

        Me.DgdLogicUpdate()

        If Me.DgdLogic.Items.Count > index Then

            Me.DgdLogic.SelectedIndex = index

        Else

            If Me.DgdLogic.Items.Count <> 0 Then

                Me.DgdLogic.SelectedIndex = Me.DgdLogic.Items.Count - 1

            End If

        End If

    End Sub

    ''' <summary>
    ''' 常設座標取得タイマー経過時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckTimer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles CheckTimer.Elapsed

        Try

            Me.Dispatcher.BeginInvoke(New CheckTimerElapsedDelegate(AddressOf Me.CheckTimerElapsed), sender, e)

        Catch ex As NullReferenceException

        End Try

    End Sub

    ''' <summary>
    ''' 開始時タイマー経過時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BgwTimer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles BgwTimer.Elapsed

        If Not Me.Bgw.IsBusy Then Me.Bgw.RunWorkerAsync(Me.DgdLogicSorce)

    End Sub

    ''' <summary>
    ''' バックグラウンド処理開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles Bgw.DoWork

        For Each row As SchemaLogic In DirectCast(e.Argument, ObservableCollection(Of SchemaLogic))

            Me.Dispatcher.BeginInvoke(New SelectDgdLogicIndexDelegate(AddressOf Me.SelectDgdLogicIndex), row)

            Dim ctrl As ICommandTypeData = UtilMacro.ObjectDesirialize(row.SrializeCommand)

            If ctrl IsNot Nothing Then ctrl.StartCommand(Me.Bgw)

            If Me.Bgw.CancellationPending Then

                e.Cancel = True

                Exit For

            End If

        Next

    End Sub

    ''' <summary>
    ''' ウィンドウ終了時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Me.Bgw.CancelAsync()

        Me.BgwTimer.Stop()

        Me.CheckTimer.Stop()

        Me.GlobalKeyHooker.Close()

    End Sub

#End Region

#Region "非公開メソッド"

    ''' <summary>
    ''' 常設座標取得タイマー経過時動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckTimerElapsed(sender As Object, e As Timers.ElapsedEventArgs)

        Try

            Dim clr = UtilMacro.GetCursorRGB(Me.BrshCon)

            Dim point As System.Drawing.Point = UtilMacro.GetCursorPos()

            With Me.LblRGB

                .Background = New SolidColorBrush(clr)

                .Foreground = UtilMacro.ToBackColor(DirectCast(Me.LblRGB.Background, SolidColorBrush).Color)

                .Content = Me.LblRGB.Background.ToString.Substring(3, 6)

            End With

            Me.LblX.Content = point.X.ToString

            Me.LblY.Content = point.Y.ToString

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' データグリッド更新
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub DgdLogicUpdate(Optional id As Integer = 0)

        ' ソースを更新
        Using ad As New WinMacroDataSetTableAdapters.commandsTableAdapter

            Using dt As WinMacroDataSet.commandsDataTable = ad.GetDataBySort

                Me.DgdLogicSorce.Clear()

                For Each row In dt

                    Me.DgdLogicSorce.Add(New SchemaLogic(row.id, row.command_type, row.message, row.command_class, row.sort))

                Next

            End Using

        End Using

        ' 行選択
        If id = 0 Then

            If Me.DgdLogicSorce.Count > 0 Then Me.DgdLogic.SelectedIndex = 0

        Else

            For Each row As SchemaLogic In Me.DgdLogic.ItemsSource

                If row.Id = id Then

                    Me.DgdLogic.SelectedItem = row

                    Exit For

                End If

            Next

        End If

    End Sub

    ''' <summary>
    ''' バックグラウンド処理中かどうか
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsBusy() As Boolean

        If Me.Bgw.IsBusy Then

            MessageBox.Show(String.Concat("前回命令を実行中です。", vbCrLf, "しばらくお待ちください。"), My.Application.Info.ProductName, MessageBoxButton.OK, MessageBoxImage.Information)

            Return True

        End If

        Return False

    End Function

    ''' <summary>
    ''' 指定行を選択する
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub SelectDgdLogicIndex(row As SchemaLogic)

        If Me.MenuHighlight.IsChecked Then Me.DgdLogic.SelectedItem = row

    End Sub

#End Region

End Class
