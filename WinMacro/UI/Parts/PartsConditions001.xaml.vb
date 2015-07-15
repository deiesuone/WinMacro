Public Class PartsConditions001
    Implements IParts

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

            Return Me.GrpConditions.Header

        End Get

        Set(value As String)

            Me.GrpConditions.Header = value

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
        Me.PartsData = New PartsConditions001Data

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <param name="parts_data"></param>
    ''' <remarks></remarks>
    Public Sub New(parts_data As PartsConditions001Data)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

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
    Private Sub CmbConditionsType_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CmbConditionsType.SelectionChanged

        Select Case CmbConditionsType.SelectedIndex

            Case PartsConditions001Data.CmbConditionsTypes.PointAColorAd

                If Me.GrpPointA IsNot Nothing Then Me.GrpPointA.Visibility = Windows.Visibility.Visible

                If Me.GrpColorA IsNot Nothing Then Me.GrpColorA.Visibility = Windows.Visibility.Visible

            Case PartsConditions001Data.CmbConditionsTypes.PointNowColorAd

                If Me.GrpPointA IsNot Nothing Then Me.GrpPointA.Visibility = Windows.Visibility.Collapsed

                If Me.GrpColorA IsNot Nothing Then Me.GrpColorA.Visibility = Windows.Visibility.Visible

            Case PartsConditions001Data.CmbConditionsTypes.AlwaysExecuted

                If Me.GrpPointA IsNot Nothing Then Me.GrpPointA.Visibility = Windows.Visibility.Collapsed

                If Me.GrpColorA IsNot Nothing Then Me.GrpColorA.Visibility = Windows.Visibility.Collapsed

        End Select

    End Sub

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' データをコントロールに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub GetData() Implements IParts.GetData

        Select Case CmbConditionsType.SelectedIndex

            Case PartsConditions001Data.CmbConditionsTypes.PointAColorAd

                With DirectCast(Me.PartsData, PartsConditions001Data)

                    Me.CmbConditionsType.SelectedIndex = .CmbConditionsType

                    Me.TxtAX.Text = UtilValidate.ParseInteger(.TxtAX)

                    Me.TxtAY.Text = UtilValidate.ParseInteger(.TxtAY)

                    Me.TxtARGB.Text = UtilValidate.ParseColor(.TxtARGB)

                End With

            Case PartsConditions001Data.CmbConditionsTypes.PointNowColorAd

                With DirectCast(Me.PartsData, PartsConditions001Data)

                    Me.CmbConditionsType.SelectedIndex = .CmbConditionsType

                    Me.TxtARGB.Text = UtilValidate.ParseColor(.TxtARGB)

                End With

            Case PartsConditions001Data.CmbConditionsTypes.PointNowColorAd

                DirectCast(Me.PartsData, PartsConditions001Data).CmbConditionsType = Me.CmbConditionsType.SelectedIndex

        End Select

    End Sub

    ''' <summary>
    ''' データをコントロールに反映
    ''' 引数を所持データに用いる
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub GetData(parts_data As PartsConditions001Data)

        Me.PartsData = parts_data

        Me.GetData()

    End Sub

    ''' <summary>
    ''' コントロールをデータに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetData() Implements IParts.SetData

        Select Case Me.CmbConditionsType.SelectedIndex

            Case PartsConditions001Data.CmbConditionsTypes.PointAColorAd

                With DirectCast(Me.PartsData, PartsConditions001Data)

                    .CmbConditionsType = Me.CmbConditionsType.SelectedIndex

                    .TxtAX = UtilValidate.ParseInteger(Me.TxtAX.Text)

                    .TxtAY = UtilValidate.ParseInteger(Me.TxtAY.Text)

                    .TxtARGB = UtilValidate.ParseColor(Me.TxtARGB.Text)

                End With

            Case PartsConditions001Data.CmbConditionsTypes.PointNowColorAd

                With DirectCast(Me.PartsData, PartsConditions001Data)

                    .CmbConditionsType = Me.CmbConditionsType.SelectedIndex

                    .TxtARGB = UtilValidate.ParseColor(Me.TxtARGB.Text)

                End With

            Case PartsConditions001Data.CmbConditionsTypes.AlwaysExecuted

                DirectCast(Me.PartsData, PartsConditions001Data).CmbConditionsType = Me.CmbConditionsType.SelectedIndex

        End Select

    End Sub

#End Region

End Class
